---
uid: General_Main_Release_10.0.0_CU5
---

# General Main Release 10.0.0 CU5

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### DataMiner Installer will now automatically select a checkbox to create an additional DataMiner user when not being executed by a user with administrative privileges \[ID_25414\]

From now on, if DataMiner Installer is not being executed by a user with administrative privileges, it will automatically select a checkbox to add the current user to the DataMiner Administrators group. This will ensure that at least one user account is available to log in to DataMiner when the installation has finished.

#### Enhanced communication between agents using HTTP and agents using HTTPS \[ID_26122\]

A number of enhancements have been made with regard to inter-agent communication within a DataMiner System, especially between agents using HTTP and agents using HTTPS.

#### BPA files will now be synchronized among all agents in a DataMiner System \[ID_26360\]

Files related to Best Practice Analysis (BPA) tests will now be synchronized among all agents in a DataMiner System.

#### Element fields now accept pipe characters and tab characters \[ID_26425\]

When adding or updating an element, it is now allowed to enter pipe characters (“\|”) and tab characters in the fields of that element.

> [!NOTE]
>
> - By default, DataMiner Cube will automatically replace tab characters by spaces.
> - Tab characters in port settings could cause problems when exporting or importing to or from a CSV file.

#### Mobile Gateway: Text messages can now contain special characters like '&' \[ID_26449\]

When DataMiner is configured to use an IP-based cell phone modem (e.g. SMSEagle), it communicates with the device via HTTP GET requests, passing values as ampersand-delimited parameters in the URL.

Up to now, when DataMiner sent a text message containing an ampersand character (“&”), the message would be cut off because the ampersand was incorrectly interpreted as a delimiter. From now on, all text messages will be URL encoded.

#### DataMiner Cube - Failover: When you chose to disable the Failover configuration, it is now also possible to select 'Cancel' \[ID_26509\]

In the Failover configuration window, up to now, when you chose to disable the Failover configuration, you were only able to select *Yes* or *No*. From now on, it is also possible to select *Cancel*.

#### DataMiner Cube - Service & Resource Management: Users will now clearly be notified when trying to configure or manage service profiles when no Indexing Engine is installed \[ID_26534\]

Since DataMiner 10.0.0, service definitions and service profiles can only be used on systems with an Indexing Engine. From now on, when no Indexing Engine is installed, DataMiner Cube will clearly indicate that it is not possible to configure service profiles in the Profiles app nor to manage them in the Services app.

#### Security checks for local connections between an SLxxx module and SLNet \[ID_26544\]

For local connections between an SLxxx module (e.g. SLDMS) and SLNet, security checks have been established. A security token will be generated and verified for each of the messages that are sent.

#### Automation: DataMiner will now check whether a parameter’s set range has not been changed dynamically \[ID_26574\]

When a parameter is set, from now on, DataMiner will check whether the set range of the parameter in question has not been changed dynamically (e.g. by an Automation script).

#### DataMiner Cube - Automation: All parameters will now be aligned vertically \[ID_26665\]

When creating or updating an Automation script in the Automation app, the parameters will now all be aligned vertically.

#### Enhanced performance when notifying SLElement of service updates \[ID_26674\]

Due to a number of enhancements, overall performance has increased when notifying SLElement of service updates.

#### DataMiner Cube - System Center: 'Include SLNet' checkbox removed from restart confirmation window \[ID_26685\]

When, in the *Agents* section of *System Center*, you clicked *(Re)start* to restart a DataMiner Agent, up to now, it was possible to select the *Include SLNet* checkbox in the confirmation window.

This checkbox has now been removed.

#### DataMiner Cube - Visual Overview: New option to show table name in parameter control shape \[ID_26694\]

Up to now, a parameter control displaying a parameter value retrieved from a table would by default also show the name of that table. From now on, this will no longer be the case.

If you want a parameter control to also show the name of the table, then specify the “ShowTableName=true” option in the *ParameterControlOptions* data field of the parameter control shape.

| Shape data field        | Value              |
|-------------------------|--------------------|
| ParameterControlOptions | ShowTableName=true |

#### DataMiner Cube: Property values in Custom tab of Properties window will now be prevented from updating automatically when a user is manually editing property values \[ID_26825\]

The values of the custom properties listed in the *Custom* tab of a *Properties* window are constantly being updated in real time. As this would sometimes cause problems when a user was manually updating one of those properties, from now on, real-time updates of custom properties listed in the *Custom* tab of the *Properties* window will be suspended as long as a user is manually editing property values in that same tab.

