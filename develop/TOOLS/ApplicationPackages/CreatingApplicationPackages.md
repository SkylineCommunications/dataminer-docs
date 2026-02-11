---
uid: CreatingApplicationPackages
---

# Creating application packages

There are multiple ways to create application packages:

- [Using Infrastructure as Code (IaC)](#infrastructure-as-code-iac)
- [Using the DataMiner Package Composer](#dataminer-package-composer)
- [Using the application package builder API](#application-package-builder-api)
- [Using the Packager .NET tool](#packager-net-tool)
- [Using the Low-Code App Editor](#low-code-app-editor)

> [!TIP]
> [DataMiner Integration Studio](xref:Overall_concept_of_the_DataMiner_Integration_Studio) supports creating application packages for automation scripts solutions.

## Infrastructure as Code (IaC)

Infrastructure as Code (IaC) is the practice of managing and provisioning infrastructure through machine-readable configuration files rather than manual processes. It enables automation, consistency, and version control, reducing human error and improving scalability.

You can leverage our Visual Studio templates to create a [Skyline DataMiner Package Project](xref:skyline_dataminer_sdk_dataminer_package_project) that will automatically make an application package when compiling and place it in the *bin* folder of your project. When you create this project, you will get a *GettingStarted.md* documentation file with further instructions.

### Installation

As of version 2.42, [DataMiner Integration Studio (DIS)](https://community.dataminer.services/exphub-dis/) automatically installs the latest template package when you open Visual Studio.

If you do not have this version of DIS, then follow these steps for the installation:

1. Install the latest .NET.

1. Run `dotnet new install Skyline.DataMiner.VisualStudioTemplates` to install the templates.

### CI/CD tutorial

If you are interested in combining this with automatic registration in the Catalog, follow our [CI/CD tutorial that uses this Skyline DataMiner Package Project](xref:CICD_Tutorial_For_Other_Items_Multi-Artifact_DataMiner_Package_VisualStudio_And_GitHub).

## DataMiner Package Composer

The DataMiner Package Composer is an experimental low-code application aimed at providing a simple, code-free solution for moving DataMiner objects (such as low-code apps, dashboards, automation scripts, and DOM modules) between DataMiner Agents (DMAs). This tool prioritizes ease of use and requires no coding, making it accessible for users looking to streamline DataMiner operations without technical complexities.

Key highlights:

- Low-code simplicity: Accessible for non-developers.
- Modular packages: Bundle components like dashboards and DOM modules.
- Version management: Track updates with ease.

You can find how to install and use this described on its [Catalog Record](https://catalog.dataminer.services/details/10aeaf2a-2e6c-4841-a49e-5e3dfcd655ba).

## Application package builder API

The application package builder API is an API that can be used to creating application packages. The API is available as a NuGet package: [Skyline.DataMiner.Core.AppPackageCreator](https://www.nuget.org/packages/Skyline.DataMiner.Core.AppPackageCreator).

For the API documentation, refer to [Skyline.AppInstaller.AppPackage](xref:Skyline.AppInstaller.AppPackage).

## Packager .NET tool

The Packager .NET tool is a tool that can be used to create application packages. Refer to [Skyline.DataMiner.CICD.Tools.Packager](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Tools.Packager#readme-body-tab) for more information on the supported types and how to install and use this tool. It is typically used to create e.g. an application package from an Automation script solution folder (e.g. as a step in a CI/CD pipeline.) It currently supports creating application packages for Automation script solutions, Visio repositories (both protocol Visio files and other) and dashboard repositories.

The packager tool also allows the creation of a protocol package (.dmprotocol) for protocol solutions.

## Exporting low-code apps

You can include a low-code app in a package. This will include only the latest version of the app, and the version history of the app will be cleaned up in the export. When this package is imported onto a DMA, the resulting app version will be the one defined in the package.

See also: [Low-code app deployment behavior](xref:Deploying_a_catalog_item#low-code-app-deployment-behavior).

## Low-Code App Editor

The *Low Code App Extensions* script or "Low-Code App Editor" is an interactive Automation script that allows, among other things, the exporting of low-code apps (optionally including DOM instances) from a DataMiner System.

For more information on how to install and use this script, refer to [Low Code App Extensions](https://github.com/SkylineCommunications/Low-Code-App-Extensions).
