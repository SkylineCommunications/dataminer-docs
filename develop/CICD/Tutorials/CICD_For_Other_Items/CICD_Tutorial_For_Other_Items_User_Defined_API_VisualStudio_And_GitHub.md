---
uid: CICD_Tutorial_For_Other_Items_User_Defined_API_VisualStudio_And_GitHub
---

# Developing a User-Defined API Using Visual Studio and GitHub

In this tutorial, you will learn how to develop, (pre-)release, and upload a User Defined API to the DataMiner Catalog with a CI/CD pipeline using Visual Studio and GitHub.
You can however utilize this tutorial for **any artifact type** except for connectors (e.g. Automation Script, Automation Script Library, Package Project, ...).

Expected duration: 5 minutes

## Prerequisites

- A [GitHub account](https://docs.github.com/en/get-started/signing-up-for-github/signing-up-for-a-new-github-account)
- [DataMiner Integration Studio](https://community.dataminer.services/exphub-dis/)
- [Microsoft Visual Studio 2022](https://visualstudio.microsoft.com/downloads/)

## Overview

- [Step 1: Create a Visual Studio project](#step-1-create-a-visual-studio-project)
- [Step 2: Create a GitHub repository](#step-2-create-a-github-repository)
- [Step 3: Check GitHub Actions](#step-3-check-github-actions)
- [Step 4: Create and add secret](#step-4-create-and-add-secret)
- [Step 5: Check The Results](#step-5-check-the-results)

## Step 1: Create a Visual Studio project

1. Open Visual Studio, and select *Create a new project*.

1. Select the *Dataminer User-Defined API Project* Template, and click *Next*.

1. Enter a project name, for example *MyUserDefinedApi*

1. Make sure *Place solution and project in the same directory* is **unchecked**, and click *Next*.

1. Fill in the Author and Check the *Create DataMiner Package* box.

1. Select *Basic* under *Add GitHub CI/CD Workflow (Overwrite Existing)*

1. Click *Create*.

## Step 2: Create a GitHub repository

1. In the menu bar of Visual Studio, select *GIT* > *Create GIT Repository*.

1. Create a new GitHub repository:

   1. Select a name, specify your GitHub account, and mark yourself as the owner.

   1. When you have entered all the information, click *Create and Push*.

1. Go to the newly created GitHub repository on <https://github.com/>.

   > [!TIP]
   > In Visual Studio 2022, you can open the *GIT* menu and select *GitHub/View Pull Requests* to quickly access the correct repository.

### Step 3: Check GitHub Actions

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

### Step 4: Create and add secret

1. Obtain an **Organization Key** from [admin.dataminer.services](https://admin.dataminer.services/) with the required scopes:
   - **Register catalog items**
   - **Read catalog items**

1. Add the key as a secret in your GitHub repository, by navigating to **Settings > Secrets and variables > Actions** and creating a secret named `DATAMINER_TOKEN`.

1. Re-run the workflow.

With this setup, any push with new content (including the initial creation) to the main/master branch will generate a new pre-release version, using the latest commit message as the version description.

### Step 5: Check The Results

1. Go to the [DataMiner Catalog](https://catalog.dataminer.services/)

1. Make sure you are within the correct organization on the top right-hand side.

1. Search for the name of your package, this is default your Visual Studio Project name (e.g. *MyUserDefinedApi*)

1. Go to the *VERSIONS* tab.

1. See your new version of the User Defined API which is now available for deployment from the Catalog.