#### DataMiner Cube - Alarm Console: Enhanced performance when closing alarm tabs \[ID_26826\]

Due to a number of enhancements, overall performance has increased when closing an alarm tab, especially when all alarms in that tab are selected.

#### DataMiner Cube -Trending: Enhanced retrieval of histogram intervals \[ID_26833\]

A number of enhancements have been made to the way in which histogram intervals are retrieved.

#### DataMiner Cube - System Center: Enhanced saving of backup settings \[ID_26858\]

A number of enhancements have been made to the way in which the backup settings are saved in the *Backup* section of *System Center*.

#### Alarm template information events no longer generated upon element/DMA restart \[ID_26862\]

Previously, when an alarm template was configured to generate information events for specific values, these information events would also be generated each time the element or the DMA restarted. Now such information events will only be generated at runtime.

#### SLLogCollector now targets Microsoft .NET Framework 4.6.2 \[ID_26888\]

SLLogCollector now targets Microsoft .NET Framework 4.6.2.

### Fixes

#### Credential library: Problem with passwords having been encrypted multiple times \[ID_24201\]

In the credential library, in some cases, passwords would incorrectly be encrypted multiple times.

Also, in some cases, an exception could be thrown when you tried to edit an existing library credential.

#### Problem with spectrum session presets reverting to the default settings \[ID_26043\]

After restarting a DMA, in some cases, spectrum session presets could revert to the default settings if a card was open in a Cube connected through another DMA.

#### After a hotfix installation, the version number in VersionHistory.txt would be updated incorrectly \[ID_26067\]

After a hotfix installation, in some cases, the version number in the VersionHistory.txt file would incorrectly be updated with the word “Hotfix” instead of the hotfix version string containing the detailed version information (e.g. “HF_10.0.7.0(CU0)\_20200520-135714”).

#### MySQL: Problem with delete queries trying to delete trend records for elements that were not being trended \[ID_26085\]

On systems with a MySQL database, in some cases, a delete query would incorrectly try to delete trend records for an element that was not being trended.

#### DataMiner Cube - Alarm Console: 'Earlier this month' and 'Last month' were sorted incorrectly \[ID_26209\]

When, in the Alarm Console, you sorted and grouped alarms by Time/descending, the “earlier this month” group would incorrectly be sorted after the “last month” group (and vice versa when sorted and grouped by Time/ascending).

#### Problem when restoring a DataMiner backup package containing a database file that took a long time to restore \[ID_26210\]

When you restored a DataMiner backup package (.dmbackup) containing a database file that took more than 30 minutes to restore, in some cases, the restore of the DataMiner backup package would incorrectly continue before the restore of the database file had finished.

#### Problem when using the IsMatrixCrosspointConnected method in an Automation script \[ID_26276\]

When, in an Automation script, the *IsMatrixCrosspointConnected* method was used before a matrix point had been connected, in some cases, an exception could be thrown.

#### DataMiner Cube - Visual Overview: Shapes with a ParameterControl shape data field would incorrectly not take into account the NoAutoScale option \[ID_26283\]

When a Visio page with the NoAutoScale option contained shapes of which the ParameterControl shape data field was set to a value containing dynamic placeholders, in some cases, those shapes would incorrectly not take into account the NoAutoScale option.

#### Problem with SLPort when polling smart-IP elements \[ID_26304\]

In some cases, a memory issue could occur in SLPort when polling smart-IP elements.

#### Some files would not immediately get synchronized when creating a new DataMiner System \[ID_26359\]

When you created a new DataMiner System, in some cases, certain existing files would not get synchronized immediately. They would incorrectly only get synchronized after restarting one of the DataMiner Agents and awaiting the first midnight synchronization.

#### Problem with SLAutomation when saving a script containing a long line \[ID_26367\]

When you saved an Automation script that contained a long line, in some cases, an error could occur in all SLAutomation processes in the DataMiner System.

#### Source OID of forwarded aggregation alarm would not contain 'Aggregation' \[ID_26369\]

When an aggregation alarm was forwarded, in some cases, OID 1.3.6.1.4.1.8813.1.1.2.2.11 (Source) would incorrectly not contain “Aggregation”.

#### Run-time errors on elements that were partially included in a service \[ID_26376\]

In some cases, processing service additions, service updates and dynamic service inclusions would cause run-time errors on elements that were partially included in a service.

