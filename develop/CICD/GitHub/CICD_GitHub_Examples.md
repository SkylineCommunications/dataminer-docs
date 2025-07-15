---
uid: CICD_GitHub_Examples
---

# GitHub CI/CD examples

These are basic pipeline examples for uploading to the Catalog and/or deploying to DMAs connected to dataminer.services. We recommend combining these with quality control beforehand, such as executing static code analysis and running tests.

If you are interested in reusing Skyline's pre-made pipelines, which include quality-of-life features and a robust quality gate, refer to:

- [CI/CD for connectors tutorial](xref:CICD_Tutorial_For_Connectors_VisualStudio_And_GitHub).
- [CI/CD for other items](xref:github_reusable_workflows_dataminer_app_packages_master_workflow).

> [!TIP]
> For information on creating a new pipeline in GitHub, see [GitHub Tutorial](https://docs.github.com/en/actions/quickstart).

## Basic upload for non-connector items

To upload an item to the Catalog, you will need *DATAMINER_TOKEN* as a secret. This will be the **key for the DataMiner organization** as provided through the [Admin app](xref:About_the_Admin_app). For more information on secrets, see [GitHub secrets and tokens](xref:GitHub_Secrets).

For now, for non-connector items, **only uploading to the Catalog** is supported. Deploying directly to a DMA from CI/CD is not supported yet.

On a **Ubuntu** runner:

```yml
name: BasicUploadUbuntu

on:
  push:
    branches: [ "master", "main" ]

jobs:

  deployment:
    runs-on: ubuntu-latest 
    
    steps:
    - name: Checkout
      uses: actions/checkout@v4
      with:
        fetch-depth: 0

    - name: Register To Catalog
      env:
        DATAMINER_TOKEN: ${{ secrets.DATAMINER_TOKEN }}
      run: |
        dotnet publish \
          -p:Version="0.0.${{ github.run_number }}-prerelease" \
          -p:VersionComment="This is just a pre-release version." \
          -p:CatalogPublishKeyName="DATAMINER_TOKEN" \
          -p:CatalogDefaultDownloadKeyName="DATAMINER_TOKEN"
```

On a **Windows** runner:

```yml
name: BasicUploadWindows

on:
  push:
    branches: [ "master", "main" ]

jobs:

  deployment:
    runs-on: ubuntu-latest 
    
    steps:
    - name: Checkout
      uses: actions/checkout@v4
      with:
        fetch-depth: 0

    - name: Register To Catalog
      env:
        DATAMINER_TOKEN: ${{ secrets.DATAMINER_TOKEN }}
      run: |
        dotnet publish `
          -p:Version="0.0.${{ github.run_number }}-prerelease" `
          -p:VersionComment="This is just a pre-release version." `
          -p:CatalogPublishKeyName="DATAMINER_TOKEN" `
          -p:CatalogDefaultDownloadKeyName="DATAMINER_TOKEN" `
```

## Basic deployment for connectors

To deploy a connector to a DMA, you will need *DATAMINER_DEPLOY_KEY* as a secret. This will be the **key for the DataMiner System** as provided through the [Admin app](xref:About_the_Admin_app). For more information on secrets, see [GitHub secrets and tokens](xref:GitHub_Secrets).

On a **Ubuntu** runner:

```yml
name: BasicDeployUbuntu

on:
  push:
    branches: [ "master", "main" ]
  pull_request:
    branches: [ "master", "main" ]

jobs:

  deployment:
    runs-on: ubuntu-latest 
    
    steps:
    - name: Checkout
      uses: actions/checkout@v4
      with:
        fetch-depth: 0

    - name: InstallPackageCreation
      run: dotnet tool install -g Skyline.DataMiner.CICD.Tools.Packager
    - name: Install Catalog Upload
      run: dotnet tool install -g Skyline.DataMiner.CICD.Tools.CatalogUpload
    - name: Install DataMiner Deploy
      run: dotnet tool install -g Skyline.DataMiner.CICD.Tools.DataMinerDeploy

    - name: Create DMPROTOCOL
      run: dataminer-package-create dmprotocol ${{ github.workspace }} --name HelloFromGithubUbuntu --output ${{ github.workspace }}

    - name: Upload DMPROTOCOL
      id: UploadDMPROTOCOL
      run: |
        echo "uploadOutput=$(dataminer-catalog-upload --path-to-artifact "${{ github.workspace }}/HelloFromGithubUbuntu.dmprotocol" --dm-catalog-token ${{ secrets.DATAMINER_DEPLOY_KEY }})" >> $GITHUB_OUTPUT
      shell: bash
      
    - name: Check Output
      run: |
        echo "${{ steps.UploadDMPROTOCOL.outputs.uploadOutput }}"
        
    - name: Deploy DMAPP
      run: dataminer-package-deploy from-volatile --artifact-id "${{ steps.UploadDMPROTOCOL.outputs.uploadOutput }}" --dm-system-token "${{ secrets.DATAMINER_DEPLOY_KEY }}"
      shell: bash
```

On a **Windows** runner:

```yml
name: BasicDeploy

on:
  push:
    branches: [ "master", "main" ]
  pull_request:
    branches: [ "master", "main" ]

jobs:

  deployment:
    runs-on: windows-latest 
    
    steps:
    - name: Checkout
      uses: actions/checkout@v4
      with:
        fetch-depth: 0
        
    - name: InstallPackageCreation
      run: dotnet tool install -g Skyline.DataMiner.CICD.Tools.Packager
    - name: Install Catalog Upload
      run: dotnet tool install -g Skyline.DataMiner.CICD.Tools.CatalogUpload
    - name: Install DataMiner Deploy
      run: dotnet tool install -g Skyline.DataMiner.CICD.Tools.DataMinerDeploy

    - name: Create DMPROTOCOL
      run: dataminer-package-create dmprotocol ${{ github.workspace }} --name HelloFromGithubUbuntu --output ${{ github.workspace }}

    - name: Upload DMPROTOCOL
      id: UploadDMPROTOCOL
      run: |
        echo "uploadOutput=$(dataminer-catalog-upload --path-to-artifact "${{ github.workspace }}/HelloFromGithubUbuntu.dmprotocol" --dm-catalog-token ${{ secrets.DATAMINER_DEPLOY_KEY }})" >> $GITHUB_OUTPUT
      shell: bash
      
    - name: Check Output
      run: |
        echo "${{ steps.UploadDMPROTOCOL.outputs.uploadOutput }}"
        
    - name: Deploy DMAPP
      run: dataminer-package-deploy from-volatile --artifact-id "${{ steps.UploadDMPROTOCOL.outputs.uploadOutput }}" --dm-system-token "${{ secrets.DATAMINER_DEPLOY_KEY }}"
      shell: bash
```
