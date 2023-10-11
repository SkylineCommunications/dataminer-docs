---
uid: public_to_catalog
---

# Publish to the Catalog

The [catalog](https://catalog.dataminer.services/) is our front end UI that allows quick lookup, download and deployment of all DataMiner related artifacts.
This platform is constantly getting improved and worked on. At the time of writing, there are several workarounds needed to get certain artifacts to show up on the catalog. Please note it is currently only possible for members of Skyline Communications to publish items to the catalog. There are future plans to have a "private" section of the catalog that could contain items published by yourself as part the larger DevOps community.

In the below sections we will describe in detail how to get any artifact on the Catalog.

## Connectors

Connectors, also known as Protocols or Drivers are xml files and assemblies that are packaged into .dmprotocol files. The sourcecode of these are currently only available through the internal SLC SE RepoManager. They use internal Jenkins pipelines for QA and automatic publishing to the catalog.

### Prerequisites

- [Visual Studio](https://visualstudio.microsoft.com/downloads/)

- [Git](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git)

- [DIS](xref:Installing_and_configuring_DataMiner_Integration_Studio)

- [SLC SE RepoManager](https://tools.skyline.be/installers/SERepoManager/SERepoInstaller.msi)

### Steps

1. Open the sourcecode
    1.  Find the connector in the SLC SE RepoManager under the tab Protocols
    1. Open the connector solution using Visual Studio
1. Tag the commit
    1. At the bottom right, select and checkout the correct branch. This must be a branch ending with a *".X"* e.g. 1.0.0.X.
    1. Right click the branch and select *View History*.
    1. Right click the commit you wish to release and select *"New Tag..."*
    1. Fill in tag name matching the branch. Connectors use 4 numbers for versioning. e.g. 1.0.0.3
    1. Fill in a comment.
    1. In the top bar in Visual Studio, select *Git* > *Commit or Stash*.
    
       This opens a new window.
    
    1. In the new window, select the 3 dots "..." and choose *Push all Tags to Origin*
 
This will tag the commit, triggering jenkins to perform a release cycle.
You can monitor the release pipeline. 
- If it goes yellow or green, the connector is successfully released and can be seen on the catalog.
- If it goes red, the release failed. You will need to either re-run that pipeline or remove the tag, fix the reported problems and tag again to trigger a new release

## Install Packages

Install Packages, also known as dmapp's can contain any other artifact, including other install packages and companion files. The sourcecode of these are currently only available through the internal SLC SE RepoManager. They use internal Jenkins pipelines for QA and automatic publishing to the catalog.

### Prerequisites

- [Visual Studio](https://visualstudio.microsoft.com/downloads/)

- [Git](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git)

- [DIS](xref:Installing_and_configuring_DataMiner_Integration_Studio)

- [SLC SE RepoManager](https://tools.skyline.be/installers/SERepoManager/SERepoInstaller.msi)

### Steps

1. Open the sourcecode
    1. Find or create a new installpackage in the SLC SE RepoManager under the tab Packages
    1. Open the solution using Visual Studio
1. Include the required artifacts
    1. Open the manifest.xml (when opened in Visual Studio you will get Intellisense)
    1. You can now add XML tags to add artifacts like Connectors, Automationscripts, ...
       For more information you can see the [additional documentation](xref:Creating_a_repository_for_an_install_package).
1. Tag the commit
    1. At the bottom right, select and checkout the correct branch. This must be a branch ending with a *".X"* e.g. 1.0.X.
    1. Right click the branch and select *View History*.
    1. Right click the commit you wish to release and select *"New Tag..."*
    1. Fill in tag name matching the branch. Packages use 3 numbers with a "-CUx" for versioning. e.g. 1.0.1-CU0
    1. Fill in a comment.
    1. In the top bar in Visual Studio, select *Git* > *Commit or Stash*.
    
       This opens a new window.
    
    1. In the new window, select the 3 dots "..." and choose *Push all Tags to Origin*
 
This will tag the commit, triggering jenkins to perform a release cycle.
You can monitor the release pipeline. 
- If it goes yellow or green, the connector is successfully released and can be seen on the catalog.
- If it goes red, the release failed. You will need to either re-run that pipeline or remove the tag, fix the reported problems and tag again to trigger a new release

## Automationscripts

Automationscript, are xml files and assemblies that are packaged into .dmapp files. The sourcecode of these are currently available both internally on SLC SE RepoManager and on GitHub. All new Automationscripts should get created on GitHub.

On SLC SE RepoManager they will use jenkins to automatically publish to the catalog when tagging.
Please follow the same steps as described for Connectors above.

On GitHub these are currently not able to be published directly to the catalog. They require a temporary workaround by adding them into an InstallPackage on SLC SE RepoManager.

### Prerequisites for Github

- [GitHub Account](https://docs.github.com/en/get-started/signing-up-for-github/signing-up-for-a-new-github-account)

- [Visual Studio](https://visualstudio.microsoft.com/downloads/)

- [Git](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git)

- [DIS](xref:Installing_and_configuring_DataMiner_Integration_Studio)

- [SLC SE RepoManager](https://tools.skyline.be/installers/SERepoManager/SERepoInstaller.msi)

### Steps for GitHub

1. Make sure there is a release or pre-release of your automationscript
    1. In [GitHub ](https://github.com/orgs/SkylineCommunications/repositories) search for your repository.
    1. Open the webpage for your repository, under the tab Code, check for Releases on the right.
    1. If there are no releases, then create a new release. For a stable release, tag using 4 numbers (e.g. 1.0.0.1). For a pre-release tag with an extra "-text" at the end (e.g. 1.0.0.1-alpha1).
    1. Check if the release has had a successful workflow by looking under the tab Actions on the webpage of the repository. The workflow for the version should be green. If not, you may need to click it and choose Re-Run all Jobs at the top right.

Due to the catalog not yet showing Deployed GitHub Automationscripts you need to perform the following workaround:

1. Open the SLC SE RepoManager, create and release a new Install Package following the steps with [Install Packages](#Install-Packages).
    1. In the manifest.xml you'll want to add an AutomationScript tag using the github url to your repository as the RepoPath and the name of your branch as the range.
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

## Dashboards

Dashboards, are json files that contain configuration settings that can be imported into DataMiner to create a Dashboard. The sourcecode of these are currently only available through the internal SLC SE RepoManager. They use internal Jenkins pipelines for QA and automatic publishing to the catalog.

As dashboards are a purely visual artifact, the sourcecode is rarely changed directly within the json. Rather, adjustments are made using the Editor in DataMiner. Once those adjusments are finished the json is exported.

### Prerequisites

- [DataMiner](https://visualstudio.microsoft.com/downloads/)
- 
- [Visual Studio](https://visualstudio.microsoft.com/downloads/)

- [Git](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git)

- [DIS](xref:Installing_and_configuring_DataMiner_Integration_Studio)

- [SLC SE RepoManager](https://tools.skyline.be/installers/SERepoManager/SERepoInstaller.msi)

### Steps

1. Create a Dashboard repository
    1. Open the SLC SE RepoManager
    1. Navigate to the Dashboards tab and click the + button on the right to create a new repository.
    1. Select your new repository in the RepoManager and click the top right, clone button.
    1. Now browse with the File Explorer to the repository.
1. Export the Dashboard
    1. RDP to the agent holding the dashboard.
    1. Go to C:\Skyline DataMiner\Dashboards
    1. Find the .json file representing your dashboard
    1. Copy the .json file into the Dashboard repository.
1. Trigger the Dashboard Pipeline
    1. Using your preferred GIT application you want to Commit & Push the Dashboard repository
        1. You can do this with Visual Studio Code, SourceTree, TortoiseGit or just using GIT Bash commands.
    1. Check if the Jenkins pipeline was green or yellow. There is an easy link on the top right in the SLC SE RepoManager when selecting your repository.
    1.  (optional) You can at this point, tag a commit to release a stable version if you want.

Due to the catalog not yet showing Deployed Dashboards you need to perform the following workaround:

1. Open the SLC SE RepoManager, create and release a new Install Package following the steps with [Install Packages](#Install-Packages).
    1. In the manifest.xml you'll want to add a Dashboard tag using the SLC SE RepoManager path to your repository as the RepoPath and the name of your branch as the range. You can easily get this value by clicking the Copy button at the top of the SLC SE RepoManager when you've selected your Dashboard.
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

