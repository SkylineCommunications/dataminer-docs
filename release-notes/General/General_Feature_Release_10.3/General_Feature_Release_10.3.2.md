---
uid: General_Feature_Release_10.3.2
---

# General Feature Release 10.3.2 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.3.2](xref:Cube_Feature_Release_10.3.2).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected for this release yet*

## Other features

#### All DOM objects now have 'LastModified', 'LastModifiedBy', 'CreatedAt' and 'CreatedBy' properties [ID_34980]

<!-- MR 10.4.0 - FR 10.3.2 -->

All DOM objects (DomInstance, DomTemplate, DomDefinition, DomBehaviorDefinition, SectionDefinition and ModuleSettings) will now contain the following additional properties:

- *LastModified*: Date/time (UTC) at which the object was last modified.
- *LastModifiedBy*: Full username of the user who last modified the object.
- *CreatedAt*: Date/time (UTC) at which the object was created.
- *CreatedBy*: Full username of the user who created the object.

> [!NOTE]
>
> - *CreatedAt* and *CreatedBy* are automatically populated when the object is created. Any value assigned to these two fields by a user will always be discarded.
> - *LastModified* and *LastModifiedBy* are automatically updated when the object is updated on the server. Any value assigned to these two fields by a user will always be discarded. When an object is created, these fields will contain the same values as *CreatedAt* and *CreatedBy*.
> - These four fields are not directly accessible on the object. You first need to cast them to either *ITrackBase* or their individual interfaces (*ITrackLastModified*, *ITrackLastModifiedBy*, *ITrackCreatedAt* and *ITrackCreatedBy*).
>
>   `string createdBy = ((ITrackBase) domInstance).CreatedBy;`
>
> - These four fields can all be used in a filter.
> - In the Elasticsearch database, existing data will not contain values for these new fields (except the *LastModified* field for all but *ModuleSettings*).
> - All four fields are also available in the GQI data source *Object Manager Instances*. The *Last Modified* and *Created At* columns should show the time in the time zone of the browser.

## Changes

### Enhancements

#### Security enhancements [ID_35240]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

A number of security enhancements have been made.

#### SLLogCollector will now first check for default.xml files in the LogConfig folder in the same location as SL_LogCollector.exe [ID_34739]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

Up to now, SLLogCollector expected custom collector configuration files named `default.xml` to always be placed in the `C:\Skyline DataMiner\Tools\SLLogCollector\LogConfigs` folder.

From now on, it will first check the `LogConfig` folder in the same location as `SL_LogCollector.exe`. If that `LogConfig` folder does not exist, if the folder is empty or if the `default.xml` file in that folder cannot be deserialized, it will fall back on the `default.xml` file in the `C:\Skyline DataMiner\Tools\SLLogCollector\LogConfigs` folder.

#### More detailed logging when the certificate chain is invalid while connecting to Cassandra [ID_34822]

<!-- MR 10.4.0 - FR 10.3.2 -->

More detailed information will now be added to the `SLDBConnection.txt` log file when the certificate chain is invalid while connecting to Cassandra.

Log entry syntax: `Certificate chain error: {chainStatus.Status}, details: {chainStatus.StatusInformation}`

#### BREAKING CHANGE: Capacity property will no longer be initialized on new Resources [ID_34856]

<!-- MR 10.3.0 - FR 10.3.2 -->

From now on, the *Capacity* property will no longer be initialized on new Resources.

As a result, in DataMiner Cube, the resources module will no longer require the legacy capacity to be initialized. Newly created resources will no longer have a legacy capacity. The concurrency of a resource will still be stored in *Resource.MaxConcurrency*.

##### Impact of this change

Since *Capacity* is no longer initialized on a new Resource, *GetEffectiveMaxConcurrency* will take into account *MaxConcurrency*. *MaxConcurrency* will now be initialized with 1 as is the case with *Capacity.MaxConcurrency*.

If *GetEffectiveMaxConcurrency* should still use the value of *Capacity.MaxConcurrency*, *MaxConcurrency* should be set to 0.

To restore legacy behavior, a new resource should be initialized as follows:

```csharp
var resource = new Resource()
{
  MaxConcurrency = 0,
  Capacity = new ResourceCapacity(),
};
```

This change in behavior will impact results for both *GetAvailableResources* and *GetResourceUsage* on ResourceManagerHelper, both marked as obsolete since 9.6.5. For both methods, newly created resources will now, by default, always be considered unavailable.

