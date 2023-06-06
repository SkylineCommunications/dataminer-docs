---
uid: General_Main_Release_10.2.0_CU13
---

# General Main Release 10.2.0 CU13

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Enhanced performance when creating or editing services [ID_35366]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

Because of a number of enhancements made with regard to the communication between SLDataMiner and SLDMS, overall performance has increased when creating or editing services, especially in heavily loaded environments.

#### Enhanced SNMP trap distribution [ID_35480]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

From now on, stopped elements will no longer be taken into account when distributing SNMP traps. When a trap has to be sent to an element on another DataMiner Agent, it will no longer be sent when that element is stopped.

#### Bookings app: Default window of timeline area now set to '-8 hours <NOW> +16 hours' [ID_35525]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

In the *Bookings* app, the default window of the timeline area has now been changed from `-1 day <NOW> +1 day` to `-8 hours <NOW> +16 hours`.

This also means that a ListView component configured to list bookings will by default have its *StartTime=* and *EndTime=* options set to `NOW - 8 hours` and `NOW + 16 hours` respectively.

#### SLAnalytics - Automatic incident tracking: Focus value updates will no longer be taken into account when determining whether the maximum group event rate was exceeded [ID_35545]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

From now on, focus value updates will no longer be taken into account when determining whether the *Maximum group event rate* was exceeded.

#### Web Services API v1: Updated descriptions of GetAlarmHistory and GetAlarmDetails methods [ID_35651]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

In the following interface files, the descriptions of the *GetAlarmHistory* and *GetAlarmDetails* methods have been updated:

```txt
http://DmaNameOrIpAddress/API/v1/soap.asmx
http://DmaNameOrIpAddress/API/v1/json.asmx
```

New description of the *GetAlarmHistory* method:

> Get the alarm history for the specified alarm (optional full tree request). Use root alarm ID with requestFullTree for the details of a cleared non-root alarm.

New description of the *GetAlarmDetails* method:

> Get the alarm details for the specified alarm (use GetAlarmHistory for the details of a cleared non-root alarm).

#### Security enhancements [ID_35667]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

A number of security enhancements have been made.

#### SLLogCollector now also collects output of 'netstat -ano' command [ID_35674]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

SLLogCollector packages will now also include the following additional file:

| File | Contents |
|------|----------|
| Logs\Network Information\Netstat.exe -ano.txt | The output of an `netstat -ano` command. |

#### GQI: Clearer error message when querying a logger table without `RTDisplay=true` settings [ID_35706]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

A clearer error message will now be returned when you are building a query against a logger table without `RTDisplay=true` settings, neither on table level nor on column level.

#### Dashboards app & Low-Code Apps - Line & area chart component: Enhanced performance when exporting trend data to CSV [ID_35727]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

Because of a number of enhancements, overall performance has increased when exporting trend data to a CSV file.

#### Web apps - Query builder: Query node options with only a single value will no longer be displayed in a selection box [ID_35865]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU2] - FR 10.3.5 -->

In the query builder, from now on, when a query node option only has a single value, that option will no longer be displayed in a selection box.

For example, up to now, when you selected the *Get elements* data source, followed by the *Aggregate* operator, the method selection box would display "Get the". This will no longer be the case.

### Fixes

#### DataMiner upgrade: VerifyNatsRunning prerequisite could fail due to SLCloudBridge.dll having been renamed [ID_33875]

<!-- MR 10.3.0 - FR 10.2.8 [CU0] -->
<!-- Also added to MR 10.2.0 [CU13] -->

During a DataMiner upgrade, the VerifyNatsRunning prerequisite could fail due to the SLCloudBridge.dll file having been renamed to SLMessageBroker.dll in DataMiner versions 10.2.0/10.1.5.

#### Memory leak in SLNet after closing a client connection that had been using a "SLDataGateway.API" subscription set [ID_35319]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When a client connection that had been using a "SLDataGateway.API" subscription set was closed, in some rare cases, the subscription object memory would incorrectly not get cleaned up.

#### Trending: Pattern matching tags could incorrectly be defined for discrete or string parameters [ID_35368]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.3 -->

Pattern matching does not support discrete or string parameters. However, up to now, when viewing a trend graph that showed trend information for either a discrete or a string parameter, it would incorrectly be possible to define tags for pattern matching. From now on, this will no longer be possible.

#### Trending: Tag icon was displayed after you selected a section of a trend graph even though it was not possible to define tags [ID_35378] [ID_35383]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.3 -->

