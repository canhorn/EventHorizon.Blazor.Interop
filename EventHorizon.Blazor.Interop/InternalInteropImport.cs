namespace EventHorizon.Blazor.Interop;

using System;
using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;

[SupportedOSPlatform("browser")]
internal partial class InternalInteropImport
{
    [JSImport("globalThis.blazorInterop.get")]
    internal static partial string Get(string root, string prop);

    [JSImport("globalThis.blazorInterop.getClass")]
    internal static partial string GetClass(string root, string prop);
}
