---
uid: General_Feature_Release_10.2.2
---

# General Feature Release 10.2.2

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## New features

### DMS core functionality

#### Table filters of type 'fullfilter' now support filtering by means of regular expressions \[ID_31893\]

Inside a table filter of type “fullfilter”, it is now possible to filter by means of regular expressions.

In the following example, a regular expression will be applied to column 512:

```txt
fullfilter=(512 REGEX 'x\'y\\\\z' AND 510 == 1000)
```

> [!NOTE]
> In the example above, the regular expression contains a single quote and a backslash character that are part of the query. Since the “fullfilter” syntax requires these characters to be escaped, they have been escaped with an additional backslash character, and as a backslash character in a regular expression also needs to be escaped, four backslash characters were needed here.

#### BREAKING CHANGE: GetSpectrumTrendTraceDataMessage will now always require a time range \[ID_31402\] \[ID_32016\]

When using a GetSpectrumTrendTraceDataMessage to retrieve spectrum data, up to now, it was possible to pass an optional time range (i.e. RangeStart and RangeEnd) next to an ID (i.e. RecordID). From now on, passing a time range next to an ID will be mandatory.

#### EPM: Aliases for topology cells, chains and search chains can now be specified on element level \[ID_32028\]

In an EPM environment, since DataMiner feature release version 10.1.7, it has been possible to override the names of topology cells, chains, and search chains specified in a protocol with aliases specified in a system-level *EPMConfig.xml* file stored in the C:\\Skyline DataMiner\\ folder. Now, it is also possible to add *EPMConfig.xml* files on element level.

If you want certain aliases for topology cells, chains and search chains to only be applied to a particular element, then create an *EPMConfig.xml* file and place it in the folder of that element (e.g. C:\\Skyline DataMiner\\Elements\\\<ElementName>\\).

> [!NOTE]
> Aliases specified in an element-level *EPMConfig.xml* file will override aliases specified in the system-level *EPMConfig.xml* file.

### DMS Cube

#### Trending: New 'Fixed interval' option when exporting average trend data \[ID_31699\]

When you export average trend data, selecting the new *Fixed interval* option will make sure that the data points are equally distributed and that gaps smaller than a time slot (e.g. 5 minutes) are ignored.

> [!NOTE]
>
> - The “fixed interval” option can only be used when exporting average trend data for double, number or analog parameters.
> - When you select the *Fixed interval* option, the *Exclude gaps* option will automatically be selected and disabled to indicate that the latter option is included in the former.
> - When you select the *Line graph* option, from now on, that option will no longer add intermediary data points. Those will now by default be added when you select the *Fixed interval* option.

#### System Center - Users/Groups: New user permission 'Monitoring web app' \[ID_31706\] \[ID_31961\]

In the *General* section of the user permissions list, a new “Monitoring web app” permission has now been added next to the existing “DataMiner web apps” permission. This permission can be used to control access to the Monitoring web app.

This user permission is enabled by default.

#### Alarm templates - Information events: Support for wildcard values \[ID_31872\] \[ID_32106\]

In the alarm template editor, you can indicate that an information event should be generated when a certain parameter reaches a certain value. To do so, you select the *Info* option and enter a value in the text box or, in case of a discreet parameter, select a value in the selection box.

From now on, for parameters of type string or double, it is also possible to enter values that contain a wildcard (\* or ?).

#### DataMiner Cube desktop app: Support for system-wide installation \[ID_31874\] \[ID_32154\]

The DataMiner Cube desktop app now supports system-wide installation via MSI.

> [!NOTE]
> When you install the DataMiner Cube desktop app by means of the MSI installer, all automatic updates will now be blocked. To update the DataMiner Cube desktop app, the administrator will need to install a new MSI file.
>
> Also, Cube will no longer attempt to download and install the CefSharp package automatically. This will now have to be installed manually using the separate CefSharp MSI installation package.

### DMS Reports & Dashboards

#### Dashboards app: 'Start sharing' button replaced by 'Share' button \[ID_31822\]

The “Start sharing” button has been replaced by a “Share” button. Clicking that button will open a popup that allows you

- to create a cloud share, or
- to copy the URL of the dashboard.

