---
uid: General_Main_Release_10.1.0_CU2
---

# General Main Release 10.1.0 CU2

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Improved performance when writing trend data in Cassandra \[ID_27777\]

Performance has improved when writing trend data in the Cassandra database, both for single Cassandra nodes and Cassandra clusters.

#### Improved performance when writing data to file offload storage \[ID_28294\]

Performance has improved when data is written to the file offload storage while the Cassandra or Elasticsearch database is down.

#### Improved performance when writing and deleting data on single Cassandra node \[ID_28376\]

Performance has improved for all write and delete queries on single Cassandra nodes (not Cassandra clusters). This applies to all data handled by the SLDataGateway process, including alarms, trending, element data, etc.

#### Improved performance when deleting element data in database \[ID_28424\]

Performance has improved when deleting element data in a Cassandra or SQL database.

#### Cassandra: Enhanced method for restoring a Cassandra database backup \[ID_28485\]

From now on, a Cassandra database backup will be restored in the following way onto a DataMiner Agent with an existing Cassandra database:

1. Reset Cassandra to its factory default settings.

2. Delete the existing Cassandra data folder.

3. Restore the backup.

To restore a Cassandra database backup on a DataMiner Failover system with a Cassandra database, you will now have to proceed as follows:

1. End the DataMiner failover configuration as well as the Cassandra failover configuration.

2. Clear/reset the backup agent.

3. Restore the Cassandra database backup onto one of the two agents.

4. Set up the DataMiner Failover system again.

#### NATS: Enhanced log settings & offline Failover agents now prevented from becoming the primary NAS \[ID_28557\]

The settings controlling the NATS server logging have been adjusted. Debug logging is now disabled by default and a new log file will now be created whenever the size of the current one exceeds 3 MB.

Also, offline Failover agents will now be prevented from becoming the primary NAS.

#### Schedule configuration of BPA tests \[ID_29000\]

On the *Agents* > *BPA* page in System Center, you can now schedule when a BPA test should run. In the drop-down box in the *Schedule* column, you can select to run a test at different intervals, e.g. daily or every 12 hours.

#### Cache for SNMP inform messages \[ID_29034\]

To handle situations where inform messages are sent out again while they have already been acknowledged by DataMiner, DataMiner will now by default keep the latest 20 inform messages per SNMP entity in a cache, so that it can check whether an incoming inform message has already been processed, and discard it if this is the case.

In the *DataMiner.xml* file, you can customize how many inform messages are stored in the cache. To do so, set the *informCacheSize* attribute of the *SNMP* tag to the number of inform messages that should be stored. For example:

```xml
<DataMiner>
   ...
   <SNMP informCacheSize="25" />
   ...
</DataMiner>
```

> [!NOTE]
>
> - If you set *informCacheSize* to 0, the cache will be disabled.
> - Only inform messages are stored in this cache, not traps.
> - When an inform message is discarded, this is logged in *SLSNMPManager.txt* on information level 3.

#### Enhanced performance when assigning alarm templates with conditions used in multiple rules \[ID_29109\]

Due to a number of enhancements, overall performance has increased when assigning an alarm template to an element, especially when that alarm template contains conditions that are used in multiple rules.

#### SLLogCollector tool can now be accessed via the DataMiner Taskbar Utility \[ID_29154\]

You can now open the SLLogCollector tool by selecting *Launch \> Tools \> SLLog Collector* in the DataMiner TaskBar Utility.

#### DataMiner Cube: Warning message will now appear when you duplicate an SNMPv3 element from another DMA \[ID_29192\]

When you duplicate an SNMPv3 element from a DMA other than the one to which you are connected, from now on, a message box will appear, saying that you have to re-enter the SNMPv3 credentials for the newly created element.

> [!NOTE]
> No such message will be displayed when using either a credential library or the NoAuthNoPriv security level.

#### Enhanced loading and initializing of alarm templates \[ID_29236\]

A number of enhancements have been made with regard to the loading and initializing of alarm templates.

#### Database: File offload enhancements \[ID_29238\]\[ID_29245\]

Due to a number of enhancements, overall performance has increased when offloading data to a file.

Also, during file offloads, less disk space will be used.

#### '!! No link found for xxx\[xx\] -> xxxx' errors will now be logged in SLErrorsInProtocol.txt instead of SLErrors.txt \[ID_29264\]

Up to now, when a “!! No link found for xxx\[xx\] -> xxxx” error was generated by SLElement, that error would be logged in SLErrors.txt. From now on, this type of errors will be logged in SLErrorsInProtocol.txt instead.

