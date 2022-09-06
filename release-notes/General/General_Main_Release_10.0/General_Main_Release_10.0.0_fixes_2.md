---
uid: General_Main_Release_10.0.0_fixes_2
---

# General Main Release 10.0.0 - Fixes (part 2)

#### Service & Resource Management: First occurrence of a ReservationDefinition was incorrectly saved twice \[ID_23328\]

When, in a DataMiner System, a ReservationDefinition was saved on a non-master DMA, in some cases, the first occurrence of that ReservationDefinition would incorrectly be saved twice.

#### HTML5 apps: Problem with WebSockets \[ID_23336\]

In the HTML5 apps (Dashboards, Jobs, etc.), in some cases, the WebSocket connection could keep disconnecting and reconnecting when a user was logged off.

From now on, when users log off, the WebSocket connection will no longer be disconnected. Instead, it will be unauthenticated.

#### DataMiner Installer: Problem when installing SNMP on Windows 10 version 1809 and above \[ID_23346\]

When installing DataMiner on a system running Windows 10 version 1809 (or above), in some cases, the DataMiner Installer was not able to properly install SNMP. As a result, the installation procedure would fail.

#### Problem when taking a backup containing data stored in a remote Elastic database \[ID_23347\]

In some cases, an error could be thrown when taking a backup containing data stored in a remote Elastic database.

#### Table of virtual function element remains empty \[ID_23356\]

In some cases, it could occur that a table of a virtual function element did not contain any data.

#### SLAnalytics: Trend data older than TTL was incorrectly taken into account when calculating trend predictions \[ID_23358\]

Up to now, trend data older than the trend data TTL setting would incorrectly be taken into account when calculating trend predictions.

#### No error information when adding TicketResolver with existing name \[ID_23369\]

In a system with a Cassandra database, when you tried to add a TicketResolver with a name that was already in use, no error information was returned.

#### Service & Resource Management: Adding, updating or deleting a protocol function would cause all protocols to be fetched from the DataMiner Agent \[ID_23373\]

In some cases, adding, updating or deleting a protocol function would incorrectly cause DataMiner Cube to fetch all protocols from the DataMiner Agent.

#### DataMiner Cube - Profile Manager: Problem when configuring the default value of profile parameters of type 'discrete' \[ID_23376\]

In some cases, it was no longer possible to configure the default value of profile parameters of type “discrete”.

#### DataMiner Cube: Not possible to unmask alarm on CPE object \[ID_23392\]

In some cases, it could occur that it was not possible to unmask an alarm on a CPE object.

#### DataMiner Cube - Visual Overview: Problem with 'VerticalAlignment=Stretch' and 'HorizontalAlignment=Stretch' options \[ID_23397\]

When positioning shapes in a grid layout, in some cases, shapes would not be stretched when using the *VerticalAlignment=Stretch* or *HorizontalAlignment=Stretch* options.

From now on, these options will allow you to stretch single, non-grouped shaped.

#### Problem when exporting Elastic logger tables \[ID_23410\]

Up to now, in some cases, an error would be thrown when you tried to export an Elastic logger table.

From now on, it is possible to export Elastic logger tables, but without any data.

#### Cassandra: Problem when fetching data using a complex filter containing subfilters \[ID_23444\]

In some cases, an error could occur when fetching data from a Cassandra database using a complex filter with a number a subfilters.

#### DataMiner Cube - Indexing: Problem when searching for most suitable hard drive at the start of the Indexing Engine installation procedure \[ID_23483\]

In some cases, an exception could be thrown when searching for the most suitable hard drive at the start of the Indexing Engine installation procedure.

#### Automation: Compiled C# files saved with an incorrect file extension \[ID_23495\]

In some cases, compiled C# files would be saved with the incorrect extension “cs0” instead of “cs”.

#### Service & Resource Management: ReservationInstances with an end time in the past would incorrectly still reserve resources \[ID_23496\]

Up to now, ReservationInstances with an end time in the past would incorrectly still reserve resources. From now on, this will no longer be the case.

Also, when eligible resources are requested for a time range with a start time in the past (by means of a GetEligibleResources call), ReservationInstances with an end time in the past will no longer be taken into account.

