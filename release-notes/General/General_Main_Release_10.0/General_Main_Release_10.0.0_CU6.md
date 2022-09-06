---
uid: General_Main_Release_10.0.0_CU6
---

# General Main Release 10.0.0 CU6

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Data forwarded using an AlarmSocket or a PollSocket will now be encoded using UTF-8 \[ID_27059\]

From now on, when DataMiner forwards data using an AlarmSocket or a PollSocket, that data will be encoded using UTF-8 instead of the ANSI code page of the DataMiner Agent.

> [!NOTE]
> From now on, all data sent to a PollSocket must also be encoded using UTF-8.

#### DataMiner Installer: Improved error handling when unable to connect to Cassandra \[ID_27096\]

During a DataMiner installation, in some cases, an error could be thrown when it took more than 2 minutes to connect to the Cassandra database.

Now, the connection timeout has been increased from 2 to 5 minutes. Also, fewer error messages will be logged while trying to connect to the Cassandra database.

#### DataMiner Cube - Data Display: Enhanced services can now include other enhanced services \[ID_27109\]

From now on, it is possible for enhanced services to include other enhanced services.

#### StandAloneBpaExecutor tool now shows the full DLL path and the BPA version \[ID_27134\]

When, in the StandAloneBpaExecutor tool, you select a DLL file, it shows the BPA information for that specific file. From now on, it will show the full path of the selected DLL file as well as the BPA version.

#### Improved performance when subscription is added on element level + possibility to set number of records in protocol cache \[ID_27183\]

Performance has improved when a subscription is added on element level, specifically if the subscription contains elements with different protocols. This will for instance ensure that when multiple cards are opened to Visual Overview pages, parameters will be displayed more quickly.

In addition, it is now possible to change the number of records that can be contained in the protocol cache. You can do so using the SLNetClientTest tool by going to *Options* > *SLNet Options*, selecting *protocolCacheMru* in the drop-down box, changing the value where necessary and clicking *OK*. However, do not change this value without checking with Skyline for advice first, as an incorrect setting can cause serious issues.

> [!WARNING]
> The DataMiner SLNetClientTest tool is an advanced system administration tool that should be used with extreme care (*C:\\Skyline DataMiner\\Files\\SLNetClientTest.exe*).

#### Improved logging for view tables in SLElement log \[ID_27192\]

Logging for view tables in the SLElement log file has been improved. Certain timing information will now only be included once a warning threshold has been exceeded, so that there is less unnecessary log information for view tables.

#### DataMiner Cube - System Center: Only changed fields will be sent to the DMA when changing information in Agents \>System \[ID_27224\]

When, in *System Center*, you click *Save* after changing some of the fields on the *System* tab of the *Agents* section, from now on, only the fields that were changed will be sent to the DataMiner Agent.

#### Client applications will now always connect to a DataMiner Agent via .NET Remoting \[ID_27237\]

Up to now, client applications could use either .NET Remoting or Web Services to connect to a DataMiner Agent. However, as Web Services Enhancements (WSE) for Microsoft .NET is now deprecated, from now on the only way to connect to a DataMiner Agent is by using .NET Remoting.

#### BPA tests: New BpaExecuteContext methods to send messages to SLNet \[ID_27261\]

The BpaExecuteContext object, which BPA tests receive as input, has been extended with methods to send messages to SLNet, allowing the tests to fetch data without manually having to set up a connection:

- DMSMessage\[\] SendSLNetMessage(DMSMessage message)
- DMSMessage\[\] SendSLNetMessages(DMSMessage\[\] message)
- DMSMessage SendSLNetSingleResponseMessage(DMSMessage message)

#### Cube launcher tool: Downgrade support \[ID_27380\]

When you downgraded a DataMiner Agent that came with the Cube launcher tool (i.e. DMS version10.0.9 or newer) to an earlier version without Cube launcher tool (i.e. DMS version 10.0.8 or older), up to now, the Cube launcher tool would incorrectly try to connect to the downgraded agent using the newer Cube version. From now on, after an agent is downgraded, the Cube launcher tool will by default connect to the agent using the matching Cube version.

### Fixes

#### SLDMS notification thread blocked by LDAP refresh \[ID_26547\]

In some cases, if refreshing LDAP took a long time, it could occur that this blocked the SLDMS notification thread.

#### 'Authentication took too long' error added to SLNet logging when trying to log on to DataMiner using an incorrect user name and password \[ID_26586\]

When you tried to log on to DataMiner using an incorrect user name or password, in some cases, an “Authentication took too long” error would be added to the SLNet logging after about 30 seconds.

#### Incorrect run-time errors of type 'SLDMS ConnectionThread Problem' would appear when an agent responded slower than expected \[ID_26596\]

When a particular agent in a DataMiner System responded slower than expected, in some cases, incorrect run-time errors of type “SLDMS ConnectionThread Problem” could start to appear on other agents in the same DataMiner System.

#### Failover: Problem when the agents had a different cluster name \[ID_26683\]

