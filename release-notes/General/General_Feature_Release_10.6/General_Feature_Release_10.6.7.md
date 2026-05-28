---
uid: General_Feature_Release_10.6.7
---

# General Feature Release 10.6.7 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.6.7](xref:Cube_Feature_Release_10.6.7).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.6.7](xref:Web_apps_Feature_Release_10.6.7).
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

#### User-defined APIs: Token-based rate limiting [ID 45470]

<!-- MR 10.7.0 - FR 10.6.7 -->

API tokens can now be configured with a rate limit to control how frequently they can be used to trigger user-definable API endpoints.

A rate limit consists of:

- A limit: The maximum number of requests allowed within the configured time window. Supported range: 1 to 100
- A window: The time span in which the configured number of requests is allowed. Supported range: 1 second to 1 day

##### Behavior when the limit is exceeded

When the rate limit is exceeded, the *UserDefinableApiEndpoint* DxM will return an HTTP 429 message ("Too Many Requests").

In this case, the API trigger will not be forwarded to SLNet, and the API script will not be executed. The response message will indicate that the rate limit was exceeded and will include internal error code 1014.

Every request that can be linked to a token counts toward that token's rate limit, regardless of whether the request results in a successful API script trigger.

##### Sliding window behavior

Rate limiting uses a sliding window. This means that, when a request is received, the system checks how many requests were made with the same token during the preceding configured window. If the configured limit has already been reached within that period, the request is blocked.

For example, with a limit of 5 requests per 1 minute, a client using the token can trigger the API up to 5 times within any rolling 1-minute period.

Keep in mind that different limit/window combinations can result in different behavior, even when they allow the same average number of requests. See the following examples:

- Limit 10 and window 60 seconds: Bursts of up to 10 requests are allowed in a short time, after which the client must wait until requests fall outside the 60-second window.
- Limit 1 and window 6 seconds: The requests are spread more evenly, allowing 1 new request every 6 seconds.

##### Performance considerations

Configuring a high rate limit, such as 100 requests per second, does not guarantee that DataMiner can process that number of API triggers.

The actual throughput depends on factors such as API script runtime, server hardware, current system load, the number of agents in the cluster, and other system-specific conditions.

##### Configuration and API changes

A new `RateLimit` property has been added to the `ApiToken` class. This property can be used to define the `Limit` and `Window` values.

If an invalid rate limit is configured, an `ApiTokenError` with reason `InvalidRateLimit` will be returned. The new `Message` property on the error contains an English description of the invalid configuration.

Currently, rate limits cannot yet be configured in the UI, and must be configured via the C# API. If an API token with a configured rate limit is updated through the UI, the rate limit will be cleared.

##### Updating an existing rate limit

When an existing rate limit is changed, the updated limit is only applied after a next trigger both starts and finishes after the update has been applied.

If a long window was configured and the limit has already been reached, the client may need to wait until the window has passed before another trigger can be executed and the updated limit can take effect.

## Changes

### Enhancements

#### SLLogCollector: New option to collect DLL file information [ID 45044]

<!-- MR 10.7.0 - FR 10.6.7 -->

The SLLogCollector tool now has a new *Collect DLL info* option. If enabled, all packages will include the following information retrieved from all DLL files found in the `C:\Skyline DataMiner\Files` and `C:\Skyline DataMiner\ProtocolScripts` folders:

- Name
- Version
- Culture
- Public key
- Dependencies

By default, the Collect DLL info option is disabled.

#### OpenSearch: Enhanced health monitoring [ID 45294]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->
<!-- Re-introduction of RN 43951, which was reverted by RN 44647 in 10.6.2 CU1 -->

A number of enhancements have been made with regard to health monitoring of OpenSearch databases.

Also, all logging with regard to OpenSearch health monitoring can now be found in *SLSearchHealth.txt*. Up to now, that logging was added to *SLCassandraHealth.txt*.

#### Alarm cache: Enhanced retrieval of alarms that are not linked to a specific element [ID 45322]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

Up to now, in some cases, DataMiner would not be able to retrieve alarms from the alarm cache when those alarms were not linked to a specific element. As a result, it had to retrieve them from the database instead.

This has now been improved so those alarms are correctly retrieved from memory when available.

#### SLNetConnectionsMonitor.txt will now log all state changes of all SLNet connections [ID 45316]

<!-- MR 10.7.0 - FR 10.6.7 -->

Up to now, only the general state of the entire cluster when an Agent connected or disconnected would be logged in the *SLNetConnectionsMonitor.txt* file.

