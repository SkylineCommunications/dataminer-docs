---
uid: General_Main_Release_10.6.0_CU3
---

# General Main Release 10.6.0 CU3 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.6.0 CU3](xref:Cube_Main_Release_10.6.0_CU3).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.6.0 CU3](xref:Web_apps_Main_Release_10.6.0_CU3).
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

### Breaking changes

#### Protocols: As many SLScripting processes as SLProtocol processes by default [ID 44420]

<!-- MR 10.6.0 [CU3] - FR 10.6.3 -->

Up to now, one SLScripting process was used by default. From now on, by default, there will be as many SLScripting processes as SLProtocol processes.

Note that is possible to configure the number of simultaneously running SLScripting processes. See [Setting the number of simultaneously running SLScripting processes](xref:Configuration_of_DataMiner_processes#setting-the-number-of-simultaneously-running-slscripting-processes).

> [!IMPORTANT]
> If you are using multiple SLScripting processes, it is important that elements running the same protocol are not sharing/exchanging data with each other through static fields. More information can be found in the [QAction documentation](xref:LogicQActionsMemberFields#sharing-and-persisting-data).

### Enhancements

#### Protocols: Elements will now restart automatically when an SLScripting process has disappeared [ID 42306]

<!-- MR 10.6.0 - FR 10.5.5 >>> Published in 10.6.0 [CU3] - FR 10.6.3 together with 44420 -->

Up to now, when an SLScripting process disappeared, elements relying on that process could become unstable, requiring manual intervention to restore functionality.

From now on, when an SLScripting process disappears, a new process instance will be started automatically, and any elements that depended on the process that disappeared will be restarted to maintain consistency across SLProtocol, SLScripting, and other related components. This will ensure that lost SLScripting data is properly reinitialized and remains in sync with other processes.

When an SLScripting process disappears, the following notice alarm will be generated:

`Process disappearance of SLScripting.exe with PID <processId>; <x> elements affected by the disappearance have been restarted.`

Also, the *SLElementsInProtocol.txt* log file has been updated to track restart reasons more accurately.

- The restart reason column will now indicate either "SLScriptingCrashRestart" or "SLProtocolCrashRestart" (if everything is OK, *NormalStart* will be shown instead).
- A new counter will now indicate the number of times the element was started due to a SLScripting process disappearance.

If SLProtocol requests an SLScripting process that is no longer valid, the system will now detect this, and trigger the same element restart flow.

> [!NOTE]
> There will be a one-minute delay between the disappearance of an SLScripting process and the creation of a new SLScripting process and the subsequent element restarts. However, when one of the elements that was hosted in the SLScripting process that disappeared tries to trigger a QAction within that one-minute delay, the new SLScripting process will be created when that QAction is triggered.

#### Enhanced performance when retrieving service state information [ID 44392]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

Because of a number of enhancements, performance has increased when retrieving service state information.

From now on, a `GetServiceStateMessage` will no longer be forwarded to the Agent hosting the service. Instead, the service state information will be retrieved from the local SLNet cache.

#### Enhanced logging for connections towards SLNet [ID 44765]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

A number of enhancements have been made with regard to SLNet logging, especially to be able to troubleshoot issues with sudden disconnects between two SLNet instances or between SLNet and DataMiner Cube.

##### New log files

In the `C:\Skyline DataMiner\Logging` folder, you can now find the following new log files:

| Log file | Description |
| --- | --- |
| SLNetConnections.txt  | An entry will be added each time an SLNet to SLNet connection encounters a timeout. |
| SLCubeConnections.txt | An entry will be added each time a Cube to SLNet connection encounters a timeout.   |

##### Existing log files

- *ConnectionDiagnostics* in `C:\Skyline DataMiner\Logging\SLNet\ConnectionDiagnostics` will now also report which calls were in progress at a certain point in time.

- *SLHangingCalls.txt* will now contain more detailed information:

  - Apart from blocking calls, it will now also log asynchronous calls.
  - The entries will now mention the exact message that is hanging, rather than the wrapping `EncryptedMessage`.

> [!NOTE]
>
> - Log entries can also be added to *SLNetConnections.txt* and *SLCubeConnections.txt* for SLNet connections created elsewhere. To do so, provide a `LoggerProvider` to `Diagnostics.AddLoggerProvider()` of `SLNetTypes`.
> - When a Cube connected to a system without server-side `Diagnostics` connects to a system with server-side `Diagnostics`, the *SLCubeConnections.txt* log file will not be populated. Restart Cube if you want that log file to be populated.

#### BrokerGateway installer will now give a clear indication when .NET is missing [ID 45169]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

When you install the BrokerGateway DxM on a server that does not have the Microsoft .NET hosting bundle installed yet, from now on, a message will appear, saying that .NET has to be installed first.

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

#### Problem when a connector was using the makeCommandByProtocol option while in slow poll mode [ID 45217]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

Up to now, a problem could occur when a connector was using the `makeCommandByProtocol` option while in slow poll mode.

The slow poll timer would make the ping command when adding the slow poll group to the execution queue. However, when regular groups were still being executed when a valid response entered, an attempt would be made to stop the slow poll timer. This attempt would fail was waiting for the response to release the resources.

From now on, the slow poll timer will no longer make the ping command when adding the slow poll group to the queue. The ping command will be made when the group is executed, and the `makeCommandByProtocol` setting will be disregarded.

#### SLAnalytics: Problem due to incorrect internal state in Automatic Incident Tracking [ID 45220]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

In some cases, SLAnalytics could stop working due to an incorrect internal state in Automatic Incident Tracking.
