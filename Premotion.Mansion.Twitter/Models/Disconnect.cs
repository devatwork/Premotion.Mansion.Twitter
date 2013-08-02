using Newtonsoft.Json;
using Premotion.Mansion.Twitter.Models.Parsers;

namespace Premotion.Mansion.Twitter.Models
{
	/// <summary>
	/// Streams may be shut down for a variety of reasons. The streaming API will attempt to deliver a message indicating why a stream was closed. Note that if the disconnect was due to network issues or a client reading too slowly, it is possible that this message will not be received.
	/// </summary>
	/// <see href="https://dev.twitter.com/docs/streaming-apis/messages#Disconnect_messages_disconnect"/>
	public class Disconnect : Message
	{
		/// <summary>
		/// Parses the given token into a <see cref="Disconnect"/>.
		/// </summary>
		public static readonly ParserDelegate Parser = ParserFactory.FilterAndParseValue<Disconnect>("disconnect");
		/// <summary>
		/// The status code.
		/// </summary>
		[JsonProperty("code")]
		public int Code { get; set; }
		/// <summary>
		/// The name of the stream.
		/// </summary>
		[JsonProperty("stream_name")]
		public string StreamName { get; set; }
		/// <summary>
		/// Human readable status message.
		/// </summary>
		[JsonProperty("reason")]
		public string Reason { get; set; }
	}
}