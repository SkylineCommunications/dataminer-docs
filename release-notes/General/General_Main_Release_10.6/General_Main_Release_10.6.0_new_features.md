---
uid: General_Main_Release_10.6.0_new_features
---

# General Main Release 10.6.0 – New features - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## Highlights

- [Swarming [ID 37381] [ID 37437] [ID 37486] [ID 37925] [ID 38019] [ID 39303] [ID 40704] [ID 40939] [ID 41258] [ID 41490]](#swarming-id-37381-id-37437-id-37486-id-37925-id-38019-id-39303-id-40704-id-40939-id-41258-id-41490)

## New features

#### Swarming [ID 37381] [ID 37437] [ID 37486] [ID 37925] [ID 38019] [ID 39303] [ID 40704] [ID 40939] [ID 41258] [ID 41490]

<!-- MR 10.6.0 - FR 10.5.1 -->

From now on, you can enable the Swarming feature in a DataMiner System in order to be able to swarm [elements](xref:SwarmingElements) from one DataMiner Agent to another Agent in the same cluster. Prior to this, this feature is available in preview if the *Swarming* [soft-launch option](xref:SoftLaunchOptions) is enabled.

The primary goal of Swarming is to eliminate downtime resulting from maintenance activities and provide a more polished user experience.

Note that when Swarming is enabled, this will result in some major changes to the DataMiner configuration:

- Alarm identifiers will be generated on a per-element basis instead of per Agent to make them unique within the cluster. Because of this change, you will need to make sure [your system is prepared](xref:SwarmingPrepare) before you can enable Swarming.

- Element configuration will be stored in the cluster-wide database instead of in the element XML files on the disk of the DataMiner Agent hosting each element.

> [!IMPORTANT]
>
> - Swarming cannot be enabled on DataMiner Main Release 10.5.
> - Once the element configuration has been moved from disk to database, there is no good way to revert this change, which means that if you were to disable Swarming again, you would lose all your elements, leaving your DMS with a lot of lingering references to non-existing elements. For instructions on how to disable Swarming and **partially** recover your elements, see [Partially rolling back Swarming](xref:SwarmingRollback).

##### Capabilities

Currently, the Swarming feature provides the following capabilities:

- As a DataMiner System Admin, you can apply maintenance (e.g. Windows updates) on a live cluster, Agent by Agent, by temporarily moving functionalities away to other Agents in the cluster.

- As a DataMiner System Admin, you can easily extend your system with an extra node and move functionalities from existing nodes to new nodes, so you can rebalance your cluster (i.e. spread the load across all nodes).

- Swarming makes it possible to recover functionalities from failing nodes by moving activities hosted on such a node to the remaining nodes.

In a later iteration, the Swarming feature will also be able to assist in making rolling DataMiner software updates on live clusters possible, with limited downtime of specific functionality.

> [!NOTE]
> The above capabilities are possible with limited downtime and as long as there is spare capacity.

##### Limitations

Swarming is not available in the following DataMiner Systems:

- DataMiner Systems with a [storage per DMA setup](xref:Configuring_storage_per_DMA) (Cassandra or MySQL).

- DataMiner Systems with [Failover](xref:About_DMA_Failover).

- DataMiner Systems where the [*LegacyReportsAndDashboards* soft-launch option](xref:Overview_of_Soft_Launch_Options#legacyreportsanddashboards) is enabled.

> [!NOTE]
>
> - Currently, Swarming is limited to [basic elements](xref:SwarmingElements). Support for other types of elements will be added in future versions.
> - [Prerequisite checks](xref:EnableSwarming#running-a-prerequisites-check) are in place to prevent the enabling of the Swarming feature when non-supported objects are present. Where possible, you will also be prevented from configuring or creating these on a Swarming-enabled system.

##### Required user permissions

To enable the Swarming feature, the [Admin Tools](xref:DataMiner_user_permissions#modules--system-configuration--tools--admin-tools) user permission is required.

Once the feature has been enabled, users will need the [Swarming](xref:DataMiner_user_permissions#modules--swarming) user permission to trigger any swarming actions. Users who previously had the [Import DELT](xref:DataMiner_user_permissions#general--elements--import-delt) and [Export DELT](xref:DataMiner_user_permissions#general--elements--import-delt) user permissions before Swarming was enabled will automatically also get the *Swarming* user permission when upgrading from a version without the *Swarming* permission to a version with the *Swarming* permission.

To swarm an element, users will also need config rights on the element.

##### Swarming elements

When Swarming has been enabled, you can swarm elements **in DataMiner Cube** via *System Center* > *Agents* > *Status*. On that page, the *Swarming* button will be displayed instead of the *Migration* button. Clicking the button will open a window where you can select the elements you want to swarm and the destination DMA.

Swarming elements is also possible **via Automation, QActions or other (external) tools**. See the following Automation script example, in which two input parameters are defined to retrieve the element key and the target agent ID:

- a parameter named "Element Key", containing the DMA ID/element ID pair of the element you want to swarm, and
- a parameter named "Target Agent ID", containing the ID of the target Agent.

```csharp
using System;
using System.Linq;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net;
using Skyline.DataMiner.Net.Swarming.Helper;

public class Script
{
  public void Run(Engine engine)
  {
    var element = ElementID.FromString(engine.GetScriptParam("Element Key").Value);
    int targetAgentId = Int32.Parse(engine.GetScriptParam("Target Agent ID").Value);
    
    var swarmingResults = SwarmingHelper.Create(Engine.SLNetRaw)
        .SwarmElement(element)
        .ToAgent(targetAgentId);

    var swarmingResultForElement = swarmingResults.First();  

    if (!swarmingResultForElement.Success)
    {
      engine.ExitFail($"Swarming failed: {swarmingResultForElement?.Message}");
    }
  }
}
```

#### Retrieving additional logging from a DataMiner System [ID 40766]

<!-- MR 10.6.0 - FR 10.5.1 -->

From now on, the `GetAdditionalLoggingMessage` can be used to retrieve additional logging from a DataMiner System. It will return a `GetAdditionalLoggingResponseMessage` with the following information:

- *Log Name*: The name of the log.
- *Log Type*: The type of the log. Currently, only the log type "DxM" is supported.

Example:

```csharp
// Send a request to collect additional logging info 
var additionalLoggingMessage = new GetAdditionalLoggingMessage();
var response = engine.SendSLNetMessages(additionalLoggingMessage);
var loggingInfo = response.AdditionalLoggingInfo;
foreach (var logEntry in loggingInfo)
{
    engine.GenerateInformationEvent($"Log Name: {logEntry.Name}, Log Type: {logEntry.Type}");
}
```

Also, the existing messages `GetLogTextFileStringContentRequestMessage` and `GetLogTextFileBinaryContentRequestMessage` now have two new properties that will allow them to retrieve additional logging:

- *AdditionalLogName*: The name of the additional log to be retrieved.
- *LogType*: The type of the log. Example: `LogFileType.DxM`

Example:

```csharp
// Create a request to retrieve a specific additional log in a string format
var logRequest = new GetLogTextFileStringContentRequestMessage
{ 
    AdditionalLogName = "DataMiner UserDefinableApiEndpoint", 
    LogType = LogFileType.DxM
};
```

> [!NOTE]
> These are SLNet messages that are subject to change without notice.

#### SLNet 'GetInfo' messages for the PropertyConfiguration' and 'ViewInfo' types now support retrieving information for a specific item [ID 41169]

<!-- MR 10.6.0 - FR 10.5.1 -->

SLNet `GetInfo` messages for the `PropertyConfiguration` and `ViewInfo` types now support retrieving information for a specific item. This will enhance the performance of the `Skyline.DataMiner.Core.DataMinerSystem.Common` NuGet package used in protocols or Automation scripts.

##### Type PropertyConfiguration

In the `ExtraData` property you can now specify ";type=\<propertyType\>" or ";type=\<propertyType\>;", where \<propertyType\> is either ELEMENT, SERVICE or VIEW.

If another value is specified, then all property configurations will be returned.

##### Type ViewInfo

In the `ExtraData` property you can now specify ";viewId=\<ID\>" or ";viewId=\<ID\>;", where \<ID\> is the ID of the view for which you want to retrieve more information.

> [!NOTE]
> These are SLNet messages that are subject to change without notice.

#### New SLNet call GetProtocolQActionsStateRequestMessage to retrieve QAction compilation warnings and errors [ID 41218]

<!-- MR 10.6.0 - FR 10.5.1 -->

A new SLNet call `GetProtocolQActionsStateRequestMessage` can now be used to retrieve the compilation warnings and errors of a given protocol and version. The response, `GetProtocolQActionsStateResponseMessage`, will then contains all faulty QActions and their respective warnings and errors.

In future versions, this call will be used to verify whether DataMiner Swarming can be enabled on a DataMiner System.

> [!NOTE]
> This SLNet message is subject to change without notice.

#### Alarms - Proactive cap detection: User feedback [ID 41371]

<!-- MR 10.6.0 - FR 10.5.1 -->

From now on, users will be allowed to give feedback (positive or negative) on alarms and suggestion events generated by the proactive cap detection feature.

- Positive feedback will make the detection process more forgiving, and future alarms and suggestion events will more likely be generated again when the trend prediction for the parameter in question directs towards the critical value or the values configured in the alarm template.

- Negative feedback will decrease the chance of a similar alarm or suggestion event being re-generated upon a future occurrence of (a) the instance that received the feedback and (b) other instances related to the same parameter. For example, if you give negative feedback on suggestion events of type "Predicted minimum value...", less suggestion events of that type will get generated for some time in the future.

> [!NOTE]
>
> - For this user feedback feature to work, the DataMiner System has to include an indexing database.
> - For more information on how to provide feedback on alarms and suggestion events generated by the proactive cap detection feature in DataMiner Cube, see [Alarm Console - Proactive cap detection: User feedback [ID 41451]](xref:Cube_Feature_Release_10.5.1#alarm-console---proactive-cap-detection-user-feedback-id-41451).

#### Web visual overviews: Load balancing [ID 41434] [ID 41728]

<!-- MR 10.5.0 [CU1]/10.6.0 [CU0] - FR 10.5.2 -->

It is now possible to implement load balancing among DataMiner Agents in a DMS for visual overviews shown in web apps.

Up to now, the DataMiner Agent to which you were connected would handle all requests and updates with regard to web visual overviews.

##### Configuration

In the *C:\\Skyline DataMiner\\Webpages\\API\\Web.config* file of a particular DataMiner Agent, add the following keys in the `<appSettings>` section:

- `<add key="visualOverviewLoadBalancer" value="true" />`

  Enables or disables load balancing on the DataMiner Agent in question.

  - When this key is set to **true**, for the DataMiner Agent in question, all requests and updates with regard to web visual overviews will by default be handled in a balanced manner by all the DataMiner Agents in the cluster.

    However, if you also add the `dmasForLoadBalancer` key (see below), these requests and updates will only be handled by the DataMiner Agents specified in that `dmasForLoadBalancer` key.

  - When this key is set to **false**, for the DataMiner Agent in question, all requests and updates with regard to web visual overviews will be handled by the local SLHelper process.

- `<add key="dmasForLoadBalancer" value="1;2;15" />`

  If you enabled load balancing by setting the `visualOverviewLoadBalancer` key to true, you can use this key to restrict the number of DataMiner Agents that will be used for visual overview load balancing.

  The key's value must be set to a semicolon-separated list of DMA IDs. For example, if the value is set to "1;2;15", the DataMiner Agents with ID 1, 2, and 15 will be used to handle all requests and updates with regard to web visual overviews.

  If you only specify one ID (without trailing semicolon), only that specific DataMiner Agent will be used to handle all requests and updates with regard to web visual overviews.

> [!NOTE]
> These settings are not synchronized among the Agents in the cluster.

##### New server messages

The following new messages can now be used to  which you can target to be sent to other DMAs in the cluster:

- `TargetedGetVisualOverviewDataMessage` allows you to retrieve a Visual Overview data message containing the image and the content of a visual overview.

- `TargetedSetVisualOverviewDataMessage` allows you to execute actions on a visual overview that is rendered on a specific DataMiner Agent.

> [!NOTE]
> DataMiner Agents will now automatically detect that a visual overview they are rendering has been updated. This means that other agents in the cluster will now be able to correctly process update events and request new images for their clients.

##### Logging

Additional logging with regard to visual overview load balancing will be available in the web logs located in the *C:\\Skyline DataMiner\\Logging\\Web* folder.

#### Information events of type 'script started' will no longer be generated when an Automation script is triggered by the Correlation engine [ID 41653]

<!-- MR 10.6.0 - FR 10.5.2 -->

From now on, by default, information events of type "script started" will no longer be generated when an Automation script is triggered by the Correlation engine.

In other words, when an Automation script is triggered by the Correlation engine, the SKIP_STARTED_INFO_EVENT:TRUE option will automatically be added to the `ExecuteScriptMessage`. See also [Release note 33666](xref:General_Main_Release_10.3.0_new_features_1#added-the-option-to-skip-the-script-started-information-event-id-33666).

If you do want such information events to be generated, you can add the `SkipInformationEvents` option to the *MaintenanceSettings.xml* file and set it to false:

```xml
<MaintenanceSettings xmlns="http://www.skyline.be/config/maintenancesettings">
    ...
    <SLNet>
        ...
        <SkipInformationEvents>false</SkipInformationEvents>
        ...
    </SLNet>
    ...
</MaintenanceSettings>
```

#### DataMiner upgrade: New upgrade action 'UpdateSrmContributingProtocolsForSwarming' [ID 41706]

<!-- MR 10.6.0 - FR 10.5.2 -->

On systems on which Swarming has been enabled, contributing bookings are not working because protocols of enhanced services do not have a parameter with ID 7.

During a DataMiner upgrade, a new upgrade action named *UpdateSrmcontributingProtocolsForSwarming* will now check for generated service protocols that do not have a parameter with ID 7. If such protocols exist, the parameter in question will be added to them.

When the above-mentioned upgrade action is executed, it will log the name and the version of every protocol to which it has added a parameter with ID 7. It will also log a warning for every corrupt protocol it has found.

> [!NOTE]
> From now on, newly generated service protocols will by default have a parameter with ID 7.

#### Elements can now be configured to run in isolation mode [ID 41757]

<!-- MR 10.6.0 - FR 10.5.4 -->

Up to now, the *ProcessOptions* section of the *DataMiner.xml* file allowed you to configure that an element had to run in its own SLProtocol and SLScripting processes, and in a *protocol.xml* file, the *RunInSeparateInstance* tag allowed you to do the same. However, it was only possible to configure this for all elements using a particular protocol.

From now on, the new *Run in isolation mode* feature will allow you to also configure this for one single element.

As creating additional SLProtocol processes has an impact on the resource usage of a DataMiner Agent, a hard limit of 50 SLProtocol processes has been introduced. If, when an element starts, an attempt to create a new SLProtocol process fails because 50 processes are already running, the element will be hosted by an existing SLProtocol process and its matching SLScripting process, regardless of how the *Run in isolation mode* was configured.

From those 50 SLProtocol processes, 10 processes will be reserved for elements that are not running in isolation mode. This means, that only 40 elements will be able to run in isolation mode at any given time. However, the notice that will appear each time an attempt is made to start an additional element in isolation mode will mention the 50-element limit.

Reducing the number of SLProtocol processes in the *DataMiner.xml* file will reduce the number of reserved processes. However, increasing the number of SLProtocol processes to above 50 will keep the reserved number of SLProtocol processes to 50 (i.e. the maximum number of SLProtocol processes).

For example, if 15 SLProtocol processes are configured in the *DataMiner.xml* file, and 45 elements are configured to run in isolation mode, then:

- 10 SLProtocol processes will be used for elements that are not running in isolation mode,
- 35 SLProtocol processes will be used to host an element in isolation mode, and
- the remaining 5 SLProtocol processes will be used for elements running either in isolation mode or not, depending on which elements starts first.

This means, that some elements will not be able to run in isolation mode, and some SLProtocol processes will not be able to host elements that are not running in isolation mode. In each of those cases, an alarm will be generated.

In the DataMiner.xml file, it is possible to configure a separate SLProtocol process for every protocol that is being used. This setting will also comply with the above-mentioned hard limit of 50 SLProtocol processes. As this type of configuration is intended for testing/debugging purposes only, an alarm will be generated when such a configuration is active to avoid that this setting would remain active once the investigation is done.

For more information on how to configure elements to run in isolation mode in DataMiner Cube, see [Elements can now be configured to run in isolation mode [ID 41758]](xref:Cube_Feature_Release_10.5.4#elements-can-now-be-configured-to-run-in-isolation-mode-id-41758).

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

#### Information events of type 'script started' will no longer be generated when an Automation script is triggered by the Scheduler app [ID 41970]

<!-- MR 10.6.0 - FR 10.5.4 -->

From now on, by default, information events of type "script started" will no longer be generated when an Automation script is triggered by the Scheduler app.

In other words, when an Automation script is triggered by the Scheduler app, the SKIP_STARTED_INFO_EVENT:TRUE option will automatically be added to the `ExecuteScriptMessage`. See also [Release note 33666](xref:General_Main_Release_10.3.0_new_features_1#added-the-option-to-skip-the-script-started-information-event-id-33666).

If you do want such information events to be generated, you can add the `SkipInformationEvents` option to the *MaintenanceSettings.xml* file and set it to false:

```xml
<MaintenanceSettings xmlns="http://www.skyline.be/config/maintenancesettings">
    ...
    <SLNet>
        ...
        <SkipInformationEvents>false</SkipInformationEvents>
        ...
    </SLNet>
    ...
</MaintenanceSettings>
```

#### Relational anomaly detection [ID 42034]

<!-- MR 10.6.0 - FR 10.5.3 -->

Relational anomaly detection (RAD) will detect when a group of parameters deviates from its normal behavior. A user can configure one or more groups of parameter instances that should be monitored together, and RAD will then learn how the parameter instances in these groups are related. Whenever the relation is broken, RAD will detect this and generate suggestion events. A suggestion event will be generated for each parameter instance in the group where a broken relation was detected.

##### Configuration file

Per DataMiner Agent, the above-mentioned parameter groups must be configured in the *C:\\Skyline DataMiner\\Analytics\\RelationalAnomalyDetection.xml* file. This file will be read when SLAnalytics starts up, when RAD is enabled or re-enabled, or when a *ReloadMadConfigurationMessage* is sent.

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
