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

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

Because of a number of enhancements, performance has increased when retrieving service state information.

From now on, a `GetServiceStateMessage` will no longer be forwarded to the Agent hosting the service. Instead, the service state information will be retrieved from the local SLNet cache.

#### STaaS: Enhanced performance when closing alarm trees [ID 45081]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

Because of a number of enhancements, on STaaS systems, overall performance has increased when closing alarm trees.

#### BrokerGateway installer will now give a clear indication when .NET is missing [ID 45169]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

When you install the BrokerGateway DxM on a server that does not have the Microsoft .NET hosting bundle installed yet, from now on, a message will appear, saying that .NET has to be installed first.

#### APIGateway: Enhanced handling of files in use during upgrades [ID 45230]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

From now on, the *Windows Restart Manager* will be enabled during installations. This will prevent unnecessary delays caused by files still in use by the APIGateway instance that is being upgraded, increasing overall performance and reliability of the upgrade process.

#### SLLogCollector packages now include hosts and lmhosts files [ID 45369]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

From now on, SLLogCollector packages will also include the following files:

| File | Description  |
|---|---|
| `C:\Windows\System32\drivers\etc\hosts`   | Maps hostnames to IP addresses for DNS name resolution. Used to override or supplement DNS locally. |
| `C:\Windows\System32\drivers\etc\lmhosts` | Maps NetBIOS names to IP addresses for legacy Windows networking. Rarely used in modern systems.    |

Both files will be added to the *Network Information* folder.

### Fixes

#### BPA tests could incorrectly not be run on DMAs that were not connected to the internet [ID 45040]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

Up to now, it would not be possible to run BPA tests on DataMiner Agents that were not connected to the internet because they were not able to fetch the necessary certificates.

From now on, it will be possible to run BPA tests on DataMiner Agents that are not connected to the internet.

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

#### Problem with alarm forwarding after an element had been edited [ID 45167]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

When an element had been edited, in some cases, alarm updates would incorrectly no longer be forwarded to northbound SNMP managers.

> [!NOTE]
> This fix will not work if the element in question has the *Enable SNMP agent* option enabled, and has a virtual IP address and a subnet mask configured.

#### Problem with connections to NATS servers of other DMAs during NATS migrations and NATS-related BPA test runs [ID 45175]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

Up to now, during NATS migrations or NATS-related BPA test runs, establishing connections to NATS servers of other DataMiner Agents in the DMS would be slow due to reverse DNS lookups.

#### SLNet: Problems with user picture requests would cause other messages to get blocked [ID 45210]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

When SLNet was not able to respond to user picture requests from a web app, up to now, those request could stay active within SLNet for several minutes, causing other messages to get blocked.

From now on, user picture requests will time out after 10 seconds.

#### Problem when a connector was using the makeCommandByProtocol option while in slow poll mode [ID 45217]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

Up to now, a problem could occur when a connector was using the `makeCommandByProtocol` option while in slow poll mode.

The slow poll timer would make the ping command when adding the slow poll group to the execution queue. However, when regular groups were still being executed when a valid response entered, an attempt would be made to stop the slow poll timer. This attempt would fail was waiting for the response to release the resources.

From now on, the slow poll timer will no longer make the ping command when adding the slow poll group to the queue. The ping command will be made when the group is executed, and the `makeCommandByProtocol` setting will be disregarded.

#### SLAnalytics: Problem due to incorrect internal state in Automatic Incident Tracking [ID 45220]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

In some cases, SLAnalytics could stop working due to an incorrect internal state in Automatic Incident Tracking.

#### SLDataMiner: Problem when trying to fetch information about loopback adapters [ID 45285]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

When the SLDataMiner process starts, it tries to fetch information about all network adapters. However, up to now, when it tried to fetch information about a loopback adapter, an error resembling the following one would be thrown:

`CIPSettings::Init|ERR|-1|Opening device failed for adapter {14763620-5D53-11EA-90D5-806E6F6E6963} (Software Loopback Interface 1): The system cannot find the file specified. (2)`

As loopback adapters are not part of any communication flow, from now on, SLDataMiner will no longer try to fetch information about those adapters.

#### DataMiner upgrade: Incorrect .NET 6 error would be thrown during the upgrade process [ID 45374]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

Up to now, the first time a newly installed DataMiner Agent was upgraded, an incorrect .NET 6 error would be thrown during the upgrade process.
