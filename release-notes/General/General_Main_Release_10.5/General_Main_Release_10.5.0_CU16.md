---
uid: General_Main_Release_10.5.0_CU16
---

# General Main Release 10.5.0 CU16 - Preview

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
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.5.0 CU16](xref:Cube_Main_Release_10.5.0_CU16).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.5.0 CU16](xref:Web_apps_Main_Release_10.5.0_CU16).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Changes

### Enhancements

#### OpenSearch: Enhanced health monitoring [ID 45294]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->
<!-- Re-introduction of RN 43951, which was reverted by RN 44647 in 10.6.2 CU1 -->

A number of enhancements have been made with regard to health monitoring of OpenSearch databases.

Also, all logging with regard to OpenSearch health monitoring can now be found in *SLSearchHealth.txt*. Up to now, that logging was added to *SLCassandraHealth.txt*.

#### Alarm cache: Enhanced retrieval of alarms that are not linked to a specific element [ID 45322]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

Up to now, in some cases, DataMiner would not be able to retrieve alarms from the alarm cache when those alarms were not linked to a specific element. As a result, it had to retrieve them from the database instead.

This has now been improved so those alarms are correctly retrieved from memory when available.

#### APIGateway has been upgraded to Microsoft .NET 10 [ID 45421]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

The APIGateway module has been upgraded to Microsoft .NET 10.

#### Cleanup of replication buffer files [ID 45432]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

When replication buffering is enabled (which is the case by default), the replication buffers will now be cleaned every 24 hours.

During this cleanup, a check will be performed to find out whether the SLNet system cache contains any files that are no longer managed by the replication buffer and that have not been updated in the last 30 days (by default). If such files are found, they will be deleted.

In the *MaintenanceSettings.xml* file, a new setting has been added in the `<SLNet>` section: `<ReplicationBufferMaxDisconnectedTime>`. This setting will allow you to configure the number of days there must be no update to the replication buffer files before they can be deleted. By default, this setting will be set to 30 (day), but can be changed to a value between 14 (days) and 30 (days). If set to -1, automatic cleanup will be disabled.

Whether replication buffering is enabled or not, you can also configure a replication buffer cleanup using the SLNetClientTest tool. To do so, open the tool, and send a `DiagnoseMessage` with `ExtraInfo` set to "cleanup:`<numberOfDays>`", where `<numberOfDays>` is a value between 14 and 30. For example: `cleanup:20`.

> [!WARNING]
> Always be extremely careful when using SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### SLLogCollector will now collect the system environment variables [ID 45435]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

From now on, SLLogCollector will collect the system environment variables and store them in the `Windows\SystemEnvironmentVariables.txt` file.

#### VerifyNatsCluster prerequisite: Enhanced performance [ID 45475]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

Because of a number of enhancements, overall performance of the VerifyNatsCluster prerequisite has increased.

### Fixes

#### Elements incorrectly moved to root view after moving view with service containing those elements to view containing the original elements [ID 45286]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.6 -->

When a view containing a service was moved to another view, it could occur that elements included in that service were incorrectly moved to the root view. This happened when an element was only included in the original view because of the service, but the element already existed in the target view. This behavior has been corrected.

#### Problem when simulations were reloaded at runtime [ID 45296]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

When simulations were reloaded at runtime, in some cases, simulations that previously worked would no longer do so.

#### SLDataGateway would terminate unexpectedly when shutting down [ID 45419]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

In some cases, SLDataGateway would terminate unexpectedly when shutting down.

#### DataMiner upgrades could get stuck while running 'Register DataMiner as Service.bat' [ID 45426]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

In some rare cases, a DataMiner upgrade could get stuck while running the `C:\Skyline DataMiner\Tools\Register DataMiner as Service.bat` file.

#### SLAutomation could stop working when recompiling libraries [ID 45436]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.6 [CU0] -->

Up to now, in some cases, SLAutomation could stop working when recompiling libraries.

#### Element that failed to start up would not properly clean up the assigned resources [ID 45447]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

When an element failed to start up because of, for example, a faulty protocol.xml file, up to now, it would not properly clean up the assigned resources.

#### Automation: File locking issue could cause a deadlock when an automation script using memory files interacted with SLAutomation [ID 45520]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

In some cases, a file locking issue could cause a deadlock when an automation script using memory files interacted with SLAutomation while, on another thread, an attempt was being made to start another script using memory files.

#### Connector with redundant polling connections would incorrectly switch connections when executing a poll action group on an element in timeout [ID 45534]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

Up to now, a connector with redundant polling connections would incorrectly switch connections when executing a group of type "poll action" or "poll trigger" on an element that was in a timeout state. In some cases, this could lead to unexpected behavior.
