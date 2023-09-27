---
uid: General_Main_Release_10.0.0_CU14
---

# General Main Release 10.0.0 CU14

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Client machines running Cube now require Microsoft .NET Framework v4.6.2 \[ID_25309\]

Client machines running DataMiner Cube now require Microsoft .NET Framework 4.6.2.

#### DataMiner Cube - Visual Overview: Viewport and Navigate variables of a Resource Manager timeline will now be read and applied upon opening \[ID_29299\]

When, in Visual Overview, you create a shape that should display the Resource Manager timeline by adding a shape data field of type Component set to “Reservations” or “Bookings”, the Navigate and Viewport session variables allow you to control navigation and zooming within the timeline.

- The Navigate variable can be used to automatically navigate to a specified time range.
- The Viewport variable can be used to zoom to a specified time range and to visualize the time range to which you zoomed manually.

From now on, both variables can be processed immediately upon opening a visual overview with a Resource Manager timeline.

- Setting the Navigate variable using a page-level InitVar will make the timeline navigate immediately to the chosen time slot and clear the Navigate variable.
- The Viewport variable will always be read upon opening the Resource Manager timeline. In other words, if a session variable already exists in the scope in question (e.g. when the time line was opened while using the global variable scope), the timeline will automatically zoom to the last-known view port.

> [!NOTE]
> The Navigate variable will be processed after the Viewport variable.

#### Mobile apps - Visual Overview: Linking shapes to webpages \[ID_29444\]

When you link a shape to a webpage using a shape data field of type *Link*, that page will be opened each time a user clicks that shape. This feature will now also work on visual overviews in mobile apps (e.g. Dashboards, Monitoring, etc.).

#### Enhancements made to the method that decides which subscriptions to forward to other agents in the DMS \[ID_29490\]

A number of enhancements have been made to the method that decides which subscriptions to forward to other agents in the DMS. These enhancements will considerably reduce SLNet CPE usage, especially on systems with a large number of active subscriptions.

#### Visual Overview: New option to keep real-time charts from showing exception values in labels \[ID_29504\]

In the *ParametersOptions* shape data field for a parameter chart showing real-time values, you can now use the *VisualizeExceptions=false* option to keep the display value for exception values from being shown in a label.

| Shape data field  | Value                                                                    |
|-------------------|--------------------------------------------------------------------------|
| ParametersOptions | VisualizeExceptions=true (default behavior)<br>VisualizeExceptions=false |

#### Notice will now appear in the Alarm Console when the initial synchronization of a DMA fails \[ID_29532\]

When, after adding a DMA to the DataMiner System, the initial synchronization of that agent fails, a notice will now appear in the Alarm Console.

Also, a number of protective measures have been added to prevent an agent that has not yet completed its full synchronization from being synchronized at midnight.

#### DVE elements notifications no longer added to SLNetCOM Notification Stack \[ID_29601\]

On DataMiner startup and hourly at report generation, a batch of notifications gets forwarded between DataMiner modules, ending up on the SLNetCOM Notification Stack. Up to now, two such notifications were also forwarded for every DVE element. These will now no longer be sent.

#### SLNetCom notification thread will now only start ignoring messages after a grace period has passed \[ID_29631\]

When the SLNetCom notification thread reaches a certain threshold (defined by MaxStackSLNetCOMNotifications), the DMA assumes something is wrong and stops processing messages, requiring a restart. However, in some cases, this threshold can be reached even when nothing is wrong.

In order to prevent this, a grace period has now been introduced. When the number of SLNetCom notification messages reaches a peak, the DMA will only start ignoring messages when the number of messages on the stack is equal or greater than the threshold during the entire grace period.

Using the SLNetClientTest tool, you can specify this grace period by configuring the SLNetCOMNotificationsStackExceedsThresholdGracePeriodInMin setting (default value: 1 minute).

#### DataMiner Cube - Element Connections app: Mechanism used to delete connections between a destination parameter and a non-virtual source parameter has been optimized \[ID_29653\]

Due to a number of enhancements made to the Element Connections app, the mechanism used to delete connections between a destination parameter and a non-virtual source parameter has been optimized.

### Fixes

#### Problem with SLManagedScripting due to a locking issue \[ID_26139\]

In some rare cases, threads could get stuck in SLScripting due to a locking issue.

#### Alarm filter combining element and table column filter not working for history alarms tab \[ID_26797\]

If a history alarms tab was filtered using an element filter combined with a table column filter, it could occur that no alarms were displayed.

