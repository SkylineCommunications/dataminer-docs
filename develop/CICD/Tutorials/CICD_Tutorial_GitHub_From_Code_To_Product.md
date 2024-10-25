---
uid: CICD_Tutorial_GitHub_Code_To_Product
---

# Going from Code to Product in GitHub

In this tutorial, you'll learn how to develop, (pre-)release, and optionally deploy any supported DataMiner artifact with a CI/CD pipeline specifically in GitHub. These processes follow the same quality standards that developers within Skyline Communications adhere to.  
If you're interested in learning how to set up CI/CD in different technologies, such as Jenkins, GitLab, Concourse, Azure DevOps, etc., take a look at the [Setting up a basic CI/CD for connectors](xref:CICD_Tutorial_Connector) tutorial.

This CI/CD pipeline will ensure strict quality standards, provide you with an item registered in your private catalog, and give you the ability to deploy automatically.

Expected duration: 10 minutes.

## Private versus Public Code

Both SonarCloud and GitHub require paid licenses to fully support Private GitHub Repositories.  
For this tutorial, it's recommended to create a Public Repository.

For real-world scenarios, you'll likely require at least a paid SonarCloud license to work with Private GitHub Repositories. A free GitHub version can still be used for Private Repositories, but it will slightly change the tutorial below.

## Prerequisites

- A GitHub and SonarCloud Organization as set up by the [Getting Started With GitHub](xref:CICD_Tutorial_GitHub_Code_To_Product) tutorial. (Skyline members may use https://github.com/SkylineCommunicationsSandbox to experiment.)
- Runtime .NET SDK 8.0. ([download](https://dotnet.microsoft.com/en-us/download/dotnet/8.0))
- A staging DataMiner Agent that is accessible from your pipeline and that uses DataMiner version 10.3.0/10.3.2 or higher
- [Microsoft Visual Studio 2022](https://visualstudio.microsoft.com/downloads/)
- [Git](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git)
- [GitHub account](https://docs.github.com/en/get-started/signing-up-for-github/signing-up-for-a-new-github-account)
- [DataMiner Integration Studio](https://community.dataminer.services/exphub-dis/)

## Overview

- [Step 1: Create a Visual Studio Project](#step-1-create-a-visual-studio-project)
- [Step 2: Create a GitHub repository](#step-2-create-a-github-repository)
- [Step 3: Add the Starter Workflow](#step-3-add-the-starter-workflow)
- [Step 4: Release to your private catalog](#step-4-release-to-your-private-catalog)

## Step 1: Create a Visual Studio Project

1. Open Visual Studio, and select *Create a new project*.

1. Select one of the available DataMiner templates (e.g., *Ad-Hoc Data Source Solution*) from the list of templates, and click *Next*.

1. Enter a solution name — it's recommended (but not required) to use [Skyline's Naming Conventions](xref:Using_GitHub_for_CICD#repository-naming-convention), e.g., *SLC-GQIDS-MyDataSourceTest*, and click *Next*.

1. Follow the wizard for any additional information requirements.

1. Click *Create*.

## Step 2: Create a GitHub repository

1. In the Visual Studio menu bar, select *GIT > Create GIT Repository...*.

1. Create a new GitHub repository.

   Choose a name, specify your GitHub account, and mark yourself as the owner. Once you've entered all the information, click *Create and Push*.

1. Go to the newly created GitHub repository on <https://github.com/>.

   > [!TIP]  
   > In Visual Studio 2022, you can open the *GIT* menu and select *GitHub/View Pull Requests* to quickly access the correct repository.

1. If your repository does not follow [Skyline's Naming Conventions](xref:Using_GitHub_for_CICD#repository-naming-convention), you will need to specify the artifact type:
   - Go to the **Code** tab.
   - Click on the **cogwheel** next to *About*.
   - Under *Topics*, add a topic with the artifact type, as defined in [GitHub Reusable Workflows](xref:github_reusable_workflows#artifact-types).

For more information, see the [GitHubToCatalogYaml README](https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.Tools.GitHubToCatalogYaml#readme-body-tab), specifically the section on [Inferring Catalog Item Type](https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.Tools.GitHubToCatalogYaml?tab=readme-ov-file#inferring-catalog-item-type).

This version clarifies each step and maintains a professional tone. Let me know if you need further adjustments!
## Step 3: Add the Starter Workflow

1. Find the Starter Workflow  
    - For Public Repositories or paid GitHub subscriptions:  
        On your GitHub page, go to the *Actions* tab and select the DataMiner workflow that matches your solution type. If none of the names match, choose *DataMiner CICD AutomationScript*.  
      
    - For Private Repositories on a free GitHub subscription:  
        On your GitHub page, go to the *Actions* tab and select **set up workflow yourself**. Then, go to [Skyline-Starter-Workflows](https://github.com/SkylineCommunications/Skyline-Starter-Workflows/tree/main/workflow-templates) and select the DataMiner workflow that matches your solution type. If none of the names match, choose *DataMiner CICD AutomationScript*. Copy the content of that file into your new workflow file.

Let me know if any other adjustments are needed!

1. Open a new browser window or tab, go to 'https://sonarcloud.io/projects/create', and create a project for the correct Organization. Then, enter the ID of the project as shown in the SonarCloud project URL as the `sonarCloudProjectName`.

1. Open a new browser window or tab, create and add the necessary GitHub Secrets that you see in the workflow. This is defined in [GitHub Secrets](xref:GitHub_Secrets).

1. Go back to your pipeline file and press *Commit Changes*. Commit directly to the master branch.

1. Go to the *Actions* tab. You should see your new workflow running. It will run for every Git push.

1. You should now see your CI jobs complete successfully, ensuring quality standards.

## Step 4: Release to your private catalog

1. Go to the Code tab.

1. On the right, click *Create a new release*.

1. Click on *Choose a tag* and type in `1.0.0.1-beta1` (or any other version you want, a pre-release is recognized by using a '-text' postfix).

1. Write any text you want to describe your release.

1. If this is a pre-release, select *Set as a pre-release*.

1. Click *Publish release*.

1. Go to the *Actions* tab. You should see your new workflow running.

1. You should now see your CI and CD jobs complete successfully, ensuring quality standards and uploading to the catalog UI.

1. You should now be able to find your artifact on <https://catalog.dataminer.services/> when searching within your organization.

> [!NOTE]  
> If you see the following errors: **Push .githubtocatalog/auto-generated-catalog Process completed with exit code 128.** or **remote: Permission to MyOrg/MyRepo.git denied to github-actionsbot**, you'll need to either set write permissions for the GITHUB_TOKEN in your specific repository as [shown here](https://docs.github.com/en/actions/security-for-github-actions/security-guides/automatic-token-authentication#modifying-the-permissions-for-the-github_token). Or, if you're an organization admin, you can enable this for the organization by setting the Workflow permissions to *Read and write permissions* as [shown here](https://docs.github.com/en/organizations/managing-organization-settings/disabling-or-limiting-github-actions-for-your-organization#setting-the-permissions-of-the-github_token-for-your-organization).

> [!NOTE]  
> To be granted DevOps points, take a screenshot of the successful run and either send it to <thunder@skyline.be> or upload it via the [Dojo tutorials page](https://community.dataminer.services/learning-courses-tutorials/).