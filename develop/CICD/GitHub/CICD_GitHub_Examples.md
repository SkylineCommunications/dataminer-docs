---
uid: CICD_GitHub_Examples
---

# GitHub CI/CD examples

## Basic deployment example

This is a basic pipeline for uploading to the DataMiner Catalog and/or deploying to DMAs connected to dataminer.services. We recommend combining this with quality control beforehand, such as executing static code analysis and running tests.

If you are interested in reusing Skyline's pre-made pipelines, which include quality-of-life features and a robust quality gate, refer to the [From code to product](xref:CICD_Tutorial_GitHub_Code_To_Product) tutorial.

> [!TIP]
> For information on creating a new pipeline in GitHub, see [GitHub Tutorial](https://docs.github.com/en/actions/quickstart).

### GitHub workflow

You will need *DATAMINER_DEPLOY_KEY* as a secret. This will be the key for the DataMiner Agent as provided through the [DataMiner Admin app](xref:CloudAdminApp). For more information on secrets, see [GitHub secrets and tokens](xref:GitHub_Secrets).

On a **Ubuntu** runner:

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

On a **Windows** runner:

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
