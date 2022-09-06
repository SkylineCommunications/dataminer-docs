---
uid: General_Feature_Release_10.1.1
---

# General Feature Release 10.1.1

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## New features

### DMS core functionality

#### Gradual introduction of inter-process communication via NATS \[ID_27496\]\[ID_28082\]\[ID_28131\] \[ID_28233\]

From now on, more and more DataMiner processes will start to communicate with each other using NATS, an open-source messaging system.

The NATS and NAS services will automatically be installed on each NATS-enabled DataMiner Agent, and if NATS is enabled on every agent in a DataMiner System, all NATS installations in that system will be consolidated into a single NATS cluster.

> [!NOTE]
>
> - When NATS is enabled on a DataMiner Agent, firewall rules will automatically be added for ports 4222, 6222, 8222 and 9090.
> - Automatic detection and triggering of NATS cluster self healing can be activated or deactivated by setting the \<NATSDisasterCheck> option to true of false in the MaintenanceSettings.xml file.
> - Only users who have been granted the *Admin tools* permission (Modules \> System configuration \> Tools) are allowed to reset the NATS service.

#### Amazon Elasticsearch Service now supported \[ID_28104\]

DataMiner now supports Amazon Elasticsearch Service.

See the example below, showing how this can be configured in the Db.xml file.

```xml
<DataBase active="true" search="true" type="Elasticsearch">
  <DBServer>mycompany-elastic.amazonaws.com</DBServer>
  <UID>myUserId</UID>
  <PWD>myPassword</PWD>
</DataBase>
```

#### Video thumbnails: Authentication header can now be specified in an 'auth=' option \[ID_28116\]

In a video thumbnail URL, you can now specify an authorization header in an “auth=” option when requesting a thumbnail image from a video server using type “Generic Images”.

This option has to be used when the video server expects an authentication token (e.g. OAuth2).

> [!NOTE]
>
> - When the authentication token expires, the URL has to be updated with the new token.
> - URLs that request video thumbnails should use HTTPS instead of HTTP. That way, you can prevent the authentication token from being stolen.
> - It is now also possible to request thumbnails from video servers that only accept TLS 1.2.

### DMS Security

#### Jobs and ReservationInstances: SecurityViewID property replaced by SecurityViewIDs property \[ID_28311\]

In Jobs and ReservationInstances, the single-value SecurityViewID property has now been replaced by a multiple-value SecurityViewIDs property.

If, for a particular job or ReservationInstance, this property contains view IDs, then the job or ReservationInstance will only be accessible to users who have access to at least one of the specified views.

For example, users with Read access to the view with ID 10 who display a list of jobs or ReservationInstances will only see the jobs or ReservationInstances of which the list of values in the SecurityViewIDs property includes “10” or no IDs at all.

> [!NOTE]
> The values in this property can be filter using a 'Contains' filter.
>
> Example: JobExposers.SecurityViewIDs.Contains(136)

### DMS Protocols

#### Extension methods moved from QActionHelperBaseClasses to SLManagedScripting \[ID_27995\]

The following extension methods have now been moved from the QActionHelperBaseClasses library to the SLManagedScripting library, and are now instance methods of the SLProtocol interface.

##### static class NotifyProtocol

- AddRow(this SLProtocol protocol, int tableId, string row)
- AddRow(this SLProtocol protocol, int tableId, object\[\] row)
- AddRow(this SLProtocol protocol, int tableId, object\[\] row, bool\[\] keyMask)
- AddRowReturnKey(this SLProtocol protocol, int tableId)
- AddRowReturnKey(this SLProtocol protocol, int tableId, object\[\] row)
- DeleteRow(this SLProtocol protocol, int tableId, string rowKey)
- DeleteRow(this SLProtocol protocol, int tableId, int row)
- DeleteRow(this SLProtocol protocol, int tableId, string\[\] rows)
- Exists(this SLProtocol protocol, int tableId, string key)
- GetKeyPosition(this SLProtocol protocol, int tableId, string key)
- RowCount(this SLProtocol protocol, int tableId)
- GetKeys(SLProtocol^ protocol, int tableId, KeyType type = KeyType.Index)
- ClearAllKeys(this SLProtocol protocol, int tableId)
- GetKeysForIndex(this SLProtocol protocol, int columnPid, string value)
- FillArray(this SLProtocol protocol, int tableId, object\[\] columns, DateTime? timeInfo = null)
- FillArray(this SLProtocol protocol, int tableId, List\<object\[\]\> columns, DateTime? timeInfo = null)
- FillArrayNoDelete(this SLProtocol protocol, int tableId, object\[\] columns, DateTime? timeInfo = null)
- FillArrayNoDelete(this SLProtocol protocol, int tableId, List\<object\[\]\> columns, DateTime? timeInfo = null)
- FillArray(this SLProtocol protocol, int tableId, List\<object\[\]\> rows, SaveOption option, DateTime? timeInfo = null)
- FillArrayWithColumn(this SLProtocol protocol, int tableId, int columnPid, object\[\] keys, object\[\] values, DateTime? timeInfo = null)
- SetParameterBinary(this SLProtocol protocol, int pid, byte\[\] data)

