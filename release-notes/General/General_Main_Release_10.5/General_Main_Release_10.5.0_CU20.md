---
uid: General_Main_Release_10.5.0_CU20
---

# General Main Release 10.5.0 CU20 - Preview

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
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.5.0 CU20](xref:Cube_Main_Release_10.5.0_CU20).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.5.0 CU20](xref:Web_apps_Main_Release_10.5.0_CU20).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Changes

### Enhancements

#### NATSMigration: Prerequisite checks added [ID 45668] [ID 46125]

<!-- MR 10.5.0 [CU20] - FR TBD -->

Each time the `NATSMigration` tool is run, it will perform the following prerequisite checks:

- DataMiner version check: Version must be at least Main Release 10.5.0 [CU4] or Feature Release 10.5.7 [CU1].
- IIS binding check for `0.0.0.0:443`, with optional hostname restrictions. A valid configuration requires a binding for `0.0.0.0` or, when multiple bindings exist, at least one binding to `127.0.0.1`.
- The server must run a recent Windows OS and TLS 1.2 must be available.
- At least one of two ciphers must be available for managed NATS communication.

#### User-Defined APIs: UserDefinableApiEndpoint DxM health status is now reported to dataminer.services [ID 46356]

<!-- MR 10.5.0 [CU20] / 10.6.0 [CU8] - FR 10.6.11 -->

The UserDefinableApiEndpoint DxM now reports its health status to dataminer.services.

When it can validate or repair the IIS rewrite rule for user-defined APIs, it reports a healthy status. If the rule cannot be repaired, it reports an unhealthy status.

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
