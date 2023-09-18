---
uid: General_Feature_Release_10.3.9_CU1
---

# General Feature Release 10.3.9 CU1

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!IMPORTANT]
> When downgrading from DataMiner Feature Release version 10.3.8 (or higher) to DataMiner Feature Release version 10.3.4, 10.3.5, 10.3.6 or 10.3.7, an extra manual step has to be performed. For more information, see [Downgrading a DMS](xref:MOP_Downgrading_a_DMS).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.3.9](xref:Cube_Feature_Release_10.3.9).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.3.9](xref:Web_apps_Feature_Release_10.3.9).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Fixes

#### NATS configuration inconsistent in Failover setup after reconfiguring NATS [ID_37023]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.9 [CU1] -->

Up to now, the offline DMA in a Failover pair built its NATS configuration by fetching the nodes from the online DMA. In case the online DMA could not communicate with the rest of the cluster, this caused the offline DMA to also mark all other DMAs as unreachable. This meant that when NATS was reconfigured, even when the offline DMA was actually able to reach them, these "unreachable" DMAs were excluded from its routes. Moreover, as the offline DMA cannot generate alarms, there would be no notification of this until it was switched to online.

This will now be prevented. The offline DMA will now collect all nodes locally when setting up its NATS configuration instead of fetching them from the online DMA.

#### Cassandra backups would no longer work [ID_37217]

<!-- MR 10.4.0 - FR 10.3.9 [CU1] -->
<!-- Not added to MR 10.4.0 -->

DataMiner version 10.3.9 introduced additional binding redirects in the *CassandraBackup.exe.config* file. SLDataGateway would try to load these references, but as these were not available in the `C:\Skyline DataMiner\Tools` folder, exceptions would be thrown and backups would fail.

These references have now been removed again.
