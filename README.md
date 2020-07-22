# About

The EventHorizon.Blazor.Interop is a slim WASM project I created to help with common Blazor JavaScript Interop actions. 

## Usage

This library requires the usage of the IJSRuntime, you will need to attach one manually before usage.

In "App.razor"
~~~ csharp
@code {
    [Inject]
    public IJSRuntime JSRuntime { get; set; }

    protected override void OnInitialized()
    {
        EventHorizonBlazorInteropt.JSRuntime = JSRuntime;
    }
}
~~~

## Sample

The EventHorizon.Blazor.Interop.Sample Project contains a suite of performance tests I created to help me verify the performance scenarios I will be using.

## Use Libraries

[BlazorJsFastDataExchanger](https://github.com/Lupusa87/BlazorJsFastDataExchanger)

[MediatR](https://github.com/jbogard/MediatR)

[Mono.WebAssembly.Interop](https://www.nuget.org/packages/Mono.WebAssembly.Interop)

## Inspiration

- [BlazorUnmarshalledCanvas](https://github.com/jhwcn/BlazorUnmarshalledCanvas/blob/master/UmCanvas/Canvas.cs)

## Future Work

- [ ] Look at binary serialization between the layers.