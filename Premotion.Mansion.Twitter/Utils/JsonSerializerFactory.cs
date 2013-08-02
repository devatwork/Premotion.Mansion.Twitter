using Newtonsoft.Json;

namespace Premotion.Mansion.Twitter.Utils
{
	/// <summary>
	/// Creates <see cref="JsonSerializer"/>s which can handle deserialization of Twitter Json.
	/// </summary>
	public static class JsonSerializerFactory
	{
		/// <summary>
		/// Creates <see cref="JsonSerializer"/>s which can handle deserialization of Twitter Json.
		/// </summary>
		/// <returns>Returns the created <see cref="JsonSerializer"/>.</returns>
		public static JsonSerializer Create()
		{
			// create the serializer
			var serializer = new JsonSerializer();

			// register a custom date formatter
			serializer.Converters.Add(new DateTimeConverter());

			// return the created serializer
			return serializer;
		}
	}
}