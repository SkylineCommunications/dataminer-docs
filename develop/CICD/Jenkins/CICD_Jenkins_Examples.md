---
uid: CICD_Jenkins_Examples
---

# Jenkins CI/CD examples

These are basic pipeline examples for uploading to the Catalog and/or deploying to DMAs connected to dataminer.services.

We recommend combining these with quality control beforehand, such as executing static code analysis and running tests.

> [!TIP]
> For information on creating a new pipeline in Jenkins, see [Jenkins Tutorial](https://www.jenkins.io/doc/pipeline/tour/hello-world/).

## Basic upload for non-connector items

This is a basic pipeline for uploading non-connector items to the Catalog. Eventually, you will also be able to deploy such items to DMAs connected to dataminer.services using this pipeline, but this is not yet supported at the moment.

To upload an item, you will need *DATAMINER_TOKEN* as a secret. This will be the **key for the DataMiner organization** as provided through the [Admin app](xref:About_the_Admin_app).

On a **Ubuntu** runner:

```groovy
pipeline
{
    agent any
    options
    {
        buildDiscarder(logRotator(numToKeepStr: '10', artifactNumToKeepStr: '10'))
        disableConcurrentBuilds()
        timeout(time: 60, unit: 'MINUTES')
    }

    environment {
        DATAMINER_TOKEN = credentials('DATAMINER_TOKEN')  // Use Jenkins credentials
    }

    stages {
        stage('Register to Catalog') {
            when {
                expression {
                    env.GIT_BRANCH == 'main' || env.GIT_BRANCH == 'master'
                }
            }
            steps {
                sh '''
                    dotnet publish \
                        -p:Version="0.0.${BUILD_NUMBER}-prerelease" \
                        -p:VersionComment="This is just a pre-release version." \
                        -p:CatalogPublishKeyName="DATAMINER_TOKEN" \
                        -p:CatalogDefaultDownloadKeyName="DATAMINER_TOKEN"
                '''
            }
        }
    }
}

```

On a **Windows** runner:

```groovy
pipeline
{
    agent any
    options
    {
        buildDiscarder(logRotator(numToKeepStr: '10', artifactNumToKeepStr: '10'))
        disableConcurrentBuilds()
        timeout(time: 60, unit: 'MINUTES')
    }

    environment {
        DATAMINER_TOKEN = credentials('DATAMINER_TOKEN')  // Use Jenkins credentials
    }

    stages {
        stage('Register to Catalog') {
            when {
                expression {
                    env.GIT_BRANCH == 'main' || env.GIT_BRANCH == 'master'
                }
            }
            steps {
                bat '''
                    dotnet publish `
                        -p:Version="0.0.%BUILD_NUMBER%-prerelease" `
                        -p:VersionComment="This is just a pre-release version." `
                        -p:CatalogPublishKeyName="DATAMINER_TOKEN" `
                        -p:CatalogDefaultDownloadKeyName="DATAMINER_TOKEN"
                '''
            }
        }
    }
}

```

## Basic pipeline for connectors

For this pipeline, you will need a dataminer.services **key for the specific DMS** to which you want to deploy the connectors. For more information on how to create a dataminer.services key, refer to [Managing dataminer.services keys](xref:Managing_dataminer_services_keys).

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
                bat "dotnet dataminer-package-create dmprotocol \"${WORKSPACE}\" --name HelloFromJenkins --output \"${WORKSPACE}\""
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
                    uploadOutput = bat(returnStdout: true, script: "@dotnet dataminer-catalog-upload --path-to-artifact \"${WORKSPACE}\\HelloFromJenkins.dmprotocol\" --dm-catalog-token %DATAMINER_CATALOG_TOKEN%")
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
                bat "dotnet dataminer-package-deploy from-volatile --artifact-id \"${uploadOutput}\" --dm-system-token %DATAMINER_CATALOG_TOKEN%"
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
