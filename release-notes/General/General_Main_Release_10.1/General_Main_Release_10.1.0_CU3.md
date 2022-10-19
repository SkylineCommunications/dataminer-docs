---
uid: General_Main_Release_10.1.0_CU3
---

# General Main Release 10.1.0 CU3

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### DataMiner Cube - Visual Overview: Viewport and Navigate variables of a Resource Manager timeline will now be read and applied upon opening \[ID_29299\]

When, in Visual Overview, you create a shape that should display the Resource Manager timeline by adding a shape data field of type Component set to “Reservations” or “Bookings”, the Navigate and Viewport session variables allow you to control navigation and zooming within the timeline.

- The Navigate variable can be used to automatically navigate to a specified time range.

- The Viewport variable can be used to zoom to a specified time range and to visualize the time range to which you zoomed manually.

From now on, both variables can be processed immediately upon opening a visual overview with a Resource Manager timeline.

- Setting the Navigate variable using a page-level InitVar will make the timeline navigate immediately to the chosen time slot and clear the Navigate variable.

- The Viewport variable will always be read upon opening the Resource Manager timeline. In other words, if a session variable already exists in the scope in question (e.g. when the time line was opened while using the global variable scope), the timeline will automatically zoom to the last-known view port.

> [!NOTE]
> The Navigate variable will be processed after the Viewport variable.

#### DataMiner Cube - SLAnalytics: Enhanced handling of errors that occurred at startup \[ID_29311\]

In DataMiner Cube, from now on, when errors occurred while SLAnalytics was starting up its different features, a message box will be displayed, listing the features that could not be started.

For more information about the listed errors, users can then check the SLAnalytics logging.

#### DataMiner Cube - Service & Resource Management: Enhanced performance \[ID_29398\]

Due to a number of enhancements, overall performance of the different Service & Resource Management modules has increased.

#### Dashboards app - PDF reports: Data overflow warnings will now be added at the bottom of the email body \[ID_29417\]

Up to now, when a data overflow was detected while generating a PDF report, a warning would be added to the “Report” section, which is closed by default. From now on, data overflow warnings will be added at the bottom of the email body, below the “Report” section. This will allow users to immediately notice the warnings when they open the email message.

#### Jobs app: Tool tips added to section definition settings \[ID_29443\]

The job section definition settings “Color”, “Icon” and “Allow Multiple Instances” now have tool tips that indicate that they are linked to the job domain and will not affect other referenced job section definitions in other domains.

#### Mobile apps - Visual Overview: Linking shapes to webpages \[ID_29444\]

When you link a shape to a webpage using a shape data field of type *Link*, that page will be opened each time a user clicks that shape. This feature will now also work on visual overviews in mobile apps (e.g. Dashboards, Monitoring, etc.).

#### Dashboards app - GQI: Enhanced performance when executing large queries \[ID_29473\]

Due to a number of enhancements, overall performance has increased, especially when executing large queries.

#### Enhancements made to the method that decides which subscriptions to forward to other agents in the DMS \[ID_29490\]

A number of enhancements have been made to the method that decides which subscriptions to forward to other agents in the DMS. These enhancements will considerably reduce SLNet CPE usage, especially on systems with a large number of active subscriptions.

#### Ticketing app: Enhancements \[ID_29492\]

A number of enhancements have been made to the Ticketing app, especially with regard to masked domains.

- When a masked domain is deleted, all tickets associated with that domain will now also be deleted.

- On the Configuration page, masked domains will now be marked with a special icon.

- When a masked domain is opened via a URL, a warning will now be displayed, indicating that the domain is masked. Also, no edit buttons will appear.

- When you open the create ticket window or edit ticket window via a URL to create or edit a ticket from a masked domain, a warning will now be displayed, and all fields of that ticket will be disabled.

#### Visual Overview: New option to keep real-time charts from showing exception values in labels \[ID_29504\]

In the *ParametersOptions* shape data field for a parameter chart showing real-time values, you can now use the *VisualizeExceptions=false* option to keep the display value for exception values from being shown in a label.

| Shape data field  | Value                                                                     |
|-------------------|---------------------------------------------------------------------------|
| ParametersOptions | VisualizeExceptions=true (default behavior)<br> VisualizeExceptions=false |

