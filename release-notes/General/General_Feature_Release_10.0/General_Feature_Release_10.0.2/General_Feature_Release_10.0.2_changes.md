---
uid: General_Feature_Release_10.0.2_changes
---

# General Feature Release 10.0.2 – Changes

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### DataMiner Cube: New label indicating new trend group that is being added \[ID_19526\]

When a new trend group is being added in DataMiner Cube, a "\[new\]" label will be added to the trend group name in the pane that lists the existing trend groups, just as this is done for scripts in the Automation app, for example.

#### Services app - Services tab: Enhanced list view column configuration \[ID_23785\]

When you right-click a column in the *Services* tab and click *Add/remove column*, you can also select *More* to open the *Choose details* window. In that window, the way in which to set a column’s type (which, by default, is set to “Text”) has now been enhanced.

To set the type of a column, open the *Column type* selection box, and

- select “Alarm icon” to display the IDs in the column as alarm icons,
- select “Custom icon” to have the column contents replaced by icons,
- select “Color” to have the cells of that column visualized as colored blocks, or
- select “Date” to have the column contents displayed as date values.

#### Dashboards app: Trend statistics component now uses caching \[ID_23853\]

To improve performance, the trend statistics dashboard component now uses caching.

#### DataMiner Cube - Service & Resource Management: Enhanced profile management \[ID_23861\]

A number of enhancements have been made with regard to the management of profile definitions, profile instances and profile parameters.

#### Failover: Additional folders synchronized at initial setup \[ID_23875\]

From now on, at initial Failover setup, the following folders under *C:\\Skyline DataMiner\\* will also be synchronized among the two DataMiner Agents:

- Aggregation
- Configurations\\JSON
- Dashboards
- ProfileManager
- ProtocolFunctionManager
- ProtocolFunctionManager\\SrmProtocolGenerationInfo
- ServiceManager
- VisualData\\Data
- VisualData\\Objects

#### Dashboards app: Tooltips for component quick menu \[ID_23879\]

Tooltips are now available for the quick menu below a dashboard component, so that a user can see what the icons in the quick menu can be used for by hovering the mouse pointer over them.

#### Logging: Log entry type of LDAP notifications changed from 'error' to 'debug' \[ID_23915\]

Up to now, LDAP notifications were of log entry type “error”. From now on, those notifications will be of type “debug”.

#### Dashboards app: Enhanced performance \[ID_23927\]

A number of performance enhancements have been made to the Dashboards app, especially with regard to the use of button panels.

The maxJSONLength setting, for instance, has now been made configurable. Up to now, this setting, which is used when serializing and deserializing WebSocket messages, was always set to 4MiB.

To set maxJSONLength to a specific value, do the following:

1. Open the *Web.config* file located in the *C:\\Skyline DataMiner\\Webpages\\API* folder.

1. Make sure that the *configuration.appSettings* section contains an element similar to the following one:

    ```xml
    <add key="maxJsonLength" value="?10485760?" />
    ```

    Note that the value should be specified in bytes. In the example above, maxJSONLength was set to 10 MiB.

> [!NOTE]
> If no maxJSONLength value is specified in the Web.config file, this setting will be set to 20 MiB by default.

#### Enhanced performance when filtering on values in tables \[ID_23964\]

Due to a number of enhancements, overall performance has increased when filtering on values in tables.

#### Additional server-side security checks when element properties are added, updated or deleted \[ID_23968\]

From now on, an additional server-side security check will be performed when a user adds, updates or deletes an element property.

#### Enhanced performance when requesting spectrum trend data from SLNet \[ID_23971\]

Due to the introduction of a dedicated cache, overall performance has increased when requesting spectrum trend data from SLNet using GetSpectrumTrendTraceTimestampsMessage and GetSpectrumTrendTraceDataMessage.

#### Web Services API v1: Enhanced performance of GetServicesForView method \[ID_23972\]

Due to a number of enhancements, overall performance has increased when calling the *GetServicesForView* method.

#### DataMiner Cube - Visual Overview: No more logging if no highlight direction can be found for connections \[ID_23973\]

When highlighting of DCF connections was configured in a Visio drawing but no specific direction could be found for a connection, up to now, log entries were added to the Cube logging. However, as this could cause many unnecessary log entries, this will now no longer be logged.

#### Services app: Service definition diagram enhancements \[ID_23985\]

In the *Services* app, a number of enhancements have been made to the diagrams that graphically visualize service definitions.

Also, when you embed the Services app in Visual Overview by using a Service Manager component, it is now possible to have that component display node IDs. To do so, add the following option to the *ComponentOptions* shape data field:

| Shape data field | Value              |
|------------------|--------------------|
| ComponentOptions | “ShowNodeIDs=true” |

#### Enhanced performance when reading data from an Elastic database \[ID_23994\]

Due to a number of data serialization enhancements, overall performance has increased when reading data from an Elastic database.

#### IIS URL Rewrite module will now automatically be installed during a DataMiner upgrade \[ID_24022\]

The IIS URL Rewrite module will now automatically be installed during a DataMiner upgrade.

#### Service & Resource Management: Function XML-related enhancements \[ID_24037\]

The following enhancements have been implemented in the Service & Resource Management module:

- The *FunctionDefinition* object now contains a list of *ExportRules*, which contain the export rules defined in the function XML file.

- It is now possible to upload function XML files that have the "broadcast" option defined on an interface.

- When *ProtocolFunctionVersion.ToXml* is called and no *ParameterGroupLink* is defined, the *ParameterGroupLink* property will now no longer be present on an interface in the resulting XML.

- When *ProtocolFunctionVersion.ToXml* is called, the resulting XML will now wrap the contents of the "Graphical" tag in a CData tag.

#### Dashboards app - Group component: Option to have the legend be expanded or collapsed by default \[ID_24046\]

The Group component now has an option that allows you to specify whether its legend should by default be expanded or collapsed.

If you do not set this option, the legend will by default be collapsed.

#### Cassandra service: Restart time-out increased from 10 seconds to 5 minutes \[ID_24084\]

When the Cassandra service goes down, DataMiner automatically attempts to restart the service.

