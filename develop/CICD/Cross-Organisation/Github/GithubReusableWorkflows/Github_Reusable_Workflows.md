---
uid: github_reusable_workflows
---

# Github Reusable Workflows

Where a [Github Action](xref:github_actions) can provide an easy access point to a single key action, the reusable workflow takes this up a notch.
A Github reusable workflow allows the re-use of a combination of many different Github Actions and other scripts, running across several jobs combined into a single easy call.

It provides versioning and can be called in a such a way to always use the latest stable version.
This contrary to [Starter Workflows](xref:github_starter_workflows) that copy and paste a template workflow without the ability to run the 'last version'.

Skyline Communications provides most Quality Control and Automation through reusable workflows, allowing us to improve and tweak them based on user feedback or corporate changes and immediately apply the changes to any workflow using them on github.
These reusable workflows are public and can be accessed by any organisation. They can also be forked and used as a starting point to be adjusted by other CI/CD Engineers to match their organisations quality standards.

> [!NOTE]
> If you're a CI/CD engineer looking to save time when building workflows, consider starting from the source code of a reusable workflow. Do note that reusable workflows are internally complex, often combining multiple tools across several jobs and steps to meet quality standards, automation requirements, and edge cases.
> Many out-of-the-box actions provided online may be lacking in functionality, requiring additional code to prepare a solution before using these standard actions. We prefer using dotnet tools over scripting code because they allow for clean versioning, reusability, and unit testing of our code. The source code for these tools is currently internal to Skyline Communications, but the dotnet tools themselves are available for use and can be found here: 

## Available Reusable Workflows

You can find all available reusable workflows in a repository called [_ReusableWorkflows](https://github.com/SkylineCommunications/_ReusableWorkflows/tree/main/.github/workflows)

For more details about what exactly each workflow does you can check one of the below links:

- [Automation Master Workflow](xref:github_reusable_workflows_automation_master_workflow)
- [NuGet Solution Master Workflow](xref:github_reusable_workflows_nuget_solution_master_workflow)
- [SRM Function Master Workflow](xref:github_reusable_workflows_srm_function_master_workflow)

## How to use

From within your own workflow yml files you can call a reusable workflow by adding a job that references the location on github of the '.yml' file:
For Example:
'''yaml
jobs:

  CI:
    uses: SkylineCommunications/_ReusableWorkflows/.github/workflows/Automation Master Workflow.yml@main
'''

Most reusable workflows require several arguments and secrets to be passed along.
You can find which those are by opening the reusable workflow and looking at the 'inputs:' and 'secrets:' sections located at the top of the file.

Alternatively we recommended you instead use one of the available [Starter Workflows](xref:github_starter_workflows) that in turn call one of our reusable workflows and are pre-filled with most of the arguments.

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
      sonarCloudProjectName: TODO: Go to 'https://sonarcloud.io/projects/create' and create a project. Then enter the id of the project as mentioned in the sonarcloud project url here.
      # The API-key: generated in the DCP Admin app (https://admin.dataminer.services/) as authentication for a certain DataMiner System.
    secrets:
      api-key: ${{ secrets.DATAMINER_DEPLOY_KEY }}
      sonarCloudToken: ${{ secrets.SONAR_TOKEN }}
'''
