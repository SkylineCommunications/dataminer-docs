---
uid: CICD_Concourse_Examples
---

# Concourse CI/CD Examples

## Basic Deployment Example

This is a basic pipeline for uploading to the catalog and/or deployment to DMAs connected to dataminer.services.

We recommend combining this with quality control beforehand, such as executing static code analysis and running tests.

### Creating a dataminer.services key

A dataminer.services key is scoped to the specific DMS for which it was created and will allow for deployments to that DMS only.

For more information on how to create a dataminer.services key, refer to [Managing dataminer.services keys](xref:Managing_DCP_keys).

### Concourse Pipeline

```yml

resources:
- name: example-deployment-repo
  type: git
  icon: github
  source:
    uri: https://github.com/janstaelensskyline/AS-JANS-ExampleDeployment

jobs:
- name: deploy-dataminer-job
  plan:
  - get: example-deployment-repo
  - task: deploy-dataminer-task
    config:
      platform: linux
      image_resource:
        type: registry-image
        source:
          repository: mcr.microsoft.com/dotnet/sdk
          tag: "6.0"
      inputs:
      - name: example-deployment-repo
      run:
        path: /bin/sh
        args:
        - -cx
        - |
          export PATH="/root/.dotnet/tools:$PATH"
          dotnet tool install -g Skyline.DataMiner.CICD.Tools.Packager
          dotnet tool install -g Skyline.DataMiner.CICD.Tools.CatalogUpload
          dotnet tool install -g Skyline.DataMiner.CICD.Tools.DataMinerDeploy
          dataminer-package-create dmapp example-deployment-repo --name HelloFromConcourse --output example-deployment-repo --type automation
          id=$(dataminer-catalog-upload --path-to-artifact "example-deployment-repo/HelloFromConcourse.dmapp" --dm-catalog-token 12345)
          dataminer-package-deploy from-catalog --artifact-id "$id" --dm-catalog-token 12345

```
