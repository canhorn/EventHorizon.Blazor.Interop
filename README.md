[![Build Status](https://img.shields.io/endpoint.svg?url=https%3A%2F%2Factions-badge.atrox.dev%2Fcanhorn%2FEventHorizon.Blazor.Interop%2Fbadge%3Fref%3Dmain&style=for-the-badge)](https://actions-badge.atrox.dev/canhorn/EventHorizon.Blazor.Interop/goto?ref=main)
[![Nuget](https://img.shields.io/nuget/vpre/EventHorizon.Blazor.Interop?style=for-the-badge)](https://www.nuget.org/packages/EventHorizon.Blazor.Interop)

[![GitHub](https://img.shields.io/github/license/canhorn/EventHorizon.Blazor.Interop?style=for-the-badge)](https://github.com/canhorn/EventHorizon.Blazor.Interop/blob/main/LICENSE)
[![GitHub tag (latest SemVer pre-release)](https://img.shields.io/github/v/tag/canhorn/EventHorizon.Blazor.Interop?include_prereleases&label=latest%20tag&style=for-the-badge)](https://github.com/canhorn/EventHorizon.Blazor.Interop/tags)

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
        EventHorizonBlazorInterop.JSRuntime = JSRuntime;
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
