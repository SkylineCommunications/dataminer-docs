---
uid: skyline_dataminer_sdk_dataminer_package_project_advanced
keywords: Skyline.DataMiner.Sdk, Package Project, overrideCatalogDownloadToken, OVERRIDE_DATAMINER_TOKEN, solutionFilterName
---

# Skyline DataMiner Package Project - Advanced

## Using a solution containing multiple packages

You can add multiple DataMiner package projects within a single solution and then use it to make different packages. The default behavior on building or publishing this solution through CI/CD is that all of the packages will have the same version and upload to the same organization.

Within a single solution, you can configure some advanced setups in order to:

- Release packages to different organizations
- Release packages with different versions

This is also supported with our reusable workflow (offered through the templates as the "complete" GitHub workflow): [DataMiner App Packages Master Workflow](xref:github_reusable_workflows_dataminer_app_packages_master_workflow).

In GitHub you can make several different workflows (or different jobs) that trigger the reusable workflow with different arguments that can change the behavior of the Build and Publish steps.

This is most easily handled using [Visual Studio 2022 solution filters (*.slnf)](xref:skyline_dataminer_sdk_solution_filter_files). These filters allow you to publish or build a specific subset of projects by providing the relevant dotnet-cli commands with a solution filter file.

### Using dotnet-cli

> [!NOTE]
> The examples below use explicit parameter names (e.g., `-p:CatalogPublishKeyName="DATAMINER_TOKEN"`), which allows you to use any environment variable name. When you omit these parameters, the SDK uses the default key name configured in your project's .csproj file.

#### Default call

By default, the following call is used to release every package in a solution to the same organization with the same version:

```bash
$env:DATAMINER_TOKEN = "MyOrgKey"
dotnet publish -p:Version="0.0.1" -p:VersionComment="This is just a pre-release version." -p:CatalogPublishKeyName="DATAMINER_TOKEN" -p:CatalogDefaultDownloadKeyName="DATAMINER_TOKEN"
```

#### Call with filters

To instead release only specific packages, a call with [solution filter files](xref:skyline_dataminer_sdk_solution_filter_files) is used, like in the following example:

- PackagesForOrganizationA.slnf
- PackagesForOrganizationB.slnf

```bash
$env:DATAMINER_TOKENA = "MyOrgAKey"
$env:DATAMINER_TOKENB = "MyOrgAKey"
dotnet publish PackagesForOrganizationA.slnf -p:Version="1.0.1" -p:VersionComment="Releasing 1.0.1 for A." -p:CatalogPublishKeyName="DATAMINER_TOKENA" -p:CatalogDefaultDownloadKeyName="DATAMINER_TOKENA"
dotnet publish PackagesForOrganizationB.slnf -p:Version="2.0.1" -p:VersionComment="Releasing 2.0.1 for B." -p:CatalogPublishKeyName="DATAMINER_TOKENB" -p:CatalogDefaultDownloadKeyName="DATAMINER_TOKENB"
```

### Using GitHub reusable workflows

When using GitHub reusable workflows as provided by Skyline Communications, you can optionally include a Visual Studio solution filter file that will adjust the behavior of the pipeline so it only builds, tests, and publishes the subsection defined by the filter.

#### Default job

This is the default job without filters:

```yml
jobs:

  CI:
    uses: SkylineCommunications/_ReusableWorkflows/.github/workflows/DataMiner App Packages Master Workflow.yml@main
    with:
      configuration: Release
      referenceName: ${{ github.ref_name }}
      runNumber: ${{ github.run_number }}
      referenceType: ${{ github.ref_type }}
      repository: ${{ github.repository }}
      owner: ${{ github.repository_owner }}
      sonarCloudProjectName: ${{ vars.SONAR_NAME }}
    secrets:
      dataminerToken: ${{ secrets.DATAMINER_TOKEN }}
      sonarCloudToken: ${{ secrets.SONAR_TOKEN }}
```

#### Jobs with filters

Below, an extra argument is added where the .slnf names can be defined. Both jobs are using a different secrets.DATAMINER_TOKEN, which allows uploading to different organizations in the same run.

