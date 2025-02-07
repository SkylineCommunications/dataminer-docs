---
uid: CICD_Tutorial_For_Other_Items_User_Defined_API_GitHub_Codespaces
---

# Registering a new version of a User-Defined API to the Catalog Using GitHub Codespaces

In this tutorial, you will learn how to develop, (pre-)release, and upload a User Defined API to the DataMiner Catalog with a CI/CD pipeline using GitHub Workspaces. You can however utilize this tutorial for **any artifact type** except for connectors (e.g. Automation Script, Automation Script Library, Package Project, ...).

Expected duration: 10 minutes

## Prerequisites

- A [GitHub account](https://docs.github.com/en/get-started/signing-up-for-github/signing-up-for-a-new-github-account)

## Overview

- [Step 1: Create a GitHub Repository](#step-1-create-a-github-repository)
- [Step 2: Create a GitHub Codespaces Environment](#step-2-create-a-github-codespaces-environment)
- [Step 3: Install DataMiner Templates](#step-3-install-dataminer-templates)
- [Step 4: Add Project Content And Solution File](#step-4-add-project-content-and-solution-file)
- [Step 5: Check GitHub Actions](#step-5-check-github-actions)
- [Step 6: Create and add secret](#step-6-create-and-add-secret)
- [Step 7: Check The Results](#step-7-check-the-results)

## Step 1: Create a GitHub Repository

1. Go to [github.com](https://github.com/)

1. Select the colored [*New* button](https://github.com/new).

1. Enter a repository name, for example *MyUserDefinedApiFromGithub*

1. Add a .gitignore called *VisualStudio*

1. Click *Create repository*.

## Step 2: Create a GitHub Codespaces Environment

1. Click on the green *<> Code* button.

1. Click *Create codespace on main*

1. Let the development instance connect

> [!NOTE]
> If you see *Oh No, it looks like you are offline?* It's likely due to your network firewall settings. You or your IT Department can follow the [Troubleshooting guide](https://docs.github.com/en/codespaces/troubleshooting/troubleshooting-your-connection-to-github-codespaces#browser-cannot-connect) and be able to resolve any issues.
> Alternatively you can continue this tutorial by restarting this step, but selecting *Continue Working in New Local Clone*. This will require you to have Visual Studio Code installed, alongside GIT and dotnet 8.0.

### Step 3: Install DataMiner Templates

1. Inside the Terminal (Press *Control + Shift + C* when focus is set on github)
    1. Check if you have *nuget.org* as a known nuget source

    ```cmd
        dotnet nuget list source 
    ```

    Check that the result contain *nuget.org*

    1. If your sources do not contain *nuget.org* call the following, otherwise skip this step

    ```cmd
      dotnet nuget add source https://api.nuget.org/v3/index.json -n "nuget.org"
    ```

    1. Install the DataMiner VisualStudio Templates

    ```cmd
      dotnet new install skyline.dataminer.visualstudiotemplates
    ```

### Step 4: Add Project Content and Solution File

1. Inside your Terminal (Control + Shift + C)

    1. Add the DataMiner User Defined API Project Template inside a new project folder

    ```cmd
      dotnet new dataminer-user-defined-api-project -o MyUserDefinedApiFromGithub -auth JanS -cdp true -I Basic
      dotnet new sln
      dotnet sln add MyUserDefinedApiFromGithub
    ```

1. Click on the Source Control button on the left-hand side
1. Enter a message (e.g. *Added Initial Project*)
1. Click the button *Commit*, if asked to stage all your changes select *Yes*
1. Click the button *Sync Changes*, if asked to pull and push from and to "origin/main" select *OK*
1. Return to your *GitHub Repository*

### Step 5: Check GitHub Actions

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

### Step 6: Create and add secret

1. Obtain an **Organization Key** from [admin.dataminer.services](https://admin.dataminer.services/) with the required scopes:
   - **Register catalog items**
   - **Read catalog items**

1. Add the key as a secret in your GitHub repository, by navigating to **Settings > Secrets and variables > Actions** and creating a secret named `DATAMINER_TOKEN`.

1. Re-run the workflow.

With this setup, any push with new content (including the initial creation) to the main/master branch will generate a new pre-release version, using the latest commit message as the version description.

### Step 7: Check The Results

1. Go to the [DataMiner Catalog](https://catalog.dataminer.services/)

1. Make sure you are within the correct organization on the top right-hand side.

1. Search for the name of your package, this is default your Visual Studio Project name (e.g. *MyUserDefinedApi*)

1. Go to the *VERSIONS* tab.

1. See your new version of the User Defined API which is now available for deployment from the Catalog.
