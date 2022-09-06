---
uid: General_Main_Release_10.1.0_fixes_1
---

# General Main Release 10.1.0 - Fixes (part 1)

#### Dashboards app: Polling issues when WebSocket communication was disabled \[ID_23801\]

When WebSocket communication was disabled for a dashboard, it could occur that the state of views and redundancy groups was only polled every 5 minutes. In addition, it could occur that only the initial active alarms were retrieved.

#### Various issues in Change Element States Offline tool \[ID_23833\]

Various issues have been resolved in the Change Element States Offline tool.

#### Dashboards app - Trend charts: Boundary lines would only be drawn on the first axis \[ID_23837\]

When you added boundary lines to a trend chart, in some cases, the lines would only be drawn on the first axis. From now on, they will be drawn on every visible axis.

#### Jobs app: Problem when filtering on a field of the default job section \[ID_24236\]

When creating a filter on a field of the default job section, in some cases, an incorrect field ID would be used.

#### DataMiner Cube - Failover: Progress message no longer displayed during a switch-over \[ID_24250\]

During a switch-over, in some cases, users would no longer receive a “\<DMA> is switching to \<DMA>” message.

Also, the term “System Display” has been replaced by “Client Interface” in *Failover status* windows.

#### Dashboards app: Incorrect message would appear when an interactive Automation script went into timeout \[ID_24258\]

When an interactive Automation script running inside the Dashboards app went into timeout, in some cases, a success message would incorrectly be displayed instead of an error message.

#### Trending: Incorrect trend data retrieved for view column parameters \[ID_24268\]

In some cases, incorrect trend data would be retrieved for view column parameters.

#### Datetime value in interactive Automation script not updated correctly \[ID_24284\]

When a datetime value in an interactive Automation script was changed by the script itself, it could occur that the value was not updated correctly.

#### Dashboards app / Jobs app: Problem opening the user menu \[ID_24285\]

In the Dashboards app and the Jobs app, in some cases, it would not be possible to open the user menu.

#### Jobs app: Job end times displayed incorrectly in timeline \[ID_24287\]

In the jobs timeline, in some cases, job end times would be displayed incorrectly.

#### HTML5 apps: Selecting the month value in a datetime control would incorrectly clear that value \[ID_24323\]

When you selected the month value in a datetime control, in some cases, that value would incorrectly be cleared.

#### Automation: Dialog box from an interactive Automation script started in Dashboards would incorrectly appear in Cube \[ID_24328\]

In some cases, a dialog box from an interactive Automation script started in Dashboards would incorrectly appear inside a Cube session.

#### Dashboards app: Element tree of a multiple-parameter feed was sorted incorrectly \[ID_24495\]

In some cases, the element tree of a multiple-parameter feed would not be sorted correctly. From now on, this tree will be sorted correctly, even when multiple filters are applied.

#### Dashboards app: Parameters in the URL would not correctly be loaded in the multiple parameter feed \[ID_24536\]

When you opened a dashboard with a multiple parameter feed using a URL that contained the parameters to be loaded in that feed, in some cases, the parameters in the URL would not correctly be loaded into the multiple parameter feed.

#### Problem when opening an HTML5 app \[ID_24565\]

When you opened an HTML5 app (e.g. Monitoring & Control, Dashboards, etc.), in some cases, the app would not load due to a missing internal component.

#### Problem during protocol buffer serialization \[ID_24630\]

In some cases, an exception could be thrown during protocol buffer serialization.

#### DataMiner Cube - Alarm console: Dragging an element to the Alarm Console incorrectly showed all alarms on the DataMiner Agent \[ID_24655\]

When you dragged an element onto the Alarm Console, in some cases, the alarm tab would incorrectly list all alarms on the DataMiner Agent instead of only the alarms of the element in question.

#### Service & Resource Management: Incorrect result when comparing service definitions \[ID_24662\]

If an Automation script compared two service definitions with at least one interface configuration or edge in the diagram, it could occur that the Equals method returned false incorrectly.

#### DataMiner Cube - EPM/CPE: Problem with chain field option 'statusTabs' \[ID_24668\]

In DataMiner Cube, in some cases, so-called status tab links to pop-up windows (defined in chain field “statusTabs” options) would no longer be rendered correctly.

#### SLAnalytics: Increased memory usage \[ID_24703\]\[ID_25601\]

Due to a code refactoring error, in some cases, the overall memory usage of the SLAnalytics process could increase by up to 40 percent.