#### DataMiner Cube: Enhancements with regard to dragging, sizing and positioning of undocked windows and cards \[ID_29508\]

DataMiner Cube automatically scales each window based on the monitor it is displayed on. A number of enhancements have now been made, especially with regard to the dragging, sizing and positioning of undocked windows and cards.

Sizing:

- When a window is undocked via a drag operation, it will take the same size as the docked window.

- When a window is undocking via SHIFT-Click or via the Undock context menu action, it will take a size based on the type of window. If no specific size is provided (e.g. in case of an element card), the default size will be used (i.e. 80% of the screen size).

- Window size range: From 600x400 (minimum) to 80% of the screen (maximum)

Positioning:

- When a window is undocked, it will be centered on the Cube’s main window.

- Undocked windows will respect the screen boundaries and be confined to one screen.

- When a window is undocked via a drag operation, it will correctly follow the mouse cursor and initiate a window drag that can immediately snap to screen borders.

#### Notice will now appear in the Alarm Console when the initial synchronization of a DMA fails \[ID_29532\]

When, after adding a DMA to the DataMiner System, the initial synchronization of that agent fails, a notice will now appear in the Alarm Console.

Also, a number of protective measures have been added to prevent an agent that has not yet completed its full synchronization from being synchronized at midnight.

#### Protocols - QActions: #define ALARM_SQUASHING \[ID_29549\]

The preprocessor directive “#define ALARM_SQUASHING” will now automatically be added to each QAction when compiling a protocol.

In QActions, all code related to alarm squashing should be enclosed as follows:

```csharp
#if ALARM_SQUASHING
    // Code specific for alarm squashing (DataMiner 10.1.0 and later)
#else
    // Code for DataMiner 10.0.0 and earlier
#endif
```

This allows protocols that contain alarm squashing functionality to also be compiled on DataMiner versions that do not support alarm squashing.

#### Elasticsearch: Support for NotRegex filters \[ID_29567\]

DataMiner now supports the use of NotRegex filters in Elasticsearch.

#### DVE elements notifications no longer added to SLNetCOM Notification Stack \[ID_29601\]

On DataMiner startup and hourly at report generation, a batch of notifications gets forwarded between DataMiner modules, ending up on the SLNetCOM Notification Stack. Up to now, two such notifications were also forwarded for every DVE element. These will now no longer be sent.

#### Automation scripts: #define ALARM_SQUASHING \[ID_29613\]

The preprocessor directive “#define ALARM_SQUASHING” will now automatically be added to each C# block of an Automation script.

In C# blocks, all code related to alarm squashing should be enclosed as follows:

```csharp
#if ALARM_SQUASHING
    // Code specific for alarm squashing (DataMiner 10.1.0 and later)
#else
    // Code for DataMiner 10.0.0 and earlier
#endif
```

This allows C# blocks that contain alarm squashing functionality to also be compiled on DataMiner versions that do not support alarm squashing.

> [!NOTE]
> Up to now, the following directives would only be added to QActions. These will now also be added to C# blocks of Automation scripts.
>
> - #define DBInfo
> - #define DCFv1

#### SLNetCom notification thread will now only start ignoring messages after a grace period has passed \[ID_29631\]

When the SLNetCom notification thread reaches a certain threshold (defined by MaxStackSLNetCOMNotifications), the DMA assumes something is wrong and stops processing messages, requiring a restart. However, in some cases, this threshold can be reached even when nothing is wrong.

In order to prevent this, a grace period has now been introduced. When the number of SLNetCom notification messages reaches a peak, the DMA will only start ignoring messages when the number of messages on the stack is equal or greater than the threshold during the entire grace period.

Using the SLNetClientTest tool, you can specify this grace period by configuring the SLNetCOMNotificationsStackExceedsThresholdGracePeriodInMin setting (default value: 1 minute).

#### DataMiner Cube - Element Connections app: Mechanism used to delete connections between a destination parameter and a non-virtual source parameter has been optimized \[ID_29653\]

Due to a number of enhancements made to the Element Connections app, the mechanism used to delete connections between a destination parameter and a non-virtual source parameter has been optimized.

#### Standalone Elastic Backup tool will now have to be used to restore a backup of an Elasticsearch database \[ID_29677\]

