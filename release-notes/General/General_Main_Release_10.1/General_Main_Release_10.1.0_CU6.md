---
uid: General_Main_Release_10.1.0_CU6
---

# General Main Release 10.1.0 CU6

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Security enhancements \[ID_30200\] \[ID_30323\] \[ID_30362\] \[ID_30363\] \[ID_30417\] \[ID_30422\] \[ID_30423\] \[ID_30561\]

A number of security enhancements have been made.

#### Dashboards app - Time range component: Selecting a preset timespan will now cause the name of that timespan to be added to the URL of the dashboard \[ID_27963\]

Up to now, when you selected a preset timespan (e.g. today, yesterday, etc.) in a time range component, the start time and end time of that timespan was added to the URL of the dashboard. From now on, when you select a preset timespan, the actual name of that timespan (e.g. today, yesterday, etc.) will be added to the URL instead.

#### DataMiner Cube - Trending: Enhanced input and validation of trend graph Y axis settings \[ID_30176\]

When you right-click on a trend graph and select “Y axis settings”, you can change the minimum and maximum Y-axis value for each numeric axis. A number of enhancements have now been made with regard to how these values are entered and validated.

#### Service & Resource Management: No longer possible to create a resource with invalid capacities and/or capabilities \[ID_30207\]

From now on, it will no longer be possible to add a resource with invalid capacities and/or capabilities.

- When you try to add a resource with “NULL” instead of a Capacity or with a Capacity of which the value is set to “NULL”, an error with reason ResourceCapacityInvalid will be added to the TraceData. The error’s ResourceManagerErrorData will contain the following properties:

  - ResourceId: The ID of the resource.
  - ResourceCapacity: The capacity object that did not reference a correct capacity profile.

- When you try to add a resource with “NULL” instead of a Capability or with a Capability of which the value is set to “NULL” and IsTimeDynamic set to FALSE, an error with reason ResourceCapabalityInvalid will be added to the TraceData. The error’s ResourceManagerErrorData will contain the following properties:

  - ResourceId: The ID of the resource.
  - ResourceCapability: The capability object that did not reference a correct capability profile.

#### Enhanced performance when creating function resources \[ID_30248\]

Due to a number of enhancements, overall performance has increased when creating function resources.

#### SLElement: Enhanced performance when processing table request filters \[ID_30262\]

Due to a number of enhancements, overall performance of SLElement has increased when processing table request filters.

#### SLElement: Enhanced performance when managing virtual elements \[ID_30274\]

Due to a number of enhancements with regard to the caching of key links, overall performance of the SLElement process has increased when managing virtual elements.

#### Enhanced performance when including/excluding elements in services based on parameter values \[ID_30284\]

Due to a number of enhancements, overall performance has increased when including/excluding elements in/from services based on parameter values, especially when the same parameter is used in a large number of element inclusion conditions.

#### Tools page now allows you to install SECTIGO certificate \[ID_30297\]

DataMiner Cube files are now signed with a SECTIGO certificate.

You can install that certificate by clicking a hyperlink in the *DataMiner tools* section of the `http://[dma\]/root/tools/` page.

#### SLElement: Enhanced performance when starting up elements \[ID_30315\] \[ID_30316\]

Due to a number of enhancements, overall performance of SLElement has increased when starting up elements, especially DVE elements and elements with a large number of foreign keys, virtual functions, etc.

#### Enhanced performance due to improved locking mechanism \[ID_30328\]

Due to a number of enhancements to the internal locking mechanism, overall performance of all DataMiner processes has increased.

#### SLElement: Enhanced performance when resolving foreign keys \[ID_30348\] \[ID_30426\]

Due to a number of enhancements, overall performance of SLElement has increased when resolving foreign keys, especially when dealing with replicated elements.

#### DataMiner Cube - Bookings app: Enhancements made to bookings timeline and bookings list \[ID_30354\]

Up to now, whenever the “now” line re-appeared in the visible range of the bookings timeline, the Follow mode would automatically be enabled again. From now on, the Follow mode will instead get the status it had before the “now” line last disappeared from the visible range.

