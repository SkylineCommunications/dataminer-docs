---
uid: github_reusable_workflows_srm_function_master_workflow
---

# NuGet Solution Master Workflow

IN DEVELOPMENT - NOT RELEASED

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

Alternatively we recommended you instead use one of the available [Starter Workflows](uid:github_starter_workflows) that in turn call one of our reusable workflows and are pre-filled with most of the arguments.

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

## Steps

IN DEVELOPMENT - NOT RELEASED
