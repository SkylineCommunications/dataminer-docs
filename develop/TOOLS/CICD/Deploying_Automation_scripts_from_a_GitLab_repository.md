---
uid: Deploying_Automation_scripts_from_a_GitLab_repository
---

# Deploying Automation scripts from a GitLab repository

It is possible to deploy an Automation script solution from a GitLab repository by using the Skyline DataMiner Deploy Action in a pipeline.

To do so, you need to [create a DCP key](#creating-a-dcp-key), [add the key as a masked variable in the repository](#adding-the-key-as-a-masked-variable-in-the-repository), and [add the Skyline DataMiner Deploy Action to a pipeline](#adding-the-skyline-dataminer-deploy-action-to-a-pipeline).

> [!IMPORTANT]
> Your DataMiner system has to be cloud-connected in order to use this feature.

A working example for this can be found [here](https://gitlab.com/ziinecorp/paris-ip-flow-management).

## Creating a DCP key

A DCP key is scoped to the specific DMS for which it was created and will allow for deployments to that DMS only.

For more information on how to create a DCP key, refer to [Managing DCP keys](xref:Managing_DCP_keys).

## Adding the key as a masked variable in the repository

The key(this can be the primary or secondary) should be added as a masked variable in the repository so that it is stored securely in GitLab and not stored in source control. Making the variable masked will prevent the value to be logged accidentally in the pipeline logs.

1. Copy the value from the DCP Admin app using the copy button next to the key.
1. In your GitLab repository, go to *Settings* > *CI/CD*.
1. Go to the section *Variables* and click on expand.
1. Click on *Add variable*.

    ![Add variable](~/develop/images/GitLab_add_variable.png)

1. Specify a name for your variable (e.g. `DCP_KEY`), paste the key as the value for the variable, select the *Mask variable*, and click *Add variable*. Optionally it is possible to further protect your variable by selecting *Protect variable*.

    ![Create variable](~/develop/images/GitLab_create_variable.png)

   Once it is saved, your variable will be displayed as one of the variables, and you will be able to use it in a workflow.

> [!NOTE]
> For more information about variables, refer to the [GitLab Documentation](https://docs.gitlab.com/ee/ci/variables/)

## Adding the Skyline DataMiner Deploy Action to a pipeline

1. If you do not have a pipeline yet, you can create one by going to the *CI/CD* > *Editor* in GitLab and clicking *Configure pipeline*. This will create a basic `.gitlab-ci.yml` file.

   If you already have a pipeline, you can edit it by opening the pipeline editor.

1. To add the deployment action to your pipeline add the following stages to your .yaml file.

    ```yaml
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
                --api-key $DCP_KEY
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
                --api-key $DCP_KEY
                --artifact-id $ARTIFACT_ID
                --timeout 300
        dependencies:
            - upload
    ```

1. Replace the `<version>` field with the latest version of the action. The latest version together with some additional information about the action can be found on the [GitHub Marketplace](https://github.com/marketplace/actions/skyline-dataminer-deploy-action)

> [!NOTE]
> For more information about CI/CD pipelines, refer to the [GitLab Documentation](https://docs.gitlab.com/ee/ci/)

> [!IMPORTANT]
> There are some differences between GitLab and GitHub regarding the versioning of the deploy action. On GitLab this is without a 'v' in front of the version. See also the ZiineCorp example on GitLab.
> Also on GitLab there is a script parameter *-basepath* that you don't have on GitHub.