##### static class ProtocolExtenders

- void Log(this SLProtocol protocol, string message, LogType logType = LogType.Allways, LogLevel logLevel = LogLevel.DevelopmentLogging)

> [!NOTE]
>
> - All overloads of the above-mentioned methods, which take in a QActionTableRow object instead of an object\[\], have been deleted.
> - The static methods could not be deleted. They have been marked obsolete instead.

### DMS Cube

#### Trending: 'Ignore gaps' option in export window renamed to 'Exclude gaps' \[ID_28067\]

Up to now, when you exported a trend graph to CSV, it was possible to select the *Ignore gaps* option to make the export skip any gaps in the trend data. This option has now been renamed to *Exclude gaps*.

#### Visual overview: Page-level execution of Automation scripts & new NodeDoubleClicked event \[ID_28185\]

On a Visio page, it is now possible to have Automation scripts executed automatically using a page-level data item of type *Execute*.

See the example below. You can use the keywords *Trigger* or *SetTrigger*, which can be set to either “ValueChanged” or “Event”.

Example:

```txt
Script:ScriptName|DummyName=ElementName or DmaID/ElementID;...| ParameterName1=[var:myVar];ParameterName2=#ValueFile;...| MemoryName=MemoryFileName;...|ToolTip|Options|Trigger=ValueChanged
```

##### Reserved prefixes can now mark each of the syntax components

In the syntax to be used in Automation script shapes as well as page-level Automation script triggers, each component can now be marked by a prefix. That way, you will no longer have to define empty components in case there are no dummies, no memory files, etc.

List of reserved prefixes:

- “Parameters:”
- “Dummies:”
- “MemoryFiles:”
- “Options:”
- “Tooltip:”

Example of syntax that can now be used in a shape data item of type *Execute*:

```txt
Script:<myScript>|Tooltip:<myTooltip>|Parameters:paramA=<myParam>|Options:NoConfirmation
```

> [!NOTE]
>
> - If you choose to use prefixes to mark syntax components, you must use them for every component.
> - When you use prefixes to mark syntax components, the components can be added in whatever order you choose.

##### New NodeDoubleClicked event

In an \[Event:\] placeholder, you can now add a new event named *NodeDoubleClicked*, followed by the argument *ID* or *Label*.

This event will trigger when you double-click a service definition node in an embedded Service Manager component. The event placeholder will then be replaced by the value of the specified argument.

Example:

```txt
[event:NodeDoubleClicked,ID]
```

##### Use case

Using the new features described above, it is possible to configure that, when a user clicks a service definition node in an embedded Service Manager component, an Automation script is executed with e.g. the node ID as a parameter.

To configure this behavior, add a page-level data item of type *Execute*, and set its value to e.g. the following:

```txt
Script:<myScript>|Parameters:IDParam=[event:NodeDoubleClicked,ID]|Options:<possibleOptions>|Trigger=Event
```

#### Visual Overview: A shape linked to an alarm can now display the parameter key \[ID_28212\]

Using a data field of type “Info” set to the value “PARAMETER KEY”, a shape linked to an alarm can now be made to display the parameter key of the alarm in question.

#### System Center - Database: Option to offload database data to a file \[ID_28226\]

In the *Database* section of *System Center*, you can now also opt to offload database data to a file instead of a database.

#### Visual Overview: Group-level shape data fields of type 'ChildrenSort' now support placeholders \[ID_28289\]

In a group-level shape data field of type *ChildrenSort*, it is now possible to use placeholders.

This will allow you to dynamically specify how the different child item shapes should be sorted using placeholders such as “\[var:xxx\]” and “\[param:xxx\]”.

### DMS Reports & Dashboards

#### Dashboards app - Time range component: Selecting a preset timespan will now cause the name of that timespan to be added to the URL of the dashboard \[ID_27963\]

Up to now, when you selected a preset timespan (e.g. today, yesterday, etc.) in a time range component, the start time and end time of that timespan was added to the URL of the dashboard. From now on, when you select a preset timespan, the actual name of that timespan (e.g. today, yesterday, etc.) will be added to the URL instead.

#### Dashboards app: Default themes updated \[ID_28074\]

In the Dashboards app, a number of default themes have been updated.

#### Dashboards app - GQI: Queries will now be saved in a separate JSON file and will be referred to using a GUID \[ID_28088\]

From now on, queries will no longer be saved in a dashboard, but in a separate file named Queries.json, located in C:\\Skyline DataMiner\\Generic Interface. Dashboards using a query will then link to it using a GUID.

