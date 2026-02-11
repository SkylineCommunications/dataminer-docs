---
uid: General_Feature_Release_10.4.9
---

# General Feature Release 10.4.9

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!IMPORTANT]
> When downgrading from DataMiner Feature Release version 10.3.8 (or higher) to DataMiner Feature Release version 10.3.4, 10.3.5, 10.3.6 or 10.3.7, an extra manual step has to be performed. For more information, see [Downgrading a DMS](xref:MOP_Downgrading_a_DMS).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.4.9](xref:Cube_Feature_Release_10.4.9).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.4.9](xref:Web_apps_Feature_Release_10.4.9).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Breaking changes

#### Parameter latch states will now be reset after every DataMiner restart [ID 39495]

<!-- MR 10.5.0 - FR 10.4.9 -->

In order to increase overall performance when starting up elements, parameter latch states will no longer be persistent by default. They will be reset after every DataMiner restart.

If you want to have persistent parameter latch states, do the following:

1. Open the *MaintenanceSettings.xml* file.

1. In the `AlarmSettings` section, add the `PersistParameterLatchState` option, and set it to true.

   ```xml
   <AlarmSettings>
      ...
      <PersistParameterLatchState>true</PersistParameterLatchState>
      ...
   </AlarmSettings>
   ```

1. Restart the DataMiner Agent.

> [!IMPORTANT]
>
> - From now on, by default (or when the `PersistParameterLatchState` option is set to false in *MaintenanceSettings.xml*), parameter latch states will no longer be written to or fetched from the database. This means that, after every DataMiner restart, all parameter latch states will be reset.
> - Element, service and view latch states will remain persistent as before.

## New features

#### Configuration of multiple threads for the same connection [ID 38887]

<!-- MR 10.5.0 - FR 10.4.9 -->

Control messages can now be sent in a thread of their own, which will prevent them from being blocked by ongoing polling actions on the same connections.

Previously, it was already possible to create multiple group execution queues for different connections. For example:

```xml
<Threads>
    <Thread connection="1" />
    <Thread connection="1002" />
</Threads>
```

Now you can also do this for the same connection by giving the thread an ID. Optionally, you can also give it a name, but this is currently only used for logging purposes. As a specific thread can have multiple connections linked to it, you will also need to specify the connection (by default 0). For example:

```xml
<Threads>
    <Thread id="1" name="HTTP Polling Thread" connection="0"/>
    <Thread id="2" name="HTTP Control Thread" connection="0"/>
</Threads>
```

> [!NOTE]
> If you want to use a thread definition with an ID, all thread definitions will need to have an ID. Combining thread definitions with and without ID is not supported.

You can then execute a group on a thread of your choice by specifying the thread ID on the group:

```xml
<Group id="1002" threadId="1">
```

In the element logging, the log entry for starting a thread will include the thread ID and thread name if these are defined.

For now, creating multiple threads for the same connection is **only supported for HTTP and SNMP connections**. If you try to configure this for a different kind of connection, the thread will not be created, and an entry will be added in the element logging to explain why. If you try to execute a group on a thread that has not been created for this reason, the group will be executed on the main protocol thread.

#### Table sizes will now be limited [ID 39836]

<!-- MR 10.5.0 - FR 10.4.9 -->

Table sizes will now be limited to protect DataMiner against ever-growing tables in elements.

> [!NOTE]
> These limits do not apply to logger tables, partial tables, and general parameter tables.

##### Row count limit for non-partial tables

If a table reaches 85&thinsp;000 rows:

- A notice alarm will be generated, and a banner will be displayed on the affected element to notify users.

If a table reaches 105&thinsp;000 rows:

- The system will prevent users from adding more rows to the table. However, they will still be able to update or delete rows.
- An error alarm will be generated, and a banner will be displayed on the affected element to notify users.
- The following entry will be added to the log file of the element:

  `Table [<table description> [table id]]: Reached maximum number of rows, adding new rows is not allowed. Current number of rows [<row count>]`

If the row count of a table drops:

