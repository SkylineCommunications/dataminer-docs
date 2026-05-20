---
uid: General_Main_Release_10.6.0_CU4
---

# General Main Release 10.6.0 CU4 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.6.0 CU4](xref:Cube_Main_Release_10.6.0_CU4).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.6.0 CU4](xref:Web_apps_Main_Release_10.6.0_CU4).
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

#### OpenSearch: Enhanced health monitoring [ID 45294]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->
<!-- Re-introduction of RN 43951, which was reverted by RN 44647 in 10.6.2 CU1 -->

A number of enhancements have been made with regard to health monitoring of OpenSearch databases.

Also, all logging with regard to OpenSearch health monitoring can now be found in *SLSearchHealth.txt*. Up to now, that logging was added to *SLCassandraHealth.txt*.

#### DataMiner Agents will now translate the primary key to the display key when receiving timeline data requests from DataMiner Cube [ID 45355]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

When DataMiner Cube requests timeline data using a `GetReportTimeLineDataMessage`, it sends the primary key when referencing display column tables. However, for this type of table, the DataMiner Agent has to retrieve the data from the database using the display key.

From now on, when a DataMiner Agent receives a timeline data request, it will first translate the primary key to the display key before returning the requested data.

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

#### SLWatchDog: Problems when switching to and from daylight savings time [ID 45290]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

Because SLWatchDog tracked threads using local time, systems could run into issues when switching to and from daylight savings time:

- When switching away from daylight savings time, half-open runtime errors could incorrectly get cleared immediately.
- When switching to daylight savings time, runtime errors could be missed for an hour.

In addition, crash dumps would not be detected correctly either.

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

#### Problem with SLSNMPAgent after startup or while adding virtual IP addresses [ID 45441]

<!-- MR 10.6.0 [CU4] - FR 10.6.7 -->

Up to now, SLSNMPAgent could unexpectedly stop working either right after startup or while adding virtual IP addresses when traps were about to be sent.

#### Element that failed to start up would not properly clean up the assigned resources [ID 45447]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

When an element failed to start up because of, for example, a faulty protocol.xml file, up to now, it would not properly clean up the assigned resources.
