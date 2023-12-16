param(
    [string]
    [ValidateSet(
        "clean",
        "restore",
        "build",
        "run",
        "format",
        "test",
        "publish",
        "serve:publish",
        "pre"
    )]
    $Command,
    [string] $Configuration = "Release",
    [string] $Filter = ""
)

$sampleProject = "./EventHorizon.Blazor.Interop.Sample/EventHorizon.Blazor.Interop.Sample.csproj"

switch ($Command) {
    "clean" {
        dotnet clean
    }
    "restore" {
        dotnet restore --no-cache
    }
    "build" {
        dotnet build --no-incremental --no-cache
    }
    "run" {
        dotnet run --project $sampleProject
    }
    "format" { 
        dotnet csharpier .
    }
    "test" { 
        echo "No Tests to Run"
    }
    "publish" {
        dotnet publish -c $Configuration -o ./published $sampleProject
    }
    "serve:publish" {
        ./entry.ps1 publish

        dotnet serve -d="./published/wwwroot"
    }
    Default {
        Write-Output "Invalid Command"
    }
}
