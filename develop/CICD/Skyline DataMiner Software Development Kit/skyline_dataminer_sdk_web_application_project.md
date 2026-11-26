---
uid: skyline_dataminer_sdk_web_application_project
description: "Create a DataMiner web application project with the SDK, configure App.info.json and its output folder, then package and install it on your system."
keywords: Skyline.DataMiner.Sdk, Web Application, WebApplication, esproj, App.info.json
---

# Skyline DataMiner Web Application Project

A DataMiner web application is a standalone (static) website that fully runs in the browser. It is developed in a separate project, typically a JavaScript project (*.esproj*), and deployed by including it in a [DataMiner Package Project](xref:skyline_dataminer_sdk_dataminer_package_project).

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

> [!TIP]
> For information on how to upload the resulting web application to a DataMiner System, see [Uploading and publishing a new app](xref:Uploading_a_new_app). For an overview of the ways to get a new app, see [Creating a new app](xref:Creating_a_new_app).

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

## Custom header controls

From DataMiner 10.6.0 [CU10]/10.7.1 onwards<!--RN 47099-->, an uploaded web application can add buttons, nested menus, spacers, and separators to the app's header bar through the `postMessage` API. In earlier versions, this API is not available.

Send a `header.set` message from the app's iframe to configure its controls:

```json
{
  "header": {
    "set": [
      { "label": "Save", "icon": "save", "identifier": "save" },
      {
        "label": "Export",
        "children": [
          { "label": "Export PDF", "identifier": "export-pdf" }
        ]
      }
    ]
  }
}
```

Top-level buttons require a non-blank `label`, or both an `icon` and a `title`. Child menu items require a non-blank `label`. Items without children require a non-blank `identifier`; selecting one sends its identifier back to the iframe:

```json
{ "header": { "identifier": "save" } }
```

Items with children open a menu without sending an action message. Top-level buttons and leaf menu actions can use the boolean `isLoading` and `isDisabled` fields. Either state prevents activation. Nested submenu parents do not support these fields. Spacers and separators are supported only at the top level.

Each `header.set` replaces the previous custom controls and closes the active menu. Send `{"header":{"set":[]}}` to remove the custom controls without removing the framework header. To change existing controls without replacing them, send a `header.update` message with updates identified by unique identifiers:

```json
{
  "header": {
    "update": [
      { "identifier": "save", "label": "Saving", "isLoading": true },
      { "identifier": "export-pdf", "isDisabled": true }
    ]
  }
}
```

Updates can change `label`, `title`, `icon`, `isLoading`, and `isDisabled`, but not identifiers, children, or layout. Set a label, title, or icon to `null` to clear it, provided the control still meets its presentation requirements. Set `isLoading` or `isDisabled` to `false` to clear that state.

Updates are applied atomically. An invalid update or an unknown or duplicated identifier leaves all controls unchanged. A header command must contain exactly one of `set` or `update`.

Updates appear in place in the header and any open first-level menu. Reopen a deeper submenu to see updates there. Clicking outside a menu over the app's iframe dismisses the menu without activating the iframe content underneath. Custom controls are cleared when the host application model changes.

## Requesting authentication tokens

From DataMiner 10.6.0 [CU10]/10.7.1 onwards<!--RN 46953-->, an uploaded web application can request authentication tokens for one or more API endpoints in a single `postMessage` request to its parent window:

```json
{ "tokens": [{ "endpoint": "/API/v1/Json.asmx" }] }
```

Each endpoint receives a separate response, in which the token is keyed by the requested endpoint. In the example above, the token is returned under `tokens["/API/v1/Json.asmx"]`.

Currently, only relative endpoints starting with `/api/v1/` are supported, regardless of casing. Unsupported endpoints, including absolute URLs, return the error message `This endpoint is not supported.`, while supported endpoints in the same request still receive their token. This contract prepares for future support for user-defined APIs, which cannot be requested yet.

> [!NOTE]
> In earlier DataMiner versions, an app requests a single token using `{ request: "token" }` and receives it in a `{ token: "..." }` response. From DataMiner 10.6.0 [CU10]/10.7.1 onwards, apps must use the endpoint-based contract described above.

### Using a token with the Web API

From DataMiner 10.6.0 [CU10]/10.7.1 onwards<!--RN 46953-->, the Web API accepts the token (connection string) in the HTTP header `Authorization: Bearer <connection string>`. Authentication is handled as follows:

- A non-empty connection parameter takes precedence over the `Bearer` header.
- When the connection parameter is empty or omitted, the `Bearer` credentials are used. Invalid `Bearer` credentials cause authentication to fail, even if a valid authentication cookie is present.
- Cookie-based authentication remains available when no `Bearer` credentials are supplied.

Cross-origin resource sharing (CORS) allows the `Authorization` header for sandboxed uploaded apps.

## Deploying a web application

A web application project does not produce its own DataMiner application package. To deploy it, include it in a [DataMiner Package Project](xref:skyline_dataminer_sdk_dataminer_package_project). By default, the [ProjectReferences.xml](xref:skyline_dataminer_sdk_dataminer_package_project_project_references) file of a package project includes all *.csproj* and *.esproj* projects of the solution.

When the package project is built, the SDK does the following for each included web application project:

1. It builds the web application project. For *.esproj* projects, the *Build* target is used (e.g., `npm run build`). For other projects, the *Publish* target is used.

1. It zips the output folder of the web application, together with the *App.info.json* file, into a file named *\<ProjectName>_\<ID>.zip*.

1. It adds this zip file to the package, in the *AppInstallContent\ZipFiles\WebApp* folder.

When the package is installed, the web application is installed on the DataMiner System. The default installation code (`installerHelper.InstallDefaultContent()`) installs all web applications included in the package.

### Output folder

The folder that is zipped is determined as follows:

1. The *BuildOutputFolder* property, if specified in the web application project.

1. The *dist* folder for *.esproj* projects, or the *wwwroot* folder in the publish directory for other projects.

For example, to zip the *build* folder instead:

```xml
<PropertyGroup>
  <DataMinerType>WebApplication</DataMinerType>
  <BuildOutputFolder>$(MSBuildProjectDirectory)\build</BuildOutputFolder>
</PropertyGroup>
```

> [!NOTE]
> Previously, web applications were deployed by placing the built website in the *PackageContent/CompanionFiles* folder of the package project and registering it with `installerHelper.WebApplications.RegisterStaticApp()`. This method is now deprecated. Use a web application project instead.

## Installing web applications during installation

The [Skyline.DataMiner.Utils.AppInstallerHelper](https://www.nuget.org/packages/Skyline.DataMiner.Utils.AppInstallerHelper) NuGet package also allows you to install the web applications included in the package separately in the installation code of the package project:

```csharp
var installerHelper = new AppInstallerHelper(Engine.SLNetRaw, context);

// Install all web applications included in the package.
installerHelper.WebApplications.InstallWebApplications();

// Or install specific web applications.
foreach (var webApplication in installerHelper.WebApplications.GetWebApplicationsToInstall())
{
    installerHelper.WebApplications.InstallWebApplication(webApplication);
}
```