When you choose to copy the URL of a dashboard, you can select the following options:

- Select “Embed” to use a URL that will link to the dashboard in embedded mode (i.e. not showing headers and sidebars).
- Select “Use uncompressed URL parameters” to use a URL in which the data in the search parameters is not compressed. This will allow you to see and, if necessary, modify the plain JSON object.

#### Dashboards app: Passing JSON data in a dashboard URL \[ID_31833\] \[ID_31885\]

There are now two ways of passing data in the URL of a dashboard:

- As a dataset containing a number of items to be selected in all components (legacy method)
- As a JSON object containing a number of items to be selected in specific components (new method)

##### Dataset (legacy method)

Up to now, data could be passed to a dashboard using the following syntax:

```txt
url?<datatype1>=<datakeys1>&<datatype2>=<datakeys2>&...
```

Using this method, the dataset, which consists of a list of datatype/datakey(s) expressions, will provide data that will be selected in all relevant components of the dashboard.

##### JSON object (new method)

Next to the legacy method, it is now also possible to pass data to a dashboard in a JSON object.

```txt
url?data=<URL-encoded JSON object>
```

This JSON object has to have the following structure:

```json
{
    "version": 1,
    "feedAndSelect": <data>, (optional)
    "feed": <data>, (optional)
    "select": <data>, (optional)
    "components": <component-data>
}
```

- **\<data>** is a JSON object with a number of property keys (identical to the legacy datatypes) and property values (as an array of datakey strings). See the following example.

    ```json
    {
        "parameters": ["1/2/3", "1/4/6"],
        "elements": ["1/2", "1/8", "212/123"]
        ...
    }
    ```

- **\<component-data>** is an array of objects that allow you to specify data to be passed to one particular component. See the following example:

    ```json
    {
        cid: <component-id>,
        select: <data>
    }
    ```

- When you provide data in the (optional) **feedAndSelect** item, that data will be interpreted as if it would be passed using the legacy method described above.

- When you provide data in the (optional) **feed** item, that data will only be used in the URL feed. It will not be used to select items in selection boxes on the dashboard.

- When you provide data in the (optional) **select** item, that data will only be used to select items in selection boxes on the dashboard. It will not be used in the URL feed.

- In the **components** item, you can provide data to be selected in specific components referred to by their ID.

    > [!NOTE]
    > When you are editing a dashboard, each component will show its ID in the bottom-right corner (e.g. “State 1”).

> [!NOTE]
> When a dashboard updates its own URL, it will use the new format, but in a compressed way. In that compressed syntax, the query parameter “d” will be used instead of “data”.

### DMS web apps

#### BREAKING CHANGE: End of Internet Explorer support for DataMiner web apps \[ID_31675\]

All DataMiner web apps have been upgraded to use Angular 12 instead of Angular 10, which means that the following DataMiner apps and functionality will no longer be available in Internet Explorer:

- The DataMiner landing page
- The Monitoring app
- The Dashboards app
- The Ticketing app
- The Jobs app
- The Application Framework module (currently still in soft launch)
- Automation Script execution in embedded web browser (currently still in soft launch)

> [!NOTE]
> For now we continue to support the use of DataMiner Cube in Internet Explorer, although it is highly recommended to use the DataMiner Cube desktop app instead. For more information, see DataMiner Dojo: <https://community.dataminer.services/documentation/internet-explorer-support/>

### DMS tools

#### New tool to transform a DMS with separate databases into a DMS with a shared Cassandra/Elasticsearch cluster \[ID_31005\] \[ID_31280\] \[ID_31421\] \[ID_31423\] \[ID_31424\] \[ID_31505\] \[ID_31788\]

Using *SLCCMigrator.exe*, you can now transform a DataMiner System consisting of Agents with separate databases into a DataMiner System consisting of Agents that are all connected to a shared Cassandra/Elasticsearch cluster.

For more information on this tool, see [Cassandra Cluster Migrator](xref:Migrating_the_general_database_to_a_DMS_Cassandra_cluster).

#### SLReset: Hostname can now be passed as an argument \[ID_32002\]

When running SLReset.exe, which can be used to fully reset a DataMiner Agent to its state immediately after installation, it is now possible to pass the hostname in a -ho argument, especially when resetting a DataMiner Agent that only allows you to connect via HTTPS.

