using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Premotion.Mansion.Twitter.Models
{
	/// <summary>
	/// Represents a Twitter message payload.
	/// </summary>
	[JsonObject(MemberSerialization.OptIn)]
	public abstract class Message
	{
		/// <summary>
		/// Tries to parse the given <paramref name="token"/> into a <see cref="Message"/>, if the <paramref name="token"/> cannot be parsed null is returned.
		/// </summary>
		/// <param name="token"></param>
		public delegate Message ParserDelegate(JObject token);
	}
}