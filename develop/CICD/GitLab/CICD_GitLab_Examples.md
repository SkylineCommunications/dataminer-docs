---
uid: CICD_GitLab_Examples
---

# GitLab CI/CD examples

These are basic pipeline examples for uploading to the Catalog and/or deploying to DMAs connected to dataminer.services.

We recommend combining these with quality control beforehand, such as executing static code analysis and running tests.

> [!NOTE]
> For information on creating a new pipeline in GitLab, see [GitLab Tutorial](https://docs.gitlab.com/ee/ci/quick_start/).

## Basic upload for non-connector items

This is a basic pipeline for uploading non-connector items to the Catalog. Eventually, you will also be able to deploy such items to DMAs connected to dataminer.services using this pipeline, but this is not yet supported at the moment.

To upload an item to the Catalog, you will need *DATAMINER_TOKEN* as a secret. This will be the **key for the DataMiner organization** as provided through the [Admin app](xref:About_the_Admin_app).

On a **Ubuntu** runner:

```yml
stages:
  - build
  - publish

variables:
  DATAMINER_TOKEN: ${DATAMINER_TOKEN}  # GitLab environment variable or secrets vault

# Ubuntu Runner Job
basic_upload_ubuntu:
  stage: publish
  tags:
    - ubuntu  # Requires a runner with the "windows" tag
  script:
    - git clone https://github.com/your-repo.git
    - cd your-repo
    - dotnet publish \
        -p:Version="0.0.${CI_PIPELINE_IID}-prerelease" \
        -p:VersionComment="This is just a pre-release version." \
        -p:CatalogPublishKeyName="DATAMINER_TOKEN" \
        -p:CatalogDefaultDownloadKeyName="DATAMINER_TOKEN"
```

On a **Windows** runner:

```yml
stages:
  - build
  - publish

variables:
  DATAMINER_TOKEN: ${DATAMINER_TOKEN}  # GitLab environment variable or secrets vault

# Windows Runner Job
basic_upload_windows:
  stage: publish
  tags:
    - windows  # Requires a runner with the "windows" tag
  script:
    - git clone https://github.com/your-repo.git
    - cd your-repo
    - dotnet publish `
        -p:Version="0.0.${CI_PIPELINE_IID}-prerelease" `
        -p:VersionComment="This is just a pre-release version." `
        -p:CatalogPublishKeyName="DATAMINER_TOKEN" `
        -p:CatalogDefaultDownloadKeyName="DATAMINER_TOKEN"
```

### GitLab workflow for connectors

For this workflow, you will need a dataminer.services **key for the specific DMS** to which you want to deploy the connectors. For more information on how to create a dataminer.services key, refer to [Managing dataminer.services keys](xref:Managing_dataminer_services_keys).

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
    
    - dataminer-package-create dmprotocol $CI_PROJECT_DIR --name $ARTIFACT_NAME --output $CI_PROJECT_DIR
    
    - export UPLOAD_OUTPUT=$(dataminer-catalog-upload --path-to-artifact "$CI_PROJECT_DIR/$ARTIFACT_NAME.dmprotocol" --dm-catalog-token $CI_JOB_TOKEN)
    
    - echo "Upload output: $UPLOAD_OUTPUT"
    
    - dataminer-package-deploy from-volatile --artifact-id "$UPLOAD_OUTPUT" --dm-system-token "$CI_JOB_TOKEN"
```
