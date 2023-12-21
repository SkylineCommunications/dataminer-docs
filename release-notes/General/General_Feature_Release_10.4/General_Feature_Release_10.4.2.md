---
uid: General_Feature_Release_10.4.2
---

# General Feature Release 10.4.2 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
> When downgrading from DataMiner Feature Release version 10.3.8 (or higher) to DataMiner Feature Release version 10.3.4, 10.3.5, 10.3.6 or 10.3.7, an extra manual step has to be performed. For more information, see [Downgrading a DMS](xref:MOP_Downgrading_a_DMS).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.4.2](xref:Cube_Feature_Release_10.4.2).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.4.2](xref:Web_apps_Feature_Release_10.4.2).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected yet.*

## New features

#### Service & Resource Management - ResourceManagerHelper & ServiceManagerHelper: New Count methods [ID_37885]

<!-- MR 10.5.0 - FR 10.4.2 -->

The *ResourceManagerHelper* and *ServiceManagerHelper* now include the following *Count* methods that will allow you to count objects using a filter.

- ServiceManagerHelper:

  - CountServiceDefinitions(filter)

- ResourceManageHelper:

  - CountResources(filter)
  - CountResourcePools(filter)
  - CountReservationInstances(filter)

Example:

```csharp
var resourceManagerHelper = new ResourceManagerHelper(engine.SendSLNetSingleResponseMessage);
var count = resourceManagerHelper.CountResources(ResourceExposers.Name.Contains("name"));
```

#### DataMiner Object Models: Creating, updating and deleting multiple DOM instances in one call [ID_37891]

<!-- MR 10.5.0 - FR 10.4.2 -->

From now on, the DOM API allows you to create, update or delete up to 100 DOM instances in one single call.

##### CreateOrUpdate

A `CreateOrUpdate` operation will return the IDs of the DomInstances that were successfully created or updated, as well as the IDs of the DomInstances that were not. Trace data will be available per DomInstance ID.

A `CreateOrUpdate` operation will return a list of DomInstances that were successfully created or updated. Trace data will be available per DomInstance ID.

If an issue occurs while creating or updating an item, no exception will be thrown, even when `ThrowExceptionsOnErrorData` is true. The trace data of the last call will contain the data for all items.

If the entire `CreateOrUpdate` operation would fail, a `CrudFailedException` will be thrown. If, in that case, `ThrowExceptionsOnErrorData` was set to false, null will be returned and the trace data of the last call will contain more details about the issue.

If the list returned by a `CreateOrUpdate` operation contains DomInstances sharing the same key, only the last item with that key will be considered to be created or updated.

```csharp
/// <summary>
/// Returns the created or updated `objects`.
/// </summary>
/// <param name="objects">
/// List of `DomInstances` to be created or updated.
/// The number of `DomInstances` should not exceed `MaxAmountBulkOperation`.
/// </param>
/// The result containing a list of `DomInstances` that were successfully updated or created,
/// a list of IDs of the `DomInstances` that were not successfully updated or created
/// and a list of `TraceData` per item.
/// `null` if `ThrowExceptionsOnErrorData` is `false` and there is no `BulkCreateOrUpdateResult` available.
/// </returns>
/// <exception cref="ArgumentNullException">if `objects` is `null`.</exception>
/// <exception cref="CrudFailedException">if `ThrowExceptionsOnErrorData` is `true`,  the TraceData contains errors and there is no `BulkCreateOrUpdateResult` available.</exception>
/// <exception cref="DomInstanceCrudMaxAmountExceededArgumentException">if the number of `objects` exceeds `MaxAmountBulkOperation`.</exception>
public BulkCreateOrUpdateResult<DomInstance, DomInstanceId> CreateOrUpdate(List<DomInstance> objects)
```

##### Delete

A `Delete` operation will return the IDs of the DomInstances that were deleted, as well as the IDs of the DomInstances that were not deleted. Trace data will be available per DomInstance ID.

If an issue occurs while deleting an item, no exception will be thrown, even when `ThrowExceptionsOnErrorData` is true. The trace data of the last call will contain the data for all items.

If the entire `Delete` operation would fail, a `CrudFailedException` will be thrown. If, in that case, `ThrowExceptionsOnErrorData` was set to false, null will be returned and the trace data of the last call will contain more details about the issue.

