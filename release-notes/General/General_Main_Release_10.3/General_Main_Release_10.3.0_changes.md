---
uid: General_Main_Release_10.3.0_changes
---

# General Main Release 10.3.0 – Changes (preview)

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes related to DataMiner Cube, see [DataMiner Cube 10.3.0](xref:Cube_Main_Release_10.3.0).

## Changes

### Enhancements

#### Security enhancements \[ID_31045\] \[ID_31054\] \[ID_31761\] \[ID_32055\] \[ID_32566\] \[ID_33069\] \[ID_33078\] \[ID_33218\] \[ID_33365\] \[ID_33583\]

A number of security enhancements have been made.

#### Function.xml files can now contain functions without entry points and maxInstance set to 1 \[ID_31480\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.1 -->

In a functions.xml file, it is now possible to define functions without entry points and maxInstance set to 1. When all criteria are met, then a function of this type will affect all tables and column parameters defined for that particular function.

> [!NOTE]
> When you defined a function without entry points and maxInstance set to 1, \[Generic Linker Table\] entries will not be taken into account. This function will still affect all table and column parameters defined for it.

#### Filtering alarms on alarm focus: Enhanced performance \[ID_31484\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.2 -->

Due to a number of enhancements, especially with regard to caching, overall performance has increased when filtering alarms on alarm focus.

#### Enhanced performance when reading data from a MySQL or SQLServer database \[ID_31532\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.1 -->

Due to a number of enhancements, on systems with a MySQL or SQLServer database, overall performance has increased when reading data from the database, especially when reading trend data during the migration to another type of database.

#### Enhanced performance when reading trend data from a MySQL or SQLServer database page by page \[ID_31535\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.1 -->

Due to a number of enhancements, on systems with a MySQL or SQLServer database, overall performance has increased when reading trend data from the database page by page.

#### Trending: Pattern matching enhancements \[ID_31668\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.2 -->

From DataMiner 10.0.7 onwards, on systems using a Cassandra and an Elasticsearch database, DataMiner Analytics can automatically recognize recurring patterns in trend data.

A number of enhancements have now been made to this pattern matching mechanism. Also, from now on, all occurrences of recognized trend data patterns will be stored in the Elasticsearch database.

#### Alarm templates: Enhanced performance when adding alarm templates with smart baselines \[ID_31670\]

<!-- Main Release Version 10.3.0 - Feature Release Version (REVERTED) 10.2.3 [CU0] -->

Due to a number of enhancements, overall performance has increased when adding alarm templates with smart baselines.

#### Cassandra will no longer store ArrowWindowRecords and PatternMatchOccurrenceRecords \[ID_31944\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.4 -->

Cassandra databases will no longer store the following data:

- ArrowWindowRecords
- PatternMatchOccurrenceRecords

The latter will now be stored in Elasticsearch instead.

#### Behavioral anomaly detection: Change point flood notice will now be cleared sooner \[ID_32013\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.3 -->

From now on, the notice created when the rate of newly detected behavioral changes reaches an upper limit will be cleared sooner. It will now be cleared when the rate has dropped under the limit again and there is no new flood situation in the following 15 minutes. Up to now, the notice would not be cleared for at least 2 hours, even when the actual flood situation had only lasted for a few seconds.

The notice will contain the following message:

```txt
Detection of behavioral anomalies temporarily disabled on DMA ...: maximum allowed rate of behavioral change points reached.
```

#### SLAnalytics - Alarm focus: Enhanced performance \[ID_32270\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.3 -->

From DataMiner 10.0.0/10.0.2 onwards, the DataMiner Analytics software assigns an estimated likelihood or “alarm focus score” to each alarm, after analyzing the short-term history and current behavior of incoming alarms in real time. Due to a number of enhancements, overall performance of this alarm focus feature has increased.

#### Analytics: Prefetching mechanism for trend icons \[ID_32300\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.4
Reverted in 10.2.4 -->

During the first few minutes that DataMiner Analytics is running, it is still calculating which trend icons should be displayed. Previously, during this initial period, the trend icons to be displayed were retrieved from the Cassandra database. However, because of changes to the database, this is no longer possible. For this reason, a prefetching mechanism has now been implemented, so that when a trend icon is requested, it is calculated based on prefetched trend data. As there are safeguards in place to ensure that not too many database requests are done at the same time, this does mean that not all trend icons may be displayed immediately.

