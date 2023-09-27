---
uid: General_Main_Release_10.1.0_enhancements
---

# General Main Release 10.1.0 - Enhancements

#### Web Services API: An exception will now be returned when retrieving alarms while the alarm cache is not initialized yet \[ID_19927\]

Up to now, when a large amount of alarms were retrieved via the Web Services API while the IIS server alarm cache was not fully initialized yet, in some cases, an incomplete result set would be returned. From now on, an exception will be returned instead.

The HTML5 apps (e.g. Monitoring), which make use of the Web Services API, will in this case now also display an error message indicating the alarm cache status.

#### SLNet: Enhanced alarm sorting \[ID_22739\]

A number of enhancements have been made to the alarm sorting mechanisms in the SLNet process.

Current alarm levels (in order of increasing priority):

- Undefined
- Initial
- Suggestion
- Information
- Normal
- Masked
- Notice
- Warning
- Minor
- Major
- Critical
- Timeout
- Error

#### Improvements to Change Element States Offline tool \[ID_23833\]

Numerous improvements have been implemented to the Change Element States Offline tool:

- The overall layout of the tool has been improved.
- The state of elements is now added as a suffix to element names.
- A CSV and XML export option for element states is now available in the *File* menu.
- A new *Elements by Protocol* tab has been added, with a tree view showing elements by protocol and protocol version. Checkboxes allow the quick selection of all elements in a node of the tree view.
- A search box has been added to make it easier to find elements in the *Elements by Name* and *Elements by Protocol* tabs. The wildcards "\*" (for any number of characters) and "?" (for exactly one character) can be used in this box. The element state can be included in the search
- The Ctrl+A key combination is now supported to select all elements.

#### Jobs app: Enhanced error handling when adding jobs \[ID_24238\]

Error handling when adding jobs has been enhanced.

#### Dashboards app: Updated design rotate button in button panel \[ID_24272\]

The design of the rotate button in a button panel component has been updated.

#### Smart-serial communication over IP: Receive time-out reduced from 100 ms to 15 ms \[ID_24282\]

In case of smart-serial communication over IP, the hard-coded time-out when receiving data has now been reduced from 100 ms to 15 ms.

#### DataMiner Cube - Stream Viewer: Buffer size increased to 1 MB \[ID_24330\]

The buffer size of Stream Viewer’s text box has increased from 32 kB to 1 MB.

#### Possibility to show information message in mobile apps + Dashboards app layout update \[ID_24336\]

In the Monitoring, Dashboards and Jobs apps, it is now possible to use the *ShowInformationMessage* method in a script to display a message in the app.

Note that a small change has also been implemented in the Dashboards app. The *New dashboard* button will no longer be displayed in the header bar. Creating a new dashboard remains possible via the context menu of the side panel and via the Dashboards homepage.

#### Jobs app: Timeline improvement \[ID_24352\]

In the Jobs app, the way items are displayed on the timeline has been improved:

- Items on the timeline now have a minimum width, so that they are displayed even if they have a very short duration.

- If items on the same height are very close to each other, they will be merged into one aggregated item.

- Clicking an item will now always select it. Clicking an aggregated item will select all the items it combines. To deselect an item, keep Ctrl pressed while you click it.

#### DataMiner Maps: Enhanced retrieval of marker alarm severities \[ID_24363\]

Due to a number of enhancements, overall performance has increased when retrieving marker alarm severities.

#### DataMiner Cube: Enhanced user picture icons in search results \[ID_24364\]\[ID_24573\]

A number of enhancements have been made to the user picture icons that appear in search results. Those icons will now also indicate whether a user is online, and when no user picture could be found, a default user icon will now be displayed instead.

Also, a user picture icon will now be displayed in the top-left corner of a user card.

#### SLAnalytics: Enhanced alarm template monitoring \[ID_24477\]

Due to a number of enhancements, overall performance of SLAnalytics has increased when monitoring alarm templates.

#### DataMiner Cube - Trending: Intermediary points added when exporting a trend graph as line graph \[ID_24580\]

If, when exporting trend data to CSV, you select the *Line graph instead of block graph* option, from now on, intermediary points will be added if no data is available at certain timestamps (which can happen when a value remained constant).

Depending on the step size of the data points, a point will be added at fixed intervals. Previously, points would only be added when a value changed.

#### DataMiner Analytics - Alarm focus: AlarmFocusEvents will no longer be cached by SLNet \[ID_24581\]

From now on, AlarmFocusEvents generated by SLAnalytics will no longer be cached by SLNet.

#### DataMiner Cube - Data Display: Matrices with more than 1000 inputs and outputs will no longer have an “Expand pages” button \[ID_24589\]

From now on, in order to prevent users from expanding large matrices, matrices with more than 1000 inputs and outputs will no longer have an “Expand pages” button.

#### Dashboards app: Changes to behavior table parameter subscriptions \[ID_24702\]

