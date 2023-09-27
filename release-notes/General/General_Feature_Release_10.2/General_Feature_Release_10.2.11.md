---
uid: General_Feature_Release_10.2.11
---

# General Feature Release 10.2.11

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.2.11](xref:Cube_Feature_Release_10.2.11).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Security enhancements [ID_33945] [ID_34251]

A number of security enhancements have been made relating, amongst others, to external authentication via RADIUS.

#### Ticketing app: Enhanced error handling [ID_33414]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

Because of a number of enhancements, overall error handling has improved.

#### Dashboards: An EPM feed can now be used to feed EPM identifiers to a parameter feed [ID_33977]

<!-- MR 10.3.0 - FR 10.2.11 -->

An EPM feed can now be used to feed EPM identifiers to a parameter feed.

#### Performance improvement to update service state more quickly [ID_34165]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

Because of a performance improvement, the calculated service alarm state will now be updated more quickly in the client.

#### Low-Code Apps: Data input via URL [ID_34261]

<!-- MR 10.3.0 - FR 10.2.11 -->

Low-code apps can now be provided with data (e.g. element data, parameter data, view data, etc.) via URL query parameters.

To do so, add a URL query parameter with key *data*. The value should be a URL-encoded JSON object with the following structure:

- *v*: version number (currently always 1)
- *components*: an array of component input objects

```json
{
   v: <version-number>;
   components: <component-data>;
}
```

The component input objects (component-data) have the following structure:

```json
{
   cid: <component-id>,
   select: <data>
}
```

In the following example, the URL selects one default element on the initial page:

- component ID = 1
- element ID = 1/6

```txt
https://<dma>/<app-id>?data=%7B%22v%22:1,%22components%22:%5B%7B%22cid%22:1,%22select%22:%7B%22elements%22:%5B%221%2F6%22%5D%7D%5D%7D%7D
```

#### Dashboards app: Filtering a parameter feed that lists EPM parameters [ID_34287]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.11 -->

When an EPM identifier from an EPM feed is fed to a parameter feed, it will now be possible to drag multiple parameters onto the parameter feed in order to use them as filters.

#### Enhanced performance when querying large XML files [ID_34299]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

Because of a number of enhancements made to SLXML, overall performance has increased when querying large XML files.

#### GQI: Enhanced performance of the ProfileInstance data source [ID_34320]

<!-- MR 10.3.0 - FR 10.2.11 -->

Because of a number of enhancements, overall performance has increased when running a GQI query using the ProfileInstance data source.

#### Web apps - Interactive Automation scripts: Enhanced performance [ID_34348]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

Because of a number of enhancements to the buffering mechanism, overall performance has improved when executing interactive Automation scripts in web apps.

#### SLLogCollector will now also collect the prerequisite output files and all upgrade logs [ID_34352]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

The SLLogCollector tool will also collect all prerequisite output files as well as all upgrade logs.

#### SLNet / SLDataGateway: Enhanced algorithm to find the first valid physical address of the DataMiner Agent [ID_34360]

<!-- MR 10.3.0 - FR 10.2.11 -->

A number of enhancements have been made to the algorithm used by SLNet and SLDataGateway to find the first valid physical address of the DataMiner Agent.

#### Lingering connections towards a DataMiner Agent will now be forcefully killed [ID_34367]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

In some cases, connections between DMAs can leak TCP connections, causing new connections towards port 8004 to fail due to port exhaustion.

Up to now, when a new connection towards port 8004 failed, the following entry was logged in the SLNet log file:

``` txt
Connection to {0} via external process succeeds while same connection via SLNet process fails since {1} ({2} times) => possible lingering TCP connections issue
```

From now on, the connection in question will also be forcefully killed.

#### Web apps - Interactive Automation script components: Minor enhancements [ID_34373]

<!-- MR 10.3.0 - FR 10.2.11 -->

A number of minor enhancements have been made to the interactive Automation script components with regard to font styles, button styles, text alignment and button and checkbox height.

#### Dashboards app / Low-Code Apps: GQI queries now support sort operators [ID_34414] [ID_34528] [ID_34479]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.11 -->

In dashboards and low-code apps, you can now add sort operators to GQI queries.

After selecting a data source, do the following:

1. Select a *Sort* operator.
1. Select the column to sort on.
1. Select *Ascending* if you want to sort in ascending order instead of descending order.

#### 'Repair DB.bat' script now also supports MySQL Server 5.5 [ID_34429]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

The `Repair DB.bat` script, located in the `C:\Skyline DataMiner\Tools` folder, now also supports MySQL Server 5.5.

#### Dashboards app / Low-Code Apps: An eye icon will now appear when you make a modification to a GQI table [ID_34445]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.11 -->

When you make one of the following modifications to a GQI table, an eye icon will now appear in the header of the table component.

- Change the sorting
- Apply a grouping
- Change the order of the columns
- Change the width of the columns
- Apply a column filter (using the context menu that appears when right-clicking a column header)

This eye icon will make you aware that the table is no longer identical to the one that was loaded originally. Clicking it will reset all modifications.

#### DataMiner web apps updated to Angular 14 [ID_34447]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.11 -->