The time-out for the Cassandra service to change from “starting” to “started” has now been increased from 10 seconds to 5 minutes. Also, if a restart attempt fails or times out after 5 minutes, DataMiner will now keep trying indefinitely every 60 seconds.

Logging has also been improved. Each time a restart attempt has failed, an error will now be added to the log.

#### Cassandra service: Startup time-out increased from 10 seconds to 5 minutes \[ID_24088\]

When the Cassandra service is down while DataMiner is starting up, DataMiner will automatically attempt to start the service.

The time-out for the Cassandra service to change from “starting” to “started” has now been increased from 10 seconds to 5 minutes.

- If DataMiner is not able to start the Cassandra service in 5 minutes, it will start up in file offload mode with all elements in an error state.

    > [!NOTE]
    > Starting the Cassandra service by hand requires a full DataMiner restart.

- If DataMiner is able to start the Cassandra service, but not to establish a database connection, DataMiner will try to establish a connection for the number of times specified in the following Db.xml setting:

    ```xml
    <DataBase active="true" local="true" type="Cassandra">
      <ConnectionRetries>60</ConnectionRetries>
    </DataBase>
    ```

#### Service & Resource Management: Enhanced performance when opening the Services app or Profiles app \[ID_24112\]

Due to a number of enhancements, overall performance has increased when opening the Services app or the Profiles app on systems with a large number of service definitions and profile definitions.

#### Dashboards app - Parameter table component: Columns of which the 'disableHistogram' option is set will no longer have a histogram icon in their header \[ID_24131\]

In a parameter table component, from now on, table columns of which the “disableHistogram” option is set will no longer have a histogram icon displayed in their header.

#### DataMiner Cube: Enhanced performance when drawing card breadcrumbs \[ID_24151\]

Due to a number of enhancements, overall performance has increased when drawing the breadcrumbs at the top of a card.

#### SLNetClientTest tool: Failover Agents included when viewing across cluster \[ID_24170\]

In the SLNetClientTest tool, for some messages (e.g. *Diagnostics* > *SLNet* > *StackSizes*) it is possible to right-click the message and select *View across cluster* to send it to the entire DMS. This feature has now been improved to include Failover Agents as well.

#### DataMiner Cube - Automation/Correlation: Width of action dialog boxes will now automatically be adapted to the size of the screen \[ID_24190\]

From now on, when you configure actions in Automation scripts or Correlation rules, the action dialog boxes will automatically adapt their width to the size of the screen.

#### Enhanced view data synchronization \[ID_24197\]

A number of enhancements have been made with regard to the synchronization of view data among the agents in a DataMiner System.

#### Jobs app: Enhanced error handling when adding jobs \[ID_24238\]

Error handling when adding jobs has been enhanced.

#### DataMiner Cube - Services app: Service list will no longer be initialized when Visual Overview only shows the service definition editor \[ID_24242\]

From now on, the services list in the Services app will no longer be initialized when Visual Overview only shows the service definition editor.

#### DataMiner Cube: Enhanced performance when generating authentication tickets for embedded web browsers \[ID_24261\]

Due to a number of enhancements, overall performance has increased when generating authentication tickets for embedded web browsers in apps like Ticketing, Dashboards, Maps, etc.

#### Dashboards app: Updated design rotate button in button panel \[ID_24272\]

The design of the rotate button in a button panel component has been updated.

#### Smart-serial communication over IP: Receive time-out reduced from 100 ms to 15 ms \[ID_24282\]

In case of smart-serial communication over IP, the hard-coded time-out when receiving data has now been reduced from 100 ms to 15 ms.

#### Service & Resource Management: Enhanced performance when saving and synchronizing resources \[ID_24289\]

Due to a number of enhancements, overall performance has increased when saving resources and synchronizing them among the agents in the DataMiner System.

#### DataMiner Maps: Enhanced performance when opening a pop-up balloon \[ID_24292\]

Due to a number of enhancements, overall performance has increased when opening a pop-up balloon.

#### Improved logging when uploaded protocol requires higher DataMiner version \[ID_24298\]

Logging has improved when a protocol is uploaded that requires a higher DataMiner version than the one currently installed in the system. The following error message will now be logged: "DataMiner version is too low to use this protocol. Please check the protocol's Compliancies tag."

#### DataMiner Cube - Visual Overview: Enhanced performance when using 'FollowPathColor' and 'InternalInterfaceHopping' \[ID_24305\]

Due to a number of enhancements, overall performance has increased when using “FollowPathColor” and “InternalInterfaceHopping”, especially when a large number of shapes are linked to elements containing many interfaces and connections.

#### Alarm level linking: Enhanced performance \[ID_24308\]

Due to a number of enhancements, overall alarm level linking performance has increased.

Also, a new table filter option "sort=NONE" has been added. Using this option will prevent SLElement from applying any kind of sorting.

#### DataMiner Cube - Stream Viewer: Buffer size increased to 1 MB \[ID_24330\]

The buffer size of Stream Viewer’s text box has increased from 32 kB to 1 MB.

#### Possibility to show information message in mobile apps + Dashboards app layout update \[ID_24336\]

In the Monitoring, Dashboards and Jobs apps, it is now possible to use the *ShowInformationMessage* method in a script to display a message in the app.

Note that a small change has also been implemented in the Dashboards app. The *New dashboard* button will no longer be displayed in the header bar. Creating a new dashboard remains possible via the context menu of the side panel and via the Dashboards homepage.

#### HTML5 apps: Enhanced icons \[ID_24341\]

All HTML5 apps (Dashboards, Monitoring, Jobs, etc.) now have enhanced icons.

#### Improved error message when bookings overlap \[ID_24346\]

When a booking is saved and there is another booking that overlaps it, previously all overlapping bookings would be returned in the error message. Now the error message will only return the bookings that conflict with the booking that is being saved.

#### Service & Resource Management: Enhanced processing of event messages related to ReservationInstances and ReservationDefinitions \[ID_24350\]

Due to a number of enhancements, the processing of event messages related to ReservationInstances or ReservationDefinitions has improved.

