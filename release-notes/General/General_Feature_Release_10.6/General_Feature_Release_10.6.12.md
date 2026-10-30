---
uid: General_Feature_Release_10.6.12
description: "Release notes for General Feature Release 10.6.12, including prerequisites, new features, enhancements, and fixes planned for this preview release."
---

# General Feature Release 10.6.12 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.6.12](xref:Cube_Feature_Release_10.6.12).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.6.12](xref:Web_apps_Feature_Release_10.6.12).
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

## Important changes

*No important changes have been selected yet.*

## Highlights

*No highlights have been selected yet.*

## New features

### Interactive Automation scripts: New WebUILayout property [ID 46602]

<!-- MR 10.7.0 - FR 10.6.12 -->

From now on, you can select the web UI layout for each dialog in an interactive Automation script using the `UIBuilder.WebUILayout` property.

For example:

```csharp
var uiBuilder = new UIBuilder
{
    WebUILayout = WebUILayout.Grid
};
```

The following values are supported:

- `Default` and `Table`: Components are arranged in a table. TAB navigation proceeds from left to right across each row before moving to the next row.
- `Grid`: Selects a CSS Grid layout that keeps visual placement independent of keyboard navigation. The order in which blocks are added to the `UIBuilder` determines the TAB order. To navigate through one column before continuing to the next, add the blocks from top to bottom in the first column, followed by the blocks in the next column.

If you do not set this property, `Default` is used, preserving the existing table layout and navigation behavior. Existing scripts therefore continue to behave as before.

> [!NOTE]
> Support for the `Grid` layout in the DataMiner web apps will be introduced separately.

### New BPA test: DataMiner Agent Versions [ID 46808]

<!-- MR 10.7.0 - FR 10.6.12 -->

A new BPA test, *DataMiner Agent Versions*, now runs daily to check whether all DataMiner Agents in the cluster are running the same DataMiner version. The check also includes offline Failover Agents.

The test fails if it detects different versions. If the information required for the check is missing or incomplete, the result is inconclusive. In both cases, the output includes details.

## Changes

### Enhancements

#### DataMiner Installer: Initial DataMiner configuration wizard has been redesigned [ID 45483]

<!-- MR 10.7.0 - FR 10.6.12 -->

The initial DataMiner configuration wizard has been redesigned to guide you through selecting a commercial model, configuring storage, and connecting to dataminer.services.

You can now follow this setup flow:

1. Select a commercial model: Community Edition, usage-based services, or a perpetual-use license with a supplied DataMiner ID.

   Community Edition requires acceptance of its terms.

1. Choose Storage as a Service (STaaS), locally hosted storage, or externally hosted storage.

1. Connect to dataminer.services when required.

   The wizard will open a browser where you can sign in or create an account. Connection is required for Community Edition, usage-based services, and STaaS. For perpetual-use licenses with self-hosted storage, cloud registration is optional.

1. Complete the applicable configuration details and review the setup.

   Only the pages relevant to your selected configuration will be shown.

1. Apply the configuration.

   The wizard will report progress and stop if a configuration step fails.

The cloud registration page provides options to reopen the sign-in page, retry registration, or refresh registration details.

For perpetual-use licensing, you can supply an existing license file or generate a license request. License requests can now be generated without first starting and stopping DataMiner. Missing required configuration files are initialized automatically, preventing setup failures on fresh installations.

Unattended configuration remains available for subscription and perpetual-use licensing. Passing a configuration file path containing spaces from the installer is now also handled correctly.

#### DataMiner Installer: Improved licensing registration and separate database TLS settings [ID 45881]

<!-- MR 10.7.0 - FR 10.6.12 -->

During interactive setup, licensing registration now uses licensing API v2 with a bearer token obtained through CloudGateway instead of an organization API key. You authenticate in your browser, after which the wizard obtains the token and completes registration. Token acquisition is retried for up to two minutes with increasing delays between attempts.

After successful registration, DataMiner restarts automatically and its startup is validated. The wizard no longer asks for an organization API key, system URL, administrator email address, or STaaS region.

Cloud registration now uses a complete session URL provided by CloudGateway, with improved session tracking and browser authentication. The sign-in screen now displays the DataMiner logo instead of a globe icon.

