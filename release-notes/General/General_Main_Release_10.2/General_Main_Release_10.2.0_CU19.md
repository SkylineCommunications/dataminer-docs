---
uid: General_Main_Release_10.2.0_CU19
---

# General Main Release 10.2.0 CU19 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Improved handling of smart baseline parameter sets [ID_36997]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

The handling of smart baseline parameter sets in SLNet has improved in cases where a protocol is configured to receive a nominal value for a column parameter (using the Protocol.Params.Param.Alarm type attribute), and the column value to be set is of the "retrieved" type, as configured in the ColumnOption type of the parameter to be set (i.e. the alarm tag `<Alarm Type="absolute:2,3">` is defined for the column parameter, and the ColumnOption type of the parameter is "retrieved"). In those cases, the parameter sets are now done in sets of at most 5000 at once, which will greatly improve performance when setting smart baselines for large tables.

In addition, a write parameter is no longer needed in this scenario. Previously, if there was no write parameter, it was not possible to update the stored baseline value. Now if a write parameter is present, it will be used to set the values in case of single parameter sets.

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

#### Dashboards app: Height of 'Data used in Dashboard' section would not be reduced when you deleted multiple components at once [ID_37032]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.9 -->

When, while in edit mode, you deleted multiple components at once, the *Data used in Dashboard* section of the edit pane would not be updated correctly. The data would be removed, but the height of the section would incorrectly not be reduced.

#### Dashboards app/Low-Code Apps: Visual glitch when closing component menu [ID_37058]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

When the menu of a component in a dashboard or low-code app was closed by moving the mouse pointer out of it at the bottom center, a visual glitch could occur where the menu appeared to rapidly open and close.
