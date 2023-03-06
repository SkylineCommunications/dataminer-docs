---
uid: github_starter_workflows
---

# Github Starter Workflows

We offer a number of starter workflows that can be used as the starting point to create a workflow for your GitHub Repository. These short .yml files are designed to be small and call both reusable workflows as well as actions from the marketplace that always try to run the latest versions.

A [Github Action](xref:github_actions) provides an easy access point to a single key action, such as deploying a dmapp, creating a dmapp, running tests, and more. 
Meanwhile, a [Github Reusable Workflow](xref:github_reusable_workflows)  allows the reuse of a combination of many different Github Actions and other scripts, running across several jobs combined into a single easy call.

By combining these three concepts, you can avoid maintenance costs and ensure that you always run the latest stable versions without needing further user configuration. Any default behavior can easily be overwritten and changed on your copy of the starter workflow if you wish to always use a specific version until manually adjusted. This might be necessary to meet security requirements for your organization.

## How to use a Starter Workflow

### On a public repository

In your github repository, navigate to the Actions tab.
If this is your first workflow then simple scroll down to the Workflows provided by your organisation and select the one that matches the content and intent of your repository.
If you're wanting to add an extra workflow to your repository then you should see a button "New Workflow" to the left. It will open the starter workflow selection screen again.

### On a private repository

If your github organisation has the enterprise edition then you will find the starter workflow offered by your organisation directly in the UI as explained in the "[On a public repository](#on-a-public-repository)" topic.

In the free version of github you won't see starter workflows in the UI directly. In this case you have to follow the following steps:

1. Navigate to the "workflow-templates" folder inside of the ".github" repository of your organisation for members of Skyline Communications this would be [https://github.com/SkylineCommunications/.github/tree/main/workflow-templates](https://github.com/SkylineCommunications/.github/tree/main/workflow-templates).
2. Select the workflow template that matches the content of your repository and look at the sourcecode.
3. Copy that and then navigate to your own Repository Action Tab.
4. Select a New Workflow and choose "Set-up a workflow yourself"
5. Paste your starter workflow.

### Deployment Jobs

Some of the starter workflows will have commented out jobs at the bottom. These are usually jobs of type Deployment.
If you want to automatically configure CD (Continuous Deployment) you can uncomment such a Job and adjust conditions on it as you prefer to deploy to one or multiple systems.

## Cross-Organisation cooperation

Since 2020, GitHub has only allowed Community Starter Workflows to be placed in the .github directory of an organization, rather than in the global overview. To help your organization obtain new workflows from Skyline Communications without the ability to add them to the global overview, we have created a public [repository](https://github.com/SkylineCommunications/Skyline-Starter-Workflows) that you can [Fork](https://github.com/SkylineCommunications/Skyline-Starter-Workflows/fork)  into your own organization.

Once you have [set-up that fork](#set-up-organisation-starter-workflows), you will automatically receive pull requests on your organization's .github repository with changes to the starter workflows. Users with the appropriate authentication will be able to accept and merge these pull requests to benefit from any new or modified workflow files.

This allows your organization to easily adjust or add workflows to meet your specific needs and to handle any necessary merging through pull requests.

## Set-up organisation starter workflows

1. (Optional) Start by creating a GitHub user specifically for Bot activities. e.g. name:CICDOrganisation. Use a shared mailbox from you organisation if possible. (If this isn't possible due to for example 2FA, you can use a personal github account with rights to create repositories)
2. (Optional) Add that user to your Organisation and make sure it has enough rights to create new repositories.
3. Create a Personal Access Token (Classic) for your user by going to the User Settings>Developer Settings>Personal Access Tokens. (See [github docs](https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/creating-a-personal-access-token) for more details)

    with the following scopes:
    - repo
    - workflow
    - admin:org/write:org
    - admin:org/read:org

4. [Fork](https://github.com/SkylineCommunications/Skyline-Starter-Workflows/fork) our Skyline-Starter-Workflows repository into your own organisation.
5. Go to the settings of your fork and Secrets and variables>Actions. Add a new secret called PAT and use the previously created Personal Access Token as the value.
6. Go to the Actions Tab and Enable the workflow (after you've verified its content and are satisfied)
7. You can go to that workflow and trigger an initial run manually. After which it will automatically run every day to check for up-stream changes.

## Contribute

Everyone is able to contribute and add Starter Workflows specifically to the ones automatically provided by Skyline Communications.

If you're looking to provide a Starter Workflow that should only be used within your organisation then you should [Fork the .github repository](https://github.com/SkylineCommunications/.github/fork) to your local account.
If you're looking to provide a Starter Workflow that can be shared across different organisations then you should [Fork the Skyline-Starter-Workflows repository](https://github.com/SkylineCommunications/Skyline-Starter-Workflows/fork to your local account.

In either case, you can then start making changes and finalize with a Pull Request.

For any questions concerning a pull request, feel free to contact the [Data Acquisition Domain](mailTo:support.data-acquisition@skyline.be?subject=Pull%20Request%20-%20Github%20Workflow%20Contribution&body=Hello,) within Skyline Communications.