For externally hosted databases, separate TLS checkboxes now allow you to enable TLS independently for Cassandra and OpenSearch. Previously, both databases shared the same TLS setting. The corresponding properties are `CassandraTlsEnabled` and `OpenSearchTlsEnabled`.

#### DataMiner backup: A default description is now generated when no description is specified [ID 46206]

<!-- MR 10.7.0 - FR 10.6.12 -->

When you create a backup without specifying a description, DataMiner will now generates one automatically.

The description will include the name of the predefined backup setting and the DataMiner ID, matching the behavior of the DataMiner Taskbar Utility.

#### SLScripting executable and dependencies now stored in a separate folder [ID 46346]

<!-- MR 10.7.0 - FR 10.6.12 -->

The *SLScripting.exe* executable and its dependencies are now stored in `C:\Skyline DataMiner\Files\SLScripting\x86` instead of `C:\Skyline DataMiner\Files`.

This reduces the risk of QActions loading assemblies from `C:\Skyline DataMiner\Files` instead of using the assemblies provided by their specific NuGet dependencies.

If an assembly cannot be found, `C:\Skyline DataMiner\Files` is still used as a fallback folder.

#### Service & Resource Management: 'Unavailable' resource mode is now obsolete in SLNetTypes [ID 46492]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

The `Unavailable` resource mode in `SLNetTypes.dll` is now marked as obsolete.

It remains in the enum for backward compatibility, but using it will produce a compiler warning, and it will no longer appear in IntelliSense suggestions. The warning will recommend `Maintenance` instead.

#### ClusterEndpointsManager soft-launch option is now always enabled [ID 46538]

<!-- MR 10.6.0 [CU9] - FR 10.6.12 -->

From now on, the *ClusterEndpointsManager* soft-launch option will always be enabled, regardless of the soft-launch configuration.

#### SLLogCollector now lists files in the Scripts folder [ID 46545]

<!-- MR 10.7.0 - FR 10.6.12 -->

Log Collector packages now include a `Scripts.txt` file listing the files in `C:\Skyline DataMiner\Scripts` and its subfolders, excluding `.txf` files. For each file, it includes the creation date as recorded on the system and the last modified date.

#### STaaS traffic can now use a single IP address [ID 46570]

<!-- MR 10.7.0 - FR 10.6.12 -->

All STaaS traffic from DataGateway will now pass through a single endpoint per region. This will allow you to whitelist a single IP address for STaaS traffic.

If this single endpoint is not reachable, DataMiner will continue to use the existing endpoints.

#### SLLogCollector now collects additional Elasticsearch and OpenSearch cluster information [ID 46618]

<!-- MR 10.7.0 - FR 10.6.12 -->

SLLogCollector now collects additional diagnostic information from configured Elasticsearch and OpenSearch clusters, including aliases, shard health and placement, disk allocation, cluster settings, ongoing recoveries, and pending cluster tasks.

The generated package now includes the following files in the `Elastic` folder for the configured database cluster:

- `_cat.aliases.txt`
- `_cat.shards.txt`
- `_cat.allocation.txt`
- `_cluster.settings.json`
- `_cat.recovery.txt`
- `_cat.pending_tasks.txt`

#### Security enhancements [ID 46665]

<!-- 46665: MR 10.7.0 - FR 10.6.12 -->

A number of security enhancements have been made.

#### BrokerGateway: HTTPS communication now supports redirects [ID 46687]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

BrokerGateway now takes redirects configured in *DMS.xml* into account when communicating over HTTPS. This allows the required API calls to work as intended in manually configured setups.

> [!NOTE]
> NATS communication does not take redirects into account.

#### Protocol: NotifyDataMiner(Queued) failures are now logged without internal offsets [ID 46709]

<!-- MR 10.7.0 - FR 10.6.12 -->

When a `NotifyDataMiner(Queued)` method invoked through the `SLProtocol` interface failed, up to now, the log included the internal offset added to the notify type.

From now on, the log will show the original notify type without the offset.

#### STaaS: Support for direct-write-only entity types [ID 46711]

<!-- MR 10.7.0 - FR 10.6.12 -->