The following changes have been implemented to the behavior of table parameter subscriptions in the Dashboards app:

- When a column filter is specified, the client will only receive updates if the updated cell is part of a filtered column. This change also applies to the web API in general.

- In the drop-down, list and tree feeds, the indices will now be updated in real time if WebSockets are enabled. If WebSockets are not enabled, the indices will be fetched initially and then a message will be displayed to notify the user that WebSockets must be enabled in order to retrieve updates.

#### Jobs app: Fields marked 'Show in list view' will now always be shown in the jobs list, even when those fields do not have values \[ID_24708\]

Fields that are marked “Show in list view” will now always be shown in the jobs list, even when none of the listed jobs have a value set in those fields.

#### DataMiner Analytics: Enhanced SLNet subscription management \[ID_24730\]

A number of enhancements have been made to the way in which DataMiner Analytics manages SLNet subscriptions.

#### Dashboards app: Enhanced 'No data' error message in Line chart component \[ID_24737\]

Up to now, when no data could be displayed in a Line chart component, a general “No data” error message would be displayed. This general message has now been replaced by a more specific error message: “No data within the specified time range”.

#### HTML5 apps: Enhanced installation \[ID_24745\]

A number of enhancements have been made to the DataMiner HTML5 apps (e.g. Jobs, Dashboards, etc.). Users will now be able to install these apps much like they install other mobile apps.

#### DataMiner Analytics - Alarm focus: AlarmFocusEvents associated with alarms of elements that are paused or stopped will no longer be cleared \[ID_24750\]

From now on, events associated with alarms of elements that are paused or stopped will no longer be cleared.

#### DataMiner Cube - Services list: Only state change icons configured to perform a valid state change will be clickable \[ID_24753\]

When life cycle management is enabled, then the services list allows you to change the state of the service by clicking an icon. From now on, you will only be able to click icons that are configured to perform a valid state change.

#### Enhanced performance of NotifyDataMiner 128 (NT_UPDATE_PORTS_XML) \[ID_24777\]

Due to a number of enhancements, overall performance of NotifyDataMiner 128 (NT_UPDATE_PORTS_XML) has increased, especially when updating matrix data.

#### Monitoring app & Dashboards app: Parameter tables can now be displayed in full-screen mode \[ID_24789\]\[ID_24830\]

In the Monitoring app (DATA pages, VISUAL pages and CPE pages) and the Dashboards app (Parameter Page component), parameter tables can now be displayed in full-screen mode.

If your internet browser supports full-screen mode, a toggle button will appear in the top-right corner of each parameter table. You can exit full-screen mode by pressing ESC or F11.

#### Monitoring app: Enhanced performance when retrieving alarm information \[ID_24831\]

Due to a number of enhancements, overall performance of the Monitoring app has increased when retrieving alarm information.

#### Enhanced notification of DataMiner processes when a DMA leaves the DataMiner System \[ID_24906\]

Due to a number of enhancements, DataMiner processes will now get notified in a more uniform way when a DataMiner Agent leaves the DataMiner System. This will allow them to execute the necessary tasks when such an event occurs.

#### HTML5 apps: Enhancement date/time selector \[ID_24912\]

In all HTML5 apps (Monitoring, Dashboards, Ticketing, etc.), the date/time selector has been enhanced. It is now also possible to confirm the time by double-clicking the minutes.

#### Increased performance due to enhancements made to the locking behavior of the SLElement EPM cache \[ID_24916\]

Overall performance has increased due to a number of enhancements made to the locking behavior of the SLElement EPM cache.

#### DataMiner Cube - Alarm Console: Enhanced performance when displaying parameter heat lines \[ID_24928\]

Due to a number of enhancements, overall performance has increased when displaying parameter heat lines in the Alarm Console.

#### DataMiner Cube - Visual Overview: 'Textblock' control now inherits text alignment of shape \[ID_24929\]

When you turned a shape into a text block control by adding a shape data item of type *Options* set to “Control=Textblock”, up to now, the text alignment of that control would by default be set to Left Center. From now on, “Textblock” controls will inherit the text alignment configuration of the shape.

#### DataMiner Analytics - Alarm focus: Enhanced likelihood calculation of alarms associated with elements that were paused or stopped \[ID_24931\]

A number of enhancements have been made to the alarm focus mechanism, especially with respect to the likelihood calculation of alarms associated with elements that were paused or stopped.

#### SLDataMiner will no longer try to send status updates to the Mobile Gateway if the latter has its location set to '\<none>' \[ID_24972\]

When the Mobile Gateway location was set to “\<none>”, up to now, SLDataMiner would incorrectly try to send status updates to the Mobile Gateway’s non-existing IP address 0.0.0.0.

From now on, when the Mobile Gateway location is set to “\<none>”, SLDataMiner will no longer try to send status updates to it. It will only add a line to the logs (with log level 0), indicating that no Mobile Gateway location has been specified.