```csharp
/// <summary>
/// Deletes the given `objects`.
/// </summary>
/// <param name="objects">
/// List of `DomInstances` to be deleted.
/// The number of `DomInstances` should not exceed `MaxAmountBulkOperation`.
/// </param>
/// <returns>
/// The result containing a list of IDs of `DomInstances` that were successfully deleted
/// a list of IDs of the `DomInstances` that were not successfully deleted
/// and a list of `TraceData` per item.
/// </returns>
/// <exception cref="ArgumentNullException">if `objects` is `null`.</exception>
/// <exception cref="CrudFailedException">if `ThrowExceptionsOnErrorData` is `true`,  the TraceData contains errors and there is no `BulkDeleteResult` available.</exception>
/// <exception cref="DomInstanceCrudMaxAmountExceededArgumentException">if the amount of `objects` exceeds `MaxAmountBulkOperation`.</exception>
public BulkDeleteResult<DomInstanceId> Delete(List<DomInstance> objects)
```

##### MaxAmountBulkOperation

By default, `MaxAmountBulkOperation` will be set to 100. This means that any `CreateOrUpdate` or `Delete` operation will be able to process up to 100 DOM instances. If more than 100 instances are passed, then an error will occur.

> [!IMPORTANT]
> Since related actions (e.g. launching script actions and history tracking) might outlive a `CreateOrUpdate` or `Delete` operation, keep in mind that repeating these operations in succession can have an impact on system stability.

##### Unique IDs

When creating, updating or deleting instances using the above-mentioned bulk operations, make sure each DOM instance in the list has a unique ID.

If multiple instances share the same ID, only the last of those instances will be taken into account.

> [!NOTE]
> This also applies when PaTokens are created, updated or deleted in bulk. If multiple instances share the same ID, only the last of those instances will be taken into account.

#### SLNetTypes and SLGlobal now support a new AlarmTreeID/SLAlarmTreeKey object [ID_37950]

<!-- MR 10.5.0 - FR 10.4.2 -->

The *SLNetTypes* and *SLGlobal* implementations have been updated to support a new *AlarmTreeID/SLAlarmTreeKey* object, which can used to refer to an alarm tree. This new object was created in order to support alarm ID ranges per element rather than per DataMiner Agent, a feature that is still in progress.

Also, a number of client messages have been adapted to support passing this new *AlarmTreeID/SLAlarmTreeKey* object, and a number of existing properties have been marked as obsolete.

#### DataMiner Object Models: Defining CRUD actions for DomInstances on DomDefinition level [ID_37963]

<!-- MR 10.5.0 - FR 10.4.2 -->

Using the `ExecuteScriptOnDomInstanceActionSettings` object, it is now possible to configure DomInstance CRUD actions on DomDefinition level.

The `ExecuteScriptOnDomInstanceActionSettings` object has been made available as a `ScriptSettings` property in the `ModuleSettingsOverrides` property of a DomDefinition.

> [!NOTE]
>
> - When `ScriptSettings` are filled in in the DomDefinition, these will take precedence.
> - When, in the DomDefinition, the `ScriptSettings` object is null, the `ScriptSettings` of the `ModuleSettings` will be used instead.
> - In order for the `ModuleSettings` objects to be used, the objects in the `ModuleSettingsOverrides` of the `DomDefinition` have to be *null*. Just making them empty is not sufficient.

## Changes

### Enhancements

#### Security enhancements [ID_37349] [ID_38040] [ID_38052]

<!-- 37349: MR 10.5.0 - FR 10.4.2 -->
<!-- 38040: MR 10.3.0 [CU11] - FR 10.4.2 -->
<!-- 38052: MR 10.5.0 - FR 10.4.2 -->

A number of security enhancements have been made.

#### Configuration of database offload functionality moved from DBConfiguration.xml to DB.xml [ID_37446]

<!-- MR 10.4.0 - FR 10.4.2 -->

Up to now, the database offload functionality described below had to be configured in the *DBConfiguration.xml* file. From now on, it has to be configured in the *DB.xml* file instead.

