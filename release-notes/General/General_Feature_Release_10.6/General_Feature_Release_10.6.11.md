---
uid: General_Feature_Release_10.6.11
---

# General Feature Release 10.6.11 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.6.11](xref:Cube_Feature_Release_10.6.11).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.6.11](xref:Web_apps_Feature_Release_10.6.11).
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

### DataMiner Edge: New 'Number', 'IP address', and 'IP port' setting types in scripted connector protocols [ID 46361]

<!-- MR 10.7.0 - FR 10.6.11 -->

DataMiner Edge now supports `Number`, `IPAddress`, and `IPPort` setting types in scripted connector protocols.

- `Number` supports an optional range and decimal precision.
- `IPAddress` accepts IPv4 and IPv6 addresses as well as hostnames.
- `IPPort` accepts whole-number port values from 1 through 65535.

### New GetCloudDmsInformationRequest message to retrieve information from a cloud-connected DMS [ID 46393]

<!-- MR 10.7.0 - FR 10.6.11 -->

The new `GetCloudDmsInformationRequest` SLNet message allows you to retrieve information from a cloud-connected DMS, including the organization name, DMS name, and remote-access URL.

This request requires a CloudGateway version that supports it.

## Changes

### Enhancements

#### Jobs module: All server-side code has now been removed from the code base [ID 46163]

<!-- MR 10.7.0 - FR 10.6.11 -->

The Jobs module has been end-of-life since DataMiner 10.5.0. All server-side code related to this module has now been removed from the code base.

#### Swarming: Alarm ID usage analysis can now be skipped when enabling swarming [ID 46340]

<!-- MR 10.7.0 - FR 10.6.11 -->

When enabling swarming using an `EnableSwarmingRequest`, you can now skip the analysis of alarm ID usage by setting `AnalyzeAlarmIDUsage` to `false`, similar to a `SwarmingPrerequisitesCheckRequest`.

By default, the analysis will still be performed. Skipping it can considerably speed up the request, but you should only do so if you have already analyzed and resolved any alarm ID usage beforehand.

### Fixes

#### Existing behavioral change points could no longer be retrieved after a DataMiner Agent restart [ID 46271]

<!-- MR 10.7.0 - FR 10.6.11 -->

In some cases, after SLAnalytics had restarted, an existing change point on a parameter could no longer be returned once a new change point was detected on that same parameter.

This was caused by an internal ID collision. Change point IDs restart from zero after a restart, and the retrieval logic could incorrectly treat a new change point with a reused ID as a duplicate.

Change points are now also distinguished by creation time. As a result, previously detected change points remain retrievable after a restart.

#### Stopping an element with a logger table could cause SLProtocol to stop unexpectedly [ID 46299]

<!-- MR 10.5.0 [CU20]/10.6.0 [CU8] - FR 10.6.11 -->

Up to now, in some rare cases, stopping an element with a logger table could cause the SLProtocol process hosting the element to stop unexpectedly.

#### DIS: DIS Inject could not trigger QAction execution on parameters unknown to SLNet [ID 46304]

<!-- MR 10.5.0 [CU20] / 10.6.0 [CU8] - FR 10.6.11 -->

Up to now, DIS Inject could not trigger QAction execution through parameters that are only known in SLProtocol and not in SLNet, such as dummy parameters.

From now on, DIS Inject will be able to trigger QActions through those parameters as well. Parameters that are known in SLNet will still be validated against the parameter security level.

#### Automation scripts from app packages could leave stale database entries when removed on systems using STaaS [ID 46308]

<!-- MR 10.6.0 [CU8] - FR 10.6.11 -->

On systems using STaaS, up to now, after an app package was installed, removing included automation scripts could fail to remove the corresponding AppPackageContent database entries.

This issue was caused by a case-sensitive mismatch in the script-type filter (`automationscript` instead of `AutomationScript`). From now on, the filter is case-insensitive, so stale automation script entries are removed correctly.

#### Failover: SLASPConnection could fail to initialize after a Failover switch [ID 46350]

<!-- MR 10.5.0 [CU20] / 10.6.0 [CU8] - FR 10.6.11 -->

After a Failover switch, SLASPConnection could fail to initialize correctly when the DataMiner Agent came back online. This could cause the following issues:

- The legacy Reporter could be unavailable when the `LegacyReportsAndDashboards` soft-launch option was enabled.
- Incoming notifications could remain in memory without being processed, causing a memory leak.
- The reporter page in DataMiner Cube and the distribution, alarm count, and timeline components in the Dashboards app could show outdated information.

#### NATSMigration and NATSRepair could omit errors from the final error overview [ID 46362]

<!-- MR 10.5.0 [CU20] / 10.6.0 [CU8] - FR 10.6.11 -->

Up to now, some errors encountered by *NATSMigration.exe* or *NATSRepair.exe* could incorrectly be missing from the error overview at the end of the command-line output.

#### STaaS: Ordering DOM entries by optional fields could throw a CRUD exception [ID 46377]

<!-- MR 10.5.0 [CU20] / 10.6.0 [CU8] - FR 10.6.11 -->

On systems using STaaS, up to now, ordering DOM entries by an optional field could throw a CRUD exception when one or more entries did not contain that field.
