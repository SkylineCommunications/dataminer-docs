---
uid: CICD_Azure_DevOps_Examples
---

# Azure DevOps CI/CD examples

## Basic deployment example

This is a basic pipeline for uploading to the catalog and/or deployment to DMAs connected to dataminer.services.

We recommend combining this with quality control beforehand, such as executing static code analysis and running tests.

> [!TIP]
> For information on creating a new pipeline in Azure DevOps, see [Azure Tutorial](https://learn.microsoft.com/en-us/azure/devops/pipelines/create-first-pipeline?view=azure-devops).

### Creating a dataminer.services key

A dataminer.services key is scoped to the specific DMS for which it was created and can only be used for deployments to that DMS.

For more information on how to create a dataminer.services key, refer to [Managing dataminer.services keys](xref:Managing_DCP_keys).

## Basic upload for non-connector items

You will need *DATAMINER_TOKEN* as a secret. This will be the key for the DataMiner Organization as provided through the [DataMiner Admin app](xref:CloudAdminApp).

>[!IMPORTANT]
> Deployment to an agent from the CI/CD is currently not possible, but we're working on it!

On a **Ubuntu** runner:

```yml
trigger:
  branches:
    include:
      - master
      - main

variables:
  DATAMINER_TOKEN: $(DATAMINER_TOKEN)  # Secret from Azure DevOps Library or Pipeline variables

jobs:
 - job: UbuntuBuildAndUpload
    displayName: 'Ubuntu: Build and Register to Catalog'
    pool:
      vmImage: 'ubuntu-latest'
    steps:
      - checkout: self

      - script: |
          dotnet publish \
            -p:Version="0.0.$(Build.BuildId)-prerelease" \
            -p:VersionComment="This is just a pre-release version." \
            -p:CatalogPublishKeyName="$(DATAMINER_TOKEN)"
        displayName: 'Publish and Register to Catalog'
        env:
          DATAMINER_TOKEN: $(DATAMINER_TOKEN)

```

On a **Windows** runner:

```yml
trigger:
  branches:
    include:
      - master
      - main

variables:
  DATAMINER_TOKEN: $(DATAMINER_TOKEN)  # Secret from Azure DevOps Library or Pipeline variables

jobs:
  - job: WindowsBuildAndUpload
    displayName: 'Windows: Build and Register to Catalog'
    pool:
      vmImage: 'windows-latest'
    steps:
      - checkout: self

      - script: |
          dotnet publish `
            -p:Version="0.0.$(Build.BuildId)-prerelease" `
            -p:VersionComment="This is just a pre-release version." `
            -p:CatalogPublishKeyName="$(DATAMINER_TOKEN)"
        displayName: 'Publish and Register to Catalog'
        env:
          DATAMINER_TOKEN: $(DATAMINER_TOKEN)
```

### Azure DevOps pipeline for Connectors

You need a secret variable DATAMINER_DEPLOY_KEY.

You need a variable that is allowed to change during the run: uploadOutput

```yml
trigger:
- master

pool:
  vmImage: ubuntu-latest

steps:
- checkout: self

- script: dotnet tool install -g Skyline.DataMiner.CICD.Tools.Packager
  displayName: 'Install Packager'

- script: dotnet tool install -g Skyline.DataMiner.CICD.Tools.CatalogUpload
  displayName: 'Install Catalog Upload'

- script: dotnet tool install -g Skyline.DataMiner.CICD.Tools.DataMinerDeploy
  displayName: 'Install Catalog Deploy'

- script: dataminer-package-create dmprotocol $(Build.SourcesDirectory) --name HelloFromAzure --output $(Build.SourcesDirectory)
  displayName: 'Create Package'

- script: |
    uploadOutput=$(dataminer-catalog-upload --path-to-artifact "$(Build.SourcesDirectory)/HelloFromAzure.dmprotocol" --dm-catalog-token $(DATAMINER_DEPLOY_KEY))
    echo "##vso[task.setvariable variable=uploadOutput]$uploadOutput"
  displayName: 'Upload Package'

- script: dataminer-package-deploy from-volatile --artifact-id "$(uploadOutput)" --dm-system-token $(DATAMINER_DEPLOY_KEY)
  displayName: 'Deploy Package'
```
