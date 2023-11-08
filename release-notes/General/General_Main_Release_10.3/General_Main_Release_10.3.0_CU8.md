---
uid: General_Main_Release_10.3.0_CU8
---

# General Main Release 10.3.0 CU8

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!IMPORTANT]
> As of DataMiner version 10.3.0[CU8]/10.3.11, Amazon Keyspaces Service, Azure Managed Instance for Apache Cassandra Service and Amazon OpenSearch Service will no longer be supported. We recommend moving to [Storage as a Service](xref:STaaS). Note that using a self-hosted OpenSearch database remains supported.

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Cassandra Cluster Migrator is now able to resume a migration that was in progress when a DMA was stopped [ID_35199]

<!-- MR 10.3.0 [CU8] - FR 10.3.11 -->

When a DataMiner Agent is deliberately stopped or stops working due to an error while a Cassandra Cluster migration is in progress, it will now be possible to resume that migration for certain storages instead of having to start it from scratch again.

For all types that are read in a partitioned way (currently alarms and trending), the migration progress will now be stored in *TokenRange.txt* files located in the `C:\Skyline DataMiner\Database` folder.

To resume a migration after restarting all DMAs in your DataMiner System, do the following:

1. Start *SLCCMigrator.exe* (which is located in the `C:\Skyline DataMiner\Tools\` folder).
1. Initialize all the DMAs in the list.
1. Click *Start Migration*.

> [!NOTE]
>
> - When a migration is resumed, the UI does not know how many rows were already migrated. Therefore, when a migration is resumed, it will erroneously display that 0 rows have been migrated so far.
> - When a DMA is initialized, a file named *SavedState.xml* will be created in the `C:\Skyline DataMiner\Database` folder. *SLCCMigrator.exe* will use this file to determine the point from which a migration has to be resumed.

#### SLAnalytics will now send regular notifications instead of client notifications [ID_35591]

<!-- MR 10.3.0 [CU8] - FR 10.3.4 -->

Up to now, when SLAnalytics sent a notification, it would generate an event of type *client notification* with parameter ID 64574. From now on, it will instead generate an event of type *notification* with parameter ID 64570.

#### Service & Resource Management: Enhanced performance when enabling and disabling function DVEs [ID_37030]

<!-- MR 10.3.0 [CU8] - FR 10.3.11 -->

Because of a number of enhancements, overall performance has increased when enabling and disabling function DVEs.

#### Cassandra Cluster: IP addresses will no longer be added and synchronized automatically [ID_37154]

<!-- MR 10.3.0 [CU8] - FR 10.3.11 -->

Up to now, for the *CassandraCluster* database type, the IP addresses of the Cassandra Cluster nodes would be added automatically to the *DB.xml* file's `<DBServer>` element. From now on, those addresses will no longer be added automatically.

Also, in case of a Failover setup, the above-mentioned list of IP addresses will no longer be automatically synchronized to prevent re-ordering.

#### NATSCustodian: Enhanced behavior when detecting unreachable NATS nodes [ID_37271]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

From now on, when *NATSCustodian* detects unreachable NATS nodes in the cluster, it will no longer generate any alarms, nor will it reset the NATS configuration. It will only add an entry to the *NATSCustodian.txt* log file for diagnostic purposes.

NATSCustodian will only reset the NATS configuration when it detects

- that NATS nodes have been added,
- that NATS nodes have been deleted, or
- when NATS is in an incorrect state.

#### SLAnalytics - Trend predictions: Enhanced trend prediction models [ID_37280]

<!-- MR 10.3.0 [CU8] - FR 10.3.11 -->

A number of enhancements have been made to the trend prediction models, especially with regard to detecting daily trend recurrences.

#### Security enhancements [ID_37291] [ID_37335]

<!-- RN 37291: MR 10.3.0 [CU8] - FR 10.3.11 -->
<!-- RN 37335: 10.2.0 [CU20]/MR 10.3.0 [CU8] - FR 10.3.11 -->

A number of security enhancements have been made.

#### SLAnalytics: Enhanced processing of trended parameters of which the value remains constant [ID_37303]

<!-- MR 10.3.0 [CU8] - FR 10.3.11 -->

A number of enhancements have been made to the memory resources used for trended parameters of which the value remains constant.

#### Old versions of NATS configuration files will now be kept when changes are made to those files [ID_37401]

<!-- MR 10.3.0 [CU8] - FR 10.3.11 -->

When changes are made to one of the following NATS configuration files, from now on, the old version of that file will be saved in the `C:\Skyline DataMiner\Recycle Bin` folder.

- `C:\Skyline DataMiner\SLCloud.xml`
- `C:\Skyline DataMiner\NATS\nats-streaming-server\nats-server.config`
- `C:\Skyline DataMiner\NATS\nats-account-server\nas.config`

This will allow you to trace changes made to these configuration files when issues arise.

### Fixes

#### Failover: Data can get lost when the backup agent is the online agent during a Cassandra Cluster migration [ID_34018]

<!-- 10.2.0 [CU20]/MR 10.3.0 [CU8] - FR 10.3.11 -->

When the backup agent is the online agent while a Failover pair is being migrated to Cassandra Cluster, data generated during the migration can get lost.

From now on, when you start a Cassandra Cluster migration, a warning message will appear if, for any of the Failover pairs in the cluster, the backup agent is the online agent. This warning message will advise you to make sure that, for all Failover pairs in the cluster, the main agent is the online agent.

#### NATS connection could fail due to payloads being too large [ID_36427]

<!-- MR 10.3.0 [CU8] - FR 10.3.8 -->

In some cases, the NATS connection could fail due to payloads being too large. As a result, parameter updates and alarms would no longer be saved to the database.

#### Not all Protocol.Params.Param.Interprete.Others tags would be read out [ID_36797]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

Not all [Protocol.Params.Param.Interprete.Others](xref:Protocol.Params.Param.Interprete.Others) tags would be read out, which could lead to unexpected behavior.

#### Problem when restarting DataMiner [ID_37112]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU8] - FR 10.3.10 -->

When DataMiner was restarted, in some rare cases, it would not start up again.

#### DataMiner backup: Number of backups to be kept would be interpreted incorrectly [ID_37143] [ID_37509]

<!-- 10.2.0 [CU20]/MR 10.3.0 [CU8] - FR 10.3.11 -->

When configuring a DataMiner backup, you can specify the number of backups that should be kept.

Up to now, this setting would incorrectly be interpreted as the total number of backups to be kept in the system. This would cause problems on systems where the number of backups specified was smaller than the number of DataMiner Agents in the DMS.

From now on, the number of backups you specify will be the number of backups that will be kept per DMA or Failover setup. For example, when you set the number of backups to be kept to 3 on a DMS with 5 DMAs or Failover setups, 3 backups will now be kept on every DMA or Failover setup.

> [!NOTE]
>
> - A DataMiner Agent will now store its backups in a subfolder of the folder set as backup location. The name of that subfolder will be identical to the DMA ID of the DataMiner Agent in question.
> - When you upgrade to this DataMiner version, an upgrade action will automatically divide the number of backups to be kept by the number of DataMiner Agents in the DMS if the number of backups to be kept is set to more than 3 and if there are at least two DMAs in the DMS. Note that this upgrade action will do nothing if, in the backup settings, you specified that all DMAs in the DMS have to store their backups on the same network path.

#### Inventory & Asset Management: Problem when synchronizing between the DMA and the database [ID_37177]

<!-- 10.2.0 [CU20]/MR 10.3.0 [CU8] - FR 10.3.11 -->

The Asset Manager would add NullReference exceptions to the SLNet log file when trying to synchronize between the DMA and the database.

When a view or an element was deleted on the DMA before a synchronization was performed from the database to the DMA, the deleted items would not get recreated unless the DMA had been restarted before the synchronization, and when a mediation configuration file was adapted and reloaded, the view configuration would not be reloaded.

#### SLElement could read and write to the same memory blocks on different threads [ID_37180]

<!-- MR 10.3.0 [CU8] - FR 10.3.11 -->

In some cases, SLElement could read and write to the same memory blocks on different threads, causing a serialized parameter update to get into a corrupt state.

#### Problem when masking a DVE child element or a virtual function [ID_37240]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

When you masked a DVE child element or a virtual function, not all alarms of all parameters would be masked.

#### Service & Resource Management: Resources that were still in use could be deactivated [ID_37244]

<!-- 10.2.0 [CU20]/MR 10.3.0 [CU8] - FR 10.3.11 -->

When a booking ends or when a booking is deleted, SLNet will try to deactivate any function DVEs that are no longer required.

In some cases, when function DVEs were being cleaned up while a resource swap occurred on another booking, DVEs required by that other booking would incorrectly also get deactivated.

#### SLLogCollector would not copy all memory dumps to the correct folder [ID_37255]

<!-- 10.2.0 [CU20]/MR 10.3.0 [CU8] - FR 10.3.11 -->

When SLLogCollector takes memory dumps, it stores them in a temporary folder before copying them to the correct location. In some cases, a parsing problem would cause some dumps to not get copied over to the correct location.

#### Problem with SLNet due to unhandled MessageBroker exceptions in SLHelper [ID_37258]

<!-- MR 10.3.0 [CU8] - FR 10.3.11 -->

An error could occur in SLNet due to unhandled MessageBroker exceptions in SLHelper.

#### Elements with multiple SSH connections would go into timeout after being restarted [ID_37294]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

When an element with multiple SSH connections was restarted, in some cases, it would no longer be able to communicate with the SSH server. As a result, it would immediately go into timeout.

#### DataMiner backup: DBConfiguration.xml file would not be included in backups [ID_37296]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

When you took a DataMiner backup either via Cube or via the Taskbar Utility, the *DBConfiguration.xml* file would incorrectly not be included in the backup.

#### Service & Resource Management: Bookings could get stuck in the 'Confirmed' state [ID_37306]

<!-- MR 10.3.0 [CU8] - FR 10.3.11 -->

In some rare cases, a booking created with a start time in the past or equal to "Now" could incorrectly get stuck in the *Confirmed* state.

#### SLAnalytics: Problem due to some features not starting up correctly [ID_37321]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

An error could occur in the SLAnalytics process due to some features not starting up correctly.

#### SLAnalytics: Problem when stopping a feature [ID_37329]

<!-- MR 10.3.0 [CU8] - FR 10.3.11 -->

In some cases, an error could occur in SLAnalytics when a feature (e.g. automatic incident tracking) was stopped.

#### Protocols: Problem when using 'MultipleGetBulk' in combination with 'PartialSNMP' [ID_37336]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

When a protocol was configured to use `MultipleGetBulk` in combination with `PartialSNMP` (e.g. `<OID options="partialSNMP:10;multipleGetBulk:10">`), and the device would return less table cells than the configured `MultipleGetBulk` value, certain fields would not get filled in.

#### SLAnalytics: Problem when fetching protocol information while creating a multivariate pattern [ID_37366]

<!-- MR 10.3.0 [CU8] - FR 10.3.11 -->

In some cases, an error could occur in SLAnalytics when fetching protocol information while creating a multivariate pattern.

#### SLAnalytics: Problem when the SLNet connection got lost while resetting the data sources [ID_37402] [ID_37459]

<!-- RN 37402: MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->
<!-- RN 37459: MR 10.3.0 [CU8] - FR 10.3.11 -->

An error could occur in SLAnalytics when the SLNet connection got lost while resetting the data sources.
