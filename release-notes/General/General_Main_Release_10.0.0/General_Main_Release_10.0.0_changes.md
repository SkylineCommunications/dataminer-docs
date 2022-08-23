---
uid: General_Main_Release_10.0.0_changes
---

# General Main Release 10.0.0 - Changes

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!IMPORTANT]
> From DataMiner 10.0.0/10.0.2 onwards, DataMiner Service & Resource Management also requires DataMiner Indexing.

## Changes

### Enhancements

#### HTML5 apps: Enhanced UI component consistency \[ID_18892\]

The UI components used in all DataMiner HTML5 apps have now been made more consistent.

#### DataMiner Cube - Alarm Console: Enhanced service information \[ID_18310\]\[ID_19131\]

When you load a history tab page with a service filter, in some cases, not all service properties are added to the alarms. From now on, when you add a service property column to an alarm tab, a warning icon will be shown in the column header. When you hover over that icon, a tooltip will appear, indicating that some properties are not shown and that you should open the alarm card to view them all.

#### HTML5 app: Embedded spectrum components and spectrum thumbnails \[ID_18479\]\[ID_19297\]

From now on, the HTML5 app fully supports spectrum components and spectrum thumbnails embedded in Visual Overview. Up to now, those components and thumbnails would be rendered as static images.

#### DataMiner Cube: Enhanced visualization of names of table column parameters \[ID_18928\]\[ID_20175\]\[ID_20252\]\[ID_20294\]\[ID_20299\]\[ID_20309\]

From now on, in DataMiner Cube, table column parameters will be referred to by either their long display name or their short display name:

- Long display name (default name, consisting of both the table name and the column name)
- Short display name (shorthand name used e.g. inside tables and in table side panels)

The long display name of a table column parameter can be formatted in two ways:

- \[TableName\]:\[ColumnName\] (default format, e.g. “MyTable: MyTableColumn01”)
- \[ColumnName\] (\[TableName\]) (e.g. “MyTableColumn01 (MyTable)”)

#### Names of existing properties can no longer be changed \[ID_18930\]

From now on, it is no longer possible to change the name of an existing property.

#### Enhanced downgrade and upgrade actions for TTL settings \[ID_18946\]

When a DataMiner System is upgraded from a version that did not use the TTL settings in *DBMaintenance.xml* and *DBMaintenanceDMS.xml* yet to a more recent version, the deprecated settings in *MaintenanceSettings.xml* will be cleared and replaced by a note mentioning that these settings have been moved to the new DBMaintenance files. When a downgrade is executed to such an older version, the old settings will be recalculated and the values of these settings will be restored.

#### OpenSSL library version 1.1.1c now included with DataMiner \[ID_19026\]\[ID_22956\]

From now on, OpenSSL library version 1.1.1c will be included with DataMiner.

#### Web Services - HTML5 app: dependencyId and dependencyValues now supported \[ID_19130\]

The DataMiner web services and HTML5 application now support protocols using the *dependencyId* and *dependencyValues* functionality.

#### Enhanced performance due to reduction of data traffic to and from the LDAP server \[ID_19135\]

Due to a reduction of the data traffic to and from the LDAP server, overall performance has increased.

#### DataMiner Cube - Alarm Console: Enhanced time range options for new history tab \[ID_19285\]

In a new empty tab in the Alarm Console, the time range options to create a history tab have been rephrased and a new "More..." option is now available. Clicking the latter will open a pop-up window where you can select one of several preconfigured quick ranges or specify a custom range.

In addition, in the Settings app, these changes have also been implemented for the configuration of a default history tab for a user or group.

#### Database: Default value of HistorySlider setting set to 1 month \[ID_19299\]

The default value for the *HistorySlider* setting in the file *DB.xml* (which determines how long history alarm information is kept in the Cassandra database so that it can be visualized with the history slider in the Alarm Console) has now been set to 1 month. This change will only affect new installations or upgrades of systems where no default value had been set for this setting yet.

#### HTML5 app: Executing an Automation script by clicking a shape \[ID_19306\]

From now on, similar to DataMiner Cube, the HTML5 app also supports executing an Automation script by clicking a shape.

#### DataMiner Cube - Visual Overview / DCF: Enhanced positioning of connection property shapes in grid layout \[ID_19352\]

Up to now, when element shapes with connectivity were positioned in a grid layout, in some cases, connection property shapes would not be positioned correctly because of rescaling. From now on, those property shapes will no longer be rescaled, not even when the size of the Visio page is changed.

#### DELT import/export packages: Description.txt and Package.xml now also mention the DataMiner version that was used to create the package \[ID_19357\]

Up to now, when you created a DELT package, the *Description.txt* and *Package.xml* files mentioned the user who created the package and the time at which the package was created. From now on, those two files will also contain the DataMiner version that was used to create the package.

#### SLSNMPAgent: Service description changed \[ID_19417\]

The description of the SLSNMPAgent service has been changed from “Skyware SNMP Agent” to “SLSNMPAgent”.

#### Possibility to copy property value of alarm to other alarm field or property \[ID_19421\]

It is now possible to have the value of a property that is available for an alarm copied to a predefined field of the alarm (i.e. the *Owner*, *Comment*, *Element Name* or *Parameter Name* field) or to another property.

To do so, in the *PropertyConfiguration.xml* file, add the *copyToAlarmField* attribute to the *Property* tag of the property that needs to be copied, and set it to the correct keyword:

| Field                          | Keyword                   |
|--------------------------------|---------------------------|
| Comment                        | \[COMMENT\]               |
| Element Name                   | \[ENAME\]                 |
| Owner                          | \[OWNER\]                 |
| Parameter Name                 | \[PNAME\]                 |
| Alarm property called "name"   | \[PROPERTY:ALARM:name\]   |
| Element property called "name" | \[PROPERTY:ELEMENT:name\] |
| Service property called "name" | \[PROPERTY:SERVICE:name\] |
| View property called "name"    | \[PROPERTY:VIEW:name\]    |

For example:

```xml
<Property id="21" type="Element" name="Location" copyToAlarmField="[ENAME]" />
```

#### DataMiner Cube: New label indicating new trend group that is being added \[ID_19526\]

When a new trend group is being added in DataMiner Cube, a "\[new\]" label will be added to the trend group name in the pane that lists the existing trend groups, just as this is done for scripts in the Automation app, for example.

#### DataMiner Cube - Visual Overview: ParametersSummary enhancements \[ID_19568\]

Up to now, if you specified a table parameter in a shape data item of type *ParametersSummary*, only one row was allowed to match the filter. From now on, it is possible to refer to several rows, a column, or a full table.

Examples:

- To refer to all rows that start with “SL”, you can specify “101/201:500:SL\*\|”.
- To refer to a column, specify the column parameter, e.g. “101/201:501”.
- To refer to an entire table, specify the table parameter, e.g. “101/201:500”.

#### Database: Improved handling of large batches for Cassandra database \[ID_19586\]

The way batches are written to the Cassandra database has been improved, so that larger batches can now be written. This can improve performance, especially for systems that are under a heavy load.

#### DataMiner Cube: Files now signed with COMODO certificate \[ID_19675\]

The following DataMiner Cube files are now signed with a COMODO certificate:

- C:\\Skyline DataMiner\\webpages\\DataMinerCubeInstall\\setup.exe
- C:\\Skyline DataMiner\\webpages\\DataMinerCube\\DataMinerCube.xbap
- C:\\Skyline DataMiner\\webpages\\DataMinerCubeStandalone\\DataMinerCube.application
- C:\\Skyline DataMiner\\webpages\\DataMinerCube\\DataMinerCube.exe
- C:\\Skyline DataMiner\\webpages\\DataMinerCubeStandalone\\DataMinerCube.exe
- C:\\Program Files (x86)\\Skyline Communications\\DataMiner Cube x.x.x.x\\DataMinerCube.exe
- C:\\Skyline DataMiner\\webpages\\Tools\\Installs\\DataMiner Cube.msi

Note that a security warning will now always appear when you download a new DataMiner Cube version. To prevent this warning from appearing, you can import the certificate into your Windows Certificate Store as follows:

1. When the security warning appears, click “Skyline Communications NV” under *Publisher*.

2. At the bottom of the *Certificate* window, click *Install Certificate...*

3. In the *Certificate Import Wizard* window, set *Store Location* to “Current User”, click *Next*, and follow the instructions in the wizard to complete the process.

    > [!NOTE]
    > Make sure all certificates are placed in the certificate store called “Trusted Publishers”.

#### Improved logging in case local database connection fails because of Db.xml configuration \[ID_19682\]

If no active local database has been configured in *Db.xml* and the database connection therefore fails, this will now cause a clear message to be logged in *SLDBConnection.txt*, stating that the local database could not be found and *Db.xml* should be verified.

#### DMS Ticketing: Ticket link filtering \[ID_19754\]

DataMiner Ticketing now allows you to filter tickets by ticket link.

#### Improved retrieval of information event history \[ID_19755\]

Historical information events are now retrieved more efficiently, so that these will be displayed in the Alarm Console more quickly.

#### Direct connection no longer limited to specific element \[ID_19790\]

To create a direct connection in a protocol (via a QAction), it is now no longer necessary to specify a DMA ID/Element ID. Instead of connecting to a specific element, you can now create multiple direct connections that are not tied to an element.

#### SLSNMPManager: SNMP++ library upgrade \[ID_19796\]

From now on, the SLSNMPManager process will use SNMP++ library version 3.3.11.

#### Web Services API: WebSocket connections will now be closed when the API is stopped \[ID_19928\]

Up to now, when the Web Services API was stopped by IIS, the existing WebSocket connections would not immediately be closed. IIS would wait a certain amount of time before forcefully terminating the connections. From now on, the Web Services API will listen to IIS for notifications on when to terminate the connections gracefully.

#### Service & Resource Management: Enhanced performance when disabling DVE element after service have ended \[ID_19947\]

Due to a number of enhancements, overall performance has increased when disabling DVE elements after service have ended.

#### Enhanced masking of DataMiner objects \[ID_20033\]\[ID_21654\]

A number of enhancements have been made with regarding to the masking of DataMiner objects (elements, alarms, redundancy group, DVE elements) via user interfaces or Automation.

> [!NOTE]
> All masking information of alarms and elements will now be stored in the *maskstate* table.

#### SLAnalytics now supports asynchronous communication \[ID_20051\]

The SLAnalytics process now allows requests to be sent either synchronously or asynchronously.

#### DataMiner Cube - Ticketing: Cube now ignores tickets without link \[ID_20088\]

Previously, when Cube connected to the DMS, it cached all the tickets from the DMS. To improve efficiency, now only tickets with a link to a DataMiner object will be cached. In addition, if new tickets are created that have no link to a DataMiner object, Cube will ignore these.

#### Service & Resource Management: 'NextAvailableStates' added to SRMServiceState object \[ID_20282\]

A list of NextAvailableStates has been added to the SRMServiceState object. This means that, using the ServiceManagerHelper class in an Automation script, it is possible to save the next available states of an SRM service.

#### Services: Enhanced alarm and element state update mechanism \[ID_20329\]

A number of enhancements have been made to the mechanism that is used to update alarms and element states within a service.

#### Enhanced performance when retrieving view impact data from elements \[ID_20353\]

Due to a number of enhancements, overall performance has increased when retrieving view impact data from elements.

#### Improved logging in case of invalid SNMPv3 trap \[ID_20356\]

The error information in the SNMPManager log file in case an invalid SNMPv3 trap is received has been improved.

#### Support for GetBulk requests \[ID_20362\]

GetBulk requests are now supported by DataMiner (for SNMPv2 and SNMPv3).

#### DataMiner Cube: Users with access to a child view will now automatically have access to the parent view \[ID_20505\]

If users have been granted access to a child view, from now on, they will automatically be granted access to the parent view.

#### Profile Manager: Improved performance when loading profile instances and definitions \[ID_20549\]

In the Profile Manager app, profile instances and definitions will now be loaded more efficiently.

#### DataMiner Cube - Security: Service & Resource Management permissions moved into one category \[ID_20586\]

In the *Users / Groups* app, the different user permissions related to the Service & Resource Management module have been moved into one category. This means that the Profile Manager, Resource Manager and Service Manager user permissions can now be found under *Service & Resource Management* instead of under the separate app names.

#### DataMiner Cube - Visual Overview: ChildrenFilter shape data now supports placeholders \[ID_20664\]

It is now possible to use placeholders such as *\[var:\]* and *\[param:\]* within *ChildrenFilter* shape data. This can for instance be used to filter child shapes using a session variable in the filter value.

