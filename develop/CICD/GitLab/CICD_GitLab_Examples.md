---
uid: CICD_GitLab_Examples
---

# GitLab CI/CD examples

## Basic deployment example

This is a basic pipeline for uploading to the catalog and/or deployment to DMAs connected to dataminer.services.

We recommend combining this with quality control beforehand, such as executing static code analysis and running tests.

> [!NOTE]
> For information on creating a new pipeline in GitLab, see [GitLab Tutorial](https://docs.gitlab.com/ee/ci/quick_start/).

### Creating a dataminer.services key

A dataminer.services key is scoped to the specific DMS for which it was created and can only be used for deployments to that DMS.

For more information on how to create a dataminer.services key, refer to [Managing dataminer.services keys](xref:Managing_DCP_keys).

### GitLab workflow

```yml
stages:
  - deploy

variables:
  ARTIFACT_NAME: "HelloFromGitLabUbuntu"

deploy:
  stage: deploy
  only:
    - master
  script:
    - apt-get update -qy
    - apt-get install -y apt-transport-https ca-certificates curl software-properties-common
    - curl -fsSL https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor | tee /usr/share/keyrings/packages.microsoft.gpg > /dev/null
    - echo "deb [signed-by=/usr/share/keyrings/packages.microsoft.gpg] https://packages.microsoft.com/debian/$(lsb_release -rs)/prod $(lsb_release -cs) main" | tee /etc/apt/sources.list.d/microsoft.list > /dev/null
    - apt-get update -qy
    - apt-get install -y dotnet-sdk
    - dotnet tool install -g Skyline.DataMiner.CICD.Tools.Packager
    - dotnet tool install -g Skyline.DataMiner.CICD.Tools.CatalogUpload
    - dotnet tool install -g Skyline.DataMiner.CICD.Tools.DataMinerDeploy
    - dotnet restore
    - dotnet build
    
    - dataminer-package-create dmapp $CI_PROJECT_DIR --name $ARTIFACT_NAME --output $CI_PROJECT_DIR --type automation
    
    - export UPLOAD_OUTPUT=$(dataminer-catalog-upload --path-to-artifact "$CI_PROJECT_DIR/$ARTIFACT_NAME.dmapp" --dm-catalog-token $CI_JOB_TOKEN)
    
    - echo "Upload output: $UPLOAD_OUTPUT"
    
    - dataminer-package-deploy from-catalog --artifact-id "$UPLOAD_OUTPUT" --dm-catalog-token "$CI_JOB_TOKEN"
```
