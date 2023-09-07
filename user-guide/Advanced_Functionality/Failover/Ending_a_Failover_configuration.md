---
uid: Ending_a_Failover_configuration
---

# Ending a Failover configuration

When two DMAs are linked together in a Failover setup, it is possible to end the Failover configuration, and thereby separate the two DMAs again.

> [!CAUTION]
> While it is possible from DataMiner 10.2.0 [CU9]/10.2.12 onwards to decommission a Failover setup while the server hosting the offline Agent is unavailable, this will not reset the offline Agent to a clean installation. As such, you will need to make sure the offline Agent is not brought online again in the network as this would cause double polling. In addition, there could be minor data loss and inconsistencies on the database level as the database node cannot be cleanly decommissioned.

## Verifying the replication factor of the Cassandra database

In you use [Cassandra storage per DMA](xref:Databases_about), you first need to check whether the replication factor of your Cassandra configuration is correct. As breaking up the Failover configuration will revert the database to a single node, you need to make sure that the data will be included on both nodes. This means that the replication factor must be set to **2**.

To verify this:

1. On the online DMA, open DataMiner Cube.

1. Go to *Apps* > *System Center* > *Tools* > *Query executor*.

1. Make sure the Failover DMA is selected in the *Execute query on* box.

1. Copy and paste the following query and click *Execute*.

   `Select keyspace_name, replication from system_schema.keyspaces where keyspace_name IN('SLDMADB','system_auth');`

1. Check in the result whether the value is set to 2 for both keyspaces.

In case this is set to **1**, you will need to update the value and repair the keyspaces to make sure the data is in both databases. For more information, refer to [Data Replication](xref:replication_and_consistency_configuration).

If the replication factor is correct, you can continue ending the Failover configuration.

## Ending the Failover configuration in System Center

1. On the online DMA, open DataMiner Cube.

1. Go to *Apps* > *System Center* > *Agents.*

1. On the *Manage* tab, make sure the online DMA is selected in the list of DataMiner Agents.

1. Click the *Failover* button in the lower right corner.

1. In the *Failover* window, depending on your DataMiner version, select *No Failover*, or clear the selection from the *Failover* checkbox.

   From **DataMiner 10.2 onwards**, DataMiner will then display a message to inform you that disabling Failover will revert the Failover Agent to a clean installation and all data on the Agent will be lost.

   - If you click *Yes* in this dialog box, the setup will be removed completely. First the offline DMA will be stopped, and its DataMiner ID and all its data will be removed. The online DMA will release its virtual IP and inform the rest of the DMS (if applicable) that it can now be reached through its actual IP.

   - If you click *No* in this dialog box, the Failover configuration will not be changed.

   Prior to **DataMiner 10.2**, you can then choose whether the Failover setup should be deleted or disabled:

   - If you click *Yes* in the dialog box, the setup will be removed completely. First the offline DMA will be stopped, and its DataMiner ID and all its data will be removed. The online DMA will release its virtual IP and inform the rest of the DMS (if applicable) that it can now be reached through its actual IP.

   - If you click *No* in the dialog box, no data will be removed. The DataMiner ID and configuration of the backup DMA will remain present but will be inactive. The online DMA will release its virtual IP and inform the rest of the DMS (if applicable) that it can now be reached through its actual IP. This means that you could easily enable the Failover setup again without having to reconfigure it from scratch.

> [!NOTE]
> In case a regular Cassandra general database is used, the Cassandra database is always reverted to a single node, regardless of whether you select to disable or delete the Failover setup. If the Cassandra cluster feature is used, the node on the backup DMA will be retained. However, the DB.xml file of the backup Agent will be adapted to no longer refer to the database.