#### Service & Resource Management: Problem when a user opened the Bookings app for the first time \[ID_23519\]

In some cases, an exception could be thrown the first time a user opened the Bookings app.

#### Problem when trying to install Elastic on a system that is already running Elastic \[ID_23523\]

When DataMiner tried to install Elastic on a system that was already running Elastic, in some cases, an exception could be thrown.

#### DataMiner Cube - Visual Overview: Connections for active path not highlighted correctly \[ID_23558\]

In some cases, it could occur that the connections for an active path were not highlighted correctly in Visual Overview.

#### Resources incorrectly considered eligible in case of overlapping bookings with same capacity \[ID_23576\]

In some cases, when multiple overlapping bookings used the same capacity, the system would return some resources as eligible for use in a booking even though they were not.

#### Baseline value close to 0 caused constant alarm \[ID_23577\]

If a relative baseline in an alarm template was set very close to 0, it could occur that the parameter was always considered to be in alarm.

#### Problem in SLAnalytics when shutting down \[ID_23593\]

A problem could occur in the SLAnalytics process when it was shutting down.

#### Service & Resource Management: Problem when requesting booking definitions with a time filter \[ID_23631

In some cases, requesting booking definitions with a time filter would incorrectly return outdated definitions.

#### Service & Resource Management: Problem when generating a contributing service \[ID_23666\]

In some cases, an exception could be thrown when a contributing service was generated with an incorrectly configured profile parameter.

#### Problem with protocol buffer serialization when server and client were running different DataMiner versions \[ID_23679\]\[ID_24035\]

When protocol buffer serialization was being used, a number of issues could occur when a DMA and a client were running different DataMiner versions.

#### DataMiner Cube: Problem when opening a spectrum card \[ID_23696\]

In some cases, an exception could be thrown when you opened a spectrum card.

#### Legacy dashboards: No data displayed at the start of a trend graph \[ID_23755\]

On a legacy dashboard, in some cases, no data would be displayed at the start of a trend graph.

#### DataMiner Installer: Problem when setting up a Failover system due to incorrect use of quotes and double quotes in Cassandra.yaml \[ID_23773\]

In some cases, setting up a Failover system using the DataMiner Installer would fail due to the incorrect use of quotes and double quotes in the Cassandra.yaml file.

#### Duplicate log entry when SLAnalytics was started or stopped \[ID_23799\]

When SLAnalytics was started or stopped, in some cases, a duplicate entry would incorrectly be added to the log.

#### DataMiner Cube - Visual Overview: \[Sum:X,Y,Z\] placeholder did not parse decimal values \[ID_23810\]

In some cases, it could occur that the *\[Sum:X,Y,Z\]* placeholder in Visio did not parse decimal values.

#### Problem with SLElement \[ID_23846\]

In some rare cases, an error could occur in the data gateway table thread of SLElement.

#### Duplicated service definition not identical with original \[ID_23870\]

If a service definition was duplicated, it could occur that the interface configuration of the duplicate was not the same as that of the original.

#### Logon to Reports & Dashboards with SAML authentication failed \[ID_23878\]

It could occur that it was not possible to log on to the legacy Reports & Dashboards app using SAML authentication.

#### DataMiner Cube: Memory leak when opening and closing dynamic list \[ID_23910\]

If a dynamic list component was opened and closed in DataMiner Cube, for instance in the Bookings app or the Services app, a memory leak could occur.

#### Problem with alarm properties after importing alarms \[ID_23918\]

When a DELT package containing alarms was imported, in some cases, alarm properties would incorrectly be added to alarms to which they did not belong.

#### DataMiner Cube - Visual Overview: Problem with client-side filtering of dynamically positioned shapes \[ID_23946\]

When dynamically positioning shapes based on table data, in some cases, a row filter specified in a shape data field of type *Filter* would no longer be applied.

#### DataMiner Cube - Visual Overview: Custom DCF connection lines and matrix connections not displayed correctly \[ID_23955\]

In some cases, custom DCF connection lines and matrix connections would be displayed incorrectly.

#### Problem with SLAnalytics when an element was removed \[ID_23965\]

