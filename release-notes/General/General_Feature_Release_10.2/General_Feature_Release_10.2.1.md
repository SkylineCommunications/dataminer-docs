---
uid: General_Feature_Release_10.2.1
---

# General Feature Release 10.2.1

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## New features

### DMS core functionality

#### Automatic Incident Tracking will be enabled by default on new systems \[ID_31617\]

From now on, Automatic Incident Tracking will be enabled by default

- on newly installed systems, and
- on systems that upgrade from a version on which Automatic Incident Tracking was not yet available (i.e. versions older than version 10.0.11).

> [!NOTE]
> On systems on which Automatic Incident Tracking has explicitly been disabled, the feature will remain disabled.

### DMS Security

#### Security: New NATS installations will no longer open IP port 8222 \[ID_31422\]

During a NATS installation, from now on, only ports 4222 and 6222 will be opened. IP port 8222 will be left closed.

### DMS Protocols

#### New option to enable/disable DCF interface state calculation on system level \[ID_31591\]

On protocol level, you can enable or disable DCF interface state calculation by setting the Protocol.ParameterGroups.Group@calculateAlarmState attribute to either true or false.

From now on, you will also be able to enable or disable this setting on system level. To do so, open the C:\\Skyline DataMiner\\MaintenanceSettings.xml file and set the ProtocolSettings.DCF.CalculateAlarmState element to either true or false.

```xml
<MaintenanceSettings xmlns="http://www.skyline.be/config/maintenancesettings">
  <ProtocolSettings>
    <DCF>
      <CalculateAlarmState>false</CalculateAlarmState>
    </DCF>
  </ProtocolSettings>
</MaintenanceSettings>
```

> [!NOTE]
>
> - This setting can only be configured in MaintenanceSettings.xml.
> - When you change this setting, the change will only be applied after a DataMiner restart.
> - The protocol-level setting will overrule the system-level setting.

### DMS Cube

#### Automatic Incident Tracking: New setting 'Maximum group events rate' \[ID_31203\]

In *System Center*, a new setting has been added to the *Analytics config* section: “Maximum group events rate”. With this setting, you can limit the maximal number of alarm group events that will be generated and thus avoid any possible performance issues during alarm floods.

When more events are generated per second that the value specified in this setting, the generation of events will be slowed down, and as soon as the number of generated events drops below the threshold again, the generation of events will again proceed at the fastest speed possible.

Each time alarm grouping enters flood mode, a notice alarm will be generated to notify users that they may experience a delay when checking the alarm group information shown by Cube. If this notice alarm is not cleared manually, it will be cleared automatically when the alarm flood has passed.

Default value of the “Maximum group events rate” setting: 100

#### Services app: Enhanced service definition security \[ID_31306\] \[ID_31428\]

In the Services app, a number of security enhancements have been made with regard to service definitions.

- In the *Users/Groups* section of System Center, the *Add*, *Edit* and *Delete* permissions under *Modules \> Services \> Definitions* have now been replaced by one single *Edit actions* permission. If a user had at least one of those previous *Add*, *Edit* or *Delete* permissions, they will now automatically be granted the new permission.
- In some cases, the *Diagram* and *Properties* permission under *Modules \> Services \> Definitions* would be applied incorrectly.
- Users who do not have read permission on functions will now be able to correctly save function nodes when configuring service definitions.

#### Alarm Console - Context menu: Links to elements, services and views in 'Open' submenu now have an element, service or view icon in front of them \[ID_31499\]

When you right-click an alarm in the Alarm Console, the *Open* submenu contains a link to the alarm card as well as links to all elements, services and views affected by the alarm. From now on, the links to the elements, services and views will each have an element, service or view icon in front of them.

#### Filter will now be taken into account when exporting a table \[ID_31586\]

Up to now, when you filtered a table and then exported it, the filter would not be taken into account and the entire table would be exported. From now on, the filtered table will be exported instead.

#### DataMiner Cube - Views: 'Below this view' list has a new column 'Communication protocols' \[ID_31590\]

A “Communication protocols” column has been added to the list on the *Below this view* page of a view card. This column will show the communication protocols used by an element.

