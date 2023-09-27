---
uid: General_Main_Release_10.2.0_CU11
---

# General Main Release 10.2.0 CU11

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Security enhancements [ID_35240]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

A number of security enhancements have been made.

#### SLLogCollector will now first check for default.xml files in the LogConfig folder in the same location as SL_LogCollector.exe [ID_34739]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

Up to now, SLLogCollector expected custom collector configuration files named `default.xml` to always be placed in the `C:\Skyline DataMiner\Tools\SLLogCollector\LogConfigs` folder.

From now on, it will first check the `LogConfig` folder in the same location as `SL_LogCollector.exe`. If that `LogConfig` folder does not exist, if the folder is empty or if the `default.xml` file in that folder cannot be deserialized, it will fall back on the `default.xml` file in the `C:\Skyline DataMiner\Tools\SLLogCollector\LogConfigs` folder.

#### DataMiner Cube - Visual Overview: Enhanced performance when loading sorted tree view controls [ID_34795]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

Because of a number of enhancements, overall performance has increased when loading sorted tree view controls.

#### NAS service will now have a quoted image path [ID_34989]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

Up to now, the NAS service had an unquoted image path. From now on, it will instead be installed with a quoted path.

When you want the NAS service on existing setups to have a quoted path, do the following:

1. Execute the following command:

   `sc config NAS binPath="\"C:\Skyline DataMiner\NATS\nats-account-server\nssm.exe\""`

1. Restart NAS and NATS.

#### DataMiner Cube - Trending: Trend points with value "0" will now also be exported to CSV [ID_35124]

<!-- Main Release Version 10.1.0 [CU22]/10.2.0 [CU11] - Feature Release Version 10.3.2 -->

Up to now, when you exported real-time trend data to a CSV file, trend points with value "0" would not be included. From now on, those values will be exported as well.

#### SAML authentication will now also work with user names instead of email addresses when automatic user creation is not enabled [ID_35159]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

Since DataMiner version 10.2.6 (10.2.0 CU6), SAML authentication would only work when the SAML response claims contained an email address. From now on, SAML authentication will also work with user names instead of email addresses in case automatic user creation is not enabled.

#### NATS: No attempt will be made to cluster NATS at DMA startup when NATSForceManualConfig is enabled [ID_35221]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

At DMA startup, from now on, no attempt will be made to automatically cluster the NATS nodes when the *NATSForceManualConfig* option is enabled.

If necessary, *NatsCustodianRequests* can be triggered via the SLNetClientTest tool.

#### Low-Code Apps: URLs of published app versions will no longer contain the app version number [ID_35236]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

From now on, the URL of a published version of an app will no longer contain the app version number. Only when you open an earlier version of an app will the URL contain the app version number.

#### ClusterState.xml file removed [ID_35248]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

The `Clusterstate.xml` file, located in the `C:\Skyline DataMiner` folder, was obsolete and has now been removed.

#### Low-Code Apps: Enhanced confirmation message when deleting an app [ID_35269]

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

#### DataMiner Cube: Latest script updates would not be shown when opening a script in the Automation app [ID_34738]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When you opened the *Automation* app in DataMiner Cube and selected an unmodified script, the latest updates made to that script by another Cube client or another program (e.g. DataMiner Integration Studio) would not be shown. From now on, when you open a script in the Automation app that has not yet been changed in that same app, the latest version of that script will now automatically be retrieved from the server.

#### Problem with Elasticsearch health monitoring [ID_34744]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When an Elasticsearch cluster used by DataMiner was hosted on servers that host IPv6 addresses, the Elasticsearch health monitoring in DataMiner would fail to assess the Elasticsearch cluster state and conclude that the indexing database was unavailable.

#### DataMiner Cube - Alarm Console: Alarm tab of type 'Active alarms linked to cards' would incorrectly not show any alarms when you opened a function card [ID_34799]

<!-- MR 10.1.0 [CU22] / 10.2.0 [CU11] - FR 10.3.2 -->

When the Alarm Console had an alarm tab of type *Active alarms linked to cards*, that tab would incorrectly not show any alarms when you opened a function card, even when that function had active alarms.

Also, when you added a new alarm tab, clicked *Apply filters*, and added an element filter, then you would incorrectly also be able to select virtual functions from the list of elements. From now on, only when you add a function filter will you be able to select virtual functions from the list of functions.

