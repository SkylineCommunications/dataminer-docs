---
uid: CICD_Tutorial_For_Other_Items_Multi-Artifact_DataMiner_Package_VisualStudio_And_GitHub
keywords: Skyline.DataMiner.Sdk, Tutorial
---

# Registering a new version of a multi-artifact DataMiner package to the Catalog using Visual Studio and GitHub

In this tutorial, you will learn how to develop, (pre-)release, and upload a DataMiner package to the Catalog with a basic CI/CD pipeline using Visual Studio and GitHub. This package will contain multiple artifacts:

- Automation script: TutorialScript1
- Automation script: TutorialScript2
- Automation script library: TutorialLibrary
- Ad hoc data source: TutorialDataSource

The package will include a simple .txt file that will be read out during installation, generating an information event with the information from the file.

Expected duration: 15 minutes

## Prerequisites

- A [GitHub account](https://docs.github.com/en/get-started/signing-up-for-github/signing-up-for-a-new-github-account)
- [DataMiner Integration Studio](https://community.dataminer.services/exphub-dis/)
- [Microsoft Visual Studio 2022](https://visualstudio.microsoft.com/downloads/)
- An [organization key](xref:Managing_dataminer_services_keys#organization-keys) or [system key](xref:Managing_dataminer_services_keys#system-keys) or account with the *Owner* role in order to access/create keys.

## Overview

- [Step 1: Add code-based content](#step-1-add-code-based-content)
- [Step 2: Add installation-specific code](#step-2-add-installation-specific-code)
- [Step 3: Create a GitHub repository](#step-3-create-a-github-repository)
- [Step 4: Check the GitHub Actions](#step-4-check-the-github-actions)
- [Step 5: Create and add a secret](#step-5-create-and-add-a-secret)
- [Step 6: Check the results](#step-6-check-the-results)

## Step 1: Add code-based content

Start by adding all code-based content into a Visual Studio solution:

1. Create a DataMiner package project:

   1. Open Visual Studio, and select *Create a new project*.

   1. Select the *DataMiner Package Project* template, and click *Next*.

   1. Enter the project name `TutorialPackage`.

   1. Make sure *Place solution and project in the same directory* is **not selected**, and click *Next*.

   1. Fill in your name as the author and keep *Create DataMiner Package* selected.

   1. Under *Add GitHub CI/CD Workflow (Overwrite Existing)*, select *Demo*.

   1. Click *Create*.

1. Add a first DataMiner automation script project:

   1. In the Solution Explorer, at the very top, right-click the solution *TutorialPackage* and select *Add > new project*.

   1. Select the *DataMiner Automation Script Project* template, and click *Next*.

   1. Enter the project name `TutorialScript1`.

   1. Fill in your name as the author and make sure *Create DataMiner Package* is not selected.

   1. Under *Add GitHub CI/CD Workflow (Overwrite Existing)*, keep the default *None* selected.

   1. Click *Create*.

1. Add a second DataMiner automation script project:

   1. In the Solution Explorer, at the very top, right-click the solution *TutorialPackage* and select *Add > new project*.

   1. Select the *DataMiner Automation Script Project* template, and click *Next*.

   1. Enter the project name `TutorialScript2`.

   1. Fill in your name as the author.

   1. Click *Create*.

1. Add a DataMiner automation script library project:

   1. In the Solution Explorer, at the very top, right-click the solution *TutorialPackage* and select *Add > new project*.

   1. Select the *DataMiner Automation Script Library Project* template, and click *Next*.

   1. Enter the project name `TutorialLibrary`.

   1. Fill in your name as the author.

   1. Click *Create*.

1. Add a DataMiner ad hoc data source project:

   1. In the Solution Explorer, at the very top, right-click the solution *TutorialPackage* and select *Add > new project*.

   1. Select the *DataMiner Ad Hoc Data Source Project* template, and click *Next*.

   1. Enter the project name `TutorialDataSource`.

   1. Fill in your name as the author.

   1. Click *Create*.

## Step 2: Add installation-specific code

In this step, you will focus on the extra code that should be executed when the content is installed.

1. Add the **setup content**:

   1. In the Solution Explorer, navigate to the project *TutorialPackage* and right-click the *SetupContent* folder.

   1. Select *Add > New Item*.

   1. Select to add a new text file (.txt), and give it the name `MyConfig.txt`.

   1. Write `Hello World!` as the content and save the file.

1. Write the **installation code**:

   1. In the Solution Explorer, navigate to the project *TutorialPackage* and double-click to open the *TutorialPackage.cs* file.

   1. Change the content of the *Install* method to the following:

      ```csharp
         try
         {
            engine.Timeout = new TimeSpan(0, 10, 0);
            engine.GenerateInformation("Starting installation");
            var installer = new AppInstaller(Engine.SLNetRaw, context);
            installer.InstallDefaultContent();
   
            string setupContentPath = installer.GetSetupContentDirectory();
   
            // Custom installation logic can be added here for each individual install package.
            string pathToConfig = System.IO.Path.Combine(setupContentPath, "MyConfig.txt");
            var config = System.IO.File.ReadAllText(pathToConfig);
            engine.GenerateInformation($"Tutorial installation ran with config: {config}");
         }
         catch (Exception e)
         {
            engine.ExitFail($"Exception encountered during installation: {e}");
         }
      ```

   1. Save the changes

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

   All artifacts will be installed. In DataMiner Cube, you should see an information event in the Alarm Console saying *Tutorial installation ran with config: Hello World!*.
