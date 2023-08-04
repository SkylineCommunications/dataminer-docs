---
uid: General_Main_Release_10.2.0_CU8
---

# General Main Release 10.2.0 CU8

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Security enhancements [ID_33945] [ID_34251]

A number of security enhancements have been made relating, amongst others, to external authentication via RADIUS.

#### Ticketing app: Enhanced error handling [ID_33414]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

Because of a number of enhancements, overall error handling has improved.

#### Performance improvement to update service state more quickly [ID_34165]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

Because of a performance improvement, the calculated service alarm state will now be updated more quickly in the client.

#### Improved performance of SLDataGateway process [ID_34206]

<!-- MR 10.2.0 [CU8] - FR 10.2.10 -->

Because of improved internal logic, the performance of the SLDataGateway process has improved.

#### DataMiner Cube - Service & Resource Management: Function resource icons are now centered in service definition diagrams [ID_34249]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

In service definition diagrams, function resource icons are now centered.

#### Enhanced performance when querying large XML files [ID_34299]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

Because of a number of enhancements made to SLXML, overall performance has increased when querying large XML files.

#### DataMiner Cube - Resources app: Removing resources from all pools [ID_34311]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

When you move one or more resources from a pool to the *(uncategorized)* pool, a confirmation box will now appear to warn you that, if you click *Yes*, the resources in question will be removed from all pools.

#### DataMiner Cube - Visual Overview: Service context of a linked shape will only be determined when the service context has been specified [ID_34340]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

When a shape was linked to an element that was not part of a service, up to now, an attempt would be made to determine the service context even when no service context had been specified. From now on, the service context will only be determined when the service context has been specified in the shape.

#### Web apps - Interactive Automation scripts: Enhanced performance [ID_34348]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

Because of a number of enhancements to the buffering mechanism, overall performance has improved when executing interactive Automation scripts in web apps.

#### DataMiner Cube - Visual Overview: Enhanced performance when sorting dynamically positioned shapes [ID_34351]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

Because of a number of enhancements, overall performance has increased when sorting dynamically positioned shapes.

#### SLLogCollector will now also collect the prerequisite output files and all upgrade logs [ID_34352]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

The SLLogCollector tool will also collect all prerequisite output files as well as all upgrade logs.

#### DataMiner Cube - Visual Overview: Enhanced shape positioning [ID_34356]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

Because of a number of enhancements, overall performance has increased when setting the X and Y position of a shape.

#### Lingering connections towards a DataMiner Agent will now be forcefully killed [ID_34367]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

In some cases, connections between DMAs can leak TCP connections, causing new connections towards port 8004 to fail due to port exhaustion.

Up to now, when a new connection towards port 8004 failed, the following entry was logged in the SLNet log file:

``` txt
Connection to {0} via external process succeeds while same connection via SLNet process fails since {1} ({2} times) => possible lingering TCP connections issue
```

From now on, the connection in question will also be forcefully killed.

#### DataMiner Cube - Visual Overview: Caching of user settings in order to enhanced performance [ID_34383]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

In Visual Overview, the current value of the following user settings will now be cached in order to enhance performance:

- *Open element cards undocked* (*Settings* window)
- *AlarmSettings.Blinking* (*MaintenanceSettings.xml* file)

#### DataMiner Cube - Visual Overview: Enhanced performance when determining whether a shape is clickable [ID_34386]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

A number of enhancements have been made to the procedure called to determine whether a shape is clickable.

#### DataMiner Cube - System Center: New DataMiner log file 'SLRADIUS.txt' [ID_34396]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 [CU0] -->

In the *Logging* section of *System Center*, you can now also consult the *SLRADIUS.txt* log file.

#### 'Repair DB.bat' script now also supports MySQL Server 5.5 [ID_34429]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

The `Repair DB.bat` script, located in the `C:\Skyline DataMiner\Tools` folder, now also supports MySQL Server 5.5.

#### Dashboards app / Low-Code Apps: Enhanced performance of node-edge components [ID_34517]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

Because of a number of enhancements, overall performance of node-edge components has improved, especially on large systems.

### Fixes

#### Elasticsearch: NewPagingSearchRequest was incorrectly not able to query an alias grouping two logger tables [ID_31767]

<!-- MR 10.2.0 [CU8] - FR 10.2.2 -->

Up to now, a NewPagingSearchRequest was incorrectly not able to retrieve data from an alias that grouped two logger tables.

#### Dashboard Gateway (legacy): Dashboards would fail to show the Maps component when the DMA had HTTPS configured [ID_33777]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

When a legacy Dashboard Gateway was connected to a DataMiner Agent with HTTPS configured and port 80 blocked, dashboards would fail to show the Maps component.

