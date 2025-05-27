---
uid: skyline_dataminer_sdk
keywords: Skyline.DataMiner.Sdk, Software Development Kit, Package, Catalog, dmapp, cicd
---

# Skyline DataMiner SDK

The **Skyline DataMiner Software Development Kit** is a specialized SDK developed and maintained by Skyline Communications. It extends Microsoft's .NET SDK and seamlessly integrates into standard compilation and publishing activities provided by Microsoft.

This allows developers to move away from separate tooling and benefit from an out-of-the-box, integrated development experience. With the Skyline DataMiner SDK, everything you need to develop, build, and publish DataMiner artifacts within the .NET ecosystem is readily available.

We have simplified the installation and usage by leveraging the **.NET Templating Engine** and offering the **Skyline.DataMiner.VisualStudioTemplates**.

## Supported project types

The Skyline DataMiner SDK currently supports the following project types:

- [**DataMiner Package Project**](xref:skyline_dataminer_sdk_dataminer_package_project)
- **DataMiner Ad Hoc Data Source Project**
- **DataMiner Automation Script Library Project**
- **DataMiner Automation Script Project**
- **DataMiner User-Defined API Project**

## Getting started

To get started, you can:

- **Install the DIS (DataMiner Integration Studio) extension** on Visual Studio, which includes the templates by default.
- **Install the templates directly** using the .NET CLI:

  ```bash
  dotnet new install Skyline.DataMiner.VisualStudioTemplates
  ```

These templates include a helpful wizard for Visual Studio and well-documented CLI arguments for creating projects using the `dotnet` command.

When you create a project, a **GettingStarted.md** file will be added to your project directory. This file provides detailed instructions on how to work with each project type.

## Key features and actions

The Skyline DataMiner SDK hooks into the compilation and publishing processes to streamline the creation of DataMiner application packages and Catalog uploads.

### Compilation: creating DataMiner application packages

During the compilation of a **Skyline.DataMiner.SDK** project, the SDK checks whether the project property `GenerateDataMinerPackage` is set to `true`. If this is the case, it uses the `DataMinerType` property to generate additional output files specific to the project type:

- **\*.dmapp file**: Represents a DataMiner application package containing the content of your project, ready to be installed on a DataMiner System.
- **\*.zip file**: Represents Catalog information used for publishing the package to the Catalog.

Only for the **DataMiner Package Project**, the SDK also checks the *CatalogDefaultDownloadKeyName* property for the name of an environment variable or Visual Studio secret containing an [organization key](xref:Managing_dataminer_services_keys#organization-keys) to download Catalog items defined in *CatalogReferences.xml*.

### Publishing: uploading to the Catalog

When you publish a **Skyline.DataMiner.SDK** project, the SDK checks whether the *GenerateDataMinerPackage* property is set to `true`. If this is the case, it checks the *CatalogPublishKeyName* property for the name of an environment variable or Visual Studio secret containing a [system key](xref:Managing_dataminer_services_keys#system-keys) or [organization key](xref:Managing_dataminer_services_keys#organization-keys).

The publishing process uploads the following artifacts to the Catalog:

- The **\*.dmapp file** containing the package content
- The **\*.zip file** containing catalog information

The following inputs are required for successful publishing:

- A valid [organization key](xref:Managing_dataminer_services_keys#organization-keys) or [system key](xref:Managing_dataminer_services_keys#system-keys)
- The project property `Version`
- The project property `VersionComment`

## See also

[Skyline DataMiner SDK project properties](xref:skyline_dataminer_sdk_project_properties)