Also, service impact indications could in some cases be displayed incorrectly.

#### Unnecessary DataMiner restart after DataMiner startup with process in 'Suspended' state \[ID_26407\]

When DataMiner started up while a DataMiner process was still in "Suspended" state, this could cause an unnecessary DMA restart later.

#### Alarms associated with an element would be displayed incorrectly after an element restart \[ID_26410\]

When an element was restarted while alarms associated with that element were being processed, in some cases, alarms would incorrectly be duplicated or would be displayed incorrectly after the restart.

#### Problem when using SNMPv3 credentials from the credential library in conjunction with a non-primary SNMP port \[ID_26435\]

In some cases, an element startup error could be thrown when using SNMPv3 credentials from the credential library in conjunction with a non-primary SNMP port.

#### DataMiner Agent not restarting after processes were stopped \[ID_26440\]

To prevent an Agent from automatically restarting when it is stopped, up to now, DataMiner did not automatically restart when more than 2 processes stopped within a 2-minute timespan. However, this could cause problems if more than 2 processes stopped but the Agent did not stop completely. To prevent this, the Agent will now be restarted when at least one of the following processes is still running: SLDataMiner, SLElement, SLDMS and SLNet.

#### Real-time trend data requested by sending a GetTrendDataMessage would incorrectly contain additional data points beyond the specified end time \[ID_26473\]

When real-time trend data was requested by sending a GetTrendDataMessage, in some cases, the response would incorrectly contain additional data points beyond the specified end time.

#### Problem due to duplicate IP addresses in DMS.xml \[ID_26480\]

In some cases, an error could occur because the DMS.xml file on a particular DataMiner Agent had the same IP address listed multiple times. From now on, when a DMS.xml file contains duplicate IP addresses, all but the first occurrence will be ignored.

#### Files in C:\\Skyline DataMiner\\ root folder would not be taken into account when processing FilesToLeave.txt during a DataMiner upgrade \[ID_26489\]

When the FilesToLeave.txt file was processed during a DataMiner upgrade, up to now, the files in the C:\\Skyline DataMiner\\ root folder would incorrectly not be taken into account.

#### Failover: Agent configured to only be switched over manually would incorrectly be switched back to offline automatically in case of failing heartbeats \[ID_26490\]

In some cases, an agent configured to only be switched over manually would incorrectly be switched back to offline automatically in case of failing heartbeats.

#### DataMiner Cube - Alarm Console: Problem when a sliding window alarm tab was present when clearing alarms correlated by the alarm storm prevention mechanism \[ID_26494\]

When too many alarms are generated for the same parameter, an alarm storm prevention mechanism is triggered, which groups all those alarms into one correlated alarm. When those alarms got cleared, in some cases, an error could occur when an alarm tab of type “sliding window” was present in the Alarm Console.

#### Automation: Engine#FindElement(null) call would incorrectly return a random element \[ID_26499\]

When using an Engine#FindElement(null) call in an Automation script, in some cases, a random Element object would incorrectly be returned. From now on, NULL will be returned instead.

#### DataMiner Cube - Documents app: Problem when trying to delete a file after saving it locally \[ID_26500\]

When, in the Documents app, you tried to delete a document after saving it to your client computer, in some cases, the document would not disappear from the list and would remain in a “Deleting” state.

#### Memory leak in SLNet \[ID_26507\]

In some cases, the SLNet process would leak memory due to a thread problem.

#### DataMiner Cube - Alarm Console: Problem when grouping alarms by time on the first day of the month \[ID_26511\]

When, on the first day of the month, you opened an alarm tab page with active alarms grouped by time, in some cases, the alarms generated on the last day of the previous month would incorrectly be marked with the day of the week instead of with the word “Yesterday”.

#### SLProtocol would incorrectly not take the pair with the lowest ID when no ping pair was defined in a serial protocol \[ID_26514\]

When, in a serial protocol, no specific pair is defined as the ping pair (in other words: no pair has its group ID set to -1 or has a ping="true" attribute), by default, SLProtocol should take the pair with the lowest ID. However, up to now, it would instead incorrectly take the first pair defined in the protocol.

#### Monitoring app - Visual Overview: Using a SetVar shape would cause two instances of the same control to be displayed on top of each other \[ID_26516\]

When, in the Monitoring app, a SetVar shape were used in a Visio file, two instances of the same control would incorrectly be displayed on top of each other.

