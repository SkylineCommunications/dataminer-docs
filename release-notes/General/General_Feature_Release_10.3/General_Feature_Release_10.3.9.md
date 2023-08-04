---
uid: General_Feature_Release_10.3.9
---

# General Feature Release 10.3.9 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
> When downgrading from DataMiner Feature Release version 10.3.8 (or higher) to DataMiner Feature Release version 10.3.4, 10.3.5, 10.3.6 or 10.3.7, an extra manual step has to be performed. For more information, see [Downgrading a DMS](xref:MOP_Downgrading_a_DMS).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.3.9](xref:Cube_Feature_Release_10.3.9).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.3.9](xref:Web_apps_Feature_Release_10.3.9).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

#### SLProtocol is now a 64-bit process by default [ID_36725]

<!-- MR 10.4.0 - FR 10.3.9 -->

SLProtocol is now a 64-bit process by default.

However, if necessary, it can still be run as a 32-bit process. For more information, see [Activating SLProtocol as a 32-bit process](xref:Activating_SLProtocol_as_a_32_Bit_Process).

## Other features

#### DataMiner Object Models: Caching of DOM configuration data [ID_36412]

<!-- MR 10.4.0 - FR 10.3.9 -->

In each DOM manager,the `DomDefinition`, `DomBehaviorDefinition` and `SectionDefinition` objects will now be fully cached.

These caches are enabled by default, also for existing DOM managers. When a DOM manager is initialized, all above-mentioned configuration objects will be stored into the caches. Depending on the amount of data, this could lead to the first request taking some more time.

##### Disabling the caches

Since the caches rely on synchronization, which requires a stable connection, an option was added to disable the caches if too many issues would arise on unstable clusters. You can configure the caching behavior per object type in the `ModuleSettings.DomManagerSettings.DomManagerSettings.StorageSettings.CachingSettings` object. Using the `DomConfigCachingPolicy` enum, you can set the caching behavior to one of the following options:

- *Default*: The default caching option, which is currently equal to the *Full* option.
- *Disabled*: Disables caching for the object type in question.
- *Full*: Enables full caching for the object type in question.

> [!IMPORTANT]
> If you modify these settings, you need to re-initialize the DOM manager.

##### Synchronization

Among the agents in a DMS, the caches will stay in sync thanks to the events sent by all the DOM managers on the different agents. If, for some reason, the caching would get out of sync, this will automatically be fixed during the midnight sync, which will cause the caches to be reloaded from the database. During that cache reload, the DOM managers will remain available.

If you want to ensure that the caches are in sync with the database, you can manually send a `ManagerStoreMidnightSyncCustomManagerRequest`. This will refresh all caches on all running instances of a DomManager with a given ID across the DMS. To do so, open a DomManager in the *SLNetClientTest* tool, go to the *Maintenance* tab, and click the refresh button.

##### Logging

In the log files, you will be able to find out which caches are enabled and when they have been refreshed (either during a midnight sync or a user-initiated sync). Also, after a refresh, a log entry will be added, mentioning the number of objects that were added, updated, ignored and removed in the cache.

##### Impact on paging

When the caches are enabled, it is no longer possible to get paged results when retrieving DomDefinitions, DomBehaviorDefinitions or SectionDefinitions. Instead, the complete list of objects matching the given query will be returned, even if that list is larger than the configured page size.

#### DataMiner Object Models: GroupFieldDescriptor and UserFieldDescriptor now have drop-down support [ID_36556]

<!-- MR 10.4.0 - FR 10.3.9 -->

From now on, the form component will render the `GroupFieldDescriptor` and `UserFieldDescriptor` as filterable drop-down boxes.

- Fields defined as `GroupFieldDescriptor` will display the group name and use that same group name as value.

- Fields defined as `UserFieldDescriptor` will display the full name of the user, but will store the user name as value.

  When the field descriptor defines any group names, the drop-down box will only list the users belonging to those groups.

