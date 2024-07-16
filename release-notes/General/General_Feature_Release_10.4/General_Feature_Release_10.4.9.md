---
uid: General_Feature_Release_10.4.9
---

# General Feature Release 10.4.9 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
> When downgrading from DataMiner Feature Release version 10.3.8 (or higher) to DataMiner Feature Release version 10.3.4, 10.3.5, 10.3.6 or 10.3.7, an extra manual step has to be performed. For more information, see [Downgrading a DMS](xref:MOP_Downgrading_a_DMS).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.4.9](xref:Cube_Feature_Release_10.4.9).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.4.9](xref:Web_apps_Feature_Release_10.4.9).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### Enhanced performance when processing SNMPv3 elements [ID_39356]

<!-- MR 10.5.0 - FR 10.4.9 -->

Because of a number of enhancements, overall performance has increased when processing SNMPv3 elements.

> [!IMPORTANT]
> When, on older DataMiner systems, you import DELT packages containing elements exported on systems running DataMiner Main Release version 10.5.0 or Feature Release version 10.4.9 (or newer), all SNMPv3 credentials will be lost and will have to be re-entered manually.

#### Enhanced performance and error handling when loading virtual elements [ID_39478]

<!-- MR 10.4.0 [CU6] - FR 10.4.9 -->

Because of a number of enhancements, overall performance has increased when loading virtual elements.

Also, error handling when loading virtual elements has been improved.

#### SLAnalytics: Alarms and suggestion events for virtual functions will now be generated on the parent element [ID_39707]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When, in the scope of behavioral anomaly detection, proactive cap detection or pattern matching, SLAnalytics has to generate alarms or suggestion events for virtual functions, from now on, it will generate them on the parent element. However, it will continue to generate alarms and suggestion events for all other kinds of DVEs on the child element.

#### MessageBroker: Clients will now first attempt to connect via the local NATS node [ID_39727]

<!-- MR 10.5.0 - FR 10.4.9 -->

From now on, when a client connects to the DataMiner System, an attempt will first be made to connect to the NATs bus via the local NATS node. Only when this attempt fails, will the client connect to the NATS bus via another node.

#### Automation scripts: Resources can now be retrieved page by page [ID_39743]

<!-- MR 10.5.0 - FR 10.4.9 -->

From now on, in Automation scripts, it is possible to retrieve resources page by page.

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

#### Service & Resource Management: Changing the cache settings of the Resource Manager without restarting DataMiner [ID_39795]

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

#### Service & Resource Management: SRM master synchronization now takes into account the Resource Manager state [ID_39835]

<!-- MR 10.5.0 - FR 10.4.9 -->

Up to now, the SRM master synchronization only took into account the DMA state, not the Resource Manager state. In some cases, that could lead to requests being sent to a DataMiner Agent of which the Resource Manager was down.

From now on, the SRM master synchronization will also take into account the Resource Manager state. A DataMiner Agent will only be appointed SRM master if DataMiner is running and if the Resource Manager is initialized.

Also, the logging with regard to the SRM master synchronization and master election process has been enhanced.

#### Time-scoped relation learning: Enhanced accuracy [ID_39841]

<!-- MR 10.5.0 - FR 10.4.9 -->

Because of a number of enhancements, the accuracy of the time-scoped relation learning algorithm has increased.

#### SLDataGateway will start up earlier in the DataMiner startup process [ID_39842]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When DataMiner starts up, from now on, SLDataGateway will start up earlier in the startup process.

#### When stopping, native processes will only wait for 30 seconds to close the MessageBroker connection when necessary [ID_39863]

<!-- MR 10.5.0 - FR 10.4.9 -->

When a native process (e.g. SLDataMiner) is stopping, it will by default wait for 30 seconds before it closes the MessageBroker connection.

However, in some rare cases, there is no need to wait for 30 seconds. In those cases, the MessageBroker connection will be closed immediately.

#### SLAnalytics - Behavioral anomaly detection: Enhanced detection of change points of type 'flatline' [ID_39898]