#### Jobs app: Action buttons no longer displayed after executing an action \[ID_24710\]

In some cases, after a job action was executed (i.e. creation, editing or deletion of a job), it could occur that the action buttons in the header bar of the panel were no longer displayed.

#### Jobs app: Timeline action buttons displayed in incorrect location \[ID_24732\]

When a job was selected on the timeline in the Jobs app, the action buttons for the job were displayed in the header bar of the app instead of the header bar of the panel.

#### Dashboards app: Resource feed selection lost after refresh \[ID_24738\]

If a resource was selected in a feed, it could occur that the feed did not keep this selection when the page was refreshed.

#### Problem when writing multiple datasets to a database \[ID_24748\]

When multiple datasets were written to a database in one go, e.g. when inserting data temporarily stored in offload files, in some cases, the following exception could be thrown:

```txt
System.InvalidOperationException: Collection was modified after the enumerator was instantiated.
```

#### Problem when serial clients went into timeout \[ID_24764\]

When a serial client went into timeout, in some cases, the socket would not be cleaned up correctly, causing the client to not reconnect when the server became available again.

Also, in case of commands that did not require a response, in some cases, the sent data would not be cleaned up correctly, causing the socket to keep on sending.

#### Problem with SLPort when parsing SSH responses \[ID_24776\]

In some cases, an error could occur in SLPort when parsing SSH responses.

#### Memory leak in SLProtocol \[ID_24793\]

In some cases, SLProtocol could leak memory when communicating with SLPort.

#### Problem when performing a full synchronization \[ID_24804\]

When performing a full synchronization, in some cases, an error could occur due to a deadlock in SLDataMiner.

#### DataMiner Cube - Visual Overview: Trend components with dynamic shape data could no longer be collapsed \[ID_24812\]

In some cases, trend components with dynamic shape data could no longer be collapsed.

#### Business Intelligence: Correcting an SLA outage would incorrectly not affect the history table \[ID_24873\]

If you corrected an outage that was no longer in the current SLA window, in some cases, the history table (i.e. table 1000) would incorrectly not get updated.

#### Jobs app: Save button could no longer be clicked after trying to save a job that contained errors \[ID_24881\]

After trying to save a job that contained errors (e.g. missing fields), in some cases, it would no longer be possible to click the *Save* button again after correcting the errors.

#### Dashboards app: Problem when loading drop-down boxes of interactive Automation scripts \[ID_24888\]

When a dialog box of an interactive Automation script showed multiple drop-down boxes next to each other, in some cases, some of those boxes would become unresponsive when data was being loaded into them.

#### Jobs app: No headers were displayed at the top of the jobs list \[ID_25042\]

In the Jobs app, in some cases, no headers would be displayed at the top of the jobs list.

#### After an element restart, the view impact information of alarms retrieved from the database could be incorrect \[ID_25053\]

When, after restarting an element, the alarms associated with that element were retrieved from the database, in some cases, the view impact information in those alarms would be incorrect.

#### Active alarms could be displayed incorrectly after restarting a DMA with a MySQL database \[ID_25071\]

When a DataMiner Agent with a MySQL database was restarted, in some cases, the active alarms could be displayed incorrectly after the restart.

#### Jobs app: Problem listing the job section definitions \[ID_25087\]

In the Jobs app, in some cases, an error would occur when trying to list the job section definitions.

#### CRC trailer from separate IP packet not added to response \[ID_25089\]

If a CRC trailer was returned in a separate IP packet, it could occur that it was not added to the response.

#### Monitoring app: Severity color indication not displayed in Alarm Console and on alarms pages \[ID_25106\]

In some cases, it could occur that the severity color indication was not displayed in the Alarm Console and on alarms pages in the Monitoring app.

#### SLAnalytics: Trend prediction data would contain incorrectly converted time stamps \[ID_25111\]

In some cases, trend prediction data returned by SLAnalytics would contain incorrectly converted time stamps.

#### Exception when writing empty data set to Elastic database \[ID_25113\]

In some cases, an exception could be thrown when an empty data set was written to the Elastic database.

#### Business Intelligence: Incorrect total violation time due to a rounding issue \[ID_25115\]

In some cases, the Total Violation Time could be incorrect due to a rounding issue.

#### Missing or incorrect alarm details after retrieving alarms of a restarted element from a MySQL database \[ID_25123\]

When, after an element restart, the alarms of that element were retrieved from a MySQL database, in some cases, a number of alarm fields would either contain incorrect values or be missing.

