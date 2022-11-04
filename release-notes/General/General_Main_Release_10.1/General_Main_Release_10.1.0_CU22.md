---
uid: General_Main_Release_10.1.0_CU22
---

# General Main Release 10.1.0 CU22 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### DataMiner upgrade: Enhanced method to delete locked files [ID_34779]

<!-- MR 10.1.0 [CU22] / 10.2.0 [CU10] - FR 10.3.1 -->

When, during a DataMiner upgrade, an attempt was made to delete files that were locked by certain processes, up to now, that attempt would fail, causing those files to remain on the system until the next upgrade.

From now on, when an attempt to delete a file during a DataMiner upgrade fails, the extension of that file will be replaced by `.SLReplace` and, later on in the upgrade process, the file will then be deleted by SLHelper.

### Fixes

#### Standalone parameters belonging to another child of the same DVE parent element could be set to 'Not Initialized' when a row linked to a DVE child element was deleted [ID_34785]

<!-- MR 10.1.0 [CU22] / 10.2.0 [CU10] - FR 10.3.1 -->

When a row linked to a DVE child element was deleted, in some cases, standalone parameters belonging to another child of the same DVE parent element could be set to "Not Initialized".
