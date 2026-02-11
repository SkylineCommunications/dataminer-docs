---
uid: github_reusable_workflows_automation_master_workflow
---

# Automation Master Workflow

> [!IMPORTANT]
> For **Skyline.DataMiner.SDK** projects, refer to the [DataMiner App Package Master Workflow](xref:github_reusable_workflows_dataminer_app_packages_master_workflow).

The Automation Master Workflow should run on repositories containing an [Automation script solution](xref:Automation_scripts_as_a_Visual_Studio_solution) as provided by the DIS extension in Visual Studio.

It was migrated from a workflow using an [internal Jenkins pipeline](xref:Pipeline_stages_for_Automation_scripts) to handle automation and quality assurance within Skyline Communications.

This workflow will act as a quality gate and code coverage collection, only creating and uploading an artifact of your Automation script solution to your private storage in the catalog if it passes the Skyline quality gate job.

The following actions will be performed:

- [Validate solution](#validate-solution)
- [Building](#building)
- [Unit tests](#unit-tests)
- [Analyze](#analyze)
- [Quality gate](#quality-gate)

In parallel, the [Artifact Creation](#artifact-creation) and [Auto-Generating Catalog from GitHub](#auto-generating-catalog-from-github) jobs will be executed.

Only when the actions above and the "Artifact Creation" job have been successful, will the "Artifact Registration and Upload" job be executed. This job will upload an artifact (.dmapp) based on the automation script solution, with the following steps:

- [Upload artifact package](#upload-artifact-package)
- [Set artifact ID](#set-artifact-id)

> [!NOTE]
> This workflow makes use of the [GitHub to Catalog tool](xref:github_reusable_workflows#github-to-catalog-tool). For this tool to work, the GitHub repository must infer the Catalog item type using either naming conventions or GitHub topics.

> [!IMPORTANT]
> This workflow can run for both development or release cycles. A development cycle is any run that triggered from a change to a branch. A release cycle is any run that triggered from adding a tag with format `A.B.C.D` or `A.B.C`. During a development cycle, only the quality control actions are performed and artifact uploading is ignored (this means the secret "DATAMINER_TOKEN" is optional). During a release cycle, an actual artifact is created and uploaded to the Catalog (this means the secret "DATAMINER_TOKEN" is required). A release cycle can also be a pre-release with versions of format `A.B.C.D-text` or `A.B.C-text`.

## Prerequisites

- Either the repository’s name or a GitHub topic must be used to infer the Catalog item type.

  Automation script solutions (and therefore this workflow) can be used to create more than an automation script. They can contain ad hoc data sources, GQI queries, ChatOps extensions, etc. This reusable workflow requires that GitHub has information that defines the Catalog item type.

- Part of our quality control involves static code analysis through SonarCloud as a mandatory step. If you want to use this reusable workflow, you will need to have a SonarCloud organization setup, linked to your GitHub organization as described in the [SonarCloud help files](https://docs.sonarsource.com/sonarcloud/getting-started/github/).

- Creating a GitHub release or tag will attempt to register your item as a private item in the Catalog. For this, the repository must have access to a DATAMINER_TOKEN. For more information, see [GitHub secrets and tokens](xref:GitHub_Secrets).

## How to use

From within your own workflow .yml files, you can call a reusable workflow by adding a job that references the location on GitHub of the .yml file:

For example:

```yml
jobs:

  CI:
    uses: SkylineCommunications/_ReusableWorkflows/.github/workflows/Automation Master Workflow.yml@main
```

For most reusable workflows, several arguments and secrets need to be provided. You can find out which arguments and secrets by opening the reusable workflow and looking at the "inputs:" and "secrets:" sections located at the top of the file.

However, we recommend that you instead use one of the available [starter workflows](xref:github_starter_workflows) that in turn call one of our reusable workflows and that are preconfigured with most of the arguments.

For example:

```yml
jobs:

  CI:
    uses: SkylineCommunications/_ReusableWorkflows/.github/workflows/Automation Master Workflow.yml@main
    with:
      referenceName: ${{ github.ref_name }}
      runNumber: ${{ github.run_number }}
      referenceType: ${{ github.ref_type }}
      repository: ${{ github.repository }}
      owner: ${{ github.repository_owner }}
      sonarCloudProjectName: TODO: Go to 'https://sonarcloud.io/projects/create' and create a project. Then enter the id of the project as mentioned in the SonarCloud project URL here.
      # The API-key: generated in the dataminer.services Admin app (https://admin.dataminer.services/) as authentication for a certain DataMiner System.
    secrets:
      api-key: ${{ secrets.DATAMINER_TOKEN }}
      sonarCloudToken: ${{ secrets.SONAR_TOKEN }}
```

## Skyline quality gate

### Validate solution

Checks that the provided Visual Studio solution does not contain NuGets added through packages.config. Our CI/CD pipelines only work correctly using PackageReference.

### Building

Attempts to compile the Visual Studio solution after restoring all NuGet packages. This will check for compilation errors.

### Unit tests

Searches for any project ending with Tests or UnitTests and will then attempt to run all unit tests found. This will handle code regression and check that all content behaves as expected by the developer.

### Analyze

Performs static code analysis using [SonarCloud](https://www.sonarsource.com/products/sonarcloud/). This will check for common errors and bugs found within C# code, track code coverage of your tests, and ensure clean code guidelines.

> [!NOTE]
> For public repositories in the *SkylineCommunications* organization, the analysis step uses the *SONAR_TOKEN* organization secret. For private repositories, you will need to create a repository secret with name *SONAR_TOKEN* (as private repositories cannot access the organization secret). For more information, see [GitHub secrets and tokens](xref:GitHub_Secrets).

### Quality gate

Checks the results of all previous steps and combines them into a single result that will either block the workflow from continuing or allow it to continue to the next job.

## Artifact Creation

This job runs in parallel and will create the .dmapp package. This will be provided as an artifact, which is directly downloadable from the run and can be used for manual testing.

### NuGet restore solution

This step makes sure creation of an application package (.dmapp) includes all assemblies used within NuGet packages in your Automation script solution.

### Create .dmapp package

This step will create an application package (.dmapp) with the [Packager .NET Tool](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Tools.Packager).

## Auto-Generating Catalog from GitHub

This job runs in parallel and provides significant quality of life improvements. It will create an *auto-generated-catalog.yml* file. This automates the workflow so it can use the GitHub repository info to perform a valid upload to the Catalog without requiring the user to manually create a *catalog.yml* (or *manifest.yml*) file. It automates the requirements for Catalog registration as defined here.

> [!NOTE]
> You can still write and include your own *catalog.yml* (or *manifest.yml*) file directly in the root of the solution by following the information under [Registering a Catalog item](xref:Register_Catalog_Item). This will always override anything from the automatic generation. You can check what was automatically generated by looking at the *.githubtocatalog\auto-generated-catalog.yml* file that gets added to the repository.

## Artifact Registration and Upload job

### Upload artifact package

This step performs the upload with the [CatalogUpload .NET Tool](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Tools.CatalogUpload). Deployment is handled in other user-configured jobs.

### Set artifact ID

If artifact creation and upload were successful, this step will make sure the ID of the artifact is returned so other jobs can use it to deploy or download the artifact.
