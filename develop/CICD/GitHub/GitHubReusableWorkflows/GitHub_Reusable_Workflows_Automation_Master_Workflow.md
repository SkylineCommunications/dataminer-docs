---
uid: github_reusable_workflows_automation_master_workflow
description: "Migrate automation script solutions from the retired Automation workflows to Skyline.DataMiner.Sdk projects and the Master Workflow."
keywords: Automation Master Workflow
---

# Automation workflow migration

> [!IMPORTANT]
> The Automation workflows are no longer available as of 2 November 2026. Migrate your solution to `Skyline.DataMiner.Sdk` projects and use the [Master Workflow](xref:github_reusable_workflows_master_workflow).
>
> This applies to all three entry points:
>
> - *Automation Master Workflow.yml*
> - *Automation Master SDK Workflow.yml*
> - *Automation Master Legacy Workflow.yml*
>
> These files are not retained as redirects. The former SDK-style Automation pipeline is also retired; changing only the workflow filename does not migrate the projects or their packaging configuration.

## Migrating to the Master Workflow

1. Convert your automation script solution to projects using the [Skyline DataMiner SDK](xref:skyline_dataminer_sdk).

1. Review the package configuration and the Catalog metadata in each package's *CatalogInformation* directory.

1. Replace the reusable workflow reference in your caller with `SkylineCommunications/_ReusableWorkflows/.github/workflows/Master Workflow.yml@main`.

1. Update the caller inputs and explicitly mapped secrets:

   | Former Automation contract | Master Workflow contract |
   |--|--|
   | Input `sonarCloudProjectName` | Input `sonarcloud-project-name` |
   | Secret `sonarCloudToken` | Secret `SONAR_TOKEN` |
   | Secret `api-key` | Secret `DATAMINER_TOKEN` |
   | Secret `azureToken` | Secret `AZURE_TOKEN` |

1. Remove the obsolete inputs `referenceName`, `runNumber`, `referenceType`, `repository`, and `owner`.

1. Review the [Master Workflow requirements](xref:github_reusable_workflows_master_workflow), including caller permissions and jobs that consume workflow outputs or artifacts.

1. Validate a branch build and a release using your normal release process before removing the old caller configuration.

## Example caller after migration

```yml
jobs:
  CI:
    permissions:
      contents: read
      id-token: write
      packages: write
      actions: read
      pull-requests: write
    uses: SkylineCommunications/_ReusableWorkflows/.github/workflows/Master Workflow.yml@main
    with:
      sonarcloud-project-name: my-org_my-automation
      # Only needed when the repository contains more than one solution:
      # solution-filter-name: MyAutomation.slnx
    secrets:
      SONAR_TOKEN: ${{ secrets.SONAR_TOKEN }}
      DATAMINER_TOKEN: ${{ secrets.DATAMINER_TOKEN }}
      AZURE_TOKEN: ${{ secrets.AZURE_TOKEN }}
```

Static analysis is optional. If you do not use SonarCloud, omit `sonarcloud-project-name` and its secret mapping.

Skyline-managed repositories can load credentials through OIDC and Azure Key Vault; external callers can provide secrets or their own OIDC configuration. See [GitHub secrets and tokens](xref:GitHub_Secrets).
