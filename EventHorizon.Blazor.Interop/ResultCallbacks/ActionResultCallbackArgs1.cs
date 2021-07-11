using Microsoft.JSInterop;
using System;

namespace EventHorizon.Blazor.Interop.ResultCallbacks
{
    /// <summary>
    /// A platform provided abstraction to help with creation of a action that will trigger when called from the Client side.
    /// </summary>
    /// <typeparam name="TArg1"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public class ActionResultCallback<TArg1, TResult>
    {
        /// <summary>
        /// This is a type that gets passed to the Client side to help with the client side marshal of arguments.
        /// </summary>
        public string ___type => "action_result_callback";
        /// <summary>
        /// The .NET representation that the Client will call back to on Action trigger.
        /// </summary>
        public DotNetObjectReference<ActionResultCallback<TArg1, TResult>> invokableReference { get; }
        /// <summary>
        /// The method on the <see cref="invokableReference" /> that will be called when the Action is triggered.
        /// </summary>
        public string method => "HandleCallback";

        private Func<TArg1, TResult> _callback;

        /// <summary>
        /// Create a new Action callback representation that will be triggered when the Client calls the method.
        /// </summary>
        /// <param name="callback">The custom action that should be triggered.</param>
        public ActionResultCallback(
            Func<TArg1, TResult> callback
        )
        {
            _callback = callback;
            invokableReference = DotNetObjectReference.Create(
                this
            );
        }
        /// <summary>
        /// The public method that will be called by the Client when an Action should be triggered.
        /// </summary>
        /// <param name="arg1">Argument that is passed from client side.</param>
        /// <returns>Make this method async for usage with Client side.</returns>
        [JSInvokable]
        public TResult HandleCallback(TArg1 arg1)
        {
            return _callback(arg1);
        }
    }
}