#### Web apps - Interactive Automation scrips: Fields containing invalid values will now be indicated more clearly [ID_34962]

<!-- MR 10.4.0 - FR 10.3.2 -->

When, in an Automation script launched from a web app, an input field contains an invalid value, the border of that field will turn red. This red border will now be wider in order to be more visible.

#### GQI: Enhanced performance of GQI queries [ID_34977]

<!-- MR 10.4.0 - FR 10.3.2 -->

Because of a number of enhancements, overall performance of GQI queries has increased, especially when those queries contain join operations.

#### NAS service will now have a quoted image path [ID_34989]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

Up to now, the NAS service had an unquoted image path. From now on, it will instead be installed with a quoted path.

When you want the NAS service on existing setups to have a quoted path, do the following:

1. Execute the following command:

   `sc config NAS binPath="\"C:\Skyline DataMiner\NATS\nats-account-server\nssm.exe\""`

1. Restart NAS and NATS.

#### GQI: Enhanced performance of GQI queries using the 'Get parameters for elements where' data source [ID_35005]

<!-- MR 10.4.0 - FR 10.3.2 -->

Because of a number of enhancements, overall performance of GQI queries using the *Get parameters for elements where* data source has increased.

#### Dashboards app - Line & area chart: Multiple timespans will now be converted to one single time range [ID_35008]

<!-- MR 10.4.0 - FR 10.3.2 -->

When a line & area chart component is fed a collection of timespans, it will now convert those timespans to one single time range.

For example, when a line & area chart component is fed the following timespans...

- *01/01/2022 9:00:00 > 01/01/2022 10:00:00*
- *01/01/2022 9:30:00 > 01/01/2022 10:30:00*

... it will convert those timespans into the following time range:

- *01/01/2022 9:00:00 > 01/01/2022 10:30:00*

#### Service & Resource Management: Enhanced performance when adding and updating bookings [ID_35016]

<!-- MR 10.3.0 - FR 10.3.2 -->

Because of a number of enhancements, overall performance has increased when creating and updating bookings.

#### Web apps: Button styles used in interactive Automation script components have been aligned with those used in low-code app components [ID_35076]

<!-- MR 10.4.0 - FR 10.3.2 -->

In the web apps, the button styles used in interactive Automation script components have now been fully aligned with those used in low-code app components.

#### SLAnalytics - Proactive cap detection: Enhanced accuracy when generating alarm predictions [ID_35080]

<!-- MR 10.4.0 - FR 10.3.2 -->

Because of a number of enhancements, overall accuracy has increased when generating alarm predictions.

#### Web app: More detailed version information in About box [ID_35090]

<!-- MR 10.4.0 - FR 10.3.2 -->

In the *About* box of a web application, you can now find more detailed version information.

| Old name | New name | Description |
|----------|----------|-------------|
| - | Server version | Server version and build number of the DataMiner Agent |
| Client build | Web version | Build number of the web app |
| Client version | App | Version number of the web app |
| Server API version | API | Version number of the Web Services API |

#### GQI: Enhanced query performance when aggregation operations are followed by a filter [ID_35110]

<!-- MR 10.4.0 - FR 10.3.2 -->

Because of a number of enhancements, overall query performance has increased, especially in cases where aggregation operations are followed by a filter.

#### SLAnalytics - Behavioral anomaly detection : More accurate change point time ranges [ID_35121]

<!-- MR 10.4.0 - FR 10.3.2 -->

Because of a number of enhancements, behavioral changes of the type "level shift", "trend change" and "variance change" will now have a more accurate time range when the change in behavior is sufficiently clear.

#### Dashboards - GQI components: Enhanced behavior when loading data [ID_35148]

<!-- MR 10.4.0 - FR 10.3.2 -->

Up to now, a loading skeleton would be displayed each time data was being loaded into a GQI component (e.g. a node edge graph). From now on, only when the component was empty will a loading skeleton be displayed. When existing data in the component is being refreshed, a loader bar will now be displayed instead.

#### Web apps: Enhanced performance when retrieving a list of users [ID_35150]

<!-- MR 10.4.0 - FR 10.3.2 -->

When a web app requests a list of users, the Web Services API will now cache the result set it receives from the server. This will increase overall performance, especially in situations where, up to now, the same list of users had to be retrieved frequently.

This user cache will be cleared each time a change occurs that has security implications (e.g. new users added, user permissions updated, etc.).

