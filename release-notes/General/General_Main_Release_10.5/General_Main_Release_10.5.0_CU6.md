---
uid: General_Main_Release_10.5.0_CU6
---

# General Main Release 10.5.0 CU6 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.5.0 CU6](xref:Cube_Main_Release_10.5.0_CU6).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.5.0 CU6](xref:Web_apps_Main_Release_10.5.0_CU6).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

*No enhancements have been added yet.*

### Fixes

#### Service & Resource Management: Reservation ID of a service created from a service template would disappears when the template was re-applied [ID 43090]

<!-- MR 10.5.0 [CU6] - FR 10.5.9 -->

When a service created from a service template had a reservation ID defined, up to now, that reservation ID would incorrectly disappear when the service template was re-applied.

#### DataMiner upgrade: Redirect tags in DMS.xml would incorrectly not be taken into account [ID 43172]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When `<Redirect via="..." />` tags were configured in the *DMS.xml* file, these would incorrectly not be taken into account when an SLNet instance retrieved upgrade progress messages from another SLNet instance.

Although the upgrade would succeed in the background, no information regarding the remote agents would be available in DataMiner Cube or the DataMiner TaskBar Utility during the upgrade, and notices saying that `http://<ip>:8004/UpgradeService` was unavailable would be added to the logs.