In some rare cases, an error could occur in SLAnalytics when an element was removed.

#### Service & Resource Management: Icons defined in system functions would not be displayed in DataMiner Cube \[ID_23966\]

In some cases, icons defined in system functions would not be displayed in DataMiner Cube.

#### Ticketing: Ticket fields without alarm properties would incorrectly no longer be included in the ticket \[ID_23967\]

In some cases, ticket fields without alarm properties would incorrectly no longer be included in the ticket. From now on, all ticket fields will be included in the ticket, regardless of alarm properties.

#### DataMiner Cube - Visual Overview: Problem when linking a shape to a matrix output \[ID_23980\]

When you linked a shape to a matrix output by using a shape data field of type *Output* or *OutputLabel* set to a number representing the index of the output (e.g. “1”), in some cases, that shape would be linked to an incorrect output.

#### DataMiner Cube - Trending: Problem when adding a parameter to a stopped element \[ID_24045\]

In some rare cases, an error could occur when you tried to add a parameter of a stopped element to a trend graph.

#### DataMiner Cube - Trending: Problem with 'Enable trend logging (debug)' setting \[ID_24065\]

When the “Enable trend logging (debug)” setting was deactivated, in some cases, certain log data would incorrectly still be kept in memory.

#### Ticketing: Ticket fields containing concatenations would have their type set incorrectly \[ID_24092\]

When a ticket field contained a concatenation, in some cases, the type of that field would be set incorrectly.

#### Problem with SLNet when using protocol buffer serialization \[ID_24099\]

In some rare cases, a problem could occur in SLNet when protocol buffer serialization was being used.

#### Cassandra: Paged database query would incorrectly only return the first two pages \[ID_24101\]

In some cases, a paged database query against a Cassandra database would incorrectly only return the first two pages instead of the entire result set.

#### Cassandra migration: Incorrect estimation of the amount of data to be migrated \[ID_24117\]

To be able to indicate the progress of a data migration operation, DataMiner first has to make an estimation of the amount of data to be migrated. Up to now, due to an incorrect calculation of logger table sizes, this estimation was not correct.

#### DataMiner Cube - Visual Overview: DCF connection lines between dynamically positioned shapes would disappear after zooming in and out \[ID_24119\]

In some cases, DCF connection lines between dynamically positioned shapes would disappear after zooming in and out.

#### Stopping an element with virtual functions included in an enhanced service would not correctly clear the alarms in the active alarms table \[ID_24154\]

When an element with virtual functions included in an enhanced service was stopped, although the alarms would disappear from the Alarm Console they would not be correctly cleared in the active alarms table of the enhanced service.

#### Performance issues in case of several subscriptions on single connection \[ID_24156\]

If several subscriptions were made on a single connection, there could be performance issues in Cube. This could for example be the case when service definitions were loaded.

#### Problem when simultaneously stopping an element with a direct view table and the element containing the source data \[ID_24169\]

In some cases, an error could occur when you simultaneously stopped an element with a direct view table and the element containing the source data of that direct view table.

#### DataMiner Cube - Cassandra: Problem when performing alarm queries \[ID_24177\]

On a DataMiner Agent with a Cassandra database but no Elastic database, in some cases, an exception could be thrown when performing an alarm query.

#### Problem when adding or deleting ObjectRefTreeElement objects in a Cassandra database \[ID_24188\]

In some cases, an error could be thrown when adding or deleting an ObjectRefTreeElement object in a Cassandra database.

#### Service & Resource Management: Resource concurrency calculated incorrectly when retrieving the list of eligible resources \[ID_24203\]

When the list of eligible resources was retrieved, it could occur that the resource concurrency was not calculated correctly.

#### Service & Resource Management: When a service definition was updated, the old version would not be removed \[ID_24208\]

When a service definition was updated, in some cases, the old version of that service definition would incorrectly not be removed from the *servicedeftrace* database table.

#### DataMiner Cube - System Center: A backup including the Indexing database could incorrectly be started without specifying a backup path \[ID_24217\]

In the *Backup* section of *System Center*, users would incorrectly be able to start a backup that included the Indexing database even when no *Indexing Engine backup path* had been specified. As a result, the backup operation would fail immediately.

