using Newtonsoft.Json;
using Premotion.Mansion.Twitter.Models.Parsers;

namespace Premotion.Mansion.Twitter.Models
{
	/// <summary>
	/// Upon establishing a User Stream connection, Twitter will send a preamble before starting regular message delivery. This preamble contains a list of the user’s friends.
	/// </summary>
	/// <see href="https://dev.twitter.com/docs/streaming-apis/messages#Friends_lists_friends"/>
	public class FriendList : Message
	{
		/// <summary>
		/// Parses the given token into a <see cref="FriendList"/>.
		/// </summary>
		public static readonly ParserDelegate Parser = ParserFactory.FilterAndParseProperty<FriendList>("friends");
		/// <summary>
		/// The ID of the friends.
		/// </summary>
		[JsonProperty("friends")]
		public long[] Friends { get; set; }
	}
}