---
uid: skyline_dataminer_sdk_dataminer_package_project
---

# Skyline DataMiner Package Project

The Skyline DataMiner Package Project is designed to create multi-artifact packages in a straightforward manner.

Note that the information below assumes that you have access to Visual Studio and [DIS](xref:Overall_concept_of_the_DataMiner_Integration_Studio). However, for most of what is mentioned below there is also limited support for Visual Studio Code without DIS. Only [importing from DataMiner](#importing-from-dataminer) can only be handled by DIS at present.

## Creating a DataMiner application package

The project is by default configured to create a `.dmapp` file every time you build the project.

When you compile or build the project, you will find the generated `.dmapp` in the standard output folder, which is typically the `bin` folder of your project.

When you publish the project, a corresponding item will be created in the online DataMiner Catalog.

## Adding extra artifacts in the same solution

You can right-click the solution and select *Add* > *New Project*. This will allow you to select DataMiner project templates (e.g. adding additional Automation scripts).

> [!NOTE]
> Connectors are currently not supported for this.

You can also add new projects by using the dotnet-cli. For the sake of stability, we recommend always using an *sln* solution with all projects included.

```bash
    dotnet new sln
    dotnet new dataminer-user-defined-api-project -o MyUserDefinedApiFromGithub -auth MyName
    dotnet sln add MyUserDefinedApiFromGithub
```

Every *Skyline.DataMiner.SDK* project within the solution, except other DataMiner package projects, will by default be included within the `.dmapp` created by this project. You can customize this behavior using the *PackageContent/ProjectReferences.xml* file. This allows you to add filters to include or exclude projects as needed.

## Importing from DataMiner

You can import specific items directly from a DataMiner Agent using DIS:

1. In Visual Studio, connect to an Agent via *Extensions* > *DIS* > *DMA* > *Connect*.

1. If your Agent is not listed, add it by going to *Extensions* > *DIS* > *Settings* and clicking *Add* on the DMA tab.

1. Once connected, import the DataMiner artifacts you want:

   1. In your *Solution Explorer*, navigate to folders such as *PackageContent/Dashboards* or *PackageContent/LowCodeApps*.
   1. Right-click, and select *Add*.
   1. Select e.g. *Import DataMiner Dashboard/Low-Code App*, depending on what you want to import.

## Executing additional code on installation

Open the `$SCRIPTNAME$.cs` file to write custom installation code. Common actions include creating elements, services, or views.

> [!TIP]
> Type `clGetDms` in the .cs file and press Tab twice to insert a snippet that gives you access to the *IDms* classes, making DataMiner manipulation easier.

## Adding configuration files

If your installation code needs configuration files (e.g. .json, .xml), you can add these to the *SetupContent* folder, which can be accessed during installation.

Access them in your code using:

```csharp
string setupContentPath = installer.GetSetupContentDirectory();
```

## Publishing to the Catalog

By default, a project is created with support for publishing to the DataMiner Catalog. You can publish your artifact manually through Visual Studio or by setting up a CI/CD workflow.

### Publishing manually

1. Obtain an **organization key** from [admin.dataminer.services](https://admin.dataminer.services/) with the following scopes:

   - *Register Catalog items*
   - *Read Catalog items*

1. Securely store the key using Visual Studio User Secrets:

   1. Right-click the project and select *Manage User Secrets*.

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

1. Publish the package by right-clicking your project in Visual Studio and then selecting the *Publish* option.

   This will open a new window, where you will find a Publish button and a link where your item will eventually be registered.

> [!NOTE]
> To safeguard the quality of your product, consider using a CI/CD setup to run *dotnet publish* only after passing quality checks.

### Changing the version of a package

There are two ways to change the version of a package:

- By adjusting the package version property:

  1. Navigate to your project in Visual Studio, right-click, and select *Properties*.

  1. Search for *Package Version*.

  1. Adjust the value as needed.

- By adjusting the *Version* XML tag:

  1. Navigate to your project in Visual Studio and double-click it.

  1. Adjust the *Version* XML tag to the version you want to register.

     ```xml
     <Version>1.0.1</Version>
     ```

### Publishing to the Catalog with the basic CI/CD workflow

If you have used the *Skyline.DataMiner.VisualStudioTemplates*, your project can include a basic GitHub workflow for Catalog publishing.

Follow these steps to set it up:

1. Create a GitHub repository by going to *Git* > *Create Git Repository* in Visual Studio, selecting GitHub, and filling in the wizard before clicking *Create and Push*.

1. In GitHub, go to the *Actions* tab.

1. Click the workflow run that failed (usually called *Add project files*).

1. Click the "build" step that failed and read the error.

   ``` text
   Error: DATAMINER_TOKEN is not set. Release not possible!
   Please create or re-use an admin.dataminer.services token by visiting: https://admin.dataminer.services/.
   Navigate to the right Organization then go to Keys and create/find a key with permissions to Register Catalog Items.
   Copy the value of the token.
   Then set a DATAMINER_TOKEN secret in your repository settings: **Dynamic Link**
   ```

   You can use the links from the actual error to better address the next couple of steps.

1. Obtain an **organization key** from [admin.dataminer.services](https://admin.dataminer.services/) with the following scopes:

   - *Register Catalog items*
   - *Read Catalog items*

1. Add the key as a secret in your GitHub repository, by navigating to *Settings* > *Secrets and variables* > *Actions* and creating a secret named `DATAMINER_TOKEN`.

1. Re-run the workflow.

With this setup, any push with new content (including the initial creation) to the main/master branch will generate a new pre-release version, using the latest commit message as the version description.

#### Releasing a specific version

1. Navigate to the *<> Code* tab in your GitHub repository.

1. In the menu on the right, select *Releases*.

1. Create a new release, select the desired version as a **tag**, and provide a title and description.

> [!NOTE]
> The description will be visible in the DataMiner Catalog.

### Publishing to the Catalog with the complete CI/CD workflow

If you have used the Skyline.DataMiner.VisualStudioTemplates, your project can include a complete GitHub workflow for Catalog publishing. This comprehensive GitHub workflow adheres to Skyline Communications' quality standards, including static code analysis, custom validation, and unit testing.

1. Make sure you have a **SonarCloud organization**.

   If you do not have one yet, you can create it on [sonarcloud.io](https://sonarcloud.io/create-organization).

1. Create a GitHub repository by going to *Git* > *Create Git Repository* in Visual Studio, selecting GitHub, and filling in the wizard before clicking *Create and Push*.

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

1. Obtain an **organization key** from [admin.dataminer.services](https://admin.dataminer.services/) with the following scopes:

   - *Register Catalog items*
   - *Read Catalog items*

1. Add the key as a secret in your GitHub repository, by navigating to *Settings* > *Secrets and variables* > *Actions* and creating secrets or variables with the required names.

1. Re-run the workflow.

The following secrets and variables will have been added to your repository after all issues are resolved:

| Name              | Type     | Description                                    | Setup Guide                                                                                               |
|-------------------|----------|------------------------------------------------|-----------------------------------------------------------------------------------------------------------|
| `DATAMINER_TOKEN` | Secret   | Organization key for publishing to the Catalog | Obtain from [admin.dataminer.services](https://admin.dataminer.services/) and add it as a secret.         |
| `SONAR_TOKEN`     | Secret   | Token for SonarCloud authentication            | Obtain from [SonarCloud Security](https://sonarcloud.io/account/security) and add it as a secret.         |
| `SONAR_NAME`      | Variable | SonarCloud project ID                          | Visit [SonarCloud](https://sonarcloud.io/projects/create), copy the project ID, and add it as a variable. |

#### Releasing a version

1. Navigate to the *<> Code* tab in your GitHub repository.

1. In the menu on the right, select *Releases*.

1. Create a new release, select the desired version as a **tag**, and provide a title and description.

> [!NOTE]
> The description will be visible in the DataMiner Catalog.

## Advanced configuration

### Multiple packages

You can add multiple DataMiner package projects within a single solution and then have them make different packages. The default behavior on building or publishing this solution through CI/CD is that all of them will have the same version and upload to the same organization.

Within a single solution, you can configure some advanced setups in order to:

- Release packages to different organizations
- Release packages with different versions

This is also supported with our reusable workflow (offered through the templates as the "Complete" GitHub Workflow): [DataMiner App Packages Master Workflow](xref:github_reusable_workflows_dataminer_app_packages_master_workflow).

In GitHub you can make several different workflows (or different jobs) that trigger the reusable workflow with different arguments that can change the behavior of the Build and Publish steps.

This is most easily handled using Visual Studio Solution filters.

#### Visual Studio solution filter files

A **solution filter** (`.slnf`) file in Visual Studio 2022 is a feature designed to load a subset of projects within a larger solution (`.sln`). This is particularly useful for large solutions that contain many projects, as it allows developers to work only with the relevant projects, improving load times and reducing resource consumption.

Within Skyline DataMiner SDK, they provide an additional key benefit. You can easily publish or build a specific subset of projects by providing those dotnet-cli commands with a solution filter file. This can allow you to independently version or release different DataMiner application packages.

For more information on how to make such filters, refer to [Visual Studio 2022 solution filter (*.slnf) files](xref:skyline_dataminer_sdk_solution_filter_files).

#### dotnet-cli

##### Default

Default call that releases every package in a solution to the same organization with the same version:

```bash
$env:DATAMINER_TOKEN = "MyOrgKey"
dotnet publish -p:Version="0.0.1" -p:VersionComment="This is just a pre-release version." -p:CatalogPublishKeyName="$DATAMINER_TOKEN"
```

##### With filters

Call that releases only packages configured with either of the provided solution filter files:

- PackagesForOrganizationA.slnf
- PackagesForOrganizationB.slnf

```bash
$env:DATAMINER_TOKENA = "MyOrgAKey"
$env:DATAMINER_TOKENB = "MyOrgAKey"
dotnet publish PackagesForOrganizationA.slnf -p:Version="1.0.1" -p:VersionComment="Releasing 1.0.1 for A." -p:CatalogPublishKeyName="$DATAMINER_TOKENA"
dotnet publish PackagesForOrganizationB.slnf -p:Version="2.0.1" -p:VersionComment="Releasing 2.0.1 for B." -p:CatalogPublishKeyName="$DATAMINER_TOKENB"
```

#### GitHub reusable workflows

When using GitHub reusable workflows as provided by Skyline Communications, you can optionally include a Visual Studio solution filter file that will adjust the behavior of the pipeline so it only builds, tests, and publishes the subsection defined by the filter.

##### Default job

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

##### Jobs with filters

Notice the addition of the extra argument below where you can define the .slnf names. Both jobs are using a different secrets.DATAMINER_TOKEN, which allows uploading to different organizations in the same run.

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
