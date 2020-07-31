using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventHorizon.Blazor.Interop.Sample.Pages.Testing.InteropTesting.Model
{
    [System.Text.Json.Serialization.JsonConverter(typeof(CachedEntityConverter<Vector3CachedEntity>))]
    public class Vector3CachedEntity
        : CachedEntity
    {
        public string X
        {
            get
            {
                return EventHorizonBlazorInterop.Get<string>(
                    this.___guid,
                    "X"
                );
            }
            set
            {
                EventHorizonBlazorInterop.Set(
                    this.___guid,
                    "X",
                    value
                );
            }
        }
        public string Y
        {
            get
            {
                return EventHorizonBlazorInterop.Get<string>(
                    this.___guid,
                    "Y"
                );
            }
            set
            {
                EventHorizonBlazorInterop.Set(
                    this.___guid,
                    "Y",
                    value
                );
            }
        }
        public string Z
        {
            get
            {
                return EventHorizonBlazorInterop.Get<string>(
                    this.___guid,
                    "Z"
                );
            }
            set
            {
                EventHorizonBlazorInterop.Set(
                    this.___guid,
                    "Z",
                    value
                );
            }
        }

        public Vector3CachedEntity(
            ICachedEntity entity
        )
        {
            ___guid = entity.___guid;
        }
    }
}