#### Automation/Scheduler: Email action now supports CPE reports \[ID_20692\]

It is now possible to send a CPE report via an Automation script or scheduled task. When configuring the email action in the script or task, if you select to attach a CPE report, you will now be able to select a CPE Manager, along with a chain and one or more fields of the selected chain. For each field, a number of KPI parameters can then be selected, optionally with a filter.

#### Backup/restore now includes Service Manager and Protocol Function Manager modules \[ID_20713\]

DataMiner Backup/Restore now also includes the Service Manager and Protocol Function Manager modules.

#### Users with an expired password now only have to change it on one agent in the DataMiner System \[ID_20717\]

Up to now, users of whom the password had expired had to change their password on every agent in the DataMiner System. From now on, they will only have to change it on one of the agents.

#### Enhanced performance when large amounts of data are being stored in Cassandra \[ID_20850\]

Due to a number of enhancements, overall performance has increased when storing large amounts of data in a Cassandra database.

#### Enhanced performance when configuring protocol-level TTL settings \[ID_20908\]

Due to a number of enhancements, overall performance has increased when configuring protocol-level TTL settings.

#### DataMiner Cube: Enhancements for elements in timeout \[ID_20910\]

When an element is in the timeout state, any write parameters of this element will now be disabled. In addition, all parameters of the element will be displayed in such a way that it is clear to the user that there is currently no connection with the device. In addition, at the bottom of the card, a message will be displayed to notify the user that the element is in timeout.

#### New Logging.DaysToKeep tag in DataMiner.xml \[ID_20911\]

In the file *DataMiner.xml*, a new *\<DaysToKeep>* subtag can now be specified within the *\<Logging>* tag, which will determine for how many days log files are kept in the folder *C:\\Skyline DataMiner\\Logging*. If this tag is not specified or if its value is 0, log files will be kept for 100 days.

Example:

```xml
<DataMiner>
  ...
  <Logging>
  ...
  <DaysToKeep>30</DaysToKeep>
  </Logging>
  ...
</DataMiner>
```

#### DataMiner Cube: Contacts panel now also shows users logged into mobile apps \[ID_20934\]

If a user is logged into the Monitoring app (formerly known as the HTML5 app), the new Job Manager app or the Ticketing app, this user will now also be displayed in the *Contacts* panel in DataMiner Cube.

#### Windows feature 'Websockets' automatically enabled as from DataMiner 9.6.5 \[ID_20974\]

As from DataMiner 9.6.5, the Windows feature “Websockets” will automatically be enabled.

> [!NOTE]
> After upgrading to DataMiner 9.6.5, a message may appear, stating that a reboot is required. Note that a reboot is only required when you plan to use the new Dashboards app.

#### Failover: Alarm generated when the two DataMiner Agents in a Failover setup do not have the same DataMiner version \[ID_20951\]\[ID_21032\]

From now on, a “version mismatch on failover pair” alarm of type “error” will be generated when the two DataMiner Agents in a Failover setup do not have the same DataMiner version.

#### Increased performance at DataMiner startup due to enhanced management of TXF files \[ID_21057\]

Due to a number of TXF file management enhancements, overall performance has increased at DataMiner startup.

#### MySQL connector upgraded to v6.9.12 \[ID_21064\]

The MySQL connector has been updated to v6.9.12.

#### Ticketing: Removing ticketing domain no longer possible while a DMA is unavailable \[ID_21100\]

To prevent synchronization issues, it is no longer possible to delete a ticketing domain while one of the Agents in the DMS is unavailable.

#### Enhanced performance by caching TXF files at SLXml startup \[ID_21139\]

From now on, all existing TXF files will be cached when the SLXml process is started. This will enhance overall performance.

#### Service & Resource Management: 'IsIDP' property now indicates if booking instances uses IDP resources \[ID_21168\]

When a booking instance that uses IDP resources is saved, the server will now automatically make sure that it has the property *IsIDP* set to true. This property can only be set on systems with an IDP license.

#### Ticketing/Automation: New type property in TicketFieldDescriptor and TicketFieldOverrideConfig class \[ID_21202\]

A new type property is now available in the *TicketFieldDescriptor* and *TicketFieldOverrideConfig* class, which allows you to define a custom alarm property type when linking an alarm property to a ticket field.

#### DataMiner Cube - Visual Overview: Visio pages displayed in mobile apps are now refreshed via WebSockets \[ID_21291\]\[ID_21941\]\[ID_21971\]

If WebSockets are enabled, from now on, Visio pages displayed in mobile apps will be refreshed using WebSockets. If WebSockets are not enabled, those pages will be refreshed as before, using a polling mechanism.

#### Database: Table creation scripts will now also create a SnapshotData table \[ID_21343\]

The following table creation scripts (found in C:\\Skyline DataMiner\\Tools) will now also create a SnapshotData table:

- CentralTabledef.txt
- CentralTabledefOracle.sql
- CentralTabledefOracleUninstall.sql
- CentralTableDefSQLServer.sql

#### DataMiner Maps: View impact data now taken into account when calculating alarm states of CPE markers \[ID_21384\]

If the source table of CPE markers has a “View Impact” column, the alarm states of the views specified in that column will now taken into account when calculating the alarm states of the CPE markers.

#### DataMiner Cube: No more warning message when changing the protocol of an element \[ID_21407\]

When you changed the protocol of an existing element, up to now, a “This will clear any unsaved changes. Do you wish to proceed?” message would appear.

From now on, this message will no longer appear.

#### Enhanced performance when dynamically including elements in services based on DCF connectivity settings \[ID_21408\]

Due to a number of enhancements, overall performance has increased when dynamically including large amounts of elements in services based on DCF connectivity settings.

#### DataMiner Cube: Redundancy groups can enter the 'Undefined' state if one or more of the switching detection triggers cannot be resolved \[ID_21414\]\[ID_22842\]

From now on, a redundancy group can enter the “Undefined” state if one or more of the switching detection triggers cannot be resolved.

#### SNMP++ library now allows user names to have multiple credentials \[ID_21458\]

The SNMP++ library now allows user names to have multiple different credentials.

Up to now, a user was considered unique based on the user name only. From now on, a user will be considered unique based on the following set of properties:

- user name
- authentication protocol
- authentication password
- privacy protocol
- privacy password

> [!NOTE]
> oidUsmStatsUnknownUserNames (1.3.6.1.6.3.15.1.1.3.0) will no longer trigger a security parameter refresh.

#### DataMiner Indexing now supports Elastic up to version 6.8.0 \[ID_21581\]\[ID_22451\]

DataMiner now supports Elastic up to version 6.8.0.

#### DataMiner Cube - Visual Overview: Bookings component now also available with IDP license \[ID_21591\]\[ID_21686\]

Previously, to have access to a *Bookings* component embedded in Visual Overview, a Resource Manager license had to be available. Now this component will also be available in case an IDP license is available.

#### Cassandra database: Custom data types now also saved to file when database goes down \[ID_21631\]

By default, when the database goes down all data is saved to file, and later, when the database is on-line again, the data in the file is flushed to the database.

From now on, the data that is saved to file will also include the custom data types.

#### Server-side table sorting now uses a natural sorting algorithm \[ID_21705\]\[ID_22243\]

From now on, server-side table sorting will use a natural sorting algorithm.

> [!NOTE]
> MAC addresses will always be sorted by value.

#### Enhanced performance of CPE crawler \[ID_21711\]

Due to a number of enhancements, overall performance of the CPE crawler has increased.

#### A DataMiner Agent can no longer be restarted without restarting SLNet \[ID_21719\]

Up to now, when you restarted a DataMiner Agent, you had the option to either also restart the SLNet process or not. From now on, when you restart a DataMiner Agent, the SLNet process will always be restarted as well.

#### SRM/Automation: IsValueCopy property added to ProfileInstance class \[ID_21797\]

The property *IsValueCopy* has been added to the *ProfileInstance* class. This property makes it possible to distinguish between temporary profile instance copies and profile instance templates.

#### SRM/Automation: Disabled property added to ProfileParameterEntry class \[ID_21808\]

The property *Disabled* has been added to the *ProfileParameterEntry* class. It can be used to disable a parameter that should not be inherited from a parent profile instance.

#### Scheduler/Automation: Possible to include trending for chain field in CPE report email action \[ID_21896\]

When you configure a scheduled task or Automation script action to email a CPE report, you can now select to include trending for a chain field.

#### Service & Resource Management: Contributing DVE associated with a contributing booking now has two additional parameters \[ID_21967\]

The contributing DVE element associated with a contributing booking now has two additional parameters:

| Parameter ID | Parameter name   |
|--------------|------------------|
| 1            | Service ID       |
| 2            | Service severity |

#### Resources: Enhanced concurrency and capacity verification \[ID_21988\]

Due to a number of enhancements, concurrency and capacity verification performed when scheduling a resource instance has been improved.

#### DataMiner Cube - Router Control: Enhanced undo \[ID_21999\]

When, in the Router Control app, you undid the latest connect or disconnect action, up to now, the locking state of the inputs or outputs in question was not taken into account.

From now on, users trying to undo a connect or disconnect action involving locked inputs or outputs will be asked whether they want to first unlock the locked inputs or outputs.

- If they click Yes, then the locked inputs and outputs will be unlocked, and the action will be undone.
- If they click No, locked inputs and outputs will stay locked, and the action will be undone only for the currently unlocked inputs and outputs.

#### Link to Jobs app in app menu Ticketing app \[ID_22012\]

The Ticketing app now has a link to the Jobs app in its app menu.

#### OpenSSL library version 1.1.0j now included with DataMiner \[ID_22070\]

From now on, OpenSSL library version 1.1.0j will be included with DataMiner.

#### SLNet logging: Elements in 'Unsubscribe' log entries now referred to by dmaID/elementID \[ID_22078\]

In the following SLNet log entries, up to now, elements were only referred to by elementID. From now on, they will be referred to by DataMinerID/elementID.

```txt
Successful : Unsubscribing from element dmaID/elementID Unsuccessful : Failed to unsubscribe from element dmaID/elementID
```

#### DataMiner Cube - Alarm Console: Improved 'More...' time range option for new alarm tab \[ID_22092\]

When a new Alarm Console tab is created by dragging a DataMiner object onto the Alarm Console, the *More...* option for the time range of the alarms now functions in a more intuitive manner.

#### Security changes applied more quickly for Web API connections \[ID_22137\]

Previously, if DataMiner security settings were changed using DataMiner Cube, any existing web API connections at that time kept using the security settings from before the changes. The changes were only applied if a new web API connection was made. Now the changes will be applied immediately, although the UI will only be updated when users refresh the page. This means that if users no longer have permission to use particular options, they will still be able to see the options but not to use them, until the page is refreshed.

#### DataMiner Cube - Visual Overview: ClientSideRowFilter now supports both the table name with and without suffix \[ID_22152\]

As, since DataMiner 9.6.4, table column names in DataMiner Cube no longer display the name of the table as a suffix in parentheses, ClientSideRowFilter will now support both the table name with and without this suffix.

For example, a column with parameter description “Value (Table1)”, will match both the filter Value:5 and “Value (Table1)”:5.

#### Service & Resource Management: System function definitions now automatically synchronized among Failover agents and among all agents in a DataMiner System \[ID_22242\]

From now on, system function definitions will automatically be synchronized among Failover agents and among all agents in a DataMiner System.

#### Enhanced performance of CPE filtering \[ID_22262\]

Due to a number of enhancements, overall CPE filtering performance has increased.

#### HTML5 apps: Browser caching disabled by default \[ID_22318\]

All DataMiner HTML5 apps (Ticketing, Jobs, etc.) will now have their browser caching disabled. This will prevent users from having to clear their browser cache after upgrading to a new version.

#### DataMiner Cube - CPE: Enhanced text in tooltip of aggregation page refresh button \[ID_22353\]

The text in the refresh button’s tooltip on CPE aggregation pages has been made more user friendly.

#### Service & Resource Management: Optimization of enhanced service protocol template \[ID_22373\]

The enhanced service protocol template, which is used to create booking services, has been optimized.

#### SLAnalytics: Enhanced calculation of state icons in tables & enhanced logging \[ID_22379\]

In order to optimize overall performance, the number of state icons calculated per table will now be limited.

Also, a number of enhancements have been made with regard to logging.

#### DataMiner Cube - Visual Overview: Enhanced image caching \[ID_22464\]

