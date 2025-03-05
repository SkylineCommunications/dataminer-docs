---
uid: skyline_dataminer_sdk_project_properties
keywords: Skyline.DataMiner.Sdk, DataMinerType, GenerateDataMinerPackage, MinimumRequiredDmVersion, VersionComment, CatalogPublishKeyName, CatalogDefaultDownloadKeyName, UserSecretsId
---

# Skyline DataMiner SDK - Project Properties

The Skyline DataMiner SDK uses several project properties to be able to generate and publish a DataMiner application package.

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

This will ensure that when installing a DataMiner application package on a DataMiner with a lower version, the installation will fail.

## Version

The version for the package. Needs to be a valid semantic version.

> [!NOTE]
> This will be overwritten during a workflow run when using the GitHub workflows.

## VersionComment

The content of this is used for the version comment when publishing a DataMiner application package to the Catalog.

> [!NOTE]
> This will be overwritten during a workflow run when using the GitHub workflows.

## CatalogPublishKeyName

This is the name of the key defined either in Visual Studio User Secrets or as an environment variable. This key is used for publishing the DataMiner application package to the Catalog.

> [!NOTE]
> This will be overwritten during a workflow run when using the GitHub workflows.

## CatalogDefaultDownloadKeyName

This is the name of the key defined either in Visual Studio User Secrets or as an environment variable. This key is used for downloading versions from the Catalog that are defined in the CatalogReferences.xml in the Package Project.

> [!NOTE]
> This will be overwritten during a workflow run when using the GitHub workflows.

## UserSecretsId

Visual Studio will automatically fill this in when adding user secrets.
