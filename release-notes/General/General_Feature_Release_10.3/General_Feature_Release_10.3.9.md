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

## Changes

### Enhancements

#### Security enhancements [ID_36319]

<!-- 36319: MR 10.4.0 - FR 10.3.9 -->

A number of security enhancements have been made.

#### DataMiner upgrade: New upgrade action added that will clean up default ListView column configuration data [ID_36475]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

During a DataMiner upgrade, from now on, all default ListView column configuration data left on the server will automatically be cleaned up if no more than one Cube client has taken a copy of that data.

#### Cassandra Cluster: Trend tables will no longer be sharded [ID_36551]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

On a Cassandra Cluster database, from now on, the trend tables will no longer be sharded. This will enhance overall performance when requesting trend data, especially on systems on which real-time trend data is stored for longer than a day.

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

#### DataMiner upgrade: Presence of Visual C++ 2010 redistributable will no longer be checked [ID_36745]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

During a DataMiner upgrade, from now on, the presence of the Visual C++ 2010 redistributable will no longer be checked.

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

### Fixes

#### Cassandra: Table data that should not expire had a TTL value set [ID_35263]

<!-- MR 10.3.0 [CU6] - FR 10.3.9 -->

Up to now, in a Cassandra Cluster or a Cassandra Standalone database, certain table data that should not expire would incorrectly have a TTL value set when inserted. As a result, that data would automatically get deleted when the TTL value reached 0.

The following mechanisms have now been implemented:

- The affected table data will no longer have any TTL value configured when inserted. Moreover, as a safety measure, all Cassandra tables will now also have a `default_time_to_live` setting. This value will provide the default TTL value in case no value for the TTL is passed when inserting data.

- When existing data with an incorrect TTL value set is retrieved from the database, its TTL value will automatically be removed to prevent it from being deleted.

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

#### Problem when renaming an element [ID_36855]

<!-- MR 10.4.0 - FR 10.3.9 -->

In some rare cases, an error could be thrown when an element was renamed.