When you open a Visual Overview, the images in that Visual Overview are kept in an image cache. That cache has now been enhanced. From now on, if you open multiple identical Visual Overviews, each image in those Visual Overviews will only be cached once.

> [!NOTE]
> If a Visual Overview contains shape data fields of type VdxPage or InlineVdx, all references to Visio files in those fields will also be cached.

#### DataMiner Cube - Visual Overview: Placeholders of non-existing properties are now automatically removed from shape text \[ID_22472\]

When shape text contains a placeholder that refers to a non-existing property, from now on, that placeholder will automatically be removed from the shape text.

#### A log entry will now be added to ERRORLOG.txt in the event of an error while processing a notification \[ID_22478\]

In the event that SLDataMiner, SLElement or SLDMS would throw an exception while processing a notification, from now on, a log entry will be added to the ERRORLOG.txt file.

#### Ticketing API: TraceData will now contain all TicketingGateway error data \[ID_22526\]

For each TicketingGateway request that failed, an entry of type TicketingManagerError.Reason.LegacyError will now be added to the TraceData.

The value of the error will be stored in the LegacyErrorMessage property of the TicketingManagerError object.

#### SLNetClientTest: Enhanced analysis of .slnetdump and follow sessions \[ID_22561\]

A number of enhancements have been made to the SLNetClientTest tool in order to improve the analysis of .slnetdump and follow sessions.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### Sorting of direct view tables that combine data retrieved from different elements \[ID_22574\]

From now on, it is possible to sort direct view tables that combine data retrieved from different elements.

Note that it is not possible to sort by a column that is not part of the result set.

#### Cassandra: Enhanced performance when writing TimeTrace data \[ID_22609\]

In order to enhance overall performance, TimeTrace data will now be written in batches with the same partition key (maximum batch size = 20).

#### DataMiner Cube - CPE Management: Enhanced performance \[ID_22629\]

Because of a number of enhancements, overall performance of the DataMiner Cube UI has increased when working in a CPE environment.

#### SLSNMPAgent process: Enhanced method to detect duplicate notices \[ID_22652\]

Previously, when SLSNMPAgent generated a notice, that notice would be blocked if an identical notice had been generated less than 5 minutes earlier. In other words, once every 5 minutes, a duplicate of an existing notice could be generated.

From now on, before a new notice is generated, the previous notice with the exact same message will be cleared.

> [!NOTE]
> If a notice older than 7 days has not yet been cleared manually, a duplicate notice might still be generated.

#### Service & Resource Management: Enhanced file cleanup when removing service definitions \[ID_22706\]

When a service definition with a generated contributing service protocol is deleted, then the generated protocol, the function definitions of the generated protocol and the SrmGenerationInfo object for the generated protocol will now also automatically be deleted.

Also, all profile parameters containing references to parameters of the generated protocol will have those references removed.

> [!NOTE]
> Deleting a service definition with a generated contributing service protocol will fail if function definitions of the generated protocol are in use.

#### DataMiner Cube - Trending: Enhanced performance when rendering trend graphs that display frequently changing average trend data \[ID_22732\]

Because of a number of enhancements, overall performance has increased when trend graphs are rendered that display frequently changing average trend data.

#### DataMiner Cube: Enhanced logging when UI thread gets frozen \[ID_22745\]

When the UI thread gets frozen, from now on, its stack trace will be logged.

#### Service & Resource Management: Enhanced performance \[ID_22781\]

Because of a number of enhancements, overall performance has increased when resources are created.

#### Analytics parameter change queue will now be cleared when Analytics is disabled \[ID_22818\]

From now on, the Analytics parameter change queue will be cleared when Analytics is disabled.

Also, Analytics will now automatically be disabled when an error of type ERROR_INVALID\_USER_BUFFER occurs.

#### Monitoring & Control app: Reduced initial load time \[ID_22877\]

The way the Monitoring & Control app is initially loaded has been improved, resulting in a shorter load time.

#### Administrative updates of history set alarms will now inherit the alarm time of the last parameter value change \[ID_22919\]

From now on, administrative updates (i.e. alarms of type “Properties Changed”, “Service impact changed”, “View impact changed” and “Name Changed”) of history set alarms will inherit the alarm time of the alarm where the value of the parameter in question was last changed.

#### DataMiner Cube - Scheduler: CPE reports now based on view tables instead of base tables \[ID_22958\]

When, in Scheduler, you configured a CPE report in an email action, up to now, that report was based on the base tables in the CPE element. From now on, if view tables are present in the CPE element, the report will be based on those view tables instead.

#### HTML5 apps: Enhanced drop-down box behavior \[ID_22968\]

In HTML5 apps like Jobs and Dashboards, drop-down box behavior has been enhanced, especially with respect to how auto-complete suggestions are being displayed.

#### DataMiner Cube - Backup: An information event will now be generated when no network path was specified for a particular Agent \[ID_22991\]

When, on the page *System Center \> Backup \> General*, you selected the options *Store the backups on a network path* and *Use a different network path for each Agent* without selecting all Agents in the list below, up to now, after a backup operation, an alarm was generated, saying that errors had occurred while taking the backup.

From now on, instead of an alarm, an information event will be generated containing the following message: “Path not specified for this agent, no backup was taken”.

#### Masking of virtual functions now possible \[ID_23033\]

It is now possible to mask virtual functions via Automation scripts. Previously it was only possible to mask the main element.

#### NT_UPDATE_PORTS_XML (128) updated to limit information events and allow new option \[ID_23052\]

When labels are updated on a matrix element with the Notify DataMiner call NT_UPDATE_PORTS_XML (128), now at most one information event will be generated with parameter description "Link File" and value "edited by ...".

If this call is used to perform a bulk set, an additional option can now be specified to indicate that a parameter of type "discreet info" should not be triggered, so that this parameter does not trigger a QAction unnecessarily.

For example:

```csharp
elementInfo[labelCount] = new uint[5] { changeType, elementId, uiMatrixPid, dataminerId, Convert.ToUInt32((int)UpdateType.UpdateFileAtOnceNoDiscreetInfoTrigger) };
```

#### SLDataGateway is now capable of performing asynchronous DELT import operations \[ID_23063\]

From now on, the SLDataGateway process will be capable of performing asynchronous DELT import operations.

#### DataMiner Backup: 'Configurations' folder is now included in backup packages \[ID_23114\]

The following DataMiner folder is now also included in backup packages:

- C:\\Skyline DataMiner\\Configurations

#### Web Services API v1: Enhanced performance due to view caching \[ID_23116\]

From now on, SLNet’s ViewInfoEventMessages and ViewStateEventMessages will be cached in a view cache. As all web methods requesting views will use this view cache, overall performance will increase when using those methods.

#### DataMiner Cube: Alarm cards will now highlight changed properties \[ID_23118\]

From now on, when you open an alarm of type “Property Changed”, the changed property (or properties) will be highlighted.

#### SLAnalytics: Enhanced memory management \[ID_23134\]

Due to a number of enhancements, overall memory management in the SLAnalytics process has improved.

#### SLAnalytics: Enhanced caching mechanism \[ID_23184\]

Due to a number of enhancements, the caching mechanism of the SLAnalytics process has improved.

#### Incorrectly named log files have been renamed or removed \[ID_23222\]\[ID_23560\]

The names of the following log files did not follow the DataMiner log file naming conventions. They have either been renamed or removed. Log entries that were written to a file that was removed, will now be written to another file instead.

| Log entries written to...      | will now be written to...        |
|--------------------------------|----------------------------------|
| Mobile Gateway.txt             | SLGSMGateway.txt                 |
| SLProtocolManager.txt          | SLNet.txt                        |
| SNMPAgent.txt                  | SLSNMPAgent.txt                  |
| TicketingMessageRedirector.txt | SLTicketingMessageRedirector.txt |
| UIProvider.txt                 | SLUIProvider.txt                 |

#### Improved connection behavior HTML 5 apps \[ID_23223\]

All the DataMiner HTML5 apps (Monitoring, Dashboards and Jobs), will now fall back to polling when WebSockets are disabled on the Agent. When WebSockets get enabled on the Agent, existing subscriptions that are using polling but can use WebSockets will stop polling and start a WebSocket connection instead.

#### HTML5 apps: Enhanced performance when running interactive Automation scripts \[ID_23312\]

Due to a number of enhancements, overall performance has improved when running interactive Automation scripts from inside HTML5 apps (Dashboards, Jobs, etc.).

#### DataMiner Cube - Alarm Console: Alarm actions will now use the root alarm ID instead of the alarm ID \[ID_23377\]

When, in the Alarm Console, you perform one of the below-mentioned alarm actions, the alarm update request sent to the DataMiner Agent will now contain the root alarm ID instead of the alarm ID.

- Add comment
- Clear alarm
- Force release ownership
- Mask
- Release ownership
- Take ownership
- Unmask

#### Alerter: 'Take ownership' action will now use the root alarm ID instead of the alarm ID \[ID_23379\]

When, in Alerter, you perform the “Take ownership” action, the alarm update request sent to the DataMiner Agent will now contain the root alarm ID instead of the alarm ID.

#### Ticketing: No more information events for third-party ticketing updates \[ID_23380\]

When tickets are updated in a third-party ticketing system, DataMiner will no longer generate an information event mentioning these updates.

#### DataMiner Cube - Visual Overview: Improved performance \[param:\] placeholder \[ID_23428\]

Performance has improved when the \[param:\] placeholder is used in Visio.

#### DataMiner Cube - Visual Overview: Enhanced processing of crosspoint updates in shapes linked to matrices \[ID_23445\]

Due to a number of enhancements, processing of crosspoint updates in shapes linked to matrices has been improved.

#### HTML5 apps: Enhanced performance due to shared communication layer \[ID_23541\]\[ID_23871\]

The HTML5 apps (Dashboards, Jobs, etc.) now use a newly developed, shared communication layer, which will considerably enhance their overall performance.

#### Element ID and QAction ID logged in SLNet log file when QAction sends a message to SLNet \[ID_23564\]

When a QAction sends a message to SLNet, from now on, the element ID and the QAction ID will be logged in the SLNet log file.

#### WatchDog log entries now provide more information in case of run-time errors \[ID_23708\]

Up to now, log entries stored in SLWatchDog2.txt due to a run-time error contained only the name of the process and the name of the thread. From now on, if possible, they will also contain the ID of the process and the ID of the thread.

#### Service & Resource Management: Enhanced performance when opening Services app and Bookings app \[ID_23765\]

Due to a number of data loading enhancements, overall performance has increased when opening the Services app or the Bookings app, especially on systems with a large number of services and bookings.

#### DataMiner Cube - Visual Overview: No more logging if no highlight direction can be found for connections \[ID_23973\]

When highlighting of DCF connections was configured in a Visio drawing but no specific direction could be found for a connection, up to now, log entries were added to the Cube logging. However, as this could cause many unnecessary log entries, this will now no longer be logged.

#### Enhanced performance when passing parameter changes to clients \[ID_23808\]

Due to a number of enhancements, overall performance has increased when passing parameter changes to client applications.

#### Service & Resource Management: Enhanced concurrency verification \[ID_23832\]

Due to a number of enhancements, concurrency verification performed when scheduling a resource instance has been improved.

#### DataMiner Cube - Service & Resource Management: Enhanced profile management \[ID_23861\]

A number of enhancements have been made with regard to the management of profile definitions, profile instances and profile parameters.

#### DataMiner Cube: Selected Visual page now expands in card side panel \[ID_23873\]

When the root Visual page is selected in DataMiner Cube, it will now expand in the card side panel to show its immediate child pages.

#### Enhanced performance when requesting spectrum trend data from SLNet \[ID_23971\]

Due to the introduction of a dedicated cache, overall performance has increased when requesting spectrum trend data from SLNet using GetSpectrumTrendTraceTimestampsMessage and GetSpectrumTrendTraceDataMessage.

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

#### DataMiner Cube: Enhanced performance when drawing card breadcrumbs \[ID_24151\]

Due to a number of enhancements, overall performance has increased when drawing the breadcrumbs at the top of a card.

#### DataMiner Cube - Automation/Correlation: Width of action dialog boxes will now automatically be adapted to the size of the screen \[ID_24190\]

From now on, when you configure actions in Automation scripts or Correlation rules, the action dialog boxes will automatically adapt their width to the size of the screen.

#### Run-time errors will now be generated when SLDataMiner halts while executing start, stop or restart actions for elements \[ID_24228\]

When, for whatever reason, SLDataMiner should halt while executing start, stop or restart actions for a particular element, from now on, a run-time error will be generated.

