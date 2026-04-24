---
uid: General_Main_Release_10.7.0_changes
---

# General Main Release 10.7.0 – Changes (preview)

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## Changes

### Breaking changes

#### SNMP trap binding values will now only display plain ASCII characters [ID 44527]

<!-- MR 10.7.0 - FR 10.6.4 -->

When the system receives a trap binding value of type OctetString, that value will either be automatically converted into characters (e.g., 0x41 will become "A") or remain in a hexadecimal string format (e.g., when the value contains a byte that is not printable like 0x02, which is an STX control character).

Up to now, hexadecimal values above the ASCII range (i.e., values >= 0x7F) were considered printable characters, and were not converted into a hexadecimal string. This would cause issues with, for example, the Unicode control character 0x8C, which would be displayed as a question mark. In such cases, complex QAction code would then be required to have it converted back into a hexadecimal value.

Also, DataMiner is not aware of whether a binding value actually contains text (e.g., a MAC address consisting of octets) or, if the value contains text, how that text was encoded (e.g., Windows code page 1252, UTF-8, UTF-16, etc.).

From now on, hexadecimal values outside of the ASCII range will be considered non-printable characters, and will remain in hexadecimal string format.

This is a breaking change.

Up to now, text containing characters that were encoded in extended ASCII (i.e., Windows code page 1252) were converted from raw octets into string text. For example, the French word "hélicoptère" would be received correctly. From now on, that same word will be received as hexadecimal string "68e96c69636f7074e87265", and a QAction will need to convert it back into a string using the correct encoding.

### Enhancements

#### SLNet: Trend graphs in Cube will now also correctly display behavioral change points for table column parameters without advanced naming [ID 41751]

<!-- MR 10.7.0 - FR 10.6.1 -->

Because of a number of enhancements made in SLNet, trend graphs in DataMiner Cube will now also correctly display behavioral change points for table column parameters without advanced naming.

#### Automation: Engine class now has an OnDestroy handler that will allow resources to be cleaned up when a script ends [ID 43919]

<!-- MR 10.7.0 - FR 10.6.1 -->

An `OnDestroy` handler has now been added to the `Engine` class. This handler will allow resources to be cleaned up when a script ends.

Multiple handlers can be added. They will run synchronously, and if one handler throws an error, the others will keep on running.

#### New parameter caches for client apps [ID 43945]

<!-- MR 10.7.0 - FR 10.6.3 -->

Two new parameter caches are now available for client apps (e.g., DataMiner Cube):

- ProtocolParameters (linked to GetProtocolParameter on the client connection)
- ElementProtocolParameters (linked to GetElementProtocolParameter on the client connection)

Both caches are added on the connection object, and have the ability to cache in memory (for the current session) and on disk (for a next session).

#### Automation: All methods that use parameter descriptions have now been marked as obsolete [ID 43948]

<!-- MR 10.7.0 - FR 10.6.1 -->

All methods in the `Skyline.DataMiner.Automation` namespace that use parameter descriptions have now been marked as obsolete.

#### Service & Resource Management: New resource manager settings to configure the number of start action threads and simultaneous actions [ID 44056]

<!-- MR 10.7.0 - FR 10.6.1 -->

Because of a number of enhancements, overall performance has increased when starting multiple bookings in parallel.

Also, in the resource manager, it is now possible to configure the number of start action threads and simultaneous actions.

| Setting | Description |
|---------|-------------|
| MaxAmountOfThreads       | The number of threads the resource manager will use to start bookings.<br>By default, 6 threads will be used. To restore this setting to the default value, set its value to null.<br>Note: The number of threads must at least be set to 2 in order for the scheduler to be able to start an action and keep a thread available for asynchronous continuations. |
| MaxAmountOfParallelTasks | The number of parallel actions the resource manager will start on the threads.<br>By default, the number of parallel action is set to 7. To restore this setting to the default value, set its value to null. |

The following example shows how you can configure this from an automation script.

```csharp
private void UpdateResourceManagerConfigSettings()
{
    var setConfigMessage = new ResourceManagerConfigInfoMessage(ResourceManagerConfigInfoMessage.ConfigInfoType.Set)
    {
        ResourceManagerAutomationSettings = new ResourceManagerAutomationSettings()
        {
            ResourceManagerAutomationThreadSettings = new ResourceManagerAutomationThreadSettings()
            {
                MaxAmountOfParallelTasks = 30,
                MaxAmountOfThreads = 8
            }
        },
    };
    engine.SendSingleResponseMessage(setConfigMessage);
}
```