#### Dashboards app - GQI: Existing queries can now be reused \[ID_28102\]

When building a query, instead of having to start a new query from scratch, it is now possible to select an existing query in the *Start from* box, and then start building a query based on the one you selected.

Current limitations:

- Changing a query will not trigger a revalidation of the queries that are using the updated query. A component will only re-fetch a query when the dashboard is refreshed or when the final query is changed.
- If queries are running in a loop, a circular dependency error will be displayed.

#### Dashboards app - GQI: Data sources now have a default column set \[ID_28103\]

Each of the different data sources now has a default column set, which, if necessary, can be extended with every possible column in that data source by adding column selector nodes to the query.

| Data source        | Default column set                                                 |
|--------------------|--------------------------------------------------------------------|
| Alarms             | Visible columns in the Alarm Console of the Monitoring app.        |
| Parameter tables   | Visible columns of the table definition in the protocol (max. 10). |
| Profile definition | Parameters in the profile definition (max. 10).                    |
| Ticketing          | Fields displayed in the Ticketing app’s list view (max. 10).       |

> [!NOTE]
> All columns, even those that are not visible in the current data table, can be used by the operators. For example, you can filter data by a column that is not visible in the data table.

#### Dashboards app: Trigger feed \[ID_28136\]

To a dashboard, you can now add a trigger feed, i.e. a feed that allows you to trigger other components either manually or automatically.

Currently, the trigger feed can only be linked to components that can visualize a database query. In that case, when a trigger feed is triggered, the data displayed in the other component will be refreshed.

##### Settings

When, in the *Settings* tab, you enable the *Trigger timer* setting, a countdown bar will be displayed, and triggering will occur automatically when the counter reaches 0. The *Time* setting allows you to specify a counter interval (default: 60 seconds).

##### Layout

In the *Layout* tab, you find three additional sections:

- In the *Trigger label* section, you can specify a label and select an icon that will both be displayed on the trigger button.

- In the *Time label* section, select the *Show when the last trigger happened* option if you want the time of the last triggering displayed. When this option is selected, in the *Time description format* box, you can enter the message to be displayed. It can contain the following placeholders:

    | Placeholder | Description                                                                                                        |
    |---------------|--------------------------------------------------------------------------------------------------------------------|
    | {duration}    | An estimated indication of the time past since the last triggering. Example: “2 minutes ago”.                   |
    | {time}        | The exact textual representation of the time when the last triggering occurred. Example: “Nov 20, 2020, 12:33”. |

- In the *Layout* section, you can specify how you want the trigger label and time label to be aligned: left, center or right.

#### Dashboards app: Right-hand edit pane is now resizable \[ID_28137\]

It is now possible to change the width of the right-hand edit pane.

#### Dashboards app - Line chart component: New option to highlight parameters on graph and legend \[ID_28144\]

When configuring a line chart component, in the *Styling and Information* section of the *Layout* tab, you can now find the *Highlight lines on hover* option. This option enables users to highlight lines on a trend graph.

When you select the *Highlight lines on hover* option, which is cleared by default, you can also specify the thickness of the highlighted lines (default: 3 px).

There are two ways to highlight a trend line:

- Hovering over the trend graph.
- Expanding the legend and hovering over a parameter name.

#### Dashboards: Deleting components by pressing the DELETE key \[ID_28171\]

In the Dashboards app, up to now, it was possible to delete components in edit mode by selecting them and clicking the *Delete* button at the top of the page. Now, instead of clicking the Delete button, it is also possible to press the DELETE key on your keyboard.

> [!NOTE]
> After selecting the component to be deleted, make sure the focus is on the dashboard before you press the DELETE key. If the focus in on e.g. the header bar or the subheader bar, pressing the DELETE key will not work.

#### Dashboards app: Restricting access to dashboards \[ID_28345\]

From now on, when you create or import a new dashboard, you will be able to restrict access to it by specifying one of the following security levels:

| Security level | Description                                                                                                                                                                     |
|----------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Public         | Every user is allowed to view, edit and share the dashboard.                                                                                                                    |
| Protected      | Every user is allowed to view the dashboard, but only the user who created it is allowed to edit or share it.                                                                   |
| Private        | Only the user who created the dashboard is allowed to view and edit it. Note: In the Automation app, it will not be possible to attach private dashboards to report emails. |

> [!NOTE]
>
> - When users with edit permission are editing a dashboard, they will now be able to indicate which users are allowed to view and/or edit that dashboard.
> - Users will not be able to rename or delete a dashboard folder when it contains dashboards they are not allowed to edit.
> - By default, the built-in Administrator account is allowed to view and edit all dashboards.
> - Existing dashboards created in earlier DataMiner versions will remain accessible to all.

### DMS Mobile apps

#### Jobs app & Ticketing app: Column widths can now be saved \[ID_28254\]

