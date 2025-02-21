---
uid: skyline_dataminer_sdk
---

# Skyline DataMiner SDK

The **Skyline DataMiner Software Development Kit** is a specialized SDK developed and maintained by Skyline Communications. As one of our most powerful and innovative tools to date, it extends Microsoft's .NET SDK and seamlessly integrates into standard compilation and publishing activities provided by Microsoft.

This allows developers to move away from separate tooling and benefit from an out-of-the-box, integrated development experience. With the Skyline DataMiner SDK, everything you need to develop, build, and publish DataMiner artifacts within the .NET ecosystem is readily available.

We’ve simplified the installation and usage by leveraging the **.NET Templating Engine** and offering the **Skyline.DataMiner.VisualStudioTemplates**.

## Supported Project Types

The Skyline DataMiner SDK currently supports the following project types:

- [**DataMiner Package Project**](xref:skyline_dataminer_sdk_dataminer_package_project)
- **DataMiner Ad Hoc Data Source Project**
- **DataMiner Automation Script Library Project**
- **DataMiner Automation Script Project**
- **DataMiner User-Defined API Project**

## Getting Started

To get started, you can:

- **Install the DIS (DataMiner Integration Studio)** extension on Visual Studio, which includes our templates by default.  
- **Install the templates directly** using the .NET CLI:

```bash
dotnet new install Skyline.DataMiner.VisualStudioTemplates
```

These templates include a helpful wizard for Visual Studio and well-documented CLI arguments for creating projects using the `dotnet` command.

When creating a project, a **GettingStarted.md** file will be added to your project directory. This file provides detailed instructions on how to work with each project type.

## Key Features and Actions

The Skyline DataMiner SDK hooks into the compilation and publishing processes to streamline the creation of DataMiner application packages and catalog uploads.

### Compilation: Creating DataMiner Application Packages

During the compilation of a **Skyline.DataMiner.Sdk** project, the SDK checks whether the project property `GenerateDataMinerPackage` is set to `true`. If enabled, it uses the `DataMinerType` property to generate additional output files specific to the project type:

- **`*.dmapp` File**: Represents a DataMiner Application Package containing the content of your project, ready to be installed on a DataMiner system.
- **`*.zip` File**: Represents catalog information used for publishing the package to the DataMiner Catalog.

### Publishing: Uploading to the DataMiner Catalog

When publishing a **Skyline.DataMiner.Sdk** project, the SDK checks whether the `GenerateDataMinerPackage` property is set to `true`. If enabled, it considers the `CatalogPublishKeyName` property, which specifies the name of an environment variable or Visual Studio secret containing a [system key](xref:Managing_DCP_keys#system-keys) or [organization key](xref:Managing_DCP_keys#organization-keys).

The publishing process uploads the following artifacts to the DataMiner Catalog:

- The **`*.dmapp` file** containing the package content  
- The **`*.zip` file** containing catalog information  

The following inputs are required for successful publishing:

- A valid [organization key](xref:Managing_DCP_keys#organization-keys) or [system key](xref:Managing_DCP_keys#system-keys)  
- The project property `Version`  
- The project property `VersionComment`  
