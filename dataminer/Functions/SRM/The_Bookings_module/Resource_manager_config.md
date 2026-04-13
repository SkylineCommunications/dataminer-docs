---
uid: Resource_manager_config
---

# Resource Manager configuration

The Resource Manager configuration allows the configuration of caching and other runtime settings that affect SRM bookings.

This configuration is stored in `C:\Skyline DataMiner\ResourceManager\Config.xml`.

System administrators can modify this file to fine-tune performance or adapt Resource Manager behavior.

## Example configuration

```xml
<?xml version="1.0" encoding="utf-8"?>
<ResourceManagerConfig benchmark="false">
    <CacheConfiguration>
        <IdCacheConfiguration>
            <MaxObjectsInCache>10000</MaxObjectsInCache>
            <ObjectLifeSpan>PT10M</ObjectLifeSpan>
        </IdCacheConfiguration>
        <TimeRangeCacheConfiguration>
            <MaxObjectsInCache>50000</MaxObjectsInCache>
            <TimeRangeLifeSpan>PT10M</TimeRangeLifeSpan>
            <CleanupCheckInterval>PT1M</CleanupCheckInterval>
        </TimeRangeCacheConfiguration>
        <HostedReservationInstanceCacheConfiguration>
            <InitialLoadDays>P1D</InitialLoadDays>
            <CheckInterval>PT6H</CheckInterval>
        </HostedReservationInstanceCacheConfiguration>
    </CacheConfiguration>
    <SkipServiceHandling>true</SkipServiceHandling>
    <IsMasterEligible>true</IsMasterEligible>
    <ShowScriptStartEventInfo>false</ShowScriptStartEventInfo>
    <AllowNotActiveElements>false</AllowNotActiveElements>
    <ResourceManagerAutomationSettings>
        <ThreadSettings>
            <MaxAmountOfThreads>6</MaxAmountOfThreads>
            <MaxAmountOfParallelTasks>7</MaxAmountOfParallelTasks>
        </ThreadSettings>
    </ResourceManagerAutomationSettings>
</ResourceManagerConfig>
```

## Retrieving or updating the configuration via API

The Resource Manager configuration can be retrieved and updated via API using the message `ResourceManagerConfigInfoMessage`.

To retrieve the current configuration, send a `ResourceManagerConfigInfoMessage` of type `Get`:

```csharp
var request = new ResourceManagerConfigInfoMessage(ResourceManagerConfigInfoMessage.ConfigInfoType.Get); 
var response = engine.SendSLNetSingleResponseMessage(request) as ResourceManagerConfigInfoResponseMessage;
```

