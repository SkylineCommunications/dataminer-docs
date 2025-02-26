---
uid: CICD_Concourse_Examples
---

# Concourse CI/CD examples

## Basic deployment example

This is a basic pipeline for uploading to the catalog and/or deployment to DMAs connected to dataminer.services.

We recommend combining this with quality control beforehand, such as executing static code analysis and running tests.

> [!TIP]
> For information on creating a new pipeline in Concourse, see [Concourse Tutorial](https://concourse-ci.org/tutorial-hello-world.html).

### Creating a dataminer.services key

A dataminer.services key is scoped to the specific DMS for which it was created and can only be used for deployments to that DMS.

For more information on how to create a dataminer.services key, refer to [Managing dataminer.services keys](xref:Managing_DCP_keys).

## Basic upload for non-connector items

You will need *DATAMINER_TOKEN* as a secret. This will be the key for the DataMiner Organization as provided through the [DataMiner Admin app](xref:CloudAdminApp).

>[!IMPORTANT]
> Deployment to an agent from the CI/CD is currently not possible, but we're working on it!

On a **Ubuntu** runner:

```yml
resources:
  - name: source-repo
    type: git
    source:
      uri: https://github.com/your-repo.git
      branch: main  # Track either 'main' or 'master'
      private_key: ((git-private-key))  # Use credential manager

jobs:
  - name: basic-upload-ubuntu
    public: true
    plan:
      - get: source-repo
        trigger: true  # Trigger job on every push

      - task: register-to-catalog-ubuntu
        config:
          platform: linux
          image_resource:
            type: docker-image
            source:
              repository: mcr.microsoft.com/dotnet/sdk  # Use .NET Core image
              tag: 6.0  # Adjust as needed
          inputs:
            - name: source-repo
          params:
            DATAMINER_TOKEN: ((DATAMINER_TOKEN))
          run:
            path: /bin/bash
            args:
              - -c
              - |
                cd source-repo
                dotnet publish \
                  -p:Version="0.0.$BUILD_ID-prerelease" \
                  -p:VersionComment="This is just a pre-release version." \
                  -p:CatalogPublishKeyName="$DATAMINER_TOKEN"
```

On a **Windows** runner:

```yml
resources:
  - name: source-repo
    type: git
    source:
      uri: https://github.com/your-repo.git
      branch: main  # Track either 'main' or 'master'
      private_key: ((git-private-key))  # Use credential manager

jobs:
  - name: basic-upload-windows
    public: true
    plan:
      - get: source-repo
        trigger: true  # Trigger job on every push
      
      - task: register-to-catalog-windows
        privileged: true
        config:
          platform: windows  # Requires a Windows worker
          inputs:
            - name: source-repo
          params:
            DATAMINER_TOKEN: ((DATAMINER_TOKEN))
          run:
            path: powershell
            args:
              - -Command
              - >
                cd source-repo;
                dotnet publish `
                  -p:Version="0.0.$BUILD_ID-prerelease" `
                  -p:VersionComment="This is just a pre-release version." `
                  -p:CatalogPublishKeyName="$env:DATAMINER_TOKEN";
```

### Concourse pipeline For Connector

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
          dataminer-package-create dmprotocol example-deployment-repo --name HelloFromConcourse --output example-deployment-repo
          id=$(dataminer-catalog-upload --path-to-artifact "example-deployment-repo/HelloFromConcourse.dmprotocol" --dm-catalog-token 12345)
          dataminer-package-deploy from-volatile --artifact-id "$id" --dm-system-token 12345
```