#### Jobs app: Timeline improvement \[ID_24352\]

In the Jobs app, the way items are displayed on the timeline has been improved:

- Items on the timeline now have a minimum width, so that they are displayed even if they have a very short duration.

- If items on the same height are very close to each other, they will be merged into one aggregated item.

- Clicking an item will now always select it. Clicking an aggregated item will select all the items it combines. To deselect an item, keep Ctrl pressed while you click it.

#### No more empty cookie in request header for embedded Chromium browser \[ID_24387\]

If the request header for an embedded Chromium browser has an empty cookie, the cookie will now no longer be included in the request header. This will improve compatibility with web servers that cannot handle an empty cookie field.

#### DataMiner Cube: Enhanced breadcrumbs on service cards \[ID_24408\]

A number of enhancements have been made to the way in which breadcrumbs are displayed when you open a service cards.

#### HTML5 apps: More consistent layout due to shared UI components \[ID_24414\]

The overall layout of the different HTML5 apps has been made more consistent.

#### DataMiner Cube: Enhanced handling of table configuration errors in protocols \[ID_24432\]

From now on, due to a number of enhancements, DataMiner Cube will be able to better handle any table configuration errors when rendering tables.

Also, when such errors are encountered, additional information will be added to the logging.

#### FullFilter can no longer be used when filtering the list of elements from which a direct view retrieves data \[ID_24445\]

When filtering the list of elements from which a direct view retrieves data, from now on, it will no longer be possible to use FullFilter. However, it will still be possible to do so using a VALUE=parameterId==value filter.

#### SLAnalytics: Enhanced alarm template monitoring \[ID_24477\]

Due to a number of enhancements, overall performance of SLAnalytics has increased when monitoring alarm templates.

#### DataMiner Cube - Visual Overview: Improved performance when using \[param:\] placeholder \[ID_24493\]

When a \[param:\] placeholder is used in Visio, the way parameters are retrieved has been improved, resulting in improved performance.

#### New default values for MySQL settings when installing a new DataMiner Agent \[ID_24516\]

When installing a new DataMiner Agent with a MySQL database, the following MySQL settings will now get a new default value:

| Setting          | Value |
|------------------|-------|
| max_connections  | 1000  |
| secure_priv_file | ""    |

#### Web Services API v1: Unused method and arguments removed \[ID_24530\]

The method *GetClusterAsync*, which could not yet be used, has been removed from the Web Services API v1. In addition, a number of fields that also could not yet be used have been removed. The following fields have been removed from the *DMAAutomationScriptSettings* object:

- DebugMode
- AllowUndef
- SupportsBackAndForward
- SkipElementChecks
- SavedFromCube
- SkipSetInfoEvents

The following fields have been removed from the *DMAScatterAxisInfo* object:

- ParameterID
- TableIndex

#### Service & Resource Management: Enhanced performance when updating active function definitions \[ID_24554\]

Due to a number of enhancements, overall performance has increased when updating active function definitions.

#### Annotation web pages now contain an explicit UTF-8 character encoding declaration \[ID_24555\]

From now on, the annotation web pages will contain the following explicit UTF-8 character encoding declaration:

```xml
<meta charset="utf-8">
```

### Fixes

#### DataMiner Cube: Problem with Element migration window \[ID_23237\]

When connected to a DataMiner System with multiple DataMiner Agents, you opened *System Center \> Agents \> Status*, clicked *Migrate*, selected a destination agent and a number of elements, and then clicked either *Migrate* to start migrating the selected elements to the selected agent or *Cancel* to exit the *Element migration* window, in some cases, an exception could be thrown.

#### DataMiner Cube - Alarm template groups: Table column parameters listed in incorrect order \[ID_23675\]

When an alarm template group listed multiple table column parameters, in some cases, those parameters would be sorted incorrectly.

#### Problem with protocol buffer serialization when server and client were running different DataMiner versions \[ID_23679\]\[ID_24035\]

When protocol buffer serialization was being used, a number of issues could occur when a DMA and a client were running different DataMiner versions.

#### DataMiner Cube - Router Control: Problem in case of multiple consecutive matrix updates \[ID_23680\]

In the Router Control app, in some rare cases, an exception could be thrown when a matrix was updated multiple times in rapid succession.

#### DataMiner Cube - Visual Overview: No effect when clicking shape \[ID_23713\]

In some cases, it could occur that clicking a shape had no effect.

#### SLProtocol crash on multi-threaded timers \[ID_23744\]

In some cases, an error could occur in SLProtocol when using multi-threaded timers on an element with debug logging enabled at level 3 or higher.

#### DataMiner Cube: Not possible to select value for alarm template condition based on discrete parameter with dependency \[ID_23789\]

When a condition was added on a parameter in an alarm template and this condition was set to be based on the value of a discrete parameter with a dependency on another parameter, it could occur that no value could be selected. This issue has been resolved. In addition, in the configuration of an alarm template condition, it is now no longer possible to use a wildcard for parameters that can only have discrete values.

#### Dashboards app: Polling issues when WebSocket communication was disabled \[ID_23801\]

When WebSocket communication was disabled for a dashboard, it could occur that the state of views and redundancy groups was only polled every 5 minutes. In addition, it could occur that only the initial active alarms were retrieved.

#### DataMiner Cube - Visual Overview: \[Sum:X,Y,Z\] placeholder did not parse decimal values \[ID_23810\]

In some cases, it could occur that the *\[Sum:X,Y,Z\]* placeholder in Visio did not parse decimal values.

#### Dashboards app - Trend charts: Boundary lines would only be drawn on the first axis \[ID_23837\]

When you added boundary lines to a trend chart, in some cases, the lines would only be drawn on the first axis. From now on, they will be drawn on every visible axis.

#### DataMiner Cube - Alarm Console: Problem when sorting alarms after grouping them \[ID_23845\]

When, in the hamburger menu of the Alarm Console, the *Automatically group according to arrangement* option is disabled, you can group the alarms by right-clicking a column header and selecting *Group by this field*. You can then sort the alarms in the different groups by clicking a column header. In some cases, however, after grouping alarms by a particular column, it was no longer possible to sort alarms by that same column.

