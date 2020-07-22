using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace EventHorizon.Blazor.BabylonJS.Pages.Testing.InteropTesting.Model
{
    public class MessageUpdateInvokeHelper
    {
        [JSInvokable]
        public Task CallAfterRenderAction()
        {
            return Task.CompletedTask;
        }
    }
}
