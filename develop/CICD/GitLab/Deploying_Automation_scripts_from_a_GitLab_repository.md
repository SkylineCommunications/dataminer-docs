---
uid: Deploying_Automation_scripts_from_a_GitLab_repository
---

# Deploying Automation scripts from a GitLab repository

It is possible to deploy an Automation script solution from a GitLab repository by using the Skyline DataMiner Deploy Action in a pipeline.

To do so, you need to [create a dataminer.services key](#creating-a-dataminerservices-key), [add the key as a masked variable in the repository](#adding-the-key-as-a-masked-variable-in-the-repository), and [add the Skyline DataMiner Deploy Action to a pipeline](#adding-the-skyline-dataminer-deploy-action-to-a-pipeline).

> [!IMPORTANT]
> You will only be able to use this feature if your DataMiner System is connected to dataminer.services. See [Connecting your DataMiner System to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

A working example for this can be found [here](https://gitlab.com/ziinecorp/paris-ip-flow-management).

## Creating a dataminer.services key

A dataminer.services key is scoped to the specific DMS for which it was created and will allow for deployments to that DMS only.

For more information on how to create a dataminer.services key, refer to [Managing dataminer.services keys](xref:Managing_DCP_keys).

## Adding the key as a masked variable in the repository

The (primary or secondary) key should be added as a masked variable in the repository so that it is stored securely in GitLab and not stored in source control. Making the variable masked will prevent the value from being logged accidentally in the pipeline logs.

1. Copy the value from the Admin app using the copy button next to the (primary or secondary) key.

1. In your GitLab repository, go to *Settings* > *CI/CD*.

1. Go to the section *Variables* and click expand.

1. Click *Add variable*.

   ![Add variable](~/develop/images/GitLab_add_variable.png)

1. Specify a name for your variable (e.g. `MY_KEY`), paste the key as the value for the variable, select the *Mask variable*, and click *Add variable*. Optionally it is possible to further protect your variable by selecting *Protect variable*.

   ![Create variable](~/develop/images/GitLab_create_variable.png)

   Once it is saved, your variable will be displayed as one of the variables, and you will be able to use it in a workflow.

> [!NOTE]
> For more information about variables, refer to the [GitLab Documentation](https://docs.gitlab.com/ee/ci/variables/)

## Adding the Skyline DataMiner Deploy Action to a pipeline

1. If you do not have a pipeline yet, you can create one by going to *CI/CD* > *Editor* in GitLab and clicking *Configure pipeline*. This will create a basic `.gitlab-ci.yml` file.

   If you already have a pipeline, you can edit it by opening the pipeline editor.

1. To add the deployment action to your pipeline, add the following stages to your .yaml file.

    ```yml
    stages:
        - upload
        - deploy
    upload:
        stage: upload
        image: docker:latest
        services:
            - docker:dind
        script:
            - docker run -e CI_PROJECT_URL -v $(pwd):/mnt ghcr.io/skylinecommunications/skyline-dataminer-deploy-action:<version>
                --stage Upload 
                --api-key $MY_KEY
                --solution-path ./AutomationScript.sln
                --base-path ./mnt
                --package-name Paris-IP-Flow-Management 
                --version 1.0.1
                --timeout 300
        artifacts:
            reports:
            dotenv: SkylineOutput.env
    deploy:
        stage: deploy
        image: docker:latest
        services:
            - docker:dind
        script:
            - docker run -e CI_PROJECT_URL -v $(pwd):/mnt ghcr.io/skylinecommunications/skyline-dataminer-deploy-action:<version>
                --stage Deploy 
                --api-key $MY_KEY
                --artifact-id $ARTIFACT_ID
                --timeout 300
        dependencies:
            - upload
    ```

1. Replace the `<version>` field with the latest version of the action. The latest version together with some additional information about the action can be found on the [GitHub Marketplace](https://github.com/marketplace/actions/skyline-dataminer-deploy-action)

> [!NOTE]
>
> - For more information about CI/CD pipelines, refer to the [GitLab Documentation](https://docs.gitlab.com/ee/ci/)
> - Keep in mind that there are some differences between GitLab and GitHub. In GitLab there is no "v" in front of the version of the deploy action, and there is also a script parameter *-basepath* that is only used in GitLab but not in GitHub. See for example [Paris IP Flow Management](https://gitlab.com/ziinecorp/paris-ip-flow-management) on GitLab.