- If the row count of a table drops below 100&thinsp;000, the error alarm will revert to a notice alarm, and the notice alarm banner will be displayed. Also, users will again be allowed to add new rows.
- If the row count of a table drops below 80&thinsp;000, both the notice alarm and the notice alarm banner will be removed.

##### Alarms for volatile tables with RTDisplay set to false

If a table reaches 805&thinsp;000 rows:

- A notice alarm will be generated, and a banner will be displayed on the affected element to notify users.

if a table reaches 1&thinsp;005&thinsp;000 rows:

- The system will prevent users from adding more rows to the table. However, they will still be able to update or delete rows.
- An error alarm will be generated, and a banner will be displayed on the affected element to notify users.
- The following entry will be added to the log file of the element:

  `Table [<table description> [table id]]: Reached maximum number of rows, adding new rows is not allowed. Current number of rows [<row count>]`

If the row count of a table drops:

- If the row count of a table drops below 1&thinsp;000&thinsp;000, the error alarm will revert to a notice alarm, and the notice alarm banner will be displayed. Also, users will again be allowed to add new rows.
- If the row count of a table drops below 800&thinsp;000, both the notice alarm and the notice alarm banner will be removed.

##### Format of alarms and banner messages

The notice alarm and banner message will have the following format:

`Table [<table description> [table id]] on page [<page name>] contains over [80K or 800K] rows. While there is no operational impact now, no more rows will be added once the table contains over [100K or 1000K] rows.`

The error alarm and banner message will have the following format:

`Table [<table description> [table id]] on page [<page name>] contains over [100K or 1000K] rows. No more rows will be added to this table until the number of rows drops below [100K or 1000K].`

When multiple tables generate an alarm for the same element, the banner will display the following message:

`Multiple tables have exceeded the row limit. Please check the alarms.`

## Changes

### Enhancements

#### Enhanced performance when processing SNMPv3 elements [ID 39356]

<!-- MR 10.5.0 - FR 10.4.9 -->

Because of a number of enhancements, overall performance has increased when processing SNMPv3 elements.

> [!IMPORTANT]
> When, on older DataMiner systems, you import DELT packages containing elements exported on systems running DataMiner Main Release version 10.5.0 or Feature Release version 10.4.9 (or newer), all SNMPv3 credentials will be lost and will have to be re-entered manually.

#### Enhanced performance and error handling when loading virtual elements [ID 39478]

<!-- MR 10.4.0 [CU6] - FR 10.4.9 -->

Because of a number of enhancements, overall performance has increased when loading virtual elements.

Also, error handling when loading virtual elements has been improved.

#### User-defined APIs: ApiToken and ApiDefinition objects will now be cached [ID 39701]

<!-- MR 10.5.0 - FR 10.4.9 -->

SLNet will now cache [ApiToken](xref:UD_APIs_Objects_ApiToken) and [ApiDefinition](xref:UD_APIs_Objects_ApiDefinition) objects. This will enhance the overall performance of the API requests.

#### SLAnalytics: Alarms and suggestion events for virtual functions will now be generated on the parent element [ID 39707]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When, in the scope of behavioral anomaly detection, proactive cap detection or pattern matching, SLAnalytics has to generate alarms or suggestion events for virtual functions, from now on, it will generate them on the parent element. However, it will continue to generate alarms and suggestion events for all other kinds of DVEs on the child element.

#### MessageBroker: Clients will now first attempt to connect via the local NATS node [ID 39727]

<!-- MR 10.4.0 [CU7] - FR 10.4.9 -->

From now on, when a client connects to the DataMiner System, an attempt will first be made to connect to the NATs bus via the local NATS node. Only when this attempt fails, will the client connect to the NATS bus via another node.

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

#### Service & Resource Management: SRM master synchronization now takes into account the Resource Manager state [ID 39835]

<!-- MR 10.5.0 - FR 10.4.9 -->

Up to now, the SRM master synchronization only took into account the DMA state, not the Resource Manager state. In some cases, that could lead to requests being sent to a DataMiner Agent of which the Resource Manager was down.