> [!NOTE]
> From now on, when a user changes the cellphone location, an information event will be generated.

#### Indexing Engine: Enhanced mechanism to delete data using filters \[ID_24977\]

A number of enhancements have been made to the mechanism used to delete data from the Indexing Engine, especially when using large filters.

#### Mobile apps: Confirmation message when leaving page with interactive script or job configuration \[ID_25078\]

When a user leaves a DataMiner mobile app page while in an interactive Automation script or while configuring jobs, a confirmation message will now be displayed. However, note that this is message is not displayed when the mobile apps are used on iOS.

#### Reports & Dashboards: PDF library updated \[ID_25117\]

The third-party library used to generated PDFs in the legacy Reports & Dashboards app (Winnovative) has been updated to version 15.

#### DataMiner Cube - Trending: Enhanced accuracy of prediction data for history set parameters \[ID_25143\]

Due to a number of enhancements, the accuracy of prediction data for history set parameters has increased.

#### Spectrum Analysis: Improved spectrum graph axis labels \[ID_25161\]

To make spectrum graphs more easily readable, the unit of measure will now no longer be displayed in every label of the X- and Y-axis of a spectrum graph. Instead, it will only be displayed once at the end of each axis.

#### DataMiner Cube - Visual Overview: ListView component enhancements \[ID_25224\]

In a *ListView* component in Visual Overview that has been configured to display elements, the following columns are now available:

- Protocol
- Protocol Version
- Polling IP
- Element properties \> Created by
- Element properties \> Created at (i.e. creation date)

In addition, it is now also possible to configure a filter on the *ListView* shape using the term "Element.PollingIP", for example *Element.PollingIP == '127.0.0.1'*.

#### SLAnalytics: Logging will no longer contain 'Unexpected number of responses returned while sending getInfoMessage' notices \[ID_25240\]

The SLAnalytics logging will no longer contain lines mentioning the following notice:

```txt
“Unexpected number of responses returned while sending getInfoMessage...”
```

#### Jobs app: Enhanced performance when viewing or editing a job \[ID_25292\]

Due to a number of enhancements, overall performance has increased when viewing or editing a job.

Also, a number of minor issues have been solved.

#### SLDataGateway: Enhanced retrieval of alarms from a MySQL database \[ID_25318\]

Due to a number of enhancements, the method used by the SLDataGateway process to retrieve alarms from a MySQL database has been optimized.

#### DataMiner Analytics - Alarm focus: timeOfArrival field added to AlarmFocusEvents \[ID_25343\]

AlarmFocusEvents now have a timeOfArrival field. In most cases, this field will be set to the time at which the corresponding AlarmEventMessage was received. However, in the following AlarmFocusEvents, it will be set to the current time:

- Hourly AlarmFocusEvents that update the focus value of active alarms.

- AlarmFocusEvents for old alarms that are resent after restarting an element.

- AlarmFocusEvents that are sent for active alarms on startup.

#### Default alarm bubble-up behavior in recursive tables changed from 'recursive=none' to 'recursive=up' \[ID_25349\]

The default alarm bubble-up behavior in recursive tables has been changed from “recursive=none” to “recursive=up”, i.e. from child nodes up to parent nodes (following the foreign key in the direction it is in).

#### DataMiner Installer now targets Microsoft .NET Framework 4.6.2 \[ID_25378\]

The DataMiner Installer now targets Microsoft .NET Framework 4.6.2.

#### Dashboards app: Pivot table supports mediation protocols \[ID_25491\]

The *Pivot table* dashboard component now supports mediation protocols.

#### Dashboards app: Service definition visualization will be updated when the service definition or the booking gets updated \[ID_25562\]

The service definition visualization will now be updated when the service definition or the booking gets updated.

> [!NOTE]
> When a booking gets deleted while the service definition instance of that booking is being displayed, an error will be shown.

#### SLAnalytics: Alarm focus enhancements \[ID_25591\]

From DataMiner 10.0.0/10.0.2 onwards, the DataMiner Analytics software assigns an estimated likelihood or “alarm focus score” to each alarm, after analyzing the short-term history and current behavior of incoming alarms in real time.

Due to a number of enhancements, overall performance of this alarm focus feature has now increased.

#### Indexing Engine: Default index replication factor now set to 2 \[ID_25606\]

From now on, new Indexing Engine installations will have their index replication factor set to 2 for all data objects except suggestions. For suggestions, the index replication factor will be set to 1.

#### Protocols - Serial clients: Enhanced locking behavior \[ID_25647\]

A number of enhancements have been made to the locking behavior of serial client elements.

#### Dashboards app: Enhanced rendering of scalable text \[ID_25671\]

Due to a number of enhancements, the rendering of scalable text in a number of dashboard components (e.g. digital clock, trend statistics, state visualizations) has been optimized.

