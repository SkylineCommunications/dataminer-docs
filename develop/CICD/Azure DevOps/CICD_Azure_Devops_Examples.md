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

### Azure DevOps pipeline

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

- script: dataminer-package-create dmapp $(Build.SourcesDirectory) --name HelloFromAzure --output $(Build.SourcesDirectory) --type automation
  displayName: 'Create Package'

- script: |
    uploadOutput=$(dataminer-catalog-upload --path-to-artifact "$(Build.SourcesDirectory)/HelloFromAzure.dmapp" --dm-catalog-token $(DATAMINER_DEPLOY_KEY))
    echo "##vso[task.setvariable variable=uploadOutput]$uploadOutput"
  displayName: 'Upload Package'

- script: dataminer-package-deploy from-catalog --artifact-id "$(uploadOutput)" --dm-catalog-token $(DATAMINER_DEPLOY_KEY)
  displayName: 'Deploy Package'
```
