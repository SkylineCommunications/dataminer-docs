---
uid: General_Main_Release_10.1.0_CU11
---

# General Main Release 10.1.0 CU11

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### SLElement: Enhanced service impact calculation \[ID_31163\]

A number of enhancements have been made to the service impact calculation in SLElement.

#### Enhanced performance when initializing elements that are included in multiple services \[ID_31611\]

Due to a number of enhancements, overall performance has increased when initializing elements that are included in multiple services.

#### DataMiner Cube: Miscellaneous enhancements \[ID_31641\]

A number of small enhancements have been made to DataMiner Cube and the DataMiner Cube start window.

#### SLLogCollector: Resources to be collected can now be specified in configuration files \[ID_31674\]

SLLogCollector will now check the C:\\Skyline DataMiner\\Tools\\SLLogCollector\\LogConfigs folder for configuration files in which you can specify the resources (i.e. objects) to be collected.

By default, the above-mentioned folder will contain a Default.xml file, listing a default list of resources to be collected. If necessary, additional XML files can be created and stored in this folder.

Example of a configuration file:

```xml
<ResourceCollectorConfig>
  <Collectors>
    <File name="Collector1">
      ...
    </File>
    <Http name="Collector2">
      ...
    </Http>
    <Exe name="Collector3">
      ...
    </Exe>
  </Collectors>
</ResourceCollectorConfig>
```

In the example above, three collectors have been defined:

- Collector1 is a collector of type “File”, and will order SLLogCollector to retrieve a set of files (e.g. log files).
- Collector2 is a collector of type “Http”, and will order SLLogCollector to send an HTTP request to a server and to store the response.
- Collector3 is a collector of type “Exe”, and will order SLLogCollector to run an executable file and to store the output.

##### Collectors of type File

Collectors of type “File” can be configured using the following XML elements and attributes:

| Element/attribute | Type | Mandatory | Description |
|--|--|--|--|
| File@name | String | Yes | The name for the collector. |
| File.Source |  | Yes | The folder in which SLLogCollector will search for files and folders. |
| File.Destination |  | Yes | The (relative) path to the destination folder in the archive. |
| File.Patterns |  | Yes | The element containing all search patterns. |
| File.Patterns.Pattern |  | Yes | A Microsoft .Net search pattern to filter file names or file paths. |
| File.Patterns.Pattern@amount | Int | No | The X most recent items to be copied. |
| File.Patterns.Pattern@recursive | Bool | No | Whether to search recursively or not. Default: false |
| File.Patterns.Pattern@isFolder | Bool | No | If true, then SLLogCollector will search for folders matching the pattern and will copy the entire content of the matching folders. Default: false |

##### Collectors of type Http

Collectors of type “Http” can be configured using the following XML elements and attributes:

| Element/attribute | Type | Mandatory | Description |
|--|--|--|--|
| Http@name | String | Yes | The name for the collector. |
| Http.Source |  | Yes | The IP address and port to which the requests have to be sent. Format: `http://ip:port` |
| Http.Destination |  | Yes | The (relative) path to the destination folder in the archive. |
| Http.Endpoints |  | Yes | The element containing all endpoints. |
| Http.Endpoints.Endpoint |  | Yes | The element grouping all information on a particular endpoint. |
| Http.Endpoints.Endpoint@name | String | Yes | The name of the endpoint. |
| Http.Endpoints.Endpoint.Requests |  | Yes | The element containing all requests to be sent to the endpoint. |
| Http.Endpoints.Endpoint.Requests.Request |  | Yes | The request to be sent. |
| Http.Endpoints.Endpoint.Requests.Request.fileName | String | No | The name of the file in which the response has to be saved. Default: \<Endpoint.name> \<Endpoint.Requests.Request>.txt |

##### Collectors of type Exe

Collectors of type “Exe” can be configured using the following XML elements and attributes:

| Element/attribute | Type | Mandatory | Description |
|--|--|--|--|
| Exe@name | String | Yes | The name for the collector. |
| Exe.Source |  | Yes | The folder in which the executable is located. |
| Exe.Executable |  | Yes | The name of the executable. |
| Exe.Destination |  | Yes | The (relative) path to the destination folder in the archive. |
| Exe.Commands |  | Yes | The element containing all commands to be run. |
| Exe.Commands.Command |  | Yes | The command to be run. |
| Exe.Commands.Command@fileName | String | No | The name of the file in which the result has to be saved. Default: \<executable> \<command>.txt |

#### DataMiner Cube: Minor enhancements with regard to views, elements and services \[ID_31742\]

A number of minor enhancements have been made with regard to views and elements:

- The *System Info* name (*System Center \> Agents*), which is used as root view name, can no longer be the name of an existing view.
- Users will now receive a clearer error message when they try to create an element or a service with a name that starts or ends with a space.
- When, in a view card, you right-click the header of the “Below this view” list, the context menu that appears is empty when the system has no properties defined. Now, when the context menu is empty, a message will be displayed, explaining users why it is empty.
- Up to now, when multiple items were selected in the “Below this view” list of a view card, selecting one item would not clear the selection. From now on, it will do so.
- When, in the “Below this view” list of a view card, you sort the list by alarm state, the list will be sorted by severity (default: descending).
- When, in a view card, you right-click the header of the “Below this view” list, the overall responsiveness of the context menu has been enhanced.

#### Chromium web browser control: Enhancements with regard to the translations of the find and zoom commands \[ID_31755\]

A number of enhancements have been made with regard to the translations of the find and zoom commands of the Chromium web browser control.

#### Enhanced performance when editing an element \[ID_31846\]

Due to a number of enhancements, overall performance has increased when editing an element.

Also, up to now, when an element was edited, all tab characters (“\\t”) in field content would be replaced by spaces. From now on, tab characters will be left untouched.

#### Unclear 'version of the protocol is not correct' notice replaced by 'DataMiner version is too low to use this protocol. Please check the protocol's Compliancies tag.' notice \[ID_31855\]

When a protocol had a minimum DataMiner version that was higher than the DataMiner version of the DMA, up to now, an unclear “version of the protocol is not correct” notice would appear in the Alarm Console and the log files. From now on, that unclear notice will be replaced by a clearer “DataMiner version is too low to use this protocol. Please check the protocol's Compliancies tag.” notice.

#### SLLogCollector: Process list will now also include processes of which the name starts with 'DataMiner' \[ID_31883\]

The SLLogCollector tool will now also list all processes of which the name starts with “DataMiner”. This will allow you to also take memory dumps of processes like “DataMiner CloudGateway”, “DataMiner CoreGateway”, “DataMiner FieldControl”, “DataMinerCube”, etc.

Also, an issue was fixed where duplicate entries would appear in the list after a DMA restart while the tool was open.

#### Elasticsearch: Backup timeout increased to 15 minutes \[ID_31595\]

The timeout of Elasticsearch backups has been increased from 1 minute to 15 minutes.

This applies to backups taken via DataMiner as well as backup taken via the Standalone Elastic Backup tool.

#### Service & Resource Management: Ending an ongoing booking by changing the end time will now cause all missed events to be run \[ID_31907\]

When the end time of an ongoing ReservationInstance is set to a time stamp in the past, from now on, all events that have not been run when the booking ended will be run.

#### DataMiner Cube - System Center: New LDAP settings \[ID_31924\]

In *System Center*, the *LDAP* tab of the *System settings* section allows you to configure a number of LDAP settings. A number of changes have now been made to the *General* tab.

- The *Use custom configuration* option has been replaced by the *Referral configured* option.

- A new *SSL/TLS* option has been added. Enable this option if you want DataMiner to use SSL/TLS when connecting to the LDAP server.

#### SLDataMiner: Enhanced locking when editing elements \[ID_31948\]

A number of enhancements have been made to SLDataMiner with regard to element locking, especially when editing elements.