#### Memory leak in SLAnalytics \[ID_25145\]

In some cases, a memory leak could occur in the SLAnalytics process.

#### Dashboards app: Not possible to select items in tree view \[ID_25151\]

In some cases, it could occur that it was not possible to select items in a tree view in the Dashboards app. This could for example be the case in a tree component or in the configuration of a parameter feed.

#### Number of masked alarm was incorrectly incremented when the severity of a masked alarm was changed \[ID_25182\]

When the severity of a masked alarm was changed, in some cases, the number of masked alarms would incorrectly be incremented.

#### DataMiner Cube - EPM: EPM filter not loaded when topology cell was not linked to topology cell of selected object \[ID_25191\]

If an EPM (formerly known as CPE) element displayed a diagram, it could occur that a filter above a filter containing a selection remained empty if the former had a topology cell that was not linked to the topology cell of the selected object.

#### Problem with SLAnalytics due to a threading issue \[ID_25207\]

In some cases, an error could occur in SLAnalytics due to a threading issue.

#### Problem when retrieving a large number of alarms from a MySQL database \[ID_25298\]

When, on a system with a MySQL database, a correlation alarm was based on a large number of alarms, in some cases, an exception could be thrown when retrieving those alarms.

#### DataMiner Cube - Alarm Console: Severity duration of cleared alarms was not set to 'N/A' \[ID_25370\]

When you added the *Severity Duration* column to the Alarm Console, up to now, the duration for a cleared alarm was incorrectly shown as the difference between the time of the alarm and the current time. From now on, the duration of a cleared alarm will always be shown as “N/A”.

#### DataMiner Cube: Elements would go into timeout after being imported from a CSV file \[ID_25457\]

When you exported elements with non-used SNMP credential library references to a CSV file, those references were incorrectly saved as empty GUIDs. This would cause the elements to go into timeout after being re-imported from that CSV file.

#### Alarm file offload serialization would fail due to a protocol buffer error on a PropertyAccessType enum value \[ID_25459\]

In some cases, alarm file offload serialization would fail due to a protocol buffer error on a PropertyAccessType enum value.

#### Dashboards app - Service definition component: Script parameters were swapped \[ID_25476\]

When a script was launched from the service definition component, in some cases, the booking ID (or the service definition ID) and the node ID script parameters would be swapped.

#### SLAnalytics: Problem when retrieving data at startup \[ID_25479\]

In some cases, an error could occur when SLAnalytics retrieved data from the database at startup.

#### SNMP: Problem when using a specific polling rate in conjunction with the 'SNMP set and get' or 'dynamic SNMP get' options \[ID_25514\]

When a protocol configured to poll SNMP columns at a specific polling rate has write parameters that use the “SNMP set and get” option or parameters that use the “dynamic SNMP get” option, in some cases, values could appear to be toggling in the user interface.

#### DataMiner Cube - Data Display: Zero-width column was not saved at the correct position when saving the column layout of a table \[ID_25534\]

When you saved the column layout of a table that contained a hidden column (i.e. a column of which the width was set to 0 in the protocol), that hidden column would not be saved at the correct position.

#### Exception when exporting SNMP element to CSV \[ID_25586\]

When an element with an SNMP connection was exported to CSV, an exception could be thrown, causing the export to fail.

#### Web Services API v1: WSDL no longer backwards compatible for GetTicket method \[ID_25605\]

The WSDL was no longer backwards compatible for the GetTicket method.

#### Problem with SLPort due to a buffer resizing issue \[ID_25607\]

When SLPort receives data, it stores it in a buffer until everything has been received. If the amount of data received is larger than the size of the buffer, the buffer is automatically resized. However, in some cases, this would not happen, causing an error to occur.

#### Automation: Email sent from an Automation script had an incorrect subject \[ID_25618\]

When an email was sent from an Automation script, in some cases, the dashboard name would incorrectly be used as email subject.

From now on, the dashboard name will only be used as email subject when no subject was specified.

#### Backup that included an Indexing database with a red index would incorrectly succeed on one agent in the DMS \[ID_25658\]

When, in a DataMiner System, you took a backup that included an Indexing database with a red index, up to now, the backup would incorrectly succeed on one agent and fail on all others.

From now on, a backup that includes an Indexing database with a red index will fail on all agents and an error will be added to the elasticbackup log file in the Backup folder.

#### Ticketing app: Certain selection boxes were not scrollable \[ID_25719\]

Certain selection boxes, like the ticket domain selector in the subheader, would incorrectly not be scrollable.

