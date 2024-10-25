---
uid: GitHub_Secrets
---

# GitHub Secrets

Several tools, starter workflows and reusable workflows provided by Skyline will require secrets and tokens to run correctly.
On this page you can find where to find the tokens you may need and how to add them as a secret in your repository.

## Public vs Private Repositories

When using a **paid GitHub License** or **Public** Repositories it's possible that some secrets and tokens have been set as Organization Secrets and then those can be used.
Otherwise you'll have to 'override' the organization secrets by adding Repository Secrets.

## Adding the key as a secret in the repository

The key should be added as a secret in the repository, so that it is stored securely in GitHub and not stored in source control.

1. Copy the value from the required key.

1. In your GitHub repository, go to *Settings*.

1. In the pane on the left, under *Security*, select *Secrets* > *Actions*.

   ![Actions page](~/develop/images/GitHub_settings_secrets.png)

1. In the top-right corner, click *New repository secret*.

1. Specify a name for your secret (e.g. `DATAMINER_DEPLOY_KEY`), paste the key as the value for the secret, and then save the secret.

   Once it is saved, your secret will be displayed in the *repository secrets*, and you will be able to use it in a workflow.

> [!NOTE]
> For more information about secrets, refer to the [GitHub Documentation](https://docs.github.com/en/actions/security-guides/encrypted-secrets)

## SONAR_TOKEN: Creating a sonarcloud key

Several provided workflows may require static code analysis through sonarcloud in order to meet quality standards. To perform such analysis access is needed to a sonarcloud project.

Name: SONAR_TOKEN
Value: The value of the secret is an API token that can be created in SonarCloud under the [Security](https://sonarcloud.io/account/security) tab of the account settings.

## DATAMINER_DEPLOY_KEY: Creating a dataminer.services System key

A dataminer.services System key is scoped to the specific DMS for which it was created and can only be used for deployments to that DMS.
It can also be used to upload artifacts to the private catalog of the organization that your DMS belongs to.

Name: DATAMINER_DEPLOY_KEY
Value: For more information on how to create a dataminer.services key, refer to [Managing dataminer.services keys](xref:Managing_DCP_keys).

## Creating a dataminer.services Organization key

A dataminer.services Organization key is scoped to the specific organization for which it was created and can **only be used to perform catalog uploads**.
It can also be used to upload artifacts to the private catalog of the organization that your DMS belongs to.

For more information on how to create a dataminer.services key, refer to [Managing dataminer.services keys](xref:Managing_DCP_keys).