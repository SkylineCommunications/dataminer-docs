---
uid: General_Main_Release_10.6.0_CU2
---

# General Main Release 10.6.0 CU2 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
>
> Before you upgrade to this DataMiner version:
>
> - Make sure **version 14.44.35211.0** or higher of the **Microsoft Visual C++ x86/x64 redistributables** is installed. Otherwise, the upgrade will trigger an **automatic reboot** of the DMA in order to complete the installation. The latest version of the redistributables can be downloaded from the [Microsoft website](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version):
>
>   - [vc_redist.x86.exe](https://aka.ms/vs/17/release/vc_redist.x86.exe)
>   - [vc_redist.x64.exe](https://aka.ms/vs/17/release/vc_redist.x64.exe)

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.6.0 CU2](xref:Cube_Main_Release_10.6.0_CU2).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.6.0 CU2](xref:Web_apps_Main_Release_10.6.0_CU2).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Changes

### Enhancements

#### SLDataGateway will now log when the TTLs of all active alarms have been refreshed [ID 44771]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

On systems where each DMA has its own Cassandra database, SLDataGateway will now log when the TTLs of all active alarms have been refreshed. This will allow you to better trace any job queue spikes caused by these refresh operations.

#### Security enhancements [ID 44898]

<!-- 44898: MR 10.6.0 [CU2] - FR 10.6.5 -->

A number of security enhancements have been made.

### Fixes

#### One protocol thread would incorrectly be able to add new rows to a table while another protocol thread was clearing that table [ID 44764] [ID 44833]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

Up to now, in some rare cases, while a table was being cleared by one protocol thread, another protocol thread could be adding rows to that same table. As a result, these newly added rows would immediately get cleared as well.

From now on, it will no longer be possible for one protocol thread to add new rows to a table while another protocol thread is clearing that same table. Only when the clear operation has finished will it be possible to add new rows again.

Also, up to now, a clear action would incorrectly be able to set the iRows field of the array to 0 without taking the write lock. As a result, SLProtocol would lose count of the number of rows that were stored in the table and would not be able to clear any of those rows without an element restart.

#### Service & Resource Management: Quarantine conflict error data would incorrectly include all quarantined usages of the affected bookings [ID 44869]

<!-- MR 10.6.0 [CU2] - FR 10.6.5 -->

Up to now, when a resource update triggered quarantine, in some cases, the conflict error data would incorrectly include all quarantined usages of the affected bookings, not just the ones caused by the current update.

From now on, the conflict error data will only include the quarantined usages of the resource that was updated.

#### Business intelligence: Active alarms table would not be updated when an alarm with 0% impact was cleared [ID 44892]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

Up to now, the SLA cleaning thread would incorrectly remove history data for an active alarm that was not linked to an outage. As a result, when a replay happened, the active alarms table would no longer be updated when that alarm was cleared.

#### Updating DVE properties could cause SLDMS to stop working [ID 44921]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

When DVE properties were being updated, in some cases, the SLDMS process could stop working when it was not aware of the element.
