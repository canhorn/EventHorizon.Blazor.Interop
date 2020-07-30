using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace EventHorizon.Blazor.Interop.Callbacks
{
    public class ActionCallback<TArg1>
    {
        public string ___type => "action_callback";
        public DotNetObjectReference<ActionCallback<TArg1>> invokableReference { get; }
        public string method => "HandleCallback";

        private Func<TArg1, Task> _callback;
        public ActionCallback(
            Func<TArg1, Task> callback
        )
        {
            _callback = callback;
            invokableReference = DotNetObjectReference.Create(
                this
            );
        }

        [JSInvokable]
        public Task HandleCallback(TArg1 arg1)
        {
            return _callback(arg1);
        }
    }
}