#### Problem with SLElement \[ID_23846\]

In some rare cases, an error could occur in the data gateway table thread of SLElement.

#### NotifyDataminer call could contain empty information \[ID_23863\]

In some rare cases, NotifyDataMiner calls would include insufficient information.

#### Duplicated service definition not identical with original \[ID_23870\]

If a service definition was duplicated, it could occur that the interface configuration of the duplicate was not the same as that of the original.

#### Service & Resource Management: Problem when sorting a ListView by a custom property column \[ID_23876\]

When you sorted a bookings list or a services list by a custom property column, in some cases, the sort order would not be remembered. The next time you opened the *Bookings* app or the *Services* app, the list would be sorted as before.

#### Dashboards app: Selected items in the feeds of a dashboard would be unselected after renaming that dashboard \[ID_23877\]

When you renamed a dashboard after selecting a number of items in its feeds, in some cases, all items selected in those feeds would incorrectly be unselected after the dashboard had been renamed.

#### Connection not closed when element with 'Accepted IP address' configuration was stopped \[ID_23882\]

If an element with a smart-serial connection was configured to only allow communication from certain IP addresses and this element was stopped, it could occur that the connection with those IP addresses was not properly closed.

#### Dashboards app: Indices data feed overwritten if same primary key was used \[ID_23884\]

If a dashboard contained a component using an indices data feed, and another indices data feed with the same primary key was added to a different component of the dashboard, it could occur that this second indices feed overwrote the indices for the first component.

#### Aggregation rules operating on views would generate an excessive amount of calls to SLDataMiner \[ID_23892\]

When an aggregation rule that operates recursively on a view was executed, in some cases, an excessive amount of calls from SLProtocol to SLDataMiner were generated.

#### Services app would not list all function definitions configured in newly activated functions file \[ID_23896\]

When you activated a new functions file for a particular protocol, in some cases, the Services app would not list all function definitions configured in that file.

#### DataMiner Cube: Memory leak when opening and closing dynamic list \[ID_23910\]

If a dynamic list component was opened and closed in DataMiner Cube, for instance in the Bookings app or the Services app, a memory leak could occur.

#### Problem with alarm properties after importing alarms \[ID_23918\]

When a DELT package containing alarms was imported, in some cases, alarm properties would incorrectly be added to alarms to which they did not belong.

#### Redundancy groups with multiple primary and multiple backup elements could go into an undefined state after switching \[ID_23924\]

In some cases, redundancy groups with multiple primary elements and multiple backup elements could incorrectly go into an undefined state after switching.

#### Problem with SLDataMiner when initializing redundancy groups at DataMiner startup \[ID_23943\]

During DataMiner startup, in some rare cases, an error could occur in SLDataMiner when initializing redundancy groups.

#### DataMiner Cube - Visual Overview: Problem with client-side filtering of dynamically positioned shapes \[ID_23946\]

When dynamically positioning shapes based on table data, in some cases, a row filter specified in a shape data field of type *Filter* would no longer be applied.

#### DataMiner Cube - Visual Overview: Problem when using a children shape in conjunction with a Service Overview Manager element \[ID_23960\]

In some cases, an exception could be thrown when using a children shape in conjunction with a Service Overview Manager element.

#### Problem with SLAnalytics when an element was removed \[ID_23965\]

In some rare cases, an error could occur in SLAnalytics when an element was removed.

#### Service & Resource Management: Icons defined in system functions would not be displayed in DataMiner Cube \[ID_23966\]

In some cases, icons defined in system functions would not be displayed in DataMiner Cube.

#### DataMiner Cube - Service templates: Incorrect combination values in 'Conditions' section of 'Edit child element' window \[ID_23979\]

When configuring conditions in the *Conditions* section of an *Edit child element* window, in some cases, the *Combination* selection boxes would contain incorrect values. Also, no value would be selected by default.

#### Table cells could no longer be set to 'invalid' & problem with SLElement when a user subscribed to a view table \[ID_23997\]

Due to a validation check problem, table cells could no longer be set to “invalid”.

Also, in some cases, an error could occur in SLElement when a user subscribed to a view table.

#### DataMiner packages: Problem when parsing UpdateContent.txt \[ID_24027\]

When a non-Latin character set was used in the UpdateContent.txt file of a DataMiner package, in some cases, an error could occur when that file was parsed.

#### Dashboards app: Problem when multiple view filters had been added to a parameter feed \[ID_24030\]

When multiple view filters had been added to a parameter feed using the entire element dataset, it could occur that only the last filter was taken into account.

#### DataMiner Cube - Trending: Problem when adding a parameter to a stopped element \[ID_24045\]

In some rare cases, an error could occur when you tried to add a parameter of a stopped element to a trend graph.

#### Problem with custom branding on landing page and tools page \[ID_24050\]

In some cases, it could occur that custom branding was not applied to a DataMiner Agent’s landing page and tools page.

#### Problem with SLPort when closing a serial or GPIB port \[ID_24056\]

In some rare cases, an error could occur in SLPort when a serial port or a GPIB port was closed.

#### DataMiner Cube - Trending: Problem with 'Enable trend logging (debug)' setting \[ID_24065\]

When the “Enable trend logging (debug)” setting was deactivated, in some cases, certain log data would incorrectly still be kept in memory.

#### DataMiner Cube: Server settings without value would incorrectly inherit the value set during the previous Cube session \[ID_24069\]

When a (new) server setting did not have a value, in some cases, instead of being assigned the default value it would incorrectly inherit the value that was assigned to it during the previous Cube session.

#### Problem during SLElement start-up \[ID_24075\]

When SLElement started up, in some cases, an error could occur when determining the amount of parameter threads to be created.

#### Scheduler: Problem when trying to save a scheduled task \[ID_24085\]

When a scheduled task was created with a report action that included a parameter with a filter containing a “\<“ character, it could occur that it was not possible to save that task.

#### Memory leak in SLElement after deleting DVE elements and/or virtual functions \[ID_24089\]

In some cases, it could occur that memory was not released properly in SLElement after DVE elements or virtual functions had been deleted.