#### DataMiner Cube - Services app: Service list will no longer be initialized when Visual Overview only shows the service definition editor \[ID_24242\]

From now on, the services list in the Services app will no longer be initialized when Visual Overview only shows the service definition editor.

#### A notice will now be generated when the parameter update stack of SLElement exceeds 5000 items \[ID_24259\]\[ID_24980\]

A notice will now be generated a minute after the parameter update stack of SLElement has exceeded 5000 items.

As soon as the number of items in that stack drops below 1000, the notice will be cleared automatically.

#### DataMiner Cube: Enhanced performance when generating authentication tickets for embedded web browsers \[ID_24261\]

Due to a number of enhancements, overall performance has increased when generating authentication tickets for embedded web browsers in apps like Ticketing, Dashboards, Maps, etc.

#### Service & Resource Management: Enhanced performance when saving and synchronizing resources \[ID_24289\]

Due to a number of enhancements, overall performance has increased when saving resources and synchronizing them among the agents in the DataMiner System.

#### DataMiner Maps: Enhanced performance when opening a pop-up balloon \[ID_24292\]

Due to a number of enhancements, overall performance has increased when opening a pop-up balloon.

#### Improved logging when uploaded protocol requires higher DataMiner version \[ID_24298\]

Logging has improved when a protocol is uploaded that requires a higher DataMiner version than the one currently installed in the system. The following error message will now be logged: "DataMiner version is too low to use this protocol. Please check the protocol's Compliancies tag."

#### DataMiner Cube - Visual Overview: Enhanced performance when using 'FollowPathColor' and 'InternalInterfaceHopping' \[ID_24305\]

Due to a number of enhancements, overall performance has increased when using “FollowPathColor” and “InternalInterfaceHopping”, especially when a large number of shapes are linked to elements containing many interfaces and connections.

#### HTML5 apps: Enhanced icons \[ID_24341\]

All HTML5 apps (Dashboards, Monitoring, Jobs, etc.) now have enhanced icons.

#### Service & Resource Management: Enhanced processing of event messages related to ReservationInstances and ReservationDefinitions \[ID_24350\]

Due to a number of enhancements, the processing of event messages related to ReservationInstances or ReservationDefinitions has improved.

#### Elements updated using an AddElementMessage will no longer be restarted by default \[ID_24370\]

When an element is updated using an AddElementMessage, from now on, that element will only be restarted if one or more of the following properties were changed:

- Bus address
- Element state
- IP
- Poll settings
- Port info
- Protocol name
- Protocol version
- Replication info
- SNMP info

#### DataMiner Cube: Enhanced breadcrumbs on service cards \[ID_24408\]

A number of enhancements have been made to the way in which breadcrumbs are displayed when you open a service cards.

#### HTML5 apps: More consistent layout due to shared UI components \[ID_24414\]

The overall layout of the different HTML5 apps has been made more consistent.

#### DataMiner Cube - Visual Overview: Improved performance when using \[param:\] placeholder \[ID_24493\]

When a \[param:\] placeholder is used in Visio, the way parameters are retrieved has been improved, resulting in improved performance.

#### Web Services API v1: Unused method and arguments removed \[ID_24530\]

The method *GetClusterAsync*, which could not yet be used, has been removed from the Web Services API v1. In addition, a number of fields that also could not yet be used have been removed. The following fields have been removed from the *DMAAutomationScriptSettings* object:

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

#### DataMiner Cube: Activity panel layout enhancements \[ID_24592\]

In the Activity panel, a number of small layout enhancements have been made, especially with regard to spacing between icons and text.

#### DataMiner Cube - Visual Overview: Signal path update enhancements \[ID_24599\]

Due to a number of enhancements, overall performance has increased when updating signal paths.

#### Rollback packages will no longer be created during a DataMiner upgrade \[ID_24614\]

During a DataMiner upgrade, a rollback package will no longer be created.

To downgrade to a specific DataMiner version, from now on, it will suffice to install the full installation package of that earlier DataMiner version.

> [!NOTE]
> In the DataMiner Taskbar Utility, the *Rollback* option has also been removed from the *Maintenance* menu.

#### DataMiner Cube: Enhanced 'Back' buttons in card headers and browser controls \[ID_24693\]

In card headers and browser controls, the *Back* button will now always be visible, either enabled or disabled.

Also, the layout of WFM card headers has been optimized.

#### DataMiner Cube: Enhanced app icons \[ID_24718\]

In DataMiner Cube, the layout of all app icons has now been enhanced.

#### Service & Resource Management: Enhanced performance when deleting service definitions \[ID_24860\]

Due to a number of enhancements, overall performance has increased when deleting service definitions, especially on systems with a large number of booking instances.

#### Outdated version number removed from DataMinerCubeStandAlone web page \[ID_24871\]

Up to now, the following HTML file contained an outdated DataMiner Cube version number. That number has now been removed.

- C:\\Skyline DataMiner\\Webpages\\DataMinerCubeStandalone\\publish.htm

#### DataMiner Cube - Side bar: Enhanced loading of app icons in App list \[ID_24891\]

Due to a number of enhancements, overall performance has increased when loading the app icons in the Apps list.

#### Maximum upload size for upgrade packages increased from 500 MB to 4,000 MB \[ID_24922\]

The maximum upload size for upgrade packages has increased from 500 MB to 4,000 MB.

#### DataMiner backup: Full backup now includes booking data stored in Indexing Engine \[ID_24766\]

When you take a full backup of your DataMiner System, from now on, the booking data stored in Indexing Engine will also be included.

#### Failover: Prevent new elements from receiving the same ID as a deleted element or a disabled function \[ID_25306\]

From now on, when a DataMiner Agent in a Failover setup goes online, SLDataMiner will now retrieve the highest element ID from dataminer.xml. This will prevent new elements from receiving the same ID as an element that was deleted or a function that was disabled.

### Fixes

#### Not possible to assign Visio file to imported view or service \[ID_19280\]\[ID_20207\]

If a service or view had been imported via a .dmimport package, it could occur that it was not possible to assign a Visio file to it.

#### DataMiner Cube - Trending: Enabling or disabling statistics would not update the trend graph \[ID_19358\]

When, in the Statistics window of a trend graph, you enabled or disabled one of the checkboxes (Average, Mean deviation, etc.), in some cases, the trend graph would not be updated unless you forced a redraw by panning or zooming.

#### Service & Resource Management - Service Chain: Problem when restarting an element \[ID_19368\]

When a service chain setup contained a connection property shape, in some cases, an exception could be thrown when you restarted an element in the chain.

#### DataMiner Cube: Function name displayed incorrectly on alarm card \[ID_19583\]

On the alarm card of an alarm with a function impact, it could occur that the name of the function was not displayed correctly if it contained several underscores.

#### Problem with SLAnalytics when opening a trend graph \[ID_19603\]

When you opened a trend graph, in some rare cases, an error could occur in SLAnalytics causing the graph to not show any prediction.

#### Parameters with RTDisplay set to false also processed by Analytics \[ID_19660\]

Up to now, DataMiner Analytics incorrectly also took parameters into account that had RTDisplay set to false, which could cause errors to be displayed in the SLAnalytics logging.

#### Default service card page setting not applied for visual page of SRM service \[ID_19674\]

If the default service card page was set to “Visual page” in the user settings, for an SRM service, it could occur that this setting was not applied.

#### DataMiner Cube: Exception when opening alarm card with service impact from removed SRM service \[ID_19679\]

If there was an alarm on the function DVE of a service booking instance, and the service was deleted at the end of the booking, it could occur that an exception was thrown when you opened the alarm card of one of the alarms affected by this service.

#### Service & Resource Management: Problem with removal of DCF entry point connections \[ID_19728\]

When, in setups with multiple entry points, an entry point connection was removed, in some cases, the connections of all entry points would be removed.

#### DataMiner Cube: Incorrect alarm filter after dragging an item onto the Alarm Console \[ID_19750\]

In some cases, dragging an item onto the Alarm Console would change the alarm filter you applied earlier.

#### Spectrum Analyzer component not loading correctly in HTML5 app \[ID_19812\]

In the HTML5 app, it could occur that the spectrum trace could not be displayed for Spectrum Analyzer components that did not have a reference level or reference scale set.

#### Trending - SLAnalytics: Trend predictions did not take into account the most recent trend data \[ID_19832\]

When you opened a trend graph, in some cases, trend predictions would not take into account the most recent trend data.

#### SLAnalytics: Alarm limits containing exception values could not be parsed correctly \[ID_19911\]

In some cases, alarm limits containing exception values could not be parsed correctly.

#### Problem with SLSNMPAgent process \[ID_20278\]

In some cases, an error could occur in SLSNMPAgent when an element was added, deleted or stopped.

#### Enhanced services did not receive currently active alarms after being restarted \[ID_20328\]

When an enhanced service was restarted (e.g. by editing the protocol), in some cases, it would not receive the currently active alarms when *Monitor Active Alarms* was enabled.

#### DataMiner Connectivity Framework: Problem deleting a connectivity chain throughout a DataMiner System \[ID_20343\]

In some cases, it was not possible to delete a connectivity chain throughout an entire DataMiner System using a DeleteConnectivitySettingsMessage.

#### Service & Resource Management: No enhanced service element created after update protocol ID for existing booking instance \[ID_20430\]

In the Service & Resource Management module, if the protocol ID was updated for an existing booking instance via the *AddOrUpdateReservationInstances* method, it could occur that no corresponding enhanced service element was created.

#### Web Services API v1: GetValuesForCPETopologyField method not returning values \[ID_20483\]

In some cases, it could occur that the *GetValuesForCPETopologyField* method did not return any values, even though values were available.

#### DataMiner Cube: Problem when exporting redundancy group \[ID_20519\]

In some cases, an issue could occur when a redundancy group was exported to a .dmimport package. In particular, when a redundancy group contains a condition involving a virtual primary element from a different redundancy group, that redundancy group will now also be included in the export package.

#### Problem with masking until clearance of parameter or cell \[ID_20553\]

In some cases, when a parameter or cell were set to be masked until an alarm on that parameter or cell was cleared, it could occur that they remained masked even after the alarm was cleared.

#### Not possible to assign alarm template to enhanced service \[ID_20580\]

In some cases, it could occur that it was not possible to assign an alarm template to an enhanced service.

#### DMS Reporter: Incorrect top 10 report if service had elements on different DMAs \[ID_20628\]

If a report was configured to display the top 10 services that spent the largest percentage of time in an alarm state, and the elements in a service were spread over multiple DMAs, it could occur that the report was not generated correctly.

#### Profile Manager: Problem when creating a profile parameter entry \[ID_20670\]

In some cases, an exception could be thrown when a profile parameter entry was created.

#### DataMiner upgrade: Problem when QActions were found without 'encoding' attribute \[ID_20673\]

In some cases, during an DataMiner upgrade, an exception could be thrown when a QAction was found that did not have an “encoding” attribute.

#### Problem when updating a view property with its current value \[ID_20693\]

In some cases, an exception could be thrown when a view property was updated with the value it had before the update.

#### SLAnalytics: Problem when multiple messages were sent simultaneously to SLNet \[ID_20703\]

In some rare cases, an exception could be thrown when multiple messages were sent simultaneously to SLNet in SLAnalytics.

#### Service & Resource Management: Serialization exception when object configuration was specified on service definition node \[ID_20720\]

When an object configuration was specified on a service definition node, this could result in a serialization exception.

#### Failover: Profile Manager data only synchronized at next DataMiner restart \[ID_20825\]

When a Failover switch was performed, in some cases, changes made to Profile Manager data would not be synchronized until the next DataMiner restart.

#### Failover: New service definitions would not be visible in the Service Manager app after a Failover switch \[ID_20832\]

When a Failover switch was performed, in some cases, newly created service definitions would not be visible in the Service Manager app.

#### Element would not go into an error state when the creation of a logger table failed \[ID_20859\]

When the creation of a logger table failed, in some cases, the element in question would not go into an error state.

#### Correlation: No correlated alarm created when using a 'new alarm' correlation action with severity 'Lowest severity of source alarms' \[ID_20917\]

When using a correlation rule with a “new alarm” action and severity set to “lowest severity of source alarms”, in some cases, no correlated alarm would be created when the alarm with the lowest severity was a normal alarm. In this kind of situation, from now on, the second lowest severity will be taken.

#### SLLogCollector process stopped upon DMA restart \[ID_20939\]

Previously, when a DMA was restarted, it could occur that the SLLogCollector process was stopped, causing DMS log information to be lost. This will no longer occur.