#### Visual Overview: Shape data fields of type 'ParametersSummary' can now also handle subscription filters specified in the index part of a parameter section \[ID_31609\]

The value of a ParametersSummary shape data field has to consist of a number of delimited sections:

```txt
Operation|Param1|Param2|...|ParamZ|Actions
```

Each parameter section in the value above has to be configured as follows:

```txt
Element:Parameter:Index
```

From now on, the “Index” part of a parameter section can also contain a subscription filter:

```txt
Filter=<subscriptionFilter>
```

This subscription filter can be any filter that can be passed to a parameter change subscription (e.g. “VALUE=\<pid> == \<value>”, “fullFilter=(...)”, etc.).

> [!NOTE]
> Up to now, when the index part of a parameter section contained a wildcard, no results would be returned whenever cells were set to “not initialized”. From now on, cells set to “not initialized” will be skipped.

#### Trending: New 'Custom' button allows you to specify a custom X-axis range \[ID_31705\]

At the top of a trend graph, a new “Custom” button has been added next to the existing “Last 24 hours”, “Last week” and “Last month” buttons.

When you click this new button, you will be able to specify a custom X-axis range.

#### DataMiner Cube: Start window will now detect a HTTP(S) redirection and will ask the user to confirm that redirection \[ID_31726\]

When, in the start window of the DataMiner Cube desktop app, you try to connect to a DataMiner Agent with a redirection on HTTP(S) level, you will now be asked to confirm the redirection.

#### Visual Overview - Embedded Resource Manager component: New and updated session variables \[ID_31770\]

The following changes have been made with regard to session variables that can be used in embedded Resource Manager components.

##### New variable 'SelectedTimeRange'

When you select a time range, that range will be stored in the SelectedTimeRange variable.

The value can be set in serialized form (e.g. “5248098399646517511;5248392353962787511”) or using a “start;stop” format. In the latter case, start and stop must be timestamps that can be parsed by DateTime (e.g. “2017-09-17T09:42:01.9129607Z;2018-08-23T15:05:53.5399607Z” in ISO 8601 format, or “17/09/2017 9:42:01;23/08/2018 15:05:53” in local format).

This variable will be cleared whenever you select another item in the component.

##### Updated variable 'SelectedResource'

The SelectedResource variable will now also be filled in when you select a resource band.

Note that, when you select a resource band, the SelectedPool variable will contain the first pool of the selected resource.

##### Problem with 'SelectedReservation' variables

When you select a booking, the following variables are filled in:

- SelectedReservation
- SelectedReservationDefinition
- ResourcesInSelectedReservation
- TimerangeOfSelectedReservation

However, up to now, when the current booking selection was cleared, those variables would incorrectly not get cleared.

### DMS Reports & Dashboards

#### Dashboards app - GQI: New 'Update data' option \[ID_31445\] \[ID_31450\]

When configuring a GQI query, you can now enable the “Update data” option if you want the component to automatically refresh the data when changes to that data are detected.

By default, the “Update data” option is disabled.

> [!NOTE]
> At present, this feature will only work for queries using a “Parameter table by ID” data source.

#### Dashboards app: Share button will now be disabled when you make a dashboard private \[ID_31667\]

As it is not possible to share private dashboards, the “Share” button will now be disabled when you make a dashboard private.

#### Dashboards app - GQI: Element, service and view data sources now also return an 'In timeout' column \[ID_31671\]

The element, service and view data sources now return an additional “In timeout” column.

| Data source | Meaning of “True” in “In timeout” column                                                                        |
|-------------|-----------------------------------------------------------------------------------------------------------------|
| Element     | The (replication) element is in timeout.                                                                        |
| Service     | One of the elements in the service is in timeout.                                                               |
| View        | The enhancing element, one of the first-level child elements or one of the recursive child views is in timeout. |

#### Dashboards app: GQI engine will now check the GQI version of a query \[ID_31698\] \[ID_31703\]

When you open a GQI query, the GQI engine will now check the GQI version of that query to determine whether it is capable of updating or running that query.