```txt
SLReset.exe -ho hostname
```

## Changes

### Enhancements

#### Security enhancements \[ID_31169\] \[ID_32081\]

A number of security enhancements have been made.

#### SLElement: Enhanced service impact calculation \[ID_31163\]

A number of enhancements have been made to the service impact calculation in SLElement.

#### Filtering alarms on alarm focus: Enhanced performance \[ID_31484\]

Due to a number of enhancements, especially with regard to caching, overall performance has increased when filtering alarms on alarm focus.

#### Enhanced performance when retrieving alarms and information events from the database \[ID_31494\]

Due to a number of enhancements, overall performance has increased when retrieving alarms and information events from the database.

#### NATS will now be installed during a DataMiner upgrade and re-installed during a factory reset \[ID_31568\]

When it has not yet been installed, NATS will now be installed during a DataMiner upgrade, and it will also be automatically re-installed when performing a factory reset using SLReset.exe.

Also, when NATS is uninstalled, the SLCloud.xml file will now be deleted.

#### Elasticsearch: Backup timeout increased to 15 minutes \[ID_31595\]

The timeout of Elasticsearch backups has been increased from 1 minute to 15 minutes.

This applies to backups taken via DataMiner as well as backup taken via the Standalone Elastic Backup tool.

#### Enhanced performance when initializing elements that are included in multiple services \[ID_31611\]

Due to a number of enhancements, overall performance has increased when initializing elements that are included in multiple services.

#### Trending: Pattern matching enhancements \[ID_31668\]

From DataMiner 10.0.7 onwards, on systems using a Cassandra and an Elasticsearch database, DataMiner Analytics can automatically recognize recurring patterns in trend data.

A number of enhancements have now been made to this pattern matching mechanism. Also, from now on, all occurrences of recognized trend data patterns will be stored in the Elasticsearch database.

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

#### Chromium web browser control: Enhancements with regard to the translations of the find and zoom commands \[ID_31755\]

A number of enhancements have been made with regard to the translations of the find and zoom commands of the Chromium web browser control.

#### DataMiner Cube - System Center: Enhanced Failover configuration window \[ID_31787\]

In the *Agents* section of *System Center*, a number of enhancements have been made to the Failover configuration window.

- The *OK* and *Cancel* buttons have been replaced by *Apply* and *Close* buttons.
- The *Apply* button will only be enabled when changes have been made to the configuration.
- In the configuration window, you will only be allowed to perform one action: switch or apply.
- After you have performed an action, the window will not close automatically. Instead, it will show a message.

#### DataMiner Cube desktop app: Enhanced host detection \[ID_31829\]

In the DataMiner Cube desktop app, a number of enhancements have been made with regard to host detection.

#### CefSharp library loaded primarily from MSI installation folder \[ID_31838\]

To download the CefSharp library, DataMiner Cube will now look in the following locations, in the order specified below:

- The location defined in a registry key created by the Cube MSI installation (*HKLM\\SOFTWARE\\Skyline Communications\\DataMiner Cube\\InstallDir*), by default *C:\\Program Files\\Skyline Communications\\DataMiner Cube*
- *%LocalAppData%\\Skyline\\DataMiner*
- *%ProgramData%\\Skyline\\DataMiner*

#### Dashboards app - Parameter feed: Enhanced performance when fetching parameter indices \[ID_31841\]

Due to a number of enhancements, overall performance of the parameter feed has increased when fetching parameter indices.

#### Enhanced performance when editing an element \[ID_31846\]

Due to a number of enhancements, overall performance has increased when editing an element.

Also, up to now, when an element was edited, all tab characters (“\\t”) in field content would be replaced by spaces. From now on, tab characters will be left untouched.

#### Unclear 'version of the protocol is not correct' notice replaced by 'DataMiner version is too low to use this protocol. Please check the protocol's Compliancies tag.' notice \[ID_31855\]

When a protocol had a minimum DataMiner version that was higher than the DataMiner version of the DMA, up to now, an unclear “version of the protocol is not correct” notice would appear in the Alarm Console and the log files. From now on, that unclear notice will be replaced by a clearer “DataMiner version is too low to use this protocol. Please check the protocol's Compliancies tag.” notice.

