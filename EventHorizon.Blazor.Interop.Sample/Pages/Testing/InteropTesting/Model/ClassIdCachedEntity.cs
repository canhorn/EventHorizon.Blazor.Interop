using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventHorizon.Blazor.Interop.Sample.Pages.Testing.InteropTesting.Model
{
    [System.Text.Json.Serialization.JsonConverter(typeof(CachedEntityConverter<ClassIdCachedEntity>))]
    public class ClassIdCachedEntity
        : CachedEntity
    {
        public string Id
        {
            get
            {
                return EventHorizonBlazorInterop.Get<string>(
                    this.___guid,
                    "id"
                );
            }
            set
            {
                EventHorizonBlazorInterop.Set(
                    this.___guid,
                    "id",
                    value
                );
            }
        }

        public ClassIdCachedEntity()
        {

        }

        public ClassIdCachedEntity(
            ICachedEntity entity
        )
        {
            ___guid = entity.___guid;
        }
    }
}