### DMS Web Services

#### Web Services API v1: New methods to manage service templates \[ID_31612\]

Using the following methods, it will now be possible to manage service templates via the web services API:

- CreateServiceTemplate
- DeleteServiceTemplate
- GetServiceTemplate
- UpdateServiceTemplate

### DMS web apps

#### Jobs app: Name, Start Time and End Time fields in default job section can now be set read-only \[ID_31485\] \[ID_31506\]

In the default job section, the *Name*, *Start Time*, and *End Time* fields can now be set read-only.

#### Ticketing app: System name will now be checked for illegal characters \[ID_31496\]

From now on, the system name of a ticket will no longer be allowed to start with an underscore character or contain one of the following characters: . # \* , " '

When the system name contains one of these illegal characters, an error message will appear.

#### Jobs app: Fields will automatically be set to 'not required' when hidden \[ID_31513\]

From now on, when you hide a job field, you will receive a message that it will automatically be set to “not required”.

> [!NOTE]
> When you unhide a hidden field, it will remain set to “not required”.

## Changes

### Enhancements

#### Security enhancements \[ID_31307\] \[ID_31761\] \[ID_31784\]

A number of security enhancements have been made.

#### Cassandra: Enhanced handling of unsuccessful connection attempts \[ID_30893\]

When SLDataGateway fails to connect to the Cassandra database, from now on, an exception will be thrown after a configured number of connection retries (default: 60).

#### SLLogCollector will now also collect the NATS log and configuration files \[ID_31238\]

SLLogCollector will now also collect the log and configuration files from the NATS\\nats-account-server and NATS\\nats-streaming-server.

#### Function.xml files can now contain functions without entry points and maxInstance set to 1 \[ID_31480\]

In a functions.xml file, it is now possible to define functions without entry points and maxInstance set to 1. When all criteria are met, then a function of this type will affect all tables and column parameters defined for that particular function.

> [!NOTE]
> When you defined a function without entry points and maxInstance set to 1, \[Generic Linker Table\] entries will not be taken into account. This function will still affect all table and column parameters defined for it.

#### Enhanced performance when reading data from a MySQL or SQLServer database \[ID_31532\]

Due to a number of enhancements, on systems with a MySQL or SQLServer database, overall performance has increased when reading data from the database, especially when reading trend data during the migration to another type of database.

#### Enhanced performance when reading trend data from a MySQL or SQLServer database page by page \[ID_31535\]

Due to a number of enhancements, on systems with a MySQL or SQLServer database, overall performance has increased when reading trend data from the database page by page.

#### DataMiner Cube: Enhanced performance when logging in \[ID_31541\]

Due to a number of enhancements, overall performance has increased when logging in to Cube.

#### DataMiner Cube: Enhanced performance when shutting down \[ID_31543\]

Due to a number of enhancements, overall performance of DataMiner Cube has increased when shutting down, especially when connected to a DataMiner System with an Elasticsearch database.

#### DataMiner Cube - EPM: Enhanced handling of hidden Data Display pages of EPM elements \[ID_31567\]

When the Alarm Console contained an alarm on a parameter of an EPM element with hidden Data Display pages\*, and the user had configured that the Data Display of the parameter had to be displayed when double-clicking the element, up to now, double-clicking the alarm would open a popup with the trend graph. From now on, the alarm card will be opened instead. If users want to access the trend information of the parameter in question, they can click the parameter name.

*\*If the “CPEOnly” option is specified in the protocol of an EPM element, the Data Display pages of that element are hidden for all users except administrators.*

#### Reports & Dashboards: Enhanced generation of PDF reports \[ID_31582\]

PDF reports will now be generated by a new PDF engine.

All reports will now have a new header and footer. Also, reports created by the legacy Reporter app will no longer have bookmarks and will now have a page number in the footer.

#### DataMiner Cube: Miscellaneous enhancements \[ID_31641\]

A number of small enhancements have been made to DataMiner Cube and the DataMiner Cube start window.

#### DataMiner Cube: More detailed error messages when trying to connect to the cloud \[ID_31661\]