Also, when you change the time range in the booking timeline, the bookings list will now be refreshed instead of reset. In other words, the list will no longer be cleared and rebuilt before the list filter is re-evaluated.

#### SLNet will now notify SLWatchdog when it has updated VersionHistory.txt \[ID_30366\]

When the SLWatchdog process is started, it checks the VersionHistory.txt file to find out the DataMiner version running on the DataMiner Agent in question. The VersionHistory.txt file, located in the C:\\Skyline DataMiner\\Upgrades\\ folder of a DataMiner Agent, lists all the major upgrades that have been performed on that DataMiner Agent, each with the date at which the DataMiner Agent was first started after that particular upgrade.

Up to now, when SLNet updated the DataMiner version in VersionHistory.txt while SLWatchdog was running, the latter would not be aware of that change until it was restarted. From now on, SLNet will notify SLWatchdog when it has updated VersionHistory.txt.

#### DataMiner Cube: Links to deprecated DCP platform replaced by links to the new dataminer.services platform \[ID_30430\]

Throughout the Cube UI, all links to the deprecated DataMiner Collaboration Platform have been replaced by links to the new <https://dataminer.services> platform.

#### DataMiner Cube - Data Display: Memory consumption of tables showing service impact has been reduced \[ID_30433\]

Due to a number of enhancements, overall memory consumption of tables showing service impact has been reduced.

#### SLElement: Enhanced performance when processing updates in tables with foreign key columns \[ID_30434\]

Due to a number of enhancements, overall performance of SLElement has increased when processing updates in tables with foreign key columns.

#### DataMiner upgrade packages will now include StandAloneBpaExecutor \[ID_30438\]

The StandAloneBpaExecutor tool will now by default be included in DataMiner upgrade packages.

#### DVE elements and virtual functions will start faster when their main element is restarted \[ID_30457\]

Due to a number of enhancements, DVE elements and virtual functions will start faster when their main element is restarted.

#### Enhanced performance when stopping elements that are in a timeout state \[ID_30462\]

Due to a number of enhancements, overall performance has increased when stopping elements that are in a timeout state.

#### Dashboards app - GQI: Queries verified and repaired when opened for editing \[ID_30507\]

In the Dashboards app, when you open a GQI query to edit it, it will now first be verified and repaired if necessary. Only when verification and repair have finished, will you be able to edit the query.

#### Dashboards app - chart components: Loading indicator \[ID_30515\]

When you opened or refreshed a dashboard, up to now, the chart components on that dashboard would show “no data” until the data had been fully loaded. From now on, when data is being loaded into a state component or a chart component using data from a query, a loading indicator will be shown instead.

### Fixes

#### Dashboards app: Error messages would incorrectly be displayed multiple times \[ID_28544\]

When an error had been thrown in the Dashboards app, in some cases, multiple instances of the same error message would be displayed. From now on, each error message will only be displayed once.

#### Problems when initializing scheduled alarm templates \[ID_29783\] \[ID_30365\]

In some cases, an alarm template group that was either unassigned or assigned to a stopped element would not get updated when the schedule of one of the alarm templates in that group was enabled or disabled.

Also, when an alarm template schedule was started, in some cases, either the active state of that schedule or the entire schedule itself would be set incorrectly.

- When an alarm template with a schedule was edited while, according to its schedule, it was inactive, the following would happen:

  - The template would temporarily be activated, causing alarms to be created which would immediately be cleared.
  - When no active window was scheduled that day, the first window of the upcoming days would be used for that day.

- When an alarm template with a schedule was assigned to an element while, according to its schedule, it was inactive, it would be activated until the first window had passed.

- When an alarm template schedule contained an overlapping window because DataMiner Cube did not detect the incorrect configuration, the overlap would not get corrected and the schedule would get activated at random times.

- When an alarm template with a schedule was updated on a DMA that was part of a DataMiner System, elements running on other DMAs in that DataMiner System would not apply the new schedule until the DMA on which the template was updated was restarted or until another alarm template update occurred on that DMA.

