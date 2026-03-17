---
uid: General_Main_Release_10.6.0_CU2
---

# General Main Release 10.6.0 CU2 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.6.0 CU2](xref:Cube_Main_Release_10.6.0_CU2).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.6.0 CU2](xref:Web_apps_Main_Release_10.6.0_CU2).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Prerequisites

Before you upgrade to this DataMiner version:

- Make sure **version 14.44.35211.0** or higher of the **Microsoft Visual C++ x86/x64 redistributables** is installed. Otherwise, the upgrade will trigger an **automatic reboot** of the DMA in order to complete the installation.

  The latest version of the redistributables can be downloaded from the [Microsoft website](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version):

  - [vc_redist.x86.exe](https://aka.ms/vs/17/release/vc_redist.x86.exe)
  - [vc_redist.x64.exe](https://aka.ms/vs/17/release/vc_redist.x64.exe)

- Make sure all DataMiner Agents in the cluster have been migrated to the BrokerGateway-managed NATS solution.

  For detailed information, see [Migrating to BrokerGateway](xref:BrokerGateway_Migration).

  See also: [DataMiner Systems will now use the BrokerGateway-managed NATS solution by default [ID 43526] [ID 43856] [ID 43861] [ID 44035] [ID 44050] [ID 44062]](xref:General_Main_Release_10.6.0_changes#dataminer-systems-will-now-use-the-brokergateway-managed-nats-solution-by-default-id-43526-id-43856-id-43861-id-44035-id-44050-id-44062)

## Changes

### Enhancements

#### SLLogCollector packages will now include the most recent WER crash dumps [ID 40754]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

Since DataMiner version 10.5.0 CU11/10.6.2, each time a DataMiner process crashes for whatever reason, a full WER crash dump is created in `C:\Skyline DataMiner\Logging\CrashDump\wer\<ExeName>\`.

From now on, each time an SLLogCollector package is created, it will include the most recent WER crash dump of every process found in the `C:\Skyline DataMiner\Logging\CrashDump\wer\` folder.

#### SLDataGateway will now log when the TTLs of all active alarms have been refreshed [ID 44771]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

On systems where each DMA has its own Cassandra database, SLDataGateway will now log when the TTLs of all active alarms have been refreshed. This will allow you to better trace any job queue spikes caused by these refresh operations.

#### SLLogCollector packages will now include the 'Security.evtx' file [ID 44845]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

From now on, each time an SLLogCollector package is created, it will include the *Security.evtx* file.

This file, located in `%SystemRoot%\System32\winevt\Logs\`, is the primary Windows Event Log file recording security-related events, such as logon attempts, privilege usage, and object access.

#### Security enhancements [ID 44898]

<!-- 44898: MR 10.6.0 [CU2] - FR 10.6.5 -->

A number of security enhancements have been made.

#### SLWatchDog2.txt will now contain more detailed logging regarding run-time errors [ID 44904]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

From now on, the *SLWatchDog2.txt* log file will contain more detailed logging regarding run-time errors.

### Fixes

#### One protocol thread would incorrectly be able to add new rows to a table while another protocol thread was clearing that table [ID 44764] [ID 44833]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

Up to now, in some rare cases, while a table was being cleared by one protocol thread, another protocol thread could be adding rows to that same table. As a result, these newly added rows would immediately get cleared as well.

From now on, it will no longer be possible for one protocol thread to add new rows to a table while another protocol thread is clearing that same table. Only when the clear operation has finished will it be possible to add new rows again.

Also, up to now, a clear action would incorrectly be able to set the iRows field of the array to 0 without taking the write lock. As a result, SLProtocol would lose count of the number of rows that were stored in the table and would not be able to clear any of those rows without an element restart.

#### Check Time Server BPA test would only work correctly on systems on which the language was set to English [ID 44837]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

Up to now, the *Check Time Server* BPA test would only work correctly on systems on which the language was set to English.

Also, the time checking algorithm would be too restrictive.

In addition, when multiple NTP servers are detected, the test will now verify whether those servers are peers of one another. If they are peers, the test will still succeed; if they are not peers, a warning will be generated.

#### Service & Resource Management: Quarantine conflict error data would incorrectly include all quarantined usages of the affected bookings [ID 44869]

<!-- MR 10.6.0 [CU2] - FR 10.6.5 -->

Up to now, when a resource update triggered quarantine, in some cases, the conflict error data would incorrectly include all quarantined usages of the affected bookings, not just the ones caused by the current update.

From now on, the conflict error data will only include the quarantined usages of the resource that was updated.

#### Business intelligence: Active alarms table would not be updated when an alarm with 0% impact was cleared [ID 44892]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

Up to now, the SLA cleaning thread would incorrectly remove history data for an active alarm that was not linked to an outage. As a result, when a replay happened, the active alarms table would no longer be updated when that alarm was cleared.

#### SNMP managers: Some configuration changes would not get properly synchronized across the Agents in the cluster [ID 44909]

<!-- MR 10.6.0 [CU2] - FR 10.6.5 -->

Up to now, when the configuration of an SNMP manager had been changed, in some cases, changes made to the following settings would not properly get synchronized across the Agents in the cluster:

- *Enable tracking to avoid duplicate inform acknowledgments (ACKs)*
- *Enable alarm storm prevention*

#### Updating DVE properties could cause SLDMS to stop working [ID 44921]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

When DVE properties were being updated, in some cases, the SLDMS process could stop working when it was not aware of the element.

#### SLDataGateway: Problem with custom data table check [ID 44933]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

When SLDataGateway checked whether a certain custom database table existed, up to now, that check would incorrectly return false when the table in question already existed before DataMiner was started.

#### Service & Resource Management: Certain bookings would incorrectly be quarantined when a range capacity was overbooked [ID 44940]

<!-- MR 10.6.0 [CU2] - FR 10.6.5 -->

Up to now, when a booking needed to be quarantined in order to solve a range capacity conflict, in some cases, certain usages that were not related to the conflict would incorrectly also be quarantined.