#### DataMiner Cube - System Center: Problem with user credentials sharing the same name \[ID_20999\]\[ID_21011\]

When, in System Center, you created a credential in the credential library, up to now, DataMiner Cube would incorrectly only compare the name of the new credential to those of the existing names in the same group. As a result, when another user created a credential with the same name in another group, no error would appear. The DataMiner Agent, on the other hand, would not save the credential.

From now on, when user create a credential of which the name is identical to that of an existing credential, an error will appear.

#### Service & Resource Management: Problem when reserving services and enhanced services \[ID_21007\]

In a DataMiner System, in some cases, IDs of services and enhanced services would be reserved twice due to a synchronization issue.

#### When an alarm filter or a trend filter was changed, the old filter was not added to the recycle bin \[ID_21030\]

When you changed a trend filter or an alarm filter, up to now, the XML file containing the old filter would not be added to the recycle bin.

#### DataMiner Upgrade: Problem with upgrade action that reformats GPIB port settings \[ID_21115\]

In some cases, the upgrade action that reformats GPIB port settings would not process disabled bus addresses incorrectly.

#### Problem with mask state of alarm after deleting and re-adding a row containing a masked cell \[ID_21278\]

When you deleted a table row with a masked cell, added that row again, and then unmasked the masked cell of the new row, the alarm would incorrectly stay masked until an alarm update was generated.

#### Problem when generating an enhanced service protocol \[ID_21283\]

When an enhanced service protocol was generated, in some cases, some of the generated parameters would incorrectly be placed on the same Data Display position.

#### Failover: Problem with incorrect database messages \[ID_21305\]

In a Failover setup without Cassandra or Indexing databases, in some cases, messages related to Cassandra or Indexing databases would incorrectly appear.

#### DataMiner Cube: Problem when choosing to recreate an element after changing its protocol \[ID_21316\]

When, after changing the protocol of an existing element, you chose to make Cube recreate the element by deleting the existing element and then creating a new element with a new element ID, in some cases, the existing element would be deleted, but no new element would be created.

#### Problem with SLElement when a masked element was stopped the moment it was automatically unmasked after a certain period \[ID_21317\]

In some cases, an error could occur in SLElement when an element, which had been masked for a certain period of time, was stopped the moment it was automatically unmasked.

#### Service & Resource Manager: Time zone difference not taken into account when checking for available resources \[ID_21318\]

When a client requested an available resource from the server, the possible time zone difference between client and server was not taken into account, which could lead to incorrect results.

#### DataMiner Cube - Visual Overview: 'ClosePage' option not working on subshape or shape on embedded page \[ID_21481\]

If a subshape within a group or a shape on an embedded page was configured with the *ClosePage* option, it could occur that this option did not work correctly.

#### DataMiner Cube - Trending: Exception values incorrectly taken into account when calculating statistical values \[ID_21593\]

When you opened the statistics window of a trend graph containing exception values, in some cases, those exception values would incorrectly be taken into account when calculating the statistical values (average, minimum, maximum).

#### Mobile Gateway: Problem when setting the cellphone location \[ID_21617\]

In some cases, an exception could be thrown when setting the location of the Mobile Gateway.

#### Sending GetInfoMessage of type 'IndexingConfiguration' incorrectly returned the indexing engine configuration of all DataMiner Agents \[ID_21770\]

When a GetInfoMessage of type “IndexingConfiguration” was sent containing one specific DataMiner ID, the indexing configuration of all DMAs would incorrectly be returned.

From now on, only the indexing configuration of the specified DMA will be returned, except when the DataMiner ID in the GetInfoMessage request was equal to -1.

#### CPE Manager: Empty top filters after item selection in lowest filter \[ID_21821\]

In some cases, it could occur that the top filters of the CPE topology remained empty if an item had been selected in the filter at the lowest level first.

#### DataMiner Cube - Logging: Problem when trying to open a log entry \[ID_21676\]

When you opened the *Logging* window by clicking the *Logging* button in the bottom-right corner of Cube’s login screen, selected a log entry and clicked *Open*, in some cases, the log entry would not be opened.

Also, a number of minor enhancements have been made to the *Logging* window.

#### DataMiner Cube - Logging: Log entry pop-up window not resized when Cube was resized \[ID_21756\]

When, in the *Logging* section of System Center (or the *Logging* window opened on Cube’s login screen), you opened a log entry in a pop-up window, in some cases, that log entry pop-up window would incorrectly keep its same size when you resized DataMiner Cube. From now on, log entry pop-up windows will be resized when you resize DataMiner Cube.

#### DataMiner Cube - Reports: Problem with 'top X' reports \[ID_21778\]

In some cases, in DataMiner Cube, the “top X” reports, which you find e.g. in a view card under *Reports \> More \> Top*, would incorrectly list the “bottom X” items instead of the “top X” items.

#### SNMP polling with V3 HMAC-MD5 or HMAC-SHA authentication algorithms caused memory leak in SLSNMPManager \[ID_21788\]

When SNMP polling was used with V3 HMAC-MD5 or HMAC-SHA authentication algorithms, a memory leak could occur in one of the SLSNMPManager processes.

#### DataMiner Cube - Visual Overview: Clicking a shape configured to perform a parameter set would cause shape text to be copied instead \[ID_21818\]

When a shape displayed some text and was configure to perform a parameter set when clicked, in some cases, clicking that shape would incorrectly cause the text displayed on that shape to be copied rather than cause the parameter set to be executed.

#### Incorrect analytics trend arrows \[ID_21851\]

In some cases, after SLAnalytics was shut down, it could occur that records for the trend arrows were not correctly stored in the database, which could cause Cube to display incorrect trend arrows.

#### DataMiner Cube - Visual Overview: Trend graph would not be properly refreshed when a dynamic placeholder was updated \[ID_21890\]

When, in a data item of type “Parameters” or “ParametersOptions” of a shape displaying a trend graph, a dynamic placeholder was updated, in some cases, the trend graph would not be properly refreshed.

#### No mask comment added to newly created alarms for masked table rows or table row cells \[ID_21927\]

When a new alarm was generated for a masked table row or table row cell, in some cases, no mask comment would be added to that new alarm.

#### Service & Resource Management: Problem with license (number of concurrent bookings) \[ID_21970\]

When the maximum amount of bookings had been scheduled, in some cases, it would not be possible to edit one of those bookings.

#### DataMiner Maps: Dynamic data in \<Detail> tags would be overwritten \[ID_22009\]

In some cases, dynamic data in \<Detail> tags would be overwritten, resulting in incorrect and/or missing placeholder values.

#### Monitoring & Control app: No data in legend for trend graph with gap \[ID_22032\]

In some cases, if a trend graph contained a gap between two trend points, no data was displayed in the legend for that trend graph for a section that was larger than the actual gap.

#### Reporter: Export to Excel/CSV did not contain all rows of a partial table \[ID_22069\]

When, in Reporter, you exported a report to an XLS or CSV file, in some cases, that file would not contain all rows of a partial table. From now on, the exported file will be able to contain up to 1 million rows.

> [!NOTE]
> When you export a report to an HTML or MHT file, that file will display only the first page of a partial table (using the page size configured in the protocol).

#### DataMiner Cube - Service & Resource Management: Caching issue with reservation instances that were more than 21 days in the future \[ID_22091\]

Previously, reservation instances with a start time of more than 21 days in the future were not cached. However, this could result in issues when such an instance was created and then quickly retrieved afterwards. Now the 500 most recently saved instances outside the default cache period of 21 days will be cached too.

#### Problem with alarms not impacting a virtual function \[ID_22127\]

In some cases, alarms would not impact a virtual function without an entry point.

#### DataMiner Cube - CPE: Incorrect table filtering due to deprecated option 'oldFiltering' \[ID_22201\]

In some cases, CPE tables would be filtered incorrectly when using the deprecated option “oldFiltering”.

#### DataMiner Cube - CPE: Opening a CPE object in another chain did not clear all filters of the destination chain before selecting the new item \[ID_22217\]

When you opened a CPE object in another chain using the right-click menu on the CPE diagram item, not all filters would be cleared in the destination chain before the new item was selected.

#### Ticketing: Ticket properties not refreshed after updating a ticket \[ID_22322\]

When you updated a ticket, in some cases, the ticket properties would not get refreshed.

#### DataMiner Agent would not notify the client when objects were unmasked when the masking period elapsed \[ID_22354\]

When, after you had masked a DataMiner object for a period of time, the object and its child items were automatically unmasked when the masking period elapsed, in some cases, the DataMiner Agent would not notify the client application. As a result, the client application would incorrectly continue to show the items as masked.

#### When a DataMiner object was masked for a period of time, not all child object would be unmasked when the masking period elapsed \[ID_22395\]

When you masked a DataMiner object for a period of time, and that object had multiple alarms, in some cases, not all those alarms would be unmasked when the masking period elapsed.

#### Ticketing: Problem when updating a ticket \[ID_22420\]

In some cases, an exception could be thrown when you updated a ticket.

#### DataMiner Cube - Visual Overview: WCF connection timeout caused 'Failed' message to appear after clicking 'Edit in Visio' \[ID_22426\]

When, in Cube, you had clicked *Edit in Visio*, after ten minutes of inactivity, a WCF connection timeout could cause a “Failed” message to appear.

From now on, when you click *Edit in Visio*, a heartbeat mechanism will prevent WCF connections from going into timeout.

#### DataMiner Cube - Cards: 'REPORTS \> More' page missing \[ID_22500\]

When you expanded the *REPORTS* page in a card’s navigation page, in some cases, there was only one subpage named *General*. The other subpage, named *More*, would be missing.

#### Problem with information events not being migrated from MySQL to Cassandra \[ID_22515\]

During a migration from MySQL to Cassandra, in some cases, information events would not get migrated.

#### Problem with topology alarm properties in case of recursive directview/view tables \[ID_22530\]

When a topology cell was defined on a direct view table, in some cases, the alarm properties would not be filled in if view tables defined between the data table and the direct view table.

#### DataMiner Cube: Incorrect sorting of direct view tables and view tables with columns containing data retrieved from other tables \[ID_22537\]

In some cases, direct view tables and view tables with columns containing data retrieved from other tables would be sorted incorrectly.

#### SLAnalytics: Unresolved placeholder in debug log entries \[ID_22612\]

In some cases, debug log entries would incorrectly contain a “%s” placeholder instead of the element ID.

#### Service & Resource Management: Discrete parameters not displayed correctly in contributing services \[ID_22614\]

In a contributing service, it could occur that discrete parameters were not displayed correctly. The way profile parameters are handled in the SRM module has now been enhanced, so that discrete parameters can be included correctly in contributing services. Note that this change could cause some loss of data if you upgrade to this version of DataMiner and then downgrade again.

#### DataMiner Cube: CPE views cards no longer showed child objects after a DELT export had been launched \[ID_22621\]

After a DELT export had been launched, in some cases, the navigation pane of a CPE view card would no longer show any child objects.

#### Service & Resource Management: Duplicate booking instances after midnight sync \[ID_22639\]

A problem could occur when SRM data were synchronized during the daily midnight sync of a DMS, causing duplicate booking instances.

#### Problem when taking a backup containing Elastic data \[ID_22653\]

When taking a backup containing Elastic data, in some cases, a problem could occur when an Elastic index contained a dot (“.”).

#### Child elements were not notified when they exported a parameter impacted by a change to Description.xml or Port.xml \[ID_22654\]

As changes to element files like Description.xml and Port.xml can impact parameters, elements are notified when one of their parameters is impacted by such a file change.

However, up to now, child elements (e.g. DVE elements or virtual functions) would not receive any such file change notification. From now on, child elements will also receive file change notifications when they export parameters that are impacted by a particular file change.

#### Problem after stopping an element that stored data into an Indexing database and restarting the DataMiner Agent \[ID_22656\]

When a DataMiner Agent was restarted after an element that stored data into an Indexing database was stopped, in some cases, an exception could be thrown.

#### Web Services API v1: Problem with DMAParameter.IsTrending \[ID_22684\]

When a parameter had its trending attribute set to “true” in the protocol.xml, in some cases, when that parameter was passed by a web method, its IsTrending property would be “true”, even if it was not being trended in the element in question.

#### Resources app: New properties not available for existing resources \[ID_22693\]

In the Resources app, it could occur that if new properties were created, these were not available for existing resources.

#### DataMiner Cube: Memory leak when opening CPE cards \[ID_22694\]

