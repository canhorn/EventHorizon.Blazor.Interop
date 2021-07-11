namespace EventHorizon.Blazor.Interop
{
    using System;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    /// <summary>
    /// This helps with the payload of passing a CacheEntity between the C# and client.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CachedEntityConverter<T>
        : JsonConverter<T> where T : CachedEntity
    {
        /// <inheritdoc />
        public override bool CanConvert(Type typeToConvert) =>
            typeof(T).IsAssignableFrom(typeToConvert);

        /// <inheritdoc />
        public override T Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var entity = (T)Activator.CreateInstance(typeToConvert);

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    return entity;
                }

                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    var propertyName = reader.GetString();
                    reader.Read();
                    switch (propertyName)
                    {
                        case "___guid":
                            entity.___guid = reader.GetString();
                            break;
                    }
                }
            }
            throw new JsonException("___guid was not found");
        }

        /// <inheritdoc />
        public override void Write(
            Utf8JsonWriter writer,
            T value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStartObject();

            writer.WriteString("___guid", value.___guid);

            writer.WriteEndObject();
        }
    }
}
