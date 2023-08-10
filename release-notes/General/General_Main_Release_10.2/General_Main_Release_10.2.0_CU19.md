---
uid: General_Main_Release_10.2.0_CU19
---

# General Main Release 10.2.0 CU19 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

*No enhancements have been added to this release yet.*

### Fixes

#### DataMiner upgrade failed because prerequisites check incorrectly marked Agent as failed [ID_36776]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

In some cases, it could occur that the prerequisites check that is performed at the start of a DataMiner upgrade incorrectly marked an Agent as failed, which caused the upgrade to fail.

#### Connection timed out while waiting for upgrade package upload to all DMAs [ID_36866]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

At the start of a DataMiner upgrade in a cluster, first the upload of the upgrade package cascades through the cluster: the package is uploaded to the DMA the client is connected to, then it is forwarded to the other DMAs in the cluster, and if one of these is a Failover pair, the online DMA in turn forwards the package to the offline DMA. The upload is only considered complete when the first DMA has uploaded the package and received confirmation from all other DMAs.

However, when the upload happened too slowly, it could occur that the connection timed out. Now, as long as the upgrade is progressing, the upload will not time out.

#### Dashboards app: Height of 'Data used in Dashboard' section would not be reduced when you deleted multiple components at once [ID_37032]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.9 -->

When, while in edit mode, you deleted multiple components at once, the *Data used in Dashboard* section of the edit pane would not be updated correctly. The data would be removed, but the height of the section would incorrectly not be reduced.

#### Dashboards app/Low-Code Apps: Visual glitch when closing component menu [ID_37058]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

When the menu of a component in a dashboard or low-code app was closed by moving the mouse pointer out of it at the bottom center, a visual glitch could occur where the menu appeared to rapidly open and close.
