@echo off
cls

dotnet restore "src/NuGetPackages"
dotnet build "src/NuGetPackages" --configuration Release
docfx metadata
docfx build

if "%1"=="" (
    docfx serve _site
) else (
    docfx serve _site -p %1
)
