---
uid: General_Main_Release_10.4.0_CU7
---

# General Main Release 10.4.0 CU7

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Main Release 10.4.0 CU7](xref:Cube_Main_Release_10.4.0_CU7).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.4.0 CU7](xref:Web_apps_Main_Release_10.4.0_CU7).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### BPA test 'Check Antivirus DLLs' will now also check known antivirus file paths [ID 32567]

<!-- MR 10.3.0 [CU19]/10.4.0 [CU7] - FR 10.4.10 -->

The *Check Antivirus DLLs* test will now also check the path of the loaded antivirus DLL files to check whether they were loaded from a known antivirus path.

This means that the test will now be able to report a fail when a new antivirus DLL file is added or when an existing antivirus DLL file is renamed, even when the file location remains the same.

#### MessageBroker: Clients will now throw a DataMinerMessageBrokerException when a single NATS node is stopped while they are busy writing data [ID 38523]

<!-- MR 10.4.0 [CU7] - FR 10.4.3 -->

When a single NATS node was stopped because it needed to be reconfigured, up to now, clients that were busy writing data would throw a *NotSupportedException*. From now on, they will throw a *DataMinerMessageBrokerException* instead.

#### MessageBroker: Each individual chunk will now be sent with a dynamic timeout [ID 38633]

<!-- MR 10.4.0 [CU7] - FR 10.4.6 -->

When chunked messages are being sent using MessageBroker, from now on, each individual chunk will be sent with a dynamic timeout instead of a static 5-second timeout.

The dynamic timeout will be calculated as the time it would take to send the chunk at a speed of 1 Mbps, rounded up to the nearest second.

> [!NOTE]
> The minimum timeout will always be 5 seconds.

#### MessageBroker: New NATS reconnection algorithm [ID 38809]

<!-- MR 10.4.0 [CU7] - FR 10.4.6 -->

From now on, when NATS reconnects, it will no longer perform the default reconnection algorithm of the NATS library. Instead, it will perform a custom reconnection algorithm that will do the following:

1. Re-read the MessageBroker configuration file.
1. Update the endpoints to which MessageBroker will connect.

#### Security enhancements [ID 38869] [ID 40229]

<!-- 38869: MR 10.4.0 [CU7] - FR 10.4.6 -->
<!-- 40229: MR 10.3.0 [CU19]/10.4.0 [CU7] - FR 10.4.9 -->

A number of security enhancements have been made.

#### MessageBroker: 'Subscribe' method of the 'NatsSession' class has now been made completely thread-safe [ID 38939]

<!-- MR 10.4.0 [CU7] - FR 10.4.6 -->

The *Subscribe* method of the `NatsSession` class has now been made completely thread-safe.

#### Caching of protocol signature information will enhance overall performance during a DataMiner startup [ID 39468]

<!-- MR 10.3.0 [CU19]/10.4.0 [CU7] - FR 10.4.7 -->

Information regarding protocol signature validation will now be cached. This will considerably enhance overall performance during a DataMiner startup.

#### MessageBroker: Clients will now first attempt to connect via the local NATS node [ID 39727]

<!-- MR 10.4.0 [CU7] - FR 10.4.9 -->

From now on, when a client connects to the DataMiner System, an attempt will first be made to connect to the NATs bus via the local NATS node. Only when this attempt fails, will the client connect to the NATS bus via another node.

#### Improved performance when alarm filters containing operators are used [ID 39732]

<!-- MR 10.4.0 [CU7] - FR 10.4.10 -->

Alarm filters that contain the operators AND, OR, or NOT (without brackets) will now be translated to OpenSearch queries, which will improve the performance of these filters. This will for example lead to improved performance when filtering alarms on a specific element and on severity.

#### When stopping, native processes will only wait for 30 seconds to close the MessageBroker connection when necessary [ID 39863]

<!-- MR 10.4.0 [CU7] - FR 10.4.9 -->

When a native process (e.g. SLDataMiner) is stopping, it will by default wait for 30 seconds before it closes the MessageBroker connection.

However, in some rare cases, there is no need to wait for 30 seconds. In those cases, the MessageBroker connection will be closed immediately.

#### SLASPConnection is now a 64-bit process [ID 39978]

<!-- MR 10.4.0 [CU7] - FR 10.4.8 -->

*SLASPConnection.exe* is now a 64-bit process.

