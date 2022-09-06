---
uid: General_Main_Release_10.2.0_fixes
---

# General Main Release 10.2.0 - Fixes

#### Problem when deleting an element that had data stored in Elasticsearch \[ID_27663\]

When you deleted an element that had data stored in an Elasticsearch database (e.g. a logger table), in some cases, this would cause errors in other elements that shared data with the element you deleted.

#### Incorrect error message when uploading a protocol with a minimum required version \[ID_27868\]

When you uploaded a protocol of which the Protocol.Compliancies.MinimumRequiredVersion element contained a DataMiner version onto a DataMiner Agent with an older version, in some cases, DataMiner would either throw the incorrect error message “No license for the encrypted protocol found” or no error message at all.

#### Problem with \<SkipCommitLog> option in DB.xml \[ID_27969\]

If you want to optimize the writing speed to a Cassandra database, in the *DB.xml* file, you can specify the \<SkipCommitLog> option to skip the writing of the commit log. However, in some cases, this would no longer work.

#### DataMiner Cube desktop app: Assembly load errors \[ID_28059\]

Certain DLL files would cause assembly load errors to get added to the log file of the DataMiner Cube desktop app.

#### DataMiner Cube - Profiles app: Service profile instance selection box empty after editing profile instance \[ID_28084\]

When you changed both the profile definition and the service profile instance when editing a profile instance, after saving, the service profile instance selection box would be empty, although the data was saved correctly.

#### Dashboards app - Line chart component: Three value columns instead of one in CSV with exported real-time trend data \[ID_28090\]

When you exported real-time trend data to a CSV file, that file would incorrectly have three value columns (avg, min, max). From now on, when you export real-time trend data, the CSV file will only have one value column.

#### DataMiner Cube - Alarm Console: Problem when retrieving alarms that contain metadata \[ID_28118\]

In some cases, an exception could be thrown when retrieving alarms that contain metadata.

#### DataMiner Cube: Problem when connecting to a large system with alarm storm prevention enabled \[ID_28127\]

When, on a large DataMiner System, alarm storm prevention was enabled, in some cases, Cube could freeze when you tried to connect.

#### DataMiner Cube - Trending: Incorrect datetime value sent to the pattern matching engine \[ID_28166\]

In some cases, DataMiner Cube would sent an incorrect datetime value to the pattern matching engine.

#### Monitoring app: Incorrect card opened after clicking service in the list of services \[ID_28215\]

When, in the Monitoring app, you opened a view that contained services, clicked Below this view \> Services, and then clicked one of the listed services, in some cases, an incorrect card would be opened.

#### SLAnalytics: Problem at startup \[ID_28258\]

In some cases, an error could occur in SLAnalytics at startup.

#### Ticketing app: Date filters would incorrectly use dates in local time instead of UTC time \[ID_28267\]

In the Ticketing app, in some cases, the date filters would incorrectly use dates in local time instead of UTC time.

#### Jobs app: Clicking Time \> Now in the date picker would set the time in an incorrect time zone \[ID_28274\]

When you clicked *Time \> Now* in the date picker while creating a new job, in some cases, the time would incorrectly be set in the time zone of the server instead of that of the client.

Also, a number of other issues regarding time zone settings were fixed.

#### Dashboards app: Problem with indices selection of parameter feed component \[ID_28309\]

When a dashboard containing a parameter feed component was refreshed or when a report was generated based on such a dashboard, in some cases, it could occur that the selection of parameter indices was no longer correct

#### Dashboards app: Folder content not scrollable \[ID_28321\]

In the Dashboards app, in some cases, it would not be possible to scroll through the contents of a dashboard folder.

#### DELT export packages would incorrectly not contain logger table data stored in Elasticsearch \[ID_28413\]

When you exported an element containing a logger table that saved its data in an Elasticsearch database, in some cases, the export package would not contain the data that was saved in the Elasticsearch database.

#### SLAutomation would incorrectly be initialized twice \[ID_28416\]

In some cases, SLAutomation would incorrectly be initialized twice.

#### Dashboards app: Error when deleting components \[ID_28426\]

When a dashboard component was deleted, in some cases, the following error could occur:

```txt
Cannot read property 'Data' of undefined'.
```

#### Problem during DataMiner startup when all nodes of an Elasticsearch database were down \[ID_28443\]

When an Elasticsearch database was configured in the *DB.xml* file, in some cases, an error could occur during DataMiner startup when all node of that database were down.

#### DataMiner Cube - Failover: Default SLAnalytics settings would incorrectly always be used \[ID_28471\]

In a Failover system, SLAnalytics would incorrectly always use the default DataMiner Cube SLAnalytics settings. Any updates to those settings would be disregarded.

#### Dashboards app - Line chart component: Parameter header not displayed when only one parameter was selected \[ID_28486\]

When, in a line chart component, only one parameter was selected, in some cases, the parameter header would not be displayed.

#### Dashboards app - Line chart component: Problem with 'Expand legend initially' option \[ID_28487\]

When you refreshed a line chart component that had the “Expand legend initially” option selected, in some cases, the legend would incorrectly not be expanded.

#### Dashboards app: Components not displayed when embedded \[ID_28492\]

In some cases, dashboards components would not be displayed when embedded in e.g. Visual Overview.

#### Dashboards app: Dummy EPM columns displayed \[ID_28495\]

In an EPM Manager driver, it is possible to mark certain columns as dummy columns. Up to now, the Dashboards app would incorrectly display those dummy columns.

#### Dashboards app: Problem when trying to select a folder after manually removing it from the Location box of the Create dashboard window \[ID_28533\]

When, in the *Create dashboard* window, you selected a folder and then removed it manually from the *Location* box, in some cases, it would no longer be possible to select the same folder in the folder tree.

