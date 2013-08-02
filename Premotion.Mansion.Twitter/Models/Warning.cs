using Newtonsoft.Json;
using Premotion.Mansion.Twitter.Models.Parsers;

namespace Premotion.Mansion.Twitter.Models
{
	/// <summary>
	/// When connected to a stream using the stall_warnings parameter, you may receive status notices indicating the current health of the connection.
	/// </summary>
	/// <see href="https://dev.twitter.com/docs/streaming-apis/messages#Stall_warnings_warning"/>
	public class Warning : Message
	{
		/// <summary>
		/// Parses the given token into a <see cref="Warning"/>.
		/// </summary>
		public static readonly ParserDelegate Parser = ParserFactory.FilterAndParseValue<Warning>("warning");
		/// <summary>
		/// The status code.
		/// </summary>
		[JsonProperty("code")]
		public string Code { get; set; }
		/// <summary>
		/// Human readable status message.
		/// </summary>
		[JsonProperty("message")]
		public string Message { get; set; }
		/// <summary>
		/// Indicator how full the queue is.
		/// </summary>
		[JsonProperty("percent_full")]
		public int PercentFull { get; set; }
		/// <summary>
		/// The ID of the user.
		/// </summary>
		/// <see href="https://dev.twitter.com/docs/streaming-apis/messages#Too_many_follows_warning"/>
		[JsonProperty("user_id")]
		public long UserId { get; set; }
	}
}