#### SLAnalytics: A notice event will no longer be generated when entering change point flood mode \[ID_32402\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.3 -->

Up to now, a notice event would be generated whenever SLAnalytics had entered change point flood mode. From now on, this event will no longer be generated.

> [!NOTE]
> As before, an entry will be added to the SLAnalytics log whenever behavioral anomaly detection has temporarily been disabled because change point flood mode was activated.

#### SLAnalytics: Enhanced accuracy of proactive cap detection \[ID_32591\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.8 -->

Because of a number of enhancements, proactive cap detection accuracy has been increased.

#### SLMessageBroker: Default connection timeout is now 10 minutes \[ID_32884\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.5 -->

The Connect() and Publish() methods of SLMessageBroker now have a default connection timeout of 10 minutes.

Also, the interval at which another reconnect is attempted has been increased from 1 second to 10 seconds.

#### Enhancements with regard to Automation scripts \[ID_33129\] \[ID_33226\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.6 -->

A number of enhancements have been made with regard to Automation scripts.

- When a script is launched, from now on, only the parameters/dummies with missing values will be shown. Automatically filled in values will no longer be shown.
- When script input is filled in with feed data, users will no longer be asked to change that input manually.
- Script input (parameters/dummies) linked to a feed is now filled in at the moment a script action is triggered. Subsequent changes in the feed will have no effect.
- In the DataMiner Low-Code Apps, the option to mark specific script parameters and dummies as required has been removed.
- When, in the Dashboards app, users mark a script parameter as required, they no longer need to fill in a value.
- From now on, a page load event will only trigger after the application page has been fully initialized. This will ensure that, when launching script actions with input linked to feeds, those feeds have been initialized.

#### Service & Resource Management: Enhanced logging \[ID_33183\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.6 -->

Up to now, when the SRM log files were set to “No logging”, no information would be logged if e.g. a Reservation event had failed. All ResourceManager, ResourceManagerAutomation and FunctionManager logging has now been re-evaluated, and the log settings have been optimized. All critical issues occurring in those modules will now be logged.

#### Profile instance list for PA service definition node now also contains child instances \[ID_33187\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.6
See also: DMS Cube - Fix was moved to 10.2.0 CU3 by RN 33188 -->

When you configure a service definition node in the Services app, a list of profile instances is shown for the selected profile definition. For service definitions of type "Skyline Process Automation" and "Custom Process Automation", this list will now also contain instances for child definitions of the configured profile definition.

#### Anomaly detection: Enhanced performance when generating suggestion events and alarms \[ID_33283\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.6 -->

Because of a number of enhancements, overall performance has increased when generating anomaly detection suggestion events and alarms.

#### DataMiner upgrade will not be performed if NATS is not installed and running \[ID_33304\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

When you launch a DataMiner upgrade, from now on, the upgrade process will not be allowed to start if NATS is not installed and running.

> [!NOTE]
> This check will be skipped if the current DataMiner version is older than version 10.1.0.

#### SLDMS will now use less memory when storing service information \[ID_33318\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

Because of a number of enhancements, the SLDMS process will now use less memory when storing service information.

#### QADeviceSimulator: Enhanced CPU usage when running SNMPv3 simulations \[ID_33376\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

Because of a number of enhancements, overall CPU usage of the QADeviceSimulator has improved when running SNMPv3 simulations.

> [!CAUTION]
> This tool is provided “As Is” with no representation or warranty whatsoever. Skyline Communications will not provide any maintenance or support for this tool.

#### Service & Resource Management: Function resources will no longer be deleted when their parent DVE element cannot be reached \[ID_33415\] \[ID_33668\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

From now on, the deletion of a function resource will be blocked when the deletion of its parent DVE element fails.

The ResourceManagerHelper now contains a new method to delete resources:

`public Resource[] RemoveResources(Resource[] resources, ResourceDeleteOptions options)`

> [!NOTE]
> Contributing resources can be deleted even when no parent element can be found. The parent element of a contributing resource is an enhanced service element. When the contributing booking is no longer running, the enhanced service element will no longer exist.

#### SLAnalytics: Enhanced performance when retrieving parameter information \[ID_33458\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

Because of a number of enhancements, overall performance has increased when retrieving parameter information.