#### Dashboards app - GQI: Problem when retrieving data for a table parameter without using a column filter \[ID_28534\]

In some cases, an exception could be thrown when using an inter-element query to retrieve data for a table parameter without using a column filter.

#### Dashboards app: Duplicated dashboard used default theme instead of original theme \[ID_28552\]

When you duplicated a dashboard, the newly created dashboard would incorrectly use the default dashboard theme instead of the theme used by the original dashboard.

#### Dashboards app: Problem when sharing a dashboard located in a folder \[ID_28610\]

When you wanted to share a dashboard using the Live Sharing Service, in some cases, a parsing error could occur when that dashboard was located in a dashboard folder.

#### Dashboards app: Image representing a moved dashboard could not be found \[ID_28661\]

When you moved a dashboard from one folder to another, and then selected the destination folder, in some cases, the image representing the dashboard you moved could not be found.

#### Empty cluster tag in NATS configuration file \[ID_28663\]

In some cases, the NATS configuration file would incorrectly have an empty cluster tag.

#### Automation: Problem when ejecting of pre-compiled library \[ID_28665\]

In some cases, an exception could be thrown when a library DLL was ejected.

#### Problem when retrieving trend data from a column of a view table based on another view table \[ID_28677\]

In some cases, it was not possible to retrieve trend data from columns of a view table that was based on another view table.

When trend data has to be retrieved from a column of a view table that is based on another view table, another column in that same view table has to have the VIEWTABLEKEY option defined.

#### Uninstalling DataMiner Cube did not remove EXE file \[ID_28704\]

When you uninstalled DataMiner Cube, in some cases, the EXE file would not be removed from the %localappdata%\\Skyline\\DataMiner\\DataMinerCube folder.

#### Dashboards app: Component configuration changes not saved \[ID_28720\]

When, in the Dashboards app, you had made a change to the configuration of a component, in some cases, that change would not get saved.

#### DataMiner Cube desktop app: Problem when started with the '/Hostname=xyz' command line argument \[ID_28774\]

When you started the DataMiner Cube desktop app with the “/Hostname=xyz” command line argument, in some cases, an error could occur when its configuration file was empty or could not be found.

#### Dashboards app: Feeds section of edit pane’s Data tab incorrectly listed feeds using the component names \[ID_28779\]

When you added a feed component to a dashboard (e.g. a drop-down feed) and gave it a title, in the Feeds section of the edit pane’s Data tab, the feed would incorrectly have the name you gave to the component instead of the actual name of the feed.

#### DataMiner Cube: Desktop app could no longer be installed from the landing page \[ID_28802\]

In some cases, it was no longer possible to install the DataMiner Cube desktop app from the DataMiner landing page.

#### Dashboards app: Problem when all data was removed from a table column parameter that acted as data source for a Gauge, Ring or State component \[ID_28806\]

When a Gauge, Ring or State component had a table column parameter as data source, in some cases, an error could be thrown when, in DataMiner Cube, all data was removed from that table.

#### Dashboards app - Line chart component: Problem with the 'Minimum visible gap size' setting \[ID_28810\]

When, while configuring a line chart component, you opened the selection box containing the values of the *Minimum visible gap size* setting, in some cases, that selection box would not be displayed correctly.

#### Dashboards app: Sorting issues \[ID_28850\]

In the Dashboards app, in some cases, table columns would be naturally sorted by display value instead of raw value, resulting in an incorrect order when using dynamic units or a numeric format with spaces.

Also, in the GQI query builder, in some cases, the default columns would be sorted incorrectly when using the “Select columns” option.

#### Dashboards app: Problem when embedding a GQI dashboard component \[ID_28874\]

When an individual GQI dashboard component was embedded into Visual Overview or a web page, in some cases, the URL of that component would not contain all necessary information to run a GQI query.

#### Problem when saving a job or a DomInstance with a section that referred to a non-existing SectionDefinition \[ID_28908\]

When saving a job or a DomInstance containing a section that referred to a non-existing SectionDefinition, up to now, a NullReferenceException would be thrown.

From now on, an error will be stored in tracedata instead:

- an error of type JobError with reason SectionUsedInJobLinksToNonExistingSectionDefinition, or
- an error of type DomInstanceError with reason SectionUsedInDomInstanceLinksToNonExistingSectionDefinition.

#### DataMiner Cube: Problem when previewing a dashboard containing components running GQI queries \[ID_28939\]

When, in DataMiner Cube, you previewed a dashboard that contained components running GQI queries, in some cases, an error could be thrown.

#### DataMiner Cube: Configuration file of start window corrupted when the start window was closed when the file was being updated \[ID_28949\]

When the DataMiner Cube start window was closed while its configuration file was being updated, in some cases, that configuration file could get corrupt.

> [!NOTE]
> In the configuration file of the DataMiner Cube start window, the minimum log level can now be configured.
> Possible log levels: 0 = Verbose, 1 = Debug, 2 = Information, 3 = Warning, 4 = Error, 5 = Fatal

#### SLAnalytics - Automatic incident tracking: Incorrect error messages when the timer switched to the next hour while there are active alarms of type 'Property changed' \[ID_28968\]

When there were active alarms of type “Property changed” when the timer switched to the next hour, in some cases, automatic incident tracking would generate incorrect error messages.

#### DataMiner Cube: Problem when opening start window from the system tray \[ID_29054\]

In some rare cases, an exception could be thrown when opening the DataMiner Cube start window from the Windows system tray.

#### DataMiner Cube start window: Configuration file cleared \[ID_29080\]

When the DataMiner Cube start window was closed, in some rare cases, the configuration file of that start window would incorrectly be cleared.

#### Description of proactive cap detection setting in System Center corrected \[ID_29096\]

