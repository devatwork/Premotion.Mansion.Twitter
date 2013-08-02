using Newtonsoft.Json;

namespace Premotion.Mansion.Twitter.Models
{
	/// <summary>
	/// The bounding box.
	/// </summary>
	/// <see href="https://dev.twitter.com/docs/platform-objects/places"/>
	public class BoundingBox
	{
		/// <summary>
		/// A series of longitude and latitude points, defining a box which will contain the Place entity this bounding box is related to. Each point is an array in the form of [longitude, latitude]. Points are grouped into an array per bounding box. Bounding box arrays are wrapped in one additional array to be compatible with the polygon notation.
		/// </summary>
		[JsonProperty("coordinates")]
		public float[][][] Coordinates { get; set; }
		/// <summary>
		/// The type of data encoded in the coordinates property. This will be "Polygon" for bounding boxes.
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}