When, in the Jobs app or the Ticketing app, you change the widths of the columns in the jobs list or the ticket list, those widths will now be saved per domain in the user settings.

### DMS Service & Resource Management

#### ReservationInstances now have an 'AbsoluteQuarantinePriority' property \[ID_28080\]

ReservationInstances now have an “AbsoluteQuarantinePriority” property.

Resources reserved by a ReservationInstance of which the AbsoluteQuarantinePriority property was set to true will force all resource usages of overlapping ReservationInstances into quarantine.

The usages of a ReservationInstance with absolute quarantine priority do not need to reserve any capacities or capabilities.

In the example below, resources will be quarantined from 10h to 12h UTC tomorrow.

```csharp
var tomorrow = DateTime.UtcNow.AddDays(1).Date;
var timeRange = new TimeRangeUtc(tomorrow.AddHours(10), tomorrow.AddHours(12));
var instance = new ReservationInstance(timeRange) {
    HasAbsoluteQuarantinePriority = false,
    Status = ReservationStatus.Confirmed
};
instance.ResourcesInReservationInstance.Add(new ResourceUsageDefinition(resourceToQuarantine.ID));
```

When adding a ReservationInstance with absolute quarantine priority, an error with reason “ReservationUpdateCausedReservationsToGoToQuarantine” will be returned if this causes any bookings to be quarantined. In that case, the update must be executed using the “forceQuarantine” flag.

> [!NOTE]
>
> - It is possible to add multiple overlapping bookings with AbsoluteQuarantinePriority. If they book the same resource and if results in an overbooking of the resource, one of the instances will be quarantined. If there is no overbooking of the resources between the two bookings with AbsoluteQuarantinePriority, both bookings will be scheduled.
> - When a booking with AbsoluteQuarantinePriority is removed, the other bookings using the resources will not automatically be taken out of quarantine.
> - Resources that are in quarantine because they overlap with a booking that reserves them with AbsoluteQuarantinePriority will have a QuarantineTrigger with reason “AbsoluteQuarantinePriorityReservationInstance”.

#### Calls requesting eligible resources will now also return information about the available capacity of the resources \[ID_28125\]

The EligibleResourceResult returned by the various GetEligibleResources calls will now contain information about the available capacity of the resources. The ResourceUsageDetails object now includes a CapacityUsageDetails list that contains the maximum available capacities for the requested time frame.

> [!NOTE]
>
> - The available capacity does not take into account the requested capacity.
> - The available capacity for capacities that were not requested in the GetEligible call, but which are present on the resource, will not be calculated, and will therefore not be present in the CapacityUsageDetails list.

#### ResourceManagerHelper.SetReservationDefinitionsAndOverrides method has been rendered obsolete \[ID_28261\]

The ResourceManagerHelper.SetReservationDefinitionsAndOverrides method has been rendered obsolete.

#### ServiceNameInUse check when a ServiceReservationInstance is started \[ID_28327\]

From now on, when a ServiceReservationInstance is started, a check will be performed to see whether a service with the same name is already active. If so, a StartActionsFailureErrorData object will be returned with error reason “ServiceNameInUse”, the error will be logged and the OnStartActionsFailureEvent will be triggered.

The StartActionsFailureErrorData object will also contains the following:

- ReservationInstanceId: The ID of the ServiceReservationInstance that could not be started.
- ServiceId: The ID of the service that has the same name.

## Changes

### Enhancements

#### Cassandra: User will now be notified when restoring a database backup has failed \[ID_27441\]

When restoring a Cassandra database backup has failed, from now on, the user will be notified and the restore operation will not be marked as complete.

#### More details will be logged when an error occurs while taking a backup \[ID_27614\]

From now on, more detailed information will be added to the log files when an error occurs while taking a backup.

#### DataMiner Cube - Visual Overview: More filter options when configuring an alarm timeline \[ID_27632\]

When, in Visual Overview, you right-click an alarm timeline with an alarm filter and select Show alarms in a new tab page, the alarms matching the filter will be loaded.

Up to now, it was only possible to filter on alarm properties. Now, you can also filter on severity (e.g. Severity:Critical), element (e.g. Element:49/1), etc.

#### DataMiner Cube: Enhanced retrieval of user images \[ID_27861\]

DataMiner Cube shows an image of the user who is logged in. The way in which this image is retrieved, has now been enhanced.

#### BPA test framework only allows to upload and execute BPA tests that have been digitally signed by Skyline \[ID_27979\]

From now on, the BPA test framework will only allow to upload and execute BPA tests that have been digitally signed by Skyline.

#### SLUpgrade: New option to forcefully kill processes \[ID_27983\]

Up to now, in some cases, attempting to disable a service during a DataMiner upgrade could fail.

Now, when a service has the ACTION_KILL flag added to its service info, it will forcefully be terminated when a clean stop and/or disabling fails.

