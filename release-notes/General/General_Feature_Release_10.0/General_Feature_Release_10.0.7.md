---
uid: General_Feature_Release_10.0.7
---

# General Feature Release 10.0.7

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## New features

### DMS Cube

#### Trending: Automatic pattern matching \[ID_24893\]\[ID_25708\]

On systems with a Cassandra database and an Indexing Engine, from now on, DataMiner will be able to automatically recognize recurring patterns in trend data called “tags”.

To define a tag:

1. In a trend graph showing trend information for one single parameter, select the portion of the graph that you identify as being a recurring pattern.
1. Enter a tag name and click the check mark to save.

Any matching patterns in the current trend graph will immediately be highlighted in orange. Matches found for the same element/parameter as the one for which a tag was defined will appear in bright orange, whereas matches associated with tags created for another element/parameter will appear in a slightly lighter hue.

> [!NOTE]
> If automatic pattern matching is enabled, each time you open a trend graph of a parameter for which patterns have been defined, all trend graph portions that match one of the saved patterns will be highlighted.

To edit a tag:

1. Click the tag button above the (highlighted) pattern you want to edit.
1. To edit the tag name, click the pencil icon and change the name.
1. To redefine the pattern, adjust its boundaries.
1. To save any modifications, click the check mark.

> [!NOTE]
> If you edit a tag, the pattern will always be overwritten, even if you did not redefine the pattern in any way.

To delete a tag:

1. Click the tag button above the (highlighted) pattern you want to delete.
1. Click the delete icon.
1. In the confirmation box, click *Yes*.

> [!NOTE]
>
> - If you delete a tag, all pattern matches associated with that tag will also be deleted.
> - If a protocol is deleted, all patterns defined for parameters of that protocol will also be deleted the first time the SLAnalytics service restarts.

##### Current limitations

Currently, automatic pattern matching has the following limitations:

- Patterns must have a size between 8 and 50,000 data points and should not have more than 5 percent missing values.
- Pattern matching can only be performed on trended parameters containing numeric values.
- If pattern matching is performed on a trend graph showing more than 100,000 data points, an aggregated level of detail will be used to improve performance at the cost of accuracy. If, at the most aggregated level, the number of data points exceeds 100,000 data points, no pattern matching will be performed.

##### Changes as to trend graph mouse button actions

In the *User \> Trending* section of the *Settings* window, the *Left mouse button action on graph* and *Right mouse button action on graph* settings can now be set to one of four values:

- Select (new option, allowing you to select part of a trend graph)
- Zoom (former “Select” option, default right mouse button action)
- Pan (default left mouse button action)
- None

In case of the (new) “Select” option, a quick menu will appear, allowing you to either zoom to the part of the trend graph you selected or to create a tag (see above). On both sides of the selection, thumb draggers will also appear to allow you to resize the area you selected.

Also, apart from the *Left mouse button action on graph* and *Right mouse button action on graph* settings, two new settings have been added:

| Setting                                    | Description                                                                                                                                |
|--------------------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------|
| Hotkey for mouse button action on graph    | The key that, when pressed while clicking the left mouse button, will cause the “hotkey + left mouse button action” to be performed.       |
| Hotkey + left mouse button action on graph | Action to be performed when you press the “hotkey for mouse button action” while clicking the left mouse button: Select, Zoom, Pan or None |

#### DataMiner Cube - Alarm templates: Conditional monitoring now support checking whether a parameter value is equal or not equal to 'Not Initialized' \[ID_25352\]\[ID_25644\]

In an alarm template, it is now possible to configure monitoring conditions that check whether a parameter value is equal or not equal to “Not Initialized”.

A drop-down box now allows you to choose between “Value” (default) and “Not initialized”. Note that, when you choose “Value” and enter a parameter value, that value will not be cleared when you later select “Not initialized”.

#### Alarm Console: Special Indexing Engine search tab is now available without enabling the 'System configuration \> Indexing Engine \> UI Available' user permission \[ID_25429\]

On systems on which the alarms were migrated to an Indexing Engine, up to now the special Indexing Engine search tab would only be available in the Alarm Console of users who had been granted the “System configuration \> Indexing Engine \> UI Available” user permission. From now on, that search tab will be available to all users, regardless of whether they were granted the above-mentioned user permission.

### DMS Reports & Dashboards

#### Dashboards app: Image component now supports more image formats \[ID_25488\]

From now on, the image component supports the following image formats:

