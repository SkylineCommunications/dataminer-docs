---
uid: General_Feature_Release_10.3.10
---

# General Feature Release 10.3.10 – Preview

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

*No highlights have been added to this release yet.*

## Other features

*No other features have been added to this release yet.*

## Changes

### Enhancements

#### Service & Resource Management: Changing the 'IsValueCopy' property of a ProfileInstance will no longer be allowed [ID_31189]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

For each ProfileInstance, an `isValueCopy` property can be set:

- When set to false, the ProfileInstance will be added to a primary index.
- When set to true, the ProfileInstance will be added to a secondary index and will be assigned a TTL of 1 year (see note below).

From now on, it will no longer be allowed to change the `IsValueCopy` property of a ProfileInstance from true to false or vice versa. If such an attempt is made, a *ProfileManagerError* will be returned in the trace data with reason *ProfileInstanceChangedType*.

Also, in DataMiner Cube, the *By value/By reference* toggle button has now been removed from the *Profiles* App. Profile instances created using Cube will now always be created *by reference*.

> [!NOTE]
> When the `isValueCopy` property of a ProfileInstance is set to true, it will only be assigned a TTL of 1 year when that ProfileInstance is stored in Elasticsearch.

#### Updated bookings now only set to Confirmed when necessary [ID_36818]

<!-- MR 10.3.0 [CU7] - FR 10.3.10 -->

Up to now, bookings were always set to Confirmed again when they were updated, even though this is not always necessary. As such, bookings will now only be set to Confirmed again when this is actually needed, i.e.:

- When the new status of the booking is not the same as the old status.
- When the start or end time is no longer the same.
- When the resources in the booking have changed.
- when the enhanced service profile ID has changed.

#### Service & Resource Management: Improved ResourceManager logging [ID_36989]

<!-- MR 10.4.0 - FR 10.3.10 -->

The ResourceManager logging (*SLResourceManager.txt*) has been improved to make debugging easier.

Some log entries have been rewritten to make them clearer, have been assigned another log level or have been removed entirely.

#### Improved handling of smart baseline parameter sets [ID_36997]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

The handling of smart baseline parameter sets in SLNet has improved in cases where a protocol is configured to receive a nominal value for a column parameter (using the Protocol.Params.Param.Alarm type attribute), and the column value to be set is of the "retrieved" type, as configured in the ColumnOption type of the parameter to be set (i.e. the alarm tag `<Alarm Type="absolute:2,3">` is defined for the column parameter, and the ColumnOption type of the parameter is "retrieved"). In those cases, the parameter sets are now done in sets of at most 5000 at once, which will greatly improve performance when setting smart baselines for large tables.

In addition, a write parameter is no longer needed in this scenario. Previously, if there was no write parameter, it was not possible to update the stored baseline value. Now if a write parameter is present, it will be used to set the values in case of single parameter sets.

#### DataMiner Object Models: Bulk deletion of history records when deleting a DOM instance [ID_37012]

<!-- MR 10.4.0 - FR 10.3.10 -->

Up to now, when a DOM instance was deleted, the associated HistoryChange records were removed one by one. From now on, when a DOM instance is deleted, its HistoryChange records will be deleted in bulk. This will greatly improve overall performance when deleting DOM instances, especially when they are deleted synchronously.

#### Automatic clean-up of C:\\Skyline DataMiner\\Upgrades\\Packages folder [ID_37033]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

After each DataMiner upgrade, up to now, the DataMiner upgrade package would be kept indefinitely in the `C:\Skyline DataMiner\Upgrades\Packages` folder.

From now on, after each DataMiner upgrade or DataMiner start-up, this folder will be cleaned up.

- When a DataMiner upgrade was successful, only the `progress.log` file for that particular upgrade will be kept.
- When a DataMiner upgrade failed, apart from the `progress.log` file, the [prerequisites](xref:Preparing_to_upgrade_a_DataMiner_Agent#prerequisites) will also be kept for debugging purposes.

#### Security enhancements [ID_37064] [ID_37094]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

A number of security enhancements have been made.

#### SLReset: Generation of NATS credentials will now also be logged in SLFactoryReset.txt [ID_37071]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

When the factory reset tool *SLReset.exe* was run, up to now, the generation of the NATS credentials would only be logged to the console. From now on, an entry will also be added to the *SLFactoryReset.txt* log file.

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

#### SLReset: Problem due to NATS being re-installed before cleaning up the 'C:\\Skyline DataMiner' folder [ID_37072]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

When you perform a factory reset by running *SLReset.exe*, NATS will automatically be re-installed.

Up to now, SLReset would re-install NATS **before** it cleaned up the `C:\Skyline DataMiner` folder. As, in some cases, this could cause unexpected behavior, SLReset will now re-install NATS **after** the file clean-up.

#### Failover: NATS servers would incorrectly use the virtual IP address of a Failover setup to establish the route to the online agent [ID_37073]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

When the NATS server builds the route connections to the agents in a Failover setup, in some cases, when establishing the route to the online agent, it would incorrectly use the virtual IP address of the Failover setup instead of the primary address of the online agent.

From now on, *NATS Custodian* will check whether the routes list contains any virtual IP addresses. If so, it will replace each virtual IP address with the correct primary address of the online agent.

#### Cassandra Cluster Migrator tool would incorrectly not migrate any logger tables [ID_37083]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

The Cassandra Cluster Migrator tool would incorrectly not migrate any logger tables.
