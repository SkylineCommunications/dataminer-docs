---
uid: General_Main_Release_10.5.0_changes
---

# General Main Release 10.5.0 – Changes (preview)

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## Changes

### Enhancements

#### Security enhancements [ID_37349] [ID_38052] [ID_38263] [ID_38869] [ID_38951]

<!-- 37349: MR 10.5.0 - FR 10.4.2 -->
<!-- 38052: MR 10.5.0 - FR 10.4.2 -->
<!-- 38263: MR 10.5.0 - FR 10.4.3 -->
<!-- 38869: MR 10.5.0 - FR 10.4.6 -->
<!-- 38951: MR 10.5.0 - FR 10.4.4 -->

A number of security enhancements have been made.

#### Deprecated NotifyDataMiner type 'NT_CONNECTIONS_TO_REMOVE' can no longer be used [ID_37595]

<!-- MR 10.5.0 - FR 10.4.1 -->

From now on, the deprecated NotifyDataMiner type *NT_CONNECTIONS_TO_REMOVE* can no longer be used.

#### SLAnalytics - Proactive cap detection: Enhanced detection of possible future alarm threshold breaches [ID_37681]

<!-- MR 10.5.0 - FR 10.4.1 -->

When an increasing or decreasing trend is detected on a highly aggregated level (i.e. a trend that persists for more than 24 hours), from now on, a proactive cap detection suggestion event will be generated when there is a probability that the trend change in question could lead to a breach of a critical alarm limit at some point in the future, even when the breach has not yet been confirmed by the full prediction model built on the historic trend data.

#### Service & Resource Management: Enhanced performance of ResourceManagerHelper.GetResources when using the ResourceExposers.ID.Equal filter [ID_37720]

<!-- MR 10.5.0 - FR 10.4.1 -->

Because of a number of enhancements, overall performance of the `ResourceManagerHelper.GetResources` method has increased when using a `ResourceExposers.ID.Equal` filter.

Also, the performance of `TrueFilterElement<Resource>` has been improved.

#### SLAnalytics - Behavioral anomaly detection: Enhanced coloring of trend graph change point indicators [ID_37827]

<!-- MR 10.5.0 - FR 10.4.1 -->

In a trend graph, the occurrence of change points is indicated by colored rectangular regions below the graph.

Up to now, these regions had a dark color when an alarm event would have been triggered for the change point in question if alarm monitoring had been activated for that type of change point.

From now on, a rectangular region will have a dark color when the change point in question actually triggered an event:

- a suggestion event (if alarm monitoring was not activated for that type of change point), or
- an alarm event (if alarm monitoring was activated for that type of change point).

#### SLAnalytics: Enhanced error logging when retrieving trend data [ID_37931]

<!-- MR 10.5.0 - FR 10.4.1 -->

More extensive information will now be logged when errors occur while retrieving trend data.

#### Service & Resource Management: Migrating profiles and resources from XML to Elasticsearch/OpenSearch is no longer supported [ID_37979]

<!-- MR 10.5.0 - FR 10.4.2 -->

As storing profiles and resources in XML files is no longer supported as from DataMiner 10.4.0/10.4.1, migrating profiles and resources from XML to Elasticsearch/OpenSearch is now no longer supported as well. If you need to migrate profiles and resources, do so before you upgrade to version 10.4.0.

Also, the *NotAllClusterAgentsReachable* error in ResourceManager is now considered obsolete and will no longer be returned.

#### DataMiner Object Models: Reading DOM objects and ModuleSettings in parallel [ID_38023]

<!-- MR 10.5.0 - FR 10.4.2 -->

It is now possible to read DOM objects and ModuleSettings in parallel. This will considerably improve overall performance.

#### SLAnalytics - Behavioral anomaly detection: Reduction of memory used for trend icon calculation [ID_38041]

<!-- MR 10.5.0 - FR 10.4.2 -->

Up to now, SLAnalytics would always keep average trend data for all trended parameters on the system for a configurable time frame in order to determine which trend icon to display in the absence of change points. From now on, it will only keep trend data and calculate state icons for 250,000 trended parameters at the most, reducing memory usage.