A typo has been corrected in the description for the proactive cap detection settings in System Center.

#### DataMiner Cube: New DMS not saved in start window configuration \[ID_29151\]

When the Cube start window was not running in the system tray, and you added a DMS and then immediately connected to it, it could occur that the new DMS was not saved in the start window configuration.

#### SLAnalytics: Problem when calculating a trend prediction for a parameter with missing trend data \[ID_29163\]

In some cases, an error could occur in the SLAnalytics process when a trend prediction was calculated for a parameter with missing trend data.

#### SRM module not starting after Failover switch \[ID_29169\]

In some rare cases, after a Failover switch, it could occur that an SRM module could not be started.

#### Dashboards app: Multiple pop-up windows displayed when Automation script could not be opened \[ID_29218\]

When the Dashboards app tried to open an Automation script that had been renamed or removed in DataMiner Cube, in some cases, a series of pop-up windows would be displayed. From now on, when the Dashboards app cannot open an Automation script, a single pop-up window will be displayed.

#### Suggestion indices not deleted when an Elasticsearch logger table without custom naming was deleted \[ID_29223\]

When an Elasticsearch logger table without custom naming was deleted, the suggestion indices would incorrectly not get deleted.

#### Dashboards app - Pivot table component: Problem when adding indices \[ID_29253\]

When indices were added to a pivot table component, in some cases, the component would not get updated correctly and a spinner icon would appear in its Settings tab.

#### Failover: Exception thrown because of issue caused by PowerShell \[ID_29263\]

In Failover systems, in some cases, a PowerShell problem could cause an exception to be thrown.

#### Problem with SLNet when correlation details were requested for alarm groups \[ID_29265\]

In some cases, an error could occur in SLNet when correlation details were requested for alarm groups.

#### Cassandra: Problem creating the timetrace table when upgrading from an older DataMiner version \[ID_29319\]

In some cases, an error could occur when the timetrace table was created when upgrading from an older DataMiner version (e.g from version 10.0.0 to 10.1.4).

#### Interactive Automation scripts: 'continue script' action triggered after the script had already been detached \[ID_29357\]

In some rare cases, a “continue script” action could incorrectly be triggered after the script in question had already been detached.

#### Jobs app: Fields in newly created copy of a section definition would have an incorrect field type \[ID_29387\]

When you copied a section definition from one job domain to another, in some cases, fields in the newly created section definition would have an incorrect field type.

#### Service & Resource Management: VirtualFunctionResource could not be bound with the same index as another VirtualFunctionResource \[ID_29403\]

In some cases, it was not possible to bind a VirtualFunctionResource when another VirtualFunctionResource was already bound to a different entrypoint table with the same index.

#### SLAnalytics: Problem with automatic incident tracking when a parent of a particular view could not be found \[ID_29419\]

In some cases, an error could occur during automatic incident tracking when a parent of a particular view could not be found.

#### Dashboards app - GQI: Problem when rebuilding a query \[ID_29468\]

In some cases, a query would not get rebuilt correctly after being edited, especially when it contained nodes that were linked to feeds.

#### Dashboards app - Time range feed: Value passed along incorrectly when 'Use quick picks' option was selected \[ID_29471\]

When the “Use quick picks” option was selected, a time range feed would pass along the selected value incorrectly.

Also, custom quick picks would disappear when reloading the dashboard, and when the “Allow refresh” option was selected, the feed would not correctly update the linked trend graph when the refresh counter was reset.

#### Dashboards app - GQI: Inconsistent column order when 'select' or 'get parameters' nodes were linked to a feed \[ID_29479\]

When the “Select” or “Get parameters for element where” nodes of a query were linked to a feed, in some cases, the order of the selected parameter columns would not be consistent with the feed selection.

From now on, the default columns will always come first, followed by the items supplied by the feed.

#### Serial communication: Problem when multiple potential responses were defined in a serial pair \[ID_29496\]

When multiple possible responses were defined in a serial pair, the responses after the first response potentially would not match the received data when header and trailer parameters were not identical.

In the following example, a pair has three responses defined (100, 101, and 102), of which one is expected to match the received data. When the headers and trailers of responses 101 and 102 were identical to those of response 100, the data was matched as expected. However, when the header or trailer was not identical, then a match could be missed for response 101 and 102.

```xml
<Pair id="100">
  <Name>Pair 100</Name>
  <Content>
    <Command>100</Command>
    <Response>100</Response>
    <Response>101</Response>
    <Response>102</Response>
  </Content>
</Pair>
```

#### Cassandra: Incorrect health status \[ID_29502\]

In some cases, the Cassandra health status was incorrect.

#### Web apps: Numeric values in text boxes would be clipped \[ID_29506\]

In some cases, numeric values in text boxes would be clipped.

#### Dashboards app: Strings containing decimal values would be sorted incorrectly \[ID_29512\]

In some cases, strings containing decimal values would be sorted incorrectly.

#### Monitoring app & Dashboards app: Problem with alarm severity counters \[ID_29561\]

In both the Monitoring app and the Dashboards app, after a number of alarm updates had been processed, the alarm severity counters would indicate an incorrect number of alarms.

#### DataMiner Cube - Trending: Problem when exporting average trend data of a trend graph with multiple lines \[ID_29579\]

When you tried to export the average trend data of a trend graph with multiple lines, in some cases, the export operation would fail. The “retrieving data” notice would not disappear and the export file would not get created.

#### Dashboards app - GQI: Filters unnecessarily sent along with SLNet calls \[ID_29583\]

When a GQI query contains a filter to be applied to e.g. a parameter table, then that filter will be sent along with the SLNet call to allow SLElement to apply the filter for performance reasons. However, in some cases, a filter would also be sent along with the SLNet call when this was not applicable (e.g. when there was a join or aggregation operation between the filter and the data source).

