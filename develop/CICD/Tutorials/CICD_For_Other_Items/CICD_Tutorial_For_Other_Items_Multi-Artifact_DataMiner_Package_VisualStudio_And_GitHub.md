---
uid: CICD_Tutorial_For_Other_Items_Multi-Artifact_DataMiner_Package_VisualStudio_And_GitHub
---

# Registering a new version of a Multi-Artifact DataMiner Package to the Catalog Using Visual Studio and GitHub

In this tutorial, you will learn how to develop, (pre-)release, and upload a DataMiner Package to the DataMiner Catalog with a Basic CI/CD pipeline using Visual Studio and GitHub.
This Package will be named TutorialPackage and contain multiple artifacts:

- Automation Script: TutorialScript1
- Automation Script: TutorialScript2
- Automation Script Library: TutorialLibrary
- Ad Hoc Data Source: TutorialDataSource

In addition,
During the installation of this package we also want to read out a simple *.txt* file we provide and generate an information event with this information.

Expected duration: 15 minutes

## Prerequisites

- A [GitHub account](https://docs.github.com/en/get-started/signing-up-for-github/signing-up-for-a-new-github-account)
- [DataMiner Integration Studio](https://community.dataminer.services/exphub-dis/)
- [Microsoft Visual Studio 2022](https://visualstudio.microsoft.com/downloads/)
- An [organization key](xref:Managing_DCP_keys#organization-keys) or [system key](xref:Managing_DCP_keys#system-keys) or account with the *Owner* role in order to access/create keys.

## Overview

- [Step 1: Add Code-Based Content](#step-1-add-code-based-content)
- [Step 2: Add Installation Specific Code](#step-2-add-installation-specific-code)
- [Step 3: Create a GitHub repository](#step-3-create-a-github-repository)
- [Step 4: Check GitHub Actions](#step-4-check-github-actions)
- [Step 5: Create and add secret](#step-5-create-and-add-secret)
- [Step 6: Check The Results](#step-6-check-the-results)

## Step 1: Add Code-Based Content

We'll start by adding all code-based content into a Visual Studio Solution:

### Step 1a: Create a DataMiner Package project

1. Open Visual Studio, and select *Create a new project*.

1. Select the *Dataminer Package Project* Template, and click *Next*.

1. Enter the project name, *TutorialPackage*

1. Make sure *Place solution and project in the same directory* is **unchecked**, and click *Next*.

1. Fill in the Author with your name and leave the *Create DataMiner Package* box checked.

1. Select *Basic* under *Add GitHub CI/CD Workflow (Overwrite Existing)*

1. Click *Create*.

### Step 1b: Add a first DataMiner Automation Script project

1. In the Solution Explorer, at the very top, right click the *Solution 'TutorialPackage'* and select *Add > new project*.

1. Select the *Dataminer Automation Script Project* Template, and click *Next*.

1. Enter the project name, *TutorialScript1*

1. Fill in the Author with your name and leave the default *Create DataMiner Package* box unchecked.

1. Leave the default *None* under *Add GitHub CI/CD Workflow (Overwrite Existing)*

1. Click *Create*.

### Step 1c: Add a second DataMiner Automation Script project

1. In the Solution Explorer, at the very top, right click the *Solution 'TutorialPackage'* and select *Add > new project*.

1. Select the *Dataminer Automation Script Project* Template, and click *Next*.

1. Enter the project name, *TutorialScript2*

1. Fill in the Author with your name

1. Click *Create*.

### Step 1d: Add a DataMiner Automation Script Library project

1. In the Solution Explorer, at the very top, right click the *Solution 'TutorialPackage'* and select *Add > new project*.

1. Select the *Dataminer Automation Script Library Project* Template, and click *Next*.

1. Enter the project name, *TutorialLibrary*

1. Fill in the Author with your name

1. Click *Create*.

### Step 1e:  Add a DataMiner Ad Hoc Data Source project

1. In the Solution Explorer, at the very top, right click the *Solution 'TutorialPackage'* and select *Add > new project*.

1. Select the *Dataminer Ad Hoc Data Source Project* Template, and click *Next*.

1. Enter the project name, *TutorialDataSource*

1. Fill in the Author with your name

1. Click *Create*.

## Step 2: Add Installation Specific Code

We'll now focus on extra code we want to execute during installation alongside installing our content.

## Step 2a: Add Setup Content

1. In the Solution Explorer, navigate to the Project *TutorialPackage* and right click on the *SetupContent* folder.

1. Select *Add > New Item*

1. Choose a new Text file *(.txt)* call it "MyConfig.txt"

1. Write Hello World! as the content and save the file.

## Step 2b: Write Installation Code

1. In the Solution Explorer, navigate to the Project *TutorialPackage* and double click to open the TutorialPackage.cs file.

1. Change the content of the Install method to the following:

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

### Step 4: Check GitHub Actions

1. Create a GitHub repository by going to **Git > Create Git Repository**, selecting GitHub, and filling in the wizard before clicking **Create and Push**.

1. In GitHub, go to the *Actions* tab.

1. Click the workflow run that failed (usually called *Add project files*).

1. Click the "build" step that failed and read the failing error.

   ``` text
   Error: DATAMINER_TOKEN is not set. Release not possible!
   Please create or re-use an admin.dataminer.services token by visiting: https://admin.dataminer.services/.
   Navigate to the right Organization then go to Keys and create/find a key with permissions to Register Catalog Items.
   Copy the value of the token.
   Then set a DATAMINER_TOKEN secret in your repository settings: **Dynamic Link**
   ```

   You can use the links from the actual error to better address the next couple of steps.

### Step 5: Create and add secret

1. Obtain an **Organization Key** from [admin.dataminer.services](https://admin.dataminer.services/) with the required scopes:
   - **Register catalog items**
   - **Read catalog items**

1. Add the key as a secret in your GitHub repository, by navigating to **Settings > Secrets and variables > Actions** and creating a secret named `DATAMINER_TOKEN`.

1. Re-run the workflow.

With this setup, any push with new content (including the initial creation) to the main/master branch will generate a new pre-release version, using the latest commit message as the version description.

### Step 6: Check The Results

1. Go to the [DataMiner Catalog](https://catalog.dataminer.services/)

1. Make sure you are within the correct organization on the top right-hand side.

1. Search for the name of your package, this is default your Visual Studio Project name (e.g. *MyUserDefinedApi*)

1. Go to the *VERSIONS* tab.

1. See your new version of the User Defined API which is now available for deployment from the Catalog.

1. If you have an available non-production DataMiner Agent you can now deploy this. You should notice an information event saying *Tutorial installation ran with config: Hello World!* alongside an installation of all artifacts.