From now on, DataMiner Cube will return a more detailed error message when an error occurs while trying to connect to the cloud.

#### DataMiner Cube - Booking app: Enhanced layout of booking blocks in timeline area \[ID_31663\]

In the timeline area of the Bookings app, the layout of the blocks that represent bookings has been enhanced.

#### DataMiner Cube: Enhanced performance when logging in and when opening the Protocols & Templates app \[ID_31709\]

Due to a number of enhancements, overall performance has increased when logging in and when opening the *Protocols & Templates* app, especially on SRM systems.

#### Enhanced polling of SNMP tables using MultipleGetBulk and MultipleGetNext \[ID_31715\]

In DataMiner versions prior to 10.1.11, when MultipleGetBulk was used to poll a table that contained only a single row and the response from the device was cut because it exceeded the maximum package size, in some cases, the algorithm could get stuck into an infinite loop. That problem was fixed in DataMiner version 10.1.11, but now, the MultipleGetBulk/MultipleGetNext polling mechanism has received a more thorough overhaul.

#### DataMiner Cube - Sidebar: Enhancements with regard to pinning and unpinning sidebar items \[ID_31720\]

In DataMiner Cube, a number of enhancements have been made with regard to pinning and unpinning sidebar items.

#### SLA management: Enhanced automatic SLA data clean-up \[ID_31729\]

A number of enhancements have been made with regard to automatic SLA data clean-up.

#### DataMiner Cube: Minor enhancements with regard to views, elements and services \[ID_31742\]

A number of minor enhancements have been made with regard to views and elements:

- The *System Info* name (*System Center \> Agents*), which is used as root view name, can no longer be the name of an existing view.
- Users will now receive a clearer error message when they try to create an element or a service with a name that starts or ends with a space.
- When, in a view card, you right-click the header of the “Below this view” list, the context menu that appears is empty when the system has no properties defined. Now, when the context menu is empty, a message will be displayed, explaining users why it is empty.
- Up to now, when multiple items were selected in the “Below this view” list of a view card, selecting one item would not clear the selection. From now on, it will do so.
- When, in the “Below this view” list of a view card, you sort the list by alarm state, the list will be sorted by severity (default: descending).
- When, in a view card, you right-click the header of the “Below this view” list, the overall responsiveness of the context menu has been enhanced.

### Fixes

#### DataMiner Connectivity Framework: Virtual functions would incorrectly inherit interfaces from the main element \[ID_30715\]

By default, the interfaces of a virtual function are the interfaces defined in the functions.xml file. Up to now, in some cases, virtual functions would also incorrectly inherited the interfaces of the main element.

#### Web Services API v0: CreateElement would throw an exception when the request did not contain a Ports array \[ID_31145\]

In some cases, the CreateElement method could throw an exception when the request did not contain a Ports array. From now on, when the request does not contain a Ports array, an error message will be returned.

#### SLLogCollector could fail to take process dumps \[ID_31213\]

In some rare cases, SLLogCollector could fail to take process dumps.

#### SLLogCollector would incorrectly stop collecting files when a file could not be copied \[ID_31220\]

When SLLogCollector would fail to collect a file from a remote server, in some cases, it would stop collecting log files. From now on, when it fails to collect a certain file, it will log the failure but continue to collect log files.

#### SLAnalytics: Problem with trend prediction \[ID_31352\]

In some rare cases, an error could occur in SLAnalytics when calculating trend predictions.

#### Service & Resource Management: No bookings could be retrieved when bookings were being created \[ID_31357\]

When bookings were being retrieved while bookings were being created, in some cases, no bookings would get retrieved.

From now on, the getResourcesMessage, the getResourcePoolsMessage and the getReservationsMessage will be allowed to skip the ResourceManager queue.

#### Protocols: Export rules would fail to parse values containing escaped XML characters \[ID_31362\]

When, in a protocol, values contained escaped XML characters (e.g. \<Description>Measurements \> 5\</Description>), the export rules would fail to parse those values and the generated DVE or Virtual Function protocol would only have some or none of the export rules applied.

