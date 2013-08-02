namespace Premotion.Mansion.Twitter.Streaming
{
	/// <summary>
	/// Holds the client configuration.
	/// </summary>
	public class TwitterHttpClientConfiguration
	{
		/// <summary>
		/// Holds the consumer key used to authenticate the request.
		/// </summary>
		public string ConsumerKey { get; set; }
		/// <summary>
		/// Holds the consumer secret used to authenticate the request.
		/// </summary>
		public string ConsumerSecret { get; set; }
		/// <summary>
		/// Holds the request token key used to authenticate the request.
		/// </summary>
		public string RequestToken { get; set; }
		/// <summary>
		/// Holds the request token secret used to authenticate the request.
		/// </summary>
		public string RequestTokenSecret { get; set; }
	}
}