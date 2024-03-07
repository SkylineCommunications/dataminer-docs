---
uid: CICD_Tutorial_Connector
---

# Setting up a GitHub workflow for connectors

In this tutorial, you will learn how to set up basic quality control and automatic deployment of a DataMiner connector to a staging system through a CI/CD pipeline. This can be done with or without the staging system being connected to dataminer.services. This tutorial uses a DataMiner Agent on an internet-accessible virtual machine.

You can find a quick overview of specific CI/CD tooling offered by Skyline Communications in our [documentation](xref:Platform_independent_CICD).

> [!NOTE]
> You can also apply the instructions in this tutorial (with limited syntax changes) to use other CI/CD technology, such as Jenkins, GitLab, Concourse, Azure DevOps, etc.

Expected duration: 20 minutes.

## Prerequisites

- Runtime .NET SDK 8.0. ([download](https://dotnet.microsoft.com/en-us/download/dotnet/8.0))

- A staging DataMiner Agent that is accessible from your pipeline and that uses DataMiner version 10.3.0/10.3.2 or higher

- [Microsoft Visual Studio](https://visualstudio.microsoft.com/downloads/)

- [Git](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git)

- [GitHub account](https://docs.github.com/en/get-started/signing-up-for-github/signing-up-for-a-new-github-account)

- [DataMiner Integration Studio](https://community.dataminer.services/exphub-dis/)

## Overview

- [Step 1: Create your connector](#step-1-create-your-connector)
- [Step 2: Create a GitHub repository](#step-2-create-a-github-repository)
- [Step 3: Create a standard .NET GitHub Action](#step-3-create-a-standard-net-github-action)
- [Step 4: Extend the workflow with DataMiner Validator](#step-4-extend-the-workflow-with-dataminer-validator)
- [Step 5: Extend the workflow with CD, automatic deployment](#step-5-extend-the-workflow-with-cd-automatic-deployment)
- [Step 6: Add your GitHub secrets](#step-6-add-your-github-secrets)
- [Step 7: Enjoy the results](#step-7-enjoy-the-results)

## Step 1: Create your connector

1. Open Visual Studio, and select *create a new project*.

1. Select *DataMiner Connector Solution* from the list of templates.

1. Specify a solution name, e.g. *MyPipelineTest*.

1. Fill in the following information:

    1. Connector name: *MyPipelineTest*

    1. Provider name: *MyFakeCompany*

    1. Vendor name: *MyFakeCompany*

    1. Vendor OID: 1.3.6.1.4.1.8813.2.*00*

    1. Device OID: 0

    1. Integration ID: DMS-DRV-*00*

    1. Element type: *kata*

    1. Type of the first connection: *virtual*

    1. Author: *MyName*

1. Click *Create*.

1. Add a visible parameter.

    1. Type *<param* and press Tab twice.

       This will add a new default visible parameter.

    1. Complete the snippet, filling in the name, description, etc.

    1. Open the Display Editor using the button at the top of the file.

        1. Drag the new parameter to the *General* page.

        1. Click *Apply Changes* in the top-right corner.

## Step 2: Create a GitHub repository

1. At the top of Visual Studio, select *GIT* and then *Create Repository*.

1. Create a new GitHub repository, choosing a name, your account, and yourself as the owner.

1. Go to the newly created GitHub repository on <www.github.com>.

   > [!TIP]
   > A trick in Visual Studio 2022 is to use the GIT Menu and select GitHub/View Pull Requests. This opens the right repository.

## Step 3: Create a standard .NET GitHub Action

1. On your GitHub page, navigate to the *Actions* tab and select the *Continuous integration/.NET starter workflow*.

1. Add the ability to trigger the workflow manually by adding *workflow_dispatch:* to the *on:* keyword in yml:

   ```yml
   on:
     push:
       branches: [ "master" ]
     pull_request:
       branches: [ "master" ]
     workflow_dispatch:
   ```

1. Commit your changes.

1. Navigate to *Actions* and see the first run of your default .NET CI pipeline.

   This will perform:

    1. Compilation

    1. Unit testing

> [!NOTE]
> This can also be created in other CI/CD technology of your choice.

## Step 4: Extend the workflow with DataMiner Validator

1. Navigate to *Actions*.

1. On the left, click your *.NET* workflow

1. At the top, click *dotnet.yml*.

1. In the new window, click the pencil icon to edit the page.

1. For clarity, change the job name *build:* to *CI:*

1. Add new steps under the current steps:

    1. Install the Validators tool by adding a new job.

    1. Run the validator on your connector.

    1. Display the results and optionally perform quality gating activities.

   ```yml
       - name: Install Connector Validator
         run: dotnet tool install -g Skyline.DataMiner.CICD.Tools.Validator

       - name: Run Connector Validator
         run: dataminer-validator validate-protocol-solution --solution-path "${{ github.workspace }}" --output-directory "${{ github.workspace }}" --output-file-name "validateResults" 

       - name: Archive Results
         if: success()
         uses: actions/upload-artifact@v4
         with:
           name: validateResults
           path: ${{ github.workspace }}/validateResults.json

       - name: Quality Gate
         run: |
           json=$(cat "${{ github.workspace }}/validateResults.json")
           critical=$(echo "$json" | jq -r '.CriticalIssueCount')
           major=$(echo "$json" | jq -r '.MajorIssueCount')

           if [ "$critical" != "0" ] || [ "$major" != "0" ]; then
              echo "Error: CriticalIssueCount or MajorIssueCount is not 0"
             exit 1
           fi
   ```

   > [!TIP]
   > For generic parts of a pipeline, like parsing JSON and making the quality gate, using an online LLM-based AI tool can help you save some time. You can for example use a prompt like this:
   >
   > ```
   > Using GitHub Workflows with an Ubuntu runner. I have a JSON file in the workspace with the path ${{ github.workspace }}/validateResults.json. I want two steps. 1 step where we upload that artifact, and a second step that retrieves the CriticalIssueCount and the  MajorIssueCount and throws an error if one of them is higher than 0. I want you to return to me only the two steps. The name of step 2 should be Quality Gate.
   > ```

1. Commit your changes.

1. Navigate to *Actions* and check the run of your enhanced pipeline.

   This will perform:

    1. Compilation

    1. Unit Testing

    1. DataMiner Connector Validator

## Step 5: Extend the workflow with CD, automatic deployment

1. Navigate to *Actions*

1. On the left, click your *.NET* workflow.

1. At the top, click *dotnet.yml*.

1. In the new window, click the pencil icon to edit the page.

1. Add a new job called *CD* running on a Windows image with new steps:

    1. Only run when the CI job is completed.

    1. Retrieve the source code.

    1. Install the Packager and Deployer tools.

    1. Run the packager to create a .dmprotocol.

    1. Deploy the .dmprotocol to an accessible Agent directly.

   > [!IMPORTANT]
   >
   > - Deployment with a local artifact requires running on a Windows OS. For more details, you can take a look at this [GitHub issue](https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.Tools.DataMinerDeploy/issues/10)
   > - Deployment with a local artifact requires DataMiner 10.3.0/10.3.2 or higher.

   ```yml
     CD:

       runs-on: windows-latest
       needs: CI
       steps:
       - uses: actions/checkout@v4
  
       - name: Install Package Creation
         run: dotnet tool install -g Skyline.DataMiner.CICD.Tools.Packager
       - name: Install DataMiner Deploy
         run: dotnet tool install -g Skyline.DataMiner.CICD.Tools.DataMinerDeploy
      
       - name: Create Protocol Package
         run: dataminer-package-create dmprotocol "${{ github.workspace }}" --name  "protocol" --output "${{ github.workspace }}\\_PackageResults"

       - name: Direct Agent Deployment
         run: dataminer-package-deploy from-artifact --path-to-artifact "${{ github.workspace }}\\_PackageResults\\protocol.dmprotocol" --dm-server-location "${{ secrets.SERVER_LOCATION }}" --dm-user "${{ secrets.DATAMINER_USER }}" --dm-password "${{ secrets.DATAMINER_PASSWORD }}"
   ```

1. Commit your changes.

1. Navigate to *Actions* and check the run of your enhanced pipeline.

   This will perform:

    1. Compilation

    1. Unit testing

    1. DataMiner connector validation

    1. Package creation

    1. Direct Agent deployment

## Step 6: Add your GitHub secrets

1. Navigate to *Settings*.

1. On the left, select *Secrets and variables*.

1. Under *Actions*, add a *New repository secret* for the following secrets:

    1. SERVER_LOCATION

    1. DATAMINER_USER

    1. DATAMINER_PASSWORD

## Step 7: Enjoy the results

1. Navigate to *Actions*.

1. Select the *.NET* workflow on the left.

1. Click *Run workflow*.

You should now see your CI and CD jobs complete successfully.

> [!NOTE]
> Taking a screenshot of this successful run and sending that to <thunder@skyline.be> or uploading it through the [Dojo tutorials page](https://community.dataminer.services/learning-courses-tutorials/) will grant you DevOps points.

## Advanced Options: CI

Skyline Communications organization uses more than these actions. For enhanced CI, you can take a look at our [reusable workflow](https://github.com/SkylineCommunications/_ReusableWorkflows/blob/main/.github/workflows/Connector%20Master%20SDK%20Workflow.yml):

1. SonarCloud static analysis to our CI

1. Ability to use our GitHub Organization private NuGet store (when added as external collaborator to the package source repository)

1. Tagging is considered a release cycle, this overrides the dmprotocol version with the tag

1. A regular commit and push is considered a build cycle, this adds a _Bx to the dmprotocol version. With x being the run-number of the pipeline.

1. We upload the dmprotocol as a downloadable artifact in GitHub

## Advanced Options: CD

Skyline Communications organization provides Starter Workflows that run the reusable workflow for CI and then allows optional CD to be defined by the user. You can take a look at our [starter workflow](https://github.com/SkylineCommunications/.github/blob/main/workflow-templates/DataMiner-CICD-Connector.yml)

1. We trigger our CI, reusable workflow as specified above

1. Optionally a user can uncomment the code that deploys the .dmprotocol
