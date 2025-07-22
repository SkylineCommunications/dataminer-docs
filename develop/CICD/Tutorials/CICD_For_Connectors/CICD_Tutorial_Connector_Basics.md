---
uid: CICD_Tutorial_Connector
---

# Setting up basic CI/CD for connector deployment in GitHub

In this tutorial, you will learn how to create a custom pipeline from scratch. This pipeline will establish basic quality control and automate the deployment of a DataMiner connector to a staging system through a CI/CD pipeline. This setup can function with or without the staging system being connected to dataminer.services. The tutorial uses a DataMiner Agent hosted on an internet-accessible virtual machine.

You can also apply the instructions in this tutorial (with limited syntax changes) to use other CI/CD technology, such as Jenkins, GitLab, Concourse, Azure DevOps, etc. You can find a quick overview of specific CI/CD tooling offered by Skyline Communications in our [CI/CD documentation](xref:Platform_independent_CICD).

> [!TIP]
> See also:
>
> - [Kata #22: How to make a connector CI/CD pipeline](https://community.dataminer.services/courses/kata-22/) on DataMiner Dojo ![Video](~/dataminer/images/video_Duo.png)
> - [Registering a new version of a connector in the Catalog using a GitHub Action](xref:Tutorial_Register_Catalog_Version_GitHub_Actions)

Expected duration: 20 minutes.

## Prerequisites

- Runtime .NET SDK 8.0 ([download](https://dotnet.microsoft.com/en-us/download/dotnet/8.0))

- A staging DataMiner Agent that is accessible from your pipeline and that uses DataMiner version 10.3.0/10.3.2 or higher

- [Microsoft Visual Studio 2022](https://visualstudio.microsoft.com/downloads/)

- [Git](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git)

- A [GitHub account](https://docs.github.com/en/get-started/signing-up-for-github/signing-up-for-a-new-github-account)

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

1. Open Visual Studio, and select *Create a new project*.

1. Select *DataMiner Connector Solution* from the list of templates, and click *Next*.

1. Enter a solution name, e.g. *MyPipelineTest*, and click *Next*.

1. Enter the following information:

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

1. In the *protocol.xml* file, go to the `<Params>` section, and add a visible parameter.

   1. Type *<param* and press Tab twice.

      This will add a new default visible parameter.

   1. Complete the snippet, filling in the ID, the name, the description, etc.

   1. At the top of the *protocol.xml* file, click the *Validate* button. You may need to click *Sign in* before the protocol.xml file is validated.

   1. Open the Display Editor by clicking the *Display Editor* button at the top of the *protocol.xml* file.

      1. Drag the new parameter from the *Parameters* pane on the right onto the *General* page in the Pages pane on the left.

      1. In the top-right corner of the Display Editor, click *Apply Changes*.

## Step 2: Create a GitHub repository

1. In the menu bar of Visual Studio, select *GIT > Create GIT Repository*.

1. Create a new GitHub repository.

   Choose a name, specify your GitHub account, and mark yourself as the owner. When you have finished entering all information, click *Create and Push*.

1. Go to the newly created GitHub repository on <https://github.com/>.

   > [!TIP]
   > A trick in Visual Studio 2022 is to open the *GIT* menu and select *GitHub/View Pull Requests*. This will open the correct repository.

## Step 3: Create a standard .NET GitHub Action

1. On your GitHub page, go to the *Actions* tab, and select the *Continuous integration/.NET starter* workflow.

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

1. Go to the *Actions* tab, and see the first run of your default .NET CI pipeline.

   The following will be performed:

   1. Compilation

   1. Unit testing

> [!NOTE]
> This can also be created in another CI/CD technology of your choice.

## Step 4: Extend the workflow with DataMiner Validator

1. Go to the *Actions* tab.

1. On the left, click your *.NET* workflow.

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
   > For generic parts of a pipeline, like parsing JSON and making the quality gate, using an online LLM-based AI tool can help you save some time. For example, you can use a prompt like this:
   >
   > ```txt
   > Using GitHub Workflows with an Ubuntu runner. I have a JSON file in the workspace with the path ${{ github.workspace }}/validateResults.json. I want two steps. 1 step where we upload that artifact, and a second step that retrieves the CriticalIssueCount and the MajorIssueCount and throws an error if one of them is higher than 0. I want you to return to me only the two steps. The name of step 2 should be Quality Gate.
   > ```

1. Commit your changes.

1. Go to the *Actions* tab, and check the run of your enhanced pipeline.

   The following will be performed:

   1. Compilation
   1. Unit Testing
   1. DataMiner Connector Validator

## Step 5: Extend the workflow with CD, automatic deployment

1. Go to the *Actions* tab.

1. On the left, click your *.NET* workflow.

1. At the top, click *dotnet.yml*.

1. In the new window, click the pencil icon to edit the page.

1. Add a new job called *CD* running on a Windows image with new steps:

   1. Only run when the CI job is completed.

   1. Retrieve the source code.

   1. Install the Packager and Deployer tools.

   1. Run the packager to create a *.dmprotocol* package.

   1. Deploy the *.dmprotocol* package directly to an accessible DataMiner Agent.

   > [!IMPORTANT]
   >
   > - Deployment with a local artifact requires running on a Windows OS. For more details, see this [GitHub issue](https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.Tools.DataMinerDeploy/issues/10).
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

1. Go to the *Actions* tab, and check the run of your enhanced pipeline.

   The following will be performed:

   1. Compilation

   1. Unit testing

   1. DataMiner connector validation

   1. Package creation

   1. Direct Agent deployment

## Step 6: Add your GitHub secrets

1. Go to the *Settings* tab.

1. On the left, click *Secrets and variables*, and then click *Actions*.

1. Add the following secrets (by clicking *New repository secret*, entering the name of the secret, and clicking *Add secret*):

   1. SERVER_LOCATION

   1. DATAMINER_USER

   1. DATAMINER_PASSWORD

## Step 7: Enjoy the results

1. Go to the *Actions* tab.

1. On the left, select the *.NET* workflow.

1. Click *Run workflow*.

You should now see your CI and CD jobs complete successfully.

> [!NOTE]
> To be granted DevOps points, take a screenshot of this successful run and either send it to <thunder@skyline.be> or upload it via the [Dojo tutorials page](https://community.dataminer.services/learning-courses-tutorials/).

## What to do next

### Advanced options: CI

The *Skyline Communications* organization uses more than these actions. For enhanced CI, you can take a look at our [reusable workflow](https://github.com/SkylineCommunications/_ReusableWorkflows/blob/main/.github/workflows/Connector%20Master%20SDK%20Workflow.yml).

These are some of the more interesting things you can find in our reusable workflows:

- SonarCloud static analysis to our CI.

- Ability to use our GitHub Organization private NuGet store (when added as external collaborator to the package source repository).

- A development and release cycle workflow:

  - Tagging is considered a release cycle. This overrides the dmprotocol version with the tag.

  - A regular commit and push is considered a build cycle. This adds a *_Bx* suffix to the dmprotocol version (*x* being the run number of the pipeline).

- Upload of a dmprotocol as a downloadable artifact in GitHub.

### Advanced options: CD

The *Skyline Communications* organization provides starter workflows that run the reusable workflow for CI and then allow optional CD to be defined by the user. You can take a look at our [starter workflow](https://github.com/SkylineCommunications/.github/blob/main/workflow-templates/DataMiner-CICD-Connector.yml):

- The CI reusable workflow is triggered as specified above.

- Optionally, you can uncomment the code that deploys the .dmprotocol package.
