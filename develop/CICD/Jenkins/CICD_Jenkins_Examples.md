---
uid: CICD_Jenkins_Examples
---

# Jenkins CI/CD examples

## Basic deployment example

This is a basic pipeline for uploading to the catalog and/or deployment to DMAs connected to dataminer.services.

We recommend combining this with quality control beforehand, such as executing static code analysis and running tests.

> [!TIP]
> For information on creating a new pipeline in Jenkins, see [Jenkins Tutorial](https://www.jenkins.io/doc/pipeline/tour/hello-world/).

### Creating a dataminer.services key

A dataminer.services key is scoped to the specific DMS for which it was created and can only be used for deployments to that DMS.

For more information on how to create a dataminer.services key, refer to [Managing dataminer.services keys](xref:Managing_DCP_keys).

### Jenkins pipeline

In the example below, the Jenkins server is on a fixed Windows machine, and local caching is used to avoid re-downloading the tools:

```groovy
class Globals
{
  static String uploadOutput
}

pipeline
{
    agent any
    options
    {
        buildDiscarder(logRotator(numToKeepStr: '10', artifactNumToKeepStr: '10'))
        disableConcurrentBuilds()
        timeout(time: 120, unit: 'MINUTES')
    }


    environment
    {
        dotnettoolsfolder = 'C:\\dotnet-tools\\'
    }

    stages
    {
        stage('Install Package Creation')
        {
            steps
            {
                bat "dotnet tool update \"Skyline.DataMiner.CICD.Tools.Packager\" --local"
            }
        }

        stage('Install Catalog Upload')
        {
            steps
            {
                bat "dotnet tool update \"Skyline.DataMiner.CICD.Tools.CatalogUpload\" --local"
            }
        }

        stage('Install DataMiner Deploy')
        {
            steps
            {
                bat "dotnet tool update \"Skyline.DataMiner.CICD.Tools.DataMinerDeploy\" --local"
            }
        }

        stage('Create DMAPP')
        {
            steps
            {
                bat "dotnet dataminer-package-create dmapp \"${WORKSPACE}\" --name HelloFromJenkins --output \"${WORKSPACE}\" --type automation"
            }
        }

       stage('Upload DMAPP')
       {
            steps
            {
              withCredentials([string(credentialsId: 'DeployExampleToken', variable: 'DATAMINER_CATALOG_TOKEN')])
              {
                script
                {
                    uploadOutput = bat(returnStdout: true, script: "@dotnet dataminer-catalog-upload --path-to-artifact \"${WORKSPACE}\\HelloFromJenkins.dmapp\"")
                    uploadOutput = uploadOutput.trim()
                }
              }
            }
       } 

       stage("Deploy DMAPP")
       {
            steps
            {
              withCredentials([string(credentialsId: 'DeployExampleToken', variable: 'DATAMINER_CATALOG_TOKEN')])
              {
                bat "dotnet dataminer-package-deploy from-catalog --artifact-id \"${uploadOutput}\""
              }
            }
       }
    }
    post
    {
        cleanup
        {
            cleanWs()
        }
    }
}
```
