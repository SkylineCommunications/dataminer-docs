---
uid: github_reusable_workflows
---

# GitHub reusable workflows

Where a [GitHub Action](xref:Deploying_Automation_scripts_from_a_GitHub_repository) can provide an easy access point to a single key action, the reusable workflow takes this up a notch. A GitHub reusable workflow allows the re-use of a combination of many different GitHub actions and other scripts, running across several jobs combined into a single easy call.

It provides versioning and can be called in such a way to always use the latest stable version. This is different from [starter workflows](xref:github_starter_workflows), which copy and paste a template workflow without the ability to run the "latest version".

Skyline Communications provides most quality control and automation through reusable workflows. Any changes we implement when we improve or tweak these workflows, for example based on user feedback, will also immediately be applied to any workflows on GitHub based on them.

These reusable workflows are public and can be accessed by any organization. They can also be forked and used as a starting point for other CI/CD engineers, who can adjust them to match their organization's quality standards.

> [!NOTE]
> If you are a CI/CD engineer looking to save time when building workflows, consider starting from the source code of a reusable workflow. Do note that reusable workflows are internally complex, often combining multiple tools across several jobs and steps to meet quality standards, automation requirements, and edge cases. Many out-of-the-box actions provided online may be lacking in functionality, requiring additional code to prepare a solution before these standard actions are used. We prefer using dotnet tools over scripting code because they allow for clean versioning, reusability, and unit testing of our code. The source code for these tools is currently internal to Skyline Communications, but the dotnet tools themselves are available for use and can be found here: <https://www.nuget.org/packages?q=Skyline.Communications.CICD.Tools&frameworks=&tfms=&packagetype=&prerel=true&sortby=relevance>

## Available reusable workflows

You can find all available reusable workflows in the [_ReusableWorkflows](https://github.com/SkylineCommunications/_ReusableWorkflows/tree/main/.github/workflows) repository.

For more details about what each workflow does, you can check one of the below links:

- [Automation Master Workflow](xref:github_reusable_workflows_automation_master_workflow)
- [NuGet Solution Master Workflow](xref:github_reusable_workflows_nuget_solution_master_workflow)
- [SRM Function Master Workflow](xref:github_reusable_workflows_srm_function_master_workflow)

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