<!-- MR 10.5.0 - FR 10.4.9 -->

A number of enhancements have been made to the algorithm that detects change points of type "flatline".

When the trend data of a parameter appears to have frequent flatline periods, the chance of a flatline change point being detected and a suggestion event being created for it has now decreased.

Also, a parameter will need to have had at least one day of fluctuating trend data behavior before the flatline detection functionality will detect the start of a flatline period.

#### SLAnalytics - Alarm focus & Automatic incident tracking: Alarms generated for child DVE elements using a parameter ID from the main DVE element will now also be taken into account [ID_39988]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

From now on, alarms generated for child DVE elements using a parameter ID from the main DVE element can also get a focus value and, as a result, be grouped by Automatic incident tracking.

#### DataMiner upgrade: ResetConfig.txt will no longer be added to FilesToDelete.txt [ID_39994]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

Every DataMiner upgrade package includes a *FilesToDelete.txt* file, which lists all files in the *C:\\Skyline DataMiner\\* folder that should be deleted during the upgrade procedure. From now on, the *ResetConfig.txt* file will no longer be added to that list of files to be deleted.

The *C:\\Skyline DataMiner\\Files\\ResetConfig.txt* file is a file used by the factory reset tool *SLReset.exe* as a whitelist to determine which files to keep. The first time *SLReset.exe* is executed, the default whitelist is added to *ResetConfig.txt*. Afterwards, you can add files you want to keep to this whitelist, so that these are not removed when the tool is executed again. If you delete *ResetConfig.txt*, the default whitelist will be used again.

#### Storage as a Service: Event hub throttling errors will now be logged as 'Warning' instead of 'Error' [ID_40018]

<!-- MR 10.4.0 [CU6] - FR 10.4.9 -->

From now on, event hub throttling errors will be logged as 'Warning' instead of 'Error'.

#### SLNet: Enhanced performance when sending requests to SLDataGateway [ID_40023]

<!-- MR 10.5.0 - FR 10.4.9 -->

Because of a number of enhancements made to SLNet, overall performance has increased when sending requests to SLDataGateway.

#### DataMiner Object Models: SLModuleSettingsManager.txt log file will now contain the IDs of the modules that were created, updated or deleted [ID_40028]

<!-- MR 10.5.0 - FR 10.4.9 -->

From now on, the *SLModuleSettingsManager.txt* log file will contain the IDs of the modules that were created, updated or deleted.

#### SLNet.txt log file will no longer contain any logging from MessageBroker [ID_40061]

<!-- MR 10.5.0 - FR 10.4.9 -->

From now on, by default, the *SLNet.txt* log file will no longer contain any logging from MessageBroker.

#### Factory reset tool will now use an absolute path to locate ResetConfig.txt [ID_40074]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

Up to now, the factory reset tool *SLReset.exe* always used the relative path `.\\` to locate the *C:\\Skyline DataMiner\\Files\\ResetConfig.txt* file, assuming that it would always be executed from the *C:\\Skyline DataMiner\\Files* folder. As a result, when it was executed from another folder (e.g. from a terminal window opened on the Windows desktop), it would not be able to find the *ResetConfig.txt* file.

From now on, *SLReset.exe* will always use the absolute path *C:\\Skyline DataMiner\\Files\\ResetConfig.txt* when locating *ResetConfig.txt*.

### Fixes

#### Problem with SLElement while processing table parameter updates [ID_39462]

<!-- MR 10.4.0 [CU6] - FR 10.4.9 -->

In some cases, SLElement could stop working while processing table parameter updates.

#### Alarms generated for an element with a virtual function would incorrectly get exported to that virtual function [ID_39536]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When alarms were generated for an element with a virtual function, those alarms would incorrectly get exported to the virtual function, even though the export option was set to true in the element protocol.

#### Run-time error could occur in SLProtocol when a large SNMP table was being polled [ID_39756]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

Up to now, when an SNMP table took a long time to be polled, a run-time error could occur in SLProtocol.

To avoid such run-time errors, from now on, when SLSNMPManager is polling an SNMP table, it will send a notification to SLProtocol every minute to indicate that SNMP data is being polled.

