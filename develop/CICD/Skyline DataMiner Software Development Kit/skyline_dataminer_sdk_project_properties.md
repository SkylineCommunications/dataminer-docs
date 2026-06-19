---
uid: skyline_dataminer_sdk_project_properties
keywords: Skyline.DataMiner.Sdk, DataMinerType, GenerateDataMinerPackage, MinimumRequiredDmVersion, MinimumRequiredDmWebVersion, VersionComment, CatalogPublishKeyName, CatalogDefaultDownloadKeyName, UserSecretsId
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

Expected format: `A.B.C.D - buildNumber`

This will ensure that when a DataMiner application package is installed on a DataMiner Agent with a lower version, the installation will fail.

## MinimumRequiredDmWebVersion

Available from Skyline DataMiner SDK 2.4 onwards.

Expected format: `A.B.C (CUX)` (e.g. `10.6.2 (CU0)`)

This allows you to define the minimum required DataMiner web version independently from the minimum required DataMiner core version. This will ensure that when a DataMiner application package is installed on a system with a lower DataMiner web version, the installation will fail.

This property is useful because the core and web versions do not always evolve at the same pace. Each cumulative update of a Main Release includes the same web app changes as the corresponding Feature Release.

For example:

- If your package depends on DataMiner core 10.5.9 but relies on a web feature introduced in 10.6.3, you can keep the core requirement at 10.5.9 and set a higher minimum web version. This allows users who manually upgraded their web components to deploy your application without a full DataMiner upgrade.

- If you want to support a 10.6 Main Release core system but require web features from 10.6.3, setting only a core requirement of 10.6 would still allow deployment on systems running 10.6.2. By also setting a minimum web version, you can block deployment on such systems unless the web version has been manually upgraded.

## Version

The version for the package. This needs to be a valid semantic version. See [Versioning of Catalog items](xref:About_the_Catalog_app#versioning-of-catalog-items).

> [!NOTE]
> This will be overwritten during a workflow run when the [GitHub reusable workflows](xref:github_reusable_workflows) are used.

## VersionComment

The content of this is used for the version comment when a DataMiner application package is published to the Catalog.

> [!NOTE]
> This will be overwritten during a workflow run when the [GitHub reusable workflows](xref:github_reusable_workflows) are used.

## CatalogPublishKeyName

This is the name of the key defined either in Visual Studio User Secrets or as an environment variable. This key is used for publishing the DataMiner application package to the Catalog.

> [!NOTE]
>
> - This will be overwritten during a workflow run when the [GitHub reusable workflows](xref:github_reusable_workflows) are used.
> - When using environment variables, replace colons (`:`) in the key name with double underscores (`__`). For example, if the .csproj file specifies `skyline:sdk:dataminertoken`, the corresponding environment variable should be named `skyline__sdk__dataminertoken`.

## CatalogDefaultDownloadKeyName

This is the name of the key defined either in Visual Studio User Secrets or as an environment variable. This key is used for downloading versions from the Catalog that are defined in the *CatalogReferences.xml* in the package project.

> [!NOTE]
>
> - This will be overwritten during a workflow run when the [GitHub reusable workflows](xref:github_reusable_workflows) are used.
> - When using environment variables, replace colons (`:`) in the key name with double underscores (`__`). For example, if the .csproj file specifies `skyline:sdk:dataminertoken`, the corresponding environment variable should be named `skyline__sdk__dataminertoken`.

## UserSecretsId

Visual Studio will automatically fill this in when adding user secrets.
