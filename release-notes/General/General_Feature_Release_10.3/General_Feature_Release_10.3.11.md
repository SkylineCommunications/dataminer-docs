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

<!-- MR 10.4.0 - FR 10.3.11 -->

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

### Fixes

#### Not all Protocol.Params.Param.Interprete.Others tags would be read out [ID_36797]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.11 -->

Not all [Protocol.Params.Param.Interprete.Others](xref:Protocol.Params.Param.Interprete.Others) tags would be read out, which could lead to unexpected behavior.

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
