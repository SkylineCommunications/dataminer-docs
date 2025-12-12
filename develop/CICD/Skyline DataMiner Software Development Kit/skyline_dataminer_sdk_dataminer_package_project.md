---
uid: skyline_dataminer_sdk_dataminer_package_project
keywords: Skyline.DataMiner.Sdk, Package Project
---

# Skyline DataMiner Package Project

The Skyline DataMiner Package Project is designed to create multi-artifact packages in a straightforward manner.

Note that the information below assumes that you have access to Visual Studio and [DIS](xref:Overall_concept_of_the_DataMiner_Integration_Studio). However, for most of what is mentioned below there is also limited support for Visual Studio Code without DIS. Only [importing from DataMiner](#importing-from-dataminer) can only be handled by DIS at present.

## Creating a DataMiner application package

The project is by default configured to create a .dmapp file every time you build the project.

When you compile or build the project, you will find the generated .dmapp in the standard output folder, which is typically the *bin* folder of your project.

When you publish the project, a corresponding item will be created in the online Catalog.

## Adding extra artifacts in the same solution

### New artifacts

You can right-click the solution and select *Add* > *New Project*. This will allow you to select DataMiner project templates (e.g. to add additional Automation scripts).

> [!NOTE]
> Connectors are currently not supported for this.

You can also add new projects by using the dotnet-cli. For the sake of stability, we recommend always using an *sln* solution with all projects included.

```bash
    dotnet new sln
    dotnet new dataminer-user-defined-api-project -o MyUserDefinedApiFromGithub -auth MyName
    dotnet sln add MyUserDefinedApiFromGithub
```

Every *Skyline.DataMiner.SDK* project within the solution, except other DataMiner package projects, will by default be included within the .dmapp created by this project. You can customize this behavior using the *PackageContent/ProjectReferences.xml* file. This allows you to add filters to include or exclude projects as needed. See [ProjectReferences.xml](xref:skyline_dataminer_sdk_dataminer_package_project_project_references) for more information.

### Existing Automation script files

You can right-click the solution and select *Add* > *Add Existing DataMiner Automation Script*. This will allow you to add existing Automation scripts files to the solution.

## Importing from DataMiner

You can import specific items directly from a DataMiner Agent using DIS:

1. In Visual Studio, connect to an Agent via *Extensions* > *DIS* > *DMA* > *Connect*.

1. If your Agent is not listed, add it by going to *Extensions* > *DIS* > *Settings* and clicking *Add* on the DMA tab.

1. Once connected, import the DataMiner artifacts you want:

   - To import **dashboards**:

     1. In your *Solution Explorer*, navigate in the Package project to *PackageContent/Dashboards*.

     1. Right-click, and select *Add*.

     1. Select *Import DataMiner Dashboard*.

   - To import **low-code apps**:

     1. In your *Solution Explorer*, navigate in the Package project to *PackageContent/LowCodeApps*.

     1. Right-click, and select *Add*.

     1. Select *Import DataMiner Low-Code App*.

   - To import an **Automation script**:

     1. In your *Solution Explorer*, right-click the solution, and select *Add*.

     1. Select *Import DataMiner Automation Script*.

## Adding content from the Catalog

You can reference and include additional content from the Catalog using the *PackageContent/CatalogReferences.xml* file provided in this project. See [CatalogReferences.xml](xref:skyline_dataminer_sdk_dataminer_package_project_catalog_references) for more information.

For the SDK to be able to download the referenced items from the Catalog, configure a user secret in Visual Studio:

1. Obtain an **organization key** from [admin.dataminer.services](https://admin.dataminer.services/) with the following scopes:

   - *Register catalog items*
   - *Read catalog items*
   - *Download catalog versions*

1. Securely store the key using Visual Studio User Secrets:

   1. Right-click the project and select *Manage User Secrets*.

   1. Add the key in the following format:

      ```json
      { 
        "skyline": {
          "sdk": {
            "dataminertoken": "MyKeyHere"
          }
        }
      }
      ```

> [!TIP]
> Alternatively, you can configure the token using the default environment variable. For more information, see [Publishing manually](#publishing-manually).

## Executing additional code during installation

To execute custom code during installation, open the `$SCRIPTNAME$.cs` file and add your logic there. This can be used for actions such as creating elements, services, or views.

> [!TIP]
> Type `clGetDms` in the .cs file and press Tab twice to insert a snippet that gives you access to the *IDms* classes, making DataMiner manipulation easier.

## Adding configuration files

If your installation code needs configuration files (e.g. .json, .xml), you can add these to the *SetupContent* folder, which can be accessed during installation.

Access them in your code using:

```csharp
string setupContentPath = installer.GetSetupContentDirectory();
```

## Publishing to the Catalog

By default, a project is created with support for publishing to the Catalog. You can publish your artifact manually through Visual Studio or by setting up a CI/CD workflow. To ensure high quality, Skyline only publishes Catalog items through CI/CD.

### Publishing manually

You can manually publish a Catalog item using either the [.NET CLI](#using-the-net-cli-with-an-environment-variable) or [Visual Studio's publish functionality](#using-visual-studio-with-a-user-secret).

#### Using the .NET CLI with an environment variable

When working in a collaborative environment, it is typically considered a best practice to work with environment variables.

You can use a `dotnet` command to publish your Catalog item:

```bash
$env:DATAMINER_TOKEN = "MyOrgKey"
dotnet publish -p:Version="0.0.1" -p:VersionComment="This is just a pre-release version." -p:CatalogPublishKeyName="DATAMINER_TOKEN" -p:CatalogDefaultDownloadKeyName="DATAMINER_TOKEN"
```

You can also choose to leave the default `CatalogPublishKeyName` in the .csproj file and add a system variable in Windows (through [Powershell](https://learn.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_environment_variables?view=powershell-7.5#set-environment-variables-with-setenvironmentvariable) or the [System Control Panel](https://learn.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_environment_variables?view=powershell-7.5#set-environment-variables-in-the-system-control-panel), e.g. `[Environment]::SetEnvironmentVariable("skyline__sdk__dataminertoken", "MyOrgKey", "Machine"))`.

By doing so, you can omit `CatalogDefaultDownloadKeyName` and `CatalogPublishKeyName`, and simplify the command:

```bash
dotnet publish -p:Version="0.0.1" -p:VersionComment="This is just a pre-release version."
```

#### Using Visual Studio with a User Secret

You can also publish your artifact via [Visual Studio's default publish functionality](https://learn.microsoft.com/en-us/dotnet/core/tutorials/publishing-with-visual-studio), using a User Secret. This is convenient when managing multiple projects with different registration keys.

1. Obtain an **organization key** from [admin.dataminer.services](https://admin.dataminer.services/) with the following scopes:

   - *Register catalog items*
   - *Read catalog items*
   - *Download catalog versions*

1. Securely store the key using Visual Studio User Secrets:

   1. Right-click the project and select *Manage User Secrets*.

   1. Add the key in the following format:

      ```json
      { 
        "skyline": {
          "sdk": {
            "dataminertoken": "MyKeyHere"
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

### Updating Catalog item details

To update only the **Catalog item details**, you can re-publish an already existing version. The Catalog does not allow the re-publishing of an existing version artifact, so the artifact will not be updated (i.e. the existing version will remain unchanged in the Catalog). However, the Catalog item details will be updated. This includes the details provided in the **manifest.yml** and the **readme**.

If you have set the default key name as a system environment variable (see above), you can run the following command:

```bash
dotnet publish -p:Version="1.0.0"
```

> [!NOTE]
> When `Version` is not included in the command, it will default to the value defined in the `<Version>` tag in the .csproj file.

### Publishing to the Catalog with the demo CI/CD workflow

If you have used the *Skyline.DataMiner.VisualStudioTemplates*, your project can include a demo GitHub workflow for Catalog publishing.

Follow these steps to set it up:

1. Create a GitHub repository by going to *Git* > *Create Git Repository* in Visual Studio, selecting GitHub, and filling in the wizard before clicking *Create and Push*.

1. In GitHub, go to the *Actions* tab.

1. Click the workflow run that failed (usually called *Add project files*).

1. Click the "build" step that failed and read the error.

   ``` text
   Error: DATAMINER_TOKEN is not set. Release not possible!
   Please create or re-use an admin.dataminer.services token by visiting: https://admin.dataminer.services/.
   Navigate to the right organization, then go to Keys and create or find a key with permission Register catalog items, Download catalog versions, and Read catalog items.
   Copy the value of the token.
   Then set a DATAMINER_TOKEN secret in your repository settings: **Dynamic Link**
   ```

   You can use the links from the actual error to better address the next couple of steps.

1. Obtain an **organization key** from [admin.dataminer.services](https://admin.dataminer.services/) with the following scopes:

   - *Register catalog items*
   - *Read catalog items*
   - *Download catalog versions*

1. Add the key as a secret in your GitHub repository, by navigating to *Settings* > *Secrets and variables* > *Actions* and creating a secret named `DATAMINER_TOKEN`.

1. Re-run the workflow.

With this setup, any push with new content (including the initial creation) to the main/master branch will generate a new pre-release version, using the latest commit message as the version description.

#### Releasing a specific version

1. Navigate to the *<> Code* tab in your GitHub repository.

1. In the menu on the right, select *Releases*.

1. Create a new release, select the desired version as a **tag**, and provide a title and description.

> [!NOTE]
> The description will be visible in the Catalog.

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
   Navigate to the right organization, then go to Keys and create or find a key with permissions Register catalog items, Download catalog versions, and Read catalog items.
   Copy the value of the token.
   Then set a DATAMINER_TOKEN secret in your repository settings: **Dynamic Link**
   ```

   You can use the links from the actual error to better address the next couple of steps.

1. Obtain an **organization key** from [admin.dataminer.services](https://admin.dataminer.services/) with the following scopes:

   - *Register catalog items*
   - *Read catalog items*
   - *Download catalog versions*

1. Add the key as a secret in your GitHub repository, by navigating to *Settings* > *Secrets and variables* > *Actions* and creating secrets or variables with the required names.

1. Re-run the workflow.

The following secrets and variables will have been added to your repository after all issues are resolved:

| Name              | Type     | Description                                    | Setup Guide                                                                                               |
|-------------------|----------|------------------------------------------------|-----------------------------------------------------------------------------------------------------------|
| `DATAMINER_TOKEN` | Secret   | Organization key for downloading/publishing from/to the Catalog | Obtain from [admin.dataminer.services](https://admin.dataminer.services/) and add it as a secret.         |
| `SONAR_TOKEN`     | Secret   | Token for SonarCloud authentication            | Obtain from [SonarCloud Security](https://sonarcloud.io/account/security) and add it as a secret.         |
| `SONAR_NAME`      | Variable | SonarCloud project ID                          | Visit [SonarCloud](https://sonarcloud.io/projects/create), copy the project ID, and add it as a variable. |

#### Releasing a version

1. Navigate to the *<> Code* tab in your GitHub repository.

1. In the menu on the right, select *Releases*.

1. Create a new release, select the desired version as a **tag**, and provide a title and description.

> [!NOTE]
> The description will be visible in the Catalog.

## See also

- [Skyline DataMiner Package Project - Advanced](xref:skyline_dataminer_sdk_dataminer_package_project_advanced)
- [Skyline DataMiner Package Project - CatalogReferences.xml](xref:skyline_dataminer_sdk_dataminer_package_project_catalog_references)
- [Skyline DataMiner Package Project - ProjectReferences.xml](xref:skyline_dataminer_sdk_dataminer_package_project_project_references)
