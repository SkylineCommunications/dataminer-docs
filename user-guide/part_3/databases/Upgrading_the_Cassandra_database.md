---
uid: Upgrading_the_Cassandra_database
---

## Upgrading the Cassandra database

To upgrade the Cassandra database:

1. Before you upgrade, make sure the following applies:

    - No backups are running on the DMA(s).

    - All devcenter processes on the DMA(s) are closed.

    - The following directory does **not** exist: *C:\\Program Files\\Cassandra_Previous_Version*.

    - All command windows that use nodetool are closed.

    - If you intend to upgrade using the DataMiner Taskbar Utility, you are running the utility as Administrator.

2. On DCP, download the latest Cassandra upgrade package from the folder *Software Downloads* > *Cassandra*.

3. While Cassandra is running, run the downloaded package in the same way as a regular upgrade package.

    > [!NOTE]
    > If you run the package on a Failover system, you will be able to apply the same Failover options as for a regular upgrade.

    > [!TIP]
    > See also:
    > - [Upgrading a DataMiner Agent in the Update Center](../DataminerAgents/Upgrading_a_DataMiner_Agent_in_the_Update_Center.md)
    > - [Upgrading a DataMiner Agent using DataMiner Taskbar Utility](../DataminerAgents/Upgrading_a_DataMiner_Agent_using_DataMiner_Taskbar_Utility.md)

    When you start the upgrade, DataMiner will be shut down, Cassandra will be upgraded, and then DataMiner will be started again.

> [!NOTE]
> - Log information for the upgrade can be found in the file *C:\\Skyline DataMiner\\logging\\SLUpgradeDatabaseSoftware.txt*.
> - If the upgrade fails, make sure no backups, devcenter processes, or command processes using nodetool are running, and that there is no directory “*C:\\Program Files\\Cassandra_Previous_Version*”.
>