#### Enhanced error handling when trying to create resource manager properties with value/key null on Elasticsearch [ID_35155]

<!-- MR 10.3.0 - FR 10.3.2 -->

When an attempt is made to create resource properties, resource definition properties and pool properties with value/key null on a system with an Elasticsearch database, from now on, an `InvalidCharactersInPropertyNames` error listing the names of the properties in question will be added to the Resource Manager log file.

This same fix also fixes the creation and migration of resources of which the property list is null and resource pools of which the property definitions list or properties list is null.

#### DataMiner Object Models: DomInstanceButtonDefinitions can only reference a single action [ID_35156]

<!-- MR 10.4.0 - FR 10.3.2 -->

From now on, DomInstanceButtonDefinitions can only reference a single action. If multiple actions are defined, a `DomBehaviorDefinitionError` with reason `InvalidButtonActionCombination` will be returned.

Also, when using the DomBehaviorDefinition inheritance system, the server-side logic will now make sure that there are no buttons or actions with identical IDs on both the parent and child definition.

- If a duplicate action is found, a `DomBehaviorDefinitionError` with reason `DuplicateActionDefinitionIds` will be returned.
- If a duplicate button is found, a `DomBehaviorDefinitionError` with reason `DuplicateButtonDefinitionIds` will be returned.

#### SAML authentication will now also work with user names instead of email addresses when automatic user creation is not enabled [ID_35159]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

Since DataMiner version 10.2.6 (10.2.0 CU6), SAML authentication would only work when the SAML response claims contained an email address. From now on, SAML authentication will also work with user names instead of email addresses in case automatic user creation is not enabled.

#### Dashboards app - Line & area chart component: 'Group by' setting will now by default be set to 'All together' [ID_35160]

<!-- MR 10.4.0 - FR 10.3.2 -->

In case a *Line & area chart* component displays trending for multiple parameters, the *Group by* setting allows you to specify how the graphs should be grouped. From now on, this *Group by* setting will by default be set to "All together".

#### Enhanced performance when updating a baseline or assigning an alarm template that contains conditional monitoring [ID_35171]

<!-- MR 10.4.0 - FR 10.3.2 -->

Because of a number of enhancements, overall performance has increased when updating a baseline or assigning an alarm template that contains conditional monitoring.

#### Enhanced performance when deleting a service from an Elasticsearch database [ID_35173]

<!-- MR 10.3.0 - FR 10.3.2 -->

Because of a number of enhancements, overall performance has increased when deleting a service from an Elasticsearch database.

#### SLLogCollector: Custom CollectorConfig XML files will now be synchronized across the DataMiner cluster [ID_35180]

<!-- MR 10.4.0 - FR 10.3.2 -->

From now on, all custom CollectorConfig XML files will be synchronized across the DataMiner cluster.

#### SLAnalytics: Enhanced processing of parameter values 'exception' and 'other' [ID_35214]

<!-- MR 10.3.0 - FR 10.3.2 -->

Because of a number of enhancements, overall processing of "exception" or "other" parameter values by the SLAnalytics process has improved.

#### NATS: No attempt will be made to cluster NATS at NATS startup when NATSForceManualConfig is enabled [ID_35221]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

At NATS startup, from now on, no attempt will be made to automatically cluster the NATS nodes when the *NATSForceManualConfig* option is enabled.

If necessary, *NatsCustodianRequests* can be triggered via the SLNetClientTest tool.

#### Low-Code Apps: URLs of published app versions will no longer contain the app version number [ID_35236]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

From now on, the URL of a published version of an app will no longer contain the app version number. Only when you open an earlier version of an app will the URL contain the app version number.

#### ClusterState.xml file removed [ID_35248]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

The `Clusterstate.xml` file, located in the `C:\Skyline DataMiner` folder, was obsolete and has now been removed.

#### Low-code apps: Enhanced confirmation message when deleting an app [ID_35269]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

The confirmation message that appears when you delete an app will now indicate more clearly what will be removed:

- When the app has never been published, only one draft exists. In this case, the confirmation message will clearly state that the entire app will be deleted.

- When the app has been published, multiple versions of the app exist. In the confirmation message, you will be able to choose whether to delete only the current draft or the entire app.

#### Web apps: Date/time picker component will now always show 6 full weeks [ID_35277]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

