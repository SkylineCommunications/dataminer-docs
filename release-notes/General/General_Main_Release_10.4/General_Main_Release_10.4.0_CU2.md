---
uid: General_Main_Release_10.4.0_CU2
---

# General Main Release 10.4.0 CU2

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Main Release 10.4.0 CU2](xref:Cube_Main_Release_10.4.0_CU2).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.4.0 CU2](xref:Web_apps_Main_Release_10.4.0_CU2).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Breaking changes

#### DOM string fields will now be filtered case-insensitively [ID 38950]

<!-- MR 10.4.0 [CU2] - FR 10.4.5 -->

Up to now, DOM string fields were filtered case-sensitively. From now on, these fields will by default be filtered case-insensitively.

> [!NOTE]
> If necessary, you can overrule this default filter behavior in code by using `StringComparison.Ordinal`. See the following snippet:
>
> ```csharp
> var filter = DomInstanceExposers.FieldValues.DomInstanceField(_stringFieldDescriptor.ID).Contains("test", StringComparison.Ordinal)
> ```

### Enhancements

#### Elasticsearch re-indexing tool [ID 37994]

<!-- MR 10.4.0 [CU2] - FR 10.4.4 -->

Migrating data from from Elasticsearch 6.8.22 to OpenSearch 2.11.1 involves the following steps:

1. Taking a snapshot of the Elasticsearch 6.8.22 cluster.
1. Copying the snapshot to an Elasticsearch 7.10.0 cluster, and restoring it.
1. Re-indexing the data and taking another snapshot.
1. Copying the snapshot with the re-indexed data to an OpenSearch 2.11.1 cluster, and restoring it

To perform step 3, a command-line re-indexing tool has been developed: *ReIndexElasticSearchIndexes.exe*.

This tool accepts the following arguments:

| Argument | Description |
|----------|-------------|
| -Node or -N | The name of the node to be used for re-indexing (mandatory).<br>Format: `http(s)://127.0.0.1:9200` or `http(s)://fqdn:9200` |
| -User or -U | The user name, to be provided in case Elasticsearch was hardened.<br>See [Securing the Elasticsearch database](xref:Security_Elasticsearch) |
| -Password or -P | The user password |
| -DBPrefix or -D | The database prefix, to be provided in case a custom database prefix is used instead of the default `dms-` prefix.<br>If you do not provide a prefix, the default `dms-` will be used. |
| -TLSEnabled or -T | Whether or not TLS is enabled for this ElasticSearch database.<br>Values: true or false. Default: false |

If you do not specify a user name and user password, the tool will assume a default ElasticSearch database installation.

#### Enhanced performance when editing properties in bulk [ID 38255]

<!-- MR 10.4.0 [CU2] - FR 10.4.5 -->

Performance has increased when properties of elements, services, or views are edited in bulk.

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

Up to now, Automation scripts would always be checked whether they were Cassandra ready, regardless of the type of database used by the DataMiner System.

From now on, this Cassandra ready check will only be performed on DataMiner Systems using a MySQL database. When the DataMiner System is using a type of database other than MySQL, Automation scripts will always be considered Cassandra ready.

#### Enhanced performance when starting up a DataMiner Agent with a large number of virtual elements [ID 38780]

<!-- MR 10.4.0 [CU2] - FR 10.4.5 -->

Because of a number of enhancements, overall performance has increased when starting up a DataMiner Agent with a large number of virtual elements.

#### New SLTimeToLive.txt log file containing all changes made to the TTL settings [ID 38851]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

In the `C:\Skyline DataMiner\Logging\SLTimeToLive` folder, you can now find a new *SLTimeToLive.txt* log file, listing all changes made to the TTL settings in Cube's *System Center > System settings > Time to live* page.

> [!NOTE]
> The contents of this folder will not be deleted during either a DataMiner restart or a DataMiner upgrade. However, in the *SLTimeToLive.txt* file, the oldest entries will be removed when the maximum log file size is exceeded.

#### Security enhancements [ID 38904]

<!-- RN 38904: MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

A number of security enhancements have been made.

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

#### STaaS: SLDataGateway will now periodically check the health of the storage service [ID 39068]

<!-- MR 10.4.0 [CU2] - FR 10.4.5 -->