- apng
- gif
- jpeg
- png
- svg
- webp

> [!NOTE]
> As images in bmp format should be avoided in web content, this format is not supported.

#### Dashboards app: Linking a component to URL data without using a feed \[ID_25705\]

In the Dashboards app, it is now possible to link a component to data in the URL without using any feeds on the dashboard.

To do so, after selecting the component, open the *Data* tab, go to *Feeds \> URL*, and drag the necessary data onto the component.

> [!NOTE]
> When the dashboard has a feed that contains the same data as the URL, the feed will overwrite the data found in the URL.

#### Dashboards app - Service definition component: Options to show/hide nodes \[ID_25763\]

On the *Layout* tab of the service definition component, two new options now allow you to specify which nodes you want the component to show or hide:

- **Visible nodes**

    In this tree, which lists all available nodes grouped per parent system function and function definition, you can select the nodes to be displayed. The nodes that are not selected will be hidden.

- **Show nodes without a resource assigned**

    When you select this checkbox, the component will also show the nodes that have no resource assigned. By default, this checkbox will not be selected.

> [!NOTE]
>
> - When the service definition component does not show any node, an animation will indicate the reason why none are shown.
> - When actions are defined on a certain node, the group labels will now be moved to the top of that node.

### DMS Service & Resource Management

#### Missing interfaces on the parent function will now automatically be added when generating a contributing function \[ID_25587\]

When a contributing function had to be generated, up to now, it was assumed the given collection of interfaces to expose would match the interfaces on the parent system function. In fact, any interfaces on the parent system function that do not have a matching interface on the underlying service definition of the contributing function can simply be omitted from the request.

The software will therefore automatically create the interfaces on the contributing function and link them to a parameter group on the contributing protocol. The parameter group in the protocol will not contain any parameters and the name of the interface will be that of the matching interface in the system function definition (or “DefaultInterfaceName” if the interface in the parent system function does not have a name).

#### A profile assignment mode can now be configured on service definition nodes and on the resource usages of a ServiceReservationInstance \[ID_25616\]

Up to now, a profile assignment mode could already be configured on the capacity and capability usages of a ServiceReservationInstance. Now, a profile assignment mode can also be configured on service definition nodes and on the resource usages of a ServiceReservationInstance. For that purpose, a “ByProfileInstanceReference” property has now been added to the ObjectConfiguration class.

#### The full capacity will now always be quarantined when a capacity with a reference string must be quarantined \[ID_25637\]

When a capacity with a reference string has to be quarantined, from now on, the full capacity will always be quarantined.

## Changes

### Enhancements

#### Web Services API: An exception will now be returned when retrieving alarms while the alarm cache is not initialized yet \[ID_19927\]

Up to now, when a large amount of alarms were retrieved via the Web Services API while the IIS server alarm cache was not fully initialized yet, in some cases, an incomplete result set would be returned. From now on, an exception will be returned instead.

The HTML5 apps (e.g. Monitoring), which make use of the Web Services API, will in this case now also display an error message indicating the alarm cache status.

#### From now on, only DMAObjectRefTreeRequestMessage requests that update information will be processed sequentially \[ID_24967\]

Up to now, all DMAObjectRefTreeRequestMessage request were processed sequentially. From now on, only those that update information will be processed as such.

#### SLDataMiner will no longer try to send status updates to the Mobile Gateway if the latter has its location set to none \[ID_24972\]

When the Mobile Gateway location was set to “\<none>”, up to now, SLDataMiner would incorrectly try to send status updates to the Mobile Gateway’s non-existing IP address 0.0.0.0.

From now on, when the Mobile Gateway location is set to “\<none>”, SLDataMiner will no longer try to send status updates to it. It will only add a line to the logs (with log level 0), indicating that no Mobile Gateway location has been specified.

> [!NOTE]
> From now on, when a user changes the cellphone location, an information event will be generated.

#### SLAnalytics: Logging will no longer contain 'Unexpected number of responses returned while sending getInfoMessage' notices \[ID_25240\]

The SLAnalytics logging will no longer contain lines mentioning the following notice:

```txt
Unexpected number of responses returned while sending getInfoMessage...
```

#### DataMiner Analytics - Alarm focus: timeOfArrival field added to AlarmFocusEvents \[ID_25343\]

AlarmFocusEvents now have a timeOfArrival field. In most cases, this field will be set to the time at which the corresponding AlarmEventMessage was received. However, in the following AlarmFocusEvents, it will be set to the current time:

- Hourly AlarmFocusEvents that update the focus value of active alarms.
- AlarmFocusEvents for old alarms that are resent after restarting an element.
- AlarmFocusEvents that are sent for active alarms on startup.

#### Indexing Engine: Configuring a custom IP port in Db.xml \[ID_25407\]

By default, an Indexing Engine listens for client requests on TCP port 9200.

From now on, it is possible to specify another port in the *Db.xml* file. See the following example.

```xml
<DBServer>localhost:9201</DBServer>
```

#### DataMiner Cube - Automation: Script execution messages will now be sent asynchronously \[ID_25438\]

Up to now, when an Automation script was launched from Cube, a script execution message would be sent to the DataMiner Agent synchronously. In order to avoid timeout issues, from now on, script execution messages will be sent asynchronously.

#### DataMiner Cube - Visual Overview: Using the \[Reservation\] placeholder no longer requires Cube to retrieve all service information \[ID_25463\]

When the \[Reservation\] placeholder was used in a service context, up to now, Cube would retrieve all service information to get the booking ID. From now on, Cube will no longer do this as the booking ID is now available in the LiteServiceInfoEvent message.

#### DataMiner Cube - Service & Resource Management: A notice will now appear when an Indexing Engine is required or when licenses are missing \[ID_25537\]

When you try to open the *Resources* app or the *Service Definitions* tab of the *Services* app, from now on, a notice will appear, saying that those apps can only be used on systems running an Indexing Engine.

Also, when you open a Visio page containing a ListView component, a notice will now appear in the following cases:

- If the ListView is configured to list elements, a notice will appear when you do not have access to the listed elements.
- If the ListView is configured to list bookings, a notice will appear when the DataMiner System has nor the required software licenses (ResourceManager, ServiceManager, SRM Concurrency) nor an Indexing Engine installed.

#### DataMiner Cube - Visual Overview: ListView component will only show 'clear filter' button when FilterMode option is set to true \[ID_25560\]

From now on, the ListView component will only show the “clear filter” button when the FilterMode option has been set to true.

#### Dashboards app: Service definition visualization will be updated when the service definition or the booking gets updated \[ID_25562\]

The service definition visualization will now be updated when the service definition or the booking gets updated.

> [!NOTE]
> When a booking gets deleted while the service definition instance of that booking is being displayed, an error will be shown.

#### DataMiner Cube - Visual Overview: Column names in legacy ListView column configuration will now be case insensitive \[ID_25589\]

Prior to DataMiner 9.6.13, the column configuration of a ListView component had to be specified in JSON format and column names in that configuration were case sensitive. From now on, column names in a legacy ListView column configuration will be case insensitive.

#### Indexing Engine: Default index replication factor now set to 2 \[ID_25606\]

From now on, new Indexing Engine installations will have their index replication factor set to 2 for all data objects except suggestions. For suggestions, the index replication factor will be set to 1.

#### Dashboards app: Enhanced rendering of scalable text \[ID_25671\]

Due to a number of enhancements, the rendering of scalable text in a number of dashboard components (e.g. digital clock, trend statistics, state visualizations) has been optimized.

#### DataMiner Cube: Enhanced timeline tool tip in Bookings app \[ID_25704\]

In the Bookings app and the Bookings app Visio component, from now on, the tool tip showing the time in the bookings timeline will now also be visible when you select a particular area.

#### DataMiner Cube - Scheduler: Task list, event list and profile list are now naturally sorted \[ID_25724\]

In the “Time line” tab of the Scheduler app, the task list, event list and profile list are now naturally sorted.

#### Memory usage of service cache has been reduced \[ID_25726\]

Since DataMiner 9.5, a service cache has made it possible to see the impacted services on cell level. Due to a number of enhancements, this cache’s memory usage has now been reduced.

#### Table of virtual function element remained empty \[ID_25732\]

In some cases, it could occur that a table of a virtual function element did not contain any data.

#### DataMiner Cube - Visual Overview: \[profile:\] placeholder enhancements \[ID_25795\]

A number of performance enhancements have been made with regard to the \[profile:\] placeholder.

### Fixes

#### Problem when sending a GetInfoMessage of type 'IndexConfigurationMessage' while an agent is offline \[ID_24898\]

