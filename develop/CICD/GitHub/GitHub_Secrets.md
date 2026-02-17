---
uid: GitHub_Secrets
---

# GitHub secrets and tokens

Several tools, starter workflows, and reusable workflows provided by Skyline will require secrets and tokens to run correctly. Below, you can find information on where to find the tokens you may need and how to add them as a secret in your repository.

## Public vs. private repositories

If you use a **paid GitHub License** or a **public** repository, it is possible that some secrets and tokens have been set as organization secrets, in which case you can use those.

Otherwise, you will have to "override" the organization secrets by adding repository secrets.

## Adding a key as a secret in the repository

A key should be added as a secret in the repository, so that it is stored securely in GitHub and not in source control.

1. Copy the value from the required key.

1. In your GitHub repository, go to *Settings*.

1. In the pane on the left, under *Security*, select *Secrets* > *Actions*.

   ![Actions page](~/develop/images/GitHub_settings_secrets.png)

1. In the top-right corner, click *New repository secret*.

1. Specify a name for your secret (e.g., `DATAMINER_TOKEN`), paste the key as the value for the secret, and then save the secret.

   Once it is saved, your secret will be displayed in the *repository secrets*, and you will be able to use it in a workflow.

> [!NOTE]
> For more information about secrets, refer to the [GitHub Documentation](https://docs.github.com/en/actions/security-guides/encrypted-secrets).

## SONAR_TOKEN SonarCloud key

Several provided workflows may require static code analysis through SonarCloud in order to meet quality standards. To perform such analysis, access is needed to a SonarCloud project.

- Name: SONAR_TOKEN
- Value: The value of the secret is an API token that can be created in SonarCloud under the [Security](https://sonarcloud.io/account/security) tab of the account settings.

## dataminer.services keys

In the [Admin app](xref:About_the_Admin_app), two different types of keys can be created: system keys and organization keys. It is important that you use the correct key for specific actions.

- A dataminer.services **system key** is scoped to the specific DMS for which it was created and can only be used for volatile uploads and deployments to that DMS. All other uploads and deployments need to use the organization key.

  - Name: DATAMINER_DEPLOY_KEY
  - Value: See [Managing dataminer.services keys](xref:Managing_dataminer_services_keys).

- A dataminer.services **organization key** is scoped to the specific organization for which it was created and can be used to upload to and deploy from the Catalog. This includes uploading private artifacts to the Catalog that will only be accessible for the organization that your DMS belongs to. To upload and deploy items, you will need this key.

  - Name: DATAMINER_TOKEN
  - Value: See [Managing dataminer.services keys](xref:Managing_dataminer_services_keys).