This will prevent out of memory exceptions from being thrown, especially on larger DataMiner Systems.

#### SLNet.txt log file will no longer contain any logging from MessageBroker [ID 40061]

<!-- MR 10.4.0 [CU7] - FR 10.4.9 -->

From now on, by default, the *SLNet.txt* log file will no longer contain any logging from MessageBroker.

#### MessageBroker: NuGet packages upgraded [ID 40164]

<!-- MR 10.4.0 [CU7] - FR TBD -->

The *DataMinerMessageBroker.API* and *DataMinerMessageBroker.API.Native* NuGet packages have been upgraded to version 2.7.3.

#### BPA tests will no longer be executed immediately after a DataMiner restart [ID 40201]

<!-- MR 10.3.0 [CU19]/10.4.0 [CU7] - FR 10.4.10 -->

Up to now, all BPA tests would be executed immediately after DataMiner had been started.

From now on, the *Report Active RTE* test will be executed for the first time exactly 8 minutes after DataMiner has been started, and all other BPA tests will be executed between 10 and 60 minutes after DataMiner has been started.

#### Service & Resource Management: Enhanced synchronization of resources and resource pools between the SRM master agent and the other agents in a DataMiner System [ID 40389]

<!-- MR 10.4.0 [CU7] - FR 10.4.10 -->

A number of enhancements have been made with regard to the synchronization of resources and resource pools between the SRM master agent and the other agents in a DataMiner System. This should improve performance when creating resources on non-master agents.

#### DxMs upgraded to versions requiring .NET 8 [ID 40445]

<!-- MR 10.4.0 [CU7] - FR 10.4.10 -->

All DxMs included in the DataMiner upgrade package have now been upgraded to versions requiring .NET 8.

#### SLAnalytics: Reduced memory usage [ID 40450]

<!-- MR 10.3.0 [CU19]/10.4.0 [CU7] - FR 10.4.10 -->

Because of a number of enhancements, overall memory usage of SLAnalytics has been reduced.

#### Storage as a Service: Maximum page size can now be specified in queries sent to dataminer.services [ID 40477]

<!-- MR 10.4.0 [CU7] - FR 10.4.9 [CU1] -->

When a query was sent to dataminer.services, up to now, the maximum page size would always be set to 1000 (i.e. the default setting).

From now on, the maximum page size can be specified in the query. This will considerable enhance overall query performance.

> [!TIP]
> See also:
>
> - [Class CrudHelperComponent\<T\>](xref:Skyline.DataMiner.Net.ManagerStore.CrudHelperComponent`1)
> - [Method PreparePaging](xref:Skyline.DataMiner.Net.ManagerStore.CrudHelperComponent`1.PreparePaging*)

#### SLNet: DataMiner Cube's Scheduler app will now support user access permissions to specific dashboard folders [ID 40550]

<!-- MR 10.3.0 [CU19]/10.4.0 [CU7] - FR 10.4.10 -->

Because of a number of enhancements made to SLNet, DataMiner Cube's Scheduler app will now support user access permissions to specific dashboard folders.

### Fixes

#### MessageBroker: Problem when trying to read a file that was being updated by another process [ID 39408]

<!-- MR 10.4.0 [CU7] - FR 10.4.7 -->

In some rare cases, an exception could be thrown when MessageBroker tried to read a file that was being updated by another process.

#### Problem when disposing an ISession with multiple subscriptions [ID 39483]

<!-- MR 10.4.0 [CU7] - FR 10.4.7 -->

In some cases, an `InvalidOperationException` could be thrown when a .NET Framework host application (e.g. DataMiner Automation) disposed an ISession with multiple subscriptions without having disposed the subscriptions first.

#### MessageBroker: Problem when receiving a Subscribe call while reconnecting [ID 39633]

<!-- MR 10.4.0 [CU7] - FR 10.4.7 -->

When MessageBroker received a Subscribe call while it was reconnecting, in some cases, the subscription could fail.

#### SLElement memory leak while NATS is down [ID 39889]

<!-- MR 10.4.0 [CU7] - FR 10.4.7 [CU0] -->

When the NATS server was down, SLElement would leak memory while trying to push data to the NATS connection.

#### MessageBroker: Reconnection mechanism could cause the overall CPU load to increase [ID 40071]

<!-- MR 10.4.0 [CU7] - FR 10.4.9 -->