#### DataMiner Cube - Visual Overview: \[profile:\] placeholder enhancements \[ID_25795\]

A number of performance enhancements have been made with regard to the \[profile:\] placeholder.

#### SLAnalytics - Behavioral anomaly detection: Enhanced performance when displaying icons on trend graphs \[ID_25798\]

Due to a number of enhancements, overall performance has increased when displaying icons on trend graphs to indicate behavioral anomalies.

#### SLPort logging enhancements \[ID_25806\]

A number of enhancements have been made to the SLPort logging.

#### Logs will now include Cassandra yaml file parsing errors \[ID_25809\]

From now on, Cassandra yaml file parsing errors will also be logged.

#### Cassandra 3.7 installer now uses AdoptOpenJDK 8u252 \[ID_25850\]

The Cassandra 3.7 installer now uses AdoptOpenJDK 8u252.

#### Alarm queuing enhancements to prevent alarms from getting stuck in the Alarm Console \[ID_25927\]

In some rare cases, alarms could get stuck in the Alarm Console. This has now been prevented by enhancing the alarm queuing mechanism.

#### SLAnalytics: Sending messages asynchronously has been optimized \[ID_25942\]

Due to a number of enhancements, sending messages asynchronously has been optimized.

#### Service & Resource Management: Enhancements with regard to quarantine-related messaging \[ID_25966\]

A number of enhancements have been made to the messages that appear when managing profile instances, especially with regard to quarantining.

#### Enhanced performance of Visio shapes linked to an EPM object but not to a view \[ID_25972\]

Due to a number of enhancements, overall performance of Visio shapes linked to EPM objects has increased, especially when they are not linked to a view.

#### Trend icons now determined based on trend window duration \[ID_26030\]

To improve the efficiency of the SLAnalytics process, it now determines the trend icon based on the trend window duration of the parameter.

#### Service & Resource Management: Optimized functions.xml generation \[ID_26060\]

The generation of functions.xml files has been optimized. Function names no longer have an “SRMFunction\_” prefix and the \<Graphical> tag of the parent function will now automatically be added to the generated functions.xml file.

#### Dashboards app: Enhanced performance of CPE feed component \[ID_26082\]

Due to a number of enhancements, overall performance of the CPE feed component has increased.

#### Jobs app: Time range validation when creating jobs \[ID_26166\]

From now on, due to a number of enhancements as to data validation, it will no longer be possible to create a job with an invalid time range.

#### Profiles app: Enhanced performance when loading \[ID_26197\]

Due to a number of enhancements, overall performance of the Profiles app has increased when loading, especially on systems with a large amount of profiles.

#### DataMiner Maps: Enhanced performance when retrieving EPM-related data \[ID_26216\]\[ID_26233\]

Due to a number of enhancements, overall performance has increased when retrieving EPM-related data.

#### Dashboards: Column parameters with advanced naming supported for trend statistics visualization \[ID_26240\]

The *Trend statistics* visualization in the new Dashboards app now supports column parameters from tables that use advanced naming.

#### DataMiner Cube - Alarm Console: Reduced memory usage \[ID_26285\]

Due to a number of enhancements, overall memory usage of the Alarm Console has been reduced.

#### Dashboards app: Embedded Chromium web browser engine updated to v81 \[ID_26296\]

The embedded Chromium web browser engine has been updated to v81.

#### SLAnalytics: Enhanced logging \[ID_26335\]

A number of enhancements have been made to the SLAnalytics logging.

#### DataMiner Cube: Enhanced Back/Forward navigation \[ID_26457\]

Up to now, clicking the *Back* and *Forward* buttons would only make you jump from one card to another. From now on, also the navigation history within a card will be taken into account.

For example, when you drill down from a card page to a parameter, clicking *Back* will bring you back to that card page, and when you open the trend page of a table cell from within a Visio page, clicking *Back* will bring you back to that Visio page.

Also, when you hover over a *Back* or *Forward* button, a tool tip will now show the name of the card and the page that will be opened.

#### DataMiner Cube: Enhanced way of saving information about the last user who logged in \[ID_26483\]

When DataMiner Cube is shut down, it saves information about the last user who logged in. The formatting of that user data has now been enhanced.

#### Jobs app: Possible to update or delete values of drop-down fields in unused job sections \[ID_26503\]

From now on, if a job section is not being used by a job, it will be possible to update or delete values of drop-down fields in that section.

If you try to update or delete values of drop-down fields in sections that are being used, an error message will appear.

#### Applications using system files to be updated during a DataMiner upgrade will now forcefully be terminated \[ID_26505\]

When updating system files during a DataMiner upgrade, the SLReplace process will now forcefully terminate any application that is using the files to be updated.

#### Jobs app: Minor enhancements \[ID_26535\]

In the Jobs app, a number of minor enhancements have been made:

- Up to now, names of job templates had to be unique across the entire Jobs app. From now on, they only have to be unique within a specific domain.

