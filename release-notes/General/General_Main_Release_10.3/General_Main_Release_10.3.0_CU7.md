---
uid: General_Main_Release_10.3.0_CU7
---

# General Main Release 10.3.0 CU7 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Correlation alarms will now by default contain the value of the alarm property by which they are grouped [ID_35583]

<!-- MR 10.3.0 [CU7] - FR 10.3.4 -->

When a correlation rule is configured to use alarm grouping via an alarm property, from now on, the value of the alarm property by which the alarms are grouped will now by default be added to the correlated alarm.

If you do not want the alarm property value to be added to the correlation alarm, then you can disable this behavior by adding the `NewAlarmOptions.DisableGroupedProperty` flag to the `NewAlarmActionDefinition.Properties` using the *SLNetClientTest* tool.

> [!WARNING]
> Always be extremely careful when using the *SLNetClientTest* tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### Updated bookings now only set to Confirmed when necessary [ID_36818]

<!-- MR 10.3.0 [CU7] - FR 10.3.10 -->

Up to now, bookings were always set to Confirmed again when they were updated, even though this is not always necessary. As such, bookings will now only be set to Confirmed again when this is actually needed, i.e.:

- When the new status of the booking is not the same as the old status.
- When the start or end time is no longer the same.
- When the resources in the booking have changed.
- when the enhanced service profile ID has changed.

#### Improved handling of smart baseline parameter sets [ID_36997]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

The handling of smart baseline parameter sets in SLNet has improved in cases where a protocol is configured to receive a nominal value for a column parameter (using the Protocol.Params.Param.Alarm type attribute), and the column value to be set is of the "retrieved" type, as configured in the ColumnOption type of the parameter to be set (i.e. the alarm tag `<Alarm Type="absolute:2,3">` is defined for the column parameter, and the ColumnOption type of the parameter is "retrieved"). In those cases, the parameter sets are now done in sets of at most 5000 at once, which will greatly improve performance when setting smart baselines for large tables.

In addition, a write parameter is no longer needed in this scenario. Previously, if there was no write parameter, it was not possible to update the stored baseline value. Now if a write parameter is present, it will be used to set the values in case of single parameter sets.

#### Security enhancements [ID_37064] [ID_37094]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

A number of security enhancements have been made.

### Fixes

#### DataMiner upgrade failed because prerequisites check incorrectly marked Agent as failed [ID_36776]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

In some cases, it could occur that the prerequisites check that is performed at the start of a DataMiner upgrade incorrectly marked an Agent as failed, which caused the upgrade to fail.

#### Connection timed out while waiting for upgrade package upload to all DMAs [ID_36866]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

At the start of a DataMiner upgrade in a cluster, first the upload of the upgrade package cascades through the cluster: the package is uploaded to the DMA the client is connected to, then it is forwarded to the other DMAs in the cluster, and if one of these is a Failover pair, the online DMA in turn forwards the package to the offline DMA. The upload is only considered complete when the first DMA has uploaded the package and received confirmation from all other DMAs.

However, when the upload happened too slowly, it could occur that the connection timed out. Now, as long as the upgrade is progressing, the upload will not time out.

#### Issues related to NT_FILL_ARRAY_WITH_COLUMN_ONLY_UPDATES (336) notifications sent to SLDataMiner [ID_36973]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

A number of issues related to NT_FILL_ARRAY_WITH_COLUMN_ONLY_UPDATES (336) notifications sent to SLDataMiner have been resolved:

- Up to now, these notifications were only able to handle one column at a time. Now they can handle multiple columns.
- A small memory leak could occur when a NT_FILL_ARRAY_WITH_COLUMN_ONLY_UPDATES notification was sent to SLDataMiner with invalid data.
- If the user sending such a notification did not have sufficient rights on the element, or if the element was locked by another user, this did not cause this notification to fail. Now it will fail. This same issue has also been resolved for the NT_DELETE_ROW (156), NT_ADD_ROW (149), and NT_ADD_ROW_RETURN_KEY (240) notifications.

#### NATS configuration inconsistent in Failover setup after reconfiguring NATS [ID_37023]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

Up to now, the offline DMA in a Failover pair built its NATS configuration by fetching the nodes from the online DMA. In case the online DMA could not communicate with the rest of the cluster, this caused the offline DMA to also mark all other DMAs as unreachable. This meant that when NATS was reconfigured, even when the offline DMA was actually able to reach them, these "unreachable" DMAs were excluded from its routes. Moreover, as the offline DMA cannot generate alarms, there would be no notification of this until it was switched to online.

This will now be prevented. The offline DMA will now collect all nodes locally when setting up its NATS configuration instead of fetching them from the online DMA.

#### Cassandra Cluster Migrator tool would incorrectly not migrate any logger tables [ID_37083]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

The Cassandra Cluster Migrator tool would incorrectly not migrate any logger tables.