From now on, the SRM master synchronization will also take into account the Resource Manager state. A DataMiner Agent will only be appointed SRM master if DataMiner is running and if the Resource Manager is initialized.

Also, the logging with regard to the SRM master synchronization and master election process has been enhanced.

#### Time-scoped relation learning: Enhanced accuracy [ID 39841]

<!-- MR 10.5.0 - FR 10.4.9 -->

Because of a number of enhancements, the accuracy of the time-scoped relation learning algorithm has increased.

#### When stopping, native processes will only wait for 30 seconds to close the MessageBroker connection when necessary [ID 39863]

<!-- MR 10.4.0 [CU7] - FR 10.4.9 -->

When a native process (e.g. SLDataMiner) is stopping, it will by default wait for 30 seconds before it closes the MessageBroker connection.

However, in some rare cases, there is no need to wait for 30 seconds. In those cases, the MessageBroker connection will be closed immediately.

#### SLAnalytics - Behavioral anomaly detection: Enhanced detection of change points of type 'flatline' [ID 39898]

<!-- MR 10.5.0 - FR 10.4.9 -->

A number of enhancements have been made to the algorithm that detects change points of type "flatline".

When the trend data of a parameter appears to have frequent flatline periods, the chance of a flatline change point being detected and a suggestion event being created for it has now decreased.

Also, a parameter will need to have had at least one day of fluctuating trend data behavior before the flatline detection functionality will detect the start of a flatline period.

#### Service & Resource Management: New 'SkipServiceHandling' option to allow the 'SRMServiceInfo' object check to be skipped when starting/stopping a booking [ID 39939]

<!-- MR 10.5.0 - FR 10.4.9 -->

When a booking was started or stopped, up to now, the system would always verify whether that booking had an `SRMServiceInfo` object. If it did, then no services would be created or deleted. However, when the start actions were run on a DMA other than the DMA on which the booking was created, no `SRMServiceInfo` object would be found, causing a service to be created when that was not necessary.

In the configuration file of the Resource Manager (`C:\Skyline DataMiner\ResourceManager\config.xml`), you can now specify a new *SkipServiceHandling* option, which will allow you to indicate whether or not an `SRMServiceInfo` object check has to be performed when a booking is started or stopped.

#### SLAutomation: Enhanced compilation of automation scripts [ID 39965]

<!-- MR 10.4.0 [CU6] - FR 10.4.9 -->

A number of enhancements have been made with regard to the compilation of automation scripts.

#### SLAnalytics - Alarm focus & Automatic incident tracking: Alarms generated for child DVE elements using a parameter ID from the main DVE element will now also be taken into account [ID 39988]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

From now on, alarms generated for child DVE elements using a parameter ID from the main DVE element can also get a focus value and, as a result, be grouped by Automatic incident tracking.

#### DataMiner upgrade: ResetConfig.txt will no longer be added to FilesToDelete.txt [ID 39994]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