To update the configuration, send a `ResourceManagerConfigInfoMessage` of type `Set`, with the updated configuration:

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
        CheckInterval = TimeSpan.FromHours(6),
        InitialLoadDays = TimeSpan.FromDays(1)
    }
};
var response = engine.SendSLNetSingleResponseMessage(request) as ResourceManagerConfigInfoResponseMessage;
```

> [!NOTE]
>
> - When the configuration is updated via API, the new configuration will be applied immediately, except for **ResourceManagerAutomationSettings**. Those settings are only updated when Resource Manager or DataMiner restarts, as internal thread settings need to be set up for this.
> - When the configuration is updated via API, only the fields that are included in the request will be updated. The other fields will keep their current value. For example, if the request only includes the `IdCacheConfiguration`, only this setting will be updated, and the other settings will stay as they are.
> - Only the **AllowNotActiveElements** setting is synced across the cluster. All other settings are applied on the Agent where the API request is sent.

## Configuration settings

### CacheConfiguration

The `CacheConfiguration` element determines the configuration of Resource Manager's different caches.

#### IdCacheConfiguration

The ID cache will store bookings by ID, to allow quick retrieval of bookings when their ID is known.

| Setting | Description | Default value |
|--|--|--|
| MaxObjectsInCache | The maximum number of objects that will be kept in this cache. When this threshold is exceeded, the oldest objects will be removed. | 10000 |
| ObjectLifeSpan | The maximum period of time an entry will be kept in the cache. Each time the entry is hit, this timer is reset. Formatted according to ISO 8601. | PT10M<br>(10 minutes) |

#### TimeRangeCacheConfiguration

When bookings within a specific time range are requested, all instances in that time range are cached in the time range cache. This is used when new bookings are created or when eligible resources are requested.

| Setting | Description | Default value |
|--|--|--|
| MaxObjectsInCache | The maximum number of objects that will be kept in this cache. When this threshold is exceeded, the oldest time ranges will be removed. | 50000 |
| TimeRangeLifeSpan | The maximum period of time a time range will be kept in the cache. Each time a query hitting this time range is resolved, this timer is reset. Formatted according to ISO 8601. | PT10M<br>(10 minutes) |
| CleanupCheckInterval | The interval at which the time ranges to be removed are checked. Formatted according to ISO 8601. | PT1M<br>(1 minute) |

#### HostedReservationInstanceCacheConfiguration

When Resource Manager starts, the hosted reservation instance cache loads the bookings that are hosted on the Agent and schedules the start/stop actions and booking events. Any new instances hosted on the Agent that are added or updated while Resource Manager is running will also be added to this cache.

| Setting | Description | Default value |
|--|--|--|
| InitialLoadDays | How far into the future reservation instances (i.e., booking instances) will be loaded at Resource Manager startup. Formatted according to ISO 8601. | P1D<br>(1 day) |
| CheckInterval | The interval after which the Resource Manager will load new bookings from the database. | PT6H<br>(6 hours) |

> [!NOTE]
> `GetReservationInstances` calls from scripts or clients will go straight to the database. They will not use the caching mechanism.

### SkipServiceHandling

When `SkipServiceHandling` is set to `true`, service handling for SRM bookings is skipped, so **SRMServiceInfo** objects will not be checked. This improves performance and prevents the creation of unnecessary services.

Default value: `false`.

> [!NOTE]
>
> - Available from DataMiner 10.4.9/10.5.0 onwards<!-- RN 39939 -->.
> - From SRM 2.0.2 onwards<!-- RN 40666 -->, this option is automatically enabled during the startup of the Booking Manager element, as SRM will manage the booking services.

### IsMasterEligible

When `IsMasterEligible` is set to `false`, the DataMiner Agent will not be eligible to be promoted to Resource Manager master. If the current master Agent is marked as not eligible, the other Agents in the DMS will elect a new master from the pool of eligible Agents.

Default value: `true`.

> [!NOTE]
>
> - Available from DataMiner 10.4.11/10.5.0 onwards<!-- RN 40712 -->.
> - If the current master Agent is marked as not eligible, it will continue to process all ongoing and queued requests. However, all new requests will be forwarded to the new master Agent. It is currently only possible to switch master Agents when there are no ongoing master-synced requests.

### ShowScriptStartEventInfo

When `ShowScriptStartEventInfo` is set to `true`, information events will be generated when booking event scripts are executed (OnStartingEvent, OnStartedEvent, OnStoppingEvent, OnStoppedEvent, TimeoutScript, OnStartActionsFailureEvent, Events (custom script)). These information events have the description "Script started" and their value contains the name of the script.

Default value: `false`.

> [!NOTE]
> Available from DataMiner 10.4.12/10.5.0 onwards<!-- RN 40972 -->. In earlier versions, these information events are always generated.

### AllowNotActiveElements

When `AllowNotActiveElements` is set to `true`, it is possible to start bookings with elements that are not active.

Default value: `false`.

> [!NOTE]
>
> - Available from DataMiner 10.5.0/10.5.1 onwards<!-- RN 41129 -->.
> - This setting is **synced** across the cluster, so all Agents will have the same value for this setting, as bookings should behave in the same way regardless of which Agent processes the start request.

> [!IMPORTANT]
> Use this option with caution, as it can cause elements used in a booking to be configured incorrectly.

### ResourceManagerAutomationSettings

These settings configure the threading behavior used when multiple bookings are started in parallel.

| Setting | Description | Default value |
|--|--|--|
| MaxAmountOfThreads | The number of threads Resource Manager will use to start bookings. The minimum value is 2, so the scheduler can start an action and keep a thread available for asynchronous continuations. Set to `nil` to use the default value. | 6 |
| MaxAmountOfParallelTasks | The number of parallel actions Resource Manager will start on the threads. Set to `nil` to use the default value. | 7 |

In most cases, these settings can keep their default value, unless performance has to be optimized when multiple concurrent bookings have to be started. To increase performance, the number of threads and parallel tasks can be increased, provided the DataMiner Agent and the database can handle the increased load.

> [!NOTE]
>
> - Available from DataMiner 10.6.1/10.7.0 onwards<!-- RN 44056 -->.
> - Requires a restart of Resource Manager or DataMiner to apply the new settings, as these settings are used to set up Resource Manager's internal thread pool.
