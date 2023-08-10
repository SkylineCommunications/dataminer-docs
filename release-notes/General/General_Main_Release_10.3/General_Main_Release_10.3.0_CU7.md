---
uid: General_Main_Release_10.3.0_CU7
---

# General Main Release 10.3.0 CU7 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Updated bookings now only set to Confirmed when necessary [ID_36818]

<!-- MR 10.3.0 [CU7] - FR 10.3.10 -->

Up to now, bookings were always set to Confirmed again when they were updated, even though this is not always necessary. As such, bookings will now only be set to Confirmed again when this is actually needed, i.e.:

- When the new status of the booking is not the same as the old status.
- When the start or end time is no longer the same.
- When the resources in the booking have changed.
- when the enhanced service profile ID has changed.

### Fixes

#### DataMiner upgrade failed because prerequisites check incorrectly marked Agent as failed [ID_36776]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

In some cases, it could occur that the prerequisites check that is performed at the start of a DataMiner upgrade incorrectly marked an Agent as failed, which caused the upgrade to fail.

#### Connection timed out while waiting for upgrade package upload to all DMAs [ID_36866]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

At the start of a DataMiner upgrade in a cluster, first the upload of the upgrade package cascades through the cluster: the package is uploaded to the DMA the client is connected to, then it is forwarded to the other DMAs in the cluster, and if one of these is a Failover pair, the online DMA in turn forwards the package to the offline DMA. The upload is only considered complete when the first DMA has uploaded the package and received confirmation from all other DMAs.

However, when the upload happened too slowly, it could occur that the connection timed out. Now, as long as the upgrade is progressing, the upload will not time out.

#### Issues related to NT_FILL_ARRAY_WITH_COLUMN_ONLY_UPDATES (336) [ID_36973]

A number of issues related to the NT_FILL_ARRAY_WITH_COLUMN_ONLY_UPDATES (336) notify type have been resolved:

- Up to now, this notify type was only able to handle one column at a time. Now it can handle multiple columns.
- A small memory leak could occur when a NT_FILL_ARRAY_WITH_COLUMN_ONLY_UPDATES notification was sent to SLDataMiner with invalid data.
- If the user sending this notification did not have sufficient rights on the element, or if the element was locked by another user, this did not cause this notification to fail. Now it will fail. This same issue has also been resolved for the NT_DELETE_ROW (156), NT_ADD_ROW (149), and NT_ADD_ROW_RETURN_KEY (240) notifications.