#### Elasticsearch: Problem with postfilters \[ID_29602\]

When a client requested data from an Elasticsearch database with a filter, in some cases, an incorrect result set would be returned because the postfilter would incorrectly apply a filter in local time on a field formatted in UTC time. This issue has now been resolved. Also, from now on, postfilters will only be applied when necessary.

#### GetActiveHysteresisInfoResponseMessage contained entries for elements without alarm data \[ID_29604\]

Up to now, when a GetActiveHysteresisInfoMessage request was sent, the GetActiveHysteresisInfoResponseMessage would contain an entry for every element in the DataMiner Agent, whether it had alarm data or not. From now on, elements without active hysteresis data will be removed from the response.

> [!NOTE]
> GetActiveHysteresisInfoMessage now also contains a constructor that accepts a DataMiner ID. That way, an ID will no longer have to be provided after constructing the object.

#### Dashboards app: Group component not showing all included components \[ID_29630\]

In some cases, a Group component would incorrectly not show all included components. The components that were not shown had no height defined or an error had prevented the styling from being applied correctly.

#### Monitoring app & Dashboards app no longer receiving alarm page updates \[ID_29635\]

In some cases, the Monitoring app and the Dashboards app would no longer receive any alarm page updates.

#### SLAnalytics - Alarm focus: Alarms treated as unexpected when baseline values in alarm template were updated automatically because of use of smart baselines \[ID_29670\]

When a user makes a change to an alarm template, SLAnalytics will treat all alarms of the parameters for which a change was implemented in the alarm template as unexpected. However, in some cases, it would incorrectly act in a similar way when, in case of smart baselines, baseline values were updated automatically.

Also, in some cases, no action would be taken when, in case of smart baselines, alarm template settings of table parameters were changed.

#### Problem when deleting a service by name \[ID_29691\]

When a SetDataMinerInfoMessage was used to delete a service using the service name, in some cases, an exception could be thrown.

#### Interactive Automation scripts: Problem when entering double-digit numbers in input controls \[ID_29736\]

In some cases, because of a problem with the WantsOnChange functionality, it would not be possible to enter a double-digit number (e.g. a number of minutes) in an input control. The interactive Automation script would incorrectly already continue after you entered the first digit.

#### Problem when an interactive Automaton script was detached on closure \[ID_29815\]

In some cases, when an interactive Automation script detached on closure, an exception could be thrown in SLAutomation. From now on, interactive Automation scripts will only detach when they are aborted by a user either closing the popup window or clicking the Abort button.

#### Service & Resource Management: Start of bookings delayed when multiple bookings started at the same time \[ID_29880\]

When multiple bookings started at the same time, and each of those bookings required function DVE elements to be enabled, in some cases, the start of the bookings would be delayed.

#### Dashboards - Table component: Problem with scroll bars when using Firefox \[ID_29892\]

When Mozilla Firefox was used, the table component would show scroll bars even in situations where it was not necessary.

Also, in some cases, columns would not resize correctly.

#### Failover: Cassandra nodes would not be removed from the Cassandra cluster when a Failover configuration was ended \[ID_29894\]

When a Failover configuration was ended, in some cases, the Cassandra nodes would not be removed from the Cassandra cluster. From now on, the Cassandra nodes on the main and the backup agent will each be properly removed from the Cassandra cluster and become single nodes.

> [!NOTE]
> After ending a Failover configuration, it is recommended to check the nodetool status on both nodes to make sure the nodes no longer form a cluster.

#### Dashboards app - GQI: Raw values displayed when grouping row after performing an aggregation \[ID_29904\]

When rows were grouped after an aggregation was performed, raw values would incorrectly be displayed instead of display values.

#### Dashboards app - GQI: Problem when applying a filter to a query that used a 'Get parameters for element where' data source \[ID_29907\]

When a filter was applied to a query that used a “Get parameters for element where” data source, in some cases, the filter would incorrectly only get applied to the rows of one element. The rows of the other elements would all be returned, whether they matched the filter or not.

#### Dashboards app - GQI: Edit pane unresponsive when importing query from one dashboard into another \[ID_29922\]

When you imported a query from one dashboard into another dashboard, in some cases, the edit pane could become unresponsive due to a parsing error.

#### DataMiner Cube - Resources app: Contributing resources not visualized correctly \[ID_30031\]

In the Resources app, up to now, contributing resources were not visualized correctly.

#### Dashboards app: Selection not set in parameter feed \[ID_30092\]

In a parameter feed, in some rare cases, it could occur that the selection was not set.

#### DataMiner Cube - Alarm Console: Problem when using the history slider \[ID_30097\]

On systems with a MySQL database, in some cases, a System.AggregateException could be thrown when the history slider was used in DataMiner Cube.

#### DataMiner Cube desktop app: No DataMiner Systems shown in start window \[ID_30100\]

When the DataMiner Cube desktop app was started, in some cases, the start window would not show any DataMiner Systems.

#### Resources and Services modules also loaded functions that were not active \[ID_30107\]

In the Resources and Services modules, it could occur that functions were loaded even though they were not marked as active, which could cause several functions with the same GUID to be loaded.

#### DataMiner Cube: Missing alarms in Active alarms tab \[ID_30126\]

In some rare cases, after connecting to a busy system, it could occur that alarms were missing in the Active alarms tab in the Alarm Console.

#### DataMiner Cube - EPM: Problem opening an EPM card from an alarm when the 'System Name' alarm property contained a trailing space \[ID_30169\]

When the “System Name” property of an alarm contained a trailing space, in some cases, it would not be possible to open the EPM card from the alarm in question.

#### SLAnalytics: Problem when the connection with SLNet was lost \[ID_30238\]