#### Elasticsearch: Dynamic templating now enabled by default on customdata \[ID_28047\]

From now on, in an Elasticsearch database, dynamic templating will be enabled by default on customdata. As a result, when new fields are added to a customdata object, those fields will now always be searchable.

#### DataMiner Cube - EPM: Enhanced color scheme of EPM topology diagram in Skyline Black theme \[ID_28053\]

In the Skyline Black theme, the color scheme of the EPM topology diagram has been enhanced.

#### DataMiner Cube - Alarm Console: Automatic incident tracking will now ignore parameter name changes \[ID_28075\]

From now on, automatic incident tracking will ignore parameter name changes. The name of an alarm group will now always be the name of the parameter as specified in the protocol.

This will prevent parameters with different names ending up in the same alarm group.

#### DataMiner Jobs: New field type 'ServiceDefinitionFieldDescriptor' \[ID_28086\]

A new field type “ServiceDefinitionFieldDescriptor” has been added, which will always require a GUID value referring to a service definition.

This field descriptor can also add service definitions using the ServiceDefinitionIds property (of type List\<Guid>), allowing you to filter service definitions based on service definition IDs.

This feature is intended to support the upcoming PLM app.

#### BPA tests: Maximum DataMiner version now specifies the last compatible version instead of the first incompatible version \[ID_28108\]

When creating a BPA test, it is possible to indicate the most recent DataMiner version on which the test will work.

From now on, when a DataMiner Agent is upgraded to a version above the one specified in the MaxVersion setting of a test, that test will no longer be executed. Also, you will not be able to upload a BPA test to a DataMiner Agent with a version above the one specified in the MaxVersion setting.

#### BPA tests can now be set to automatically run at specific intervals \[ID_28126\]

BPA tests can now be set to automatically run at specific intervals.

#### Dashboards app - Line chart component: Trend percentile calculation will now also take into account the period during which a parameter had a certain value \[ID_28135\]

From now on, trend percentile calculations will also take into account the period during which a parameter had a certain value.

> [!NOTE]
> Percentile calculation is skipped when a parameter is of type discrete or when multiple parameters are displayed in one trend graph.

#### Table updates: Threshold columns will now be processed before non-prioritized columns \[ID_28139\]

When a table row is updated, the cells are handled according to the column's perceived priority unless overwritten. The processing order of columns has now been extended so that columns that are part of a threshold option (*Protocol.Params.Param.Alarm@Options*) within the same table definition get processed before columns that are part of a property definition and any other columns. This results in the following column processing order:

1. Primary key (index)
2. Display column
3. Foreign key columns
4. Columns part of the naming or namingformat definition
5. Columns part of a conditional monitoring definition
6. Columns part of a threshold definition (NEW)
7. Columns part of a property definition

Any other columns are processed in the order defined in the table parameter

#### Cube launcher tool: Alias now also replaces the cluster name in the Windows task bar \[ID_28161\]

When defining a DataMiner Agent in the Cube launcher tool, apart from the host name or IP address, you can also specify an alias.

If you specify a custom alias, from now on, it will not only replace the cluster name in the Cube header, but also in the Windows task bar.

#### Dashboards app: Enhanced mechanism used to create PDF reports \[ID_28170\]

A number of enhancements have been made to the mechanism used to generate PDF reports.

#### DataMiner Cube - Protocols & Templates: More information will now be returned to the user when a protocol upload fails \[ID_28183\]

When you are uploading a protocol in the *Protocols & Templates* app, a message box will appear when the upload operation has failed. This message box will now contain more detailed information about why the operation failed.

#### DataMiner Cube - Alarm Console: Reasons mentioned in Value column of group alarms generated by Automatic incident tracking now appear in the UI language \[ID_28189\]

When automatic incident tracking is activated, active alarms that are related to the same incident will automatically be grouped into a new alarm, and the Value column of such an alarm will show the reason why the alarms underneath it were grouped. From now on, that reason that appear in the UI language.

#### Cube launcher tool: Animation enhancements \[ID_28190\]

A number of enhancements have been made to the animations in the Cube launcher tool.

#### DataMiner Cube: 'Central database' replaced by 'Offload database' in all modules \[ID_28196\]

Throughout DataMiner Cube, the term “central database” has now been replaced by “offload database”.

#### SLAutomation will now automatically compile new libraries at startup \[ID_28218\]

When, on startup, SLAutomation detects any new Automation scripts that contain libraries that need to be compiled, from now on, it will automatically compile them.

#### Dashboards app: Enhanced page selector in embedded visual overviews \[ID_28237\]

A number of enhancements have been made to the page selector of embedded visual overviews.

For example, when a visual overview with multiple pages is embedded in a dashboard, the page selector will now also inherit the dashboard theme colors. Also, when a page is selected, the page selector will now display the name of the page.

