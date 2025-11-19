---
uid: General_Main_Release_10.6.0_new_features
---

# General Main Release 10.6.0 – New features - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## Highlights

- [Swarming [ID 37381] [ID 37437] [ID 37486] [ID 37925] [ID 38019] [ID 39303] [ID 40704] [ID 40939] [ID 41258] [ID 41490] [ID 42314] [ID 42535] [ID 43196] [ID 43567] [ID 43793]](#swarming-id-37381-id-37437-id-37486-id-37925-id-38019-id-39303-id-40704-id-40939-id-41258-id-41490-id-42314-id-42535-id-43196-id-43567-id-43793)

## New features

#### Swarming [ID 37381] [ID 37437] [ID 37486] [ID 37925] [ID 38019] [ID 39303] [ID 40704] [ID 40939] [ID 41258] [ID 41490] [ID 42314] [ID 42535] [ID 43196] [ID 43567] [ID 43793]

<!-- MR 10.6.0 - FR 10.5.1 -->
<!-- RN 42314: MR 10.6.0 - FR 10.5.4 -->
<!-- RN 42535: MR 10.6.0 - FR 10.5.5 -->
<!-- RN 43196: MR 10.6.0 - FR 10.5.9 -->
<!-- RN 43567: MR 10.6.0 - FR 10.5.11 -->
<!-- RN 43793: MR 10.6.0 - FR 10.5.11 -->

From now on, you can enable the Swarming feature in a DataMiner System in order to be able to swarm [elements](xref:SwarmingElements) from one DataMiner Agent to another Agent in the same cluster. Prior to this, this feature is available in preview if the *Swarming* [soft-launch option](xref:SoftLaunchOptions) is enabled.

The primary goal of Swarming is to eliminate downtime resulting from maintenance activities and provide a more polished user experience.

Note that when Swarming is enabled, this will result in some major changes to the DataMiner configuration:

- Alarm identifiers will be generated on a per-element basis instead of per Agent to make them unique within the cluster. Because of this change, you will need to make sure [your system is prepared](xref:SwarmingPrepare) before you can enable Swarming.

- Element configuration will be stored in the cluster-wide database instead of in the element XML files on the disk of the DataMiner Agent hosting each element.

  When Swarming is enabled, a file named *Where are my elements.txt* will be present in the `C:\Skyline DataMiner\Elements\` folder. In that file, users who wonder why this folder no longer contains any *element.xml* files will be referred to the [Swarming documentation](https://aka.dataminer.services/swarming) in [docs.dataminer.services](https://docs.dataminer.services/).

When you create or update an element in DataMiner Cube, you will be able to indicate that the element is not allowed to swarm to another host. To do so, go to the *Advanced* section, and enable to *Block Swarming* option. By default, this option will be set to false.

If you try to swarm an element of which the *Block Swarming* option is set to true, then the error message *Element is not allowed to swarm (blocked)* will be displayed.

In DataMiner Cube, this *Block Swarming* option will only be visible if Swarming is enabled in the DataMiner System.

When an element is swarmed to the DataMiner Agent that is hosting it already, an unload request will be broadcasted to all DataMiner Agents in the cluster, making sure that no other DataMiner Agent is incorrectly hosting it.

> [!IMPORTANT]
>
> - Swarming cannot be enabled on DataMiner Main Release 10.5.
> - If you decide to [roll back Swarming](xref:SwarmingRollback) again, you will need to restore a backup to get the element XML files back. Any changes that have been implemented to elements after you enabled Swarming will be lost. As a consequence, the sooner you decide to roll back, the smaller the impact of the rollback will be.

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
> - Currently, Swarming is limited to [basic elements](xref:SwarmingElements) and parent DVE and Virtual Function elements. Support for other types of elements will be added in future versions.
> - If you swarm a parent DVE or parent Virtual Function element, all child elements will then automatically be swarmed together with the parent element. Note that parent or child elements that are part of a redundancy group cannot be swarmed. Also, a parent element cannot be swarmed if one of its child elements is part of a redundancy group.
> - [Prerequisite checks](xref:EnableSwarming#running-a-prerequisites-check) are in place to prevent the enabling of the Swarming feature when non-supported objects are present. Where possible, you will also be prevented from configuring or creating these on a Swarming-enabled system.

##### Required user permissions

To enable the Swarming feature, the [Admin Tools](xref:DataMiner_user_permissions#modules--system-configuration--tools--admin-tools) user permission is required.

Once the feature has been enabled, users will need the [Swarming](xref:DataMiner_user_permissions#modules--swarming) user permission to trigger any swarming actions. Users who previously had the [Import DELT](xref:DataMiner_user_permissions#general--elements--import-delt) and [Export DELT](xref:DataMiner_user_permissions#general--elements--import-delt) user permissions before Swarming was enabled will automatically also get the *Swarming* user permission when upgrading from a version without the *Swarming* permission to a version with the *Swarming* permission.

To swarm an element, users will also need config rights on the element.

##### Swarming elements

When Swarming has been enabled, you can swarm elements **in DataMiner Cube** via *System Center* > *Agents* > *Status*. On that page, the *Swarming* button will be displayed instead of the *Migration* button. Clicking the button will open a window where you can select the elements you want to swarm and the destination DMA. Note that child DVE elements and child Virtual Function elements will not appear in this window as they automatically follow their parent element.

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

An information event will be generated when an element has been successfully swarmed. Example:

`Swarmed from <DmaName> (<DmaId>) to <DmaName> (<DmaId>) by <UserName>`

> [!NOTE]
> When the source DMA is no longer available or unknown, the information event will be shortened to `Swarmed to <DmaName> (<DmaId>) by <UserName>`.

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

In the `C:\Skyline DataMiner\Webpages\API\Web.config` file of a particular DataMiner Agent, add the following keys in the `<appSettings>` section:

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

The following new messages can now be used to which you can target to be sent to other DMAs in the cluster:

- `TargetedGetVisualOverviewDataMessage` allows you to retrieve a Visual Overview data message containing the image and the content of a visual overview.

- `TargetedSetVisualOverviewDataMessage` allows you to execute actions on a visual overview that is rendered on a specific DataMiner Agent.

> [!NOTE]
> DataMiner Agents will now automatically detect that a visual overview they are rendering has been updated. This means that other agents in the cluster will now be able to correctly process update events and request new images for their clients.

##### Logging

Additional logging with regard to visual overview load balancing will be available in the web logs located in the `C:\Skyline DataMiner\Logging\Web` folder.

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

From now on, the new *Run in isolation mode* feature will allow you to also configure this for one single element. For more information on how to configure this in DataMiner Cube, see [Elements can now be configured to run in isolation mode [ID 41758]](xref:Cube_Feature_Release_10.5.4#elements-can-now-be-configured-to-run-in-isolation-mode-id-41758).

As creating additional SLProtocol processes has an impact on the resource usage of a DataMiner Agent, a hard limit of 50 SLProtocol processes has been introduced. If, when an element starts, an attempt to create a new SLProtocol process fails because 50 processes are already running, the element will be hosted by an existing SLProtocol process and its matching SLScripting process, regardless of how the *Run in isolation mode* was configured.

From those 50 SLProtocol processes, 10 processes will be reserved for elements that are not running in isolation mode. This means, that only 40 elements will be able to run in isolation mode at any given time. However, the notice that will appear each time an attempt is made to start an additional element in isolation mode will mention the 50-element limit.

Reducing the number of SLProtocol processes in the *DataMiner.xml* file will reduce the number of reserved processes. However, increasing the number of SLProtocol processes to above 50 will keep the reserved number of SLProtocol processes to 50 (i.e. the maximum number of SLProtocol processes).

For example, if 15 SLProtocol processes are configured in the *DataMiner.xml* file, and 45 elements are configured to run in isolation mode, then:

- 10 SLProtocol processes will be used for elements that are not running in isolation mode,
- 35 SLProtocol processes will be used to host an element in isolation mode, and
- the remaining 5 SLProtocol processes will be used for elements running either in isolation mode or not, depending on which elements starts first.

This means, that some elements will not be able to run in isolation mode, and some SLProtocol processes will not be able to host elements that are not running in isolation mode. In each of those cases, an alarm will be generated.

In the *DataMiner.xml* file, it is possible to configure a separate SLProtocol process for every protocol that is being used. This setting will also comply with the above-mentioned hard limit of 50 SLProtocol processes. As this type of configuration is intended for testing/debugging purposes only, an alarm will be generated when such a configuration is active to avoid that this setting would remain active once the investigation is done.

See also [RunInIsolationModeConfig property added to SLNet messages ElementInfoEventMessage and LiteElementInfoEvent [ID 42247]](#runinisolationmodeconfig-property-added-to-slnet-messages-elementinfoeventmessage-and-liteelementinfoevent-id-42247)

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

#### Relational anomaly detection [ID 41983] [ID 42034] [ID 42181] [ID 42276] [ID 42283] [ID 42319] [ID 42429] [ID 42480] [ID 42602] [ID 43320] [ID 43440] [ID 43686] [ID 43720] [ID 43769] [ID 43797] [ID 43853] [ID 43934] [ID 44096]

<!-- RNs 41983: MR 10.6.0 - FR 10.5.3 -->
<!-- RNs 42034: MR 10.6.0 - FR 10.5.3 -->
<!-- RNs 42181: MR 10.6.0 - FR 10.5.4 -->
<!-- RNs 42276: MR 10.6.0 - FR 10.5.4 -->
<!-- RNs 42283: MR 10.6.0 - FR 10.5.4 -->
<!-- RNs 42319: MR 10.6.0 - FR 10.5.4 -->
<!-- RNs 42429: MR 10.6.0 - FR 10.5.5 -->
<!-- RNs 42480: MR 10.6.0 - FR 10.5.5 -->
<!-- RNs 42602: MR 10.6.0 - FR 10.5.6 -->
<!-- RNs 43320: MR 10.6.0 - FR 10.5.9 -->
<!-- RNs 43440: MR 10.6.0 - FR 10.5.11 -->
<!-- RNs 43686: MR 10.6.0 - FR 10.5.11 -->
<!-- RNs 43720: MR 10.6.0 - FR 10.5.12 -->
<!-- RNs 43769: MR 10.6.0 - FR 10.5.12 -->
<!-- RNs 43797: MR 10.6.0 - FR 10.5.11 -->
<!-- RNs 43853: MR 10.6.0 - FR 10.5.12 -->
<!-- RNs 43934: MR 10.6.0 - FR 10.5.12 -->
<!-- RNs 44096: MR 10.6.0 - FR 10.6.1 -->

Relational anomaly detection (RAD) will detect when a group of parameters deviates from its normal behavior. A user can configure one or more groups of parameter instances that should be monitored together, and RAD will then learn how the parameter instances in these groups are related.

Whenever the relation is broken, RAD will detect this and generate suggestion events for each parameter instance in the group where a broken relation was detected. These suggestion events will then be grouped into a single incident so that it is shown on a single line in the Alarm Console. When you clear such an incident, all its base alarms (i.e. the suggestion events created by Relational anomaly detection) will also be cleared.

All relational anomalies detected by the Relational Anomaly Detection (RAD) feature will be stored in the database\*.

*\*If you choose not to use the recommended Storage as a Service (STaaS) setup but instead choose self-managed storage, you also need to set up an OpenSearch or Elasticsearch indexing database in your DMS.*

##### Configuring the parameter groups

All configuration settings are stored in the *ai_rad_models_v2* database table, and have to be managed using either the *RAD Manager* app or the RAD API.

> [!NOTE]
>
> - A RAD parameter group will be hosted on the DMA on which it was created, even after some of the parameters in the group were swarmed to other DMAs.
> - Whenever you delete an element that is being used in one or more RAD parameter groups, an error will immediately get logged, and the parameter groups containing parameters from that deleted element will be marked as "not monitored".
> - When SLAnalytics starts up, it checks whether the configured relational anomaly groups are still valid. In other words, it checks whether the elements and parameters in those groups still exist and are still trended. Note that, if at least one parameter in a group is no longer valid, and if the group in question is a shared model group with multiple subgroups, SLAnalytics will still start the monitoring of the subgroups in which all parameters are still valid.

##### Average trending

RAD requires parameter instances to have at least one week of five-minute average trend data. If at least one parameter instance has less than a week of trend data available, monitoring will only start after this one week becomes available. In particular, this means that average trending has to be enabled for each parameter instance used in a RAD group and that the TTL for five-minute average trend data has to be set to more than one week (recommended setting: 1 month). Also, RAD only works for numeric parameters.

If necessary, users can force RAD to retrain its internal model by sending a `RetrainMadModelMessage`. In this message, they can indicate the periods during which the parameters were behaving as expected. This will help RAD to identify when the parameters deviate from that expected behavior in the future.

##### History set parameters

Under certain conditions, Relational anomaly detection (RAD) is able to detect relational anomalies on history set parameters:

- If there is at least one history set parameter in a RAD parameter group, that parameter group will only be processed when all data from all parameters in the group has been received. In other words, if a history set parameter receives data 30 minutes later than the real-time parameters, possible anomalies will only be detected after 30 minutes.

- RAD will only process data received within the last hour. If a history set parameter receives data more than an hour later than the real-time parameters, that data will be disregarded.

##### Limitations

Some parameter behavior will cause RAD to work less accurately. For example, if a parameter only reacts on another parameter after a certain time, then RAD will produce less accurate results.

##### Messages

The following API messages can be used to create, retrieve, migrate, and remove RAD parameter groups:

| Message | Function |
|---------|----------|
| AddRADParameterGroupMessage     | Creates a new RAD parameter group.<br>It is not allowed to have two groups with the same name, even when they are hosted by different agents.<br>If a group with the same name already exists, no new group will be added. Instead, the existing group will be updated. |
| GetAllRelationalAnomaliesMessage | Retrieves all relational anomalies within a given time frame, regardless of the RAD parameter group or parameter they were detected on.<br>Note: This message will only return anomalies detected on parameters to which the user has access. |
| GetRADDataMessage               | Retrieves the anomaly scores over a specified time range of historical data. |
| GetRADParameterGroupInfoMessage | Retrieves all configuration information for a particular RAD parameter group.<br>The response to a `GetRADParameterGroupInfoMessage` includes an IsMonitored flag. This flag will indicate whether the (sub)group is correctly being monitored ("true"), or whether an error has occurred that prevents the group from being monitored ("false"). In the latter case, more information can be found in the SLAnalytics logging. |
| GetRADParameterGroupsMessage    | Retrieves a list of all RAD parameter groups that have been configured across all agents in the cluster. |
| GetRADSubgroupInfoMessage       | Retrieves all configuration information for a particular RAD parameter subgroup by subgroup ID. |
| GetRADSubgroupModelFitMessage   | Retrieves the model fit score of a RAD parameter subgroup.<br>The model fit score, ranging from 0 to 1, indicates how well the relational behavior of a subgroup is captured by the shared model trained across multiple subgroups:<br>- Higher scores suggest that the subgroup's behavior aligns well with the shared model.<br>- Lower scores indicate that the subgroup's behavior deviates from the patterns learned by the shared model.<br>The model fit score is derived from the evolution of anomaly scores over time for the subgroup in question. In general, subgroups with consistently high anomaly scores tend to have lower model fit scores, reflecting poor alignment with the shared relational model. |
| GetRelationalAnomaliesMessage   | Retrieves relational anomalies detected in the past for a particular parameter during a specified time range. |
| MigrateRADParameterGroupMessage | Migrates a RAD parameter group to a specific DataMiner Agent. This new DataMiner Agent will then be responsible for building, maintaining, and executing the anomaly detection model of the RAD parameter group in question.<br>Note: A RAD parameter group will be migrated automatically when its parameters are hosted by elements that are swarmed from one DataMiner Agent to another. The RAD parameter group will then be migrated to the DataMiner Agent hosting the majority of its parameters. |
| RemoveRADParameterGroupMessage  | Deletes a RAD parameter group. |
| RetrainRADModelMessage          | Retrains the RAD model over a specified time range. |

> [!NOTE]
>
> - These messages do not have to be sent to the agent monitoring the parameters in question. Each message will automatically be forwarded to the correct agent based on the name of the parameter group. If the agent could not be determined, an exception will be thrown.
> - Names of RAD parameter groups will be processed case-insensitive.
> - When a Relational Anomaly Detection (RAD) parameter group is deleted, all open suggestion events associated with that parameter group will automatically be cleared.
> - Instances of (direct) view column parameters provided in the `AddRADParameterGroupMessage` or the `AddRADSubgroupMessage` will automatically be translated to the base table parameters.
> - DVE child parameters provided in the `AddRADParameterGroupMessage` or the `AddRADSubgroupMessage` will automatically be translated to the parent parameters.
> - Security has been added to all RAD messages. You will not be able to edit, remove or retrieve information about groups that contain parameters of elements to which you do not have access. The `GetRADParameterGroupsMessage` will return all groups though.
> - The following messages have been deprecated: *AddMADParameterGroupMessage*, *GetMADParameterGroupInfoMessage*, *RemoveMADParameterGroupMessage*, and *RetrainMADModelMessage*.

#### SLNetClientTest tool: Element process ID information [ID 42013]

<!-- MR 10.6.0 - FR 10.5.4 -->

In the *SLNetClientTest* tool, you can now retrieve live information about the mapping between elements running on a DataMiner Agent and the processes they use, including SLProtocol and SLScripting. To do so, go to *Diagnostics > DMA > Element Process ID Info*.

The information provided is similar to the information found in the *SLElementInProtocol.txt* log file. It will allow you to monitor and troubleshoot process usage in real time.

> [!WARNING]
> Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### RunInIsolationModeConfig property added to SLNet messages ElementInfoEventMessage and LiteElementInfoEvent [ID 42247]

<!-- MR 10.6.0 - FR 10.5.4 -->

A new `RunInIsolationModeConfig` property has been added to the SLNet messages `ElementInfoEventMessage` and `LiteElementInfoEvent`. This property will allow client applications to indicate if and how an element is configured to run in isolation mode.

The property can have one of the following values:

| Value    | Description |
|----------|-------------|
| None     | The element is not running in isolation mode. |
| Dma      | In the `ProcessOptions` section of the *DataMiner.xml* file, it has been specified that all elements using the protocol in question should be running in isolation mode. |
| Protocol | In the *protocol.xml* file, the `RunInSeparateInstance` tag specifies that all elements using the protocol in question should be running in isolation mode. |
| Element  | The element has been individually configured to run in isolation mode. |

If multiple settings indicate that the element should be running in isolation mode, the `RunInIsolationModeConfig` property will be set to one of the above-mentioned values in the following order of precedence: "Protocol", "Element", "Dma".

> [!NOTE]
>
> - If, in DataMiner Cube, you specified that a particular element had to run in isolation mode, the boolean property `RunInIsolationMode` will be true. In some cases, this boolean `RunInIsolationMode` property will be false, while the above-mentioned `RunInIsolationModeConfig` property will be set to "Protocol". In that case, the element will be running in isolation mode because it was configured to do on protocol level.
> - See also [Elements can now be configured to run in isolation mode [ID 41757]](#elements-can-now-be-configured-to-run-in-isolation-mode-id-41757)

#### New NotifyProtocol call NT_CLEAR_PARAMETER [ID 42397]

<!-- MR 10.6.0 - FR 10.5.6 -->

A new NotifyProtocol call *NT_CLEAR_PARAMETER* (474) can now be used to clear tables and single parameters. When used, it will also clear the parameter's display value and save any changes when the parameter is saved.

Internally, this new *NT_CLEAR_PARAMETER* call will now also be used by the existing SLProtocol function `ClearAllKeys()`. As a result, the latter will now be able to clear tables of which the RTDisplay setting was not set to true.

> [!NOTE]
>
> - *NT_CLEAR_PARAMETER* cannot be used to clear table columns.
> - This new NotifyProtocol method can be invoked from within a QAction by using the `protocol.ClearParameter(<paramId>`) function.
> - When using `ProtocolExt`, you can now use e.g. `protocol.getRequests.Clear()` to clear a table parameter named *getRequests*. Internally, this new `Clear()` function will then execute a `protocol.ClearAllKeys(<getRequests parameter ID>)` call.

#### Automation: Separate log file for every Automation script that is run [ID 42572]

<!-- MR 10.6.0 - FR 10.5.6 -->

From now on, when an Automation script is run, every entry that is logged in the *SLAutomation.txt* file by the `Engine.Log` method will also be logged in a separate log file located in `C:\Skyline DataMiner\Logging\Automation\`. That log file will have a name that is identical to that of the Automation script.

- The first time an Automation script is run, a log file will be created in `C:\Skyline DataMiner\Logging\Automation\` for that particular script.
- After a DataMiner restart, the first time a script is executed, its existing log file will get the "_Bak" suffix and a new log file will be created.
- If an Automation script is renamed, a new log file will be created with a name identical to that of the renamed script. The old file will be kept.
- If you want to configure a custom log level for a particular Automation script, send an `UpdateLogfileSettingMessage` in which *Name* is set to "Automation\ScriptName". If no custom log configuration exists for a particular Automation script, the default configuration will be used.
- These new Automation script log files will also be included in SLLogCollector packages.
- Each time a DataMiner upgrade package is installed, all Automation script log files will be deleted.

Log entry format: `1|2|3|4|5|6|7|8`

1. Date/time
1. "SLManagedAutomation"
1. Method that created the log entry
1. Log type
1. Log level
1. Thread ID
1. Script run ID
1. Message

Example: `2025/04/01 16:31:31.813|SLManagedAutomation|RunSafe|INF|0|959|473|Example message`

> [!NOTE]
>
> - In the Automation script log file, you will find an indication of when the script execution started and stopped. However, this indication will be slightly different from the one you will find in the *SLAutomation.txt* log file. The one in the *SLAutomation.txt* log file will represent the total time it took for the script to run, while the one in the script log file will only take into account the C# blocks in the Automation script.
> - For each entry that is logged in one of the above-mentioned script log files, an identical copy will also be logged in the *SLAutomation.txt* file. However, note that the timestamps of both entries may not be identical.

#### Automation: Hash property of GetScriptInfoResponseMessage now contains a hash value of the script [ID 42616]

<!-- MR 10.6.0 - FR 10.5.7 -->

A `Hash` property has now been added to the `GetScriptInfoResponseMessage`. This property will contain a calculated hash value of the script based on the following script data:

- Name
- Description
- Type
- Script options:

  - Options included in the hash value calculation:
  
    - DebugMode
    - SkipElementChecks
    - SkipInfoEventsSet
    - SupportsBackAndForward
    - AllowUndef
    - WebCompliant (see soft-launch option [UseWebIAS](xref:Overview_of_Soft_Launch_Options#usewebias))

  - Options not included in the hash value calculation:

    - None
    - RequireInteractive
    - SavedFromCube
    - HasFindInteractiveClient

  > [!NOTE]
  > For more information on the different script options, see [options attribute](xref:DMSScript-options).

- CheckSets
- Protocols
- Memories
- Parameters
- Executables

  > [!NOTE]
  > Executable code will be trimmed. All empty lines before and after the code will be removed.

> [!NOTE]
> Author will not be included in the hash value as changing the author would result in a different value being calculated.

All hash values of all Automation scripts will be added as `AutomationScriptHashInfo` objects to the Automation script hash value cache file *AutomationScriptHashCache.txt*, located in the `C:\Skyline DataMiner\System Cache\` folder. This file will be updated one minute after an Automation script was created or updated or one minute after a `GetScriptInfoMessage` was called.

Format of an AutomationScriptHashInfo object: `Script Name;LastUpdate;Calculated hash`

Example: `Automation script;638786700548555379;48bcb02e89875979c680d936ec19ad5e9697f7ed73498fd061aecb73e7097497`

#### SNMPv3: Parameter value can now be used as context name or context ID when executing an SNMP get or set command [ID 42676]

<!-- MR 10.6.0 - FR 10.5.6 -->

In a connector of an SNMPv3 element, it is now possible to indicate that the value of a specific parameter should be used as context name or context ID whenever an SNMP get command or an SNMP set command is executed on the particular connection.

To define that the value of a particular parameter should be used as context name for connection 0, specify the following:

```xml
<Param ...>
    ...
    <SNMP options="ContextName:0"/>
    ...
</Param>
```

To define that the value of a particular parameter should be used as context ID for connection 0, specify the following:

```xml
<Param ...>
    ...
    <SNMP options="ContextID:0"/>
    ...
</Param>
```

If the parameter is not initialized or is set to an empty string, the default parameter value will be used (i.e. an empty string).

The context name and context ID can be changed at runtime, and are not saved by default. When the element is restarted, the parameter data will be lost unless the `save` attribute of the parameter was set to true (e.g. `<Param id="1" save="true">`).

#### Automation scripts: Generating information events when editing a connection in a QAction [ID 42783]

<!-- MR 10.6.0 - FR 10.5.7 -->

The SLNet message `EditConnection`, which can be used to edit a connection from within a QAction, now has a `GenerateInformationEvents` property. If this property is set to true, information events will be generated when a connection is created, updated, or deleted.

#### Interactive Automation scripts executed in a web app: Filtering values in a dropdown box [ID 42808]

<!-- MR 10.6.0 - FR 10.5.8 -->

To prevent dropdown boxes in interactive Automation scripts from getting loaded with too much data, it is now possible to filter the data that is loaded into a dropdown box.

For an example showing how to implement a dropdown box filter in an interactive Automation script, see [Interactive Automation scripts: Filtering values in a redesigned UI component 'DropDown' [ID 42845]](xref:Web_apps_Feature_Release_10.5.8#interactive-automation-scripts-filtering-values-in-a-redesigned-ui-component-dropdown-id-42845).

> [!IMPORTANT]
> This feature is only supported for interactive Automation scripts executed in web apps. It is not supported for interactive Automation scripts executed in DataMiner Cube.

#### New BPA test 'Large Alarm Trees' [ID 42952]

<!-- MR 10.6.0 - FR 10.5.9 -->

A new BPA test named "Large Alarm Trees" is now available. This test will retrieve the active alarm trees and check if any are getting too large, because excessively large alarm trees can potentially have a negative impact on your DataMiner System. If any large alarm trees are found, you will need to take the necessary [corrective actions](xref:Best_practices_for_assigning_alarm_severity_levels#keep-alarm-trees-from-growing-too-large).

The BPA test is available in System Center on the *Agents > BPA* tab.

#### Automation scripts: New Interactivity tag [ID 42954]

<!-- MR 10.6.0 - FR 10.5.9 -->

Up to now, Automation scripts using the IAS Interactive Toolkit required a special comment or code snippet in order to be recognized as interactive. From now on, you will be able to define the interactive behavior of an Automation script by adding an `<Interactivity>` tag in the header of the script. See the following example.

```xml
<DMSScript xmlns="http://www.skyline.be/automation">
  ...  
  <Interactivity>Always</Interactivity>
  ...
  <Script>
    ...
  </Script>
</DMSScript>
```

Possible values:

| Value | Description |
|-------|-------------|
| Auto     | Like before, an attempt will be made to automatically detect the interactive behavior of the script. |
| Never    | The script will never show any UI element. |
| Optional | The script will be interactive when it needs to be. |
| Always   | The script will always be interactive. |

#### Automation: New OnRequestScriptInfo entry point [ID 42969]

<!-- MR 10.6.0 - FR 10.5.7 -->

In an Automation script, you can now implement the `OnRequestScriptInfo` entry point. This will allow other Automation scripts (or any other code) to request information about the script in question, for example to find out which profile parameter values a script needs in order to orchestrate a device.

##### Using the entry point

To use the entry point, add a method with the following signature to the script:

```csharp
[AutomationEntryPoint(AutomationEntryPointType.Types.OnRequestScriptInfo)]
public RequestScriptInfoOutput OnRequestScriptInfoRequest(IEngine engine, RequestScriptInfoInput inputData)
```

Both `RequestScriptInfoInput` and `RequestScriptInfoOutput` have a `Data` property of type `Dictionary<string, string>`, which can be used to exchange information between the script and other code. We strongly recommend keeping the passed data below 20 MB (i.e. 10 million characters). If larger chunks need to be passed, a reference to that information should be passed instead.

It is allowed to pass null as input data and to return null as output data.

##### Arguments

If the script has any script parameters, dummies or memory files, then these are not required when executing the `OnRequestScriptInfo` entry point. However, they are required when executing the `Run` method of that same script.

- When an omitted script parameter is used in the entry point logic, retrieving the script parameter is possible, but its value will be an empty string.
- When an omitted dummy is used in the entry point logic, retrieving the dummy is possible, but it will refer to DMA ID -1 and element ID -1. Any actions that use the dummy will fail with an exception.
- When an omitted memory file is used in the entry point logic, retrieving the memory file is possible, but it will refer to a linked file that is empty. Retrieving a value using the memory file will fail with an exception.

##### Subscript

To execute the `OnRequestScriptInfo` entry point within Automation, you have to use the following `PrepareSubScript` method on `Engine` or `IEngine`:

```csharp
RequestScriptInfoSubScriptOptions PrepareSubScript(String scriptName, RequestScriptInfoInput input)
```

The script should be started synchronously. It will return a subscript options object with an `Output` property containing the information returned by the script. The `Input` property can be used to check or update the data sent to the script.

Executing subscripts is limited to a maximum of 10 levels.

##### ExecuteScriptMessage

The `ExecuteScriptMessage` can be used to trigger the entry point using an SLNet connection.

```csharp
var input = new RequestScriptInfoInput
{
  Data = new Dictionary<string, string>
  {
    { "Action", "RequestValues" },
  },
};

new ExecuteScriptMessage
{
  ScriptName = scriptName,
  Options = new SA(new []{ "DEFER:FALSE" }),
  CustomEntryPoint = new AutomationEntryPoint
  {
    EntryPointType = AutomationEntryPoint.Types.OnRequestScriptInfo,
    Parameters = new List<object> { input },
  },
};
```

When an `ExecuteScriptMessage` is sent, an `ExecuteScriptResponseMessage` will be returned. The information is returned in an `EntryPointResult.Result` property of type `RequestScriptInfoOutput`.

This message should not be used to request the information in an Automation script.

#### Automation script and QAction dependencies can now also be uploaded to the 'DllImport\\SolutionLibraries' folder [ID 43108]

<!-- MR 10.6.0 - FR 10.5.9 -->

Up to now, the `UploadScriptDependencyMessage` was only able to upload Automation script and QAction dependencies to the `C:\Skyline DataMiner\Scripts\DllImport` folder. From now on, it will also be able to upload those dependencies to the `C:\Skyline DataMiner\ProtocolScripts\DllImport\SolutionLibraries` folder.

See the following example. The `UploadScriptDependencyMessage` now has a `DependencyFolder` property, which allows you to specify the destination of the dependency to be uploaded.

```csharp
var uploadDependencyMessage = new UploadScriptDependencyMessage()
{
  Bytes = bytes,
  DependencyName = name,
  Path = string.Empty, // Subfolders within the destination can be specified here
  DependencyFolder = ScriptDependencyFolder.SolutionLibraries // Default is 'ScriptDependencyFolder.ScriptImports'
};
```

After a dependency has been uploaded, all scripts using that dependency will be recompiled.

> [!NOTE]
> For QActions in protocols, the relevant SLScripting process must be restarted before the new DLL will get loaded.

#### DataMiner Object Models: Attachments can now be uploaded to a network share [ID 43114] [ID 43366]

<!-- MR 10.6.0 - FR 10.5.10 -->

In `ModuleSettings`, `DomManagerSettings` now contains a new `DomInstanceNetworkAttachmentSettings` class that allows you to save DOM instance attachments to a network share instead of to the *Documents* module.

The `DomInstanceNetworkAttachmentSettings` class contains the following properties:

- `NetworkSharePath` (string)

  The UNC path to the network share where the attachments should be saved.

  This path has to start with `\\` and cannot contain any characters that are illegal for a path (e.g. "<") or strings that allow directory traversal (e.g. "../").

  When the path is left empty, attachments are saved to the `C:\Skyline DataMiner\Documents` folder. This is the default behavior.

- `CredentialId` (GUID)

  The ID of the credentials in the credentials library that will be used to add the attachment to the network share.

  These credentials must be of type *Username and password credentials* and must be the credentials of a user that has read/write access to the path defined in `NetworkSharePath`. In case you have a Windows network share, you need to add the domain name (for a domain user) or hostname (for a local user) in front of the username (e.g. "MYPC\userName").

> [!NOTE]
>
> - When a DOM module is configured to save attachments to a network share, the system will validate whether the user creating/updating the `ModuleSettings` has permission to access the credentials. Once this is set up, any user that has permissions to create or update a `DomInstance` can save attachments to the network share under the configured user.
> - When a DOM module is configured to save attachments to a network share, no migration is done of existing attachments. They will continue to exist in the `C:\Skyline DataMiner\Documents` folder, but will no longer work. You can copy them over or move them to the network share; the folder structure is the same. Likewise, when removing the configuration to save attachments to a network share, no migration is done of attachments available on the previously configured network share.
> - By default, the size of the attachments is limited to 20 MB. See [Documents.MaxSize](xref:MaintenanceSettings.Documents.MaxSize).

#### SLNet: 'TraceId' property added to ClientRequestMessage & extended logging [ID 43187]

<!-- MR 10.6.0 - FR 10.5.9 -->

The `ClientRequestMessage` class has been extended with a new `TraceInfo` class, which has one `TraceId` property of type string. In a later phase, this property will be used to track requests across multiple modules (e.g. queries coming from ad hoc data sources).

CrudLoggerProxy logging will also support trace IDs for CRUD operations by the following managers:

- AppPackageContentManager
- BaseFunctionManager
- BaseProfileManager
- BPAManager
- ClusterEndpointsManager
- ClusterManager
- ConfigurationManager
- DOMManager
- IncrementManager
- JobManager
- MigrationManager
- ModuleSettingsManager
- NATSCustodianManager
- SRMServiceStateManager
- TicketingManager
- UserDefinableApiManager
- VisualManager

Examples of CRUD operation log entries with a trace ID:

```txt
2025/07/02 13:19:14.170|SLNet.exe|CrudLoggerProxy|INF|3|6|[Trace: AUT/98731f18-15ca-421c-9ed7-f93346160d89] Object: SectionDefinition, Forced: False, User: DOMAIN\UserName, Action: Creating CustomSectionDefinition[IDQ1XPM7DXBIL9YXKWZZ,c74e85be-2c1d-4002-aaba-a3b7d712fe3a].

2025/07/02 13:19:14.457|SLNet.exe|CrudLoggerProxy|INF|3|6|[Trace: AUT/98731f18-15ca-421c-9ed7-f93346160d89] Object: SectionDefinition, Forced: False, User: DOMAIN\UserName, Action: Created CustomSectionDefinition[IDQ1XPM7DXBIL9YXKWZZ,c74e85be-2c1d-4002-aaba-a3b7d712fe3a].
```

Also, the trace ID will be logged for the following messages:

- slow client messages (in *SLNet.txt* and *SLSlowClientMessages.txt*)

  ```txt
  2025/07/02 13:19:34.715|SLNet.exe|LogSlowClientMessage|INF|0|252|[Trace: AUT/98731f18-15ca-421c-9ed7-f93346160d89] [Facade.HandleMessage] 60908.7999ms were needed to handle Cube (FirstName LastName @ GTC-USERNAME) => Diagnostic Request: Hang ()
  ```

- incoming messages in SLNet (in *SLNet.txt* and *SLNet\FacadeHandleMessage.txt*)

  ```txt
  2025-07-02 15:05:04.329|277|Facade.HandleMessage|[Trace: AUT/98731f18-15ca-421c-9ed7-f93346160d89] Incoming (RTManagerGUI.exe (FirstName LastName @ GTC-USERNAME)): Skyline.DataMiner.Net.Messages.ManagerStoreCreateRequest`1[Skyline.DataMiner.Net.Apps.DataMinerObjectModel.DomDefinition]
  ```

The logging of a DOM manager will now also contain a line indicating the start of status transitions. This will be logged on information level 3, i.e. the same type and level as regular CRUD actions:

```txt
2025/07/02 15:05:11.110|SLNet.exe|HandleStatusTransitionRequest|INF|3|269|[Trace: AUT/98731f18-15ca-421c-9ed7-f93346160d89] Handling status transition with ID 'new_to_closed' for instance with ID '1ff720a3-0aa2-4548-8b51-d8b975e19ea4'.
```

#### gRPC now used by default for server-server and server-client communication [ID 43190] [ID 43260] [ID 43305] [ID 43331] [ID 43435] [ID 43506]

<!-- MR 10.6.0 - FR 10.5.9 -->

Up to now, .Net Remoting was used by default for communication between DataMiner Cube and a DataMiner Agent as well as between DataMiner Agents, though it was possible to set gRPC as the default instead (either by adding *Redirect* tags in *DMS.xml* or by disabling .NET Remoting in *MaintenanceSettings.xml* for server-server communication, and by adjusting *ConnectionSettings.txt* for server-client communication). Now gRPC will be the default instead. This means that the *EnableDotNetRemoting* setting in *MaintenanceSettings.xml* is now by default set to *false*, and the connection type in *ConnectionSettings.txt* is now by default set to *GRPCConnection*.

When you upload an upgrade package that includes this change, the *VerifyGRPCConnection* prerequisite check will run to verify whether all DataMiner Agents in the cluster are ready to switch to using gRPC as the default communication type. This check will fail in case a possible configuration issue or connectivity issue is detected. For details, refer to [Upgrade fails because of VerifyGRPCConnection.dll prerequisite](xref:KI_Upgrade_fails_VerifyGRPCConnection_prerequisite).

We recommend uploading the package prior to the maintenance window for the upgrade, so you can already check beforehand whether all requirements for the upgrade are met and address any possible issues.

#### Service & Resource Management: Support for capacity ranges [ID 43335]

<!-- MR 10.6.0 - FR 10.5.9 -->

Resource capacity ranges are now supported. To that end, profile parameters can now be of type "range".

A resource can have one capacity range per profile parameter. This range can be either fully booked or partially booked.

- If a range is partially booked, other bookings can book the unbooked part of the range as long as the bookings do not overlap.
- The same range can be booked by two overlapping bookings on condition that the same reference string is used and that the range is identical in both bookings. `GetEligibleResources` has been updated to take this into account.

##### Examples

Scenario: A Resource has a capacity range parameter with a range from 100 to 200.

Example 1:

- If a booking books the entire range without a reference string, no other overlapping bookings can book that resource while requesting that same capacity range.
- `GetEligibleResources` will not return that resource if asked for that capacity range with an overlapping time range.

Example 2:

- If a booking books the range from 100 to 110, another booking can book that range from 110 to 200, etc.
- `GetEligibleResources` will return that resource, specifying the available range from 110 to 200.

Example 3:

- If a booking books the range from 100 to 110 with reference string "Example 3", another booking can book the same range from 100 to 110 if it uses the same "Example 3" reference.
- `GetEligibleResources` wil return the entire range if "Example 3" is provided as reference.

##### Creating a range parameter

This is how you can create a range parameter.

```csharp
var rangeCapacityParameter= new ProfileParameter
{
  ID = Guid.NewGuid(),
  Categories = ProfileParameterCategory.Capacity,
  Name = "Range Parameter",
  Type = ProfileParameter.ParameterType.Range,
};
profileHelper.ProfileParameters.Create(rangeCapacityParameter);
```

##### Creating a resource with a capacity range

This is how you can add range 100 to 1000 to a resource.

```csharp
var capacities = new List<MultiResourceCapacity>
{
  new MultiResourceCapacity
  {
    CapacityProfileID = rangeCapacityParameter.ID,
    Value = new CapacityParameterValue(100, 1000),
  }
};

var resource = new Resource(Guid.NewGuid())
{
  Name = "Resource",
  Mode = ResourceMode.Available,
  Capacities = capacities,
  MaxConcurrency = 10
};

resourceManager.AddOrUpdateResources(resource);
```

##### Booking a range

This is how you can book the range from 100 to 150 of a specified resource.

```csharp
var resourceUsage = new ResourceUsageDefinition(resource.ID)
{
  RequiredCapacities = new List<MultiResourceCapacityUsage>
  {
    new MultiResourceCapacityUsage
    {
      CapacityProfileID = rangeCapacityParameter.ID,
      RangeStart = 100,
      DecimalQuantity = 50
    }
  }
};

booking.ResourcesInReservationInstance.Add(resourceUsage);
```

##### Checking which resources have a specific range available

This is how you can check which resources have a specific range available.

```csharp
var requiredCapacities = new List<MultiResourceCapacityUsage>()
{
  new MultiResourceCapacityUsage(rangeCapacityParameter, 100, 50)
};

var requiredCapabilities = new List<ResourceCapabilityUsage>();

result = resourceManager.GetEligibleResourcesWithUsageInfo(now, now.AddHours(1), requiredCapacities, requiredCapabilities);
```

#### Trap forwarding: Traps can now be forwarded to target elements of which a specific hostname was configured in the port settings [ID 43347]

<!-- MR 10.6.0 - FR 10.5.9 -->

SLSNMPManager is now capable of forwarding traps to target elements of which a specific hostname was configured in the port settings.

If the hostname cannot be resolved to an IP address, an error alarm with the following message will be generated on the target element:

`Could not resolve destination host to an IP: polling host=<hostname>, or failed to set the destination address. <ERROR>`

Example:

`Could not resolve destination host to an IP: polling host=localhost123, or failed to set the destination address. Host to IP failure. Error : 11001. [WSAHOST_NOT_FOUND]`

#### DataMiner upgrade: New VerifyOSVersion prerequisite will block upgrades on unsupported OS versions [ID 43356]

<!-- MR 10.6.0 - FR 10.5.12 -->

When a DataMiner upgrade is being performed, from now on, the new *VerifyOSVersion* prerequisite will check whether the DataMiner version in the upgrade package supports the version of the operating system that is installed on the DataMiner Agent. If not, the upgrade will be aborted, and the user will be asked to upgrade the operating system.

> [!NOTE]
> Microsoft no longer supports OS versions older than Windows Server 2016 or Windows 10. Hence, these versions will not pass the above-mentioned OS version check.

#### DataMiner Object Models: Definition-level security [ID 43380] [ID 43589]

<!-- MR 10.6.0 - FR 10.5.10 -->

It is now possible to configure DOM instance security based on the DOM definitions the instances are linked to. In other words, you will now be able to configure which DataMiner user groups should have access to the DOM instances of a certain DOM definition.

The following important changes have been made:

- Only users who have been granted the *Modules > System configuration > Object Manager > Module Settings* user permission will be allowed to create, update, and delete DOM configuration objects (i.e. section definitions, DOM definitions, DOM behavior definitions, and DOM templates). This means that, if you want to deploy or change a DOM model, you will now need this permission.

- The DOM module settings now include a new `LinkSecuritySettings` configuration object that will allow you to link a DataMiner user group to a DOM definition by ID. This object contains a collection of `GroupLink` objects, each containing the following properties:

  - `GroupName` (string) : The name of the DataMiner user group
  - `DomDefinitionReferences` (List\<DomDefinitionReference\>) : The list of references to the DOM definitions linked to the user group specified in `GroupName`.

  > [!NOTE]
  > Reinitialize the DOM manager each time you have updated the DOM module settings.

##### General behavior

- When no `GroupLink` objects are defined, definition-level security will not be enabled, but users who want to make changes to the DOM configuration settings will need *Modules > System configuration > Object Manager > Module Settings* permission to do so.

  > [!NOTE]
  > Even when definition-level security is enabled will users need *Modules > System configuration > Object Manager > Module Settings* permission if they want to make changes to the DOM configuration settings.

- From the moment one `GroupLink` object has been defined, definition-level security will be enabled for the entire DOM module. Only users belonging to user groups that have `GroupLink` object defined will have access to the instances of the DOM definitions specified in those `GroupLink` objects.

- If a DOM module with definition-level security enabled contains multiple DOM definitions, no one will be able to access the instances of DOM definitions for which no `GroupLink` objects have been defined yet.

- Currently, `GroupLink` objects grant full access (i.e. read access as well as write access) to the instances of the DOM definitions specified in them.

##### Filtering behavior & restrictions

When definition-level security has been enabled for a DOM module, every read and count filter/query will need to be evaluated to find out whether the person using that filter/query is allowed to do so. As it is only possible to evaluate filters and queries with enough context, a number of restrictions have been set.

###### Read filters/queries

A read filter/query needs to filter by DOM definition or by DOM instance ID.

Examples of allowed filters/queries:

| Example | Description |
|---------|-------------|
| (DOM Definition ID == a1ds5z8)  | Reading all DOM instances that are part of the specified DOM definition. |
| (DOM Definition ID == a1ds5z8) && (Field X = "Some Value") | Reading all DOM instances with field X set to "Some Value" that are part of the specified DOM definition. |
| (DOM Definition ID == a1ds5z8) \|\| (DOM Definition ID == 5ze7s84a) | Reading all DOM instances that are part of either of the specified DOM definitions. |
| (DOM Instance ID == f4e87d) \|\| (DOM Instance ID == qs4z54) \|\| (DOM Instance ID == ezeasf) | Reading specific DOM instances based on ID. |

Examples of prohibited filters/queries:

| Example | Description |
|---------|-------------|
| TRUEFilterElement\<DomInstance\> | Sending a plain TRUE filter is not supported when the DOM module has definition-level security enabled. |
| (Field X = "Some Value") | This filter does not contain any context. |
| (Status ID = "in_progress") | This filter does not contain any context. |

When a filter/query that reads DOM instances has a DOM definition context the user does not have access to, the read request will fail with a `NoPermission` error. If the DOM instances are read using a DOM instance ID filter, the read request will not fail, but the DOM instances the user does not have access to will not be returned in the result set. Here are a few examples in which the user only has access to DOM definition A.

| Example | Description |
|---------|-------------|
| (DOM Definition ID == A) | Request will be allowed. |
| (DOM Definition ID == A) \|\| (DOM Definition ID == B) | Request will fail with a `NoPermission` error. |
| (DOM Instance ID == \<Instance linked to A\>) \|\| (DOM Instance ID == \<Instance linked to B\>) | Only the DOM instance linked to DOM definition A will be returned. |

###### Count filters/queries

A count filter/query needs to filter by DOM definition. That means that the filter/query should already limit the results based on one or more DOM definitions. Counts filtered by DOM instance ID(s) are not supported.

Examples of allowed filters/queries:

| Example | Description |
|---------|-------------|
| (DOM Definition ID == a1ds5z8) | Counting all DOM instances that are part of the specified DOM definition. |
| (DOM Definition ID == a1ds5z8) && (Field X = "Some Value") | Counting all DOM instances with field X set to "Some Value" that are part of the specified DOM definition. |
| (DOM Definition ID == a1ds5z8) \|\| (DOM Definition ID == 5ze7s84a) | Counting all DOM instances that are part of either of the specified DOM definitions. |
| (DOM Definition ID = a1ds5z8) && ((DOM Instance ID == f4e87d) \|\| (DOM Instance ID == qs4z54) \|\| (DOM Instance ID == ezeasf)) | Reading specific DOM instances based on ID is only supported if a DOM definition context is specified. |

Examples of prohibited filters/queries:

| Example | Description |
|---------|-------------|
| TRUEFilterElement\<DomInstance\> | Sending a plain TRUE filter is not supported when the DOM module has definition-level security enabled. |
| (Field X = "Some Value") | This filter does not contain any context. |
| (Status ID = "in_progress") | This filter does not contain any context. |
| (DOM Instance ID == f4e87d) \|\| (DOM Instance ID == qs4z54) \|\| (DOM Instance ID == ezeasf) | Reading specific DOM instances based on ID is not supported if no DOM definition context is specified. |

When a filter/query that counts DOM instances has a DOM definition context the user does not have access to, the count request will fail with a `NoPermission` error.

> [!NOTE]
> Filters sent to the DOM manager by standard GQI queries made in a dashboard or low-code app have a DOM definition context by default. No special adjustments have to be made in this case, but keep in mind that GQI queries that retrieve data for DOM definitions the user does not have access to will result in permission errors appearing in the dashboard or low-code app.

##### Additional security when reading/counting DOM instance history records

From now on, when definition-level security is enabled for a DOM module, reading and counting DOM instance history records will only be possible if the following conditions are met:

- The filter must include 'SubjectID Equal' clauses that narrow down the filter to the history of one or more DOM instances. If the filter does not meet this requirement, the request will fail with a `CrudFailedException`, and the `TraceData` will contain a `DomInstanceError` with reason `ReadFilterNotSupportedBySecurity` or `CountFilterNotSupportedBySecurity`.

- The user must have access to all DOM instances for which history records are requested. Also, all specified DOM instances must exist. Otherwise, the request will fail with a `CrudFailedException`, and the `TraceData` will contain `DomInstanceError` with reason `NoPermission`.

##### Event security

The permissions defined by the `GroupLink` objects will also be applied when subscribing on a `DomInstancesChangedEventMessage`. The event should only contain the created, updated or deleted instances the subscribed user is allowed to access. If an event contains multiple objects, and the user does not have access to all of those, the event will be dropped.

The following properties have been added to the `DomInstancesChangedEventMessage` class:

| Property | Description |
|----------|-------------|
| FromSecurityEnabledModule | Determines whether security could be applied to the event.<br>If true, there could be more created, updated, or deleted objects, but the subscribed user may not have access to all of them. |
| SecurityEnabledModuleNotAvailable | An empty event could be received with this boolean property set to true if, for some reason, the security could not be applied.<br>This can occur when a user is subscribed on an agent other than the one that handled the create/update/delete action, and this other agent has connection issues with the database preventing the DOM manager to initialize.<br>If such an event is received, the subscriber may have missed one or more updates. If these events are used to keep a list of cached objects up to date, we recommend reloading them to ensure that the most recent and correct data is visualized. |

##### General notes

- Changing the name of a DataMiner user group will invalidate any existing `GroupLink` objects associated with it. Make sure to adjust these objects when a user group was renamed.
- Reading, adding or removing a DOM instance attachment will now also be blocked if the user does not have permission to read/write that DOM instance.

##### Changes to the SLNetClientTest tool

The SLNetClientTest tool has been updated to support the limitation of not being able to send a TRUEFilterElement to get all DOM instances in a module.

When definition-level security is enabled, you will now need to first select one or more DOM definitions from a filter menu. This menu is accessible for any DOM manager, so it can also be used to retrieve DOM instances more easily for a specified list of DOM definitions.

#### DataMiner Objects Models: DomInstances CRUD helper now supports reading only a selected subset of fields from `DomInstance` objects [ID 43852]

<!-- MR 10.6.0 - FR 10.6.1 -->

The `DomInstances` CRUD helper now supports reading only a selected subset of fields from `DomInstance` objects. This will reduce the amount of data transferred and can significantly improve performance in cases where clients only need a few fields from each instance.

New `Read` and `PreparePaging` overloads will accept a `SelectedFields<DomInstance>` object. To select a field, add the exposer from `DomInstanceExposers` or add the `FieldDescriptorID` to the `SelectedFields<DomInstance>` object.

> [!NOTE]
>
> - The `Id` is always available on a `PartialObject`. You do not need to add the `Id` exposer to `SelectedFields<DomInstance>`.
> - Selecting the `FieldValues` or `FullObject` exposer is not supported and will result in a failed read operation.

The `Read` and `PreparePaging` methods will return a list of `PartialObject<DomInstance, DomInstanceId>`, which provides:

- `ID`: The `DomInstance` ID.
- `GetValue` and `TryGetValue`, which retrieve the value of a selected exposer or a single-value `FieldDescriptorID`.
- `GetValues` and `TryGetValues`, which retrieve a list of values for a selected `FieldDescriptorID` (for fields with multiple values, or when multiple sections are allowed).

When retrieving field values for a selected `FieldDescriptorID`, the following behavior will apply:

- **Multiple values**: Use `GetValues<T>`/`TryGetValues<T>` to obtain a `List<T>`. `GetValues<T>` throws `InvalidOperationException` if the values are not of type `T`; `TryGetValues<T>` returns `false` in that case.
- **Single value**: Use `GetValue<T>`/`TryGetValue<T>` for fields with a single value. `GetValue<T>` throws `InvalidOperationException` if the value is not of type `T` or when there are multiple values available for that field descriptor; `TryGetValue<T>` returns `false`.
- **No value**: `GetValue<T>` returns `default(T)` (equivalent to an empty list for list types). `TryGetValue<T>` returns `false`. `GetValues<T>` returns `null`. `TryGetValues<T>` returns `false`.

> [!IMPORTANT]
> A `FieldDescriptor` ID must be unique across section definitions in a DOM module.

#### SLNetClientTest tool: Filtering messages using regular expressions [ID 43540]

<!-- MR 10.6.0 - FR 10.5.11 -->

In the *SLNetClientTest* tool, at the bottom of the main window, a new filter box has been added.

After you select the checkbox in front of it, it will allow you to filter the message list using a regular expression.

This new filter box should only be used when no new messages will be added to the list, e.g. when inspecting an *\*.slnetdump* file.

> [!WARNING]
> Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### User-defined APIs: New ResponseHeaders property [ID 43705] [ID 43960]

<!-- MR 10.6.0 - FR 10.5.12 -->

In the `ResponseHeaders` property of the `ApiTriggerOutput` class, you can now specify the HTTP headers that will be added to the response.

Also, the `ApiTriggerOutput` class now allows you to override the contents of the Content-Type header, which is set to "application/json" by default.

Currently, the following headers are blocked, and will result in an error if you try to set them:

- Access-Control-Allow-Origin
- Access-Control-Allow-Credentials
- Access-Control-Expose-Headers
- Access-Control-Allow-Methods
- Access-Control-Max-Age
- Vary
- Content-Length (automatically set)
- Set-Cookie
- WWW-Authenticate
- Proxy-Authenticate
- Transfer-Encoding
- Connection
- Upgrade
- Trailer
- TE
- Via
- Server
- Date (automatically set)
- Strict-Transport-Security

The endpoint can now also return the following additional errors:

| ErrorCode | Integer value | HTTP Status Code | Description |
|-----------|---------------|------------------|-------------|
| ResponseHeadersNotAllowed | 1012 | 500 | The response header or headers you are trying to return are not allowed. |
| ResponseHeadersInvalid | 1013 | 500 | The response header or headers you are trying to return are invalid. Header names and values cannot contain whitespace, colons (":"), commas (","), or ASCII control characters. The *UserDefinableApiEndpoint* logging will contain the exact error. |

#### Interactive Automation scripts executed in a web app: UI version can now be set in the script [ID 43875]

<!-- MR 10.6.0 - FR 10.5.12 -->

Up to now, when you wanted an interactive Automation script executed in a web app to use the new UI version, you had to add `useNewIASInputComponents=true` to the URL of the app.

From now on, it is also possible to indicate the UI version in the script itself. To do so, set the `engine.WebUIVersion` property to one of the following values:

| Value | UI version |
|-------|------------|
| WebUIVersion.Default | Default UI version. At present, this is V1. |
| WebUIVersion.V1      | Current UI version (V1) |
| WebUIVersion.V2      | New UI version (V2)     |

Example:

```csharp
engine.WebUIVersion = WebUIVersion.V2
```

The URL parameter `useNewIASInputComponents` has priority over the UI version set in the script.

- If you use `useNewIASInputComponents=true`, the script will use the new UI version (i.e. V2), even when V1 was set in the script.
- If you use `useNewIASInputComponents=false`, the script will use the current UI version (i.e. V1), even when V2 was set in the script.

> [!IMPORTANT]
> This feature is only supported for interactive Automation scripts executed in web apps. It is not supported for interactive Automation scripts executed in DataMiner Cube.

#### Dashboard reports can now be generated in PDF, HTML, and/or CSV format [ID 43887]

<!-- MR 10.6.0 - FR 10.6.1 -->

Up to now, a report of a dashboard could only be generated in PDF format (.pdf). Now, it is possible to generate a report in PDF, archived HTML format (.mhtml) and/or CSV format.

MHTML files include all necessary information to allow the report to be rendered in a web browser: HTML code, images, CSS stylesheets, etc.

Also, the default file name has been changed from `Report.pdf` to `<dashboard name>.pdf`, `<dashboard name>.mhtml`, or `<dashboard name>.csv.zip`.