#### SLElement: Enhanced error handling \[ID_29270\]

A number of enhancements have been made to the error handling in SLElement.

#### DataMiner Cube: Filter box in Documents app & Documents card pages \[ID_29298\]

In the *Documents* app and the *Documents* card pages, a filter box now allows you to filter the list of documents.

#### Enhancements to prevent 'Messages have gone lost, making the connection invalid' errors from being thrown \[ID_29304\]

A number of enhancements have been made to prevent “Messages have gone lost, making the connection invalid” errors from being thrown.

#### DataMiner Cube - Visual Overview: New icons added to Icons stencils \[ID_29315\]

The following icons has been added to the Icons stencil:

- Airplane

- Android

- Apple TV

- Boat

- Browser.2

- Bus

- Car

- Chromecast

- Delete Connections

- Delete Element

- Discover Connections

- Download Configuration Back-Up

- House

- IOS

- Laptop

- Person

- Profile Manager

- Provision Connections

- Reapply CI Type

- Reassign CI Type

- Remove Filter

- Restore Default Configuration

- Train

- Unmanage Element

- Voice

#### DataMiner Cube: Enhancement made to 'Skyline Black' theme \[ID_29370\]

A number of enhancements have been made to the “Skyline Black” theme, especially with regard to readability in the *Database* section of *System Center*.

#### 'Saving report...' entry will no longer be added to SLWatchdog.txt when a Watchdog report has successfully been saved \[ID_29379\]

From now on, when a Watchdog report has successfully been saved, no “Saving report...” entry will be added to the SLWatchdog.txt log file anymore.

#### Enhanced performance of file synchronization operations \[ID_29401\]

When the internal file change repository of the SLDMS process reached a considerable size, up to now, overall performance of the file synchronization operations would decline.

Due to a number of enhancements, overall performance of the file synchronization operations has now been optimized.

### Fixes

#### DataMiner Cube: 'Migrate booking data to Indexing Engine' button would still be displayed after the booking data had already been migrated \[ID_28813\]

In DataMiner Cube, clicking the *Migrate booking data to Indexing Engine* button starts a wizard that allows you to migrate booking data from the Cassandra database to the Indexing database. In some cases, this button would incorrectly still be displayed after the booking data had already been migrated.

#### DataMiner Cube - Visual Overview: Element shapes would incorrectly not inherit the service context of their parent element shape \[ID_28867\]

Up to now, an element shape that was a child of another element shape would not inherit the service context of its parent.

From now on, an element shape that is a child of another element shape will inherit the service context of its parent when it does not have a service context of its own.

#### DataMiner Cube: Linked alarm tab would not show all alarms after all cards had been closed & no context menu when right-clicking an app in the Cube header search box \[ID_28893\]

When you closed all cards while a linked alarm tab was open in the Alarm Console, that linked alarm tab would not show all alarms. Instead, it would incorrectly keep the last card you closed as a filter.

Also, when you searched for an app using the search box in the Cube header, right-clicking the app in the search results would not open its context menu.

#### Cassandra: Problem with file offload \[ID_28951\]

Due to a file offload problem, in some rare cases, data operations (e.g. parameter updates) executed during a Cassandra outage would not get pushed to the database after the outage.

#### Dashboards app: Multiple parameter feeds in PDF reports would incorrectly also show all selected parameter indices \[ID_28978\]

When you generated a PDF report with the options “No grouping” and “Include feeds” enabled, in some cases, multiple parameter feeds would not only show the selected parameters, but incorrectly also all selected parameter indices.

#### DataMiner Cube - Automation: Discarding a newly created script would not delete it \[ID_29032\]

When you discarded a newly created Automation script, in some cases, it would incorrectly not be deleted although it had disappeared from the UI. As a result, trying to create a new script with the same name would fail.

#### No trigger keys listed when debugging a QAction due to a compatibility issue between DataMiner and DataMiner Integration Studio \[ID_29049\]

Due to a compatibility issue between DataMiner and DataMiner Integration Studio, in some cases, when debugging a QAction, the *Trigger key* box in the *DIS Inject* window would incorrectly not list any trigger keys.

#### SNMPAgent: Engine ID and engine boots counter of local agent would incorrectly be cleared when the users were cleared \[ID_29081\]

Up now on, when an SNMP agent cleared the users during the re-initialization of the SNMP forwarding, the engine ID and the engine boots counter of the local agent would incorrectly be cleared as well. From now on, when an SNMP agents clears the users, it will ignore the engine ID and engine boots counter of the local agent.