#### Ticketing app: No automatic redirection anymore when ticket creation or ticket update has finished \[ID_28310\]

Up to now, when, after creating or editing a ticket, you navigated to another part of the Ticketing app, you would automatically be navigated back to the ticket when the ticket creation of ticket update was finished. From now on, this will no longer be the case.

#### DataMiner Mobile apps: Improvement of arrow controls to increase/decrease a value \[ID_28312\]

In the DataMiner mobile apps, such as the Monitoring, Ticketing and Dashboards app, when you hover over the arrow buttons to increase or decrease the value of a date or time, the value that will be affected by the arrow buttons will now be highlighted. In addition, such arrow buttons will now only be displayed when you hover over the input.

### Fixes

#### Problem when deleting an element that had data stored in Elasticsearch \[ID_27663\]

When you deleted an element that had data stored in an Elasticsearch database (e.g. a logger table), in some cases, this would cause errors in other elements that shared data with the element you deleted.

#### Incorrect error message when uploading a protocol with a minimum required version \[ID_27868\]

When you uploaded a protocol of which the Protocol.Compliancies.MinimumRequiredVersion element contained a DataMiner version onto a DataMiner Agent with an older version, in some cases, DataMiner would either throw the incorrect error message “No license for the encrypted protocol found” or no error message at all.

#### Jobs app: Job section fields would not be displayed in the correct order \[ID_27943\]

When editing a job, in some cases, the fields of a particular job section would not be displayed in the order in which they were defined in the job domain.

#### Problem when using smart IP header on UDP \[ID_27957\]

When the smartIpHeader communication option was used in a smart serial protocol and multiple clients were sending UDP datagram packets to the smart serial server socket, it could occur that the first package of the second sender would not be processed until a second package arrived.

#### Dashboards app: Table component would not be rendered correctly in a PDF report \[ID_27958\]

In some cases, a table component would not be rendered correctly in a PDF report.

#### Problem with \<SkipCommitLog> option in Db.xml \[ID_27969\]

If you want to optimize the writing speed to a Cassandra database, in the Db.xml file, you can specify the \<SkipCommitLog> option to skip the writing of the commit log. However, in some cases, this would no longer work.

#### Problem when multiple network interfaces shared the same MAC address \[ID_27971\]

When multiple network interfaces shared the same MAC address, in some cases, DataMiner would not be able to correctly detect those interfaces.

#### DataMiner Cube - Trending: Rounding issue when exporting a trend graph to CSV \[ID_27980\]

When you exported a trend graph to CSV with the *Line graph instead of block graph* option selected, in some cases, the timestamps would be off by a second due to a rounding error.

#### Problem when retrieving protocol-level TTL settings from the database \[ID_28023\]

When writing trend data to the database, in some cases, protocol-level TTL settings could not be retrieved. From now on, when TTL settings cannot be retrieved from the database, additional information will be added to the logs.

#### DataMiner Cube: Redundancy groups using software redundancy would not trigger when the switching logic contained elements that were neither primary nor backup element \[ID_28041\]

Redundancy groups making use of software redundancy would incorrectly not trigger when the switching logic contained elements that were neither primary nor backup element.

#### Service & Resource Management: Problem when setting function resource states \[ID_28050\]

In some cases, an error could occur when setting function resource states. As a result, ReservationInstances would no longer be created.

#### DataMiner Cube - Trending: Problems with percentile lines \[ID_28051\]

When no change points were displayed on a trend graph, in some cases, the percentile line would be displayed too high.

Also, when the percentile line was displayed at the very top of the trend graph, the line would become sticky. In other words, when the trend graph was redrawn, a new percentile line would be added while the previous would incorrectly not be removed.

#### Cube launcher tool: Assembly load errors \[ID_28059\]

Certain DLL files would cause assembly load errors to get added to the log file of the Cube launcher tool.

#### DataMiner Cube - Visual Overview: Zoom buttons would disappear when switching to full-screen mode and back in an embedded trend graph \[ID_28065\]

When, in an embedded trend graph, you switched to full-screen mode and back, in some cases, the “Zoom to last X” buttons would disappear.

#### Trending: Percentile calculation was incorrect when the data set started with a gap \[ID_28077\]

In some cases, a trending percentile would be calculated incorrectly when the data set started with a gap.

#### DataMiner Cube - Profiles app: After editing a profile instance, the service profile instance selection box would incorrectly be empty \[ID_28084\]

When you changed both the profile definition and the service profile instance when editing a profile instance, after saving, the service profile instance selection box would be empty, although the data was saved correctly.

#### Problem when retrieving composite instances using the 'partialSNMP' option \[ID_28087\]

When retrieving composite instances using the SNMP polling option “partialSNMP”, in some cases, only the first set of the table would be polled correctly. Other rows would either be empty or not polled at all.

#### DataMiner Cube - Profiles app: 'Based on' selection box would be empty \[ID_28089\]

