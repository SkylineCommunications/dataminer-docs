---
uid: Producing_NuGet_GitHub
---

# Producing NuGet packages via GitHub

> [!IMPORTANT]
> This section includes information that is only applicable to Skyline employees and/or links that are only accessible to Skyline employees.

## Internal NuGet packages

It is possible to create internal packages on GitHub that are stored in the GitHub NuGet registry from the 'SkylineCommunications' organization.

This can then be used by other repositories in our SkylineCommunications organization when using the workflows that are provided.

> [!NOTE]
> Internal NuGet packages on GitHub can not be used on Jenkins.

### Step 0: Create Personal Access Token

> [!NOTE]
> If you have already created a token for reading the packages, you can adapt that token if you want.
> See [Consuming NuGet packages](xref:Consuming_NuGet).

First off you need to make a Personal Access Token (PAT). This will enable you to read/write from/to the NuGet registry. More information on how to create a PAT can be found here: [Creating a personal access token (classic)](https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/managing-your-personal-access-tokens#creating-a-personal-access-token-classic)

Set the expiration to *No expiration*. You can let it expire, but then you'll need to more frequently update this locally and on your repositories.

For the scopes select:

- *write:packages*
- *delete:packages*

You will see that the *repo* scope is automatically selected as well.

Click *Generate token* at the bottom and make sure to copy the token as you are unable to see it again afterwards!

### Publishing an internal NuGet package

#### Step 1: GitHub Workflow

Instead of taking the regular Github workflow for NuGet solutions, use the one for Internal NuGet solutions. Add a secret `NUGETAPIKEY_GITHUB` with the PAT token as value.

#### Step 2: Create a tag

After creating the tag and running the workflow you'll find your package on [GitHub Packages](https://github.com/orgs/SkylineCommunications/packages).

If you didn't specify a repository url in the csproj file, then the package isn't linked with the repository. You can link it by following the steps explained [here](https://docs.github.com/en/packages/learn-github-packages/connecting-a-repository-to-a-package#connecting-a-repository-to-an-organization-scoped-package-on-github).

This will link the repository and showcasing the Readme file, the contributors, etc. On the repository you'll also see at the right the package that is released.