#### Dashboards app / Low-Code Apps: Tooltips of certain visualizations would not be aligned correctly [ID_33844]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version TBD -->

In some cases, tooltips of certain visualizations would not be aligned correctly.

#### Protocols - Multi-threaded timers: Empty poll groups would cause SLProtocol to send empty SNMP requests to SLSNMPManager [ID_33900]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

When multi-threaded timers were used in an SNMP protocol, the timer would incorrectly always execute the poll group, even if it did not specify any OIDs to be polled.

From now on, an empty group will no longer cause SLProtocol to send an empty SNMP request to SLSNMPManager.

#### Elasticsearch: Closed alarms were incorrectly not migrated to the dms-alarms index when the associated element had been migrated from another DMS [ID_34020]

<!-- MR 10.2.0 [CU8] - FR 10.2.9 -->

When, on a system with an Elasticsearch database, an alarm was closed, that alarm would incorrectly not get moved from the dms-Activealarms index to the dms-alarms index when the associated element had been migrated from another DMS.

#### Problem with SLProtocol when testing protocol connections [ID_34036]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

When a protocol connection was tested, the CProtocol object created in SLProtocol for that test would neither get cleared nor deleted when the connection test had finished. In other words, the element would not get unloaded. This would cause SLProtocol to leak each time a protocol connection was tested.

#### DataMiner Cube - Visual Overview: Problem with conditional shape manipulation actions 'Show' and 'Hide' [ID_34108]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

When, in a particular shape, you had specified a *Show* or *Hide* action with a condition, the shape would incorrectly always be visible, whether the condition was true or false.

#### DataMiner Cube - Trending: Y axis would incorrectly show other values when the trend graph showed a constant exception value [ID_34242]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

When you opened a trend graph that only showed a constant exception value, the Y axis would incorrectly not only show the exception value but also a number of other values. In cases like this, from now on, the Y axis will only show the exception value.

#### Problem when deserializing an overridden parameter description [ID_34266]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

When a JSON string containing an overridden parameter description was deserialized to an ElementInfo message, in some cases, an exception would be thrown.

#### DataMiner Cube - Trending: Y-axis values did not take into account the number of decimals configured in the protocol.xml file [ID_34269]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

When you opened a trend graph, the Y-axis values would incorrectly not take into account the number of decimals configured in the *protocol.xml* file for the parameters in question.

#### Interactive Automation scripts: Problem when entering an invalid value in a numeric component [ID_34310]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

When you entered an invalid value in a numeric component, the *UIResults.GetString()* method would incorrectly not return that invalid value. Instead, it returned the last valid value that had been entered.

#### DataMiner Cube - Alarm Console: Negative counters in the footer bar [ID_34318]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

On systems with active correlation rules, in some rare cases, the counters in the footer bar of the Alarm Console could show negative numbers.

#### DataMiner Cube - EPM: Not possible to add a second parameter to a trend graph of an EPM object [ID_34323]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

When you opened a trend graph of an EPM object, it would not be possible to add a second parameter. After you had added a new parameter, the drop-down box would incorrectly only contain the current parameter.

#### DataMiner Cube - Booking app: Booking updates would cause the UI to flicker [ID_34349]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

When one of the listed bookings was updated, all bookings would incorrectly be re-rendered, causing the UI to flicker.

#### DataMiner Cube - Spectrum analysis: Preset would not be loaded when clicking 'View buffer' [ID_34357]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

When, in a Spectrum card, you clicked *View buffer*, the preset contained inside the buffer would incorrectly not be loaded. As a result, incorrect threshold values would be displayed.

#### Dashboards app / Low-Code Apps: Creating a custom theme with a custom color palette would incorrectly cause the color palette of all built-in themes to be updated [ID_34368]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

Creating a custom theme with a custom color palette would incorrectly cause the color palette of all built-in themes to be updated.

#### Legacy Reporter: Custom files attached to a PDF report in plain text format would not be sent along [ID_34369]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

When, using the legacy Reporter app, you sent a PDF report in "plain text" format, any custom files attached to the report would incorrectly not be sent along.

#### Dashboards app: Email reports would incorrectly not include CSV files when the 'Include CSV' option had been selected [ID_34370]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

In some cases, email reports would incorrectly not include CSV files when the *Include CSV* option had been selected.

#### Low-Code Apps: Problem when creating a new component theme [ID_34372]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

When you created a new component theme while a built-in dashboard theme was active, in some cases, a Web Services API error could occur.

#### DataMiner Cube - Visual Overview: Problem when receiving a DCF connection line update [ID_34375]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

An error could occur when the client received a DCF connection line update.

#### Problem when processing a history set with a timestamp referring to a moment far in the past [ID_34378]