#### SLLogCollector: Process list will now also include processes of which the name starts with 'DataMiner' \[ID_31883\]

The SLLogCollector tool will now also list all processes of which the name starts with “DataMiner”. This will allow you to also take memory dumps of processes like “DataMiner CloudGateway”, “DataMiner CoreGateway”, “DataMiner FieldControl”, “DataMinerCube”, etc.

Also, an issue was fixed where duplicate entries would appear in the list after a DMA restart while the tool was open.

#### Service & Resource Management: Ending an ongoing booking by changing the end time will now cause all missed events to be run \[ID_31907\]

When the end time of an ongoing ReservationInstance is set to a time stamp in the past, from now on, all events that have not been run when the booking ended will be run.

#### Enhanced logging when importing groups from Azure AD \[ID_31917\]

From now on, more detailed logging will be added to SLErrors.txt when groups are being imported from Azure AD.

#### DataMiner Cube - System Center: New LDAP settings \[ID_31924\]

In *System Center*, the *LDAP* tab of the *System settings* section allows you to configure a number of LDAP settings. A number of changes have now been made to the *General* tab.

- The *Use custom configuration* option has been replaced by the *Referral configured* option.
- A new *SSL/TLS* option has been added. Enable this option if you want DataMiner to use SSL/TLS when connecting to the LDAP server.

#### SLDataMiner: Enhanced locking when editing elements \[ID_31948\]

A number of enhancements have been made to SLDataMiner with regard to element locking, especially when editing elements.

#### Enhanced socket cleanup after closing a serial connection \[ID_31955\]

A number of enhancements have been made with regard to socket cleanup after closing a serial connection, especially in situations where the “closeConnectionOnResponse” option is enabled or when a close action is performed.

#### DataMiner Cube - Service & Resource Management: Enhanced performance when opening a visual overview of a service linked to a booking and when updating a bookings list \[ID_32054\]

Due to a number of enhancements, overall performance has increased when opening a visual overview of a service linked to a booking and when updating a bookings list.

#### Enhanced performance when loading domain users from Azure AD \[ID_32077\]

Due to a number of enhancements, overall performance has increased when loading domain users from Azure AD.

#### DataMiner Taskbar Utility: Improved entering of credentials before testing the SLNet connection \[ID_32079\]

When you right-click the Taskbar Utility icon and select *Options*, in the *SLNet* tab, you can enter your credentials and click *Test & Save Connection* to test the connection to SLNet.

Up to now, in some cases, you could experience some lag while entering your credentials. From now on, entering your credentials will go much smoother.

#### DataMiner Cube - Visual Overview: Spectrum Analysis component now allows combining an inline preset with one or more measurement points \[ID_32101\]

When configuring a Spectrum Analysis component, it is now possible to combine an inline preset with one or more measurement points.

#### Updated BPA tests \[ID_32102\]

The following BPA tests have been updated:

- Cassandra DB Size
- Check Antivirus DLLs

#### Replication: Name of the local element will now be logged in SLReplication.txt when a replication connection is set up \[ID_32109\]

When a replication connection is set up to another DataMiner Agent, from now on, the name of the local element for which that connection is set up will be logged in the SLReplication.txt file.

### Fixes

#### Cassandra: Incorrect health status \[ID_29502\]

In some cases, the Cassandra health status was incorrect.

#### Proactive cap detection: Problem with frequency of trend prediction calculations \[ID_31447\]

The “proactive cap detection” feature predicts future issues based on trend data in the Cassandra database, using advanced techniques that consider repeating patterns, information on the rate at which a parameter value increases or decreases, etc.

Up to now, in some cases, the frequency with which trend predictions were calculated would either be too low or too high.

#### Problem with SLProtocol when trying to parse data received from SLPort \[ID_31676\]

In some cases, an error could occur in SLProtocol when trying to parse data received from SLPort.

#### Elasticsearch would keep an incorrect number of backups \[ID_31701\]

Elasticsearch would incorrectly keep one backup more than was specified in the “number of backups to keep” setting.

For example, when you had specified that 4 backups had to be kept, Elasticsearch would incorrectly keep 5 backups instead.

