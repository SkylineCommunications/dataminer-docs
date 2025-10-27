---
uid: Tutorial_Register_Catalog_Version_GitHub_Actions
---

# Registering a new version of a connector in the Catalog using a GitHub Action

This tutorial demonstrates how to add a new version of a connector using the [Catalog API](xref:Register_Catalog_Item) and [GitHub Actions](https://docs.github.com/en/actions). In the tutorial, you will register your own version of an [example connector](https://github.com/SkylineCommunications/SLC-C-Example_Rates-Custom).

Expected duration: 10 minutes

> [!NOTE]
> If you are interested in reusing Skyline's pre-made pipelines, which include quality-of-life features and a robust quality gate, refer to the [Setting up complete quality control in CI/CD for connector deployment](xref:CICD_Tutorial_For_Connectors_VisualStudio_And_GitHub) tutorial.

## Prerequisites

- An [organization key](xref:Managing_dataminer_services_keys#organization-keys) or account with the *Owner* role in order to access/create keys.

  > [!TIP]
  > See [Changing the role of a dataminer.services user](xref:Changing_the_role_of_a_dataminer_services_user)

- A registered Catalog item.

  > [!TIP]
  > For an example of how to register an item, see [Registering a new connector in the Catalog](xref:Tutorial_Register_Catalog_Item).

- A [GitHub](https://github.com/) account with admin access to the GitHub repository you intend to use for this tutorial.

## Overview

- [Step 1: Create the GitHub Actions Workflow file](#step-1-create-the-github-actions-workflow-file)
- [Step 2: Add a GitHub secret](#step-2-add-a-github-secret)
- [Step 3: Push the workflow file](#step-3-push-the-workflow-file)
- [Step 4: Trigger the workflow](#step-4-trigger-the-workflow)
- [Step 5: Monitor workflow execution](#step-5-monitor-workflow-execution)

## Step 1: Create the GitHub Actions Workflow file

1. On your GitHub page, go to the *Actions* tab and select **set up workflow yourself**.

1. Paste the pipeline template below into this file.

   > [!IMPORTANT]
   > Make sure to change the *CATALOG_ID* environment variable to the Catalog ID of the item for which you will register a new version. If you followed the tutorial [Registering a new connector in the Catalog](xref:Tutorial_Register_Catalog_Item), this is the ID that was returned in the last step. If you are registering a new version for a different Catalog item, you can find it by navigating to its details page in the [Catalog](https://catalog.dataminer.services/) and checking the last part of the URL.

   ```yaml

   name: Build and Register a Catalog version

   on:
     push:
       branches:
         - main
     workflow_dispatch:  # Add this line to enable manual triggering

   jobs:
     build_and_upload:
       runs-on: ubuntu-latest

       steps:
         # Check out the repository
         - name: Checkout repository
           uses: actions/checkout@v4

         - name: Use GitHub run number for versioning
           run: echo "VERSION=1.0.0.${{ github.run_number }}" >> $GITHUB_ENV

         - name: Use GitHub environment variable to store Catalog ID
           run: echo "CATALOG_ID=1742495c-9231-4eeb-a56e-1fec8189246e" >> $GITHUB_ENV

         # Install the Skyline DataMiner Tooling
         - name: Install .NET Tools
           run: |
             dotnet tool install -g Skyline.DataMiner.CICD.Tools.Packager              
             dotnet tool install -g Skyline.DataMiner.CICD.Tools.CatalogUpload

         # Create the DataMiner protocol package
         - name: Create DataMiner Protocol Package
           run: dataminer-package-create dmprotocol "${{ github.workspace }}" --name catalog_registration_tutorial --output "${{ github.workspace }}/Packages"

         # Upload the DataMiner protocol package
         - name: Upload DataMiner Protocol Package to Catalog
           id: upload_to_catalog
           shell: bash
           run: |
             dataminer-catalog-upload with-registration \
               --path-to-artifact "${{ github.workspace }}/Packages/catalog_registration_tutorial.dmprotocol" \
               --artifact-version "${{ env.VERSION }}" \
               --dm-catalog-token "${{ secrets.API_TOKEN }}" \
               --catalog-identifier "${{ env.CATALOG_ID }}"

   ```

## Step 2: Add a GitHub secret

To securely store sensitive information like the API token, you will need to add a GitHub secret:

1. Create an [organization key](xref:Managing_dataminer_services_keys#organization-keys) token to authenticate the register version call from the Catalog API:

   1. In the [Admin app](https://admin.dataminer.services/), under *Organization* in the sidebar on the left, select the *Keys* page.

   1. At the top of the page, click *New Key*.

   1. Configure the key with a label of your choice and the permission *Register catalog items*.

      ![Organization Key](~/dataminer/images/tutorial_catalog_registration_create_org_key.png)

   1. Copy the key so you can use it later.

   > [!IMPORTANT]
   > You need to have the *Owner* role in order to access/create organization keys. See [Changing the role of a dataminer.services user](xref:Changing_the_role_of_a_dataminer_services_user) for information on how to change a role for a user.

1. In your GitHub repository, go to the *Settings* page.

1. In the sidebar on the left, select *Secrets and variables* > *Actions*, and then click the *New repository secret* button.

   ![New repository secret button](~/dataminer/images/tutorial_catalog_registration_new_secret.png)

1. Specify the name `API_TOKEN`, and add the organization key you copied earlier as the value.

> [!NOTE]
> In case using an organization key results in issues, you can try using a [system key](xref:Managing_dataminer_services_keys#system-keys) instead.

## Step 3: Push the workflow file

Commit and push the addition of the *dataminer-catalog-pipeline.yml* file in the *.github/workflows* folder to your repository. You can use the following commands for this:

```bash
git add .github/workflows/dataminer-catalog-pipeline.yml
git commit -m "Add GitHub Actions pipeline for catalog version registration"
git push origin main
```

## Step 4: Trigger the workflow

To create a new version, push a change to the *main* branch of the repository (or the branch you have defined in the workflow under the *on* section). The GitHub Actions pipeline will automatically be triggered.

You can also manually trigger the workflow by navigating to the *Actions* tab in your repository, selecting the pipeline, and then clicking *Run workflow*.

## Step 5: Monitor workflow execution

1. Go to the *Actions* tab of your GitHub repository.

   You should see the pipeline you created listed there.

1. Select the workflow to see its progress.

   You can view detailed logs for each step to check for errors or success messages.

1. When the workflow has run successfully, navigate to the item in the Catalog.

   You will be able to see the registered version in the **versions** tab.