Whenever the MessageBroker client loses its connection to the NATS server, it will try to reconnect. Because of an internal issue, up to now, this reconnection mechanism could cause the overall CPU load to increase. This issue has now been fixed.

#### Problem in SLDataMiner when redundancy groups were configured to switch based on connectivity [ID 40118]

<!-- MR 10.3.0 [CU19]/10.4.0 [CU7] - FR 10.4.10 -->

When redundancy groups were configured to switch based on connectivity, it could occur that the signals sent to SLDataMiner contained duplicates. In a system with a heavy load, this could cause too many of these to be sent, which would cause a memory leak in the SLDataMiner process and eventually caused the process to crash.

Performance improvements have now been implemented to avoid sending duplicate signals and to better process the signals. A throttling mechanism has also been implemented: in case SLDataMiner detects that too many signals are being sent, the DCF calculation will be slowed down to allow the system to catch up. In the logging, this will be mentioned in *SLConnectivity.txt* like in the example below:

```txt
07/04 09:13:32.713|SLNet.exe|Log|INF|0|174|Received throttle request to slowdown DCF path calculation current value: 5000 ms

2024/07/04 09:15:34.019|SLNet.exe|Log|INF|0|172|Received stop throttle request to resume normal DCF path calculation current value: 1000 ms

07/04 09:13:32.713|SLNet.exe|Log|INF|0|174|Received throttle request to slowdown DCF path calculation current value: 5000 ms

2024/07/04 09:16:29.462|SLNet.exe|Log|INF|0|175|Received throttle request to slowdown DCF path calculation current value: 25000 ms

2024/07/04 09:22:51.732|SLNet.exe|Log|INF|0|54|Received stop throttle request to resume normal DCF path calculation current value: 1000 ms
```

#### Changes implemented with parameter-specific template editors not saved correctly [ID 40125]

<!-- MR 10.3.0 [CU19]/10.4.0 [CU7] - FR 10.4.10 -->

When you changed the alarm or trend template for a table parameter (e.g. by going to the templates tab on the parameter card), it could occur that the wrong line from the template was edited. For example, if a template contained exactly one line for a column in a table, and that line was configured with the filter "SL*", the parameter template editor would show the configuration corresponding to the line in the template with the filter even if that line was not applicable for the current cell. Now, instead an empty template configuration will be shown, corresponding to the filter "\*". When you edit and save this configuration, a new line with filter "\*" will be added to the template.

In addition, when there were two or more lines in the trend template for a table parameter, but none were applicable for the current cell for which you edited the trend template, the parameter template editor would show and create a new line in the template corresponding to an empty filter, instead of to the filter "\*". This has now also been fixed.

Finally, if you changed the information template for a parameter, and the information template did not contain a line for the current parameter, the ID was not saved correctly. In addition, for table parameters, a line with an empty filter would be saved, instead of the filter "\*".

#### Problem in SLProtocol because virtual primary element behaved like regular element [ID 40321]

<!-- MR 10.4.0 [CU7] - FR 10.4.10 -->

Because of a race condition, it could occur that a virtual primary element in a redundancy group behaved as if it were a regular DataMiner element. This could cause a runtime error in the SLProtocol process and could eventually cause the process to crash.

#### GQI: Problems with persisting GQI sessions and incorrectly serialized GenIfAggregateException messages [ID 40333]

<!-- MR 10.4.0 [CU7] - FR 10.4.9 -->

When the user's SLNet connection was lost, the GQI session of a query with real-time updates enabled would incorrectly persist, potentially causing both an unhandled exception to be thrown when GQI tried to send an update to the user and SLHelper to crash.

Also, *GenIfAggregateException* messages would not be serialized correctly, causing the following exception to be added to the SLHelperWrapper log file:

```txt
2024/07/25 15:25:35.636|SLNet.exe|SendMessage|ERR|0|264|System.Reflection.TargetInvocationException: Exception has been thrown by the target of an invocation. ---> System.Runtime.Serialization.SerializationException: Member 'InnerExceptions' was not found.
   at System.Runtime.Serialization.SerializationInfo.GetElement(String name, Type& foundType)
   at System.Runtime.Serialization.SerializationInfo.GetValue(String name, Type type)
   at Skyline.DataMiner.Analytics.GenericInterface.GenIfAggregateException..ctor(SerializationInfo info, StreamingContext context)
```

