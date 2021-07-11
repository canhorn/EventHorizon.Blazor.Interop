namespace EventHorizon.Blazor.Interop
{
    /// <summary>
    /// The API contract that helps to connect the .NET to the Client.
    /// </summary>
    public interface ICachedEntity
    {
        /// <summary>
        /// The Client identifier for this specific entity.
        /// </summary>
        string ___guid { get; set; }
    }
}
