---
uid: General_Main_Release_10.5.0_enhancements
---

# General Main Release 10.5.0 – Enhancements

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

#### Security enhancements [ID 37349] [ID 38052] [ID 38951] [ID 39387]

<!-- 37349: MR 10.5.0 - FR 10.4.2 -->
<!-- 38052: MR 10.5.0 - FR 10.4.2 -->
<!-- 38951: MR 10.5.0 - FR 10.4.4 -->
<!-- 39387: MR 10.5.0 - FR 10.4.7 -->

A number of security enhancements have been made.

#### Deprecated NotifyDataMiner type 'NT_CONNECTIONS_TO_REMOVE' can no longer be used [ID 37595]

<!-- MR 10.5.0 - FR 10.4.1 -->

From now on, the deprecated NotifyDataMiner type *NT_CONNECTIONS_TO_REMOVE* can no longer be used.

#### SLAnalytics - Proactive cap detection: Enhanced detection of possible future alarm threshold breaches [ID 37681]

<!-- MR 10.5.0 - FR 10.4.1 -->

When an increasing or decreasing trend is detected on a highly aggregated level (i.e. a trend that persists for more than 24 hours), from now on, a proactive cap detection suggestion event will be generated when there is a probability that the trend change in question could lead to a breach of a critical alarm limit at some point in the future, even when the breach has not yet been confirmed by the full prediction model built on the historic trend data.

#### Service & Resource Management: Enhanced performance of ResourceManagerHelper.GetResources when using the ResourceExposers.ID.Equal filter [ID 37720]

<!-- MR 10.5.0 - FR 10.4.1 -->

Because of a number of enhancements, overall performance of the `ResourceManagerHelper.GetResources` method has increased when using a `ResourceExposers.ID.Equal` filter.

Also, the performance of `TrueFilterElement<Resource>` has been improved.

#### SLAnalytics - Behavioral anomaly detection: Enhanced coloring of trend graph change point indicators [ID 37827]

<!-- MR 10.5.0 - FR 10.4.1 -->

In a trend graph, the occurrence of change points is indicated by colored rectangular regions below the graph.

Up to now, these regions had a dark color when an alarm event would have been triggered for the change point in question if alarm monitoring had been activated for that type of change point.

From now on, a rectangular region will have a dark color when the change point in question actually triggered an event:

- a suggestion event (if alarm monitoring was not activated for that type of change point), or
- an alarm event (if alarm monitoring was activated for that type of change point).

#### SLAnalytics: Enhanced error logging when retrieving trend data [ID 37931]

<!-- MR 10.5.0 - FR 10.4.1 -->

More extensive information will now be logged when errors occur while retrieving trend data.

#### Service & Resource Management: Migrating profiles and resources from XML to Elasticsearch/OpenSearch is no longer supported [ID 37979]

<!-- MR 10.5.0 - FR 10.4.2 -->

As storing profiles and resources in XML files is no longer supported as from DataMiner 10.4.0/10.4.1, migrating profiles and resources from XML to Elasticsearch/OpenSearch is now no longer supported as well. If you need to migrate profiles and resources, do so before you upgrade to version 10.4.0.

Also, the *NotAllClusterAgentsReachable* error in ResourceManager is now considered obsolete and will no longer be returned.

#### DataMiner Object Models: Reading DOM objects and ModuleSettings in parallel [ID 38023]

<!-- MR 10.5.0 - FR 10.4.2 -->

It is now possible to read DOM objects and ModuleSettings in parallel. This will considerably improve overall performance.

#### SLAnalytics - Behavioral anomaly detection: Reduction of memory used for trend icon calculation [ID 38041]

<!-- MR 10.5.0 - FR 10.4.2 -->

Up to now, SLAnalytics would always keep average trend data for all trended parameters on the system for a configurable time frame in order to determine which trend icon to display in the absence of change points. From now on, it will only keep trend data and calculate state icons for 250,000 trended parameters at the most, reducing memory usage.

#### GQI: Sort operator will now be forwarded to the correct query of a Join operator [ID 38150]

<!-- MR 10.5.0 - FR 10.4.2 -->

When you add a Sort operator after adding a Join operator, that Sort operator will now automatically be forwarded to the correct query in the Join operator. This will considerably enhance performance, especially when sorting on a joined column.

When you sort on a joined column, the Sort operator will be forwarded in the following situations:

- In case of an inner join
- In case of a left join, but only if all sorts are descending
- In case of a right join

#### DataMiner Object Models: Required list fields can no longer be set to an empty list [ID 38238]

<!-- MR 10.5.0 - FR 10.4.3 -->

From now on, when the value of a required list field is set to an empty list, one of the following errors will be thrown:

- `DomInstanceHasMissingRequiredFieldsForCurrentStatus` (when using the DOM status system)
- `DomInstanceDoesNotContainAllRequiredFieldsForSectionDefinition` (when not using the DOM status system)

#### DataMiner Object Models: HistoryChanges will now be processed in bulk [ID 38241]

<!-- MR 10.5.0 - FR 10.4.3 -->

Up to now, if history storage was enabled, when DomInstances were created, updated or deleted, a HistoryChange operation would be executed for every DomInstance separately.

From now on, for every batch of DomInstances that are processed in bulk, the history records will also be processed in bulk.

#### SLAnalytics: Cassandra tables 'analytics_parameterinfo_v1' and 'analytics_wavestream' will be dropped when downgrading [ID 38336]

<!-- MR 10.5.0 - FR 10.4.3 -->

When downgrading a DataMiner System using a Cassandra database, from now on, the Cassandra tables *analytics_parameterinfo_v1* and *analytics_wavestream* will be dropped. Contrary to the old versions, the new versions no longer contain display keys.

#### User-Defined APIs: Enhanced logging [ID 38491]

<!-- MR 10.5.0 - FR 10.4.3 -->

Up to now, when a user-defined API was triggered, log entries like the ones below would only be added to the *SLUserDefinableApiManager.txt* file when the log level was set to 5. From now on, when a user-defined API is triggered, these entries will be added to *SLUserDefinableApiManager.txt* when the log level is set to 0 (i.e. always).

```txt
2024/01/18 10:13:00.740|SLNet.exe|Handle|CRU|0|152|[1f9cd6c045] Started handling API trigger from NATS for route 'dma/id-2'.
2024/01/18 10:13:01.268|SLNet.exe|Handle|CRU|0|152|[1f9cd6c045] Handling API trigger from NATS for route 'dma/id-2' SUCCEEDED after 526.46 ms. API script provided response code: 200. (Token ID: 78dd7916-6d01-4c17-9010-530c28338120)
```

#### DxMs upgraded [ID 38499] [ID 38596] [ID 38743] [ID 38900] [ID 39278] [ID 39802] [ID 39803] [ID 41297]