#### Web apps: Enhancements with regard to the rendering of GQI tables \[ID_33463\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

A number of enhancements have been made with regard to the rendering of GQI tables.

#### Alarm templates: All behavioral change points will now be considered anomalous \[ID_33476\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

From DataMiner 10.0.3 onwards, you can enable alarm monitoring on specific types of anomalies for parameters in an alarm template. Up to now, when you enabled this, an alarm was generated whenever the SLAnalytics engine considered a behavioral change point anomalous. From now on, all behavior change points will be considered anomalous and will hence trigger an alarm.

#### QADeviceSimulator: Enhanced performance when loading a MySQL database at the start of a MySQL database simulation \[ID_33555\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

Because of a number of enhancements, overall performance of the QADeviceSimulator has improved when loading a MySQL database at the start of a MySQL database simulation.

Also, the overall memory footprint of MySQL database simulations has been reduced.

> [!CAUTION]
> This tool is provided “As Is” with no representation or warranty whatsoever. Skyline Communications will not provide any maintenance or support for this tool.

#### Service & Resource Management: A booking will now be set to 'interrupted' when whatever event related to that booking could not be executed \[ID_33576\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.8 -->

Up to now, when DataMiner was unavailable when a booking was supposed to start or stop, its state was set to “interrupted” when DataMiner started up again.

This functionality has now been extended. A booking will now also be set to “interrupted” when whatever event related to that booking could not be executed.

#### Frequency of smart baseline calculations is now configurable \[ID_33584\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

It is now possible to change the frequency of smart baseline calculations. On systems that aggregate large amounts of data from parameters with smart baselines, it is recommended to increase this frequency, which is 5 minutes by default.

To change this setting, do the following:

1. Open the SLNetClientTest tool.
1. Go to *Advanced \> Options \> SLNet Options*.
1. Select the *SmartBaselineThreadTime* option and change its value.

Minimum value: 1 minute - Default value: 5 minutes

> [!WARNING]
> Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### External authentication using SAML: Extended logging [ID_33622]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.10 -->

When authenticating users using SAML, the following additional debug information will now be logged in the *SLSaml.txt* file:

- Whether Just-In-Time provisioning (JIT) is enabled.
- Which group claims are being used.

#### Dashboards app / Low-Code Apps: Support for feed categories in components [ID_33719]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

Up to now, components could only produce one feed for each data type. Now support has been added for different categories within a data type, so that components will be able to produce several feeds for the same data type. This will for example make it possible for a component to produce a query row feed with the categories "timeline item" and "timeline band".

#### QA Device Simulator: Enhanced performance \[ID_33761\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

Because of a number of enhancements, overall performance of the QA Device Simulator tool has improved.

#### Maximum for element timeout setting increased to 24 hours \[ID_33862][ID_33951]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

The maximum value for the element setting "*The element goes into timeout state when it is not responding for (sec)*" has now been increased from 120 seconds to 24 hours (i.e. 86400 seconds).

#### DataMiner Analytics: Improved handling of clearable alarms [ID_33910]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

Up to now, DataMiner Analytics handled clearable alarms with severity "Normal" in the same way as cleared alarms. This meant that these were automatically removed from alarm groups (also known as incidents).

From now on, clearable alarms will keep the alarm focus from the last alarm in the alarm tree that had a non-normal severity. They will also stay in the same alarm group they were in before their severity became "Normal".

#### Service & Resource Management: Enhancements made to ResourceManagerHelper [ID_33993]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

A number of enhancements have been made to the ResourceManagerHelper class.

For example, from now on, an ArgumentNullException will be thrown when a NULL argument is provided. Also, when a collection with one or more NULL objects is provided, those objects will be ignored.

#### GQI: Improved performance of column filter [ID_34014]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

Instead of a client-side filter, a more efficient server-side filter is now used to filter columns of a table component showing GQI data in a dashboard or low-code app. This will greatly improve the filter performance. However, because this server-side filter does not support "OR" filters, it will no longer be possible to combine multiple conditions within the same filter.

#### Dashboards / Low-Code Apps: Table filter improvements [ID_34022]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

If you used the search box below a table displaying GQI data to filter this data, up to now, this could cause a serious load on the server in case a large number of rows had to be retrieved. To prevent this, the following conditions will now be applied to determine if more data should be retrieved:

- If the table already has enough rows to fill the next page, no further data will be retrieved.
- If the condition above is not met, at least 250 rows will retrieved initially.
- If at least one record is found that matches the search filter, no more rows will be retrieved. You will then need to click a "Load more" button to retrieve more data.
- If 2000 additional records have been retrieved after you click "Load more", no more data will be retrieved until you click the button again.
- If you scroll through the results, additional data will be fetched until there are enough rows to fill the next page.

#### Improved SPI logging for Automation [ID_34025]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

The log levels of some of the log lines related to SPIs in the *SLAutomation* log file have been changed, so that the log file does not get flooded with potentially irrelevant data. In addition, these log lines will now contain the SPI node ID and definition ID. The log line mentioning the SPI definition ID when this definition is created will no longer be added.

#### Dashboards app / Low-Code apps: No more statistics and suggestions for conditional coloring of Table and Node edge component [ID_34037]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->
<!-- Part of this RN is still in soft launch and consequently has not been documented yet -->

To improve performance, in the *Layout* pane for a Table or Node edge component, no more statistics and suggestions will be shown for conditional coloring.

#### GQI: Initial support for nested tables [ID_34144]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

Initial support has been added for GQI results with cells containing nested records. However, at present this is only used for the *Resources* data source, which still requires the *GenericInterface* [soft-launch option](xref:SoftLaunchOptions).

The following functionality is now available for nested tables:

- Checking the number of records in nested tables. If a column with nested tables is retrieved, you cannot inspect the nested tables themselves yet, but a display value will show the number of records they contain.
- Aggregation on a single nested table column. There is no support for grouping yet. The aggregated value of the nested cell will be shown in the parent record as an ordinary cell.
- Filtering of nested tables.
- Selecting columns from nested tables. These will be shown in the same list box as regular columns, but their name will be prefixed by the parent column name. For example, if the parent column is named "Capabilities" and the nested table column is named "Name", the column will be listed as "Capabilities.Name".

#### Dashboards app / Low-Code apps: Conditional coloring layout configuration now uses numeric filter instead of numeric slider [ID_34174]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.10 -->
<!-- Part of this RN is still in soft launch and consequently has not been documented yet -->

In the conditional coloring layout setting for Table and Node edge components, the numeric slider control has been replaced with a numeric filter. This has the following advantages:

- Full control over the boundaries. You can indicate whether the start and end should be in- or excluded.
- Possibility to not have a start or end boundary.
- More consistent with the free text filter.
- Easier to define a precise filter.

#### Dashboards app / Low-Code apps: Conditional coloring layout filter configuration now shows discrete column values [ID_34182]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.10 -->
<!-- Part of this RN is still in soft launch and consequently has not been documented yet -->

In the conditional coloring layout setting for Table and Node edge components, discrete column values will now be displayed to make it easier to configure a filter.

#### SLReset will no longer remove VersionHistory.txt and the HTTPS configuration [ID_34194]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.10 -->

From now on, the factory reset tool *SLReset.exe* will no longer remove the following items:

- the *VersionHistory.txt* file
- the HTTPS configuration stored in the *MaintenanceSettings.xml* file.

#### GQI table column names will no longer include table names [ID_34302]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.10 -->

When a GQI table column inherits its name from a parameter of which the name includes the table name (between brackets), that table name will now be trimmed from the column name.

#### Improved performance of SLDataGateway process [ID_34206]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.10 -->

Because of improved internal logic, the performance of the SLDataGateway process has improved.

### Fixes

#### SLAnalytics: Problem with trend prediction \[ID_31352\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.1 -->

In some rare cases, an error could occur in SLAnalytics when calculating trend predictions.

#### Proactive cap detection: Problem with frequency of trend prediction calculations \[ID_31447\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.2 -->

The “proactive cap detection” feature predicts future issues based on trend data in the Cassandra database, using advanced techniques that consider repeating patterns, information on the rate at which a parameter value increases or decreases, etc.

Up to now, in some cases, the frequency with which trend predictions were calculated would either be too low or too high.

#### Alarm templates: Incorrect calculation of smart baselines \[ID_31601\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.6 -->

In some cases, smart baselines would be calculated incorrectly, especially when the “Skip the last X hours in the configured trend window” and “Handle weekend days separately” options were enabled.

