---
uid: General_Feature_Release_10.4.6_CU1
---

# General Feature Release 10.4.6 CU1

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!IMPORTANT]
> When downgrading from DataMiner Feature Release version 10.3.8 (or higher) to DataMiner Feature Release version 10.3.4, 10.3.5, 10.3.6 or 10.3.7, an extra manual step has to be performed. For more information, see [Downgrading a DMS](xref:MOP_Downgrading_a_DMS).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.4.6](xref:Cube_Feature_Release_10.4.6).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.4.6](xref:Web_apps_Feature_Release_10.4.6).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Changes

### Enhancements

#### DxM upgraded [ID 39803]

<!-- RN 39803: MR 10.5.0 - FR 10.4.6 [CU1] -->

The following DataMiner Extension Module (DxM), which is included in the DataMiner upgrade package, has been upgraded to the indicated version:

- DataMiner CoreGateway: version 2.14.7

For detailed information about the changes included in this version, refer to the [DxM release notes](xref:DxM_RNs_index).

### Fixes

#### Service & Resource Management: Deadlock when forcing quarantine during a booking update [ID 39755]

<!-- MR 10.5.0 - FR 10.4.6 [CU1] -->

After a quarantine had been forced during a booking update, in some cases, the SRM framework would stop responding.

See also: [Deadlock when forcing quarantine during booking update](xref:KI_Deadlock_when_forcing_quarantine)

#### Problem with SLProtocol after it had tried to read beyond the size of a table [ID 39829]

<!-- MR 10.5.0 - FR 10.4.6 [CU1] -->

In some cases, SLProtocol would stop working after it had tried to read beyond the size of a table.