When, in the DataMiner System, a GetInfoMessage of type “IndexConfigurationMessage” was sent to all agents while one of them was offline, in some cases, the method would return an exception instead of the information received from the online agents.

#### Problem with SLAnalytics due to a threading issue \[ID_25207\]

In some cases, an error could occur in SLAnalytics due to a threading issue.

#### DataMiner Cube - Spectrum analysis: Problem when editing presets \[ID_25330\]

In a spectrum element card, in some cases, problems could occur when editing presets.

Shared presets could get lost when editing them, and, in some cases, when renaming a preset, DataMiner Cube could show other presets with the same name.

#### DataMiner Cube - Users & groups: Selection was incorrectly cleared when filtering the list of users/groups \[ID_25342\]

When you had selected one or more users or groups in the Add existing user or Add existing group window respectively, in some cases, the selected users or groups would incorrectly get unselected when you filtered the list.

#### DataMiner Cube - Scheduler: Memory leak due to an incorrect clean-up of removed timeline items \[ID_25359\]

In some cases, DataMiner Cube could leak memory due to an incorrect internal clean-up of items removed from the Scheduler timeline.

#### DataMiner Cube - Alarm Console: Severity duration of cleared alarms was not set to 'N/A' \[ID_25370\]

When you added the *Severity Duration* column to the Alarm Console, up to now, the duration for a cleared alarm was incorrectly shown as the difference between the time of the alarm and the current time. From now on, the duration of a cleared alarm will always be shown as “N/A”.

#### Service & Resource Management: Problem when updating the end time of a parent and child ReservationInstance while both were in progress \[ID_25405\]

In some cases, an exception could be thrown when the end time of a parent and child ReservationInstance were updated while both were in progress.

#### DataMiner Cube - Bookings app: Blank time line when opening the app \[ID_25410\]

When you opened the Bookings app for the first time in a Cube session, in some cases, the time line would incorrectly be empty.

Also, due to a number of enhancements, overall performance has increased when opening the Bookings app.

#### Problem when sending an SNMP trap from an element that was being restarted \[ID_25435\]

When an SNMP trap was sent from an element that was being restarting, in some cases, an error could occur.

#### Alarm file offload serialization would fail due to a protocol buffer error on a PropertyAccessType enum value \[ID_25459\]

In some cases, alarm file offload serialization would fail due to a protocol buffer error on a PropertyAccessType enum value.

#### Monitoring app: Password boxes would incorrectly display their contents in normal text \[ID_25467\]

In the Monitoring app, password boxes would incorrectly display their contents in normal text. From now on, the contents of password boxes will be displayed as a series of bullets.

#### SLAnalytics: Problem when retrieving data at startup \[ID_25479\]

In some cases, an error could occur when SLAnalytics retrieved data from the database at startup.

#### DataMiner Cube - Settings: User setting hidden in the group settings would incorrectly also be hidden in the group settings editor \[ID_25480\]

When a user setting was hidden in the group settings, it would incorrectly also be hidden in the group settings editor.

#### Automation: Problem when generating a large report via an Automation script \[ID_25482\]

When a large report was generated via an Automation script, in some cases, all other communication with the SLReportsAndDashboardsManager process could get blocked.

#### Protocols: When no column was polled during a polling cycle, previously polled columns could incorrectly get cleared from memory \[ID_25500\]

When, using a particular pollingRate configuration, there was a polling cycle during which no column was polled, in some cases, previously polled columns could incorrectly get cleared from memory in SLProtocol.

#### DataMiner Cube - Correlation: Placeholders in Correlation emails were not filled in correctly \[ID_25504\]

In some cases, placeholders in Correlation emails would not be filled in correctly.

#### SNMP: Problem when using a specific polling rate in conjunction with the 'SNMP set and get' or 'dynamic SNMP get' options \[ID_25514\]

When a protocol configured to poll SNMP columns at a specific polling rate has write parameters that use the “SNMP set and get” option or parameters that use the “dynamic SNMP get” option, in some cases, values could appear to be toggling in the user interface.

#### DataMiner Cube - Resources app: Expander showed an incorrect icon \[ID_25541\]

In the Resources app, in some cases, the expander would show an incorrect icon.

#### Trending data not cleaned up in Failover MySQL database \[ID_25552\]

If a Failover pair used MySQL local databases, it could occur that trending data was not removed from the database when its time to live had elapsed.

#### DataMiner Cube - Alarm Console: Hyperlinks would not update in the hyperlink column \[ID_25566\]

