---
uid: Upgrading_a_DataMiner_Agent_in_System_Center
---

## Upgrading a DataMiner Agent in System Center

Proceed as follows to upgrade your DataMiner Agent(s) in System Center:

1. Go to *Apps* > *System Center*.

2. In System Center, select the *Agents* page.

3. In the *Manage* tab, select the DMA you want to upgrade.

    > [!WARNING]
    > To make sure the system functions correctly, all DMAs in a cluster must run the same DataMiner version.

4. In the panel on the right, click the *Upgrade* button.

5. In the *Schedule* tab of the *Upgrade* window, under *Upgrade package*, select an upgrade package in one of the following two ways:

    - Select *Available packages* and then select one of the available packages in the list.

    - Select *New package* and click the ellipsis button ("...") to select the DataMiner upgrade package (extension *.dmupgrade*).

    > [!NOTE]
    > - It is also possible to only upload a new package to the DMA, without installing it yet. To do so, when you have selected the package, click the *Upload only* button.
    > - After you have used a specific package to execute an upgrade, it is marked as completed, and you will not be able to execute another upgrade with this package. However, it does remain displayed in the list of packages to make sure you have an overview of the upgrade history.
    > - From DataMiner 10.0.0 CU20, 10.1.0 CU9, and 10.1.12 onwards, if your system does not meet the prerequisites for a specific upgrade version, the upgrade package will not be accepted as a valid package.

6. Under *Upgrade DataMiner Agents*, select which Agents to upgrade:

    - To upgrade the entire cluster, select *All Agents in cluster*.

    - To upgrade one or more individual Agents, select *Individual Agents* and expand the *DataMiner Agents* section to select the Agents or add them by entering an external IP.

7. Expand the *Advanced upgrade options* section and select the necessary upgrade options.

   - *Extract All Files*: This option is selected by default to ensure that all DataMiner system files are replaced. (Recommended.)

   - *Delayed Start*: This option is selected by default to ensure that the Windows system services are started before the DataMiner services. (Recommended on systems running a large number of services.)

   - *Automatically start DMA after startup*: This option is selected by default to ensure that the DataMiner Agent software is started up automatically after the upgrade. If you clear the selection, the DMA will need to be started manually. 

   - *Stop SNMP*: This option is selected by default to ensure that the Windows SNMP Service is stopped before the upgrade procedure starts. If you choose not to stop the Windows SNMP service, it is likely to interfere with the DataMiner SLSNMPAgent process. To prevent interference, you will have to change either the listening port of SLSNMPAgent or the listening port of the Windows SNMP service. See also: [Changing SNMP agent ports](xref:Changing_SNMP_agent_ports).

   - *Reboot After Upgrade*: Select this option if you want the DataMiner Agent(s) to be automatically rebooted at the end of the upgrade procedure.

8. For Agents in a Failover setup, open the section *Advanced Failover options* and select the Failover policy, which determines in what order the DMAs are upgraded. The following options are available:

    - *Default policy* (selected by default)

    - *Upgrade main and backup Agent simultaneously* (highly recommended; always use this option in case of a major upgrade, unless it is already the default policy).

    - *Upgrade backup Agent first, switch over and upgrade main*

    - *Upgrade backup Agent first, switch over, upgrade main, then switch back again*.

    > [!NOTE]
    > The default policy can be configured in System Center, via *Settings* > *Upgrade* > *Failover options*. We highly recommend that you set this to *Upgrade main and backup Agent simultaneously*.

9. Click *Upgrade* to start the upgrade procedure.

The upgrade process can take several minutes, depending on the network properties, the type of upgrade, and the size and complexity of your DataMiner System. You can follow the progress of the update in the *Progress* tab.