#### Problem due to the protobuf-net framework in SLNetTypes being initialized on multiple threads [ID_39807]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

On heavily loaded systems, in some cases, the protobuf-net framework in SLNetTypes would simultaneously be initialized on multiple threads, causing the following exception to be thrown:

`Timeout while inspecting metadata; this may indicate a deadlock. This can often be avoided by preparing necessary serializers during application initialization, rather than allowing multiple threads to perform the initial metadata inspection; please also see the LockContended event`

#### Service & Resource Management: Problem when deleting a discrete value of a profile parameter [ID_39867]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When two capability parameters shared the same discrete value, and the value of one of those parameters was included in a resource, up to now, it would not be possible to delete that value for the parameter that was not used.

#### No longer possible to edit a service that had been migrated from one DMA to another within a DMS [ID_39893]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When a service had been migrated from one DataMiner Agent to another within a DataMiner System, it would no longer be possible to edit that service. The messages would incorrectly be sent to the DataMiner Agent that hosted the service previously.

#### Failover: Problem when connecting to an offline agent with a DataMiner Cube that used external authentication [ID_39925]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When you connected to an offline agent in a Failover setup with a DataMiner Cube that used external authentication, an `External authentication failed` error would appear. As a result, it would not be possible to force that offline agent to go online.

#### SLAnalytics: Issues fixed with regard to alarm template monitoring mechanism [ID_39948]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

A number of issues have been fixed with regard to the internal SLAnalytics alarm template monitoring mechanism.

#### SLNet - CloudEndpointManager: Problem at startup when NATS and NAS services were not installed [ID_39980]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

At startup, in some cases, the CloudEndpointManager in SLNet could throw an exception when the NATS and NAS services were not installed.

#### Service & Resource Management: Problem when a DMA did not respond during the midnight sync of the Resource Manager [ID_40021]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When a DMA did not respond during the midnight synchronization (e.g. because the Resource Manager had not been initialized on that DMA), up to now, a nullreference exception would be thrown directly after the error had been logged.

#### Sending a GetCCAGatewayGlobalStateRequest would incorrectly require the 'Connect to cloud/DCP' user permission [ID_40051]

<!-- MR 10.5.0 - FR 10.4.9 -->

Up to now, sending a *GetCCAGatewayGlobalStateRequest* to check whether the DataMiner System is connected to dataminer.services would incorrectly require the *Modules > System configuration > Cloud sharing/gateway > Connect to cloud/DCP* user permission.

As a result, in DataMiner Cube, users without the above-mentioned user permission would not be able to see any relations after clicking the light bulb icon in the top-right corner of a trend graph.

From now on, the *Connect to cloud/DCP* user permission is no longer required to be able to send a *GetCCAGatewayGlobalStateRequest*.

#### MessageBroker: Reconnection mechanism could cause the overall CPU load to rise [ID_40071]

<!-- MR 10.5.0 - FR 10.4.9 -->

Whenever the MessageBroker client loses its connection to the NATS server, it will try to reconnect. Due to an internal issue, up to now, this reconnection mechanism could cause the overall CPU load to rise. This issue has now been fixed.

#### Automation scripts could fail due to zero or negative sleep intervals being passed to Engine.Sleep [ID_40084]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

Up to now, an Automation script could fail because a zero or negative sleep interval was passed to the `Engine.Sleep` method. From now on, any zero or negative sleep interval will be ignored.

#### Service & Resource Management: Booking events could be triggered multiple times when a database issue occurred while DataMiner was starting up [ID_40114]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When a database issue occurred while DataMiner was starting up, in some cases, booking events could be triggered multiple times.

#### SLAnalytics - Behavioral anomaly detection: Change points would incorrectly be generated after an SLAnalytics process restart [ID_40156]

<!-- MR 10.4.0 [CU6] - FR 10.4.9 -->

In some cases, new change points would incorrectly be generated shortly after the SLAnalytics process had been restarted, even though no changes in trend behavior had been detected.