<!-- MR 10.2.0 [CU8] - FR TBD -->

When SLElement was processing a history set, an error could occur when the timestamp of that history set referred to a moment far in the past.

#### Problem with SLProtocol when reading incorrectly configured port settings [ID_34379]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

In some cases, an error could occur in SLProtocol when reading incorrectly configured port settings.

#### Dashboards app: URL parameter data would not be parsed correctly [ID_34380]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

In some cases, parameter data in a dashboard URL would incorrectly only get parsed when followed by a forward slash ("/").

#### Dashboards app: Renaming, duplicating or importing a dashboard would break the feeds inside the queries used in that dashboard [ID_34382]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

When you renamed, duplicated or imported a dashboard, in some cases, the feeds inside the queries used in that dashboard would get broken.

#### Problem with SLLog when closing a log file [ID_34385]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

In some cases, an error could occur in SLLog when closing a log file.

#### Automation: Retrieving active alarms with the 'WithActiveAlarmsOnly()' option would not work without filtering by element [ID_34388]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

When active alarms were retrieved via an Automation script, an incorrect result set could get returned when no element filter had been applied.

Example of C# code that would return an incorrect result set:

```csharp
var query = new TRUEFilterElement<Alarm>().OrderBy(AlarmExposers.TimeOfArrival)
    .WithExecutionOptions(options => options.WithTargetHop(QueryTargetHopOptions.All)
    .WithSpecificQueryExecutionOptions(AlarmQueryOptions.Default.WithAlarmsPostProcessed().WithActiveAlarmsOnly()));
var alarms = alarmRepository.CreateReadQuery(query).Execute().ToList();
```

#### DataMiner Cube - Visual Overview: Problem when the Parameter shape data field of a range slider control contained a dynamic placeholder referring to a session variable [ID_34389]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

When the shape data field *Parameter* of a range slider control contained a dynamic placeholder referring to a session variable, it would no longer be possible to move the slider when the value of the session variable changed from valid to invalid or vice versa.

#### Failover: Incorrect 'Cluster name of agents doesn't match' error when main agent was unable to make contact with the offline agent [ID_34393]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

When the online agent was unable to make contact with the backup agent, the failover status window could incorrectly show a "Cluster name of agents doesn't match" error.

#### Dashboards app: Sharing menu would incorrectly contain a 'Copy URL' command in HTTP setups [ID_34395]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

In HTTP setups, up to now, the dashboard sharing menu would incorrectly contain a non-functioning *Copy URL* command.

From now on, in HTTP setups, the dashboard sharing menu will no longer contain this command.

#### Dashboards app: Special characters in exported CSV files would be displayed incorrectly [ID_34400]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

When a CSV file exported via a dashboard component or attached to an email report was opened in e.g. Microsoft Excel, any special characters in that CSV file would be displayed incorrectly.

#### Legacy Reporter app: Users without 'Modules > Documents > UI available' permission would incorrectly be able to view documents [ID_34402]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

Users who had not been granted the *Modules > Documents > UI available* permission would incorrectly be able to view documents in the legacy Reporter app.

From now on, an error message will be displayed when users without the above-mentioned permission try to view a document in the legacy Reporter app.

#### Dashboards app: Problem with invalid URL parameters [ID_34405]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

In some cases, an error could occur when invalid parameters were passed to a dashboard in the URL (e.g. invalid time spans).

#### Dashboards app: Not possible to access the query column selection box of a newly created query [ID_34410]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

In some cases, it would not be possible to access the query column selection box of a newly created query.

#### Dashboards app: Side panel context menu and selected dashboard would overlap each other [ID_34411]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

When you opened the context menu of the side panel, in some cases, the context menu and the dashboard selected in the list would overlap each other.

#### DataMiner Cube - Visual Overview: Fix multiple script executions on page shape data change [ID_34412]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

When, on page level, you had configured a data field of type *Execute* containing multiple *Set* actions with placeholders as well as a *Script* action, the script would incorrectly get executed multiple times when the page was opened.

#### DataMiner Cube - Alarm Console: Problem when loading an alarm tab with hyperlink columns [ID_34420]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

In some cases, DataMiner Cube could become unresponsive when loading an alarm tab with hyperlink columns, especially when that alarm tab contained a large number of alarms.

#### DataMiner Cube: EPM diagrams would incorrectly get mixed up when selecting a formerly selected field in an EPM filter box [ID_34431]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

When, in an EPM filter box, you selected a field, selected another field, and then selected the first field again, in some cases, the diagrams linked to those two fields would incorrectly get mixed up.

#### Elasticsearch: Problem when migrating large alarm trees from the active-alarms index to an index containing closed alarms [ID_34444]

