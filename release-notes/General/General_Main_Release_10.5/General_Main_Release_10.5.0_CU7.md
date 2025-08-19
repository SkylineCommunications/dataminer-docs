---
uid: General_Main_Release_10.5.0_CU7
---

# General Main Release 10.5.0 CU7 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.5.0 CU7](xref:Cube_Main_Release_10.5.0_CU7).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.5.0 CU7](xref:Web_apps_Main_Release_10.5.0_CU7).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

*No enhancements have been added yet.*

### Fixes

#### SLDataMiner issue after connection type of element changed [ID 43249]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

In some cases, a problem could occur in SLDataMiner when the connection type of an element changed. To prevent this, the validation of SNMPv3 usernames has now been improved.

#### Swarming: Problem when redundancy groups contained DVE child elements acting as primary or backup elements [ID 43286] [ID 43492]

<!-- MR 10.5.0 [CU7] - FR 10.5.10 -->

When Swarming was enabled, in some rare cases, SLDMS and SLDataMiner could get into a deadlock when the system contained redundancy groups in which DVE child elements acted as primary or backup elements.

#### Failed upgrade action because of duplicate keys for SNMPv3 elements [ID 43477]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.9 -->

In some cases, it could occur that the SyncInfo file contained duplicate keys for SNMPv3 elements, which would cause upgrade actions to fail with the following error message: `UpgradeAction failed:System.ArgumentException: An item with the same key has already been added.`