NT_ADD_FILE (99) has now been adapted in order to better handle alarm template changes. When NT_ADD_FILE is called and the templateDetails variable (object 2) specifies the type as “1” (alarm template), then the protocolDetails variable (object 1) will optionally receive a fourth string value: “364” (NT_INITIALIZE_SCHEDULE) or “378” (NT_CLEAR_SCHEDULE). This will specifies how the template's schedule should be reloaded in the memory of SLDataMiner.

> [!NOTE]
> When no fourth string value is passed along, it will by default be set to NT_INITIALIZE_SCHEDULE as it is capable of handling a template without a schedule.

#### DataMiner Cube - Alarm templates: Hysteresis could incorrectly be applied to 'low' severity levels for parameters of type string \[ID_30117\]

When applying hysteresis to specific alarm severity level for parameters of type string, up to now, it would incorrectly be possible to do so for “low” severity levels. From now on, for parameters of type string, it will only be possible to apply hysteresis to “high” severity levels.

> [!NOTE]
> If, for a string parameter, Hysteresis is set to “On” or “Off”, then the High and Low levels must be consistent. Both should either be enabled or disabled.

#### DataMiner Cube - Scheduler: Tasks with a type other than 'Once' would incorrectly allow you to enter a date and a time in the start date box \[ID_30140\]

When you configure a scheduled task with a type other than “Once”, you can specify a start date and an end date. Up to now, the start date box would allow you to enter a date and a time. As this is not relevant, from now on, the start date box will only allow you to enter a date.

#### DataMiner Cube - Cassandra: Information events would not have the correct properties \[ID_30178\]

When you opened an information event on a DataMiner Cube connected to a system with a Cassandra database, in some cases, that information event would not have the correct properties. The problem was due to the properties being stored incorrectly into the database.

#### DataMiner Cube - Visual Overview: Problem with session variables that control an embedded Resource Manager component \[ID_30180\]

When a Resource Manager component is embedded in a visual overview, it can be controlled by a number of session variables. For example, with YAxisResources you can set the timeline bands and with SelectedReservation you can highlight a certain booking.

Normally, the bands must be updated before a new selection is set. However, in some cases, the selection was set first, both session variables were set simultaneously, or the time line band was set via an Execute page option. From now on, when timeline bands are updated, the latest “set booking selection” will be always be set again to make sure the selection is kept even when bands are changed or updated.

#### Problem with SLElement when the hysteresis timer was activated when an element was restarted \[ID_30212\]

In some rare cases, an error could occur in SLElement when the hysteresis timer was activated at the moment when an element was restarted.

#### SLDataGateway: 'Connection was closed' error \[ID_30213\]

In some cases, a “connection was closed” error could occur in the SLDataGateway process.

#### CPU usage of SLASPConnection would surge after a service update \[ID_30242\]

On systems with a large number of services, in some cases, the CPU usage of the SLASPConnection process would temporarily surge after a service had been updated.

#### DataMiner Cube - Surveyor: Newly created element would be displayed twice after being updated \[ID_30258\]

When a newly created element was in multiple views, and at least two of these views had been opened in the Surveyor, in some cases, the element would incorrectly be displayed twice in the same view after being updated.

#### DataMiner Cube could become unresponsive when the Bookings app was closed \[ID_30261\]

In some cases, DataMiner Cube could become unresponsive when you closed the Bookings app.

#### DataMiner Cube - Visual Overview: Problem when the parent shape of a shape with an embedded Chromium web browser control had a show/hide condition configured \[ID_30270\]

In some rare cases, an exception could occur when, in a visual overview, the parent shape of a shape with an embedded Chromium web browser control had a show/hide condition configured.

#### Problem with SLElement when changing an alarm template of a DVE element that contained references to general parameters in conditional monitoring rules \[ID_30277\]

When a DVE element had its alarm template updated, was assigned a new alarm template or went to “not monitored”, in some cases, an access violation error could occur in SLElement when the alarm template contained references to general parameters in conditional monitoring rules.

