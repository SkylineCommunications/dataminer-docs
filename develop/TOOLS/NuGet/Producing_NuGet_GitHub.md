---
uid: Producing_NuGet_GitHub
---

# Producing NuGet packages via GitHub

NuGet packages can be produced automatically using the [Master Workflow](xref:github_reusable_workflows_master_workflow). When a tag is created in the format `A.B.C` or `A.B.C-text`, the workflow will build, test, sign, and publish your NuGet packages. Where the packages are published depends on the `nuget-push-source` input.

## Publishing to the GitHub NuGet registry

By default (when no `nuget-push-source` is configured), the [Master Workflow](xref:github_reusable_workflows_master_workflow) publishes NuGet packages to the [GitHub Packages registry](https://github.com/features/packages) of the repository owner. For the *SkylineCommunications* organization, this means packages are stored in the [SkylineCommunications GitHub NuGet registry](https://github.com/orgs/SkylineCommunications/packages) and can be consumed by other repositories in the organization.

### Creating a personal access token

> [!NOTE]
> If you have already created a token for reading packages, you can optionally modify it. See [Consuming NuGet packages](xref:Consuming_NuGet).

To access the GitHub NuGet registry, you need a personal access token (PAT). Follow these steps:

1. Follow the instructions in [the official GitHub Docs](https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/managing-your-personal-access-tokens#creating-a-personal-access-token-classic) to create a PAT.

   - **Expiration**: Choose the *No expiration* default option.

     > [!NOTE]
     > You can choose to set an expiration date for your token. However, this will require you to update the token more frequently on your local machine and repositories.

   - **Scope**: Select the *write:packages* and *delete:packages* scopes. The *repo* scope should be selected by default as well.

1. Click *Generate token* in the lower-left corner.

1. Copy your personal access token. You will not be able to see it again afterwards.

### Setting up the workflow

To publish to the GitHub NuGet registry, use the [Master Workflow](xref:github_reusable_workflows_master_workflow) without specifying a `nuget-push-source`. The default behavior will push to the GitHub Packages registry.

Follow the instructions in [the official GitHub Docs](https://docs.github.com/en/actions/security-guides/using-secrets-in-github-actions) to add a new secret to your repository:

- **Name**: Enter `NUGET_API_KEY`.

- **Secret**: Enter your personal access token.

Then pass the secret in your workflow file:

```yml
jobs:

  CI:
    uses: SkylineCommunications/_ReusableWorkflows/.github/workflows/Master Workflow.yml@main
    with:
      sonarcloud-project-name: ${{ vars.SONAR_NAME }}
    secrets:
      SONAR_TOKEN: ${{ secrets.SONAR_TOKEN }}
      NUGET_API_KEY: ${{ secrets.NUGETAPIKEY_GITHUB }}
```

### Verifying the published package

After creating the tag and running the workflow, you can find your package on the *Packages* page on [GitHub](https://github.com/orgs/SkylineCommunications/packages).

If you did not specify a repository URL in the .csproj file, the package will not be linked with the repository. You can establish this link by following the steps explained [in the official GitHub Docs](https://docs.github.com/en/packages/learn-github-packages/connecting-a-repository-to-a-package#connecting-a-repository-to-an-organization-scoped-package-on-github).

This will link the repository and showcase the *README.md* file, contributors, and more. On the right side of the repository, you will also see the released packages.

## Publishing to nuget.org

To publish your NuGet packages to [nuget.org](https://www.nuget.org/) instead of the GitHub Packages registry, set the `nuget-push-source` input to `https://api.nuget.org/v3/index.json` and provide a `NUGET_API_KEY` secret with a valid nuget.org API key.

> [!IMPORTANT]
> Skyline employees do not manage their own nuget.org API keys. To set up nuget.org publishing for a repository, contact the **BOOST team** and ask them to configure the `NUGETAPIKEY` secret on your repository.

```yml
jobs:

  CI:
    uses: SkylineCommunications/_ReusableWorkflows/.github/workflows/Master Workflow.yml@main
    with:
      sonarcloud-project-name: ${{ vars.SONAR_NAME }}
      nuget-push-source: "https://api.nuget.org/v3/index.json"
    secrets:
      SONAR_TOKEN: ${{ secrets.SONAR_TOKEN }}
      NUGET_API_KEY: ${{ secrets.NUGETAPIKEY }}
```

After creating a tag, the workflow will build, test, sign, and publish your NuGet packages to nuget.org. You can verify the published package at `https://www.nuget.org/packages/<YourPackageName>`.