#### GQI: Sort operator will now be forwarded to the correct query of a Join operator [ID_38150]

<!-- MR 10.5.0 - FR 10.4.2 -->

When you add a Sort operator after adding a Join operator, that Sort operator will now automatically be forwarded to the correct query in the Join operator. This will considerably enhance performance, especially when sorting on a joined column.

When you sort on a joined column, the Sort operator will be forwarded in the following situations:

- In case of an inner join
- In case of a left join, but only if all sorts are descending
- In case of a right join

#### DataMiner Object Models: Required list fields can no longer be set to an empty list [ID_38238]

<!-- MR 10.5.0 - FR 10.4.3 -->

From now on, when the value of a required list field is set to an empty list, one of the following errors will be thrown:

- `DomInstanceHasMissingRequiredFieldsForCurrentStatus` (when using the DOM status system)
- `DomInstanceDoesNotContainAllRequiredFieldsForSectionDefinition` (when not using the DOM status system)

#### DataMiner Object Models: HistoryChanges will now be processed in bulk [ID_38241]

<!-- MR 10.5.0 - FR 10.4.3 -->

Up to now, if history storage was enabled, when DomInstances were created, updated or deleted, a HistoryChange operation would be executed for every DomInstance separately.

From now on, for every batch of DomInstances that are processed in bulk, the history records will also be processed in bulk.

#### SLAnalytics: Cassandra tables 'analytics_parameterinfo_v1' and 'analytics_wavestream' will be dropped when downgrading [ID_38336]

<!-- MR 10.5.0 - FR 10.4.3 -->

When downgrading a DataMiner System using a Cassandra database, from now on, the Cassandra tables *analytics_parameterinfo_v1* and *analytics_wavestream* will be dropped. Contrary to the old versions, the new versions no longer contain display keys.

#### User-Defined APIs: Enhanced logging [ID_38491]

<!-- MR 10.5.0 - FR 10.4.3 -->

Up to now, when a user-defined API was triggered, log entries like the ones below would only be added to the *SLUserDefinableApiManager.txt* file when the log level was set to 5. From now on, when a user-defined API is triggered, these entries will be added to *SLUserDefinableApiManager.txt* when the log level is set to 0 (i.e. always).

```txt
2024/01/18 10:13:00.740|SLNet.exe|Handle|CRU|0|152|[1f9cd6c045] Started handling API trigger from NATS for route 'dma/id_2'.
2024/01/18 10:13:01.268|SLNet.exe|Handle|CRU|0|152|[1f9cd6c045] Handling API trigger from NATS for route 'dma/id_2' SUCCEEDED after 526.46 ms. API script provided response code: 200. (Token ID: 78dd7916-6d01-4c17-9010-530c28338120)
```

#### DxMs upgraded [ID_38499] [ID_38596] [ID_38743] [ID_38900] [ID_39278]

<!-- RNs 38499/38596: MR 10.5.0 - FR 10.4.3 -->
<!-- RN 38743/38900: MR 10.5.0 - FR 10.4.4 -->
<!-- RN 39278: MR 10.5.0 - FR 10.4.5 -->

The following DataMiner Extension Modules (DxMs), which are included in the DataMiner upgrade package, have been upgraded to the indicated versions:

- DataMiner ArtifactDeployer: version 1.6.8
- DataMiner CoreGateway: version 2.14.6
- DataMiner FieldControl: version 2.10.5
- DataMiner Orchestrator: version 1.5.8
- DataMiner SupportAssistant: version 1.6.8

For detailed information about the changes included in those versions, refer to the [dataminer.services change log](xref:DCP_change_log).

#### MessageBroker: Each individual chunk will now be sent with a dynamic timeout [ID_38633]

<!-- MR 10.5.0 - FR 10.4.6 -->

When chunked messages are being sent using MessageBroker, from now on, each individual chunk will be sent with a dynamic timeout instead of a static 5-second timeout.

The dynamic timeout will be calculated as the time it would take to send the chunk at a speed of 1 Mbps, rounded up to the nearest second.

> [!NOTE]
> The minimum timeout will always be 5 seconds.

