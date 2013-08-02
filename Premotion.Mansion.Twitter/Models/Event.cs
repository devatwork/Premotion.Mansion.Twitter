using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Premotion.Mansion.Twitter.Models.Parsers;

namespace Premotion.Mansion.Twitter.Models
{
	/// <summary>
	/// Notifications about non-Tweet events are also sent over a user stream.
	/// </summary>
	/// <see href="https://dev.twitter.com/docs/streaming-apis/messages#Events_event"/>
	public class Event : Message
	{
		/// <summary>
		/// Parses the given token into a <see cref="Event"/>.
		/// </summary>
		public static readonly ParserDelegate Parser = ParserFactory.FilterAndParseProperty<Event>("event");
		/// <summary>
		/// The target user.
		/// </summary>
		[JsonProperty("target")]
		public User Target { get; set; }
		/// <summary>
		/// The source user.
		/// </summary>
		[JsonProperty("source")]
		public User Source { get; set; }
		/// <summary>
		/// The event name.
		/// </summary>
		[JsonProperty("event")]
		public string EventName { get; set; }
		/// <summary>
		/// The target object.
		/// </summary>
		[JsonProperty("target_object")]
		public JObject TargetObject { get; set; }
		/// <summary>
		/// The date the event was created.
		/// </summary>
		[JsonProperty("created_at")]
		public DateTime CreatedAt { get; set; }
	}
}