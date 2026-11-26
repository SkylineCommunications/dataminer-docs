---
uid: skyline_dataminer_sdk_web_application_project
description: "Create a DataMiner web application project with the SDK, configure App.info.json and its output folder, then package and install it on your system."
keywords: Skyline.DataMiner.Sdk, Web Application, WebApplication, esproj, App.info.json
---

# Skyline DataMiner Web Application Project

A DataMiner web application is a standalone (static) website that fully runs in the browser. It is developed in a separate project, typically a JavaScript project (*.esproj*), and deployed by including it in a [DataMiner Package Project](xref:skyline_dataminer_sdk_dataminer_package_project).

## Prerequisites

- Use Skyline DataMiner SDK 2.8.0 or later for the package project. The web application template is available from Skyline.DataMiner.VisualStudioTemplates 2.10.0.
- The JavaScript template requires Node.js and npm on the development machine and on any build machine.
- To install web applications through the package installer's default ZIP flow, the installation Agent must run DataMiner 10.7.1.0 build 17902 or later, and the package project must use Skyline.DataMiner.Core.AppPackageInstaller 4.5.0 or later. An older installation Agent causes the installer to skip the web application and log a message; other package content can still be installed.
- The target system must also support uploaded web applications. This feature is planned for DataMiner web 10.5.0 [CU22]/10.6.0 [CU10]/10.7.1<!--RN 45878-->. See the [preview release notes](xref:Web_apps_Feature_Release_10.7.1#dataminer-apps-support-for-uploading-web-applications-id-45878). The installer version check above applies to the Agent's core version even if its web components have been upgraded separately.

To prevent installation on an unsupported Agent, set [MinimumRequiredDmVersion](xref:skyline_dataminer_sdk_project_properties#minimumrequireddmversion) in the package project:

```xml
<MinimumRequiredDmVersion>10.7.1.0 - 17902</MinimumRequiredDmVersion>
```

If necessary, also set [MinimumRequiredDmWebVersion](xref:skyline_dataminer_sdk_project_properties#minimumrequireddmwebversion) to specify the web version your application requires.

## Creating a web application project

You can create a new web application project with the *DataMiner Web Application Project* template, either in Visual Studio or using the .NET CLI:

```powershell
dotnet new install Skyline.DataMiner.VisualStudioTemplates
dotnet new dataminer-web-application-project -o MyWebApplication
dotnet sln add MyWebApplication\MyWebApplication.esproj
```

The template creates a JavaScript project using Vite. In the project directory, use `npm run dev` to start the development server or `npm run build` to build the site into the *dist* folder. Install the project dependencies with `npm install` if needed.

You can also use an existing *.esproj* or *.csproj* project that builds a static website. Add the following property to a `PropertyGroup` in the project file:

```xml
<DataMinerType>WebApplication</DataMinerType>
```

Make sure the project builds the site into the [output folder](#output-folder) and that asset paths work when the app is hosted under an app-specific path. For example, the Vite template uses `base: './'` for relative asset paths.

## App.info.json

Each web application project needs an *App.info.json* file in the root of the project. The template creates this file and generates a unique ID. For example:

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

- **ID**: A GUID that uniquely identifies the app. Keep the same ID when you update the app; use a different ID for a different app.
- **Name**: The app's display name.
- **Color**: The accent color, specified as a hexadecimal or RGB string.
- **Icon**: An icon name prefixed with `ms-Icon--`, or a relative path to an image in the app assets.

You can also specify `Description`, `DefaultDocument` (the relative or virtual path to the home page), `Manifest` (the relative path to the web app manifest), and `Sections` (a list of landing page section names). Paths refer to files in the built app assets.

When a package is created, the SDK validates that the *App.info.json* file is present and valid, that the mandatory fields have a value, and that the ID is a valid GUID. If this is not the case, the build of the package project fails.

## Deploying a web application

A web application project does not produce its own *.dmapp* file. Add a DataMiner Package Project to the solution and include the web application in its *PackageContent/ProjectReferences.xml* file. New package templates include both *.csproj* and *.esproj* project patterns. If an existing file explicitly includes only *.csproj* projects, add a reference to the web application, for example:

```xml
<ProjectReference Include="..\MyWebApplication\MyWebApplication.esproj" />
```

Alternatively, include `..\*\*.esproj` to match projects in directories one level below the package project's parent directory. Paths are relative to the package project directory, not to the *PackageContent* folder. See [ProjectReferences.xml](xref:skyline_dataminer_sdk_dataminer_package_project_project_references) for the complete XML structure and filtering options.

Make sure `GenerateDataMinerPackage` is set to `true` in the package project, and build the project. For example, run the following command from the solution directory, replacing the path with the path to your package project:

```powershell
dotnet build .\MyPackage\MyPackage.csproj
```

When the package project is built, the SDK does the following for each included web application project:

1. It builds the web application project. For *.esproj* projects, the *Build* target is used (e.g., `npm run build`). For other projects, the *Publish* target is used.

1. It zips the output folder of the web application, together with the *App.info.json* file, into a file named *\<ProjectName>_\<ID>.zip*.

1. It adds this zip file to the package, in the *AppInstallContent\ZipFiles\WebApp* folder.

The resulting *.dmapp* is written to the package project's output folder, typically *bin*. You can [install the application package](xref:Installing_an_app_package) on a DataMiner System or [publish it to the Catalog](xref:skyline_dataminer_sdk_dataminer_package_project#publishing-to-the-catalog).

### Output folder

The folder that is zipped is determined as follows:

1. The *BuildOutputFolder* property, if specified in the web application project. A relative path is resolved from the project directory.

1. The *dist* folder for *.esproj* projects, or the *wwwroot* folder in the publish directory for other projects.

The output folder must exist and contain files, or the package build will fail.

For example, to zip the *build* folder instead:

```xml
<PropertyGroup>
  <DataMinerType>WebApplication</DataMinerType>
  <BuildOutputFolder>$(MSBuildProjectDirectory)\build</BuildOutputFolder>
</PropertyGroup>
```

The root *App.info.json* from the project is used even if the output folder contains a file with the same name.

> [!NOTE]
> Previously, web applications were deployed by placing the built website in the *PackageContent/CompanionFiles* folder of the package project and registering it with `installerHelper.WebApplications.RegisterStaticApp()`. Use a web application project to package and deploy the app as described on this page.

## Installing web applications during installation

The standard package installation script calls `AppInstaller.InstallDefaultContent()`, which installs the included ZIP content, including web applications. You do not need to call `AppInstaller.InstallZipFiles()` separately if you use `InstallDefaultContent()`.

If you have custom installation code that installs content separately, call `AppInstaller.InstallZipFiles()` to install all ZIP content, not just web applications. Make sure an existing package project uses a compatible version of the installer package and does not rely on an older custom installation script that omits ZIP content.

You can access the app from the [DataMiner landing page](xref:Accessing_the_web_apps#dataminer-landing-page), depending on your DataMiner and app permissions.