From now on, all state changes of all SLNet connections between Agents in the cluster will be logged in the *SLNetConnectionsMonitor.txt* file.

#### Automation: Enhanced memory usage when compiling development packs and script libraries [ID 45333]

<!-- MR 10.7.0 - FR 10.6.7 -->

Because of a number of enhancements, memory usage has improved when compiling development packs and script libraries.

#### Service template definitions will no longer be stored alongside services [ID 45370]

<!-- MR 10.7.0 - FR 10.6.7 -->

Up to now, service templates were stored alongside services in the `C:\Skyline DataMiner\Services` and `C:\Skyline DataMiner\RemoteServices` folders. Each service template also had exactly one DataMiner Agent actively hosting the service template.

In preparation of service swarming, service template definitions have now been moved into a new `C:\Skyline DataMiner\ServiceTemplates` folder, which will be synchronized across the cluster. A service template no longer has a dedicated hosting agent, which means that they now remain available even if DataMiner Agents are down.

#### SLAnalytics: Enhanced performance when detecting flatline events [ID 45376]

<!-- MR 10.7.0 - FR 10.6.7 -->

Because of a number of enhancements, overall performance has increased when detecting flatline events, especially on systems with a large number of monitored parameters.

#### DxMs upgraded [ID 45392] [ID 45506]

<!-- RN 45392: MR 10.7.0 - FR 10.6.7 -->
<!-- RN 45506: MR 10.7.0 - FR 10.6.7 -->

The following DataMiner Extension Modules (DxMs), which are included in the DataMiner upgrade package, have been upgraded to the indicated versions:

- DataMiner CloudGateway 3.1.0

For detailed information about the changes included in those versions, refer to the [DxM release notes](xref:DxM_RNs_index).

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

#### Standalone BPA Executor will now return exit code 1 or 2 when issues were detected [ID 45433]

<!-- MR 10.7.0 - FR 10.6.7 -->

Up to now, the *Standalone BPA Executor* tool would always return exit code 0, regardless of whether the BPA tests it had run had detected any issues. In situations where the tool had been integrated into another process (e.g., a DataMiner upgrade, an SLLogCollector run, etc.), this would make it hard to determine whether a BPA test had failed or not.

From now on, the *Standalone BPA Executor* tool will return one of the following exit codes when issues were detected:

| Exit code | Description |
|---|---|
| 1 | Unexpected errors have occurred. |
| 2 | BPA tests have detected issues. |

#### SLLogCollector will now collect the system environment variables [ID 45435]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

From now on, SLLogCollector will collect the system environment variables and store them in the `Windows\SystemEnvironmentVariables.txt` file.

#### VerifyNatsCluster prerequisite: Enhanced performance [ID 45475]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

Because of a number of enhancements, overall performance of the VerifyNatsCluster prerequisite has increased.

### Fixes

#### Problem when simulations were reloaded at runtime [ID 45296]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

When simulations were reloaded at runtime, in some cases, simulations that previously worked would no longer do so.

#### SLDataGateway would terminate unexpectedly when shutting down [ID 45419]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

In some cases, SLDataGateway would terminate unexpectedly when shutting down.

#### DataMiner upgrades could get stuck while running 'Register DataMiner as Service.bat' [ID 45426]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

In some rare cases, a DataMiner upgrade could get stuck while running the `C:\Skyline DataMiner\Tools\Register DataMiner as Service.bat` file.

#### Problem with SLSNMPAgent after startup or while adding virtual IP addresses [ID 45441]

<!-- MR 10.6.0 [CU4] - FR 10.6.7 -->

Up to now, SLSNMPAgent could unexpectedly stop working either right after startup or while adding virtual IP addresses when traps were about to be sent.

#### Element that failed to start up would not properly clean up the assigned resources [ID 45447]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

When an element failed to start up because of, for example, a faulty protocol.xml file, up to now, it would not properly clean up the assigned resources.

#### Automation: File locking issue could cause a deadlock when an automation script using memory files interacted with SLAutomation [ID 45520]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

In some cases, a file locking issue could cause a deadlock when an automation script using memory files interacted with SLAutomation while, on another thread, an attempt was being made to start another script using memory files.

#### Connector with redundant polling connections would incorrectly switch connections when executing a poll action group on an element in timeout [ID 45534]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

Up to now, a connector with redundant polling connections would incorrectly switch connections when executing a group of type "poll action" or "poll trigger" on an element that was in a timeout state. In some cases, this could lead to unexpected behavior.