The DataMiner mobile apps that use Angular (e.g. Low-Code Apps, Dashboards, Monitoring, Ticketing, Jobs, and Automation) now use Angular 14 instead of Angular 13.

#### Dashboards app / Low-Code Apps: Enhanced filtering by protocol [ID_34453]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.11 -->

From now on, when you add a protocol filter to a component without specifying any particular version(s), that filter will return all data related to that protocol irrespective of protocol version. If you want the data in the component to be filtered by a specific version of the protocol in question, you can select that version from the protocol filter box.

#### GQI: New 'IsActive' column added to 'Get alarms' data source [ID_34455]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.11 -->

A new *IsActive* column has been added to *Get alarms* data source. This column will be set to true when the alarm is an active alarm.

#### Timers: Specifying an interval between two consecutive ping packets [ID_34463] [ID_34549]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.11 -->

When you configure a timer to automatically send ping requests to a device, you can now use either the `interval` option or the `intervalPid` option to specify the interval in ms between two consecutive ping packets.

- `interval`: With this option, you can specify a fixed interval in ms between two consecutive ping packets. This should be used when the device does not respond to all ping requests when they are sent without any interval.

- `intervalPID`: Instead of specifying a fixed interval value ("interval=x"), it is also possible to specify a dynamic value stored in a parameter. Note that if you specify both a fixed and a dynamic value, the latter will take precedence.

    The value in the referred parameters must not be 0 or uninitialized. Otherwise, 0, the hard-coded value on the timer, or the last valid value will be used by default. The referred parameters must be of numeric type.

> [!NOTE]
> These options are only relevant when *amountPackets* or *amountPacketsPID* is used. These are currently only supported in conjunction with the *threadPool* option. When *threadPool* is not used, only one ping request will be sent.

#### Dashboards app - Parameter feed: 'Auto-select all' setting no longer available when using an EPM identifier feed as source [ID_34501]

<!-- MR 10.3.0 - FR 10.2.11 -->

When a parameter feed has an EPM identifier feed as source, from now on, the *Auto-select all* setting will no longer be available.

#### Dashboards app & Low-Code Apps: Enhanced performance of node-edge components [ID_34517]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

Because of a number of enhancements, overall performance of node-edge components has improved, especially on large systems.

### Fixes

#### Failover: Offline agent would fail to come online when the NATS cluster was down during a Failover switch [ID_33681]

<!-- MR 10.3.0 - FR 10.2.11 -->

When, during a Failover switch, the NATS cluster was down, the offline agent would fail to come online.

#### GQI - Elasticsearch: Aggregated data did not have the number of decimals specified in the parameter info [ID_33712]

<!-- MR 10.3.0 - FR 10.2.11 -->

Aggregated data retrieved from an Elasticsearch database did not have the number of decimals specified in the parameter info.

#### Dashboard Gateway (legacy): Dashboards would fail to show the Maps component when the DMA had HTTPS configured [ID_33777]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

When a legacy Dashboard Gateway was connected to a DataMiner Agent with HTTPS configured and port 80 blocked, dashboards would fail to show the Maps component.

#### Protocols - Multi-threaded timers: Empty poll groups would cause SLProtocol to send empty SNMP requests to SLSNMPManager [ID_33900]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

When multi-threaded timers were used in an SNMP protocol, the timer would incorrectly always execute the poll group, even if it did not specify any OIDs to be polled.

From now on, an empty group will no longer cause SLProtocol to send an empty SNMP request to SLSNMPManager.

#### Problem with SLProtocol when testing protocol connections [ID_34036]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

When a protocol connection was tested, the CProtocol object created in SLProtocol for that test would neither get cleared nor deleted when the connection test had finished. In other words, the element would not get unloaded. This would cause SLProtocol to leak each time a protocol connection was tested.

#### Problem when deserializing an overridden parameter description [ID_34266]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

When a JSON string containing an overridden parameter description was deserialized to an ElementInfo message, in some cases, an exception would be thrown.

#### Interactive Automation scripts: Problem when entering an invalid value in a numeric component [ID_34310]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

When you entered an invalid value in a numeric component, the *UIResults.GetString()* method would incorrectly not return that invalid value. Instead, it returned the last valid value that had been entered.

#### Web apps - Interactive Automation scripts: Not possible to clear a selection box by selecting an empty option [ID_34315]

<!-- MR 10.3.0 - FR 10.2.11 -->

When an interactive Automation script was executed in a web app, it would incorrectly not be possible to clear a selection box by selecting an empty option.

#### Dashboards app - Service definition component: Function type 'TimeStartEvent' would not be visualized correctly [34316]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.11 -->
<!-- Not added to 10.3.0 -->

When a Process Automation definition is added to the Service definition component, the added function shapes will reflect the function type (UserTask, ScriptTask, ResourceTask, Gateway, NoneStartEvent, TimeStartEvent or EndEvent). However, in some cases, the function type *TimeStartEvent* would not be visualized correctly. From now on, these will be assigned a BPMN reference time icon.

#### Service & Resource Management: Resource property definition names would contain illegal characters after SRM data had been migrated to Elasticsearch [ID_34361]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.11 -->
<!-- Not added to 10.3.0 -->