Every DataMiner upgrade package includes a *FilesToDelete.txt* file, which lists all files in the `C:\Skyline DataMiner\` folder that should be deleted during the upgrade procedure. From now on, the *ResetConfig.txt* file will no longer be added to that list of files to be deleted.

The `C:\Skyline DataMiner\Files\ResetConfig.txt` file is a file used by the factory reset tool *SLReset.exe* as a whitelist to determine which files to keep. The first time *SLReset.exe* is executed, the default whitelist is added to *ResetConfig.txt*. Afterwards, you can add files you want to keep to this whitelist, so that these are not removed when the tool is executed again. If you delete *ResetConfig.txt*, the default whitelist will be used again.

#### Storage as a Service: Event hub throttling errors will now be logged as 'Warning' instead of 'Error' [ID 40018]

<!-- MR 10.4.0 [CU6] - FR 10.4.9 -->

From now on, event hub throttling errors will be logged as 'Warning' instead of 'Error'.

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

#### Service & Resource Management: Enhanced logging when booking objects are added to, updated in or deleted from the cache [ID 40043]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When booking objects are added to, updated in or deleted from the cache, from now on, the following properties of the booking in question will be logged:

- Booking status
- Booking resources
- Time when the booking was last modified

#### SLNet.txt log file will no longer contain any logging from MessageBroker [ID 40061]

<!-- MR 10.4.0 [CU7] - FR 10.4.9 -->

From now on, by default, the *SLNet.txt* log file will no longer contain any logging from MessageBroker.

#### Factory reset tool will now use an absolute path to locate ResetConfig.txt [ID 40074]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

Up to now, the factory reset tool *SLReset.exe* always used the relative path `.\\` to locate the `C:\Skyline DataMiner\Files\ResetConfig.txt` file, assuming that it would always be executed from the `C:\Skyline DataMiner\Files` folder. As a result, when it was executed from another folder (e.g. from a terminal window opened on the Windows desktop), it would not be able to find the *ResetConfig.txt* file.

From now on, *SLReset.exe* will always use the absolute path `C:\Skyline DataMiner\Files\ResetConfig.txt` when locating *ResetConfig.txt*.

#### Service & Resource Management: Enhanced performance when creating and initializing reservations [ID 40082]

<!-- MR 10.5.0 - FR 10.4.9 -->

Because a number of database operations have been optimized, overall performance has increased when creating and initializing reservations.

#### Automation: Using the Engine.Sleep method in an automation script could affect other scripts [ID 40104]

<!-- MR 10.3.0 [CU19]/10.4.0 [CU6] - FR 10.4.9 -->

Up to now, using the *Engine.Sleep* method in an automation script could cause issues that would affect other scripts. This has now been resolved.

#### SLLogCollector: Enhanced CPU usage when 'Include memory dump' is selected [ID 40109]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

Because of a number of enhancements, SLLogCollector will now use less CPU resources when you selected the *Include memory dump* option.

#### Failover: Online agent will be restarted at the end of the decommissioning process [ID 40161]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When you decommission a Failover setup, from now on, the DataMiner Agent that was online when you started the decommission process will be restarted as soon as the decommission process has finished.

The DataMiner Agent that was offline when you started the decommission process will, as before, be reset by the factory reset tool *SLReset.exe*.

#### DataMiner startup: Listening for incoming traps will now delayed until SLNet is fully initialized [ID 40162]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

Up to now, listening for incoming traps would start once SLSNMPManager was up and running. In order to reduce the time it takes for DataMiner to start up, listening for incoming traps will now be delayed until SLNet is fully initialized. As a result, SLNet will only be requested to distribute traps once all DataMiner modules are loaded.

#### BPA tests can now be marked 'upgrade only' [ID 40163]

<!-- MR 10.5.0 - FR 10.4.9 -->

BPA tests can now be marked "upgrade only". That way, tests marked as such can be ignored by the DataMiner installer.

#### MySQL.data.dll downgraded to version 8.0.32 to prevent known MySQL issue [ID 40200]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

In order to prevent the following known MySQL issue from occurring, the *Mysql.Data.dll* driver has been downgraded to version 8.0.32.

- [Bug #110789 - OpenAsync throws unhandled exception from thread pool](https://bugs.mysql.com/bug.php?id=110789)

#### Security enhancements [ID 40229]

<!-- 40229: MR 10.3.0 [CU19]/10.4.0 [CU7] - FR 10.4.9 -->

A number of security enhancements have been made.

#### DxMs upgraded [ID 40231] [ID 40254]

<!-- RN 40231: MR 10.4.0 [CU6] - FR 10.4.9 -->
<!-- RN 40254: MR 10.4.0 [CU6] - FR 10.4.9 -->

The following DataMiner Extension Modules (DxMs), which are included in the DataMiner upgrade package, have been upgraded to the indicated versions:

- DataMiner CoreGateway: version 2.14.9
- DataMiner SupportAssistant: version 1.6.10

For detailed information about the changes included in those versions, refer to the [DxM release notes](xref:DxM_RNs_index).

#### DataMiner Object Models: Enhanced storage of DOM instances [ID 40242]

<!-- MR 10.5.0 - FR 10.4.9 -->

Because of a number of enhancements, from now on, less storage space will be needed when storing DOM instances in the database, especially in cases where multiple sections link to the same section definition.

#### All Cassandra driver logging will now be stored in the SLCassandraDriver.txt file [ID 40268]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

From now on, all Cassandra driver logging will be stored in the *SLCassandraDriver.txt* file.

> [!NOTE]
> The logging of the SQLite driver, which is used when offloading data to file, will now be stored in the *SLSQLiteDriver.txt* file.

#### User-Defined APIs: UserDefinableApiEndpoint DxM has been updated and now requires .NET 8 [ID 40303]

<!-- MR 10.5.0 - FR 10.4.9 -->

The UserDefinableApiEndpoint DxM has been upgraded to version 3.2.3. It now requires .NET version 8.

#### DataMiner Object Models: Exception thrown when trying to use unsupported field types will now include the full type name [ID 40339]

<!-- MR 10.4.0 [CU6] - FR 10.4.9 -->

The exception that is thrown when an attempt is made to serialize a DOM instance containing unsupported value types will now include the full type name. The text of the exception will now indicate more clearly which type is not supported.

Example of the former exception:

```txt
System.NotSupportedException: This type of ValueWrapper is not supported (ValueWrapper`1)
```

Example of the new exception:

```txt
System.NotSupportedException: This type of ValueWrapper is not supported (Skyline.DataMiner.Net.Sections.ValueWrapper`1[[Skyline.DataMiner.Net.Apps.DataMinerObjectModel.DomInstanceId, SLNetTypes, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9789b1eac4cb1b12]])
```

#### SLNetClientTest - DataMiner Object Models: DOM instance overview now shows DOM definition names [ID 40341]

<!-- MR 10.4.0 [CU6] - FR 10.4.9 -->

In the SLNetClientTest tool, you can go to *Advanced > Apps > DataMiner Object Model...* to get a list of all DOM modules. When you drill down to get a list of all DOM objects in a particular module, the first tab shows a subset of the recently updated DOM instances including their ID, their name, and some additional metadata. This view will now have an extra column containing the name of the DOM definitions to which the instances are linked.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### Enhanced CPU usage when storing table rows in EPM environments [ID 40380]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

Because of a number of enhancements, less CPU resources will now be used when storing table rows in EPM environments.

### Fixes

#### Problem with SLElement while processing table parameter updates [ID 39462]

<!-- MR 10.4.0 [CU6] - FR 10.4.9 -->

In some cases, SLElement could stop working while processing table parameter updates.

#### Alarms generated for an element with a virtual function would incorrectly get exported to that virtual function [ID 39536]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When alarms were generated for an element with a virtual function, those alarms would incorrectly get exported to the virtual function.

#### SLDataGateway: Problem when retrieving data page by page [ID 39581]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When SLDataGateway retrieved data from the database page by page, in some cases, paging handlers that had already fetched all their data and had already been deleted would incorrectly be used, causing exceptions to be thrown.

#### DataMiner Object Models: CRUD events would incorrectly be of type 'DomCrudEvent\<T\>' [ID 39696]

<!-- MR 10.4.0 [CU6] - FR 10.4.9 -->

Events generated after DOM objects were created, updated or deleted would incorrectly be of type `DomCrudEvent<T>` instead of e.g. `DomInstancesChangedEventMessage`.

#### Run-time error could occur in SLProtocol when a large SNMP table was being polled [ID 39756]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

Up to now, when an SNMP table took a long time to be polled, a runtime error could occur in SLProtocol.

To avoid such runtime errors, from now on, when SLSNMPManager is polling an SNMP table, it will send a notification to SLProtocol every minute to indicate that SNMP data is being polled.

#### Failover switch would take significantly longer than usual due to blocking calls in the SLASPConnection process [ID 39769]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

On Failover systems with a Cassandra setup, a Failover switch would take significantly longer than usual due to blocking calls in the SLASPConnection process.

See also: [Failover switch taking a long time on systems with Cassandra setup](xref:KI_Failover_switch_Cassandra)

#### Problem due to the protobuf-net framework in SLNetTypes being initialized on multiple threads [ID 39807]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

On heavily loaded systems, in some cases, the protobuf-net framework in SLNetTypes would simultaneously be initialized on multiple threads, causing the following exception to be thrown:

`Timeout while inspecting metadata; this may indicate a deadlock. This can often be avoided by preparing necessary serializers during application initialization, rather than allowing multiple threads to perform the initial metadata inspection; please also see the LockContended event`

#### Service & Resource Management: Problem when deleting a discrete value of a profile parameter [ID 39867]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When two capability parameters shared the same discrete value, and the value of one of those parameters was included in a resource, up to now, it would not be possible to delete that value for the parameter that was not used.

#### No longer possible to edit a service that had been migrated from one DMA to another within a DMS [ID 39893]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When a service had been migrated from one DataMiner Agent to another within a DataMiner System, it would no longer be possible to edit that service. The messages would incorrectly be sent to the DataMiner Agent that hosted the service previously.

#### Failover: Problem when connecting to an offline agent with a DataMiner Cube that used external authentication [ID 39925]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When you connected to an offline agent in a Failover setup with a DataMiner Cube that used external authentication, an `External authentication failed` error would appear. As a result, it would not be possible to force that offline agent to go online.

#### SLAnalytics: Issues fixed with regard to alarm template monitoring mechanism [ID 39948]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

A number of issues have been fixed with regard to the internal SLAnalytics alarm template monitoring mechanism.

#### SLNet - CloudEndpointManager: Problem at startup when NATS and NAS services were not installed [ID 39980]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

At startup, in some cases, the CloudEndpointManager in SLNet could throw an exception when the NATS and NAS services were not installed.

#### Service & Resource Management: Problem when a DMA did not respond during the midnight sync of the Resource Manager [ID 40021]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When a DMA did not respond during the midnight synchronization (e.g. because the Resource Manager had not been initialized on that DMA), up to now, a nullreference exception would be thrown directly after the error had been logged.

#### Sending a GetCCAGatewayGlobalStateRequest would incorrectly require the 'Connect to cloud/DCP' user permission [ID 40051]

<!-- MR 10.5.0 - FR 10.4.9 -->
<!-- Not added to MR 10.5.0 - Reverted in FR 10.4.10 by RN 40395 -->

Up to now, sending a *GetCCAGatewayGlobalStateRequest* to check whether the DataMiner System is connected to dataminer.services would incorrectly require the *Modules > System configuration > Cloud sharing/gateway > Connect to cloud/DCP* user permission.

As a result, in DataMiner Cube, users without the above-mentioned user permission would not be able to see any relations after clicking the light bulb icon in the top-right corner of a trend graph.

From now on, the *Connect to cloud/DCP* user permission is no longer required to be able to send a *GetCCAGatewayGlobalStateRequest*.

#### MessageBroker: Reconnection mechanism could cause the overall CPU load to increase [ID 40071]

<!-- MR 10.4.0 [CU7] - FR 10.4.9 -->

Whenever the MessageBroker client loses its connection to the NATS server, it will try to reconnect. Because of an internal issue, up to now, this reconnection mechanism could cause the overall CPU load to increase. This issue has now been fixed.

#### automation scripts could fail due to zero or negative sleep intervals being passed to Engine.Sleep [ID 40084]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

Up to now, an automation script could fail because a zero or negative sleep interval was passed to the `Engine.Sleep` method. From now on, any zero or negative sleep interval will be ignored.

#### SLProtocol would leak memory when performing an SNMP Set [ID 40112]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

In the following cases, SLProtocol would leak memory:

- When performing an SNMP Set on a cell in a table.

- When performing an SNMP Set on a standalone parameter with part of the OID coming from a different standalone parameter. See the following example:

  `<OID type="complete" id="9901">1.3.6.1.4.1.14014.1.1.1.6.1.1.6.*</OID>`

#### Service & Resource Management: Booking events could be triggered multiple times when a database issue occurred while DataMiner was starting up [ID 40114]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When a database issue occurred while DataMiner was starting up, in some cases, booking events could be triggered multiple times.

#### Problem with SLProtocol when elements with multiple connections were in slow poll mode [ID 40119]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

In some cases, SLProtocol could stop working when elements with multiple connections were in slow poll mode.

#### Problem with SLProtocol when loading a connector with forbidden parameter IDs [ID 40127]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

Up to now, SLProtocol would stop working when it loaded a connector containing parameters with IDs that exceeded the boundaries (see [Reserved parameter IDs](xref:ReservedIDsParameters)).

From now on, SLProtocol will no longer stop working when loading such a connector. However, if any parameters are found with IDs that exceed the boundaries, they will not be loaded.

#### SLAnalytics - Behavioral anomaly detection: Change points would incorrectly be generated after an SLAnalytics process restart [ID 40156]

<!-- MR 10.4.0 [CU6] - FR 10.4.9 -->

In some cases, new change points would incorrectly be generated shortly after the SLAnalytics process had been restarted, even though no changes in trend behavior had been detected.

#### Service & Resource Management: Problem when retrieving resources filtered by property [ID 40209]

<!-- MR 10.4.0 [CU6] - FR 10.4.9 -->

When a request was sent to a DataMiner Agent to retrieve resources filtered by property, in some cases, the DataMiner Agent would throw a `NullReferenceException` when one of the resources had "null" properties.

#### Problem when NATSMigration called SLKill to stop the NATS service [ID 40271]

<!-- MR 10.4.0 [CU6] - FR 10.4.9 -->

When the NATSMigration process called SLKill to stop the NATS service, up to now, SLKill would incorrectly also kill the NATSMigration process.

From now on, SLKill will no longer kill the NATSMigration process when it is asked to kill all processes of which the name starts with "NATS".

#### GQI: Data returned by multiple queries for the same user would incorrectly get mixed [ID 40293]

<!-- MR 10.4.0 [CU6] - FR 10.4.9 -->

When multiple GQI queries were run for the same user, using the same data source, and with real-time updates enabled, in some cases, the data returned by those queries would incorrectly get mixed.

#### Video thumbnail of type 'Generic Images' would not be reloaded [ID 40328]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When no proxy was used to show a video thumbnail of type *Generic Images*, in some cases, the specified image would incorrectly not be reloaded at the configured refresh rate.

Example:

```html
http://<DMA IP>/VideoThumbnails/video.htm?type=Generic%20Images&source=<IMG URL>&refresh=5000&proxy=false
```

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

#### Certain processes could get restarted while DataMiner was being stopped [ID 40337]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

In some rare cases, certain processes could get restarted while DataMiner was being stopped. This would then cause issue when DataMiner was restarted.

#### Progress information updates no longer available during DataMiner upgrade [ID 40348]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

In some cases, it could occur that progress information updates during a DataMiner upgrade were no longer available. This was caused by long timeouts in gRPC connections. These could also trigger a race condition, causing the logic checking for progress updates on the client side to override a successful upgrade event. The timeouts will now occur more quickly, so that a reconnection occurs faster and updates become available again.

#### SLLogCollector would incorrectly report a null reference exception when a DataMiner Agent did not have Failover configured [ID 40376]

<!-- MR 10.5.0 - FR 10.4.9 -->
<!-- Not added to MR 10.5.0 - Introduced by RN 39526 -->

Up to now, SLLogCollector would incorrectly report the following null reference exception when a DataMiner Agent did not have Failover configured:

```txt
ERROR - Object reference not set to an instance of an object.   at LogCollectorWPF.Helper.DataMiner.DataMinerHelper.get_FailoverHostname()
```

#### SLAnalytics: Behavioral anomaly detection, proactive cap detection and trend icons could not be started on systems without indexing database [ID 40505]

<!-- MR 10.5.0 - FR 10.4.9 -->
<!-- Not added to MR 10.5.0 - Introduced by RN 39691 -->

On systems without an indexing database, SLAnalytics would incorrectly not be able to start the behavioral anomaly detection, proactive cap detection and trend icons features.
