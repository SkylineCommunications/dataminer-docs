---
uid: General_Feature_Release_10.6.3
---

# General Feature Release 10.6.3 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
>
> Before you upgrade to this DataMiner version:
>
> - Make sure **version 14.40.33816** or higher of the **Microsoft Visual C++ x86/x64 redistributables** is installed. Otherwise, the upgrade will trigger an **automatic reboot** of the DMA in order to complete the installation. The latest version of the redistributables can be downloaded from the [Microsoft website](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version):
>
>   - [vc_redist.x86.exe](https://aka.ms/vs/17/release/vc_redist.x86.exe)
>   - [vc_redist.x64.exe](https://aka.ms/vs/17/release/vc_redist.x64.exe)
>
> - Make sure all DataMiner Agents in the cluster have been migrated to the BrokerGateway-managed NATS solution. For detailed information, see [Migrating to BrokerGateway](xref:BrokerGateway_Migration).
>
>   See also: [DataMiner Systems will now use the BrokerGateway-managed NATS solution by default [ID 43856] [ID 43861] [ID 44035] [ID 44050] [ID 44062]](xref:General_Feature_Release_10.6.1#dataminer-systems-will-now-use-the-brokergateway-managed-nats-solution-by-default-id-43856-id-43861-id-44035-id-44050-id-44062)

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.6.3](xref:Cube_Feature_Release_10.6.3).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.6.3](xref:Web_apps_Feature_Release_10.6.3).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

- [DataMiner Object Models: Fine-grained security on instance level [ID 44233]](#dataminer-object-models-fine-grained-security-on-instance-level-id-44233)
- [Protocols: Elements will now restart automatically when an SLScripting process has disappeared [ID 42306]](#protocols-elements-will-now-restart-automatically-when-an-slscripting-process-has-disappeared-id-42306)
- [Protocols: As many SLScripting processes as SLProtocol processes by default [ID 44420]](#protocols-as-many-slscripting-processes-as-slprotocol-processes-by-default-id-44420)

## New features

#### DataMiner Object Models: Fine-grained security on instance level [ID 44233]

<!-- MR 10.6.0 - FR 10.6.3 -->

On top of [DataMiner Object Models: Definition-level security [ID 43380] [ID 43589]](xref:General_Feature_Release_10.5.10#dataminer-object-models-definition-level-security-id-43380-id-43589), which allows you to grant user groups access to all DOM instances of a DOM definition, it is now also possible to allow user groups access to an individual DOM instance based on whether that DOM instance contains at least one of a specified set of values for a specified FieldDescriptor.

For example, the user group *London employees* will only be able to read the "Job" instances where the *Assigned office* field (i.e. a `DomInstanceFieldDescriptor`) contains the ID of the DOM instance for the London office.

##### Limitations

This instance-level security filtering is applied in the database, which can contain DOM definitions with millions of DOM instances.

However, there are a number of limitations:

- You can only define a maximum of 10 values per FieldDescriptor.

- For a particular DOM definition, you can only specify one condition per user group.

- When a user is a member of multiple user groups, and several of those groups have conditions for a certain DOM definition, then the condition of the user group that comes first (alphabetically) will be used.

  It is recommended that you avoid these situations by defining and using the user groups in such a way that there are no overlaps.

  > [!NOTE]
  > If users are a member of a user group with full definition-level access, this definition-level access will take precedence over any limited access of other groups they are a member of.

- When reading DOM instances, the filter is only allowed to search within one specific DOM definition. If it searches across multiple DOM definitions, and the user does not have full definition-level access to all of those definitions, the request will fail, even if the user is a member of a user group that has conditional access. If the request fails, the following error message will be thrown: `Make sure the user has full access to all queried DOM definitions`.

- Ideally, the filter should not contain more than 100 OR clauses.

##### Defining the conditional access

To configure that a user group has limited access, you can add a `FieldValueReference` to the `GroupLink` class.

A `FieldValueReference` contains the following data objects:

- DomDefinitionId (Guid): The ID of the DOM definition
- FieldDescriptorId (Guid): The ID of the FieldDescriptor
- List of allowed FieldDescriptor values (to be set via the corresponding constructor)

Currently supported FieldDescriptors:

| FieldDescriptor | Descriptor Type | Referenced Value Collection Type |
|---------|---------|---------|
| DomInstanceFieldDescriptor      | `Guid` OR `List<Guid>` | `List<Guid>` |
| DomInstanceValueFieldDescriptor | `Guid` OR `List<Guid>` | `List<Guid>` |
| GenericEnumFieldDescriptor      | `GenericEnum<int>` OR `List<GenericEnum<int>>`       | `List<int>`    |
| GenericEnumFieldDescriptor      | `GenericEnum<string>` OR `List<GenericEnum<string>>` | `List<string>` |

The `FieldValueReference` class also has a number of methods that can be used to retrieve the (number of) referenced values:

- `GetValuesCount()`: Returns the number of referenced values.
- `GetValuesType()`: Returns an enum value of `FieldValueReferenceTypes` that represents whether the `FieldValueReference` in question contains a list of Guid, string, or int values.
- `GetValues<T>`: Returns the actual values. To this method, you have to pass the correct type as returned by the `GetValuesType()` method.

When `FieldValueReference` values are saved in the `ModuleSettings`, the following validation checks will be executed:

- Check if there are any IDs that are equal to Guid.Empty. If empty IDs are detected, a `DomManagerSettingsErrorData` error will be returned with reason `DomSecurityFieldValueReferenceHasInvalidIds`.
- Check if the list of values is not empty. If the list is empty, a `DomManagerSettingsErrorData` error will be returned with reason `DomSecurityFieldValueReferenceHasNoValues`.
- Check if the list of values does not contain more than 10 items. If the list contains more than 10 items, a `DomManagerSettingsErrorData` error will be returned with reason `DomSecurityFieldValueReferenceHasTooManyValues`.

In all errors listed above, the `ErrorData` properties `GroupName` and `DomDefinitionId` can be used to find out which references are invalid. The third error also contains a `Limit` property that contains the max number of values (i.e. 10).

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

If scheduled tasks are stored in the database, you can use an Automation script to initiate the swarming process.

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

## Changes

### Breaking changes

#### Protocols: As many SLScripting processes as SLProtocol processes by default [ID 44420]

<!-- MR 10.7.0 - FR 10.6.3 -->

Up to now, one SLScripting process was used by default. From now on, by default, there will be as many SLScripting processes as SLProtocol processes.

Note that is possible to configure the number of simultaneously running SLScripting processes. See [Setting the number of simultaneously running SLScripting processes](xref:Configuration_of_DataMiner_processes#setting-the-number-of-simultaneously-running-slscripting-processes).

> [!IMPORTANT]
> If you are using multiple SLScripting processes, it is important that elements running the same protocol are not sharing/exchanging data with each other through static fields. More information can be found in the [QAction documentation](xref:LogicQActions#sharing-and-persisting-data).

### Enhancements

#### Protocols: Elements will now restart automatically when an SLScripting process has disappeared [ID 42306]

<!-- MR 10.6.0 - FR 10.5.5 >>> Published in 10.7.0 - FR 10.6.3 together with 44420 -->

Up to now, when an SLScripting process disappeared, elements relying on that process could become unstable, requiring manual intervention to restore functionality.

From now on, when an SLScripting process disappears, a new process instance will be started automatically, and any elements that depended on the process that disappeared will be restarted to maintain consistency across SLProtocol, SLScripting, and other related components. This will ensure that lost SLScripting data is properly reinitialized and remains in sync with other processes.

When an SLScripting process disappears, the following notice alarm will be generated:

`Process disappearance of SLScripting.exe with PID <processId>; <x> elements affected by the disappearance have been restarted.`

Also, the *SLElementsInProtocol.txt* log file has been updated to track restart reasons more accurately.

- The restart reason column will now indicate either "SLScriptingCrashRestart" or "SLProtocolCrashRestart" (if everything is OK, *NormalStart* will be shown instead).
- A new counter will now indicate the number of times the element was started due to a SLScripting process disappearance.

If SLProtocol requests an SLScripting process that is no longer valid, the system will now detect this, and trigger the same element restart flow.

> [!NOTE]
> There will be a one-minute delay between the disappearance of an SLScripting process and the creation of a new SLScripting process and the subsequent element restarts. However, when one of the elements that was hosted in the SLScripting process that disappeared tries to trigger a QAction within that one-minute delay, the new SLScripting process will be created when that QAction is triggered.

> [!IMPORTANT]
> For this feature to work, make sure the number of simultaneously running SLScripting processes is not set to 1. If set to 1, then no new SLScripting process will be started automatically when an SLScripting process disappears. See [Setting the number of simultaneously running SLScripting processes](xref:Configuration_of_DataMiner_processes#setting-the-number-of-simultaneously-running-slscripting-processes).

#### New parameter caches for client apps [ID 43945]

<!-- MR 10.7.0 - FR 10.6.3 -->

Two new parameter caches are now available for client apps (e.g. DataMiner Cube):

- ProtocolParameters (linked to GetProtocolParameter on the client connection)
- ElementProtocolParameters (linked to GetElementProtocolParameter on the client connection)

Both caches are added on the connection object, and have the ability to cache in memory (for the current session) and on disk (for a next session).

#### Enhanced visibility on SLNet connection issues [ID 44069]

<!-- MR 10.7.0 - FR 10.6.3 -->

Visibility on SLNet connection issues has been enhanced:

- When a dashboard cannot be loaded because a DataMiner Agent is offline, an appropriate error message will now appear in that dashboard.

- A new log file named *SLNetConnectionsMonitor.txt* will now keep a historic record of all SLNet connection states.

#### SLNet will now take into account the log level before sending a log entry to SLLog [ID 44314]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

Up to now, SLNet would incorrectly send all log entries directly to SLLog, including entries of which the log level dictated that they should not be added to a log file.

From now on, SLNet will only send a log entry to SLLog if the log level dictates that the entry should be logged. As a result, overall performance will increase when adding entries to log files.

#### An error will now be logged if the response to an SNMP Get request cannot be mapped [ID 44329]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

If the response to an *SNMP Get* request cannot be mapped, from now on, an error will be logged in the log file of the element in question and in the *SLErrorsInProtocol.txt* file.

#### .dmprotocol packages included in DELT export packages will now also contain all assemblies used by the connectors in those .dmprotocol packages [ID 44345]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

From now on, *.dmprotocol* packages included in DELT export packages will also contain all assemblies used by the connectors in those *.dmprotocol* packages.

#### Factory reset tool: Actions that stop and stop DcMs and DxMs will now have a 15-minute timeout [ID 44387]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

The factory reset tool *SLReset.exe* can be used by an administrator to fully reset a DataMiner Agent to its default state from immediately after installation.

One of the actions performed by this tool when resetting a DMA is stopping and starting the DcMs and DxMs. Up to now, the DcMs and DxMs would be stopped and started without any timeout. From now on, the stop and start actions will have a 15-minute timeout.

Also, if an exception would be thrown during a stop action, a kill command will be executed instead.

#### DataMiner backup: 'Ticketing Gateway Configuration' removed from the list of backup options [ID 44401]

<!-- MR 10.7.0 - FR 10.6.3 -->

As the Ticketing app is End of Life as of DataMiner 10.6.x, *Ticketing Gateway Configuration* has now been removed from the list of backup options.

#### Ticketing app End of Life [ID 44417]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

DataMiner Ticketing has been declared End of Life. As a result, all server code related to Ticketing has been removed.

#### Security Advisory BPA test: Enhancements [ID 44444] [ID 44477] [ID 44566]

<!-- MR 10.5.0 [CU12] / 10.6.0 [CU0] - FR 10.6.3 -->

A number of enhancements have been made to the Security Advisory BPA test:

- Up to now, the *Local admin hygiene* test would verify whether the local admin account was disabled and whether there were not too many local administrator accounts. From now on, this test will no longer be performed as the recommendations in the [hardening guide](https://aka.dataminer.services/HardeningGuide) have been updated.

- The HTTP header test will now also check whether the referrer-policy header is set.

- A new test was added that will check the *versionhistory.txt* file to find out whether a system upgrade was performed in the last 6 months.

  If the contents of the *versionhistory.txt* file cannot be read, the test will check when that file was last updated, and if that also fails, it will check when the *SLNet.exe* file was last updated.

Also, the following issues have now been fixed:

- The *gRPC* test will now properly take the default configuration into account. Up to now, this test would assume gRPC was disabled when not configured. From DataMiner feature release 10.5.10, gRPC is enabled by default, causing the test to report a false positive.

- On systems where the `enableLegacyV0Interface` flag is not set in the *web.config* file, the test that verifies whether the v0 web API is disabled would incorrectly assume that the v0 web API was enabled. From now on, when the `enableLegacyV0Interface` flag is not set in the *web.config* file, the v0 web API will be considered disabled.

#### APIGateway now has a dedicated log file [ID 44469]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

Up to now, APIGateway would send its log entries to the Microsoft Event Viewer. Now, a dedicated APIGateway log file has been added in `C:\ProgramData\Skyline Communications\DataMiner APIGateway\Logs`.

- When the current log file reaches its maximum size of 5 MB, a new log file will be started. Up to 2 files will be kept.
- The configuration of the log file can be adjusted using an `appsettings.custom.json` file. Copy the contents of the `appsettings.json` file to the `appsettings.custom.json` file, and change the necessary values.

#### SLAnalytics: Enhanced resilience during startup [ID 44476]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

Because of a number of enhancements, from now on, SLAnalytics will be more resilient when starting up.

From now on, when an issue occurs during startup, in most cases, SLAnalytics will add an entry describing the issue to the SLAnalytics log file, and will keep on working.

#### BPA test 'Cube CRL Freeze': Enhanced performance [ID 44479] [ID 44616]

<!-- RN 44479: MR 10.4.0 [CU21] / 10.5.0 [CU12] / 10.6.0 [CU0] - FR 10.6.3 -->
<!-- RN 44616: MR 10.4.0 [CU21] / 10.5.0 [CU12] / 10.6.0 [CU0] - FR 10.6.3 -->

Because of a number of enhancements, overall performance of the the *Cube CRL Freeze* BPA test has increased.

This BPA test will identify client machines and DataMiner Agents without internet access where the DataMiner Cube application experiences a significant freeze during startup. This freeze is caused by the system attempting to verify the application's digital signatures with online Certificate Revocation Lists (CRLs).

#### Interactive Automation scripts launched from web apps: UI components Time and Calendar can now all display seconds [ID 44487]

<!-- MR 10.6.0 - FR 10.6.3 -->

Up to now, in interactive Automation scripts launched from web apps, only the `UIBlockType.Time` component with `AutomationTimeUpDownOptions` had the ability to show seconds. From now on, all the following `UIBlockType.Time` components, as well as the `UIBlockType.Calendar` component, will also have that ability. Their option classes will now all have a `ShowSeconds` property, which will be set to false by default.

- `UIBlockType.Time` with `AutomationDateTimePickerOptions`
- `UIBlockType.Time` with `AutomationDateTimeUpDownOptions`
- `UIBlockType.Time` with `AutomationTimePickerOptions`
- `UIBlockType.Calendar` with `AutomationCalendarOptions`

#### GQI: Domain user name will now be included in the OnInitInputArgs of a GQI extension [ID 44509]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

Up to now, for a GQI extension (i.e. an ad hoc data source or a custom operator) to be able to retrieve the username of the user who launched the query, an additional connection had to be set up, which could cause overall performance of the extension to decrease.

From now on, the `OnInitInputArgs` will include a `Session` object that will contains the domain user name of the user who launched the query.

#### Interactive Automation scripts in web apps: New UsePreviousCollapsedState property will allow tree nodes to restore their IsCollapsed state when the UI is updated [ID 44515]

<!-- MR 10.6.0 - FR 10.6.3 -->

When, in an interactive Automation script, a TreeView control was used with the `SupportsLazyLoading` option set to false, up to now, each time the UI was updated, all tree nodes would revert their expanded state back to the `IsCollapsed` setting.

Tree nodes now have a new `UsePreviousCollapsedState` property. By default, this property will be set to false. When set to true, each time the UI is updated, the previous `IsCollapsed` state of the tree node in question will be restored. If no previous `IsCollapsed` state is available, the current `IsCollapsed` state will be applied.

#### SLManagedScripting will again add a log entry each time it has loaded or failed to load an assembly [ID 44522]

<!-- MR 10.5.0 [CU12] / 10.6.0 [CU1] - FR 10.6.3 -->

Since DataMiner version 10.4.0 [CU18]/10.5.0 [CU6]/10.5.9<!-- RN 43690 -->, SLManagedScripting no longer added an entry in the *SLManagedScripting.txt* log file each time it had loaded or failed to load an assembly. From now on, it will again do so.

These log entries will include both the requested version and the actual version of the assembly.

#### SLNet messages GetLiteElementInfo, GetLiteServiceInfo, and GetLiteRedundancyGroupInfo now support filtering by HostingAgentID [ID 44537]

<!-- MR 10.6.0 - FR 10.6.3 -->

The following SLNet messages, which can be used to retrieve information about elements, services, and redundancy groups, now also support filtering by HostingAgentID. This allows you to e.g. retrieve a list of all elements that are being hosted on a particular DataMiner Agent.

- GetLiteElementInfo
- GetLiteRedundancyGroupInfo
- GetLiteServiceInfo

#### Migrating booking data from Cassandra Single to indexing database is no longer supported [ID 44550]

<!-- MR 10.5.0 [CU12] / 10.6.0 [CU0] - FR 10.6.3 -->
<!-- Not added to MR 10.5.0 [CU12] -->

From now on, it will no longer be possible to migrate booking data from a Cassandra database per DMA to an indexing database.

Up to now, in DataMiner Cube, the *Migrate booking data to Indexing Engine*, found in *System Center > Search & Indexing*, allowed you to migrate older booking data (i.e. from prior to DataMiner 10.0) stored in a Cassandra database per DMA to the indexing database. From now on, when Cube is connected to a DMA running DataMiner 10.6.0 [CU0]/10.6.3 or newer, this option will no longer be available.

#### DataMiner backup: Scheduler configuration will now be included in full and configuration backups [ID 44584]

<!-- MR 10.7.0 - FR 10.6.3 -->

From now on, the Scheduler configuration found in `C:\Skyline Dataminer\Scheduler` will be included in the following pre-configured backups:

- Full backup (without database)
- Configuration backup (without database)

If you create a custom backup, the Scheduler configuration will be included only if you selected the *DataMiner settings* option.

#### Scheduler: Enhanced logging when a Windows task cannot be found and needs to be recreated [ID 44587]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

If, at DataMiner startup, the scheduled task configured for the DMA could not be found in the Windows Task Scheduler, up to now, SLScheduler would log a message like the following one:

```console
Failed to get info for task 1 [BTT: Cassandra Backup]: Failed to get info for task 'Skyline DataMiner Scheduled Task 1': 0x80070002h The system cannot find the file specified.
```

This message would incorrectly not indicate whether the task was missing in the Windows Task Scheduler or whether an issue had occurred while verifying it. Also, it would be unclear whether DataMiner would recreate the scheduled task.

From now on, when a task cannot be found in the Windows Task Scheduler and needs to be recreated, more detailed information will be added to the *SLScheduler.txt* log file. See the example log entry below:

```console
Failed to get MS task for Scheduler task 321/2 [Task 1]: (Task 'Skyline DataMiner Scheduled Task 321-2' not found in MS Task Scheduler). MS Task will be recreated.
Task 321/2 [Task 1] successfully added to MS Task Scheduler
```

### Fixes

#### Numeric cell would incorrectly not be cleared when its exception value was set to 0 [ID 44356]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

When a numeric cell had its exception value set to 0, up to now, it would incorrectly not be possible to clear that cell by setting its value to null or by using the `protocol.clear` property. When an attempt was made to clear the cell or to set its value to null, the cell would incorrectly show its exception value instead of the word "Uninitialized".

Also, in some cases, an exception would be displayed even when it had a type other than the parameter for which it had been defined. For example, an exception value of type string defined for a parameter of type double.

For more information, see [Exceptions element](xref:Protocol.Params.Param.Interprete.Exceptions). The `Exceptions` tag should only be used to intercept values of the same `Interprete.Type` as that of your parameter. If you want to intercept values of another type, then you should use the `Protocol.Params.Param.Interprete.Others` tag instead.

#### MessageBroker: Problem with hostnames and FQDNs containing a certain combination of dashes and characters [ID 44433]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

Up to now, hostnames and FQDNs in the *MessageBrokerConfig.json* file would incorrectly be considered invalid when they contained a certain combination of dashes and characters.

Examples of hostnames that were incorrectly considered invalid:

- Hostnames that start with one letter or number, followed by a dash. E.g. `a-agent`, `h-hostname`, etc.
- Full IPv6 addresses like `[2001:0db8:85a3:0000:0000:8a2e:0370:7334]`
- Shortened IPv6 addresses like `[::1]`

#### DaaS: Short-lived alarms without operational impact would appear immediately after the 'My DataMiner Agent' element had been created [ID 44440]

<!-- MR 10.6.0 - FR 10.6.3 -->

On a newly created DaaS system, up to now, short-lived alarms without operational impact could appear immediately after the *My DataMiner Agent* element had been created.

In the alarm template of the *My DataMiner Agent* element, hysteresis has now been tweaked to prevent such alarms from appearing on newly created DaaS systems.

#### GQI: Problem with Timer callbacks could cause SLHelper to stop working [ID 44458]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

In some cases, exceptions could be thrown in the callback of System.Threading.Timer, causing the SLHelper process to stop working.

See also: [GQI DxM: Problem with Timer callbacks could cause the GQI DxM to stop working [ID 44460]](xref:Web_apps_Feature_Release_10.6.3#gqi-dxm-problem-with-timer-callbacks-could-cause-the-gqi-dxm-to-stop-working-id-44460)

#### Event message would return the object twice in case of two subscriptions to the same object [ID 44486]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

When, on the same connection, there were two subscriptions to the same object, in some cases, that object would incorrectly be returned twice in the event message.

#### SLA would degrade after an element had been restarted [ID 44490]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

When an element was restarted, and that element had alarms with service impact that were being tracked by an SLA, in some cases, the SLA would degrade when one of those alarms no longer affected the SLA.

#### Elements: Clicking 'Test connection' while adding or editing an element could cause SLProtocol to stop working [ID 44514]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

If, while adding or editing an element based on a connector that had an additional thread specified, you clicked *Test connection*, in some cases, SLProtocol could stop working.

#### SLAnalytics - Behavior anomaly detection: Anomaly significance of anomalous change points would incorrectly be set to zero [ID 44585]

<!-- MR 10.6.0 - FR 10.6.3 -->

Up to now, in some cases, the anomaly significance of change points that are marked anomalous due to crossing a user-configured threshold in the alarm template would incorrect remain set to zero.

From now on, the anomaly significance of these change points will correctly be set to a high value.

> [!NOTE]
> When you use the *Get behavioral change events* data source to retrieve change points, the anomaly significance of theses change points can be found in the *Anomaly significance* column.