<!-- RNs 38499/38596: MR 10.5.0 - FR 10.4.3 -->
<!-- RN 38743/38900: MR 10.5.0 - FR 10.4.4 -->
<!-- RN 39278: MR 10.5.0 - FR 10.4.5 -->
<!-- RN 39802: MR 10.5.0 - FR 10.4.8 -->
<!-- RN 39803: MR 10.5.0 - FR 10.4.6 [CU1] -->
<!-- RN 41297: MR 10.4.0 [CU10]/10.5.0 [CU0] - FR 10.5.1 -->

The following DataMiner Extension Modules (DxMs), which are included in the DataMiner upgrade package, have been upgraded to the indicated versions:

- DataMiner ArtifactDeployer: version 1.8.1
- DataMiner CoreGateway: version 2.14.11
- DataMiner FieldControl: version 2.11.1
- DataMiner Orchestrator: version 1.7.1
- DataMiner SupportAssistant: version 1.7.1

For detailed information about the changes included in those versions, refer to the [DxM release notes](xref:DxM_RNs_index).

#### GQI: Ad hoc data source now supports real-time updates [ID 38643]

<!-- MR 10.5.0 - FR 10.4.4 -->

The ad hoc data source now supports real-time updates.

For this purpose, the [IGQIUpdateable](xref:GQI_IGQIUpdateable) interface must be implemented in the data source.

#### SLAnalytics: Enhanced management of DataMinerObjectDeleteMessages [ID 38734]

<!-- MR 10.5.0 - FR 10.4.4 -->

Because of a number of enhancements, overall memory usage has been reduced, especially with regard to the management of DataMinerObjectDeleteMessages.

#### SLLogCollector will now run the 'tasklist /fo TABLE' command [ID 38842]

<!-- MR 10.5.0 - FR 10.4.4 -->

SLLogCollector will now by default run the `tasklist /fo TABLE` command, and save the output in the `Logs\Windows` folder of the generated package.

#### GQI: Enhanced sorting of indexed logger tables [ID 38857]

<!-- MR 10.5.0 - FR 10.4.7 -->

A number of enhancements have been made with regard to the sorting of indexed logger tables.

#### Grouping of GQI event messages [ID 38913]

<!-- MR 10.5.0 - FR 10.4.5 -->

From now on, GQI event messages sent by the same GQI session within a time frame of 100 ms will be grouped into one single message.

#### Service & Resource Management: Enhanced performance when activating function DVEs [ID 38972]

<!-- MR 10.5.0 - FR 10.4.6 -->

Because of a number of enhancements, overall performance has increased when activating function DVEs.

#### GQI: Errors related to real-time GQI data updates will now also be logged [ID 38986]

<!-- MR 10.5.0 - FR 10.4.6 -->

From now on, errors related to real-time GQI data updates will also be logged.

For example:

- When an ad hoc data source is not able to send an update due to API methods being used incorrectly.
- When a built-in data source is not able to send an update.
- When the connection used to send the updates to the client gets lost.

Exceptions associated with a custom data source will be logged in the log file of the data source in question.

#### Factory reset tool SLReset.exe will now remove the NodeId.txt files [ID 39092]

<!-- MR 10.5.0 - FR 10.4.5 -->

When the factory reset tool (*SLReset.exe*) is run, from now on, it will also remove the *NodeId.txt* files located in the following folders:

- `C:\ProgramData\Skyline Communications\DxMs Shared\Data`
- `C:\ProgramData\Skyline Communications\DataMiner Orchestrator\Data`

These files will be recreated with a new identifier when DataMiner or any of its extension modules is restarted.

#### STaaS: Enhanced performance when fetching alarm distribution data [ID 39197]

<!-- MR 10.5.0 - FR 10.4.5 -->

Because of a number of enhancements, overall performance has increased when fetching alarm distribution data from the database, especially on Failover systems using Storage as a Service.

#### GQI: Enhanced error handling [ID 39226]

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

#### SLAnalytics - Behavioral anomaly detection: A decreasing trend slope will now be labeled as a trend change instead of a variance decrease [ID 39249]

<!-- MR 10.5.0 - FR 10.4.6 -->

Up to now, in some cases, a decreasing trend slope would be labeled as a variance decrease. From now on, a decreasing trend slope will be labeled as a trend change instead.

#### Enhanced performance when starting up a DataMiner Agent because of SLDataMiner loading protocols in parallel [ID 39260]

<!-- MR 10.5.0 - FR 10.4.6 -->

From now on, at DataMiner startup, SLDataMiner will load protocols in parallel. This will considerably increase overall performance when starting up a DataMiner Agent.

#### Service & Resource Management: Queue will now be skipped when processing SetSrmJsonSerializableProperties requests [ID 39264]

<!-- MR 10.5.0 - FR 10.4.6 -->

When the *ResourceManagerHelper* methods *UpdateReservationInstanceProperties* or *SafelyUpdateReservationInstanceProperties* were used to update properties of a booking, up to now, their action was queued on the master DMA to be handled sequentially for all bookings.

From now on, the *SetSrmJsonSerializableProperties* requests will skip said queue.

#### Enhanced SLDBConnection logging [ID 39267]

<!-- MR 10.5.0 - FR 10.4.6 -->

A number of enhancements have been made with regard to the logging of errors and warnings in the *SLDBConnection.txt* log file.

#### SLAnalytics - Proactive cap detection: Enhanced clearing of proactive detection suggestion events [ID 39296]

<!-- MR 10.5.0 - FR 10.4.6 -->

A proactive detecting suggestion event indicating a forecasted crossing of a critical alarm threshold will now be cleared sooner. As soon as the system detects that the predicted trend has dropped below the threshold in question will the suggestion event be cleared.

#### GQI: Changing the minimum log level no longer requires an SLHelper restart [ID 39309]

<!-- MR 10.5.0 - FR 10.4.6 -->

Up to now, when you changed the *serilog:minimum-level* setting in `C:\Skyline DataMiner\Files\SLHelper.exe.config`, the change would only take effect after an SLHelper restart.

From now on, when you change this setting, the change will take effect the moment you save the configuration file. Restarting SLHelper will no longer be necessary.

#### ProtocolCache.txt replaced by ProtocolCacheV2.txt [ID 39316]

<!-- MR 10.5.0 - FR 10.4.6 -->