From now on, the *Execute backup* button will be disabled when no *Indexing Engine backup path* is specified.

#### DataMiner Cube - System Center: Agent list would incorrectly be expanded after having chosen not to upgrade a number of specific agents \[ID_24223\]

When, in the *Agents* section of *System Center*, you click *Upgrade*, you can choose whether to upgrade either all agents in the cluster or a number of specific agents. If you choose the latter, and click “Yes” in the confirmation box, the list of available agents will be expanded, allowing you to select the agents to be upgraded.

However, up to now, the list of available agents would also incorrectly be expanded when you clicked “No” in the confirmation box. This will no longer occur.

#### DataMiner Cube: Version conflict error after logging in with an incorrect Administrator password \[ID_24229\]

When you tried to log in to DataMiner Cube with an incorrect Administrator password, in some cases, a version conflict error could be thrown.

#### DataMiner Cube: Locally saved document locked until DMA restart \[ID_24231\]

When a document was saved from the Documents app in Cube to a local drive, it could occur that this file was locked by DataMiner until the DMA was restarted.

#### Service & Resource Management: Alarm icons not displayed in ListView component \[ID_24232\]

In some cases, if the column configuration for a ListView component contained alarm icons, it could occur that the alarm icons were not displayed when the configuration was loaded.

#### Issues when deleting booking instances \[ID_24244\]

When a booking instance in "Ongoing" state was deleted, it could occur that the deletion failed. In addition, if a booking instances tree was deleted by passing the nodes in the tree to the helper call, it could occur that the response contained too many bookings.

#### Element migration failure because of file with same name \[ID_24249\]

When an element was migrated, it could occur that an element data file could not be created because a file with the same name already existed, causing the migration to fail. Now a suffix will be added to the file name to ensure that the file can be created.

#### DataMiner Cube - Alarm Console: Alarm filters using session variables would no longer be updated correctly \[ID_24255\]

In some cases, alarm filters that contained session variables would no longer be updated correctly when one of those variables had changed.

#### Problem with SLSNMPManager when an incorrectly configured SNMPv3 element was started \[ID_24269\]

In some cases, an error could occur in SLSNMPManager when an incorrectly configured SNMPv3 element was started.

#### Problem with SLDataMiner when processing a service alarm while updating a service \[ID_24274\]

In some rare cases, an error could occur in SLDataMiner when it is was simultaneously updating a service and processing a new alarm linked to a service.

#### Problem in SLElement when adding comment while clearing timeout alarm \[ID_24286\]

When a timeout alarm was cleared manually and the user set the comment when clearing the alarm to the IP address of the connection, a problem could occur in SLElement.

#### Failover - MySQL: Alarm cleaning process would not be able to correctly separate active from non-active alarms \[ID_24306\]

When the number of alarms stored in the database reaches a certain threshold, the oldest, non-active alarms are automatically removed from the system. However, on a Failover system with MySQL databases, in some cases, the alarm cleaning process would not be able to correctly separate active from non-active alarms.

#### DataMiner Cube - Data Display: Problem when displaying a tabbed table \[ID_24317\]

In some cases, an exception could be thrown when a tabbed table was displayed on a DATA page.

#### Reports & Dashboards: Empty tables in legacy dashboards \[ID_24320\]

On legacy dashboard, in some cases, tables containing data would incorrectly be displayed as empty.

#### DataMiner Cube: Not possible to connect to another DMA after starting Cube with a 'host=' argument \[ID_24322\]

When DataMiner Cube was started with a “host=” argument, in some cases, the user would not be able to connect to another DataMiner Agent.

#### Exception when starting up DMAs in cluster with empty Elastic database \[ID_24325\]

If several DMAs in a cluster were started at the same time and these DMAs has an empty Elastic database, an exception could be thrown.

#### Reports & Dashboards: Problem with status query in legacy Reporter app \[ID_24332\]

When you used the legacy Reporter app to generate a report containing a status query, in some cases, a “response buffer limit exceeded” error message would appear, especially when the report contained a large amount of data.

#### Alarm Console: Hyperlinks missing in right-click menu after element restart or DataMiner restart \[ID_24335\]

