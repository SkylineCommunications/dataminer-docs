---
uid: skyline_dataminer_sdk_dataminer_package_project
---

# Skyline DataMiner Package Project

This project is designed to create multi-artifact packages in a straightforward manner.
Note that the below information assumes access to Visual Studio and DIS.

There is also limited support for Visual Studio Code without DIS.
You can do most of the things defined below except for [Importing from DataMiner](#importing-from-dataminer) which is currently handled by DIS.

## Creating a DataMiner Application Package

This project is by default configured to create a `.dmapp` file every time you build the project.  
When you compile or build the project, you will find the generated `.dmapp` in the standard output folder, typically the `bin` folder of your project.

When you publish the project, a corresponding item will be created in the online DataMiner Catalog.

## Adding Extra Artifacts in the Same Solution

You can right-click the solution and select **Add** and then **New Project**. This will allow you to select DataMiner project templates (e.g. adding additional Automation scripts).

> [!NOTE]
> Connectors are currently not supported.

You can also add new projects by using the dotnet-cli.
It's recommended for stability to always have a *sln* solution with all projects included.

```bash
    dotnet new sln
    dotnet new dataminer-user-defined-api-project -o MyUserDefinedApiFromGithub -auth MyName
    dotnet sln add MyUserDefinedApiFromGithub
```

Every **Skyline.DataMiner.SDK** project within the solution, except other DataMiner package projects, will by default be included within the `.dmapp` created by this project.  
You can customize this behavior using the **PackageContent/ProjectReferences.xml** file. This allows you to add filters to include or exclude projects as needed.

## Importing from DataMiner

You can import specific items directly from a DataMiner Agent:  

1. Connect to an Agent via **Extensions > DIS > DMA > Connect**.

1. If your Agent is not listed, add it by going to **Extensions > DIS > Settings** and clicking **Add** on the DMA tab.

1. Once connected, you can import specific DataMiner artifacts: in your **Solution Explorer**, navigate to folders such as **PackageContent/Dashboards** or **PackageContent/LowCodeApps**, right-click, select **Add**, and select **Import DataMiner Dashboard/Low Code App** or the equivalent.

## Executing Additional Code on Installation

Open the **$SCRIPTNAME$.cs** file to write custom installation code. Common actions include creating elements, services, or views.

**Quick tip:** Type `clGetDms` in the `.cs` file and press **Tab** twice to insert a snippet that gives you access to the **IDms** classes, making DataMiner manipulation easier.

## Does Your Installation Code Need Configuration Files?

You can add configuration files (e.g. `.json`, `.xml`) to the **SetupContent** folder, which can be accessed during installation.

Access them in your code using:

```csharp
string setupContentPath = installer.GetSetupContentDirectory();
```

## Publishing to the Catalog

This project is by default created with support for publishing to the DataMiner Catalog.  
You can publish your artifact manually through Visual Studio or by setting up a CI/CD workflow.

### Manual Publishing

1. Obtain an **Organization Key** from [admin.dataminer.services](https://admin.dataminer.services/) with the following scopes:
   - **Register Catalog items**
   - **Read Catalog items**

1. Securely store the key using Visual Studio User Secrets:

   1. Right-click the project and select **Manage User Secrets**.

   1. Add the key in the following format:

      ```json
      { 
        "skyline": {
          "sdk": {
            "catalogpublishtoken": "MyKeyHere"
          }
        }
      }
      ```

1. Publish the package by right-clicking your project in Visual Studio and then selecting the **Publish** option.

   This will open a new window, where you will find a Publish button and a link where your item will eventually be registered.

**Recommendation:** To safeguard the quality of your product, consider using a CI/CD setup to run **dotnet publish** only after passing quality checks.

### Changing the Version

1. Navigate to your project in Visual Studio, right-click, and select Properties.

1. Search for Package Version.

1. Adjust the value as needed.

### Changing the Version - Alternative

1. Navigate to your project in Visual Studio and double-click it.

1. Adjust the "Version" XML tag to the version you want to register.

   ```xml
   <Version>1.0.1</Version>
   ```

## Publishing to the Catalog with Basic CI/CD Workflow

If you've used the Skyline.DataMiner.VisualStudioTemplates then it's possible this project includes a basic GitHub workflow for Catalog publishing.
Follow these steps to set it up:

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

1. Obtain an **Organization Key** from [admin.dataminer.services](https://admin.dataminer.services/) with the following scopes:
   - **Register Catalog items**
   - **Read Catalog items**

1. Add the key as a secret in your GitHub repository, by navigating to **Settings > Secrets and variables > Actions** and creating a secret named `DATAMINER_TOKEN`.

1. Re-run the workflow.

With this setup, any push with new content (including the initial creation) to the main/master branch will generate a new pre-release version, using the latest commit message as the version description.

### Releasing a Specific Version

1. Navigate to the **<> Code** tab in your GitHub repository.

1. In the menu on the right, select **Releases**.

1. Create a new release, select the desired version as a **tag**, and provide a title and description.

> [!NOTE]
> The description will be visible in the DataMiner Catalog.

## Publishing to the Catalog with Complete CI/CD Workflow

If you've used the Skyline.DataMiner.VisualStudioTemplates then it's possible this project includes a Complete GitHub workflow for Catalog publishing:
This comprehensive GitHub workflow adheres to Skyline Communications' quality standards, including static code analysis, custom validation, and unit testing.

### Prerequisite

You need a **SonarCloud Organization**. If you don’t have one, you can create it [here](https://sonarcloud.io/create-organization).

### Steps

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

1. Obtain an **Organization Key** from [admin.dataminer.services](https://admin.dataminer.services/) with the following scopes:
   - **Register Catalog items**
   - **Read Catalog items**

1. Add the key as a secret in your GitHub repository, by navigating to **Settings > Secrets and variables > Actions** and creating secrets or variables with the required names.

1. Re-run the workflow.

The following secrets and variables will have been added to your repository after all issues are resolved:

| Name            | Type    | Description                                        | Setup Guide                                                                                 |
|-----------------|---------|----------------------------------------------------|---------------------------------------------------------------------------------------------|
| `DATAMINER_TOKEN` | Secret  | Organization key for publishing to the Catalog   | Obtain from [admin.dataminer.services](https://admin.dataminer.services/) and add it as a secret. |
| `SONAR_TOKEN`    | Secret  | Token for SonarCloud authentication               | Obtain from [SonarCloud Security](https://sonarcloud.io/account/security) and add it as a secret.  |
| `SONAR_NAME`     | Variable | SonarCloud project ID                            | Visit [SonarCloud](https://sonarcloud.io/projects/create), copy the project ID, and add it as a variable. |

### Releasing a Version

1. Navigate to the **<> Code** tab in your GitHub repository.

1. In the menu on the right, select **Releases**.

1. Create a new release, select the desired version as a **tag**, and provide a title and description.

> [!NOTE]
> The description will be visible in the DataMiner Catalog.

## Advanced Configuration

### Multiple Packages

You can add multiple DataMiner Package Projects within a single solution and then have them make different packages.
The default behavior on building or publishing this solution through CI/CD is that all of them will have the same version and upload to the same organization.

It's possible to do some advanced setups within a single solution that can provide:

- Releasing Packages to different organizations
- Releasing Packages with different versions

This is also supported with our reusable workflow (Offered through the Templates as the "Complete" GitHub Workflow): [DataMiner App Packages Master Workflow](xref:github_reusable_workflows_dataminer_app_packages_master_workflow)

In GitHub you can make several different workflows (or different jobs) that trigger the reusable workflow with different arguments that can change the behavior of the Build and Publish.

This is most easily handled using Visual Studio Solution Filters

#### Visual Studio Solution Filter Files

A **Solution Filter** (`.slnf`) file in Visual Studio 2022 is a feature designed to load a subset of projects within a larger solution (`.sln`).
This is particularly useful for large solutions that contain many projects, as it allows developers to work with only the relevant projects, improving load times and reducing resource consumption.

Within Skyline DataMiner SDK they provide an additional key benefit.
You can easily publish or build a specific subset of projects by providing those dotnet-cli commands a solution filter file.
This can allow you to independently version or release different DataMiner Application Packages.

You can find more information on how to make such filters [HERE](xref:skyline_dataminer_sdk_solution_filter_files).

#### Dotnet-Cli

##### Default

Default call that releases every package in a solution to the same organization with the same version:

```bash
$env:DATAMINER_TOKEN = "MyOrgKey"
dotnet publish -p:Version="0.0.1" -p:VersionComment="This is just a pre-release version." -p:CatalogPublishKeyName="$DATAMINER_TOKEN"
```

##### With Filters

Call that releases only packages configured with either of the provided **Solution Filter** files:

- PackagesForOrganizationA.slnf
- PackagesForOrganizationB.slnf

```bash
$env:DATAMINER_TOKENA = "MyOrgAKey"
$env:DATAMINER_TOKENB = "MyOrgAKey"
dotnet publish PackagesForOrganizationA.slnf -p:Version="1.0.1" -p:VersionComment="Releasing 1.0.1 for A." -p:CatalogPublishKeyName="$DATAMINER_TOKENA"
dotnet publish PackagesForOrganizationB.slnf -p:Version="2.0.1" -p:VersionComment="Releasing 2.0.1 for B." -p:CatalogPublishKeyName="$DATAMINER_TOKENB"
```

#### GitHub Reusable Workflows

When using GitHub Reusable Workflows as provided by Skyline Communications you can optionally include a Visual Studio Solution Filter File that will adjust the behavior of our pipelines so it only builds, tests and publishes the subsection defined by the filter.

##### Default Job

```yml
jobs:

  CI:
    uses: SkylineCommunications/_ReusableWorkflows/.github/workflows/DataMiner App Packages Master Workflow.yml@main
    with:
      configuration: Release
      referenceName: ${{ github.ref_name }}
      runNumber: ${{ github.run_number }}
      referenceType: ${{ github.ref_type }}
      repository: ${{ github.repository }}
      owner: ${{ github.repository_owner }}
      sonarCloudProjectName: ${{ vars.SONAR_NAME }}
    secrets:
      dataminerToken: ${{ secrets.DATAMINER_TOKEN }}
      sonarCloudToken: ${{ secrets.SONAR_TOKEN }}

```

##### Jobs With Filters

Notice the addition of the extra argument below where you can define the .slnf names.
Both jobs are using a different secrets.DATAMINER_TOKEN which allows uploading to different organizations in the same run.

```yml
jobs:

  CI-package1:
    uses: SkylineCommunications/_ReusableWorkflows/.github/workflows/DataMiner App Packages Master Workflow.yml@DataMinerSDKSupport
    with:
      configuration: Release
      referenceName: ${{ github.ref_name }}
      runNumber: ${{ github.run_number }}
      referenceType: ${{ github.ref_type }}
      repository: ${{ github.repository }}
      owner: ${{ github.repository_owner }}
      sonarCloudProjectName: ${{ vars.SONAR_NAME }}
      solutionFilterName: "PackagesForOrganizationA.slnf"
    secrets:
      dataminerToken: ${{ secrets.DATAMINER_TOKENA }}
      sonarCloudToken: ${{ secrets.SONAR_TOKEN }} 
  
  CI-package2:
    uses: SkylineCommunications/_ReusableWorkflows/.github/workflows/DataMiner App Packages Master Workflow.yml@DataMinerSDKSupport
    with:
      configuration: Release
      referenceName: ${{ github.ref_name }}
      runNumber: ${{ github.run_number }}
      referenceType: ${{ github.ref_type }}
      repository: ${{ github.repository }}
      owner: ${{ github.repository_owner }}
      sonarCloudProjectName: ${{ vars.SONAR_NAME }}
      solutionFilterName: "PackagesForOrganizationB.slnf"
    secrets:
      dataminerToken: ${{ secrets.DATAMINER_TOKENB }}
      sonarCloudToken: ${{ secrets.SONAR_TOKEN }} 
```