#### Factory reset tool SLReset.exe did not remove a number of .lic files \[ID_31722\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.1 -->

The factory reset tool C:\\Skyline DataMiner\\Files\\SLReset.exe can be used to fully reset a DataMiner Agent to its state immediately after installation.

When run, it will now also remove the following files:

- ClientApps.lic
- request.lic (will be recreated after a DataMiner restart)
- chartDir.lic

#### Dashboards app: Dashboard names would incorrectly be allowed to contain backslash characters \[ID_31735\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.1 -->

Up to now, it would incorrectly be allowed to enter a name containing backslash characters when creating or renaming a dashboard. From now on, this will no longer be allowed.

#### Elasticsearch: NewPagingSearchRequest was incorrectly not able to query an alias grouping two logger tables \[ID_31767\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.2 -->

Up to now, a NewPagingSearchRequest was incorrectly not able to retrieve data from an alias that grouped two logger tables.

#### Service & Resource Management: Retrieving ReservationInstances sorted by a property of type string would return an incorrectly sorted result set \[ID_32003\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.3 -->

When a list of ReservationInstances were retrieved sorted by a property of type string, that list would be returned in an incorrect sort order.

#### Mobile apps: Clients would not immediately receive updates when items were added \[ID_32042\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.2 -->

When new items were added in one client, in some cases, those items would not immediately appear in other clients. For example, when a user created a ticket for a particular domain, other users viewing the list of tickets for that same domain would not immediately have their ticket list updated.

#### Cassandra: Problem when a NULL value was encountered in a logger table during a database migration \[ID_32358\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.3 -->

When migrating a database to a Cassandra cluster, in some cases, an error could be thrown when a NULL value was encountered in a logger table.

#### Jobs app: No 'loading' indication when job sections were being loaded \[ID_32616\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.4 -->

When configuring jobs, no “loading” indication would appear when job sections were being loaded.

#### Web services API: Problem with GetServiceTemplate \[ID_32625\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.4 -->

The GetServiceTemplate method would throw an exception when requesting a service template with Text inputs that had neither of the following options:

- Require a valid element name
- Allow 'N/A' to indicate empty value

#### SLAnalytics: Inaccurate short-term trend predictions \[ID_32731\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.5 -->

If the DataMiner Agent uses a Cassandra database, trend graphs can show how the value of a parameter in the graph is most likely to evolve in the future. Up to now, in some cases, short-term trend predictions could be inaccurate due to a longer seasonality being detected on a higher level.

#### Alarms and information events not migrated during migration to Cassandra Cluster \[ID_32755\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.4 -->

When a DataMiner cluster with multiple DMAs was migrated to a Cassandra Cluster database, it could occur that the migration of alarms and information events failed because the DMAs tried to truncate the same table at the same time. Truncation will now take place in the initialization phase to prevent this problem, and if it fails, this will be logged but will not stop the migration. This will also prevent a rare problem where data could be missing after DMAs were migrated one by one.

#### SLAnalytics: Unneeded error was thrown when an upgrade action tried to remove the pattern match occurrences table from a non-existing Elasticsearch database \[ID_32772\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.4 -->

On systems without an Elasticsearch database, the following messages were thrown when an upgrade action tried to remove the pattern match occurrences table from the non-existing Elasticsearch database:

```txt
10.102.0.12|2022-03-03 09:33:57|information|Elastic was not detected in DB.xml. Will not remove obsolete Elastic indices.
10.102.0.12|2022-03-03 09:33:58|error|Couldn't remove Elastic indices. Cause: Object reference not set to an instance of an object.
```

From now on, when no Elasticsearch database can be found, only the above-mentioned information event will be thrown.

#### Elasticsearch: TTL settings would not be applied correctly \[ID_32913\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.6 -->

In some cases, TTL settings defined in an Elasticsearch database would not be applied correctly. As a result, certain data (e.g. profile instance data) would not get properly cleaned up.

#### Web Services API: Problem when opening the soap.asmx page \[ID_32939\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.5 -->

In some cases, an exception could be thrown when you tried to open the following page: `http://DmaNameOrIpAddress/API/v1/soap.asmx`

#### Dashboards app: Selection in parameter feed would incorrectly be cleared whenever the linked EPM feed was updated \[ID_33153\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.6 -->