In some cases, when the pattern matching feature was not enabled in *System Center* > *System settings* > *analytics config*, the tag icon was displayed after you selected a section of a trend graph even though it was not actually possible to define tags.

From now on, Cube will check whether the pattern matching feature is enabled each time you open a trend graph.

#### Problem with SLElement when stopping an EPM element [ID_35439]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.3 -->

When an EPM element was stopped, in some rare cases, an error could occur in SLElement.

#### Dashboards app & Low-Code Apps - GQI: Problem with 'Update data' option when using the 'Get parameter table by ID' data source [ID_35490]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When a query using the *Get parameter table by ID* data source had the *Update data* option enabled, the component would incorrectly no longer automatically refresh the data when changes were detected.

#### Web apps - Interactive Automation scripts: Components in a row following a component with a row span greater than 1 would not be positioned correctly [ID_35504]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

In an interactive Automation script executed in a web app, components positioned in a row following a row that contained a component with a row span greater than 1 would not be positioned correctly.

> [!NOTE]
> If, in an interactive Automation script executed in a web app, a component is positioned on a cell that is overlapped by a component with a row span greater than 1, it will not be displayed.

> [!IMPORTANT]
> **BREAKING CHANGE**: If, in an interactive Automation script designed to be executed in a web app, the column property was altered to position a component at a specific spot, because of this fix, the component in question will no longer be displayed. It will be hidden by the component of which the row span is greater than 1. The component can be made visible again by changing the column property.

#### SLAnalytics : Problem after a DVE parent element had been deleted [ID_35521]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.3 -->

In some cases, an error could occur in the SLAnalytics process after a DVE parent element had been deleted.

#### DataMiner Cube - Bookings app: Initial time window was incorrect [ID_35527]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When you open the *Bookings* app, Cube adds a small offset to the time window when it requests the list of bookings from the server. Up to now, instead of subtracting 1 minute from the start time, it would incorrectly add 1 minute to it. When the initial time window was e.g. 11h00 to 12h00, it would incorrectly request the bookings from 11h01 to 12h01 instead of from 10h59 to 12h01.

Also, in some cases, the "loading" indicator of the bookings timeline would incorrectly not disappear when all bookings were loaded.

#### DataMiner Cube - Visual Overview: Problem with EnableFollowMode option of Resource Manager timeline [ID_35528]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When you had specified the *EnableFollowMode* option in the *ComponentOptions* shape data field of a shape configured to display the Resource Manager timeline, in some cases, that option would incorrectly be disabled.

From now on, when you activate the follow mode by specifying the *EnableFollowMode* option, the timeline will move along with the current time. When you navigate away from the line that represents now while follow mode is enabled, follow mode will temporarily be paused. As soon as you navigate back in view of the line that represents now, follow mode will be activated again.

#### Dashboards app: Problem with width of PDF reports [ID_35531]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU3] - FR 10.3.4 -->

When a PDF report was generated via Automation or Scheduler, in some cases, its width would be set incorrectly.

Also, in some cases, the left and right padding of PDF reports generated via Automation, Scheduler and the Dashboards app itself would be missing.

#### Failover: Profile Manager would incorrectly not be initialized on the agent that was brought online [ID_35534]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When a failover was triggered, in some rare cases, the Profile Manager would incorrectly not be initialized on the agent that was brought online.

In the Alarm Console, an error would appear with the following message:

```txt
Unexpected exception while triggering failover for BaseProfileManager: Skyline.DataMiner.Net.ManagerStore.CrudFailedException: Exception of type 'Skyline.DataMiner.Net.ManagerStore.CrudFailedException' was thrown.
```

#### Problem when modifying the production version of a protocol with an SNMPv3 connection [ID_35538]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When you modified the production version of a protocol with multiple connections, of which one was an SNMNv3 connection, in some cases, the element could lose its SNMPv3 port settings. As a result, the SLSNMPManager process would fail to initialize the SNMPv3 communication, and the following alarm would appear in the Alarm Console:

```txt
Error parsing SNMPv3 password for port: <port number> on element: <element name>
```

Also, an error could occur in SLDataMiner when you tried to re-enter the SNMPv3 port settings.

#### Low-Code Apps: Sidebar would incorrectly be displayed when there was only one visible page [ID_35544]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

