using System.Text.Json.Serialization;

namespace EventHorizon.Blazor.Interop.Sample.Pages.Testing.InteropTesting.Model
{
    [JsonConverter(typeof(CachedEntityConverter<TestClass>))]
    public class TestClass : CachedEntity
    {
        public bool Found
        {
            get
            {
                return EventHorizonBlazorInterop.Get<bool>(
                    this.___guid,
                    "found"
                );
            }
            set
            {
                EventHorizonBlazorInterop.Set(
                    this.___guid,
                    "found",
                    value
                );
            }
        }

        public string Arg1
        {
            get
            {
                return EventHorizonBlazorInterop.Get<string>(
                    this.___guid,
                    "arg1"
                );
            }
            set
            {
                EventHorizonBlazorInterop.Set(
                    this.___guid,
                    "arg1",
                    value
                );
            }
        }

        public TestClass()
        {
            var cachedEntity = EventHorizonBlazorInterop.New(
                new string[] { "Vector3" },
                1,
                2,
                3
            );
            ___guid = cachedEntity.___guid;
        }
    }
}