#### GQI: Ad hoc data source now supports real-time updates [ID_38643]

<!-- MR 10.5.0 - FR 10.4.4 -->

The ad hoc data source now supports real-time updates.

For this purpose, the [IGQIUpdateable](xref:GQI_IGQIUpdateable) interface must be implemented in the data source.

#### SLAnalytics: Enhanced management of DataMinerObjectDeleteMessages [ID_38734]

<!-- MR 10.5.0 - FR 10.4.4 -->

Because of a number of enhancements, overall memory usage has been reduced, especially with regard to the management of DataMinerObjectDeleteMessages.

#### SLLogCollector will now run the 'tasklist /fo TABLE' command [ID_38842]

<!-- MR 10.5.0 - FR 10.4.4 -->

SLLogCollector will now by default run the `tasklist /fo TABLE` command, and save the output in the `Logs\Windows` folder of the generated package.

#### Grouping of GQI event messages [ID_38913]

<!-- MR 10.5.0 - FR 10.4.5 -->

From now on, GQI event messages sent by the same GQI session within a time frame of 100 ms will be grouped into one single message.

#### MessageBroker: 'Subscribe' method of the 'NatsSession' class has now been made completely thread-safe [ID_38939]

<!-- MR 10.5.0 - FR 10.4.6 -->

The *Subscribe* method of the `NatsSession` class has now been made completely thread-safe.

#### Service & Resource Management: Enhanced performance when activating function DVEs [ID_38972]

<!-- MR 10.5.0 - FR 10.4.6 -->

Because of a number of enhancements, overall performance has increased when activating function DVEs.

#### GQI: Errors related to real-time GQI data updates will now also be logged [ID_38986]

<!-- MR 10.5.0 - FR 10.4.6 -->

From now on, errors related to real-time GQI data updates will also be logged.

For example:

- When an ad hoc data source is not able to send an update due to API methods being used incorrectly.
- When a built-in data source is not able to send an update.
- When the connection used to send the updates to the client gets lost.

Exceptions associated with a custom data source will be logged in the log file of the data source in question.

#### Factory reset tool SLReset.exe will now remove the NodeId.txt files [ID_39092]

<!-- MR 10.5.0 - FR 10.4.5 -->

When the factory reset tool (*SLReset.exe*) is run, from now on, it will also remove the *NodeId.txt* files located in the following folders:

- *C:\\ProgramData\\Skyline Communications\\DxMs Shared\\Data*
- *C:\\ProgramData\\Skyline Communications\\DataMiner Orchestrator\\Data*

These files will be recreated with a new identifier when DataMiner or any of its extension modules is restarted.

#### STaaS: Enhanced performance when fetching alarm distribution data [ID_39197]

<!-- MR 10.5.0 - FR 10.4.5 -->

Because of a number of enhancements, overall performance has increased when fetching alarm distribution data from the database, especially on Failover systems using Storage as a Service.

#### GQI: Enhanced error handling [ID_39226]

<!-- MR 10.5.0 - FR 10.4.5 [CU0] -->

In order to enhance the way in which specific GQI errors are handled, the following new `GenIfException` types have been introduced:

- `GenIfSecurityException` will be thrown when a request cannot be satisfied because the action is not allowed.
- `GenIfAggregateException` will be thrown when a request caused multiple independent exceptions.

Also, error handling has changed for the following GQI requests:

- `GenIfCloseSessionRequest`

  This request can be used to close multiple sessions at the same time. However, up to now, it would only close sessions until an error occurred, leaving the remaining sessions open. From now on, if an exception occurs for more than one session, a `GenIfAggregateException` will be thrown containing the individual exceptions.

- `GenIfSessionHeartbeatRequest`

  This request can be used to send a heartbeat to multiple sessions at the same time in order to keep them alive.

  Similar to the `GenIfCloseSessionRequest`, up to now, it would only send a heartbeat to the first sessions in the request until an error occurred. In some cases, this could cause sessions to expire unexpectedly.

As to logging, behavior has changed with respect to exceptions:

- `GenIfAggregate` will log each individual exception separately.
- `GenIfSessionException` will be logged as a warning without stack trace.
- `GenIfSecurityException` will be logged as a warning without stack trace.
- Any other error will be logged as error with stack trace.

#### SLAnalytics - Behavioral anomaly detection: A decreasing trend slope will now be labeled as a trend change instead of a variance decrease [ID_39249]

<!-- MR 10.5.0 - FR 10.4.6 -->

Up to now, in some cases, a decreasing trend slope would be labeled as a variance decrease. From now on, a decreasing trend slope will be labeled as a trend change instead.

#### Enhanced performance when starting up a DataMiner Agent because of SLDataMiner loading protocols in parallel [ID_39260]

<!-- MR 10.5.0 - FR 10.4.6 -->

From now on, at DataMiner startup, SLDataMiner will load protocols in parallel. This will considerably increase overall performance when starting up a DataMiner Agent.

#### Service & Resource Management: Queue will now be skipped when processing SetSrmJsonSerializableProperties requests [ID_39264]

<!-- MR 10.5.0 - FR 10.4.6 -->

When the *ResourceManagerHelper* methods *UpdateReservationInstanceProperties* or *SafelyUpdateReservationInstanceProperties* were used to update properties of a booking, up to now, their action was queued on the master DMA to be handled sequentially for all bookings.

From now on, the *SetSrmJsonSerializableProperties* requests will skip said queue.

#### Enhanced SLDBConnection logging [ID_39267]

<!-- MR 10.5.0 - FR 10.4.6 -->

A number of enhancements have been made with regard to the logging of errors and warnings in the *SLDBConnection.txt* log file.

#### SLAnalytics - Proactive cap detection: Enhanced clearing of proactive detection suggestion events [ID_39296]

<!-- MR 10.5.0 - FR 10.4.6 -->

A proactive detecting suggestion event indicating a forecasted crossing of a critical alarm threshold will now be cleared sooner. As soon as the system detects that the predicted trend has dropped below the threshold in question will the suggestion event be cleared.

#### GQI: Changing the minimum log level no longer requires an SLHelper restart [ID_39309]

<!-- MR 10.5.0 - FR 10.4.6 -->

Up to now, when you changed the *serilog:minimum-level* setting in `C:\Skyline DataMiner\Files\SLHelper.exe.config`, the change would only take effect after an SLHelper restart.

From now on, when you change this setting, the change will take effect the moment you save the configuration file. Restarting SLHelper will no longer be necessary.

#### ProtocolCache.txt replaced by ProtocolCacheV2.txt [ID_39316]

<!-- MR 10.5.0 - FR 10.4.6 -->

