using Newtonsoft.Json;
using Premotion.Mansion.Twitter.Models.Parsers;

namespace Premotion.Mansion.Twitter.Models
{
	/// <summary>
	/// These events contain an id field indicating the user ID and a collection of withheld_in_countries uppercase two-letter country codes.
	/// </summary>
	/// <see href="https://dev.twitter.com/docs/streaming-apis/messages#Withheld_content_notices_status_withheld_user_withheld"/>
	public class UserWithheld : Message
	{
		/// <summary>
		/// Parses the given token into a <see cref="UserWithheld"/>.
		/// </summary>
		public static readonly ParserDelegate Parser = ParserFactory.FilterAndParseValue<UserWithheld>("user_withheld");
		/// <summary>
		/// The ID of the user.
		/// </summary>
		[JsonProperty("id")]
		public long Id { get; set; }
		/// <summary>
		/// A collection of withheld_in_countries uppercase two-letter country codes
		/// </summary>
		[JsonProperty("withheld_in_countries")]
		public string[] WithheldInCountries { get; set; }
	}
}