When an alarm had a hyperlink configured that was displayed in a hyperlink column, in some cases, that hyperlink would not get updated when the alarm was updated. The placeholders in the hyperlink would keep on displaying values from the previous alarm.

#### Exception when exporting SNMP element to CSV \[ID_25586\]

When an element with an SNMP connection was exported to CSV, an exception could be thrown, causing the export to fail.

#### DataMiner Cube - Visual Overview: Alarm timeline component did not correctly aggregate different alarm timelines into a single band \[ID_25590\]

In an alarm timeline component, in some cases, an error could occur when different alarm timelines had to be aggregated into a single band.

#### Dashboards app - Visual Overview component: Problem when no page had been selected in the component settings \[ID_25594\]

When, in the Dashboards app, no page had been selected in the settings of a Visual Overview component, in some cases, that component would show a “Could not retrieve the image for the Visual Overview” error message.

#### Legacy Reporter: Report with trend graph block would incorrectly show a 'No parameters were provided for this element' notice \[ID_25595\]

When, in the legacy Reporter, you generated a report with a “trend graph” block, it would incorrectly display a “No parameters were provided for this element” notice when the parameters in question only had real-time trending enabled.

#### Elements not displayed in DataMiner Cube after connection between DMAs was restored \[ID_25602\]

When two DMAs established contact with each other after their connection had been lost, a problem could occur, which could cause elements not to be displayed in DataMiner Cube.

#### Web Services API v1: WSDL no longer backwards compatible for GetTicket method \[ID_25605\]

The WSDL was no longer backwards compatible for the GetTicket method.

#### Automation: Email sent from an Automation script had an incorrect subject \[ID_25618\]

When an email was sent from an Automation script, in some cases, the dashboard name would incorrectly be used as email subject.

From now on, the dashboard name will only be used as email subject when no subject was specified.

#### Hysteresis-related issues fixed \[ID_25619\]

A number of hysteresis-related issues were fixed:

- When a parameter had both Hysteresis on and Hysteresis off enabled, and the alarm got a non-value update (e.g comment added, property changed, service impact changed, etc.) during the Hysteresis off period, the alarm would not be cleared and would stay stuck until the value of the parameter would again enter an alarm state.

- When, during either the Hysteresis off period or the Hysteresis on period, a parameter got two value updates within the Normal range, the timestamp of the generated alarm would be that of the latest parameter update rather than that of update that triggered the initial drop to Normal.

- When a parameter that had Hysteresis off enabled and Hysteresis on disabled got two value updates within the Normal range during the Hysteresis off period, the alarm would be instantly cleared (or set to “clearable”) instead of at the end of the Hysteresis off period.

#### Parsing error when field names contained colon characters \[ID_25620\]

When converting a string to a filter, in some cases, a parsing error could occur when field names contained colon characters.

#### CPE cards would remain empty or would keep on loading when a direct view table requested data from an element that was starting up \[ID_25623\]

In some cases, CPE cards would remain empty or would keep on loading when a direct view table requested data from an element that was in the process of starting up.

#### Legacy Reporter / Cassandra: History pages would include alarms that did not match the parameter name filter \[ID_25624\]

When, in the legacy Reporter on systems running a Cassandra database, a parameter name filter was applied to a History page, in some cases, the alarm list would incorrectly include alarms that did not match the filter.

#### Problem with SLSNMPManager when testing a connection of an SNMPv3 protocol \[ID_25626\]

In some cases, an error could occur in SLSNMPManager when testing a connection of a protocol of type SNMPv3.

#### Failover: Problem in case of manual switchover with multiple heartbeats \[ID_25633\]

When, on a Failover system with manual switchover, multiple heartbeats had been configured, in some cases, the main agent would not be able to start up when only one of the heartbeats was successful.

From now on, manual switchover will behave in the same way as automatic switchover.

#### Trend graph showing a trend window with a constant parameter value would incorrectly remain empty \[ID_25646\]

When data is requested for a trend window that shows a constant parameter value, the last data point before the requested trend window should also be retrieved to allow the client application to draw the trend graph. In some cases, that data point would not be retrieved, causing the trend graph to remain empty.

#### Backup that included an Indexing database with a red index would incorrectly succeed on one agent in the DMS \[ID_25658\]

When, in a DataMiner System, you took a backup that included an Indexing database with a red index, up to now, the backup would incorrectly succeed on one agent and fail on all others.