#### Dashboards app: Parameter feed could incorrectly continue to feed data when the parameter in question was no longer selected \[ID_31403\]

In some cases, a parameter feed could incorrectly continue to feed data even though the parameter in question was no longer selected.

#### Problem with SLElement when performing alarm level linking calculations \[ID_31404\]

In some cases, an error could occur in SLElement when performing alarm level linking calculations.

#### Alarm limit updates for column parameters would contain invalid data \[ID_31415\]

When alarm monitoring of type “rate” was used to monitor a column parameter, alarm limit change events would contain invalid data.

From now on, alarm limit change events will only be sent for standalone parameters and column parameters that are exported as standalone parameters in a virtual function or DVE child element.

#### DataMiner Cube - Correlation: Incorrect background color when creating or opening an analyzer or a correlation rule \[ID_31482\]

When, in the Correlation app, you created or opened an analyzer in the Analyzers tab or you created or opened a legacy correlation rule in the Correlation rules tab, the tab would incorrectly have a gray background.

#### DataMiner Cube: Problem when opening a specific page of a card \[ID_31490\]

In some cases, it would no longer be possible to open a specific page of a card.

#### DataMiner Cube: Incorrect display value could be displayed when discreet values and display values overlapped \[ID_31497\]

When the discreet values and the display values of a certain parameter overlapped, in some cases, an incorrect display value could be displayed.

#### Dashboards Sharing: Incorrect login screen would appear when the shared dashboard you were viewing was unshared \[ID_31503\]