In all web apps, the date/time picker component will now always show 6 full weeks, regardless of the number of days in the current month. This will prevent the component from having to resize when you switch from one month to another.

#### SLLogCollector now also collects hot threads, node usage and tasks from Elasticsearch [ID_35310]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

SLLogCollector packages will now also include the following additional files containing information retrieved from the Elasticsearch database (if present):

| File | Contents |
|------|----------|
| `\Logs\Elastic\<Node address>\_nodes.hot_threads.txt` | The output of an `GET /_nodes/hot_threads` command. |
| `\Logs\Elastic\<Node address>\_nodes.usage.json`      | The output of a `GET /_nodes/usage` command.        |
| `\Logs\Elastic\<Node address>\_tasks.json`            | The output of a `GET /_tasks?detailed` command.     |

### Fixes

#### Problem with Elasticsearch health monitoring [ID_34744]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When an Elasticsearch cluster used by DataMiner was hosted on servers that host IPv6 addresses, the Elasticsearch health monitoring in DataMiner would fail to assess the Elasticsearch cluster state and conclude that the indexing database was unavailable.

#### External authentication via SAML: Problem when using Okta as identity provider [ID_34745]

<!-- MR 10.3.0 - FR 10.3.2 -->

When using external authentication via SAML, a software issue would prevent you from logging in when Okta was set up as identity provider.

#### Cassandra cluster: Null reference exceptions [ID_34964]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

On systems with a Cassandra cluster, in some cases, messages to SLDataGateway could cause `nullreference` exceptions to be thrown.

Example of an exception stored in the `SLDBconnection.txt` log file:

```txt
SLDBConnection|Skyline.DataMiner.Net.Messages.SLDataGateway.DataRequest`1[Skyline.DataMiner.Net.Messages.SLDataGateway.Alarm]|INF|0|285|System.NullReferenceException: Object reference not set to an instance of an object.
   at SLCassandraClassLibrary.DBGateway.DBGateway.ExecuteRequest[T](DataRequest`1 request)
   at SLCassandraClassLibrary.DBGateway.IncomingConnection.$_executor_ExecuteRequest(BaseRequest request)
```

> [!TIP]
> See [Null reference exceptions in SLDBConnection.txt and unhandled exception when retrieving Correlation details](xref:KI_NullReferenceException_SLDBConnection).

#### Problem with SLDataMiner when loading an alarm template schedule failed [ID_34988]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

In some cases, an error could occur in SLDataMiner when loading an alarm template schedule failed.

#### Alarm templates: Parameters exported to DVE child elements could have incorrect alarm limits [ID_34996]

<!-- MR 10.3.0 - FR 10.3.2 -->

When a parameter was exported as a standalone parameter to a DVE child element, in some cases, the alarm limits could be incorrect when the type of alarm monitoring was set to either *Relative* or *Absolute*.

Also, LED bar controls would either not display or not update their alarm limits.

#### Dashboards app: Button to restore the initial view would incorrectly appear on all tables after sorting or filtering a table [ID_35003]

<!-- MR 10.3.0 - FR 10.3.2 -->

When, on a dashboard, you sorted or filtered a table, a button to restore the initial view would incorrectly appear on all tables on that dashboard. Also, when you clicked one of those buttons, they would all disappear. From now on, when you sort or filter a table on a dashboard, a button to restore the initial view will only appear on that particular table.

#### Web apps - Visual Overview: Certain actions would no longer work [ID_35012]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

In some cases, *Card*, *Script*, *Link* and *Popup* actions would no longer work in visual overviews opened in web apps.

#### Hosting agent filters would be disregarded when alarm events were retrieved from an Elasticsearch database [ID_35049]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When alarm events were retrieved from an Elasticsearch database, any hosting agent filters would be disregarded.

#### SLLogCollector would only take a dump of the first process when multiple processes were specified in the -d command-line option [ID_35074]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When you ran SLLogCollector via the command line and specified multiple processes for which dumps had to be taken (e.g. `SL_LogCollector.exe -c -d=46436,61652`), it would incorrectly only take a dump of the first process.

#### Problem with the generation of TaskCancellationExceptions [ID_35079]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

Modules using the managed SPI framework (Skyline.DataMiner.Spi) would trigger excessive numbers of TaskCancellationExceptions. Also, for the SLNet process, increasing numbers of these exceptions would be generated for every additional Cube client.

#### Monitoring app: Problem when opening the histogram page of a view [ID_35081]

<!-- MR 10.3.0 - FR 10.3.2 -->

When, in the *Monitoring* app, you selected a view and opened the histogram page, in some cases, a `Maximum call stack size exceeded` error would appear.

#### Automation: Memory leak when using the engine.AddScriptOutput method to pass script output of type string [ID_35119]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When an engine.AddScriptOutput method was used to pass output data of type string from a script to the application that executed it or from a subscript to the script that executed that subscript, that output data of type string would incorrectly not get cleared from memory.

> [!TIP]
> See [SLAutomation memory leak when Engine.AddScriptOutput is used](xref:KI_SLAutomation_memory_leak_AddScriptOutput)

#### Dashboards app: Visual Overview component would not show any content when linked to a feed [ID_35130]

<!-- MR 10.3.0 - FR 10.3.2 -->

When a Visual Overview component was linked to a feed, in some cases, it would not show any content.

#### SLElement would leak memory when an element was frequently receiving timeout values [ID_35131]

<!-- MR 10.3.0 - FR 10.3.2 -->

When an element was frequently receiving timeout values, SLElement would leak memory.

#### Trending: Stable trend data points no longer properly refreshed in the database [ID_35139]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

Since DataMiner 10.2.10/10.2.0 CU8, stable trend data points were no longer properly refreshed in the database, which could cause them to be removed from the database when they expired.

> [!TIP]
> See [Stable trend points not kept alive](xref:KI_stable_trend_points_not_kept_alive).

#### Protocols: Problem when using the 'partialSNMP' option when polling tables using the 'multipleGetNext' or 'multipleGetBulk' method [ID_35147]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When the *partialSNMP* option was used when polling tables using the *multipleGetNext* or *multipleGetBulk* method, up to now, rows and values would be skipped when one or more columns did not contain values for one or more rows. This caused the next partial requests to jump forward by the amount of empty cells, resulting in missing rows and unexpected empty cells.

Also, a problem with the detection of infinite loops for SNMPv3 when receiving end-of-mib-view errors has been fixed.

#### Trending: Missing one-day average trend records [ID_35179]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

One-day average trend records would incorrectly only be written into the database if

- a TTL was specified, and
- the *MaintenanceSettings.xml* file contained an entry specifying the window size (e.g. `<TimeSpan1DayRecords windows="120" />`).

From now on, one-day average trend records will be written into the database as soon as a TTL setting has been configured for *Day records*.

Also, the default window size for the records has been restored to 120 minutes (i.e. 2 hours).

> [!TIP]
> See [Missing 1-day average trending records](xref:KI_missing_avg_trending).

#### Dashboards app & Low-Code Apps - Parameter feed: Problem when more than 10,000 elements had to be retrieved from the server [ID_35186]

<!-- MR 10.4.0 - FR 10.3.2 -->

Up to now, the parameter feed used the element cache of the web client to populate its element list. As this cache can only hold up to 10,000 elements, this prevented the parameter feed from retrieving all elements when the cluster contained more than 10,000 elements.

From now on, when the parameter feed has a protocol or view filter, it will fetch all elements matching the filter page by page, even when the total number of elements exceeds 10,000.

#### Problem with wildcard OIDs when specified on a table parameter [ID_35223]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

SNMP table polling would stop working when a wildcard OID was configured on the table parameter. That wildcard OID would always be replaced by 1 instead of the configured parameter value.

Configuring an OID on the table is necessary when using *getNext* (with or without *multipleGet*). In other cases, it is optional. There, a workaround could be to remove the OID configured on the table parameter.

Standalone parameters configured with a wildcard OID were not affected.

#### Dashboards app & Low-Code Apps - Node edge component: Segments of bidirectional edges would not always be positioned consistently [ID_35230]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

In a node edge graph, the segments of bidirectional edges would not always be positioned consistently.

#### DataMiner Object Models: Problem when retrieving a non-existing DomInstance status ID [ID_35231]

<!-- MR 10.3.0 - FR 10.3.2 -->

When a GQI query retrieved the status of a DOM instance that had no status, the logic would incorrectly detect that a status was present and would try to resolve the display name for that status, causing a `Could not find state for statusID ...` error to be thrown.

#### Problem when a GQI message was sent asynchronously to SLNet [ID_35232]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When a client asynchronously sent an GQI message to SLNet, in some cases, an exception could be thrown.

#### Problem during DataMiner startup when an element had its state changed from 'undefined' to 'stopped' [ID_35233]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When redundancy groups were being initialized during a DataMiner startup, in some cases, an error could occur when an element had its state changed from "undefined" to "stopped".

#### Cassandra Cluster: Incorrect db.xml entries could cause db.xml to get corrupted upon synchronization [ID_35237]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

On DataMiner clusters with a Cassandra Cluster database, incorrect *db.xml* entries could cause that file to get corrupted upon synchronization.

#### Dashboards app & low-code apps: Loading indicator would not appear when sorting, filtering or refreshing a table [ID_35238]

<!-- MR 10.3.0 - FR 10.3.2 -->

When you sorted or filtered a table by clicking a table header, or when an action triggered a refresh of the table data, in some cases, no loading indicator would appear.

#### Dashboards app & Low-code apps: Issues with regard to data highlighting [ID_35250]

<!-- MR 10.4.0 - FR 10.3.2 -->

A number of issues with regard to data highlighting have been fixed.

#### Dashboards app & Low-code apps: Enhanced caching of items in query column selection box [ID_35251]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When creating or editing a query, you can select the query columns from a selection box. A number of enhancements have now been made with regard to the caching of this list of query columns.

#### Dashboards app & Low-code apps: Selected data would incorrectly not get removed after being deleted [ID_35254]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When data (e.g. a query) was deleted while it was selected, in some cases, it would incorrectly not be removed from the selection.

#### Dashboards app: Two context menus could incorrectly be displayed simultaneously in the side bar [ID_35255]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When, in the side bar, you right-clicked a folder or a dashboard, and then clicking the ellipsis ("...") in the tab header, two context menus could incorrectly be displayed simultaneously.

#### Dashboards app & Low-code apps - Node edge component: Problem with 'Set as ...' commands in component settings [ID_35256]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When, in the settings of a node edge component, you had selected a configured edge, it would incorrectly be possible to use the *Set as edge* command. This would clear the existing configuration of the edge in question and cause the settings to be saved incorrectly.

From now on, it will only be possible to set a node as edge and vice versa.

#### Dashboards app & Low-code apps: Unknown components would incorrectly no longer be indicated as such [ID_35257]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

In some cases, unknown components would incorrectly no longer be indicated as such.

#### SLAnalytics would incorrectly ignore trend patterns defined for parameters of child DVE elements [ID_35260]

<!-- MR 10.3.0 - FR 10.3.2 -->
<!-- Not added to MR 10.3.0 -->

In DataMiner feature version 10.3.1, SLAnalytics would incorrectly ignore trend patterns defined for parameters of child DVE elements.

#### Documents module: SLDataMiner would leak memory when email addresses and hyperlinks to web pages were retrieved [ID_35261]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

The *Documents* module allows you to integrate documents in DataMiner. This way, you can access relevant information about the elements and services in your system at any time. You can store physical files, email addresses and hyperlinks to web pages.

Up to now, when email addresses and hyperlinks to web pages were retrieved from the XML files in which they are stored, SLDataMiner would leak memory due to a problem with the cleanup of temporary data.

#### Eventing and polling would incorrectly be used simultaneously [ID_35267]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When a client application connects to a DataMiner Agent, it will first try to set up communication via eventing. If communication via eventing fails, the DataMiner Agent will fall back to communication via polling. In some rare cases, both types of communication (i.e. eventing and polling) would incorrectly be used simultaneously.

#### Low-code apps: Keyboard shortcuts would not work in the dashboard editor [ID_35274]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

Up to now, the following keyboard shortcuts would not work in the dashboard editor:

| Shortcut | Action                          |
|----------|---------------------------------|
| CTRL+a   | Select all components.          |
| DELETE   | Delete the selected components. |

#### GQI: Metadata would incorrectly be removed when a custom operator was applied [ID_35283]

<!-- MR 10.3.0 - FR 10.3.2 -->

When, in a GQI query, a custom operator was applied, all metadata available on the rows would incorrectly be removed, causing feeds to no longer work as expected.

Also, when a column was renamed via a custom operator, the metadata available on that column would incorrectly be removed.

#### Spectrum Analysis: 'Visualize measurement points' setting of a spectrum element would no longer be property saved [ID_35293]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When you enabled the *Visualize measurement points* setting of a spectrum element, that change would no longer to properly saved in the element's *element.xml* file. This would cause unexpected behavior after restarting the DataMiner Agent or the element in question.