From now on, a backup that includes an Indexing database with a red index will fail on all agents and an error will be added to the elasticbackup log file in the Backup folder.

#### SNMP tables without polling rate defined would no longer be polled \[ID_25659\]

In some cases, an SNMP table without polling rate defined on any of its columns would no longer be polled.

#### Service & Resource Management: Existing occurrences of updated ReservationDefinition incorrectly only deleted on the hosting agent \[ID_25661\]

When a confirmed ReservationDefinition was updated, the existing occurrences would only be deleted on the hosting agent, not on the other agents in the DataMiner System. This would cause occurrences to get duplicated on those agents.

#### DataMiner Cube: When exporting an element to CSV, only the timeout of the first communication layer would get exported \[ID_25664\]

When you exported an element to a CSV file, and that element had timeouts defined for each of its communication layers, in some cases, only the timeout of the first communication layer would get exported. When you then imported that element from the CSV file, it would immediately go into timeout.

#### DataMiner Cube - Resources app: Problem when deleting a capability or a capacity from a resource \[ID_25680\]

In the Resources app, it is possible to add capabilities and capacities to resources. When you deleted a capability or a capacity in the user interface, in some cases, the deletion would incorrectly not be implemented on the DataMiner Agent.

#### DataMiner Cube - Trending: Problem with invalid 'NaN' points \[ID_25698\]

When, in a trend graph, an invalid “NaN” point had to be drawn immediately after a gap, in some cases, an error could occur.

#### Problem when conditionally monitoring a standalone parameter using a condition that included a column parameter check \[ID_25731\]

When a standalone parameter was monitored conditionally, and the condition in question included a column parameter check, in some cases, an error could occur in SLElement.

#### Parameter updates that did not change the parameter value would incorrectly not be applied \[ID_25736\]

In some cases, parameter updates that did not change the parameter value would not be applied. In case of a history set, this could cause a problem.

From now on, history sets will always be considered value changes, regardless of whether the value is updated or not.

#### DataMiner Cube - Service templates: Empty selection box when right-clicking a view and selecting Actions \> Apply service template... \[ID_25741\]

When you right-clicked a view in the Surveyor, and selected Actions \> Apply service template..., in some cases, the selection box containing the list of service templates to choose from would be empty due to a problem with the selection box filter.

#### DataMiner Cube - Automation: Problem when including a legacy report template to an email action of an Automation script \[ID_25743\]

When, in an Automation script, you added an email action and included a report template of type “Multiple elements/services” (created in the legacy Reporter app) to which you passed a protocol as view filter, in some cases, that protocol would not be shown until you saved the script and then closed and reopened the Automation app.

#### DataMiner Cube - Visual Overview: Selected service definition in an embedded ServiceManager component would get unselected when another service definition was modified \[ID_25748\]

In some cases, a service definition selected in an embedded ServiceManager component would incorrectly get unselected when another service definition was modified in another Cube session.

#### DataMiner Cube - EPM: Problem when opening an EPM diagram that used the 'DiagramPids' option \[ID_25797\]

In some cases, DataMiner Cube would freeze when you opened an EPM diagram that used the “DiagramPids” option.

#### DataMiner Cube - Spectrum analysis: Hamburger menu of spectrum card still contained a deprecated link to the legacy Data Display UI \[ID_25799\]

The hamburger menu of a spectrum card still contained a deprecated link to the legacy Data Display UI. This link has now been removed.

#### DataMiner Cube: Login algorithm would incorrectly try to use TLS 1.0 when browser was configured to use TLS 1.2 \[ID_25803\]

When the Internet browser was configured to only use TLS 1.2, in some cases, the Cube login algorithm would incorrectly try to use TLS 1.0 instead.

#### Problem with SLDMS when connecting to another DataMiner Agent \[ID_25863\]

In some rare cases, an error could occur in SLDMS when connecting to another DataMiner Agent.

#### Jobs app: Problem when adding a field of type 'Static Text' \[ID_25930\]

In some cases, an exception could be thrown when you added a field of type “Static Text” to a job section.

## Addendum

From DataMiner 10.0.7 onwards, the following release note also applies:

#### Dashboards app: Problem with URL feeds and with parameter state linked to feed \[ID_25598\]

When multiple feeds were specified using the URL of a dashboard from the new Dashboards app, it could occur that the feed components in the dashboard remained empty. In addition, it could occur that a parameter state remained empty if it was linked to a feed.
