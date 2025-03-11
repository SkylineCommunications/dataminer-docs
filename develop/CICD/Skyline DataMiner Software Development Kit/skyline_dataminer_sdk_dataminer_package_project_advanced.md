---
uid: skyline_dataminer_sdk_dataminer_package_project_advanced
keywords: Skyline.DataMiner.Sdk, Package Project, overrideCatalogDownloadToken, OVERRIDE_DATAMINER_TOKEN, solutionFilterName
---

# Skyline DataMiner Package Project - Advanced

## Multiple packages

You can add multiple DataMiner package projects within a single solution and then have them make different packages. The default behavior on building or publishing this solution through CI/CD is that all of them will have the same version and upload to the same organization.

Within a single solution, you can configure some advanced setups in order to:

- Release packages to different organizations
- Release packages with different versions

This is also supported with our reusable workflow (offered through the templates as the "Complete" GitHub Workflow): [DataMiner App Packages Master Workflow](xref:github_reusable_workflows_dataminer_app_packages_master_workflow).

In GitHub you can make several different workflows (or different jobs) that trigger the reusable workflow with different arguments that can change the behavior of the Build and Publish steps.

This is most easily handled using Visual Studio Solution filters.

### Visual Studio solution filter files

A **solution filter** (`.slnf`) file in Visual Studio 2022 is a feature designed to load a subset of projects within a larger solution (`.sln`). This is particularly useful for large solutions that contain many projects, as it allows developers to work only with the relevant projects, improving load times and reducing resource consumption.

Within Skyline DataMiner SDK, they provide an additional key benefit. You can easily publish or build a specific subset of projects by providing those dotnet-cli commands with a solution filter file. This can allow you to independently version or release different DataMiner application packages.

For more information on how to make such filters, refer to [Visual Studio 2022 solution filter (*.slnf) files](xref:skyline_dataminer_sdk_solution_filter_files).

### dotnet-cli

#### Default

Default call that releases every package in a solution to the same organization with the same version:

```bash
$env:DATAMINER_TOKEN = "MyOrgKey"
dotnet publish -p:Version="0.0.1" -p:VersionComment="This is just a pre-release version." -p:CatalogPublishKeyName="DATAMINER_TOKEN" -p:CatalogDefaultDownloadKeyName="DATAMINER_TOKEN"
```

#### With filters

Call that releases only packages configured with either of the provided solution filter files:

- PackagesForOrganizationA.slnf
- PackagesForOrganizationB.slnf

```bash
$env:DATAMINER_TOKENA = "MyOrgAKey"
$env:DATAMINER_TOKENB = "MyOrgAKey"
dotnet publish PackagesForOrganizationA.slnf -p:Version="1.0.1" -p:VersionComment="Releasing 1.0.1 for A." -p:CatalogPublishKeyName="DATAMINER_TOKENA" -p:CatalogDefaultDownloadKeyName="DATAMINER_TOKENA"
dotnet publish PackagesForOrganizationB.slnf -p:Version="2.0.1" -p:VersionComment="Releasing 2.0.1 for B." -p:CatalogPublishKeyName="DATAMINER_TOKENB" -p:CatalogDefaultDownloadKeyName="DATAMINER_TOKENB"
```

### GitHub reusable workflows

When using GitHub reusable workflows as provided by Skyline Communications, you can optionally include a Visual Studio solution filter file that will adjust the behavior of the pipeline so it only builds, tests, and publishes the subsection defined by the filter.

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

#### Jobs with filters

Notice the addition of the extra argument below where you can define the .slnf names. Both jobs are using a different secrets.DATAMINER_TOKEN, which allows uploading to different organizations in the same run.

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

## Using different organization keys for downloading Catalog items and publishing package

### dotnet-cli

#### Default

Default call that releases every package in a solution to the same organization with the same version:

```bash
$env:DATAMINER_TOKEN = "MyOrgKey"
dotnet publish -p:Version="0.0.1" -p:VersionComment="This is just a pre-release version." -p:CatalogPublishKeyName="DATAMINER_TOKEN" -p:CatalogDefaultDownloadKeyName="DATAMINER_TOKEN"
```

#### With different organization key

Default call that releases every package in a solution to the same organization with the same version:

```bash
$env:DATAMINER_TOKEN = "MyOrgKey"
$env:OVERRIDE_DATAMINER_TOKEN = "MyOtherOrgKey"
dotnet publish -p:Version="0.0.1" -p:VersionComment="This is just a pre-release version." -p:CatalogPublishKeyName="DATAMINER_TOKEN" -p:CatalogDefaultDownloadKeyName="OVERRIDE_DATAMINER_TOKEN"
```

### GitHub reusable workflows

When using GitHub reusable workflows as provided by Skyline Communications and you are including packages from one organization on Catalog but want your package in another organization on Catalog, then you can add an override Catalog download token.

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

## Change cache location of Catalog items

When downloading Catalog items via the CatalogReferences, the items are added to a cache (similar like NuGet). The default location is `%USERPROFILE%\.dataminer-catalog-packages\packages` for Windows and `~/.dataminer-catalog-packages/packages` for other operating systems.

This cache location can be changed by setting an environment variable `DATAMINER_CATALOG_PACKAGES`.
