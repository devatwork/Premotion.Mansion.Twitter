using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Premotion.Mansion.Http.BackoffStrategies;
using Premotion.Mansion.Http.ExceptionHandlers;
using Premotion.Mansion.Http.Streaming;
using Premotion.Mansion.Twitter.Models;

namespace Premotion.Mansion.Twitter.Streaming
{
	/// <summary>
	/// Handles the connection details for connection for a Twitter streaming API.
	/// </summary>
	/// <see href="https://dev.twitter.com/docs/streaming-apis/connecting"/>
	public class TwitterStreamingConnection : StreamingWebConnection<Message>
	{
		/// <summary>
		/// Constructs a new stream configuration using the given <paramref name="configuration"/>.
		/// </summary>
		/// <param name="configuration">The <see cref="TwitterHttpClientConfiguration"/> to configure the connection.</param>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="configuration"/> is null.</exception>
		public TwitterStreamingConnection(TwitterHttpClientConfiguration configuration) : base(TwitterHttpClient.Create(configuration))
		{
		}
		/// <summary>
		/// Returns a small random sample of all public statuses. The Tweets returned by the default access level are the same, so if two different clients connect to this endpoint, they will see the same Tweets.
		/// </summary>
		public async void ConnectToSampleStream()
		{
			// guard for disosed object
			CheckDisposed();

			// create the request message
			var request = new HttpRequestMessage(HttpMethod.Get, "https://stream.twitter.com/1.1/statuses/sample.json");

			// connect
			await Connect(request);
		}
		/// <summary>
		/// Returns public statuses that match one or more filter predicates. Multiple parameters may be specified which allows most clients to use a single connection to the Streaming API.
		/// </summary>
		public async void ConnectToStatusesFilter(StatusesFilter filter)
		{
			// validate arguments
			if (filter == null)
				throw new ArgumentNullException("filter");

			// guard for disosed object
			CheckDisposed();

			// create the request message
			var request = new HttpRequestMessage(HttpMethod.Post, "https://stream.twitter.com/1.1/statuses/filter.json");

			// add the body
			var bodyParameters = new Dictionary<string, string>();
			if (filter.Follow != null && filter.Follow.Length > 0)
				bodyParameters.Add("follow", string.Join(",", filter.Follow));
			if (filter.Locations != null && filter.Locations.Length > 0)
				bodyParameters.Add("locations", string.Join(",", filter.Locations.Select(location => string.Join(",", location))));
			if (filter.StallWarnings)
				bodyParameters.Add("stall_warnings", "true");
			if (filter.Track != null && filter.Track.Length > 0)
				bodyParameters.Add("track", string.Join(",", filter.Track));
			request.Content = new FormUrlEncodedContent(bodyParameters);
			request.Properties.Add(OAuthMessageHandler.OAuthParametersPropertyName, bodyParameters);

			// connect
			await Connect(request);
		}
		/// <summary>
		/// Fired when a response was received without an error.
		/// </summary>
		protected override void Connected()
		{
			socketExceptionHandler.Clear();
			rateLimitExceptionHandler.Clear();
			serviceUnavailableExceptionHandler.Clear();
		}
		/// <summary>
		/// Reads a <see cref="Message"/> from the given <paramref name="reader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="TextReader"/> from which to read the token.</param>
		/// <returns>Returns the parsed <see cref="Message"/>.</returns>
		protected override Message Read(TextReader reader)
		{
			// read a json string from the text reader
			var raw = reader.ReadLine();

			// parse the json into a token
			var token = JObject.Parse(raw);

			// try to parse the token
			var message = parsers.Select(parser => parser(token)).FirstOrDefault(parsed => parsed != null);
			if (message == null)
				throw new InvalidOperationException(string.Format("Unknown message: {0}", token.ToString(Formatting.Indented)));
			return message;
		}
		/// <summary>
		/// Tries the handle the given <paramref name="exception"/>.
		/// </summary>
		/// <param name="exception">The <see cref="Exception"/> which to try to handle.</param>
		/// <param name="reconnect">A callback invoked when a reconnection attempt can be made.</param>
		/// <returns>Returns true if the error is handled, otherwise false.</returns>
		protected override bool TryHandle(Exception exception, Func<Task> reconnect)
		{
			// error handling, https://dev.twitter.com/docs/streaming-apis/connecting#Reconnecting
			if (socketExceptionHandler.TryHandle(exception, reconnect))
				return true;
			if (rateLimitExceptionHandler.TryHandle(exception, reconnect))
				return true;
			if (serviceUnavailableExceptionHandler.TryHandle(exception, reconnect))
				return true;

			// non-recoverable error
			return false;
		}
		/// <summary>
		/// Dispose resources. Override this method in derived classes. Unmanaged resources should always be released
		/// when this method is called. Managed resources may only be disposed of if disposeManagedResources is true.
		/// </summary>
		/// <param name="disposeManagedResources">A value which indicates whether managed resources may be disposed of.</param>
		protected override void DisposeResources(bool disposeManagedResources)
		{
			base.DisposeResources(disposeManagedResources);

			// check for unmanaged disposal
			if (!disposeManagedResources)
				return;

			// dispose the exception handlers
			socketExceptionHandler.Dispose();
			rateLimitExceptionHandler.Dispose();
			serviceUnavailableExceptionHandler.Dispose();
		}
		private readonly SocketExceptionHandler socketExceptionHandler = new SocketExceptionHandler(new LinearTimeoutBackoffStrategy(250, 16000));
		private readonly HttpExceptionHandler rateLimitExceptionHandler = new HttpExceptionHandler(new ExponentialBackoffStrategy(60000, int.MaxValue), new[] {422});
		private readonly HttpExceptionHandler serviceUnavailableExceptionHandler = new HttpExceptionHandler(new ExponentialBackoffStrategy(5000, 19200), new[] {(int) HttpStatusCode.ServiceUnavailable});
		private readonly IEnumerable<Message.ParserDelegate> parsers = new[] {
			StatusDeletionNotice.Parser,
			LocationDeletionNotice.Parser,
			LimitNotice.Parser,
			StatusWithheld.Parser,
			UserWithheld.Parser,
			Disconnect.Parser,
			Warning.Parser,
			FriendList.Parser,
			Event.Parser,
			Tweet.Parser,
			User.Parser
		};
	}
}