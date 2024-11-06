---
uid: CICD_Tutorial_GitHub_Setting_Up_Organization
---

# Setting up your development environment in GitHub

In this tutorial, you will learn how to set up an Organization in GitHub and SonarCloud so that you and your development team can collaboratively develop DataMiner artifacts while maintaining high-quality standards. This tutorial sets up the framework to achieve the same quality standards that developers at Skyline Communications adhere to. It will also add Starter Workflows provided by Skyline to improve efficiency. Additionally, you will learn how to set up SonarCloud, a mandatory static analysis tool used in all Skyline-provided GitHub workflows.

If you are interested in learning how to set up CI/CD in other technologies, such as Jenkins, GitLab, Concourse, Azure DevOps, etc., check out the [Setting up basic CI/CD for connectors](xref:CICD_Tutorial_Connector) tutorial.

Expected duration: 10 minutes.

## Private versus public code

Both SonarCloud and GitHub require paid licenses to fully support private GitHub repositories.

For real-world scenarios, you will likely need at least a paid SonarCloud license to work with private GitHub repositories. A free GitHub version can still be used for private repositories, but this will slightly alter how you work with the product.

## Prerequisites

- [GitHub account](https://docs.github.com/en/get-started/signing-up-for-github/signing-up-for-a-new-github-account)

## Overview

- [Step 1: Create a GitHub Organization](#step-1-create-a-github-organization)
- [Step 2: Create a SonarCloud Organization and link with GitHub](#step-2-create-a-sonarcloud-organization-and-link-with-github)
- [Step 3: Setting Up Organization Starter Workflows](#step-3-setting-up-organization-starter-workflows)
- [Step 4: Adjust Permissions for GITHUB_TOKEN](#step-4-adjust-permissions-for-github_token)
- [Step 5: Optionally Add Organization Wide-Secrets](#step-5-optionally-add-organization-wide-secrets)

## Step 1: Create a GitHub Organization

Follow the instructions specified by [GitHub Docs](https://docs.github.com/en/organizations/collaborating-with-groups-in-organizations/creating-a-new-organization-from-scratch).

## Step 2: Create a SonarCloud Organization and link with GitHub

Follow the instructions specified by [SonarCloud Docs](https://docs.sonarsource.com/sonarcloud/getting-started/github/).

## Step 3: Setting Up Organization Starter Workflows

1. Optionally, create a GitHub user specifically for bot activities, e.g., *CICDOrganization*.

   - Use a shared mailbox from your organization if possible. If not, for example, due to 2FA, you can use a personal GitHub account with rights to create repositories.

   - Add the user to your organization and ensure they have sufficient rights to create new repositories.

1. Go to *User Settings* > *Developer Settings* > *Personal Access Tokens* to create a personal access token (classic) for your GitHub user.

   Ensure the token has the following scopes:
    - repo
    - workflow
    - admin:org/write:org
    - admin:org/read:org

   > [!TIP]  
   > For more details, refer to the [GitHub docs](https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/creating-a-personal-access-token).

1. [Fork](https://github.com/SkylineCommunications/Skyline-Starter-Workflows/fork) the *Skyline-Starter-Workflows* repository into your organization.

1. Add a new secret to the fork:

   1. Go to the settings of your fork and select *Secrets and variables* > *Actions*.
   1. Add a new secret called `PAT` and use the previously created personal access token as the value.

1. Go to the *Actions* tab, verify the workflow content, and enable the workflow.

1. Go to the workflow and trigger an initial run manually.

   After this, it will automatically run daily to check for upstream changes.

## Step 4: Adjust Permissions for GITHUB_TOKEN

Some workflows provided by Skyline will automatically create files containing information needed when you upload an artifact to the catalog. These files retrieve data from the GitHub UI. To create an auto-generated file, the GITHUB_TOKEN present in workflows must have write permissions.

You can enable this at the organization level by setting the Workflow permissions to *Read and write permissions* as [shown here](https://docs.github.com/en/organizations/managing-organization-settings/disabling-or-limiting-github-actions-for-your-organization#setting-the-permissions-of-the-github_token-for-your-organization).

> [!NOTE]  
> The GITHUB_TOKEN only has access to the currently running workflow. It also does not trigger new workflow runs when used to push new files, which helps prevent endless loops of CI/CD flows.

## Step 5: Optionally Add Organization-Wide Secrets

Some Skyline-provided workflows require tokens and secrets to access services like SonarCloud or your private DataMiner catalog. Instead of adding secrets to every repository, you can add them organization-wide.

Unless you have a paid GitHub Subscription, these secrets will only be available for public repositories.

1. In your GitHub Organization, click on the *Settings* tab.

1. Scroll down to **Secrets and variables** under **Security**.

1. Select *Actions*.

1. You can now add new organization secrets such as `SONAR_TOKEN`, as explained in [our documentation](xref:GitHub_Secrets).
1. 