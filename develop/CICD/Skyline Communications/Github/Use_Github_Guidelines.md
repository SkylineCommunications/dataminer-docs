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

How to choose?

**Public**: The code/script is generic and can be used outside of the context of the project.

**Private**: The code/script is specific to a project and cannot be shared publicly.

## Selecting the right license

> [!IMPORTANT]
> When creating the repository, make sure you select the correct license. Changing the license later can be very challenging. If you want to publish code to a public repository, and you are not sure what license you should use, contact the IT team **before creating the repository** or create a private repository in the meantime and turn it into a public one only once the right license is applied.

For a script, the correct license is **MIT**.

## Repository naming convention

The repository name should look like this (using "-" as separator): **{customerAcronym}-{itemType}-{itemName}**

- For a list of **customer acronyms**, refer to [DCP](https://dcp.skyline.be/Lists/Customers/AllItems.aspx). For generic repositories, use the Skyline Communications acronym (SLC).

- The following **item types** are currently supported (this list is to be extended):

  - C (Connectors)
  - V (Visio files)
  - S (Solutions)
  - F (Functions)
  - AS (Automation Scripts)
  - PLS (Profile-Load Scripts)
  - PA (Process Automation)
  - LSO (Life Service Orchestration)
  - D (Dashboards)
  - CF (Companion Files)
  - T (Tests)
  - GQIDS (GQI data source)
  - GQIO (GQI operator)

  > [!NOTE]
  > If you think an item type should be added, please contact us so we can add it before you create the repository.

- It is up to the repository creator to choose the **item name**; however, make sure this name clearly indicates the purpose of the repository.

## Adding a README file

It is important to add a *README.md* file to the root folder. The contents of this file should provide users with the necessary information to understand the purpose of the code and learn how to use it.

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

Please refer to [GitHub's workflow documentation](https://docs.github.com/en/actions/using-workflows/about-workflows) and to our [workflow templates](https://github.com/SkylineCommunications/.github/tree/main/workflow-templates).

For Automation, see [DataMiner CI/CD Automation](https://github.com/SkylineCommunications/.github/blob/main/workflow-templates/DataMiner-CICD-Automation.yml):

- The first section contains the CI part and makes reference to [reusable workflows](https://github.com/SkylineCommunications/_ReusableWorkflows).

- The second section (optional and commented out by default) contains the CD part to deploy the DataMiner package to a cloud-connected DataMiner Agent.

## Using GitHub actions to publish to a cloud-connected DataMiner Agent

An action [Skyline-DataMiner-Deploy-Action](https://github.com/SkylineCommunications/Skyline-DataMiner-Deploy-Action) is publicly available on GitHub to deploy from a GitHub repository.

Refer to [Deploying Automation scripts from a GitHub repository](xref:Deploying_Automation_scripts_from_a_GitHub_repository) for more information.