When you take a backup of a DataMiner Agent, you can opt to also take a backup of its Elasticsearch database. However, as the latter will in most cases be a cluster, automatically restoring an Elasticsearch backup when restoring a DataMiner Agent is not advisable.

From now on, even when a DataMiner backup includes an Elasticsearch backup, the latter will not be automatically restored when the DataMiner backup is restored. Restoring an Elasticsearch backup will now have to be done using the Standalone Elastic Backup tool.

For more information on the Standalone Elastic Backup tool, see [Standalone Elastic Backup Tool](xref:Standalone_Elastic_Backup_Tool).

#### DataMiner Cube - Surveyor: Enhanced performance when loading services \[ID_29715\]

Due to a number of enhancements, especially with regard to the loading of services into the Surveyor, overall performance of DataMiner Cube has increased when starting up.

### Fixes

#### Problem when retrieving protocol-level TTL settings from the database \[ID_28023\]

When writing trend data to the database, in some cases, protocol-level TTL settings could not be retrieved. From now on, when TTL settings cannot be retrieved from the database, additional information will be added to the logs.

#### DataMiner Cube - Visual Overview: DCF connections of hidden shapes would incorrectly still be visible \[ID_28930\]

Up to now, DCF connections of shapes that were hidden because of a condition would incorrectly still be visible. From now on, any connection that is linked to a shape that is hidden will no longer be displayed.

Also, hidden shapes will no longer be taken into account when grouping shapes.

#### DataMiner Cube - Visual Overview: IDOfSelection session variable would not get updated when selected rows were removed or the selection was cleared in a ListView component \[ID_29057\]

When you select one or more rows in a ListView component, the IDs or GUIDs of the selected items are stored in the IdOfSelection session variable.

Up to now, when a selected row was removed or when the selection was cleared in any way, in some cases, the contents of the IdOfSelection session variable would not get updated.

#### NATS service would no longer start up after being reset when a DataMiner Agent was removed from the DMS \[ID_29075\]

In some cases, the NATS service would no longer start up after being reset when a DataMiner Agent was removed from the DMS.

#### DataMiner Cube - Trending: Extra data point would incorrectly be exported to CSV \[ID_29212\]

When you exported average trend data to a CSV file, in some cases, extra data points would incorrectly be added to the exported trend data.

#### Protocols: Problem with SLProtocol when the save attribute of a table parameter was incorrectly set to 'true' \[ID_29214\]

When, in a protocol.xml file, the save attribute of a table parameter was incorrectly set to “true”, in some rare cases, an error could occur in SLProtocol.

#### Dashboards app - Parameter feed: Problem with parameter indices in dashboard URLs \[ID_29242\]

In the URL of a dashboard, primary key and display key in parameter indices are by default separated by a forward slash character (“/”). In some cases, when display keys also contained that same character, parameter indices would be parsed incorrectly.

Also, when a dashboard URL containing a selection was refreshed, in some cases, part of that selection would be cleared.

#### Dashboards app - GQI: Colors set for exception values of numeric parameters would not get applied \[ID_29244\]

In the *Layout* tab of the Table component, the *Column filters* option allows you to highlight cells based on a condition. In some cases, colors set for exception values of numeric parameters with a range would not get applied.

Also, the *Column filters* option now allows you to highlight “Not initialized” values.

#### At DMA startup, NT_CLEAN_SUBSCRIPTION_FOR_STOPPED_ELEMENT would incorrectly be called before all elements were fully loaded \[ID_29257\]

When a DataMiner Agent was started in a DataMiner System, in some cases, errors would be logged due to NT_CLEAN_SUBSCRIPTION_FOR_STOPPED_ELEMENT being called before all element were fully loaded.

#### DataMiner Cube: No search results when using an element card search box on a system with an Elasticsearch database \[ID_29310\]

When using an element card search box on a system with an Elasticsearch database, in some cases, no search results would appear.

#### Automation: UIBuilder properties MaxWidth and MaxHeight would incorrectly not get applied to interactive Automation script pop-up windows \[ID_29361\]

In some cases, the UIBuilder properties “MaxWidth” and “MaxHeight” would incorrectly not get applied to interactive Automation script pop-up windows.

