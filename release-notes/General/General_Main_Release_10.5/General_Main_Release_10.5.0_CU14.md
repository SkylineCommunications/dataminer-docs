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

#### SLLogCollector packages will now include the 'Security.evtx' file [ID 44845]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

From now on, each time an SLLogCollector package is created, it will include the *Security.evtx* file.

This file, located in `%SystemRoot%\System32\winevt\Logs\`, is the primary Windows Event Log file recording security-related events, such as logon attempts, privilege usage, and object access.

#### SLWatchDog2.txt will now contain more detailed logging regarding run-time errors [ID 44904]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

From now on, the *SLWatchDog2.txt* log file will contain more detailed logging regarding run-time errors.

#### BrokerGateway DxM has been upgraded to Microsoft .NET 10 [ID 44979]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

The BrokerGateway DxM has been upgraded to Microsoft .NET 10.

#### StorageModule DxM has been upgraded to Microsoft .NET 10 [ID 45006]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

The StorageModule DxM has been upgraded to Microsoft .NET 10.

#### 'Functions' and 'Helper' folders will no longer be checked when protocols are being loaded [ID 44946]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

Before a DataMiner Agent starts loading protocol files during startup, it checks the protocol version folders to determine the location of all protocol files to be loaded. When a version folder does not contain any protocol files, it will log the following error: `Directory found for protocol xxx with version yyy but no protocol file found in path.`

Up to now, apart from the protocol version folders, the DataMiner Agent would also incorrectly check the *Functions* and *Helper* folders. However, as these folders do not contain any protocol files, this would result in a large number of invalid errors being logged.

From now on, when DataMiner starts up, it will no longer check for protocol files in the *Functions* and *Helper* folders.

#### Correlation: Enhanced detection of circular correlation rules [ID 45007]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

A number of enhancements have been made to the mechanism that detects circular correlation rules.

A correlation rule will be blocked when it was triggered due to a correlated alarm that depends on an alarm created by the rule in question.

> [!NOTE]
> ​This feature only works when the correlation rule and all alarms in question reside on the same DataMiner Agent.

### Fixes

#### Problem when importing a dmimport package containing an element that generates DVE elements running a production version of the protocol with alarm templates configured on the DVEs [ID 44398]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

When you imported a dmimport package containing an element that generates DVE elements running a production version of the protocol with alarm templates configured on the DVEs, up to now, the alarm templates on the DVE elements would incorrectly not be available because they were imported on the reference version instead of the production version.

#### One protocol thread would incorrectly be able to add new rows to a table while another protocol thread was clearing that table [ID 44764] [ID 44833]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

Up to now, in some rare cases, while a table was being cleared by one protocol thread, another protocol thread could be adding rows to that same table. As a result, these newly added rows would immediately get cleared as well.

From now on, it will no longer be possible for one protocol thread to add new rows to a table while another protocol thread is clearing that same table. Only when the clear operation has finished will it be possible to add new rows again.

Also, up to now, a clear action would incorrectly be able to set the iRows field of the array to 0 without taking the write lock. As a result, SLProtocol would lose count of the number of rows that were stored in the table and would not be able to clear any of those rows without an element restart.

#### Check Time Server BPA test would only work correctly on systems on which the language was set to English [ID 44837]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

Up to now, the *Check Time Server* BPA test would only work correctly on systems on which the language was set to English.

Also, the time checking algorithm would be too restrictive.

#### Business intelligence: Active alarms table would not be updated when an alarm with 0% impact was cleared [ID 44892]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

Up to now, the SLA cleaning thread would incorrectly remove history data for an active alarm that was not linked to an outage. As a result, when a replay happened, the active alarms table would no longer be updated when that alarm was cleared.

#### Native MessageBroker clients would not order the IP addresses in SLCloud.xml correctly [ID 44901]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

Up to now, native MessageBroker clients would not order the IP addresses in *SLCloud.xml* correctly. From now on, local IP addresses will again be put at the top of the list.

#### Alarm severity change within two minutes after an element start or restart would be processed incorrectly [ID 44917]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

When the alarm severity of an element changed within two minutes after the element had been started or restarted, up to now, that change would be processed incorrectly.

#### Updating DVE properties could cause SLDMS to stop working [ID 44921]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

When DVE properties were being updated, in some cases, the SLDMS process could stop working when it was not aware of the element.

#### SLDataGateway: Problem with custom data table check [ID 44933]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

When SLDataGateway checked whether a certain custom database table existed, up to now, that check would incorrectly return false when the table in question already existed before DataMiner was started.

#### SLElement: Uninitialized memory could cause memory corruption [ID 45004]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

In some cases, uninitialized memory in SLElement could cause memory corruption.

#### Names of DVE elements created with the noelementprefix option would be empty [ID 45014]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

Up to now, when a DVE manager generated DVE elements with the `noelementprefix` option, in some cases, the name of these elements would incorrectly be empty.

#### SLSNMPAgent would not properly unregister itself with SLWatchDog during a DataMiner shutdown [ID 45023]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

Up to now, when DataMiner was shutting down, SLSNMPAgent would not properly unregister itself with SLWatchDog. This lead to a false alarm as SLWatchDog incorrectly thought that the process had crashed.

From now on, when SNMPAgent shuts down, it will unregister itself with SLWatchDog.

#### GetProtocolInfoResponseMessage.FindParameter method would not be thread-safe [ID 45035]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

Up to now, the `GetProtocolInfoResponseMessage.FindParameter` method would not be thread-safe. Using this method in different threads at the same time could lead to simultaneous access and modification of the underlying parameter cache, causing the following exception to be thrown:

`Operations that change non-concurrent collections must have exclusive access. A concurrent update was performed on this collection and corrupted its state. The collection's state is no longer correct.`

#### Nats-server would incorrectly not be installed alongside BrokerGateway when no DataMiner software had been installed on the system [ID 45049]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

When BrokerGateway was installed on a system on which no DataMiner software had been installed, up to now, nats-server would incorrectly not be installed automatically because certain required DataMiner files were missing.

From now on, nats-server will correctly be installed alongside BrokerGateway.

#### APIGateway: '/api/versions' endpoint could return null as SLNet version [ID 45051]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

In some rare cases, the `/api/versions` endpoint exposed by DataMiner APIGateway could return "null" as SLNet version, especially after the *SLNet.exe* file had been updated on disk during a DataMiner upgrade.

#### Swarming: Problem when StorageModule failed to load elements from the database during DataMiner startup [ID 45067]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

When, on swarming-enabled systems, the StorageModule DxM failed to load elements from the database during DataMiner startup, up to now, the error state would incorrectly not be propagated to SLDataMiner, causing the DataMiner Agent to start up without loaded elements.

#### Subsequent element updates could fail after the casing of the element name had been changed [ID 45119]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

When, on a system on which Swarming was not enabled, you changed the casing of an element name and then restarted the element, in some cases, the next time you updated that element, the update would fail.
