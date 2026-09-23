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

if %ERRORLEVEL% NEQ 0 (
   cls
   echo
   echo An error occurred. Maybe another 'docfx serve' is still running.
   pause
)