#### Incorrect data could be returned during a migration from MySQL to Cassandra \[ID_29385\]

Due to a problem with certain COM calls, in some cases, incorrect data could be returned during a migration from MySQL to Cassandra.

#### Jobs app: Problem when sorting on a field added to the default job section \[ID_29386\]

In some cases, an error could occur when you sorted the jobs list on a field that had been added to the default section.

#### Dashboards app: Input boxes would extend beyond the borders of the screen \[ID_29406\]

When configuring certain components, a number of input boxes would not resize correctly. Instead, they would extend beyond the borders of the screen.

#### Dashboards app - GQI: Filters would not be applied when requesting aggregated values from an Elasticsearch logger table \[ID_29439\]

In some cases, filters in GQI queries would not be applied when requesting aggregated values from an Elasticsearch logger table. This would cause the values to be aggregated over the entire table instead of a subset of that table.

#### Jobs app: Name of default job section would incorrectly be set to 'DefaultJobDomain' when the section was updated \[ID_29460\]

When the default section was updated, its name would incorrectly be changed to “DefaultJobDomain” instead of “DefaultJobSection”.

#### SLAnalytics: Problem when retrieving data from DVE elements \[ID_29464\]

Due to a problem when retrieving data from DVE elements, in some cases, trend prediction and pattern matching would not work for this type of elements.

#### DataMiner Cube - EPM: Children of the siblings of the selected object would incorrectly also be displayed \[ID_29465\]

Up to now, when the *ShowSiblings* option was combined with the *ShowChildren* option, the children of the siblings of the selected object would incorrectly also be displayed. From now on, only the children of the selected object will be displayed.

#### DataMiner Cube - Alarm Console: Problem when clicking the 'Alarm storm' button \[ID_29472\]

If alarm storm protection by delaying is activated, during an alarm storm you can click the red *Alarm storm* button in the alarm bar to open a new card with a list of the delayed alarms.

In some cases, when you clicked that button, an exception would be thrown and no alarms would be displayed.

#### Legacy Dashboards app - Trend component: Custom range values would be ignored when the time range of the chart was updated \[ID_29480\]

In the legacy Dashboards app, the “Custom low range” and “Custom high range” options of the Trend component would incorrectly be ignored whenever the time range of the chart was updated.

#### Dashboards app: Data item dragged onto a component would not appear in the component’s edit panel \[ID_29481\]

When you dragged a data item (e.g. the entire Elements dataset) onto a component, in some rare cases, that item would not appear in the component’s edit panel.

#### Dashboards app: Index feed would remain in status 'Loading' when an error occurred while fetching the indices \[ID_29487\]

When an error occurred while fetching the indices, in some cases, the index feed would remain in status “Loading”. From now on, when an error occurs while fetching the indices, the reason of the failure will be displayed.

#### SLLogCollector would incorrectly not take a dump when the temp folder did not exist \[ID_29500\]

In some cases, SLLogCollector would incorrectly not take a dump when the temp folder did not exist.

#### Mobile apps: Error 404 page would not list the 6th app \[ID_29521\]

When the DataMiner landing page listed 6 apps and you were redirected to an error 404 page due to an error with one of those apps, then the error 404 page would only list 5 apps.

#### DMA that was incorrectly cleaned after having been removed from a DMS would skip its initial synchronization when added to another DMS later on \[ID_29523\]

When a DataMiner Agent had been removed from the DataMiner System and was cleaned up incorrectly afterwards (e.g. by manually updating the DMS.xml file), in some cases, it would skip its initial synchronization when it was added to another DataMiner System later on.

#### Problem with SLASPConnection when processing the results of a GetAlarmHistory call \[ID_29525\]

In some cases, an error could occur in SLASPConnection when processing the results of a GetAlarmHistory call.

#### DataMiner Cube - Alarm Console: Blue footer bar had an incorrect dark blue color \[ID_29529\]

In some cases, the blue footer bar of the Alarm Console would have an incorrect dark blue color.

#### Baseline of standalone parameter would incorrectly be cleared when its condition had first been evaluated as true and then as false \[ID_29531\]

When relative or absolute monitoring was enabled on a standalone parameter of which the condition had first been evaluated as true and then as false, in some cases, the baseline of the parameter would incorrectly be cleared.