In the Alarm Console, in some cases, the alarm hyperlinks would disappear from the right-click menu after an element restart or a DataMiner restart.

#### Problem when importing DELT packages containing alarms \[ID_24340\]

When a DELT package containing alarms was imported on a system running Cassandra, in some cases, the root time and root creation time of the alarms could be incorrect.

#### Service & Resource Management: Function DVEs not removed after resource swap \[ID_24342\]

If resources of a running booking were swapped with other resources, it could occur that the function DVEs that were no longer in use were not disabled until the maximum number of functions was reached.

#### DataMiner Cube: CPE card headers not showing the correct alarm color \[ID_24345\]

In some cases, the header of a CPE card did not show the correct alarm color. Instead, it was set to gray (Initial).

#### Web Services API v1: Incorrect view alarm severity \[ID_24347\]

The view state returned by the following methods would incorrectly not take into account the user security.

- GetAlarmStateForView
- GetView
- GetViewsForParent

> [!NOTE]
> The above-mentioned methods are also used by the DataMiner web applications (e.g. Monitoring & Control, Dashboards, Ticketing, etc.), and the view states are also used in DataMiner Maps.

#### Element connections saved incorrectly \[ID_24348\]

If an element had multiple serial, smart-serial or HTTP port connections, it could occur that the connection type of the first port was applied to all other serial, smart-serial or HTTP ports as well.

#### Service & Resource Management: Exception when saving multiple profile instances or profile definitions with empty field \[ID_24359\]

When multiple profile instances or profile definitions containing an empty field were saved at the same time, an exception could be thrown.

#### DataMiner Cube: Problem when resizing the Alarm Console \[ID_24362\]

When you made the Alarm Console smaller and then restored it to its original size, in some cases, the entire console would become blank.

#### DataMiner Cube: Problem when displaying dialog box while window/scroll bar thumb is dragged \[ID_24383\]

In the XBAP version of DataMiner Cube, if a dialog box was displayed while a user was dragging a window or a scroll bar thumb, a problem could cause Cube to freeze.

#### Booking definition saved even though no instance could be planned \[ID_24397\]

In some cases, it could occur that a booking definition was saved even though it was not possible to plan a booking instance.

#### Addition/removal booking events of existing booking not implemented correctly \[ID_24398\]

When booking events were added to or removed from an existing booking that still needed to start, it could occur that this change was not executed correctly.

#### Service & Resource Management: Exceptions when using a MySQL local database \[ID_24401\]

On systems with a MySQL local database, if a booking was saved that overrides a property on one of its resources, an exception could be thrown. In addition, an exception could be thrown during the initialization of the Resource Manager.

#### DataMiner Cube - Visual Overview: Column configuration of ListView component not updated \[ID_24422\]

In some rare cases, it could occur that the column configuration of a *ListView* component was not saved or retrieved correctly.

#### DataMiner Cube: Editing an SNMPv3 element created prior to DataMiner 9.6.12 would cause the authentication type to be reset to the default type \[ID_24423\]

When you edited an SNMPv3 element that was created prior to DataMiner 9.6.12, in some cases, the authentication type would incorrectly be reset to the default type (i.e. SHA512).

#### Dashboards: Problem with duplicate trend graphs in line chart component \[ID_24427\]

When, in a line chart component, you selected a second parameter, in some cases, each trend graph would incorrectly be displayed twice.

#### Service & Resource Management: ReservationInstances did incorrectly not have their status set to 'interrupted' \[ID_24434\]

In some rare cases, ReservationInstances that should have had their status set to “interrupted”, had their status set to an incorrect value.

#### Problem with SLElement when updating the source data of a direct view table belonging to an element with debug log level 2 \[ID_24449\]

In some cases, an error could occur in SLElement when updating the source data of a direct view table belonging to an element of which the debug log level was set to 2.

#### Problem with SLDataGateway when retrieving recursive tree items \[ID_24461\]

In some cases, an error could occur in SLDataGateway when retrieving recursive tree items.

#### Problem when SLProtocol retrieved data from a logger table \[ID_24483\]

In some cases, a problem could occur when SLProtocol retrieved data from a logger table using an integer value as primary key.

