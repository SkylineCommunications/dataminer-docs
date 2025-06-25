---
uid: github_reusable_workflows_nuget_solution_master_workflow
---

# NuGet Solution Master Workflow

> [!IMPORTANT]
> This workflow is intended for internal use at Skyline Communications as it uses Skyline-specific validation. However, you can use it as a baseline and adjust it for use elsewhere by replacing the validation step with your own.

The NuGet Solution Master Workflow is designed to run on repositories containing the DataMiner NuGet Package Solution provided by the DIS extension in Visual Studio or from [Skyline.DataMiner.VisualStudioTemplates](https://www.nuget.org/packages/Skyline.DataMiner.VisualStudioTemplates#readme-body-tab).

This workflow is a migration of the original [internal Jenkins pipelines](xref:Pipeline_stages_for_custom_solutions) used for automation and quality assurance within Skyline Communications.

To use this workflow, your Visual Studio solution must consist of SDK-style projects. If you are migrating an existing library, you will need to convert it to SDK style. You can for example do so using the following dotnet tool: [Project2015To2017.Migrate2019.Tool](https://www.nuget.org/packages/Project2015To2017.Migrate2019.Tool). Alternatively, you can create a new solution with the template and then move all content from the old solution.

The goal of this workflow is to automatically create and upload reusable .NET libraries if they pass certain quality standards. The workflow acts as a quality gate and code coverage collection before attempting to create and publish a NuGet package to nuget.org. Publishing only occurs during release cycles.

- Skyline quality gate:

  - [Validate NuGet metadata](#validate-nuget-metadata)
  - [Building](#building)
  - [Unit tests](#unit-tests)
  - [Analyze](#analyze)
  - [Quality gate](#quality-gate)

  If the library passes these checks, the job will archive the created NuGet package and provide it as an artifact. The next job will attempt to push the package.

- Push:

  - [Push to GitHub NuGet registry](#push-to-github-nuget-registry)

> [!IMPORTANT]
> This workflow can run for both development or release cycles. A development cycle is any run that triggered from a change on a branch. A release cycle is any run that triggered from adding a tag with format A.B.C or A.B.C-text. During the development cycle, the version of an artifact automatically includes the run number. The .nupkg is available as artifact on GitHub. During the release cycle, the version of the artifact becomes the tag provided and the .nupkg is published on nuget.org. A release cycle can also release a pre-release version of a NuGet package. To do so, simply tag with format A.B.C-text. (e.g. 1.0.1-AlphaOne).

## How to use

From within your own workflow .yml files, you can call a reusable workflow by adding a job that references the location on GitHub of the .yml file:

For example:

```yml
jobs:

  CI:
    uses: SkylineCommunications/_ReusableWorkflows/.github/workflows/Internal NuGet Solution Master Workflow.yml@main
```

For most reusable workflows, several arguments and secrets need to be provided. You can find out which arguments and secrets by opening the reusable workflow and looking at the "inputs:" and "secrets:" sections located at the top of the file.

However, we recommend that you instead use one of the available [starter workflows](xref:github_starter_workflows) that in turn call one of our reusable workflows and that are preconfigured with most of the arguments.

For more information on GitHub secrets, see [GitHub secrets and tokens](xref:GitHub_Secrets).

For example:

```yml
jobs:

  CI:
    uses: SkylineCommunications/_ReusableWorkflows/.github/workflows/Internal NuGet Solution Master Workflow.yml@main
    with:
      referenceName: ${{ github.ref_name }}
      runNumber: ${{ github.run_number }}
      referenceType: ${{ github.ref_type }}
      repository: ${{ github.repository }}
      owner: ${{ github.repository_owner }}
      sonarCloudProjectName: TODO: Go to 'https://sonarcloud.io/projects/create' and create a project. Then enter the id of the project as mentioned in the sonarcloud project URL here.
    secrets:
      sonarCloudToken: ${{ secrets.SONAR_TOKEN }}
      nugetApiKey: ${{ secrets.NUGETAPIKEY_GITHUB }}
```

## Skyline quality gate

### Validate NuGet metadata

Validates if the provided solution has all technical requirements for an official Skyline Communications NuGet package.

You can find all requirements under [GitHub validation requirements](xref:github_validation_requirements).

A lot of requirements are preconfigured when the [Skyline.DataMiner.VisualStudioTemplates](https://www.nuget.org/packages/Skyline.DataMiner.VisualStudioTemplates#readme-body-tab) are used.

### Building

Attempts to compile the Visual Studio solution after restoring all NuGet packages. This will check for compilation errors.

### Unit Tests

Searches for any project ending with Tests or UnitTests and will then attempt to run all unit tests found. This will handle code regression and check that all content behaves as expected by the developer.

### Analyze

Performs static code analysis using [SonarCloud](https://www.sonarsource.com/products/sonarcloud/). This will check for common errors and bugs found within C# code, track code coverage of your tests, and ensure clean code guidelines.

> [!NOTE]
> For public repositories, the analysis step uses the SONAR_TOKEN organization secret. For private repositories, you will need to create a repository secret with name SONAR_TOKEN (as private repositories cannot access the organization secret). For more information, see [GitHub secrets and tokens](xref:GitHub_Secrets).

### Quality gate

Checks the results of all previous steps and combines them into a single result that will either block the workflow from continuing or allow it to continue to the next job.

## Push

### Push to GitHub NuGet registry

If this is a release cycle, the NuGet packages are published to the [Skyline Communications GitHub NuGet registry](https://github.com/orgs/SkylineCommunications/packages).

These can be both stable releases (A.B.C) or pre-releases.(A.B.C-text).
