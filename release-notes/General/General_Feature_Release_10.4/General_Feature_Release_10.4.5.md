---
uid: General_Feature_Release_10.4.5
---

# General Feature Release 10.4.5

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!IMPORTANT]
> When downgrading from DataMiner Feature Release version 10.3.8 (or higher) to DataMiner Feature Release version 10.3.4, 10.3.5, 10.3.6 or 10.3.7, an extra manual step has to be performed. For more information, see [Downgrading a DMS](xref:MOP_Downgrading_a_DMS).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.4.5](xref:Cube_Feature_Release_10.4.5).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.4.5](xref:Web_apps_Feature_Release_10.4.5).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

- [GQI: Implementing a custom sort order for GQI columns using a custom operator [ID 39136]](#gqi-implementing-a-custom-sort-order-for-gqi-columns-using-a-custom-operator-id-39136)
- [Storage as a Service: Proxy support [ID 39221]](#storage-as-a-service-proxy-support-id-39221)

## Breaking changes

#### DOM string fields will now be filtered case-insensitively [ID 38950]

<!-- MR 10.4.0 [CU2] - FR 10.4.5 -->

Up to now, DOM string fields were filtered case-sensitively. From now on, these fields will by default be filtered case-insensitively.

> [!NOTE]
> If necessary, you can overrule this default filter behavior in code by using `StringComparison.Ordinal`. See the following snippet:
>
> ```csharp
> var filter = DomInstanceExposers.FieldValues.DomInstanceField(_stringFieldDescriptor.ID).Contains("test", StringComparison.Ordinal)
> ```

## New features

#### New SLTimeToLive.txt log file containing all changes made to the TTL settings [ID 38851]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

In the `C:\Skyline DataMiner\Logging\SLTimeToLive` folder, you can now find a new *SLTimeToLive.txt* log file, listing all changes made to the TTL settings in Cube's *System Center > System settings > Time to live* page.

> [!NOTE]
> The contents of this folder will not be deleted during either a DataMiner restart or a DataMiner upgrade. However, in the *SLTimeToLive.txt* file, the oldest entries will be removed when the maximum log file size is exceeded.

#### SLNetTypes: New requests GetLogTextFileStringContentRequestMessage and GetLogTextFileBinaryContentRequestMessage [ID 39021]

<!-- MR 10.5.0 - FR 10.4.5 -->

SLNetTypes now exposes two new request-response operations that will allow you to retrieve a file from the `C:\Skyline DataMiner\Logging` folder or one of its subfolders:

| Type of file to be retrieved | Request | Response |
|---|---|---|
| ASCII text files (e.g., log files) | `GetLogTextFileStringContentRequestMessage` | `GetLogTextFileStringContentResponseMessage` |
| Binary files (e.g., zip files)     | `GetLogTextFileBinaryContentRequestMessage` | `GetLogTextFileBinaryContentResponseMessage` |

Both requests have the following arguments:

- The name of the file to be retrieved (with or without extension, with or without full path)
- The ID of the DataMiner Agent

Restrictions:

- The user must have administrative privileges or must be granted the *SDLogging* permission.
- The requests must sent from a managed DataMiner module, i.e., not directly from a client application.
- The requests must be sent via a scripted, wrapped connection (e.g., a QAction of a protocol)
- The file name passed in the requests must be the name of an existing file.
- The file path passed in the requests must be a valid, existing path.

#### GQI: Ad hoc data sources and custom operators can now log messages and exceptions within GQI [ID 39043]

<!-- MR 10.5.0 - FR 10.4.5 -->

When configuring an ad hoc data source or a custom operator, you can now use the new `Logger` property of the `OnInitInputArgs` class to log messages and exceptions within GQI.

#### STaaS: SLDataGateway will now periodically check the health of the storage service [ID 39068]

<!-- MR 10.4.0 [CU2] - FR 10.4.5 -->

When Storage as a Service (STaaS) is used, SLDataGateway will now periodically check the health of that storage service. If the current status cannot be determined or if the current status is "red", SLDataGateway will switch to file offload mode.

> [!NOTE]
>
> - When the current status is "yellow", SLDataGateway will not switch to file offload mode.
> - Whenever the health of the storage service changes, an alarm mentioning the current health status is generated.

#### GQI: The IGQIOnInit and IGQIOnDestroy interfaces can now also be used in custom operators [ID 39088]

<!-- MR 10.4.0 [CU3] - FR 10.4.5 -->

From now on, the `IGQIOnInit` and `IGQIOnDestroy` interfaces can also be used in custom operators.

For more information on these interfaces, see:

- [IGQIOnInit interface](xref:GQI_IGQIOnInit)
- [IGQIOnDestroy interface](xref:GQI_IGQIOnDestroy)

#### GQI: Metrics for requests, first session pages and all session pages [ID 39098]

<!-- MR 10.4.0 [CU3] - FR 10.4.5 -->

GQI will now log the following metrics in the `C:\Skyline DataMiner\Logging\GQI\Metrics` folder:

- Duration of the individual GQI requests:

  - Request type (e.g., GenIfOpenSessionRequest)
  - User ID (e.g., SKYLINE2\FirstName)
  - Duration (in ms)

- Duration of the first page of a session (when `SessionOptions.OptimizeType` is "NextPage"):

  - [Query name](#query-name)
  - User ID
  - Number of rows fetched
  - Duration (in ms)

  > [!NOTE]
  > For queries that retrieve data page by page on demand.

- Total duration of all the pages of a session (when `SessionOptions.OptimizeType` is "AllData"):

  - [Query name](#query-name)
  - User ID
  - Total number of rows fetched across all pages
  - Number of pages
  - Total duration (in ms), i.e., the accumulated time of the individual pages

  > [!NOTE]
  > For queries that retrieve all data at once.

##### Query name

In each GQI request that contains a query, clients can now provide an optional query name. This query name will be used in metrics and logging, and can be used to indicate the origin of the query.

The following requests now have an optional `QueryName` property:

- GenIfCapabilitiesRequest
- GenIfColumnFetchRequest
- GenIfDataFetchRequest
- GenIfMigrateQueryRequest
- GenIfOpenSessionRequest

> [!NOTE]
>
> - When the GQI log level is set to "Debug", the full query will be logged instead of the query name.
> - When an exception is thrown during a request, and the GQI log level is set to at least "Error" (which is the case by default), the query (if any) will also be logged alongside the error.

#### GQI: Implementing a custom sort order for GQI columns using a custom operator [ID 39136]

<!-- MR 10.5.0 - FR 10.4.5 -->

It is now possible to define a custom sort order for GQI columns by implementing a custom operator that "redirects" the sort operation on one column to another.

New features added to allow this include:

- Comparing `IGQIColumn` objects

- Inspecting a sort operator appended to a custom operator via the `IGQISortOperator` interface

  - List of sort fields (of type `IGQISortField`)
  - Each sort field exposes a sort column (`IGQIColumn`) and a sort direction (`GQISortDirection`)

- An `IGQIFactory` property is now exposed on the `OnInitInputArgs`, which provides factory functions to generate

  - a new `IGQISortField`
  - a new `IGQISortOperator`

#### Storage as a Service: Proxy support [ID 39221]

<!-- MR 10.5.0 - FR 10.4.5 -->

Storage as Service (STaaS) now supports the use of a proxy server.

When you configure a proxy server in the *Db.xml* file, all traffic towards STaaS will pass through the proxy instead of going directly to the cloud.

Example of a *Db.xml* file in which a proxy server has been configured:

```xml
<?xml version="1.0"?>
<DataBases xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://www.skyline.be/config/db">
  <DataBase active="true" local="true" search="true" cloud="true" type="CloudStorage">
    <Proxy>
      <Address></Address>
      <Port></Port>
      <UserName></UserName>
      <Password></Password>
    </Proxy>
  </DataBase>
</DataBases>
```

> [!NOTE]
> The proxy server will be used once the `<Address>` field is filled in. If the proxy server does not require any authentication, the `<UserName>` and `<Password>` fields can be left blank or removed altogether.

## Changes

### Enhancements

#### Enhanced performance when editing properties in bulk [ID 38255]

<!-- MR 10.4.0 [CU2] - FR 10.4.5 -->

Performance has increased when properties of elements, services, or views are edited in bulk.

#### 'Database Security' BPA test has been replaced by the 'Security Advisory' BPA test [ID 38632]

<!-- MR 10.3.0 [CU15]/10.4.0 [CU3] - FR 10.4.5 -->

The *Database Security* BPA test has been replaced by the *Security Advisory* BPA test, which will run a collection of checks to see if the system is configured as securely as possible.

For more information on this new BPA test, see [Security Advisory](xref:BPA_Security_Advisory).

#### Service & Resource Management: Enhanced performance of volume license check [ID 38705]

<!-- MR 10.4.0 [CU2] - FR 10.4.5 -->

Because of a number of enhancements, overall performance has increased when performing volume license checks.

#### APIGateway now runs on .NET 8 and allows you to enable kernel response buffering [ID 38710]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

APIGateway has been upgraded. It now runs on Microsoft .NET 8.

This service now allows you to enable kernel response buffering, which should improve throughput and responsiveness over high-latency connections. This setting is disabled by default. To enable it, do the following:

1. In the `C:\Program Files\Skyline Communications\DataMiner APIGateway\` folder of the DataMiner Agent, create a JSON file named *appsettings.custom.json*.
1. Open this JSON file, and add the following content:

   ```json
   { "HostingOptions": { "EnableKernelResponseBuffering": true } }
   ```

#### Automation: Cassandra Ready check will now only be performed on DataMiner Systems using a MySQL database [ID 38760]

<!-- MR 10.4.0 [CU2] - FR 10.4.5 -->

Up to now, automation scripts would always be checked whether they were Cassandra ready, regardless of the type of database used by the DataMiner System.

From now on, this Cassandra ready check will only be performed on DataMiner Systems using a MySQL database. When the DataMiner System is using a type of database other than MySQL, automation scripts will always be considered Cassandra ready.

#### Enhanced performance when starting up a DataMiner Agent with a large number of virtual elements [ID 38780]

<!-- MR 10.4.0 [CU2] - FR 10.4.5 -->

Because of a number of enhancements, overall performance has increased when starting up a DataMiner Agent with a large number of virtual elements.

#### Security enhancements [ID 38904]

<!-- RN 38904: MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

A number of security enhancements have been made.

#### Grouping of GQI event messages [ID 38913]

<!-- MR 10.5.0 - FR 10.4.5 -->

From now on, GQI event messages sent by the same GQI session within a time frame of 100 ms will be grouped into one single message.

#### SLLogCollector: Enhancements [ID 38966]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

SLLogCollector now uses Microsoft .NET 4.8.0.

Also, an number of enhancements have been made to improve overall exception handling and to prevent the tool from timing out on servers without internet access.

#### SLLogCollector: Enhancements [ID 38975]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

From now on, SLLogCollector will also log when it was not able to find any DataMiner processes or include memory dumps.

Also, it will no longer attempt to read log files when it was not able to find the `C:\Skyline DataMiner\` folder.

#### Protocols: Enhanced performance when filling an array using the QActionTableRow objects in a QAction [ID 39017]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Because of a number of enhancements, overall performance has increased when filling an array using the `QActionTableRow` objects in a QAction.

#### SLAnalytics - Behavioral anomaly detection: Enhancements [ID 39024]

<!-- MR 10.4.0 [CU2] - FR 10.4.5 -->

A number of enhancements have been made with regard to the behavioral anomaly detection feature.

#### Enhanced performance when loading DVEs and virtual functions, changing production protocols and uploading protocols [ID 39034]

<!-- MR 10.4.0 [CU2] - FR 10.4.5 -->

Because of a number of enhancements, overall performance has increased in the following situations:

- When loading stopped and activated parent elements that generate DVEs or virtual functions when a DMA starts up or when a Failover agent goes online.
- When changing the production protocol or when uploading a protocol being used by existing elements.

Also, when DataMiner Cube is connecting to a DataMiner Agent that is starting up or going online, users will now receive more detailed information on the progress of virtual elements being loaded.

#### Service & Resource Management: Enhanced performance when starting the Resource Manager module [ID 39037]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Because of a number of enhancements, overall performance has increased when starting the Resource Manager module, especially on systems with a large number of permanent bookings.

#### Factory reset tool SLReset.exe will now remove the NodeId.txt files [ID 39092]

<!-- MR 10.5.0 - FR 10.4.5 -->

When the factory reset tool (*SLReset.exe*) is run, from now on, it will also remove the *NodeId.txt* files located in the following folders:

- `C:\ProgramData\Skyline Communications\DxMs Shared\Data`
- `C:\ProgramData\Skyline Communications\DataMiner Orchestrator\Data`

These files will be recreated with a new identifier when DataMiner or any of its extension modules is restarted.

#### SLAnalytics: Enhanced performance when processing database operations [ID 39109]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Because of a number of enhancements, overall performance of SLAnalytics has increased when processing database operations, especially small insert or update operations.

#### SLNet: Enhanced task processing [ID 39131]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Because of a number of enhancements, overall processing of tasks in SLNet has been optimized.

#### MySql.Data.dll updated to version 8.3.0 [ID 39152]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

The *MySql.Data.dll* file, stored in the `C:\Skyline DataMiner\Files` and `C:\Skyline DataMiner\Files\x64` folders, has been updated from version 6.9.12 to version 8.3.0.

The connection string will now include `allowloadlocalinfile=True` as this required setting needs to be enabled on both the client side and the server side of the database connection.

#### STaaS: Text of storage service health status alarm has been made clearer [ID 39154]

<!-- MR 10.4.0 [CU2] - FR 10.4.5 -->

Whenever the health of the storage service changes, an alarm mentioning the current health status is generated. The text of this health status alarm has now been made clearer.

#### SLAnalytics - Behavioral anomaly detection: Enhanced flatline detection accuracy [ID 39160]

<!-- MR 10.4.0 [CU2] - FR 10.4.5 -->

Because of a number of enhancements, the accuracy of the flatline detection algorithm has improved.

#### No more DataMiner startup beep [ID 39176]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

The DataMiner startup beep has been removed.

On virtual machines, beep commands are bypassed, and on physical machines, this beep would cause a delay of 1.25 seconds during startup.

#### OpenSearch: Enhanced performance when fetching alarm distribution data during DataMiner startup [ID 39177]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Because of a number of enhancements, on systems using an OpenSearch database, overall performance has increased when fetching alarm distribution data during DataMiner startup.

#### STaaS: Enhanced performance when fetching alarm distribution data [ID 39197]

<!-- MR 10.5.0 - FR 10.4.5 -->

Because of a number of enhancements, overall performance has increased when fetching alarm distribution data from the database, especially on Failover systems using Storage as a Service.

#### Enhanced performance when executing an NT_SNMP_RAW_SET notify type on multiple sources simultaneously [ID 39213]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Because of a number of enhancements, overall performance has increased when executing an `NT_SNMP_RAW_SET` notify type on multiple sources simultaneously.

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

#### SLAnalytics - Behavioral anomaly detection: Open suggestion events related to anomalies will now be limited to 500 [ID 39256]

<!-- MR 10.4.0 [CU2] - FR 10.4.5 -->

The number of open suggestion events related to behavioral anomalies will now be limited to 500 for the entire DataMiner System.

In other words, you will no longer have more than 500 suggestion events related to behavioral anomalies in the suggestion events tab of the Alarm Console.

#### DxMs upgraded [ID 39278]

<!-- RN 39278: MR 10.5.0 - FR 10.4.5 -->

The following DataMiner Extension Modules (DxMs), which are included in the DataMiner upgrade package, have been upgraded to the indicated versions:

- DataMiner ArtifactDeployer: version 1.6.8
- DataMiner CoreGateway: version 2.14.6
- DataMiner FieldControl: version 2.10.5
- DataMiner Orchestrator: version 1.5.8
- DataMiner SupportAssistant: version 1.6.8

For detailed information about the changes included in those versions, refer to the [DxM release notes](xref:DxM_RNs_index).

#### GQI: Maximum number of concurrent queries has been increased from 20 to 100 [ID 39293]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

The maximum number of concurrent GQI queries has now been increased from 20 to 100.

### Fixes

#### Correlation: Alarm buckets would not get cleaned up when alarms were cleared before the end of the time frame specified in the 'Collect events for ... after first event, then evaluate conditions and execute actions' setting [ID 38292]

<!-- MR 10.3.0 [CU14]/10.4.0 [CU2] - FR 10.4.5 -->

Up to now, when alarms were cleared before the end of the time frame specified in the *Collect events for ... after first event, then evaluate conditions and execute actions* correlation rule setting, the alarm buckets would not get cleaned up.

From now on, when a correlation rule is configured to use the *Collect events for ... after first event, then evaluate conditions and execute actions* trigger mechanism, all alarm buckets will be properly cleaned up so that no lingering buckets are left.

#### Problem when migrating SLAnalytics data, DOM data or SRM data to STaaS [ID 38884]

<!-- MR 10.4.0 [CU2] - FR 10.4.5 -->

When being migrated to STaaS, SLAnalytics data, DOM data or SRM data would incorrectly not be replicated. This could cause data created during the migration to be missing after the migration.

#### Not possible to delete a service created via an SRM booking when it had been assigned a name that was already being used [ID 38914]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

When a service created via an SRM booking got into an error state because it had been assigned a name that was already being used by another object, it would not be possible to delete it as it would be considered invalid.

#### Service & Resource Management: Problem when the function manager was not able to read the functions.xml file in C:\\Skyline DataMiner\\ServiceManager [ID 38925]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Up to now, in some cases, a runtime error could occur when the function manager was not able to read the *functions.xml* file in `C:\Skyline DataMiner\ServiceManager`.

From now on, if an error occurs when the function manager was not able to read that file, an entry will be added to the *SLFunctionManager.txt* log file, and if the error occurred because the file was locked by another process, the log entry will include the name of the process.

#### GQI: Problem when loading extensions [ID 38998]

<!-- MR 10.5.0 - FR 10.4.5 -->

When GQI extensions (i.e., ad hoc data sources or custom operators) were being loaded, in some cases, an exception could be thrown when inspecting the assembly of an extension that prevented subsequent extensions from being loaded.

This type of exceptions will be now be properly caught and logged as warnings so that other extensions will no longer be prevented from being loaded.

> [!TIP]
> See also: [GQI: Full logging [ID 38870]](xref:General_Feature_Release_10.4.4#gqi-full-logging-id-38870)

#### Problem while checking whether the DataMiner System was licensed to use the ModelHost DxM [ID 39001]

<!-- MR 10.5.0 - FR 10.4.5 -->

A *ModelHostException* could be thrown while checking whether the DataMiner System was licensed to use the ModelHost DxM.

#### STaaS: Database queries could time out [ID 39081]

<!-- MR 10.4.0 [CU2] - FR 10.4.5 -->

When a database query was performed against a STaaS database, in some cases, the query could time out, leading to no results being returned.

#### Protocols: Compliancies element would not get parsed correctly when it contained comments [ID 39085]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Up to now, the `<Compliancies>` element of a *protocol.xml* file would not get parsed correctly when it contains HTML comments.

As a result, DataMiner would fail to open the protocol and create elements with it.

#### Visual Overview: 'Connection could not be fully established' error when viewing visual overviews in a web app [ID 39133]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

When you opened a visual overview in a web app, in some cases, a `Connection could not be fully established` error would appear.

#### No emails could be sent as long as SLASPConnection was not fully initialized [ID 39137]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Up to now, an error would occur when a DataMiner module (e.g., Automation, Scheduler, etc.) tried to send an email while *SLASPConnection* was still initializing. From now on, all DataMiner modules will be able to send emails, even when *SLASPConnection* is still initializing.

#### SNMP: Timeout time of commands would incorrectly be doubled when using SNMP++ [ID 39164]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

When SNMP++ was being used to communicate with a device, commands would incorrectly have their configured timeout time doubled.

#### Problem with SLProtocol when processing a matrix parameter update [ID 39178]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

In some cases, an error could occur in SLProtocol when processing a matrix parameter update.

#### The 'Communication Info' table would incorrectly not get loaded into the element [ID 39181]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

When, in a connector, you had used the following `<Connections>` syntax, in some cases, the *Communication Info* table would incorrectly not get loaded into the element.

Example of the `<Connections>` syntax that caused the *Communication Info* table to not get loaded into the element:

```xml
<Connections>
   <Connection id="0" name="IPDRData">
      <SmartSerial>
      ...
      </SmartSerial>
   </Connection>
</Connections>
```

#### SLDMS would incorrectly stop loading elements when it failed to load one of them [ID 39184]

<!-- MR 10.4.0 [CU2] - FR 10.4.5 -->

When SLDataMiner has finished initializing the elements, SLDMS starts loading them.

Up to now, when SLDMS failed to load an element, it would stop loading the rest of them. As a result, SLNet would be unaware of the existence of some elements, causing them to not show up in DataMiner client applications without any error whatsoever.

From now on, when SLDMS fails to load an element, it will continue to load the rest of the elements, and generate an error for each element that could not be loaded.