#### Enhanced socket cleanup after closing a serial connection \[ID_31955\]

A number of enhancements have been made with regard to socket cleanup after closing a serial connection, especially in situations where the “closeConnectionOnResponse” option is enabled or when a close action is performed.

#### DataMiner Taskbar Utility: Improved entering of credentials before testing the SLNet connection \[ID_32079\]

When you right-click the Taskbar Utility icon and select *Options*, in the *SLNet* tab, you can enter your credentials and click *Test & Save Connection* to test the connection to SLNet.

Up to now, in some cases, you could experience some lag while entering your credentials. From now on, entering your credentials will go much smoother.

#### Updated BPA tests \[ID_32102\]

The following BPA tests have been updated:

- Cassandra DB Size

- Check Antivirus DLLs

#### DataMiner Cube - Visual Overview: Spectrum Analysis component now allows combining an inline preset with one or more measurement points \[ID_32101\]

When configuring a Spectrum Analysis component, it is now possible to combine an inline preset with one or more measurement points.

#### Replication: Name of the local element will now be logged in SLReplication.txt when a replication connection is set up \[ID_32109\]

When a replication connection is set up to another DataMiner Agent, from now on, the name of the local element for which that connection is set up will be logged in the SLReplication.txt file.

#### SLLogCollector will now also by default collect the most recent backup\_\*.log.txt file and all Database\\\*.xml files \[ID_32114\]

From now on, SLLogCollector will also by default collect the following files:

- The most recent backup\_\*.log.txt file in C:\\Skyline Dataminer\\Backup

- All \*.xml configuration files in C:\\Skyline Dataminer\\Database

### Fixes

#### Cassandra: Problem when creating user-defined types \[ID_31001\]

On systems with a Cassandra database, in some rare cases, creating user-defined types could fail and return an exception.

When creating the user-defined types failed during a migration from MySQL to Cassandra, the following exception could be thrown:

```txt
The migration has failed.DBGatewayException(SLCassandraClassLibrary.DBGateway.Cassandra.StorageManagers.SingleNode.CassandraConnection,,UNKNOW SLDataGateway.Types.DBGatewayException: CassandraConnection CreateCustomType - no host available All hosts tried for query failed.
```

#### Problem with SLProtocol when trying to parse data received from SLPort \[ID_31676\]

In some cases, an error could occur in SLProtocol when trying to parse data received from SLPort.

#### Problem with SLDataMiner when a trigger to reload service settings was delayed & memory leak in SLElement \[ID_31711\]

When a trigger to reload service settings was delayed, in some cases, a run-time error could occur in the service thread of SLDataMiner.

Also, SLElement could leak memory when services were configured with a delayed trigger or a redundancy condition that persisted for a period of time.

#### Deadlock in SLDataGateway could cause data to not get written to the database \[ID_30717\]

In some cases, a deadlock in the SLDataGateway process could cause e.g. Correlation rule data to not get written to the database and remain in memory indefinitely.

#### Problem with SLElement after restarting an element with a subscription that had a 'resolve' or 'filter' option configured \[ID_31741\]

When there was an active element subscription with a “resolve=x” or “sort=x” filter option configured, in some cases, an error could occur in SLElement when processing table changes after an element restart.

#### SLPort could incorrectly accept a payload containing only a trailer and forward it to SLProtocol \[ID_31743\]

In case of a serial protocol, when both a header and trailer were configured for a response, in some cases, SLPort could incorrectly accept a payload containing only a trailer and forward it to SLProtocol before the timeout of the command was reached.

From now on, if a payload contains only a trailer, the socket buffer will be read until the configured timeout is reached and then the payload will be forwarded to SLProtocol.

#### SLA: Problem when an update of an SLA setting coincided with a window change \[ID_31750\]

When an update of an SLA setting (e.g. Base timestamp, Monitor span, Window size, Window Unit, Window type, Validity start or Validity end) coincided with a window change, in some rare cases, the next window would incorrectly be taken instead of the window that triggered the change. This would cause calculations to incorrectly use a timestamp in the future.

