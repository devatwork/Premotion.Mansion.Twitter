namespace Premotion.Mansion.Twitter.Streaming
{
	/// <summary>
	/// Returns public statuses that match one or more filter predicates. Multiple parameters may be specified which allows most clients to use a single connection to the Streaming API.
	/// </summary>
	/// <see href="https://dev.twitter.com/docs/api/1.1/post/statuses/filter"/>
	public class StatusesFilter
	{
		/// <summary>
		/// A comma separated list of user IDs, indicating the users to return statuses for in the stream.
		/// </summary>
		/// <see href="https://dev.twitter.com/docs/streaming-apis/parameters#follow"/>
		public long[] Follow { get; set; }
		/// <summary>
		/// Keywords to track. Phrases of keywords are specified by a comma-separated list.
		/// </summary>
		/// <see href="https://dev.twitter.com/docs/streaming-apis/parameters#track"/>
		public string[] Track { get; set; }
		/// <summary>
		/// Specifies a set of bounding boxes to track.
		/// </summary>
		/// <see href="https://dev.twitter.com/docs/streaming-apis/parameters#locations"/>
		public float[][] Locations { get; set; }
		/// <summary>
		/// https://dev.twitter.com/docs/streaming-apis/parameters#stall_warnings
		/// </summary>
		/// <see href="https://dev.twitter.com/docs/streaming-apis/parameters#delimited"/>
		public bool StallWarnings { get; set; }
	}
}