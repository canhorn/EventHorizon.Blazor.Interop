namespace EventHorizon.Blazor.Interop
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// A base class that is created as an easy way to interface with Client side implementation.
    /// </summary>
    [JsonConverter(typeof(CachedEntityConverter<CachedEntity>))]
    public class CachedEntity 
        : ICachedEntity
    {
        /// <inheritdoc />
        public string ___guid { get; set; }
    }
}