Up to now, whether the sidebar was displayed or not would incorrectly depend on the number of pages. From now on, it will depend on the number of visible pages. In other words, the sidebar will only be displayed when there are at least two visible pages.

#### SLAnalytics - Automatic incident tracking: Alarm groups could incorrectly be created without a focus value [ID_35551]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

In some cases, alarm groups could incorrectly be created without a focus value.

#### Low-Code Apps: Clock components in a published low-code app would incorrectly only update when you moved the mouse [ID_35554]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

Clock components in a published low-code app would incorrectly only update when you moved the mouse.

#### Problem with parameter update throttling when subscribing to column parameters [ID_35578]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When a client subscribed on a column parameter with a filter as index (e.g. *), the messages would be throttled incorrectly.

From now on, parameter update throttling can be disabled by setting the *MessageThrottlingThreshold* option to -1 in the *MaintenanceSettings.xml* file.

```xml
<MaintenanceSettings>
  ...
  <SLNet>
    ...
    <MessageThrottlingThreshold>-1</MessageThrottlingThreshold>
    ...
  </SLNet>
  ...
</MaintenanceSettings>
```

#### DataMiner Cube - Search box: Problem when loading templates after right-clicking an element and selecting 'Assign alarm template' or 'Assign trend template' [ID_35582]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When, in the search box in the middle of the Cube header bar, you enter the name of an element and right-click the suggested element, a context menu will open identical to that which opens when you click an element in the Surveyor.

However, when, in that context menu, you then selected *Protocols & Templates > Assign alarm template* or *Protocols & Templates > Assign trend template*, the available templates would not get loaded.

#### DataMiner Cube: Problem when receiving a notification from SLAnalytics while in alarm storm mode [ID_35596]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

An error could occur in DataMiner Cube when it received a notification from SLAnalytics while in alarm storm mode.

Also, from now on, DataMiner Cube will no longer group incident alarms into summary alarms while in alarm storm mode.

#### When retrieving the protocol of a DVE parent element, its alarm filter would not get returned correctly for some of its parameters that are exported as standalone parameters [ID_35607]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When a client retrieved the protocol of a DVE parent element, its alarm filter would not get returned correctly for some of its parameters that are exported as standalone parameters.

#### A number of alarm-related issues have been fixed [ID_35611]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

A number of alarm-related issues have been fixed:

- In some cases, the alarm that closed an alarm tree would incorrectly not contain the root GUID.
- If no comment was passed when an alarm was cleared, in some cases, the comment of the previous alarm would incorrectly not be added to the closing alarm.
- In some cases, an incorrect `Alarm didn't have the correct format.` error would be logged.

#### Service & Resource Management: ResourceManager module could briefly be uninitialized during a midnight synchronization [ID_35621]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

During a midnight synchronization, in some cases, the ResourceManager module could briefly be uninitialized.

The logging indicating the start and the end of the initialization, synchronization and cache load of the ResourceManager module has now been changed from log level 4 to log level 0.

#### DataMiner Cube: Pattern edit menu would incorrectly open when you resized the selected area in a trend graph [ID_35627]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When you resized the selected area in a trend graph by dragging either the left or right selection boundary, the pattern edit menu would incorrectly open, even when you were not allowed to create a pattern or when you had no intention of editing a pattern.

#### DataMiner Cube - Trending: Problem with Y axis alarm coloring [ID_35633]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.3 [CU1] -->
<!-- Incorrect FR - not added to 10.3.3 [CU1] -->

When a parameter with a relative alarm threshold had its baseline set to a negative value, in the trend graph of that parameter, the alarm coloring on the Y axis could be incorrect.

#### SLAnalytics - Automatic incident tracking: Problem with duplicate alarms [ID_35664]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

Up to now, when the SLAnalytics process started, the entire focus data cache of the agent hosting the process was cleared and recreated, causing the automatic incident tracking feature to clear any incident associated with the alarms removed from the focus data cache. When the focus data was then regenerated later on, this could lead to a recreation of the same groups.

Also, when the SLAnalytics processes of different agents in the same cluster were restarted right before a full hour, it was possible to trigger the internal duplication of active alarms hosted on non-leader agents. This could, in turn, lead to an incorrect internal alarm state and incorrect incidents containing copies of the same alarm.

From now on, the focus data cache will no longer be cleared when SLAnalytics process starts up. Instead, only the focus data associated with the alarms that are no longer active will be removed from the cache.