#### DataMiner Cube - Services app: Same connection could incorrectly be drawn twice in diagram \[ID_30291\]

When drawing connections between nodes in a service definition diagram, in some cases, it would incorrectly be possible to draw the same connection twice.

#### Web apps: Problems with DefaultTimeZone setting \[ID_30301\]

The time displayed in the DataMiner web apps (e.g. Jobs, Dashboards, etc.) is based on the DefaultTimeZone setting in the *C:\\Skyline DataMiner\\Users\\ClientSettings.json* file.

Up to now, the following problems could occur with regard to this setting:

- When DefaultTimeZone was set to a time zone without offset (e.g. UTC), in some cases, an error message could appear.

- In the Dashboards app and the Monitoring app, the configured time zone would not always be applied correctly.

#### Cassandra cluster: Problems with cluster health monitoring & data offloads \[ID_30310\]

In some cases, an incorrect consistency level and replication factor would be used when assessing the health of the Cassandra cluster.

Also, a problem could occur when offloading data to a file.

#### DataMiner Cube - Alarm Console: Sources of correlated alarms would incorrectly not be removed from the Alarm Console \[ID_30311\]

In some rare cases, the sources of a correlated alarm would incorrectly not be removed from the Alarm Console.

#### BPA tests: Version compatibility test would fail when a BPA test was run on a Feature Release version instead of a Main Release version \[ID_30312\]

A BPA test can only be executed if it has been digitally signed by Skyline, and if your DataMiner version is within the limitations of the minimum and/or maximum DataMiner version configured in the test (if any). However, up to now, the version compatibility test would fail when a BPA test was run on a Feature Release version instead of a Main Release version.

The version compatibility test has now been adapted:

- When no minimum and/or maximum DataMiner version is specified, the BPA test will run regardless of the version.
- When a minimum and/or maximum DataMiner version is specified, the BPA test will run when the DataMiner Agent has

  - a Main Release version greater than the minimum Main Release version and smaller than or equal to the maximum Main Release version, or
  - a Feature Release version greater than the minimum Feature Release version and smaller than or equal to the maximum Feature Release version, or
  - a Release version of which the Main Release on which it is based is greater than the minimum Feature Release version and smaller or equal to the maximum Feature Release version.

#### SLNet would fail to initialize when external authentication via SAML was configured incorrectly \[ID_30318\]

When external authentication via SAML was configured incorrectly, up to now, SLNet would fail to initialize. From now on, a “Failed to build External Authentication for SAML” notice will be generated instead and SLNet will continue its initialization routine.

#### SLAnalytics: 'Division by zero' error when encountering an invalid polling time in legacy parameterInfo records \[ID_30321\]

In some cases, a “division by zero” error could occur in SLAnalytics when encountering an invalid polling time in legacy parameterInfo records.

#### DataMiner Cube - Alarm Console: Submenu of Copy command not shown in right-click menu \[ID_30334\]

When, in the Alarm Console, you selected all alarms with element name “DMA” and then right-clicked to open the shortcut menu, the submenu of the “Copy” command would incorrectly not be shown.

#### DVE elements / Virtual functions: Alarms in tables would not get re-evaluated when foreign keys linking those tables to other tables had changed \[ID_30336\]

In some cases, alarms in tables would not get re-evaluated when foreign keys linking those tables to other tables had changed.

#### Problem with SLDataMiner \[ID_30359\]

In some cases, the SLDataMiner process could become unresponsive due to a problem with its element locking mechanism.

#### Enabling or disabling a Failover setup would break the Cassandra cluster \[ID_30361\]

When either enabling or disabling a Failover setup using a Cassandra cluster, in some cases, the Cassandra cluster would break.

#### Failover: 'DB forwarding is failing' alarm would incorrectly be generated when using Cassandra Cluster \[ID_30392\]

In a Failover environment using a Cassandra Cluster, in some cases, the following alarm would incorrectly be generated:

```txt
Failover DB forwarding is failing since YYYY-MM-DD HH:MM:SS
```

