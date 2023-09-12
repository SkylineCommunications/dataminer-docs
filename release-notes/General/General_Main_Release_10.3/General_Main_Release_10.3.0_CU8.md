---
uid: General_Main_Release_10.3.0_CU8
---

# General Main Release 10.3.0 CU8 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### ElasticBackup.exe will now always convert the keyspace and the snapshot name to lower case [ID_37247]

<!-- 10.2.0 [CU20]/MR 10.3.0 [CU8] - FR 10.3.11 -->

From now on, the *ElasticBackup.exe* tool will always convert the keyspace and the snapshot name to lower case.

### Fixes

#### NATS connection could fail due to payloads being too large [ID_36427]

<!-- MR 10.3.0 [CU8] - FR 10.3.8 -->

In some cases, the NATS connection could fail due to payloads being too large. As a result, parameter updates and alarms would no longer be saved to the database.

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

#### Inventory & Asset Management: Problem when synchronizing between the DMA and the database [ID_37177]

<!-- 10.2.0 [CU20]/MR 10.3.0 [CU8] - FR 10.3.11 -->

The Asset Manager would add NullReference exceptions to the SLNet log file when trying to synchronize between the DMA and the database.

When a view or an element was deleted on the DMA before a synchronization was performed from the database to the DMA, the deleted items would not get recreated unless the DMA had been restarted before the synchronization, and when a mediation configuration file was adapted and reloaded, the view configuration would not be reloaded.

#### SLElement could read and write to the same memory blocks on different threads [ID_37180]

<!-- MR 10.3.0 [CU8] - FR 10.3.11 -->

In some cases, SLElement could read and write to the same memory blocks on different threads, causing a serialized parameter update to get into a corrupt state.

#### Service & Resource Management: Resources that were still in use could be deactivated [ID_37244]

<!-- 10.2.0 [CU20]/MR 10.3.0 [CU8] - FR 10.3.11 -->

When a booking ends or when a booking is deleted, SLNet will try to deactivate any function DVEs that are no longer required.

In some cases, when function DVEs were being cleaned up while a resource swap occurred on another booking, DVEs required by that other booking would incorrectly also get deactivated.

#### SLLogCollector would not copy all memory dumps to the correct folder [ID_37255]

<!-- 10.2.0 [CU20]/MR 10.3.0 [CU8] - FR 10.3.11 -->

When SLLogCollector takes memory dumps, it stores them in a temporary folder before copying them to the correct location. In some cases, a parsing problem would cause some dumps to not get copied over to the correct location.
