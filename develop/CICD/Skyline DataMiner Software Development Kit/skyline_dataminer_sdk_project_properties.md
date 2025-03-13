---
uid: skyline_dataminer_sdk_project_properties
keywords: Skyline.DataMiner.Sdk, DataMinerType, GenerateDataMinerPackage, MinimumRequiredDmVersion, VersionComment, CatalogPublishKeyName, CatalogDefaultDownloadKeyName, UserSecretsId
---

# Skyline DataMiner SDK project properties

The Skyline DataMiner SDK uses several project properties to be able to generate and publish a DataMiner application package. Below, you can find an overview of these properties.

## DataMinerType

Supported types:

- [Package](xref:skyline_dataminer_sdk_dataminer_package_project)
- AutomationScript
- AutomationScriptLibrary
- AdHocDataSource
- UserDefinedApi

## GenerateDataMinerPackage

When the value is set to `true`, it will generate a DataMiner application package with the content of your project.

## MinimumRequiredDmVersion

Expected format: `A.B.C.D` or `A.B.C.D - buildNumber`

This will ensure that when a DataMiner application package is installed on a DataMiner Agent with a lower version, the installation will fail.

## Version

The version for the package. Needs to be a valid semantic version.

> [!NOTE]
> This will be overwritten during a workflow run when the GitHub workflows are used.

## VersionComment

The content of this is used for the version comment when a DataMiner application package is published to the Catalog.

> [!NOTE]
> This will be overwritten during a workflow run when the GitHub workflows are used.

## CatalogPublishKeyName

This is the name of the key defined either in Visual Studio User Secrets or as an environment variable. This key is used for publishing the DataMiner application package to the Catalog.

> [!NOTE]
> This will be overwritten during a workflow run when the GitHub workflows are used.

## CatalogDefaultDownloadKeyName

This is the name of the key defined either in Visual Studio User Secrets or as an environment variable. This key is used for downloading versions from the Catalog that are defined in the CatalogReferences.xml in the Package Project.

> [!NOTE]
> This will be overwritten during a workflow run when the GitHub workflows are used.

## UserSecretsId

Visual Studio will automatically fill this in when adding user secrets.
