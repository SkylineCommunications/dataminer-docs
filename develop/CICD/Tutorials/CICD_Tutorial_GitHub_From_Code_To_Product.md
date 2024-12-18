---
uid: CICD_Tutorial_GitHub_Code_To_Product
---

# Going from code to product in GitHub

In this tutorial, you will learn how to develop, (pre-)release, and optionally deploy any supported DataMiner artifact with a CI/CD pipeline in GitHub. These processes follow the same quality standards that developers within Skyline Communications adhere to.

If you are interested in learning how to set up CI/CD using different technologies, such as Jenkins, GitLab, Concourse, Azure DevOps, etc., take a look at the [Setting up basic CI/CD for connectors](xref:CICD_Tutorial_Connector) tutorial.

This CI/CD pipeline will ensure strict quality standards, provide you with a private item registered in the DataMiner Catalog, and give you the ability to deploy the item automatically.

Expected duration: 10 minutes.

> [!TIP]
> See also: [Kata #50: Going from code to product in Github](https://community.dataminer.services/courses/kata-50/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)

## Private versus public code

Both SonarCloud and GitHub require paid licenses to fully support private GitHub repositories. For this tutorial, we recommend creating a public repository.

For real-world scenarios, you will likely need at least a paid SonarCloud license to work with private GitHub repositories. A free GitHub version can still be used for private repositories, but it will slightly change the tutorial below.

## Prerequisites

- A GitHub and SonarCloud Organization set up as detailed under [Setting up your development environment in GitHub](xref:CICD_Tutorial_GitHub_Setting_Up_Organization) (Skyline employees can use <https://github.com/SkylineCommunicationsSandbox>)
- Runtime .NET SDK 8.0 ([download](https://dotnet.microsoft.com/en-us/download/dotnet/8.0))
- A staging DataMiner Agent that is accessible from your pipeline and that uses DataMiner version 10.3.0/10.3.2 or higher
- [Microsoft Visual Studio 2022](https://visualstudio.microsoft.com/downloads/)
- [Git](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git)
- A [GitHub account](https://docs.github.com/en/get-started/signing-up-for-github/signing-up-for-a-new-github-account)
- [DataMiner Integration Studio](https://community.dataminer.services/exphub-dis/)

## Overview

- [Step 1: Create a Visual Studio project](#step-1-create-a-visual-studio-project)
- [Step 2: Create a GitHub repository](#step-2-create-a-github-repository)
- [Step 3: Add the Starter Workflow](#step-3-add-the-starter-workflow)
- [Step 4: Release a private item in the DataMiner Catalog](#step-4-release-a-private-item-in-the-dataminer-catalog)

## Step 1: Create a Visual Studio project

1. Open Visual Studio, and select *Create a new project*.

1. Select one of the available DataMiner templates from the list of templates (for example *Ad Hoc Data Source Solution*), and click *Next*.

1. Enter a solution name, for example *SLC-GQIDS-MyDataSourceTest*, and click *Next*.

   We recommend adhering to [Skyline's naming conventions](xref:Using_GitHub_for_CICD#repository-naming-convention), though this is not mandatory.

1. Follow the wizard for any additional information requirements.

1. Click *Create*.

## Step 2: Create a GitHub repository

1. In the menu bar of Visual Studio, select *GIT* > *Create GIT Repository*.

1. Create a new GitHub repository:

   1. Select a name, specify your GitHub account, and mark yourself as the owner.

   1. When you have entered all the information, click *Create and Push*.

1. Go to the newly created GitHub repository on <https://github.com/>.

   > [!TIP]
   > In Visual Studio 2022, you can open the *GIT* menu and select *GitHub/View Pull Requests* to quickly access the correct repository.

1. If your repository does not follow [Skyline's naming conventions](xref:Using_GitHub_for_CICD#repository-naming-convention), specify the artifact type:

   1. Go to the *Code* tab.

   1. Click the cogwheel next to *About*.

   1. Under *Topics*, add a topic with the artifact type, as defined under [Inferring Catalog Item Type](https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.Tools.GitHubToCatalogYaml?tab=readme-ov-file#inferring-catalog-item-type).

> [!TIP]
> For more information, refer to the [GitHubToCatalogYaml readme](https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.Tools.GitHubToCatalogYaml#readme-body-tab).

## Step 3: Add the Starter Workflow

1. Go to the Starter Workflow:

   - For **public** repositories or **paid** GitHub subscriptions:

     On your GitHub page, go to the *Actions* tab and select the DataMiner workflow that matches your solution type. If none of the names match, select *DataMiner CICD AutomationScript*.

   - For **private** repositories on a **free** GitHub subscription:

     1. On your GitHub page, go to the *Actions* tab and select *Set up workflow yourself*.

     1. Go to [Skyline-Starter-Workflows](https://github.com/SkylineCommunications/Skyline-Starter-Workflows/tree/main/workflow-templates) and select the DataMiner workflow that matches your solution type.

        If none of the names match, select *DataMiner CICD AutomationScript*.

     1. Copy the content of the workflow file and paste it into your new workflow file.

1. Open a new browser window or tab, go to <https://sonarcloud.io/projects/create>, and create a project for the correct organization.

1. Enter the ID of the project as shown in the SonarCloud project URL as the `sonarCloudProjectName`.

1. Open a new browser window or tab, and create and add the necessary [GitHub secrets](xref:GitHub_Secrets) that you see in the workflow..

1. Go back to your pipeline file and click *Commit Changes*.

   Commit the changes directly to the master branch.

1. Go to the *Actions* tab.

   You should see your new workflow running. It will run for every Git push.

You should now see your CI jobs complete successfully, ensuring that quality standards are met.

## Step 4: Release a private item in the DataMiner Catalog

1. On the *Code* tab for your repository on GitHub, on the right, click *Create a new release*.

1. Click *Choose a tag* and enter the version, for example `1.0.0.1-beta1`.

   You can use any version you want. For a pre-release, usually a suffix is added, which can contain any text, e.g. "-beta1" in the example above.

1. Enter a description of your release.

1. If this is a pre-release, select *Set as a pre-release*.

1. Click *Publish release*.

1. Go to the *Actions* tab.

   You should now see your new workflow running in this tab. Your CI and CD jobs should complete successfully, ensuring quality standards are met and uploading the item to the Catalog UI as a private item.

1. Go to <https://catalog.dataminer.services/>, make sure your organization is selected in the top-right corner, and look up your artifact.

> [!NOTE]
> If you see the following errors: **Push .githubtocatalog/auto-generated-catalog Process completed with exit code 128.** or **remote: Permission to MyOrg/MyRepo.git denied to github-actionsbot**, you will need to either [set write permissions for the GITHUB_TOKEN in your specific repository](https://docs.github.com/en/actions/security-for-github-actions/security-guides/automatic-token-authentication#modifying-the-permissions-for-the-github_token), or, if you are an organization admin, you can enable this for the organization by [setting the workflow permissions](https://docs.github.com/en/organizations/managing-organization-settings/disabling-or-limiting-github-actions-for-your-organization#setting-the-permissions-of-the-github_token-for-your-organization) to *Read and write permissions*.