The *ProtocolCache.txt* file, located in the `C:\Skyline DataMiner\System Cache\` folder, has now been replaced by the *ProtocolCacheV2.txt* file.

While the *ProtocolCache.txt* file only contained information about the protocols that were not fully compatible with Cassandra, the *ProtocolCacheV2.txt* file will also contain information like minimum required DataMiner version.

> [!IMPORTANT]
> up to now, when no compliance information was specified in a protocol, all QActions would be checked for queries incompatible with Cassandra. From now on, it will be assumed that a protocol version is compatible with Cassandra unless Cassandra compliance is explicitly set to false in the `<Compliancies>` element of the protocol.

#### SLDataGateway: Enhanced logging [ID 39341]

<!-- MR 10.5.0 - FR 10.4.6 -->

A number of enhancements have been made with regard to the logging of the SLDataGateway process.

The *SLDBConnection.txt* and *SLCloudStorage.txt* log files will now contain cleaner entries, and entries of type "Error" will also be added to the *SLError.txt* file.

Also, runtime log level updates will now be applied at runtime without requiring a DataMiner restart.

#### GQI now also logs requests to SLNet [ID 39355]

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

#### Enhanced performance when processing SNMPv3 elements [ID 39356]

<!-- MR 10.5.0 - FR 10.4.9 -->

Because of a number of enhancements, overall performance has increased when processing SNMPv3 elements.

> [!IMPORTANT]
> When, on older DataMiner systems, you import DELT packages containing elements exported on systems running DataMiner Main Release version 10.5.0 or Feature Release version 10.4.9 (or newer), all SNMPv3 credentials will be lost and will have to be re-entered manually.

#### Enhanced error message 'Failed to create one or more storages' [ID 39360]

<!-- MR 10.5.0 - FR 10.4.6 -->

When DataMiner fails to start up due to a problem that occurred while connecting to the database, a `Failed to create one or more storages` message will be thrown.

From now on, this error message will include a reference to the StorageModule log file, in which you can find more information about the problem that occurred:

`More info might be available in C:\ProgramData\Skyline Communications\DataMiner StorageModule\Logs\DataMiner StorageModule.txt.`

#### MySql.Data.dll file is now deprecated [ID 39370]

<!-- MR 10.5.0 - FR 10.4.6 -->

The *MySql.Data.dll* file, located in `C:\Skyline DataMiner\ProtocolScripts\`, should from now on be considered deprecated.

This file will no longer be included in DataMiner upgrade packages. Also, a BPA test has been created to detect the presence and usage of this DLL file in protocols and automation scripts.

To remove all references to the *MySql.Data.dll* file in your protocols and automation scripts, do the following:

1. Open DataMiner Cube.
1. Open *System Center*.
1. Go to *Agents > BPA*.
1. Run the *Check Deprecated MySql DLL* test (if it has not been run yet).
1. If references to the DLL file have been found, click the ellipsis button next to the message to see an overview of all protocols and automation scripts that are still using this DLL file.

   This overview is displayed as a string in JSON format. It will contain the following information:

   - The names and versions of the protocols that are still using this file, including the IDs of the QActions in which this file is referenced.
   - The names of the automation scripts that are still using this file.

1. Replace every reference to the *MySql.Data.dll* file in the listed protocol QActions and automation scripts by a reference to the [MySql.Data NuGet](https://www.nuget.org/packages/MySql.Data). Using that NuGet should not require any other changes to the existing code.

When you have replaced all references to the *MySql.Data.dll* file, do the following:

1. Stop the DataMiner Agent.
1. Remove the *MySql.Data.dll* file from the `C:\Skyline DataMiner\ProtocolScripts\` folder.
1. Start the DataMiner Agent.

> [!IMPORTANT]
> The BPA test *Check Deprecated MySql DLL* is only able to detect whether the *MySql.Data.dll* file is referenced directly. For example, if a QAction would contain a reference to a particular DLL that references the *MySql.Data.dll* file, the BPA will not be able to detect this.
> When you remove the *MySql.Data.dll* file, it is advised to keep a temporary copy and to check the DataMiner log files *Errors* and *Errors in Protocol* for lines mentioning missing references to the *MySql.Data.dll* file when a QAction or an Automation script was executed.

#### SLNet: Enhancements that optimize the performance of the Jobs and Ticketing APIs [ID 39385]

<!-- MR 10.5.0 - FR 10.4.6 -->

Because of a number of enhancements to SLNet, overall performance of the *Jobs* and *Ticketing* APIs has increased, especially when retrieving data from the database.

#### SLLogCollector: Enhancements to make sure the JAVA_HOME variable is set [ID 39409]

<!-- MR 10.5.0 - FR 10.4.6 -->

A number of enhancements have been made to prevent SLLogCollector from experiencing problems when the JAVA_HOME variable is not set:

- SLLogCollector is now able to pass environment variables to helper executables. This will allow temporarily setting an environment variable to make sure a particular tool can be run correctly.

- In SLLogCollector, the timeout for helper executables has been reduced from 5 minutes to 1 minute.

- An upgrade action has been created to set the JAVA_HOME variable in case this has not been done by [nodetool](xref:TOONodetool).

#### SLAnalytics - Behavioral anomaly detection: Enhanced performance when updating anomalous change point alarms and suggestion events [ID 39453]

<!-- MR 10.5.0 - FR 10.4.6 -->

Because of a number of enhancements, overall performance has increased when updating an alarm or suggestion event generated after an anomalous change point has been detected.

#### SLAnalytics - Behavioral anomaly detection: Enhanced rounding of anomaly threshold values & optimized linking of severities to anomaly thresholds [ID 39492]

<!-- MR 10.5.0 - FR 10.4.7 -->

In alarm templates, the rounding of anomaly threshold values has been enhanced. For example, 3.09999999999999 will now be displayed as 3.1.

Also, the mechanism used to associate severities with anomaly thresholds has been optimized.

#### DataMiner Object Models: Length of string fields is now limited in order to prevent database errors [ID 39496]

<!-- MR 10.5.0 - FR 10.4.12 -->

Values of DOM fields of type `String` are now limited to 32,766 UTF8 bytes.

When a DOM instance contains string fields of which the value exceeds this limit, a `DomInstanceError` will be returned with error reason *ValueTooLarge*. The `AssociatedFields` collection will contain the SectionDefinition, Section and FieldDescriptor IDs referring to the incorrect FieldValue as well as the new `ActualSize` property, which will contain the actual UTF8 size of the string that exceeds the limit.  

#### SLLogCollector packages now include GQI and Web API logging [ID 39557]

<!-- MR 10.5.0 - FR 10.4.7 -->

From now on, SLLogCollector packages will also include the contents of the following folders:

- `C:\Skyline DataMiner\Logging\GQI`
- `C:\Skyline DataMiner\Logging\GQI\Ad hoc data sources`
- `C:\Skyline DataMiner\Logging\GQI\Custom operators`
- `C:\Skyline DataMiner\Logging\Web`

#### Elasticsearch/OpenSearch: Limit set on queries retrieving DOM instances will now be applied to the result set [ID 39686]

<!-- MR 10.5.0 - FR 10.4.8 -->

Up to now, when a limit was set on the result set of queries that retrieve DOM instances from an Elasticsearch or OpenSearch database, that limit would only be applied in memory, causing the entire result set to be returned. From now on, a limited result set will be returned instead. This will enhance overall performance of this type of queries.

#### User-defined APIs: ApiToken and ApiDefinition objects will now be cached [ID 39701]

<!-- MR 10.5.0 - FR 10.4.9 -->

SLNet will now cache [ApiToken](xref:UD_APIs_Objects_ApiToken) and [ApiDefinition](xref:UD_APIs_Objects_ApiDefinition) objects. This will enhance the overall performance of the API requests.

#### automation scripts: Resources can now be retrieved page by page [ID 39743]

<!-- MR 10.5.0 - FR 10.4.9 -->

From now on, in automation scripts, it is possible to retrieve resources page by page.

See the following example, which shows how to implement this.

```csharp
var helper = new ResourceManagerHelper(engine.SendSLNetSingleResponseMessage);