#### Problem with SLProtocol when using a timer to perform 'SNMP Get' operations [ID 40402]

<!-- MR 10.3.0 [CU19]/10.4.0 [CU7] - FR 10.4.10 -->

When using a timer to perform *SNMP Get* operations on all rows in a table, you have two options:

- the thread pool option (which you activate by specifying the *threadPool* keyword), or
- the default logic (which you activate by not specifying the *threadPool* keyword).

When the default logic was used, up to now, when you stopped an element before the *SNMP Get* operations were completed, resources that were still required would incorrectly be cleaned up, leading to the SLProtocol process being stopped.

In order to remedy this behavior, the `DeInit` method of the `protocol` object has now been updated. It will now always wait for the *SNMP Get* operations to finish before proceeding.

Also, up to now, the thread that handles the *SNMP Get* operations would not correctly catch exceptions, which resulted in no crashdump files being automatically generated when exceptions occurred. This made it difficult to diagnose the issue, as it required setting up a procdump and waiting for the issue to occur again.

#### Protocols: Problem when a response with a 'next param' and a 'fixed length' parameter did not have a trailer defined [ID 40430]

<!-- MR 10.3.0 [CU19]/10.4.0 [CU7] - FR 10.4.10 -->

Up to now, when a response contained a parameter with a LengthType equal to "next param" and another parameter with a LengthType equal to "fixed" but no trailer, SLPort would incorrectly return the payload to SLProtocol as soon as it read at least the number of bytes that was configured in the fixed length parameter.

#### Cassandra Cluster Migrator: Problem when retrying an alarm migration [ID 40434]

<!-- MR 10.3.0 [CU19]/10.4.0 [CU7] - FR 10.4.10 -->

When, using the Cassandra Cluster Migrator tool (*SLCCMigrator.exe*), you retried an alarm migration, the migration would immediately fail and go into a *Cancelled* state.

#### SLAnalytics - Pattern matching: Problem when a pattern was deleted on one DMA while it was being edited on another DMA [ID 40471]

<!-- MR 10.4.0 [CU7] - FR 10.4.10 -->

In some rare cases, SLAnalytics could stop working when a pattern was deleted on one DMA while it was being edited on another DMA.

#### Cassandra Cluster Migrator: Problem when initializing a migration [ID 40476]

<!-- MR 10.3.0 [CU19]/10.4.0 [CU7] - FR 10.4.10 -->

When the Cassandra Cluster Migrator tool (*SLCCMigrator.exe*) initialized a migration, SLDataGateway would stop writing alarms to the TimeTrace table. When the migration was subsequently aborted, data would be lost.

#### Service & Resource Management: Problem when a reservation instance property had been updated while the agents in the DMS were disconnected [ID 40484]

<!-- MR 10.4.0 [CU7] - FR 10.4.10 -->

When a property of a reservation instance had been updated while the agents in the DMS were disconnected, in some cases, when the agents were connected again, an error could occur when another reservation instance property was updated.

#### Problem with SNMPv3 communication when the same device was polled with different credentials [ID 40502]

<!-- MR 10.3.0 [CU19]/10.4.0 [CU7] - FR 10.4.10 -->

When two SNMPv3 interfaces pointing to the same device, either on the same element or on two different elements, were using different credentials, SNMP communication using one set of credentials would break as soon as an SNMP operation was executed using the other set of credentials. An element restart was required to get communication working again.

#### DataMiner Object Models: Not possible to create multiple DOM module subscriptions [ID 40508]

<!-- MR 10.3.0 [CU19]/10.4.0 [CU7] - FR 10.4.10 -->

Up to now, when an attempt was made to create multiple DOM module subscriptions at a time, only the first subscription would be created.

From now on, it will be possible to create multiple DOM module subscriptions on one connection.

#### SLAnalytics - Alarm focus: Problem with time of arrival when clearing a focus event [ID 40509]

<!-- MR 10.3.0 [CU19]/10.4.0 [CU7] - FR 10.4.10 -->

When a focus event was cleared because an element had been deleted, up to now, the time of arrival of the new focus event (i.e. the time at which the focus event had been cleared) would incorrectly be identical to the time of arrival of the focus event that had been cleared.

From now on, the time of arrival of the new focus event will instead be the current time (i.e. the time at which the element was deleted).
