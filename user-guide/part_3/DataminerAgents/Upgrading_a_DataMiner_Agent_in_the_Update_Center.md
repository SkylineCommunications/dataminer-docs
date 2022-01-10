## Upgrading a DataMiner Agent in the Update Center

From DataMiner 9.0.5 onwards, it is possible to upgrade or update a DMA via the Update Center.

To do so:

1. From DataMiner 10.0.0/10.0.2 onwards: Click the user icon in the Cube header bar and select *Check for updates*.<br>Prior to DataMiner 10.0.0/10.0.2: Click the updates icon ![](../../images/updates_icon00065.png) in the Cube header bar, or click the question mark icon in the header bar and select *Check for Updates*.

    This will open the Update Center window.

2. Go to the *software* tab of the Update Center window.

    > [!NOTE]
    > You will only have access to this tab if you have the following user permissions:
    > - *General* > *Software* *updates* > *Download software updates from DCP*
    > - *Modules* > *System* *configuration* > *Agents* > *Install App packages*
    > - *Modules* > *System* *configuration* > *Agents* > *Upgrade / restore*
    > - *Modules* > *System* *configuration* > *Agents* > *Stop*

3. Enter your DCP credentials when you are prompted to do so.

    At this point, the window will display whether your system is up to date, and if it is not, it will show which update or upgrade is available (depending on whether you follow the Main Release track or the Feature Release track, respectively).

    > [!NOTE]
    > - For every update or upgrade package listed, you can click *Release notes* to open the release notes document on DCP.
    > - If your system is not using a default DataMiner release, for example because a hotfix is installed, no updates will be available.
    > - Whether you follow the Main Release track or the Feature Release track is determined in the advanced options of the Update Center.
    >     - To switch tracks, click *Advanced Options* and select the release track you wish to follow. As soon as an upgrade or update is available for this track, you will then be able to install it as usual.
    >     - Switching tracks will never cause a downgrade, e.g. if you are using DataMiner 9.5.4 and switch to the Main Release track, an update to a 9.5.0 version will never be proposed.
    >     - The release path selection is saved as one setting across all users.

4. Start downloading the upgrade or update:

    - If you follow the main release path, and an update package is available (e.g. a new Cumulative Update), click *Download & Install* to install that package.

    - If you follow the feature release path, and an upgrade package is available, click *Upgrade to X.X.X.X-XXXX* to install that package.

    The *Upgrade* window will be displayed, which shows the progress of the download, and allows you to select a number of options:

    - Under *Upgrade DataMiner Agents*, you can select which Agents to upgrade:

        - By default, *All Agents in cluster* is selected.

        - To upgrade one or more individual Agents, select *Individual Agents* and expand the *DataMiner Agents* section to select the Agents or add them by entering an external IP. However, note that we strongly advise to use the same version of DataMiner on all Agents in a DMS.

    - In the *Advanced upgrade options* section, you can select the following upgrade options:

        | Option                              | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           |
        |---------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
        | Extract All Files                     | This option is selected by default to ensure that all DataMiner system files are replaced. (Recommended.)                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
        | Delayed Start                         | This option is selected by default to ensure that the Windows system services are started before the DataMiner services. (Recommended on systems running a large number of services.)                                                                                                                                                                                                                                                                                                                                                                                 |
        | Automatically start DMA after startup | This option is selected by default to ensure that the DataMiner Agent software is started up automatically after the upgrade. If you clear the selection, the DMA will need to be started manually.                                                                                                                                                                                                                                                                                                                                                                   |
        | Stop SNMP                             | This option is selected by default to ensure that the Windows SNMP Service is stopped before the upgrade procedure starts.<br> If you choose not to stop the Windows SNMP service, it is likely to interfere with the DataMiner SLSNMPAgent process. To prevent interference, you will have to change either the listening port of SLSNMPAgent or the listening port of the Windows SNMP service.<br> See also: [Changing SNMP agent ports](../SNMP/Changing_SNMP_agent_ports.md) |
        | Reboot After Upgrade                  | Select this option if you want the DataMiner Agent(s) to be automatically rebooted at the end of the upgrade procedure.                                                                                                                                                                                                                                                                                                                                                                                                                                               |

    - For Agents in a Failover setup, you can select a Failover policy in the section *Advanced Failover options*. This determines in what order the Failover DMAs are upgraded. The following options are available:

        - Default policy (selected by default).

        - Upgrade main and backup Agent simultaneously.

        - Upgrade backup Agent first, switch over and upgrade main.

        - Upgrade backup Agent first, switch over, upgrade main, then switch back again.

5. Click *Upgrade* to start the upgrade or update procedure.

    Alternatively, you can also click *Upload only*, if you wish to only upload the package for now and execute the upgrade or update later.
