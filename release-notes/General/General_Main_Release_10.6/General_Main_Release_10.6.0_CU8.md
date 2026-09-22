---
uid: General_Main_Release_10.6.0_CU8
---

# General Main Release 10.6.0 CU8 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.6.0 CU8](xref:Cube_Main_Release_10.6.0_CU8).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.6.0 CU8](xref:Web_apps_Main_Release_10.6.0_CU8).
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

#### DataMiner Installer: Perpetual STaaS systems will retain their configured DMA ID and use a supplied license file [ID 46102]

<!-- MR 10.6.0 [CU8] - FR 10.6.11 -->

When you configure a perpetual STaaS system using the DataMiner Installer, the configured DMA ID is now retained instead of being replaced with an ID returned by dataminer.services.

Also, when the Installer is run in unattended mode, you will now be able to specify the optional `LicenseConfig.LicenseFilePath` setting in order to apply an existing *DataMiner.lic* file. The installer will then copy the license file to the DataMiner root folder and start DataMiner, without requiring you to generate and upload a *Request.lic* file.

#### User-Defined APIs: UserDefinableApiEndpoint DxM health status is now reported to dataminer.services [ID 46356]

<!-- MR 10.5.0 [CU20] / 10.6.0 [CU8] - FR 10.6.11 -->

The UserDefinableApiEndpoint DxM now reports its health status to dataminer.services.

When it can validate or repair the IIS rewrite rule for user-defined APIs, it reports a healthy status. If the rule cannot be repaired, it reports an unhealthy status.

#### DxMs upgraded [ID 46577]

<!-- RN 46577: MR 10.5.0 [CU20] / 10.6.0 [CU8] - FR 10.6.11 -->

The following DataMiner Extension Modules (DxMs), which are included in the DataMiner upgrade package, have been upgraded to the indicated versions:

- DataMiner DataAPI 1.5.0

For detailed information about the changes included in those versions, refer to the [DxM release notes](xref:DxM_RNs_index).

### Fixes

#### Deleted-service information events would no longer have the service impact of the deleted service [ID 46195]

<!-- MR 10.5.0 [CU20] / 10.6.0 [CU8] - FR 10.6.11 -->

Up to now, when a service was deleted, the generated deleted-service information event would incorrectly no longer have the service impact of that deleted service.

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

#### SRM: Conflicting bookings incorrectly could be created during bulk creation [ID 46351]

<!-- MR 10.5.0 [CU20] / 10.6.0 [CU8] - FR 10.6.11 -->

Up to now, bulk creation of booking instances could incorrectly create instances identified as conflicting when the force quarantine flag was disabled.

#### NATSReset.exe could throw an InvalidOperationException after the IP address of a DataMiner Agent had changed [ID 46360]

<!-- MR 10.5.0 [CU20] / 10.6.0 [CU8] - FR 10.6.11 -->

Up to now, after the IP address of a DataMiner Agent had changed, running *NATSReset.exe* could throw an `InvalidOperationException`.

#### NATSMigration and NATSRepair could omit errors from the final error overview [ID 46362]

<!-- MR 10.5.0 [CU20] / 10.6.0 [CU8] - FR 10.6.11 -->

Up to now, some errors encountered by *NATSMigration.exe* or *NATSRepair.exe* could incorrectly be missing from the error overview at the end of the command-line output.

#### STaaS: Ordering DOM entries by optional fields could throw a CRUD exception [ID 46377]

<!-- MR 10.5.0 [CU20] / 10.6.0 [CU8] - FR 10.6.11 -->

On systems using STaaS, up to now, ordering DOM entries by an optional field could throw a CRUD exception when one or more entries did not contain that field.

#### SLSNMPManager could stop unexpectedly when testing a connection with SNMPv3 credentials [ID 46438]

<!-- MR 10.5.0 [CU20] / 10.6.0 [CU8] - FR 10.6.11 -->

Up to now, testing a connection that used SNMPv3 credentials from the Credential Library with SHA-224, SHA-256, SHA-384, or SHA-512 authentication could cause the SLSNMPManager process to stop unexpectedly.
