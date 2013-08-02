using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using OAuth;

namespace Premotion.Mansion.Twitter.Streaming
{
	/// <summary>
	/// Automatically signs the requests using OAuth.
	/// </summary>
	public class OAuthMessageHandler : DelegatingHandler
	{
		/// <summary>
		/// Defines the key under which the request parameters are stored in <see cref="HttpRequestMessage.Properties"/>.
		/// </summary>
		public static readonly string OAuthParametersPropertyName = typeof (OAuthMessageHandler) + "OauthParameters";
		/// <summary>
		/// Creates a new instance of the <see cref="OAuthMessageHandler"/> class with a specific inner handler.
		/// </summary>
		/// <param name="consumerKey">The consumer key used to authenticate the request.</param>
		/// <param name="consumerSecret">The consumer secret used to authenticate the request.</param>
		/// <param name="innerHandler">The inner handler which is responsible for processing the HTTP response messages.</param>
		public OAuthMessageHandler(string consumerKey, string consumerSecret, HttpMessageHandler innerHandler) : base(innerHandler)
		{
			// validate arguments
			if (string.IsNullOrEmpty(consumerKey))
				throw new ArgumentNullException("consumerKey");
			if (string.IsNullOrEmpty(consumerSecret))
				throw new ArgumentNullException("consumerSecret");

			// set values
			this.consumerKey = consumerKey;
			this.consumerSecret = consumerSecret;
		}
		/// <summary>
		/// Creates a new instance of the <see cref="OAuthMessageHandler"/> class with a specific inner handler.
		/// </summary>
		/// <param name="consumerKey">The consumer key used to authenticate the request.</param>
		/// <param name="consumerSecret">The consumer secret used to authenticate the request.</param>
		/// <param name="requestToken">The request token used to authenticate the request.</param>
		/// <param name="requestTokenSecret">The request token secret used to authenticate the request.</param>
		/// <param name="innerHandler">The inner handler which is responsible for processing the HTTP response messages.</param>
		public OAuthMessageHandler(string consumerKey, string consumerSecret, string requestToken, string requestTokenSecret, HttpMessageHandler innerHandler) : base(innerHandler)
		{
			// validate arguments
			if (string.IsNullOrEmpty(consumerKey))
				throw new ArgumentNullException("consumerKey");
			if (string.IsNullOrEmpty(consumerSecret))
				throw new ArgumentNullException("consumerSecret");
			if (string.IsNullOrEmpty(requestToken))
				throw new ArgumentNullException("requestToken");
			if (string.IsNullOrEmpty(requestTokenSecret))
				throw new ArgumentNullException("requestTokenSecret");

			// set values
			this.consumerKey = consumerKey;
			this.consumerSecret = consumerSecret;
			this.requestToken = requestToken;
			this.requestTokenSecret = requestTokenSecret;
		}
		/// <summary>
		/// Sends an HTTP request to the inner handler to send to the server as an asynchronous operation.
		/// </summary>
		/// <returns>
		/// Returns <see cref="T:System.Threading.Tasks.Task`1"/>. The task object representing the asynchronous operation.
		/// </returns>
		/// <param name="request">The HTTP request message to send to the server.</param><param name="cancellationToken">A cancellation token to cancel operation.</param><exception cref="T:System.ArgumentNullException">The <paramref name="request"/> was null.</exception>
		protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			// generate and the OAuth authorization header
			OAuthRequest oauth;
			if (string.IsNullOrEmpty(requestToken) || string.IsNullOrEmpty(requestTokenSecret))
				oauth = OAuthRequest.ForRequestToken(consumerKey, consumerSecret);
			else
				oauth = OAuthRequest.ForAccessToken(consumerKey, consumerSecret, requestToken, requestTokenSecret);

			// set request info
			oauth.Method = request.Method.Method;
			oauth.RequestUrl = request.RequestUri.AbsoluteUri;

			// add parameters if any
			IDictionary<string, string> parameters = null;
			object parametersObj;
			if (request.Properties.TryGetValue(OAuthParametersPropertyName, out parametersObj))
				parameters = parametersObj as IDictionary<string, string>;

			// generate the authorization header value
			var oauthHeader = parameters != null ? oauth.GetAuthorizationHeader(parameters) : oauth.GetAuthorizationHeader();

			// add the authorization header to the request
			request.Headers.Authorization = new AuthenticationHeaderValue("OAuth", oauthHeader.Substring("OAuth ".Length));

			// continue sending request
			return base.SendAsync(request, cancellationToken);
		}
		private readonly string consumerKey;
		private readonly string consumerSecret;
		private readonly string requestToken;
		private readonly string requestTokenSecret;
	}
}