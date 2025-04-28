---
uid: github_reusable_workflows_dataminer_app_packages_master_workflow
---

# DataMiner App Packages Master Workflow

The DataMiner App Package Master Workflow should run on repositories containing one or more of the following DataMiner SDK-style projects:

- DataMiner Ad Hoc Data Source Project
- DataMiner Automation Script Library Project
- Dataminer Automation Script Project
- Dataminer Package Project
- Dataminer User-Defined API Project

This workflow will act as a quality gate and code coverage collection, only creating and uploading one or more artifacts of your Automation script solution to your private storage in the Catalog if it passes the Skyline quality gate job.

The following actions will be performed:

- [Validate inputs](#validate-inputs)
- [Enable Skyline NuGet sources](#enable-skyline-nuget-sources)
- [Start static code analysis](#start-static-code-analysis)
- [Run tests](#run-tests)
- [Build](#build)
- [Publish to Catalog](#publish-to-catalog)

> [!IMPORTANT]
> This workflow can run for both development or release cycles. A development cycle is any run that triggered from a change to a branch. A release cycle is any run that triggered from adding a tag with format `A.B.C.D` or `A.B.C`. During a development cycle, only the quality control actions are performed and artifact uploading is ignored. During a release cycle, an actual artifact is created and uploaded to the Catalog. A release cycle can also be a pre-release with versions of format `A.B.C.D-text` or `A.B.C-text`.

## Prerequisites

- Part of our quality control involves static code analysis through SonarCloud as a mandatory step. If you want to use this reusable workflow, you will need to have a SonarCloud organization setup, linked to your GitHub organization as described in the [SonarCloud help files](https://docs.sonarsource.com/sonarcloud/getting-started/github/).

- Creating a GitHub release or tag will attempt to register your item as a private item in the Catalog. For this, the repository must have access to a DATAMINER_TOKEN stored as a GitHub secret.

## How to use

### Manually creating the workflow

From within your own workflow .yml files, you can call a reusable workflow by adding a job that references the location on GitHub of the .yml file:

For example:

```yml
jobs:

  CI:
    uses: SkylineCommunications/_ReusableWorkflows/.github/workflows/DataMiner App Packages Master Workflow.yml@main
```

For most reusable workflows, several arguments and secrets need to be provided. You can find out which arguments and secrets by opening the reusable workflow and looking at the "inputs:" and "secrets:" sections located at the top of the file.

For example:

```yml
name: Skyline Reusable Quality Workflow

# Controls when the workflow will run
on:
  # Triggers the workflow on push or pull request events but only for the master branch
  push:
    branches: []
    tags:
      - "[0-9]+.[0-9]+.[0-9]+.[0-9]+"
      - "[0-9]+.[0-9]+.[0-9]+.[0-9]+-**"
      - "[0-9]+.[0-9]+.[0-9]+"
      - "[0-9]+.[0-9]+.[0-9]+-**"

  # Allows you to run this workflow manually from the Actions tab
  workflow_dispatch:

# A workflow run is made up of one or more jobs that can run sequentially or in parallel
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
      sonarCloudProjectName: ${{ vars.SONAR_NAME }} # Go to 'https://sonarcloud.io/projects/create' and create a project. Then create a SONAR_NAME variable with the ID of the project as mentioned in the SonarCloud project URL.
      # solutionFilterName: "MySolutionFilter.slnf"
    secrets:
      dataminerToken: ${{ secrets.DATAMINER_TOKEN }} # The API key: generated in the dataminer.services Admin app (https://admin.dataminer.services/) as authentication for a certain organization.
      sonarCloudToken: ${{ secrets.SONAR_TOKEN }} # The API key for access to SonarCloud.
      # overrideCatalogDownloadToken: ${{ secrets.OVERRIDE_DATAMINER_TOKEN }} # Override on the dataminerToken for downloading Catalog items: generated in the dataminer.services Admin app (https://admin.dataminer.services/) as authentication for a certain organization.
```

### Using Visual Studio templates

If you have the latest version of DIS installed, you can use the *DataMiner x Project* templates, which have the ability to add a **complete** GitHub Workflow. This is the reusable workflow described on this page.

## Skyline quality gate

### Validate inputs

Checks that the provided inputs and secrets are valid.

### Enable Skyline NuGet sources

Only triggers for Skyline Communications.

Attempts to add NuGet sources for Skyline Communications (Azure and GitHub private NuGet). This only triggers for the SkylineCommunications GitHub organization.

### Start static code analysis

Performs static code analysis using [SonarCloud](https://www.sonarsource.com/products/sonarcloud/). This will check for common errors and bugs found within C# code, track code coverage of your tests, and ensure clean code guidelines.

> [!NOTE]
> For public repositories in the *SkylineCommunications* organization, the analysis step uses the *SONAR_TOKEN* organization secret. For private repositories, you will need to create a repository secret with name *SONAR_TOKEN* (as private repositories cannot access the organization secret). For more information, see [GitHub secrets and tokens](xref:GitHub_Secrets).

### Run tests

Searches for any project ending with *Tests* or *UnitTests* and will then attempt to run all unit tests found. This will handle code regression and check whether all content behaves as expected by the developer.

### Build

Attempts to compile the Visual Studio solution after restoring all NuGet packages. This will check for compilation errors.

This step will create an application package (.dmapp). This will be provided as an artifact, which is directly downloadable from the run and can be used for manual testing.

### Publish to Catalog

This step performs the upload to the Catalog of all created application packages. Deployment is handled in other user-configured jobs.
