---
uid: CICD_Tutorial_For_Other_Items_User_Defined_API_VisualStudio_And_GitHub
keywords: Skyline.DataMiner.Sdk, Tutorial
---

# Registering a new version of a user-defined API to the Catalog using Visual Studio and GitHub

In this tutorial, you will learn how to develop, (pre-)release, and upload a user-defined API to the Catalog with a CI/CD pipeline using Visual Studio and GitHub. However, note that you can use similar steps for **any artifact type** except for connectors (e.g. Automation script, Automation script library, package project, etc.).

Expected duration: 10 minutes

## Prerequisites

- A [GitHub account](https://docs.github.com/en/get-started/signing-up-for-github/signing-up-for-a-new-github-account)
- [DataMiner Integration Studio](https://community.dataminer.services/exphub-dis/)
- [Microsoft Visual Studio 2022](https://visualstudio.microsoft.com/downloads/)
- A dataminer.services account with the *Owner* role in order to be able to access/create keys for your organization.

## Overview

- [Step 1: Create a Visual Studio project](#step-1-create-a-visual-studio-project)
- [Step 2: Create a GitHub repository](#step-2-create-a-github-repository)
- [Step 3: Check the GitHub Actions](#step-3-check-the-github-actions)
- [Step 4: Create and add a secret](#step-4-create-and-add-a-secret)
- [Step 5: Check the results](#step-5-check-the-results)

## Step 1: Create a Visual Studio project

1. Open Visual Studio, and select *Create a new project*.

1. Select the *DataMiner User-Defined API Project* template, and click *Next*.

1. Enter a project name, for example *MyUserDefinedApi*.

1. Make sure *Place solution and project in the same directory* is **not selected**, and click *Next*.

1. Fill in your name as the author and keep *Create DataMiner Package* selected.

1. Under *Add GitHub CI/CD Workflow (Overwrite Existing)*, select *Basic*.

1. Click *Create*.

## Step 2: Create a GitHub repository

1. In the menu bar of Visual Studio, select *GIT* > *Create GIT Repository*.

1. Create a new GitHub repository:

   1. Select a name, specify your GitHub account, and mark yourself as the owner.

   1. When you have entered all the information, click *Create and Push*.

1. Go to the newly created GitHub repository on <https://github.com/>.

   > [!TIP]
   > In Visual Studio 2022, you can open the *GIT* menu and select *GitHub/View Pull Requests* to quickly access the correct repository.

## Step 3: Check the GitHub Actions

1. In GitHub, go to the *Actions* tab.

1. Click the workflow run that failed (usually called *Add project files*).

1. Click the "build" step that failed and read the failing error.

   ``` text
   Error: DATAMINER_TOKEN is not set. Release not possible!
   Please create or re-use an admin.dataminer.services token by visiting: https://admin.dataminer.services/.
   Navigate to the right Organization then go to Keys and create/find a key with permissions to Register catalog items, Download catalog versions and Read catalog items.
   Copy the value of the token.
   Then set a DATAMINER_TOKEN secret in your repository settings: <Dynamic Link>
   ```

   You can use the links from the actual error in the next couple of steps.

## Step 4: Create and add a secret

1. Obtain an **organization key** from [admin.dataminer.services](https://admin.dataminer.services/) with the required scopes:

   - *Register catalog items*
   - *Read catalog items*
   - *Download catalog versions*

   > [!TIP]
   > See also: [dataminer.services keys](xref:GitHub_Secrets#dataminerservices-keys)

1. Add the key as a secret in your GitHub repository, by navigating to *Settings* > *Secrets and variables* > *Actions* and creating a secret named `DATAMINER_TOKEN`.

1. Re-run the workflow by going back to the failing run and selecting *Re-run jobs* in the top-right corner.

With this setup, any push with new content (including the initial creation) to the main/master branch will generate a new pre-release version, using the latest commit message as the version description.

## Step 5: Check the results

1. Go to the [Catalog](https://catalog.dataminer.services/)

1. Check in the top-right corner if the correct organization is selected.

1. Search for the name of your package.

   By default, this is your Visual Studio project name (e.g. *MyUserDefinedApi*).

1. Go to the *VERSIONS* tab.

   This tab should contain the new version of your user-defined API, which is now available for deployment from the Catalog.
