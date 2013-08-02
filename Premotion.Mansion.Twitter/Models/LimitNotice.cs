using Newtonsoft.Json;
using Premotion.Mansion.Twitter.Models.Parsers;

namespace Premotion.Mansion.Twitter.Models
{
	/// <summary>
	/// These messages indicate that a filtered stream has matched more Tweets than its current rate limit allows to be delivered. Limit notices contain a total count of the number of undelivered Tweets since the connection was opened, making them useful for tracking counts of track terms, for example. Note that the counts do not specify which filter predicates undelivered messages matched.
	/// </summary>
	/// <see href="https://dev.twitter.com/docs/streaming-apis/messages#Limit_notices_limit"/>
	public class LimitNotice : Message
	{
		/// <summary>
		/// Parses the given token into a <see cref="LimitNotice"/>.
		/// </summary>
		public static readonly ParserDelegate Parser = ParserFactory.FilterAndParseValue<LimitNotice>("limit");
		/// <summary>
		///The total count of the number of undelivered Tweets since the connection was opened
		/// </summary>
		[JsonProperty("track")]
		public long Track { get; set; }
	}
}