#### Alarm Console: Masking a correlated alarm would incorrectly cause the base alarms to disappear from the 'Active alarms' tab [ID_34815]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

Up to now, when you masked a correlated alarm, the alarm would not only be moved to the *Masked alarms* tab together with all its sources. The base alarms would also disappear from the *Active alarms* tab. From now on, when you mask a correlated alarm, its base alarms will remain visible in the *Active alarms* tab.

#### DataMiner Cube - Protocols & Templates: Function protocols would incorrectly be listed multiple times [ID_34885]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When you opened the *Protocol & Templates* module, in some rare cases, function protocols would incorrectly be listed multiple times in the protocol list.

#### DataMiner Cube: Renaming your local DataMiner user would incorrectly cause that user to disappear [ID_34918]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When you renamed your local DataMiner user with administrative access while being logged in as that user, the user would incorrectly get (partially) removed.

#### Alarm state changes could be generated at an incorrect time in the trend graph of a monitored parameter that needed to be compared to a relative baseline value [ID_34952]

<!-- MR 10.2.0 [CU11] - FR 10.3.1 -->

In the trend graph of a monitored parameter that needed to be compared to a relative baseline value, in some cases, alarm state changes could be generated at an incorrect time.

> [!NOTE]
> When both the baseline and the factor are stored in parameters, then the baseline parameter, the factor parameter and the monitored parameter must all have the history set option enabled. Also, all history sets should be executed chronologically.

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

#### DataMiner Cube: Problem when opening scheduled tasks, Automation scripts or Correlation rules containing actions that include PDF reports [ID_34997]

<!-- MR 10.1.0 [CU22] / 10.2.0 [CU11] - FR 10.3.2 -->

When, in *Scheduler*, *Automation* or *Correlation*, you opened scheduled tasks, Automation scripts or Correlation rules containing actions that include PDF reports, in some rare cases, the data linked to those reports (i.e. the elements and services in view selection) could not be loaded. This data will now be loaded correctly. Also, a "Loading" indicator will now be displayed and the actions will remain disabled while the data is being loaded. When an error occurs while loading the protocols associated with said data, a clear warning entry will also be added to the Cube logging.

> [!NOTE]
> From now on, in the *Elements and services in view selection* list, it will also be possible to select parameters of enhanced services.

#### DataMiner Cube - Spectrum Analysis: Selected measurement point no longer selected after playing a spectrum recording [ID_35001]

<!-- Main Release Version 10.1.0 [CU22]/10.2.0 [CU11] - Feature Release Version 10.3.2 -->

When you selected a measurement point of a spectrum trace, and then played a spectrum recording in which other measurement points were used, the measurement point you selected would incorrectly no longer be selected when the spectrum recording stopped playing.

#### Web apps - Visual Overview: Certain actions would no longer work [ID_35012]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

In some cases, *Card*, *Script*, *Link* and *Popup* actions would no longer work in visual overviews opened in web apps.

#### DataMiner Cube - Alarm Console: Cube freezes when loading a large sliding window [ID_35032]

<!-- Main Release Version 10.1.0 [CU22]/10.2.0 [CU11] - Feature Release Version 10.3.2 -->

When you opened an alarm tab of type "sliding window" with a large number of alarm trees, in some cases, the UI could become unresponsive.

#### Hosting agent filters would be disregarded when alarm events were retrieved from an Elasticsearch database [ID_35049]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When alarm events were retrieved from an Elasticsearch database, any hosting agent filters would be disregarded.

#### DataMiner Cube: Y-axis values could be missing when opening a trend graph [ID_35060]

<!-- Main Release Version 10.1.0 [CU22]/10.2.0 [CU11] - Feature Release Version 10.3.2 -->

When you opened the trend graph of a parameter that contained discrete values or exceptions, in some cases, Y-axis values could be missing.

#### SLLogCollector would only take a dump of the first process when multiple processes were specified in the -d command-line option [ID_35074]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When you ran SLLogCollector via the command line and specified multiple processes for which dumps had to be taken (e.g. `SL_LogCollector.exe -c -d=46436,61652`), it would incorrectly only take a dump of the first process.

#### Problem with the generation of TaskCancellationExceptions [ID_35079]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

