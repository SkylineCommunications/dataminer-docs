---
uid: General_Main_Release_10.3.0_CU6
---

# General Main Release 10.3.0 CU6 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### DataMiner upgrade: Presence of Visual C++ 2010 redistributable will no longer be checked [ID_36745]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

During a DataMiner upgrade, from now on, the presence of the Visual C++ 2010 redistributable will no longer be checked.

### Fixes

#### SNMPv3 credentials would not get deleted when an SNMPv3 element was deleted [ID_36573]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When an SNMPv3 element was deleted, its SNMPv3 credentials would incorrectly not get deleted. Also, when users were deleted, their DCP credentials would not get deleted.
