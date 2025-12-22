---
uid: Using_GitHub_for_CICD
---

# Using GitHub - Guidelines

> [!IMPORTANT]
> The account and repository creation information in this section is only applicable to Skyline employees and includes links that are only accessible to Skyline employees.

You can use GitHub to:

- Share generic code/scripts or useful tools/libraries with the DataMiner community.
- Collaborate on code with external users.

> [!NOTE]
> At present, **only Automation scripts** have workflows available for packaging and deployment.
>
> Automation scripts that are packaged with other artifacts (Visio files, connectors, etc.) currently will not be able to use the GitHub actions, so we do not recommend using GitHub for those yet.

## Creating an account in GitHub's Skyline organization

See [Creating a GitHub account](https://internaldocs.skyline.be/Corporate/OfficeConventions/OC_Corporate/IT/IT_GitHub.html).

## Creating a repository in the Skyline organization

You can create either a public repository or a private repository.

**Public**: The code/script is generic and can be used outside of the context of the project.

**Private**: The code/script is specific to a project and cannot be shared publicly. 

## Selecting the right license

> [!IMPORTANT]
> When creating the repository, make sure you select the correct license. Changing the license later can be very challenging. If you want to publish code to a public repository, and you are not sure what license you should use, contact the IT team **before creating the repository** or create a private repository in the meantime and turn it into a public one only once the right license is applied.

For a script, the correct license is **MIT**.

## Repository naming convention

If the repository is private, the name should look like this (using "-" as separator): **{customerAcronym}-{itemType}-{itemName}**.

> [!IMPORTANT]
> If the repository is **public**, **do not use a customer acronym** in the repository name. Instead, use the **Skyline acronym "SLC"**.

> [!NOTE]
> When working on a repository that will have projects with different types, consider this as a Solution (see below).

- For a list of **customer acronyms**, refer to [DCP](https://dcp-ui.azurewebsites.net/customers). For generic repositories, use the Skyline Communications acronym (SLC).

- The following **item types** are currently supported (this list is to be extended):

  | Syntax | Description |
  |--|--|
  | AS | Automation Scripts. Note that specific types of Automation scripts, such as GQI data sources, User-Defined APIs, regression tests, etc., have their own syntax. |
  | C | Connectors |
  | CF | Companion Files |
  | CHATOPS | ChatOps extension |
  | D | Dashboards |
  | DISMACRO |DIS Macro |
  | DOC | Documentation |
  | F | Functions |
  | GQIDS | GQI data source |
  | GQIO | GQI operator |
  | LCA | Low-Code App |
  | LSO | Lifecycle Service Orchestration |
  | PA | Process Automation |
  | PLS | Profile-Load Scripts |
  | S | Solutions |
  | SC | Scripted Connector |
  | T | Tests: regression tests, integration tests, performance tests, etc. |
  | UDAPI | User-Defined APIs |
  | V | Visio files |
  | EXT | External tools - softwares  |

  > [!NOTE]
  > If you think an item type should be added, please contact us so we can add it before you create the repository.

- It is up to the repository creator to choose the **item name**; however, make sure this name clearly indicates the purpose of the repository.

## Adding a README file

It is important to add a *README.md* file to the root folder. The contents of this file should provide users with the necessary information to understand the purpose of the code and learn how to use it.

### Repository README structure

The root *README.md* file should include:

1. **Repository goal**: A short description (maximum three sentences) explaining the purpose of the repository.

2. **Projects overview**: A list of all projects in the solution with:
   - The project name as a link to its subfolder README (e.g. `[ProjectName](ProjectFolder/README.md)`)
   - A brief description of the project's goal

3. **Catalog link** (if applicable): If the repository is published to the Catalog, include a TIP alert with a link:

   > [!TIP]
   > This repository is available in the Catalog: [Catalog item name | Catalog | dataminer.services](https://catalog.dataminer.services/details/{catalog-item-guid})
   >
   > The Catalog item GUID (ID) and Name (Title) can be found in the *manifest.yml* file.

### Project README structure

Each project subfolder should contain its own *README.md* file with:

1. **Summary**: A functional overview of what the project does (not method-level details)

2. **Input arguments**: Documentation of any input parameters defined in the XML, including:
   - Parameter name
   - Expected type (number, text, multiple choice, etc.)
   - Description of the parameter's purpose

3. **Project type**: The type is automatically determined based on code patterns:

   | Code Pattern | Project Type |
   |--|--|
   | C# file implementing `IGQIDataSource` | Ad-Hoc Data Source |
   | C# file implementing `IGQIRowOperator` and/or `IGQIColumnOperator` | Data Transformer |
   | C# file containing `[AutomationEntryPoint(AutomationEntryPointType.Types.OnApiTrigger)]` | User-Defined API |
   | DMSScript XML file with `<Folder>` tag equal to `bot` or starting with `bot/` | ChatOps Operator |
   | DMSScript XML file | Automation Script |
   | Protocol XML file | Connector |

## Adding a .gitignore

It is important to add a *.gitignore* file to the root folder. The contents of this file will ensure that you do not commit things like assemblies from the bin folders or other user-specific configuration. Using the default suggested .gitignore should be sufficient.

## Adding topics to a repository

Topics must be used to help categorize the repositories and help users find them when exploring GitHub.

Here is a list of topics you should use (this list is to be extended):

- dataminer
- dataminer-connector
- dataminer-visio
- dataminer-solution
- dataminer-function
- dataminer-automation-script
- dataminer-dashboard
- dataminer-profile-load-script
- dataminer-process-automation-script
- dataminer-life-service-orchestration
- dataminer-gqi-data-source
- dataminer-gqi-operator
- dataminer-regression-test
- dataminer-UI-test
- dataminer-bot
- dataminer-user-defined-api
- dataminer-doc
- dataminer-dis-macro
- dataminer-chatops
- dataminer-nuget

If you have code for a specific project/customer, you should add a topic with the customer's name as well, e.g. `Skyline-Communications`. Always use a hyphen ("-") as a separator.

> [!NOTE]
> For regression tests, use *T* as the item type in the repository name, and use topics to identify the type of test, e.g. *dataminer-regression-test*.

> [!TIP]
> Refer to the [guidelines about adding topics](https://docs.github.com/en/repositories/managing-your-repositorys-settings-and-features/customizing-your-repository/classifying-your-repository-with-topics) and [Searching for repositories](https://docs.github.com/en/search-github/searching-on-github/searching-for-repositories) on docs.github.com.

## Collaborating with external users on code

In case private repositories have been created for a customer's project, external users (i.e. that customer's employees) can be invited to collaborate on the code.

An invite can then be sent to external users as "outside collaborators".

To ensure code is reviewed by the repository owner, "outside collaborators" should work on a fork of the repository and create a pull request for the owner to review and merge.

## Workflows available in GitHub

Both **Skyline employees and external users** can access some workflow templates Skyline has made available.

These workflows will allow you to:

- Build a solution
- Run unit tests
- Use SonarCloud
- Compile to a DataMiner package
- Deploy directly to a cloud-connected DataMiner Agent

When using the [Visual Studio Templates](xref:VisualStudioTemplates), workflows are automatically included with your project. You can select from different workflow options (demo, build, complete). It is very much recommended to use the **complete** workflow whenever possible. In the background, this will use on of our  [workflow templates](_ReusableWorkflows/.github/workflows/DataMiner App Packages Master Workflow.yml at main · SkylineCommunications/_ReusableWorkflows) for the CI part.

## Using GitHub actions to publish to a cloud-connected DataMiner Agent

An action [Skyline-DataMiner-Deploy-Action](https://github.com/SkylineCommunications/Skyline-DataMiner-Deploy-Action) is publicly available on GitHub to deploy from a GitHub repository.

Refer to [Marketplace deployment action](xref:Marketplace_deployment_action) for more information.

## Ensuring Dependabot can access the private GitHub NuGet registry

If a repository uses NuGet packages that are stored in Skyline's internal GitHub NuGet registry, Dependabot will not see those automatically.

Below is an example of a Dependabot configuration file that will check every day if there are any NuGet packages to update. The "PRIVATE_NUGET_USERNAME" and "PRIVATE_NUGET_PASSWORD" secrets are only available to Dependabot.

```yml
version: 2
registries:
  public:
    type: nuget-feed
    url: https://api.nuget.org/v3/index.json
  slc-github:
    type: nuget-feed
    url: https://nuget.pkg.github.com/SkylineCommunications/index.json
    username: ${{ secrets.PRIVATE_NUGET_USERNAME }}
    password: ${{ secrets.PRIVATE_NUGET_PASSWORD }}
updates:
  - package-ecosystem: "nuget" # See documentation for possible values
    directory: "/" # Location of package manifests
    registries: "*" # Which registries to use, * for all of them
    schedule:
      interval: "daily"
```

> [!TIP]
> For more information about the configuration file, see [Configuration options for the dependabot.yml file](https://docs.github.com/code-security/dependabot/dependabot-version-updates/configuration-options-for-the-dependabot.yml-file).