#### Dashboards app - Line & area chart component: Trend data could not be retrieved for spectrum parameters [ID_35676]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When, in a dashboard, you added a trended spectrum parameter to a line & area chart component, the component would not be able to retrieve the trend data of that parameter.

#### DataMiner Cube - Alarm Console: Problem when a session variable was used in an alarm filter [ID_35681]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When you applied a filter to an alarm tab, no alarms would be shown when you had used a session variable in the filter.

#### Dashboards app - Line & area chart component: Duplicate data in exported CSV file [ID_35688]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When you exported the data shown in a line & area chart component to a CSV file, the file could incorrectly contain duplicate data.

#### Dashboards app & Low-Code Apps - State component: Changing the query order would incorrectly only be applied when the browser was refreshed [ID_35690]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When you changed the order of the queries added to a State component, this change would incorrectly only be applied when you refreshed the browser. From now on, the change will be applied immediately.

#### Dashboards app - Line & area chart: Problem when selecting a new time range [ID_35691]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When a line & area chart was filtered by means of a time range feed, in some cases, the dashboard would incorrectly keep on loading when a new time range was selected.

#### Dashboards app & Low-Code Apps: Last nodes of a migrated query would incorrectly be cut off [ID_35693]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When a GQI was migrated, in some cases, the last nodes of the migrated query would incorrectly be cut off.

#### Dashboards app & Low-Code Apps - Node edge component: An incorrect tooltip would appear when hovering over a segment of an edge [ID_35696]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When you hovered over a segment of an edge, in some cases, an incorrect tooltip would appear.

#### DataMiner Cube: Exception values with decimals would be displayed incorrectly in trend graph [ID_35714]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

Because DataMiner Cube would use the incorrect culture when parsing exception values, in some cases, exception values with decimals would be displayed incorrectly in trend graphs.

#### Dashboards app: 'Data used in dashboard' section would incorrectly not list DOM instances [ID_35717]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When editing a dashboard, DOM instances used by components on that dashboard would incorrectly not be listed in the *Data used in dashboard* section of the *DATA* tab.

#### Web apps: Node edge actions would incorrectly no longer work [ID_35723]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

Node edge actions would incorrectly no longer work.

#### SLAnalytics - Automatic incident tracking: Problem when starting up [ID_35731]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When a large number of groups needed to be created while automatic incident tracking was starting up, the `A timeout of 00:01:00.0 occurred while processing message of type AlarmFloodMessage` error could be thrown, causing automatic incident tracking to not start up correctly.

#### Web apps - Query builder: Query nodes that by default only had a single value would incorrectly not be displayed [ID_35735]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

In the query builder, query nodes that by default only had a single value would incorrectly not be displayed.

#### DataMiner Cube - Asset Manager app: Enum fields would not immediately be updated after clicking 'Apply' [ID_35747]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

When, in the *Asset Manager* app, you tried to update an enum field, the value would not immediately be updated in the UI after clicking *Apply*.

#### GQI: Queries containing float or GUID values would not get migrated correctly [ID_35759]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

GQI queries containing float or GUID values would not get migrated correctly.

#### Problem with SLElement when creating an alarm with an 'SLA Affecting' property [ID_35776]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

In some rare cases, an error could occur in SLElement when creating an alarm with an *SLA Affecting* property.

#### Business Intelligence: Enhancements with regard to the retrieval of data from logger tables and to general error handling [ID_35820]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU2] - FR 10.3.5 -->

A number of enhancements have been made to the Business Intelligence module, especially with regard to the retrieval of data from logger tables and to general error handling.

#### Web apps: Problem when opening a visual overview [ID_35841]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU2] - FR 10.3.5 -->

When you opened a visual overview in a web app, in some cases, the web app could become unresponsive.

#### SLAnalytics could keep on waiting indefinitely for large delete operations to finish [ID_35848]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU2] - FR 10.3.5 -->

In some cases, SLAnalytics could keep on waiting indefinitely for large delete operations to finish.

#### Dashboards app: Multiple parameter feeds would incorrectly have their 'group by' reset when a PDF was generated [ID_35866]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU2] - FR 10.3.5 -->

When you generated a PDF of a dashboard that contained multiple parameter feeds, a multiple parameter feed with a "group by" applied would incorrectly have that "group by" reset to the value that was configured in its settings.

#### Web apps: Certain icons would incorrectly not be displayed [ID_35877]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU2] - FR 10.3.5 -->

In web apps, certain icons would incorrectly not be displayed.