#### Ticketing: Ticket fields containing concatenations would have their type set incorrectly \[ID_24092\]

When a ticket field contained a concatenation, in some cases, the type of that field would be set incorrectly.

#### Problem with SLNet when using protocol buffer serialization \[ID_24099\]

In some rare cases, a problem could occur in SLNet when protocol buffer serialization was being used.

#### Cassandra: Paged database query would incorrectly only return the first two pages \[ID_24101\]

In some cases, a paged database query against a Cassandra database would incorrectly only return the first two pages instead of the entire result set.

#### Parameters exported to multiple types of DVE elements would not be updated in all DVE elements \[ID_24103\]

When a parameter that was not directly linked to a DVE element via primary or foreign key was exported to multiple types of DVE elements sharing the same parent DVE element, it could occur that updates of that parameter did not get pushed to all the DVE elements to which it had been exported.

#### DataMiner Cube: Updates made to the LDAP settings would not immediately be applied \[ID_24110\]

When changes had been made to the LDAP settings, in some cases, those changes would not be applied immediately. From now on, any change made to the LDAP settings will be applied immediately.

#### Cassandra migration: Incorrect estimation of the amount of data to be migrated \[ID_24117\]

To be able to indicate the progress of a data migration operation, DataMiner first has to make an estimation of the amount of data to be migrated. Up to now, due to an incorrect calculation of logger table sizes, this estimation was not correct.

#### DataMiner Cube - Visual Overview: DCF connection lines between dynamically positioned shapes would disappear after zooming in and out \[ID_24119\]

In some cases, DCF connection lines between dynamically positioned shapes would disappear after zooming in and out.

#### Dashboards app: Problem when a parameter state component was linked to an element feed \[ID_24136\]

When the element filter of a parameter state component was changed, in some cases, that change would not get applied. When a parameter state component was linked to an element feed, only the initial filter would be applied. Any changed to the element feed would not be passed to the parameter state component.

#### Problem when changing a foreign key value in a table linked to a DVE element or a Virtual Function \[ID_24141\]

When a foreign key value was changed in a table linked to a DVE element or a Virtual Function, in some cases, only the primary key and foreign key value would be passed along with the update message. As a result, all other values would incorrectly be shown as “not initialized”.

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

#### DataMiner Cube: Problem when closing card \[ID_24196\]

In some rare cases, a problem could occur in DataMiner Cube when a card was closed.

#### Credential library: Problem with passwords having been encrypted multiple times \[ID_24201\]

In the credential library, in some cases, passwords would incorrectly be encrypted multiple times.

Also, in some cases, an exception could be thrown when you tried to edit an existing library credential.

#### Service & Resource Management: When a service definition was updated, the old version would not be removed \[ID_24208\]

When a service definition was updated, in some cases, the old version of that service definition would incorrectly not be removed from the *servicedeftrace* database table.

#### DataMiner Cube - System Center: A backup including the Indexing database could incorrectly be started without specifying a backup path \[ID_24217\]

In the *Backup* section of *System Center*, users would incorrectly be able to start a backup that included the Indexing database even when no *Indexing Engine backup path* had been specified. As a result, the backup operation would fail immediately.

From now on, the *Execute backup* button will be disabled when no *Indexing Engine backup path* is specified.

#### DataMiner Cube - System Center: Agent list would incorrectly be expanded after having chosen not to upgrade a number of specific agents \[ID_24223\]

When, in the *Agents* section of *System Center*, you click *Upgrade*, you can choose whether to upgrade either all agents in the cluster or a number of specific agents. If you choose the latter, and click “Yes” in the confirmation box, the list of available agents will be expanded, allowing you to select the agents to be upgraded.

However, up to now, the list of available agents would also incorrectly be expanded when you clicked “No” in the confirmation box. This will no longer occur.

#### Service & Resource Management: Resources in service of child booking not updated after booking resources were updated \[ID_24224\]

When an SRM script updated the resources for a child booking but it only passed the main booking to the *AddOrUpdateReservationInstances* call, it could occur that the resources in the service of the child booking were not updated.

#### DataMiner Cube: Version conflict error after logging in with an incorrect Administrator password \[ID_24229\]

When you tried to log in to DataMiner Cube with an incorrect Administrator password, in some cases, a version conflict error could be thrown.

#### DataMiner Cube: Locally saved document locked until DMA restart \[ID_24231\]

When a document was saved from the Documents app in Cube to a local drive, it could occur that this file was locked by DataMiner until the DMA was restarted.

#### Service & Resource Management: Alarm icons not displayed in ListView component \[ID_24232\]

In some cases, if the column configuration for a ListView component contained alarm icons, it could occur that the alarm icons were not displayed when the configuration was loaded.

#### Jobs app: Problem when filtering on a field of the default job section \[ID_24236\]

When creating a filter on a field of the default job section, in some cases, an incorrect field ID would be used.

#### Issues when deleting booking instances \[ID_24244\]

When a booking instance in "Ongoing" state was deleted, it could occur that the deletion failed. In addition, if a booking instances tree was deleted by passing the nodes in the tree to the helper call, it could occur that the response contained too many bookings.

#### Element migration failure because of file with same name \[ID_24249\]

When an element was migrated, it could occur that an element data file could not be created because a file with the same name already existed, causing the migration to fail. Now a suffix will be added to the file name to ensure that the file can be created.

#### DataMiner Cube - Failover: Progress message no longer displayed during a switch-over \[ID_24250\]

During a switch-over, in some cases, users would no longer receive a “\<DMA> is switching to \<DMA>” message.

Also, the term “System Display” has been replaced by “Client Interface” in *Failover status* windows.

#### DataMiner Cube - Alarm Console: Alarm filters using session variables would no longer be updated correctly \[ID_24255\]

In some cases, alarm filters that contained session variables would no longer be updated correctly when one of those variables had changed.

#### Dashboards app: Incorrect message would appear when an interactive Automation script went into timeout \[ID_24258\]

When an interactive Automation script running inside the Dashboards app went into timeout, in some cases, a success message would incorrectly be displayed instead of an error message.