#### DataMiner Cube - Visual Overview: Service definition passed in a session variable to an embedded Service Manager component would not be selected in that component \[ID_30396\]

When a service definition was passed in a session variable to an embedded Service Manager component, in some cases, that service definition would not be selected and, as a result, its diagram would not be loaded.

#### EPM: All clients would incorrectly receive view updates when one view was enhanced \[ID_30412\]

When, in an EPM environment, you enhanced a view on a particular DataMiner Agent in the DMS, all clients connected to any of the other DataMiner Agents in the DMS would incorrectly receive updates for all of the enhanced views in the system.

#### Legacy Reports & Dashboards - Alarm List: History alarms with missing ‘Hosting DataMiner ID’ & GetAlarmTreeDetailsMessage not working for imported elements \[ID_30415\]

When, in the legacy Reports & Dashboards app, the Alarm List component requested the alarm tree details, all history alarms would incorrectly have a hosting DataMiner ID equal to -1 and using the GetAlarmTreeDetailsMessage with Hosting DataMiner ID and Root Alarm ID did not work for elements imported by means of a DELT package.

#### Failover: SLASPConnection would be unaware of the local DMA ID \[ID_30416\]

On a Failover setup, part of the SLASPConnection process would be unaware of the local DataMiner ID. In some cases, this could lead to “Handle Notifications Thread” errors.

#### Security: Problems when adding domain users and domain groups \[ID_30428\]

In some cases, a problem could occur when adding a domain user or a domain group to DataMiner.

#### Dashboards app - GQI: Queries could cease to function when items used in those queries were renamed \[ID_30436\]

Up to now, in some cases, a GQI query could cease to function when items used in that query (e.g. parameters, profile definitions, etc.) were renamed.

#### Dashboards app - State timeline: Problem with state change highlighting in Mozilla Firefox \[ID_30446\]

When using the Dashboards app in Mozilla Firefox, the state timeline component would not highlight the correct state change when you hovered over the component.

#### DataMiner Cube: Problem when opening a service \[ID_30471\]

In DataMiner Cube, in some cases, a stack overflow exception could be thrown when you opened a service.

#### Incorrect exceptions thrown when installing a DataMiner upgrade package \[ID_30516\]

When you install a DataMiner upgrade package, a number of checks are performed before the upgrade is started. In some cases, one of those checks would throw incorrect ZipExceptions.

#### DataMiner Cube - Visual Overview: Asterisk in shape text of an 'Info' shape would not be replaced when the shape text contained more than just the asterisk \[ID_30534\]

When the shape text of an “Info” shape contained more than just an asterisk (“\*”), in some cases, the asterisk would not be replaced with the information specified in the Info shape data field.

#### DataMiner Cube - Tab layout: Clicking e.g. an element multiple times would incorrectly each time open a new instance of the card in question \[ID_30541\]

When in tab layout, clicking e.g. an element multiple times would incorrectly each time open a new instance of the card in question.

> [!NOTE]
> When, on a visual overview, you click a button to navigate to another card and then click the *Back* button, in some cases, clicking the button to navigate to another card a second time may no longer open that other card.

#### Legacy Reporter app - Bookings component: Not possible to select properties \[ID_30547\]

When, in the legacy Reporter app, you had created a report template with a booking component of which the type was set to “list”, in some cases, it would not be possible to select properties to be included in the report.

#### DataMiner Cube - Data Display: Table cells would not contain their current value when in edit mode \[ID_30553\]

In some cases, when you had changed a value in a table cell, and then clicked inside that same cell to change the value again, the cell would not contain the current value. Instead, it would contain the value it contained before the first change.

#### DataMiner Cube - Service & Resource Management: Missing icons in service definitions \[ID_30619\]

In some cases, icons could be missing in service definitions because SVG content could not be loaded.

#### Dashboards & Monitoring apps - Popups no longer working \[ID_30797\]

In the Dashboards app and the Monitoring app, in some cases, no popup would appear when you clicked a page button.