- **Configuring a size limit for file offloads**

  When the main database is offline, file offloads are used to store write/delete operations. You can configure a limit for the file size of these offloads. When the limit is reached, new data will be dropped.

  Example:

  ```xml
  <DataBases>
    ...
    <FileOffloadConfiguration>
      <MaxSizeMB>20</MaxSizeMB>
    </FileOffloadConfiguration>
  </DataBases>
  ```

- **Configuring multiple OpenSearch or Elasticsearch clusters**

  It is possible to have data offloaded to multiple OpenSearch or Elasticsearch clusters, i.e. one main cluster and several replicated clusters.

  Example:

  ```xml
  <DataBases>
    <!-- Reads will be handled by the ElasticCluster with the lowest priorityOrder -->
    <DataBase active="true" search="true" ID="0" priorityOrder="0" type="ElasticSearch">
      <DBServer>localhost</DBServer>
      <UID />
      <PWD>root</PWD>
      <DB>dms</DB>
      <FileOffloadIdentifier>cluster1</FileOffloadIdentifier>
    </DataBase>
    <DataBase active="true" search="true" ID="0" priorityOrder="1" type="ElasticSearch">
      <DBServer>10.11.1.44,10.11.2.44,10.11.3.44</DBServer>
      <UID />
      <PWD>root</PWD>
      <DB>dms</DB>
      <FileOffloadIdentifier>cluster2</FileOffloadIdentifier>
    </DataBase>
  </DataBases>
  ```

#### Number of shards generated by Elasticsearch/OpenSearch has been optimized [ID_37619]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

The number of shards generated by Elasticsearch and OpenSearch has now been optimized. These database will now generate less shards than before.

#### SNMPv3 responses now have a dynamic size [ID_37948]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

Up to now, the size of SNMPv3 responses was limited to 16000 bytes. When larger responses were received, a timeout message would appear in StreamViewer.

From now on, the size of SNMPv3 responses will no longer be limited, meaning that the only constriction will be the maximum size of a UDP packet (i.e. 65000 bytes).

> [!NOTE]
> When sending SNMPv3 messages, the size of those messages is still limited to 16000 bytes.

#### Service & Resource Management: Migrating profiles and resources from XML to Elasticsearch/OpenSearch is no longer supported [ID_37979]

<!-- MR 10.5.0 - FR 10.4.2 -->

As storing profiles and resources in XML files is no longer supported as from DataMiner 10.4.0/10.4.1, migrating profiles and resources from XML to Elasticsearch/OpenSearch is now no longer supported as well. If you need to migrate profiles and resources, do so before you upgrade to version 10.4.0.

Also, the *NotAllClusterAgentsReachable* error in ResourceManager is now considered obsolete and will no longer be returned.

#### Enhanced performance when compiling QActions in SLScripting [ID_37993]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When QActions are compiled in SLScripting, several resources need to be loaded. Up to now, those resources would be loaded for every QAction individually. From now on, they will be loaded only once and stored in a cache in order to reduce memory and CPU overhead.

Every 10 seconds, resources that have not been referenced in the last 30 seconds will be removed from the cache.

> [!NOTE]
> Uploading protocol or app packages that contain different versions of DLL files stored in the same location may not compile against the shipped version if the previous version was also uploaded and put in use in the previous 60 seconds. Forcing a recompilation of the QActions a minute later (causing the packages to be uploaded again) will yield the expected result.
>
> Protocols and scripts should use NuGet packages as much as possible. The DLL files in those packages will then automatically be placed in folders by version. When protocols use custom non-NuGet DLL files, those should also be placed in folders by version.
>
> With DLL files such as NewtonSoft, which protocols do not reference using NuGet, overwriting the DLL file with a newer version will cause protocols with QActions that have already been compiled to no longer work after a DataMiner restart as the correct strong-named assembly can no longer be found.

#### Elasticsearch/OpenSearch: TTL-based rollover for the CustomData and LoggerTables storage types is now disabled [ID_38000]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

TTL-based rollover for the CustomData and LoggerTables storage types is now disabled.

#### SLAnalytics - Proactive cap detection: Cleanup of all proactive suggestion events at startup [ID_38004]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

Up to now, after a restart of the SLAnalytics process, it could occur that a number of open proactive suggestion events were still left on the system. These would then remain open indefinitely unless a user would manually clear them.