#### DataMiner Cube - Profiles app: Protocol version not set to 'Production' when linking a parameter \[ID_24260\]

When, in the Profiles app, you dragged an element using the production version of a protocol onto the parameter list and linked a protocol parameter to a profile parameter, in some cases, the protocol version would incorrectly not be set to “Production”.

#### DataMiner Cube - Protocols & Templates: Problem when opening information template \[ID_24267\]

In some cases, an exception could be thrown when an information template was opened.

#### Trending: Incorrect trend data retrieved for view column parameters \[ID_24268\]

In some cases, incorrect trend data would be retrieved for view column parameters.

#### DataMiner Cube - Visual Overview: Missing options in trending context menu \[ID_24271\]

In some cases, it could occur that the context menu for a trend component in Visual Overview did not show all the available options.

#### Problem with SLDataMiner when processing a service alarm while updating a service \[ID_24274\]

In some rare cases, an error could occur in SLDataMiner when it is was simultaneously updating a service and processing a new alarm linked to a service.

#### DataMiner Cube - Profiles app: When linking a profile parameter to a protocol parameter only Read/Write parameters would be listed \[ID_24280\]

When, in the Profiles app, you linked a profile parameter to a protocol parameter, the parameter selection box would incorrectly only list Read/Write parameters.

Also, it would incorrectly only be possible to link parameters of category “Configuration” to protocol parameters.

#### Datetime value in interactive Automation script not updated correctly \[ID_24284\]

When a datetime value in an interactive Automation script was changed by the script itself, it could occur that the value was not updated correctly.

#### Dashboards app / Jobs app: Problem opening the user menu \[ID_24285\]

In the Dashboards app and the Jobs app, in some cases, it would not be possible to open the user menu.

#### Problem in SLElement when adding comment while clearing timeout alarm \[ID_24286\]

When a timeout alarm was cleared manually and the user set the comment when clearing the alarm to the IP address of the connection, a problem could occur in SLElement.

#### Jobs app: Job end times displayed incorrectly in timeline \[ID_24287\]

In the jobs timeline, in some cases, job end times would be displayed incorrectly.

#### Problem when filtering view tables \[ID_24288\]

When a view table was filtered, in some cases, the table would incorrectly be empty or show incorrect data.

#### Failover - MySQL: Alarm cleaning process would not be able to correctly separate active from non-active alarms \[ID_24306\]

When the number of alarms stored in the database reaches a certain threshold, the oldest, non-active alarms are automatically removed from the system. However, on a Failover system with MySQL databases, in some cases, the alarm cleaning process would not be able to correctly separate active from non-active alarms.

#### Problem when DVE creation was being disabled while updating a table with an ';element' column option \[ID_24309\]

In some rare cases, an error could occur when a table with an “;element” column option was being updated while a request was being processed to disable the DVE creation on that element.

#### Problem with a FullFilter on a direct view that retrieved data from elements with different protocols \[ID_24313\]

When a FullFilter was used on a direct view that retrieved data from elements with different protocols, in some cases, no results would be returned.

#### DataMiner Cube - Data Display: Problem when displaying a tabbed table \[ID_24317\]

In some cases, an exception could be thrown when a tabbed table was displayed on a DATA page.

#### DataMiner Cube: Masked alarms included in 'Unassigned active alarms' or 'My active alarms' tab page \[ID_24319\]

When an "Unassigned active alarms" or "My active alarms" tab page was added in the Alarm Console, it could occur that this tab page also included masked alarms.

#### Reports & Dashboards: Empty tables in legacy dashboards \[ID_24320\]

On legacy dashboard, in some cases, tables containing data would incorrectly be displayed as empty.

#### DataMiner Cube: Not possible to connect to another DMA after starting Cube with a 'host=' argument \[ID_24322\]

When DataMiner Cube was started with a “host=” argument, in some cases, the user would not be able to connect to another DataMiner Agent.

#### HTML5 apps: Selecting the month value in a datetime control would incorrectly clear that value \[ID_24323\]

When you selected the month value in a datetime control, in some cases, that value would incorrectly be cleared.

#### Exception when starting up DMAs in cluster with empty Elastic database \[ID_24325\]

If several DMAs in a cluster were started at the same time and these DMAs has an empty Elastic database, an exception could be thrown.

#### DataMiner Cube - Visual Overview: Problem when using dynamic zoom while DCF connection properties were being displayed \[ID_24326\]

In some rare cases, an exception could be thrown when you tried to use the dynamic zoom while DCP connection properties were being displayed.

#### Automation: Dialog box from an interactive Automation script started in Dashboards would incorrectly appear in Cube \[ID_24328\]

In some cases, a dialog box from an interactive Automation script started in Dashboards would incorrectly appear inside a Cube session.

#### Reports & Dashboards: Problem with status query in legacy Reporter app \[ID_24332\]

When you used the legacy Reporter app to generate a report containing a status query, in some cases, a “response buffer limit exceeded” error message would appear, especially when the report contained a large amount of data.

#### Alarm Console: Hyperlinks missing in right-click menu after element restart or DataMiner restart \[ID_24335\]

In the Alarm Console, in some cases, the alarm hyperlinks would disappear from the right-click menu after an element restart or a DataMiner restart.

#### Alarm templates: Problem when changing the condition of a conditionally monitored parameter \[ID_24338\]

When, in an alarm template, a conditionally monitored parameter had its condition changed, in some cases, alarms associated with that parameter would incorrectly be cleared using the current time instead of the time at which the condition was changed.

Also, when such a condition was changed, the alarm level update would be stored in the database with an incorrect time stamp, leading to issues with trend graphs.

#### Problem when importing DELT packages containing alarms \[ID_24340\]

When a DELT package containing alarms was imported on a system running Cassandra, in some cases, the root time and root creation time of the alarms could be incorrect.

#### Service & Resource Management: Function DVEs not removed after resource swap \[ID_24342\]

If resources of a running booking were swapped with other resources, it could occur that the function DVEs that were no longer in use were not disabled until the maximum number of functions was reached.

#### DataMiner Cube: Not possible to navigate to DataMiner object from embedded Chromium browser \[ID_24343\]