In most cases, these settings can keep their default value, unless performance has to optimized when multiple concurrent bookings have to be started. In order to increase performance, the number of threads and parallel tasks can be increased, provided the DataMiner Agent and the database can handle the increased load.

> [!NOTE]
>
> - When the above-mentioned settings have been changed, the resource manager must be restarted.
> - Only users with *Modules > System configuration > Tools > Admin tools* permission are allowed to change the above-mentioned settings.
> - If the `SkipDcfLinks` setting is set to true, we recommend that you do not set MaxAmountOfParallelTasks too high. DCF link creation can be an expensive operation. Performing a large number of action in parallel might decrease performance.

#### Enhanced visibility on SLNet connection issues [ID 44069]

<!-- MR 10.7.0 - FR 10.6.3 -->

Visibility on SLNet connection issues has been enhanced:

- When a dashboard cannot be loaded because a DataMiner Agent is offline, an appropriate error message will now appear in that dashboard.

- A new log file named *SLNetConnectionsMonitor.txt* will now keep a historic record of all SLNet connection states.

#### Augmented Operations: Server-side support for new flatline detection modes [ID 44094]

<!-- MR 10.7.0 - FR 10.6.2 -->

When, in DataMiner client applications (e.g., DataMiner Cube), you are configuring the Augmented Operations alarm settings for a particular parameter in an alarm template, from now on, it will be possible to choose between the following flatline detection modes:

| Mode | Description |
|------|-------------|
| Smart flatline alarming    | In this mode, SLAnalytics will automatically determine when a flatline period is anomalous by comparing it to the parameter's historical behavior. A new flatline period will only trigger an alarm if it is significantly longer than previously observed flat periods. |
| Absolute flatline alarming | In this mode, you can define a fixed duration threshold (in seconds) for when a flatline event should trigger an alarm. Additionally, you can assign a severity level to the generated flatline alarm event. |