<!-- 10.2.0 [CU8] - FR 10.2.11 -->

When an alarm tree with more than 1,000 alarms was migrated from the *active-alarms* index to an index containing closed alarms, in some cases, alarms could get lost.

#### Problem during midnight synchronization would cause '200+ clients connected to this agent' errors to appear [ID_34450]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

During a midnight synchronization, in some cases, ResourceManager subscriptions could incorrectly get duplicated, causing `200+ clients connected to this agent` errors to appear in the Alarm Console.

#### Problem with SLDMS while a connection with another agent was being established or cleaned up [ID_34452]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

In some rare cases, an error could occur in SLDMS while a connection with another agent was being established or cleaned up.

#### Web apps: URL option 'subheader=' would no longer work [ID_34456]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

When, in the URL of a web app (e.g. Dashboards, Ticketing, etc.), you had specified `subheader=true` or `subheader=false` in combination with `embed=true`, that `subheader=` option would no longer work.

Example of a dashboard URL containing a `subheader=true` option:

```txt
https://[DMA IP]/dashboard/#/MyDashboards/dashboard.dmadb?embed=true&subheader=true
```

#### Web Services API: Problem when calling the GetBooking or GetBookings method via SOAP [ID_34466]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

When the GetBooking or GetBookings method was called via SOAP, in some cases, a serialization exception could be thrown when the booking (in case of GetBooking) or one of the bookings (in case of GetBookings) had a property that contained a TimeSpan object.

#### Dashboards app: List of available dashboards would not be displayed when using a Dashboard Gateway server [ID_34468]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

When you opened the Dashboards app via a Dashboard Gateway server, in some cases, the list of available dashboards would incorrectly not be displayed in the sidebar.

#### Alerter would leak memory when configured to play a sound when alarms matched a certain filter [ID_34473]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

When Alerter had been configured to play a sound when alarms matched a certain filter, it could leak memory.

#### Service impact of an alarm could be incorrect [ID_34475]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

In some cases, the service impact of an alarm would be incorrect

- when the column parameter was partially included with a primary key filter without a wildcard and any other filter (primary filter with a wildcard, display key filter with or without a wildcard), or

- when the row included in the service via a filter is updated via an NT_SET_ROW call that triggers both a new alarm and a display key change.

#### Dashboards app / Low-Code Apps: Problem with slider ranges [ID_34477]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

When the range of a slider control did not have a span (i.e. when start was equal to end), both the start value and the end value of the range would incorrectly be NaN values.  

Also, when the range of a slider control had values outside of the minimum/maximum range, the start and end values would both be set to Infinity. From now on, the minimum and maximum values will be adapted to the actual start and end values.

#### SLSNMPManager: Trap binding of type 'IP Address' would incorrectly be parsed as an empty string [ID_34481]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

When a trap binding of type "IP Address" came in while the SLSNMPManager SNMPv3 process was processing traps on the default port 162, that binding would be incorrectly parsed as an empty string.

#### DataMiner Taskbar Utility: Upgrade process displayed in Taskbar Utility would lag behind [ID_34488]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

After you had launched an upgrade, in some cases, the upgrade process displayed in DataMiner Taskbar Utility would lag behind and DataMiner Taskbar Utility would use a considerable amount of memory.

This fixes a [known issue](xref:KI_Taskbar_Utility_performance_issue_while_agents_are_being_upgraded).

#### GQI - Aggregation GroupBy changes cellValue type [ID_34490]

<!-- MR 10.2.0 [CU8] - FR TBD -->

When, in a GQI query, you applied a "Group By" operator that grouped by a column, the values of that column would incorrectly be changed to type `string`.

For example, when you grouped by a column containing boolean values, those values would all be displayed as true. Also, when you applied other operators to that same column that contained boolean values, those other operators would work incorrectly because, although the column type would be `boolean`, the cell values would incorrectly be strings.

#### Cassandra cluster: Memory leak when real-time trend data was requested via a paged database request [ID_34514]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 [CU0] -->

When, on a Cassandra cluster, real-time trend data was requested via a paged database request, in some cases, the cookie would incorrectly not cleaned, leading to increased memory consumption.

#### DataMiner Cube - Alarm Console : Problem when loading an alarm tab [ID_34539]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

When a new alarm tab with a large number of correlated alarms was being loaded, in some cases, an exception could be thrown and the alarm tab would keep on loading.

#### SLProtocol could leak memory when a protocol with HTTP connections sent an HTTP request with a header [ID_34775]

<!-- MR 10.1.0 [CU20] / 10.2.0 [CU8] - FR 10.2.11 [CU1] -->

When a protocol with HTTP connections sent an HTTP request with a header, SLProtocol could leak memory.
