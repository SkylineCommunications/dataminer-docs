---
uid: General_Feature_Release_10.1.5
---

# General Feature Release 10.1.5

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## New features

### DMS core functionality

#### All alarms will now be published on the NATS bus \[ID_28441\]

On DataMiner that contain an SLCloud.xml configuration file and are able to connect to a NATS instance, all new real-time alarms will now be published on the NATS bus.

Alarms will be published with the following topic name:

```txt
alarm.dma_id.element_id.pid.row_key
```

Example: alarm.162.951.102.AMP33_SLC

> [!NOTE]
> Currently, the alarm only contains the IDs of the views containing the parent object of the alarm (e.g. element, service, etc.). It does not yet contain the IDs of the views containing all the parents of that parent object.

#### External alarms can now also have general alarm properties \[ID_29231\]

External alarms (e.g. anomaly detection alarms, etc.) can now also have general alarm properties such as “System Name” or “System Type”.

> [!NOTE]
> DataMiner automatically evaluates and populates the “System Name” and “System Type” alarm properties. If you want external alarms to overwrite the values in those properties, make sure new property values are passed along with those external alarms.

#### Mobile Gateway: SMSEagle device can now send Unicode messages \[ID_29369\]

When using an SMSEagle device to send text messages, it is now possible to configure that device to use Unicode characters.

To do so, proceed as follows:

1. In the C:\\Skyline DataMiner\\Mobile Gateway\\Config.xml file, add `unicode="true"` to the \<SMSEagle> element, and save the file.
1. Restart the SLGSMGateway process.

Default setting: unicode=”false”

### DMS Security

#### Importing domain users and user groups from an Azure Active Directory \[ID_28444\]

DataMiner is now able to import domain users and user groups from an Azure Active Directory.

In the DataMiner.xml file, an \<AzureAD> element should be present. See the following example.

```xml
<DataMiner>
  ...
  <AzureAD tenantId=""
           clientId=""
           clientSecret=""
           username=""
           password=""/>
  ...
</DataMiner>
```

> [!NOTE]
>
> - Currently, users imported from an Azure AD can only log in via SAML.
> - In an upcoming release, functionality will be added so that this can be configured directly in DataMiner Cube instead.

#### DataMiner Cube - System Center: New user permission \[ID_29097\]\[ID_29291\]

In the *Users/Groups* section of System Center, you can now configure the following new user permission:

- System Configuration \> DataMiner Object Manager (DOM) \> Module Settings

> [!NOTE]
> This user permission is included in the *Administrators (read-only access to Security)* preset and higher.

### DMS Cube

#### Enhanced table export \[ID_28952\]

The table export mechanism has been reworked.

Also, in case of paged tables, it is now possible to indicate whether you want to export only the current page or the entire table.

#### Resources app: Enhanced UI \[ID_29086\]

The UI of the Resources app has had a complete overhaul. Look and feel are now in line with all other SRM-related apps.

#### Logging of important user actions \[ID_29139\]

From now on, the following important user actions will be logged in the SLClient.txt log file:

- Connect
- Disconnect
- Cube loaded
- Card opened
- Card closed
- Visio file loaded
- Alarm tab created in Alarm Console
- Trend graph opened

#### DataMiner Cube: Warning message will now appear when you duplicate an SNMPv3 element from another DMA \[ID_29192\]

When you duplicate an SNMPv3 element from a DMA other than the one to which you are connected, from now on, a message box will appear, saying that you have to re-enter the SNMPv3 credentials for the newly created element.

> [!NOTE]
> No such message will be displayed when using either a credential library or the NoAuthNoPriv security level.

#### Services app: Duplicating service profile definitions and service profile instances \[ID_29262\]

In the *Profiles* tab of the *Services* app, it is now possible to duplicate service profile definitions or service profile instances.

#### DataMiner Cube: Filter box in Documents app & Documents card pages \[ID_29298\]

In the *Documents* app and the *Documents* card pages, a filter box now allows you to filter the list of documents.

#### Visual Overview: New icons added to Icons stencils \[ID_29315\]

The following icons has been added to the Icons stencil:

- Airplane
- Android
- Apple TV
- Boat
- Browser.2
- Bus
- Car
- Chromecast
- Delete Connections
- Delete Element
- Discover Connections
- Download Configuration Back-Up
- House
- IOS
- Laptop
- Person
- Profile Manager
- Provision Connections
- Reapply CI Type
- Reassign CI Type
- Remove Filter
- Restore Default Configuration
- Train
- Unmanage Element
- Voice

