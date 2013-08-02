using System.Collections.Generic;
using Newtonsoft.Json;

namespace Premotion.Mansion.Twitter.Models
{
	/// <summary>
	/// An occurrence of a media.
	/// </summary>
	/// <see href="https://dev.twitter.com/docs/platform-objects/entities"/>
	public class MediaEntity
	{
		/// <summary>
		/// URL of the media to display to clients.
		/// </summary>
		[JsonProperty("display_url")]
		public string DisplayUrl { get; set; }
		/// <summary>
		/// An expanded version of display_url. Links to the media display page.
		/// </summary>
		[JsonProperty("expanded_url")]
		public string ExpandedUrl { get; set; }
		/// <summary>
		/// ID of the media expressed as a 64-bit integer.
		/// </summary>
		[JsonProperty("id")]
		public long Id { get; set; }
		/// <summary>
		/// ID of the media expressed as a string.
		/// </summary>
		[JsonProperty("id_str")]
		public string IdStr { get; set; }
		/// <summary>
		/// An array of integers indicating the offsets within the Tweet text where the URL begins and ends. The first integer represents the location of the first character of the URL in the Tweet text. The second integer represents the location of the first non-URL character occurring after the URL (or the end of the string if the URL is the last part of the Tweet text).
		/// </summary>
		[JsonProperty("indices")]
		public int[] Indices { get; set; }
		/// <summary>
		/// An http:// URL pointing directly to the uploaded media file.
		/// </summary>
		[JsonProperty("media_url")]
		public string MediaUrl { get; set; }
		/// <summary>
		/// An https:// URL pointing directly to the uploaded media file, for embedding on https pages.
		/// </summary>
		[JsonProperty("media_url_https")]
		public string MediaUrlHttps { get; set; }
		/// <summary>
		/// An object showing available sizes for the media file.
		/// </summary>
		[JsonProperty("sizes")]
		public IDictionary<string, MediaSize> Sizes { get; set; }
		/// <summary>
		/// For Tweets containing media that was originally associated with a different tweet, this ID points to the original Tweet.
		/// </summary>
		[JsonProperty("source_status_id")]
		public long SourceStatusId { get; set; }
		/// <summary>
		/// For Tweets containing media that was originally associated with a different tweet, this string-based ID points to the original Tweet.
		/// </summary>
		[JsonProperty("source_status_id_str")]
		public string SourceStatusIdStr { get; set; }
		/// <summary>
		/// Type of uploaded media.
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; }
		/// <summary>
		/// Wrapped URL for the media link. This corresponds with the URL embedded directly into the raw Tweet text, and the values for the indices parameter.
		/// </summary>
		[JsonProperty("url")]
		public string Url { get; set; }
	}
}