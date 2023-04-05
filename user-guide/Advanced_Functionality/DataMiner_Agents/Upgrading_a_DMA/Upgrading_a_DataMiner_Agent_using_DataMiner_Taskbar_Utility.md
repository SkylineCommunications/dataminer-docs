---
uid: Upgrading_a_DataMiner_Agent_using_DataMiner_Taskbar_Utility
---

# Upgrading a DataMiner Agent using DataMiner Taskbar Utility

> [!TIP]
> See also: [DataMiner Taskbar Utility](xref:DataMiner_Taskbar_Utility)

## Before upgrading your DataMiner System

If you intend to upgrade your entire DataMiner System (i.e. all DMAs in the cluster), first log on to the DataMiner System with administrative privileges:

1. On one of the DMAs, right-click the DataMiner Taskbar Utility icon in the system tray and select *Options*.

1. Go to the *slnet* tab page, specify the user credentials and click *Test & Save Connection*.

## Performing a DataMiner Upgrade

Proceed as follows to upgrade your DataMiner Agent(s) to the latest version:

> [!NOTE]
> You can also double-click an upgrade package that has been saved in a temporary folder on one of your DataMiner Agents, and then proceed with the procedure from step 3.

1. In the Windows taskbar, right-click the DataMiner Taskbar Utility icon and click *Upgrade*.

1. To the right of the *Package* box, click the ellipsis button ("...") and select the DataMiner upgrade package (extension *.dmupgrade*).

   > [!NOTE]
   >
   > - From DataMiner 10.0.0 CU20, 10.1.0 CU9, and 10.1.12 onwards, if your system does not meet the prerequisites for a specific upgrade version, the upgrade package will not be accepted as a valid package.
   > - From DataMiner 10.3.0/10.3.3 onwards, you can upgrade the DataMiner web apps separately from the core software, by means of a package available on the [DataMiner Software](https://community.dataminer.services/downloads/) page. However, note that when you install a full upgrade package, this will replace any previous web apps upgrade.

1. If you want to upgrade a different Agent than suggested next to *Agents to upgrade*, click *Change* and select the DataMiner Agents that have to be upgraded.

   > [!NOTE]
   >
   > - To upgrade an entire cluster, click *Select all* in the *select Agents to upgrade* window.
   > - To upgrade both Agents in a Failover setup, it suffices to select the entry that represents the setup.

    > [!WARNING]
    > To make sure the system functions correctly, all DMAs in a cluster must run the same DataMiner version.

1. If you do not want to use the [default upgrade options](xref:Configuring_the_default_upgrade_options) settings, expand the *Upgrade options* section and select the necessary upgrade options.

   - *Automatic Start Services*: Select this option if you want the DataMiner Agent software to start up automatically after the upgrade. If you do not select this option, the DataMiner Agent software will have to be started manually.

   - *Delayed Start*: Select this option if you want the Windows system services to be started before the DataMiner services. (Recommended on systems running a large number of services.)

   - *Stop Internet Explorer*: Select this option if you want all open Internet Explorer sessions to be closed during the upgrade process. (Highly recommended for legacy systems prior to 8.5.0.)

   - *Extract All Files*: This option is selected by default, and ensures that all DataMiner system files are replaced. (Recommended.)

   - *Stop SNMP*: Select this option if you want the Windows SNMP Service to be stopped before starting the upgrade procedure. If you choose not to stop the Windows SNMP service, the latter is likely to interfere with the DataMiner SLSNMPAgent process. To prevent interference, you will have to change either the listening port of SLSNMPAgent or the listening port of the Windows SNMP service. See also: [Changing SNMP agent ports](xref:Changing_SNMP_agent_ports).

   - *Reboot After Upgrade*: Select this option if you want the DataMiner Agent(s) to be automatically rebooted at the end of the upgrade procedure.

1. If you are upgrading Agents in a Failover setup, optionally expand the *Failover options* section and select the Failover policy, which determines in what order the DMAs are upgraded.

    - *UseDefault*: Selected by default. If this option is used, the default failover policy will be applied.

    - *Simultaneously*: Select this option if you want to upgrade both Agents simultaneously. This option is highly recommended; always use it in case of a major upgrade, unless it is already the default policy.

    - *BackupFirst*: Select this option if you want to upgrade the offline Agent, switch over and upgrade the online Agent.

    - *BackupFirstWithSwitchback*: Select this option if you want to upgrade the offline Agent, switch over, upgrade the online Agent, and switch back again.

    > [!NOTE]
    > To specify the default Failover policy, in DataMiner Cube, go to *System Center* > *System Settings* > *upgrade* > *Failover options.* We highly recommend that you set this to *Upgrade main and backup Agent simultaneously*.

1. Click *Upgrade* to start the upgrade procedure.

1. Wait until the upgrade has finished. This can take several minutes, depending on the network properties, the type of upgrade, and the size and complexity of your DataMiner System.

1. When all DataMiner Agents have successfully been upgraded, click *Finished*.
