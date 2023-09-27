---
uid: General_Main_Release_10.0.0_CU2
---

# General Main Release 10.0.0 CU2

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Cassandra database: Cluster name in cassandra.yaml file now always set to 'DMS' \[ID_24645\]

In a cassandra.yaml file, the cluster name will no longer be configurable. It will now always be set to “DMS”.

> [!NOTE]
> The Cassandra cluster name is not linked to the DMS cluster name. The latter is still configurable.

#### From now on, only DMAObjectRefTreeRequestMessage requests that update information will be processed sequentially \[ID_24967\]

Up to now, all DMAObjectRefTreeRequestMessage request were processed sequentially. From now on, only those that update information will be processed as such.

#### Decreased CPU load when installing DataMiner \[ID_25291\]

Due to a number of enhancements, overall CPU load has decreased when installing DataMiner.

#### Indexing Engine: Configuring a custom IP port in Db.xml \[ID_25407\]

By default, an Indexing Engine listens for client requests on TCP port 9200.

From now on, it is possible to specify another port in the *Db.xml* file. See the following example.

```xml
<DBServer>localhost:9201</DBServer>
```

#### DataMiner Cube - Automation: Script execution messages will now be sent asynchronously  \[ID_25438\]

Up to now, when an Automation script was launched from Cube, a script execution message would be sent to the DataMiner Agent synchronously. In order to avoid timeout issues, from now on, script execution messages will be sent asynchronously.

#### DataMiner Cube - Visual Overview: Using the \[Reservation\] placeholder no longer requires Cube to retrieve all service information \[ID_25463\]

When the \[Reservation\] placeholder was used in a service context, up to now, Cube would retrieve all service information to get the booking ID. From now on, Cube will no longer do this as the booking ID is now available in the LiteServiceInfoEvent message.

#### DataMiner Cube - Service & Resource Management: A notice will now appear when an Indexing Engine is required or when licenses are missing \[ID_25537\]

When you try to open the *Resources* app or the *Service Definitions* tab of the *Services* app, from now on, a notice will appear, saying that those apps can only be used on systems running an Indexing Engine.

Also, when you open a Visio page containing a ListView component, a notice will now appear in the following cases:

- If the ListView is configured to list elements, a notice will appear when you do not have access to the listed elements.

- If the ListView is configured to list bookings, a notice will appear when the DataMiner System has nor the required software licenses (ResourceManager, ServiceManager, SRM Concurrency) nor an Indexing Engine installed.

#### DataMiner Cube - Visual Overview: ListView component will only show 'clear filter' button when FilterMode option is set to true \[ID_25560\]

From now on, the ListView component will only show the “clear filter” button when the FilterMode option has been set to true.

#### DataMiner Cube - Visual Overview: Column names in legacy ListView column configuration will now be case insensitive \[ID_25589\]

Prior to DataMiner 9.6.13, the column configuration of a ListView component had to be specified in JSON format and column names in that configuration were case sensitive. From now on, column names in a legacy ListView column configuration will be case insensitive.

#### DataMiner Cube: Enhanced timeline tool tip in Bookings app \[ID_25704\]

In the Bookings app and the Bookings app Visio component, from now on, the tool tip showing the time in the bookings timeline will now also be visible when you select a particular area.

#### DataMiner Cube - Scheduler: Task list, event list and profile list are now naturally sorted \[ID_25724\]

In the “Time line” tab of the Scheduler app, the task list, event list and profile list are now naturally sorted.

#### Memory usage of service cache has been reduced \[ID_25726\]

Since DataMiner 9.5, a service cache has made it possible to see the impacted services on cell level. Due to a number of enhancements, this cache’s memory usage has now been reduced.

#### Table of virtual function element remained empty \[ID_25732\]

In some cases, it could occur that a table of a virtual function element did not contain any data.

### Fixes

#### DataMiner Installer: Problem when installing a DataMiner Agent with a Cassandra database \[ID_24762\]

In some cases, the DataMiner Installer would fail to install a DataMiner Agent with a Cassandra database.

#### Problem when sending a GetInfoMessage of type 'IndexConfigurationMessage' while an agent is offline \[ID_24898\]

When, in the DataMiner System, a GetInfoMessage of type “IndexConfigurationMessage” was sent to all agents while one of them was offline, in some cases, the method would return an exception instead of the information received from the online agents.

