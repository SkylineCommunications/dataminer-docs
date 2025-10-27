---
uid: General_Feature_Release_10.5.3
---

# General Feature Release 10.5.3

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!IMPORTANT]
>
> Before you upgrade to this DataMiner version, make sure **version 14.40.33816** or higher of the **Microsoft Visual C++ x86/x64 redistributables** is installed. Otherwise, the upgrade will trigger an **automatic reboot** of the DMA in order to complete the installation.
>
> The latest version of the redistributables can be downloaded from the [Microsoft website](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version):
>
> - [vc_redist.x86.exe](https://aka.ms/vs/17/release/vc_redist.x86.exe)
> - [vc_redist.x64.exe](https://aka.ms/vs/17/release/vc_redist.x64.exe)

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.3](xref:Cube_Feature_Release_10.5.3).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.3](xref:Web_apps_Feature_Release_10.5.3).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

- [Service & Resource Management: Defining an availability window for a resource [ID 41894]](#service--resource-management-defining-an-availability-window-for-a-resource-id-41894)
- [Relational anomaly detection [ID 42034]](#relational-anomaly-detection-id-42034)

## New features

#### DataMiner Object Models: Configuring trigger conditions for CRUD scripts [ID 41780]

<!-- MR 10.6.0 - FR 10.5.3 -->

From now on, conditions can be used to prevent the update script from being triggered for each and every `DomInstance` update. This allows you to make a solution more efficient as no unnecessary script triggers are executed. These conditions can be configured by instantiating one of the supported condition classes and adding it to the `OnUpdateTriggerConditions` collection property on the `ExecuteScriptOnDomInstanceActionSettings`.

The conditions are evaluated using a logical 'OR', meaning that only one condition needs to be true for the script to trigger.

> [!IMPORTANT]
> When you configure conditions, the update script will no longer be triggered when a status transition is done. A status-related condition to define a trigger based on a specific status is currently not available.

##### FieldValueUpdatedTriggerCondition

This condition type allows you to check whether a `FieldValue` for a given `FieldDescriptor` has been added, updated, or removed. It also supports multiple sections, meaning the condition will be met if:

- A **new** `FieldValue` is added in a new or existing `Section`.
- An **existing** `FieldValue` is deleted from a deleted or existing `Section`.

To use this condition, define the ID of the `FieldDescriptor` by passing it to the condition's constructor.

Example:

```csharp
var licensePlate = new FieldDescriptorID(Guid.Parse("81915fe0-8f55-4ad1-8da5-3b703f9e7842"));
var insuranceId = new FieldDescriptorID(Guid.Parse("7cd4366c-983c-46d2-aa92-e0308a3102e5"));

moduleSettings.DomManagerSettings.ScriptSettings.OnUpdateTriggerConditions = new List<IDomCrudScriptTriggerCondition>
{
   new FieldValueUpdatedTriggerCondition(licensePlate),
   new FieldValueUpdatedTriggerCondition(insuranceId)
};
```

#### Service & Resource Management: Defining an availability window for a resource [ID 41894]

<!-- MR 10.6.0 - FR 10.5.3 -->

For each resource, you can now define an availability window, i.e. a period during which the resource is available.

An availability window has the following (optional) properties:

| Property | Description |
|----------|-------------|
| AvailableFrom  | The start time of the availability window. Default value: `DateTimeOffset.MinValue` (i.e. no start time). |
| AvailableUntil | The end time of the availability window. Default value: `DateTimeOffset.MaxValue` (i.e. no end time). |
| RollingWindowConfiguration | The size of the availability window relative to the current time.<br>For example, if you set this property to 30 days, the resource will be available for booking until 30 days from now.<br>If both a fixed end time and a rolling window are set, the earlier time of the two will be used. For example, if the fixed end time is 15 days from now, but the rolling window is 30 days, the resource will no longer be available after the 15-day mark, even though the rolling window would extend to 30 days. |

When you use the *GetEligibleResources* API call to retrieve resources available during a specific time range, resources that are not available for the entire requested range will not be returned.

Example showing how to configure the above-mentioned properties:

```csharp
var resource = _rmHelper.GetResource(...);
resource.AvailabilityWindow = new BasicAvailabilityWindow()
{
    AvailableFrom = DateTimeOffset.Now.AddHours(1),
    AvailableUntil = DateTimeOffset.Now.AddDays(30),
    // RollingWindow can be left as 'null' if no rolling window needs to be configured
    RollingWindowConfiguration = new RollingWindowConfiguration(TimeSpan.FromHours(5))
};
resource = _rmHelper.AddOrUpdateResources(resource)?.FirstOrDefault();
var td = _rmHelper.GetTraceDataLastCall();
if (!td.HasSucceeded())
{
    // Handle the error
}
```

Setting `AvailableFrom` to a date after `AvailableUntil`, or `AvailableUntil` to a date before `AvailableFrom` will throw an `ArgumentOutOfRangeException`. Also, passing a zero or negative `TimeSpan` to the `RollingWindowConfiguration` will throw an `ArgumentOutOfRangeException`.

Adding an availability window to an existing resource, or adding a resource to a booking that runs outside the availability window of the resource will trigger quarantine. The following errors will be returned when quarantine is triggered:

- When you add an availability window to a resource, an error of type `ResourceManagerError` with reason `ResourceUpdateCausedReservationsToGoToQuarantine` will be returned. The quarantine reason in the trigger will be `ResourceAvailabilityWindowChanged`.

- When you try to book a resource that is not available in the requested time range, an error of type `ResourceManagerError` with reason `ReservationUpdateCausedReservationsToGoToQuarantine` will be returned. The quarantine reason in the trigger will be `ReservationInstanceUpdated`. The `ReservationConflictType` will be `OutsideResourceAvailabilityWindow`.

The availability window provides a method to retrieve the time ranges in which the resource is available:

```csharp
AvailabilityResult result = resource.AvailabilityWindow.GetAvailability(new AvailabilityContext());
List<ResourceWindowTimeRange> availableRanges = result.AvailableTimeRanges;
foreach (var range in availableRanges)
{
    DateTimeOffset start = range.Start;
    DateTimeOffset end = range.Stop;
    
    // A corresponding details property 'StopDetails' exists for the stop;
    TimeRangeBoundaryDetails startDetails = range.StartDetails;

    // Indicates if this boundary was defined by a fixed point (start/stop) or by a rolling window
    BoundaryDefinition startDefinition = startDetails.BoundaryDefinition;
    if (startDefinition == BoundaryDefinition.RollingWindow)
    {
        // ...
    }
}
```

The `AvailabilityContext` parameter has a property `Now`, which can be used to override the "now" timestamp in order to calculate e.g. the current end of a rolling window. For regular use cases, there is no need to override this. This is mainly used for testing purposes and to ensure a consistent timestamp when performing internal checks.

#### Relational anomaly detection [ID 42034]

<!-- MR 10.6.0 - FR 10.5.3 -->

Relational anomaly detection (RAD) will detect when a group of parameters deviates from its normal behavior. A user can configure one or more groups of parameter instances that should be monitored together, and RAD will then learn how the parameter instances in these groups are related. Whenever the relation is broken, RAD will detect this and generate suggestion events. A suggestion event will be generated for each parameter instance in the group where a broken relation was detected.

##### Configuration file

Per DataMiner Agent, the above-mentioned parameter groups must be configured in the `C:\Skyline DataMiner\Analytics\RelationalAnomalyDetection.xml` file. This file will be read when SLAnalytics starts up, when RAD is enabled or re-enabled, or when a *ReloadMadConfigurationMessage* is sent.

The configuration file must be formatted as follows.

```xml
<?xml version="1.0" ?>
<RelationalAnomalyDetection>
  <Group name="[GROUP_NAME]" updateModel="[true/false]" anomalyScore="[THRESHOLD]">
    <Instance>[INSTANCE1]</Instance>
    <Instance>[INSTANCE2]</Instance>
    [... one <Instance> tag per parameter in the group]
  </Group>
  [... one <Group> tag per group of parameters that should be monitored by RAD]
</RelationalAnomalyDetection>
```

**Group arguments**

| Argument | Description |
|---|---|
| `name`         | The name of the parameter group.<br>This name must be unique, and will be used when a suggestion event is generated for the group in question. |
| `updateModel`  | Indicates whether RAD should update its internal model of the relation between the parameters in the group.<br>- If set to "false", RAD will only do an initial training based on the data available at startup.<br>- If set to "true", RAD will update the model each time new data comes in. |
| `anomalyScore` | Optional argument that can be used to specify the suggestion event generation threshold.<br>By default, this value will be set to 3. Higher values will result in less suggestion events, lower values will result in more suggestion events. |

**Parameter instance formats**

In each `Instance`, you can specify either a single-value parameter or a table parameter by using one of the following formats:

- Single-value parameter: [DataMinerID]/[ElementID]/[ParameterID]
- Table parameter: [DataMinerID]/[ElementID]/[ParameterID]/[PrimaryKey]

##### Average trending

RAD requires parameter instances to have at least one week of five-minute average trend data. If at least one parameter instance has less than a week of trend data available, monitoring will only start after this one week becomes available. In particular, this means that average trending has to be enabled for each parameter instance used in a RAD group and that the TTL for five-minute average trend data has to be set to more than one week (recommended setting: 1 month). Also, RAD only works for numeric parameters.

If necessary, users can force RAD to retrain its internal model by sending a `RetrainMadModelMessage`. In this message, they can indicate the periods during which the parameters were behaving as expected. This will help RAD to identify when the parameters deviate from that expected behavior in the future.

##### Limitations

- RAD is only able to monitor parameters on the local DataMiner Agent. This means that all parameter instances configured in the *RelationalAnomalyDetection.xml* configuration file on a given DMA must be hosted on that same DMA. Currently, RAD is not able to simultaneously monitor parameters hosted on different DMAs.

- RAD does not support history sets.

- Some parameter behavior will cause RAD to work less accurately. For example, if a parameter only reacts on another parameter after a certain time, then RAD will produce less accurate results.

## Changes

### Enhancements

#### Change Element States Offline tool: Service elements will now be hidden by default [ID 41341]

<!-- MR 10.5.0 - FR 10.5.3 -->

From now on, the *Change Element States Offline* tool will hide service elements by default. This will prevent users from mistakenly stopping those elements.

If you do want service elements to be visible, select the *Advanced* checkbox.

#### Protocols: New 'overrideTimeoutVF' option to override the timeout for a virtual function [ID 41388]

<!-- MR 10.6.0 - FR 10.5.3 -->

Up to now, when the `overrideTimeoutDVE` option was enabled in a *protocol.xml* file, the timeout would apply to DVE elements as well as virtual functions. From now on, this option will only apply to DVE elements.

In order to override the timeout for a virtual function, you will now be able to specify the new *overrideTimeoutVF* option in a *Functions.xml* file.

#### Swarming: Clearer exception will now be thrown when the state of an element is changed while the element is being swarmed [ID 41634]

<!-- MR 10.6.0 - FR 10.5.3 -->
<!-- Not added to MR 10.6.0 -->

When the state of an element was changed while that element was being swarmed, up to now, a "host unknown" exception would be thrown.

From now on, an *SL_SWARMING_IN_PROGRESS* exception will be thrown instead. This exception will now clearly state that the update cannot be performed because the element is being swarmed.

#### DataMiner Connectivity Framework: Enhanced processing of SRM services by the connectivity manager [ID 41649]

<!-- MR 10.5.0 - FR 10.5.3 -->

Because of a number of enhancements made to the DataMiner Connectivity Framework, overall performance of the connectivity manager has increased when processing SRM services.

#### Enhanced error and exception handling when updating or clearing correlation alarms [ID 41675]

<!-- MR 10.5.0 - FR 10.5.3 -->

Error and exception handling has been enhanced in order to prevent duplicate or sticky correlation alarms due to errors or exceptions thrown when updating or clearing correlation alarms.

#### SLNet: Enhancements to prevent SLNet modules from forwarding requests back and forth between two DMAs [ID 41827]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

A number of enhancements have been made to prevent SLNet modules from forwarding requests back and forth between two DataMiner Agents.

#### SLAnalytics: New check to verify if the incident tracking leader is still a member of the current DMS [ID 41836]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

At DataMiner startup, from now on, SLAnalytics will check whether the DataMiner Agent configured as leader\* is still a member of a current DataMiner System.

Also, from now on, a new leader will be elected when the former leader has left the cluster.

*\* In DataMiner Cube, the leader can be configured in the *Leader DataMiner ID* box, which can be found in *System Center > System settings > Analytics config > Automatic incident tracking*.*

#### Service & Resource Management: Enhanced performance when processing history entries for booking instances and resources [ID 41842]

<!-- MR 10.6.0 - FR 10.5.3 -->

Up to now, history entries for booking instances and resources would be processed individually. From now on, they will be processed in batches of 100 entries. This will considerably enhance overall performance when processing these history entries.

#### Smart baselines will now also get capped when the parameter only has either a low value or a high value [ID 41870]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

When DataMiner calculates a smart baseline value that lies outside the range specified in the protocol for the parameter in question, then the value is capped. However, up to now, this would only happen when the range had both a low value and a high value.

From now on, calculated smart baseline values will also get capped when the parameter in question only has either a low value or a high value.

#### Amazon Keyspaces Service is now end-of-life [ID 41874] [ID 41914]

<!-- MR 10.5.0 [CU0] - FR 10.5.3 -->

Support for Amazon Keyspaces Service is now officially end-of-life.

When you run the DataMiner installer or install a DataMiner upgrade package, the *VerifyNoAmazonKeyspaces* prerequisite will check whether the DataMiner Agent is configured to use a database of type *Amazon Keyspaces*. If so, the upgrade process will not be allowed to continue.

We recommend using [Storage as a Service (STaaS)](xref:STaaS) instead. If you want to use self-hosted storage, install a [Cassandra Cluster](xref:Cassandra_database) database.

For more information, see [Amazon Keyspaces Service](xref:Amazon_Keyspaces_Service)

#### SLLogCollector now collects data regarding the GQI DxM [ID 41880]

<!-- MR 10.5.0 - FR 10.5.3 -->

SLLogCollector packages now include the following data regarding the GQI DxM:

- *appsettings.json*
- Log file
- Version

#### SLLogCollector packages now also contain the ClusterEndpoints.json file [ID 41887]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

SLLogCollector packages now also include the *ClusterEndpoints.json* file.

#### SLPort: Enhanced performance and reduced memory and CPU usage [ID 41896]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

Because of a number of enhancements, overall performance of SLPort has increased. The process will now also use less memory and CPU.

#### Swarming prerequisites: Entries will now be added to SLNet.txt while checking alarm ID usage in Automation scripts and protocol QActions [ID 41930]

<!-- MR 10.6.0 - FR 10.5.3 -->
<!-- Not added to MR 10.6.0 -->

While checking the Swarming prerequisites, DataMiner checks alarm ID usage in Automation scripts and protocol QActions. As this step can take up to several minutes, log entries will now be added to the *SLNet.txt* log file while alarm ID usage is being checked.

#### Swarming: Elements polling the local IP address no longer blocked from being swarmed [ID 41957]

<!-- MR 10.6.0 - FR 10.5.3 -->
<!-- Not added to MR 10.6.0 -->

Up to now, it was not allowed to swarm elements polling the local IP address of any agent in the DMS and elements polling the loopback address.

From now on, it will be allowed to swarm elements polling the local IP address of any agent in the DMS. However, elements polling the loopback address will remain blocked.

#### SLNet: Enhanced performance when clearing the alarms cache [ID 41998]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

Because of a number of enhancements, overall performance of SLNet has increased when clearing the alarms cache.

#### SLProtocol: Reduced CPU usage when converting data from String to Double [ID 42049]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

Because of a number of enhancements made to SLProtocol, overall CPU usage has been reduced when converting data from String to Double.

#### Swarming: Prerequisite checks will now also check whether obsolete Engine methods are being used [ID 42073]

<!-- MR 10.6.0 - FR 10.5.3 -->
<!-- Not added to MR 10.6.0 -->

[Prerequisite checks](xref:EnableSwarming#running-a-prerequisites-check) are in place to prevent the enabling of the Swarming feature when non-supported objects are present. From now on, these checks will also check whether the following obsolete Engine methods are being used:

- Engine.GetAlarmProperty(int, int, string)
- Engine.SetAlarmProperty(int, int, string, string)
- Engine.SetAlarmProperties(int, int, string[], string[])
- Engine.AcknowledgeAlarm(int, int, string)

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

### Fixes

#### Elements no longer visible after having been swarmed [ID 41635]

<!-- MR 10.5.0 - FR 10.5.3 -->
<!-- Not added to MR 10.5.0 -->

In some rare cases, when an element had been swarmed, it would no longer be visible in client apps like DataMiner Cube.

#### Missing DATAMINER_NOTIFICATION_QUEUE thread [ID 41699]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

When DataMiner was restarted, an issue could occur, causing the DATAMINER_NOTIFICATION_QUEUE thread not to be registered in processes like SLDMS, SLElement or SLDataGateway. These missing threads could then lead to a number of symptoms like empty element data cards or not being able to swarm back elements.

#### Problem with incorrect virtual element states [ID 41705]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

In some rare cases, the element state of a DVE or Virtual Function element would end up incorrect in the SLNet cache, causing some caches to not be initialized correctly.

#### Problem when trying to swarm an element back to its original DataMiner Agent [ID 41709]

<!-- MR 10.6.0 - FR 10.5.3 -->
<!-- Not added to MR 10.6.0 -->

In some cases, it would not be possible to swarm an element back to its original DataMiner Agent due to a caching issue in the SLDataMiner process.

#### Problem with SLDataMiner when a DMS with swarming enabled had a database connection issue at startup [ID 41714]

<!-- MR 10.6.0 - FR 10.5.3 -->
<!-- Not added to MR 10.6.0 -->

When, while starting up, a DataMiner System with swarming enabled experienced a problem with its database connection, the SLDataMiner process would incorrectly shut down.

#### Service & Resource Management: Problem when a previously deleted booking was created again [ID 41718]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

When a previously deleted booking was created again with the same ID, up to now, that booking would incorrectly not be retrieved.

#### Startup routine of a DMA with an offline time-based license would temporarily halt before continuing [ID 41736]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

In some cases, the startup routine of a DataMiner Agent with an offline time-based license would temporarily halt before continuing.

#### GQI: Min and Max aggregation of a datetime column would incorrectly result in a number column [ID 41789]

<!-- MR 10.5.0 - FR 10.5.3 -->

Up to now, when a Min or Max aggregation was performed on a datetime column, the aggregated column would incorrectly be a number column instead of datetime column.

#### Uploading the same version of a DVE connector twice would incorrectly cause the production version of DVE child elements to be changed [ID 41798]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

When the same version of a DVE connector was uploaded twice, the production version of all DVE child elements using another version of that connector as production version would incorrectly have their production version set to the newly uploaded version.

#### Protocols: Problem when deleting an element with a parameter that had a duplicate RawType tag configured [ID 41871]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

When an element was deleted, a runtime error could occur in SLProtocol when a parameter had a duplicate `RawType` tag configured.

#### No longer possible to clear or update an alarm associated with a general information parameter [ID 41877]

<!-- MR 10.5.0 - FR 10.5.3 -->
<!-- Not added to MR 10.5.0 - Introduced by RN 39193 -->

When an alarm had been generated for a general information parameter (i.e. a parameter with an ID within the range 64502 to 64999), it would incorrectly not be possible to clear or update that alarm.

#### SNMP managers would incorrectly receive some or all active alarms at DMA startup [ID 41878]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

When a DataMiner Agent was started, in some cases, the configured SNMP managers would incorrectly receive some or all active alarms.

#### Fixes made with regard to the management of locally-stored element documents [ID 41882]

<!-- MR 10.5.0 - FR 10.5.3 -->

A number of fixes have been made with regard to the management of locally-stored element documents that are not synchronized among the DMAs in a DataMiner System.

#### Problem when swarming elements between two DMAs with a time difference [ID 41910]

<!-- MR 10.6.0 - FR 10.5.3 -->
<!-- Not added to MR 10.6.0 -->

When elements were swarmed between two DataMiner Agents, in some rare cases, a problem could occur when there was a time difference between both agents.

#### Alarms without focus value would not be correctly removed from alarm groups when the associated element was deleted, stopped or paused [ID 41950]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

In some cases, alarm groups containing alarms without a focus value (e.g. notices or errors) would not be correctly removed from the group when the element associated with the alarm was deleted, stopped or paused.

#### Problem with SLDataMiner when creating a dmimport package [ID 41963]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

Up to now, in some cases, SLDataMiner could stop working while creating a dmimport package.

A number of enhancements have now been made with regard to error handling during the creation of dmimport packages. From now on, when an issue occurs while a dmimport package is being created, an error message will be shown in the client (e.g. DataMiner Cube).

#### Problem with SLProtocol when using a condition to check whether a table is empty [ID 41968]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

SLProtocol could stop working when, in a protocol, a condition was used to check whether a table is empty.

#### Errors would be logged in SLErrors.txt and SLNet.txt when Mobile Gateway was enabled in a DMS with more than one agent [ID 41988]

<!-- MR 10.5.0 - FR 10.5.3 -->

Up to now, errors would be logged in the *SLErrors.txt* and *SLNet.txt* log files when Mobile Gateway was enabled in a DataMiner System with more than one DMA.

Also, the Mobile Gateway process would only be aware of elements that were hosted on the same agent as the one on which it was hosted itself. As a result, actions like GET and SET on other elements via the Mobile Gateway would fail.

#### Problem when updating the GQI DxM [ID 41990]

<!-- MR 10.5.0 - FR 10.5.3 -->

When you tried to update the GQI DxM by means of the MSI installer, in some cases, the update would either not entirely succeed or even fail.

A number of enhancements have now been made to prevent any problems from occurring while updating the GQI DxM.

#### SLA window change records would not properly be removed from the database [ID 41995]

<!-- MR 10.5.0 [CU0] - FR 10.5.3 [CU0] -->
<!-- Not added to MR 10.5.0 -->

Since DataMiner feature version 10.4.12, SLA window change records would not properly be removed from the database.

Also, attempts to clean up those records would potentially lead to thread problems in SLProtocol.

#### Swarming: Problems with information events [ID 41999]

<!-- MR 10.6.0 - FR 10.5.3 -->
<!-- Not added to MR 10.6.0 -->

When an element was being swarmed, in some cases, the final information event that was generated would have an incorrect alarm ID.

Also, in some rare cases, the *Activated By* information event could have a duplicate alarm tree key.

#### BPA tests would fail to load the necessary DLL files [ID 42000]

<!-- MR 10.4.0 [CU12] - FR 10.5.3 -->

In some cases, BPAs tests would fail to load the necessary DLL files.

#### Swarming: Not all data would be flushed when the element was unloaded [ID 42077]

<!-- MR 10.6.0 - FR 10.5.3 -->
<!-- Not added to MR 10.6.0 -->

When an element was being swarmed, not all data would be flushed when the element was unloaded.

#### No more logging would be added to SLWatchDog2.txt after a DataMiner upgrade [ID 42180]

<!-- MR 10.4.0 [CU12] / 10.5.0 [CU0] - FR 10.5.3 [CU0] -->

After a DataMiner upgrade, in some cases, no new entries would be added to the *SLWatchDog2.txt* log file anymore.

#### SLSNMPManager process could stop working when an SNMPv3 element was stopped [ID 42195]

<!-- MR 10.5.0 [CU0] - FR 10.5.3 [CU0] -->

When an SNMPv3 element was stopped, in some rare cases, the SLSNMPManager process could stop working.