DataGateway can now handle STaaS entity types configured for direct writes only, without an Event Hub configuration. This allows blob storage data types to be written directly through the Ingest API instead of Event Hub.

#### Automation: Clearer error messages when saving scripts [ID 46713]

<!-- MR 10.7.0 - FR 10.6.12 -->

Error messages returned when saving an automation script now provide more details about what went wrong.

For example, when you import a script in DataMiner Cube and a dummy references an unavailable protocol or protocol version, the error message will now identify the dummy, protocol, and version instead of showing a generic error.

#### DxM upgrades: Improved rollback when an upgrade fails or is canceled [ID 46715]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

For the following DataMiner Extension Modules (DxMs), uninstalling the previous version is now part of the upgrade transaction:

- ArtifactDeployer
- CloudGateway
- CoreGateway
- Orchestrator
- SupportAssistant

If an upgrade fails or is canceled after the previous version has been uninstalled, that version will now be restored.

#### SLLogCollector packages now include the configuration files of ResourceManager, ProtocolFunctionManager, and Scheduler [ID 46753]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

SLLogCollector packages now include the following configuration files:

- `C:\Skyline DataMiner\ResourceManager\Config.xml`
- `C:\Skyline DataMiner\ProtocolFunctionManager\Config.xml`
- `C:\Skyline DataMiner\Scheduler\Config.xml` (if it exists)

#### TCP server ports: Multiple elements can now receive data from the same allowed IP address [ID 46784]

<!-- MR 10.7.0 - FR 10.6.12 -->

When multiple elements listen on the same TCP server port and explicitly list a client's IP address in their allowed IP addresses, all of those elements will now receive the data sent by that client. Previously, only one element would receive the data.

Only one element can still respond to the client. This enhancement is intended for scenarios where multiple elements need to receive data without responding.

If an element explicitly lists a client's IP address as allowed, elements that do not explicitly list that IP address will still not receive data from that client.

### Fixes

#### Element severity could be incorrect after a restart when unmasked alarms were present [ID 46501]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

When an element had unmasked alarms, its severity could be incorrect after it was restarted.

#### SNMP GET results could be matched to the wrong polling group [ID 46507]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

When multiple polling groups were executed concurrently, results from SNMP GET requests could be matched to the wrong group, potentially causing runtime errors.

The group ID is now passed along with each SNMP GET request so that the result is matched to the correct group.

#### NATS cluster verification BPA could skip NATS checks when NATSForceManualConfig was enabled [ID 46547]

<!-- MR 10.6.0 [CU9] - FR 10.6.12 -->

On systems where DataMiner BrokerGateway manages NATS, the `NATS cluster verification` BPA could skip its checks when the `NATSForceManualConfig` flag was enabled, even if NATS was not manually configured. The BPA now checks `appsettings.runtime.json` for the BrokerGateway configuration instead of relying on the obsolete flag.

#### DataMiner memory usage could keep increasing during frequent GQI queries [ID 46560]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

Up to now, every time a connection to the DataMiner storage layer was opened, SLNet would register handlers for logging configuration changes and incoming messages. These handlers were not removed when the connection closed, leaving their associated objects in memory for the lifetime of the process.

On systems where GQI queries repeatedly opened connections, for example through dashboards or low-code apps that refresh automatically, memory usage could keep increasing, potentially degrading performance or causing out-of-memory errors.

From now on, the handlers will be removed when the connection closes.

#### Service & Resource Management: Resources with time-dependent capabilities could be ineligible when ignoring a booking [ID 46576]

<!-- MR 10.7.0 - FR 10.6.12 -->

When requesting eligible resources while ignoring a booking and its service definition node, a resource with a time-dependent capability could still be considered unavailable if it was used in that booking.

From now on, the Resource Manager will take ignored booking into account when determining whether such resources are eligible.

#### ProtocolFunctionManager configuration changes were not synchronized across the cluster [ID 46583]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

Up to now, when you updated the ProtocolFunctionManager configuration on a DataMiner Agent, the changes were not synchronized with the other Agents in the cluster. As a result, you had to apply the settings manually on each Agent.

From now on, configuration updates will be synchronized across the cluster, and new Agents will automatically inherit the existing cluster settings.

