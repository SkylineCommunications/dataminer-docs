---
uid: General_Feature_Release_10.0.10_changes
---

# General Feature Release 10.0.10 – Changes

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Increased performance due to enhancements made to the locking behavior of the SLElement EPM cache \[ID_24916\]

Overall performance has increased due to a number of enhancements made to the locking behavior of the SLElement EPM cache.

#### DataMiner Installer will now automatically select a checkbox to create an additional DataMiner user when not being executed by a user with administrative privileges \[ID_25414\]

From now on, if DataMiner Installer is not being executed by a user with administrative privileges, it will automatically select a checkbox to add the current user to the DataMiner Administrators group. This will ensure that at least one user account is available to log in to DataMiner when the installation has finished.

#### SLPort logging enhancements \[ID_25806\]

A number of enhancements have been made to the SLPort logging.

#### Trend icons now determined based on trend window duration \[ID_26030\]

To improve the efficiency of the SLAnalytics process, it now determines the trend icon based on the trend window duration of the parameter.

#### Enhanced communication between agents using HTTP and agents using HTTPS \[ID_26122\]

A number of enhancements have been made with regard to inter-agent communication within a DataMiner System, especially between agents using HTTP and agents using HTTPS.

#### Trend data pattern matching: Enhanced performance \[ID_26174\]\[ID_26219\]\[ID_27001\]

Due to a number of enhancements, overall performance has increased when matching patterns in trend data.

#### SLAnalytics: Enhanced logging \[ID_26335\]

A number of enhancements have been made to the SLAnalytics logging.

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

#### DataMiner Cube: Enhanced Back/Forward navigation \[ID_26457\]

Up to now, clicking the *Back* and *Forward* buttons would only make you jump from one card to another. From now on, also the navigation history within a card will be taken into account.

For example, when you drill down from a card page to a parameter, clicking *Back* will bring you back to that card page, and when you open the trend page of a table cell from within a Visio page, clicking *Back* will bring you back to that Visio page.

Also, when you hover over a *Back* or *Forward* button, a tool tip will now show the name of the card and the page that will be opened.

#### Cube Launcher: Enhancements \[ID_26482\]\[ID_26577\]\[ID_26584\]\[ID_26746\]

A number of enhancements have been made to the Cube Launcher:

- In the *New DataMiner System* window, you can now press ENTER instead of clicking the *Connect* button.

- When you click the cogwheel button at the bottom, you can now click *View logging* to open the folder containing the log files of the Cube Launcher:

    *C:\\Users\\\<username>\\AppData\\Local\\Skyline\\DataMiner\\DataMinerCube\\Logs*

- Retrieving and saving temporary Cube settings has been optimized.

- Enhanced animations.

#### Jobs app: Possible to update or delete values of drop-down fields in unused job sections \[ID_26503\]

From now on, if a job section is not being used by a job, it will be possible to update or delete values of drop-down fields in that section.

If you try to update or delete values of drop-down fields in sections that are being used, an error message will appear.

#### Applications using system files to be updated during a DataMiner upgrade will now forcefully be terminated \[ID_26505\]

When updating system files during a DataMiner upgrade, the SLReplace process will now forcefully terminate any application that is using the files to be updated.

#### DataMiner Cube - Failover: When you chose to disable the Failover configuration, it is now also possible to select 'Cancel' \[ID_26509\]

In the Failover configuration window, up to now, when you chose to disable the Failover configuration, you were only able to select *Yes* or *No*. From now on, it is also possible to select *Cancel*.

#### DataMiner Cube - Service & Resource Management: Users will now clearly be notified when trying to configure or manage service profiles when no Indexing Engine is installed \[ID_26534\]

Since DataMiner 10.0.0, service definitions and service profiles can only be used on systems with an Indexing Engine. From now on, when no Indexing Engine is installed, DataMiner Cube will clearly indicate that it is not possible to configure service profiles in the Profiles app nor to manage them in the Services app.

#### Jobs app: Minor enhancements \[ID_26535\]

In the Jobs app, a number of minor enhancements have been made:

- When creating a new domain or updating the name of an existing domain, the domain name will now be trimmed. Any leading and trailing whitespace characters will be removed before the domain name is saved.

- Up to now, names of job templates had to be unique across the entire Jobs app. From now on, they only have to be unique within a specific domain.

- Up to now, when you changed the type of a job field that was being used in a job, in some cases, the value of the “Show in list view” option would incorrectly be changed. From now on, the value of this option will be left untouched.

#### Security checks for local connections between an SLxxx module and SLNet \[ID_26544\]

For local connections between an SLxxx module (e.g. SLDMS) and SLNet, security checks have been established. A security token will be generated and verified for each of the messages that are sent.

#### Dashboards app - Line chart component: Loading indicator next to button to expand or collapse the trend graph legend \[ID_26557\]

Up to now, when data was being loaded into a line chart component, a loading indicator would replace the button to expand or collapse the legend. As a result, it was not possible to expand or collapse the legend while data was being loaded. From now on, when data is being loaded into a line chart component, a loading indicator will be displayed next to the button to expand or collapse the legend.

#### Automation: DataMiner will now check whether a parameter’s set range has not been changed dynamically \[ID_26574\]

