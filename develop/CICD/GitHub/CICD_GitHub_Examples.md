---
uid: CICD_GitHub_Examples
---

# GitHub CI/CD Examples

## Basic Deployment Example

A basic pipeline for upload to catalog and/or deployment to cloud-connected agents.
It's recommended to combine this with quality control beforehand such as executing static code analysis and running tests.

## Creating a dataminer.services key

A dataminer.services key is scoped to the specific DMS for which it was created and will allow for deployments to that DMS only.

For more information on how to create a dataminer.services key, refer to [Managing dataminer.services keys](xref:Managing_DCP_keys).

### GitHub Workflow

You will need DATAMINER_DEPLOY_KEY as a secret. This will be the key for your cloud connected agent as provided through https://admin.dataminer.services


On an ubuntu runner:

```yml

name: BasicDeployUbuntu

on:
  push:
    branches: [ "master" ]
  pull_request:
    branches: [ "master" ]

jobs:

  deployment:
    runs-on: ubuntu-latest 
    
    steps:
    - name: Checkout
      uses: actions/checkout@v3
      with:
        fetch-depth: 0

    - name: InstallPackageCreation
      run: dotnet tool install -g Skyline.DataMiner.CICD.Tools.Packager
    - name: Install Catalog Upload
      run: dotnet tool install -g Skyline.DataMiner.CICD.Tools.CatalogUpload
    - name: Install DataMiner Deploy
      run: dotnet tool install -g Skyline.DataMiner.CICD.Tools.DataMinerDeploy

    - name: Create DMAPP
      run: dataminer-package-create dmapp ${{ github.workspace }} --name HelloFromGithubUbuntu --output ${{ github.workspace }} --type automation

    - name: Upload DMAPP
      id: UploadDMAPP
      run: |
        echo "uploadOutput=$(dataminer-catalog-upload --path-to-artifact "${{ github.workspace }}/HelloFromGithubUbuntu.dmapp" --dm-catalog-token ${{ secrets.DATAMINER_DEPLOY_KEY }})" >> $GITHUB_OUTPUT
      shell: bash
      
    - name: Check Output
      run: |
        echo "${{ steps.UploadDMAPP.outputs.uploadOutput }}"
        
    - name: Deploy DMAPP
      run: dataminer-package-deploy from-catalog --artifact-id "${{ steps.UploadDMAPP.outputs.uploadOutput }}" --dm-catalog-token "${{ secrets.DATAMINER_DEPLOY_KEY }}"
      shell: bash

```

On a windows runner: 

```yml

name: BasicDeploy

on:
  push:
    branches: [ "master" ]
  pull_request:
    branches: [ "master" ]

jobs:

  deployment:
    runs-on: windows-latest 
    
    steps:
    - name: Checkout
      uses: actions/checkout@v3
      with:
        fetch-depth: 0
        
    - name: InstallPackageCreation
      run: dotnet tool install -g Skyline.DataMiner.CICD.Tools.Packager
    - name: Install Catalog Upload
      run: dotnet tool install -g Skyline.DataMiner.CICD.Tools.CatalogUpload
    - name: Install DataMiner Deploy
      run: dotnet tool install -g Skyline.DataMiner.CICD.Tools.DataMinerDeploy

    - name: Create DMAPP
      run: dataminer-package-create dmapp ${{ github.workspace }} --name HelloFromGithubWindows --output ${{ github.workspace }} --type automation

    - name: Upload DMAPP
      id: UploadDMAPP
      run: |
        echo "uploadOutput=$(dataminer-catalog-upload --path-to-artifact "${{ github.workspace }}\HelloFromGithubWindows.dmapp" --dm-catalog-token ${{ secrets.DATAMINER_DEPLOY_KEY }})" >> $GITHUB_OUTPUT
      shell: bash
        
    - name: Deploy DMAPP
      run: dataminer-package-deploy from-catalog --artifact-id "${{ steps.UploadDMAPP.outputs.uploadOutput }}" --dm-catalog-token "${{ secrets.DATAMINER_DEPLOY_KEY }}"
      shell: bash

```