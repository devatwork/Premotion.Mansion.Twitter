using Newtonsoft.Json;

namespace Premotion.Mansion.Twitter.Models
{
	/// <summary>
	/// Entities provide metadata and additional contextual information about content posted on Twitter. Entities are never divorced from the content they describe. In API v1.1, entities will be returned wherever Tweets are found in the API. Entities are instrumental in resolving URLs.
	/// </summary>
	/// <see href="https://dev.twitter.com/docs/platform-objects/entities"/>
	public class Entities
	{
		/// <summary>
		/// Represents hashtags which have been parsed out of the Tweet text.
		/// </summary>
		[JsonProperty("hashtags")]
		public HashtagEntity[] Hashtags { get; set; }
		/// <summary>
		/// Represents media elements uploaded with the Tweet.
		/// </summary>
		[JsonProperty("media")]
		public MediaEntity[] Media { get; set; }
		/// <summary>
		/// Represents URLs included in the text of a Tweet or within textual fields of a user object.
		/// </summary>
		[JsonProperty("urls")]
		public UrlEntity[] Urls { get; set; }
		/// <summary>
		/// Represents other Twitter users mentioned in the text of the Tweet.
		/// </summary>
		[JsonProperty("user_mentions")]
		public UserMentionEntity[] UserMentions { get; set; }
	}
}