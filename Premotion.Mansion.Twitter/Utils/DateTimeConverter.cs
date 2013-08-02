using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Premotion.Mansion.Twitter.Utils
{
	/// <summary>
	/// Implements <see cref="DateTimeConverterBase"/> for Twitter date format.
	/// </summary>
	public class DateTimeConverter : DateTimeConverterBase
	{
		/// <summary>
		/// The format twitter uses to pass <see cref="DateTime"/>s.
		/// </summary>
		public const string Format = "ddd MMM dd HH:mm:ss zzzz yyyy";
		/// <summary>
		/// Writes the JSON representation of the object.
		/// </summary>
		/// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter"/> to write to.</param><param name="value">The value.</param><param name="serializer">The calling serializer.</param>
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			// convert to universal and format properly
			var formatted = ((DateTime) value).ToUniversalTime().ToString(Format, CultureInfo.InvariantCulture);

			// write the value
			writer.WriteValue(formatted);
		}
		/// <summary>
		/// Reads the JSON representation of the object.
		/// </summary>
		/// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader"/> to read from.</param><param name="objectType">Type of the object.</param><param name="existingValue">The existing value of object being read.</param><param name="serializer">The calling serializer.</param>
		/// <returns>
		/// The object value.
		/// </returns>
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			// get the string value
			var value = reader.Value.ToString();

			// parse the date
			DateTime parsed;
			if (!DateTime.TryParseExact(value, Format, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out parsed))
				throw new InvalidOperationException(string.Format("Could not parse date '{0}' using format '{1}'", value, Format));

			// return the value
			return parsed;
		}
	}
}