#### Problem with SLDataMiner when a trigger to reload service settings was delayed & memory leak in SLElement \[ID_31711\]

When a trigger to reload service settings was delayed, in some cases, a run-time error could occur in the service thread of SLDataMiner.

Also, SLElement could leak memory when services were configured with a delayed trigger or a redundancy condition that persisted for a period of time.

#### Problem with SLElement after restarting an element with a subscription that had a 'resolve' or 'filter' option configured \[ID_31741\]

When there was an active element subscription with a “resolve=x” or “sort=x” filter option configured, in some cases, an error could occur in SLElement when processing table changes after an element restart.

#### SLPort could incorrectly accept a payload containing only a trailer and forward it to SLProtocol \[ID_31743\]

In case of a serial protocol, when both a header and trailer were configured for a response, in some cases, SLPort could incorrectly accept a payload containing only a trailer and forward it to SLProtocol before the timeout of the command was reached.

From now on, if a payload contains only a trailer, the socket buffer will be read until the configured timeout is reached and then the payload will be forwarded to SLProtocol.

#### SLA: Problem when an update of an SLA setting coincided with a window change \[ID_31750\]

When an update of an SLA setting (e.g. Base timestamp, Monitor span, Window size, Window Unit, Window type, Validity start or Validity end) coincided with a window change, in some rare cases, the next window would incorrectly be taken instead of the window that triggered the change. This would cause calculations to incorrectly use a timestamp in the future.

#### Web apps: 'Refresh now' instead of 'Reconnecting...' message after communication was interrupted \[ID_31753\]

Up now on, when a web app (e.g. Dashboards, Monitoring, Ticketing, etc.) lost communication, a “Reconnecting...” message would appear in the UI. From now on, a “Refresh now” message will appear instead, prompting users to refresh the web page.

#### DataMiner Cube - Alarm Console: No context menu would appear when right-clicking an instance of an alarm that impacted more than one service when the alarms were grouped by service \[ID_31764\]

When, in an alarm tab in which the alarms are grouped by service, there is an alarm that impacts more than one service, that alarm will be listed once for every impacted service. Up to now, when you right-clicked one of those duplicate alarms, the context menu would incorrectly not be opened.

#### Failover: Redundancy groups containing DVE elements would not get loaded after a Failover switch or a restart of the Failover system \[ID_31765\]

After a Failover switch or a restart of a Failover system, in some cases, redundancy groups containing DVE elements would incorrectly not get loaded.

#### Elasticsearch: NewPagingSearchRequest was incorrectly not able to query an alias grouping two logger tables \[ID_31767\]

Up to now, a NewPagingSearchRequest was incorrectly not able to retrieve data from an alias that grouped two logger tables.

#### DataMiner Cube - Alarm Console: Base alarms of a correlated alarm not shown on linked alarm tab \[ID_31789\]

When the Alarm Console had an alarm tab that was linked to an element of which an alarm was the base alarm of a correlated alarm, that alarm would incorrectly not be shown.

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

#### Problem with SLAnalytics when a large number of element state updates were being generated \[ID_31810\]

In some rare cases, an error could occur in SLAnalytics when a large number of element state updates were being generated.

#### DataMiner Cube - Settings: Filtered alarm tabs configured to show active alarms and masked alarms would incorrectly only show active alarms \[ID_31815\]

When, in the Settings app, you had configured a filtered alarm tab to contain both active alarms and masked alarms, that alarm tab would incorrectly only show active alarms.

#### Problem when SLAnalytics was stopped while it was writing to the database \[ID_31824\]

When SLAnalytics was stopped while it was writing to the database, in some rare cases, caching issues could occur.

#### Problem with synchronization of SLAnalytics configuration settings \[ID_31825\]

In some cases, SLAnalytics configuration settings would be constantly synchronized among agents in a DataMiner System. From now on, automatic synchronization of SLAnalytics configuration settings will be limited to once an hour.

#### Ticketing app: Problem with Ticket exposer \[ID_31826\]

When the Ticket exposer was used with a filter like the one below, in some cases, incorrect results would be returned:

```csharp
var query = TicketingExposers.Ticket.Contains(@"7999").ToQuery();
```

