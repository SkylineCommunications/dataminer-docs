---
uid: General_Feature_Release_10.6.6
---

# General Feature Release 10.6.6 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.6.6](xref:Cube_Feature_Release_10.6.6).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.6.6](xref:Web_apps_Feature_Release_10.6.6).
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

*No new features have been added yet.*

## Changes

### Enhancements

#### Enhanced performance when retrieving service state information [ID 44392]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

Because of a number of enhancements, performance has increased when retrieving service state information.

From now on, a `GetServiceStateMessage` will no longer be forwarded to the Agent hosting the service. Instead, the service state information will be retrieved from the local SLNet cache.

#### Connector synchronization enhancements [ID 44715]

<!-- MR 10.7.0 - FR 10.6.6 -->

A number of enhancements have been made with regard to the synchronization of connectors within a DataMiner System:

- The first time you upload a version of a new connector, it will automatically be set as production version. Up to now, when a connector version was automatically set as production version, this would trigger a synchronization of that production version. From now on, the new connector will be synchronized within the cluster, and when a DataMiner Agent detects that it is the first version, it will set it as the production version.

- Up to now, when a parent connector exported child connectors (as is the case with DVE connectors), these exported child connectors would be synchronized within the cluster when the parent connector was added or modified. From now on, only the parent connector will be synchronized, and each DataMiner Agent will then generate the child connectors.

- From now on, a protocol.xml file that is generated based on the active function.xml file will no longer be synchronized when the function is activated.

> [!NOTE]
> The midnight sync has not been altered.

#### Enhanced logging for connections towards SLNet [ID 44765] [ID 45359]

<!-- 44765: MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->
<!-- 45359: MR 10.7.0 - FR 10.6.6 -->

A number of enhancements have been made with regard to SLNet logging, especially to be able to troubleshoot issues with sudden disconnects between two SLNet instances or between SLNet and DataMiner Cube.

##### New log files

In the `C:\Skyline DataMiner\Logging` folder, you can now find the following new log files:

| Log file | Description |
| --- | --- |
| SLNetConnections.txt  | An entry will be added each time an SLNet to SLNet connection encounters a timeout. |
| SLCubeConnections.txt | An entry will be added each time a Cube to SLNet connection encounters a timeout.   |

If information logging is set to Level 4, the log entries will also mention if a message is waiting until other calls have finished. Up to 10 active calls are allowed at any given time.

##### Existing log files

- *ConnectionDiagnostics* in `C:\Skyline DataMiner\Logging\SLNet\ConnectionDiagnostics` will now also report which calls were in progress at a certain point in time.

- *SLHangingCalls.txt* will now contain more detailed information:

  - Apart from blocking calls, it will now also log asynchronous calls.
  - The entries will now mention the exact message that is hanging, rather than the wrapping `EncryptedMessage`.

> [!NOTE]
>
> - Log entries can also be added to *SLNetConnections.txt* and *SLCubeConnections.txt* for SLNet connections created elsewhere. To do so, provide a `LoggerProvider` to `SLNetTypesDiagnostics.AddLoggerProvider()`.
> - When a Cube connected to a system without server-side `SLNetTypesDiagnostics` connects to a system with server-side `SLNetTypesDiagnostics`, the *SLCubeConnections.txt* log file will not be populated. Restart Cube if you want that log file to be populated.

#### BrokerGateway installer will now give a clear indication when .NET is missing [ID 45169]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

When you install the BrokerGateway DxM on a server that does not have the Microsoft .NET hosting bundle installed yet, from now on, a message will appear, saying that .NET has to be installed first.

#### Protocols: Indicating that smart-serial elements in server mode are allowed to be swarmed [ID 45173]

<!-- MR 10.7.0 - FR 10.6.6 -->

By default, elements with a smart-serial connection in server mode are not allowed to be swarmed. However, it is possible that, at startup, an element can send a message to the data source in order to indicate where data should be sent to. In that case, the fact that the smart-serial connection is in server mode will not be considered a valid reason to prevent the element from swarming.

As DataMiner is not able to automatically detect such exceptional cases, you can now indicate in the *protocol.xml* file of the element that it is allowed to be swarmed. See the following example:

```xml
<Swarming>
    <BypassChecks>
        <Check>smartSerialAsServer</Check>
    </BypassChecks>
</Swarming>
```

#### Correlation: GetAvailableCorrelationRulesMessage response now also includes grouping information [ID 45187]

<!-- MR 10.7.0 - FR 10.6.6 -->

When a `GetAvailableCorrelationRulesMessage` is sent to SLNet, the response will now also include information regarding the grouping defined in the correlation rules.

#### DataMiner upgrade: .NET Framework 4.8 will no longer be installed [ID 45196]

<!-- MR 10.7.0 - FR 10.6.6 -->

From now on, during a DataMiner upgrade, Microsoft .NET Framework 4.8 will no longer be installed.

On most machines running DataMiner, this will already be installed. If, for any reason, you need to install this package, it can be downloaded from [the official download page](https://dotnet.microsoft.com/en-us/download/dotnet-framework).

#### DataMiner upgrade: A number of default Visio stencils will no longer be included [ID 45202]

<!-- MR 10.7.0 - FR 10.6.6 -->

From now on, a DataMiner upgrade package will no longer contain the following Visio stencil files:

- AppearTV DC1000.vss
- AppearTV DC1100.vss
- AppearTV MC3000.vss
- AppearTV MC3100.vss
- AppearTV SC2000.vss
- AppearTV SC2100.vss
- BridgeTech.vss
- Nimbra300.vss
- Nimbra600.vss
- NimbraNodes.vss
- United States Maps (US units).vss
- World Maps (Metric).vss
- World Maps (US units).vss

Note that the following stencil files will still be deployed:

- Buttons.vssm
- Icons.vssx
- KPI.vssm
- SkylineNewDrawing.vsdx

> [!NOTE]
> The above-mentioned stencil files that are no longer included in DataMiner upgrade packages will not automatically be removed from existing systems.

#### Automation: Compiled assemblies generated during syntax checks will no longer be loaded into memory [ID 45214]

<!-- MR 10.7.0 - FR 10.6.6 -->

Up to now, when a syntax check was performed on an automation script (e.g., by clicking *Validate* in a script's C# block in DataMiner Cube), the compiled assembly would be loaded into the SLAutomation memory.

From now on, compiled assemblies generated during syntax checks will no longer be loaded into memory.

#### SLLogCollector: Only BPA tests deployed by default will be rerun each time a log package is created [ID 45228]

<!-- MR 10.7.0 - FR 10.6.6 -->

Up to now, each time SLLogCollector created a log package, it would rerun all BPA tests deployed on the system. From now on, it will only rerun the BPA tests deployed by default.

> [!NOTE]
> Each time a log package is created, all BPA test results available on the system will still be included in that package. This means, that all results from non-default BPA tests will also be included, even when, from now on, these tests are no longer rerun when a package is created.

#### Number of smart-serial messages allowed to enter has now been limited [ID 45273]

<!-- MR 10.7.0 - FR 10.6.6 -->

In order to protect DataMiner against a continuously growing queue of incoming smart-serial messages, the number of smart-serial messages that are allowed to enter per element with smart-serial connections has now been limited.

- If more than 200 MB of messages are waiting in the queue, a notice alarm will be generated, and a log entry will be added to the *SLErrorsInProtocol.txt* file. This is meant as a warning. As soon as the queue drops below 150 MB again and the maximum limit is not breached, the notice alarm will be cleared.

- If more than 300 MB of messages are waiting in the queue, an error alarm will be generated, and a log entry will be added to the *SLErrorsInProtocol.txt* file. As the maximum limit was breached, the queue will no longer accept any additional messages.

- Once the maximum limit has been breached, the queue will need to drop below 200 MB before new messages can be added again. As soon as the queue drops below 200 MB, the error alarm will become a notice alarm. Note that, even when the queue would be empty, the notice alarm will not be cleared. It will serve as an indication that part of the communication was lost.

> [!NOTE]
>
> - We strongly advise you to restart the element when the limit has been breached. When certain messages within a data stream get dropped because the maximum queue limit was breached, an incomplete data stream may get processed, which could then produce unexpected results.
> - The alarm not only mentions the limit that was reached (in MB). It also mentions the number of messages that are present in the queue. This number of messages is not always equal to the number of responses to be processed. For example, in some cases, Windows can combine multiple received UDP packets into one when adding packets to the receive buffer, causing SLPort to then add a single message to the queue.

#### DxMs upgraded [ID 45304] [ID 45347]

<!-- RN 45304: MR 10.7.0 - FR 10.6.6 -->
<!-- RN 45347: MR 10.7.0 - FR 10.6.6 -->

The following DataMiner Extension Modules (DxMs), which are included in the DataMiner upgrade package, have been upgraded to the indicated versions:

- DataMiner ArtifactDeployer 1.8.8
- DataMiner CoreGateway 2.14.17
- DataMiner FieldControl 2.12.1
- DataMiner Orchestrator 1.8.2
- DataMiner SupportAssistant 1.9.1

For detailed information about the changes included in those versions, refer to the [DxM release notes](xref:DxM_RNs_index).

#### DataMiner upgrade: Clients can now also connect to the orchestrating Agent when it has finished upgrading locally [ID 45312]

<!-- MR 10.7.0 - FR 10.6.6 -->

When you upgrade an entire DMS, every DMA will upgrade itself locally, and one of them, the so-called orchestrating Agent, will give you progress updates. This orchestrating Agent is the Agent from which the upgrade was triggered.

Up to now, while a full DMS upgrade was in progress, you could connect with a client application (e.g., DataMiner Cube) to any of the Agents that had finished upgrading locally, except the orchestrating Agent. Even when that Agent had finished upgrading locally, it would not be possible to connect to it. From now on, this will be possible.

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

#### SLLogCollector: Problem when running BPA tests [ID 45053]

<!-- MR 10.7.0 - FR 10.6.6 -->

When the SLLogCollector tool was configured to execute all BPA tests available in the system when collecting log packages, up to now, in some cases, executing those BPA tests would fail and cause them to report a wide variety of exceptions.

From now on, when the SLLogCollector tool detects that it is not possible to execute the BPA tests, it will skip their execution and collect the results of their last successful run.

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

#### An alarm will now be generated when a protocol connection acting as a server failed to bind to the socket [ID 45241]

<!-- MR 10.7.0 - FR 10.6.6 -->

When a protocol connection that acted as a server failed to bind to the socket during startup, up to now, this would only get logged (with debug level 1). From now on, this will be assigned error level 0.

Also, the element will go into an error state, and an alarm indicating a failing binding will be generated.

#### SLNet: MessageBroker cache could leak NATS threads [ID 45259]

<!-- MR 10.7.0 - FR 10.6.6 -->

In some rare cases, the MessageBroker cache of SLNet could leak NATS threads.

#### Service & Resource Management: Problem when the Agent with the lowest DMA ID was removed from a DataMiner System [ID 45281]

<!-- MR 10.7.0 - FR 10.6.6 -->

Up to now, when the Agent with the lowest DMA ID had been removed from a DataMiner System, the Resource Manager would incorrectly still consider the removed Agent the master DMA and would still attempt to communicate with it. As a result, master synchronization requests would fail, producing errors like the following one:

`System.AggregateException: One or more errors occurred. ---> Skyline.DataMiner.Net.Exceptions.DataMinerException: Fatal error while sending request [MasterSyncRequestMessage for message of type SetReservationInstanceMessage from XXX] to master DMA XXX, max retries reached. ---> Skyline.DataMiner.Net.MasterSync.MasterSyncerException: Could not use the connection to master DMA XXX`

From now on, when the Agent with the lowest DMA ID was removed from the DataMiner System, the Resource Manager will correctly re-evaluate and update the master DMA when it receives a master synchronization request.

#### SLDataMiner: Problem when trying to fetch information about loopback adapters [ID 45285]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

When the SLDataMiner process starts, it tries to fetch information about all network adapters. However, up to now, when it tried to fetch information about a loopback adapter, an error resembling the following one would be thrown:

`CIPSettings::Init|ERR|-1|Opening device failed for adapter {14763620-5D53-11EA-90D5-806E6F6E6963} (Software Loopback Interface 1): The system cannot find the file specified. (2)`

As loopback adapters are not part of any communication flow, from now on, SLDataMiner will no longer try to fetch information about those adapters.