After SRM data had been migrated to Elasticsearch, in some cases, resource property definition names would contain characters that Elasticsearch considers illegal.

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

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

Users who had not been granted the *Modules > Documents > UI available* permission would incorrectly be able to view documents in the legacy Reporter app.

From now on, an error message will be displayed when users without the above-mentioned permission try to view a document in the legacy Reporter app.

#### Dashboards app: Problem with invalid URL parameters [ID_34405]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

In some cases, an error could occur when invalid parameters were passed to a dashboard in the URL (e.g. invalid time spans).

#### 'One or more of the following modules are not licensed' error would incorrectly not list the unlicensed modules [ID_34407]

<!-- MR 10.1.0 [CU22] / 10.2.0 [CU10] - FR 10.2.11 -->

When a required software license cannot be found, a `One or more of the following modules are not licensed: ...` message will appear.

In some cases, instead of listing the unlicensed modules, this message would incorrectly only mention "None".

#### Dashboards app: Not possible to access the query column selection box of a newly created query [ID_34410]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

In some cases, it would not be possible to access the query column selection box of a newly created query.

#### Dashboards app: Side panel context menu and selected dashboard would overlap each other [ID_34411]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

When you opened the context menu of the side panel, in some cases, the context menu and the dashboard selected in the list would overlap each other.

#### Web Services API - CreateServiceTemplate: DataMinerID and ElementID incorrectly set to 0 instead of -1 [ID_34440]

<!-- MR 10.3.0 - FR 10.2.11 -->

When a service template was created using the *CreateServiceTemplate* method, the DataMinerID and ElementID of the newly created service template would incorrectly be set to 0 instead of -1.

#### Elasticsearch: Problem when migrating large alarm trees from the active-alarms index to an index containing closed alarms [ID_34444]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

When an alarm tree with more than 1,000 alarms was migrated from the *active-alarms* index to an index containing closed alarms, in some cases, alarms could get lost.

#### Web Services API: Problem when calling the GetBooking or GetBookings method via SOAP [ID_34466]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

When the GetBooking or GetBookings method was called via SOAP, in some cases, a serialization exception could be thrown when the booking (in case of GetBooking) or one of the bookings (in case of GetBookings) had a property that contained a TimeSpan object.

#### Problem during midnight synchronization would cause '200+ clients connected to this agent' errors to appear [ID_34450]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

During a midnight synchronization, in some cases, ResourceManager subscriptions could incorrectly get duplicated, causing `200+ clients connected to this agent` errors to appear in the Alarm Console.

#### Problem with SLDMS while a connection with another agent was being established or cleaned up [ID_34452]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

In some rare cases, an error could occur in SLDMS while a connection with another agent was being established or cleaned up.

#### Web apps: URL option 'subheader=' would no longer work [ID_34456]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

When, in the URL of a web app (e.g. Dashboards, Ticketing, etc.), you had specified `subheader=true` or `subheader=false` in combination with `embed=true`, that `subheader=` option would no longer work.

Example of a dashboard URL containing a `subheader=true` option:

```txt
https://[DMA IP]/dashboard/#/MyDashboards/dashboard.dmadb?embed=true&subheader=true
```

#### Dashboards app: List of available dashboards would not be displayed when using a Dashboard Gateway server [ID_34468]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

When you opened the Dashboards app via a Dashboard Gateway server, in some cases, the list of available dashboards would incorrectly not be displayed in the sidebar.

#### Alerter would leak memory when configured to play a sound when alarms matched a certain filter [ID_34473]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

When Alerter had been configured to play a sound when alarms matched a certain filter, it could leak memory.

#### Web apps: List box items not displayed correctly in embedded visual overviews [ID_34474]

<!-- MR 10.2.0 [CU9] - FR 10.2.11 -->

In an embedded visual overview, in some cases, list box items would not be displayed correctly.

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

<!-- MR 10.0.0 [CU22]/10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

When a trap binding of type "IP Address" came in while the SLSNMPManager SNMPv3 process was processing traps on the default port 162, that binding would be incorrectly parsed as an empty string.

#### DataMiner Taskbar Utility: Upgrade process displayed in Taskbar Utility would lag behind [ID_34488]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

After you had launched an upgrade, in some cases, the upgrade process displayed in DataMiner Taskbar Utility would lag behind and DataMiner Taskbar Utility would use a considerable amount of memory.

This fixes a [known issue](xref:KI_Taskbar_Utility_performance_issue_while_agents_are_being_upgraded).

#### Cassandra cluster: Memory leak when real-time trend data was requested via a paged database request [ID_34514]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 [CU0] -->

When, on a Cassandra cluster, real-time trend data was requested via a paged database request, in some cases, the cookie would incorrectly not cleaned, leading to increased memory consumption.

#### Dashboards / Low-Code Apps: Changing a GQI query would not cause a table to get updated when column filters were applied [ID_34520]

<!-- MR 10.3.0 - FR 10.2.11 -->

When the GQI query linked to a table component was changed, the table would incorrectly not get updated when column filters were applied. The table would only get updated when you changed the column filters.
