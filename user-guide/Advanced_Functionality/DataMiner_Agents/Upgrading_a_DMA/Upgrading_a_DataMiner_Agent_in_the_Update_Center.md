---
uid: Upgrading_a_DataMiner_Agent_in_the_Update_Center
---

# Upgrading a DataMiner Agent in the Update Center

It is possible to upgrade or update a DMA via the Update Center in DataMiner Cube.

To do so:

1. From DataMiner 10.0.0/10.0.2 onwards: Click the user icon in the Cube header bar and select *Check for updates*.

   Prior to DataMiner 10.0.0/10.0.2: Click the updates icon ![update icon](~/user-guide/images/updates_icon00065.png) in the Cube header bar, or click the question mark icon in the header bar and select *Check for Updates*.

   This will open the Update Center window.

1. Go to the *software* tab of the Update Center window.

    > [!NOTE]
    > You will only have access to this tab if you have the following user permissions:
    >
    > - *General* > *Software* *updates* > *Download software updates from DCP*
    > - *Modules* > *System* *configuration* > *Agents* > *Install App packages*
    > - *Modules* > *System* *configuration* > *Agents* > *Upgrade / restore*
    > - *Modules* > *System* *configuration* > *Agents* > *Stop*

1. Enter your DCP credentials when you are prompted to do so.

    At this point, the window will display whether your system is up to date, and if it is not, it will show which update or upgrade is available (depending on whether you follow the Main Release track or the Feature Release track, respectively).

    > [!NOTE]
    >
    > - For every update or upgrade package listed, you can click *Release notes* to browse to the release notes on DataMiner Dojo.
    > - If your system is not using a default DataMiner release, for example because a hotfix is installed, no updates will be available.
    > - Whether you follow the Main Release track or the Feature Release track is determined in the advanced options of the Update Center.
    >     - To switch tracks, click *Advanced Options* and select the release track you wish to follow. As soon as an upgrade or update is available for this track, you will then be able to install it as usual.
    >     - Switching tracks will never cause a downgrade, e.g. if you are using DataMiner 10.2.12 and switch to the Main Release track, an update to a 10.2.0 version will never be proposed.
    >     - The release path selection is saved as one setting across all users.

1. Start downloading the upgrade or update:

   - If you follow the main release path, and an update package is available (e.g. a new Cumulative Update), click *Download & Install* to install that package.

   - If you follow the feature release path, and an upgrade package is available, click *Upgrade to X.X.X.X-XXXX* to install that package.

   The *Upgrade* window will be displayed, which shows the progress of the download, and allows you to select a number of options:

   - Under *Upgrade DataMiner Agents*, you can select which Agents to upgrade. By default, *All Agents in cluster* is selected. While it is possible to select an individual Agent instead, we strongly recommend using the same version of DataMiner on all Agents in a DMS.

     > [!WARNING]
     > To make sure the system functions correctly, all DMAs in a cluster must run the same DataMiner version.

   - In the *Advanced upgrade options* section, you can change the upgrade options if necessary. For more information on these options, see [default upgrade options](xref:Configuring_the_default_upgrade_options).

   - For Agents in a Failover setup, you can select a Failover policy in the section *Advanced Failover options*. This determines in what order the Failover DMAs are upgraded. The following options are available:

     - *Default policy* (selected by default)

     - *Upgrade main and backup Agent simultaneously* (highly recommended; always use this option in case of a major upgrade, unless it is already the default policy)

     - *Upgrade backup Agent first, switch over and upgrade main* (legacy)

     - *Upgrade backup Agent first, switch over, upgrade main, then switch back again* (legacy)

     > [!NOTE]
     > To specify the default Failover policy, in DataMiner Cube, go to *System Center* > *System Settings* > *upgrade* > *Failover options*. We highly recommend that you set this to *Upgrade main and backup Agent simultaneously*.

1. Click *Upgrade* to start the upgrade or update procedure.

    Alternatively, you can also click *Upload only*, if you wish to only upload the package for now and execute the upgrade or update later.