#### Problem when conditionally monitoring a standalone parameter using a condition that included a column parameter check \[ID_25731\]

When a standalone parameter was monitored conditionally, and the condition in question included a column parameter check, in some cases, an error could occur in SLElement.

#### Service & Resource Management: Problem when updating multiple ReservationInstance properties in rapid succession \[ID_25808\]

When multiple ReservationInstance properties were updated in rapid succession, in some cases, “PropertiesWereAlreadyModified” errors could be thrown.

#### DataMiner Cube - Resources app: Incorrect validation tool tip would appear when a capability parameter did not have a regular expression defined \[ID_25835\]

When adding or editing a resource in the Resources app, in some cases, an incorrect validation tool tip would appear when a capability parameter did not have a regular expression defined.

#### Indexing Engine: Memory issues caused by custom data paging cooking not being cleaned up \[ID_25836\]

On systems running Indexing Engine, custom data paging cookies would no longer be cleaned up. In some cases, this could lead to memory issues.

#### SLAnalytics: Memory usage would increase due to a buffering issue \[ID_25844\]

In some cases, the overall memory usage of the SLAnalytics process would increase due to a buffering issue.

#### SLAnalytics: Parameter information of inactive elements would incorrectly not get removed from the cache \[ID_25851\]

Up to now, parameter information of inactive elements would incorrectly not get removed from the cache.

#### Unnecessary 'codedom' tag in SLNet.exe.config file \[ID_25868\]

In some cases, the SLNet.exe.config file would contain an unnecessary “codedom” tag. On certain DataMiner Agents, this could lead to issues when generating functions.

#### Interactive Automation scripts: Some drop-down boxes would unnecessarily trigger a refresh of the UI \[ID_25902\]

In some cases, drop-down boxes would unnecessarily trigger a refresh of the UI.

#### Dashboards app - Service Definition component: Booking ID not passed to the script when clicking a node \[ID_25912\]

When, in a service definition component linked to a booking, you clicked a node that launched an Automation script, in some cases, the booking ID would not be passed to the script.

#### SLAnalytics: Element state changes and element deletions would not be processed correctly when behavioral anomaly detection was disabled \[ID_25929\]

Up to now, when behavioral anomaly detection was disabled, in some cases, element state changes and element deletions would not be processed correctly.

#### Problems when generating a PDF report based on a dashboard from the new app \[ID_25939\]

In PDF reports generated based on dashboards from the new Dashboards app, the page numbers would be incorrect and the service state visualizations would not be displayed correctly.

#### Problem when a table filter contained the table parameter ID instead of the column parameter ID \[ID_25988\]

When a DynamicTableQuery is passed to SLelement, it is possible to add a column filter in one of the following formats:

- Value= \<COLUMNPID> == \<Value>

- Fullfilter= \<COLUMNPID>==\<Value>

Up to now, when such a column filter contained the table parameter ID instead of the column parameter ID, in some cases, either a NULL response would incorrectly be returned or an error would occur in SLElement.

#### SLAnalytics: Different agents in a DMS would incorrectly each create a different configuration file \[ID_26005\]

Due to a synchronization issue, in some rare cases, different agents in a DMS would incorrectly each create a different SLAnalytics configuration file.

#### Failover: Backup agent would lose its connection to the virtual agent \[ID_26025\]

When, in a Failover setup with a Cassandra database, the backup agent was online, in some cases, it would lose its connection to the virtual agent.

#### DataMiner was not able to correctly parse the Cassandra.yaml file at startup \[ID_26041\]

At startup, in some cases, DataMiner was not able to correctly parse the IP addresses of the seed nodes when reading the Cassandra.yaml file.

#### Restarting an element immediately after masking it would cause it to be shown as unmasked for a short period of time \[ID_26070\]

When you masked an element and then immediately restarted it, in some rare cases, it could be shown as unmasked for a short period of time.

#### Incorrect page margins in PDF reports sent by an Automation script \[ID_26090\]

When an Automation script sent a PDF report based on a dashboard, in some cases, the page margins in that PDF report would be incorrect.

#### Failover: Problem when switching over the first time after migrating from MySQL to Cassandra \[ID_26116\]

When, in a Failover setup, the first switch-over occurred after migrating from MySQL to Cassandra, in some cases, a DataMiner run-time error alarm would be generated.

#### ResourceManager module would no longer initialize after a DataMiner restart \[ID_26117\]\[ID_26309\]