### DMS Reports & Dashboards

#### Dashboards app: Alarm table component \[ID_27790\] \[ID_28012\] \[ID_28142\] \[ID_28519\] \[ID_28718\] \[ID_28887\] \[ID_29131\] \[ID_29456\]

A new alarm table component is now available in the Dashboards app. It can be used to display a list of active alarms, masked alarms, history alarms, alarms in a sliding window, or information events.

Multiple component settings are available:

- Selection of type of alarm list.
- Filter configuration, including index filters using wildcards, and saved alarm filters.
- Default sorting column, default sorting order and number of alarms to load.
- Displayed columns and their order.
- Grouping by a specific column.
- “Expand on hover” layout option.

You can also add different data filters to the component, such as element or view data filters, or parameter feed or time range feed filters. If a parameter index data filter is used, a setting allows you to determine whether the index should match the filter or contain the filter.

#### Dashboards app - Service definition component: Node scaling \[ID_29142\]

In the service definition component, nodes will now have a fixed initial size and ratio. When the service definition does not fit inside the component, vertical and/or horizontal panning will be enabled depending on the direction that is clipped. For example, when a service definition is very wide and its nodes are clipped on the right-hand size, horizontal panning will be possible, but vertical panning will not. Also, zooming in and out will fully scale the nodes so that every-thing keeps its aspect ratio.

> [!NOTE]
> The zoom controls in the bottom-right corner have been removed.

#### Dashboards app - GQI: Linking a \[Get parameters for elements where\] 'Protocol' filter to a parameter feed \[ID_29335\]

After selecting a \[Get parameters for elements where\] “Protocol” filter, it is now possible to link this filter to a protocol feed.

To do so, select the *Use feed* option, and select one of the available parameter feeds from the list. The parameters from that feed will then be added to the query.

#### Dashboards app - GQI: Linking a filter to an index feed \[ID_29338\]

After selecting a filter, it is now possible to link this filter to an index feed.

To do so, select the *Use feed* option, and select one of the available index feeds from the list.

#### Dashboards app - GQI: Linking a \[Get parameter table by ID\] 'DataMiner ID' 'Element ID' filter to a parameter feed \[ID_29351\]

After selecting a \[Get parameter table by ID\] “DataMiner ID” “Element ID” filter, it is now possible to link this filter to a parameter feed.

To do so, select the *Use feed* option, and select one of the available parameter feeds from the list. The first table parameter from that feed will then be added to the query.

#### Dashboards app - GQI: Linking a \[Get elements/services/views/view relations\] \> \[Select\] filter to a parameter feed \[ID_29360\]

After selecting a \[Get elements/services/views/view relations\] \> \[Select\] filter, it is now possible to link this filter to a parameter feed.

To do so, select the *Use feed* option, and select one of the available parameter feeds from the list. The parameters from that feed will then be added to the query.

#### Dashboards app - GQI: Linking a time range filter to a time range feed \[ID_29367\]

Whenever you have to specify a time range when building a query, it is now possible to link this time range filter to a time range feed.

To do so, select the *From feed* option, and select one of the available time range feeds from the list.

#### Dashboards app - GQI: Query filters configured to filter using a regular expression will now combine multiple feed values using “OR” operators \[ID_29396\]

When a query filter using a feed is configured to filter using a regular expression, from now on, it will combine multiple feed values using “OR” operators.

#### Dashboards app: Node-edge graph component \[ID_29425\]

The new node-edge graph component allows you to visualize any type of objects (i.e. “nodes”) and the connections between them (i.e. “edges”). Moreover, by linking parameters and properties to those nodes and edges, you can turn a node-edge graph into a full-fledged analytical tool that shows real-time alarm statuses and KPI data using dynamic coloring.

The data necessary to create a node-edge graph can to be provided by means of GQI queries. Node queries provide data that will be visualized as nodes (i.e. objects), whereas edge queries provide data that will be visualized as edges (i.e. connections between objects).

For more detailed information, see [Node edge graph](xref:DashboardNodeEdgeGraph).

### DMS Automation

#### Interactive Automation scripts: Lazy loading of tree view items \[ID_29295\]

It is possible to configure that a tree view item in interactive Automation scripts will only be loaded when a user expands the item by clicking the arrow in front of it.

You can now use the GetExpanded method of the UIResults class to retrieve the keys of all expanded tree view items that have the SupportsLazyLoading property set to true.