Modules using the managed SPI framework (Skyline.DataMiner.Spi) would trigger excessive numbers of TaskCancellationExceptions. Also, for the SLNet process, increasing numbers of these exceptions would be generated for every additional Cube client.

#### Automation: Memory leak when using the engine.AddScriptOutput method to pass script output of type string [ID_35119]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When an engine.AddScriptOutput method was used to pass output data of type string from a script to the application that executed it or from a subscript to the script that executed that subscript, that output data of type string would incorrectly not get cleared from memory.

> [!TIP]
> See [SLAutomation memory leak when Engine.AddScriptOutput is used](xref:KI_SLAutomation_memory_leak_AddScriptOutput)

#### DataMiner Cube - Alarm Console: Incorrect error would appear when a DataMiner cluster had an IDP license but no Resource Manager license [ID_35123]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When a DataMiner cluster had an IDP license but no Resource Manager license, an error would incorrectly appear in the Alarm Console when the agents were synchronized.

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

#### DataMiner Cube - Trending: Trend graph would start to flicker when its data was updated [ID_35181]

<!-- Main Release Version 10.1.0 [CU22]/10.2.0 [CU11] - Feature Release Version 10.3.2 -->

When you opened a trend graph and left it open for a while, it would start to flicker when its data was updated.

#### Upgrading DataMiner Agents known by hostname could fail [ID_35192]

<!-- MR 10.2.0 [CU11] - FR TBD -->

When an agent in a cluster was known by its hostname instead of its IP address, in some cases, a DataMiner upgrade of that agent would fail due to the upgrade process not being able to correctly resolve the hostname to the expected IP address.

#### DataMiner Cube - Data Display: Tables of which the table parameter had its 'Filter' option set to false would incorrectly have a filter box [ID_35196]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When you opened an element card, tables of which the table parameter had its `Filter` option set to *false* in the element protocol would incorrectly have a filter box.

From now on, table filter boxes will be shown or hidden depending on the following rules:

| Protocol option    | Filter box |
|--------------------|------------|
| Filter:true        | Shown      |
| Filter:false       | Not shown  |
| Filter             | Shown      |
| *No Filter option* | Not shown  |

#### DataMiner Cube - Surveyor: Problem when upgrading a view of which the name contains invalid characters [ID_35208]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When a view of which the name contained one of the below-mentioned characters was upgraded to a service, up to now, the *Upgrade to service* action would fail because those characters are not allowed in service names. The view would disappear, but the service would incorrectly not be created.

```txt
\ / : * ? " < > | ° ;
```

From now on, when you try to upgrade a view of which the name contains one of these characters, a pop-up window will appear, saying that the view name contains invalid characters. When you then click *OK*, the pop-up window will close and the view will switch to edit mode, allowing you to change its name.

#### DataMiner Cube - Visual Overview: Parameter value displayed on a shape in history mode would not be updated when linked to a session variable [ID_35219]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When a shape is linked to a parameter via a session variable, the parameter value shown on the shape will be updated when the session variable is updated, and when the shape goes into history mode, the history value of the linked parameter will be shown. However, up to now, when the session variable was updated while the shape was in history mode, the parameter value would incorrectly not be updated.

#### Problem with wildcard OIDs when specified on a table parameter [ID_35223]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

SNMP table polling would stop working when a wildcard OID was configured on the table parameter. That wildcard OID would always be replaced by 1 instead of the configured parameter value.

Configuring an OID on the table is necessary when using *getNext* (with or without *multipleGet*). In other cases, it is optional. There, a workaround could be to remove the OID configured on the table parameter.

Standalone parameters configured with a wildcard OID were not affected.

#### DataMiner Cube - Element Connections app: Problems when creating or updating connections [ID_35228]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When, in the *Element Connections* app, you created a new connection or updated an existing connection, in some cases, duplicate connections would incorrectly be created or existing data would be modified incorrectly.

Also, the *Element Connections* app has now been made fully compatible with the *Skyline Black* theme.

#### Dashboards app & Low-Code Apps - Node edge component: Segments of bidirectional edges would not always be positioned consistently [ID_35230]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

In a node edge graph, the segments of bidirectional edges would not always be positioned consistently.