> [!NOTE]
> Up to now, only users with *Modules > System configuration > Security > UI available* permission were allowed to view the list of DataMiner users. From now on, even users without *Modules > System configuration > Security > UI available* permission will at least be able to view the list of DataMiner users who are a member of any of the groups they themselves are a member of.

#### DataMiner Object Models: Soft-deletable objects [ID_36721]

<!-- MR 10.4.0 - FR 10.3.9 -->

The following DOM objects can now be soft-deleted:

- [FieldDescriptor](xref:DOM_SectionDefinition#fielddescriptor)
- [SectionDefinitionLink](xref:DomDefinition#sectiondefinitionlink)
- [DomStatusSectionDefinitionLink](xref:DOM_status_system#configuring-fields)

When the fields linked to a soft-deleted `FieldDescriptor` or part of a soft-deleted `SectionDefinitionLink` or `DomStatusSectionDefinitionLink` are marked as *IsSoftDeleted*, the following applies:

- The fields will not be shown in a UI form.
- The fields are not validated when the `SectionDefinition`, `DomDefinition`, or `DomBehaviorDefinition` is updated.
- The fields are never be required.
- Values are allowed to exist in the fields on a `DomInstance` for a soft-deleted `FieldDescriptor`, `SectionDefinitionLink`, or `DomStatusSectionDefinitionLink`.
- Updating a `DomInstance` with new/updated values will be blocked for a field that has a soft-deleted `FieldDescriptor`, or is part of a soft-deleted `SectionDefinitionLink` or `DomStatusSectionDefinitionLink` (for that status). A [ValueForSoftDeletedFieldNotAllowed error](xref:DomInstance#errors) will be returned.

#### Reinitializing ResourceManager [ID_36811]

<!-- MR 10.4.0 - FR 10.3.9 -->

You can now (re)initialize Resource Manager using the SLNetClientTest tool. This can be useful if Resource Manager fails to initialize on DataMiner startup, and you want to try to initialize it again without restarting DataMiner.

> [!CAUTION]
> When you reinitialize Resource Manager, it will first be deinitialized and then initialized again. This can cause pending calls to fail, and new calls that are made while Resource Manager is being deinitialized will fail with the *ModuleNotInitialized* error.

> [!NOTE]
> In order to do this, you need the user permission [Modules > System configuration > Tools > Admin tools](xref:DataMiner_user_permissions#modules--system-configuration--tools--admin-tools).

To (re)initialize Resource Manager:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. In the *Advanced* menu, go to *Apps* > *SRM Surveyor*.

1. At the bottom of the window, click *Reinitialize ResourceManager*.

   Resource Manager will be (re)initialized on the DataMiner Agent you are connected to.

## Changes

### Enhancements

#### NATS: Enhanced (re)configuration [ID_35246]

Automatic NATS (re)configuration has been enhanced.

- When the routes of the local NATS server contain the virtual IP address of a Failover setup/node, a NATS restart will be triggered.

- When a DataMiner Agent is added or removed from the DMS, NATS will be reconfigured automatically.

- When a DataMiner Agent cannot be reached, has an incorrect configuration or is in an incorrect state, a NATS reconfiguration will be suggested in Cube via an alarm. To trigger a reconfiguration, users with *Change IP settings* permission can then right-click the alarm, select *Actions > Reconfigure NATS*, and confirm the operation.

  If no errors occur during the reconfiguration, the alarm will disappear from the Alarm Console. If, on the other hand, errors do occur, they will be displayed in a popup window and the alarm will not disappear.

All logging related to a NATS reconfiguration will be added to the *SLNATSCustodian.txt* log file.

#### Security enhancements [ID_36319] [ID_36928]

<!-- MR 10.4.0 - FR 10.3.9 -->

A number of security enhancements have been made.

#### DataMiner upgrade: New upgrade action added that will clean up default ListView column configuration data [ID_36475]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

During a DataMiner upgrade, from now on, all default ListView column configuration data left on the server will automatically be cleaned up if no more than one Cube client has taken a copy of that data.

#### Cassandra Cluster: Trend tables will no longer be sharded [ID_36551]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

On a Cassandra Cluster database, from now on, the trend tables will no longer be sharded. This will enhance overall performance when requesting trend data, especially on systems on which real-time trend data is stored for longer than a day.

#### SLDataGateway: Enhanced performance of the Elasticsearch health monitoring logic [ID_36554]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

Because of a number of enhancements, overall performance of the Elasticsearch health monitoring logic has increased.

#### Cassandra Cleaner can now also be used to clean the 'infotrace' table [ID_36592]

<!-- MR 10.4.0 - FR 10.3.9 -->

Up to now, the *Cassandra Cleaner* tool could only be used to remove data from the *timetrace* table. From now on, it can also be used to remove data from the *infotrace* table.

1. In the *db.yaml* file, set `table.name` to "infotrace".

   By default, `table.name` is set to "timetrace".

1. Specify a time range by setting the `delete.start.time` and `delete.end.time` fields.

  > [!CAUTION]
  > All infotrace data between the `delete.start.time` and `delete.end.time` timestamps will be deleted, so be careful.

1. Run the following command: `clean -l`

   > [!NOTE]
   > The *infotrace* table can only be cleaned using the `clean -l` command.

For more information, see [Cassandra Cleaner](xref:Cassandra_Cleaner).

#### SLLogCollector will now also collect the scheduled tasks configured in Microsoft Task Scheduler [ID_36645]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

SLLogCollector will now also collect the scheduled tasks configured in Microsoft Task Scheduler.

#### Automation: DLL references on script libraries will also be loaded when an Automation script does not need to be recompiled [ID_36730]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

Up to now, when the SLAutomation service was started, the DLL references defined on an Automation script library would only be taken into account when that library needed to be recompiled. As a result, Automation scripts that relied on a script library could fail due to missing references.

From now on, when the SLAutomation service is started, the DLL references on an Automation script library will also be loaded when that library does not need to be recompiled.

#### DataMiner upgrade: Presence of Visual C++ 2010 redistributable will no longer be checked [ID_36745]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

During a DataMiner upgrade, from now on, the presence of the Visual C++ 2010 redistributable will no longer be checked.

#### DataMiner Object Models: DomInstanceHistory will now be saved asynchronously [ID_36785]

<!-- MR 10.4.0 - FR 10.3.9 -->

When a DomInstance is created or updated, a HistoryChange record is stored in the database, and when a DomInstance is deleted, all HistoryChange objects associated with that DomInstance are deleted from the database. Up to now, those HistoryChange records were always created, updated and deleted synchronously.

From now on, all DOM managers will create, update and delete their HistoryChange records asynchronously, which will considerably enhance overall performance when creating, updating or deleting DomInstances.

Using the new `DomInstanceHistoryStorageBehavior` enum on the new `DomInstanceHistorySettings` class, you can configure whether HistoryChange records will be stored and how they will be stored. See the following example:

```csharp
​ModuleSettings.DomManagerSettings.DomInstanceHistorySettings.StorageBehavior = DomInstanceHistoryStorageBehavior.Disabled;
```

The `DomInstanceHistoryStorageBehavior` can be set to one of three values:

- **EnabledAsync** (default value): The HistoryChange records will be created, updated and deleted asynchronously.

- **EnabledSync**: The HistoryChange records will be created and deleted synchronously.

- **Disabled**: No HistoryChange records will be created, updated or deleted.

  > [!NOTE]
  > If you set the value to "Disabled" after it had been set to one of the other options, the existing HistoryChange records in the database will be left untouched, even if the corresponding DomInstance is deleted.

> [!NOTE]
> When you delete a DomInstance with a large number of associated HistoryChange records, deleting all those HistoryChange records can take a long time, even when this is done asynchronously. Therefore, we recommend disabling the creation of HistoryChange records if you do not need them.

#### Service & Resource Management: Enhanced performance when adding or updating ReservationInstances [ID_36788]

<!-- MR 10.4.0 - FR 10.3.9 -->

Because of a number of enhancements, overall performance has increased when adding or updating ReservationInstances, especially on systems with a large number of overlapping bookings and a large number of bookings using the same resources.

#### DataMiner installation/upgrade: Updated DataMiner Extension Modules [ID_36799]

<!-- MR 10.4.0 - FR 10.3.9 -->

When you install or upgrade a DataMiner Agent, a number of DataMiner Extension Modules (DxMs) will automatically be installed (if not present yet). The following modules have now been updated:

- DataMiner CoreGateway (version 2.13.0)
- DataMiner SupportAssistant (version 1.4.0)

> [!NOTE]
> For detailed information on the changes included in the different versions of these DxMs, refer to the [dataminer.services change log](xref:DCP_change_log).

#### SLAnalytics - Automatic incident tracking: Root time of an alarm group will be set to the most recent of the base alarm root times [ID_36809]

<!-- MR 10.4.0 - FR 10.3.9 -->

From now on, the root time of an alarm group (i.e. the time of arrival of the first alarm in the alarm group tree) will be set to the most recent of the base alarm root times.

Up to now, when alarm groups were recreated after a DataMiner upgrade, their time of arrival and root time was set to the time of the upgrade.

#### DataMiner upgrade: Microsoft .NET 5 will no longer be installed by default [ID_36815]

<!-- MR 10.4.0 - FR 10.3.9 -->

Up to now, Microsoft .NET 5 would always be installed during a DataMiner upgrade. As all DataMiner components using .NET 5 have been upgraded to use .NET 6 instead, .NET 5 will no longer be installed by default.

> [!NOTE]
> If Microsoft .NET 5 is present, it will not be automatically uninstalled during a DataMiner upgrade.  

#### SLWatchdog: Additional logging & retry mechanism for restarts [ID_36839]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When SLWatchdog starts, restarts or stops DataMiner, extra information will now be logged to help pinpoint certain issues that may arise:

- the SLDataMiner process ID,
- the output of the batch scripts that are being executed while DataMiner is (re)starting,
- etc.

Also, if DataMiner did not start up correctly for some reason, a retry will now be attempted in that same startup routine.

In the `C:\Skyline DataMiner\Tools` folder, you can also find the following new startup scripts:

- *DataMiner Start DataMiner And SLNet.bat*
- *DataMiner Start DataMiner.bat*

#### Renaming objects: DMA will throw a more clearer error message in case the name already exists [ID_36845]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

When an attempt is made to rename an object, the DataMiner Agent will now throw the following error message when the name already exists:

```txt
The name is already used by another object in the DMS.
```

Also, certain false positive errors that used to occur when renaming objects will no longer be logged in *SLErrors.txt*, and a NATS exception that is generated when a message needs to be sent from SLNet to SLDataGateway, SLHelper or SLAnalytics has now been converted to a *DataMinerException* to avoid DataMiner/client disconnects due to `message not marked as serializable` errors.

#### User-Defined APIs: ApiTriggerInput object has a new TokenId property [ID_36856] [ID_37015]

<!-- MR 10.4.0 - FR 10.3.9 -->
<!-- Not added to MR 10.4.0 -->

The `ApiTriggerInput` object, which contains information about the API trigger, will now also contain a `TokenId` property.

This property will contain the GUID of the `ApiToken` that was used to trigger the API.

#### Elasticsearch/OpenSearch: Unused suggest indices have been disabled [ID_36875]

<!-- MR 10.4.0 - FR 10.3.9 -->

Up to now, each time a new DOM manager was initialized, SLDataGateway would create a main data index and a suggest index in the Elasticsearch database for each DOM type. As these suggest indices are not used, they have now been disabled. As a result, overall performance will increase when initializing new DOM managers.

Other unused suggest indices have been disabled as well. This will have a positive impact on the hardware resources required for Elasticsearch or OpenSearch.

The following suggest indices have been disabled:

- ApiDefinition
- ApiToken
- AutoIncrementer
- DomBehaviorDefinition
- DomDefinition
- DomInstance
- DomTemplate
- HistoryChange
- JobDomain
- JobTemplate
- MediationSnippet
- ModuleSettings
- PaProcess
- Parameter
- PaToken
- ProfileDefinition
- ProfileInstance
- Record
- RecordDefinition
- ReservationDefinition
- ReservationInstance
- Resource
- ResourcePool
- SectionDefinition
- ServiceDefinition
- ServiceDeletionHistory
- ServiceProfileDefinition
- ServiceProfileInstance
- SRMServiceInfo
- SRMSettableServiceState
- Ticket
- TicketFieldResolver
- TicketHistory
- VirtualFunctionDefinition
- VirtualFunctionProtocolMeta

> [!NOTE]
> Existing suggest indices will not automatically be removed from the database. You can remove them manually if necessary.

#### SLNetClientTest: Enhancements made to 'DataMiner Object Model' window [ID_36891]

<!-- MR 10.4.0 - FR 10.3.9 -->

A number of enhancements have been made to the *DataMiner Object Model* window.

- The *DataMiner Object Model* window will now only subscribe to the events of the DOM manager you selected in the *ModuleSettings* window. Up to now, it would subscribe to all events of all DOM managers.

- The *DomInstances* and *History* pages will initially only load up to 500 objects. A warning message at the top of the window will indicate that only a limited list was loaded, and that you will need to click *Refresh* to load all items.

- The objects listed on the *DomInstances* and *History* pages will now be sorted by the data that was last modified (descending), allowing you to quickly see the recently updated objects.

- On the *History* page, the GUID of the DomInstance will no longer have a "DomInstanceId" prefix.

- The *Attachments* page will no longer load all DomInstances at startup. If you want all DomInstances to be loaded, you will need to click *Load all DOM instances*.

- On the *SectionDefinitions* page, the IDs of the section definitions will now be shown in the first column.

- When you click *View* after selecting a section definition, the text will no longer include a *Validators* line if no validators could be found.

- When no name is assigned to a *DomBehaviorDefinition* or a *DomDefinition*, the text "(no name)" will appear to indicate that no name was assigned.

- If, on any of the pages, you want to select an item in a table, you can now click the item anywhere. Up to now, you had to click the cell in the first column.

> [!CAUTION]
> Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### NATS firewall rule profiles set to 'All" during DataMiner upgrades [ID_36914]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

During a DataMiner upgrade, from now on, the *InstallNATS* upgrade action will set all existing NATS firewall rule profiles to "All".

#### SLLogCollector: Easier selection of processes after selecting 'Include memory dump' [ID_36982]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When configuring the *SLLogCollector* tool, you can select the *Include memory dump* option, and then indicate for which process(es) memory dumps should be collected and when these should be collected. Up to now, to select a process, you had to select a checkbox. From now on, you will be able to select a process by clicking any cell in the row representing the process.

### Fixes

#### Problem due to incorrect NATS reconfiguration [ID_35246]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When, for example in a three-node DMS configuration composed of a Failover pair and another, separate DMA, one of the agents in the Failover setup went offline, after 5 minutes, the separate non-Failover agent would incorrectly shift to a two-node DMS configuration. From now on, the non-Failover agent will keep the three-node DMS configuration if one of the Failover agents goes offline.

#### Cassandra: Table data that should not expire had a TTL value set [ID_35263]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

Up to now, in a Cassandra Cluster or a Cassandra Standalone database, certain table data that should not expire would incorrectly have a TTL value set when inserted. As a result, that data would automatically get deleted when the TTL value reached 0.

The following mechanisms have now been implemented:

- The affected table data will no longer have any TTL value configured when inserted. Moreover, as a safety measure, all Cassandra tables will now also have a `default_time_to_live` setting. This value will provide the default TTL value in case no value for the TTL is passed when inserting data.

- When existing data with an incorrect TTL value set is retrieved from the database, its TTL value will automatically be removed to prevent it from being deleted.

#### NATS auto-reconnect mechanism could lead to a situation in which a large number of TCP ports were left open [ID_36339]

<!-- MR 10.4.0 - FR 10.3.9 -->

When NATS tried to automatically reconnect at a moment when none of the servers were available, it would incorrectly not wait for a while until the cluster was online again. In some cases, this could lead to a situation in which a large number of TCP ports were left open.

#### SLDataGateway: Memory leak when migrating average trend data from MySQL to Cassandra Cluster [ID_36367]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

SLDataGateway would leak memory when migrating average trend data from MySQL to Cassandra Cluster.

#### Problem when an SNMP connection was assigned to a separate thread [ID_36441]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When, in a protocol, an SNMP connection was assigned to a separate thread, in most cases, the polling would get stuck because the main protocol thread would get notified of the response rather than the thread that was assigned to the SNMP connection.

From now on, a poll group will default to connection 0 rather than -1. As a result, when a separate thread is created for the main connection (i.e. the connection with ID 0), the groups for that connection will no longer need to have `connection="0"` specified.

Also, the following issues have been fixed:

- Potential memory leaks and SLProtocol errors related to SNMP and additional protocol threads. For example, up to now, stopping an element while a forced group was being executed could cause an error to occur in SLProtocol.

- Up to now, assigning the same connection ID to multiple thread elements could result in undefined behavior. From now on, connection IDs will be assigned according to what occurs first.

> [!NOTE]
> Known issue: Currently, the action to stop the current group is only capable of stopping the group on the main thread. It is not yet possible to specify a particular thread on which to stop a group.

#### Failover: Problems when running BPA tests [ID_36445]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When the backup agent was active, certain BPA tests would incorrectly return the following error:

`This BPA does not apply for this Agent: cannot run on Offline Failover Agents`

Also, certain managers in SLNet (e.g. BPA Manager) would not properly initialize if the following Failover settings were configured in the *SLDMS.xml* file:

- `State="Offline"`
- `StateBeforeShutDown="Online"`

#### SNMPv3 credentials would not get deleted when an SNMPv3 element was deleted [ID_36573]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When an SNMPv3 element was deleted, its SNMPv3 credentials would incorrectly not get deleted. Also, when users were deleted, their DCP credentials would not get deleted.

#### NT Notify type NT_ADD_VIEW could be executed with an invalid parent view ID [ID_36739]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

Up to now, when an `NT_ADD_VIEW` call was executed with `parentViewID` set to a non-existing view ID, the newly added view would not be visible in the Surveyor. Hence, there was no way of correcting the situation using the UI. Cube logging would include a warning that a `parentViewID` cannot be resolved.

Validation has now been added to `NT_ADD_VIEW`. When a request enters to create a view with an invalid parent view ID, the view will not be created. Also, views with an invalid parent view ID will now be placed directly under the root view. This will allow you to drag the view to its correct location, updating its parent view ID to a valid ID in the process. An error will also be logged and the *View Recursion* BPA test will report the view in question.

#### SLAnalytics - Behavioral anomaly detection: Problem when processing a behavioral change point [ID_36755]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

In some cases, an `index out of bounds` error could occur when processing a behavioral change point.

#### Certain alarms would have their 'root creation time' set incorrectly [ID_36812]

<!-- MR 10.4.0 - FR 10.3.9 -->

In some cases, the *root creation time* of an alarm would not be equal to the *creation time* of the root alarm.

For example, when an alarm group was created with an old time of arrival, the *root creation time* would be set to the root time (i.e. the time of arrival of the root alarm), while the *creation time* would be set to the time at which the alarm was created.

#### SLAnalytics - Automatic incident tracking: 'relationThreshold' set to an incorrect value after a DataMiner upgrade [ID_36826]

<!-- MR 10.4.0 - FR 10.3.9 -->
<!-- Not added to MR 10.4.0 -->

After upgrading from DataMiner main version 10.3.0 (or older) to DataMiner feature version 10.3.7 or 10.3.8, the default `relationThreshold` value would unexpectedly be set to 0.5 instead of 0.7 (i.e. the default value).

#### Problem with SLScripting when resolving assemblies [ID_36843]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

In some cases, an error could occur in SLScripting when it was resolving DLL files for a QAction or an Automation Script.

#### Problem with SLProtocol when the system locale was set to Japanese [ID_36854]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

On the system locale was set to Japanese, an error could occur in SLProtocol when a QAction tried to read a parameter value containing raw bytes.

#### Problem when renaming an element [ID_36855]

<!-- MR 10.4.0 - FR 10.3.9 -->

In some rare cases, an error could be thrown when an element was renamed.

#### Cassandra Cluster: Not all data would get offloaded when the database went down [ID_36865]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When a Cassandra Cluster database went down, not all data would get offloaded.

#### Polling an SNMP table with MultipleGetNext could incorrectly produce two result sets [ID_36867]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When an SNMP table was polled with *MultipleGetNext* and the response was not processed within 10 minutes, in some rare cases, an error could occur in SLSNMPManager, causing the table to be polled a second time as the result of a retry. This meant that, in such a case, one poll action would produce two result sets.

#### Elements would not be created on remote agents when importing elements from a CSV file [ID_36873]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When you imported elements from a CSV file, new elements would only be created on the local agent, not on any of the remote agents, i.e. the agents other than the one the Cube client was connected to. Existing elements would be updated correctly on the local agents as well as on all remote agents.

#### Incorrect error message was thrown when NATS credentials could not be retrieved from a remote DMA [ID_36906]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

In some cases, when *NATSCustodian* was trying to set up a new configuration, some nodes could get an error with the following incorrect message:

`Failed to copy credentials from <ip> - corrupt zip file.`

From now on, an error containing the actual reason will be thrown instead. See the following example.

```txt
Failed to copy credentials from <ip> - TraceData: (amount = 1)
      - ErrorData: (amount = 1)
          - Reason: ModuleNotInitialized
```

#### A DataMiner Agent with a single-node Cassandra and an Elasticsearch would not start up when Elasticsearch was down [ID_36930]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

When a DataMiner Agent had its own single-node Cassandra database as well as its own Elasticsearch database, DataMiner would not start up when Elasticsearch was down. From now on, it will start up, but a full DataMiner restart will be required for all modules depending on Elasticsearch to work properly.

#### Elements would no longer be able to generate alarms and information events after having been migrated [ID_36951]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When an element had been migrated from one DataMiner Agent to another, it would no longer be able to generate alarms and information events.

> [!IMPORTANT]
> The element protocol must pass the DataMiner ID of the element instead of the DataMiner ID of the DataMiner Agent.

#### Deprecated DMS_GET_INFO call could return unexpected DVE child data [ID_36964]

The deprecated DMS_GET_INFO call would return unexpected data when it returned data of elements that contained remotely hosted DVE child elements.

#### Dynamic IP setting for a serial connection would cause incorrect SSH errors to be logged [ID_37016]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When, for a particular parameter, the `options` attribute of the `<Type>` element was set to "dynamic ip" for a serial connection, the following incorrect entry would be added to the element's log file:

`An error occurred when applying SSH connection settings from parameters. Not implemented (hr = 0x80004001)`

Moreover, when additional logging was activated for SLPort, an `Attempted to set SSH options on a non-SSH connection` error would be added to the same log file, followed by an unreadable value (representing the IP address), which could even cause a fatal error to occur in SLPort.
