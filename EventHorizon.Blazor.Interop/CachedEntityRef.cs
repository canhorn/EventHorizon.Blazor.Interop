using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EventHorizon.Blazor.Interop
{
    /// <summary>
    /// Represents a root reference to JS object. The JS object will live as long as this reference exists,
    /// and once it is collected, the JS object will also be released for collection by the JS runtime.
    /// </summary>
    [JsonConverter(typeof(CachedEntityRefConverter))]
    public sealed class CachedEntityRef : IEquatable<CachedEntityRef>
    {
        readonly string _guid;

        internal CachedEntityRef(string guid)
        {
            _guid = guid;
        }

        /// <inheritdoc />
        ~CachedEntityRef()
        {
            EventHorizonBlazorInterop.RemoveEntity(_guid);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return _guid;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return (_guid != null ? _guid.GetHashCode() : 0);
        }

        /// <inheritdoc />
        public bool Equals(CachedEntityRef other)
        {
            return _guid == other?._guid;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((CachedEntityRef) obj);
        }

        /// <summary>
        /// Converts an instance of this object to string.
        /// </summary>
        /// <param name="obj">A cached entity reference.</param>
        /// <returns>The internal UUID of the cached entity.</returns>
        public static implicit operator string(CachedEntityRef obj) => obj.ToString();
    }


    /// <summary>
    /// This helps with the payload of passing a CacheEntity between the C# and client.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class CachedEntityRefConverter : JsonConverter<CachedEntityRef>
    {
        /// <inheritdoc />
        public override bool CanConvert(Type typeToConvert) =>
            typeof(CachedEntityRef).IsAssignableFrom(typeToConvert);

        /// <inheritdoc />
        public override CachedEntityRef Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.Read() ? new CachedEntityRef(reader.GetString()) : null;
        }

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, CachedEntityRef value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
