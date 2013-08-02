using Newtonsoft.Json;

namespace Premotion.Mansion.Twitter.Models
{
	/// <summary>
	/// The coordinates.
	/// </summary>
	/// <see href="https://dev.twitter.com/docs/platform-objects/tweets#obj-coordinates"/>
	public class Point
	{
		/// <summary>
		/// The longitude and latitude of the Tweet's location, as an collection in the form of [longitude, latitude].
		/// </summary>
		[JsonProperty("coordinates")]
		public float[] Coordinates { get; set; }
		/// <summary>
		/// The type of data encoded in the coordinates property. This will be "Point" for Tweet coordinates fields.
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}