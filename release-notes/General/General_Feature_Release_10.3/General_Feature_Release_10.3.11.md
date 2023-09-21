---
uid: General_Feature_Release_10.3.11
---

# General Feature Release 10.3.11 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
> When downgrading from DataMiner Feature Release version 10.3.8 (or higher) to DataMiner Feature Release version 10.3.4, 10.3.5, 10.3.6 or 10.3.7, an extra manual step has to be performed. For more information, see [Downgrading a DMS](xref:MOP_Downgrading_a_DMS).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.3.10](xref:Cube_Feature_Release_10.3.10).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.3.10](xref:Web_apps_Feature_Release_10.3.10).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been added to this section yet.*

## New features

*No new features have been added to this release yet.*

## Changes

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

#### Service & Resource Management: Enhanced performance when enabling and disabling function DVEs [ID_37030]

<!-- MR 10.3.0 [CU8] - FR 10.3.11 -->

Because of a number of enhancements, overall performance has increased when enabling and disabling function DVEs.

#### Cassandra Cluster: IP addresses will no longer be added and synchronized automatically [ID_37154]

<!-- MR 10.3.0 [CU8] - FR 10.3.11 -->

Up to now, for the *CassandraCluster* database type, the IP addresses of the Cassandra Cluster nodes would be added automatically to the *DB.xml* file's `<DBServer>` element. From now on, those addresses will no longer be added automatically.

Also, in case of a Failover setup, the above-mentioned list of IP addresses will no longer be automatically synchronized to prevent re-ordering.

#### DataMiner.xml: objectId attribute of AzureAD element will now be considered optional [ID_37162]

<!-- MR 10.4.0 - FR 10.3.11 -->

Up to now, a run-time error would be thrown when the `<AzureAD>` element in the *DataMiner.xml* file did not contain an `objectId` attribute.

This `objectId` attribute will now be considered optional. Hence, no run-time error will be thrown anymore when it has not been specified.

#### Security enhancements [ID_37267] [ID_37291] [ID_37335] [ID_37345]

<!-- RN 37267/37345: MR 10.4.0 - FR 10.3.11 -->
<!-- RN 37291: MR 10.3.0 [CU8] - FR 10.3.11 -->
<!-- RN 37335: 10.2.0 [CU20]/MR 10.3.0 [CU8] - FR 10.3.11 -->

A number of security enhancements have been made.

#### SLAnalytics - Trend predictions: Enhanced trend prediction models [ID_37280]

<!-- MR 10.3.0 [CU8] - FR 10.3.11 -->

A number of enhancements have been made to the trend prediction models, especially with regard to detecting daily trend recurrences.

#### SLDataMiner will now use the MessageBroker.Native NuGet package for all communication with the NATS bus [ID_37298]

<!-- MR 10.4.0 - FR 10.3.11 -->

Up to now, SLDataMiner used SLCloudBridge for all communication with the NATS bus. From now on, it will use the *MessageBroker.Native* NuGet package instead.

#### SLAnalytics: Enhanced processing of trended parameters of which the value remains constant [ID_37303]

<!-- MR 10.3.0 [CU8] - FR 10.3.11 -->

A number of enhancements have been made to the memory resources used for trended parameters of which the value remains constant.

### Fixes

#### Failover: Data can get lost when the backup agent is the online agent during a Cassandra Cluster migration [ID_34018]

<!-- 10.2.0 [CU20]/MR 10.3.0 [CU8] - FR 10.3.11 -->

When the backup agent is the online agent while a Failover pair is being migrated to Cassandra Cluster, data generated during the migration can get lost.

From now on, when you start a Cassandra Cluster migration, a warning message will appear if, for any of the Failover pairs in the cluster, the backup agent is the online agent. This warning message will advise you to make sure that, for all Failover pairs in the cluster, the main agent is the online agent.

#### Not all Protocol.Params.Param.Interprete.Others tags would be read out [ID_36797]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

Not all [Protocol.Params.Param.Interprete.Others](xref:Protocol.Params.Param.Interprete.Others) tags would be read out, which could lead to unexpected behavior.

