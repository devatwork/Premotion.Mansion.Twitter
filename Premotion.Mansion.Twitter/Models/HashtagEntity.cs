using Newtonsoft.Json;

namespace Premotion.Mansion.Twitter.Models
{
	/// <summary>
	/// An occurrence of a hashtag.
	/// </summary>
	/// <see href="https://dev.twitter.com/docs/platform-objects/entities"/>
	public class HashtagEntity
	{
		/// <summary>
		/// An array of integers indicating the offsets within the Tweet text where the hashtag begins and ends. The first integer represents the location of the # character in the Tweet text string. The second integer represents the location of the first character after the hashtag. Therefore the difference between the two numbers will be the length of the hashtag name plus one (for the '#' character).
		/// </summary>
		[JsonProperty("indices")]
		public int[] Indices { get; set; }
		/// <summary>
		/// Name of the hashtag, minus the leading '#' character.
		/// </summary>
		[JsonProperty("text")]
		public string Text { get; set; }
	}
}