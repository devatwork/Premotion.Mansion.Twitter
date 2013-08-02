using Newtonsoft.Json;

namespace Premotion.Mansion.Twitter.Models
{
	/// <summary>
	/// A size of a <see cref="MediaEntity"/>.
	/// </summary>
	/// <see href="https://dev.twitter.com/docs/platform-objects/entities"/>
	public class MediaSize
	{
		/// <summary>
		/// Height in pixels of this size.
		/// </summary>
		[JsonProperty("h")]
		public int H { get; set; }
		/// <summary>
		/// Resizing method used to obtain this size. A value of fit means that the media was resized to fit one dimension, keeping its native aspect ratio. A value of crop means that the media was cropped in order to fit a specific resolution.
		/// </summary>
		[JsonProperty("resize")]
		public string Resize { get; set; }
		/// <summary>
		/// Width in pixels of this size.
		/// </summary>
		[JsonProperty("w")]
		public int W { get; set; }
	}
}