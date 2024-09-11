---
uid: Tutorial_Register_Catalog_Version_GitHub_Actions
---

# Registering a new version of a connector in the Catalog

This tutorial demonstrates how to add a new version to a Catalog item using the [Catalog API](xref:Register_Catalog_Item) and [GitHub Actions](https://docs.github.com/en/actions).  
We will be registering our own version of the following example [connector](https://github.com/SkylineCommunications/SLC-C-Example_Rates-Custom), so go ahead and download the solution.

## Prerequisites

- A registered Catalog item, see [register a catalog item tutorial](xref:Tutorial_Register_Catalog_Item) for an example on how to register an item.
- A [GitHub](https://github.com/) account.

## Overview

- [Step 1: Create the GitHub Actions Workflow file](#step-1-create-the-github-actions-workflow-file)
- [Step 2: Add GitHub secrets](#step-2-add-github-secrets)
- [Step 3: Push the workflow file](#step-3-push-the-workflow-file)
- [Step 4: Trigger the workflow](#step-4-trigger-the-workflow)
- [Step 5: Monitor workflow execution](#step-5-monitor-workflow-execution)

## Step 1: Create the GitHub Actions Workflow file

- Go to your GitHub Repository.  
    Open the repository where you want to add this GitHub Actions workflow.

- Create a .github/workflows Directory.  
    In the root of your repository, create a directory named `.github` (if it doesn't exist).
    Inside the `.github` directory, create another directory called `workflows`.

- Add the Workflow File.  
Inside the `workflows` directory, create a new file named `dataminer-catalog-pipeline.yml`.
Paste below pipeline template into this file.

```yaml
name: Build and Register a Catalog version

on:
  push:
    branches:
      - main

jobs:
  build_and_upload:
    runs-on: ubuntu-latest

    steps:
      # Checkout the repository
      - name: Checkout repository
        uses: actions/checkout@v3
      - name: Use GitHub run number for versioning
        run: echo "VERSION=1.0.0.${{ github.run_number }}" >> $GITHUB_ENV

      # Install the Skyline DataMiner CICD Packager Tool
      - name: Install Skyline DataMiner CICD Packager Tool
        run: dotnet tool install -g Skyline.DataMiner.CICD.Tools.Packager

      # Create the DataMiner Protocol package
      - name: Create DataMiner Protocol Package
        run: dataminer-package-create dmprotocol "${{ github.workspace }}" --name catalog_registration_tutorial --output "${{ github.workspace }}/Packages"

      # Prepare the package file and version details
      - name: Register on Catalog
        shell: pwsh
        run: |
          $file = Get-Item "${{ github.workspace }}/Packages/catalog_registration_tutorial.dmprotocol"
          $uri = "https://api.dataminer.services/api/key-catalog/v1-0/catalog/${{ secrets.CATALOG_ID }}/register/version"
          
          # Define the form data (package file, version, and description)
          $formData = @{
            file = Get-Item $file.FullName
            versionNumber = "${{ env.VERSION }}"
            versionDescription = "New version registered by GitHub Actions pipeline"
          }

          # Set up the API request to register the new version in the catalog
          Invoke-RestMethod -Uri $uri -Method Post -Headers @{ 'Ocp-Apim-Subscription-Key' = "${{ secrets.API_TOKEN }}" } -Form $formData
```

## Step 2: Add GitHub secrets

To securely store sensitive information like the catalog ID, API token, and version number, follow these steps:

- Navigate to GitHub Secrets.  
    In your GitHub repository, go to the repository's main page.  
    Click on the `Settings` tab.  
    On the left sidebar, click on `Secrets and variables` > `Actions`.  
    Click the `New repository secret` button.


- Add the Required Secrets.  
`CATALOG_ID`: This is the catalog ID. Make sure this is the correct id of the [Catalog item](xref:Tutorial_Register_Catalog_Item) you registered earlier.   

  `API_TOKEN`: This is the [organization key](xref:Managing_DCP_keys#organization-keys) token to authenticate the register version call from the Catalog API.  

  We can obtain one in the [Admin App](https://admin.dataminer.services/) on the Keys page. 
  This key identifies your organization and will make sure the registration will register your Catalog item under the correct organization.  

## Step 3: Push the workflow file

Once you’ve added the dataminer-catalog-pipeline.yml file to the .github/workflows folder, commit and push it to your repository.

```bash
git add .github/workflows/dataminer-catalog-pipeline.yml
git commit -m "Add GitHub Actions pipeline for catalog version registration"
git push origin main
```

## Step 4: Trigger the workflow

Now, whenever you push changes to the `main` branch (or the branch you've defined in the workflow under the `on` section), the GitHub Actions pipeline will automatically trigger.

You can also manually trigger the workflow by navigating to the `Actions` tab in your repository and selecting the pipeline, then clicking `Run workflow`.

> [!NOTE]  
> A version can be registered only once, registration will fail if you try to register an existing version number of a catalog item.

## Step 5: Monitor workflow execution

Go to the `Actions` tab of your GitHub repository.
You should see the pipeline you created listed there.
Select the workflow to see its progress. You can view detailed logs for each step to check for errors or success messages.  
You will be able to see the registered version on the Catalog in the **versions** tab.