When you opened a CPE card with a Visio file that showed tables in shapes, but you did not navigate to Visual Overview, in some cases, a memory leak could occur.

#### Service & Resource Management: Problem with Profile Manager when filtered subscriptions were being used \[ID_22698\]

In some cases, the Profile Manager could throw an exception when filtered subscriptions were being used.

#### DataMiner Cube - Alarm Console: Incorrect time range shown when editing a history tab page \[ID_22699\]

When you clicked the pencil icon of a history tab page in order to edit that tab page, in some cases, the time range would be filled in incorrectly.

#### DataMiner Cube - Visual Overview: Problem when closing a Visual Overview \[ID_22711\]

In some cases, an exception could be thrown when you closed a Visual Overview.

#### Service & Resource Management: Problem when trying to open a functions.xml file \[ID_22744\]

Due to a problem with file access rights, in some cases, it would not be possible to manually open a functions.xml file for e.g. debugging purposes.

#### ProfileManagerHelper.GetProfileInstance with empty GUID returned random profile \[ID_22768\]

Previously, if the method *ProfileManagerHelper.GetProfileInstance* passed an empty GUID, a random profile was returned. Now null will be returned in this case.

#### DataMiner Cube - Alarm Console: Problem when grouping or sorting the alarms \[ID_22797\]

When the Alarm Console contained at least two alarm tab pages, and more that 50 alarms per second were received, an error could occur while grouping or sorting the alarms.

#### Inconsistent access to enhanced service elements among the agents in a DataMiner System \[ID_22798\]

In some cases, access to enhanced service elements would be inconsistent among the different agents in a DataMiner System.

#### Problem when updating the Visio file linked to a service hosted on another DMA \[ID_22814\]

In some cases, it could occur that it was not possible to update the Visio file linked to a service hosted on a DMA other than the one you were connected to.

#### Failover: Deleted ticket field resolver would re-appear after a switch-over \[ID_22822\]

When a ticket field resolver was deleted on a Failover system, in some cases, it could re-appear after a switch-over due to a caching problem.

#### Analytics: Mid-term prediction was not shown when polling frequency exceeded 1 minute \[ID_22863\]

In some cases, mid-term prediction would not be shown when the polling frequency exceeded 1 minute.

#### Spectrum Analysis: Problem when sending a SpectrumElementSpecificConfigRequestMessage \[ID_22882\]

When a SpectrumElementSpecificConfigRequestMessage was sent, in some cases, an exception could be thrown when the element.xml file of the spectrum element in question did not contain a \<SpectrumElementSpecificConfig> tag.

#### DataMiner Cube: Cards could get stuck in a 'loading' state when users had not been granted the 'Correlation/UI available' permission \[ID_22908\]

In some cases, cards could get stuck in a “loading” state when users had not been granted the “Correlation/UI available” permission.

#### DataMiner Cube - Security: List of user/group permissions was not sorted alphabetically \[ID_22939\]

When you opened System Center and navigated to the permissions of a particular user or user group, the “Bookings” permission was not displayed at the correct location in the list.

The list of permissions is now again sorted alphabetically.

#### DataMiner Cube - Visual Overview: Columns were not hidden correctly when their width was set to 0 in a 'ColumnWidth' option \[ID_22960\]

When, in a shape data field of type *ParameterControlOptions*, you added a *ColumnWidth* option in which you set the width of a particular column to 0 pixels, in some cases, that column would not be hidden correctly.

#### Reporter: Problem with CPE status report on view tables using advanced naming \[ID_22965\]

When, in Reporter, you generated a CPE status report, in some cases, tables using advanced naming would show primary keys instead of display keys.

Also, in case of custom reports, the DMS_getTableFiltered method would incorrectly return display keys when the tables in question used advanced naming.

#### HTML5 apps: Last column of a list view would incorrectly take up all remaining space \[ID_22993\]

In some cases, the last column of a list view would incorrectly take up all remaining space.

#### DataMiner Cube: Problem during startup when no connection could be made to the internet \[ID_22995\]

When DataMiner Cube was not able to connect to the internet during startup, in some cases, the UI could momentarily become unresponsive.

#### Problem with SLSNMPManager when stopping or deleting a duplicated SMNPv3 element \[ID_23006\]

When one of multiple SNMPv3 elements using identical credentials was stopped or deleted, in some cases, the remaining ones would go into timeout.

#### DataMiner Cube - Visual Overview: Problem when displaying trend graphs \[ID_23041\]

When a trend component on a Visio page was configured to display a trend graph when selecting a table index from a list of table parameter indices, in some cases, no trend graph would be displayed when you selected a table index from the list.

#### Visio: Shapes linked to enhanced service not displayed for some users \[ID_23059\]

In some cases, for an enhanced service that was part of other services, it could occur that linked shapes in Visio were not displayed for users with limited user permissions.

#### Not possible to select different drive for Cassandra installation \[ID_23068\]

In the Cassandra installation/migration wizard, it could occur that it was not possible to change the drive where Cassandra had to be installed.

#### Labels/crosspoints not displayed correctly for exported matrix parameters \[ID_23069\]

In some cases, it could occur that matrix labels and crosspoints were not displayed correctly for exported matrix parameters of virtual functions or DVE child elements. To prevent this, the *Description.xml*, *labels.xml* and *Ports.xml* files of a parent element will now be applied to its child elements.

#### Service & Resource Manager - Profile Manager: Problem during DMS startup \[ID_23070\]

In some cases, Profile Manager could throw an exception while the DataMiner System was starting up.

#### HTML5 apps: App title not always displayed correctly on login screen and/or title bar \[ID_23076\]

In some cases, the app title of an HTML5 app would not be displayed correctly on the login screen and/or the app’s title bar.

#### Problem in SLDataMiner when importing large amount of element data \[ID_23120\]

When a large amount of element data was imported, a problem could occur in the SLDataMiner process.

#### SNMP Manager sending SNMPv3 inform messages stuck in ping mode \[ID_23132\]

If an SNMP Manager in DataMiner was configured to send SNMPv3 inform messages and went into ping mode, it could occur that it remained stuck in this mode.

#### DataMiner Cube: Parameters displayed on dialog boxes had an incorrect parameter description \[ID_23167\]

When a parameter was displayed on a dialog box, in some cases, its parameter description would be incorrect.

#### Various issues with Cube breadcrumbs \[ID_23169\]

A number of issues have been resolved that could occur with the breadcrumbs at the top of cards in DataMiner Cube:

- When an object was renamed, it could occur that the name in the breadcrumbs was not updated.
- When an object had been deleted, it could occur that it was still displayed in the breadcrumbs' drop-down menu.
- For services that only contained excluded devices, it could occur that breadcrumbs were not displayed correctly.
- Breadcrumbs will no longer be displayed in upper case only.

In addition, on a view card, it could occur that the list of elements was not updated if an element was removed from the view while the card was open.

#### End time of masking operation not applied correctly \[ID_23157\]\[ID_23170\]

When a parameter was masked for a limited period of time, it could occur that the end time of the mask operation was not applied correctly.

#### DataMiner Cube - Automation: Window appearing when an Automation script fails had an incorrect caption on a Cube with custom branding \[ID_23171\]

When using a DataMiner Cube with custom branding, up to now, the window that appeared when an Automation script failed would incorrectly have the default “Skyline DataMiner” caption. From now on, on a DataMiner Cube with custom branding, the caption of that window will show the custom product name.

#### DataMiner Cube: Alarm storm prevention incorrectly enabled while being disabled in enforced group settings \[ID_23181\]

When the alarm storm prevention mechanism was enabled in the user settings but disabled in enforced group settings, in some cases, it would incorrectly be enabled.

#### SNMP Managers not respecting resend timer in system with virtual SNMP agent \[ID_23188\]

In a system that had a virtual SNMP agent configured, it could occur that the resend timer of SNMP Managers was not always respected.

#### Visio: PushContextMenu not working correctly with service chain container or a signal path container \[ID_23194\]

If the *PushContextMenu* option was used for shapes like a service chain container or a signal path container, this caused the container to become clickable and then contain all of the context menu items and actions of its children. To avoid this unintended behavior, these container shapes will no longer have any actions of their own.

#### Problem when restoring a backup containing Elastic data \[ID_23197\]

When, after re-installing the Elastic database and starting DataMiner, you took a backup containing Elastic data, in some cases, it would not be possible to restore that backup.

#### Service & Resource Management - Visual Overview: Service chain not displayed correctly \[ID_23205\]

If a Visio drawing displayed a booking service chain with its expected connections, but the booking contained resources that were not linked to an element, it could occur that the chain was not displayed correctly. Now, resources that are not linked to an element will be ignored.

#### DataMiner Cube: Problem with Element migration window \[ID_23237\]

When connected to a DataMiner System with multiple DataMiner Agents, you opened *System Center \> Agents \> Status*, clicked *Migrate*, selected a destination agent and a number of elements, and then clicked either *Migrate* to start migrating the selected elements to the selected agent or *Cancel* to exit the *Element migration* window, in some cases, an exception could be thrown.

#### DataMiner Cube - Backup: No backup made if only Elastic data was selected \[ID_23248\]

Up to now, when you made a custom backup that only contained Elastic data and no Cassandra data, no backup file would be created.

From now on, it is possible to make a backup that only contains Elastic data.

#### DataMiner installation failed when no theme was selected \[ID_23253\]

When DataMiner was installed and no theme had been selected during the setup of the installer, it could occur that the installation failed.

#### DataMiner Cube - Visual Overview: Only one shape used of source/destination shapes with same tag \[ID_23261\]

If shapes in Visio were tagged as a source or destination and multiple shapes had the same tag, only one of them would work as a source or destination. Now all shapes with matching tags will be considered a possible source or destination.

#### DataMiner Cube - Visual Overview: Automatic connection lines generated instead of connectors drawn in Visio \[ID_23295\]

In some rare cases, it could occur that connectors drawn in Visio were replaced by regular connection lines generated by Cube.

#### HTML5 apps: Problem when mouse pointer went outside the Scheduler component \[ID_23302\]

In the HTML5 apps (Dashboards, Jobs, etc.), in some cases, the Scheduler component would not react as expected when moving the mouse pointer away from it.

When you move the mouse pointer away from the Scheduler component and back, from now on, the action will either continue when the mouse button is being pressed or be canceled when the mouse button is no longer being pressed.

#### Incorrect column spans in interactive Automation script in HTML5 applications \[ID_23325\]

If an interactive Automation script was run using a HTML5 DataMiner application, it could occur that the column spans in the script were not correctly applied.

#### Service & Resource Management: First occurrence of a ReservationDefinition was incorrectly saved twice \[ID_23328\]

When, in a DataMiner System, a ReservationDefinition was saved on a non-master DMA, in some cases, the first occurrence of that ReservationDefinition would incorrectly be saved twice.

#### HTML5 apps: Problem with WebSockets \[ID_23336\]

In the HTML5 apps (Dashboards, Jobs, etc.), in some cases, the WebSocket connection could keep disconnecting and reconnecting when a user was logged off.

From now on, when users log off, the WebSocket connection will no longer be disconnected. Instead, it will be unauthenticated.

#### DataMiner Installer: Problem when installing SNMP on Windows 10 version 1809 and above \[ID_23346\]

When installing DataMiner on a system running Windows 10 version 1809 (or above), in some cases, the DataMiner Installer was not able to properly install SNMP. As a result, the installation procedure would fail.

#### Problem when taking a backup containing data stored in a remote Elastic database \[ID_23347\]

In some cases, an error could be thrown when taking a backup containing data stored in a remote Elastic database.

#### Table of virtual function element remains empty \[ID_23356\]

In some cases, it could occur that a table of a virtual function element did not contain any data.

#### SLAnalytics: Trend data older than TTL was incorrectly taken into account when calculating trend predictions \[ID_23358\]

Up to now, trend data older than the trend data TTL setting would incorrectly be taken into account when calculating trend predictions.

#### No error information when adding TicketResolver with existing name \[ID_23369\]

In a system with a Cassandra database, when you tried to add a TicketResolver with a name that was already in use, no error information was returned.

#### Service & Resource Management: Adding, updating or deleting a protocol function would cause all protocols to be fetched from the DataMiner Agent \[ID_23373\]

In some cases, adding, updating or deleting a protocol function would incorrectly cause DataMiner Cube to fetch all protocols from the DataMiner Agent.

#### DataMiner Cube - Profile Manager: Problem when configuring the default value of profile parameters of type 'discrete' \[ID_23376\]

In some cases, it was no longer possible to configure the default value of profile parameters of type “discrete”.