### DMS Mobile apps

#### Jobs app: Added text and number filters for fields \[ID_29221\]

Users can now be allowed to filter on the following field types:

- Text
- Email
- Url

If you want to allow filtering on one of those fields, then select its *Allow filtering on this field* option.

> [!NOTE]
> Text-based filters will behave like case-sensitive “contains” filters.

#### Jobs app: Enhanced time filter \[ID_29328\]

In the Jobs app, the time filter in the sidebar has been improved. You can now indicate whether you want the list to show you the jobs that occurred, started or ended during a particular time frame.

> [!NOTE]
> This time filter will now be stored locally, in the web browser, per domain.

#### Mobile apps will now display a warning when you do not use an HTTPS connection \[ID_29389\]

From now on, when you access a mobile app (e.g. Monitoring, Dashboards, Jobs, Ticketing, etc.), a warning will now be displayed when you do not use an HTTPS connection.

### DMS Service & Resource Management

#### New option to retrieve ProfileInstance parameters from the cache \[ID_29160\]

When the GenerateRequiredCapas method is called on a ProfileInstance, the response will contain all parameters of that instance and its parents. If these parameters are not yet cached on the instances, they will automatically be retrieved from the server. However, in some cases, retrieving them from the server will not be necessary because the script or application in question already cached them.

From now on, the automatic server retrieval can be bypassed by

1. creating a retrieval method that tries to return the parameters that are already cached in the script or application before retrieving them from the server (see the example below), and
1. passing that method to the GenerateRequiredCapas(Func\<ProfileParameterEntry, Parameter> parameterResolver) call.

The following example shows a method that tries to return the parameters that are already cached in the script or application before retrieving them from the server. We first check whether a certain parameter can be found in the local “\_profileParameterCache”. If not, we then retrieve it using the built-in AutoSync collection by means of a get operation on Parameter property.

```csharp
private Parameter GetParameterForParameterEntry(ProfileParameterEntry entry)
{
    if (_profileParameterCache.TryGetValue(entry.ParameterID, out var parameter))
    {
        return parameter;
    }
    // Not found in cache, retrieve using internal AutoSync collection   (by just doing a get on Parameter)
    parameter = entry.Parameter;
    if (parameter == null)
    {
        throw new Exception($"Could not retrieve parameter with ID: {entry.ParameterID}");
    }
    // Add it to our cache
    _profileParameterCache.Add(parameter.ID, parameter);
    return parameter;
}
```

#### New log file: SLResourceManagerAutomation.txt \[ID_29233\]\[ID_29281\]

The following actions will now be logged in the SLResourceManagerAutomation.txt file instead of the SLResourceManager.txt file:

- Actions related to the registering and unregistering of ReservationInstances
- Actions related to the starting of ReservationInstances
- Actions related to the execution of ReservationInstance events

All these log entries will have log level 5.

> [!NOTE]
> In DataMiner Cube, you can access this new log file by going to *System Center \> Logging \> DataMiner \> Resource Manager Automation*.

#### New caching mechanism when retrieving ReservationInstances from Elasticsearch \[ID_29289\]

A caching mechanism involving three separate caches will now be used when retrieving ReservationInstances from an Elasticsearch database, especially when the already saved ReservationInstances have to be checked, e.g. when saving a new ReservationInstance or when requesting the availability of resources in a certain time frame.

##### Overview of the caches

| Cache | Description |
|--|--|
| Hosted ReservationInstance cache | When the ResourceManager module starts, this cache loads the ReservationInstances that are hosted on the agent and schedules the start/stop actions and booking events for these ReservationInstances. Any new instances hosted on the agent that are added or updated while the ResourceManager module is running will also be added to this cache so they can be scheduled. On startup, only the instances starting before a certain point in the future are loaded (default: 1 day). At regular intervals, the database will be checked for instances further in the future. |
| ID cache | When a specific ReservationInstance is requested by ID, the result is cached in this ID cache. When an internal request is made for a specific ID, the cached ReservationInstance will be returned. Used when adding or editing ReservationInstances and when executing start/stop actions and ReservationEvents. |
| Time range cache | When ReservationInstances within a specific time range are requested, all instances in that time range will be cached in this cache. Used when new bookings are created or when eligible resources are requested. |

> [!NOTE]
> GetReservationInstances calls from scripts or clients will go straight to the database. They will not use the caching mechanism.

##### Configuration of the caches

The caches can be configured in the C:\\Skyline DataMiner\\ResourceManager\\Config.xml file. See the following example.