#### SLNet handle leaks \[ID_26517\]

In some cases, the SLNet process would experience handle leaks.

#### DataMiner Cube: Problem when trying to refresh a table by clicking the Refresh button \[ID_26521\]

In some cases, it would no longer be possible to manually refresh a table by clicking the *Refresh* button at the top of the table.

#### DataMiner Cube - Services app: Services list would not display the current states of the listed services \[ID_26537\]

When you opened the Services app, in some rare cases, the services list would not display the current states of the listed services.

#### Automation scripts could fail with a 'No CodeBuilder found for cookie xxx' error \[ID_26546\]

In some cases, Automation scripts could fail with a “No CodeBuilder found for cookie xxx” error.

#### Parts of a table polled via SNMP could be set to 'not initialized' when errors had occurred during polling \[ID_26551\]

When a table with columns that had a specific polling rate configured was polled via SNMP, in some cases, parts of that table could get set to “not initialized” when errors had occurred during polling.

#### Ticketing: TicketFieldResolver instances would no longer be synchronized \[ID_26552\]

In some cases, the TicketFieldResolver instances on the different agents in a DataMiner System would incorrectly no longer be synchronized.

#### HTML5 apps: Problem when logging in \[ID_26559\]

When you tried to log in to an HTML5 app (e.g. Monitoring, Dashboards, etc.), in some cases, the login page could become unresponsive when the login attempt failed.

#### DataMiner Cube: Visual page of a newly opened card would not get loaded when the new card replaced the contents of an existing card \[ID_26561\]

By default, if you left-click an item in the Surveyor using a card layout other than the tab layout, each new card you open will replace the previous open, docked card. Up to now, when the contents of an open card were replaced, in some cases, the visual page of the new card would not get loaded. It would only be loaded when you selected it after opening another page.

#### DataMiner Cube - Visual Overview: Problem with ColumnWidth option \[ID_26570\]

When, in a shape data field of type ParameterControlOptions, a ColumnWidth option had been specified, in some cases, Visual Overview would incorrectly show an empty table.

#### No exception would be thrown when part of an SLDataGateway filter could not be parsed \[ID_26572\]

In some cases, no exception would be thrown when part of an SLDataGateway filter could not be parsed.

#### DataMiner Cube: Alarms would incorrectly be updated with a 'View Impact Changed' event when the Name field in System Info was emptied \[ID_26575\]

When, in DataMiner Cube, you went to *System Center \> Agents \> System \> System info*, and emptied the *Name* field, the alarms would incorrectly be updated with a “View Impact Changed” event.

#### Dashboards app: Line chart components could show incorrect trend data due to a caching problem \[ID_26576\]

Due to a caching problem, in some cases, line chart component would display incorrect trend data.

#### DataMiner Cube - Data Display: Statistical values in table column headers would be displayed incorrectly \[ID_26587\]

In Data Display, in some cases, statistical values in table column headers would be displayed incorrectly.

#### DataMiner Cube - SNMP forwarding: Problems with Notifications tab \[ID_26590\]

When, in the *SNMP forwarding* section of *System Center*, you configured an SNMP manager, in some cases, the following problems could occur:

- When, in the *General* tab, you selected “SNMPv1” and saved the configuration as is, in some cases, the notification OID would not be saved correctly. By default, it should be set to “User device-specific OID”.

- In case of SNMPv2 or SNMPv3, when the *Notification OID* field was not set to “Use custom bindings” and the *Custom bindings* pane was expanded, the *Delete* button would incorrectly always be enabled. That button should only be enabled when the *Notification OID* field is set to “Use custom bindings” and a custom binding is selected in the list.

#### DataMiner Cube - Multiple set: List of table indices would not be populated when there was no associated read parameter \[ID_26593\]

When you performed a multiple set (i.e. an update of multiple parameter values in one go), up to now, the drop-down box listing the table indices would incorrectly not be populated when there was no associated read parameter (e.g. write parameters linked to buttons displayed in table cells).

#### DataMiner Cube - EPM: KPI list would incorrectly display long column names that included the table name \[ID_26599\]

In a CPE Manager element card, the KPI list would incorrectly display long column names that included the table name. From now on, that list will display short column names.

#### DataMiner Cube - Data Display: Incorrect parameter range validation after the range had been modified via a protocol QAction \[ID_26600\]

When a parameter range had been modified via a protocol QAction, in some cases, the new range would not correctly be validated when the parameter was updated via Data Display.