From now on, all proactive suggestion events will be cleared when proactive cap detection is started, and trend alarm records will no longer be stored in the Cassandra database.

#### DataMiner Object Models: Reading DOM objects and ModuleSettings in parallel [ID_38023]

<!-- MR 10.5.0 - FR 10.4.2 -->

It is now possible to read DOM objects and ModuleSettings in parallel. This will considerably improve overall performance.

#### GQI - 'Get parameter table by ID' data source: Enhanced sorting [ID_38039]

<!-- MR 10.4.0 - FR 10.4.2 -->

When multiple, separate sort operators were optimized by the GQI data source *Get parameter table by ID*, up to now, they would be incorrectly combined into a single multi-level sort operation. From now on, only the last sort operator will be used, consistent with the behavior in case the sort operators are not optimized.

For example, from now on, when you sort by A and, later on in the GQI query, sort again by B, the query will now only be sorted by B.

#### SLAnalytics - Behavioral anomaly detection: Reduction of memory used for trend icon calculation [ID_38041]

<!-- MR 10.5.0 - FR 10.4.2 -->

Up to now, SLAnalytics would always keep one hour of average trend data for all trended parameters on the system in order to determine which trend icon to display in the absence of change points. From now on, it will only keep one hour of trend data for 250,000 trended parameters at the most, reducing memory usage to a maximum of 330 MB.

#### NATS: All nodes will now be considered primary nodes [ID_38089]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

From now on, there will no longer be any primary and secondary NAS configurations. All nodes will now be considered primary and will be using their local credential files.

Also, when the NATS configuration is reset, the DMS IP addresses will now be collected via the online Failover agent.

#### SLAnalytics - Behavioral anomaly detection: Reduction of memory used for flatline detection [ID_38118]

<!-- MR 10.4.0 - FR 10.4.2 -->

The amount of memory used for flatline detection has been reduced.

#### GQI: Right query will be fetched lazily in case of a right join [ID_38134]

<!-- MR 10.4.0 - FR 10.4.2 -->

Up to now, when a *Join* operator of type "Right join" was applied, both the entire left query and the entire right query would be fetched. From now on, the right query will be fetched lazily.

#### SLAnalytics - Behavioral anomaly detection: Enhanced anomaly check algorithm [ID_38176]

<!-- MR 10.4.0 - FR 10.4.2 -->

A number of enhancements have been made to the anomaly check algorithm.

#### SLLogCollector will now also collect the backup logs of the StorageModule DxM [ID_38228]

<!-- MR 10.4.0 - FR 10.4.2 -->

SLLogCollector will now also collect the backup logs of the *StorageModule* DxM located in the `C:\ProgramData\Skyline Communications\DataMiner StorageModule\Logs\Backup` folder.

### Fixes

#### Problems with SLDataMiner [ID_37409]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

SLDataMiner would leak memory when retrieving the baseline values of an element while the relative baseline value was being updated. Also, an error could occur in SLDataMiner after a service had been created, updated or deleted.

Apart from the above-mentioned fixes, memory management and overall error logging have also been improved.

#### PropertyConfiguration.xml: New properties could incorrectly be assigned an existing property ID [ID_37596]

<!-- MR 10.4.0 - FR 10.4.2 -->

When, in a client application (e.g. DataMiner Cube) you created a new custom property, in some cases, that new property would incorrectly be assigned an ID that had already been assigned to another, existing property.

#### SLDataGateway: Problem with casing when retrieving data from Elasticsearch/OpenSearch [ID_37835]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When SLDataGateway retrieved data from Elasticsearch/OpenSearch on behalf of a DataMiner app (e.g. Ticketing), in some cases, it would pass an incorrect result set to that app due to a casing issue.

#### SLAnalytics: Problem with table parameter indices containing special characters [ID_37860]

<!-- MR 10.4.0 - FR 10.4.2 -->

Up to now, SLAnalytics would not correctly handle special characters in the table parameter indices. These characters will now be handled correctly. If parameters with indices containing special characters are trended, they will now also receive a trend prediction in the trend graph, and their behavioral change points will now be displayed.

Also, special characters in parameter indices will no longer cause errors to be logged.

#### Service & Resource Management: Timeout script in end event of booking would not get executed when the booking was set to end while the DMA was being stopped [ID_37911]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When the end event of a booking used a timeout script, in some cases, that script would not get executed when the booking was set to end while the DataMiner Agent was being stopped.

