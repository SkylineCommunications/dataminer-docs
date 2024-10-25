---
uid: github_reusable_workflows_connector_master_workflow
---

# Connector master workflow

The Connector workflow should run on repositories containing a Connector Solution as provided by the DIS extension in Visual Studio.

This workflow will act as a quality gate and code coverage collection, only creating and uploading an artifact of your Connector solution to your private storage in the catalog if it passes the Skyline quality gate job.

The following actions will be performed:

- [Validate solution](#validate-solution)
- [Building](#building)
- [Unit tests](#unit-tests)
- [Connector Validator](#connector-validator)
- [Analyze](#analyze)
- [Quality gate](#quality-gate)

Only when the actions above have been successful, will the "Artifact Registration and Upload" job be executed. This job will create an artifact (.dmprotocol) based on the Connector solution and upload it, with the following steps:

- [NuGet restore solution](#nuget-restore-solution)
- [Upload artifact package](#upload-artifact-package)
- [Set artifact ID](#set-artifact-id)

In parallel to these stages it will execute two jobs:

- [Artifact Creation](#artifact-creation)
- [Auto-Generating Catalog from GitHub](#auto-generating-catalog-from-github)

> [!IMPORTANT]
> This workflow can run for both development or release cycles. A development cycle is any run that triggered from a change to a branch. A release cycle is any run that triggered from adding a tag with format `A.B.C.D` or `A.B.C`. During a development cycle, only the quality control actions are performed and artifact uploading is ignored (this means the secret "DATAMINER_DEPLOY_KEY" is optional). During a release cycle, an actual artifact is created and uploaded to the catalog (this means the secret "DATAMINER_DEPLOY_KEY" is required). A release cycle can also be a pre-release with versions of format `A.B.C.D-text` or `A.B.C-text`.

## Prerequisites

- Either the repository’s name or a GitHub topic must be used to infer the catalog item type.

- Part of our quality control involves static code analysis through sonarcloud as a mandatory step. When wishing to use this reusable workflow you'll be required to have a sonarcloud organization setup, linked to your GitHub Organization as described in [sonarcloud help files](https://docs.sonarsource.com/sonarcloud/getting-started/github/).

- Creating a GitHub Release or Tag will attempt to register your item to your private catalog. This requires the repository to have access to a DATAMINER_DEPLOY_KEY. You can find more information on secrets and on the [GitHub Secrets](xref:Github_Secrets) page.

## **GitHub UI to Catalog Details**

This workflow utilizes a tool that auto-generates an `auto-generated-catalog.yml` file, which can extend an existing `catalog.yml` (or `manifest.yml`) file by adding metadata and registration details for a catalog item. To function, the GitHub repository must infer the catalog item type using either naming conventions or GitHub topics.

For more information, see the [GitHubToCatalogYaml README](https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.Tools.GitHubToCatalogYaml#readme-body-tab), specifically the section on [Inferring Catalog Item Type](https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.Tools.GitHubToCatalogYaml?tab=readme-ov-file#inferring-catalog-item-type).

## How to use

From within your own workflow .yml files, you can call a reusable workflow by adding a job that references the location on GitHub of the .yml file:

For example:

```yml
jobs:

  CI:
    uses: SkylineCommunications/_ReusableWorkflows/.github/workflows/Connector Master Workflow.yml@main
```

For most reusable workflows, several arguments and secrets need to be provided. You can find out which arguments and secrets by opening the reusable workflow and looking at the "inputs:" and "secrets:" sections located at the top of the file.

However, we recommend that you instead use one of the available [starter workflows](xref:github_starter_workflows) that in turn call one of our reusable workflows and that are preconfigured with most of the arguments.

For example:

```yml
jobs:

  CI:
    uses: SkylineCommunications/_ReusableWorkflows/.github/workflows/Connector Master Workflow.yml@main
    with:
      referenceName: ${{ github.ref_name }}
      runNumber: ${{ github.run_number }}
      referenceType: ${{ github.ref_type }}
      repository: ${{ github.repository }}
      owner: ${{ github.repository_owner }}
      sonarCloudProjectName: TODO: Go to 'https://sonarcloud.io/projects/create' and create a project. Then enter the id of the project as mentioned in the SonarCloud project URL here.
      # The API-key: generated in the DCP Admin app (https://admin.dataminer.services/) as authentication for a certain DataMiner System.
    secrets:
      api-key: ${{ secrets.DATAMINER_DEPLOY_KEY }}
      sonarCloudToken: ${{ secrets.SONAR_TOKEN }}
```

## Skyline quality gate

### Validate solution

Checks that the provided Visual Studio solution does not contain NuGets added through packages.config. Our CI/CD pipelines only work correctly using PackageReference.

### Building

Attempts to compile the Visual Studio solution after restoring all NuGet packages. This will check for compilation errors.

### Unit tests

Searches for any project ending with Tests or UnitTests and will then attempt to run all unit tests found. This will handle code regression and check that all content behaves as expected by the developer.

### Connector Validator

This step runs the DataMiner Connector Validator, also included with DIS, to verify the XML and DataMiner-specific code for any errors. A quality gate will then determine whether the process passes or is blocked.

### Analyze

Performs static code analysis using [SonarCloud](https://www.sonarsource.com/products/sonarcloud/). This will check for common errors and bugs found within C# code, track code coverage of your tests, and ensure clean code guidelines.

> [!NOTE]
> For public repositories in SkylineCommunications, the analysis step uses the SONAR_TOKEN organization secret. For private repositories, you will need to create a repository secret with name SONAR_TOKEN (as private repositories cannot access the organization secret). You can find more information on secrets and on the [GitHub Secrets](xref:Github_Secrets) page.

### Quality gate

Checks the results of all previous steps and combines them into a single result that will either block the workflow from continuing or allow it to continue to the next job.

## Artifact Registration and Upload job

### NuGet restore solution

This step makes sure creation of an application package (.dmprotocol) includes all assemblies used within NuGet packages in your Connector solution.

### Upload artifact package

This step performs the Skyline Communications [Deploy Action](xref:Marketplace_deployment_action), set to only "Upload", because deployment is handled in other user-configured jobs.

### Set artifact ID

If artifact creation and upload was successful, this step will make sure the ID to the artifact is returned so other jobs may use it to deploy or download the artifact.

## Artifact Creation

This job runs in parallel and will create the .dmapp package. This will be provided as an artifact, downloadable directly from the run and can be used for manual testing.

## Auto-Generating Catalog from GitHub

This job runs in parallel and provides significant quality of life improvements. It will create an auto-generated-catalog.yml file. This automates the workflow so it can use the GitHub Repository info to perform a valid upload to the catalog without requiring the user to manually create a catalog.yml (or manifest.yml). It automates the requirements for catalog registrations as defined here.

> [!NOTE]
> You can still write and include your own catalog.yml (or manifest.yml) file directly in the root of the solution following the information on the [Registering a Catalog Item](xref:Register_Catalog_Item) page. This will always override anything from the automatic generation. You can check what was automatically generated by looking at the ".githubtocatalog\auto-generated-catalog.yml" file that gets added to the repository.