In some rare cases, an error could occur in SLAnalytics when the connection with SLNet was lost.

#### Dashboards app: 'Loading' bar stayed visible longer than necessary \[ID_30343\]

In some cases, the “Loading” bar, which is visible while the Dashboards app is busy loading all components, would stay visible longer than necessary. From now on, it will disappear immediately after all components have been loaded.

#### Not possible to log in to web app using SAML \[ID_30469\]

In some cases, it could occur that it was not possible to log in to the Dashboards or Monitoring app using SAML.

#### Dashboards app - State timeline: Unclear error message when no parameter index had been specified yet \[ID_30485\]

When you dragged a table parameter onto a state timeline component, up to now, the following error would be visible until you specified a table index:

```txt
Failed getting the timeline data from the DMA agent: Empty server response
```

This error will now be replaced by a message that clearly indicates that the table index is still missing and should be specified.

#### Dashboards app: Query with filter on value discrete parameter not working correctly \[ID_30486\]

If a query in a dashboard was filtered on the value of a discrete parameter, it could occur that the filter was not executed correctly. This happened because the filter used the display value of the parameter instead of the actual value.

#### Dashboards app - Tree feed & Parameter feed: Problem with 'Selected only' option \[ID_30510\]

When you open a dashboard containing a tree feed or a parameter feed with a preset selection in the URL, the “Selected only” option of those feeds is selected by default.

Up to now, when you cleared that option in one of those feeds and then selected other items in the feed, the “Selected only” option would incorrectly be selected again.

#### Profile parameter with mediation snippet incorrectly shown as changed \[ID_30530\]

When a profile parameter with a mediation snippet was loaded initially, it would incorrectly be shown as having unsaved changes.

#### Dashboards app - Parameter feed: Indices of selected items not all selected \[ID_30532\]

When you opened a dashboard containing a parameter feed with a preset selection, in some cases, the indices of the selected items would not all be selected.

#### Profiles module: Discrete capability parameter showed actual values instead of display values \[ID_30533\]

In the Profiles module, if a capability parameter of type Discrete was configured in a profile instance, the drop-down box for this parameter showed the actual discrete values instead of the display values.

#### Insufficient information in exception message in case of invalid characters in dictionary keys \[ID_30602\]

When an exception was thrown because invalid characters were used in dictionary keys, it could occur that the message did not include all invalid characters, but only the string array type name.

#### Automation: Problems with datetime filters in scripts \[ID_30611\]

Several issues have been resolved in case data is retrieved using a datetime filter in a script:

- DataMiner will now translate between UTC and local time when necessary. Previously, data objects could be in UTC time while the filter used local time.
- If *DateTime.Kind* is unspecified, now no action is performed.

#### Problem with SLNet because of unhandled exception \[ID_30626\]

In some rare cases, an unhandled exception could cause a problem in the SLNet process.

#### Service & Resource Management: Property updates overwritten by status updates \[ID_30642\]

When the properties of a ReservationInstance were updated in an asynchronous event script while the end actions were running, in some cases, the end actions could overwrite the updated properties, causing the event script’s property update to fail and throw a “PropertiesAlreadyModified” exception.

#### DataMiner Cube - Resources app: Not possible to link virtual function resources to elements of which the protocol version was set to 'production' \[ID_30655\]

In the Resources app, it is possible to create virtual function resources that are linked to compatible elements. Up to now, in some cases, it was not possible to link virtual function resources to elements of which the protocol version was set to “production”.

#### Visual Overview: Property value not shown in shape text \[ID_30696\]

If an element shape was configured with property shape data and contained "\*" as its shape text, it could occur that the property value was not shown even though it was available.

#### Dashboards app: All pages of query initially loaded in table component \[ID_30697\]

If a table component showed a query with multiple pages of data, it could occur that all pages were initially fetched instead of only the first page.

#### Dashboards app: State component showed GQI query ID instead of display name \[ID_30702\]

The State component incorrectly showed the ID of a GQI query instead of its display name.

From now on, when you select the *Display query name* option in the *Layout* tab of the State component, the component will show the display name of the query.

#### Resource Manager would fail to initialize during a DataMiner startup \[ID_30708\]

During a DataMiner startup, in some cases, the Resource Manager would fail to initialize.

#### DataMiner Cube - Bookings app: check added of elastic support when retrieving virtual functions \[ID_30814\]

When, in DataMiner Cube, you opened the Bookings app while being connected to a DataMiner Agent without an Elasticsearch database, in some cases, an error could occur when trying to retrieve virtual function definitions. From now on, Cube will only retrieve virtual function definitions when it is connected to a DataMiner Agent with an Elasticsearch database.

#### DataMiner Cube - Visual Overview: Problems when updating Children shapes \[ID_30924\]

A number of problems with Children shape updates have been fixed:

- When a Children shape was sorted on alarm severity, in some cases, updates to the alarm level of the shape would no longer be processed and the sorting would not be updated.
- When a shape no longer matched a filter, in some cases, it would not be removed from the list of generated shapes.
- In some cases, the (configurable) maximum amount of child shapes would no longer be applied when updates were received.

#### DataMinerCube.exe not shut down when Cube desktop app was closed \[ID_30968\] \[ID_31036\]

When you opened a Cube desktop app without using the start window and connected it to a DataMiner System with an Elasticsearch database, in some cases, the DataMinerCube.exe process would not shut down when you closed the Cube app.

#### DataMiner Cube - Trending: Problem when exporting a trend graph to a CSV file \[ID_30987\]

In some cases, an exception could be thrown when you tried to export a trend graph to a CSV file.

#### Memory usage of SLAnalytics temporary increasing because of alarm focus events not getting cleared from the cache \[ID_31025\]