When, in the *Definitions* tab of the Profiles app, you selected a profile definition and then clicked *Add* to select another profile definition in the *Based on* selection box, in some cases, that selection box would be empty.

#### Dashboards app - Line chart component: CSV with exported real-time trend data would incorrectly have three value columns instead of one \[ID_28090\]

When you exported real-time trend data to a CSV file, that file would incorrectly have three value columns (avg, min, max). From now on, when you export real-time trend data, the CSV file will only have one value column.

#### Dashboards app: Share window would incorrectly be resized when you entered a message \[ID_28093\]

When you opened a dashboard, clicked *Start sharing*, and entered a message, in some cases, the *Share* window would incorrectly be resized.

#### DataMiner Cube - Profiles app: Regular expression of a profile instance parameter would incorrectly not be checked \[ID_28094\]

In the Profiles app, it is possible to define a parameter of type text and add a regular expression that values have to match.

When such a parameter was added to a profile instance, in some cases, when its value was changed, the regular expression would incorrectly not be checked and all values would be allowed.

#### DataMiner Cube - Visual Overview: ListView filter would not reapply conditions when new items were added \[ID_28095\]

When a ListView component listing elements or services had an external filter applied, the filter would incorrectly not be reapplied when new items were added to the list.

#### DataMiner Cube - Alarm Console: Problem when retrieving alarms that contain metadata \[ID_28118\]

In some cases, an exception could be thrown when retrieving alarms that contain metadata.

#### Visual Overview: SetVar shape with tooltip would not work on a mobile device \[ID_28129\]

When a SetVar shape had its SetVarOptions data field set to “Control=Shape” and contained a legacy tooltip configuration (e.g. ‘\<MyVar>:\<MyValue>:\<MyToolTip>’), in some cases, the variable would not be updated when you clicked the control on a mobile device.

#### Dashboards app: Problems with table component \[ID_28146\]

A number of problems have been fixed with regard to the table component.

In some cases, for example, rendering issues could occur when resizing table columns.

#### Dashboards: Problems with CPE feed \[ID_28157\]

When you selected a CPE filter, in some cases, the raw key would incorrectly be displayed for a short while.

Also, when you selected a chain filter (e.g. Region) and a value (e.g. California), and then selected another chain filter and value, in some cases, nothing would be displayed and an error would occur.

#### DataMiner Cube - Trending: Incorrect datetime value would be sent to the pattern matching engine \[ID_28166\]

In some cases, DataMiner Cube would sent an incorrect datetime value to the pattern matching engine.

#### Ticketing app: Problem when creating a ticket \[ID_28167\]

In some cases, a null reference exception could be thrown when creating a ticket.

#### Web Services API v1: Problem with DeleteJobsDomain method \[ID_28177\]

When the DeleteJobsDomain method was used to delete the last job domain, in some cases, it would incorrectly try to delete the default job domain instead.

#### DataMiner Cube - Element connections app: Problem with 'Include element state' checkbox \[ID_28188\]

In the *Element connections* app, in some cases, the value of the *Include element state* checkbox would be saved incorrectly.

#### DataMiner Cube - System Center/Backup: 'Use one network path for all Agents' setting would be saved correctly but displayed incorrectly \[ID_28192\]

In the Backup section of System Center, it is possible to specify that a backup has to be stored on a network path. In some cases, when you specified one shared network path for all DataMiner Agents, this would be saved correctly, but displayed incorrectly in the user interface.

#### DataMiner Cube: EPM manager would incorrectly show the base table on a KPI popup \[ID_28194\]

When a field was defined on a base table while the topology cell was defined on a view table based on that base table, in some cases, a KPI popup on the field in question would incorrectly display the base table instead of the view table.

#### DataMiner Cube: Impossible to remove a trend template or an alarm template via the right-click menu of an element when the UI language was not set to English \[ID_28198\]

When DataMiner Cube was set to a language other than English, in some cases, it would not be possible to remove an alarm template or a trend template via the right-click menu of an element.

#### DataMiner Cube - Profiles app: Problem when linking a protocol parameter to a profile parameter with a table index \[ID_28208\]

When linking a protocol parameter to a profile parameter, in some cases, it would no longer be possible to enter a table index when a table column parameter was selected.

#### Monitoring app: Clicking a service in the list of services in a view would open an incorrect card \[ID_28215\]

When, in the Monitoring app, you opened a view that contained services, clicked Below this view \> Services, and then clicked one of the listed services, in some cases, an incorrect card would be opened.

#### SLUpgrade would incorrectly disregard changes made to the SLNet.exe.config file \[ID_28228\]

In some cases, the SLUpgrade process would disregard changes that were made to the SLNet.exe.config file.

#### GQI: Problem when querying a profile parameter with a column parameter belonging to a protocol with no elements \[ID_28239\]

