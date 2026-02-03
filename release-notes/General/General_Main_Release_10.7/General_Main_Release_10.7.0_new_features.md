---
uid: General_Main_Release_10.7.0_new_features
---

# General Main Release 10.7.0 – New features - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## Highlights

*No highlights have been selected yet.*

## New features

#### Service & Resource Management: New PatchReservationInstanceProperties method to update properties of a reservation instance [ID 44084]

<!-- MR 10.7.0 - FR 10.6.1 -->

The ResourceManagerHelper now contains a new `PatchReservationInstanceProperties` method. This method can be used to update properties of a reservation instance.

See the following example:

```csharp
Guid bookingId = ...; 
var propertiesToPatch = new JSONSerializableDictionary();
propertiesToPatch.AddOrUpdate("Key to update", "New value");

var result = rmHelper.PatchReservationInstanceProperties(bookingId, propertiesToPatch);

if (result.UpdatePropertiesResult != UpdatePropertiesResult.Success)
{
    // Handle failure
}
else
{
    // Call returns the booking with the updated properties
    var booking = result.UpdatedInstance;
}
```

> [!NOTE]
>
> - Only the properties passed to the `propertiesToPatch` dictionary will be updated.
> - The result of the property update will contain the updated booking with all its properties (including those that were not updated).
> - This new method does not allow you to removed properties from a reservation instance.

#### User-defined APIs are now capable of returning bytes instead of a string [ID 44158]

<!-- MR 10.7.0 - FR 10.6.1 -->

User-defined APIs are now capable of returning bytes instead of a string.

The `ApiTriggerOutput` class now has a `ResponseBodyBytes` property of type byte[], which, when set, will take precedence over `ResponseBody` of type string. Both `ResponseBodyBytes` and `ResponseBody` are limited to 29 MB.

By default, a Content-Type header of type `application/octet-stream` will be returned. If necessary, this can be overridden by means of the `Headers` property in `ApiTriggerOutput`.

> [!NOTE]
>
> - `TriggerUserDefinableApiRequestMessage` is now also capable of returning bytes.
> - When a user-defined API being tested in the SLNetClientTest tool returns bytes, the following message will appear: "Response body is in bytes and cannot be displayed".

#### Automation: New message to retrieve information about the available Automation scripts [ID 44209]

<!-- MR 10.7.0 - FR 10.6.2 -->

A new `GetAvailableAutomationScriptsRequestMessage` now allows you to retrieve the following information about each Automation script available in the DataMiner System:

- The folder containing the script's XML file.
- Whether or not the script supports a dedicated log file.

> [!NOTE]
> The above-mentioned message can only be used on systems with an *Automation* license by users who have the following permissions:
>
> - *Modules > Automation > UI available*
> - *Modules > Automation > Execute*

#### SLNet subscription logging [ID 44361]

<!-- MR 10.7.0 - FR 10.6.3 -->

In the *SLNetClientTest* tool, you can now specify that all SLNet subscription events have to be logged in the *SLSubscriptionLog.txt* log file.

To activate SLNet subscription event logging, do the following:

1. Open the *SLNetClientTest* tool, and connect to the DataMiner Agent.

1. Open the *Advanced* menu, and select *Options* > *SLNet options*.

1. Open the *Option values for* selection box, and select "SubscriptionLogOptions".

   You will see a list of all DMAs in the cluster. For each of those DMAs, the list will show whether the selected option is active, and what options are set.

1. In the *Value* column, right-click the value you want to edit, and select *Edit value*.

1. In the edit box, add or update the necessary options, and click *OK*. For a list of available options, see below.

##### Event type and cache key filtering

The entries in the *SLSubscriptionLog.txt* log file can be filtered by event type (e.g. *ParameterChangeEventMessage*) and/or cache key (e.g. DataMinerID/ElementID/ParameterID). To do so, you have to provide a value with a *filter=* prefix. If you want to provide multiple values, they have to be separated by a semicolon (";").

Options for filtering by event type:

| Option | Event type |
|--------|------------|
| element   | *ElementInfoEventMessage*     |
| alarm     |  *AlarmEventMessage*          |
| dma       | *DataMinerExtendedStateEvent* |
| parameter | *ParameterChangeEventMessage* |
| alarmfocusevent      | *Skyline.DataMiner.Analytics.AlarmFocus.AlarmFocusEvent*  |
| radgroupinfoevent    | *Skyline.DataMiner.Analytics.Rad.RadGroupInfoEvent*       |
| stateiconchangeevent | *Skyline.DataMiner.Analytics.Arrows.StateIconChangeEvent* |

Apart from the above-mentioned options, you can also use any other message type from the *Skyline.DataMiner.Net.Messages* namespace.

Formats for filtering by cache key:

- HostingDataMinerID/DataMinerID/ElementID/ParameterID
- DataMinerID
- DataMinerID/ElementID
- DataMinerID/ElementID/ParameterID

These filtering options are saved in the `<SLNet>` section of the *MaintenanceSettings.xml* file, in an element named `<SubscriptionLogOptions>`. The contents of this element are not synchronized across the DMAs in the cluster.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### Swarming scheduled tasks [ID 44620]

<!-- MR 10.7.0 - FR 10.6.3 -->

Scheduled tasks can now be swarmed between Agents in the cluster, but only when those tasks are stored in a database. Therefore, if you want to allow your scheduled tasks to be swarmed, you should first migrate them from *Schedule.xml* to a database ([STaaS](xref:STaaS) or [dedicated clustered storage](xref:Dedicated_clustered_storage)).

You can identify the Agent that is currently hosting a scheduled task by checking the *ExecutingDmaId* property on the task. This value is displayed in the Scheduler module in Cube in the *DataMiner* column. If you want the task to run on a different Agent, you can swarm it to another Agent in the cluster.

During the swarming process, DataMiner removes the task from the Microsoft Task Scheduler on the current hosting Agent. This means the task will not be triggered while swarming is in progress. Once the task has been swarmed, the task will be recreated on the new hosting Agent, and it will be executed at its next scheduled runtime.

For more information, see:

- [Scheduler data storage](xref:SchedulerDataStorage)
- [Configuring a script to swarm scheduled tasks](xref:SwarmingScriptScheduledTask)