```xml
<?xml version="1.0" encoding="utf-8"?>
<ResourceManagerConfig>
  <CacheConfiguration>
    <IdCacheConfiguration>
      <MaxObjectsInCache>100</MaxObjectsInCache>
      <ObjectLifeSpan>P1DT12H</ObjectLifeSpan>
    </IdCacheConfiguration>
    <TimeRangeCacheConfiguration>
      <MaxObjectsInCache>200</MaxObjectsInCache>
      <TimeRangeLifeSpan>PT30M</TimeRangeLifeSpan>
      <CleanupCheckInterval>PT5M</CleanupCheckInterval>
    </TimeRangeCacheConfiguration>
    <HostedReservationInstanceCacheConfiguration>
      <InitialLoadDays>P10D</InitialLoadDays>
      <CheckInterval>PT12H</CheckInterval>
    </HostedReservationInstanceCacheConfiguration>
  </CacheConfiguration>
</ResourceManagerConfig>
```

Overview of the different settings:

| Cache | Setting | Description | Default value |
|--|--|--|--|
| IdCacheConfiguration | MaxObjectsInCache | The maximum amount of objects that will be kept in this cache. When this threshold is exceeded, the oldest objects will be removed. | 500 |
|  | ObjectLifeSpan | The maximum period of time an entry will be kept in the cache. Each time the entry is hit, this timer is reset. This setting has to be formatted according to ISO 8601. | 10 minutes |
| TimeRangeCacheConfiguration | MaxObjectsInCache | The maximum amount of objects that will be kept in this cache. When this threshold is exceeded, the oldest time ranges will be removed. | 3000 |
|  | TimeRangeLifeSpan | The maximum period of time a time range will be kept in the cache. Each time a query hitting this time range is resolved, this timer is reset. This setting has to be formatted according to ISO 8601. | 10 minutes |
|  | CleanupCheckInterval | The interval at which the time ranges to be removed are checked. This setting has to be formatted according to ISO 8601. | 1 minute |
| HostedReservationInstanceCacheConfiguration | InitialLoadDays | The setting that controls how long into the future the ReservationInstances will be loaded at ResourceManager startup. This setting has to be formatted according to ISO 8601. | 1 day |
|  | CheckInterval | The period of time after which the ResourceManager will load new bookings from the database. | 6 hours |

> [!NOTE]
> The ResourceManagerConfig.InitialLoadDays setting no longer has any use, as the ReservationInstances will now be loaded according to the settings in HostedReservationInstanceCacheConfiguration.

##### ClientTest tool

The SLNetClientTest tool now allows you to retrieve the IDs of the currently cached ReservationInstances. To do so, go to *Advanced \> Apps \> SRMSurveyor \> Inspect ReservationInstance Cache*.

> [!WARNING]
> Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

##### Logging

If loglevel 6 is enabled, the caches will log any added, updated or removed items in the  SLResourceManagerStorage.txt file.

#### Enhanced performance by implementing ISerializable on the ReservationInstance class using protocol buffer serialization \[ID_29306\]

Overall performance has increased by implementing ISerializable on the ReservationInstance class using protocol buffer serialization.

> [!WARNING]
> BREAKING CHANGES:
>
> - The Children and Parent property of a ReservationInstance will no longer be serialized between client and server. When the ResourceManagerHelper is used, backwards compatibility is implemented. However, if you use the messages yourself and receive ResourceManagerEventMessages via subscriptions (which is NOT recommended), you will need to call the GetStitched method on the ReservationInstance class. Saving ReservationInstances with a parent or child instance using messages may also cause issues.
> - When the SetReservationInstances method is called on the ResourceManagerHelper, a random ID will now be assigned before the instances are saved to the server. This could be an issue if scripts expect the ID to be empty and try to reuse the object.

## Changes

### Enhancements

#### NATS: Enhanced log settings & offline Failover agents now prevented from becoming the primary NAS \[ID_28557\]

The settings controlling the NATS server logging have been adjusted. Debug logging is now disabled by default and a new log file will now be created whenever the size of the current one exceeds 3 MB.

Also, offline Failover agents will now be prevented from becoming the primary NAS.

#### Elasticsearch: Alarm will now be generated when Elasticsearch goes into read-only mode \[ID_28821\]

When disk usage exceeds 90 percent on a server running an Elasticsearch database, the database will go into read-only mode. Up to now, when that happened, only an entry was added to the logs. From now on, also an alarm will be generated.