- Up to now, when you changed the type of a job field that was being used in a job, in some cases, the value of the “Show in list view” option would incorrectly be changed. From now on, the value of this option will be left untouched.

#### Dashboards app - Line chart component: Loading indicator next to button to expand or collapse the trend graph legend \[ID_26557\]

Up to now, when data was being loaded into a line chart component, a loading indicator would replace the button to expand or collapse the legend. As a result, it was not possible to expand or collapse the legend while data was being loaded. From now on, when data is being loaded into a line chart component, a loading indicator will be displayed next to the button to expand or collapse the legend.

#### General security enhancements \[ID_26620\]

A number of enhancements have been made with regard to user permissions needed to retrieve or modify data on DataMiner Systems.

#### Dashboards app: Parameter feed enhancements \[ID_26627\]

Due to a number of enhancements, overall performance of the parameter feed has increased, especially when using it in conjunction with parameter table, pivot table and line chart components.

#### DataMiner Cube - Service & Resource Management: Enhanced error messages \[ID_26629\]

Throughout DataMiner Cube, a number of error messages related to Service & Resource Management have been rewritten to make them clearer and more user-friendly.

#### Cassandra: Enhanced performance when deleting element data \[ID_26639\]

Due to a number of enhancements, overall performance has increased when deleting element data from a Cassandra database.

#### Trending: Increased limit for trend values of type Double to be converted to scientific notation strings \[ID_26646\]

In the database, trend values are stored as text strings.

Up to now, all values of type Double with a length of more than 6 characters were converted to a scientific notation string (e.g. “1e07”). From now on, only values of type Double with a length of more than 12 characters will be converted to a scientific notation string.

#### Improved logging in case client is disconnected \[ID_26667\]

If a client application tries to send a request to a DMA that has already destroyed the client connection, or when the client application checks the connection and finds that it no longer exists, now the log information will mention that the connection was closed with the time when it was closed and the reason it was closed. Previously, logging only mentioned "no such connection" in this case.

#### Enhanced performance when migrating a database from MySQL to Cassandra \[ID_26670\]

Due to a number of enhancements, overall performance has increased when migrating a database from MySQL to Cassandra.

#### Jobs app: No longer possible to edit or delete hidden job sections \[ID_26687\]

In configuration mode, up to now, it was possible to not only unhide a hidden section, but also to edit or delete it. From now on, it will only be possible to unhide hidden sections. It will no longer be possible to edit or delete hidden sections.

#### Jobs app: Enhanced label behavior in timeline view \[ID_26727\]

A number of enhancements have been made to the way in which labels are visualized in the timeline view.

Also, the custom time filter will now correctly update when zooming in or out.

#### DataMiner Cube: Enhanced performance when processing parameter updates and calculating service statistics \[ID_26863\]

Due to a number of enhancements, overall performance has increased, especially when processing parameter updates and calculating service statistics.

#### SLAnalytics: Enhanced logging \[ID_26884\]

A number of enhancements have been made to the SLAnalytics logging.

#### Raw value displayed if string value of analog parameter could not be parsed as double \[ID_26909\]

If a string value of an analog parameter could not be parsed as double, since DataMiner 10.0.9, "0" would be displayed as the default fallback value. However, as some older drivers relied on the previous behavior, now the raw value will be displayed again instead.

#### Lazy loading of cards in tab layout \[ID_26920\]

To improve memory usage and performance, when you open a saved workspace with multiple cards in a tab layout, each card will only be initialized once it has been selected. The same applies when cards are loaded when you log in to Cube.

#### DataMiner Cube desktop app now updated silently after connection to DMS with higher DataMiner version \[ID_26944\]

When you connect to a DMS with a higher DataMiner version than the currently installed version, the DataMiner Cube desktop app is now updated silently, without a pop-up message.

#### Improved graph layout of service RCA chains \[ID_26945\]

An improved algorithm is now used to draw the graph of the RCA chain of a service. This will better prevent overlapping connections and connections running through nodes.

#### Service & Resource Management: Wildcard supported for protocol version in ProtocolLinks of VirtualFunctionDefinition \[ID_26966\]