When an EPM feed was linked to a parameter feed, in some cases, the current selection in the parameter feed would incorrectly be cleared whenever the EPM feed was updated.

#### SLPort would incorrectly split WebSocket messages larger than 65kB \[ID_33182\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.6 -->

Up to now, when SLPort received a WebSocket message larger than the WebSocket buffer (i.e. 65 kB), it would incorrectly split that message in multiple chunks before passing it to the protocol.

#### Alarm templates: Problem with anomaly detection alarms \[ID_33216\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.6 -->

When you created an element with an alarm template in which anomaly detection alarms were configured for table parameters, in some cases, none of the enabled types of change points would trigger an alarm.

#### CSLCloudBridge library would incorrectly not take into account the connection timeout specified in SLCloud.xml \[ID_33322\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.6 [CU0]  -->

Up to now, the CSLCloudBridge library would incorrectly not take into account the connection timeout specified in the SLCloud.xml file. In some cases, this could lead to run-time errors in the MessageBrokerReconnectThread.

The connection timeout specified in SLCloud.xml is the maximum time it can take to set up a connection with NATS (in milliseconds). Minimum value is 1000 ms, default value is 5000 ms.

```xml
<SLCloud>
  ...
  <ConnectTimeout>5000</ConnectTimeout>
  ...
</SLCloud>
```

#### ResourceManager module would fail to initialize on systems with a MySQL database \[ID_33327\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.6 -->

On systems with a MySQL database, the ResourceManager module would fail to initialize.

#### SLCloud.xml files would incorrectly refer to the local agent using the IP address instead of the hostname when the agents were configured to use HTTPS \[ID_33342\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

When, in a DataMiner System, agents were configured to use HTTPS, the SLCloud.xml files of each of those agent would incorrectly refer to the local agent using the IP address instead of the hostname.

#### Web apps: Only part of the value would be selected when moving the mouse pointer over a selection box that had the focus \[ID_33379\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

When you moved the mouse pointer over a selection box that had the focus, in some cases, only part of the value would be selected.

#### SLAnalytics: Problem when predicting the trend of a history set parameter \[ID_33389\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

Up to now, negative status values in the trend data due to element restarts could cause the trend prediction engine to incorrectly interpret the trend data of a history set parameter.

#### Dashboards app - GQI: Values of profile parameters without decimals defined would incorrectly be replaced by the maximum integer value \[ID_33418\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

When a profile parameter of type “number” had no decimals defined, its value would incorrectly be displayed as the maximum value that can be assigned to a parameter of type integer. From now on, when a profile parameter has no decimals defined, its value will be displayed as is, without decimals.

#### Ticketing app: Problem with ticket domains incorrectly marked as masked \[ID_33449\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

If, in the Ticketing app, you tried to edit a ticket of a domain linked to an element, in some cases, that domain would incorrectly be marked as “masked”.

#### Issues with NATS request/response actions \[ID_33487\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

A number of issues with NATS request/response actions have been solved.

#### Problem with SLDataGateway when updating parameters \[ID_33535\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

In some cases, an error could occur in SLDataGateway when updating parameters.

#### Ticketing app: Problem when trying to add a value to the State field of a ticket domain \[ID_33537\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 -->

When you tried to add a new value to the State field of a ticket domain, the following error would be thrown when the change was saved:

```txt
Error trapped: Unable to cast object of type 'Skyline.DataMiner.Web.Common.v1.DMATicketFieldPossibleValue' to type 'Skyline.DataMiner.Web.Common.v1.DMATicketStateFieldPossibleState'.
```

#### Dashboards app: Dashboard would incorrectly scroll up when you selected a field in an EPM feed \[ID_33650\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.8 -->

When, on a dashboard, an EPM feed was surrounded by other components, in some cases, the dashboard would incorrectly scroll up when you selected a field in the EPM feed.

#### Run-time errors due to MessageBrokerReconnectThread problems in SLCloudBridge \[ID_33716\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.8 [CU0] -->

In some cases, run-time errors could occur due to MessageBrokerReconnectThread problems in the SLCloudBridge process.

#### SLDataGateway: Communication via NATS could get stopped when a large number of parameter changes were being processed \[ID_33731\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.7 [CU0] -->

When a large number of parameter changes were being processed, up to now, communication entering or leaving SLDataGateway via NATS could get stopped.

