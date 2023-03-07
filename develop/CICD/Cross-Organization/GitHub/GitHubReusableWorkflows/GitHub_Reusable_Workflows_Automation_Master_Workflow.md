---
uid: github_reusable_workflows_automation_master_workflow
---

# Automation master workflow

The Automation workflow should run on repositories containing an [Automation script solution](xref:Automation_scripts_as_a_Visual_Studio_solution) as provided by the DIS extension in Visual Studio.
It is a migration of what was originally an [internal Jenkins pipelines](xref:Pipeline_stages_for_Automation_scripts) to handle automation and quality assurance within Skyline Communications.
It currently will not work on solutions containing SDK-style projects but instead expects the legacy project style (DIS provides this automatically)

This workflow will act as a quality gate and code coverage collection, only creating and uploading an artifact of your Automation script solution to the catalog if it passes the Skyline Quality Gate job.

The following will be performed:

- [Validate Solution](#validate-solution)
- [Building](#building)
- [Unit Tests](#unit-tests)
- [Analyze](#analyze)
- [Quality Gate](#quality-gate)

Only when passing the above jobs, the "Artifact Registration and Upload" job will be executed: This job will create an artifact (.dmapp) out of the Automation script solution and upload it with the following steps:

- [NuGet restore solution](#nuget-restore-solution)
- [Upload artifact Package](#upload-artifact-package)
- [Set artifact ID](#set-artifact-id)

> [!IMPORTANT]
> This workflow can run for both development or release cycles. > A development cycle is any run that triggered from a change on a branch.
> A release cycle is any run that triggered from adding a tag with format `A.B.C.D`.
> During the development cycle, the version of an artifact automatically includes the run number.
> During the release cycle, the version of the artifact is the tag provided.

## How to use

From within your own workflow .yml files, you can call a reusable workflow by adding a job that references the location on GitHub of the '.yml' file:
For Example:

'''yaml
jobs:

  CI:
    uses: SkylineCommunications/_ReusableWorkflows/.github/workflows/Automation Master Workflow.yml@main
'''

Most reusable workflows require several arguments and secrets to be passed along.
You can find which those are by opening the reusable workflow and looking at the 'inputs:' and 'secrets:' sections located at the top of the file.

However, we instead recommended to use one of the available [Starter Workflows](xref:github_starter_workflows) that in turn call one of our reusable workflows and are preconfigured with most of the arguments.

For example:
'''yaml
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
'''

## Skyline quality gate

### Validate solution

Checks that the provided Visual Studio solution does not contain NuGets added through packages.config. Our CI/CD Pipelines only work correctly using packagereference.

### Building

Attempts to compile the Visual Studio solution after restoring all NuGet packages.
This will check for compilation errors.

### Unit Tests

Searches for any project ending with Tests or UnitTests and will then attempt to run all unit tests found.
This will handle code regression and check that all content behaves as expected by the developer.

### Analyze

Performs static code analysis using [SonarCloud](https://www.sonarsource.com/products/sonarcloud/).
This will check for common errors and bugs found within C# code, track code coverage of your tests and ensure clean code guidelines.

### Quality Gate

Will check the results of all previous steps and combine them into a single result that will either block the workflow from continuing or allow it to continue to the next job.

## Artifact Registration and Upload job

### NuGet restore solution

This is required to make sure creation of an application package (.dmapp) includes all assemblies used within NuGet packages in your Automation script solution.

### Upload artifact Package

This will perform the Skyline Communications [Deploy Action](xref:Deploying_Automation_scripts_from_a_GitHub_repository). Specifically set to only "Upload" as Deployment is handled in other user-configured jobs.

### Set artifact Id

If artifact creation and upload was successful, this step will make sure the ID to the artifact is returned so other jobs may use it to deploy or download the artifact.
