using System.Collections.Generic;
using Newtonsoft.Json;

namespace Premotion.Mansion.Twitter.Models
{
	/// <summary>
	/// Places are specific, named locations with corresponding geo coordinates. They can be attached to Tweets by specifying a place_id when tweeting. Tweets associated with places are not necessarily issued from that location but could also potentially be about that location. Places can be created and searched for. Tweets can also be found by place_id.
	/// </summary>
	/// <see href="https://dev.twitter.com/docs/platform-objects/places"/>
	public class Places
	{
		/// <summary>
		/// Contains a hash of variant information about the place.
		/// </summary>
		[JsonProperty("attributes")]
		public IDictionary<string, string> Attributes { get; set; }
		/// <summary>
		/// A bounding box of coordinates which encloses this place.
		/// </summary>
		[JsonProperty("bounding_box")]
		public BoundingBox BoundingBox { get; set; }
		/// <summary>
		/// Name of the country containing this place.
		/// </summary>
		[JsonProperty("country")]
		public string Country { get; set; }
		/// <summary>
		/// Shortened country code representing the country containing this place.
		/// </summary>
		[JsonProperty("country_code")]
		public string CountryCode { get; set; }
		/// <summary>
		/// Full human-readable representation of the place's name.
		/// </summary>
		[JsonProperty("full_name")]
		public string FullName { get; set; }
		/// <summary>
		/// ID representing this place. Note that this is represented as a string, not an integer.
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }
		/// <summary>
		/// Short human-readable representation of the place's name.
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }
		/// <summary>
		/// The type of location represented by this place.
		/// </summary>
		[JsonProperty("place_type")]
		public string PlaceType { get; set; }
		/// <summary>
		/// URL representing the location of additional place metadata for this place.
		/// </summary>
		[JsonProperty("url")]
		public string Url { get; set; }
	}
}