#### EPM: Problem when unmasking a tree element \[ID_26612\]

In some cases, an exception could be thrown when a tree element was unmasked.

#### DataMiner Cube - Data Display: 'CPEOnly' option would not be applied correctly \[ID_26624\]

In some cases, the “CPEOnly” protocol option would not be applied correctly when opening a card.

#### DataMiner Cube - Visual Overview: Breadcrumbs header showing after Visio page is maximized \[ID_26631\]

When you maximized a Visio page and then navigated to e.g. another view inside that page, in some cases, the breadcrumbs header would incorrectly be displayed at the top of the screen.

#### DataMiner Cube: Loading issue when returning to a parent node when navigating through a tree control \[ID_26634\]

When navigating through a tree control showing table data, in some cases, a loading issue could occur when returning to a parent node.

#### DataMiner Cube - Data Display: Exporting a table to CSV could generate wrong column order \[ID_26651\]

When you exported a Data Display table to a CSV file after moving or (un)hiding some of its columns, in some cases, the column order in the CSV file would be incorrect.

> [!NOTE]
> When hidden columns are exported, they are positioned where they would appear when not hidden, i.e. on the right of the closest non-hidden column as defined in the protocol.

#### DataMiner Cube - Visual Overview: Problem when using a placeholder inside another placeholder of the same type in Element shape data fields \[ID_26653\]

When, in an Element shape data field, you used a placeholder inside another placeholder of the same type (e.g. a \[Param:\] placeholder inside another \[Param:\] placeholder), in some cases, those placeholders would not get resolved correctly, causing the shape to not get displayed.

#### DataMiner Taskbar Utility: Problem at the end of a DataMiner upgrade operation \[ID_26660\]

In some rare cases, the DataMiner Taskbar Utility could throw an “out of memory” exception at the end of a DataMiner upgrade operation.

#### Problem with alarm statuses of parent services \[ID_26671\]

When a child service was added to multiple parent services hosted on a different DataMiner Agent, and all those parent services were edited, in some cases, only the alarm status of the parent service that had been edited last would be updated when the child service received an alarm status update.

#### Monitoring app: Clicking an editable table cell caused its value to be replaced by 0 \[ID_26678\]

When in the Monitoring app, you clicked an editable table cell to edit the value, in some cases, the current cell value would incorrectly be replaced b y 0.

#### Elements with an SNMPv3 port and at least one other port not correctly exported to CSV file \[ID_26680\]

In some cases, elements with an SNMPv3 port and at least one other port would not correctly be exported to a CSV file and, in the CSV file, the Credential Library GUID of the additional ports would incorrectly be set to that of the main port.

Also, when elements were exported to the Windows clipboard, in some cases, table columns would be misaligned.

#### Problem when taking a DataMiner backup that included the Cassandra database \[ID_26689\]

When taking a DataMiner backup, in some cases, an error could occur when that backup included the Cassandra database.

#### DataMiner Cube: Incorrect trend data value in Agents statistics in System Center on system with Cassandra database \[ID_26695\]

In DataMiner Cube, in some cases, System Center would show an incorrect trend data value in the Agents statistics when a Cassandra database was being used.

#### Service & Resource Management: ReservationDefinition with an occurrence outside of its time range could not be saved \[ID_26696\]

When a ReservationDefinition was created with an occurrence outside of its time range, in some cases, it would not be possible to save it.

#### Settings of advanced ports incorrectly deleted when element was edited \[ID_26703\]

When an element was edited without changing the existing port settings, in some cases, the settings of the advanced ports would incorrectly be deleted.

#### Element connections: Destination parameter not updated when parameter was linked to cell or column of table using advanced naming \[ID_26712\]

When a parameter was linked to a cell or a column of a table that used advanced naming, in some cases, the destination parameter would not be updated when the source parameter was updated.

#### Problems with the DataMiner Comparison tool \[ID_26713\]

When, in the DataMiner Comparison tool, you requested parameter values, in some cases, the Collapse common lines option would no longer work.

Also, it would no longer be possible to select the text of the option labels and, when the tool was not embedded in Visual Overview, an error could occur when scrolling.

#### DataMiner Cube - Scheduler: No longer possible to modify the actions defined in a task after going to the General or Schedule tabs \[ID_26714\]

When, in the *Scheduler* app, you created a new task and defined a number of actions in the *Actions* tab, in some cases, it would no longer be possible to modify those actions when you returned to the *Actions* tab after going to the *General* or *Schedule* tab.