#### Failover: Redundancy groups containing DVE elements would not get loaded after a Failover switch or a restart of the Failover system \[ID_31765\]

After a Failover switch or a restart of a Failover system, in some cases, redundancy groups containing DVE elements would incorrectly not get loaded.

#### 'Duplicate name detected' notice would incorrectly be generated when turning a service into an enhanced service or vice versa \[ID_31801\]

When a service was turned into an enhanced service, or when an enhanced service was turned into a regular service, a “Duplicate name detected” notice would incorrectly be generated.

#### DataMiner Cube: Miscellaneous small fixes \[ID_31802\]

In DataMiner Cube, a number of small fixes have been made:

- In a tree control, the tab borders would not be visible in the Skyline Black theme.
- Undocking the Alarm Console could affect the layout of the main Cube window.
- When you pressed ENTER in an editable table cell, a trend graph would incorrectly open instead of the table cell editor.
- When an element was restarted, in some cases, a table would incorrectly stay grayed out.
- A parameter containing a disabled exception value would stay disabled after it had received a normal value.

#### SLElement: Problem with invalid parameter IDs in the Generic DVE Linker Table \[ID_31805\]

When creating resources, the \[Generic DVE Linker Table\] is used to link a row from the \[Generic DVE Table\] to any other table. Up to now, in some cases, invalid parameter IDs in the \[FK Table\] column would result in invalid relations being constructed in SLElement’s memory.

From now on, the values from the \[FK Table\] will be checked against the protocol's parameters and a functioning link will only be made when a table with such a parameter ID exists in the element.

#### DataMiner Cube - Settings: Filtered alarm tabs configured to show active alarms and masked alarms would incorrectly only show active alarms \[ID_31815\]

When, in the Settings app, you had configured a filtered alarm tab to contain both active alarms and masked alarms, that alarm tab would incorrectly only show active alarms.

#### Problem when SLAnalytics was stopped while it was writing to the database \[ID_31824\]

When SLAnalytics was stopped while it was writing to the database, in some rare cases, caching issues could occur.

#### Ticketing app: Problem with Ticket exposer \[ID_31826\]

When the Ticket exposer was used with a filter like the one below, in some cases, incorrect results would be returned:

```csharp
var query = TicketingExposers.Ticket.Contains(@"7999").ToQuery();
```

#### DataMiner Cube - Visual Overview: Connection between two shapes would incorrectly not be hidden when one of the shapes was hidden \[ID_31839\]

When a shape with a connection to another shape was hidden, in some cases, the connection between the two shapes would incorrectly not be hidden.

#### SLProtocol could leak memory when an enhanced service was tracking alarms that contained duplicate property names \[ID_31851\]

When an enhanced service was tracking alarms, SLProtocol could leak memory when an alarm contained duplicate property names.

Also, the same process could leak memory when a table parameter was cleaned up after an element restart.

#### SLPhotoManager would incorrectly log 'PrincipalServerDown' exceptions in SLErrors.txt when trying to retrieve pictures of local users \[ID_31865\]

Up to now, when SLPhotoManager was unable to retrieve pictures of local (i.e. non-LDAP) users, it would incorrectly log “PrincipalServerDown” exceptions in the SLErrors.txt log file. From now on, it will log those exceptions in the SLPhotoManager.txt log file when the debug level is set to 5.

#### Web apps - Visual Overview: Native controls inside clickable child shapes would incorrectly not be displayed \[ID_31871\]

When, in a web app, a visual overview had interactive parent shapes with clickable child shapes that contained a native control (e.g. view shapes containing an embedded browser control), that control would incorrectly not be displayed.

#### Scheduled tasks configured to take a DataMiner backup, optimize the database or perform an LDAP resynchronization would incorrectly not get executed \[ID_31877\]

In some cases, scheduled tasks configured to take a DataMiner backup, optimize the database or perform an LDAP resynchronization would incorrectly not get executed.