#### DataMiner Cube - Resources app: Capacity parameter values would incorrectly be stored without decimals \[ID_29082\]

Up to now, in the Resources app, capacity parameter values would incorrectly be stored without decimals.

#### SLNet.txt log file would contain irrelevant log entries \[ID_29120\]

From now on, the following irrelevant entries will no longer be added to the SLNet.txt log file:

```txt
DmaConnections|Unexpected filter type: SubscriptionFilter\`2
```

```txt
Unexpected filter type: Skyline.DataMiner.Net.SubscriptionFilters.SubscriptionFilter\`2[XXXX,XXXXXX]
```

#### Interactive Automation scripts: Date selected in calendar control would be parsed incorrectly \[ID_29153\]

When, in an interactive Automation script, a calendar control was used to select a date (i.e. a datetime value without a specific time), in some cases, the value of the selected date would be parsed incorrectly.

#### UDP smart-serial server would receive an empty package each time a new client started sending data to it \[ID_29166\]

When multiple clients were sending data to a smart-serial UDP server, that server would incorrectly receive an empty package each time a new client started sending data.

#### DataMiner Cube - EPM: No longer possible to unmask items in a topology diagram or alarms in the Alarm Console \[ID_29173\]

In an EPM environment, in some cases, it would no longer be possible to manually unmask items in a topology diagram or alarms in the Alarm Console.

#### Dashboards app: Ring or Gauge component would incorrectly indicate the maximum value \[ID_29175\]

In some cases, a Ring or Gauge component would indicate the maximum value instead of the current value, especially when that value had a unit assigned.

#### DataMiner Cube: Table columns with a width set to 0 in the protocol would incorrectly be visible \[ID_29196\]

In DataMiner Cube, in some cases, table columns of which the width was set to 0 in the protocol would incorrectly be visible.

#### Dashboards app - GQI: Aggregated values would incorrectly be displayed in raw format \[ID_29200\]

In GQI query results, aggregated values would incorrectly be displayed in raw format. From now on, they will be formatted according to the display properties (e.g. units, decimals, etc.) defined in the protocol.

#### DataMiner Cube - Alarm Console: Problem when trying to unmask an EPM object \[ID_29213\]

When an EPM object is masked, you can try to unmask it via its alarms in the Alarm Console. These alarms are linked to the EPM object via the “System Name” and “System Type” properties.

In some cases, it would no longer be possible to unmask such an EPM object due to a casing issue in those “System Name” and “System Type” properties.

#### DataMiner Cube - EPM: No longer possible to manually unmask items in a topology diagram \[ID_29228\]

In an EPM environment, in some cases, it would no longer be possible to manually unmask items in a topology diagram.

#### Problem in SLNet could cause DataMiner to restart \[ID_29229\]

In some rare cases, an error occurring in SLNet could cause DataMiner to restart.

#### DataMiner 10.1.0 upgrade package: Launcher.ashx file missing \[ID_29235\]

The C:\\Skyline DataMiner\\Webpages\\DataMinerCubeStandAlone\\Launcher.ashx file was missing in the DataMiner 10.1.0 upgrade package.

#### Dashboards app - GQI: Problem when performing an aggregation operation on an additional column \[ID_29249\]

In some cases, an exception could be thrown when a aggregation operation was performed on an additional column.

#### DataMiner Cube: Problem when exporting tables to function DVE protocols \[ID_29266\]

When a table is exported to a function DVE protocol, some of the columns can optionally be left out. In some cases, especially when the omitted columns appeared before the primary key or display key columns, DataMiner Cube would interpret the data incorrectly.

#### Data would not get written to the backup agent after configuring a Failover setup on a system with MySQL databases \[ID_29267\]

When a Failover setup is configured on two DataMiner Agents with a MySQL database, after synchronizing the two databases, all new data should be written to both these databases. However, in some cases, new data would incorrectly not be written to the backup agent until after the primary agent had been restarted.

#### DataMiner Cube - System Center: Incorrect counter values on Agents \> BPA page \[ID_29271\]

In *System Center*, on the *Agents \> BPA* page, in some cases, the displayed counters would show incorrect values.

#### Problem with SLAnalytics \[ID_29275\]

In some rare cases, an error could occur in the SLAnalytics process.

#### Dashboards app: Problem when no elements could be found when running an inter-element GQI query that retrieved a table \[ID_29285\]

When no elements could be found while running an inter-element GQI query that retrieved a table, up to now, an exception would be thrown. From now on, an empty result set will be returned instead.