#### DataMiner Cube - Visual Overview: Connection between two shapes would incorrectly not be hidden when one of the shapes was hidden \[ID_31839\]

When a shape with a connection to another shape was hidden, in some cases, the connection between the two shapes would incorrectly not be hidden.

#### Problem with filtered table subscriptions on DVE elements \[ID_31845\]

When a subscription on a table of a DVE element had been created with a filter (e.g. a primary key filter), the client would receive the initial data but no updates.

#### SLProtocol could leak memory when an enhanced service was tracking alarms that contained duplicate property names \[ID_31851\]

When an enhanced service was tracking alarms, SLProtocol could leak memory when an alarm contained duplicate property names.

Also, the same process could leak memory when a table parameter was cleaned up after an element restart.

#### Failover: Problem when setting up a Failover system with a Cassandra database \[ID_31854\]

In some cases, the following exception could be thrown when a Failover system with a Cassandra database was set up:

```txt
System.Exception: Unexpected error from nodetool.
```

#### SLPhotoManager would incorrectly log 'PrincipalServerDown' exceptions in SLErrors.txt when trying to retrieve pictures of local users \[ID_31865\]

Up to now, when SLPhotoManager was unable to retrieve pictures of local (i.e. non-LDAP) users, it would incorrectly log “PrincipalServerDown” exceptions in the SLErrors.txt log file. From now on, it will log those exceptions in the SLPhotoManager.txt log file when the debug level is set to 5.

#### Web apps - Visual Overview: Native controls inside clickable child shapes would incorrectly not be displayed \[ID_31871\]

When, in a web app, a visual overview had interactive parent shapes with clickable child shapes that contained a native control (e.g. view shapes containing an embedded browser control), that control would incorrectly not be displayed.

#### Scheduled tasks configured to take a DataMiner backup, optimize the database or perform an LDAP resynchronization would incorrectly not get executed \[ID_31877\]

In some cases, scheduled tasks configured to take a DataMiner backup, optimize the database or perform an LDAP resynchronization would incorrectly not get executed.

#### Visual Overview: Hidden pages of an embedded Visio file would incorrectly be displayed when viewed in a web app \[ID_31881\]

When an embedded multi-page Visio file with hidden pages was viewed in a web app, the hidden pages would incorrectly be displayed.

#### DataMiner Cube - Visual Overview: DCF signal paths would not be visualized correctly on pages with a grid layout \[ID_31888\]

In some cases, a DCF signal path would not be visualized correctly on Visio pages with a grid layout.

#### SLNet would thrown an 'Arithmetic operation resulted in an overflow' exception when performance information was being calculated \[ID_31894\]

In some cases, SLNet would thrown an “Arithmetic operation resulted in an overflow” exception when performance information was being calculated.

#### Exported protocols would incorrectly have the same Protocol.Description and Protocol.Type as their parent protocol \[ID_31904\]

Up to now, the Protocol.Description and Protocol.Type values in an exported protocol would incorrectly be identical to those of the parent protocol. From now on, the Protocol.Description and Protocol.Type elements of an exported protocol will contain the export name and the virtual type instead.

#### Failover: Agents not coming online after DataMiner restart \[ID_31915\]

When a Failover configuration incorrectly did not have normal heartbeats defined between the two Agents, the Agents would not automatically come online after a DataMiner restart.

#### Errors occurring while deleting Cassandra compaction and repair tasks could affect the DataMiner startup routine \[ID_31921\]

When a DataMiner Agent with a Cassandra cluster configuration starts up, any scheduled task to compact or repair the Cassandra database is deleted. Up to now, when an error occurred while deleting such a task, in some cases, the DataMiner Agent would not start up correctly.

From now on, any error that occurs while deleting Cassandra compaction and repair tasks will no longer affect the DataMiner startup routine.

#### Dashboard Gateway was not able to access the dashboard configuration files of user accounts other than the one used to set up the Dashboard Gateway connection \[ID_31926\]

Since DataMiner version 10.0.10, a Dashboard Gateway would no longer be able to access the dashboard configuration files of user accounts other than the one used to set up the Dashboard Gateway connection.

