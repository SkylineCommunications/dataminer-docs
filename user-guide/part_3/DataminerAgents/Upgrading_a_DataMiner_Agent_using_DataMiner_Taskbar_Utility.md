## Upgrading a DataMiner Agent using DataMiner Taskbar Utility

> [!TIP]
> See also:
> [DataMiner Taskbar Utility](../../part_7/DataminerTools/DataMiner_Taskbar_Utility.md)

### Before upgrading your DataMiner System

If you intend to upgrade your entire DataMiner System (i.e. all DMAs in the cluster), then first log on to the DataMiner System with administrative privileges:

1. On one of the DMAs, right-click the DataMiner Taskbar Utility icon in the system tray and select *Options*.

2. Go to the *slnet* tab page, specify the user credentials and click *Test & Save Connection*.

### Performing a DataMiner Upgrade

> [!NOTE]
> When you upgrade systems prior to DataMiner version 8.5.0, it is recommended to start the upgrade from a client machine rather than from a DataMiner Agent. During the upgrade process, all open Internet Explorer windows will be closed. As a consequence, if you start the process from a DataMiner Agent, you will not be able to follow the progress of the upgrade being performed. From version 8.5.0 onwards, the files *SLSystemDisplay.ocx* and *SLElementDisplay.ocx* are removed from the folder *C:\\Skyline DataMiner\\Files*, which makes it possible to leave Internet Explorer open during the update.

Proceed as follows to upgrade your DataMiner Agent(s) to the newest version:

1. In the Windows taskbar, right-click the DataMiner Taskbar Utility icon and click *Upgrade*.

2. To the right of the *Package* box, click the ellipsis button (”...”) and select the DataMiner upgrade package (extension *.dmupgrade*).

    > [!NOTE]
    > From DataMiner 10.0.0 CU20, 10.1.0 CU9, and 10.1.12 onwards, if your system does not meet the prerequisites for a specific upgrade version, the upgrade package will not be accepted as a valid package.

3. To the right of the *Agents to upgrade* box, click *Change* and select the DataMiner Agents that have to be upgraded.

    > [!NOTE]
    > -  To upgrade an entire cluster, click *Select all* in the *select Agents to upgrade* window.
    > -  To upgrade both Agents in a Failover setup, it suffices to select the entry that represents the setup.

    > [!WARNING]
    > To make sure the system functions correctly, all DMAs in a cluster must run the same DataMiner version.

4. Expand the *Upgrade options* section and select the necessary upgrade options.

    | Option                 | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     |
    |--------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | Automatic Start Services | Select this option if you want the DataMiner Agent software to start up automatically after the upgrade.<br> If you do not select this option, the DataMiner Agent software will have to be started manually.                                                                                                                                                                                                                                                                                                                                                   |
    | Delayed Start            | Select this option if you want the Windows system services to be started before the DataMiner services.<br> (recommended on systems running a large number of services)                                                                                                                                                                                                                                                                                                                                                                                         |
    | Stop Internet Explorer   | Select this option if you want all open Internet Explorer sessions to be closed during the upgrade process.<br> (highly recommended for DataMiner versions prior to 8.5.0)                                                                                                                                                                                                                                                                                                                                                                                      |
    | Extract All Files        | This option is selected by default, and ensures that all DataMiner system files are replaced.<br> (recommended)                                                                                                                                                                                                                                                                                                                                                                                                                                                 |
    | Stop SNMP                | Select this option if you want the Windows SNMP Service to be stopped before starting the upgrade procedure.<br> If you choose not to stop the Windows SNMP service, the latter is likely to interfere with the DataMiner SLSNMPAgent process. To prevent interference, you will have to change either the listening port of SLSNMPAgent or the listening port of the Windows SNMP service.<br> See also: [Changing SNMP agent ports](../SNMP/Changing_SNMP_agent_ports.md) |
    | Reboot After Upgrade     | Select this option if you want the DataMiner Agent(s) to be automatically rebooted at the end of the upgrade procedure.                                                                                                                                                                                                                                                                                                                                                                                                                                         |

5. If you are upgrading Agents in a Failover setup, optionally expand the *Failover options* section and select the Failover policy, which determines in what order the DMAs are upgraded.

    | Option                  | Description                                                                                                                |
    |---------------------------|----------------------------------------------------------------------------------------------------------------------------|
    | UseDefault                | Selected by default. If this option is used, the default failover policy will be applied.                                  |
    | Simultaneously            | Select this option if you want to upgrade both Agents simultaneously.                                                      |
    | BackupFirst               | Select this option if you want to upgrade the offline Agent, switch over and upgrade the online Agent.                     |
    | BackupFirstWithSwitchback | Select this option if you want to upgrade the offline Agent, switch over, upgrade the online Agent, and switch back again. |

 

    > [!NOTE]
    > To specify the default failover policy, in DataMiner Cube, go to *System Center* > *System Settings* > *upgrade* > *Failover options.*

6. Click *Upgrade* to start the upgrade procedure.

7. Wait until the upgrade has finished. This can take several minutes, depending on the network properties, the type of upgrade, and the size and complexity of your DataMiner System.

8. When all DataMiner Agents have successfully been upgraded, click *Finished*.

> [!NOTE]
> Alternatively, you can also double-click an upgrade package that has been saved in a temporary folder on one of your DataMiner Agents, and then proceed with the procedure above from step 3.
>
