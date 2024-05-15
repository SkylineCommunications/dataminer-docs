---
uid: publish_to_catalog
---

# Publishing artifacts to the DataMiner Catalog

The [DataMiner Catalog](https://catalog.dataminer.services/) allows users to quickly look up, download, and deploy various DataMiner-related artifacts.

This platform is constantly getting improved. At present, several workarounds are still needed to get certain artifacts to show up in the Catalog. Below, you can find more information about how to publish specific kinds of artifacts.

> [!NOTE]
> Publishing items to the Catalog is currently only possible for members of Skyline Communications. However, we are planning to add a "private" section of the Catalog where you will be able to add items that you publish yourself as part of the larger DevOps community.

> [!TIP]
> See also: [DataMiner Catalog](xref:About_the_Catalog_module)

## Publishing connectors

Connectors (also known as protocols or drivers) are XML files and assemblies that are packaged into .dmprotocol files. The source code of these is currently only available through the internal SLC SE RepoManager. They use internal Jenkins pipelines for QA and automatic publishing to the catalog.

1. Make sure the following prerequisites are available:

   - [Visual Studio](https://visualstudio.microsoft.com/downloads/)

   - [Git](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git)

   - [DIS](xref:Installing_and_configuring_DataMiner_Integration_Studio)

   - [SLC SE RepoManager](https://tools.skyline.be/installers/SERepoManager/SERepoInstaller.msi)

1. Open the source code:

   1. Find the connector in the SLC SE RepoManager under the tab *Protocols*.

   1. Open the connector solution using Visual Studio.

1. Tag the commit:

   1. In the lower right corner, select and check out the correct branch. This must be a branch ending in *".X"*, e.g. 1.0.0.X.

   1. Right-click the branch and select *View History*.

   1. Right-click the commit you want to release and select *New Tag*.

   1. Fill in a tag name matching the branch. Connectors use four numbers for versioning, e.g. `1.0.0.3`.

   1. Fill in a comment.

   1. In the top bar in Visual Studio, select *Git* > *Commit or Stash*.

      This opens a new window.

   1. In the new window, select the ellipsis "..." and choose *Push all Tags to Origin*.

This will tag the commit, which will trigger Jenkins to perform a release cycle.

You can monitor the release pipeline:

- If it goes yellow or green, the connector has been successfully released, and users will be able to find it in the Catalog.

- If it goes red, the release failed. You will need to either re-run the pipeline or remove the tag, fix the reported problems, and tag the commit again to trigger a new release.

## Publishing DataMiner install packages

DataMiner install packages, i.e. .dmapp files, can contain any other artifacts, including other install packages and companion files. The source code of these packages is currently only available through the internal SLC SE RepoManager. They use internal Jenkins pipelines for QA and automatic publishing to the catalog.

1. Make sure the following prerequisites are available:

   - [Visual Studio](https://visualstudio.microsoft.com/downloads/)

   - [Git](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git)

   - [DIS](xref:Installing_and_configuring_DataMiner_Integration_Studio)

   - [SLC SE RepoManager](https://tools.skyline.be/installers/SERepoManager/SERepoInstaller.msi)

1. Open the source code:

   1. Find or create a new install package in the SLC SE RepoManager under the tab *Packages*.

   1. Open the solution using Visual Studio.

1. Include the required artifacts:

   1. Open *manifest.xml*.

      > [!TIP]
      > If you open this in Visual Studio, you will get Intellisense.

   1. You can now add XML tags to add artifacts like connectors, Automation scripts, etc.

   > [!TIP]
   > For more information, refer to [Creating a repository for an install package](xref:Creating_a_repository_for_an_install_package).

1. Tag the commit:

   1. In the lower right corner, select and check out the correct branch. This must be a branch ending in *".X"*, e.g. 1.0.0.X.

   1. Right-click the branch and select *View History*.

   1. Right-click the commit you want to release and select *New Tag*.

   1. Fill in a tag name matching the branch. Packages use three numbers with a "-CUx" suffix for versioning, e.g. `1.0.1-CU0`.

   1. Fill in a comment.

   1. In the top bar in Visual Studio, select *Git* > *Commit or Stash*.

      This opens a new window.

   1. In the new window, select the ellipsis "..." and choose *Push all Tags to Origin*.

This will tag the commit, which will trigger Jenkins to perform a release cycle.

You can monitor the release pipeline:

- If it goes yellow or green, the install package has been successfully released, and users will be able to find it in the Catalog.

- If it goes red, the release failed. You will need to either re-run the pipeline or remove the tag, fix the reported problems, and tag the commit again to trigger a new release.

## Publishing Automation scripts

Automation scripts are XML files and assemblies that are packaged into .dmapp files. The source code of these is currently available both through the internal SLC SE RepoManager and on GitHub. All **new Automation scripts should be created on GitHub**.

If you use **SLC SE RepoManager**, Jenkins will be used to automatically publish scripts to the catalog when tagging. For this, you should [follow the same steps as described for connectors](#publishing-connectors) above.

If you use **GitHub**, it is currently not possible to publish scripts directly to the Catalog. Instead you will need to follow the workaround described below to add them into an install package on SLC SE RepoManager:

1. Make sure the following prerequisites are available:

   - [GitHub Account](https://docs.github.com/en/get-started/signing-up-for-github/signing-up-for-a-new-github-account)

   - [Visual Studio](https://visualstudio.microsoft.com/downloads/)

   - [Git](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git)

   - [DIS](xref:Installing_and_configuring_DataMiner_Integration_Studio)

   - [SLC SE RepoManager](https://tools.skyline.be/installers/SERepoManager/SERepoInstaller.msi)

1. Make sure there is a release or pre-release of your Automation script.

   1. In [GitHub](https://github.com/orgs/SkylineCommunications/repositories), search for your repository and go to its webpage.

   1. On the *Code* tab, check if any releases are listed under *Releases* on the right.

   1. If there are no releases, then create a new release.

      - For a stable release, use a tag with 4 numbers (e.g. 1.0.0.1).

      - For a pre-release, use a similar tag tag with an extra "-text" suffix at the end (e.g. 1.0.0.1-alpha1).

   1. Go to the *Actions* tab for your repository to check if the workflow for the release was successful.

      The workflow for the release should be green. If it is not, you may need to click it and select *Re-run all jobs* in the top-right corner.
      
      If the workflow of the release remains red, and you notice error logging mentioning *Missing argument "api-key"*, add the DATAMINER_DEPLOY_KEY to your repository secrets before re-running the jobs.

1. To make sure the deployed GitHub Automation script is shown in the catalog, use the following workaround:

   1. Open the SLC SE RepoManager.

   1. Follow the steps for [install packages](#publishing-dataminer-install-packages) to create and release a new install package containing the script.

      In *manifest.xml*, add an *AutomationScript* tag using the GitHub URL of your repository as the repo path and the name of your branch as the range.

      For example:

      ```xml
      <AutomationScripts>
         <AutomationScript>
            <RepoPath>https://github.com/SkylineCommunications/AutomationScriptTest_SDK_DataAcq</RepoPath>
            <Version>
               <Selection>
                  <Range rangeSelection="latestBuild">master</Range>
               </Selection>
            </Version>
         </AutomationScript>
      <AutomationScripts>
      ```

## Publishing dashboards

Dashboards are JSON files with configuration settings that can be imported into DataMiner to create a DataMiner dashboard. The source code of these is currently only available through the internal SLC SE RepoManager. They use internal Jenkins pipelines for QA and automatic publishing to the catalog.

As dashboards are a purely visual artifact, the source code is rarely changed directly within the JSON file. Instead, adjustments are made using the Dashboards app UI. Once those adjustments are finished, the JSON is exported.

1. Make sure the following prerequisites are available:

   - [DataMiner](xref:Creating_a_DataMiner_System)

   - [Visual Studio](https://visualstudio.microsoft.com/downloads/)

   - [Git](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git)

   - [DIS](xref:Installing_and_configuring_DataMiner_Integration_Studio)

   - [SLC SE RepoManager](https://tools.skyline.be/installers/SERepoManager/SERepoInstaller.msi)

1. Create a dashboard repository:

   1. Open the SLC SE RepoManager.

   1. Navigate to the *Dashboards* tab and click the + button on the right to create a new repository.

   1. Select your new repository and click the clone button in the top-right corner.

   1. Browse to the repository in File Explorer.

1. Export the dashboard:

   1. Connect to the DataMiner Agent containing the dashboard using RDP.

   1. Go to the folder `C:\Skyline DataMiner\Dashboards`.

   1. Find the .json file representing the dashboard.

   1. Copy the .json file into the dashboard repository.

1. Trigger the dashboard pipeline:

   1. Use your preferred GIT application to commit and push the dashboard repository.

      You can do this with Visual Studio Code, SourceTree, TortoiseGit, or just GIT Bash commands.

   1. Check if the Jenkins pipeline is green or yellow.

      You can do so with the link displayed in the top-right corner of SLC SE RepoManager when your repository is selected.

   1. Optionally, tag a commit to release a stable version.

1. To make sure the deployed dashboard is shown in the catalog, use the following workaround:

   1. Open the SLC SE RepoManager.

   1. Follow the steps for [install packages](#publishing-dataminer-install-packages) to create and release a new install package containing the dashboard.

      In *manifest.xml*, add a *Dashboard* tag using the SLC SE RepoManager path to your repository as the repo path and the name of your branch as the range. You can easily get this value by clicking the *Copy* button at the top of the SLC SE RepoManager when you have selected your dashboard.

      For example:

      ```xml
      <Dashboards>
         <Dashboard>
            <RepoPath>Dashboards\SLCSandbox\TempRegistrationTrial</RepoPath>
            <Version>
               <Selection>
                  <Range rangeSelection="latestBuild">1.0.0.X</Range>
               </Selection>
            </Version>
         </Dashboard>
      </Dashboards>
      ```

## Publishing Visio files

Visio files can be used as a custom user interface for elements, services, or views. They are generally published as single .vsdx files.

Publishing them can be done in the same way as [publishing dashboards](#publishing-dashboards), with the following differences:

- Use the *Visios* tab in the SLC SE RepoManager.

- Use the *Visios* tag when making an install package.
