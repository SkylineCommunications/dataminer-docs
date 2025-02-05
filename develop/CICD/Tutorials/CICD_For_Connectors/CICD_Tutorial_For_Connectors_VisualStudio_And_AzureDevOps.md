---
uid: CICD_Tutorial_For_Connectors_VisualStudio_And_AzureDevOps
---

# Developing Connectors using Azure DevOps

In this tutorial, you will learn how to develop, (pre-)release, and optionally deploy Connectors with a CI/CD pipeline in Azure Devops, though this can be applied to any CI/CD technology. These processes do not necessarily follow the same quality standards that developers within Skyline Communications adhere to but can be tweaked and configured to personal preferences.

This CI/CD pipeline provides you with the ability to deploy the a protocol automatically to an agent.

Expected duration: 10 minutes.

## Prerequisites

- A staging DataMiner Agent that is accessible from your pipeline and that uses DataMiner version 10.3.0/10.3.2 or higher
- An [Azure DevOps Organization and Project](https://dev.azure.com/)
- [Microsoft Visual Studio 2022](https://visualstudio.microsoft.com/downloads/)
- [DataMiner Integration Studio](https://community.dataminer.services/exphub-dis/)

## Overview

- [Step 1: Create a Visual Studio project](#step-1-create-a-visual-studio-project)
- [Step 2: Create an Azure DevOps Repository](#step-2-create-an-azure-devops-repository)
- [Step 3: Creating a dataminer.services key](#step-3-creating-a-dataminerservices-key)
- [Step 4: Create and run a Workflow](#step-4-create-and-run-a-workflow)
- [Step 5: (Optional) Validation](#step-5-optional-validation)

## Step 1: Create a Visual Studio project

1. Open Visual Studio, and select *Create a new project*.

1. Select the *DataMiner Connector Solution* Template, and click *Next*.

1. Enter a solution name, for example *SLC-C-MyDataSourceTest*, and click *Next*.

1. Follow the wizard for any additional information requirements.

1. Click *Create*.

### Step 2: Create an Azure DevOps repository

1. In the menu bar of Visual Studio, select *GIT* > *Create GIT Repository*.

1. Create a new Azure DevOps repository:

   1. Select a name, specify your Azure account, Organization and Project/

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

### Step 3: Creating a dataminer.services key

A dataminer.services key is scoped to the specific DMS for which it was created and can only be used for deployments to that DMS.

For more information on how to create a dataminer.services key, refer to [Managing dataminer.services keys](xref:Managing_DCP_keys).

### Step 4: Create and run a Workflow

1. Go to Pipelines and select Create Pipeline
    1. When Asked, Where is my code? Select *Azure Repos Git*
    1. Select the repository you just added
    1. Select *Starter pipeline*
1. Select, Install and run the required dotnet tools.
    1. Go to [Azure DevOps Example](xref:CICD_Azure_DevOps_Examples)
    1. Copy the example and paste it into your new Starter pipeline
1. Configure Secrets and Variables (This will be different for each CI/CD Technology)
    1. Select Variables on the top right.
    1. Select New Variable
        1. Call it DATAMINER_DEPLOY_KEY
        1. Check *Keep this value secret*
        1. Go to admin.dataminer.services and select/create a key from a specific DataMiner Agent.
    1. Click + and add another variable
        1. Call it uploadOutput
        1. Check *Let users override this value when running this pipeline*
1. Click Save and Run
1. You should now see your new connector on your specified specific DataMiner Agent.

### Step 5 (Optional) Validation

You can now tweak and adjust your workflow using other validation steps such as static code analysis, running unit testing or running the DataMiner Validator.

For example, by using the previous added workflow as an example, you can also add our Validator tool for XML syntax in Connectors:

- [Skyline.DataMiner.CICD.Tools.Validator](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Tools.Validator)

  This tool allows the validation of a DataMiner protocol solution. This is the same validator as is included in [DataMiner Integration Studio (DIS)](xref:Overall_concept_of_the_DataMiner_Integration_Studio).

  > [!NOTE]
  > This tool requires that the projects of the protocol solution are SDK-style projects.