When Storage as a Service (STaaS) is used, SLDataGateway will now periodically check the health of that storage service. If the current status cannot be determined or if the current status is "red", SLDataGateway will switch to file offload mode.

> [!NOTE]
>
> - When the current status is "yellow", SLDataGateway will not switch to file offload mode.
> - Whenever the health of the storage service changes, an alarm mentioning the current health status is generated.

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

#### Enhanced performance when executing an NT_SNMP_RAW_SET notify type on multiple sources simultaneously [ID 39213]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Because of a number of enhancements, overall performance has increased when executing an `NT_SNMP_RAW_SET` notify type on multiple sources simultaneously.

#### SLAnalytics - Behavioral anomaly detection: Open suggestion events related to anomalies will now be limited to 500 [ID 39256]

<!-- MR 10.4.0 [CU2] - FR 10.4.5 -->

The number of open suggestion events related to behavioral anomalies will now be limited to 500 for the entire DataMiner System.

In other words, you will no longer have more than 500 suggestion events related to behavioral anomalies in the suggestion events tab of the Alarm Console.

#### GQI: Maximum number of concurrent queries has been increased from 20 to 100 [ID 39293]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

The maximum number of concurrent GQI queries has now been increased from 20 to 100.

### Fixes

#### Databases: Problem when starting a migration from MySQL to Cassandra [ID 37589]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.1 -->

When you started a migrating from a MySQL database to a Cassandra database, an error could occur when the connection to the MySQL database took a long time to get established.

#### Correlation: Alarm buckets would not get cleaned up when alarms were cleared before the end of the time frame specified in the 'Collect events for ... after first event, then evaluate conditions and execute actions' setting [ID 38292]

<!-- MR 10.3.0 [CU14]/10.4.0 [CU2] - FR 10.4.5 -->

Up to now, when alarms were cleared before the end of the time frame specified in the *Collect events for ... after first event, then evaluate conditions and execute actions* correlation rule setting, the alarm buckets would not get cleaned up.

From now on, when a correlation rule is configured to use the *Collect events for ... after first event, then evaluate conditions and execute actions* trigger mechanism, all alarm buckets will be properly cleaned up so that no lingering buckets are left.

#### STaaS: Problem when going into file offload mode [ID 38648]

<!-- MR 10.4.0 [CU2] - FR 10.4.4 -->

When the system went into file offload mode, in some cases, a serialization issue could occur, causing the file offload mode to get stuck.

#### Problem when migrating SLAnalytics data, DOM data or SRM data to STaaS [ID 38884]

<!-- MR 10.4.0 [CU2] - FR 10.4.5 -->

When being migrated to STaaS, SLAnalytics data, DOM data or SRM data would incorrectly not be replicated. This could cause data created during the migration to be missing after the migration.

#### DataMiner Cube: 'Search for alarms' would list alarms with timestamps according to the local time zone of the client computer [ID 38899]

<!-- MR 10.3.0 [CU14]/10.4.0 [CU2] - FR 10.4.4 -->

Up to now, when you opened a new alarm tab, and did a search using the *Search for alarms* box, the alarms matching the search criterion would incorrectly show timestamps according to the local time zone of the client computer.

From now on, when you use the *Search of alarms* box, the alarms matching the search criterion will show timestamps according to the server time, i.e. the local time zone of the DataMiner Agent to which the Cube client is connected.

#### Not possible to delete a service created via an SRM booking when it had been assigned a name that was already being used [ID 38914]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

When a service created via an SRM booking got into an error state because it had been assigned a name that was already being used by another object, it would not be possible to delete it as it would be considered invalid.

#### Service & Resource Management: Problem when the function manager was not able to read the functions.xml file in C:\\Skyline DataMiner\\ServiceManager [ID 38925]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.5 -->

Up to now, in some cases, a runtime error could occur when the function manager was not able to read the *functions.xml* file in `C:\Skyline DataMiner\ServiceManager`.

From now on, if an error occurs when the function manager was not able to read that file, an entry will be added to the *SLFunctionManager.txt* log file, and if the error occurred because the file was locked by another process, the log entry will include the name of the process.

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

Up to now, an error would occur when a DataMiner module (e.g. Automation, Scheduler, etc.) tried to send an email while *SLASPConnection* was still initializing. From now on, all DataMiner modules will be able to send emails, even when *SLASPConnection* is still initializing.

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