When an embedded Chromium browser was used in DataMiner Cube, it could occur that it was not possible to navigate to a DataMiner object from the embedded browser.

#### DataMiner Cube: CPE card headers not showing the correct alarm color \[ID_24345\]

In some cases, the header of a CPE card did not show the correct alarm color. Instead, it was set to gray (Initial).

#### Element connections saved incorrectly \[ID_24348\]

If an element had multiple serial, smart-serial or HTTP port connections, it could occur that the connection type of the first port was applied to all other serial, smart-serial or HTTP ports as well.

#### DataMiner Cube - Automation: Variables not linked to an input parameter would not be displayed \[ID_24358\]

In Automation, in some cases, referenced variables would incorrectly not be displayed if they were not linked to a script input parameter.

#### Service & Resource Management: Exception when saving multiple profile instances or profile definitions with empty field \[ID_24359\]

When multiple profile instances or profile definitions containing an empty field were saved at the same time, an exception could be thrown.

#### DataMiner Cube: Pages loading slowly because of unnecessary view table data refresh \[ID_24360\]

In some cases, it could occur that view table data were refreshed even when this was not necessary, which could cause data pages or visual overview pages to load very slowly in Cube.

#### DataMiner Cube - Correlation: Problem with 'Send email' actions in Correlation rules \[ID_24361\]

When triggered, in some cases, “Send email” actions in Correlation rules would not send an email when the recipient was a DataMiner user.

#### DataMiner Cube: Problem when resizing the Alarm Console \[ID_24362\]

When you made the Alarm Console smaller and then restored it to its original size, in some cases, the entire console would become blank.

#### DataMiner Cube: Not possible to export debug information \[ID_24365\]

In some cases, it could occur that it was not possible to export debug information in the Logging app.

#### SNMP forwarding with multiple alarm filters not working correctly \[ID_24368\]

If multiple alarm filters were combined for the forwarding of SNMP notifications, it could occur that only the first filter was applied.

#### DataMiner Cube: Problem when changing the protocol as well as the trend or alarm template of an element \[ID_24371\]

In some cases, an exception could be thrown when, during an element edit, you changed the protocol or protocol version as well as the trend or alarm template.

#### Service & Resource Management - Bookings app: Bookings displayed on the bookings timeline would not be listed in the bookings list \[ID_24374\]

In the Bookings app, in some cases, bookings displayed on the bookings timeline would not be listed in the bookings list.

#### DataMiner Cube: Problem when displaying dialog box while window/scroll bar thumb is dragged \[ID_24383\]

In the XBAP version of DataMiner Cube, if a dialog box was displayed while a user was dragging a window or a scroll bar thumb, a problem could cause Cube to freeze.

#### Booking definition saved even though no instance could be planned \[ID_24397\]

In some cases, it could occur that a booking definition was saved even though it was not possible to plan a booking instance.

#### Addition/removal booking events of existing booking not implemented correctly \[ID_24398\]

When booking events were added to or removed from an existing booking that still needed to start, it could occur that this change was not executed correctly.

#### Service & Resource Management: Exceptions when using a MySQL local database \[ID_24401\]

On systems with a MySQL local database, if a booking was saved that overrides a property on one of its resources, an exception could be thrown. In addition, an exception could be thrown during the initialization of the Resource Manager.

#### DataMiner Maps: Problem with user-defined links in pop-up balloons when using the Chromium web engine \[ID_24402\]

When DataMiner maps were being displayed on a Visio page using a Chromium web engine, in some cases, the user-defined links in pop-up balloons would not function correctly.

#### DataMiner Cube - Visual Overview: Incorrect trend legend when graph was opened from table parameter in Visio \[ID_24405\]

When you opened a trend graph from a table parameter control in Visio, it could occur that the legend of the trend graph only allowed a limited parameter selection.

#### Landing page displayed link to Ticketing even without Ticketing license \[ID_24412\]

If a DMA was not licensed for Ticketing, it could occur that the DataMiner landing page nevertheless displayed a link to the Ticketing app.

#### DataMiner Cube - Visual Overview: Column configuration of ListView component not updated \[ID_24422\]

In some rare cases, it could occur that the column configuration of a *ListView* component was not saved or retrieved correctly.

#### DataMiner Cube: Editing an SNMPv3 element created prior to DataMiner 9.6.12 would cause the authentication type to be reset to the default type \[ID_24423\]

When you edited an SNMPv3 element that was created prior to DataMiner 9.6.12, in some cases, the authentication type would incorrectly be reset to the default type (i.e. SHA512).

#### Tables would show incorrect data after being updated \[ID_24425\]

When protocol buffer serialization was enabled, in some cases, tables would show incorrect data after being updated.

#### Dashboards: Problem with duplicate trend graphs in line chart component \[ID_24427\]

When, in a line chart component, you selected a second parameter, in some cases, each trend graph would incorrectly be displayed twice.

#### Service & Resource Management: ReservationInstances did incorrectly not have their status set to 'interrupted' \[ID_24434\]

In some rare cases, ReservationInstances that should have had their status set to “interrupted”, had their status set to an incorrect value.

#### Cassandra: Problem during upgrade would cause duplicate entries being added to the activealarms table \[ID_24436\]

In some cases, an error could occur when executing the *CassandraActiveAlarmsRootOnlyUpgrade* upgrade action. As a result of this error, duplicate entries would be added to the activealarms table.

#### Problem with SLNet when the connections among the different DataMiner Agents were being initiated \[ID_24437\]

In some rare cases, an error could occur in SLNet when the DataMiner Agents in the DataMiner System were initiating the connections among each other.

#### DataMiner landing page: Broken links to other pages \[ID_24439\]

On the DataMiner landing page, in some cases, the following links would be broken:

- Link to the <https://www.skyline.be> website (under “Skyline Communications”)
- Link to /licenses.asp
- Link to /systemdisplay.htm

#### DataMiner Cube: Problem when searching paged tables \[ID_24440\]

When you entered a string enclosed in double quotes ("") in the search box of a paged table, in some cases, an incorrect filter would be sent to the DataMiner Agent.