In some cases, the ResourceManager module would no longer initialize after a DataMiner restart.

#### Problem with SLManagedScripting due to a locking issue \[ID_26139\]

In some rare cases, threads could get stuck in SLScripting due to a locking issue.

#### DataMiner Cube: Incorrect error would be logged when opening a view card without linked EPM object in an EPM environment \[ID_26141\]

When, in an EPM environment, you opened a view card without linked EPM object, in some cases, an incorrect error would be logged.

#### Dashboards app - Service definition component: When a node action was executed, all action buttons of other nodes with the same action configured would be set to 'loading' \[ID_26145\]

In a service definition component, in some cases, all nodes with the same action configured would set the state of their action button to “loading” when the action was executed on one of those nodes.

#### DataMiner Cube - Trending: Trend graph of aggregation parameter did not show any data \[ID_26172\]

When you opened the trend graph of an aggregation parameter, in some cases, no trend data was shown.

#### Exceptions related to correlation data flushing would be logged during a DMA startup or Failover switch \[ID_26177\]

During a DMA startup or a Failover switch, in some cases, exceptions related to correlation data flushing would be logged in SLErrors.txt.

#### Visual Overview: Tabs names not displayed when alternative tab control style was used \[ID_26181\]

When a tab control in a Visio drawing was configured to use an alternative style with the option "*TabControlStyle=2*", it could occur that tab names were not displayed.

#### SLAnalytics: New alarms generated while SLAnalytics was stopped would incorrectly not be assigned an alarm focus score when SLAnalytics was restarted \[ID_26186\]

When a new alarm was generated while SLAnalytics was stopped, in some cases, that alarm would incorrectly not get assigned an alarm focus score when SLAnalytics was restarted.

#### Jobs app: Problem when creating custom data tables \[ID_26237\]

In the Jobs app, in some rare cases, an exception could be thrown when two custom data tables were created simultaneously.

#### Service & Resource Management: System functions were not synchronized when a new agent was added to an existing DataMiner System \[ID_26238\]

When a new agent was added to an existing DataMiner System, in some cases, the system functions would not be synchronized.

#### Memory leak in SLDataGateway \[ID_26361\]

In some cases, the SLDataGateway process would leak memory.

#### Monitoring app: Client timezone setting was disregarded when displaying timestamps in trend graphs \[ID_26368\]

In some cases, the Monitoring app would incorrectly disregard the client timezone setting when displaying timestamps in trend graphs.

#### Problem with user permissions for Automation scripts \[ID_26401\]\[ID_26957\]

Up to now the permissions to add, edit, delete and execute Automation scripts were only enforced in the client, which could make it possible for a user to modify the Automation scripts on a DMA despite not having the required permissions for this.

Now the system will enforce the permissions as follows:

- To view or retrieve an Automation script, you need the "Automation - UI available" or "Automation - Execute" permission.

- To create an Automation script, you need the "Automation - Add" or the "Automation - Edit" permission.

- To update an Automation script, you need the "Automation - Add" or the "Automation - Edit" permission.

- To delete an Automation script, you need the "Automation - Delete" permission.

- To execute an Automation script, you need the "Automation - Execute" permission.

- To perform a DLL injection in an Automation script, you need the "Automation - Add" or the "Automation - Edit" permission.

- To change a memory file, you need the "Automation - Add" or the "Automation - Edit" permission.

- To retrieve a memory file, you need "Automation - UI available" or "Automation - Execute" permission.

In addition, within DataMiner Cube, up to now there could be a problem when you made changes to the memory files in the Automation app. This has now been resolved. To bring the memory files tab in line with the rest of the Automation app, the *Cancel* button in this tab has also been replaced by a *Discard* button.

#### SLLogCollector tool: LogCollector package would incorrectly not contain any dump files \[ID_26417\]

When a LogCollector package had been made using the SLLogCollector tool, in some cases, that package would incorrectly not contain any dump files.

#### Active alarms would not be retrieved correctly from the database \[ID_26420\]

In some cases, an internal exception could be thrown, causing the active alarms not to be retrieved correctly from the database.

#### LoggerUtil: Some log entries would not get added to the logs \[ID_26429\]

In some cases, certain log entries would not get added to the logs.

#### Jobs app: Problem with 'New' and 'Save' buttons \[ID_26474\]

In the Jobs app, in some cases, the *New* button would not be shown in the subheader.

Also, in some cases, clicking the *Save* button would not cause a job to be saved.

#### Service & Resource Management: Problem when retrieving Profile Manager data \[ID_26478\]