#### Problem when retrieving alarms with rootkey equal to 0 from the database \[ID_25073\]

In some rare cases, an error could occur when retrieving alarms with a rootkey equal to 0 from the database. From now on, if the database contains alarms with a rootkey equal to 0, those alarms will be ignored and will not be retrieved.

Also, each time an alarm with rootkey equal to 0 is encountered, an entry will now be added to the SLDBConnection.txt log file.

#### DataMiner Cube - Correlation: Problem when saving a Correlation rule mail action that sends a PDF report \[ID_25315\]

When you added a mail action to a Correlation rule and configured that action to send a PDF report, in some cases, that configuration would not be saved correctly.

#### DataMiner Cube - Correlation: Mail action in Correlation rule could not be modified more than once \[ID_25317\]

When, in a Correlation rule, you had configured a mail action, in some cases, it would not be possible to update this action more than once.

#### DataMiner Cube - Spectrum analysis: Problem when editing presets \[ID_25330\]

In a spectrum element card, in some cases, problems could occur when editing presets.

Shared presets could get lost when editing them, and, in some cases, when renaming a preset, DataMiner Cube could show other presets with the same name.

#### DataMiner Cube - Users & groups: Selection was incorrectly cleared when filtering the list of users/groups \[ID_25342\]

When you had selected one or more users or groups in the Add existing user or Add existing group window respectively, in some cases, the selected users or groups would incorrectly get unselected when you filtered the list.

#### DataMiner Cube - Scheduler: Memory leak due to an incorrect clean-up of removed timeline items \[ID_25359\]

In some cases, DataMiner Cube could leak memory due to an incorrect internal clean-up of items removed from the Scheduler timeline.

#### DataMiner Cube - Alarm Console: Problem when grouping or sorting the alarms on an alarm tab page with a sliding window \[ID_25390\]

When, in the Alarm Console, an alarm tab page with a sliding window was grouped or sorted by time, in some cases, the grouping or sorting would not get updated when one of the alarms was updated. Also, when you turned history tracking off and then on again, in some cases, the alarms would no longer be grouped or sorted correctly.

#### Service & Resource Management: Problem when updating the end time of a parent and child ReservationInstance while both were in progress \[ID_25405\]

In some cases, an exception could be thrown when the end time of a parent and child ReservationInstance were updated while both were in progress.

#### DataMiner Cube - Bookings app: Blank time line when opening the app \[ID_25410\]

When you opened the Bookings app for the first time in a Cube session, in some cases, the time line would incorrectly be empty.

Also, due to a number of enhancements, overall performance has increased when opening the Bookings app.

#### Problem when sending an SNMP trap from an element that was being restarted \[ID_25435\]

When an SNMP trap was sent from an element that was being restarting, in some cases, an error could occur.

#### Monitoring app: Password boxes would incorrectly display their contents in normal text \[ID_25467\]

In the Monitoring app, password boxes would incorrectly display their contents in normal text. From now on, the contents of password boxes will be displayed as a series of bullets.

#### DataMiner Cube - Settings: User setting hidden in the group settings would incorrectly also be hidden in the group settings editor \[ID_25480\]

When a user setting was hidden in the group settings, it would incorrectly also be hidden in the group settings editor.

#### Automation: Problem when generating a large report via an Automation script \[ID_25482\]

When a large report was generated via an Automation script, in some cases, all other communication with the SLReportsAndDashboardsManager process could get blocked.

#### Jobs app: Problem when entering text in the search box \[ID_25489\]

When, in the Jobs app, you entered a piece of text in the search box, in some cases, no suggestions would be shown and *index_not_found* exceptions would be added to the logging.

#### Protocols: When no column was polled during a polling cycle, previously polled columns could incorrectly get cleared from memory \[ID_25500\]

When, using a particular pollingRate configuration, there was a polling cycle during which no column was polled, in some cases, previously polled columns could incorrectly get cleared from memory in SLProtocol.

#### DataMiner Cube - Correlation: Placeholders in Correlation emails were not filled in correctly \[ID_25504\]

In some cases, placeholders in Correlation emails would not be filled in correctly.

#### DataMiner Cube - Resources app: Expander showed an incorrect icon \[ID_25541\]

