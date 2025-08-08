---
uid: CICD_Tutorial_For_Connectors_VisualStudio_And_AzureDevOps
---

# Setting up basic CI/CD for connector deployment in Azure Devops

In this tutorial, you will learn how to develop, (pre-)release, and optionally deploy connectors with a CI/CD pipeline in Azure Devops, though this can be applied to any CI/CD technology. These processes do not necessarily follow the same quality standards that developers within Skyline Communications adhere to but can be tweaked and configured to your personal preferences.

This CI/CD pipeline provides you with the ability to deploy a connector automatically on a DMA.

Expected duration: 10 minutes.

## Prerequisites

- A staging DataMiner Agent that is accessible from your pipeline and that uses DataMiner version 10.3.0/10.3.2 or higher
- An [Azure DevOps organization and project](https://dev.azure.com/)
- [Microsoft Visual Studio 2022](https://visualstudio.microsoft.com/downloads/)
- [DataMiner Integration Studio](https://community.dataminer.services/exphub-dis/)

## Overview

- [Step 1: Create a Visual Studio project](#step-1-create-a-visual-studio-project)
- [Step 2: Create an Azure DevOps repository](#step-2-create-an-azure-devops-repository)
- [Step 3: Create a dataminer.services key](#step-3-create-a-dataminerservices-key)
- [Step 4: Create and run a workflow](#step-4-create-and-run-a-workflow)
- [Step 5: Validation (optional)](#step-5-validation-optional)

## Step 1: Create a Visual Studio project

1. Open Visual Studio, and select *Create a new project*.

1. Select the *DataMiner Connector Solution* template, and click *Next*.

1. Enter a solution name, for example *SLC-C-MyDataSourceTest*, and click *Next*.

1. Follow the wizard for any additional information requirements.

1. Click *Create*.

## Step 2: Create an Azure DevOps repository

1. In the menu bar of Visual Studio, select *GIT* > *Create GIT Repository*.

1. Create a new Azure DevOps repository:

   1. Select a name, and specify your Azure account, organization, and project.

   1. When you have entered all the information, click *Create and Push*.

1. Go to the newly created Azure DevOps repository on <https://dev.azure.com/>.

   > [!TIP]
   > In Visual Studio 2022, you can open the *GIT* menu and select *Azure DevOps/View Pull Requests* to quickly access the correct repository.

1. If your repository does not follow [Skyline's naming conventions](xref:Using_GitHub_for_CICD#repository-naming-convention), specify the artifact type:

   1. Go to the *Code* tab.

   1. Click the cogwheel next to *About*.

   1. Under *Topics*, add a topic called *Connector*

> [!TIP]
> For more information, refer to the [GitHubToCatalogYaml readme](https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.Tools.GitHubToCatalogYaml#readme-body-tab).

## Step 3: Create a dataminer.services key

To securely upload and/or deploy a connector, you will need a secret key.

This means that you will need to create a [system key](xref:Managing_dataminer_services_keys#system-keys) token to authenticate the register version call from the Catalog API:

1. In the [Admin app](https://admin.dataminer.services/), under *DataMiner Systems* in the sidebar on the left, select the DMS to which you want to deploy connectors and go to the *Keys* page.

1. At the top of the page, click *New Key*.

1. Configure the key with a label of your choice and the permission *Register catalog items*.

   ![Organization Key](~/dataminer/images/tutorial_catalog_registration_create_org_key.png)

1. Copy the key so you can use it later.

> [!IMPORTANT]
> You need to have the *Owner* role in order to access/create system keys. See [Changing the role of a dataminer.services user](xref:Changing_the_role_of_a_dataminer_services_user) for information on how to change a role for a user.

## Step 4: Create and run a workflow

1. On your Azure DevOps repository page, go to *Pipelines* and select *Create Pipeline*.

   1. If you are asked *Where is my code?*, select *Azure Repos Git*.

   1. Select the repository you have just added.

   1. Select *Starter pipeline*.

1. Select, install, and run the required dotnet tools:

   1. Go to [Azure DevOps Example](xref:CICD_Azure_DevOps_Examples).

   1. Copy the example and paste it into your new starter pipeline.

1. Configure secrets and variables:

   > [!NOTE]
   > This step can be different for each CI/CD technology.

   1. Select *Variables* in the top-right corner.

   1. Select *New Variable*, and configure the new variable as follows:

      1. Specify the name *DATAMINER_DEPLOY_KEY*.

      1. Select *Keep this value secret*.

      1. Use the key you created in [step 3](#step-3-create-a-dataminerservices-key).

   1. Click + to add another variable, and configure it as follows:

      1. Specify the name *uploadOutput*.

      1. Select *Let users override this value when running this pipeline*.

1. Click *Save and Run*.

1. You should now see your new connector on your specified specific DataMiner Agent.

## Step 5: Validation (optional)

You can now tweak and adjust your workflow using other validation steps such as static code analysis, running unit testing, or running the DataMiner Validator.

You can for example add our validator tool for XML syntax in connectors: [Skyline.DataMiner.CICD.Tools.Validator](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Tools.Validator). This tool allows the validation of a DataMiner protocol solution. This is the same validator as is included in [DataMiner Integration Studio (DIS)](xref:Overall_concept_of_the_DataMiner_Integration_Studio).

> [!NOTE]
> The validator tool requires that the projects of the protocol solution are [SDK-style projects](xref:skyline_dataminer_sdk).
