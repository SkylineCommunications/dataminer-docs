---
uid: General_Main_Release_10.5.0_CU19
---

# General Main Release 10.5.0 CU19 - Preview

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
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.5.0 CU19](xref:Cube_Main_Release_10.5.0_CU19).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.5.0 CU19](xref:Web_apps_Main_Release_10.5.0_CU19).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Changes

### Enhancements

#### SLLogCollector: Separate log file per instance [ID 44668]

<!-- MR 10.5.0 [CU19]/10.6.0 [CU7] - FR 10.6.4 -->

Up to now, all SLLogCollector logging of all SLLogCollector instances would end up in the following files, stored in the `C:\ProgramData\Skyline\DataMiner\SL_LogCollector\Log` folder:

- `SL_LogCollector_fulllog.log`
- `SL_LogCollector_log.log`

From now on, each SLLogCollector instance will have its own dedicated log file named `log-[creation timestamp].txt`, stored in the `C:\ProgramData\Skyline Communications\SLLogCollector` folder.

Up to 10 log files will be kept on disk, and the log file of the current instance will be added to the SLLogCollector package.

#### Enhanced performance when recalculating security keys [ID 46077]

<!-- MR 10.5.0 [CU19] / 10.6.0 [CU7] - FR 10.6.10 -->

Because of a number of enhancements, overall performance has increased when recalculating security keys.

#### DxM upgraded [ID 46124] [ID 46259]

<!-- RN 46124: MR 10.5.0 [CU19] / 10.6.0 [CU7] - FR 10.6.10 -->
<!-- RN 46259: MR 10.5.0 [CU19] / 10.6.0 [CU7] - FR TBD -->

The following DataMiner Extension Modules (DxM), which are included in the DataMiner upgrade package, have been upgraded to the indicated version:

- DataMiner ArtifactDeployer 1.10.0
- DataMiner CloudFeed 1.4.9
- DataMiner CloudGateway 3.3.2
- DataMiner CoreGateway 2.14.17
- DataMiner FieldControl 2.12.2
- DataMiner Orchestrator 1.11.0
- DataMiner SupportAssistant 1.9.3

For detailed information about the changes included in these versions, refer to the [DxM release notes](xref:DxM_RNs_index).

### Fixes

#### Agent element alarm and masking information could be out of sync after a Failover switch [ID 45601]

<!-- MR 10.5.0 [CU19] / 10.6.0 [CU7] - FR 10.6.10 -->

Up to now, when a DataMiner Agent came online after a Failover switch, the Agent element alarm tree and mask state could remain stale in memory. As a result, alarm and masking information for the Agent element could temporarily differ from what was stored in the database.

From now on, when the Agent comes online after the Failover switch, the Agent element's alarm and masking information are explicitly reloaded from the database. This ensures that the incoming Agent immediately reflects the correct alarm tree, correlated alarms, and mask state.

#### Table subscriptions with forceFullTable filter did not deliver updates for newly added rows on regular tables [ID 45970]

<!-- MR 10.5.0 [CU19] / 10.6.0 [CU7] - FR 10.6.10 -->

Up to now, when you created a subscription on a regular (non-partial) table and included the `forceFullTable=true` extra filter, updates for rows that did not yet exist at subscription creation time were not delivered.

From now on, this filter will be ignored for regular tables. As a result, subscriptions that include this filter now behave the same as subscriptions without it, and updates for newly added rows are delivered correctly.

View tables, direct view tables, partial tables, and matrixes are not affected.

#### SLAutomation deadlock when many subscripts were launched rapidly [ID 46056]

<!-- MR 10.5.0 [CU19] / 10.6.0 [CU7] - FR 10.6.10 -->

SLAutomation could deadlock when many subscripts were launched in a short time. This issue has been resolved.

#### SLAutomation could hang during shutdown [ID 46123]

<!-- MR 10.5.0 [CU19] / 10.6.0 [CU7] - FR 10.6.10 -->

In some cases, a race condition could cause the SLAutomation process to hang during shutdown.

As a result, a DataMiner upgrade could be delayed unnecessarily by up to 5 minutes.

#### Invalid cleared correlated alarms could be generated when DVE linking changed [ID 46174]

<!-- MR 10.5.0 [CU19] / 10.6.0 [CU7] - FR 10.6.10 -->

When a correlation rule with the *AutoClear* option disabled generated an alarm for base alarms on a linked DVE table, DataMiner could generate invalid cleared alarms if the linked row disappeared and reappeared or was unlinked and relinked.