#### Problem with SLAnalytics when an element or a parameter was deleted \[ID_33788\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

When an element or a parameter was deleted, in some rare cases, an error could occur in the SLAnalytics process.

#### SLAnalytics: Error messages could get added to the log file due to a problem with the automatic incident tracking algorithm \[ID_33820\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

Due to a problem with the automatic incident tracking algorithm, error messages similar to the following one could incorrectly get added to the SLAnalytics log file:

```txt
2022/06/08 23:54:36.684|SLAnalytics|Counter.h(61): containers::Counter<ServiceInfo>::decrease)|ERR|0|Decreasing counter for key that is not in the map
```

#### Problem with SLDataGateway while a DataMiner Agent was being shut down [ID_33839]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.8 [CU0] -->

When a DataMiner Agent was being shut down, in some cases, an error could occur in the SLDataGateway process.

#### DataMiner upgrade: VerifyNatsRunning prerequisite could fail due to SLCloudBridge.dll having been renamed [ID_33875]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.8 [CU0] -->

During a DataMiner upgrade, the VerifyNatsRunning prerequisite could fail due to the SLCloudBridge.dll file having been renamed to SLMessageBroker.dll in DataMiner versions 10.2.0/10.1.5.

#### Azure Active Directory: Domain users who were only a member of a domain group could be deleted during an LDAP synchronization \[ID_33916\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

When using Azure Active Directory as an identity provider, up to now, during an LDAP synchronization, all domain users who were only a member of a domain group would incorrectly be deleted when the Azure AD client secret had expired.

#### DataMiner Object Model: FieldValues would not get concatenated correctly \[ID_33989\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

When a name concatenation for a DomInstance had been defined in either the ModuleSettings or the DomDefinition, in some cases, the FieldValues would not get concatenated correctly.

#### Elasticsearch: Closed alarms were incorrectly not migrated to the dms-alarms index when the associated element had been migrated from another DMS \[ID_34020\]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

When, on a system with an Elasticsearch database, an alarm was closed, that alarm would incorrectly not get moved from the dms-Activealarms index to the dms-alarms index when the associated element had been migrated from another DMS.

#### DOM: FieldAlias properties not saved to database [ID_34054]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

In some cases, it could occur that properties of a FieldAlias DOM object could not be saved to the database.

#### DataMiner upgrade: AnalyticsDropUnusedCassandraTables upgrade action would fail [ID_34091]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

During a DataMiner upgrade, in some cases, the *AnalyticsDropUnusedCassandraTables* upgrade action would fail.

#### Dashboards app / Low-code apps: Changes to the feed could incorrectly influence the time window of a state timeline component [ID_34148]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.10 -->

In some cases, changes to the feed linked to a state timeline component could reset the time window. From now on, linking a query filter to the timeline will no longer influence the time window. The filter will be applied and the current time window will be preserved.

Also, because of a number of enhancements, overall performance has increased when linking a query filter to a state timeline component.

#### SLScripting instances mismatched with SLProtocol instances [ID_34167]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

When the *ProcessOptions* tag in *DataMiner.xml* was configured with the attribute *protocolProcesses* set to "protocol" and the attribute *scriptingProcesses* set to "protocol" or to a number larger than one, it could occur that elements ran their QActions in the wrong SLScripting instance, which could cause compilation or load balancing issues.

This issue will now be prevented. In addition, the element's instance GUID will now be added to the element log file for easier investigations.

#### SLAnalytics RTEs after upgrading DMS with Cassandra Cluster \[ID_34180]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.8 CU2 -->

After a DMS with a Cassandra Cluster setup was upgraded to 10.2.8 (CU1), it could occur that the Alarm Console showed run-time errors related to the SLAnalytics process. This was caused by an upgrade action that was not triggered for such a setup.

#### Dashboards app / Low-code apps: Column filters in generic filter component incorrectly marked as incapable [ID_34273]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.10 -->

In the generic filter component, in some cases, column filters would be incorrectly marked as incapable when the filter assistance option was enabled.

#### Dashboards app / Low-code apps: Query column filters would not be applied correctly to table components [ID_34305]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.10 -->

when a dashboard, a low-code app page or low-code app panel was initialized, in some cases, query column filters would not be applied correctly to table components on that dashboard, page or panel.
