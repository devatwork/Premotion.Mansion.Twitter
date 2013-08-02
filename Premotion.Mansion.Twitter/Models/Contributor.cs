using Newtonsoft.Json;

namespace Premotion.Mansion.Twitter.Models
{
	/// <summary>
	/// A contributor.
	/// </summary>
	/// <see href="https://dev.twitter.com/docs/platform-objects/tweets#obj-contributors"/>
	public class Contributor
	{
		/// <summary>
		/// The integer representation of the ID of the user who contributed to this Tweet.
		/// </summary>
		[JsonProperty("id")]
		public long Id { get; set; }
		/// <summary>
		/// The string representation of the ID of the user who contributed to this Tweet.
		/// </summary>
		[JsonProperty("id_str")]
		public string IdStr { get; set; }
		/// <summary>
		/// The screen name of the user who contributed to this Tweet.
		/// </summary>
		[JsonProperty("screen_name")]
		public string ScreenName { get; set; }
	}
}