#### DataMiner Cube - Data Display: Memory leak after sorting and/or filtering tables \[ID_24492\]

In some cases, DataMiner Cube could leak memory after sorting and/or filtering tables displayed on DATA pages.

#### Memory leak in SLXML due to a parsing issue in SLDataMiner \[ID_24503\]

In some cases, SLXML could leak memory due to an XML parsing issue in SLDataMiner.

#### DataMiner Cube: Backup could incorrectly be started while the backup settings of the Indexing engine were being configured \[ID_24510\]

Up to now, users would incorrectly be able to start a backup operation while the Indexing nodes were restarting after, for example, changing the Indexing engine’s backup path.

From now on, it will no longer be possible to start a backup operation while the backup settings of the Indexing engine are being configured.

#### Problem with SLDataMiner \[ID_24511\]

In some rare cases, an error in SLDataMiner would cause other problems to occur (e.g. element timeouts).

#### Service & Resource Management: Editing a service in the services list would incorrectly clear the IDOfSelection session variable \[ID_24519\]

When you select a service in the services list, the ID of that service is stored in the *IDOfSelection* session variable. In some cases, that session variable would incorrectly be cleared when you edited the selected service.

#### Dashboards app: Problem with unintentional move operations in Chrome \[ID_24525\]

When working with the Dashboards app in Chrome, in some cases, a mouse click could unintentionally cause a dashboard component to be moved to another location.

#### HTML5 apps: Selection box values containing backslash characters displayed incorrectly in interactive Automation scripts \[ID_24541\]

When an interactive Automation script was run from within an HTML5 app, in some cases, selection box values containing “\\” characters could be displayed incorrectly.

#### DataMiner Cube: Clicking 'Open Cube Mobile' would not always direct you to the landing page \[ID_24560\]

When, in DataMiner Cube, you clicked *Open Cube Mobile*, in some cases, you were incorrectly directed to the Monitoring & Control app. From now on, clicking *Open Cube Mobile* will always direct you to the landing page.

#### Failover: Problem with Indexing database after a Failover switch \[ID_23945\]\[ID_24562\]

When an Indexing database was installed on a pair of DataMiner Agents in a Failover setup, in some cases, the Indexing database could no longer be reached after a Failover switch.

#### DataMiner Cube: Icons and names not properly aligned in 'Below this view' list \[ID_24572\]

When you opened a view card and selected *Below this view \> All*, in some cases, the icons and the names of the list items would not be properly aligned.

#### Service & Resource Management: Problem during Resource Manager initializing \[ID_24604\]

In some cases, the Resource Manager module could fail to initialize when protocol buffer serialization was enabled.

#### Service & Resource Management: Problem when retrieving a ReservationInstance immediately after a property update \[ID_24622\]

When a ReservationInstance was retrieved immediately after its properties had been updated, in some cases, the properties of the retrieved ReservationInstance would incorrectly still have their old values.

#### DataMiner Cube - Data Display: Alarm icon outside of colored background when hovering over a parameter control \[ID_24631\]

When you hovered over a parameter control, in some cases, the colored background would not include the alarm icon.

#### DataMiner Cube: Problem when using TAB to navigate among controls \[ID_24670\]

When you used the TAB key to navigate from one control to another, navigation would fail when a numeric up/down control had the focus.

#### DataMiner Cube - Data Display: DPI settings not always taken into account when rendering selection boxes and tool tips \[ID_24685\]

In Data Display, in some cases, the screen’s DPI settings would not be taken into account when rendering selection boxes and tool tips.

#### DataMiner Cube: Problem when saving or assigning group settings \[ID_24701\]

In some cases, it would no longer be possible to save group settings or to assign new settings to a group to which none had been assigned before.

#### Problem with SLDMS when synchronizing services to other agents \[ID_24725\]

In some rare cases, an error could occur in SLDMS when synchronizing services to other agents in the DataMiner System.

#### DataMiner Cube - Services app: Service definition not loaded correctly when Services app is opened \[ID_24735\]

When you opened the Services app, it could occur that one of the service definitions was not loaded correctly. When you selected it, it was tagged as “\[modified\]” and its connection lines were lost.