#### STaaS: Feedback registrations could cause a memory leak [ID 46617]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

On STaaS systems, waiting for feedback or queues to be flushed for certain data types could leave event registrations uncleared and retain memory.

From now on, these registrations will be cleared when they are no longer needed.

#### Spectrum: Measurement point cycle was not loaded when DONT_APPLY_SETTINGS was passed [ID 46630]

<!-- MR 10.7.0 - FR 10.6.12 -->

Up to now, when you loaded a preset with both the `SPA_PRESET_DONT_APPLY_SETTINGS` and `SPA_PRESET_LOAD_MEASUREMENT_POINT_CYCLE` flags, the measurement point cycle would not be loaded.

From now on, passing the `SPA_PRESET_LOAD_MEASUREMENT_POINT_CYCLE` flag will load the measurement point cycle regardless of whether the `SPA_PRESET_DONT_APPLY_SETTINGS` flag is also passed.

#### STaaS: Certain exceptions were incorrectly wrapped [ID 46637]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

In certain cases, exceptions were wrapped in another exception even though they should have been handled or left unwrapped.

#### Crash dumps of native processes will now be captured earlier when a process crashes [ID 46696]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

From now on, crash dumps of native processes will be captured earlier when a process crashes, to help gather more useful diagnostic information.

Also, a number of minor issues have been fixed in SLDMS. For example, up to now, memory handling issues could occur in notification threads for DataMiner Agents.

#### Remote DELT export and migration failures did not show the failure reason [ID 46699]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

When you exported or migrated an element hosted on another DMA in the cluster, up to now, a failure only produced a generic error message in DataMiner Cube. To find the cause, you had to check the DELT error log on the DMA hosting the element.

From now on, DataMiner Cube now also displays the failure reason.

#### SLAnalytics - Alarm Focus: Swarming notifications could be missed during startup [ID 46717]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

Up to now, SLAnalytics subscribed to swarming notifications after startup prefetch, which could cause it to miss notifications while the cache was being initialized. From now on, it will subscribe before startup prefetch. History reads triggered during prefetch will wait for the cache lock; normal prefetched-cache lookup behavior will remain unchanged.

If an alarm for a migrating element is processed before its history loads, a fresh model could still have an incorrect likelihood, for example 0 instead of 0.2. The later history load could then skip that existing model, leaving the learned history unrestored.

#### CCAEndpoint initialization is now retried after failures [ID 46752]

<!-- MR 10.7.0 - FR 10.6.12 -->

If initialization of `CCAEndpointManager` or `CCAEndpointHandler` fails, DataMiner will now keep retrying.

The retry scheduler will increase the delay between attempts up to a maximum of 60 seconds.

#### STaaS: Encrypted credential records could accumulate when credentials were updated [ID 46746]

<!-- MR 10.7.0 - FR 10.6.12 -->
<!-- Not added to MR 10.7.0 - Introduced by RN 46061 -->

On STaaS systems, when you updated a Credentials Library credential with encrypted fields (such as an SNMPv3, token, or username and password credential), new records could be added to the `encryptedsecrets` table without removing the old ones. As a result, the table could grow indefinitely.

The update process now removes the old encrypted records, preventing them from accumulating.

#### Automation: Script execution time could be incorrect in script log files [ID 46749]

<!-- MR 10.6.0 [CU9] - FR 10.6.12 -->

In script log files, execution times for scripts running longer than one minute could be incorrect. In addition, the `SLAutomation` log file did not include the library name when it logged the start or completion of script library compilation.

From now on, the script log file will report the correct total execution time, and the `SLAutomation` log file will now include the library name in these messages.

#### Failover: BrokerGateway redirects would cause a Failover setup to fail [ID 46781]

<!-- MR 10.6.0 [CU9] - FR 10.6.12 -->

Up to now, it was not possible to set up a Failover pair when `DMS.xml` redirects were configured and BrokerGateway was manually configured with redirected NATS addresses.

#### STaaS: Source connection was not restored after stopping a migration or replication [ID 46782]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

When a STaaS migration or replication was stopped, the source connection was not restored as the current connection. Instead, DataMiner could continue to use the migration connection.

From now on, stopping a STaaS migration or replication will restore the source connection.
