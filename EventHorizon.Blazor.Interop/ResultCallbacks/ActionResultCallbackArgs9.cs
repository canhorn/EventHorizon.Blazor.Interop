namespace EventHorizon.Blazor.Interop.ResultCallbacks
{
    using System;
    using Microsoft.JSInterop;

    /// <summary>
    /// A platform provided abstraction to help with creation of a action that will trigger when called from the Client side.
    /// </summary>
    /// <typeparam name="TArg1"></typeparam>
    /// <typeparam name="TArg2"></typeparam>
    /// <typeparam name="TArg3"></typeparam>
    /// <typeparam name="TArg4"></typeparam>
    /// <typeparam name="TArg5"></typeparam>
    /// <typeparam name="TArg6"></typeparam>
    /// <typeparam name="TArg7"></typeparam>
    /// <typeparam name="TArg8"></typeparam>
    /// <typeparam name="TArg9"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public class ActionResultCallback<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult>
    {
        /// <summary>
        /// This is a type that gets passed to the Client side to help with the client side marshal of arguments.
        /// </summary>
        public string ___type => "action_result_callback";
        /// <summary>
        /// The .NET representation that the Client will call back to on Action trigger.
        /// </summary>
        public DotNetObjectReference<ActionResultCallback<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult>> invokableReference { get; }
        /// <summary>
        /// The method on the <see cref="invokableReference" /> that will be called when the Action is triggered.
        /// </summary>
        public string method => "HandleCallback";

        private Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> _callback;

        /// <summary>
        /// Create a new Action callback representation that will be triggered when the Client calls the method.
        /// </summary>
        /// <param name="callback">The custom action that should be triggered.</param>
        public ActionResultCallback(
            Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> callback
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
        /// <param name="arg2">Argument that is passed from client side.</param>
        /// <param name="arg3">Argument that is passed from client side.</param>
        /// <param name="arg4">Argument that is passed from client side.</param>
        /// <param name="arg5">Argument that is passed from client side.</param>
        /// <param name="arg6">Argument that is passed from client side.</param>
        /// <param name="arg7">Argument that is passed from client side.</param>
        /// <param name="arg8">Argument that is passed from client side.</param>
        /// <param name="arg9">Argument that is passed from client side.</param>
        /// <returns>The result from client side when this action is called.</returns>
        [JSInvokable]
        public TResult HandleCallback(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9)
        {
            return _callback(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
        }
    }
}