When a parameter is set, from now on, DataMiner will check whether the set range of the parameter in question has not been changed dynamically (e.g. by an Automation script).

#### General security enhancements \[ID_26620\]

A number of enhancements have been made with regard to user permissions needed to retrieve or modify data on DataMiner Systems.

#### Dashboards app: Parameter feed enhancements \[ID_26627\]

Due to a number of enhancements, overall performance of the parameter feed has increased, especially when using it in conjunction with parameter table, pivot table and line chart components.

#### DataMiner Cube - Service & Resource Management: Enhanced error messages \[ID_26629\]

Throughout DataMiner Cube, a number of error messages related to Service & Resource Management have been rewritten to make them clearer and more user-friendly.

#### Trending: Increased limit for trend values of type Double to be converted to scientific notation strings \[ID_26646\]

In the database, trend values are stored as text strings.

Up to now, all values of type Double with a length of more than 6 characters were converted to a scientific notation string (e.g. “1e07”). From now on, only values of type Double with a length of more than 12 characters will be converted to a scientific notation string.

#### DataMiner Cube - Automation: All parameters will now be aligned vertically \[ID_26665\]

When creating or updating an Automation script in the Automation app, the parameters will now all be aligned vertically.

#### Improved logging in case client is disconnected \[ID_26667\]

If a client application tries to send a request to a DMA that has already destroyed the client connection, or when the client application checks the connection and finds that it no longer exists, now the log information will mention that the connection was closed with the time when it was closed and the reason it was closed. Previously, logging only mentioned "no such connection" in this case.

#### Cube Launcher: Enhanced host name validation when adding a DMS \[ID_26668\]

When adding a new DataMiner System to Cube Launcher, the host name you enter will now be validated. This will prevent launch buttons from being disabled when a host name is invalid.

#### Enhanced performance when notifying SLElement of service updates \[ID_26674\]

Due to a number of enhancements, overall performance has increased when notifying SLElement of service updates.

#### DataMiner Cube - System Center: 'Include SLNet' checkbox removed from restart confirmation window \[ID_26685\]

When, in the *Agents* section of *System Center*, you clicked *(Re)start* to restart a DataMiner Agent, up to now, it was possible to select the *Include SLNet* checkbox in the confirmation window.

This checkbox has now been removed.

#### Jobs app: No longer possible to edit or delete hidden job sections \[ID_26687\]

In configuration mode, up to now, it was possible to not only unhide a hidden section, but also to edit or delete it. From now on, it will only be possible to unhide hidden sections. It will no longer be possible to edit or delete hidden sections.

#### Cube Launcher: Configurations will now be synchronized in real time among different instances \[ID_26699\]

When different instances of Cube Launcher are running simultaneously, they will now synchronize their configurations in real time.

#### Jobs app: Enhanced label behavior in timeline view \[ID_26727\]

A number of enhancements have been made to the way in which labels are visualized in the timeline view.

Also, the custom time filter will now correctly update when zooming in or out.

#### Cube Launcher: Enhanced host name validation \[ID_26752\]

When you add a new DataMiner Agent or DataMiner System to Cube Launcher, the host name you enter will now be validated as follows:

- Is it a valid IP address or host name?

    > [!NOTE]
    > If the host name cannot be validated, you will be able to add it, but a warning message will appear.

- Is it accessible over HTTP and/or HTTPS?

    > [!NOTE]
    > If the DMA is accessible over HTTPS, the configuration will be modified to make sure Cube will always connect to that agent over HTTPS. However, if there are any issues with the HTTPS certificate, those issues will be indicated and HTTP will be used instead.

- Is it a DataMiner Agent?

#### Cube Launcher application will appear under the name 'DataMiner Cube' \[ID_26788\]

When you start the Cube Launcher tool, the application will be shown as “DataMiner Cube” in e.g. the Windows Task Manager.

#### Problem with logging of SLManagedScripting \[ID_26796\]

In some cases, the log file of the SLManagedScripting process would incorrectly keep on growing. From now on, all logging of the SLManagedScripting process will be handled by SLLog.

#### DataMiner Cube: Property values in Custom tab of Properties window will now be prevented from updating automatically when a user is manually editing property values \[ID_26825\]

The values of the custom properties listed in the *Custom* tab of a *Properties* window are constantly being updated in real time. As this would sometimes cause problems when a user was manually updating one of those properties, from now on, real-time updates of custom properties listed in the *Custom* tab of the *Properties* window will be suspended as long as a user is manually editing property values in that same tab.

#### DataMiner Cube - Alarm Console: Enhanced performance when closing alarm tabs \[ID_26826\]

Due to a number of enhancements, overall performance has increased when closing an alarm tab, especially when all alarms in that tab are selected.

#### DataMiner Cube -Trending: Enhanced retrieval of histogram intervals \[ID_26833\]

A number of enhancements have been made to the way in which histogram intervals are retrieved.

#### DataMiner Cube - System Center: Enhanced saving of backup settings \[ID_26858\]

A number of enhancements have been made to the way in which the backup settings are saved in the *Backup* section of *System Center*.

#### Alarm template information events no longer generated upon element/DMA restart \[ID_26862\]

