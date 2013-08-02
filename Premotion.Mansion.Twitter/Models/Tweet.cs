using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Premotion.Mansion.Twitter.Models.Parsers;

namespace Premotion.Mansion.Twitter.Models
{
	/// <summary>
	/// Tweets are the basic atomic building block of all things Twitter. Users tweet Tweets, also known more generically as "status updates." Tweets can be embedded, replied to, favorited, unfavorited and deleted.
	/// Users can amplify the broadcast of tweets authored by other users by retweeting. Retweets can be distinguished from typical Tweets by the existence of a retweeted_status attribute. This attribute contains a representation of the original Tweet that was retweeted. Users can also unretweet a retweet they created by deleting their retweet.
	/// </summary>
	/// <see href="https://dev.twitter.com/docs/platform-objects/tweets"/>
	public class Tweet : Message
	{
		/// <summary>
		/// Parses the given token into a <see cref="Tweet"/>.
		/// </summary>
		public static readonly ParserDelegate Parser = ParserFactory.FilterAndParseSelf<Tweet>("text");
		/// <summary>
		/// Future/beta home for status annotations.
		/// </summary>
		[JsonProperty("annotations")]
		public JObject Annotations { get; set; }
		/// <summary>
		/// An collection of brief user objects (usually only one) indicating users who contributed to the authorship of the tweet, on behalf of the official tweet author.
		/// </summary>
		[JsonProperty("contributors")]
		public Contributor[] Contributors { get; set; }
		/// <summary>
		/// An collection of brief user objects (usually only one) indicating users who contributed to the authorship of the tweet, on behalf of the official tweet author.
		/// </summary>
		[JsonProperty("coordinates")]
		public Point Coordinates { get; set; }
		/// <summary>
		/// UTC time when this Tweet was created.
		/// </summary>
		[JsonProperty("created_at")]
		public DateTime CreatedAt { get; set; }
		/// <summary>
		/// Only surfaces on methods supporting the include_my_retweet parameter, when set to true. Details the Tweet ID of the user's own retweet (if existent) of this Tweet.
		/// </summary>
		[JsonProperty("current_user_retweet")]
		public JObject CurrentUserRetweet { get; set; }
		/// <summary>
		/// Entities which have been parsed out of the text of the Tweet.
		/// </summary>
		[JsonProperty("entities")]
		public Entities Entities { get; set; }
		/// <summary>
		/// Indicates approximately how many times this Tweet has been "favorited" by Twitter users.
		/// </summary>
		[JsonProperty("favorite_count")]
		public int? FavoriteCount { get; set; }
		/// <summary>
		/// Indicates whether this Tweet has been favorited by the authenticating user.
		/// </summary>
		[JsonProperty("favorited")]
		public bool? Favorited { get; set; }
		/// <summary>
		/// Indicates the maximum value of the filter_level parameter which may be used and still stream this Tweet. So a value of medium will be streamed on none, low, and medium streams.
		/// </summary>
		[JsonProperty("filter_level")]
		public string FilterLevel { get; set; }
		/// <summary>
		/// The integer representation of the unique identifier for this Tweet. This number is greater than 53 bits and some programming languages may have difficulty/silent defects in interpreting it. Using a signed 64 bit integer for storing this identifier is safe. Use id_str for fetching the identifier to stay on the safe side.
		/// </summary>
		[JsonProperty("id")]
		public long Id { get; set; }
		/// <summary>
		/// The string representation of the unique identifier for this Tweet. Implementations should use this rather than the large integer in id.
		/// </summary>
		[JsonProperty("id_str")]
		public string IdStr { get; set; }
		/// <summary>
		/// If the represented Tweet is a reply, this field will contain the screen name of the original Tweet's author.
		/// </summary>
		[JsonProperty("in_reply_to_screen_name")]
		public string InReplyToScreenName { get; set; }
		/// <summary>
		/// If the represented Tweet is a reply, this field will contain the integer representation of the original Tweet's ID.
		/// </summary>
		[JsonProperty("in_reply_to_status_id")]
		public long? InReplyToStatusId { get; set; }
		/// <summary>
		/// If the represented Tweet is a reply, this field will contain the string representation of the original Tweet's ID.
		/// </summary>
		[JsonProperty("in_reply_to_status_id_str")]
		public string InReplyToStatusIdStr { get; set; }
		/// <summary>
		/// If the represented Tweet is a reply, this field will contain the integer representation of the original Tweet's author ID. This will not necessarily always be the user directly mentioned in the Tweet.
		/// </summary>
		[JsonProperty("in_reply_to_user_id")]
		public long? InReplyToUserId { get; set; }
		/// <summary>
		/// If the represented Tweet is a reply, this field will contain the string representation of the original Tweet's author ID. This will not necessarily always be the user directly mentioned in the Tweet.
		/// </summary>
		[JsonProperty("in_reply_to_user_id_str")]
		public string InReplyToUserIdStr { get; set; }
		/// <summary>
		/// When present, indicates a BCP 47 language identifier corresponding to the machine-detected language of the Tweet text, or "und" if no language could be detected.
		/// </summary>
		[JsonProperty("lang")]
		public string Lang { get; set; }
		/// <summary>
		/// When present, indicates that the tweet is associated (but not necessarily originating from) a Place.
		/// </summary>
		[JsonProperty("place")]
		public Places Place { get; set; }
		/// <summary>
		/// This field only surfaces when a tweet contains a link. The meaning of the field doesn't pertain to the tweet content itself, but instead it is an indicator that the URL contained in the tweet may contain content or media identified as sensitive content.
		/// </summary>
		[JsonProperty("possibly_sensitive")]
		public bool? PossiblySensitive { get; set; }
		/// <summary>
		/// A set of key-value pairs indicating the intended contextual delivery of the containing Tweet. Currently used by Twitter's Promoted Products.
		/// </summary>
		[JsonProperty("scopes")]
		public IDictionary<string, JToken> Scopes { get; set; }
		/// <summary>
		/// Number of times this Tweet has been retweeted. This field is no longer capped at 99 and will not turn into a String for "100+"
		/// </summary>
		[JsonProperty("retweet_count")]
		public int RetweetCount { get; set; }
		/// <summary>
		/// Indicates whether this Tweet has been retweeted by the authenticating user.
		/// </summary>
		[JsonProperty("retweeted")]
		public bool Retweeted { get; set; }
		/// <summary>
		/// Utility used to post the Tweet, as an HTML-formatted string. Tweets from the Twitter website have a source value of web.
		/// </summary>
		[JsonProperty("source")]
		public string Source { get; set; }
		/// <summary>
		/// The actual UTF-8 text of the status update. See twitter-text for details on what is currently considered valid characters.
		/// </summary>
		[JsonProperty("text")]
		public string Text { get; set; }
		/// <summary>
		/// Indicates whether the value of the text parameter was truncated, for example, as a result of a retweet exceeding the 140 character Tweet length. Truncated text will end in ellipsis, like this ... Since Twitter now rejects long Tweets vs truncating them, the large majority of Tweets will have this set to false.
		/// Note that while native retweets may have their toplevel text property shortened, the original text will be available under the retweeted_status object and the truncated parameter will be set to the value of the original status (in most cases, false).
		/// </summary>
		[JsonProperty("truncated")]
		public bool Truncated { get; set; }
		/// <summary>
		/// The user who posted this Tweet. Perspectival attributes embedded within this object are unreliable.
		/// </summary>
		[JsonProperty("user")]
		public User User { get; set; }
		/// <summary>
		/// When present and set to "true", it indicates that this piece of content has been withheld due to a DMCA complaint.
		/// </summary>
		[JsonProperty("withheld_copyright")]
		public bool WithheldCopyright { get; set; }
		/// <summary>
		/// When present, indicates a list of uppercase two-letter country codes this content is withheld from. See New Withheld Content Fields in API Responses.
		/// As announced in More changes to withheld content fields, Twitter supports the following non-country values for this field:
		/// * "XX" - Content is withheld in all countries
		/// * "XY" - Content is withheld due to a DMCA request.
		/// </summary>
		[JsonProperty("withheld_in_countries")]
		public string[] WithheldInCountries { get; set; }
		/// <summary>
		/// When present, indicates whether the content being withheld is the "status" or a "user."
		/// </summary>
		[JsonProperty("withheld_scope")]
		public string WithheldScope { get; set; }
	}
}