#### Enhanced performance when assigning alarm templates with conditions used in multiple rules \[ID_29109\]

Due to a number of enhancements, overall performance has increased when assigning an alarm template to an element, especially when that alarm template contains conditions that are used in multiple rules.

#### Service & Resource Management: Enhanced loading of ResourceManager module \[ID_29144\]

Due to a number of enhancements, overall performance has increased when loading the ResourceManager module at startup.

#### SLLogCollector tool can now be accessed via the DataMiner Taskbar Utility \[ID_29154\]

You can now open the SLLogCollector tool by selecting *Launch \> Tools \> SLLog Collector* in the DataMiner TaskBar Utility.

#### NATS connection timeout can now be configured \[ID_29172\]

In the SLCloud.xml file, the timeout of the NATS server connection can be now specified in the \<ConnectTimeout> element. Minimum value (in milliseconds): 1000

If this element contains a value lower than 1000 or a non-numeric value, that value will be ignored and an error will be logged in the SLMessageBroker.txt file.

#### Live Sharing service now supports both HTTP and HTTPS connections \[ID_29219\]

The Live Sharing service, which is currently still in soft launch, now supports both HTTP and HTTPS connections.

#### Enhanced loading and initializing of alarm templates \[ID_29236\]

A number of enhancements have been made with regard to the loading and initializing of alarm templates.

#### Database: File offload enhancements \[ID_29238\]\[ID_29245\]

Due to a number of enhancements, overall performance has increased when offloading data to a file.

Also, during file offloads, less disk space will be used.

#### SLAnalytics: Enhanced accuracy of proactive cap detection and behavioral anomaly detection \[ID_29255\]

Due to a number of enhancements made to the way in which history set parameter updates are processed, overall accuracy of the proactive cap detection and behavioral anomaly detection features has increased.

#### '!! No link found for xxx\[xx\] -> xxxx' errors will now be logged in SLErrorsInProtocol.txt instead of SLErrors.txt \[ID_29264\]

Up to now, when a “!! No link found for xxx\[xx\] -> xxxx” error was generated by SLElement, that error would be logged in SLErrors.txt. From now on, this type of errors will be logged in SLErrorsInProtocol.txt instead.

#### SLElement: Enhanced error handling \[ID_29270\]

A number of enhancements have been made to the error handling in SLElement.

#### Enhancements to prevent 'Messages have gone lost, making the connection invalid' errors from being thrown \[ID_29304\]

A number of enhancements have been made to prevent “Messages have gone lost, making the connection invalid” errors from being thrown.

#### DataMiner Cube: Enhancement made to 'Skyline Black' theme \[ID_29370\]

A number of enhancements have been made to the “Skyline Black” theme, especially with regard to readability in the *Database* section of *System Center*.

#### 'Saving report...' entry will no longer be added to SLWatchdog.txt when a Watchdog report has successfully been saved \[ID_29379\]

From now on, when a Watchdog report has successfully been saved, no “Saving report...” entry will be added to the SLWatchdog.txt log file anymore.

#### Enhanced performance of file synchronization operations \[ID_29401\]

When the internal file change repository of the SLDMS process reached a considerable size, up to now, overall performance of the file synchronization operations would decline.

Due to a number of enhancements, overall performance of the file synchronization operations has now been optimized.

#### Service & Resource Management: Enhanced performance when cloning ReservationInstances during quarantine checks \[ID_29408\]

Due to a number of enhancements with regard to the cloning of ReservationInstances, overall performance has increased when performing quarantine checks

### Fixes

#### Dashboards app: Image representing a moved dashboard could not be found \[ID_28661\]

When you moved a dashboard from one folder to another, and then selected the destination folder, in some cases, the image representing the dashboard you moved could not be found.

#### DataMiner Cube: 'Migrate booking data to Indexing Engine' button would still be displayed after the booking data had already been migrated \[ID_28813\]

In DataMiner Cube, clicking the *Migrate booking data to Indexing Engine* button starts a wizard that allows you to migrate booking data from the Cassandra database to the Indexing database. In some cases, this button would incorrectly still be displayed after the booking data had already been migrated.

#### DataMiner Cube - Visual Overview: Element shapes would incorrectly not inherit the service context of their parent element shape \[ID_28867\]

Up to now, an element shape that was a child of another element shape would not inherit the service context of its parent.

From now on, an element shape that is a child of another element shape will inherit the service context of its parent when it does not have a service context of its own.