#### DataMiner Cube - Data Display: Scrolling to the far right of a table would cause the column headers to no longer be aligned with the table content \[ID_26736\]

When you scrolled to the far right of a table, in some cases, the column headers would no longer be aligned with the table content.

#### Service & Resource Management: Problem when the generation of a ReservationDefinition occurrence failed \[ID_26745\]

When the generation of a ReservationDefinition occurrence failed, in some cases, an error could occur in SLNet.

#### DataMiner Cube - Visual Overview: Empty 'Parameter' shape data field could cause DataMiner Cube to become unresponsive \[ID_26750\]

When, on a Visio page, you had defined an element shape with an empty Parameter data field, in some rare cases, this could cause DataMiner Cube to become unresponsive. From now on, empty Parameter data fields will be disregarded.

#### DataMiner Cube - Visual Overview: Child shapes would incorrectly not disappear when the ChildrenFilter no longer applied \[ID_26760\]

When a ChildrenFilter was used in a child shape with ChildType set to “Service”, in some cases, generated child shapes would incorrectly not disappear when the filter no longer applied.

#### Masked rows would no longer be masked after an element restart \[ID_26771\]

When you masked a table row and then restarted the element, in some cases, the row would incorrectly no longer be masked.

#### Monitoring app: Notes on DVE elements \[ID_26787\]

In the Monitoring app, when users had been granted the “View notes” permission, in some cases, a Notes page would incorrectly be shown when they opened the card of a DVE element although it is not possible to create notes linked to DVE elements.

#### DataMiner tasks in Windows Task Scheduler would incorrectly remain in a 'Running' status when DataMiner was not running \[ID_26791\]

When DataMiner was not running, in some cases, the following scheduled tasks would incorrectly remain in a “Running” state:

- Skyline DataMiner Backup (DataMinerBackup.js)
- Skyline DataMiner Database Optimization (OptimizeDB.js)
- Skyline DataMiner LDAP Resync (ReloadLDAP.js)

As a result, the next scheduled execution of those tasks would not take place and a number of files would remain locked.

#### Problem with logging of SLManagedScripting \[ID_26796\]

In some cases, the log file of the SLManagedScripting process would incorrectly keep on growing. From now on, all logging of the SLManagedScripting process will be handled by SLLog.

#### External DCF connections could get deleted at DMA startup \[ID_26807\]

In a DataMiner System, in some rare cases, external DCF connections could get deleted at DMA startup.

#### DataMiner Cube - Trending: Curves submenu would be empty or incomplete when you right-clicked a trend graph \[ID_26809\]

When you right-clicked a trend graph, in some cases, the Curves submenu would be either empty or incomplete.

#### Dashboards app: Problem when a line chart component was configured to display columns from different tables of the same element without grouping \[ID_26810\]

When a line chart component was configured to display columns from different tables of the same element without grouping, in some cases, a “Cannot read property 'indexof' of undefined” error could be thrown.

#### CSV export of table parameter trend graph empty for custom data set other than 'Real-time' \[ID_26818\]

When a trend graph of a table cell for which the display key was different from the primary key was exported to CSV, and a custom data set other than "Real-time" was selected, it could occur that the export was empty.

#### DataMiner Cube - Trending: Exception value displayed incorrectly in trend graph legend \[ID_26824\]

If a trend graph showed an exception value, it could occur that the corresponding trace value in the legend below the graph was displayed incorrectly.

#### Axis name displayed incorrectly after 'Split to new Y-axis' option was used \[ID_26831\]

If a trend graph displayed multiple parameters and the *Split to new Y-axis* option was used for the first parameter that had been added to the graph, it could occur that in the *Y-axis settings* box both axes were displayed with the name of the first parameter.

#### Reporter app: Zip package would incorrectly contain duplicate CSV files when a trend report was generated \[ID_26854\]

When, in the legacy Reporter app, you generated a report template containing a trend block in CSV format, in some cases, the zip package would incorrectly contain duplicate files.

#### DataMiner Cube: Special characters in log files would not be displayed correctly \[ID_26874\]

When viewing log files in DataMiner Cube, in some cases, special characters in those log files would not be displayed correctly. From now on, the browser control displaying the log files will always render the page using UTF-8 character encoding.

#### Monitoring app: Video thumbnails not displayed \[ID_26879\]

