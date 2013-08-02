using Newtonsoft.Json;

namespace Premotion.Mansion.Twitter.Models
{
	/// <summary>
	/// An occurrence of a user mention.
	/// </summary>
	/// <see href="https://dev.twitter.com/docs/platform-objects/entities"/>
	public class UserMentionEntity
	{
		/// <summary>
		/// ID of the mentioned user, as an integer.
		/// </summary>
		[JsonProperty("id")]
		public long Id { get; set; }
		/// <summary>
		/// If of the mentioned user, as a string.
		/// </summary>
		[JsonProperty("id_str")]
		public string IdStr { get; set; }
		/// <summary>
		/// An array of integers representing the offsets within the Tweet text where the user reference begins and ends. The first integer represents the location of the '@' character of the user mention. The second integer represents the location of the first non-screenname character following the user mention.
		/// </summary>
		[JsonProperty("indices")]
		public int[] Indices { get; set; }
		/// <summary>
		/// Display name of the referenced user.
		/// </summary>
		[JsonProperty("name")]
		public string name { get; set; }
		/// <summary>
		/// Screen name of the referenced user.
		/// </summary>
		[JsonProperty("screen_name")]
		public string ScreenName { get; set; }
	}
}