#### DataMiner Cube: Linked alarm tab would not show all alarms after all cards had been closed & no context menu when right-clicking an app in the Cube header search box \[ID_28893\]

When you closed all cards while a linked alarm tab was open in the Alarm Console, that linked alarm tab would not show all alarms. Instead, it would incorrectly keep the last card you closed as a filter.

Also, when you searched for an app using the search box in the Cube header, right-clicking the app in the search results would not open its context menu.

#### Dashboards app: Multiple parameter feeds in PDF reports would incorrectly also show all selected parameter indices \[ID_28978\]

When you generated a PDF report with the options “No grouping” and “Include feeds” enabled, in some cases, multiple parameter feeds would not only show the selected parameters, but incorrectly also all selected parameter indices.

#### DataMiner Cube - Automation: Discarding a newly created script would not delete it \[ID_29032\]

When you discarded a newly created Automation script, in some cases, it would incorrectly not be deleted although it had disappeared from the UI. As a result, trying to create a new script with the same name would fail.

#### No trigger keys listed when debugging a QAction due to a compatibility issue between DataMiner and DataMiner Integration Studio \[ID_29049\]

Due to a compatibility issue between DataMiner and DataMiner Integration Studio, in some cases, when debugging a QAction, the *Trigger key* box in the *DIS Inject* window would incorrectly not list any trigger keys.

#### NATS service would no longer start up after being reset when a DataMiner Agent was removed from the DMS \[ID_29075\]

In some cases, the NATS service would no longer start up after being reset when a DataMiner Agent was removed from the DMS.

#### SNMPAgent: Engine ID and engine boots counter of local agent would incorrectly be cleared when the users were cleared \[ID_29081\]

Up now on, when an SNMP agent cleared the users during the re-initialization of the SNMP forwarding, the engine ID and the engine boots counter of the local agent would incorrectly be cleared as well. From now on, when an SNMP agents clears the users, it will ignore the engine ID and engine boots counter of the local agent.

#### DataMiner Cube - Resources app: Capacity parameter values would incorrectly be stored without decimals \[ID_29082\]

Up to now, in the Resources app, capacity parameter values would incorrectly be stored without decimals.

#### SLNet.txt log file would contain irrelevant log entries \[ID_29120\]

From now on, the following irrelevant entries will no longer be added to the SLNet.txt log file:

```txt
DmaConnections|Unexpected filter type: SubscriptionFilter\`2
```

```txt
Unexpected filter type: Skyline.DataMiner.Net.SubscriptionFilters.SubscriptionFilter\`2[XXXX,XXXXXX]
```

#### Interactive Automation scripts: Date selected in calendar control would be parsed incorrectly \[ID_29153\]

When, in an interactive Automation script, a calendar control was used to select a date (i.e. a datetime value without a specific time), in some cases, the value of the selected date would be parsed incorrectly.

#### SLAnalytics: Problem when calculating a trend prediction for a parameter with missing trend data \[ID_29163\]

In some cases, an error could occur in the SLAnalytics process when calculating a trend prediction for a parameter with missing trend data.

#### UDP smart-serial server would receive an empty package each time a new client started sending data to it \[ID_29166\]

When multiple clients were sending data to a smart-serial UDP server, that server would incorrectly receive an empty package each time a new client started sending data.

#### DataMiner Cube - EPM: No longer possible to unmask items in a topology diagram or alarms in the Alarm Console \[ID_29173\]

In an EPM environment, in some cases, it would no longer be possible to manually unmask items in a topology diagram or alarms in the Alarm Console.

#### Dashboards app: Ring or Gauge component would incorrectly indicate the maximum value \[ID_29175\]

In some cases, a Ring or Gauge component would indicate the maximum value instead of the current value, especially when that value had a unit assigned.

#### DataMiner Cube: Table columns with a width set to 0 in the protocol would incorrectly be visible \[ID_29196\]

In DataMiner Cube, in some cases, table columns of which the width was set to 0 in the protocol would incorrectly be visible.

#### Dashboards app - GQI: Aggregated values would incorrectly be displayed in raw format \[ID_29200\]

In GQI query results, aggregated values would incorrectly be displayed in raw format. From now on, they will be formatted according to the display properties (e.g. units, decimals, etc.) defined in the protocol.

#### SLAnalytics: Problem when a connection was lost while handling a previous connection loss \[ID_29210\]

In some cases, an error could occur in SLAnalytics when a connection was lost while a previous connection loss was being handled.