#### DataMiner Cube: Not possible to unmask alarm on CPE object \[ID_23392\]

In some cases, it could occur that it was not possible to unmask an alarm on a CPE object.

#### DataMiner Cube - Visual Overview: Problem with 'VerticalAlignment=Stretch' and 'HorizontalAlignment=Stretch' options \[ID_23397\]

When positioning shapes in a grid layout, in some cases, shapes would not be stretched when using the *VerticalAlignment=Stretch* or *HorizontalAlignment=Stretch* options.

From now on, these options will allow you to stretch single, non-grouped shaped.

#### Problem when exporting Elastic logger tables \[ID_23410\]

Up to now, in some cases, an error would be thrown when you tried to export an Elastic logger table.

From now on, it is possible to export Elastic logger tables, but without any data.

#### Cassandra: Problem when fetching data using a complex filter containing subfilters \[ID_23444\]

In some cases, an error could occur when fetching data from a Cassandra database using a complex filter with a number a subfilters.

#### DataMiner Cube - Indexing: Problem when searching for most suitable hard drive at the start of the Indexing Engine installation procedure \[ID_23483\]

In some cases, an exception could be thrown when searching for the most suitable hard drive at the start of the Indexing Engine installation procedure.

#### Automation: Compiled C# files saved with an incorrect file extension \[ID_23495\]

In some cases, compiled C# files would be saved with the incorrect extension “cs0” instead of “cs”.

#### Service & Resource Management: ReservationInstances with an end time in the past would incorrectly still reserve resources \[ID_23496\]

Up to now, ReservationInstances with an end time in the past would incorrectly still reserve resources. From now on, this will no longer be the case.

Also, when eligible resources are requested for a time range with a start time in the past (by means of a GetEligibleResources call), ReservationInstances with an end time in the past will no longer be taken into account.

#### Service & Resource Management: Problem when a user opened the Bookings app for the first time \[ID_23519\]

In some cases, an exception could be thrown the first time a user opened the Bookings app.

#### Problem when trying to install Elastic on a system that is already running Elastic \[ID_23523\]

When DataMiner tried to install Elastic on a system that was already running Elastic, in some cases, an exception could be thrown.

#### DataMiner Cube - Visual Overview: Connections for active path not highlighted correctly \[ID_23558\]

In some cases, it could occur that the connections for an active path were not highlighted correctly in Visual Overview.

#### Resources incorrectly considered eligible in case of overlapping bookings with same capacity \[ID_23576\]

In some cases, when multiple overlapping bookings used the same capacity, the system would return some resources as eligible for use in a booking even though they were not.

#### Baseline value close to 0 caused constant alarm \[ID_23577\]

If a relative baseline in an alarm template was set very close to 0, it could occur that the parameter was always considered to be in alarm.

#### Problem in SLAnalytics when shutting down \[ID_23593\]

A problem could occur in the SLAnalytics process when it was shutting down.

#### Service & Resource Management: Problem when requesting booking definitions with a time filter \[ID_23631

In some cases, requesting booking definitions with a time filter would incorrectly return outdated definitions.

#### Service & Resource Management: Problem when generating a contributing service \[ID_23666\]

In some cases, an exception could be thrown when a contributing service was generated with an incorrectly configured profile parameter.

#### Problem with protocol buffer serialization when server and client were running different DataMiner versions \[ID_23679\]\[ID_24035\]

When protocol buffer serialization was being used, a number of issues could occur when a DMA and a client were running different DataMiner versions.

#### DataMiner Cube: Problem when opening a spectrum card \[ID_23696\]

In some cases, an exception could be thrown when you opened a spectrum card.

#### Legacy dashboards: No data displayed at the start of a trend graph \[ID_23755\]

On a legacy dashboard, in some cases, no data would be displayed at the start of a trend graph.

#### DataMiner Installer: Problem when setting up a Failover system due to incorrect use of quotes and double quotes in Cassandra.yaml \[ID_23773\]

In some cases, setting up a Failover system using the DataMiner Installer would fail due to the incorrect use of quotes and double quotes in the Cassandra.yaml file.

#### Duplicate log entry when SLAnalytics was started or stopped \[ID_23799\]

When SLAnalytics was started or stopped, in some cases, a duplicate entry would incorrectly be added to the log.

#### DataMiner Cube - Visual Overview: \[Sum:X,Y,Z\] placeholder did not parse decimal values \[ID_23810\]

In some cases, it could occur that the *\[Sum:X,Y,Z\]* placeholder in Visio did not parse decimal values.

#### Problem with SLElement \[ID_23846\]

In some rare cases, an error could occur in the data gateway table thread of SLElement.

#### Duplicated service definition not identical with original \[ID_23870\]

If a service definition was duplicated, it could occur that the interface configuration of the duplicate was not the same as that of the original.

#### Logon to Reports & Dashboards with SAML authentication failed \[ID_23878\]

It could occur that it was not possible to log on to the legacy Reports & Dashboards app using SAML authentication.

#### DataMiner Cube: Memory leak when opening and closing dynamic list \[ID_23910\]

If a dynamic list component was opened and closed in DataMiner Cube, for instance in the Bookings app or the Services app, a memory leak could occur.

#### Problem with alarm properties after importing alarms \[ID_23918\]

When a DELT package containing alarms was imported, in some cases, alarm properties would incorrectly be added to alarms to which they did not belong.

#### DataMiner Cube - Visual Overview: Problem with client-side filtering of dynamically positioned shapes \[ID_23946\]

When dynamically positioning shapes based on table data, in some cases, a row filter specified in a shape data field of type *Filter* would no longer be applied.

#### DataMiner Cube - Visual Overview: Custom DCF connection lines and matrix connections not displayed correctly \[ID_23955\]

In some cases, custom DCF connection lines and matrix connections would be displayed incorrectly.

#### Problem with SLAnalytics when an element was removed \[ID_23965\]

In some rare cases, an error could occur in SLAnalytics when an element was removed.

#### Service & Resource Management: Icons defined in system functions would not be displayed in DataMiner Cube \[ID_23966\]

In some cases, icons defined in system functions would not be displayed in DataMiner Cube.

#### Ticketing: Ticket fields without alarm properties would incorrectly no longer be included in the ticket \[ID_23967\]

In some cases, ticket fields without alarm properties would incorrectly no longer be included in the ticket. From now on, all ticket fields will be included in the ticket, regardless of alarm properties.

#### DataMiner Cube - Visual Overview: Problem when linking a shape to a matrix output \[ID_23980\]

When you linked a shape to a matrix output by using a shape data field of type *Output* or *OutputLabel* set to a number representing the index of the output (e.g. “1”), in some cases, that shape would be linked to an incorrect output.

#### DataMiner Cube - Trending: Problem when adding a parameter to a stopped element \[ID_24045\]

In some rare cases, an error could occur when you tried to add a parameter of a stopped element to a trend graph.

#### DataMiner Cube - Trending: Problem with 'Enable trend logging (debug)' setting \[ID_24065\]

When the “Enable trend logging (debug)” setting was deactivated, in some cases, certain log data would incorrectly still be kept in memory.

#### Ticketing: Ticket fields containing concatenations would have their type set incorrectly \[ID_24092\]

When a ticket field contained a concatenation, in some cases, the type of that field would be set incorrectly.

#### Problem with SLNet when using protocol buffer serialization \[ID_24099\]

In some rare cases, a problem could occur in SLNet when protocol buffer serialization was being used.

#### Cassandra: Paged database query would incorrectly only return the first two pages \[ID_24101\]

In some cases, a paged database query against a Cassandra database would incorrectly only return the first two pages instead of the entire result set.

#### Cassandra migration: Incorrect estimation of the amount of data to be migrated \[ID_24117\]

To be able to indicate the progress of a data migration operation, DataMiner first has to make an estimation of the amount of data to be migrated. Up to now, due to an incorrect calculation of logger table sizes, this estimation was not correct.

#### DataMiner Cube - Visual Overview: DCF connection lines between dynamically positioned shapes would disappear after zooming in and out \[ID_24119\]

In some cases, DCF connection lines between dynamically positioned shapes would disappear after zooming in and out.

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

#### Service & Resource Management: Resource concurrency calculated incorrectly when retrieving the list of eligible resources \[ID_24203\]

When the list of eligible resources was retrieved, it could occur that the resource concurrency was not calculated correctly.

#### Service & Resource Management: When a service definition was updated, the old version would not be removed \[ID_24208\]

When a service definition was updated, in some cases, the old version of that service definition would incorrectly not be removed from the *servicedeftrace* database table.

#### DataMiner Cube - System Center: A backup including the Indexing database could incorrectly be started without specifying a backup path \[ID_24217\]

In the *Backup* section of *System Center*, users would incorrectly be able to start a backup that included the Indexing database even when no *Indexing Engine backup path* had been specified. As a result, the backup operation would fail immediately.

From now on, the *Execute backup* button will be disabled when no *Indexing Engine backup path* is specified.

#### DataMiner Cube - System Center: Agent list would incorrectly be expanded after having chosen not to upgrade a number of specific agents \[ID_24223\]

When, in the *Agents* section of *System Center*, you click *Upgrade*, you can choose whether to upgrade either all agents in the cluster or a number of specific agents. If you choose the latter, and click “Yes” in the confirmation box, the list of available agents will be expanded, allowing you to select the agents to be upgraded.

However, up to now, the list of available agents would also incorrectly be expanded when you clicked “No” in the confirmation box. This will no longer occur.

#### DataMiner Cube: Version conflict error after logging in with an incorrect Administrator password \[ID_24229\]

When you tried to log in to DataMiner Cube with an incorrect Administrator password, in some cases, a version conflict error could be thrown.

#### DataMiner Cube: Locally saved document locked until DMA restart \[ID_24231\]

When a document was saved from the Documents app in Cube to a local drive, it could occur that this file was locked by DataMiner until the DMA was restarted.

#### Service & Resource Management: Alarm icons not displayed in ListView component \[ID_24232\]

In some cases, if the column configuration for a ListView component contained alarm icons, it could occur that the alarm icons were not displayed when the configuration was loaded.

#### Issues when deleting booking instances \[ID_24244\]

When a booking instance in "Ongoing" state was deleted, it could occur that the deletion failed. In addition, if a booking instances tree was deleted by passing the nodes in the tree to the helper call, it could occur that the response contained too many bookings.

#### Element migration failure because of file with same name \[ID_24249\]

When an element was migrated, it could occur that an element data file could not be created because a file with the same name already existed, causing the migration to fail. Now a suffix will be added to the file name to ensure that the file can be created.

#### DataMiner Cube - Alarm Console: Alarm filters using session variables would no longer be updated correctly \[ID_24255\]

In some cases, alarm filters that contained session variables would no longer be updated correctly when one of those variables had changed.

#### Problem with SLSNMPManager when an incorrectly configured SNMPv3 element was started \[ID_24269\]

In some cases, an error could occur in SLSNMPManager when an incorrectly configured SNMPv3 element was started.

#### Problem with SLDataMiner when processing a service alarm while updating a service \[ID_24274\]

In some rare cases, an error could occur in SLDataMiner when it is was simultaneously updating a service and processing a new alarm linked to a service.

#### Problem in SLElement when adding comment while clearing timeout alarm \[ID_24286\]

When a timeout alarm was cleared manually and the user set the comment when clearing the alarm to the IP address of the connection, a problem could occur in SLElement.

#### Failover - MySQL: Alarm cleaning process would not be able to correctly separate active from non-active alarms \[ID_24306\]

When the number of alarms stored in the database reaches a certain threshold, the oldest, non-active alarms are automatically removed from the system. However, on a Failover system with MySQL databases, in some cases, the alarm cleaning process would not be able to correctly separate active from non-active alarms.

#### DataMiner Cube - Data Display: Problem when displaying a tabbed table \[ID_24317\]

In some cases, an exception could be thrown when a tabbed table was displayed on a DATA page.

#### Reports & Dashboards: Empty tables in legacy dashboards \[ID_24320\]

On legacy dashboard, in some cases, tables containing data would incorrectly be displayed as empty.

#### DataMiner Cube: Not possible to connect to another DMA after starting Cube with a 'host=' argument \[ID_24322\]

When DataMiner Cube was started with a “host=” argument, in some cases, the user would not be able to connect to another DataMiner Agent.

#### Exception when starting up DMAs in cluster with empty Elastic database \[ID_24325\]

If several DMAs in a cluster were started at the same time and these DMAs has an empty Elastic database, an exception could be thrown.