#### DataMiner Cube - Data Display: Description of Write parameters would be missing when there was no corresponding Read parameter \[ID_24767\]

On an element card, in some cases, Write parameters for which there was no corresponding Read parameter would not have their description displayed.

#### Problem when masking rows or cells in view tables or direct views \[ID_24773\]

In some cases, it would no longer be possible to mask cells or rows in view tables or direct views.

#### DataMiner Cube - Automation: Problem when an Automation script tried to send an e-mail containing a report \[ID_24775\]

In some cases, an error could occur when an Automation script tried to send an e-email containing a report.

#### Problem with SLProtocol when calling 'NT_LOAD_TABLE' \[ID_24780\]

In some cases, an error could occur in SLProtocol when calling the NotifyProtocol method “NT\_LOAD_TABLE”.

#### Problem when trying to back up an Elastic database using its public IP address \[ID_24810\]

When you tried to back up an Elastic database (which is used by the DataMiner Indexing engine) using its public IP address, in some cases, a message would incorrectly appear, saying that no Elastic database could be found on the machine in question.

#### SNMP communication error processing issue \[ID_24811\]

In some cases, SNMP communication would interpret SNMP errors incorrectly.

#### Problem when an element was stopped while an alarm time trace was being written \[ID_24872\]

In some rare cases, an error could occur when an element was stopped while a time trace was being written for one of its alarms.

#### Problem when calling GetParameter on the virtual element of a redundancy group \[ID_24892\]

When a GetParameter method was called in an Automation script on the virtual element of a redundancy group, in some cases, a CreateDummyFailedException could be thrown.

#### Memory leak in SLNet when enabling or disabling logging \[ID_24921\]

In some cases, the SLNet process would leak memory when logging was enabled or disabled.

#### Users with an expired password were not able to enter a new password \[ID_24938\]

In some cases, users of whom the password had expired would not be able to enter a new password. Instead, a “Failed to setup ProtoBuf” error would appear.

#### Deleting a monitored table row could cause an incorrect alarm to be generated \[ID_24957\]

When a monitored table row was deleted, in some cases, an incorrect alarm with an invalid root ID and invalid time stamp would be generated.

#### Problem with booking after property update \[ID_25076\]

When a property of a booking was updated using the method *SafelyUpdateReservationInstanceProperties*, a problem could occur with the booking.

#### SLAnalytics: Problem when receiving a trend prediction data request for an unknown parameter \[ID_25171\]

In some cases, an error could occur in SLAnalytics when it received a request to return trend prediction data for a parameter that could not be found in the protocol.

#### Failover: Remote services not synchronized towards offline Agent \[ID_25173\]

In a Failover setup, it could occur that remote services were not synchronized towards the offline Agent.

#### Memory leak in SLLoggerUtil process \[ID_25206\]\[ID_25465\]

In some cases, the SLLoggerUtil process would leak memory. For instance, when the log levels were updated multiple times.

#### Ticketing app: Deleting a ticket would incorrectly cause all tickets to be deleted \[ID_25211\]

In some cases, deleting a ticket would incorrectly cause all tickets to be deleted.

#### Problem with SLElement when the element incorrectly identified as the DMA element was deleted \[ID_25261\]

In some cases, an error could occur in SLElement when the element incorrectly identified as the DataMiner Agent element was deleted.

#### SLProtocol would incorrectly flush timetrace data when only element data had to be flushed \[ID_25273\]

In some cases, when SLProtocol had to flush element data, it would also incorrectly flush timetrace data.

#### Generation of alarm events with root key 0 upon creation of DVE element \[ID_25328\]

When a DVE element was created, in some cases, alarm events with root key 0 would incorrectly be generated for the monitored parameters that were not in an alarm status.

#### Cassandra: When an element was restarted, duplicate timetrace entries would be written to the database \[ID_25385\]

When an element with a large amount of active alarms was restarted, in some cases, duplicate timetrace entries would be written to the Cassandra database

#### Memory leak in SLDataGateway \[ID_25395\]

When DVE elements had average trending configured while the central database was enabled, in some cases, the SLDataGateway process would leak memory.