#### Problem when a GQI message was sent asynchronously to SLNet [ID_35232]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When a client asynchronously sent an GQI message to SLNet, in some cases, an exception could be thrown.

#### Problem during DataMiner startup when an element had its state changed from 'undefined' to 'stopped' [ID_35233]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When redundancy groups were being initialized during a DataMiner startup, in some cases, an error could occur when an element had its state changed from "undefined" to "stopped".

#### DataMiner Cube - Trending: 'Trending is currently not available ...' error would incorrectly be displayed while viewing the trend graph of an EPM object [ID_35234]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

In some cases, a `Trending is currently not available for this parameter` error would incorrectly be displayed when you were viewing the trend graph of an EPM object.

#### Cassandra Cluster: Incorrect db.xml entries could cause db.xml to get corrupted upon synchronization [ID_35237]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

On DataMiner clusters with a Cassandra Cluster database, incorrect *db.xml* entries could cause that file to get corrupted upon synchronization.

#### DataMiner Cube - Visual Overview: Inline preset of spectrum component would no longer be applied [ID_35244]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When you had defined an inline preset while configuring an embedded spectrum component, that preset would no longer be applied. Instead, a `Please select at least one of the preset content items before clicking Load.` message would appear.

#### Dashboards app & Low-Code Apps: Enhanced caching of items in query column selection box [ID_35251]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When creating or editing a query, you can select the query columns from a selection box. A number of enhancements have now been made with regard to the caching of this list of query columns.

#### Dashboards app & Low-Code Apps: Selected data would incorrectly not get removed after being deleted [ID_35254]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When data (e.g. a query) was deleted while it was selected, in some cases, it would incorrectly not be removed from the selection.

#### Dashboards app: Two context menus could incorrectly be displayed simultaneously in the side bar [ID_35255]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When, in the side bar, you right-clicked a folder or a dashboard, and then clicking the ellipsis ("...") in the tab header, two context menus could incorrectly be displayed simultaneously.

#### Dashboards app & Low-Code Apps - Node edge component: Problem with 'Set as ...' commands in component settings [ID_35256]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When, in the settings of a node edge component, you had selected a configured edge, it would incorrectly be possible to use the *Set as edge* command. This would clear the existing configuration of the edge in question and cause the settings to be saved incorrectly.

From now on, it will only be possible to set a node as edge and vice versa.

#### Dashboards app & Low-Code Apps: Unknown components would incorrectly no longer be indicated as such [ID_35257]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

In some cases, unknown components would incorrectly no longer be indicated as such.

#### Documents module: SLDataMiner would leak memory when email addresses and hyperlinks to web pages were retrieved [ID_35261]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

The *Documents* module allows you to integrate documents in DataMiner. This way, you can access relevant information about the elements and services in your system at any time. You can store physical files, email addresses and hyperlinks to web pages.

Up to now, when email addresses and hyperlinks to web pages were retrieved from the XML files in which they are stored, SLDataMiner would leak memory due to a problem with the cleanup of temporary data.

#### Eventing and polling would incorrectly be used simultaneously [ID_35267]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When a client application connects to a DataMiner Agent, it will first try to set up communication via eventing. If communication via eventing fails, the DataMiner Agent will fall back to communication via polling. In some rare cases, both types of communication (i.e. eventing and polling) would incorrectly be used simultaneously.

#### Low-Code Apps: Keyboard shortcuts would not work in the dashboard editor [ID_35274]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

Up to now, the following keyboard shortcuts would not work in the dashboard editor:

| Shortcut | Action                          |
|----------|---------------------------------|
| CTRL+a   | Select all components.          |
| DELETE   | Delete the selected components. |

#### Spectrum Analysis: 'Visualize measurement points' setting of a spectrum element would no longer be property saved [ID_35293]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When you enabled the *Visualize measurement points* setting of a spectrum element, that change would no longer to properly saved in the element's *element.xml* file. This would cause unexpected behavior after restarting the DataMiner Agent or the element in question.

#### Elasticsearch: Problem when fetching metadata referring to stopped elements [ID_35423]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 [CU0] -->

When alarms are being indexed in Elasticsearch, metadata is added. For example, the name of the protocol of the element in question.

Up to now, when SLNet requested that metadata, an error could occur when fetching information regarding a stopped element that had DVE child elements with alarms that had not yet been written to the database.
