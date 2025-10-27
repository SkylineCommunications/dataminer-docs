---
uid: General_Feature_Release_10.4.2
---

# General Feature Release 10.4.2

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!IMPORTANT]
> When downgrading from DataMiner Feature Release version 10.3.8 (or higher) to DataMiner Feature Release version 10.3.4, 10.3.5, 10.3.6 or 10.3.7, an extra manual step has to be performed. For more information, see [Downgrading a DMS](xref:MOP_Downgrading_a_DMS).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.4.2](xref:Cube_Feature_Release_10.4.2).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.4.2](xref:Web_apps_Feature_Release_10.4.2).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

- [DataMiner Object Models: Creating, updating and deleting multiple DOM instances in one call [ID 37891]](#dataminer-object-models-creating-updating-and-deleting-multiple-dom-instances-in-one-call-id-37891)
- [Configuration of database offload functionality moved from DBConfiguration.xml to DB.xml [ID 37446]](#configuration-of-database-offload-functionality-moved-from-dbconfigurationxml-to-dbxml-id-37446)

## New features

#### API Gateway: DataMiner modules can now register with API Gateway [ID 36575] [ID 37734]

<!-- MR 10.4.0 - FR 10.4.2 -->

DataMiner modules can now register with API Gateway. These modules can be either "regular modules" (e.g. SLNet) or "proxy modules" (e.g. a DxM that wishes to expose an API).

All modules registered with API Gateway will be displayed under `/APIGateway/api/version`, showing the following properties:

- Name
- Version
- Endpoint on which they can be accessed via API Gateway (proxy modules only)

#### Service & Resource Management - ResourceManagerHelper & ServiceManagerHelper: New Count methods [ID 37885] [ID 38096]

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

> [!NOTE]
> When a *Get Bookings* GQI query performs a count aggregate on ID, it will now use the new *ResourceManageHelper.CountReservationInstances* method. This will considerably enhance overall performance.

#### DataMiner Object Models: Creating, updating and deleting multiple DOM instances in one call [ID 37891]

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

#### SLNetTypes and SLGlobal now support a new AlarmTreeID/SLAlarmTreeKey object [ID 37950]

<!-- MR 10.5.0 - FR 10.4.2 -->

The *SLNetTypes* and *SLGlobal* implementations have been updated to support a new *AlarmTreeID/SLAlarmTreeKey* object, which can used to refer to an alarm tree. This new object was created in order to support alarm ID ranges per element rather than per DataMiner Agent, a feature that is still in progress.

Also, a number of client messages have been adapted to support passing this new *AlarmTreeID/SLAlarmTreeKey* object, and a number of existing properties have been marked as obsolete.

#### DataMiner Object Models: Defining CRUD actions for DomInstances on DomDefinition level [ID 37963]

<!-- MR 10.5.0 - FR 10.4.2 -->

Using the `ExecuteScriptOnDomInstanceActionSettings` object, it is now possible to configure DomInstance CRUD actions on DomDefinition level.

The `ExecuteScriptOnDomInstanceActionSettings` object has been made available as a `ScriptSettings` property in the `ModuleSettingsOverrides` property of a DomDefinition.

> [!NOTE]
>
> - When `ScriptSettings` are filled in in the DomDefinition, these will take precedence.
> - When, in the DomDefinition, the `ScriptSettings` object is null, the `ScriptSettings` of the `ModuleSettings` will be used instead.
> - In order for the `ModuleSettings` objects to be used, the objects in the `ModuleSettingsOverrides` of the `DomDefinition` have to be *null*. Just making them empty is not sufficient.

#### FillArray now supports protocol.Leave and protocol.Clear [ID 38153]

<!-- MR 10.5.0 - FR 10.4.2 -->

Up to now, the SLProtocol `FillArray` methods did not any support `protocol.Clear` and `protocol.Leave`. An optional `useClearAndLeave` boolean argument has now been added to indicate that `protocol.Clear` and `protocol.Leave` should be treated as cell actions instead of cell values. When this argument is not provided, `useAndClear` will be considered false and `protocol.Clear` and `protocol.Leave` will be treated as cell values.

The following methods have been added to the `SLProtocol` and `SLProtocolExt` interfaces:

```csharp
protocol.FillArray(int tableId, object[] columns, DateTime? timeInfo, bool useClearAndLeave)
protocol.FillArray(int tableId, object[] columns, bool useClearAndLeave)
protocol.FillArray(int tableId, List<object[]> columns, DateTime? timeInfo, bool useClearAndLeave)
protocol.FillArray(int tableId, List<object[]> columns, bool useClearAndLeave)
protocol.FillArray(int tableId, List<object[]> rows, SaveOption option, DateTime? timeInfo, bool useClearAndLeave)
protocol.FillArray(int tableId, List<object[]> rows, SaveOption option, bool useClearAndLeave)
protocol.FillArrayNoDelete(int tableId, object[] columns, DateTime? timeInfo, bool useClearAndLeave)
protocol.FillArrayNoDelete(int tableId, object[] columns, bool useClearAndLeave)
protocol.FillArrayNoDelete(int tableId, List<object[]> columns, DateTime? timeInfo, bool useClearAndLeave)
protocol.FillArrayNoDelete(int tableId, List<object[]> columns, bool useClearAndLeave)
protocol.FillArrayWithColumn(int tableId, int columnPid, object[] keys, object[] values, DateTime? timeInfo, bool useClearAndLeave)
protocol.FillArrayWithColumn(int tableId, int columnPid, object[] keys, object[] values, bool useClearAndLeave)
```

The `QActionHelper` class has also been adapted.

- `protocol.Clear` and `protocol.Leave` are now supported when calling the `FillArray` methods on the `QActionTable` class objects of `SLProtocolExt`. The following methods have been added:

  ```csharp
  protocol.QActionTable.FillArray(object[] columns, DateTime? timeInfo, bool useClearAndLeave)
  protocol.QActionTable.FillArray(object[] columns, bool useClearAndLeave)
  protocol.QActionTable.FillArray(List<object> columns, DateTime? timeInfo, bool useClearAndLeave)
  protocol.QActionTable.FillArray(List<object> columns, bool useClearAndLeave)
  protocol.QActionTable.FillArray(QActionTableRow[] rows, DateTime? timeInfo, bool useClearAndLeave)
  protocol.QActionTable.FillArray(QActionTableRow[] rows, bool useClearAndLeave)
  protocol.QActionTable.FillArray(List<QActionTableRow> rows, DateTime? timeInfo, bool useClearAndLeave)
  protocol.QActionTable.FillArray(List<QActionTableRow> rows, bool useClearAndLeave)
  protocol.QActionTable.FillArrayNoDelete(object[] columns, DateTime? timeInfo, bool useClearAndLeave)
  protocol.QActionTable.FillArrayNoDelete(object[] columns, bool useClearAndLeave)
  protocol.QActionTable.FillArrayNoDelete(List<object> columns, DateTime? timeInfo, bool useClearAndLeave)
  protocol.QActionTable.FillArrayNoDelete(List<object> columns, bool useClearAndLeave)
  protocol.QActionTable.FillArrayNoDelete(QActionTableRow[] rows, DateTime? timeInfo, bool useClearAndLeave)
  protocol.QActionTable.FillArrayNoDelete(QActionTableRow[] rows, bool useClearAndLeave)
  protocol.QActionTable.FillArrayNoDelete(List<QActionTableRow> rows, DateTime? timeInfo, bool useClearAndLeave)
  protocol.QActionTable.FillArrayNoDelete(List<QActionTableRow> rows, bool useClearAndLeave)
  protocol.QActionTable.SetColumn(int columnPid, string[] keys, object[] values, DateTime? timeInfo, bool useClearAndLeave)
  protocol.QActionTable.SetColumn(int columnPid, string[] keys, object[] values, bool useClearAndLeave)
  ```

- `protocol.Clear` and `protocol.Leave` are now supported when calling the `SetRow` method on the `QActionTable` class objects of `SLProtocolExt`. The following methods have been provided:

  ```csharp
  protocol.QActionTable.AddRow(string row, DateTime? timeInfo)
  protocol.QActionTable.AddRow(object[] row, DateTime? timeInfo)
  protocol.QActionTable.AddRow(QActionTableRow row, DateTime? timeInfo)
  protocol.QActionTable.AddRowReturnKey(DateTime? timeInfo)
  protocol.QActionTable.AddRowReturnKey(object[] row, DateTime? timeInfo)
  protocol.QActionTable.AddRowReturnKey(QActionTableRow row, DateTime timeInfo)
  protocol.QActionTable.SetRow(QActionTableRow row, bool createRow, DateTime? timeInfo, bool useClearAndLeave)
  protocol.QActionTable.SetRow(QActionTableRow row, bool createRow, DateTime? timeInfo)
  protocol.QActionTable.SetRow(QActionTableRow row, bool createRow, bool useClearAndLeave)
  protocol.QActionTable.SetRow(int row, object[] data, DateTime? timeInfo, bool useClearAndLeave)
  protocol.QActionTable.SetRow(int row, object[] data, DateTime? timeInfo)
  protocol.QActionTable.SetRow(int row, object[] data, bool useClearAndLeave)
  protocol.QActionTable.SetRow(string row, object[] data, bool createRow, DateTime? timeInfo, bool useClearAndLeave)
  protocol.QActionTable.SetRow(string row, object[] data, bool createRow, DateTime? timeInfo)
  protocol.QActionTable.SetRow(string row, object[] data, bool createRow, bool useClearAndLeave)
  ```

  > [!NOTE]
  > The `AddRow` and `SetRow` methods can now also perform history sets.

#### SSH: Support for hmac-sha2-512-etm and hmac-sha2-256-etm [ID 38213]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

DataMiner now supports two additional hash-based message authentication algorithms: *hmac-sha2-512-etm* and *hmac-sha2-256-etm*.

From now on, it will propose the following algorithms to the server in the following order:

1. hmac-sha2-512-etm\@openssh.com
1. hmac-sha2-256-etm\@openssh.com
1. hmac-sha2-512
1. hmac-sha2-256
1. hmac-sha1
1. hmac-md5

## Changes

### Enhancements

#### Security enhancements [ID 37349] [ID 37637] [ID 38040] [ID 38052] [ID 38656]

<!-- 37349: MR 10.5.0 - FR 10.4.2 -->
<!-- 37637 (part of 37734): MR 10.4.0 - FR 10.4.2 -->
<!-- 38040: MR 10.3.0 [CU11] - FR 10.4.2 -->
<!-- 38052: MR 10.5.0 - FR 10.4.2 -->
<!-- 38656: MR 10.3.0 [CU11] - FR 10.4.2 [CU0] -->

A number of security enhancements have been made.

#### Configuration of database offload functionality moved from DBConfiguration.xml to DB.xml [ID 37446]

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

#### Number of shards generated by Elasticsearch/OpenSearch has been optimized [ID 37619]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

The number of shards generated by Elasticsearch and OpenSearch has now been optimized. These database will now generate less shards than before.

#### SNMPv3 responses now have a dynamic size [ID 37948]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

Up to now, the size of SNMPv3 responses was limited to 16000 bytes. When larger responses were received, a timeout message would appear in StreamViewer.

From now on, the size of SNMPv3 responses will no longer be limited, meaning that the only constriction will be the maximum size of a UDP packet (i.e. 65000 bytes).

> [!NOTE]
> When sending SNMPv3 messages, the size of those messages is still limited to 16000 bytes.

#### Service & Resource Management: Migrating profiles and resources from XML to Elasticsearch/OpenSearch is no longer supported [ID 37979]

<!-- MR 10.5.0 - FR 10.4.2 -->

As storing profiles and resources in XML files is no longer supported as from DataMiner 10.4.0/10.4.1, migrating profiles and resources from XML to Elasticsearch/OpenSearch is now no longer supported as well. If you need to migrate profiles and resources, do so before you upgrade to version 10.4.0.

Also, the *NotAllClusterAgentsReachable* error in ResourceManager is now considered obsolete and will no longer be returned.

#### Reduction of number of information events when clients connect or disconnect [ID 37992]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

In DataMiner Systems with a large number of Agents, up to now, each Agent in the DataMiner System would generate an information event when a client application connected to or disconnected from a particular Agent. From now on, when a client application connects to or disconnects from an Agent, only that particular Agent will generate an information event.

#### Enhanced performance when compiling QActions in SLScripting [ID 37993]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When QActions are compiled in SLScripting, several resources need to be loaded. Up to now, those resources would be loaded for every QAction individually. From now on, they will be loaded only once and stored in a cache in order to reduce memory and CPU overhead.

Every 10 seconds, resources that have not been referenced in the last 30 seconds will be removed from the cache.

> [!NOTE]
> Uploading protocol or app packages that contain different versions of DLL files stored in the same location may not compile against the shipped version if the previous version was also uploaded and put in use in the previous 60 seconds. Forcing a recompilation of the QActions a minute later (causing the packages to be uploaded again) will yield the expected result.
>
> Protocols and scripts should use NuGet packages as much as possible. The DLL files in those packages will then automatically be placed in folders by version. When protocols use custom non-NuGet DLL files, those should also be placed in folders by version.
>
> With DLL files such as NewtonSoft, which protocols do not reference using NuGet, overwriting the DLL file with a newer version will cause protocols with QActions that have already been compiled to no longer work after a DataMiner restart as the correct strong-named assembly can no longer be found.

#### Elasticsearch/OpenSearch: TTL-based rollover for the CustomData and LoggerTables storage types is now disabled [ID 38000]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

TTL-based rollover for the CustomData and LoggerTables storage types is now disabled.

#### SLAnalytics - Proactive cap detection: Cleanup of all proactive suggestion events at startup [ID 38004]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

Up to now, after a restart of the SLAnalytics process, it could occur that a number of open proactive suggestion events were still left on the system. These would then remain open indefinitely unless a user would manually clear them.

From now on, all proactive suggestion events will be cleared when proactive cap detection is started, and trend alarm records will no longer be stored in the Cassandra database.

#### DataMiner Object Models: Reading DOM objects and ModuleSettings in parallel [ID 38023]

<!-- MR 10.5.0 - FR 10.4.2 -->

It is now possible to read DOM objects and ModuleSettings in parallel. This will considerably improve overall performance.

#### GQI - 'Get parameter table by ID' data source: Enhanced sorting [ID 38039]

<!-- MR 10.4.0 - FR 10.4.2 -->

When multiple, separate sort operators were optimized by the GQI data source *Get parameter table by ID*, up to now, they would be incorrectly combined into a single multilevel sort operation. From now on, only the last sort operator will be used, consistent with the behavior in case the sort operators are not optimized.

For example, from now on, when you sort by A and, later on in the GQI query, sort again by B, the query will now only be sorted by B.

#### SLAnalytics - Behavioral anomaly detection: Reduction of memory used for trend icon calculation [ID 38041]

<!-- MR 10.5.0 - FR 10.4.2 -->

Up to now, SLAnalytics would always keep average trend data for all trended parameters on the system for a configurable time frame in order to determine which trend icon to display in the absence of change points. From now on, it will only keep trend data and calculate state icons for 250,000 trended parameters at the most, reducing memory usage.

#### NATS: All nodes will now be considered primary nodes [ID 38089]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

From now on, there will no longer be any primary and secondary NAS configurations. All nodes will now be considered primary and will be using their local credential files.

Also, when the NATS configuration is reset, the DMS IP addresses will now be collected via the online Failover agent.

#### SLAnalytics - Behavioral anomaly detection: Reduction of memory used for flatline detection [ID 38118]

<!-- MR 10.4.0 - FR 10.4.2 -->

The amount of memory used for flatline detection has been reduced.

#### GQI: Right query will be fetched lazily in case of a right join [ID 38134]

<!-- MR 10.4.0 - FR 10.4.2 -->

Up to now, when a *Join* operator of type "Right join" was applied, both the entire left query and the entire right query would be fetched. From now on, the right query will be fetched lazily.

#### GQI: Sort operator will now be forwarded to the correct query of a Join operator [ID 38150]

<!-- MR 10.5.0 - FR 10.4.2 -->

When you add a Sort operator after adding a Join operator, that Sort operator will now automatically be forwarded to the correct query in the Join operator. This will considerably enhance performance, especially when sorting on a joined column.

When you sort on a joined column, the Sort operator will be forwarded in the following situations:

- In case of an inner join
- In case of a left join, but only if all sorts are descending
- In case of a right join

#### Enhanced performance when deleting redundancy groups [ID 38173]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

Because of a number of enhancements, overall performance has increased when deleting a redundancy group.

#### SLAnalytics - Behavioral anomaly detection: Enhanced anomaly check algorithm [ID 38176]

<!-- MR 10.4.0 - FR 10.4.2 -->

A number of enhancements have been made to the anomaly check algorithm.

#### SLLogCollector will now also collect the backup logs of the StorageModule DxM [ID 38228]

<!-- MR 10.4.0 - FR 10.4.2 -->

SLLogCollector will now also collect the backup logs of the *StorageModule* DxM located in the `C:\ProgramData\Skyline Communications\DataMiner StorageModule\Logs\Backup` folder.

#### DataMiner upgrade: Enhanced robustness of MSI package installations [ID 38376]

<!-- MR 10.3.0 [CU12] - FR 10.4.2 [CU0] -->

Up to now, during a DataMiner upgrade, in some cases, MSI packages would fail to install and throw one of the following errors:

- `The Installer has insufficient privileges to access this directory: ...`
- `Service ... could not be installed. Verify that you have sufficient privileges to install system services.`

From now on, when one of the above-mentioned errors is thrown, it will no longer be necessary to restart the entire upgrade procedure. Instead, a retry will be attempted during the running upgrade.

### Fixes

#### Failover: Problems when using hostnames instead of virtual IP addresses [ID 32951] [ID 35380]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

Up to now, a number of issues could occur when setting up a Failover system using hostnames instead of virtual IP addresses.

#### Problems with SLDataMiner [ID 37409]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

SLDataMiner would leak memory when retrieving the baseline values of an element while the relative baseline value was being updated. Also, an error could occur in SLDataMiner after a service had been created, updated or deleted.

Apart from the above-mentioned fixes, memory management and overall error logging have also been improved.

#### Failover: Shared hostname would incorrectly always refer to the same agent when using gRPC [ID 37558]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 [CU0] -->

On a Failover system with a shared hostname using gRPC connections, the shared hostname would incorrectly always refer to the same agent, whether it was online or offline. From now on, the shared hostname will always refer to the online agent.

#### PropertyConfiguration.xml: New properties could incorrectly be assigned an existing property ID [ID 37596]

<!-- MR 10.4.0 - FR 10.4.2 -->

When, in a client application (e.g. DataMiner Cube) you created a new custom property, in some cases, that new property would incorrectly be assigned an ID that had already been assigned to another, existing property.

#### SLDataGateway: Problem with casing when retrieving data from Elasticsearch/OpenSearch [ID 37835]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When SLDataGateway retrieved data from Elasticsearch/OpenSearch on behalf of a DataMiner app (e.g. Ticketing), in some cases, it would pass an incorrect result set to that app due to a casing issue.

#### SLAnalytics: Problem with table parameter indices containing special characters [ID 37860]

<!-- MR 10.4.0 - FR 10.4.2 -->

Up to now, SLAnalytics would not correctly handle special characters in the table parameter indices. These characters will now be handled correctly. If parameters with indices containing special characters are trended, they will now also receive a trend prediction in the trend graph, and their behavioral change points will now be displayed.

Also, special characters in parameter indices will no longer cause errors to be logged.

#### Service & Resource Management: Timeout script in end event of booking would not get executed when the booking was set to end while the DMA was being stopped [ID 37911]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When the end event of a booking used a timeout script, in some cases, that script would not get executed when the booking was set to end while the DataMiner Agent was being stopped.

#### DataMiner Taskbar Utility: Problem when making SLTaskbarUtility perform an action using the command prompt [ID 37952]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When you made the DataMiner Taskbar Utility perform some action using the command prompt, the arguments would not be parsed correctly when no instance of SLTaskbarUtility was running.

#### MySQL: Problem when elements were started [ID 37973]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

On systems with a MySQL database, in some cases, page handlers would be deleted too soon. This caused the following errors to be logged when an element was started:

```txt
Querying elementdata
Could not read the next page of element data for ...
Failed to query elementdata for parameter ...: General database failure.
Failed to query elementdata for ...: General database failure.
```

#### SLDataGateway would incorrectly keep waiting for acknowledgements from SLDataGatewayAPI [ID 37985]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

SLDataGateway would incorrectly keep waiting for an acknowledgement from SLDataGatewayAPI, causing numerous `Waiting for SLDataGatewayAPI to acknowledge ...` entries to be added to the *SLDataGateway.txt* log file.

#### Problem with SLProtocol when a parameter was updated while an SLA window was changing [ID 37990]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When one of the following parameters was updated while an SLA window was changing, a runtime error could occur in SLProtocol:

- Base timestamp
- Monitor span
- Window size
- Window unit
- Window type
- Validity start
- Validity end

#### SLNet prefetcher would request the web API URL too often [ID 38012]

<!-- MR 10.4.0 - FR 10.4.2 -->
<!-- Not added to MR 10.4.0 -->

Since the legacy Reports, Dashboards and Annotations modules were disabled by default, the prefetcher in SLNet only requests the URL of the web APIs. However, up to now, it would request that URL once every second. From now on, it will only request that URL once every 10 minutes.

#### SLNet: Problem when a client application sent multiple messages to the same manager [ID 38025]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When a client application (e.g. DataMiner Cube) sent multiple messages to the same manager, in some cases, a number of those messages would return an exception and would not get processed.

#### Problem with protocol compliancies cache in SLNet [ID 38043]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

The compliancies cache in SLNet, which keeps track of the minimum required version of a protocol or of whether a protocol supports Cassandra, was only refreshed when you uploaded a *protocol.xml* file that did not contain a `<Compliancies>` tag or when the cache was accessed for the first time.

#### Storage as a Service: Resources would not always be released correctly [ID 38058]

<!-- MR 10.5.0 - FR 10.4.2 -->

Resources would not always be released correctly, causing some resources to be used for longer than strictly necessary.

#### GQI: Problem when retrieving a large amount of alarms [ID 38065]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When a GQI query had to retrieve a large amount of paged alarms, after a while, a timeout exception would be thrown even though none of the paged requests had timed out.

#### SLAnalytics: Problem when the trend icon calculation feature was disabled immediately after being enabled [ID 38072]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

In some cases, SLAnalytics could partially get stuck when the trend icon calculation feature was disabled immediately after being enabled.

#### Behavioral anomaly detection: Unlabelled changes would cause the trend icon to not be updated [ID 38105]

<!-- MR 10.4.0 - FR 10.4.2 -->

When small, unlabelled changes were detected in a trend graph of a parameter of which the value was clearly increasing, decreasing or remaining stable, up to now, the trend icon would incorrectly not be updated to indicate this increasing, decreasing or stable trend. From now on, when a small, unlabelled change occurs in a trend graph that clearly increases, decreases or remains stable, the trend icon will be updated to indicate this.

#### Problem when loading data of elements hosted on another DMA while a Correlation rule action was running [ID 38121]

<!-- MR 10.3.0 [CU12] - FR 10.4.2 -->

When, while an extensive Correlation rule action was running, you opened an element card of an element hosted on a DataMiner Agent other than the one you were connected to, loading the data of that element could get delayed until the Correlation rule action had finished.

#### Failover: Problem with DVE elements and virtual function elements after a Failover switch [ID 38167]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

After a Failover switch, in some cases, DVE elements or virtual function elements would not be loaded correctly. Also, new DVE elements would incorrectly not appear in the Surveyor when they were created while their parent element was hosted on the Failover setup that had switched.

#### Problems with gRPC connections when SLNet was not running [ID 38177]

<!-- MR 10.4.0 - FR 10.4.2 -->

When a DataMiner Agent had the APIGateway service running but not the SLNet process (e.g. a DataMiner Agent that had been fully stopped), the following issues would occur:

- No exception would be thrown when a client application sent a message via one of the gRPC connections that was still open. Instead, an empty response was returned. As a result, client applications would not notice that there was a problem.

- When an attempt was made to establish a new gRPC connection, an `Invalid username or password` would be returned instead of a `DataMinerNotRunningException`.

#### BPA test 'Check Cluster SLNet Connections' did not have valid signature [ID 38201] [ID 38208]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When you ran the BPA test 'Check Cluster SLNet Connections', this failed with the exception message `BPA doesn’t have a valid signature`. The BPA has now been signed correctly, so this issue will no longer occur.

From now on, this test will be run daily on every Agent in a DataMiner System.

#### SLAnalytics - Automatic incident tracking: Problem after clearing or removing an alarm [ID 38239]

<!-- MR 10.4.0 - FR 10.4.2 -->

When an alarm had been cleared or removed, in some cases, the automatic incident tracking feature could incorrectly assume that no more alarms were associated with the parameter in question. As a result, alarms could get grouped incorrectly or error messages similar to the following one could start to appear:

`Parameter key [PARAMETER_KEY] was not in parameterKeyConverter, while it should have been.`

#### SLAnalytics - Automatic incident tracking: Empty alarm group would be created when manually creating an incident with non-active alarms [ID 38248]

<!-- MR 10.4.0 - FR 10.4.2 -->

When, while automatic incident tracking was running, you manually created an incident (i.e. an alarm group) containing non-active alarms, an empty alarm group would be created.

#### Service & Resource Management: Incorrect trace data would be returned after performing a create, update or delete action using the ServiceManagerHelper [ID 38262]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When you retrieved the trace data after performing a create, update or delete action using the ServiceManagerHelper, in some cases, an error could be returned although the action that was performed had succeeded.

#### SLAnalytics could stop working when it lost its connection to SLNet during startup [ID 38268]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

Up to now, when SLAnalytics lost its connection to SLNet at a particular moment during startup, it would stop working because it was not able to reach the database. From now on, when SLAnalytics loses its connection to SLNet at that particular moment during startup, it will continue working and will try to connect to the database again as soon as its connection to SLNet has been re-established.

#### Correlation alarms with incorrect severity after a DataMiner restart [ID 38286]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

After a DataMiner restart, in some cases, correlation alarms would have an incorrect severity.

#### BPA test 'Check Cluster SLNet Connections' could incorrectly report connection problems when it found a Failover system with a shared hostname [ID 38328]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 [CU0] -->

Up to now, the BPA test *Check Cluster SLNet Connections* BPA could incorrectly report connection problems in a DataMiner System when it found a Failover setup with a shared hostname.

#### SLReset: Problem when cleaning a Cassandra database [ID 38332]

<!-- MR 10.5.0 - FR 10.4.2 -->

When cleaning (i.e. resetting) a Cassandra database, in some cases, a `TypeInitializationException` could be thrown.

#### Failover: NATS would incorrectly be reconfigured when both agents were offline [ID 38349]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 [CU0] -->

When both agents in a Failover setup were offline, in some cases, they would incorrectly reconfigure the NATS settings.

#### Problem with SLDataMiner when an enhanced service was not able to find some of its child services [ID 38583]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 [CU0] -->

At DataMiner startup, SLDataMiner could throw an access violation exception when an enhanced service was not able to find some of its child services.