#### Visual Overview: Hidden pages of an embedded Visio file would incorrectly be displayed when viewed in a web app \[ID_31881\]

When an embedded multi-page Visio file with hidden pages was viewed in a web app, the hidden pages would incorrectly be displayed.

#### Elements of which the second port was incorrectly configured would no longer start up \[ID_31882\]

Elements of which the second port was incorrectly configured would no longer start up. In some cases, a port could get configured incorrectly after the production version of a protocol had been changed to a version with an additional port.

Editing the element, setting any missing port values and saving the element configuration will fix this kind of problem. Therefore, whenever the system detects an element with an incorrect port configuration, from now on, a notice alarm with the following text will be generated for that element:

```txt
Initializing the communication of port (x) failed. Please verify the connection settings in the Edit window of the element.
```

> [!NOTE]
> Even if the second port of an element is a hidden port that does not require any configuration, the system will generate a notice alarm like the one above when it detects any anomalies in the port settings.

#### DataMiner Cube - Visual Overview: DCF signal paths would not be visualized correctly on pages with a grid layout \[ID_31888\]

In some cases, a DCF signal path would not be visualized correctly on Visio pages with a grid layout.

#### SLNet would thrown an 'Arithmetic operation resulted in an overflow' exception when performance information was being calculated \[ID_31894\]

In some cases, SLNet would thrown an “Arithmetic operation resulted in an overflow” exception when performance information was being calculated.

#### Exported protocols would incorrectly have the same Protocol.Description and Protocol.Type as their parent protocol \[ID_31904\]

Up to now, the Protocol.Description and Protocol.Type values in an exported protocol would incorrectly be identical to those of the parent protocol. From now on, the Protocol.Description and Protocol.Type elements of an exported protocol will contain the export name and the virtual type instead.

#### Errors occurring while deleting Cassandra compaction and repair tasks could affect the DataMiner startup routine \[ID_31921\]

When a DataMiner Agent with a Cassandra cluster configuration starts up, any scheduled task to compact or repair the Cassandra database is deleted. Up to now, when an error occurred while deleting such a task, in some cases, the DataMiner Agent would not start up correctly.

From now on, any error that occurs while deleting Cassandra compaction and repair tasks will no longer affect the DataMiner startup routine.

#### Dashboard Gateway was not able to access the dashboard configuration files of user accounts other than the one used to set up the Dashboard Gateway connection \[ID_31926\]

Since DataMiner version 10.0.10, a Dashboard Gateway would no longer be able to access the dashboard configuration files of user accounts other than the one used to set up the Dashboard Gateway connection.

From now on, a Dashboard Gateway will be able to access the dashboard configuration files of all users when the user account that is used to set up the Dashboard Gateway connection has been granted the *Modules \> System configuration \> Tools \> Admin tools* permission.

#### DataMiner Cube - Visual Overview: DCF connections incorrectly not shown when opening a second visual overview for the same element \[ID_31931\]

When you had opened a visual overview with DCF information for a particular element, and you opened another visual overview with DCF information for that same element, in some rare cases, the latter would incorrectly not show any DCF connections.

#### Problem when reading out a parameter or element latch \[ID_31932\]

When DataMiner was started or when an element was started, in some cases, the following event could appear in the Windows event viewer:

```txt
Could not read element latch for DMAID/EID. 0x80131533
```

#### Dashboards app: 'Top X alarms' chart would incorrectly not include a graph in a PDF report \[ID_31949\]

When a PDF report was generated of a dashboard containing a “top X alarms” chart based on alarm state duration, in some cases, that chart would incorrectly not include a graph when set to stacked mode.

#### 'Service Manager not licensed' error when synchronizing files on DataMiner Agents that do not have a Service Manager license \[ID_31958\]

In some cases, when a DataMiner Agent did not have a Service Manager license, a “Service Manager not licensed” error would be thrown when synchronizing files. From now on, when a DataMiner Agent does not have a Service Manager license, no attempt will be made to synchronize system function definitions when synchronizing files.

