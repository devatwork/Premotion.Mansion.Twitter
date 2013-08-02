using Newtonsoft.Json;
using Premotion.Mansion.Twitter.Models.Parsers;

namespace Premotion.Mansion.Twitter.Models
{
	/// <summary>
	/// These events contain an id field indicating the status ID, a user_id indicating the user, and a collection of withheld_in_countries uppercase two-letter country codes.
	/// </summary>
	/// <see href="https://dev.twitter.com/docs/streaming-apis/messages#Withheld_content_notices_status_withheld_user_withheld"/>
	public class StatusWithheld : Message
	{
		/// <summary>
		/// Parses the given token into a <see cref="StatusWithheld"/>.
		/// </summary>
		public static readonly ParserDelegate Parser = ParserFactory.FilterAndParseValue<StatusWithheld>("status_withheld");
		/// <summary>
		/// The ID of the status.
		/// </summary>
		[JsonProperty("id")]
		public long Id { get; set; }
		/// <summary>
		/// The user ID of the status.
		/// </summary>
		[JsonProperty("user_id")]
		public long UserId { get; set; }
		/// <summary>
		/// A collection of withheld_in_countries uppercase two-letter country codes
		/// </summary>
		[JsonProperty("withheld_in_countries")]
		public string[] WithheldInCountries { get; set; }
	}
}