Up to now, when the two DataMiner Agents in a Failover setup had a different cluster name, in some cases, the backup agent could end up remaining completely empty. Although, at first, everything would appear correct in the UI, the problem would become apparent after a switch-over.

In such a scenario, from now on, the active agent will show the following “DataMiner Failover Status” notice:

```txt
Failover agent xxx.xxx.xxx.xxx is experiencing sync issues. Check the Failover status.
```

Also, the Failover status window will show a red color and will indicate that the configuration is invalid with reason “Cluster name of agents doesn't match”.

#### DataMiner Cube - Alarm Console: Correlation base alarms not shown in filtered alarm tab when Correlation tracking was disabled \[ID_26817\]

When a filtered alarm tab page contained a correlated alarm, in some cases, the base alarms would not be shown when Correlation tracking was disabled.

#### DataMiner Cube - Settings: Alarm tab page of type 'sliding window' added for a particular group would not be shown to the users in that group \[ID_26902\]

When, in the settings for a particular group, you created a new alarm tab page of type “sliding window” and then changed the size of the sliding window, in some cases, the tab page would not be shown to the users in that group, even when the Enforce Alarm Console pages option was enabled.

#### DataMiner Cube - Alarm templates: Problem when duplicating table column rows in an alarm template \[ID_26985\]

When you duplicated a table column row in an alarm template, in some cases, unsaved changes made to the Info column would not be duplicated correctly.

Also, when you exported a duplicated table column row to a CSV file before saving the changes, in some cases, the Parameter name column in the CSV file would not contain the table name.

#### Problem when installing Indexing Engine on a system with a remote Cassandra database \[ID_27005\]

When you tried to install Indexing Engine on a system with a remote Cassandra database, in some cases, an error could be thrown when the recommendations were being retrieved.

#### Problem when trying to connect to an IPC port after installing Indexing Engine on a remote node \[ID_27014\]

After installing Indexing Engine on a remote node, in some cases, DataMiner would not be able to start up as it would fail to connect to an IPC port.

#### DataMiner Cube - Spectrum Analysis: Trace coloring problem when rapidly switching between spectrum element cards \[ID_27020\]

When you rapidly switched between two spectrum element cards, in some cases, the color of the background, the grid lines, the grid text and the trace of a spectrum trace would incorrectly turn gray or black instead of the color saved in the spectrum preset display settings.

#### DataMiner Cube: Null reference exception when closing alarm tab \[ID_27044\]

In some cases, a null reference exception could be thrown when you closed an alarm tab in the Alarm Console.

#### DataMiner Cube - Alarm Console: Service names visible even to user without access to those services \[ID_27050\]

When a user viewed an alarm that affected a number of services, up to now, the Services column would incorrectly list all impacted services, including those to which the user in question did not have access. From now on, the Services column will only list the services to which the user has access. However, the Service impact column will continue to show the total amount of affected services.

> [!NOTE]
> When you open an alarm in an alarm card, the list of impacted services will now also only contain the services to which you have access.

#### DataMiner Cube - Visual Overview: Alarm color would not be updated in situations where the alarm state changed but the parameter value did not \[ID_27057\]

When text like “\[param:...\]\|Alarm” was specified in a shape data item of type Parameter, in some cases, the alarm color would not be updated correctly while the Visio page was open, especially in situations where the alarm state changed but the parameter value did not.

#### Unexpected behavior if condition for inclusion in service or redundancy switching contained no primary key or display key \[ID_27067\]

Previously, if a condition was defined for the inclusion of an element in a service or for redundancy switching and this condition did not contain a primary key or display key, this could cause unexpected behavior. Now if no primary key or display key is included in a condition, this will be interpreted as a wildcard, and any available row will be considered.

#### DataMiner Cube - Visual Overview: Children of element shapes with an Info placeholder in their shape text would not be displayed \[ID_27095\]

In some cases, child shapes of Element shapes with an Info placeholder (e.g. \[NAME\]) in their shape text would incorrectly not be displayed.

#### DataMiner Cube - Alarm Console: Audible alert would incorrectly be played again after you restarted an element \[ID_27098\]

If, in the Alarm Console, you had configured that an audible alert has to be played as long as not all the alarms in a certain alarm tab page have been read, in some cases, even when all alarms in the alarm tab page in question had been read, the alert would incorrectly be played again when an element was restarted.

#### DataMiner Cube: Not possible to zoom or pan with keyboard in Visual Overview \[ID_27101\]

In some cases, it could occur that it was not possible to zoom and pan using the keyboard in Visual Overview.

#### Problem when reloading Cube browser app \[ID_27103\]

If the Cube browser application was reloaded, it could occur that it did not fully load but instead kept displaying "Connected”.

#### DataMiner Cube - Data Display: Table query would incorrectly not be updated when an initially hidden column of a filtered partial table was unhidden \[ID_27104\]

When an initially hidden column of a filtered partial table was unhidden, in some cases, the table query fetching the data from the server would incorrectly not be updated to include the unhidden column.