#### DataMiner Cube - Alarm Console: Problem when trying to unmask an EPM object \[ID_29213\]

When an EPM object is masked, you can try to unmask it via its alarms in the Alarm Console. These alarms are linked to the EPM object via the “System Name” and “System Type” properties.

In some cases, it would no longer be possible to unmask such an EPM object due to a casing issue in those “System Name” and “System Type” properties.

#### Dashboards app: Multiple pop-up windows would be displayed when an Automation script could not be opened \[ID_29218\]

When the Dashboards app tried to open an Automation script that had been renamed or removed in DataMiner Cube, in some cases, a series of pop-up windows would be displayed. From now on, when the Dashboards app cannot open an Automation script, a single pop-up window will be displayed.

#### DataMiner Cube - EPM: No longer possible to manually unmask items in a topology diagram \[ID_29228\]

In an EPM environment, in some cases, it would no longer be possible to manually unmask items in a topology diagram.

#### Problem in SLNet could cause DataMiner to restart \[ID_29229\]

In some rare cases, an error occurring in SLNet could cause DataMiner to restart.

#### Dashboards app - Parameter feed: Problem with parameter indices in dashboard URLs \[ID_29242\]

In the URL of a dashboard, primary key and display key in parameter indices are by default separated by a forward slash character (“/”). In some cases, when display keys also contained that same character, parameter indices would be parsed incorrectly.

Also, when a dashboard URL containing a selection was refreshed, in some cases, part of that selection would be cleared.

#### Dashboards app - GQI: Colors set for exception values of numeric parameters would not get applied \[ID_29244\]

In the *Layout* tab of the Table component, the *Column filters* option allows you to highlight cells based on a condition. In some cases, colors set for exception values of numeric parameters with a range would not get applied.

Also, the *Column filters* option now allows you to highlight “Not initialized” values.

#### Dashboards app - GQI: Problem when performing an aggregation operation on an additional column \[ID_29249\]

In some cases, an exception could be thrown when a aggregation operation was performed on an additional column.

#### Problem with SLNet when correlation details were requested for alarm groups \[ID_29265\]

In some cases, an error could occur in SLNet when correlation details were requested for alarm groups.

#### DataMiner Cube: Problem when exporting tables to function DVE protocols \[ID_29266\]

When a table is exported to a function DVE protocol, some of the columns can optionally be left out. In some cases, especially when the omitted columns appeared before the primary key or display key columns, DataMiner Cube would interpret the data incorrectly.

#### Data would not get written to the backup agent after configuring a Failover setup on a system with MySQL databases \[ID_29267\]

When a Failover setup is configured on two DataMiner Agents with a MySQL database, after synchronizing the two databases, all new data should be written to both these databases. However, in some cases, new data would incorrectly not be written to the backup agent until after the primary agent had been restarted.

#### DataMiner Cube - System Center: Incorrect counter values on Agents \> BPA page \[ID_29271\]

In *System Center*, on the *Agents \> BPA* page, in some cases, the displayed counters would show incorrect values.

#### Problem with SLAnalytics \[ID_29275\]

In some rare cases, an error could occur in the SLAnalytics process.

#### Dashboards app: Problem when no elements could be found when running an inter-element GQI query that retrieved a table \[ID_29285\]

When no elements could be found while running an inter-element GQI query that retrieved a table, up to now, an exception would be thrown. From now on, an empty result set will be returned instead.

#### BPA framework would not check the DBConfiguration.xml file \[ID_29286\]

Since DataMiner feature version 10.1.3, the configuration of the Elasticsearch clusters can be stored in a new DBConfiguration.xml file, which will then take priority over the existing Db.xml file when it comes to Elasticsearch.

Up to now, the BPA framework was unaware of this new configuration file and would therefore incorrectly report that no Elasticsearch database was available on a DataMiner Agent that was not running.

#### Jobs app: 'no sections added yet' error incorrectly displayed on a booking section \[ID_29293\]

In some cases, a “no sections added yet” error would incorrectly be displayed on a booking section.

#### Problem at DataMiner startup due to an invalid loop in the view hierarchy \[ID_29307\]

On DataMiner startup, in some cases, an error could occur when an invalid loop was found in the view hierarchy. From now on, when an invalid view loop is found, an error mentioning the incorrectly configured views will be logged.

#### Problem when an Element.xml or Service.xml file could not be found \[ID_29322\]

Up to now, in some cases, an exception would be thrown when an Element.xml or Service.xml file could not be found. From now on, an error will be logged instead.