In some rare cases, overall memory usage of the SLAnalytics process would temporarily increase because alarm focus events did not get cleared from the cache.

#### Enabled soft-launch options could incorrectly be disabled \[ID_31033\]

When no *SoftLaunchOptions.xml* file was found in the *C:\\Skyline DataMiner\\* root directory, soft-launch options that were enabled by default (e.g. the new average trending feature) would incorrectly be disabled.

#### Interactive Automation scripts: Problem with file upload components \[ID_31064\]

After multiple updates had occurred in an interactive Automation script, in some cases, a file upload component could end up in an invalid state and lose all information about the uploaded files.

#### Security: Azure AD access tokens not refreshed \[ID_31067\]

In some cases, Azure AD access tokens would incorrectly not get refreshed.

#### DataMiner Cube: Problem when adding/deleting DataMiner Agent to/from a DMS \[ID_31078\]

In the *Agents* section of *System Center*, up to now, users with *Agents \> Add* permission but without *Agents \> Add DMA to cluster* permission seemed to able to add a DMA to a DMS. However, after *System Center* had been refreshed, the added DMA would not be listed. Also, users with *Agents \> Delete* permission but without *Agents \> Delete DMA to cluster* permission seemed to able to delete a DMA to a DMS. However, after *System Center* had been refreshed, the deleted DMA would still be listed.

From now on, users with only *Agents \> Add* permission or *Agents \> Delete* permission will be able to correctly add or delete DMAs from a DMS.

#### Dashboards app - GQI: Problem when migrating queries that contain joins \[ID_31080\]

Each time the GQI version gets upgraded, all GQI queries are migrated to the new version. In some cases, the migration of a GQI query could fail when that query contained joins.

#### Web apps: Selecting the selected value in a selection box could clear that value \[ID_31089\]

When, in a web app, you opened a selection box and selected the value that was selected, in some cases, that value would incorrectly be cleared.

#### Cassandra cluster: No SLA table created on startup or on creation of an SLA \[ID_31092\]

On a Cassandra cluster, in some cases, no SLA table would be created on startup or on creation of an SLA.

#### Reporter: Problem when retrieving an alarm history on a system with a Cassandra cluster \[ID_31096\]

When, on a system with a Cassandra cluster, you used Reporter to retrieve the alarm history of an element, in some cases, the query would not return any results.

#### Dashboards app: GQI queries in PDF reports sent via an interactive Automation script not migrated correctly \[ID_31127\]

When a PDF report of a dashboard containing GQI queries was generated before being sent by email via an interactive Automation script, in some cases, the GQI queries would not be migrated correctly.

#### Web Services API v0: Exception when CreateElement request did not contain Ports array \[ID_31145\]

In some cases, the CreateElement method could throw an exception when the request did not contain a Ports array. From now on, when the request does not contain a Ports array, an error message will be returned.

#### Dashboards app: Duplicate options in GQI queries \[ID_31206\]

In some cases, options added to GQI queries would incorrectly be added twice.

#### DataMiner Agent could get stuck in offload mode after the database had been unreachable \[ID_31245\]

In some cases, a DataMiner Agent could get stuck in offload mode after the database had been unreachable for a period of time.

#### Users without access to elements were no longer able to retrieve the list of views in which a service is located \[ID_31258\]

In some cases, it would no longer be possible for users without access to elements to retrieve the list of views in which a service is located using, for example, the Web Services API.

#### Interactive Automation scripts: Initial state of non-recursive tree view incorrect \[ID_31302\]

The initial checked/unchecked state of a non-recursive tree item would be incorrect when

- the state of the item in question was “checked”,
- there was no recursive checking,
- the item had children, and
- none of those children were checked.

#### Interactive Automation scripts: Dialog items inherited dimensions of dialog item shown earlier \[ID_31311\]

When an interactive Automation script was launched from a web app, in some cases, a dialog item could incorrectly inherit the dimensions of a dialog item shown earlier.

#### DataMiner Cube - System Center: Server setting updates not saved immediately \[ID_31339\]

When you updated server settings in System Center (e.g. the default browser plug-in), up to now, it could take up to 10 seconds for the changes to be applied. Also, when Cube was closed in the meantime, those latest changes would be lost. From now on, all changes made to system settings will be applied immediately.

#### DataMiner Cube - Alarm Console: Problem after turning on the alarm focus feature \[ID_31343\]

When the alarm focus feature was used for the first time, in some cases, all alarm events would incorrectly be marked with an icon in the *Focus* column.

#### Dashboards app - GQI: Problem when enabling the 'Use feed' option of a select node \[ID_31349\]

When, in a GQI query, the “Use feed” option of a select node had been enabled, in some cases, an error could occur when selecting the default columns.

#### Problem when writing to the database after restarting an SLAnalytics feature or changing a setting of an SLAnalytics feature \[ID_31371\]

When an SLAnalytics feature had been restarted or when a setting of such a feature had been changed, in some cases, an exception could be thrown when data was written to the database.

#### DataMiner Cube - Alarm Console: 'Saved filters' option missing on systems with MySQL database \[ID_31375\]

When, on a system with a MySQL database, you selected *Apply filter...* in a newly created alarm tab, in some cases, the *Saved filters* options could be missing.

#### Dashboards app: Problem when generating a PDF report of a dashboard that contained empty components \[ID_31388\]

When a PDF report was generated for a dashboard that contained empty components, in some rare cases, the PDF generation process could get stuck.

#### Dashboards app: Problem when trying to import a dashboard \[ID_31389\]

When you tried to import a dashboard, in some cases, the system would incorrectly look for the dashboard to be imported in the “Dashboards” folder instead of the “ImportDashboards” folder.