When retrieving Profile Manager objects, in some cases, a NULL object would incorrectly be returned.

#### Jobs app: Problem when exporting a job to PDF \[ID_26484\]

In some cases, it would not be possible to export a job to a PDF file.

#### Jobs app: Problem when updating a job with bookings \[ID_26486\]

In some cases, an error could occur when you updated a job with bookings.

#### Jobs app: Bookings list would not be updated correctly after adding, editing or deleting a booking \[ID_26487\]

In the Jobs app, in some cases, the bookings list would not be updated correctly after adding, editing or deleting a booking.

#### Dashboards app - CPE feed: A field filtered by a field value lower in the chain would not contain the correct value \[ID_26529\]

When using a CPE feed on a dashboard, in some cases, a field filtered by a field value lower in the chain would not contain the correct value.

#### Monitoring app: Alarm Console could show an error when the browser was connected to the Web Services API using web sockets \[ID_26581\]

In the Monitoring app, in some cases, the Alarm Console would show a “Received invalid data” error when the browser was connected to the Web Services API using web sockets.

#### Renamed DVE element would again have its former name after restarting the DMA \[ID_26589\]

When you renamed a DVE element, in some cases, it would incorrectly have its former name again after the DMA was restarted.

#### MySQL: DVE child elements would incorrectly not be deleted when the DVE parent element was deleted \[ID_26607\]

When a DVE parent element was deleted from a MySQL database, in some cases, its child elements would incorrectly not be deleted.

#### Problem when opening a Visio file in an HTML5 app \[ID_26610\]

In some cases, an exception could be thrown when opening a Visio file in an HTML5 app (e.g. Monitoring).

#### Dashboards app: Problem when opening a dashboard after closing a dashboard containing feeds \[ID_26636\]

When you closed a dashboard containing feeds, and then opened another dashboard, in some cases, an error could occur.

#### Dashboards app: Feeds would not appear in the Feeds section of a component’s data tab \[ID_26702\]

In some cases, the time range, drop-down, list and tree feeds would not appear in the Feeds section of a component’s data tab.

#### Problem with SLAnalytics during a Failover switch \[ID_26711\]

In some cases, an error could occur in SLAnalytics during a Failover switch.

#### Jobs app: Fields of type static text could incorrectly be saved without assigning them a value \[ID_26721\]

When configuring job sections, up to now, it would incorrectly be possible to add fields of type static text without assigning them a value. From now on, when you add a field of type static text, you will have to assign it a value.

#### Ticketing app: Number of selected tickets would incorrectly be displayed next to the Delete button when only one ticket was selected \[ID_26723\]

When more than one ticket is selected in the list, the number of selected tickets is displayed next to the *Delete* button at the top of the screen. However, up to now, the number of selected tickets would incorrectly also be displayed when only one ticket was selected.

From now on, the number of selected tickets will no longer be displayed when only one ticket is selected in the list.

#### Problem with SLDataMiner when an SNMP manager was deleted \[ID_26749\]

In some rare cases, an error could occur in SLDataMiner when an SNMP manager was deleted.

#### Long-term trend prediction shorter than mid-term/short-term prediction \[ID_26766\]

In some cases, it could occur that a long-term trend prediction was calculated that was in fact shorter than the mid-term or short-term prediction for the same parameter. In such cases, a long-term prediction will now no longer be available.

#### Protocols: Hex string parameters would not contain enough leading zeros \[ID_26777\]

When a parameter value of type “double” was converted to a value of type “hex string” (e.g. a CRC parameter), in some cases, it would not contain enough leading zeros when put into a data stream.

The problem would typically occur when the parameter was configured as follows:

| Property   | Value                             |
|------------|-----------------------------------|
| Base       | “16”                              |
| Length     | “2”, “4”, “8” or “16”             |
| LengthType | “fixed”                           |
| RawType    | “numeric text”, “text” or “other” |
| Type       | “double”                          |

#### DataMiner Cube - Profiles app: Problem when retrieving the discreet values of a profile parameter \[ID_26782\]

When you opened the *Profiles* app, in some cases, an error could occur when retrieving the discreet values of a profile parameter.

#### Dashboards app: No longer possible to delete dashboards \[ID_26798\]

In some cases, users would no longer be able to delete dashboards.

#### Alarm filter combining element and table column filter not working for history alarms tab \[ID_26797\]

If a history alarms tab was filtered using an element filter combined with a table column filter, it could occur that no alarms were displayed.
