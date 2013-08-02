using System;
using System.Net;
using System.Net.Http;

namespace Premotion.Mansion.Twitter.Streaming
{
	/// <summary>
	/// Implements <see cref="HttpClient"/> for twitter.
	/// </summary>
	public class TwitterHttpClient : HttpClient
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TwitterHttpClient"/> class with a specific handler.
		/// </summary>
		/// <param name="handler">The HTTP handler stack to use for sending requests. </param>
		private TwitterHttpClient(HttpMessageHandler handler) : base(handler)
		{
			// set the timeout to 90s, https://dev.twitter.com/docs/streaming-apis/connecting#Stalls
			Timeout = new TimeSpan(0, 0, 90);
		}
		/// <summary>
		/// Creates a new instance of <see cref="TwitterHttpClient"/> using the specified <paramref name="configuration"/>.
		/// </summary>
		/// <param name="configuration">The <see cref="TwitterHttpClientConfiguration"/> which to use to configure the client.</param>
		/// <returns>Returns the created <see cref="HttpClient"/>.</returns>
		public static HttpClient Create(TwitterHttpClientConfiguration configuration)
		{
			// validate arguments
			if (configuration == null)
				throw new ArgumentNullException("configuration");
			if (string.IsNullOrEmpty(configuration.ConsumerKey) || string.IsNullOrEmpty(configuration.ConsumerSecret))
				throw new ArgumentException("The consumer key and secret are required", "configuration");

			// use the gzip and deflate, https://dev.twitter.com/docs/streaming-apis/processing#gzip-compression
			var httpClientHandler = new HttpClientHandler {
				AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
			};

			// create the oauth message handler which generates a Auth header
			OAuthMessageHandler oAuthMessageHandler;
			if (string.IsNullOrEmpty(configuration.RequestToken) && string.IsNullOrEmpty(configuration.RequestTokenSecret))
				oAuthMessageHandler = new OAuthMessageHandler(configuration.ConsumerKey, configuration.ConsumerSecret, httpClientHandler);
			else
				oAuthMessageHandler = new OAuthMessageHandler(configuration.ConsumerKey, configuration.ConsumerSecret, configuration.RequestToken, configuration.RequestTokenSecret, httpClientHandler);

			// create the client
			return new TwitterHttpClient(oAuthMessageHandler);
		}
	}
}