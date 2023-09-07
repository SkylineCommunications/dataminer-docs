---
uid: github_reusable_workflows_automation_master_workflow
---

# Automation master workflow

The Automation workflow should run on repositories containing an [Automation script solution](xref:Automation_scripts_as_a_Visual_Studio_solution) as provided by the DIS extension in Visual Studio.

It was migrated from a workflow using an [internal Jenkins pipeline](xref:Pipeline_stages_for_Automation_scripts) to handle automation and quality assurance within Skyline Communications.

At present, this workflow will not work on solutions containing SDK-style projects. It instead expects the legacy project style, which DIS provides automatically.

This workflow will act as a quality gate and code coverage collection, only creating and uploading an artifact of your Automation script solution to your private storage in the catalog if it passes the Skyline quality gate job.

> [!NOTE]
> This private storage is not yet accessible from within the Catalog UI.

The following actions will be performed:

- [Validate solution](#validate-solution)
- [Building](#building)
- [Unit tests](#unit-tests)
- [Analyze](#analyze)
- [Quality gate](#quality-gate)

Only when the actions above have been successful, will the "Artifact Registration and Upload" job be executed. This job will create an artifact (.dmapp) based on the Automation script solution and upload it, with the following steps:

- [NuGet restore solution](#nuget-restore-solution)
- [Upload artifact package](#upload-artifact-package)
- [Set artifact ID](#set-artifact-id)

> [!IMPORTANT]
> This workflow can run for both development or release cycles. A development cycle is any run that triggered from a change to a branch. A release cycle is any run that triggered from adding a tag with format `A.B.C.D` or `A.B.C`. During a development cycle, only the quality control actions are performed and artifact uploading is ignored (this means the secret "DATAMINER_DEPLOY_KEY" is optional). During a release cycle, an actual artifact is created and uploaded to the catalog (this means the secret "DATAMINER_DEPLOY_KEY" is required). A release cycle can also be a pre-release with versions of format `A.B.C.D-text` or `A.B.C-text`. 

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

### Analyze

Performs static code analysis using [SonarCloud](https://www.sonarsource.com/products/sonarcloud/). This will check for common errors and bugs found within C# code, track code coverage of your tests, and ensure clean code guidelines.

### Quality gate

Checks the results of all previous steps and combines them into a single result that will either block the workflow from continuing or allow it to continue to the next job.

## Artifact Registration and Upload job

### NuGet restore solution

This step makes sure creation of an application package (.dmapp) includes all assemblies used within NuGet packages in your Automation script solution.

### Upload artifact package

This step performs the Skyline Communications [Deploy Action](xref:Deploying_Automation_scripts_from_a_GitHub_repository), set to only "Upload", because deployment is handled in other user-configured jobs.

### Set artifact ID

If artifact creation and upload was successful, this step will make sure the ID to the artifact is returned so other jobs may use it to deploy or download the artifact.