Previously, when an alarm template was configured to generate information events for specific values, these information events would also be generated each time the element or the DMA restarted. Now such information events will only be generated at runtime.

#### DataMiner Cube: Enhanced performance when processing parameter updates and calculating service statistics \[ID_26863\]

Due to a number of enhancements, overall performance has increased, especially when processing parameter updates and calculating service statistics.

#### SLAnalytics: Enhanced logging \[ID_26884\]

A number of enhancements have been made to the SLAnalytics logging.

#### SLLogCollector now targets Microsoft .NET Framework 4.6.2 \[ID_26888\]

SLLogCollector now targets Microsoft .NET Framework 4.6.2.

#### Analytics settings from cluster now applied when new DMA joins DMS \[ID_26904\]

When a new DMA joins a DMS, the DMA will now be updated with the DataMiner Analytics settings from the DMS. Previously, the most recently updated settings were synced in the DMS, which meant that if the new DMA had been updated more recently, its settings were used for the rest of the DMS when it joined.

#### Raw value displayed if string value of analog parameter could not be parsed as double \[ID_26909\]

If a string value of an analog parameter could not be parsed as double, since DataMiner 10.0.9, "0" would be displayed as the default fallback value. However, as some older drivers relied on the previous behavior, now the raw value will be displayed again instead.

#### Analytics configuration file updated after DMA leaves cluster \[ID_26912\]

When a DMA is taken out of a cluster, its analytics configuration file will now be renamed to reflect this change. However, note that to prevent issues in case the DMA is added to the cluster again, we strongly recommend to restart the DMA after it leaved the cluster.

#### Lazy loading of cards in tab layout \[ID_26920\]

To improve memory usage and performance, when you open a saved workspace with multiple cards in a tab layout, each card will only be initialized once it has been selected. The same applies when cards are loaded when you log in to Cube.

#### Cube launcher now updated silently after connection to DMS with higher DataMiner version \[ID_26944\]

When you connect to a DMS with a higher DataMiner version than the currently installed version, the Cube launcher is now updated silently, without a pop-up message.

#### Improved graph layout of service RCA chains \[ID_26945\]

An improved algorithm is now used to draw the graph of the RCA chain of a service. This will better prevent overlapping connections and connections running through nodes.

#### Service & Resource Management: Wildcard supported for protocol version in ProtocolLinks of VirtualFunctionDefinition \[ID_26966\]