```yml
jobs:

  CI-package1:
    uses: SkylineCommunications/_ReusableWorkflows/.github/workflows/DataMiner App Packages Master Workflow.yml@main
    with:
      configuration: Release
      referenceName: ${{ github.ref_name }}
      runNumber: ${{ github.run_number }}
      referenceType: ${{ github.ref_type }}
      repository: ${{ github.repository }}
      owner: ${{ github.repository_owner }}
      sonarCloudProjectName: ${{ vars.SONAR_NAME }}
      solutionFilterName: "PackagesForOrganizationA.slnf"
    secrets:
      dataminerToken: ${{ secrets.DATAMINER_TOKENA }}
      sonarCloudToken: ${{ secrets.SONAR_TOKEN }} 
  
  CI-package2:
    uses: SkylineCommunications/_ReusableWorkflows/.github/workflows/DataMiner App Packages Master Workflow.yml@main
    with:
      configuration: Release
      referenceName: ${{ github.ref_name }}
      runNumber: ${{ github.run_number }}
      referenceType: ${{ github.ref_type }}
      repository: ${{ github.repository }}
      owner: ${{ github.repository_owner }}
      sonarCloudProjectName: ${{ vars.SONAR_NAME }}
      solutionFilterName: "PackagesForOrganizationB.slnf"
    secrets:
      dataminerToken: ${{ secrets.DATAMINER_TOKEN_B }}
      sonarCloudToken: ${{ secrets.SONAR_TOKEN }} 
```

## Using different organization keys for downloading Catalog items and publishing a package

### Using dotnet-cli

#### Default call

Default call that releases every package in a solution to the same organization with the same version:

```bash
$env:DATAMINER_TOKEN = "MyOrgKey"
dotnet publish -p:Version="0.0.1" -p:VersionComment="This is just a pre-release version." -p:CatalogPublishKeyName="DATAMINER_TOKEN" -p:CatalogDefaultDownloadKeyName="DATAMINER_TOKEN"
```

#### Call with different organization key

Call that releases every package in a solution to the same organization with the same version, but with the difference that the referenced Catalog items will be downloaded with the other key:

```bash
$env:DATAMINER_TOKEN = "MyOrgKey"
$env:OVERRIDE_DATAMINER_TOKEN = "MyOtherOrgKey"
dotnet publish -p:Version="0.0.1" -p:VersionComment="This is just a pre-release version." -p:CatalogPublishKeyName="DATAMINER_TOKEN" -p:CatalogDefaultDownloadKeyName="OVERRIDE_DATAMINER_TOKEN"
```

### Using GitHub reusable workflows

When using GitHub reusable workflows as provided by Skyline Communications, if you are including packages from one organization in the Catalog but want your package to be published in another organization on Catalog, then you can add an override Catalog download token.

#### Default job

```yml
jobs:

  CI:
    uses: SkylineCommunications/_ReusableWorkflows/.github/workflows/DataMiner App Packages Master Workflow.yml@main
    with:
      configuration: Release
      referenceName: ${{ github.ref_name }}
      runNumber: ${{ github.run_number }}
      referenceType: ${{ github.ref_type }}
      repository: ${{ github.repository }}
      owner: ${{ github.repository_owner }}
      sonarCloudProjectName: ${{ vars.SONAR_NAME }}
    secrets:
      dataminerToken: ${{ secrets.DATAMINER_TOKEN }}
      sonarCloudToken: ${{ secrets.SONAR_TOKEN }}
```

#### Job with different organization key

Notice the addition of the extra argument below where you can define the other organization key.

```yml
jobs:

  CI:
    uses: SkylineCommunications/_ReusableWorkflows/.github/workflows/DataMiner App Packages Master Workflow.yml@main
    with:
      configuration: Release
      referenceName: ${{ github.ref_name }}
      runNumber: ${{ github.run_number }}
      referenceType: ${{ github.ref_type }}
      repository: ${{ github.repository }}
      owner: ${{ github.repository_owner }}
      sonarCloudProjectName: ${{ vars.SONAR_NAME }}
    secrets:
      dataminerToken: ${{ secrets.DATAMINER_TOKEN }}
      sonarCloudToken: ${{ secrets.SONAR_TOKEN }}
      overrideCatalogDownloadToken: ${{ secrets.OVERRIDE_DATAMINER_TOKEN }}
```

## Changing the cache location of Catalog items

When Catalog items are downloaded via the CatalogReferences, the items are added to a cache (similar to NuGet). The default location is `%USERPROFILE%\.dataminer-catalog-packages\packages` for Windows and `~/.dataminer-catalog-packages/packages` for other operating systems.

You can change this cache location by setting the environment variable *DATAMINER_CATALOG_PACKAGES*.
