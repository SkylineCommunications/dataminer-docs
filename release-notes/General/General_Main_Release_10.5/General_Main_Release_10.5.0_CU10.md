---
uid: General_Main_Release_10.5.0_CU10
---

# General Main Release 10.5.0 CU10 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.5.0 CU10](xref:Cube_Main_Release_10.5.0_CU10).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.5.0 CU10](xref:Web_apps_Main_Release_10.5.0_CU10).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

*No enhancements have been added yet.*

### Fixes

#### SLNet: Information messages triggered in a QAction would incorrectly only be forwarded to the DMA hosting the element in question [ID 43958]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

When a QAction triggered an information message with regard to a particular element, SLNet would incorrectly only forward that message to the DataMiner Agent that hosted that element. As a result, that information message would not appear in client applications connected to any of the other DataMiner Agents in the system.

#### Failover: Problem when deleting an element with an empty name [ID 44005]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

When, on the offline Agent of a failover system, an element with an empty name was deleted, up to now, the entire `C:\Skyline DataMiner\Elements\` folder would incorrectly be deleted. As a result, after a failover switch, the Agent that had now become the online Agent would not have any elements.
