---
uid: Marketplace_deployment_action
---

# Deployment through the GitHub Marketplace action

> [!IMPORTANT]
> This GitHub action no longer runs under its own docker image. The docker image has been deprecated and is replaced by .NET tools that makes it easier to create workflows/pipelines/... outside of GitHub and still be able to deploy packages to DataMiner. You can still use this GitHub action in GitHub workflows. It will perform the dotnet tool calls in the background on the current runner. If you want more modular control on the actions performed, consider using the .NET tools instead to package, upload, and deploy as shown in [this example](xref:CICD_GitHub_Examples).

It is possible to deploy an Automation script solution from a GitHub repository by using the Skyline DataMiner Deploy Action in a workflow.

To do so, you need to [create a dataminer.services key](#creating-a-dataminerservices-key), [add the key as a secret in the repository](#adding-the-key-as-a-secret-in-the-repository), and [add the Skyline DataMiner Deploy Action to a workflow](#adding-the-skyline-dataminer-deploy-action-to-a-workflow).

> [!IMPORTANT]
> You will only be able to use this feature if your DataMiner System is connected to dataminer.services. See [Connecting your DataMiner System to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

## Creating a dataminer.services key

A dataminer.services key is scoped to the specific organization for which it was created and can only be used for uploads and deployments to that organization.

For more information on how to create a dataminer.services key, refer to [Managing dataminer.services keys](xref:Managing_dataminer_services_keys#organization-keys).

## Adding the key as a secret in the repository

The (primary or secondary) key should be added as a secret in the repository, so that it is stored securely in GitHub and not stored in source control.

1. Copy the value from the Admin app using the copy button next to the (primary or secondary) key.

1. In your GitHub repository, go to *Settings*.

1. In the pane on the left, under *Security*, select *Secrets* > *Actions*.

   ![Actions page](~/develop/images/GitHub_settings_secrets.png)

1. In the top-right corner, click *New repository secret*.

1. Specify a name for your secret (e.g. `MY_KEY`), paste the key as the value for the secret, and then save the secret.

   Once it is saved, your secret will be displayed in the *repository secrets*, and you will be able to use it in a workflow.

> [!NOTE]
> For more information about secrets, refer to the [GitHub Documentation](https://docs.github.com/en/actions/security-guides/encrypted-secrets)

## Adding the Skyline DataMiner Deploy Action to a workflow

1. If you do not have a workflow yet, you can create one by going to the *Actions* tab in GitHub and clicking *Set up a workflow yourself*. This will create a basic workflow file.

   If you already have a workflow, you can edit it by opening the workflow file and clicking the pencil icon.

1. In the pane on the right, select *Marketplace*, search for *Skyline DataMiner Deploy Action* and select it.

   ![Search for action](~/develop/images/GitHub_workflow_marketplace.png)

1. Copy and paste the template code and fill in the required parameters.

   For more information about the parameters and the action itself, refer to [Skyline DataMiner Deploy Action](https://github.com/marketplace/actions/skyline-dataminer-deploy-action).