#### DataMiner Cube - Spectrum Analysis: Not possible to view average, minimum or maximum trace unless current trace is displayed \[ID_27127\]

When viewing a spectrum analyzer graph, it could occur that it was not possible to display the average, minimum or maximum trace if the current trace was not displayed.

#### Service & Resource Management: Missing LinkerTableEntries in resources after DMA restart \[ID_27139\]

After a DMA was restarted, it could occur that LinkerTableEntries were missing in SRM resources.

#### DataMiner Cube: No longer possible to click below or above a scrollbar thumb \[ID_27149\]

In some cases, it would no longer be possible to click inside a scrollbar track (i.e. below or above the scrollbar thumb).

#### DataMiner Cube - Visual Overview: Memory leak in SLHelper \[ID_27162\]

The SLHelper process keeps a set of actions in memory to be able to track what action should be taken when a Visio shape is clicked. In some cases, that set of actions would never get cleared and new actions would be added each time a Visio file was updated.

#### DataMiner Cube: No context menu would appear when right-clicking a suggestion in the header search box after right-clicking the 'Advanced search' button \[ID_27166\]

When, in the Cube header bar, you first right-clicked the *Advanced search for...* option at the bottom of the suggestions list, and then right-clicked any of the listed suggestions, no context menu would appear.

#### DataMiner Cube - Visual Overview: Masked alarm color not shown for cells displayed in Children shape \[ID_27172\]

If cells of a table row were displayed in a Children shape in Visual Overview, it could occur that masked cells did not display the masked alarm color.

#### DataMiner Cube: Custom icon visualization not working for list view components \[ID_27173\]

In list view components, for example in the Bookings app, in the Services app or in ListView shapes in Visual Overview, it was no longer possible to visualize the content of a column as a custom icon. This is now again possible for booking, service and element columns as well as for booking, service and element property columns. Note that this functionality relies on Automation scripts to provide the icon library and column value/icon mapping.

#### DataMiner Cube - Scheduler app: Problem with drag-and-drop in timeline tab \[ID_27174\]

In the *Timeline \> Events* tab, in some cases, it would no longer be possible to drag a profile onto the timeline.

#### Problem with SLAutomation when a ThreadAbortException was thrown in a script while the thread was not actually aborted \[ID_27187\]

When a ThreadAbortException was thrown in an Automation script while the thread running the script was not actually aborted, in some cases, an error could occur in SLAutomation.

#### Data in DVE child element not updated correctly \[ID_27189\]

When a data table was not fully exported to a DVE child element, but only a few columns were exported as standalone parameters of the DVE child element, including the foreign key column of the DVE table, it could occur that data were not updated correctly.

#### DataMiner Cube: No arrow icons would be displayed in partial tables when behavioral anomaly detection was enabled \[ID_27201\]

When behavioral anomaly detection was enabled, in some cases, only standard trend icons but no arrow icons would be displayed in partial tables.

#### Failover configuration deleted when it should only have been disabled \[ID_27252\]

When Failover was disabled, it could occur that the Failover configuration was deleted from the offline Agent even if you had selected to only disable the configuration. Now this will only happen if you select to delete the configuration.

#### DataMiner Cube - Visual Overview: Incorrect alarm coloring DataDisplayPage shape \[ID_27270\]

When a shape in Visual Overview was linked to a Data Display page, it could occur that it showed the alarm color of the element instead of that of the Data Display page.

#### Problem in SLNet when calculating view alarm states \[ID_27271\]

In some rare cases, a problem could occur in the SLNet process when the alarm states of views were calculated.

#### DataMiner Cube - EPM: Problem when selecting a node in another chain \[ID_27278\]

When you opened an EPM node in another chain via the context menu of that node, in some cases, the filters in the destination chain would be empty when the filter table did not exactly match the corresponding filter table in the source chain.

Also, a number of other (minor) enhancements and fixes have been done:

- The positioning of the selected node in the diagram has been improved, the minimum width of the diagram nodes has been increased, and selection filters without links have been better aligned.

- When opening a node in a chain that had not yet been opened, up to now, some of the filters could be empty.

#### Problem with SLLog \[ID_27317\]

In some cases, the SLLog process could cause a problem or memory leak.

#### Problem with blinking status of service children \[ID_27319\]

Up to now, a service child would always blink when its parent element blinked. As elements can be partially included in a service, in some cases, this was not correct.

From now on, whether a service child blinks will depend on the included parameters.

#### Failover: Incorrect alarm event of type 'properties changed' would be generated for alarms with multiple identical view properties \[ID_27374\]

When, in a Failover setup, an alarm had multiple identical view properties defined, in some cases, an incorrect alarm event of type “properties changed” would be generated each time a switchover occurred.

#### Service & Resource Management: Problem when removing a ServiceResourceUsageDefinition from the ResourcesInReservationInstance list \[ID_27385\]

When you used the Remove() method to remove a ServiceResourceUsageDefinition from the ResourcesInReservationInstance list, in some cases, the incorrect ServiceResourceUsageDefinition would be removed.
