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

## Changes

### Enhancements

#### Service & Resource Management: 'Unavailable' resource mode is now obsolete in SLNetTypes [ID 46492]

<!-- MR 10.7.0 - FR 10.6.12 -->

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

### Fixes

#### SNMP GET results could be matched to the wrong polling group [ID 46507]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

When multiple polling groups were executed concurrently, results from SNMP GET requests could be matched to the wrong group, potentially causing runtime errors.

The group ID is now passed along with each SNMP GET request so that the result is matched to the correct group.

#### VerifyNatsCluster could skip NATS checks when NATSForceManualConfig was enabled [ID 46547]

<!-- MR 10.6.0 [CU9] - FR 10.6.12 -->

On systems where DataMiner BrokerGateway manages NATS, the `VerifyNatsCluster` BPA could skip its checks when the `NATSForceManualConfig` flag was enabled, even if NATS was not manually configured. The BPA now checks `appsettings.runtime.json` for the BrokerGateway configuration instead of relying on the obsolete flag.

#### DataMiner memory usage could keep increasing during frequent GQI queries [ID 46560]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

Up to now, every time a connection to the DataMiner storage layer was opened, SLNet would register handlers for logging configuration changes and incoming messages. These handlers were not removed when the connection closed, leaving their associated objects in memory for the lifetime of the process.

On systems where GQI queries repeatedly opened connections, for example through dashboards or low-code apps that refresh automatically, memory usage could keep increasing, potentially degrading performance or causing out-of-memory errors.

From now on, the handlers will be removed when the connection closes.

#### Service & Resource Management: Resources with time-dependent capabilities could be ineligible when ignoring a booking [ID 46576]

<!-- MR 10.7.0 - FR 10.6.12 -->

When requesting eligible resources while ignoring a booking and its service definition node, a resource with a time-dependent capability could still be considered unavailable if it was used in that booking.

From now on, the Resource Manager will take ignored booking into account when determining whether such resources are eligible.

#### STaaS: Feedback registrations could cause a memory leak [ID 46617]

<!-- MR 10.7.0 - FR 10.6.12 -->

On STaaS systems, waiting for feedback or queues to be flushed for certain data types could leave event registrations uncleared and retain memory.

From now on, these registrations will be cleared when they are no longer needed.

#### Spectrum: Measurement point cycle was not loaded when DONT_APPLY_SETTINGS was passed [ID 46630]

<!-- MR 10.7.0 - FR 10.6.12 -->

Up to now, when you loaded a preset with both the `SPA_PRESET_DONT_APPLY_SETTINGS` and `SPA_PRESET_LOAD_MEASUREMENT_POINT_CYCLE` flags, the measurement point cycle would not be loaded.

From now on, passing the `SPA_PRESET_LOAD_MEASUREMENT_POINT_CYCLE` flag will load the measurement point cycle regardless of whether the `SPA_PRESET_DONT_APPLY_SETTINGS` flag is also passed.