In the list of *ProtocolLinks* of a *VirtualFunctionDefinition*, an asterisk ('"\*") can now be used as a wildcard character in a protocol version. However, the wildcard can only be specified at the end of the version.

#### DataMiner mobile apps updated to Angular 9 \[ID_26975\]

The DataMiner mobile apps that use Angular, e.g. the Monitoring, Dashboards and Jobs app, now use Angular 9 instead of Angular 8.

#### Opening the DataMiner Cube start window via system tray icon can now restore existing minimized window \[ID_27006\]

When the DataMiner Cube start window was opened and minimized, opening it again using the system tray icon will restore the existing window.

#### DataMiner Cube: Embedded DataMiner apps now always use Chromium browser \[ID_27052\]

All DataMiner apps displayed within an embedded web browser in DataMiner Cube (e.g. Ticketing, Dashboards, Reports, Annotations, etc.) will now always use the Chromium browser engine, regardless of which default browser engine is configured.

#### Alarm when Cassandra or Elasticsearch database go offline \[ID_27061\]

When the Cassandra or Elasticsearch database go offline, an alarm is now generated in DataMiner. In the alarm details, it will show exactly which storage is in file offload mode while the database is offline.

#### App packages now synced in Failover setup \[ID_27100\]

When an app package is uploaded to one of the DMAs in a Failover pair, it is now automatically synced to the other DMA in the pair. Similarly, if an app package is removed from one of the DMAs in a Failover pair, it is now also automatically removed from the other DMA.

#### Improved behavior of input controls in HTML5 apps \[ID_27129\]

In the DataMiner HTML5 apps, when you fill in a control consisting of multiple parts, e.g. a datetime control, now the next part will always be automatically selected after a part has been completed.

#### Dashboards app: Improved pop-up window when interactive Automation script is canceled \[ID_27141\]

If an interactive Automation script is canceled in the Dashboards app, a pop-up window will now be displayed with the title of the current content of the script, or with the name of the script if no title is available. The pop-up window will not mention the term "script" to avoid confusion in users who may not be aware that they are using a script.

#### Improved logging of PowerShell scripts in DataMiner upgrades \[ID_27160\]

When DataMiner is upgraded and one of the steps of the upgrade is a PowerShell script, the output of that script is now written to the progress.log file and displayed in the upgrade window.

#### Dashboards app: Improved row height behavior \[ID_27203\]

The height of the rows of the dashboard grid has been halved, from 36 to 18 pixels, in order to allow more precise control of the position of dashboard components. In existing dashboards, the existing components will therefore use twice as many rows.

In addition, row height will no longer be adjusted dynamically, the default height of a component now takes margin, padding and border into account and there is no longer a minimum height for a component.

#### Failover: More information will now be returned after synchronizing the two agents \[ID_27156\]\[ID_27870\]

After synchronizing the two agents in a Failover setup, from now on, more detailed information about the synchronization process will be returned.

#### DataMiner Cube desktop app: Upgrade improvements \[ID_27159\]

A number of improvements were implemented to the upgrade mechanism of the DataMiner Cube desktop app:

- When the DataMiner Cube desktop app detects that an update is ready, in any open instances an info bar will now notify the user that the app needs to be restarted, and ask for confirmation.

- When the download of a new version is incomplete because of a restart or shutdown of the app, the download will now be cleaned up automatically to prevent issues.

- If the *Check for updates* option is selected in the start window, the resulting message will now be displayed in an info bar instead of a message box.

#### DataMiner Cube - Service & Resource Management: Enhanced retrieval of service states \[ID_27202\]\[ID_27484\]

Due to a number of enhancements, overall performance has increased when retrieving SRM service states in the Cube Surveyor, the Services app and Visual Overview.

#### Dashboards app: Enhanced tool tip icons \[ID_27331\]

Throughout the Dashboards app, the tool tip icons have been enhanced.

#### Dashboards app: Enhanced component resizing \[ID_27372\]

Due to a number of enhancements, the way to resize dashboard components has been improved, especially on mobile devices.

#### Jobs app: Miscellaneous enhancements \[ID_27454\]

A number of enhancements have been made to the user interface of the Jobs app: icons have been replaced, progress bars and tool tips have been added where appropriate, actions showing “remove” now all show “delete” instead, etc. Also, overall performance has increased.

#### Services app now includes virtual function definitions configured in DataMiner \[ID_27462\]

Previously, the Services module only listed virtual functions that had been uploaded to DataMiner via a Functions.xml file. Now it also includes virtual function definitions that were fully configured in DataMiner.

#### SLWatchdog will now automatically restart the NAS and NATS services \[ID_27478\]

From now on, when SLWatchdog notices that the NAS and/or NATS services were stopped, it will automatically restart them and generate an alarm.

#### DataMiner Cube: Enhanced performance when loading custom SVG icons during login \[ID_27480\]

Due to a number of enhancements, overall performance has increased when loading custom SVG icons during login.

#### DataMiner Maps: KML layers now always bottom layers of map \[ID_27492\]

In the DataMiner Maps application, KML layers will now always be placed below other layers. Other layers will be drawn from top to bottom as defined in the map configuration.

#### Monitoring app/Dashboards app: Support for embedded trend graphs in Visual Overview \[ID_27574\]\[ID_27584\]

The Monitoring app and Dashboards app now support the use of embedded trend graphs in Visual Overview. By default the trend graphs will display the last 24 hours of trending. In a dashboard, the colors of the graph will depend on the theme settings of the dashboard.

#### DataMiner Cube start window: Popup windows can be closed by pressing ESC & main window title changed to 'DataMiner Cube' \[ID_27582\]

In DataMiner Cube start window, popup windows can now be closed by pressing the ESC button.

Also, the title of the main window has been changed to “DataMiner Cube”.

#### DataMiner upgrade packages now also include the C:\\Skyline DataMiner\\Resources folder \[ID_27600\]

DataMiner upgrade packages now also include the C:\\Skyline DataMiner\\Resources folder.

#### More details will be logged when an error occurs while taking a backup \[ID_27614\]

From now on, more detailed information will be added to the log files when an error occurs while taking a backup.

#### Dashboards app: Right-clicking a component now only shows 'Copy embed URL' in edit mode \[ID_27629\]

Previously, when a dashboard component was right-clicked, this always showed the option *Copy embed URL*. However, as this option is not as useful for a dashboard operator as the default right-click menu, it will now only be displayed when the component is right-clicked in edit mode. Otherwise, the default right-click menu will be displayed.

#### DataMiner Cube - Services app: Enhanced retrieval of service information \[ID_27647\]

In the Services app, all SRM service information will now be retrieved page by page.

#### DataMiner Cube - Resources app: A pop-up message will now be displayed when trying to configure resources on a system with an SRM license but no Indexing Engine \[ID_27737\]

When, on a system with an SRM license but no Indexing Engine, you try to configure resources, from now on, DataMiner Cube will show a message, saying that this is not possible.

#### Client applications now also get notified when cell alarm levels in the source data tables of direct views change due to updates that do not change the cell value \[ID_27785\]

From now on, client applications displaying direct views will also be notified when cell alarm levels in the source data tables change due to updates that do not change the cell value. (e.g. when a cell in a source table gets masked).

#### Live Sharing Service: Enhanced error handling \[ID_27791\]

A number of enhancements have been made to the overall error handling in the Live Sharing Service.

#### DataMiner Cube: Enhanced consistency of trend graph legends \[ID_27831\]

From now on, when multiple trend graphs show similar data, they will all have a similar legend.

#### DataMiner Cube: Virtual functions now in separate section in Protocols & Templates app + made unavailable for regular element creation \[ID_27832\]

Virtual functions are now displayed in a separate *Virtual Functions* section in the Protocols & Templates app. In addition, when you create an element, virtual functions are not listed among the protocols you can choose for the element.

#### DataMiner Cube: Enhanced performance when connecting to a DMA with a large amount of alarms \[ID_27837\]

Due to a number of enhancements, overall performance has increased when connecting to a DataMiner Agent with a large amount of alarms.

#### Interactive Automation scripts: No longer possible to clear the value of a selection box control \[ID_27845\]

Up to now, in an interactive Automation script, it was possible to clear the value of a selection box control by clicking an X button. From now on, this is no longer possible.

#### Interactive Automation scripts: Multi-line text boxes will no longer expand when selected \[ID_27858\]

Up to now, a multi-line text box (i.e. a UIBlock of type TextBox with IsMultiline set to true) would by default have a height of 1 line and would expand when it was selected. From now on, its initial height will be fixed. It will no longer expand when selected.

#### DataMiner Cube: Enhanced retrieval of user images \[ID_27861\]

DataMiner Cube shows an image of the user who is logged in. The way in which this image is retrieved, has now been enhanced.

#### SLPort now automatically resizes the socket buffer before receiving data from a socket \[ID_27891\]

From now on, the SLPort process will automatically resize the socket buffer before receiving data from a socket.

#### DataMiner Jobs: new ResourceFieldDescriptor field \[ID_27922\]

A new *ResourceFieldDescriptor* field is now available for DataMiner jobs. This field requires a GUID value, which should be the GUID of a resource. It also has a *ResourcePoolIds* property which can be used to filter resources based on resource pools. This feature is intended to support the upcoming PLM app.

#### Performance enhancement: An element card page containing a direct view table will only show the alarm severity of that table when the page is opened \[ID_27928\]

When you open an element card, pages containing direct view tables will no longer show the alarm severity of those tables. Only when you open a page containing a direct view table will the alarm severity of that table be calculated and displayed.

#### DataMiner Jobs: New DefaultValue property of FieldDescriptor class \[ID_27934\]

The *FieldDescriptor* class for DataMiner jobs now has a new *DefaultValue* property, so that it is now possible to add a default field value to each FieldDescriptor. This feature is intended to support the upcoming PLM app.

#### Service & Resource Management: ResourcesNotMatchWithServiceDefinition check removed \[ID_27938\]

The ResourcesNotMatchWithServiceDefinition check has been removed.

As a result, an error will no longer be returned when saving a ServiceReservationInstance where the booked resources do not match the functions or virtual functions required by the ServiceDefinition.

#### Service & Resource Management: New VirtualFunctionID property added to NodeDefinition class \[ID_27953\]

A new *VirtualFunctionID* property is now available for *NodeDefinition* objects for service profiles.

When a service profile definition is created, DataMiner will check if the virtual function ID exists. If it does not exist, a new error reason *InvalidVirtualFunctionDefinitions* will be added in the trace data. The property *InvalidVirtualFunctionIDs* of the trace data will be filled in with the non-existing virtual function IDs. The property *ServiceProfileDefinition* of the trace data will allow you to identify which service profile definition has an error.

Note that this property can currently not yet be configured in DataMiner Cube.

#### Ticketing app: Enhanced 'Edit ticket field' window \[ID_27962\]

Due to a number of enhancements to the *Edit ticket field* window, especially the section that allows you to define the possible values, configuring a ticket state field has been made more intuitive.

#### Dashboards app - Parameter feed: 'partial table' renamed to 'paged table' \[ID_28048\]

In the tool tip of the “Select all items” and “Select specific number of items” options, “partial table” has been renamed to “paged table”.

#### DataMiner Cube - EPM: Enhanced color scheme of EPM topology diagram in Skyline Black theme \[ID_28053\]

In the Skyline Black theme, the color scheme of the EPM topology diagram has been enhanced.

#### New icons added to Icons.xml file \[ID_28060\]

The following new icons have been added to the file Icons.xml, located in the folder C:\\Skyline DataMiner\\Protocols.

- Trash
- New item

#### Dashboards app: Default themes updated \[ID_28074\]

In the Dashboards app, a number of default themes have been updated.

#### Dashboards app: Enhanced page selector in embedded visual overviews \[ID_28237\]

A number of enhancements have been made to the page selector of embedded visual overviews.

For example, when a visual overview with multiple pages is embedded in a dashboard, the page selector will now also inherit the dashboard theme colors. Also, when a page is selected, the page selector will now display the name of the page.

#### DataMiner Cube: SVG icons will now automatically adapt to the chosen Cube theme \[ID_28248\]

Due to a number of enhancements, SVG icons will now automatically adapt to the chosen Cube theme.

#### Ticketing app: No automatic redirection anymore when ticket creation or ticket update has finished \[ID_28310\]

Up to now, when, after creating or editing a ticket, you navigated to another part of the Ticketing app, you would automatically be navigated back to the ticket when the ticket creation of ticket update was finished. From now on, this will no longer be the case.

#### DataMiner Mobile apps: Improvement of arrow controls to increase/decrease a value \[ID_28312\]

In the DataMiner mobile apps, such as the Monitoring, Ticketing and Dashboards app, when you hover over the arrow buttons to increase or decrease the value of a date or time, the value that will be affected by the arrow buttons will now be highlighted. In addition, such arrow buttons will now only be displayed when you hover over the input.

#### Jobs app: No longer possible to start a job data migration when no Elasticsearch database is available \[ID_28385\]

From now on, it will no longer be possible to start a job data migration when no Elasticsearch database is available.

#### DataMiner Cube - Service & Resource Management: Enhanced performance when opening Cube \[ID_28603\]

Due to a number of enhancements, overall performance has increased when opening Cube, especially in SRM environments.

#### Dashboards app: Optimized rendering of GQI query results in PDF reports \[ID_28622\]

In the Automation, Correlation and Scheduler modules, you can generate a report based on a dashboard from the new Dashboards app.

Due to a number of enhancements, the way in which tables that display GQI query results are rendered in PDF reports has now been optimized. When the *Stack components* option is enabled, tables showing results from different queries will even be rendered in such a way that all result sets are displayed one after the other.

#### Failover: Heartbeat checks will now be logged in the debug logging \[ID_28627\]

In a Failover setup, heartbeat checks will now be logged in the debug logging.

#### SLAnalytics - Alarm Focus: Enhanced performance \[ID_28689\]

Due to a number of enhancements, overall performance has increased when fetching the alarm history.

#### Dashboards app - GQI: Changing the column order by using a column filter \[ID_28693\]

It is now possible to change the column order by using a column filter. The order of the selected columns in the column filter will now be used to construct the resulting table. By default, the order of the columns is determined by the data source.

Also, the following issue was fixed. When a row filter was used on a column that was not included in the default column set, in some cases, an additional column would incorrectly be added to the default column set.

#### Dashboards app - Table components: Enhancements with regard to resizing \[ID_28733\]

A number of enhancements have been made to the table components, especially with regard to the resizing of those components.

#### DataMiner Cube - Profiles app: Enhancements \[ID_28768\]

A number of enhancements have been made to the Profiles app. Overall performance has increased when loading profiles, and paging of profile parameters and profile definitions is now supported.

#### DataMiner Cube - Profiles app: A warning will now appear when no value is assigned to a mandatory parameter \[ID_28787\]

When, in the Profiles app, you indicate that a profile parameter is mandatory, if that parameter does not have a value assigned, a warning will now appear, saying that it is recommended to assign a value to mandatory parameters.
