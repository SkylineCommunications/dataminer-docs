---
uid: General_Main_Release_10.0.0_enhancements
---

# General Main Release 10.0.0 - Enhancements

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