In some cases, it could occur that video thumbnails were not displayed in Visual Overview in the Monitoring app.

#### DataMiner Cube - Visual Overview: Not possible to connect matrix input and output \[ID_26886\]

In some cases, it could occur that it was not possible to connect an input and output of a matrix control in a visual overview.

#### No data shown for table parameter in service if multiple filters were used and one contained a closing parenthesis \[ID_26893\]

If a table parameter was included in a service using multiple filters, one of which contained a closing parenthesis, it could occur that no data were shown for this parameter.

#### Incorrect sorting of parameters in multiple parameter set confirmation window \[ID_26908\]

If a parameter value was changed in a table cell and multiple other parameter values were changed as well, it could occur that the table parameter name was not displayed in the correct location in the pop-up window where you could confirm the multiple parameter set.

#### DataMiner Cube - Alarm Console: Delay not applied correctly \[ID_26915\]

In some cases, if a delay was applied to a tab in the Alarm Console, it could occur that this delay was not applied correctly when multiple alarms came in at different moments.

#### Legacy dashboards not synced in new Failover setup \[ID_26916\]

When a new Failover pair was configured, it could occur that the existing dashboards from the legacy Dashboards app were not synced from the online DMA to the offline DMA.

#### DataMiner Cube: Automation script executed from Visual Overview still displayed as 'Executing' when finished \[ID_26925\]

When an Automation script was executed from a shape in Visual Overview, it could occur that it continued to be displayed as being executed even when the script was finished.

#### Precompiled QActions loaded in memory multiple times \[ID_26952\]

In some cases, it could occur that precompiled QActions were loaded in memory multiple times.

#### CPE masking soft-launch feature visible even though soft-launch option was not activated \[ID_26960\]

In some cases, it could occur that the option to mask an EPM object in a diagram was available, even though the *CPEIntegration* soft-launch option was not activated. Attempting to mask the object would result in an error, since this feature is only available in soft launch.

#### DataMiner Cube - Visual Overview: Input 1 missing from right-click menu of matrix control \[ID_26963\]

When a matrix control was displayed in Visual Overview, it could occur that Input 1 was not listed among the available inputs in the right-click menu where you can connect an output with an input.

#### Fixed parameter length from protocol not respected \[ID_26968\]

In some cases, it could occur that the fixed parameter length defined in a protocol was not respected when data was sent.

#### Alarm update with incorrect timestamp after custom element property change \[ID_26971\]

In some cases, when the custom properties for an element were changed, it could occur that the timestamp for corresponding alarm updates was incorrect.

#### Automation: Parameter set failed for string parameter with custom name \[ID_26973\]

If a parameter of type string was configured to be displayed with a custom parameter name, it could occur that parameter sets via the Automation API failed for this parameter.

#### Matrix follow mode issues \[ID_26976\]

The following issues with matrix follow mode have been resolved:

- If a matrix element had been migrated to a different DMA than the one where it was originally created, it could occur that follow mode did not work for this element.

- If follow mode was enabled on an output that was already connected to an input, and this output was set as a slave of another output, it could occur that the output was connected to the wrong input.

#### DataMiner Cube: Visual Overview page not displayed when Visio drawing was not cached on client \[ID_27000\]

In some cases, if a Visio drawing was not cached on the client, it could occur that the displayed Visual Overview page remained empty even after it had been downloaded from the server.

#### DMA startup problem if COM pointer was created for SLGSMGateway while SLNet was initializing \[ID_27023\]

In some rare cases, a DMA startup problem could occur if a COM pointer was created for the SLGSMGateway process while the SLNet process was initializing.

#### Encrypted credential library passwords would incorrectly be re-encrypted \[ID_27034\]\[ID_27089\]

In some cases, encrypted credential library passwords would incorrectly be re-encrypted. This would cause the credential library to grow, which, in turn, would cause a memory issue in SLNet.

> [!NOTE]
> The DataMiner SLNetClientTest tool allows you to repair credential library files that contain incorrectly encrypted passwords.

#### DataMiner Cube: Service child displayed twice in Surveyor after service refresh \[ID_27042\]

In some cases, when a service was refreshed, for example by a manager protocol, it could occur that a service child was displayed twice in the Surveyor until a new Cube session was started.

#### The log size would incorrectly be converted from MB to bytes when the log settings were changed \[ID_27075\]

When the log settings were changed, in some cases, the log size would incorrectly be converted from MB to bytes.