Also, when you tried to import a dashboard on a DataMiner Agent that did not have an “ImportDashboards” folder, the Dashboards app would incorrectly look for the dashboard to be imported in the “Dashboards” folder instead. From now on, when the “ImportDashboards” folder does not exist, a message will appear, saying that no dashboards are available for import.

#### DataMiner Cube - Visual Overview: Session variable 'IDOfSelection' of ListView updated incorrectly \[ID_31395\]

When you embed a list view component in a visual overview and set the Source field to “Bookings”, then the session variable IDOfSelection will contain the ID of the currently selected booking. In some cases, this session variable would be updated incorrectly, especially when you selected a booking in the future after having selected a booking in the past.

#### Dashboards app: Parameter feed could incorrectly continue to feed data when the parameter in question was no longer selected \[ID_31403\]

In some cases, a parameter feed could incorrectly continue to feed data even though the parameter in question was no longer selected.

#### Dashboards Sharing: Incorrect login screen when the shared dashboard you were viewing was unshared \[ID_31503\]

When a shared dashboard was unshared while you were viewing it, up to now, you would incorrectly be redirected to the login screen of the Dashboards app. From now on, you will be redirected to the DataMiner Cloud login screen (i.e. <https://shares.dataminer.services>) instead.

#### Dashboards app: Value for EPM components with only one chain filter not displayed in PDF report \[ID_31563\]

In a PDF report, in some cases, EPM components that only had one active chain filter would incorrectly not display their selected value.

#### Failover: Status of newly installed Failover system not set to 'No problems detected' \[ID_31604\]

In some cases, the status of a newly installed Failover system would incorrectly not be set to “No problems detected” (i.e. green LED).

#### Automation: Possible to add multiple files in file selector of interactive script despite AllowMultipleFiles being set to false \[ID_31614\]

When the *UIBlockDefinition* property *AllowMultipleFiles* is set to false in an interactive Automation script, users should not be able to add multiple files in a file selector. However, it was still possible to get multiple files into the selector by selecting several files at once and dragging them into it. This will now no longer be allowed.

#### Incorrect number of Elasticsearch backups kept \[ID_31701\]

Elasticsearch would incorrectly keep one backup more than was specified in the “number of backups to keep” setting.

For example, when you had specified that 4 backups had to be kept, Elasticsearch would incorrectly keep 5 backups instead.

#### DataMiner Cube - Visual Overview: Connectors without matching DCF connection not hidden \[ID_31727\]

When, on a visual overview, the “ConnectivityLines\|HighlightPath” page option had connectors replace DCF connections, in some cases, connectors without a matching DCF connection would incorrectly not be hidden.

Also, in some cases, hidden shapes linked to EPM objects would incorrectly be visible.

#### DataMiner Cube - Trending: Problem when opening a histogram \[ID_31731\]

In some cases, an exception could be thrown when you opened a histogram.

#### Web apps: 'Refresh now' instead of 'Reconnecting...' message after communication was interrupted \[ID_31753\]

Up now on, when a web app (e.g. Dashboards, Monitoring, Ticketing, etc.) lost communication, a “Reconnecting...” message would appear in the UI. From now on, a “Refresh now” message will appear instead, prompting users to refresh the web page.

#### Failover: DataMiner modules would incorrectly consider the local IP address of the online agent as the primary IP address of the Failover setup \[ID_31756\]

After a Failover configuration had been updated (either manually or after an automatic synchronization), the DataMiner modules would incorrectly consider the local IP address of the online agent as the primary IP address of the Failover setup (instead of the virtual IP address). As a result, when file changes on the Failover setup were forwarded to other agents in the DMS, those agents would reject the changes as the IP address of the sender was unknown to them. Only after a DMA restart or a switchover/switchback operation would the DataMiner modules again use the virtual IP address of the Failover setup.

#### Jobs app: Hidden or required fields no longer hidden or required when domain or section was duplicated \[ID_31758\]

When you duplicated a job domain using the *Duplicate \> Create copies of the sections* option or when you duplicated a job section using the *Create a copy* option, in some cases, hidden or required fields would incorrectly no longer be hidden or required in the newly created domain or section.

#### DataMiner Cube - Alarm Console: Base alarms of a correlated alarm not shown on linked alarm tab \[ID_31789\]

When the Alarm Console had an alarm tab that was linked to an element of which an alarm was the base alarm of a correlated alarm, that alarm would incorrectly not be shown.

#### Problem with SLAnalytics when a large number of element state updates were being generated \[ID_31810\]

In some rare cases, an error could occur in SLAnalytics when a large number of element state updates were being generated.

#### Service & Resource Management: Problem with GetEligibleResources method \[ID_31818\]

In some cases, the GetEligibleResources method could throw NullReference exceptions or KeyNotFound exceptions.

#### Dashboards app - Parameter feed: Enhanced performance when fetching parameter indices \[ID_31841\]

Due to a number of enhancements, overall performance of the parameter feed has increased when fetching parameter indices.

#### Problem with filtered table subscriptions on DVE elements \[ID_31845\]

When a subscription on a table of a DVE element had been created with a filter (e.g. a primary key filter), the client would receive the initial data but no updates.

#### Failover: Problem when setting up a Failover system with a Cassandra database \[ID_31854\]

In some cases, the following exception could be thrown when a Failover system with a Cassandra database was set up:

```txt
System.Exception: Unexpected error from nodetool.
```

#### PDF reports: Incorrect scaling \[ID_31863\]

Up to now, in some cases, the contents of PDF reports would not get scaled correctly to fit the page.

#### DataMiner Cube - Bookings app: Not all booking data flushed from memory when Bookings app was closed \[ID_31880\]

When you closed the Bookings app, in some cases, not all booking data would be flushed from memory.

#### Failover: Agents not coming online after DataMiner restart \[ID_31915\]

When a Failover configuration incorrectly did not have normal heartbeats defined between the two Agents, the Agents would not automatically come online after a DataMiner restart.

#### External authentication via SAML: Problem when logging in with a user account that shared its email address with another account \[ID_31990\]

When, on a system that used external authentication via SAML, you tried to log in with a user account that shared its email address with another user account, up to now, an exception would be thrown. From now on, an error message will be added to the SLSAML.txt log file instead.

#### DataMiner landing page: User icon no longer shown in top-right corner \[ID_32108\]

On the DataMiner landing page, the user icon would incorrectly no longer be shown in the top-right corner.

#### Incorrect error in logging during startup of Failover setup \[ID_32112\]

In a Failover setup, during startup the following incorrect error could briefly be reported in the *SLFailover.txt* log file:

```txt
INVALID CONFIG: Failover is active, but no cluster is defined
```

#### Dashboards app: Problems with GQI \[ID_32142\]

In the Dashboards app, a number of issues with regard to GQI have been resolved.

- Column manipulation by regular expression would not work when all columns contained numeric values.
- Column manipulation by concatenation would concatenate the raw values instead of the display values.
- When data was being aggregated, “group by” operations would use the raw value instead of the display value.

#### Dashboards app: Problem when double-clicking the 'Start editing' button \[ID_32159\]

When, in the Dashboards app, you double-clicked the *Start editing* button, in some cases, the dashboard would keep on going in and out of edit mode.

#### Automation: Minor fixes with regard to the generation of email reports via Dashboards app \[ID_32165\]

In Automation, a number of minor issues have been fixed with regard to the generation of email reports via the Dashboards app.

#### Web apps: All CSS styles would incorrectly be reloaded when the theme colors were updated \[ID_32231\]

When, in a web app, the theme colors were updated, up to now, all CSS styles would incorrectly be reloaded.

#### DataMiner would incorrectly try to connect to 127.0.0.1 when taking a backup of a Cassandra database \[ID_32242\]

When a DataMiner backup included a backup of a Cassandra database, and, in the Cassandra.yml file, the rpc_address setting did not contain “0.0.0.0”, DataMiner would incorrectly assume the database was located at IP address 127.0.0.1. From now on, DataMiner will instead connect to the database located at the IP address specified in the DB.xml file.

#### Dashboards app: Feeds would stop feeding data after refreshing the page \[ID_32251\]

In some cases, feeds in a dashboards would stop feeding data after refreshing the page.

#### Dashboards app: Parameter state component would not show parameter updates for certain column parameters when using table index filters \[ID_32268\]

When a parameter state component was linked to a column parameter from a table using display keys and filtered using a table index filter, the data displayed by that component would not be updated when changes were made to the parameter.

#### Dashboards app: GQI engine would not fall back to the timezone of the browser when the commonServer.ui.DefaultTimeZone setting could not be found \[ID_32283\]

From DataMiner 9.6.11 onwards, the DataMiner web apps format time values based on the commonServer.ui.DefaultTimeZone setting, located in the C:\\Skyline DataMiner\\Users\\ClientSettings.json file. When this setting cannot be found, they will instead use the time zone of the browser. Up to now, the GQI engine would incorrectly not fall back to the time zone of the browser when it was unable to find the commonServer.ui.DefaultTimeZone setting in the ClientSettings.json file.

#### DataMiner Cube: Problem when a user without permission to view service definitions connected to an SRM system \[ID_32309\]

When a user connected to a Service & Resource Management environment, DataMiner Cube would throw an exception when that user did not have permission to view service definitions.

#### Problem when opening DMS Alerter \[ID_32312\]

In some cases, an error could occur when you opened DMS Alerter.

#### Dashboards app: Parameter feeds would incorrectly not load all parameter indices \[ID_32329\]

When loading parameters, in some cases, a parameter feed would incorrectly not load all parameter indices.

#### SLDataGateway would incorrectly try to start the local Cassandra service when a remote Cassandra cluster was configured \[ID_32338\]

In some cases, SLDataGateway would incorrectly try to start the local Cassandra service in situations where a remote Cassandra cluster was configured,

#### DataMiner Cube - Profiles app: Problem when duplicating profile parameters with mediation snippets \[ID_32387\]

When you duplicated a profile parameter with a mediation snippet on one of the configured protocol links, the duplicated mediation snippet would incorrectly not be marked as new. As a result, that snippet would not get added.

#### Failover: Problem with SLDataGateway after losing its connection to SLNet during a Failover switch \[ID_32435\]

When a Failover switch is performed, in some cases, SLDataGateway loses its connection to SLNet and immediately recreates it. However, because it did not receive any SLNet events during the time the connection was lost, up to now, SLDataGateway would be unaware that DataMiner was up and running, causing all write operations that require information from SLNet to get blocked. From now on, as soon as the connection between SLNet and SLDataGateway is re-established, the latter will assume DataMiner is up and running.

#### Dashboards: Component selection not cleared when switching between dashboards \[ID_32452\]

In some cases, component selection was not cleared when you switched between different dashboards in the Dashboards app, which could cause issues when new components were added.

#### SLAnalytics: Pattern matching would no longer work due to a problem while retrieving pattern data from Elasticsearch \[ID_32466\]

In some cases, pattern matching would no longer work due to a problem while retrieving pattern data from the Elasticsearch database.

#### Web apps: 'Refresh now' message would incorrectly appear when opening a web app that did not have an active websocket connection \[ID_32585\]

When your opened a web app (e.g. Dashboards, Monitoring, Ticketing, etc.) that did not have an active websocket connection, a “Refresh now” message would incorrectly appear. From now on, this message will only appear when an active websocket connection was broken.
