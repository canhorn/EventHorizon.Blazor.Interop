namespace EventHorizon.Blazor.Interop
{
    using System;
    using Microsoft.JSInterop;
    using Mono.WebAssembly.Interop;

    public static class EventHorizonBlazorInteropt
    {
        public static MonoWebAssemblyJSRuntime RUNTIME = new MonoWebAssemblyJSRuntime();

        public static void Call(
            params object[] args
        )
        {
            RUNTIME.InvokeVoid(
                "blazorInterop.call",
                args
            );
        }

        public static CachedEntity Func(
            params object[] args
        )
        {
            return RUNTIME.Invoke<CachedEntity>(
                "blazorInterop.func",
                args
            );
        }

        /// https://github.com/jhwcn/BlazorUnmarshalledCanvas/blob/master/UmCanvas/Canvas.cs
        public static T Get<T>(
            string root,
            string identifier
        )
        {
            return RUNTIME.InvokeUnmarshalled<ValueTuple<string, string>, T>(
                "blazorInterop.get",
                ValueTuple.Create(
                    root,
                    identifier
                )
            );
        }

        public static CachedEntity New(
            params object[] args
        )
        {
            return RUNTIME.Invoke<CachedEntity>(
                "blazorInterop.new",
                args
            );
        }

        public static void RunScript(
            string methodName,
            string script,
            object args
        )
        {
            RUNTIME.InvokeVoid(
                "blazorInterop.runScript",
                new JavaScriptMethodRunner
                {
                    MethodName = methodName,
                    Script = script,
                    Args = args
                }
            );
        }

        public static CachedEntity Set(
            params object[] args
        )
        {
            return RUNTIME.Invoke<CachedEntity>(
                "blazorInterop.set",
                args
            );
        }
    }
    public struct JavaScriptMethodRunner
    {
        public string MethodName { get; set; }
        public string Script { get; set; }
        public object Args { get; set; }
    }
}
