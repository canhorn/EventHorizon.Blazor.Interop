using System.Text.Json.Serialization;

namespace EventHorizon.Blazor.Interop
{
    [JsonConverter(typeof(CachedEntityConverter<CachedEntity>))]
    public class CachedEntity : ICachedEntity
    {
        public string ___guid { get; set; }
    }
}
