using System;
using Newtonsoft.Json;
using Premotion.Mansion.Twitter.Models.Parsers;

namespace Premotion.Mansion.Twitter.Models
{
	/// <summary>
	/// Users can be anyone or anything. They tweet, follow, create lists, have a home_timeline, can be mentioned, and can be looked up in bulk.
	/// </summary>
	/// <see href="https://dev.twitter.com/docs/platform-objects/users"/>
	public class User : Message
	{
		/// <summary>
		/// Parses the given token into a <see cref="User"/>.
		/// </summary>
		public static readonly ParserDelegate Parser = ParserFactory.FilterAndParseSelf<User>("screen_name");
		/// <summary>
		/// Indicates that the user has an account with "contributor mode" enabled, allowing for Tweets issued by the user to be co-authored by another account. Rarely true.
		/// </summary>
		[JsonProperty("contributors_enabled")]
		public bool ContributorsEnabled { get; set; }
		/// <summary>
		/// The UTC datetime that the user account was created on Twitter.
		/// </summary>
		[JsonProperty("created_at")]
		public DateTime CreatedAt { get; set; }
		/// <summary>
		/// When true, indicates that the user has not altered the theme or background of their user profile.
		/// </summary>
		[JsonProperty("default_profile")]
		public bool DefaultProfile { get; set; }
		/// <summary>
		/// When true, indicates that the user has not uploaded their own avatar and a default egg avatar is used instead.
		/// </summary>
		[JsonProperty("default_profile_image")]
		public bool DefaultProfileImage { get; set; }
		/// <summary>
		/// The user-defined UTF-8 string describing their account.
		/// </summary>
		[JsonProperty("description")]
		public string Description { get; set; }
		/// <summary>
		/// Entities which have been parsed out of the url or description fields defined by the user.
		/// </summary>
		[JsonProperty("entities")]
		public Entities Entities { get; set; }
		/// <summary>
		/// The number of tweets this user has favorited in the account's lifetime. British spelling used in the field name for historical reasons.
		/// </summary>
		[JsonProperty("favourites_count")]
		public int FavouritesCount { get; set; }
		/// <summary>
		/// When true, indicates that the authenticating user has issued a follow request to this protected user account.
		/// </summary>
		[JsonProperty("follow_request_sent")]
		public bool? FollowRequestSent { get; set; }
		/// <summary>
		/// When true, indicates that the authenticating user is following this user. Some false negatives are possible when set to "false," but these false negatives are increasingly being represented as "null" instead.
		/// </summary>
		[JsonProperty("following"), Obsolete("https://groups.google.com/forum/#!topic/twitter-development-talk/QrqIO5-OPG4")]
		public bool? Following { get; set; }
		/// <summary>
		/// The number of followers this account currently has. Under certain conditions of duress, this field will temporarily indicate "0."
		/// </summary>
		[JsonProperty("followers_count")]
		public int FollowersCount { get; set; }
		/// <summary>
		/// The number of users this account is following (AKA their "followings"). Under certain conditions of duress, this field will temporarily indicate "0."
		/// </summary>
		[JsonProperty("friends_count")]
		public int FriendsCount { get; set; }
		/// <summary>
		/// When true, indicates that the user has enabled the possibility of geotagging their Tweets. This field must be true for the current user to attach geographic data when using POST statuses/update.
		/// </summary>
		[JsonProperty("geo_enabled")]
		public bool GeoEnabled { get; set; }
		/// <summary>
		/// The integer representation of the unique identifier for this User. This number is greater than 53 bits and some programming languages may have difficulty/silent defects in interpreting it. Using a signed 64 bit integer for storing this identifier is safe. Use id_str for fetching the identifier to stay on the safe side.
		/// </summary>
		[JsonProperty("id")]
		public long Id { get; set; }
		/// <summary>
		/// The string representation of the unique identifier for this User. Implementations should use this rather than the large, possibly un-consumable integer in id.
		/// </summary>
		[JsonProperty("id_str")]
		public string IdStr { get; set; }
		/// <summary>
		/// When true, indicates that the user is a participant in Twitter's translator community.
		/// </summary>
		[JsonProperty("is_translator")]
		public bool IsTranslator { get; set; }
		/// <summary>
		/// The BCP 47 code for the user's self-declared user interface language. May or may not have anything to do with the content of their Tweets.
		/// </summary>
		[JsonProperty("lang")]
		public string Lang { get; set; }
		/// <summary>
		/// The number of public lists that this user is a member of.
		/// </summary>
		[JsonProperty("listed_count")]
		public string ListedCount { get; set; }
		/// <summary>
		/// The user-defined location for this account's profile. Not necessarily a location nor parseable. This field will occasionally be fuzzily interpreted by the Search service.
		/// </summary>
		[JsonProperty("location")]
		public string Location { get; set; }
		/// <summary>
		/// The name of the user, as they've defined it. Not necessarily a person's name. Typically capped at 20 characters, but subject to change.
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }
		/// <summary>
		/// May incorrectly report "false" at times. Indicates whether the authenticated user has chosen to receive this user's tweets by SMS.
		/// </summary>
		[JsonProperty("notifications"), Obsolete("https://groups.google.com/forum/#!topic/twitter-development-talk/QrqIO5-OPG4")]
		public bool? Notifications { get; set; }
		/// <summary>
		/// The hexadecimal color chosen by the user for their background.
		/// </summary>
		[JsonProperty("profile_background_color")]
		public string ProfileBackgroundColor { get; set; }
		/// <summary>
		/// A HTTP-based URL pointing to the background image the user has uploaded for their profile.
		/// </summary>
		[JsonProperty("profile_background_image_url")]
		public string ProfileBackgroundImageUrl { get; set; }
		/// <summary>
		/// A HTTP-based URL pointing to the background image the user has uploaded for their profile.
		/// </summary>
		[JsonProperty("profile_background_image_url_https")]
		public string ProfileBackgroundImageUrlHttps { get; set; }
		/// <summary>
		/// When true, indicates that the user's profile_background_image_url should be tiled when displayed.
		/// </summary>
		[JsonProperty("profile_background_tile")]
		public bool ProfileBackgroundTile { get; set; }
		/// <summary>
		/// The HTTPS-based URL pointing to the standard web representation of the user's uploaded profile banner. By adding a final path element of the URL, you can obtain different image sizes optimized for specific displays. In the future, an API method will be provided to serve these URLs so that you need not modify the original URL. For size variations, please see User Profile Images and Banners.
		/// </summary>
		[JsonProperty("profile_banner_url")]
		public string ProfileBannerUrl { get; set; }
		/// <summary>
		/// A HTTP-based URL pointing to the user's avatar image.
		/// </summary>
		[JsonProperty("profile_image_url")]
		public string ProfileImageUrl { get; set; }
		/// <summary>
		/// A HTTPS-based URL pointing to the user's avatar image.
		/// </summary>
		[JsonProperty("profile_image_url_https")]
		public string ProfileImageUrlHttps { get; set; }
		/// <summary>
		/// The hexadecimal color the user has chosen to display links with in their Twitter UI.
		/// </summary>
		[JsonProperty("profile_link_color")]
		public string ProfileLinkColor { get; set; }
		/// <summary>
		/// The hexadecimal color the user has chosen to display sidebar borders with in their Twitter UI.
		/// </summary>
		[JsonProperty("profile_sidebar_border_color")]
		public string ProfileSidebarBorderColor { get; set; }
		/// <summary>
		/// The hexadecimal color the user has chosen to display sidebar backgrounds with in their Twitter UI.
		/// </summary>
		[JsonProperty("profile_sidebar_fill_color")]
		public string ProfileSidebarFillColor { get; set; }
		/// <summary>
		/// The hexadecimal color the user has chosen to display text with in their Twitter UI.
		/// </summary>
		[JsonProperty("profile_text_color")]
		public string ProfileTextColor { get; set; }
		/// <summary>
		/// When true, indicates the user wants their uploaded background image to be used.
		/// </summary>
		[JsonProperty("profile_use_background_image")]
		public bool ProfileUseBackgroundImage { get; set; }
		/// <summary>
		/// When true, indicates that this user has chosen to protect their Tweets. 
		/// </summary>
		[JsonProperty("protected")]
		public bool Protected { get; set; }
		/// <summary>
		/// The screen name, handle, or alias that this user identifies themselves with. screen_names are unique but subject to change. Use id_str as a user identifier whenever possible. Typically a maximum of 15 characters long, but some historical accounts may exist with longer names.
		/// </summary>
		[JsonProperty("screen_name")]
		public string ScreenName { get; set; }
		/// <summary>
		/// Indicates that the user would like to see media inline. Somewhat disused.
		/// </summary>
		[JsonProperty("show_all_inline_media")]
		public string ShowAllInlineMedia { get; set; }
		/// <summary>
		/// If possible, the user's most recent tweet or retweet. In some circumstances, this data cannot be provided and this field will be omitted, null, or empty. Perspectival attributes within tweets embedded within users cannot always be relied upon.
		/// </summary>
		[JsonProperty("status")]
		public Tweet Status { get; set; }
		/// <summary>
		/// The number of tweets (including retweets) issued by the user
		/// </summary>
		[JsonProperty("statuses_count")]
		public int StatusesCount { get; set; }
		/// <summary>
		/// A string describing the Time Zone this user declares themselves within.
		/// </summary>
		[JsonProperty("time_zone")]
		public string TimeZone { get; set; }
		/// <summary>
		/// A URL provided by the user in association with their profile.
		/// </summary>
		[JsonProperty("url")]
		public string Url { get; set; }
		/// <summary>
		/// The offset from GMT/UTC in seconds.
		/// </summary>
		[JsonProperty("utc_offset")]
		public int? UtcOffset { get; set; }
		/// <summary>
		/// When true, indicates that the user has a verified account.
		/// </summary>
		[JsonProperty("verified")]
		public bool Verified { get; set; }
		/// <summary>
		/// When present, indicates a textual representation of the two-letter country codes this user is withheld from.
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