#### Problem with SLElement at DataMiner startup \[ID_29539\]

At DataMiner startup, in some rare cases, an error could occur in SLElement.

#### Dashboards app - GQI: Problem when executing a large query \[ID_29540\]

In some cases, the Dashboards app could become unresponsive when a large query was being executed.

#### Service & Resource Management: Problem loading functions.xml files \[ID_29551\]

When the first attempt to load a functions.xml file would fail, in some cases, no further attempts would incorrectly be made.

#### Problem when taking a backup of an Elasticsearch database after logging on with a password encrypted by DataMiner \[ID_29564\]

In some cases, it would not be possible to take a backup of an Elasticsearch database to which you had logged on using a password encrypted by DataMiner.

#### DataMiner Cube - Embedded Chromium web browser engine: Problems with scaling \[ID_29596\]

In some cases, the following problems could occur with regard to Chromium web browser controls:

- When opened in a window on a high-DPI monitor, they would be scaled twice and the image would not match the mouse cursor.

- When displayed in a window that was moved from one monitor to another, they would not adapt to the new DPI scale.

- When displayed on a high-DPI monitor, they were rendered at 100% DPI and then upscaled, resulting in an imperfect image.

#### SLNetComNotificationThread: Delay between notifications \[ID_29599\]

In SLNet, up to now, the SLNetComNotificationThread had a delay of 15 ms between notifica-tions. In cases where a large number of notifications had to be processed, the total delay could be significant.

#### Incorrect in-memory state in SLDMS when removing an agent from a DMS \[ID_29612\]

When a DMA was removed from a DataMiner System, in some cases, the memory of the SLDMS process would be left in an incorrect state.

This could prevent actions like initial synchronization from working when setting up a new DMS or a new Failover environment that included the agent in question.

#### Elasticsearch: Problem when trying to create a customdata object \[ID_29617\]

When a customdata object had to be created in an Elasticsearch database, in some rare cases, multiple DMAs in the DMS would try to create the same table. This would cause an exception to be thrown on some of those DMAs.

#### DataMiner Cube - Data Display: Problem with dynamic parameter ranges \[ID_29625\]

When a protocol updated parameter ranges using an NT_UPDATE_DESCRIPTION_XML call, in some cases, the ranges could be reverted to an old value, especially when the PageUnloadOnNavigatingAway option was enabled or when the ranges belonged to parameters located on pages that had not yet been visited.

#### Problem with SLSNMPAgent \[ID_29629\]

In some cases, an error could occur in SLSNMPAgent when dealing with issues caused by not being able to fetch XML cookies from SLDataMiner.

#### Problem in SLDataMiner when reloading virtual functions \[ID_29641\]

In some cases, an error could occur in SLDataMiner when a functions.xml file was reloaded.

#### DataMiner Cube - Element Connections: Duplicated non-virtual parameters would be added twice when they referred to a destination parameter \[ID_29645\]

In the Element Connections app, in some cases, duplicated non-virtual parameters would be added twice when they referred to a destination parameter.

#### Dashboards app - Line chart component: Zero values would incorrectly be exported to CSV as null values \[ID_29660\]

When trend data was exported to a CSV file, in some cases, zero values would incorrectly be exported as null values.

#### DataMiner Cube - Spectrum Analysis: Start, stop and center frequencies incorrectly displayed without decimals \[ID_29661\]

When you opened a Spectrum element card, in some rare cases, the start, stop and center frequencies would incorrectly be displayed without decimals.

#### DataMiner Cube: No views visible in the Surveyor after clicking the 'Start' button on the message box saying that the agent was not running \[ID_29665\]

When you opened DataMiner Cube and clicked Start on the message box saying that the agent was not running, the agent would start up but, in some cases, no views would be visible in the Surveyor.

#### Problem when restarting a DMA without stopping SLNet \[ID_29667\]

When you restarted a DataMiner Agent without stopping SLNet, in some rare cases, an exception could be thrown.

#### DMS Alerter would start to consume an excessive amount a memory when configured to play a sound when the alarm in the pop-up matched a filter \[ID_29672\]

When you had configured Alerter to play a sound when the alarm displayed in the pop-up balloon matched a filter, in some cases, Alerter would start to consume an excessive amount a memory.
