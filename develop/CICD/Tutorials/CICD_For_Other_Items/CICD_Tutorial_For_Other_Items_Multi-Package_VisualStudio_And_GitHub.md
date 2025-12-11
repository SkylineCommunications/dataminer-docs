---
uid: CICD_Tutorial_For_Other_Items_Multi-Package_VisualStudio_And_GitHub
keywords: Skyline.DataMiner.Sdk, Tutorial
---

# Registering a new version of multiple DataMiner packages to the Catalog using Visual Studio and GitHub

In this tutorial, you will learn how to develop, (pre-)release, and upload multiple DataMiner packages to the Catalog with a basic CI/CD pipeline using Visual Studio and GitHub.

- TutorialPackage1:
  - Automation script: TutorialScript1

- TutorialPackage2:
  - Automation script: TutorialScript1
  - Automation script: TutorialScript2

Expected duration: 15 minutes

## Prerequisites

- A [GitHub account](https://docs.github.com/en/get-started/signing-up-for-github/signing-up-for-a-new-github-account)
- [DataMiner Integration Studio](https://community.dataminer.services/exphub-dis/)
- [Microsoft Visual Studio 2022](https://visualstudio.microsoft.com/downloads/)
- An [organization key](xref:Managing_dataminer_services_keys#organization-keys) or account with the *Owner* role in order to access/create keys.

## Overview

- [Step 1: Add code-based content](#step-1-add-code-based-content)
- [Step 2: Specify what needs to be in the package](#step-2-specify-what-needs-to-be-in-the-package)
- [Step 3: Create a GitHub repository](#step-3-create-a-github-repository)
- [Step 4: Check the GitHub Actions](#step-4-check-the-github-actions)
- [Step 5: Create and add a secret](#step-5-create-and-add-a-secret)
- [Step 6: Check the results](#step-6-check-the-results)

## Step 1: Add code-based content

Start by adding all code-based content into a Visual Studio solution:

1. Create a first DataMiner package project:

   1. Open Visual Studio, and select *Create a new project*.

   1. Select the *DataMiner Package Project* template, and click *Next*.

   1. Enter the project name `TutorialPackage1`.

   1. Make sure *Place solution and project in the same directory* is **not selected**, and click *Next*.

   1. Fill in your name as the author and keep *Create DataMiner Package* selected.

   1. Under *Add GitHub CI/CD Workflow (Overwrite Existing)*, select *Demo*.

   1. Click *Create*.

1. Create a second DataMiner package project:

   1. Open Visual Studio, and select *Create a new project*.

   1. Select the *DataMiner Package Project* template, and click *Next*.

   1. Enter the project name `TutorialPackage2`.

   1. Make sure *Place solution and project in the same directory* is **not selected**, and click *Next*.

   1. Fill in your name as the author and keep *Create DataMiner Package* selected.

   1. Under *Add GitHub CI/CD Workflow (Overwrite Existing)*, select *None*.

   1. Click *Create*.

1. Add a first DataMiner Automation script project:

   1. In the Solution Explorer, at the very top, right-click the solution *TutorialPackage* and select *Add > new project*.

   1. Select the *DataMiner Automation Script Project* template, and click *Next*.

   1. Enter the project name `TutorialScript1`.

   1. Fill in your name as the author and make sure *Create DataMiner Package* is not selected.

   1. Under *Add GitHub CI/CD Workflow (Overwrite Existing)*, keep the default *None* selected.

   1. Click *Create*.

1. Add a second DataMiner Automation script project:

   1. In the Solution Explorer, at the very top, right-click the solution *TutorialPackage* and select *Add > new project*.

   1. Select the *DataMiner Automation Script Project* template, and click *Next*.

   1. Enter the project name `TutorialScript2`.

   1. Fill in your name as the author.

   1. Click *Create*.

## Step 2: Specify what needs to be in the package

In this step, you will focus on the way to specify what needs to be in the package. While this can be done in multiple ways, below you will find how to do so using [Visual Studio solution filters](xref:skyline_dataminer_sdk_solution_filter_files).

1. Create a solution filter for TutorialPackage1:

   1. In the Solution Explorer, unload *TutorialPackage2* and *TutorialScript2* by right-clicking the projects and selecting *Unload Project*.

   1. Right-click the solution and select *Save As Solution Filter*.

   1. Specify a name (e.g. `TutorialPackage1.slnf`).

1. Create a solution filter for TutorialPackage2:

   1. In the Solution Explorer, reload *TutorialPackage2* and *TutorialScript2* by right-clicking the projects and selecting *Reload Project*.

   1. Unload *TutorialPackage1*, by right-clicking the project and selecting *Unload Project*.

   1. Right-click the solution and select *Save As Solution Filter*.

   1. Specify a name (e.g. `TutorialPackage2.slnf`).

1. Update the package project for TutorialPackage1:

   1. In the Solution Explorer, navigate to the project *TutorialPackage1*, open the directory *PackageContent*, and double-click to open the *ProjectReferences.xml* file.

   1. Modify the **project references** by replacing *ProjectReference* with the new *SolutionFilter*:

      ```xml
      <ProjectReferences xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://www.skyline.be/projectReferences">
         <SolutionFilter Include="..\TutorialPackage1.slnf" />
      </ProjectReferences>
      ```

1. Update the package project for TutorialPackage2:

   1. In the Solution Explorer, navigate to the project *TutorialPackage2*, open the directory *PackageContent*, and double-click to open the *ProjectReferences.xml* file.

   1. Modify the **project references** by replacing *ProjectReference* with the new *SolutionFilter*:

      ```xml
      <ProjectReferences xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://www.skyline.be/projectReferences">
         <SolutionFilter Include="..\TutorialPackage2.slnf" />
      </ProjectReferences>
      ```

## Step 3: Create a GitHub repository

1. In the menu bar of Visual Studio, select *GIT* > *Create GIT Repository*.

1. Create a new GitHub repository:

   1. Select a name, specify your GitHub account, and mark yourself as the owner.

   1. When you have entered all the information, click *Create and Push*.

1. Go to the newly created GitHub repository on <https://github.com/>.

   > [!TIP]
   > In Visual Studio 2022, you can open the *GIT* menu and select *GitHub/View Pull Requests* to quickly access the correct repository.

## Step 4: Check the GitHub Actions

1. In GitHub, go to the *Actions* tab.

1. Click the workflow run that failed (usually called *Add project files*).

1. Click the "build" step that failed and read the failing error.

   ``` text
   Error: DATAMINER_TOKEN is not set. Release not possible!
   Please create or re-use an admin.dataminer.services token by visiting: https://admin.dataminer.services/.
   Navigate to the right organization, then go to Keys and create or find a key with the permissions Register catalog items, Download catalog versions, and Read catalog items.
   Copy the value of the token.
   Then set a DATAMINER_TOKEN secret in your repository settings: <Dynamic Link>
   ```

   You can use the links from the actual error in the next couple of steps.

## Step 5: Create and add a secret

1. Obtain an **organization key** from [admin.dataminer.services](https://admin.dataminer.services/) with the required scopes:

   - *Register catalog items*
   - *Read catalog items*
   - *Download catalog versions*

   > [!TIP]
   > See also: [dataminer.services keys](xref:GitHub_Secrets#dataminerservices-keys)

1. Add the key as a secret in your GitHub repository, by navigating to *Settings* > *Secrets and variables* > *Actions* and creating a secret named `DATAMINER_TOKEN`.

1. Re-run the workflow.

With this setup, any push with new content (including the initial creation) to the main/master branch will generate a new pre-release version, using the latest commit message as the version description.

## Step 6: Check the results

1. Go to the [Catalog](https://catalog.dataminer.services/)

1. Check in the top-right corner if the correct organization is selected.

1. Search for the name of your package.

   By default, this is your Visual Studio project name (e.g. *TutorialPackage*).

1. Go to the *VERSIONS* tab.

   This tab should contain the new version of the package, which is now available for deployment from the Catalog.

1. If you have an available non-production DataMiner Agent, use the *Deploy* button to deploy the new version to the DMA.