#### Problem when retrieving protocol-level TTL settings from the database \[ID_28023\]

When writing trend data to the database, in some cases, protocol-level TTL settings could not be retrieved. From now on, when TTL settings cannot be retrieved from the database, additional information will be added to the logs.

#### DataMiner Cube - Visual Overview: DCF connections of hidden shapes would incorrectly still be visible \[ID_28930\]

Up to now, DCF connections of shapes that were hidden because of a condition would incorrectly still be visible. From now on, any connection that is linked to a shape that is hidden will no longer be displayed.

Also, hidden shapes will no longer be taken into account when grouping shapes.

#### DataMiner Cube - Visual Overview: IDOfSelection session variable would not get updated when selected rows were removed or the selection was cleared in a ListView component \[ID_29057\]

When you select one or more rows in a ListView component, the IDs or GUIDs of the selected items are stored in the IdOfSelection session variable.

Up to now, when a selected row was removed or when the selection was cleared in any way, in some cases, the contents of the IdOfSelection session variable would not get updated.

#### DataMiner Cube - Resources app: Capacity parameter values would incorrectly be stored without decimals \[ID_29082\]

Up to now, in the Resources app, capacity parameter values would incorrectly be stored without decimals.

#### DataMiner Cube - Trending: Extra data point would incorrectly be exported to CSV \[ID_29212\]

When you exported average trend data to a CSV file, in some cases, extra data points would incorrectly be added to the exported trend data.

#### Protocols: Problem with SLProtocol when the save attribute of a table parameter was incorrectly set to 'true' \[ID_29214\]

When, in a protocol.xml file, the save attribute of a table parameter was incorrectly set to “true”, in some rare cases, an error could occur in SLProtocol.

#### At DMA startup, NT_CLEAN_SUBSCRIPTION_FOR_STOPPED_ELEMENT would incorrectly be called before all elements were fully loaded \[ID_29257\]

When a DataMiner Agent was started in a DataMiner System, in some cases, errors would be logged due to NT_CLEAN_SUBSCRIPTION_FOR_STOPPED_ELEMENT being called before all element were fully loaded.

#### Data would not get written to the backup agent after configuring a Failover setup on a system with MySQL databases \[ID_29267\]

When a Failover setup is configured on two DataMiner Agents with a MySQL database, after synchronizing the two databases, all new data should be written to both these databases. However, in some cases, new data would incorrectly not be written to the backup agent until after the primary agent had been restarted.

#### Automation: UIBuilder properties MaxWidth and MaxHeight would incorrectly not get applied to interactive Automation script pop-up windows \[ID_29361\]

In some cases, the UIBuilder properties “MaxWidth” and “MaxHeight” would incorrectly not get applied to interactive Automation script pop-up windows.

#### Dashboards app: Input boxes would extend beyond the borders of the screen \[ID_29406\]

When configuring certain components, a number of input boxes would not resize correctly. Instead, they would extend beyond the borders of the screen.

#### SLAnalytics: Problem when retrieving data from DVE elements \[ID_29464\]

Due to a problem when retrieving data from DVE elements, in some cases, trend prediction and pattern matching would not work for this type of elements.

#### DataMiner Cube - EPM: Children of the siblings of the selected object would incorrectly also be displayed \[ID_29465\]

Up to now, when the *ShowSiblings* option was combined with the *ShowChildren* option, the children of the siblings of the selected object would incorrectly also be displayed. From now on, only the children of the selected object will be displayed.

#### DataMiner Cube - Alarm Console: Problem when clicking the 'Alarm storm' button \[ID_29472\]

If alarm storm protection by delaying is activated, during an alarm storm you can click the red *Alarm storm* button in the alarm bar to open a new card with a list of the delayed alarms.

In some cases, when you clicked that button, an exception would be thrown and no alarms would be displayed.

#### Legacy Dashboards app - Trend component: Custom range values would be ignored when the time range of the chart was updated \[ID_29480\]

In the legacy Dashboards app, the “Custom low range” and “Custom high range” options of the Trend component would incorrectly be ignored whenever the time range of the chart was updated.

#### SLLogCollector would incorrectly not take a dump when the temp folder did not exist \[ID_29500\]

In some cases, SLLogCollector would incorrectly not take a dump when the temp folder did not exist.

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

#### Service & Resource Management: Problem loading functions.xml files \[ID_29551\]

When the first attempt to load a functions.xml file would fail, in some cases, no further attempts would incorrectly be made.

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
