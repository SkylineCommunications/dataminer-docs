---
uid: skyline_dataminer_sdk_web_application_project
keywords: Skyline.DataMiner.Sdk, Web Application, WebApplication, esproj, App.info.json
---

# Skyline DataMiner Web Application Project

A DataMiner web application is a standalone (static) web site that fully runs in the browser. It is developed in a separate project, typically a JavaScript project (*.esproj*), and deployed by including it in a [DataMiner Package Project](xref:skyline_dataminer_sdk_dataminer_package_project).

## Creating a web application project

You can create a new web application project with the *DataMiner Web Application Project* template, either in Visual Studio or using the .NET CLI:

```bash
dotnet new dataminer-web-application-project -o MyWebApplication
dotnet sln add MyWebApplication
```

Any *.esproj* or *.csproj* project can be used as a web application project, as long as it has the following project property:

```xml
<DataMinerType>WebApplication</DataMinerType>
```

## App.info.json

Each web application project needs an *App.info.json* file in the root of the project. This file describes the web application:

```json
{
  "ID": "554e0e42-d497-49e9-b3c6-c00ea662b917",
  "Name": "My Web Application",
  "Description": "Example of a DataMiner web application.",
  "Color": "#2563EB",
  "Icon": "ms-Icon--Globe"
}
```

The following fields are mandatory:

- **ID**: A GUID that uniquely identifies the web application.
- **Name**: The name of the web application.
- **Color**: The color of the web application.
- **Icon**: The icon of the web application.

Optionally, you can also specify fields such as *Description*, *DefaultDocument*, *Manifest*, and *Sections*.

When a package is created, the SDK validates that the *App.info.json* file is present, that the mandatory fields have a value, and that the ID is a valid GUID. If this is not the case, the build of the package project fails.

## Deploying a web application

A web application project does not produce its own DataMiner application package. To deploy it, include it in a [DataMiner Package Project](xref:skyline_dataminer_sdk_dataminer_package_project). By default, the [ProjectReferences.xml](xref:skyline_dataminer_sdk_dataminer_package_project_project_references) file of a package project includes all *.csproj* and *.esproj* projects of the solution.

When the package project is built, the SDK does the following for each included web application project:

1. It builds the web application project. For *.esproj* projects, the *Build* target is used (e.g., `npm run build`). For other projects, the *Publish* target is used.

1. It zips the output folder of the web application, together with the *App.info.json* file, into a file named *\<ProjectName>_\<ID>.zip*.

1. It adds this zip file to the package, in the *AppInstallContent\ZipFiles\WebApp* folder.

When the package is installed, the web application is imported on the DataMiner System. The default installation code (`installerHelper.InstallDefaultContent()`) imports all web applications included in the package.

### Output folder

The folder that is zipped is determined as follows:

1. The *DataMinerWebApplicationOutputPath* property, if specified in the web application project.

1. The *BuildOutputFolder* property, if specified in the web application project.

1. The *dist* folder for *.esproj* projects, or the *wwwroot* folder in the publish directory for other projects.

For example, to zip the *build* folder instead:

```xml
<PropertyGroup>
  <DataMinerType>WebApplication</DataMinerType>
  <DataMinerWebApplicationOutputPath>build</DataMinerWebApplicationOutputPath>
</PropertyGroup>
```

> [!NOTE]
> Previously, web applications were deployed by placing the built web site in the *PackageContent/CompanionFiles* folder of the package project and registering it with `installerHelper.WebApplications.RegisterStaticApp()`. This method is now deprecated. Use a web application project instead.

## Importing web applications during installation

The [Skyline.DataMiner.Utils.AppInstallerHelper](https://www.nuget.org/packages/Skyline.DataMiner.Utils.AppInstallerHelper) NuGet package also allows you to import the web applications included in the package separately in the installation code of the package project:

```csharp
var installerHelper = new AppInstallerHelper(Engine.SLNetRaw, context);

// Import all web applications included in the package.
installerHelper.WebApplications.InstallWebApplications();

// Or import specific web applications.
foreach (var webApplication in installerHelper.WebApplications.GetWebApplicationsToInstall())
{
    installerHelper.WebApplications.ImportWebApplication(webApplication);
}
```
