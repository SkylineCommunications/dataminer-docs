@echo off
cls

powershell -NoProfile -ExecutionPolicy Bypass -File ".\scripts\validate-documentation-metadata.ps1" -RepositoryRoot "."
if %ERRORLEVEL% NEQ 0 exit /b %ERRORLEVEL%
powershell -NoProfile -ExecutionPolicy Bypass -File ".\scripts\validate-documentation-governance.ps1" -RepositoryRoot "." -ReportPath ".\_artifacts\documentation-governance.json"
if %ERRORLEVEL% NEQ 0 exit /b %ERRORLEVEL%
powershell -NoProfile -ExecutionPolicy Bypass -File ".\scripts\validate-documentation-dependency-map.ps1" -RepositoryRoot "." -ReportPath ".\_artifacts\documentation-dependency-map.json"
if %ERRORLEVEL% NEQ 0 exit /b %ERRORLEVEL%
powershell -NoProfile -ExecutionPolicy Bypass -File ".\scripts\resolve-documentation-coupling.ps1" -RepositoryRoot "." -OutputPath ".\_artifacts\documentation-coupling.json"
if %ERRORLEVEL% NEQ 0 exit /b %ERRORLEVEL%
dotnet restore "src/NuGetPackages"
dotnet build "src/NuGetPackages" --configuration Release
docfx metadata
if %ERRORLEVEL% NEQ 0 exit /b %ERRORLEVEL%
powershell -NoProfile -ExecutionPolicy Bypass -File ".\scripts\generate-generated-metadata-provenance.ps1" -RepositoryRoot "." -OutputPath ".\_artifacts\generated-metadata-provenance.json" -RequireGeneratedOutputs
if %ERRORLEVEL% NEQ 0 exit /b %ERRORLEVEL%
powershell -NoProfile -ExecutionPolicy Bypass -File ".\scripts\validate-generated-metadata-provenance.ps1" -RepositoryRoot "." -Path ".\_artifacts\generated-metadata-provenance.json"
if %ERRORLEVEL% NEQ 0 exit /b %ERRORLEVEL%
powershell -NoProfile -ExecutionPolicy Bypass -File ".\scripts\generate-ai-content-manifest.ps1" -RepositoryRoot "." -OutputPath ".\_artifacts\ai-content-manifest.json"
if %ERRORLEVEL% NEQ 0 exit /b %ERRORLEVEL%
powershell -NoProfile -ExecutionPolicy Bypass -File ".\scripts\validate-ai-content-manifest.ps1" -RepositoryRoot "." -Path ".\_artifacts\ai-content-manifest.json"
if %ERRORLEVEL% NEQ 0 exit /b %ERRORLEVEL%
powershell -NoProfile -ExecutionPolicy Bypass -File ".\scripts\generate-deployment-delta.ps1" -RepositoryRoot "." -CurrentManifestPath ".\_artifacts\ai-content-manifest.json" -OutputPath ".\_artifacts\deployment-delta.json"
if %ERRORLEVEL% NEQ 0 exit /b %ERRORLEVEL%
powershell -NoProfile -ExecutionPolicy Bypass -File ".\scripts\validate-deployment-delta.ps1" -RepositoryRoot "." -Path ".\_artifacts\deployment-delta.json"
if %ERRORLEVEL% NEQ 0 exit /b %ERRORLEVEL%
docfx build --warningsAsErrors
if %ERRORLEVEL% NEQ 0 exit /b %ERRORLEVEL%
powershell -NoProfile -ExecutionPolicy Bypass -File ".\scripts\generate-segmented-sitemaps.ps1" -RepositoryRoot "." -SitePath ".\_site" -GeneratedProvenancePath ".\_artifacts\generated-metadata-provenance.json" -OutputPath ".\_artifacts\segmented-sitemap-report.json"
if %ERRORLEVEL% NEQ 0 exit /b %ERRORLEVEL%
powershell -NoProfile -ExecutionPolicy Bypass -File ".\scripts\validate-segmented-sitemaps.ps1" -RepositoryRoot "." -SitePath ".\_site" -ReportPath ".\_artifacts\segmented-sitemap-report.json"
if %ERRORLEVEL% NEQ 0 exit /b %ERRORLEVEL%

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