From now on, a Dashboard Gateway will be able to access the dashboard configuration files of all users when the user account that is used to set up the Dashboard Gateway connection has been granted the *Modules \> System configuration \> Tools \> Admin tools* permission.

#### DataMiner Cube - Visual Overview: DCF connections incorrectly not shown when opening a second visual overview for the same element \[ID_31931\]

When you had opened a visual overview with DCF information for a particular element, and you opened another visual overview with DCF information for that same element, in some rare cases, the latter would incorrectly not show any DCF connections.

#### Problem when reading out a parameter or element latch \[ID_31932\]

When DataMiner was started or when an element was started, in some cases, the following event could appear in the Windows event viewer:

```txt
Could not read element latch for DMAID/EID. 0x80131533
```

#### Interactive Automation scripts - TreeViewItem: Selecting a tree item would not cause the corresponding valuable to be updated \[ID_31940\]

When you selected an item in a tree view, in some cases, the value of the corresponding variable would not be updated, especially when the parent item was also selected and was configured to not use recursion.

#### Dashboards app: 'Top X alarms' chart would incorrectly not include a graph in a PDF report \[ID_31949\]

When a PDF report was generated of a dashboard containing a “top X alarms” chart based on alarm state duration, in some cases, that chart would incorrectly not include a graph when set to stacked mode.

#### Information event with parameter value 'Set by \<user>...' would incorrectly be generated when an SNMP trap was processed \[ID_31953\]

In some cases, an information event with parameter value “Set by \<user> ...” would incorrectly be generated when an SNMP trap was processed.

#### 'Service Manager not licensed' error when synchronizing files on DataMiner Agents that do not have a Service Manager license \[ID_31958\]

In some cases, when a DataMiner Agent did not have a Service Manager license, a “Service Manager not licensed” error would be thrown when synchronizing files. From now on, when a DataMiner Agent does not have a Service Manager license, no attempt will be made to synchronize system function definitions when synchronizing files.

#### Failover: Standalone BPA Executor could incorrectly not be launched from an offline agent \[ID_31959\]

When, in a Failover setup, the Standalone BPA Executor was launched from the offline agent, up to now, it would throw an exception, stating that the agent was offline. Because this tool must be able to run certain tests on offline agents, it has now been made possible for the Standalone BPA Executor to be launched from an offline agent.

#### GetAnalogTrendDataMessage would incorrectly return 5-minute data point when more than 48 hours of trend data was requested \[ID_31970\]

When a GetAnalogTrendDataMessage was used to retrieve more than 48 hours of trend data for a particular element, in some cases, the result set would incorrectly contain 5-minute data points instead of 60-minute data points.

#### Service & Resource Management: Problem with SLNet when updating ReservationInstance properties \[ID_31973\]

In some cases, an error could occur in SLNet when updating ReservationInstance properties while the status of the instance was being changed.

#### DataMiner Cube - Visual Overview: Trend graph would incorrectly not be loaded when clicking a trend icon \[ID_31978\]

When, in a visual overview that showed a table with trended columns, you opened a trend graph by clicking a trend icon, in some cases, the trend graph would incorrectly not be loaded and a “Trending is currently not enabled for this parameter” message would appear.

#### Cassandra: Incorrect 'null statement' messages would be added to SLDBConnection.txt \[ID_31979\]

In some cases, the following message would repeatedly be added to the SLDBConnection.txt log file:

```txt
Cassandra: tried to execute null statement.
```

#### External authentication via SAML: Problem when logging in with a user account that shared its email address with another account \[ID_31990\]

When, on a system that used external authentication via SAML, you tried to log in with a user account that shared its email address with another user account, up to now, an exception would be thrown. From now on, an error message will be added to the SLSAML.txt log file instead.

#### Failover: Initial file synchronization would incorrectly not be performed \[ID_31991\]

When a standalone DataMiner Agent had been added to a Failover setup, in some cases, the initial file synchronization from online agent to offline agent would incorrectly not be performed.

#### Failover configuration would incorrectly only be saved on the online agent \[ID_32007\]

When a DataMiner Failover setup was configured, in some rare cases, the configuration would incorrectly only be saved on the online agent and not on the offline agent.

#### Failover: Offline agent would not execute its 'go offline' routine after a Failover setup was configured \[ID_32014\]

