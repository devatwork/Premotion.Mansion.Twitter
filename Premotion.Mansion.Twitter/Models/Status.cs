using Newtonsoft.Json;

namespace Premotion.Mansion.Twitter.Models
{
	/// <summary>
	/// Represents a status.
	/// </summary>
	public class Status
	{
		/// <summary>
		/// The ID of the status.
		/// </summary>
		[JsonProperty("id")]
		public long Id { get; set; }
		/// <summary>
		/// The string representation of the ID of the status.
		/// </summary>
		[JsonProperty("id_str")]
		public long IdStr { get; set; }
		/// <summary>
		/// The user ID of the status.
		/// </summary>
		[JsonProperty("user_id")]
		public long UserId { get; set; }
		/// <summary>
		/// The string representation of the user ID of the status.
		/// </summary>
		[JsonProperty("user_id_str")]
		public long UserIdStr { get; set; }
	}
}