Also, it would not be possible to search for exception values or discreet values.

#### Problem with SLElement when updating the source data of a direct view table belonging to an element with debug log level 2 \[ID_24449\]

In some cases, an error could occur in SLElement when updating the source data of a direct view table belonging to an element of which the debug log level was set to 2.

#### DataMiner Cube - Surveyor: Views without sub-views would incorrectly have an expand arrow \[ID_24465\]

In the Surveyor, in some cases, views without sub-views would incorrectly have an expand arrow.

#### DataMiner Cube - Services: Some rows would be missing from tables partly included in a service \[ID_24471\]

In some cases, rows could be missing from tables that were partly included in a service.

#### Backup aborted if package could not be copied to network drive \[ID_24482\]

If a DataMiner backup package could not be copied to a network drive, it could occur that the backup was aborted. The new backup package on the DMA would still be marked as a temporary package, which was deleted when the next backup started.

#### DataMiner Cube - Data Display: Memory leak after sorting and/or filtering tables \[ID_24492\]

In some cases, DataMiner Cube could leak memory after sorting and/or filtering tables displayed on DATA pages.

#### Dashboards app: Element tree of a multiple-parameter feed was sorted incorrectly \[ID_24495\]

In some cases, the element tree of a multiple-parameter feed would not be sorted correctly. From now on, this tree will be sorted correctly, even when multiple filters are applied.

#### DataMiner Cube: Miscellaneous Alarm Console issues \[ID_24508\]

When a sliding window tab in the Alarm Console included cleared alarms, it could occur that the severity duration for these alarms was not indicated correctly. In addition, when you opened the alarm card of a cleared alarm, it could occur that no severity duration was shown for this alarm. Finally, when you opened the alarm card for an alarm that was not the top alarm in an alarm tree, only that alarm was shown on the card. Now the entire alarm tree will be shown in that case.

#### Dashboards app: Problem with unintentional move operations in Chrome \[ID_24525\]

When working with the Dashboards app in Chrome, in some cases, a mouse click could unintentionally cause a dashboard component to be moved to another location.

#### Dashboards app: Parameters in the URL would not correctly be loaded in the multiple parameter feed \[ID_24536\]

When you opened a dashboard with a multiple parameter feed using a URL that contained the parameters to be loaded in that feed, in some cases, the parameters in the URL would not correctly be loaded into the multiple parameter feed.

#### HTML5 apps: Selection box values containing backslash characters displayed incorrectly in interactive Automation scripts \[ID_24541\]

When an interactive Automation script was run from within an HTML5 app, in some cases, selection box values containing “\\” characters could be displayed incorrectly.

#### Failover: Problem with Indexing database after a Failover switch \[ID_23945\]\[ID_24562\]

When an Indexing database was installed on a pair of DataMiner Agents in a Failover setup, in some cases, the Indexing database could no longer be reached after a Failover switch.

#### Problem when opening an HTML5 app \[ID_24565\]

When you opened an HTML5 app (e.g. Monitoring & Control, Dashboards, etc.), in some cases, the app would not load due to a missing internal component.

#### Service & Resource Management: Problem during Resource Manager initializing \[ID_24604\]

In some cases, the Resource Manager module could fail to initialize when protocol buffer serialization was enabled.

#### Service & Resource Management: Problem when retrieving a ReservationInstance immediately after a property update \[ID_24622\]

When a ReservationInstance was retrieved immediately after its properties had been updated, in some cases, the properties of the retrieved ReservationInstance would incorrectly still have their old values.

#### DataMiner Cube - Alarm console: Dragging an element to the Alarm Console incorrectly showed all alarms on the DataMiner Agent \[ID_24655\]

When you dragged an element onto the Alarm Console, in some cases, the alarm tab would incorrectly list all alarms on the DataMiner Agent instead of only the alarms of the element in question.

## Changes in DataMiner 10.0.2 CU1

### CU1 fixes

#### Problem when logging in to a DataMiner mobile app \[ID_24333\]

In some cases, the following exception could be thrown when logging in to any DataMiner mobile app:

```txt
Failed to setup a connection with the DataMiner Agent: Method not found:'SLLoggerUtil.ILogger SLLoggerUtil.LoggerUtil.GetLogger(SLLoggerUtil.LoggerCategoryUtil.ILoggerCategory)'.
```

#### Problem with SLProtocol when calling 'NT_LOAD_TABLE' \[ID_24780\]

In some cases, an error could occur in SLProtocol when calling the NotifyProtocol method “NT_LOAD_TABLE”.

#### DataMiner Cube failed to start \[ID_24796\]

On a clean Windows system, in some cases, DataMiner Cube would fail to start, especially when using a new user account.

#### Problem when trying to back up an Elastic database using its public IP address \[ID_24810\]

When you tried to back up an Elastic database (which is used by the DataMiner Indexing engine) using its public IP address, in some cases, a message would incorrectly appear, saying that no Elastic database could be found on the machine in question.

## Changes in DataMiner 10.0.2 CU2

### CU2 enhancements

#### Service & Resource Management: Enhanced performance when deleting service definitions \[ID_24860\]

Due to a number of enhancements, overall performance has increased when deleting service definitions, especially on systems with a large number of booking instances.

### CU2 fixes

#### DataMiner Cube - Services app: Service definition not loaded correctly when Services app is opened \[ID_24735\]

When you opened the Services app, it could occur that one of the service definitions was not loaded correctly. When you selected it, it was tagged as “\[modified\]” and its connection lines were lost.

#### DataMiner - Services app: Problem when saving service definitions \[ID_24849\]

In some cases, an error could occur when you tried to save a service definition.

#### Migrating booking data to DataMiner Indexing failed when service definition properties had null values \[ID_24880\]

If service definition properties had null values, it could occur that migrating booking data to DataMiner Indexing failed.

#### Failover - Service & Resource management: Problem when migrating booking data to DataMiner Indexing after performing a Failover switch twice \[ID_24883\]

When you started a booking data migration to DataMiner Indexing on a Failover Agent that had previously been switched twice, in some cases, the migration operation would never get marked as completed.
