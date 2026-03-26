---
uid: github_reusable_workflows_update_catalog_details
---

# Update Catalog Details

The Update Catalog Details workflow can run on any repository. It is intended to update only the Catalog metadata and details without uploading new versions of artifacts.

This is an optional workflow. Running the regular automation script or connector reusable workflows will perform the same actions, but with additional quality control and the ability to release new artifacts.

The following actions will be performed:

- [Create or extend catalog.yml](#create-or-extend-catalogyml)
- [Commit and push auto-generated-catalog.yml](#commit-and-push-auto-generated-catalogyml)
- [Retrieve readme](#retrieve-readme)
- [Retrieve images](#retrieve-images)
- [Upload to Catalog](#upload-to-catalog)

> [!NOTE]
> This workflow makes use of the [GitHub to Catalog tool](xref:github_reusable_workflows#github-to-catalog-tool). For this tool to work, the GitHub repository must infer the Catalog item type using either naming conventions or GitHub topics.

## How to use

From within your own workflow .yml files, you can call a reusable workflow by adding a job that references the location on GitHub of the .yml file:

For example:

```yml
jobs:

  CI:
    uses: SkylineCommunications/_ReusableWorkflows/.github/workflows/Update Catalog Details Workflow.yml@main
```

For most reusable workflows, several arguments and secrets need to be provided. You can find out which arguments and secrets by opening the reusable workflow and looking at the "inputs:" and "secrets:" sections located at the top of the file.

However, we recommend that you instead use one of the available [starter workflows](xref:github_starter_workflows) that in turn call one of our reusable workflows and that are preconfigured with most of the arguments.

For example:

```yml
jobs:

  Catalog:
    uses: SkylineCommunications/_ReusableWorkflows/.github/workflows/Update Catalog Details Workflow.yml@main
    secrets:
      # The API-key: generated in the dataminer.services Admin app (https://admin.dataminer.services/) as authentication for a certain DataMiner Organization or Agent.
      api-key: ${{ secrets.DATAMINER_TOKEN }}
```

## Create or extend catalog.yml

- Uses the `github-to-catalog-yaml` tool to either create a new *catalog.yml* file or update an existing one. This file defines catalog metadata based on the repository details.
For more information, see the [GitHubToCatalogYaml README](https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.Tools.GitHubToCatalogYaml#readme-body-tab).

## Commit and push auto-generated-catalog.yml

- Checks if there are changes to the *auto-generated-catalog.yml*. If so, it commits the changes and pushes them back to the repository.

## Retrieve readme

- Searches for a `README.md` file within the repository. If found, it retrieves its path for use in Catalog updates.

## Retrieve images

- Looks for an `Images` folder, initially near the `README.md` or, if not found, in the workspace. This folder is intended to store image assets for the catalog.

## Upload to Catalog

- Uploads the collected *catalog.yml*, `README.md`, and images to the Catalog using the specified API key for authentication.