When a shared dashboard was unshared while you were viewing it, up to now, you would incorrectly be redirected to the login screen of the Dashboards app. From now on, you will be redirected to the DataMiner Cloud login screen (i.e. <https://shares.dataminer.services>) instead.

#### Web Services API v1: Problem when using GetTableForParameterFiltered or GetTableForParameterSorted to retrieve part of a parameter table \[ID_31504\]

When the GetTableForParameterFiltered orGetTableForParameterSorted method was used to retrieve part of a parameter table by specifying a non-zero start index and a specific number of rows, in some cases, not all requested rows would be returned.

#### DataMiner Cube: Problem when the version history of a protocol included a version that was incorrectly based on itself \[ID_31508\]

In some cases, DataMiner Cube would become unresponsive when you changed the protocol of an element to a protocol of which the version history included a version that was incorrectly based on itself. From now on, a warning will appear when you try to change the protocol of a element to a protocol with an incorrect version history.

#### Jobs app: User pictures incorrectly not displayed in job history \[ID_31510\]

In some cases, user pictures would incorrectly not be displayed in the list of changes made to a job.

#### Problem when interpreting cell content wrapped in quotes while importing CSV files \[ID_31511\] \[ID_31522\]

When a CSV file was imported, up to now, SLDataMiner would incorrectly interpret cell content wrapped in quotes. For example, if quoted cell content contained a separator character, it would incorrectly be interpreted as a separator.

From now on, cell content will be parsed as follows:

- When no quotes are present, the cell will not have its spaces trimmed. When quotes are present around the cell's data, spaces will be trimmed outside of the quotes.

- Quotes inside a cell are expected to be escaped by another quote. Example: “A “”value”” inside a cell”.

- When there are quotes inside a cell, it is not allowed to have anything besides spaces outside of the quotes. The cell will be parsed as if no quotes are used and the first separator will close the cell. See the following example.

| If you import... | cell 1 will contain... | cell 2 will contain... | cell 3 will contain... |
|------------------|------------------------|------------------------|------------------------|
| “0,1m”, “0,5”m,  | 0,1m                   | “0                     | 5”m                    |

- Each imported object is expected to be a single element (besides the headers). Providing a string that contains a newline (\\n) for a property is possible, but carriage returns are removed (\\r) and tabs (\\t) are converted to spaces.

> [!NOTE]
> When you import a CSV file via DataMiner Cube, DataMiner Cube will send the imported data to the DataMiner Agent without performing any kind of preprocessing.

#### SLPort would leak a socket when executing an action of type 'open' via a socket that had already been opened \[ID_31512\]

When an action of type “open” was executed on a smart-serial interface via a socket that had already been opened, SLPort would leak a socket as well as a port in the ephemeral port range. This would eventually lead to a situation in which no more ports were available and no more sockets could be created. From now on, SLPort will close the socket when it receives an action of type “open” on a socket that is already open.

#### Failover using a shared hostname: Cube would not always send the 'bring online' message to the offline agent \[ID_31516\]

When, on a Failover system using a shared hostname with manual switchover, the active agent went down or became unreachable, in some cases, DataMiner Cube would send the message to bring the offline agent online to the incorrect agent.

#### Dashboard sharing: Problem when opening a shared dashboard containing selectors that did not feed any data to other components \[ID_31529\]

When you opened a shared dashboard containing selectors that did not feed any data to other components, in some cases, a “not allowed” exception could be thrown.

#### DataMiner Cube - Visual Overview: Child shapes of type alarm could lose data when scrolling through them \[ID_31547\]

When you scrolled through a large number of automatically generated shapes that represented alarms, in some cases, information displayed on those shapes would incorrectly disappear.

#### DataMiner Cube - Alarm Console: Problem when clearing an alarm while alarms were grouped by service \[ID_31549\]

When, in one of the tab pages in the Alarm Console, alarms were grouped by service, in some cases, an exception could be thrown when an alarm listed in more than one group was cleared.

#### Problem with SLReplaceLauncher during a DataMiner upgrade \[ID_31552\]

During a DataMiner upgrade, in some cases, an error could occur when SLReplaceLauncher was started.

#### DataMiner Cube - Data Display: Pressing a button inside a tree control would pass an incorrect row key \[ID_31554\]

When you pressed a button inside a tree control, in some cases, an incorrect row key would be passed to the command in question.

#### DataMiner Cube: Trend icons could stay hidden until Data Display was resized \[ID_31555\]

In Data Display, in some cases, trend icons next to parameters could incorrectly stay hidden until Data Display was resized.

#### DataMiner Cube: Parent view(s) of element, service or redundancy group created in one Cube session would be expanded in the Surveyor of another Cube session \[ID_31558\]

When, in a particular Cube session, a new element, service or redundancy group was created, in some cases, the Surveyor in other Cube session would incorrectly expand the parent view(s) of that new element, service or redundancy group.

#### Dashboards app: EPM components with only one chain filter would incorrectly not display their value in a PDF report \[ID_31563\]

In a PDF report, in some cases, EPM components that only had one active chain filter would incorrectly not display their selected value.

#### Problem when run-time errors occurred in identically named process threads \[ID_31564\]

When, in a single process, multiple threads have a run-time error, those errors are grouped into one alarm tree. However, some threads have names that are not unique. When multiple identically named threads had a run-time error, all associated alarms would be generated simultaneously with the same value. This would cause SLElement to generate additional, incorrect alarms and SLWatchdog to not properly close those alarms.

#### Jobs app: Problem when changing the type of a field that was being used in a job filter \[ID_31565\]

When you changed the type of a custom section field that was being used a job filter, in some cases, that field would incorrectly still be used as a filter, even when it was not possible to use that type of field as a filter.

#### DataMiner Cube - Settings: Changes made in 'Alarm Console \> Card-specific' section would incorrectly not get applied \[ID_31566\]

In the *Alarm Console \> Card-specific* section of the *Settings* app, you can configure which alarm tabs should be shown on element, service and view cards. Up to now, when you made changes to the settings on that page, those changes would incorrectly not get applied.

#### NATS: Incorrect 'Timed out on heartbeats' entries would be added to the nats-server.log file \[ID_31572\]

In some cases, a large number of incorrect “Timed out on heartbeats” entries would be added to the nats-server.log file.

#### DataMiner Cube - Service templates: Generated services missing from the list \[ID_31576\]

In some cases, the *Service Templates* app would incorrectly not list generated services of which the ID was identical to that of generated services found on other DataMiner Agents.

#### Problem with SLDataMiner when deleting an alarm template or a trend template \[ID_31583\]

In some rare cases, an error could occur in SLDataMiner when an alarm template or a trend template was deleted.

#### bypassProxy option would incorrectly not be taken into account in case of a websocket connection \[ID_31584\]

When the bypassproxy option had been set in a bus address field, this setting would incorrectly not be taken into account in case of a websocket connection.

From now on, when the bypassproxy option is specified for a websocket connection, the HTTP handshake to set up the websocket connection will not go through the configured proxy server.

#### Jobs app: Preset field values would not be filled in when a newly created job template was applied \[ID_31585\]

When you applied a newly created job template, in some cases, preset field values would incorrectly not be filled in.

#### DataMiner Cube: Problem with external authentication via SAML \[ID_31587\]

When the SAML authentication form contained other fields besides the SAMLResponse field, the authentication would fail.

Also, external authentication via SAML would not work when using the Cube browser app in Microsoft Internet Explorer.

#### DataMiner Cube: Problem when creating an element of type SNMPv3 when the UI language was not set to English \[ID_31588\]

When Cube’s UI language was set to a language other than English, an error could be thrown when you tried to create an element of type SNMPv3.

#### Communication between SLNet and SLHelper will now use NATS \[ID_31589\]

Communication between SLNet and SLHelper will now use NATS instead of .NET remoting.

#### DataMiner Cube - Alarm cards: Services were not sorted naturally \[ID_31607\]

When you opened an alarm card, in some cases, the services affected by the alarm would incorrectly not be sorted naturally.

#### Jobs app: Job templates linked to a job domain were not deleted when the job domain was deleted \[ID_31616\]

In some cases, job templates linked to a job domain would incorrectly not be deleted when the job domain in question was deleted.

#### DataMiner Cube - Visual Overview: Embedded page would incorrectly not show DCF connections \[ID_31627\]

When you opened a visual overview with only one visible page containing an embedded hidden page with DCF connections, in some cases, those DCF connections would incorrectly not be shown.

#### DataMiner Cube - Sidebar: Some applications and modules would not be translated correctly when the UI language was changed \[ID_31633\]

In the *Apps* pane of Cube’s sidebar, some applications and modules would not be translated correctly when you changed the UI language.

#### Memory leak in SLProtocol when a fill array or fill column method passed along empty or null values \[ID_31634\]

In some cases, SLProtocol could leak memory when a fill array or fill column method was called on the protocol object passing along empty or null values for a cell.

#### Problem when SLWatchDog was copying log files to the Minidump folder \[ID_31652\]

When an error of type “thread problem” occurs, the contents of the C:\\Skyline DataMiner\\Logging folder is compressed into a zip file, which is then placed in the C:\\Skyline DataMiner\\Logging\\Minidump folder. During this action, in some cases, a lock inside the SLWatchdog process would accidentally delay the start-up of elements.

#### DataMiner Cube: Problem when refreshing a log file after scrolling down \[ID_31662\]

When, in the *Logging* section of *System Center*, you opened a log file, scrolled down beyond the first 50 KB of data, and then refreshed the file, the vertical scroll position would incorrectly not be restored.

#### DataMiner Cube - Settings: Turning an alarm tab of type 'sliding window' into a normal alarm tab would cause this change to be reverted as soon as another change was made to it \[ID_31664\]

When, in the group settings, you added an alarm tab of type “sliding window” and enforced it, as soon as a user had turned this tab into a normal alarm tab, the slightest change made to the tab afterwards would cause the tab to be changed back into a tab of type “sliding window”.

#### DataMiner Cube - Alarm Console: Problem when alarm tabs were grouped by property \[ID_31673\]

When an alarm tab was grouped by property, in some cases, DataMiner Cube could become unresponsive, especially on systems with high alarm traffic.

#### DataMiner Cube - Scheduler: Creating a task could fail on client machines with culture set to 'Finnish' \[ID_31712\]

In DataMiner Cube, creating a task in the Scheduler app could fail when the culture of the client machine was set to “Finnish”.

#### DataMiner Cube: Element, service and view cards on a saved workspace would not show the correct page when the workspace was opened \[ID_31718\]

When you opened a saved workspace, in some cases, open element, service or view cards would not show the correct page.

#### DataMiner Cube - EPM: Zoom buttons on trend graph popup would incorrectly be displayed twice \[ID_31719\]

When you opened an EPM trend graph popup from a KPI on an EPM card, in some cases, the zoom buttons would incorrectly be displayed twice.

#### Factory reset tool SLReset.exe did not remove a number of .lic files \[ID_31722\]

The factory reset tool C:\\Skyline DataMiner\\Files\\SLReset.exe can be used to fully reset a DataMiner Agent to its state immediately after installation.

When run, it will now also remove the following files:

- ClientApps.lic
- request.lic (will be recreated after a DataMiner restart)
- chartDir.lic

#### DataMiner Cube - Visual Overview: Connectors without a matching DCF connection would incorrectly not be hidden \[ID_31727\]

When, on a visual overview, the “ConnectivityLines\|HighlightPath” page option had connectors replace DCF connections, in some cases, connectors without a matching DCF connection would incorrectly not be hidden.

Also, in some cases, hidden shapes linked to EPM objects would incorrectly be visible.

#### DataMiner Cube - Trending: Problem when opening a histogram \[ID_31731\]

In some cases, an exception could be thrown when you opened a histogram.

#### Dashboards app: Dashboard names would incorrectly be allowed to contain backslash characters \[ID_31735\]

Up to now, it would incorrectly be allowed to enter a name containing backslash characters when creating or renaming a dashboard. From now on, this will no longer be allowed.

#### Dashboards app: Problem when listing the parameters of a selected element \[ID_31737\]

When, in a dashboard, you selected an element, in some cases, an “Index was outside the bounds of the array” error could be thrown when a linked parameter component tried to list all parameters of the element you selected.

#### Failover: DataMiner modules would incorrectly consider the local IP address of the online agent as the primary IP address of the Failover setup \[ID_31756\]

After a Failover configuration had been updated (either manually or after an automatic synchronization), the DataMiner modules would incorrectly consider the local IP address of the online agent as the primary IP address of the Failover setup (instead of the virtual IP address). As a result, when file changes on the Failover setup were forwarded to other agents in the DMS, those agents would reject the changes as the IP address of the sender was unknown to them. Only after a DMA restart or a switchover/switchback operation would the DataMiner modules again use the virtual IP address of the Failover setup.

#### Dashboards app: Problem when sharing a dashboard containing a state timeline \[ID_31757\]

When you opened a shared dashboard that contained a state timeline, in some cases, an error could occur.

#### Jobs app: Hidden or required fields would incorrectly no longer be hidden or required when duplicating a domain or a section \[ID_31758\]

When you duplicated a job domain using the *Duplicate \> Create copies of the sections* option or when you duplicated a job section using the *Create a copy* option, in some cases, hidden or required fields would incorrectly no longer be hidden or required in the newly created domain or section.

#### Service & Resource Management: Problem with GetEligibleResources method \[ID_31818\]

In some cases, the GetEligibleResources method could throw NullReference exceptions or KeyNotFound exceptions.

#### SLAnalytics - Automatic incident tracking: Problem when trying to parse invalid element IDs \[ID_31820\]

When a view contained invalid element IDs, up to now, an exception would be thrown. From now on, when SLAnalytics was not able to parse an element ID, an error will be added to the SLAnalytics log file.

#### PDF reports: Incorrect scaling \[ID_31863\]

Up to now, in some cases, the contents of PDF reports would not get scaled correctly to fit the page.

#### DataMiner Cube - Bookings app: Not all booking data would be flushed from memory when closing the Bookings app \[ID_31880\]

When you closed the Bookings app, in some cases, not all booking data would be flushed from memory.

## Addendum

From DataMiner 10.2.1 onwards, the following release note also applies:

#### DataMiner web apps: Filter issue when using arrow keys in drop-down box \[ID_31472\]

In the DataMiner web apps (e.g. the Dashboards app), when you opened a drop-down box that already had a value selected and used the arrow keys to navigate through the values, the current value was applied as a filter, while this should not occur.