In the Resources app, in some cases, the expander would show an incorrect icon.

#### DataMiner Cube - Alarm Console: Hyperlinks would not update in the hyperlink column \[ID_25566\]

When an alarm had a hyperlink configured that was displayed in a hyperlink column, in some cases, that hyperlink would not get updated when the alarm was updated. The placeholders in the hyperlink would keep on displaying values from the previous alarm.

#### DataMiner Cube - Visual Overview: Alarm timeline component did not correctly aggregate different alarm timelines into a single band \[ID_25590\]

In an alarm timeline component, in some cases, an error could occur when different alarm timelines had to be aggregated into a single band.

#### Dashboards app - Visual Overview component: Problem when no page had been selected in the component settings \[ID_25594\]

When, in the Dashboards app, no page had been selected in the settings of a Visual Overview component, in some cases, that component would show a “Could not retrieve the image for the Visual Overview” error message.

#### Legacy Reporter: Report with trend graph block would incorrectly show a 'No parameters were provided for this element' notice \[ID_25595\]

When, in the legacy Reporter, you generated a report with a “trend graph” block, it would incorrectly display a “No parameters were provided for this element” notice when the parameters in question only had real-time trending enabled.

#### Elements not displayed in DataMiner Cube after connection between DMAs was restored \[ID_25602\]

When two DMAs established contact with each other after their connection had been lost, a problem could occur, which could cause elements not to be displayed in DataMiner Cube.

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

#### SNMP tables without polling rate defined would no longer be polled \[ID_25659\]

In some cases, an SNMP table without polling rate defined on any of its columns would no longer be polled.

#### DataMiner Cube: When exporting an element to CSV, only the timeout of the first communication layer would get exported \[ID_25664\]

When you exported an element to a CSV file, and that element had timeouts defined for each of its communication layers, in some cases, only the timeout of the first communication layer would get exported. When you then imported that element from the CSV file, it would immediately go into timeout.

#### DataMiner Cube - Resources app: Problem when deleting a capability or a capacity from a resource \[ID_25680\]

In the Resources app, it is possible to add capabilities and capacities to resources. When you deleted a capability or a capacity in the user interface, in some cases, the deletion would incorrectly not be implemented on the DataMiner Agent.

#### DataMiner Cube - Trending: Problem with invalid 'NaN' points \[ID_25698\]

When, in a trend graph, an invalid “NaN” point had to be drawn immediately after a gap, in some cases, an error could occur.

#### Parameter updates that did not change the parameter value would incorrectly not be applied \[ID_25736\]

In some cases, parameter updates that did not change the parameter value would not be applied. In case of a history set, this could cause a problem.

From now on, history sets will always be considered value changes, regardless of whether the value is updated or not.

#### DataMiner Cube - Service templates: Empty selection box when right-clicking a view and selecting Actions \> Apply service template... \[ID_25741\]

When you right-clicked a view in the Surveyor, and selected Actions \> Apply service template..., in some cases, the selection box containing the list of service templates to choose from would be empty due to a problem with the selection box filter.

#### DataMiner Cube - Visual Overview: Selected service definition in an embedded ServiceManager component would get unselected when another service definition was modified \[ID_25748\]

In some cases, a service definition selected in an embedded ServiceManager component would incorrectly get unselected when another service definition was modified in another Cube session.

#### DataMiner Cube - EPM: Problem when opening an EPM diagram that used the 'DiagramPids' option \[ID_25797\]

In some cases, DataMiner Cube would freeze when you opened an EPM diagram that used the “DiagramPids” option.

#### DataMiner Cube - Spectrum analysis: Hamburger menu of spectrum card still contained a deprecated link to the legacy Data Display UI \[ID_25799\]

The hamburger menu of a spectrum card still contained a deprecated link to the legacy Data Display UI. This link has now been removed.

#### DataMiner Cube: Login algorithm would incorrectly try to use TLS 1.0 when browser was configured to use TLS 1.2 \[ID_25803\]

When the Internet browser was configured to only use TLS 1.2, in some cases, the Cube login algorithm would incorrectly try to use TLS 1.0 instead.

#### Jobs app: Problem when adding a field of type 'Static Text' \[ID_25930\]

In some cases, an exception could be thrown when you added a field of type “Static Text” to a job section.
