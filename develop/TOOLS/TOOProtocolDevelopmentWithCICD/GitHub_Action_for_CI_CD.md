---
uid: GitHub_Action_for_CI_CD
---

# Deploying Automation scripts from a GitHub repository

It's possible to deploy your Automation script solution from a GitHub repository by using the Skyline DataMiner Deploy Action in a workflow.

## Creating a DCP key

This key is scoped to the specific DMS for which it was created and will allow for deployments to that DMS only. A guide on how to create a DCP key can be found [here](xref:Managing_DCP_keys).

## Adding the key as a secret in the repository

The key should be added as a secret in the repository. This way the key is stored securely in GitHub and is not stored in source control.

1. Copy the value from the admin page using the copy button next to one of the keys.
1. Go over to your GitHub repository and go to *settings*.
1. In the left pane, look for the security section and click *Secrets* followed by *Actions*.

   ![Actions tab](~/develop/images/GitHub_settings_secrets.png)

1. On the top right of the page, click *New repository secret*.
1. Give a name to your secret (E.g. `DCP_KEY`), paste the key as value for the secret and then save the secret.
1. Once it is saved, your secret will appear in the *repository secrets* and it can be used in a workflow.

> [!NOTE]
> More information about secrets can be found in the [GitHub Documentation](https://docs.github.com/en/actions/security-guides/encrypted-secrets)
>

## Adding the Skyline DataMiner Deploy Action to a workflow

1. If you don't have a workflow yet you can create one by going to the *Actions* tab in GitHub and click *set up a workflow yourself*. This will create a basic workflow file.
1. To add the Skyline DataMiner Deploy Action to the workflow, in the right pane select Marketplace, search for *Skyline DataMiner Deploy Action* and click it.

   ![Search for action](~/develop/images/GitHub_workflow_marketplace.png)

1. Copy and paste the template code and fill in the required parameters. More information about the action itself can be found [here](https://github.com/marketplace/actions/skyline-dataminer-deploy-action)