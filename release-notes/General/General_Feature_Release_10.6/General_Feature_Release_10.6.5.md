---
uid: General_Feature_Release_10.6.5
---

# General Feature Release 10.6.5 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.6.5](xref:Cube_Feature_Release_10.6.5).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.6.5](xref:Web_apps_Feature_Release_10.6.5).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Prerequisites

Before you upgrade to this DataMiner version:

- Make sure **version 14.44.35211.0** or higher of the **Microsoft Visual C++ x86/x64 redistributables** is installed. Otherwise, the upgrade will trigger an **automatic reboot** of the DMA in order to complete the installation.

  The latest version of the redistributables can be downloaded from the [Microsoft website](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version):

  - [vc_redist.x86.exe](https://aka.ms/vs/17/release/vc_redist.x86.exe)
  - [vc_redist.x64.exe](https://aka.ms/vs/17/release/vc_redist.x64.exe)

- Make sure all DataMiner Agents in the cluster have been migrated to the BrokerGateway-managed NATS solution.

  For detailed information, see [Migrating to BrokerGateway](xref:BrokerGateway_Migration).

  See also: [DataMiner Systems will now use the BrokerGateway-managed NATS solution by default [ID 43856] [ID 43861] [ID 44035] [ID 44050] [ID 44062]](xref:General_Feature_Release_10.6.1#dataminer-systems-will-now-use-the-brokergateway-managed-nats-solution-by-default-id-43856-id-43861-id-44035-id-44050-id-44062)

## Highlights

*No highlights have been selected yet.*

## New features

#### Automation: DEBUG preprocessor directive will now be added to a C# code block when you select the 'Compile in DEBUG mode' option [ID 44958]

<!-- MR 10.7.0 - FR 10.6.5 -->

From now on, when you select the *Compile in DEBUG mode* option in the *Advanced* section of a C# code block, a `DEBUG` preprocessor directive will automatically be added inside that code block. In that preprocessor directive, you can then add code that will only be compiled when in DEBUG mode.

```csharp
#if DEBUG
    engine.Log("This code is only compiled in DEBUG mode.");
#endif
```

## Changes

### Enhancements

#### SLLogCollector packages will now include the most recent WER crash dumps [ID 40754]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

Since DataMiner version 10.5.0 CU11/10.6.2, each time a DataMiner process crashes for whatever reason, a full WER crash dump is created in `C:\Skyline DataMiner\Logging\CrashDump\wer\<ExeName>\`.

From now on, each time an SLLogCollector package is created, it will include the most recent WER crash dump of every process found in the `C:\Skyline DataMiner\Logging\CrashDump\wer\` folder.

#### SLDataGateway will now log when the TTLs of all active alarms have been refreshed [ID 44771]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

On systems where each DMA has its own Cassandra database, SLDataGateway will now log when the TTLs of all active alarms have been refreshed. This will allow you to better trace any job queue spikes caused by these refresh operations.

#### Security enhancements [ID 44804] [ID 44898]

<!-- 44804: MR 10.7.0 - FR 10.6.5 -->
<!-- 44898: MR 10.6.0 [CU2] - FR 10.6.5 -->

A number of security enhancements have been made.

#### SLLogCollector packages will now include the 'Security.evtx' file [ID 44845]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

From now on, each time an SLLogCollector package is created, it will include the *Security.evtx* file.

This file, located in `%SystemRoot%\System32\winevt\Logs\`, is the primary Windows Event Log file recording security-related events, such as logon attempts, privilege usage, and object access.

#### SLWatchDog2.txt will now contain more detailed logging regarding run-time errors [ID 44904]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

From now on, the *SLWatchDog2.txt* log file will contain more detailed logging regarding run-time errors.

#### 'Functions' and 'Helper' folders will no longer be checked when protocols are being loaded [ID 44946]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

Before a DataMiner Agent starts loading protocol files during startup, it checks the protocol version folders to determine the location of all protocol files to be loaded. When a version folder does not contain any protocol files, it will log the following error: `Directory found for protocol xxx with version yyy but no protocol file found in path.`

Up to now, apart from the protocol version folders, the DataMiner Agent would also incorrectly check the *Functions* and *Helper* folders. However, as these folders do not contain any protocol files, this would result in a large number of invalid errors being logged.

From now on, when DataMiner starts up, it will no longer check for protocol files in the *Functions* and *Helper* folders.

#### BrokerGateway DxM has been upgraded to Microsoft .NET 10 [ID 44979]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

The BrokerGateway DxM has been upgraded to Microsoft .NET 10.

#### StorageModule DxM has been upgraded to Microsoft .NET 10 [ID 45006]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

The StorageModule DxM has been upgraded to Microsoft .NET 10.

#### Correlation: Enhanced detection of circular correlation rules [ID 45007]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

A number of enhancements have been made to the mechanism that detects circular correlation rules.

A correlation rule will be blocked when it was triggered due to a correlated alarm that depends on an alarm created by the rule in question.

> [!NOTE]
> ​This feature only works when the correlation rule and all alarms in question reside on the same DataMiner Agent.

#### Automation: Script library hint paths will only be sent to the script compilation engine the first time they are required [ID 45022]

<!-- MR 10.7.0 - FR 10.6.5 -->

Previously, when a script library was added to a DataMiner System, its hint paths were automatically sent to the automation script compilation engine, even when the library was not used by any automation script.

From now on, script library hint paths will only be sent to the automation script compilation engine the first time they are required, i.e., when a script referencing the library in question (either directly or via another library) is executed for the first time.

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

#### Service & Resource Management: Quarantine conflict error data would incorrectly include all quarantined usages of the affected bookings [ID 44869]

<!-- MR 10.6.0 [CU2] - FR 10.6.5 -->

Up to now, when a resource update triggered quarantine, in some cases, the conflict error data would incorrectly include all quarantined usages of the affected bookings, not just the ones caused by the current update.

From now on, the conflict error data will only include the quarantined usages of the resource that was updated.

#### Business intelligence: Active alarms table would not be updated when an alarm with 0% impact was cleared [ID 44892]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

Up to now, the SLA cleaning thread would incorrectly remove history data for an active alarm that was not linked to an outage. As a result, when a replay happened, the active alarms table would no longer be updated when that alarm was cleared.

#### Native MessageBroker clients would not order the IP addresses in SLCloud.xml correctly [ID 44901]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

Up to now, native MessageBroker clients would not order the IP addresses in *SLCloud.xml* correctly. From now on, local IP addresses will again be put at the top of the list.

#### SNMP managers: Some configuration changes would not get properly synchronized across the Agents in the cluster [ID 44909]

<!-- MR 10.6.0 [CU2] - FR 10.6.5 -->

Up to now, when an SNMP manager had been added, or its configuration had been changed, the following settings would not get properly synchronized across the Agents in the cluster. On the remote Agents, after synchronization, these two settings would incorrectly be set to their default value.

- *Enable tracking to avoid duplicate inform acknowledgments (ACKs)*
- *Group alarms with the same parameter name*

#### Alarm severity change within two minutes after an element start or restart would be processed incorrectly [ID 44917]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

When the alarm severity of an element changed within two minutes after the element had been started or restarted, up to now, that change would be processed incorrectly.

#### Updating DVE properties could cause SLDMS to stop working [ID 44921]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

When DVE properties were being updated, in some cases, the SLDMS process could stop working when it was not aware of the element.

#### SLDataGateway: Problem with custom data table check [ID 44933]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

When SLDataGateway checked whether a certain custom database table existed, up to now, that check would incorrectly return false when the table in question already existed before DataMiner was started.

#### Service & Resource Management: Certain bookings would incorrectly be quarantined when a range capacity was overbooked [ID 44940]

<!-- MR 10.6.0 [CU2] - FR 10.6.5 -->

Up to now, when a booking needed to be quarantined in order to solve a range capacity conflict, in some cases, certain usages that were not related to the conflict would incorrectly also be quarantined.

#### SLElement: Uninitialized memory could cause memory corruption [ID 45004]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

In some cases, uninitialized memory in SLElement could cause memory corruption.

#### SLSNMPAgent would not properly unregister itself with SLWatchDog during a DataMiner shutdown [ID 45023]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

Up to now, when DataMiner was shutting down, SLSNMPAgent would not properly unregister itself with SLWatchDog. This lead to a false alarm as SLWatchDog incorrectly thought that the process had crashed.

From now on, when SNMPAgent shuts down, it will unregister itself with SLWatchDog.

#### SLAnalytics: Flatline anomaly alerts would incorrectly not be triggered for parameters that are only updated once every 24 hours [ID 45033]

<!-- MR 10.7.0 - FR 10.6.5 -->

Up to now, flatline anomaly alerts would incorrectly not be triggered for parameters that are only updated once every 24 hours.

#### APIGateway: '/api/versions' endpoint could return null as SLNet version [ID 45051]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

In some rare cases, the `/api/versions` endpoint exposed by DataMiner APIGateway could return "null" as SLNet version, especially after the *SLNet.exe* file had been updated on disk during a DataMiner upgrade.

#### Swarming: Problem when StorageModule failed to load elements from the database [ID 45067]

<!-- MR 10.6.0 [CU2] - FR 10.6.5 -->

When, on swarming-enabled systems, the StorageModule DxM failed to load elements from the database, up to now, the error state would incorrectly not be propagated to SLDataMiner, causing the DataMiner Agent to start up without loaded elements.
