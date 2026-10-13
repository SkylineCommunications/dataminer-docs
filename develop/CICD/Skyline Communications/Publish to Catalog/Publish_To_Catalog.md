---
uid: publish_to_catalog
---

# Publishing items in the Catalog

The [Catalog](https://catalog.dataminer.services/) allows users to quickly look up, download, and deploy various DataMiner-related items.

This platform is constantly getting improved. At present, several workarounds are still needed to get certain items to show up in the Catalog. Below, you can find more information about how to publish specific kinds of items.

> [!TIP]
> See also: [About the Catalog app](xref:About_the_Catalog_app)

## Publishing connectors

Connectors (also known as protocols) are XML files and assemblies that are packaged into .dmprotocol files. The source code of these is currently hosted on GitHub under the [Skyline Communications organization](https://github.com/SkylineCommunications). They use GitHub workflows to (pre-)release new versions on catalog.

Perform the following steps to release a connector version:

1. Make sure the following prerequisites are available:

   - [Visual Studio](https://visualstudio.microsoft.com/downloads/)

   - [Git](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git)

   - [DIS](xref:Installing_and_configuring_DataMiner_Integration_Studio)

1. Registering the connector on Catalog (note that for all non-connector items, registrations will happen automatically from the GitHub workflows. But for connectors, a pre-registration is required):

   1. Register the connector using the [Connector Admin Tool](https://internaldocs.skyline.be/Corporate/PoliciesAndProcedures/EngineeringAndConsultancyServices/Scripts_and_connectors/Connector_Admin_Tool/Connector_Admin_Tool.html).

   1. Copy the [Integration ID](xref:Protocol.IntegrationID), the [Vendor OID](xref:Protocol.VendorOID) and the [Device OID](xref:Protocol.DeviceOID) received from previous step and paste it within the appropriate connector XML tags.

   1. Find back the newly registered connector on Catalog and copy the GUID from the URL. Registering a new connector will always register it as private so you need to log in to find it back. When applicable, the connector can be made public once a first release or pre-release is made.

   1. Make sure the root folder of the repository contains a catalog.yml file, add an `id` property to it and paste the catalog guid as value. Without this, the release flow will fail. Example:

      ```yaml
      id: PASTE_YOUR_CATALOG_GUID_HERE
      ```

1. Add the 'DataMiner Connector' workflow to the repository.

   1. The workflow will then run and a "auto-generated-catalog.yml" file will be created under the ".githubtocatalog" folder within the connector repository. This file should never be edited manually.

   1. Optionally, use this file as an example on how to complete the "catalog.yml" you created during the registration step with extra properties. You may need to do so in following cases:

      - The catalog item name should be different from the name within the protocol.xml file. This can, for example, happen when a special char, that is not allowed within the Protocol/Name XML tag of protocol.xml, is desired on the catalog item name.

      - The connector has some owners.

      - The catalog should associate some extra tags to the connector.

      - ...

1. Release or pre-release using GitHub release feature

## Publishing DataMiner install packages

DataMiner install packages, i.e., .dmapp files, can contain any other artifacts, including other install packages and companion files. The source code of these packages is currently only available through the internal SLC SE RepoManager. They use internal Jenkins pipelines for QA and automatic publishing to the Catalog.

1. Make sure the following prerequisites are available:

   - [Visual Studio](https://visualstudio.microsoft.com/downloads/)

   - [Git](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git)

   - [DIS](xref:Installing_and_configuring_DataMiner_Integration_Studio)

   - [SLC SE RepoManager](https://tools.skyline.be/installers/SERepoManager/SERepoInstaller.msi)

1. Open the source code:

   1. Find or create a new install package in the SLC SE RepoManager under the tab *Packages*.

      > [!NOTE]
      > Make sure you use the correct *Constraint* field to define the appropriate visibility of the Catalog item. See [Creating a repository](xref:Creating_a_repository).

   1. Open the solution using Visual Studio.

1. Include the required artifacts:

   1. Open *manifest.xml*.

      > [!TIP]
      > If you open this in Visual Studio, you will get Intellisense.

   1. You can now add XML tags to add artifacts like connectors, automation scripts, etc.

   > [!TIP]
   > For more information, refer to [Creating a repository for an install package](xref:Creating_a_repository_for_an_install_package).

1. Tag the commit:

   1. In the lower-right corner, select and check out the correct branch. This must be a branch ending in *".X"*, e.g., 1.0.0.X.

   1. Right-click the branch and select *View History*.

   1. Right-click the commit you want to release and select *New Tag*.

   1. Fill in a tag name matching the branch. Packages use three numbers with a "-CUx" suffix for versioning, e.g., `1.0.1-CU0`.

   1. Fill in a comment.

   1. In the top bar in Visual Studio, select *Git* > *Commit or Stash*.

      This opens a new window.

   1. In the new window, select the ellipsis "..." and choose *Push all Tags to Origin*.

This will tag the commit, which will trigger Jenkins to perform a release cycle.

You can monitor the release pipeline:

- If it goes yellow or green, the install package has been successfully released, and users will be able to find it in the Catalog.

- If it goes red, the release failed. You will need to either re-run the pipeline or remove the tag, fix the reported problems, and tag the commit again to trigger a new release.

## Publishing automation scripts

Automation scripts are XML files and assemblies that are packaged into .dmapp files. The source code of these is currently hosted on GitHub under the [Skyline Communications organization](https://github.com/SkylineCommunications).

The scripts will automatically be registered as private Catalog items via GitHub workflows once a release or pre-release is made. When applicable, you can make them made public directly within the catalog.

## Publishing dashboards

Dashboards are JSON files with configuration settings that can be imported into DataMiner to create a DataMiner dashboard. The source code of these is currently only available through the internal SLC SE RepoManager. They use internal Jenkins pipelines for QA and automatic publishing to the Catalog.

Dashboards are currently published as private Catalog items with type *Unknown*. You can find them in the Catalog by searching on their name.

As dashboards are a purely visual artifact, the source code is rarely changed directly within the JSON file. Instead, adjustments are made using the Dashboards app UI. Once those adjustments are finished, the JSON is exported.

1. Make sure the following prerequisites are available:

   - [DataMiner](xref:Deploying_a_DataMiner_System)

   - [Visual Studio](https://visualstudio.microsoft.com/downloads/)

   - [Git](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git)

   - [DIS](xref:Installing_and_configuring_DataMiner_Integration_Studio)

   - [SLC SE RepoManager](https://tools.skyline.be/installers/SERepoManager/SERepoInstaller.msi)

1. Create a dashboard repository:

   1. Open the SLC SE RepoManager.

   1. Navigate to the *Dashboards* tab and click the + button on the right to create a new repository.

      > [!NOTE]
      > Make sure you use the correct *Constraint* field to define the appropriate visibility of the Catalog item. See [Creating a repository](xref:Creating_a_repository).

   1. Select your new repository and click the clone button in the upper-right corner.

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

      You can do so with the link displayed in the upper-right corner of SLC SE RepoManager when your repository is selected.

   1. Optionally, tag a commit to release a stable version.

1. If you want to make sure the deployed dashboard is listed as a public item in the Catalog, either contact the Cloud domain or create an install package as explained below.

   1. Open the SLC SE RepoManager.

   1. Follow the steps for [install packages](#publishing-dataminer-install-packages) to create and release a new install package containing the dashboard.

      Make sure you use the correct *Constraint* field so your package is listed as a public Catalog item. See [Creating a repository](xref:Creating_a_repository).

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

1. Create a Visio repository

   1. Open the SLC SE RepoManager.

   1. Navigate to the *Visios* tab and click the + button on the right to create a new repository.

      > [!NOTE]
      > Make sure you use the correct *Constraint* field to define the appropriate visibility of the Catalog item. See [Creating a repository](xref:Creating_a_repository).

   1. Select your new repository and click the clone button in the upper-right corner.

   1. Browse to the repository in File Explorer.

   1. Copy the .vsdx file in the repository.

1. Trigger the Visio pipeline

   1. Use your preferred GIT application to commit and push the dashboard repository.

      You can do this with Visual Studio Code, SourceTree, TortoiseGit, or just GIT Bash commands.

   1. Check if the Jenkins pipeline is green or yellow.

      You can do so with the link displayed in the upper-right corner of SLC SE RepoManager when your repository is selected.

   1. Tag a commit to release a stable version.
