using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace EventHorizon.Blazor.Interop.Callbacks
{
    public class ActionCallback<TArg1, TArg2, TArg3, TArg4, TArg5>
    {
        public string ___type => "action_callback";
        public DotNetObjectReference<ActionCallback<TArg1, TArg2, TArg3, TArg4, TArg5>> invokableReference { get; }
        public string method => "HandleCallback";

        private Func<TArg1, TArg2, TArg3, TArg4, TArg5, Task> _callback;
        public ActionCallback(
            Func<TArg1, TArg2, TArg3, TArg4, TArg5, Task> callback
        )
        {
            _callback = callback;
            invokableReference = DotNetObjectReference.Create(
                this
            );
        }

        [JSInvokable]
        public Task HandleCallback(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
        {
            return _callback(arg1, arg2, arg3, arg4, arg5);
        }
    }
}
