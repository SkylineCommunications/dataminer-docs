---
uid: CreatingApplicationPackages
---

# Creating application packages

There are currently two ways to create application packages:

- Infrastructure as Code (IaC)
- using the Application package builder API

## Infrastructure as Code (IaC)

> [!IMPORTANT]
> This section might include some information that is only applicable to Skyline employees and/or links that are only accessible to Skyline employees.

Infrastructure as Code is the practice where you can use a descriptive model (i.e. code) for provisioning and deploying resources. This enables using version control and link it with CI/CD pipelines just as any other codebase. IaC also allows to have a repeatable way of provisioning and deploying resources.

Skyline employees can use the SLC SE Repository Manager tool to create a repository for an application install package. For more information, refer to [Creating a repository for an install package](xref:Creating_a_repository_for_an_install_package#packages).

The repository contains a Visual Studio solution which consists of the following components:

- A **manifest**. The manifest provides information about the install package such as its name and version and content. The manifest is an XML file and more info about the manifest XML schema can be found in [Package manifest schema](xref:SchemaPackageManifest).
- An **install script**. This is an Automation script that gets executed when the application package is installed on DataMiner. This install script allows performing custom actions (e.g. creating an element that runs a connector that is included in the application package).

The repository is linked to a CI/CD pipeline that will create the application package as an artifact. For more information about this pipeline refer to [Pipeline stages for install packages](xref:Pipeline_stages_for_install_packages).

## Application package builder API

The application package builder API is an API that can be used to creating application packages. The API is available as a NuGet package: [Skyline.DataMiner.Core.AppPackageCreator](https://www.nuget.org/packages/Skyline.DataMiner.Core.AppPackageCreator).

The API documentation can be found [here](xref:Skyline.AppInstaller).
