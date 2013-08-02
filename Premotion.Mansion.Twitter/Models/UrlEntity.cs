using Newtonsoft.Json;

namespace Premotion.Mansion.Twitter.Models
{
	/// <summary>
	/// An occurrence of a url.
	/// </summary>
	/// <see href="https://dev.twitter.com/docs/platform-objects/entities"/>
	public class UrlEntity
	{
		/// <summary>
		/// Version of the URL to display to clients.
		/// </summary>
		[JsonProperty("display_url")]
		public string DisplayUrl { get; set; }
		/// <summary>
		/// Expanded version of display_url.
		/// </summary>
		[JsonProperty("expanded_url")]
		public string ExpandedUrl { get; set; }
		/// <summary>
		/// An array of integers representing offsets within the Tweet text where the URL begins and ends. The first integer represents the location of the first character of the URL in the Tweet text. The second integer represents the location of the first non-URL character after the end of the URL.
		/// </summary>
		[JsonProperty("indices")]
		public int[] Indices { get; set; }
		/// <summary>
		/// Wrapped URL, corresponding to the value embedded directly into the raw Tweet text, and the values for the indices parameter
		/// </summary>
		[JsonProperty("url")]
		public string Url { get; set; }
	}
}