var result = new List<Resource>();
var pagingSize = 100;
var pagingHelper = helper.PrepareResourcePaging(new TRUEFilterElement<Resource>().ToQuery(), pagingSize);

while (true)
{
    if (!pagingHelper.MoveToNextPage())
    {
        break;
    }

    result.AddRange(pagingHelper.GetCurrentPage());
 }
```

Default page size: 200

#### Unhandled exceptions thrown by QActions will now be logged in SLManagedScripting.txt [ID 39779]

<!-- MR 10.5.0 - FR 10.4.8 -->

From now on, when a QAction throws an unhandled exception, an attempt will be made to log that exception in *SLManagedScripting.txt* as an error before the crash dump is created.

#### Service & Resource Management: Changing the cache settings of the Resource Manager without restarting DataMiner [ID 39795]

<!-- MR 10.5.0 - FR 10.4.9 -->

The ResourceManager configuration contains settings that limit the numbers of items that will be cached. These settings have now been updated:

| Setting | Former value | New value |
|---|---|---|
| IdCacheConfiguration-MaxObjectsInCache        | 500  | 10000 |
| TimeRangeCacheConfiguration-MaxObjectsInCache | 3000 | 50000 |

Also, from now on, it will be possible to change these settings without having to restart DataMiner.

To do so, send a `ResourceManagerConfigInfoMessage` containing an `IdCacheConfiguration`, a `TimeRangeCacheConfiguration`, or a `HostedReservationInstanceCacheConfiguration`. Only when the `CleanupCheckInterval` (in case of `TimeRangeCacheConfiguration`) or `CheckInterval` (in case of `HostedReservationInstanceCacheConfiguration`) property has been changed, should the ResourceManager be reinitialized.

See the following example:

```csharp
var request = new ResourceManagerConfigInfoMessage(ResourceManagerConfigInfoMessage.ConfigInfoType.Set)
{
    StorageSettings = new StorageSettings(ResourceStorageType.Elastic),
    IdCacheConfiguration = new IdCacheConfiguration()
    {
        MaxObjectsInCache = 5000,
        ObjectsLifeSpan = TimeSpan.FromMinutes(10)
    },
    TimeRangeCacheConfiguration = new TimeRangeCacheConfiguration()
    {
        CleanupCheckInterval = TimeSpan.FromMinutes(10),
        MaxObjectsInCache = 5000,
        TimeRangeLifeSpan = TimeSpan.FromMinutes(10)
    },
    HostedReservationInstanceCacheConfiguration = new HostedReservationInstanceCacheConfiguration()
    {
        CheckInterval = TimeSpan.FromMinutes(10),
        InitialLoadDays = TimeSpan.FromMinutes(10)
    }
};
var response = _engine.SendSLNetSingleResponseMessage(request) as ResourceManagerConfigInfoResponseMessage;
```

> [!NOTE]
>
> - Sending a `ResourceManagerConfigInfoMessage` to a DataMiner Agent will only update the cache settings of that specific agent. If you want to update the settings of all agents in the cluster, you will have to sent a `ResourceManagerConfigInfoMessage` to every agent in that cluster.
> - To retrieve the above-mentioned settings, you can send a `ResourceManagerConfigInfoMessage` of type `Get`.

#### SLAnalytics - Behavioral anomaly detection: Enhanced trend change detection accuracy [ID 39805]

<!-- MR 10.5.0 - FR 10.4.8 -->

The trend change detection accuracy has been improved, especially after a restart of the SLAnalytics process.

#### Service & Resource Management: SRM master synchronization now takes into account the Resource Manager state [ID 39835]

<!-- MR 10.5.0 - FR 10.4.9 -->

Up to now, the SRM master synchronization only took into account the DMA state, not the Resource Manager state. In some cases, that could lead to requests being sent to a DataMiner Agent of which the Resource Manager was down.

From now on, the SRM master synchronization will also take into account the Resource Manager state. A DataMiner Agent will only be appointed SRM master if DataMiner is running and if the Resource Manager is initialized.

Also, the logging with regard to the SRM master synchronization and master election process has been enhanced.

#### Time-scoped relation learning: Enhanced accuracy [ID 39841]

<!-- MR 10.5.0 - FR 10.4.9 -->

Because of a number of enhancements, the accuracy of the time-scoped relation learning algorithm has increased.

#### DataMiner upgrade: 'C:\\Skyline Dataminer\\Logging\\FormatterExceptions' folder will now be emptied during the upgrade process [ID 39894]

<!-- MR 10.5.0 - FR 10.4.10 -->

The `C:\Skyline Dataminer\Logging\FormatterExceptions` folder will now be emptied each time a DataMiner upgrade is performed.

This folder is used by Skyline developers to keep track of serialization issues.

#### SLAnalytics - Behavioral anomaly detection: Enhanced detection of change points of type 'flatline' [ID 39898]

<!-- MR 10.5.0 - FR 10.4.9 -->

A number of enhancements have been made to the algorithm that detects change points of type "flatline".

When the trend data of a parameter appears to have frequent flatline periods, the chance of a flatline change point being detected and a suggestion event being created for it has now decreased.

Also, a parameter will need to have had at least one day of fluctuating trend data behavior before the flatline detection functionality will detect the start of a flatline period.

#### STaaS: Result set of queries against custom data types can now be limited [ID 39902]

<!-- MR 10.5.0 - FR 10.4.8 -->

From now on, when using STaaS, it is possible to limit the result set of queries against custom data types (e.g. DOM, SRM, etc.). This will enhance overall performance of this type of queries.

#### DaaS: BPA tests that cannot be run on a DaaS system will now be flagged as "Not applicable" [ID 39910]

<!-- MR 10.5.0 - FR 10.4.8 -->

On a DaaS system, BPA tests than cannot be run on a DaaS system will now be flagged as "Not applicable".

#### Service & Resource Management: New 'SkipServiceHandling' option to allow the 'SRMServiceInfo' object check to be skipped when starting/stopping a booking [ID 39939]

<!-- MR 10.5.0 - FR 10.4.9 -->

When a booking was started or stopped, up to now, the system would always verify whether that booking had an `SRMServiceInfo` object. If it did, then no services would be created or deleted. However, when the start actions were run on a DMA other than the DMA on which the booking was created, no `SRMServiceInfo` object would be found, causing a service to be created when that was not necessary.

In the configuration file of the Resource Manager (`C:\Skyline DataMiner\ResourceManager\config.xml`), you can now specify a new *SkipServiceHandling* option, which will allow you to indicate whether or not an `SRMServiceInfo` object check has to be performed when a booking is started or stopped.

#### DataMiner upgrade: 'VerifyNoLegacyReportsDashboards' prerequisite will no longer be run on DMAs with version 10.4.0 or higher [ID 39964]

<!-- MR 10.5.0 - FR 10.4.8 -->

When you upgrade DataMiner from a version older than 10.4.0 to a version from 10.4.0 onwards, the *VerifyNoLegacyReportsDashboards* prerequisite verifies that no legacy reports and legacy dashboards still exist on your DataMiner System before upgrading, as these will no longer work after the upgrade.

Up to now, this prerequisite would also be run on DMAs with version 10.4.0 or higher. From now on, this will no longer be the case.

See also: [Verify No Legacy Reports Dashboards](xref:Verify_No_Legacy_Reports_Dashboards)

#### NT_SNMP_RAW_GET, NT_SNMP_GET, NT_SNMP_RAW_SET and NT_SNMP_SET calls will take the SnmpPollingSnmpPlusPlusOnly soft-launch option into account [ID 40019]

<!-- MR 10.5.0 - FR 10.4.9 -->

From now on, [NT_SNMP_RAW_GET](xref:NT_SNMP_RAW_GET), [NT_SNMP_GET](xref:NT_SNMP_GET), [NT_SNMP_RAW_SET](xref:NT_SNMP_RAW_SET) and [NT_SNMP_SET](xref:NT_SNMP_SET) calls will take the [SnmpPollingSnmpPlusPlusOnly](xref:Overview_of_Soft_Launch_Options#snmppollingsnmpplusplusonly) soft-launch option into account.

In other words, from now on, when this soft-launch option is set to true, these calls will be executed using SNMP++ instead of WinSNMP.

#### SLNet: Enhanced performance when sending requests to SLDataGateway [ID 40023]

<!-- MR 10.4.0 [CU13]/10.5.0 - FR 10.4.9 -->

Because of a number of enhancements made to SLNet, overall performance has increased when sending requests to SLDataGateway.

#### DataMiner Object Models: SLModuleSettingsManager.txt log file will now contain the IDs of the modules that were created, updated or deleted [ID 40028]

<!-- MR 10.5.0 - FR 10.4.9 -->

From now on, the *SLModuleSettingsManager.txt* log file will contain the IDs of the modules that were created, updated or deleted.

#### Service & Resource Management: Enhanced performance when creating and initializing reservations [ID 40082]

<!-- MR 10.5.0 - FR 10.4.9 -->

Because a number of database operations have been optimized, overall performance has increased when creating and initializing reservations.

#### Correlation engine now supports separate alarm ID ranges per element [ID 40089]

<!-- MR 10.5.0 - FR 10.4.10 -->

The Correlation engine now supports separate alarm ID ranges per element.

Also, *GetAlarmDetailsMessage* and *GetAlarmTreeDetailsMessage* now support separate alarm ID ranges per element and take AlarmTreeID instances as input.

#### BPA tests can now be marked 'upgrade only' [ID 40163]

<!-- MR 10.5.0 - FR 10.4.9 -->

BPA tests can now be marked "upgrade only". That way, tests marked as such can be ignored by the DataMiner installer.

#### DataMiner Object Models: Enhanced storage of DOM instances [ID 40242]

<!-- MR 10.5.0 - FR 10.4.9 -->

Because of a number of enhancements, from now on, less storage space will be needed when storing DOM instances in the database, especially in cases where multiple sections link to the same section definition.

#### Alarms: Enhanced performance when calculating baselines [ID 40298]

<!-- MR 10.5.0 - FR 10.4.10 -->

Because of a number of enhancements, overall performance has increased when calculating baselines.

#### User-Defined APIs: UserDefinableApiEndpoint DxM has been updated and now requires .NET 8 [ID 40303]

<!-- MR 10.5.0 - FR 10.4.9 -->

The UserDefinableApiEndpoint DxM has been upgraded to version 3.2.3. It now requires .NET version 8.

#### New 'IsCloudConnected' message to check whether the DataMiner System is connected to dataminer.services [ID 40395]

<!-- MR 10.5.0 - FR 10.4.10 -->

From now on, you can check whether the DataMiner System is connected to dataminer.services by sending either a *GetCCAGatewayGlobalStateRequest* message or an *IsCloudConnected* message.

- The *IsCloudConnected* message does not require any special user permissions.
- The *GetCCAGatewayGlobalStateRequest* message requires the *Modules > System configuration > Cloud sharing/gateway > Connect to cloud/DCP* user permission.

#### SNMP traps can now be received from SNMP connections other than the main connection [ID 40511]

<!-- MR 10.5.0 - FR 10.4.10 -->

When SLSNMPManager received a trap, up to now, it would check whether the IP address of the trap matched the IP address of the main connection.

From now on, SLSNMPManager will check whether the IP address of the trap matches the IP address of any of the SNMP connections of the protocol that is being used by the element.

> [!NOTE]
> The IP address of a trap is either the source IP of the trap or the *agentaddress* binding (if the *useAgentBinding* communication option is being used).

#### SLAnalytics - Behavioral anomaly detection: Enhanced variance increase detection [ID 40580]

<!-- MR 10.5.0 - FR 10.4.11 -->

Because of a number of enhancements, variance increase detection has been improved.

#### Trimmed log entries will now get an '(x bytes omitted)' suffix [ID 40629]

<!-- MR 10.5.0 - FR 10.4.11 -->

In log files generated by SLLog, all messages longer than 5120 characters are trimmed by default.

From now on, all messages that have been trimmed will get a `(x bytes omitted)` suffix. That way, users will immediately notice which messages have been trimmed.

#### GQI: DOMHelper can now retrieve DOM instances in the background using a custom page size [ID 40654]

<!-- MR 10.5.0 - FR 10.4.11 -->

Up to now, when the DOM GQI adapter retrieved DOM instances in the background, it would do so page by page using a default page size of 500, even if a different page size was specified in the request. From now on, the GQI adapter will force the DomHelper to use the provided page size when it retrieves DOM instances in the background.

The page size must be set to a value between 10 and 500. When a page size value below 10 or above 500 is passed, the DomHelper will retrieve DOM instances using a page size of 10 or 500, respectively.

#### Trending - Relation learning: Light bulb will now also propose time-scoped related parameters from other elements within the same service [ID 40658]

<!-- MR 10.5.0 - FR 10.4.11 -->

In e.g. DataMiner Cube, a light bulb icon will be displayed when you select a time range on the trend graph of a parameter. If you want to know which other parameters are related to this parameter, based purely on the behavior during the selected time range, then you can click this icon to add or view related parameters. Even if multiple curves are displayed on the same trend graph, the light bulb always shows relations with one specific parameter, whose name is mentioned in the light bulb tooltip.

Up to now, this feature only proposed parameters from the same DataMiner element. From now on, it will also propose parameters from other elements within the same service.

#### Correlation: Only the most recent information about correlation alarm tree entries will now be cached [ID 40661]

<!-- MR 10.5.0 - FR 10.4.11 -->

Up to now, SLNet would cache all information about all entries in a correlation alarm (group) tree. In order to reduce the amount of data in this cache, from now on, only the most recent information about these entries will be kept in memory.

#### VerifyDotNetVersion prerequisite check now returns the missing .NET version and a link to the download page [ID 40677]

<!-- MR 10.5.0 - FR 10.4.12 -->

When you run the DataMiner installer or install a DataMiner upgrade package, the *VerifyDotNetVersion* prerequisite check will verify whether Microsoft ASP.NET 8.0 is installed. When this is not the case, the installation or upgrade will be aborted and a pop-up window will appear, showing the following message:

*Please install the latest \"ASP.NET Core Runtime hosting bundle\" for .NET 8.0 from [https://aka.ms/dotnet/download](https://aka.ms/dotnet/download)*

#### Failover: Both agents will now keep a copy of the C:\\Skyline DataMiner\\Configurations\\ClusterEndpoints.json file [ID 40702]

<!-- MR 10.5.0 - FR 10.4.11 -->

When, in a Failover setup, a DataMiner Agent went offline, up to now, its `C:\Skyline DataMiner\Configurations\ClusterEndpoints.json` file would by default be cleared.

From now on, both DMAs in a Failover setup will keep a copy of the `C:\Skyline DataMiner\Configurations\ClusterEndpoints.json` file, and the online agent will push all changes made to that file toward the offline agent in order to keep both files in sync.

#### Failover - Virtual IP address check: Logging of the arp command will now also include the MAC address that claimed the IP address [ID 40703]

<!-- MR 10.5.0 - FR 10.5.2 -->

Since Main Release 10.3.0 [CU20]/10.4.0 [CU8] and Feature Release 10.4.11, the virtual IP address check uses both a ping and an arp command to check whether an IP address is free.

The logging of the arp command will now also include the MAC address that claimed the IP address.

#### Service & Resource Management: Switching master agents [ID 40712] [ID 41089] [ID 41549]

<!-- RN 40712: MR 10.5.0 - FR 10.4.11 -->
<!-- RN 41089: MR 10.5.0 - FR 10.5.1 -->
<!-- RN 41549: MR 10.5.0 - FR 10.5.2 -->

From now on, when you have been granted the *Modules > System configuration > Tools > Admin tools* permission, you can indicate that a DataMiner Agent is "not eligible to be promoted to master" by sending a `ResourceManagerConfigInfoMessage` in which the `IsMasterEligible` property is set to false.

When the DataMiner Agent that is currently the master agent is marked "not eligible to be promoted to master", the other DataMiner Agents in the DMS will elect a new master from the pool of DataMiner Agents that have been marked "eligible to be promoted to master".

The `IsMasterEligible` property of a DataMiner Agent is stored in the ResourceManager configuration. If the property is not filled in, the agent will be considered "eligible to be promoted to master".

> [!NOTE]
> If the current master agent is marked "not eligible to be promoted to master", all ongoing and queued requests that had been sent to it will fail with a `NotAMasterAgentException`, and the agents that sent those requests will resend them to the new master agent. All new requests will be forwarded to the new master agent.

#### Minor enhancements made to BPAs [ID 40751]

<!-- MR 10.5.0 - FR 10.4.12 -->

A number of minor enhancements have been made to the following BPAs:

##### Cassandra DB Size

- Will no longer be considered a standard BPA test.
- Will no longer fail when the IP address is "localhost".
- Error `! execution failed | This BPA does not apply for this DataMiner Agent` will no longer appear on DMAs using STaaS.

##### Check Agent Presence Test In NATS

- Renamed to *Nats connections between the DataMiner Agents*.

##### HTTPS Configuration

- Will no longer be considered a standard BPA test.
- Will by default be executed as part of the *Security Advisory* BPA.

##### Password Strength

- Will no longer be considered a standard BPA test.
- Will by default be executed as part of the *Security Advisory* BPA.

##### Security Advisory BPA

- Renamed to *Security Advisory*.

##### View Recursion BPA

- Renamed to *View recursive loops*.
- Will no longer be considered a standard BPA test.

#### PortLog.txt file now supports IPv6 addresses [ID 40753]

<!-- MR 10.5.0 - FR 10.4.12 -->

In the *PortLog.txt* file, you can specify IP addresses of DataMiner elements for which log information has to be added to the *SLPort.txt* log file.

In this *PortLog.txt* file, it is now possible to specify IPv6 addresses as well as IPv4 addresses.

#### Enhanced performance when loading newly created elements into SLDataMiner [ID 40762]

<!-- MR 10.5.0 - FR 10.4.11 -->

Because of a number of enhancements, overall performance has increased when loading newly created elements into SLDataMiner.

#### Automation: Engine methods will now use alarm IDs with the syntax DMAID/ELEMENTID/ROOTID [ID 40773]

<!-- MR 10.5.0 - FR 10.4.11 -->

From now on, the following Engine methods will use alarm IDs with the syntax DMAID/ELEMENTID/ROOTID. Up to now, they used alarm IDs with the syntax DMAID/AlarmID.

- GetAlarmProperty
- SetAlarmProperty
- SetAlarmProperties
- AcknowledgeAlarm

#### DataMiner backup: nats-server.config file by default added to backup packages [ID 40812]

<!-- MR 10.5.0 - FR 10.4.11 -->

From now on, the *nats-server.config* file, located in the `C:\Skyline DataMiner\NATS\nats-streaming-server\` folder, will by default be added to all backup packages (except the predefined backup type *Visual Configuration Backup*).

#### STaaS: Enhanced performance when writing data to the database [ID 40870]

<!-- MR 10.5.0 - FR 10.4.12 -->

Because of a number of enhancements, on STaaS systems, overall performance has increased when writing data to the database.

#### SLAnalytics - Time-scoped relations: Menu will now show more related parameters [ID 40904]

<!-- MR 10.5.0 - FR 10.4.12 -->

When, after selecting a section of a trend graph showing trend information for a particular parameter, you clicked the light bulb icon, up to now, a menu would open, showing the other parameters in the same service that were related to the parameter shown in the graph.

From now on, the menu will no longer only show all parameters in the same service that were related in the selected time range. It will now also show the top 10 parameters system-wide that were related in the selected time range.

#### Certain information events will no longer be generated when an element is replicated [ID 40926]

<!-- MR 10.5.0 - FR 10.4.12 -->

When an element is replicated, the following information events will no longer be generated:

- [Replicated Element]
- [Remote Element Name]
- [Remote DMA IP]

#### Failover: Enhanced updating of values stored in the C:\\Skyline DataMiner\\Configurations\\ClusterEndpoints.json file based on current system status [ID 40930]

<!-- MR 10.5.0 - FR 10.4.12 -->

A number of enhancements have been made with regard to updating values stored in the `C:\Skyline DataMiner\Configurations\ClusterEndpoints.json` file based on current system status.

#### GQI: Enhanced performance of 'top X' queries using the 'Get alarms' data source [ID 40937]

<!-- MR 10.5.0 - FR 10.4.12 -->

Because of a number of enhancements, overall performance of GQI "top X" queries using the *Get alarms* data source has increased.

#### Service & Resource Management: Controlling the generation of information events when starting booking event scripts [ID 40972]

<!-- MR 10.5.0 - FR 10.4.12 -->

Up to now, when a booking event script was executed, an information event would automatically be generated to indicate that a script had been executed. This information event had the description "Script started" and its value contained the name of the script.

From now on, these information events will no longer be generated unless the `ShowScriptStartEventInfo` option is set to true in the ResourceManager configuration.

Also, the following scripts will now only be executed when the above-mentioned option is set to true:

- the *StateChangeScript*, defined on an `SRMServiceInfo` object, which is executed when the state of the `SRMServiceInfo` object changes.
- the *SRM_QuarantineHandling* script, which is executed when there is a conflict with a booking causing that booking to be put in quarantine.

Additionally, the following script will also no longer generate an information event when it is executed:

- the *UpdateBookingConfigByReferenceScript* script, defined in the `ProfileHelper` configuration, which is executed when the `UpdateAndApply` method of the `ProfileInstances` class is run successfully.

> [!IMPORTANT]
> The `ShowScriptStartEventInfo` option is not synchronized among the DataMiner Agents in a DMS. It has to be set on every individual DataMiner Agent.

#### Web apps - Visual Overview: Default page will now be the first page that has not been set to 'hidden' [ID 41013]

<!-- MR 10.5.0 - FR 10.4.12 -->

For visual overviews in web apps (e.g. Monitoring, Dashboards, etc.), up to now, the default page would always be the first page, regardless of whether that page had been set to "hidden" or not. From now on, the default page will be the first page that has not been set to "hidden".

#### SLManagedAutomation and SLManagedScripting will now use at least TLS 1.2 encryption when communicating with BrokerGateway [ID 41048]

<!-- MR 10.5.0 - FR 10.4.12 -->

When initialized, SLManagedAutomation and SLManagedScripting will now set the allowed security protocol to "Tls1 | Tls11 | Tls12".

This will ensure that SLManagedAutomation and SLManagedScripting are capable of communicating with BrokerGateway and other HTTP APIs that reject anything below TLS 1.2.

#### Notification message templates: New [treeid] placeholder [ID 41052]

<!-- MR 10.5.0 - FR 10.4.12 -->

When defining a notification message template in the *NotifyTemplates.xml* file, you can use the [treeid] placeholder.

This placeholder will be replaced by the tree ID of the alarm.

For more information, see [Customizing the layout of notification messages](xref:Customizing_the_layout_of_notification_messages)

#### Default number of simultaneously running SLProtocol processes has been increased from 5 to 10 [ID 41077]

<!-- MR 10.5.0 - FR 10.4.12 -->

The number of simultaneously running SLProtocol processes can be set in the `<ProcessOptions>` tag of the *DataMiner.xml* file.

Up to now, the number of simultaneously running processes was by default set to 5. From now on, this number will by default be set to 10.

#### Cassandra Cluster Migrator tool: Enhancements [ID 41099]

<!-- MR 10.4.0 [CU10]/10.5.0 [CU0] - FR 10.5.1 -->

A number of enhancements have been made to the Cassandra Cluster Migrator tool (*SLCCMigrator.exe*):

- The initialization of a single agent has been disabled in favor of the global initialization, unless not all agents could be initialized.
- Connection details will now only be requested once, unless not all agents could not be initialized.
- The migration can now only be started when all agents have successfully been initialized.

#### Service & Resource Management: Starting bookings with elements that are not active [ID 41129]

<!-- MR 10.5.0 - FR 10.5.1 -->

It is now possible to start bookings with elements that are not active.

To do so, in the Resource Manager configuration file, set the *AllowNotActiveElements* option to true.

#### Deprecated NT Notify type 'NT_PING' can no longer be used [ID 41152]

<!-- MR 10.5.0 - FR 10.5.1 -->

From now on, the deprecated NT Notify type *NT_PING* can no longer be used.

#### Service & Resource Management: More detailed logging when an error occurs while a booking is being created [ID 41168]

<!-- MR 10.5.0 - FR 10.4.12 -->

Up to now, when an error occurred while a booking is being created, in some cases, the entry added to the *SLResourceManager.txt* log file would contain insufficient information about the reason why the error had occurred. From now on, this log entry will contain more detailed information.

#### DataMiner upgrade packages now include the latest Visual C++ Redistributable [ID 41173]

<!-- MR 10.5.0 - FR 10.5.2 -->

All DataMiner upgrade packages now include the latest Visual C++ Redistributable.

> [!NOTE]
> From now on, after having upgraded a DataMiner Agent, the `C:\Skyline DataMiner\Files` and `C:\Skyline DataMiner\Files\x64` folders will no longer contain any individual Visual C++ Redistributable DLL files.

#### Service & Resource Management: Process of starting blocking tasks has now been optimized [ID 41175]

<!-- MR 10.5.0 - FR 10.5.1 -->

Up to now, when blocking tasks with the same start time needed to be scheduled for several bookings, in some cases, bookings with limited start actions could get blocked by bookings with longer start actions.

Because of a number of enhancements, the process of starting blocking tasks has now been optimized.

#### Web apps - Visual Overview: Multiple log levels [ID 41200]

<!-- MR 10.4.0 [CU10] / 10.5.0 [CU0] - FR 10.5.1 -->

Up to now, all log entries regarding visual overviews shown in web apps would have a log level equal to 5.

From now on, these log entries will be assigned a log level that indicates their importance.

#### VerifyNatsIsRunning prerequisite will no longer fail when IgnitionValue is not found in ClusterEndpoints.json [ID 41248]

<!-- MR 10.5.0 - FR 10.5.1 -->

Up to now, the *VerifyNatsIsRunning* prerequisite would fail when it did not find `IgnitionValue` in the `C:\Skyline DataMiner\Configurations\ClusterEndpoints.json` file. From now on, it will no longer check whether `IgnitionValue` is present in that file.

#### VerifyClusterPorts: Endpoints to be tested will be retrieved from the Single Source of Truth [ID 41262]

<!-- MR 10.5.0 - FR 10.5.1 -->

The *VerifyClusterPorts* prerequisite and the *VerifyClusterPorts.dmupgrade* package will now use the Single Source of Truth (`C:\Skyline DataMiner\Configurations\ClusterEndpoints.json`) to determine which endpoints should be tested.

If this JSON file cannot be found, the endpoint to be tested will be retrieved from the *DMS.xml* and *SLCloud.xml* files.

#### Change Element States Offline tool: Service elements will now be hidden by default [ID 41341]

<!-- MR 10.5.0 - FR 10.5.3 -->

From now on, the *Change Element States Offline* tool will hide service elements by default. This will prevent users from mistakenly stopping those elements.

If you do want service elements to be visible, select the *Advanced* checkbox.

#### DataMiner upgrade packages will now include the most recent version of the CloudFeed DxM [ID 41357]

<!-- MR 10.5.0 - FR 10.5.1 -->

From now on, DataMiner upgrade packages will include the most recent version of the *CloudFeed* DxM.

> [!NOTE]
> It will still be possible to install newer versions via the [dataminer.services admin app](https://admin.dataminer.services/).

#### Security Advisory BPA test: Enhancements [ID 41385]

<!-- MR 10.5.0 / 10.4.0 [CU11] - FR 10.5.2 -->

A number of minor enhancements have been made to the *Security Advisory* BPA test.

#### DataMiner Object Models: An information event will no longer be generated when a DOM CRUD or DOM Action script is started [ID 41536]

<!-- MR 10.5.0 - FR 10.5.2 -->

Up to now, a "Script started" information event would be generated each time a DOM CRUD script or DOM Action script was started. From now on, these information events will no longer be generated.

#### Protocols: Enhanced protection of table data [ID 41539]

<!-- MR 10.5.0 - FR 10.5.2 -->

Up to now, when a protocol performed multiple actions on a table, SLProtocol would not properly lock the array in which the data was stored. This could then lead to concurrent access to the array, causing the entries to get corrupted and SLProtocol to stop working when those corrupted entries were accessed.

The above-mentioned array will now be locked to prevent the data from getting corrupted.

#### SLDataMiner will now check BrokerGateway soft-launch option in order to decide which NATS services to start [ID 41570]

<!-- MR 10.5.0 - FR 10.5.2 -->

At DataMiner startup, SLDataMiner will now check the `C:\Skyline DataMiner\SoftLaunchOptions.xml` file to determine whether the *BrokerGateway* soft-launch option is enabled or not.

- If the *BrokerGateway* soft-launch option is **enabled**, it will start the **nats-server service**.
- If the *BrokerGateway* soft-launch option is **disabled**, it will start the **NAS and NATS services**.

#### DataMiner Cube server-side search engine: Enhanced performance [ID 41643]

<!-- MR 10.4.0 [CU11]/10.5.0 - FR 10.5.2 -->

Because of a number of enhancements, overall performance of the DataMiner Cube server-side search engine has increased.

#### DataMiner Connectivity Framework: Enhanced processing of SRM services by the connectivity manager [ID 41649]

<!-- MR 10.5.0 - FR 10.5.3 -->

Because of a number of enhancements made to the DataMiner Connectivity Framework, overall performance of the connectivity manager has increased when processing SRM services.

#### Enhanced error and exception handling when updating or clearing correlation alarms [ID 41675]

<!-- MR 10.5.0 - FR 10.5.3 -->

Error and exception handling has been enhanced in order to prevent duplicate or sticky correlation alarms due to errors or exceptions thrown when updating or clearing correlation alarms.

#### Storage as a Service: Timeout for responses to write requests has been reduced to 10 seconds [ID 41717]

<!-- MR 10.5.0 - FR 10.5.2 -->

On STaaS systems, the timeout for responses to write requests has been reduced to 10 seconds.

#### Amazon Keyspaces Service is now end-of-life [ID 41874] [ID 41914]

<!-- MR 10.5.0 [CU0] - FR 10.5.3 -->

Support for Amazon Keyspaces Service is now officially end-of-life.

When you run the DataMiner installer or install a DataMiner upgrade package, the *VerifyNoAmazonKeyspaces* prerequisite will check whether the DataMiner Agent is configured to use a database of type *Amazon Keyspaces*. If so, the upgrade process will not be allowed to continue.

We recommend using [Storage as a Service (STaaS)](xref:STaaS) instead. If you want to use self-managed storage, install a [Cassandra Cluster](xref:Cassandra_database) database.

For more information, see [Amazon Keyspaces Service](xref:Amazon_Keyspaces_Service)

#### SLLogCollector now collects data regarding the GQI DxM [ID 41880]

<!-- MR 10.5.0 - FR 10.5.3 -->

SLLogCollector packages now include the following data regarding the GQI DxM:

- *appsettings.json*
- Log file
- Version

#### GQI DxM: Redundant Logging section removed from appsettings.custom.json file [ID 42075]

<!-- MR 10.5.0 - FR 10.5.3 -->

The redundant `Logging` section (see example below) has now been removed from the `C:\Program Files\Skyline Communications\DataMiner GQI\appsettings.custom.json` file.

```json
"Logging": {
  "LogLevel": {
  "Default": "Debug",
  "Microsoft": "Information"
  }
},
```

#### Failover: Virtual IP address check will no longer execute an arp command to double-check whether an IP address is free [ID 42280]

<!-- MR 10.4.0 [CU12]/10.5.0 [CU0] - FR 10.5.3 [CU0] -->

When the virtual IP address check concluded that the IP address was free after having executed the required number of ping commands, since DataMiner main release 10.3.0 [CU20]/10.4.0 [CU8] and feature release 10.4.11, it would double-check by executing an arp command.

From now on, it will no longer execute an arp command.