See also: [Alarm templates: New flatline detection modes in Augmented Operations alarm settings [ID 44191]](xref:Cube_Feature_Release_10.6.2#alarm-templates-new-flatline-detection-modes-in-augmented-operations-alarm-settings-id-44191)

#### DataMiner upgrade: Web-only upgrades with version 10.6.x or above will now require the DMA to have version 10.5.x or above [ID 44103]

<!-- MR 10.7.0 - FR 10.6.1 -->

From now on, it will no longer be allowed to perform web-only upgrades with version 10.6.x or above on DataMiner Agents with a version below 10.5.x.

This means, that any DataMiner Agent on which you want to perform a web-only upgrade with version 10.6.x or above will first have to be upgraded to version 10.5.x or above.

#### dataminer.services: Restrictions when adding a DMA to a DMS [ID 44171]

<!-- MR 10.7.0 - FR 10.6.2 -->

From now on, when you try to add a DataMiner Agent to a DataMiner System, the operation will fail in the following cases:

- The DataMiner Agent is cloud-connected, but the DataMiner System is not.
- The DataMiner Agent and the DataMiner System are cloud-connected, but they do not have the same identity, i.e., they are not part of the same cloud-connected system.

If the DataMiner System is a STaaS system, adding a DataMiner Agent will also fail if the DataMiner Agent is not cloud-connected.

#### SLWatchdog will now report SLNet/SLDataGateway TPL ThreadPool and 'time dilation' issues as run-time errors [ID 44186]

<!-- MR 10.7.0 - FR 10.6.4 -->

From now on, whenever the TPL ThreadPool of SLNet or SLDataGateway would get stuck or a "time dilation" would occur on your system (for example, when a freeze of a virtual machine would cause sleep actions to take longer than anticipated), SLWatchDog will report these issues as a run-time error.

#### Scheduler will now be able to start more than 10 synchronously running automation scripts [ID 44200]

<!-- MR 10.7.0 - FR 10.6.2 -->

Up to now, using Scheduler, it would only be possible to start a maximum of 10 synchronously running automation scripts.

From now on, it will be possible to start more than 10 synchronously running automation scripts.

#### Relational anomaly detection: GetRADParameterGroupInfoResponseMessage now also includes the ID of the RAD parameter group [ID 44237]

<!-- MR 10.7.0 - FR 10.6.2 -->

The response to a `GetRADParameterGroupInfoMessage` will now also include the ID of the RAD parameter group.

#### Service & Resource Management: Enhanced communication between resource managers across DataMiner Agents [ID 44279]

<!-- MR 10.7.0 - FR 10.6.2 -->

A number of enhancements have been done with regard to the communication between resource managers across DataMiner Agents. This will especially enhance performance when starting multiple bookings on non-master DMAs.

#### DataMiner upgrade: DataMiner Assistant DxM will now be included in the DataMiner web upgrade packages [ID 44291]

<!-- MR 10.7.0 - FR 10.6.2 -->

In order to upgrade the DataMiner Assistant DxM, up to now, you had to install a full DataMiner server upgrade package (main release or feature release).

From now on, the DataMiner Assistant DxM will be included in the DataMiner web upgrade packages instead.

See also: [DataMiner upgrade: DataMiner Assistant DxM will now be included in the DataMiner web upgrade packages [ID 44291]](xref:Web_apps_Feature_Release_10.6.2#dataminer-upgrade-dataminer-assistant-dxm-will-now-be-included-in-the-dataminer-web-upgrade-packages-id-44291)

> [!NOTE]
> The DataMiner Assistant DxM will only be upgraded when an older version is found on the DataMiner Agent. If no older version is found, it will not be installed.

#### Automation: Entrypoint ID added to the 'Finished executing script' log entry [ID 44382]

<!-- MR 10.7.0 - FR 10.6.2 -->

The entry added to the *SLAutomation.txt* log file when an automation script has finished will now contain the entrypoint ID.

In the following example, the entrypoint ID can be found at the end of the entry between brackets (11):

`2025/12/18 13:40:00.546|SLAutomation.exe 8.0.1415.2|22300|16908|CAutomation::Execute|INF|0|Finished executing script: 'script_RT_USER_DEFINABLE_APIS_BodySizeLimit_RT_USER_DEFINABLE_APIS_BodySizeLimit_MaxResponseBodySize' (ID: 7) - SUCCEEDED - Execution took 00.308s. (11)`

#### DataMiner backup: 'Ticketing Gateway Configuration' removed from the list of backup options [ID 44401]

<!-- MR 10.7.0 - FR 10.6.3 -->

As the Ticketing app is End of Life as of DataMiner 10.6.x, *Ticketing Gateway Configuration* has now been removed from the list of backup options.

#### DataMiner backup: Scheduler configuration will now be included in full and configuration backups [ID 44584]

<!-- MR 10.7.0 - FR 10.6.3 -->

From now on, the Scheduler configuration found in `C:\Skyline Dataminer\Scheduler` will be included in the following pre-configured backups:

- Full backup (without database)
- Configuration backup (without database)

If you create a custom backup, the Scheduler configuration will be included only if you selected the *DataMiner settings* option.

#### DataMiner Objects Models: Selected subset of fields from DomInstance objects will now be read from the repository API [ID 44600]

<!-- MR 10.7.0 - FR 10.6.4 -->

Since DataMiner 10.6.0/10.6.1, it is possible to read only a selected subset of fields from `DomInstance` objects. In order to further enhance performance, from now on, those subsets will be read from the repository API.

Currently, the repository API will still request the full objects from the database and extract the required values.

> [!NOTE]
> When a field value is requested, the type defined in the field descriptor will be used. In order to determine that type, field descriptor IDs should be unique across section definitions in a DOM module.

#### NotifyMail.html has been updated in order to better support both classic Microsoft Outlook and new Microsoft Outlook [ID 44617]

<!-- MR 10.7.0 - FR 10.6.4 -->

The `C:\Skyline DataMiner\NotifyMail.html` file, i.e., the email report template, has been updated to better support both classic Microsoft Outlook and new Microsoft Outlook.

#### SLDataGateway: Job queue updates will now be logged in SLJobQueues.txt [ID 44661]

<!-- MR 10.7.0 - FR 10.6.4 -->

Up to now, log entries regarding SLDataGateway job queue updates would be logged in the `C:\Skyline DataMiner\Logging\SLDbConnection.txt` file.

From now on, these log entries will be logged in the `C:\Skyline DataMiner\Logging\SLDataGateway\SLJobQueues.txt` file instead.

#### SLLogCollector: Separate log file per instance [ID 44668]

<!-- MR 10.7.0 - FR 10.6.4 -->

Up to now, all SLLogCollector logging of all SLLogCollector instances would end up in the following files, stored in the `C:\ProgramData\Skyline\DataMiner\SL_LogCollector\Log` folder:

- `SL_LogCollector_fulllog.log`
- `SL_LogCollector_log.log`

From now on, each SLLogCollector instance will have its own dedicated log file named `log-[creation timestamp].txt`, stored in the `C:\ProgramData\Skyline Communications\SLLogCollector` folder.

Up to 10 log files will be kept on disk, and the log file of the current instance will be added to the SLLogCollector package.

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

#### Security enhancements [ID 44804]

<!-- 44804: MR 10.7.0 - FR 10.6.5 -->

A number of security enhancements have been made.

#### Enhanced SSH logging [ID 44975]

<!-- MR 10.7.0 - FR 10.6.5 -->

A number of enhancements have been made to the SSH logging:

- From now on, when an SSH connection times out for one of the following reasons, an entry will be added to the element log:

  - Host name could not be resolved.
  - User authentication failed.

- In the SSH logging, it will now clearly be indicated which operations have been performed. For example, during authentication, the logging will now clearly state which authentication methods have been used and what the results were.

- In the SSH logging, most entries will now mention the session ID associated with the entry. As this same session ID is also mentioned in element log entries, users will find it much easier to find out which log entries are related.

Also, an issue has been fixed. When a host name could not be resolved to an IP address, up to now, the SSH connection would incorrectly try to connect to localhost. From now on, when the host name could not be resolved, the connection will fail.

#### DataMiner Object Models: SLDataGateway will now try to read only the selected fields from an OpenSearch or Elasticsearch database [ID 45151]

<!-- MR 10.7.0 - FR 10.6.6 -->

When SLDataGateway is retrieving DOM data from an OpenSearch or Elasticsearch database, from now on, it will attempt to retrieve only the selected fields using the native field projection capabilities of these databases. This will considerably enhance data transfer efficiency and overall performance.

This optimization will leverage the indexed field values to avoid transferring complete objects when only specific fields are needed.

If selected field retrieval is not supported by the database, the system will automatically fall back to retrieving the full object and extracting the required values. This currently applies to STaaS and to queries that require post-filtering or post-sorting.

By default, the value type will be the field type defined by the exposer. When a field value is explicitly requested, the type defined in the field descriptor will be used instead.

> [!IMPORTANT]
> To ensure correct type resolution, field descriptor IDs must be unique across all section definitions within a DOM module. Non-unique IDs may result in incorrect type mapping and unexpected behavior.

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

#### SLAnalytics would not receive 'swarming complete' notifications for swarmed DVE child elements [ID 43984]

<!-- MR 10.7.0 - FR 10.6.1 -->

Up to now, SLAnalytics would incorrectly not receive any "swarming complete" notifications for swarmed DVE child elements. As a result, alarm focus calculations for DVE child elements would be restarted from scratch instead of being fetched from the database.

#### Service & Resource Management: A capability could incorrectly be set to a null value [ID 44125]

<!-- MR 10.7.0 - FR 10.6.1 -->

In some cases, a capability could incorrectly be set to a null value.

From now on, when a capability is booked, it will no longer be possible to set its value to null.

#### Failover: Problem when reloading the scheduled tasks [ID 44234]

<!-- MR 10.7.0 - FR 10.6.1 -->

After a Failover switch, in some cases, the new online agent would incorrectly not reload the scheduled tasks that the former online agent had in memory.

#### History set trending would show gaps where no gaps were expected [ID 44705]

<!-- MR 10.7.0 - FR 10.6.4 -->

Up to now, history set trending would show gaps where no gaps were expected.

From now on, trend records with the following *iStatus* values will no longer cause gaps in trend graphs:

| Value | Description |
|-------|-------------|
| -1  | Element is starting up. |
| -2  | Element is being paused. |
| -3  | Element is being activated. |
| -4  | Element is going into a timeout state. |
| -5  | Element is coming out of a timeout state. |
| -6  | Element is being stopped. |
| -9  | Trending was started for the specified parameter. |
| -10 | Trending was stopped for the specified parameter. |

#### SLAnalytics: Flatline anomaly alerts would incorrectly not be triggered for parameters that are only updated once every 24 hours [ID 45033]

<!-- MR 10.7.0 - FR 10.6.5 -->

Up to now, flatline anomaly alerts would incorrectly not be triggered for parameters that are only updated once every 24 hours.

#### SLLogCollector: Problem when running BPA tests [ID 45053]

<!-- MR 10.7.0 - FR 10.6.6 -->

When the SLLogCollector tool was configured to execute all BPA tests available in the system when collecting log packages, up to now, in some cases, executing those BPA tests would fail and cause them to report a wide variety of exceptions.

From now on, when the SLLogCollector tool detects that it is not possible to execute the BPA tests, it will skip their execution and collect the results of their last successful run.

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
