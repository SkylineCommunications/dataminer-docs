---
uid: General_Main_Release_10.5.0_CU15
---

# General Main Release 10.5.0 CU15 - Preview

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
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.5.0 CU15](xref:Cube_Main_Release_10.5.0_CU15).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.5.0 CU15](xref:Web_apps_Main_Release_10.5.0_CU15).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Changes

### Enhancements

#### Enhanced performance when retrieving service state information [ID 44392]

<!-- MR 10.5.0 [CU15] - FR 10.6.6 -->

Because of a number of enhancements, performance has increased when retrieving service state information.

From now on, a `GetServiceStateMessage` will no longer be forwarded to the Agent hosting the service. Instead, the service state information will be retrieved from the local SLNet cache.

#### BrokerGateway installer will now give a clear indication when .NET is missing [ID 45169]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

When you install the BrokerGateway DxM on a server that does not have the Microsoft .NET hosting bundle installed yet, from now on, a message will appear, saying that .NET has to be installed first.

### Fixes

#### STaaS: Problem when retrieving data to be visualized in 'State timeline' components or element and parameter heatlines [ID 45043]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

When, on systems using STaaS, the `GetReportTimelineDataMessage` was used to retrieve data to be visualized in *State timeline* components or element and parameter heatlines, in some cases, the data that was visualized would not be correct.

#### Dynamic units: A unit would incorrectly be assigned to date/time parameters [ID 45047]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

When the dynamic units feature is enabled in, for example, DataMiner Cube, many numerical values are automatically converted into more readable formats with appropriate units. Up to now, the dynamic units feature would incorrectly also try to assign a unit to parameters of type date/time.

#### Alarm squashing: Alarm would incorrectly not show up in the Alarm Console when the element had been restarted and the AlarmsPerParameter limit was exceeded [ID 45063]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

When, on a system with alarm squashing enabled, the `AlarmsPerParameter` limit in the `AlarmSettings` section of the *MaintenanceSettings.xml* file was exceeded, an alarm of which all alarms in the alarm tree were squashable would incorrectly not show up in the Alarm Console after the element associated with the alarm had been restarted.

#### SLWatchdog to incorrectly interpret processes being stopped during a DataMiner shutdown as a crash [ID 45115]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

When DataMiner is shutting down, processes are expected to be stopped. However, up to now, the tracking in SLWatchdog would not be cleaned correctly, causing certain processes to still be monitored. When these processes eventually stopped, SLWatchdog would incorrectly interpret this as a crash, which would then trigger a number of crash detection features, such as notifying CDMR or attempting to perform a full restart.

#### SLAnalytics: Problem due to a large number of state icon events being added to the SLNet queue simultaneously [ID 45145]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

In some cases, timeouts could occur due to a large number of state icon events being added to the SLNet queue simultaneously.

From now on, the number of state icon events sent by SLAnalytics instances will be reduced to a maximum of 10,000 events per minute. Also, they will be sent in batches of maximum 1000 events.

Additionally, state icon events, alarm focus events and RAD parameter aggregation events will now all have a smaller weight, meaning that more of them will be allowed in the queue.

#### Problem with connections to NATS servers of other DMAs during NATS migrations and NATS-related BPA test runs [ID 45175]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

Up to now, during NATS migrations or NATS-related BPA test runs, establishing connections to NATS servers of other DataMiner Agents in the DMS would be slow due to reverse DNS lookups.