In the list of *ProtocolLinks* of a *VirtualFunctionDefinition*, an asterisk ('"\*") can now be used as a wildcard character in a protocol version. However, the wildcard can only be specified at the end of the version.

#### DataMiner mobile apps updated to Angular 9 \[ID_26975\]

The DataMiner mobile apps that use Angular, e.g. the Monitoring, Dashboards and Jobs app, now use Angular 9 instead of Angular 8.

#### Opening Cube launcher via system tray icon can now restore existing minimized window \[ID_27006\]

When a Cube launcher window was opened and minimized, opening the launcher again using the system tray icon will restore the existing window.

#### Jobs app: Section definition can now be removed completely \[ID_27025\]

Up to now, when you deleted a section definition, this only broke the link between the section definition and the job domain, so that technically, the section definition still existed in the database.

Now the following methods in the DataMiner Web Services API allow the deletion of a section definition from the job domain and the complete deletion of the domain itself:

- *DeleteJobsSectionDefinition*: This method will try to remove a section definition from the database. In case the section definition is used in other domains, it will try to remove all the links in those domains first. If this fails, any changes will be reverted and an error will be thrown.

- *DeleteJobsDomain*: This method will now remove the domain and all its section definitions as well, unless these are linked to other domains.

In the Jobs app itself, when a user tries to delete a section definition, a dialog box is now displayed, asking whether only the link with the current domain should be removed or whether the section definition should be removed entirely.

#### DataMiner Cube: Embedded DataMiner apps now always use Chromium browser \[ID_27052\]

All DataMiner apps displayed within an embedded web browser in DataMiner Cube (e.g. Ticketing, Dashboards, Reports, Annotations, etc.) will now always use the Chromium browser engine, regardless of which default browser engine is configured.

#### Alarm when Cassandra or Elasticsearch database go offline \[ID_27061\]

When the Cassandra or Elasticsearch database go offline, an alarm is now generated in DataMiner. In the alarm details, it will show exactly which storage is in file offload mode while the database is offline.

### Fixes

#### Problem with spectrum session presets reverting to the default settings \[ID_26043\]

After restarting a DMA, in some cases, spectrum session presets could revert to the default settings if a card was open in a Cube connected through another DMA.

#### After a hotfix installation, the version number in VersionHistory.txt would be updated incorrectly \[ID_26067\]

After a hotfix installation, in some cases, the version number in the VersionHistory.txt file would incorrectly be updated with the word “Hotfix” instead of the hotfix version string containing the detailed version information (e.g. “HF_10.0.7.0(CU0)\_20200520-135714”).

#### Exceptions related to correlation data flushing would be logged during a DMA startup or Failover switch \[ID_26177\]

During a DMA startup or a Failover switch, in some cases, exceptions related to correlation data flushing would be logged in SLErrors.txt.

#### DataMiner Cube - Alarm Console: 'Earlier this month' and 'Last month' were sorted incorrectly \[ID_26209\]

When, in the Alarm Console, you sorted and grouped alarms by Time/descending, the “earlier this month” group would incorrectly be sorted after the “last month” group (and vice versa when sorted and grouped by Time/ascending).

#### Problem when restoring a DataMiner backup package containing a database file that took a long time to restore \[ID_26210\]

When you restored a DataMiner backup package (.dmbackup) containing a database file that took more than 30 minutes to restore, in some cases, the restore of the DataMiner backup package would incorrectly continue before the restore of the database file had finished.

#### Problem when using the IsMatrixCrosspointConnected method in an Automation script \[ID_26276\]

When, in an Automation script, the *IsMatrixCrosspointConnected* method was used before a matrix point had been connected, in some cases, an exception could be thrown.

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

#### SLLogCollector tool: LogCollector package would incorrectly not contain any dump files \[ID_26417\]

When a LogCollector package had been made using the SLLogCollector tool, in some cases, that package would incorrectly not contain any dump files.

#### LoggerUtil: Some log entries would not get added to the logs \[ID_26429\]

In some cases, certain log entries would not get added to the logs.

#### Problem when using SNMPv3 credentials from the credential library in conjunction with a non-primary SNMP port \[ID_26435\]

In some cases, an element startup error could be thrown when using SNMPv3 credentials from the credential library in conjunction with a non-primary SNMP port.

#### DataMiner Agent not restarting after processes were stopped \[ID_26440\]

To prevent an Agent from automatically restarting when it is stopped, up to now, DataMiner did not automatically restart when more than 2 processes stopped within a 2-minute timespan. However, this could cause problems if more than 2 processes stopped but the Agent did not stop completely. To prevent this, the Agent will now be restarted when at least one of the following processes is still running: SLDataMiner, SLElement, SLDMS and SLNet.

#### Real-time trend data requested by sending a GetTrendDataMessage would incorrectly contain additional data points beyond the specified end time \[ID_26473\]

When real-time trend data was requested by sending a GetTrendDataMessage, in some cases, the response would incorrectly contain additional data points beyond the specified end time.

#### Service & Resource Management: Problem when retrieving Profile Manager data \[ID_26478\]

When retrieving Profile Manager objects, in some cases, a NULL object would incorrectly be returned.

#### Problem due to duplicate IP addresses in DMS.xml \[ID_26480\]

In some cases, an error could occur because the DMS.xml file on a particular DataMiner Agent had the same IP address listed multiple times. From now on, when a DMS.xml file contains duplicate IP addresses, all but the first occurrence will be ignored.

#### Files in C:\\Skyline DataMiner\\ root folder would not be taken into account when processing FilesToLeave.txt during a DataMiner upgrade \[ID_26489\]

When the FilesToLeave.txt file was processed during a DataMiner upgrade, up to now, the files in the C:\\Skyline DataMiner\\ root folder would incorrectly not be taken into account.

#### Failover: Agent configured to only be switched over manually would incorrectly be switched back to offline automatically in case of failing heartbeats \[ID_26490\]

In some cases, an agent configured to only be switched over manually would incorrectly be switched back to offline automatically in case of failing heartbeats.

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

In some cases, it would no longer be possible to manually refresh a table by clicking the *Refresh* button at the top of the table.

#### Dashboards app - CPE feed: A field filtered by a field value lower in the chain would not contain the correct value \[ID_26529\]

When using a CPE feed on a dashboard, in some cases, a field filtered by a field value lower in the chain would not contain the correct value.

#### DataMiner Cube - Services app: Services list would not display the current states of the listed services \[ID_26537\]

When you opened the Services app, in some rare cases, the services list would not display the current states of the listed services.

#### SLDMS notification thread blocked by LDAP refresh \[ID_26547\]

In some cases, if refreshing LDAP took a long time, it could occur that this blocked the SLDMS notification thread.

#### Parts of a table polled via SNMP could be set to 'not initialized' when errors had occurred during polling \[ID_26551\]

When a table with columns that had a specific polling rate configured was polled via SNMP, in some cases, parts of that table could get set to “not initialized” when errors had occurred during polling.

#### Ticketing: TicketFieldResolver instances would no longer be synchronized \[ID_26552\]

In some cases, the TicketFieldResolver instances on the different agents in a DataMiner System would incorrectly no longer be synchronized.

#### DataMiner Cube: Visual page of a newly opened card would not get loaded when the new card replaced the contents of an existing card \[ID_26561\]

By default, if you left-click an item in the Surveyor using a card layout other than the tab layout, each new card you open will replace the previous open, docked card. Up to now, when the contents of an open card were replaced, in some cases, the visual page of the new card would not get loaded. It would only be loaded when you selected it after opening another page.

#### DataMiner Cube - Visual Overview: Problem with ColumnWidth option \[ID_26570\]

When, in a shape data field of type ParameterControlOptions, a ColumnWidth option had been specified, in some cases, Visual Overview would incorrectly show an empty table.

#### No exception would be thrown when part of an SLDataGateway filter could not be parsed \[ID_26572\]

In some cases, no exception would be thrown when part of an SLDataGateway filter could not be parsed.

#### DataMiner Cube: Alarms would incorrectly be updated with a 'View Impact Changed' event when the Name field in System Info was emptied \[ID_26575\]

When, in DataMiner Cube, you went to *System Center \> Agents \> System \> System info*, and emptied the *Name* field, the alarms would incorrectly be updated with a “View Impact Changed” event.

#### Dashboards app: Line chart components could show incorrect trend data due to a caching problem \[ID_26576\]

Due to a caching problem, in some cases, line chart component would display incorrect trend data.

#### Monitoring app: Alarm Console could show an error when the browser was connected to the Web Services API using web sockets \[ID_26581\]

In the Monitoring app, in some cases, the Alarm Console would show a “Received invalid data” error when the browser was connected to the Web Services API using web sockets.

#### DataMiner Cube - Data Display: Statistical values in table column headers would be displayed incorrectly \[ID_26587\]

In Data Display, in some cases, statistical values in table column headers would be displayed incorrectly.

#### Renamed DVE element would again have its former name after restarting the DMA \[ID_26589\]

When you renamed a DVE element, in some cases, it would incorrectly have its former name again after the DMA was restarted.

#### DataMiner Cube - SNMP forwarding: Problems with Notifications tab \[ID_26590\]

When, in the *SNMP forwarding* section of *System Center*, you configured an SNMP manager, in some cases, the following problems could occur:

- When, in the *General* tab, you selected “SNMPv1” and saved the configuration as is, in some cases, the notification OID would not be saved correctly. By default, it should be set to “User device-specific OID”.

- In case of SNMPv2 or SNMPv3, when the *Notification OID* field was not set to “Use custom bindings” and the *Custom bindings* pane was expanded, the *Delete* button would incorrectly always be enabled. That button should only be enabled when the *Notification OID* field is set to “Use custom bindings” and a custom binding is selected in the list.

#### DataMiner Cube - Multiple set: List of table indices would not be populated when there was no associated read parameter \[ID_26593\]

When you performed a multiple set (i.e. an update of multiple parameter values in one go), up to now, the drop-down box listing the table indices would incorrectly not be populated when there was no associated read parameter (e.g. write parameters linked to buttons displayed in table cells).

#### DataMiner Cube - EPM: KPI list would incorrectly display long column names that included the table name \[ID_26599\]

In a CPE Manager element card, the KPI list would incorrectly display long column names that included the table name. From now on, that list will display short column names.

#### DataMiner Cube - Data Display: Incorrect parameter range validation after the range had been modified via a protocol QAction \[ID_26600\]

When a parameter range had been modified via a protocol QAction, in some cases, the new range would not correctly be validated when the parameter was updated via Data Display.

#### MySQL: DVE child elements would incorrectly not be deleted when the DVE parent element was deleted \[ID_26607\]

When a DVE parent element was deleted from a MySQL database, in some cases, its child elements would incorrectly not be deleted.

#### EPM: Problem when unmasking a tree element \[ID_26612\]

In some cases, an exception could be thrown when a tree element was unmasked.

#### DataMiner Cube - Data Display: 'CPEOnly' option would not be applied correctly \[ID_26624\]

In some cases, the “CPEOnly” protocol option would not be applied correctly when opening a card.

#### DataMiner Cube - Visual Overview: Breadcrumbs header showing after Visio page is maximized \[ID_26631\]

When you maximized a Visio page and then navigated to e.g. another view inside that page, in some cases, the breadcrumbs header would incorrectly be displayed at the top of the screen.

#### DataMiner Cube: Loading issue when returning to a parent node when navigating through a tree control \[ID_26634\]

When navigating through a tree control showing table data, in some cases, a loading issue could occur when returning to a parent node.

#### Dashboards app: Problem when opening a dashboard after closing a dashboard containing feeds \[ID_26636\]

When you closed a dashboard containing feeds, and then opened another dashboard, in some cases, an error could occur.

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

#### Dashboards app: Feeds would not appear in the Feeds section of a component’s data tab \[ID_26702\]

In some cases, the time range, drop-down, list and tree feeds would not appear in the Feeds section of a component’s data tab.

#### Settings of advanced ports incorrectly deleted when element was edited \[ID_26703\]

When an element was edited without changing the existing port settings, in some cases, the settings of the advanced ports would incorrectly be deleted.

#### Problem with SLAnalytics during a Failover switch \[ID_26711\]

In some cases, an error could occur in SLAnalytics during a Failover switch.

#### Element connections: Destination parameter not updated when parameter was linked to cell or column of table using advanced naming \[ID_26712\]

When a parameter was linked to a cell or a column of a table that used advanced naming, in some cases, the destination parameter would not be updated when the source parameter was updated.

#### Problems with the DataMiner Comparison tool \[ID_26713\]

When, in the DataMiner Comparison tool, you requested parameter values, in some cases, the Collapse common lines option would no longer work.

Also, it would no longer be possible to select the text of the option labels and, when the tool was not embedded in Visual Overview, an error could occur when scrolling.

#### DataMiner Cube - Scheduler: No longer possible to modify the actions defined in a task after going to the General or Schedule tab \[ID_26714\]

When, in the *Scheduler* app, you created a new task and defined a number of actions in the *Actions* tab, in some cases, it would no longer be possible to modify those actions when you returned to the *Actions* tab after going to the *General* or *Schedule* tab.

#### Jobs app: Fields of type static text could incorrectly be saved without assigning them a value \[ID_26721\]

When configuring job sections, up to now, it would incorrectly be possible to add fields of type static text without assigning them a value. From now on, when you add a field of type static text, you will have to assign it a value.

#### Ticketing app: Number of selected tickets would incorrectly be displayed next to the Delete button when only one ticket was selected \[ID_26723\]

When more than one ticket is selected in the list, the number of selected tickets is displayed next to the *Delete* button at the top of the screen. However, up to now, the number of selected tickets would incorrectly also be displayed when only one ticket was selected.

#### DataMiner Cube - Data Display: Scrolling to the far right of a table would cause the column headers to no longer be aligned with the table content \[ID_26736\]

When you scrolled to the far right of a table, in some cases, the column headers would no longer be aligned with the table content.

#### Service & Resource Management: Problem when the generation of a ReservationDefinition occurrence failed \[ID_26745\]

When the generation of a ReservationDefinition occurrence failed, in some cases, an error could occur in SLNet.

#### Problem with SLDataMiner when an SNMP manager was deleted \[ID_26749\]

In some rare cases, an error could occur in SLDataMiner when an SNMP manager was deleted.

#### DataMiner Cube - Visual Overview: Empty 'Parameter' shape data field could cause DataMiner Cube to become unresponsive \[ID_26750\]

When, on a Visio page, you had defined an element shape with an empty Parameter data field, in some rare cases, this could cause DataMiner Cube to become unresponsive. From now on, empty Parameter data fields will be disregarded.

#### DataMiner Cube - Visual Overview: Child shapes would incorrectly not disappear when the ChildrenFilter no longer applied \[ID_26760\]

When a ChildrenFilter was used in a child shape with ChildType set to “Service”, in some cases, generated child shapes would incorrectly not disappear when the filter no longer applied.

#### Long-term trend prediction shorter than mid-term/short-term prediction \[ID_26766\]

In some cases, it could occur that a long-term trend prediction was calculated that was in fact shorter than the mid-term or short-term prediction for the same parameter. In such cases, a long-term prediction will now no longer be available.

#### Masked rows would no longer be masked after an element restart \[ID_26771\]

When you masked a table row and then restarted the element, in some cases, the row would incorrectly no longer be masked.

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

#### DataMiner Cube: Not possible to open the Profiles app when no profile data was configured \[ID_26778\]

In some cases, it would not be possible to open the Profiles app when no profile data was configured.

#### DataMiner Cube - Profiles app: Problem when retrieving the discreet values of a profile parameter \[ID_26782\]

When you opened the *Profiles* app, in some cases, an error could occur when retrieving the discreet values of a profile parameter.

#### Monitoring app: Notes on DVE elements \[ID_26787\]

In the Monitoring app, when users had been granted the “View notes” permission, in some cases, a Notes page would incorrectly be shown when they opened the card of a DVE element although it is not possible to create notes linked to DVE elements.

#### DataMiner tasks in Windows Task Scheduler would incorrectly remain in a 'Running' status when DataMiner was not running \[ID_26791\]

When DataMiner was not running, in some cases, the following scheduled tasks would incorrectly remain in a “Running” state:

- Skyline DataMiner Backup (DataMinerBackup.js)
- Skyline DataMiner Database Optimization (OptimizeDB.js)
- Skyline DataMiner LDAP Resync (ReloadLDAP.js)

As a result, the next scheduled execution of those tasks would not take place and a number of files would remain locked.

#### Dashboards app: No longer possible to delete dashboards \[ID_26798\]

In some cases, users would no longer be able to delete dashboards.

#### Alarm filter combining element and table column filter not working for history alarms tab \[ID_26797\]

If a history alarms tab was filtered using an element filter combined with a table column filter, it could occur that no alarms were displayed.

#### Dashboards app - Pivot table component: Problem with 'Auto-expand rows' option \[ID_26803\]

In some cases, the pivot table component’s “Auto-expand rows” option would not work properly when exiting edit mode.

#### Jobs app: No longer possible to save jobs after removing all additionally added fields from the default job section \[ID_26805\]

When you added a number of additional fields to the default job section and then removed them again, in some cases, it would no longer be possible to save jobs.

#### External DCF connections could get deleted at DMA startup \[ID_26807\]

In a DataMiner System, in some rare cases, external DCF connections could get deleted at DMA startup.

#### DataMiner Cube - Trending: Curves submenu would be empty or incomplete when you right-clicked a trend graph \[ID_26809\]

When you right-clicked a trend graph, in some cases, the Curves submenu would be either empty or incomplete.

#### Dashboards app: Problem when a line chart component was configured to display columns from different tables of the same element without grouping \[ID_26810\]

When a line chart component was configured to display columns from different tables of the same element without grouping, in some cases, a “Cannot read property 'indexof' of undefined” error could be thrown.

#### Email report based on dashboard from new app was blank \[ID_26811\]

In some cases, it could occur that if an Automation script sent an email report based on a dashboard from the new Dashboards app, the PDF attached to this email was blank.

#### DataMiner Cube: Not possible to reuse alarm template condition based on non-linked table \[ID_26812\]

If a non-linked table was used in an alarm template condition for a table column parameter, it could occur that this condition could not be selected in the condition drop-down box for other table column parameters in the alarm template.

#### CSV export of table parameter trend graph empty for custom data set other than 'Real-time' \[ID_26818\]

When a trend graph of a table cell for which the display key was different from the primary key was exported to CSV, and a custom data set other than "Real-time" was selected, it could occur that the export was empty.

#### Cube Launcher: Problem when loading assemblies \[ID_26819\]

In some rare cases, Cube Launcher could thrown an exception when loading assemblies.

#### DataMiner Cube - Trending: Exception value displayed incorrectly in trend graph legend \[ID_26824\]

If a trend graph showed an exception value, it could occur that the corresponding trace value in the legend below the graph was displayed incorrectly.

#### Dashboards app: Configuration of Group component not saved \[ID_26828\]

In the Dashboards app, it could occur that the configuration of a Group component was not saved.

#### Axis name displayed incorrectly after 'Split to new Y-axis' option was used \[ID_26831\]

If a trend graph displayed multiple parameters and the *Split to new Y-axis* option was used for the first parameter that had been added to the graph, it could occur that in the *Y-axis settings* box both axes were displayed with the name of the first parameter.

#### Exception value of numeric parameter displayed incorrectly \[ID_26837\]\[ID_26889\]

If a numeric parameter was set to an exception value, it could occur that it displayed a numeric value instead of its exception value string.

#### Monitoring app: Visual Overview pages not retrieved if HTTPS was enabled \[ID_26839\]

When HTTPS was enabled on a DMA, it could occur that Visual Overview pages could not be retrieved in the Monitoring app.

#### Issues when exporting trend graph for multiple parameters to CSV with custom data set \[ID_26851\]

If a trend graph containing multiple parameters was exported to CSV with a custom data set, it could occur that the export window closed to soon, causing a problem in Cube or making it impossible to save the file. In addition, it could occur that multiple rows were created for the same timestamp.

#### Reporter app: Zip package would incorrectly contain duplicate CSV files when a trend report was generated \[ID_26854\]

When, in the legacy Reporter app, you generated a report template containing a trend block in CSV format, in some cases, the zip package would incorrectly contain duplicate files.

#### Various issues in the Jobs app \[ID_26866\]

The following issues have been resolved in the Jobs app:

- The confirmation message when a job was deleted was not in line with other deletion confirmation messages.

- When a collapsed or expanded job section was deleted, it was respectively expanded or collapsed while the deletion confirmation message was displayed.

- When the pop-up window to edit a field was closed without saving the changes and then reopened, it still displayed the changes.

#### DataMiner Cube: Special characters in log files would not be displayed correctly \[ID_26874\]

When viewing log files in DataMiner Cube, in some cases, special characters in those log files would not be displayed correctly. From now on, the browser control displaying the log files will always render the page using UTF-8 character encoding.

#### Monitoring app: Video thumbnails not displayed \[ID_26879\]

In some cases, it could occur that video thumbnails were not displayed in Visual Overview in the Monitoring app.

#### DataMiner Cube - Visual Overview: Not possible to connect matrix input and output \[ID_26886\]

In some cases, it could occur that it was not possible to connect an input and output of a matrix control in a visual overview.

#### No data shown for table parameter in service if multiple filters were used and one contained a closing parenthesis \[ID_26893\]

If a table parameter was included in a service using multiple filters, one of which contained a closing parenthesis, it could occur that no data were shown for this parameter.

#### Service & Resource Management: Virtual function elements would remain in an 'Undefined' state \[ID_26898\]

In some cases, the element state of a virtual function element would remain “Undefined”. As a result, bookings using the resource in question could not be started.

#### Dashboards app: Problems with CPE feed \[ID_26905\]

In some cases, the diagram would not show the selected value when the first field was a text field.

Also, when you opened a drop-down field, in some cases, the fields would close again, making it impossible to select a value.

#### Incorrect sorting of parameters in multiple parameter set confirmation window \[ID_26908\]

If a parameter value was changed in a table cell and multiple other parameter values were changed as well, it could occur that the table parameter name was not displayed in the correct location in the pop-up window where you could confirm the multiple parameter set.

#### DataMiner Cube - Alarm Console: Delay not applied correctly \[ID_26915\]

In some cases, if a delay was applied to a tab in the Alarm Console, it could occur that this delay was not applied correctly when multiple alarms came in at different moments.

#### Legacy dashboards not synced in new Failover setup \[ID_26916\]

When a new Failover pair was configured, it could occur that the existing dashboards from the legacy Dashboards app were not synced from the online DMA to the offline DMA.

#### DataMiner Cube: Automation script executed from Visual Overview still displayed as "Executing" when finished \[ID_26925\]

When an Automation script was executed from a shape in Visual Overview, it could occur that it continued to be displayed as being executed even when the script was finished.

#### DataMiner state saved in connection and in event cache not in sync \[ID_26928\]

In some cases, it could occur that the DataMiner state saved on the connection and in the event cache were not in sync, which could cause various issues. For example, it could be impossible to delete a ticketing resolver.

#### DataMiner Cube desktop app installation drop-down box not displayed correctly on landing page on small screen \[ID_26934\]

On the DataMiner landing page, the drop-down box that allows you to install the desktop DataMiner Cube app was not displayed correctly if the screen was too small. Since the DataMiner Cube desktop app can only be installed on PCs with a relatively large screen, on small screens this drop-down box will no longer be displayed.

#### DataMiner Cube: Text displayed incorrectly in mixed DPI environment \[ID_26937\]

If DataMiner Cube was displayed on different monitors with different DPI settings, it could occur that text was not displayed correctly in some places.

#### Incorrect information about Cube in Programs and Features window \[ID_26944\]

In the Windows *Programs and Features* window, it could occur that the version number and size of the originally installed DataMiner Cube desktop app were displayed, instead of the actual version number and size.

#### Precompiled QActions loaded in memory multiple times \[ID_26952\]

In some cases, it could occur that precompiled QActions were loaded in memory multiple times.

#### CPE masking soft-launch feature visible even though soft-launch option was not activated \[ID_26960\]

In some cases, it could occur that the option to mask an EPM object in a diagram was available, even though the *CPEIntegration* soft-launch option was not activated. Attempting to mask the object would result in an error, since this feature is only available in soft launch.

#### DataMiner Cube - Visual Overview: Input 1 missing from right-click menu of matrix control \[ID_26963\]

When a matrix control was displayed in Visual Overview, it could occur that Input 1 was not listed among the available inputs in the right-click menu where you can connect an output with an input.

#### Service & Resource Management: Virtual function definition linked to protocol version used as production version could not be bound to element using production version \[ID_26966\]

If an element used the production version of a protocol, a virtual function definition with a protocol link to the version of the protocol that was used as the production version could not be bound to the element.

Note that protocol links do not support specifying "production" as the protocol version. Note also that when the protocol of an element is changed, the virtual function resource bound to that element is currently not yet changed.

#### Fixed parameter length from protocol not respected \[ID_26968\]

In some cases, it could occur that the fixed parameter length defined in a protocol was not respected when data was sent.

#### Dashboards app: Title not updated after switch between dashboards \[ID_26969\]

When you switched between dashboards in the new Dashboards app, it could occur that the title was not updated correctly.

#### Alarm update with incorrect timestamp after custom element property change \[ID_26971\]

In some cases, when the custom properties for an element were changed, it could occur that the timestamp for corresponding alarm updates was incorrect.

#### Automation: Parameter set failed for string parameter with custom name \[ID_26973\]

If a parameter of type string was configured to be displayed with a custom parameter name, it could occur that parameter sets via the Automation API failed for this parameter.

#### Matrix follow mode issues \[ID_26976\]

The following issues with matrix follow mode have been resolved:

- If a matrix element had been migrated to a different DMA than the one where it was originally created, it could occur that follow mode did not work for this element.

- If follow mode was enabled on an output that was already connected to an input, and this output was set as a slave of another output, it could occur that the output was connected to the wrong input.

#### DataMiner Cube: Time value of datetime parameter with exception/discrete values remained empty \[ID_26977\]

If a datetime parameter had one or more exception values or discrete values, it could occur that the displayed time remained empty.

#### DataMiner Cube: Visual Overview page not displayed when Visio drawing was not cached on client \[ID_27000\]

In some cases, if a Visio drawing was not cached on the client, it could occur that the displayed Visual Overview page remained empty even after it had been downloaded from the server.

#### DataMiner Cube: Issues occurring during DELT import operations \[ID_27004\]

A number of issues that would sometimes occur during DELT import operations have now been fixed.

#### DMA startup problem if COM pointer was created for SLGSMGateway while SLNet was initializing \[ID_27023\]

In some rare cases, a DMA startup problem could occur if a COM pointer was created for the SLGSMGateway process while the SLNet process was initializing.

#### Jobs app: Drop-down icon of domain selector in header bar not displayed in case hidden domain was selected \[ID_27025\]

When a hidden domain was selected, the drop-down icon of the domain selector in the header of the Jobs app was not displayed.

#### Encrypted credential library passwords would incorrectly be re-encrypted \[ID_27034\]\[ID_27089\]

In some cases, encrypted credential library passwords would incorrectly be re-encrypted. This would cause the credential library to grow, which, in turn, would cause a memory issue in SLNet.

> [!NOTE]
> The DataMiner SLNetClientTest tool allows you to repair credential library files that contain incorrectly encrypted passwords.

#### DataMiner Cube: Service child displayed twice in Surveyor after service refresh \[ID_27042\]

In some cases, when a service was refreshed, for example by a manager protocol, it could occur that a service child was displayed twice in the Surveyor until a new Cube session was started.

#### The log size would incorrectly be converted from MB to bytes when the log settings were changed \[ID_27075\]

When the log settings were changed, in some cases, the log size would incorrectly be converted from MB to bytes.

#### Not possible to upgrade DataMiner from client in time zone with higher offset from UTC than server \[ID_27138\]

When a DataMiner upgrade was started from a DataMiner Cube client on a machine of which the local time had a higher offset from UTC than the time of the server, it could occur that the upgrade timed out immediately and could not be completed.
