using Newtonsoft.Json;
using Premotion.Mansion.Twitter.Models.Parsers;

namespace Premotion.Mansion.Twitter.Models
{
	/// <summary>
	/// These messages indicate that geolocated data must be stripped from a range of Tweets. Clients must honor these messages by deleting geocoded data from Tweets which fall before the given status ID and belong to the specified user. These messages may also arrive before a Tweet which falls into the specified range, although this is rare.
	/// </summary>
	/// <see href="https://dev.twitter.com/docs/streaming-apis/messages#Location_deletion_notices_scrub_geo"/>
	public class LocationDeletionNotice : Message
	{
		/// <summary>
		/// Parses the given token into a <see cref="LocationDeletionNotice"/>.
		/// </summary>
		public static readonly ParserDelegate Parser = ParserFactory.FilterAndParseValue<LocationDeletionNotice>("scrub_geo");
		/// <summary>
		/// The user ID of the status.
		/// </summary>
		[JsonProperty("user_id")]
		public long UserId { get; set; }
		/// <summary>
		/// The string representation of the user ID of the status.
		/// </summary>
		[JsonProperty("user_id_str")]
		public long UserIdStr { get; set; }
		/// <summary>
		/// The ID of the status.
		/// </summary>
		[JsonProperty("up_to_status_id")]
		public long UpToStatusId { get; set; }
		/// <summary>
		/// The string representation of the ID of the status.
		/// </summary>
		[JsonProperty("up_to_status_id_str")]
		public long UpToStatusIdStr { get; set; }
	}
}