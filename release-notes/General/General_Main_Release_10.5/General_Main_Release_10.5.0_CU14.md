---
uid: General_Main_Release_10.5.0_CU14
---

# General Main Release 10.5.0 CU14 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
> Before you upgrade to this DataMiner version:
>
> - Make sure the Microsoft **.NET 10** hosting bundle is installed (download the latest Hosting Bundle under ASP.NET Core Runtime from [dotnet.microsoft.com](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)). See also: [DataMiner upgrade: New prerequisite will check whether .NET 10 is installed](xref:General_Main_Release_10.5.0_CU10#dataminer-upgrade-new-prerequisite-will-check-whether-net-10-is-installed-id-44121).
> - Make sure **version 14.44.35211.0** or higher of the **Microsoft Visual C++ x86/x64 redistributables** is installed. Otherwise, the upgrade will trigger an **automatic reboot** of the DMA in order to complete the installation. The latest version of the redistributables can be downloaded from the [Microsoft website](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version):
>
>   - [vc_redist.x86.exe](https://aka.ms/vs/17/release/vc_redist.x86.exe)
>   - [vc_redist.x64.exe](https://aka.ms/vs/17/release/vc_redist.x64.exe)

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.5.0 CU14](xref:Cube_Main_Release_10.5.0_CU14).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.5.0 CU14](xref:Web_apps_Main_Release_10.5.0_CU14).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Changes

### Enhancements

#### SLLogCollector packages will now include the most recent WER crash dumps [ID 40754]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

Since DataMiner version 10.5.0 CU11/10.6.2, each time a DataMiner process crashes for whatever reason, a full WER crash dump is created in `C:\Skyline DataMiner\Logging\CrashDump\wer\<ExeName>\`.

From now on, each time an SLLogCollector package is created, it will include the most recent WER crash dump of every process found in the `C:\Skyline DataMiner\Logging\CrashDump\wer\` folder.

#### SLDataGateway will now log when the TTLs of all active alarms have been refreshed [ID 44771]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

On systems where each DMA has its own Cassandra database, SLDataGateway will now log when the TTLs of all active alarms have been refreshed. This will allow you to better trace any job queue spikes caused by these refresh operations.

### Fixes

#### One protocol thread would incorrectly be able to add new rows to a table while another protocol thread was clearing that table [ID 44764] [ID 44833]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

Up to now, in some rare cases, while a table was being cleared by one protocol thread, another protocol thread could be adding rows to that same table. As a result, these newly added rows would immediately get cleared as well.

From now on, it will no longer be possible for one protocol thread to add new rows to a table while another protocol thread is clearing that same table. Only when the clear operation has finished will it be possible to add new rows again.

Also, up to now, a clear action would incorrectly be able to set the iRows field of the array to 0 without taking the write lock. As a result, SLProtocol would lose count of the number of rows that were stored in the table and would not be able to clear any of those rows without an element restart.

#### Business intelligence: Active alarms table would not be updated when an alarm with 0% impact was cleared [ID 44892]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

Up to now, the SLA cleaning thread would incorrectly remove history data for an active alarm that was not linked to an outage. As a result, when a replay happened, the active alarms table would no longer be updated when that alarm was cleared.

#### Updating DVE properties could cause SLDMS to stop working [ID 44921]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

When DVE properties were being updated, in some cases, the SLDMS process could stop working when it was not aware of the element.