When a DataMiner Failover setup was configured, in some cases, the offline agent would not execute its “go offline” routine. As a result, certain clean-up actions would not be performed and active Cube clients would stay connected instead of being automatically disconnected.

#### Problem when creating separate SLScripting processes for every protocol being used \[ID_32015\]

In the DataMiner.xml file, you can configure to have separate SLScripting processes created for every protocol being used. When this option was enabled, up to now, when SLScripting processes would crash, in some cases, they would either not get recreated or too many SLScripting processes would get created.

#### Failover: Certain system files would incorrectly not get synchronized to the offline agent during the initial sync \[ID_32034\]

When a Failover system was set up, certain system files (e.g. PropertyConfiguration.xml) would incorrectly not get synchronized to the offline agent during the initial sync.

#### DataMiner Cube: Information templates could no longer be edited when connected to a DataMiner Agent installed on Windows Server 2016 \[ID_32035\]

In DataMiner Cube, in some cases, it would no longer be possible to edit information templates; especially when connected to a DataMiner Agent installed on Windows Server 2016.

#### Mobile apps: Clients would not immediately receive updates when items were added \[ID_32042\]

When new items were added in one client, in some cases, those items would not immediately appear in other clients. For example, when a user created a ticket for a particular domain, other users viewing the list of tickets for that same domain would not immediately have their ticket list updated.

#### DataMiner Cube - Alarm Console: Alarms coming in while grouping or sorting an alarm tab would incorrectly not appear in that alarm tab \[ID_32051\]

In some rare cases, alarms coming in while you were grouping or sorting the alarms on an alarm tab would incorrectly not appear on that alarm tab, especially on heavy-duty systems.

#### Legacy Dashboards: Using 'Add to dashboard' in Cube would no longer work when the DataMiner Agent was only accessible via HTTPS \[ID_32083\]

From DataMiner 9.0 onwards, it is possible to add items to a legacy dashboard directly from the Cube UI, for instance from the Surveyor or an element card.

This functionality would no longer work when the DataMiner Agent was only accessible via HTTPS.

#### Dashboards app: A 'not allowed' message would incorrectly appear when opening a shared dashboard containing EPM components \[ID_32093\]

When you opened a shared dashboard that contained EPM components, in some cases, a “not allowed” message would incorrectly appear.

#### DataMiner upgrade: SLNet could load an incorrect version of the SLUpgrade.dll file \[ID_32094\]

To be able to check the prerequisites during a DataMiner upgrade, SLNet needs to load the SLUpgrade.dll file. In some cases, it would load the 32-bit version instead of the 64-bit version or vice versa.

#### DataMiner landing page: User icon no longer shown in top-right corner \[ID_32108\]

On the DataMiner landing page, the user icon would incorrectly no longer be shown in the top-right corner.

#### Incorrect error in logging during startup of Failover setup \[ID_32112\]

In a Failover setup, during startup the following incorrect error could briefly be reported in the *SLFailover.txt* log file:

```txt
INVALID CONFIG: Failover is active, but no cluster is defined
```

#### SLLogCollector will now also by default collect the most recent backup\_\*.log.txt file and all Database\\\*.xml files \[ID_32114\]

From now on, SLLogCollector will also by default collect the following files:

- The most recent backup\_\*.log.txt file in C:\\Skyline Dataminer\\Backup
- All \*.xml configuration files in C:\\Skyline Dataminer\\Database

#### SLReset would incorrectly delete the Webpages\\root and Webpages\\monitoring folders \[ID_32139\]

Up to now, SLReset would incorrectly delete the following folders:

- C:\\Skyline DataMiner\\Webpages\\root
- C:\\Skyline DataMiner\\Webpages\\monitoring

From now on, SLReset will no longer delete these folders.

#### Newly created elements would incorrectly be assigned an ID equal to -1 \[ID_32178\]

In some cases, newly created elements would incorrectly be assigned an ID equal to -1.

#### SLNet would no longer correctly take into account the system-level EPMConfig.xml file \[ID_32220\]

SLNet would no longer correctly take into account the system-level *EPMConfig.xml* file. As a result, the protocol information received by SLNet would contain topology and search chains with incorrect names.
