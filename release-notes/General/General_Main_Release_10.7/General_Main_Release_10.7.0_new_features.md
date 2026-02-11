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

#### Automation: New message to retrieve information about the available automation scripts [ID 44209]

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

#### New BPA test: Detect unsupported connector versions [ID 44607]

<!-- MR 10.7.0 - FR 10.6.4 -->

From now on, a new BPA test named *Detect unsupported connector versions* will run every day to check for elements that are using connector versions that have been removed from the Catalog.

When a connector version is removed from the Catalog, this means that it is no longer supported by Skyline Communications. Using unsupported connector versions can lead to compatibility issues, lack of support, and potential security vulnerabilities. It is important to regularly check for unsupported connector versions and update them to supported versions to ensure optimal performance and security of the system.

#### Swarming scheduled tasks [ID 44620]

<!-- MR 10.7.0 - FR 10.6.3 -->

Scheduled tasks can now be swarmed between Agents in the cluster, but only when those tasks are stored in a database. Therefore, if you want to allow your scheduled tasks to be swarmed, you should first migrate them from *Schedule.xml* to a database ([STaaS](xref:STaaS) or [dedicated clustered storage](xref:Dedicated_clustered_storage)).

You can identify the Agent that is currently hosting a scheduled task by checking the *ExecutingDmaId* property on the task. This value is displayed in the Scheduler module in Cube in the *DataMiner* column. If you want the task to run on a different Agent, you can swarm it to another Agent in the cluster.

During the swarming process, DataMiner removes the task from the Microsoft Task Scheduler on the current hosting Agent. This means the task will not be triggered while swarming is in progress. Once the task has been swarmed, the task will be recreated on the new hosting Agent, and it will be executed at its next scheduled runtime.

##### Checking the current storage type

The storage type used for a specific DMA is shown in the Scheduler configuration file `C:\Skyline DataMiner\Scheduler\Config.xml`. The `Storage` value will either be set to "Xml" or "Database".

If this configuration file is missing, scheduled tasks default to XML storage. Newly installed DataMiner Agents also by default use XML storage.

If you want to switch from XML to database storage, do not adjust this directly in this file. Instead, use the migration procedure detailed below.

##### Migrating from XML to database storage

You can migrate the scheduled tasks from *Schedule.xml* to a database ([STaaS](xref:STaaS) or [dedicated clustered storage](xref:Dedicated_clustered_storage)) using the SLNetClientTest tool.

1. Open the SLNetClientTest tool and connect to the DMS.
1. From the *Advanced* menu, select *Migration*.
1. In the *Scheduler XML to database* section, click the *Start Migration* button to launch the migration wizard.

   - During migration, no scheduled tasks will be triggered, but tasks that are already running will continue to run. However, we recommend not starting a migration while tasks are still running.
   - A window will show the migration actions that have been scheduled. If you close this window, the migration will continue in the background.
   - You can cancel the migration process at any time by clicking the *Cancel Migration* button.
   - The progress of the migration will be shown in the *MigrationStatus* table in SLNetClientTest tool, where a row will be created for each Agent in the cluster where the scheduled tasks will be migrated.
   - If one of the DataMiner Agents in the cluster cannot be reached for some reason, the migration will be canceled.
   - Once the migration is complete on all Agents, the storage will automatically switch from XML to database, and incoming messages will be unblocked.

If the migration fails for any reason, the migration status object in the SLNetClientTest tool window will get a red background color. The *SLMigrationManager.txt* and *SLScheduler.txt* log files will contain more information. Scheduler Manager will not switch the configuration, so XML storage will still be used after a failed migration.

If a *MigrationStatus* is stuck in the *InProgress* state, you will need to cancel the migration to make all Scheduler Manager instances start or to trigger the migration again. You can do so with the *Cancel Migration* button in the *Scheduler XML to database* section of the SLNetClientTest tool window.

> [!NOTE]
>
> - Scheduler will be restarted during the migration.
> - Incoming requests to the Scheduler Manager will be blocked while the migration is in progress.

> [!WARNING]
> Always be extremely careful when using SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

##### Configuring a script to swarm scheduled tasks

If scheduled tasks are stored in the database, you can use an automation script to initiate the swarming process.

In this script, create a SwarmingHelper using the new hosting Agent ID along with the scheduled task IDs. See the following example.

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
        var newHostingAgent = 123;

        var scheduledTaskIds = new List<ScheduledTaskID>
        {
            // DmaId, TaskId
            new ScheduledTaskID(..., ...),
            new ScheduledTaskID(..., ...),
        };

        var swarmingResults = SwarmingHelper.Create(engine.GetUserConnection()).SwarmScheduledTasks(scheduledTaskIds.ToArray()).ToAgent(newHostingAgent);

        if (swarmingResults == null)
        {
            engine.ExitFail("Swarming failed: result was null");
        }

        // There should be a result for each scheduled task.
        if (swarmingResults.Length != scheduledTaskIds.Count)
        {
            var sentIds = string.Join(", ", scheduledTaskIds
                    .OrderBy(t => t.DmaId)
                    .ThenBy(t => t.TaskId)
                    .Select(t => $"{t.DmaId}/{t.TaskId}"));


            // 'ToString' of a SwarmingResult will contain the ID of the object, the message and whether swarming succeeded for the object or not.
            var results = string.Join(", ", swarmingResults.Select(s => s.ToString()));

            engine.ExitFail($"Did not receive enough swarming responses. Requested to swarm {scheduledTaskIds.Count} scheduled tasks, but got {swarmingResults.Length} responses.{Environment.NewLine}" +
                            $"Sent ids: {sentIds}{Environment.NewLine}Results: {results}");
        }

        var unsuccessfulResults = swarmingResults.Where(s => !s.Success).ToList();
        if (unsuccessfulResults.Count > 0)
        {
            var failedScheduledTasks = string.Join(", ", unsuccessfulResults.Select(s => s.ToString()));
            engine.ExitFail($"Failed to swarm some scheduled tasks. Failed results: {failedScheduledTasks}");
        }
    }
}
```

> [!NOTE]
>
> - To swarm a scheduled task, the new hosting Agent must be up and running. In case the current hosting Agent is unreachable, swarming will still take place, but an error will be logged in the *SLScheduler* log file.
> - To be able to trigger swarming for a scheduled task, you need the *Modules > Swarming* user permission.
