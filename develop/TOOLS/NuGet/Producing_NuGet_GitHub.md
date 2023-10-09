---
uid: Producing_NuGet_GitHub
---

# Producing NuGet packages via GitHub

> [!IMPORTANT]
> This section includes information that is only applicable to Skyline employees and/or links that are only accessible to Skyline employees.

## Internal NuGet packages

It is possible to create internal packages on GitHub that are stored in the GitHub NuGet registry from the 'SkylineCommunications' organization.

This can then be used by other repositories in our SkylineCommunications organization when using the workflows that are provided.

### Creating a personal access token

> [!NOTE]
> If you have already created a token for reading packages, you can optionally modify it. See [Consuming NuGet packages](xref:Consuming_NuGet).

To access the GitHub NuGet registry, you need a personal access token (PAT). Follow these steps:

1. Follow the instructions in [the official GitHub Docs](https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/managing-your-personal-access-tokens#creating-a-personal-access-token-classic) to create a PAT.

   - **Expiration**: Choose the *No expiration* default option.

     > [!NOTE]
     > You can choose to set an expiration date for your token. However, this will require you to update the token more frequently on your local machine and repositories.

   - **Scope**: Select the *write:packages* and *delete:packages* scopes. The *repo* scope should be selected by default as well.

1. Click *Generate token* in the lower left corner.

1. Copy your personal access token. You will not be able to see it again afterwards.

### Publishing an internal NuGet package

#### Editing the GitHub Workflow

Instead of using the regular GitHub workflow for NuGet solutions, use the following starter workflow: **Internal DataMiner CICD NuGet Solution**.

Follow the instructions in [the official GitHub Docs](https://docs.github.com/en/actions/security-guides/using-secrets-in-github-actions) to add a new secret:

- **Name**: Enter `NUGETAPIKEY_GITHUB`.

- **Secret**: Enter your personal access token.

#### Publishing the package

After creating the tag and running the workflow, you can find your package on the *Packages* page on [GitHub](https://github.com/orgs/SkylineCommunications/packages).

If you did not specify a repository URL in the csproj file, the package will not be linked with the repository. You can establish this link by following the steps explained [in the official GitHub Docs](https://docs.github.com/en/packages/learn-github-packages/connecting-a-repository-to-a-package#connecting-a-repository-to-an-organization-scoped-package-on-github).

This will link the repository and showcase the *README.md* file, contributors, and more. On the repository's right-hand side, you will also see the released packages.