#### DataMiner Taskbar Utility: Problem when making SLTaskbarUtility perform an action using the command prompt [ID_37952]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When you made the DataMiner Taskbar Utility perform some action using the command prompt, the arguments would not be parsed correctly when no instance of SLTaskbarUtility was running.

#### MySQL: Problem when elements were started [ID_37973]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

On systems with a MySQL database, in some cases, page handlers would be deleted too soon. This caused the following errors to be logged when an element was started:

```txt
Querying elementdata
Could not read the next page of element data for ...
Failed to query elementdata for parameter ...: General database failure.
Failed to query elementdata for ...: General database failure.
```

#### SLDataGateway would incorrectly keep waiting for acknowledgements from SLDataGatewayAPI [ID_37985]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

SLDataGateway would incorrectly keep waiting for an acknowledgement from SLDataGatewayAPI, causing numerous `Waiting for SLDataGatewayAPI to acknowledge ...` entries to be added to the *SLDataGateway.txt* log file.

#### Problem with SLProtocol when a parameter was updated while an SLA window was changing [ID_37990]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When one of the following parameters was updated while an SLA window was changing, a run-time error could occur in SLProtocol:

- Base timestamp
- Monitor span
- Window size
- Window unit
- Window type
- Validity start
- Validity end

#### SLNet prefetcher would request the web API URL too often [ID_38012]

<!-- MR 10.4.0 - FR 10.4.2 -->
<!-- Not added to MR 10.4.0 -->

Since the legacy Reports, Dashboards and Annotations modules were disabled by default, the prefetcher in SLNet only requests the URL of the web APIs. However, up to now, it would request that URL once every second. From now on, it will only request that URL once every 10 minutes.

#### SLNet: Problem when a client application sent multiple messages to the same manager [ID_38025]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When a client application (e.g. DataMiner Cube) sent multiple messages to the same manager, in some cases, a number of those messages would return an exception and would not get processed.

#### Problem with protocol compliancies cache in SLNet [ID_38043]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

The compliancies cache in SLNet, which keeps track of the minimum required version of a protocol or of whether a protocol supports Cassandra, was only refreshed when you uploaded a *protocol.xml* file that did not contain a `<Compliancies>` tag or when the cache was accessed for the first time.

#### Storage as a Service: Resources would not always be released correctly [ID_38058]

<!-- MR 10.5.0 - FR 10.4.2 -->

Resources would not always be released correctly, causing some resources to be used for longer than strictly necessary.

#### GQI: Problem when retrieving a large amount of alarms [ID_38065]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When a GQI query had to retrieve a large amount of paged alarms, after a while, a timeout exception would be thrown even though none of the paged requests had timed out.

#### SLAnalytics: Problem when the trend icon calculation feature was disabled immediately after being enabled [ID_38072]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

In some cases, SLAnalytics could partially get stuck when the trend icon calculation feature was disabled immediately after being enabled.

#### Behavioral anomaly detection: Unlabelled changes would cause the trend icon to not be updated [ID_38105]

<!-- MR 10.4.0 - FR 10.4.2 -->

When small, unlabelled changes were detected in a trend graph of a parameter of which the value was clearly increasing, decreasing or remaining stable, up to now, the trend icon would incorrectly not be updated to indicate this increasing, decreasing or stable trend. From now on, when a small, unlabelled change occurs in a trend graph that clearly increases, decreases or remains stable, the trend icon will be updated to indicate this.

#### Problem when loading data of elements hosted on another DMA while a correlation rule action was running [ID_38121]

<!-- MR 10.4.0 - FR 10.4.2 -->

When, while an extensive correlation rule action was running, you opened an element card of an element hosted on a DataMiner Agent other than the one you were connected to, loading the data of that element could get delayed until the correlation rule action had finished.

#### BPA test 'Check Cluster SLNet Connections' did not have valid signature [ID_38201] [ID_38208]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When you ran the BPA test 'Check Cluster SLNet Connections', this failed with the exception message `BPA doesn’t have a valid signature`. The BPA has now been signed correctly, so this issue will no longer occur.

From now on, this test will be run daily on every Agent in a DataMiner System.