#### Jobs app: Problem when updating section and field definitions \[ID_29325\]

In some cases, changes made to job sections and job fields would not immediately be visible in the UI.

Also, when a field with the *Allow filtering on this field* option enabled had its type changed, in some cases, the *Allow filtering on this field* option would incorrectly stay enabled.

#### Problem with SLDataMiner when an element was stopped \[ID_29327\]

In some cases, an error could occur in SLDataMiner when an element was stopped.

#### Dashboards app: Web components would not load HTTPS-only websites when the Dashboards app was being used with HTTP \[ID_29352\]

When the Dashboards app is being used with HTTP instead of HTTPS (which is not recommended), then it also loads all web component URLs using HTTP, even when they are configured to use HTTPS. As a result, up to now, websites only accessible using HTTPS could not be loaded.

From now on, it will also be possible to load websites only accessible using HTTPS when the Dashboards app is being used with HTTP.

#### Legacy Reporter app: Status query report with table parameters exported to a CSV file would contain tables within table cells \[ID_29355\]

When, in the legacy Reporter app, you generated a report containing a status query with a number of table parameters and exported it to a CSV file, full tables would end up in status query cells.

From now on, when you export a status query report containing table parameters to a CSV file, the data in the table parameters will be exported to separate CSV files as before, but it will no longer appear inside status query cells.

#### DataMiner Cube - Bookings app: Bookings without an end time would incorrectly only be listed when their start time was within the specified time window \[ID_29356\]

In the Bookings app, booking without an end time would incorrectly only be listed when their start time was within the specified time window.

#### Using an NT_EDIT_PROPERTY (62) call to update an alarm property of a DVE element would fail when no element ID was specified \[ID_29358\]

When an alarm property of a DVE element was updated using a SetDataMinerInfoMessage of type 62 (NotifyType.EditProperty) without specifying the element ID, the request would fail with an “element is unknown” error.

#### Elements with a large amount of data stored in a Cassandra database would fail to start \[ID_29363\]

On systems with a Cassandra database, in some cases, elements that had a large amount of data stored in the database would fail to start.

#### Dashboards app - CPE feed: Selection box contained too much data \[ID_29377\]

Due to incorrect filtering, in some cases, the selection box in the CPE feed would contain too much data.

#### DataMiner Cube: Problem when selecting a value from a drop-down parameter in a custom context menu of a table \[ID_29383\]

If a parameter of type “drop-down” in a custom context menu of a table retrieved its values from a dependency parameter, in some cases, the first time a value was selected, the selection would not be applied.

#### Jobs app: Fields in newly created copy of a section definition would have an incorrect field type \[ID_29387\]

When you copied a section definition from one job domain to another, in some cases, fields in the newly created section definition would have an incorrect field type.

#### Jobs app: Small typographical error in warning message \[ID_29388\]

When, in the Jobs app, you tried to hide the only domain that was visible, up to now, the warning message that appeared, would contain a small typographical error.

- Former message: “Atleast one job domain should be visible.”
- New message: “At least one job domain should be visible.”

#### Jobs app: Booking sections did not have their initial values filled in \[ID_29392\]

In some cases, booking sections did not have their initial values filled in.

#### Jobs app: Jobs no longer selected after canceling a delete operation \[ID_29402\]

When you selected a number of jobs in the list, clicked *Delete*, and then clicked *Cancel*, in some cases, the jobs you had selected would no longer be selected.

#### Service & Resource Management:  VirtualFunctionResource could not be bound with the same index as another VirtualFunctionResource \[ID_29403\]

In some cases, it would not be possible to bind a VirtualFunctionResource when another VirtualFunctionResource was already bound to a different entrypoint table with the same index.

#### Automation: Subscripts would return an incorrect output \[ID_29405\]

When, in an Automation script, a subscript that returned its output was run twice, in some cases, when it cleared its output during its second run, it would incorrectly return the same output it had returned at the end of its first run.

#### SLAnalytics: Problem with automatic incident tracking when a parent of a particular view could not be found \[ID_29419\]

In some cases, an error could occur during automatic incident tracking when a parent of a particular view could not be found.

#### Problem with SLDataMiner when elements without a valid protocol configured were started \[ID_29454\]

In some cases, an error could occur in SLDataMiner when elements without a valid protocol configured were started.

#### Legacy Reporter: Status query would no longer show alarm colors \[ID_29516\]

In the legacy Reporter app, in some cases, the status query would no longer show alarm colors.
