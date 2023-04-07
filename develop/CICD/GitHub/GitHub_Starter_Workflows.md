---
uid: github_starter_workflows
---

# GitHub starter workflows

We offer a number of starter workflows that can be used as the starting point to create a workflow for your GitHub repository. These .yml files are designed to be small and call both reusable workflows and actions from the marketplace that always try to run the latest versions.

A [GitHub action](xref:Deploying_Automation_scripts_from_a_GitHub_repository) provides an easy access point to a single key action, such as deploying a DMAPP, creating a DMAPP, running tests, and more.

[GitHub reusable workflow](xref:github_reusable_workflows) allows the reuse of a combination of many different GitHub actions and other scripts, running across several jobs combined into a single easy call.

By combining these three concepts, you can avoid maintenance costs and ensure that you always run the latest stable versions without the need for further user configuration. Any default behavior can easily be overwritten and changed on your copy of the starter workflow if you wish to always use a specific version until it is manually adjusted. This might be necessary to meet security requirements for your organization.

## Using a starter workflow

### In a public repository

In your GitHub repository, navigate to the *Actions* tab.

If this is your first workflow, scroll down to the workflows provided by your organization and select the one that matches the content and intent of your repository.

If you want to add a new workflow to your repository, you should see a button *New Workflow* to the left. This will open the starter workflow selection screen.

### In a private repository

If your GitHub organization has the enterprise edition, you will find the starter workflow offered by your organization directly in the UI as explained [above](#in-a-public-repository).

In the free version of GitHub, you will not see starter workflows in the UI directly. In this case, perform the following steps:

1. Navigate to the *workflow-templates* folder in the *.github* repository of your organization.

   For members of Skyline Communications, this is <https://github.com/SkylineCommunications/.github/tree/main/workflow-templates>.

1. Select the workflow template that matches the content of your repository and look at the source code.

1. Copy that and navigate to the *Actions* tab of your own repository.

1. Select *New Workflow* and select to set up a workflow yourself.

1. Paste your starter workflow.

### Deployment jobs

Some of the starter workflows will have commented out jobs at the bottom. These are usually jobs of type Deployment.

If you want to automatically configure CD (continuous deployment), you can uncomment such a job and adjust conditions on it to deploy to one or multiple systems.

## Cross-organization cooperation

At present, GitHub allows community starter workflows to be placed only in the .github directory of an organization, rather than in the global overview. To help your organization obtain new workflows from Skyline Communications even though these cannot be placed in the global overview, we have created a [public repository](https://github.com/SkylineCommunications/Skyline-Starter-Workflows) that you can [fork](https://github.com/SkylineCommunications/Skyline-Starter-Workflows/fork) into your own organization.

Once you have [set up that fork](#setting-up-organization-starter-workflows), you will automatically receive pull requests on your organization's .GitHub repository with changes to the starter workflows. Users with the appropriate authentication will be able to accept and merge these pull requests to benefit from any new or modified workflow files.

This allows your organization to easily adjust or add workflows to meet your specific needs and to handle any necessary merging through pull requests.

## Setting up organization starter workflows

1. Optionally, start by creating a GitHub user specifically for bot activities, e.g. with the name *CICDOrganization*.

   - Use a shared mailbox from your organization if possible. If this is not possible, for example because of 2FA, you can use a personal GitHub account with rights to create repositories.

   - Add the user to your organization and make sure they have enough rights to create new repositories.

1. Go to *User Settings* > *Developer Settings* > *Personal Access Tokens* to create a personal access token (classic) for your GitHub user.

   Make sure the token has the following scopes:
    - repo
    - workflow
    - admin:org/write:org
    - admin:org/read:org

   > [!TIP]
   > For more details, refer to the [GitHub docs](https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/creating-a-personal-access-token).

1. [Fork](https://github.com/SkylineCommunications/Skyline-Starter-Workflows/fork) our *Skyline-Starter-Workflows* repository into your own organization.

1. Add a new secret to the fork:

   1. Go to the settings of your fork and select *Secrets and variables* > *Actions*.

   1. Add a new secret called PAT and use the previously created personal access token as the value.

1. Go to the *Actions* tab, verify the content of your workflow, and then enable the workflow.

1. Go to the workflow and trigger an initial run manually.

   After this, it will automatically run every day to check for upstream changes.

## Contributing

Everyone can contribute and add starter workflows to the ones automatically provided by Skyline Communications.

If you want to provide a starter workflow that should only be used within your organization, you should [fork the .github repository](https://github.com/SkylineCommunications/.github/fork) to your local account.

If you want to provide a starter workflow that can be shared across different organizations, you should [fork the Skyline-Starter-Workflows repository](https://github.com/SkylineCommunications/Skyline-Starter-Workflows/fork) to your local account.

In either case, you can then start making changes and finalize them with a pull request.

> [!TIP]
> If you have any questions concerning a pull request, contact the Skyline Communications [Data Acquisition Domain](mailTo:support.data-acquisition@skyline.be?subject=Pull%20Request%20-%20GitHub%20Workflow%20Contribution&body=Hello,).
