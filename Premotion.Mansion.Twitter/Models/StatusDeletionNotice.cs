using Newtonsoft.Json;
using Premotion.Mansion.Twitter.Models.Parsers;

namespace Premotion.Mansion.Twitter.Models
{
	/// <summary>
	/// These messages indicate that a given Tweet has been deleted. Client code must honor these messages by clearing the referenced Tweet from memory and any storage or archive, even in the rare case where a deletion message arrives earlier in the stream that the Tweet it references.
	/// </summary>
	/// <see href="https://dev.twitter.com/docs/streaming-apis/messages#Status_deletion_notices_delete"/>
	public class StatusDeletionNotice : Message
	{
		/// <summary>
		/// Parses the given token into a <see cref="StatusDeletionNotice"/>.
		/// </summary>
		public static readonly ParserDelegate Parser = ParserFactory.FilterAndParseValue<StatusDeletionNotice>("delete");
		/// <summary>
		/// Gets the status which should be deleted.
		/// </summary>
		[JsonProperty]
		public Status Status { get; set; }
	}
}