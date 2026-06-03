---
uid: MaintenanceSettings.SLNet.ReplicationBufferMaxDisconnectedTime
---

# ReplicationBufferMaxDisconnectedTime element

Available from DataMiner 10.5.0 [CU16]/10.6.0 [CU4]/10.6.7 onwards<!--RN 45432-->. Specifies how long replication buffer files can remain unchanged before they are automatically deleted.

- Default: 30 days
- Minimum value: 14 days
- Maximum value: 30 days
- If set to `-1`, automatic cleanup is disabled.

When replication buffering is enabled (default setting), DataMiner performs an automatic cleanup every 24 hours. See [Automatic cleanup of replication buffer files](xref:SLNetClientTest_inspecting_active_replication_buffers#automatic-cleanup-of-replication-buffer-files).

## Content Type

integer

## Parents

[SLNet](xref:MaintenanceSettings.SLNet)