#### Problem with .NET Framework DLL files used by QActions or Automation scripts [ID_36984]

<!-- 10.2.0 [CU20]/MR 10.3.0 [CU8] - FR 10.3.11 -->

When a QAction or Automation script used a NuGet package containing a .NET Framework DLL file on a DataMiner Agent that used a more recent .NET Framework that included that same DLL file by default, a compilation error would occur.

Also, certain DLL files located in a subfolder of the .NET Framework would not be resolved correctly.

#### DataMiner backup: Number of backups to be kept would be interpreted incorrectly [ID_37143]

<!-- 10.2.0 [CU20]/MR 10.3.0 [CU8] - FR 10.3.11 -->

When configuring a DataMiner backup, you can specify the number of backups that should be kept.

Up to now, this setting would incorrectly be interpreted as the total number of backups to be kept in the system. This would cause problems on systems where the number of backups specified was smaller than the number of DataMiner Agents in the DMS.

From now on, the number of backups you specify will be the number of backups that will be kept per DMA or Failover setup. For example, when you set the number of backups to be kept to 3 on a DMS with 5 DMAs or Failover setups, 3 backups will now be kept on every DMA or Failover setup.

> [!NOTE]
> A DataMiner Agent will now store its backups in a subfolder of the folder set as backup location. The name of that subfolder will be identical to the DMA ID of the DataMiner Agent in question.

#### SLNet would incorrectly return certain port information fields of type string as null values [ID_37165]

<!-- MR 10.4.0 - FR 10.3.11 -->
<!-- Not added to MR 10.4.0 - This RN is identical to RN 36524 -->

When element information was retrieved from SLNet, in some cases, certain port information fields of type string would incorrectly be returned as a null value instead of an empty string value. As a result, DataMiner Cube would no longer show the port information when you edited an element.

Affected port information fields:

- BusAddress
- Number
- PollingIPAddress
- PollingIPPort

#### Inventory & Asset Management: Problem when synchronizing between the DMA and the database [ID_37177]

<!-- 10.2.0 [CU20]/MR 10.3.0 [CU8] - FR 10.3.11 -->

The Asset Manager would add NullReference exceptions to the SLNet log file when trying to synchronize between the DMA and the database.

When a view or an element was deleted on the DMA before a synchronization was performed from the database to the DMA, the deleted items would not get recreated unless the DMA had been restarted before the synchronization, and when a mediation configuration file was adapted and reloaded, the view configuration would not be reloaded.

#### SLElement could read and write to the same memory blocks on different threads [ID_37180]

<!-- MR 10.3.0 [CU8] - FR 10.3.11 -->

In some cases, SLElement could read and write to the same memory blocks on different threads, causing a serialized parameter update to get into a corrupt state.

#### DataMiner.xml: Entire LDAP section could get removed when settings were updated with values containing illegal XML characters [ID_37235]

<!-- MR 10.4.0 - FR 10.3.11 -->

When settings inside the `<LDAP>` element of the *DataMiner.xml* file were updated with values that contained illegal XML characters, the entire `<LDAP>` element would be removed from the file.

#### MessageHandler method in SLHelperTypes.SLHelper would incorrectly try to serialize exceptions that could not be serialize [ID_37238]

<!-- MR 10.4.0 - FR 10.3.11 -->

Up to now, the MessageHandler method in SLHelperTypes.SLHelper would incorrectly try to serialize exceptions that could not be serialized, causing other exceptions to be thrown.

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

#### DataMiner backup: DBConfiguration.xml file would not be included in backups [ID_37296]

<!-- 10.2.0 [CU20]/MR 10.3.0 [CU8] - FR 10.3.11 -->

When you took a DataMiner backup either via Cube or via the Taskbar Utility, the *DBConfiguration.xml* file would incorrectly not be included in the backup.

#### SLAnalytics: Problem due to some features not starting up correctly [ID_37321]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

An error could occur in the SLAnalytics process due to some features not starting up correctly.
