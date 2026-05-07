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

*No features have been added yet.*

## Changes

### Enhancements

#### OpenSearch: Enhanced health monitoring [ID 45294]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->
<!-- Re-introduction of RN 43951, which was reverted by RN 44647 in 10.6.2 CU1 -->

A number of enhancements have been made with regard to health monitoring of OpenSearch databases.

Also, all logging with regard to OpenSearch health monitoring can now be found in *SLSearchHealth.txt*. Up to now, that logging was added to *SLCassandraHealth.txt*.

#### SLNetConnectionsMonitor.txt will now log all state changes of all SLNet connections [ID 45316]

<!-- MR 10.7.0 - FR 10.6.7 -->

Up to now, only the general state of the entire cluster when an Agent connected or disconnected would be logged in the *SLNetConnectionsMonitor.txt* file.

From now on, all state changes of all SLNet connections between Agents in the cluster will be logged in the *SLNetConnectionsMonitor.txt* file.

#### DataMiner Agents will now translate the primary key to the display key when receiving timeline data requests from DataMiner Cube [ID 45355]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

When DataMiner Cube requests timeline data using a `GetReportTimeLineDataMessage`, it sends the primary key when referencing display column tables. However, for this type of table, the DataMiner Agent has to retrieve the data from the database using the display key.

From now on, when a DataMiner Agent receives a timeline data request, it will first translate the primary key to the display key before returning the requested data.

#### SLAnalytics: Enhanced performance when detecting flatline events [ID 45376]

<!-- MR 10.7.0 - FR 10.6.7 -->

Because of a number of enhancements, overall performance has increased when detecting flatline events, especially on systems with a large number of monitored parameters.

#### DxMs upgraded [ID 45392]

<!-- RN 45392: MR 10.7.0 - FR 10.6.7 -->

The following DataMiner Extension Modules (DxMs), which are included in the DataMiner upgrade package, have been upgraded to the indicated versions:

- DataMiner CloudGateway 3.0.2

For detailed information about the changes included in those versions, refer to the [DxM release notes](xref:DxM_RNs_index).

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

#### SLDataGateway would terminate unexpectedly when shutting down [ID 45419]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

In some cases, SLDataGateway would terminate unexpectedly when shutting down.

#### DataMiner upgrades could get stuck while running 'Register DataMiner as Service.bat' [ID 45426]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

In some rare cases, a DataMiner upgrade could get stuck while running the `C:\Skyline DataMiner\Tools\Register DataMiner as Service.bat` file.