#### Reports & Dashboards: Problem with status query in legacy Reporter app \[ID_24332\]

When you used the legacy Reporter app to generate a report containing a status query, in some cases, a “response buffer limit exceeded” error message would appear, especially when the report contained a large amount of data.

#### Alarm Console: Hyperlinks missing in right-click menu after element restart or DataMiner restart \[ID_24335\]

In the Alarm Console, in some cases, the alarm hyperlinks would disappear from the right-click menu after an element restart or a DataMiner restart.

#### Problem when importing DELT packages containing alarms \[ID_24340\]

When a DELT package containing alarms was imported on a system running Cassandra, in some cases, the root time and root creation time of the alarms could be incorrect.

#### Service & Resource Management: Function DVEs not removed after resource swap \[ID_24342\]

If resources of a running booking were swapped with other resources, it could occur that the function DVEs that were no longer in use were not disabled until the maximum number of functions was reached.

#### DataMiner Cube: CPE card headers not showing the correct alarm color \[ID_24345\]

In some cases, the header of a CPE card did not show the correct alarm color. Instead, it was set to gray (Initial).

#### Web Services API v1: Incorrect view alarm severity \[ID_24347\]

The view state returned by the following methods would incorrectly not take into account the user security.

- GetAlarmStateForView
- GetView
- GetViewsForParent

> [!NOTE]
> The above-mentioned methods are also used by the DataMiner web applications (e.g. Monitoring & Control, Dashboards, Ticketing, etc.), and the view states are also used in DataMiner Maps.

#### Element connections saved incorrectly \[ID_24348\]

If an element had multiple serial, smart-serial or HTTP port connections, it could occur that the connection type of the first port was applied to all other serial, smart-serial or HTTP ports as well.

#### Service & Resource Management: Exception when saving multiple profile instances or profile definitions with empty field \[ID_24359\]

When multiple profile instances or profile definitions containing an empty field were saved at the same time, an exception could be thrown.

#### DataMiner Cube: Problem when resizing the Alarm Console \[ID_24362\]

When you made the Alarm Console smaller and then restored it to its original size, in some cases, the entire console would become blank.

#### DataMiner Cube: Problem when displaying dialog box while window/scroll bar thumb is dragged \[ID_24383\]

In the XBAP version of DataMiner Cube, if a dialog box was displayed while a user was dragging a window or a scroll bar thumb, a problem could cause Cube to freeze.

#### Booking definition saved even though no instance could be planned \[ID_24397\]

In some cases, it could occur that a booking definition was saved even though it was not possible to plan a booking instance.

#### Addition/removal booking events of existing booking not implemented correctly \[ID_24398\]

When booking events were added to or removed from an existing booking that still needed to start, it could occur that this change was not executed correctly.

#### Service & Resource Management: Exceptions when using a MySQL local database \[ID_24401\]

On systems with a MySQL local database, if a booking was saved that overrides a property on one of its resources, an exception could be thrown. In addition, an exception could be thrown during the initialization of the Resource Manager.

#### DataMiner Cube - Visual Overview: Column configuration of ListView component not updated \[ID_24422\]

In some rare cases, it could occur that the column configuration of a *ListView* component was not saved or retrieved correctly.

#### DataMiner Cube: Editing an SNMPv3 element created prior to DataMiner 9.6.12 would cause the authentication type to be reset to the default type \[ID_24423\]

When you edited an SNMPv3 element that was created prior to DataMiner 9.6.12, in some cases, the authentication type would incorrectly be reset to the default type (i.e. SHA512).

#### Dashboards: Problem with duplicate trend graphs in line chart component \[ID_24427\]

When, in a line chart component, you selected a second parameter, in some cases, each trend graph would incorrectly be displayed twice.

#### Service & Resource Management: ReservationInstances did incorrectly not have their status set to 'interrupted' \[ID_24434\]

In some rare cases, ReservationInstances that should have had their status set to “interrupted”, had their status set to an incorrect value.

#### Problem with SLElement when updating the source data of a direct view table belonging to an element with debug log level 2 \[ID_24449\]

In some cases, an error could occur in SLElement when updating the source data of a direct view table belonging to an element of which the debug log level was set to 2.

#### Problem with SLDataGateway when retrieving recursive tree items \[ID_24461\]

In some cases, an error could occur in SLDataGateway when retrieving recursive tree items.

#### Problem when SLProtocol retrieved data from a logger table \[ID_24483\]

In some cases, a problem could occur when SLProtocol retrieved data from a logger table using an integer value as primary key.

#### DataMiner Cube - Data Display: Memory leak after sorting and/or filtering tables \[ID_24492\]

In some cases, DataMiner Cube could leak memory after sorting and/or filtering tables displayed on DATA pages.

#### Memory leak in SLXML due to a parsing issue in SLDataMiner \[ID_24503\]

In some cases, SLXML could leak memory due to an XML parsing issue in SLDataMiner.

#### DataMiner Cube: Backup could incorrectly be started while the backup settings of the Indexing engine were being configured \[ID_24510\]

Up to now, users would incorrectly be able to start a backup operation while the Indexing nodes were restarting after, for example, changing the Indexing engine’s backup path.

From now on, it will no longer be possible to start a backup operation while the backup settings of the Indexing engine are being configured.

#### Problem with SLDataMiner \[ID_24511\]

In some rare cases, an error in SLDataMiner would cause other problems to occur (e.g. element timeouts).

#### Service & Resource Management: Editing a service in the services list would incorrectly clear the IDOfSelection session variable \[ID_24519\]

When you select a service in the services list, the ID of that service is stored in the *IDOfSelection* session variable. In some cases, that session variable would incorrectly be cleared when you edited the selected service.

#### Dashboards app: Problem with unintentional move operations in Chrome \[ID_24525\]

When working with the Dashboards app in Chrome, in some cases, a mouse click could unintentionally cause a dashboard component to be moved to another location.

#### HTML5 apps: Selection box values containing backslash characters displayed incorrectly in interactive Automation scripts \[ID_24541\]

When an interactive Automation script was run from within an HTML5 app, in some cases, selection box values containing “\\” characters could be displayed incorrectly.

#### DataMiner Cube: Clicking 'Open Cube Mobile' would not always direct you to the landing page \[ID_24560\]

When, in DataMiner Cube, you clicked *Open Cube Mobile*, in some cases, you were incorrectly directed to the Monitoring & Control app. From now on, clicking *Open Cube Mobile* will always direct you to the landing page.

#### Failover: Problem with Indexing database after a Failover switch \[ID_23945\]\[ID_24562\]

When an Indexing database was installed on a pair of DataMiner Agents in a Failover setup, in some cases, the Indexing database could no longer be reached after a Failover switch.

#### DataMiner Cube: Icons and names not properly aligned in 'Below this view' list \[ID_24572\]

When you opened a view card and selected *Below this view \> All*, in some cases, the icons and the names of the list items would not be properly aligned.

#### Service & Resource Management: Problem during Resource Manager initializing \[ID_24604\]

In some cases, the Resource Manager module could fail to initialize when protocol buffer serialization was enabled.

#### Service & Resource Management: Problem when retrieving a ReservationInstance immediately after a property update \[ID_24622\]

When a ReservationInstance was retrieved immediately after its properties had been updated, in some cases, the properties of the retrieved ReservationInstance would incorrectly still have their old values.

#### DataMiner Cube - Data Display: Alarm icon outside of colored background when hovering over a parameter control \[ID_24631\]

When you hovered over a parameter control, in some cases, the colored background would not include the alarm icon.

#### DataMiner Cube: Problem when using TAB to navigate among controls \[ID_24670\]

When you used the TAB key to navigate from one control to another, navigation would fail when a numeric up/down control had the focus.

#### DataMiner Cube - Data Display: DPI settings not always taken into account when rendering selection boxes and tool tips \[ID_24685\]

In Data Display, in some cases, the screen’s DPI settings would not be taken into account when rendering selection boxes and tool tips.

#### DataMiner Cube: Problem when saving or assigning group settings \[ID_24701\]

In some cases, it would no longer be possible to save group settings or to assign new settings to a group to which none had been assigned before.

#### Problem with SLDMS when synchronizing services to other agents \[ID_24725\]

In some rare cases, an error could occur in SLDMS when synchronizing services to other agents in the DataMiner System.

#### DataMiner Cube - Services app: Service definition not loaded correctly when Services app is opened \[ID_24735\]

When you opened the Services app, it could occur that one of the service definitions was not loaded correctly. When you selected it, it was tagged as “\[modified\]” and its connection lines were lost.

#### DataMiner Cube - Data Display: Description of Write parameters would be missing when there was no corresponding Read parameter \[ID_24767\]

On an element card, in some cases, Write parameters for which there was no corresponding Read parameter would not have their description displayed.

#### Problem when masking rows or cells in view tables or direct views \[ID_24773\]

In some cases, it would no longer be possible to mask cells or rows in view tables or direct views.

#### DataMiner Cube - Automation: Problem when an Automation script tried to send an e-mail containing a report \[ID_24775\]

In some cases, an error could occur when an Automation script tried to send an e-email containing a report.

#### Problem with SLProtocol when calling 'NT_LOAD_TABLE' \[ID_24780\]

In some cases, an error could occur in SLProtocol when calling the NotifyProtocol method “NT\_LOAD_TABLE”.

#### Problem when trying to back up an Elastic database using its public IP address \[ID_24810\]

When you tried to back up an Elastic database (which is used by the DataMiner Indexing engine) using its public IP address, in some cases, a message would incorrectly appear, saying that no Elastic database could be found on the machine in question.

#### SNMP communication error processing issue \[ID_24811\]

In some cases, SNMP communication would interpret SNMP errors incorrectly.

#### Problem when an element was stopped while an alarm time trace was being written \[ID_24872\]

In some rare cases, an error could occur when an element was stopped while a time trace was being written for one of its alarms.

#### Problem when calling GetParameter on the virtual element of a redundancy group \[ID_24892\]

When a GetParameter method was called in an Automation script on the virtual element of a redundancy group, in some cases, a CreateDummyFailedException could be thrown.

#### Memory leak in SLNet when enabling or disabling logging \[ID_24921\]

In some cases, the SLNet process would leak memory when logging was enabled or disabled.

#### Users with an expired password were not able to enter a new password \[ID_24938\]

In some cases, users of whom the password had expired would not be able to enter a new password. Instead, a “Failed to setup ProtoBuf” error would appear.

#### Deleting a monitored table row could cause an incorrect alarm to be generated \[ID_24957\]

When a monitored table row was deleted, in some cases, an incorrect alarm with an invalid root ID and invalid time stamp would be generated.

#### Problem with booking after property update \[ID_25076\]

When a property of a booking was updated using the method *SafelyUpdateReservationInstanceProperties*, a problem could occur with the booking.

#### SLAnalytics: Problem when receiving a trend prediction data request for an unknown parameter \[ID_25171\]

In some cases, an error could occur in SLAnalytics when it received a request to return trend prediction data for a parameter that could not be found in the protocol.

#### Failover: Remote services not synchronized towards offline Agent \[ID_25173\]

In a Failover setup, it could occur that remote services were not synchronized towards the offline Agent.

#### Memory leak in SLLoggerUtil process \[ID_25206\]\[ID_25465\]

In some cases, the SLLoggerUtil process would leak memory. For instance, when the log levels were updated multiple times.

#### Ticketing app: Deleting a ticket would incorrectly cause all tickets to be deleted \[ID_25211\]

In some cases, deleting a ticket would incorrectly cause all tickets to be deleted.

#### Problem with SLElement when the element incorrectly identified as the DMA element was deleted \[ID_25261\]

In some cases, an error could occur in SLElement when the element incorrectly identified as the DataMiner Agent element was deleted.

#### SLProtocol would incorrectly flush timetrace data when only element data had to be flushed \[ID_25273\]

In some cases, when SLProtocol had to flush element data, it would also incorrectly flush timetrace data.

#### Generation of alarm events with root key 0 upon creation of DVE element \[ID_25328\]

When a DVE element was created, in some cases, alarm events with root key 0 would incorrectly be generated for the monitored parameters that were not in an alarm status.

#### Cassandra: When an element was restarted, duplicate timetrace entries would be written to the database \[ID_25385\]

When an element with a large amount of active alarms was restarted, in some cases, duplicate timetrace entries would be written to the Cassandra database

#### Memory leak in SLDataGateway \[ID_25395\]

When DVE elements had average trending configured while the central database was enabled, in some cases, the SLDataGateway process would leak memory.