#### Jobs app: 'no sections added yet' error incorrectly displayed on a booking section \[ID_29293\]

In some cases, a “no sections added yet” error would incorrectly be displayed on a booking section.

#### Problem at DataMiner startup due to an invalid loop in the view hierarchy \[ID_29307\]

On DataMiner startup, in some cases, an error could occur when an invalid loop was found in the view hierarchy. From now on, when an invalid view loop is found, an error mentioning the incorrectly configured views will be logged.

#### Problem when an Element.xml or Service.xml file could not be found \[ID_29322\]

Up to now, in some cases, an exception would be thrown when an Element.xml or Service.xml file could not be found. From now on, an error will be logged instead.

#### Jobs app: Problem when updating section and field definitions \[ID_29325\]

In some cases, changes made to job sections and job fields would not immediately be visible in the UI.

Also, when a field with the *Allow filtering on this field* option enabled had its type changed, in some cases, the *Allow filtering on this field* option would incorrectly stay enabled.

#### Problem with SLDataMiner when an element was stopped \[ID_29327\]

In some cases, an error could occur in SLDataMiner when an element was stopped.

#### DataMiner Cube - Alarm Console: Correlation sources would no longer be updated \[ID_29330\]

When one of the sources of a correlation alarm (group) was updated, in some cases, the update would not be reflected in the Alarm Console. When you opened the correlation alarm (group), the previous alarm source would incorrectly still be shown.

#### Dashboards app: Web components would not load HTTPS-only websites when the Dashboards app was being used with HTTP \[ID_29352\]

When the Dashboards app is being used with HTTP instead of HTTPS (which is not recommended), then it also loads all web component URLs using HTTP, even when they are configured to use HTTPS. As a result, up to now, websites only accessible using HTTPS could not be loaded.

From now on, it will also be possible to load websites only accessible using HTTPS when the Dashboards app is being used with HTTP.

#### Legacy Reporter app: Status query report with table parameters exported to a CSV file would contain tables within table cells \[ID_29355\]

When, in the legacy Reporter app, you generated a report containing a status query with a number of table parameters and exported it to a CSV file, full tables would end up in status query cells.

From now on, when you export a status query report containing table parameters to a CSV file, the data in the table parameters will be exported to separate CSV files as before, but it will no longer appear inside status query cells.

#### DataMiner Cube - Bookings app: Bookings without an end time would incorrectly only be listed when their start time was within the specified time window \[ID_29356\]

In the Bookings app, booking without an end time would incorrectly only be listed when their start time was within the specified time window.

#### Using an NT_EDIT_PROPERTY (62) call to update an alarm property of a DVE element would fail when no element ID was specified \[ID_29358\]

When an alarm property of a DVE element was updated using a SetDataMinerInfoMessage of type 62 (NotifyType.EditProperty) without specifying the element ID, the request would fail with an “element is unknown” error.

#### Elements with a large amount of data stored in a Cassandra database would fail to start \[ID_29363\]

On systems with a Cassandra database, in some cases, elements that had a large amount of data stored in the database would fail to start.

#### Dashboards app - CPE feed: Selection box contained too much data \[ID_29377\]

Due to incorrect filtering, in some cases, the selection box in the CPE feed would contain too much data.

#### DataMiner Cube: Problem when selecting a value from a drop-down parameter in a custom context menu of a table \[ID_29383\]

If a parameter of type “drop-down” in a custom context menu of a table retrieved its values from a dependency parameter, in some cases, the first time a value was selected, the selection would not be applied.

#### Jobs app: Small typographical error in warning message \[ID_29388\]

When, in the Jobs app, you tried to hide the only domain that was visible, up to now, the warning message that appeared, would contain a small typographical error.

- Former message: “Atleast one job domain should be visible.”

- New message: “At least one job domain should be visible.”

#### Jobs app: Booking sections did not have their initial values filled in \[ID_29392\]

In some cases, booking sections did not have their initial values filled in.

#### Jobs app: Jobs no longer selected after canceling a delete operation \[ID_29402\]

When you selected a number of jobs in the list, clicked *Delete*, and then clicked *Cancel*, in some cases, the jobs you had selected would no longer be selected.

#### Automation: Subscripts would return an incorrect output \[ID_29405\]

When, in an Automation script, a subscript that returned its output was run twice, in some cases, when it cleared its output during its second run, it would incorrectly return the same output it had returned at the end of its first run.

#### Legacy Reporter: Status query would no longer show alarm colors \[ID_29516\]

In the legacy Reporter app, in some cases, the status query would no longer show alarm colors.
