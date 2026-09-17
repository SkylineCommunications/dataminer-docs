@echo off
cls

dotnet restore "src/NuGetPackages"
dotnet build "src/NuGetPackages" --configuration Release
docfx metadata
if %ERRORLEVEL% NEQ 0 exit /b %ERRORLEVEL%
powershell -NoProfile -ExecutionPolicy Bypass -File ".\scripts\generate-generated-metadata-provenance.ps1" -RepositoryRoot "." -OutputPath ".\_artifacts\generated-metadata-provenance.json" -RequireGeneratedOutputs
if %ERRORLEVEL% NEQ 0 exit /b %ERRORLEVEL%
powershell -NoProfile -ExecutionPolicy Bypass -File ".\scripts\validate-generated-metadata-provenance.ps1" -RepositoryRoot "." -Path ".\_artifacts\generated-metadata-provenance.json"
if %ERRORLEVEL% NEQ 0 exit /b %ERRORLEVEL%
docfx build --warningsAsErrors

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