The *ProtocolCache.txt* file, located in the `C:\Skyline DataMiner\System Cache\` folder, has now been replaced by the *ProtocolCacheV2.txt* file.

While the *ProtocolCache.txt* file only contained information about the protocols that were not fully compatible with Cassandra, the *ProtocolCacheV2.txt* file will also contain information like minimum required DataMiner version.

> [!IMPORTANT]
> up to now, when no compliance information was specified in a protocol, all QActions would be checked for queries incompatible with Cassandra. From now on, it will be assumed that a protocol version is compatible with Cassandra unless Cassandra compliance is explicitly set to false in the `<Compliancies>` element of the protocol.

#### SLDataGateway: Enhanced logging [ID_39341]

<!-- MR 10.5.0 - FR 10.4.6 -->

A number of enhancements have been made with regard to the logging of the SLDataGateway process.

The *SLDBConnection.txt* and *SLCloudStorage.txt* log files will now contain cleaner entries, and entries of type "Error" will also be added to the *SLError.txt* file.

Also, run-time log level updates will now be applied at runtime without requiring a DataMiner restart.

#### GQI now also logs requests to SLNet [ID_39355]

<!-- MR 10.5.0 - FR 10.4.6 -->

From now on, when the *serilog:minimum-level* setting in `C:\Skyline DataMiner\Files\SLHelper.exe.config` is set to "Debug" or lower, GQI will also log information about requests sent to SLNet.

Types of log entries related to SLNet requests:

- `Started SLNet request <RequestID> with <MessageCount> messages`

  This type of entry will be added to the log when GQI starts a request to SLNet, before the messages included in the request are sent.

  - *RequestID*: A unique ID that will allow you to find all log entries associated with one particular SLNet request.
  - *MessageCount*: The number of SLNet messages included in the request.

- `Sending SLNet message <RequestID>.<Index>: <Description>`

  This type of entry will be added to the log for each individual message in an SLNet request.

  - *RequestID.Index*: The unique ID of the message, consisting of the *RequestID* (which identifies the request) and an *Index* (i.e. the sequence number of the message).
  - *Description*: The string representation of the actual SLNet message, which should give a short but meaningful description of the message.

- `Finished SLNet request <RequestID> in <Duration>ms`

  This type of entry will be added to the log when GQI finishes a request to SLNet, regardless of whether the request was successful or not.

  - *RequestID*: The unique ID of request.
  - *Duration*: The duration of the request, including the time it took for GQI to process it (in milliseconds).

#### Enhanced error message 'Failed to create one or more storages' [ID_39360]

<!-- MR 10.5.0 - FR 10.4.6 -->

When DataMiner fails to start up due to a problem that occurred while connecting to the database, a `Failed to create one or more storages` message will be thrown.

From now on, this error message will include a reference to the StorageModule log file, in which you can find more information about the problem that occurred:

`More info might be available in C:\ProgramData\Skyline Communications\DataMiner StorageModule\Logs\DataMiner StorageModule.txt.`

#### MySql.Data.dll file is now deprecated [ID_39370]

<!-- MR 10.5.0 - FR 10.4.6 -->

The *MySql.Data.dll* file, located in `C:\Skyline DataMiner\ProtocolScripts\`, should from now on be considered deprecated.

This file will no longer be included in DataMiner upgrade packages. Also, a BPA test has been created to detect the presence and usage of this DLL file in protocols and Automation scripts.

To remove all references to the *MySql.Data.dll* file in your protocols and Automation scripts, do the following:

1. Open DataMiner Cube.
1. Open *System Center*.
1. Go to *Agents > BPA*.
1. Run the *Check Deprecated MySql DLL* test (if it has not been run yet).
1. If references to the DLL file have been found, click the ellipsis button next to the message to see an overview of all protocols and Automation scripts that are still using this DLL file.

   This overview is displayed as a string in JSON format. It will contain the following information:

   - The names and versions of the protocols that are still using this file, including the IDs of the QActions in which this file is referenced.
   - The names of the Automation scripts that are still using this file.

1. Replace every reference to the *MySql.Data.dll* file in the listed protocol QActions and Automation scripts by a reference to the [MySql.Data NuGet](https://www.nuget.org/packages/MySql.Data). Using that NuGet should not require any other changes to the existing code.

When you have replaced all references to the *MySql.Data.dll* file, do the following:

1. Stop the DataMiner Agent.
1. Remove the *MySql.Data.dll* file from the `C:\Skyline DataMiner\ProtocolScripts\` folder.
1. Start the DataMiner Agent.

> [!IMPORTANT]
> The BPA test *Check Deprecated MySql DLL* is only able to detect whether the *MySql.Data.dll* file is referenced directly. For example, if a QAction would contain a reference to a particular DLL that references the *MySql.Data.dll* file, the BPA will not be able to detect this.
> When you remove the *MySql.Data.dll* file, it is advised to keep a temporary copy and to check the DataMiner log files *Errors* and *Errors in Protocol* for lines mentioning missing references to the *MySql.Data.dll* file when a QAction or an Automation script was executed.

#### SLNet: Enhancements that optimize the performance of the Jobs and Ticketing APIs [ID_39385]

<!-- MR 10.5.0 - FR 10.4.6 -->

Because of a number of enhancements to SLNet, overall performance of the *Jobs* and *Ticketing* APIs has increased, especially when retrieving data from the database.

#### SLLogCollector: Enhancements to make sure the JAVA_HOME variable is set [ID_39409]

<!-- MR 10.5.0 - FR 10.4.6 -->

A number of enhancements have been made to prevent SLLogCollector from experiencing problems when the JAVA_HOME variable is not set:

- SLLogCollector is now able to pass environment variables to helper executables. This will allow temporarily setting an environment variable to make sure a particular tool can be run correctly.

- In SLLogCollector, the timeout for helper executables has been reduced from 5 minutes to 1 minute.

- An upgrade action has been created to set the JAVA_HOME variable in case this has not been done by [nodetool](xref:TOONodetool).

#### SLAnalytics - Behavioral anomaly detection: Enhanced performance when updating anomalous change point alarms and suggestion events [ID_39453]

<!-- MR 10.5.0 - FR 10.4.6 -->

Because of a number of enhancements, overall performance has increased when updating an alarm or suggestion event generated after an anomalous change point has been detected.

### Fixes

#### Storage as a Service: Resources would not always be released correctly [ID_38058]

<!-- MR 10.5.0 - FR 10.4.2 -->

Resources would not always be released correctly, causing some resources to be used for longer than strictly necessary.

#### SLReset: Problem when cleaning a Cassandra database [ID_38332]

<!-- MR 10.5.0 - FR 10.4.2 -->

When cleaning (i.e. resetting) a Cassandra database, in some cases, a `TypeInitializationException` could be thrown.

#### StorageModule: Only final retry will be logged as error when a data storage request fails [ID_38897]

<!-- MR 10.5.0 - FR 10.4.4 -->

When a StorageModule client requests data to be stored, in some cases, a subscription exception can be thrown. Those data storage requests are retried automatically. However, up to now, each retry would be logged as error.

From now on, only the final retry will be logged as error. All prior retries will only be logged when the log level is set to "debug".

#### GQI: Problem when loading extensions [ID_38998]

<!-- MR 10.5.0 - FR 10.4.5 -->

When GQI extensions (i.e. ad hoc data sources or custom operators) were being loaded, in some cases, an exception could be thrown when inspecting the assembly of an extension that prevented subsequent extensions from being loaded.

This type of exceptions will be now be properly caught and logged as warnings so that other extensions will no longer be prevented from being loaded.

> [!TIP]
> See also: [GQI: Full logging [ID_38870]](xref:General_Main_Release_10.4.0_CU1#gqi-full-logging-id_38870)

#### Problem while checking whether the DataMiner System was licensed to use the ModelHost DxM [ID_39001]

<!-- MR 10.5.0 - FR 10.4.5 -->

A *ModelHostException* could be thrown while checking whether the DataMiner System was licensed to use the ModelHost DxM.

#### Issues with user accounts [ID_39234]

<!-- MR 10.5.0 - FR 10.4.7 -->

In some cases, user accounts could become corrupted and group memberships could get lost.

Also, in some cases, SLDataMiner could stop working when an alarm template or trend template was uploaded, removed, assigned or unassigned.

#### Skyline Device Simulator: Problem when loading HTTP simulation files that contained additional tags [ID_39379]

<!-- MR 10.5.0 - FR 10.4.6 -->

In some cases, when you tried to load a PDML file containing an HTTP simulation, the simulation would fail to load, especially when the PDML file contained additional tags (e.g. comments).

#### MessageBroker: Problem when trying to read a file that was being updated by another process [ID_39408]

<!-- MR 10.5.0 - FR 10.4.7 -->

In some rare cases, an exception could be thrown when MessageBroker tried to read a file that was being updated by another process.

#### STaaS: Problem when using a delete statement with a filter [ID_39416]

<!-- MR 10.5.0 - FR 10.4.6 -->

When, on a STaaS system, an attempt was made to delete data from the database using a delete statement with a filter, in some cases, the data would not be deleted and the following error would be logged in the *CloudStorage.txt* log file:

`Provided delete filter resulted in a post filter, post filtering is not supported for cloud delete requests.`

This issue has now been fixed.

#### Problem when disposing an ISession with multiple subscriptions [ID_39483]

<!-- MR 10.5.0 - FR 10.4.7 -->

In some cases, an `InvalidOperationException` could be thrown when a .NET Framework host application (e.g. DataMiner Automation) disposed an ISession with multiple subscriptions without having disposed the subscriptions first.
