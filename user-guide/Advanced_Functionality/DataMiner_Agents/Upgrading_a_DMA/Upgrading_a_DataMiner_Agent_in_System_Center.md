---
uid: Upgrading_a_DataMiner_Agent_in_System_Center
---

# Upgrading a DataMiner Agent in System Center

Proceed as follows to upgrade your DataMiner Agent(s) in System Center:

1. Go to *Apps* > *System Center*.

1. In System Center, select the *Agents* page.

1. In the *Manage* tab, select the DMA you want to upgrade.

   > [!WARNING]
   > To make sure the system functions correctly, all DMAs in a cluster must run the same DataMiner version.

1. In the panel on the right, click the *Upgrade* button.

1. In the *Schedule* tab of the *Upgrade* window, under *Upgrade package*, select an upgrade package in one of the following two ways:

   - Select *Available packages* and then select one of the available packages in the list.

   - Select *New package* and click the ellipsis button ("...") to select the DataMiner upgrade package (extension *.dmupgrade*).

   > [!NOTE]
   >
   > - From DataMiner 10.3.0/10.3.3 onwards, you can upgrade the DataMiner web apps separately from the core software, by means of a package available on the [DataMiner Software](https://community.dataminer.services/downloads/) page. However, note that when you install a full upgrade package, this will replace any previous web apps upgrade.
   > - It is also possible to only upload a new package to the DMA, without installing it yet. To do so, when you have selected the package, click the *Upload only* button.
   > - After you have used a specific package to execute an upgrade, it is marked as completed, and you will not be able to execute another upgrade with this package. However, it does remain displayed in the list of packages to make sure you have an overview of the upgrade history.
    > - From DataMiner 10.0.0 CU20, 10.1.0 CU9, and 10.1.12 onwards, if your system does not meet the prerequisites for a specific upgrade version, the upgrade package will not be accepted as a valid package.

1. Under *Upgrade DataMiner Agents*, select which Agents to upgrade:

    - To upgrade the entire cluster, select *All Agents in cluster*.

    - To upgrade one or more individual Agents, select *Individual Agents* and expand the *DataMiner Agents* section to select the Agents or add them by entering an external IP.

1. If you do not want to use the default upgrade options settings, expand the *Advanced upgrade options* section and select the necessary upgrade options. For more information on these, options, see [default upgrade options](xref:Configuring_the_default_upgrade_options).

1. If you do not want to use the default policy for Agents in a Failover setup, open the section *Advanced Failover options* and select the Failover policy, which determines in what order the DMAs are upgraded. The following options are available:

    - *Default policy* (selected by default)

    - *Upgrade main and backup Agent simultaneously* (highly recommended; always use this option in case of a major upgrade, unless it is already the default policy)

    - *Upgrade backup Agent first, switch over and upgrade main* (legacy)

    - *Upgrade backup Agent first, switch over, upgrade main, then switch back again* (legacy)

1. Click *Upgrade* to start the upgrade procedure.

The upgrade process can take several minutes, depending on the network properties, the type of upgrade, and the size and complexity of your DataMiner System. You can follow the progress of the update in the *Progress* tab.
