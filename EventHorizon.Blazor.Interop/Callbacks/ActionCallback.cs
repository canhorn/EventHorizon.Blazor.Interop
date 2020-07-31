using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace EventHorizon.Blazor.Interop.Callbacks
{
    public class ActionCallback
    {
        public string ___type => "action_callback";
        public DotNetObjectReference<ActionCallback> invokableReference { get; }
        public string method => "HandleCallback";

        private Func<Task> _callback;
        public ActionCallback(
            Func<Task> callback
        )
        {
            _callback = callback;
            invokableReference = DotNetObjectReference.Create(
                this
            );
        }

        [JSInvokable]
        public Task HandleCallback()
        {
            return _callback();
        }
    }
}
