using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Premotion.Mansion.Twitter.Utils;

namespace Premotion.Mansion.Twitter.Models.Parsers
{
	/// <summary>
	/// Factory for creating <see cref="Message.ParserDelegate"/>s.
	/// </summary>
	public static class ParserFactory
	{
		/// <summary>
		/// The json serializer used for deserialization.
		/// </summary>
		private static readonly JsonSerializer Serializer;
		/// <summary>
		/// Static constructor which creates the <see cref="Serializer"/>.
		/// </summary>
		static ParserFactory()
		{
			// create the serializer
			Serializer = new JsonSerializer();

			// register a custom date formatter
			Serializer.Converters.Add(new DateTimeConverter());
		}
		/// <summary>
		/// Creates a <see cref="Message.ParserDelegate"/> which filters on <paramref name="filter"/> and uses it's <see cref="JProperty.Value"/> to deserialze.
		/// </summary>
		/// <typeparam name="TMessage">The type of <see cref="Message"/> parsed by the parser.</typeparam>
		/// <param name="filter">The name of the <see cref="Message.ParserDelegate"/> on which to filter.</param>
		/// <returns>Returns the created <see cref="Message.ParserDelegate"/>.</returns>
		public static Message.ParserDelegate FilterAndParseValue<TMessage>(string filter) where TMessage : Message
		{
			// validate arguments
			if (string.IsNullOrEmpty(filter))
				throw new ArgumentNullException("filter");

			// create 
			return token => {
				// the first property should have delete as its key
				var property = token.Property(filter);

				// if there is no property or it does not have a value, it does not match
				if (property == null || property.Value == null)
					return default(TMessage);

				// parse the message
				return property.Value.ToObject<TMessage>(Serializer);
			};
		}
		/// <summary>
		/// Creates a <see cref="Message.ParserDelegate"/> which filters on <paramref name="filter"/> and uses the <see cref="JProperty"/> to deserialze.
		/// </summary>
		/// <typeparam name="TMessage">The type of <see cref="Message"/> parsed by the parser.</typeparam>
		/// <param name="filter">The name of the <see cref="Message.ParserDelegate"/> on which to filter.</param>
		/// <returns>Returns the created <see cref="Message.ParserDelegate"/>.</returns>
		public static Message.ParserDelegate FilterAndParseProperty<TMessage>(string filter) where TMessage : Message
		{
			// validate arguments
			if (string.IsNullOrEmpty(filter))
				throw new ArgumentNullException("filter");

			// create 
			return token => {
				// the first property should have delete as its key
				var property = token.Property(filter);

				// if there is no property or it does not have a value, it does not match
				if (property == null || property.Value == null)
					return default(TMessage);

				// parse the message
				return property.ToObject<TMessage>(Serializer);
			};
		}
		/// <summary>
		/// Creates a <see cref="Message.ParserDelegate"/> which filters on <paramref name="filter"/> and uses the <see cref="JObject"/> to deserialze.
		/// </summary>
		/// <typeparam name="TMessage">The type of <see cref="Message"/> parsed by the parser.</typeparam>
		/// <param name="filter">The name of the <see cref="Message.ParserDelegate"/> on which to filter.</param>
		/// <returns>Returns the created <see cref="Message.ParserDelegate"/>.</returns>
		public static Message.ParserDelegate FilterAndParseSelf<TMessage>(string filter) where TMessage : Message
		{
			// validate arguments
			if (string.IsNullOrEmpty(filter))
				throw new ArgumentNullException("filter");

			// create 
			return token => {
				// the first property should have delete as its key
				var property = token.Property(filter);

				// if there is no property or it does not have a value, it does not match
				if (property == null || property.Value == null)
					return default(TMessage);

				// parse the message
				return token.ToObject<TMessage>(Serializer);
			};
		}
	}
}