In some cases, an exception could be thrown when querying a profile parameter with a column parameter belonging to a protocol with no elements.

#### Failover: Incorrect error message would appear after configuring a Failover setup \[ID_28241\]

In some cases, a cluster name mismatch error would incorrectly appear immediately after configuring a Failover setup.

#### Vendor name would incorrectly disappear from protocol signatures \[ID_28246\]

When a DVE protocol was signed, or when a signed protocol was promoted to production protocol, in some cases, the vendor name would disappear from the signature.

#### Client applications would incorrectly receive table updates multiple times \[ID_28250\]

When data was updated in a table, in some cases, client applications would incorrectly receive those updates multiple times.

#### Dashboards app: Components could not be moved in a Chromium web browser due to a spacing problem \[ID_28260\]

When using the Dashboards app in a Chromium web browser, in some cases, a lack of spacing around the components would prevent you from moving them.

#### Ticketing app: Date filters would incorrectly use dates in local time instead of UTC time \[ID_28267\]

In the Ticketing app, in some cases, the date filters would incorrectly use dates in local time instead of UTC time.

#### Dashboards app - GQI: Problem when aggregating values retrieved from an Elasticsearch table \[ID_28268\]

In some cases, an exception could be thrown when aggregating values retrieved from an Elasticsearch table.

#### Dashboards app - GQI: Problem when joining queries \[ID_28269\]

When joining a query, in some rare cases, an error could occur in the left query when the right query was incomplete. From now on, incomplete queries will be marked orange when the end of the query is invalid or red when the middle of the query is invalid.

Also, you will no longer have to click *Add* to join. As soon as the left and the right columns are filled in, both will automatically be joined.

#### DataMiner Cube: EPM card would not open when no topology cell was linked to the filter \[ID_28272\]

When an EPM field was defined on a table without a chain topology cell, in some cases, it would not be possible to launch an EPM card of an item in this field from the *Topology* tab in the sidebar.

#### SLAnalytics: Problem when trying to process a parameter update for a non-existing parameter \[ID_28282\]

In some case, an error could occur in SLAnalytics when trying to process a parameter update for a non-existing parameter.

#### Ticketing app: Headers would incorrectly not be cleared when switching domains \[ID_28291\]

In the Ticketing app, in some cases, headers would not be cleared when you switched domains.

#### Web Services API v0: Serialization error when using the GetActiveAlarmsFromView and GetActiveAlarmsFromElement methods \[ID_28293\]

Due to a serialization error, in some cases, the following Web Services API v0 methods would no longer work:

- GetActiveAlarmsFromView
- GetActiveAlarmsFromElement

#### DataMiner Cube: No pop-up messages when users logged in again after logging out \[ID_28306\]

When users logged in again after having logged out, in some cases, popup messages would no longer appear.

#### Dashboards app: Problem with indices selection of parameter feed component \[ID_28309\]

When a dashboard containing a parameter feed component was refreshed or when a report was generated based on such a dashboard, in some cases, it could occur that the selection of parameter indices was no longer correct

#### Dashboards app: Folder content not scrollable \[ID_28321\]

In the Dashboards app, in some cases, it would not be possible to scroll through the contents of a dashboard folder.

#### SNMP managers: Custom bindings linked to custom DataMiner object properties would not get filled in \[ID_28349\]

When custom bindings were linked to custom element, view, alarm or service properties, in some cases, those binding would not get filled in.

#### Profiles app: Problem when using converters \[ID_28404\]

When, In the *Profiles* app, converters (i.e. mediation snippets) had been configured, in some cases, a notice alarm would be generated.

#### Assembly incorrectly configured in SLNet.exe.config file \[ID_28408\]

In the SLNet.exe.config file, an assembly was configured incorrectly.

#### Problem with SLDataMiner when loading protocols \[ID_28447\]

In some cases, an error could occur in the SLDataMiner process when loading protocols.

#### Dashboards app - GQI: Problem when retrieving data for a table parameter without using a column filter \[ID_28534\]

In some cases, an exception could be thrown when using an inter-element query to retrieve data for a table parameter without using a column filter.

## Addendum CU1

### CU1 enhancements

#### Installation output of NAS/NATS will now be logged in SLCloudEndpointManager.txt instead of SLNet.txt \[ID_28577\]

When CloudEndpointManager installs NATS, it will now log the full installation output in the SLCloudEndpointManager.txt file instead of the SLNet.txt file.

#### NATS disaster recovery now deactivated by default \[ID_28660\]

From now on, automatic detection and triggering of NATS cluster self healing will be deactivated by default.

### CU1 fixes

#### Issues fixed in NATS server cluster configuration and in NATS clustering logic of offline agents in a Failover setup \[ID_28503\]

Issues have been fixed in the NATS server cluster configuration as well as in the NATS clustering logic of offline agents in a Failover setup.
