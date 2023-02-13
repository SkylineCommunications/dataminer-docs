---
uid: Using_GitHub_for_CICD
---

# Using GitHub - Guidelines

You can use GitHub to:

- share generic code or useful tools/libraries with Dataminer community
- collaborate on code with external users
- repositories or for an Automation script solution.

> [!NOTE]
> As of today , **only automation scripts** have actions available for packaging and deployment.
>
> Automation scripts that are packaged with other artifacts ( Visio files , connectors...) won't be able to use the GitHub actions, it is then not recommended to use GitHub for those yet.

## Creating an account in GitHub's Skyline organization

Please refer to the following procedure: [Creating a GitHub account](https://internaldocs.skyline.be/Corporate/OfficeConventions/OC_Corporate/IT/IT_GitHub.html)
> [!NOTE]
> Account & repository creation only applies to Skyline internal users.

## Creating a repository in Skyline organization

You can either create a public repository or a private repository.

How to choose?

**Public** : The code/script is generic and can be used outside of the context of the project.

**Private** : The code/script is specific to a project and can't be shared publicly  

## Selecting the right License

> [!IMPORTANT]
> When creating the repository , make sure you select the correct license. Changing the license later can become very challenging.
> If you want to publish code to a public repository and you are not sure what license you should use, please contact IT team.

For a script, the correct License is **MIT**.

## Repository naming convention

Repository name should look like this (use ‘-‘ as separator) : **{customerAcronym}-{itemType}-{itemName}**

List of [Customers Acronyms](https://dcp.skyline.be/Lists/Customers/AllItems.aspx).

List of Item Types (to be extended) :

- C (Connectors)
- V (Visio files)
- S (Solutions)
- F (functions)
- AS (Automation Scripts)
- PLS (Profile Load Scripts)
- D (Dashboard)
- CF (Companion Files)

Item Name : Up to the repository creator but the name should clearly indicate the purpose of the repository.

## Adding topics to the repository

Topics must be used to help categorize the repositories and help users find them when exploring Github.

Here you can find some guidelines about [adding topics](https://docs.github.com/en/repositories/managing-your-repositorys-settings-and-features/customizing-your-repository/classifying-your-repository-with-topics)

### How to search for repositories

Github Documentation about [searching](https://docs.github.com/en/search-github/searching-on-github/searching-for-repositories)

## Collaborate with external users on code

In case of private repositories created for a customer's project, external users (ie: customer's employees) can be invited to collaborate on the code.

An invite can then be sent to external users as "outside collaborators".

## Worfklows available in Github

Skyline **and external users** can access some workflow templates Skyline has made available.

Here you can find a list of [reusable workflows](https://github.com/SkylineCommunications/_ReusableWorkflows) in Github.

These workflows will allow you to :

- Build a solution
- Run Unit Tests
- Use of SonarCloud
- Compile to a Dataminer Package
- Deploy directly to a Cloud Connected Dataminer Agent

## Use Github actions to publish to a "Cloud Connected" Dataminer Agent

An action is publicly available in GitHub to deploy from a GitHub repository.

Here you can find documentation about how to use the [Deploy Actions](https://docs.dataminer.services/develop/TOOLS/CICD/Deploying_Automation_scripts_from_a%20GitHub_repository.html)