#### Failover: Standalone BPA Executor could incorrectly not be launched from an offline agent \[ID_31959\]

When, in a Failover setup, the Standalone BPA Executor was launched from the offline agent, up to now, it would throw an exception, stating that the agent was offline. Because this tool must be able to run certain tests on offline agents, it has now been made possible for the Standalone BPA Executor to be launched from an offline agent.

#### GetAnalogTrendDataMessage would incorrectly return 5-minute data point when more than 48 hours of trend data was requested \[ID_31970\]

When a GetAnalogTrendDataMessage was used to retrieve more than 48 hours of trend data for a particular element, in some cases, the result set would incorrectly contain 5-minute data points instead of 60-minute data points.

#### DataMiner Cube - Visual Overview: Trend graph would incorrectly not be loaded when clicking a trend icon \[ID_31978\]

When, in a visual overview that showed a table with trended columns, you opened a trend graph by clicking a trend icon, in some cases, the trend graph would incorrectly not be loaded and a “Trending is currently not enabled for this parameter” message would appear.

#### Cassandra: Incorrect 'null statement' messages would be added to SLDBConnection.txt \[ID_31979\]

In some cases, the following message would repeatedly be added to the SLDBConnection.txt log file:

```txt
Cassandra: tried to execute null statement.
```

#### Failover: Initial file synchronization would incorrectly not be performed \[ID_31991\]

When a standalone DataMiner Agent had been added to a Failover setup, in some cases, the initial file synchronization from online agent to offline agent would incorrectly not be performed.

#### Problem when creating separate SLScripting processes for every protocol being used \[ID_32015\]

In the DataMiner.xml file, you can configure to have separate SLScripting processes created for every protocol being used. When this option was enabled, up to now, when SLScripting processes would crash, in some cases, they would either not get recreated or too many SLScripting processes would get created.

#### Failover: Certain system files would incorrectly not get synchronized to the offline agent during the initial sync \[ID_32034\]

When a Failover system was set up, certain system files (e.g. PropertyConfiguration.xml) would incorrectly not get synchronized to the offline agent during the initial sync.

#### DataMiner Cube: Information templates could no longer be edited when connected to a DataMiner Agent installed on Windows Server 2016 \[ID_32035\]

In DataMiner Cube, in some cases, it would no longer be possible to edit information templates; especially when connected to a DataMiner Agent installed on Windows Server 2016.

#### DataMiner Cube - Alarm Console: Alarms coming in while grouping or sorting an alarm tab would incorrectly not appear in that alarm tab \[ID_32051\]

In some rare cases, alarms coming in while you were grouping or sorting the alarms on an alarm tab would incorrectly not appear on that alarm tab, especially on heavy-duty systems.

#### Legacy Dashboards: Using 'Add to dashboard' in Cube would no longer work when the DataMiner Agent was only accessible via HTTPS \[ID_32083\]

From DataMiner 9.0 onwards, it is possible to add items to a legacy dashboard directly from the Cube UI, for instance from the Surveyor or an element card.

This functionality would no longer work when the DataMiner Agent was only accessible via HTTPS.

#### DataMiner upgrade: SLNet could load an incorrect version of the SLUpgrade.dll file \[ID_32094\]

To be able to check the prerequisites during a DataMiner upgrade, SLNet needs to load the SLUpgrade.dll file. In some cases, it would load the 32-bit version instead of the 64-bit version or vice versa.

#### SLReset would incorrectly delete the Webpages\\root and Webpages\\monitoring folders \[ID_32139\]

Up to now, SLReset would incorrectly delete the following folders:

- C:\\Skyline DataMiner\\Webpages\\root
- C:\\Skyline DataMiner\\Webpages\\monitoring

From now on, SLReset will no longer delete these folders.

#### Newly created elements would incorrectly be assigned an ID equal to -1 \[ID_32178\]

In some cases, newly created elements would incorrectly be assigned an ID equal to -1.
