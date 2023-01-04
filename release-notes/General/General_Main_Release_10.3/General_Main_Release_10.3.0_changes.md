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

#### Security enhancements [ID_31045] [ID_31054] [ID_31761] [ID_32055] [ID_32566] [ID_33069] [ID_33078] [ID_33218] [ID_33365] [ID_33583] [ID_34723]

A number of security enhancements have been made.

#### Function.xml files can now contain functions without entry points and maxInstance set to 1 [ID_31480]

<!-- MR 10.3.0 - FR 10.2.1 -->

In a functions.xml file, it is now possible to define functions without entry points and maxInstance set to 1. When all criteria are met, then a function of this type will affect all tables and column parameters defined for that particular function.

> [!NOTE]
> When you defined a function without entry points and maxInstance set to 1, \[Generic Linker Table\] entries will not be taken into account. This function will still affect all table and column parameters defined for it.

#### Filtering alarms on alarm focus: Enhanced performance [ID_31484]

<!-- MR 10.3.0 - FR 10.2.2 -->

Due to a number of enhancements, especially with regard to caching, overall performance has increased when filtering alarms on alarm focus.

#### Enhanced performance when reading data from a MySQL or SQLServer database [ID_31532]

<!-- MR 10.3.0 - FR 10.2.1 -->

Due to a number of enhancements, on systems with a MySQL or SQLServer database, overall performance has increased when reading data from the database, especially when reading trend data during the migration to another type of database.

#### Enhanced performance when reading trend data from a MySQL or SQLServer database page by page [ID_31535]

<!-- MR 10.3.0 - FR 10.2.1 -->

Due to a number of enhancements, on systems with a MySQL or SQLServer database, overall performance has increased when reading trend data from the database page by page.

#### Trending: Pattern matching enhancements [ID_31668]

<!-- MR 10.3.0 - FR 10.2.2 -->

From DataMiner 10.0.7 onwards, on systems using a Cassandra and an Elasticsearch database, DataMiner Analytics can automatically recognize recurring patterns in trend data.

A number of enhancements have now been made to this pattern matching mechanism. Also, from now on, all occurrences of recognized trend data patterns will be stored in the Elasticsearch database.

#### Alarm templates: Enhanced performance when adding alarm templates with smart baselines [ID_31670]

<!-- MR 10.3.0 - FR (REVERTED) 10.2.3 [CU0] -->

Due to a number of enhancements, overall performance has increased when adding alarm templates with smart baselines.

#### Cassandra will no longer store ArrowWindowRecords and PatternMatchOccurrenceRecords [ID_31944]

<!-- MR 10.3.0 - FR 10.2.4 -->

Cassandra databases will no longer store the following data:

- ArrowWindowRecords
- PatternMatchOccurrenceRecords

The latter will now be stored in Elasticsearch instead.

#### Behavioral anomaly detection: Change point flood notice will now be cleared sooner [ID_32013]

<!-- MR 10.3.0 - FR 10.2.3 -->

From now on, the notice created when the rate of newly detected behavioral changes reaches an upper limit will be cleared sooner. It will now be cleared when the rate has dropped under the limit again and there is no new flood situation in the following 15 minutes. Up to now, the notice would not be cleared for at least 2 hours, even when the actual flood situation had only lasted for a few seconds.

The notice will contain the following message:

```txt
Detection of behavioral anomalies temporarily disabled on DMA ...: maximum allowed rate of behavioral change points reached.
```

#### SLAnalytics - Alarm focus: Enhanced performance [ID_32270]

<!-- MR 10.3.0 - FR 10.2.3 -->

From DataMiner 10.0.0/10.0.2 onwards, the DataMiner Analytics software assigns an estimated likelihood or “alarm focus score” to each alarm, after analyzing the short-term history and current behavior of incoming alarms in real time. Due to a number of enhancements, overall performance of this alarm focus feature has increased.

#### Analytics: Prefetching mechanism for trend icons [ID_32300]

<!-- MR 10.3.0 - FR 10.2.4
Reverted in 10.2.4 -->

During the first few minutes that DataMiner Analytics is running, it is still calculating which trend icons should be displayed. Previously, during this initial period, the trend icons to be displayed were retrieved from the Cassandra database. However, because of changes to the database, this is no longer possible. For this reason, a prefetching mechanism has now been implemented, so that when a trend icon is requested, it is calculated based on prefetched trend data. As there are safeguards in place to ensure that not too many database requests are done at the same time, this does mean that not all trend icons may be displayed immediately.

#### SLAnalytics: A notice event will no longer be generated when entering change point flood mode [ID_32402]

<!-- MR 10.3.0 - FR 10.2.3 -->

Up to now, a notice event would be generated whenever SLAnalytics had entered change point flood mode. From now on, this event will no longer be generated.

> [!NOTE]
> As before, an entry will be added to the SLAnalytics log whenever behavioral anomaly detection has temporarily been disabled because change point flood mode was activated.

#### SLAnalytics: Enhanced accuracy of proactive cap detection [ID_32591]

<!-- MR 10.3.0 - FR 10.2.8 -->

Because of a number of enhancements, proactive cap detection accuracy has been increased.

#### SLMessageBroker: Default connection timeout is now 10 minutes [ID_32884]

<!-- MR 10.3.0 - FR 10.2.5 -->

The Connect() and Publish() methods of SLMessageBroker now have a default connection timeout of 10 minutes.

Also, the interval at which another reconnect is attempted has been increased from 1 second to 10 seconds.

#### Enhancements with regard to Automation scripts [ID_33129] [ID_33226]

<!-- MR 10.3.0 - FR 10.2.6 -->

A number of enhancements have been made with regard to Automation scripts.

- When a script is launched, from now on, only the parameters/dummies with missing values will be shown. Automatically filled in values will no longer be shown.
- When script input is filled in with feed data, users will no longer be asked to change that input manually.
- Script input (parameters/dummies) linked to a feed is now filled in at the moment a script action is triggered. Subsequent changes in the feed will have no effect.
- In the DataMiner Low-Code Apps, the option to mark specific script parameters and dummies as required has been removed.
- When, in the Dashboards app, users mark a script parameter as required, they no longer need to fill in a value.
- From now on, a page load event will only trigger after the application page has been fully initialized. This will ensure that, when launching script actions with input linked to feeds, those feeds have been initialized.

#### Service & Resource Management: Enhanced logging [ID_33183]

<!-- MR 10.3.0 - FR 10.2.6 -->

Up to now, when the SRM log files were set to “No logging”, no information would be logged if e.g. a Reservation event had failed. All ResourceManager, ResourceManagerAutomation and FunctionManager logging has now been re-evaluated, and the log settings have been optimized. All critical issues occurring in those modules will now be logged.

#### Profile instance list for PA service definition node now also contains child instances [ID_33187]

<!-- MR 10.3.0 - FR 10.2.6
See also: DMS Cube - Fix was moved to 10.2.0 CU3 by RN 33188 -->

When you configure a service definition node in the Services app, a list of profile instances is shown for the selected profile definition. For service definitions of type "Skyline Process Automation" and "Custom Process Automation", this list will now also contain instances for child definitions of the configured profile definition.

#### Anomaly detection: Enhanced performance when generating suggestion events and alarms [ID_33283]

<!-- MR 10.3.0 - FR 10.2.6 -->

Because of a number of enhancements, overall performance has increased when generating anomaly detection suggestion events and alarms.

#### DataMiner upgrade will not be performed if NATS is not installed and running [ID_33304]

<!-- MR 10.3.0 - FR 10.2.7 -->

When you launch a DataMiner upgrade, from now on, the upgrade process will not be allowed to start if NATS is not installed and running.

> [!NOTE]
> This check will be skipped if the current DataMiner version is older than version 10.1.0.

#### SLDMS will now use less memory when storing service information [ID_33318]

<!-- MR 10.3.0 - FR 10.2.7 -->

Because of a number of enhancements, the SLDMS process will now use less memory when storing service information.

#### QADeviceSimulator: Enhanced CPU usage when running SNMPv3 simulations [ID_33376]

<!-- MR 10.3.0 - FR 10.2.7 -->

Because of a number of enhancements, overall CPU usage of the QADeviceSimulator has improved when running SNMPv3 simulations.

#### Service & Resource Management: Function resources will no longer be deleted when their parent DVE element cannot be reached [ID_33415] [ID_33668]

<!-- MR 10.3.0 - FR 10.2.7 -->

From now on, the deletion of a function resource will be blocked when the deletion of its parent DVE element fails.

The ResourceManagerHelper now contains a new method to delete resources:

`public Resource[] RemoveResources(Resource[] resources, ResourceDeleteOptions options)`

> [!NOTE]
> Contributing resources can be deleted even when no parent element can be found. The parent element of a contributing resource is an enhanced service element. When the contributing booking is no longer running, the enhanced service element will no longer exist.

#### SLAnalytics: Enhanced performance when retrieving parameter information [ID_33458]

<!-- MR 10.3.0 - FR 10.2.7 -->

Because of a number of enhancements, overall performance has increased when retrieving parameter information.

#### Web apps: Enhancements with regard to the rendering of GQI tables [ID_33463]

<!-- MR 10.3.0 - FR 10.2.7 -->

A number of enhancements have been made with regard to the rendering of GQI tables.

#### Alarm templates: All behavioral change points will now be considered anomalous [ID_33476]

<!-- MR 10.3.0 - FR 10.2.7 -->

From DataMiner 10.0.3 onwards, you can enable alarm monitoring on specific types of anomalies for parameters in an alarm template. Up to now, when you enabled this, an alarm was generated whenever the SLAnalytics engine considered a behavioral change point anomalous. From now on, all behavior change points will be considered anomalous and will hence trigger an alarm.

#### QADeviceSimulator: Enhanced performance when loading a MySQL database at the start of a MySQL database simulation [ID_33555]

<!-- MR 10.3.0 - FR 10.2.7 -->

Because of a number of enhancements, overall performance of the QADeviceSimulator has improved when loading a MySQL database at the start of a MySQL database simulation.

Also, the overall memory footprint of MySQL database simulations has been reduced.

#### Service & Resource Management: A booking will now be set to 'interrupted' when whatever event related to that booking could not be executed [ID_33576]

<!-- MR 10.3.0 - FR 10.2.8 -->

Up to now, when DataMiner was unavailable when a booking was supposed to start or stop, its state was set to “interrupted” when DataMiner started up again.

This functionality has now been extended. A booking will now also be set to “interrupted” when whatever event related to that booking could not be executed.

#### Frequency of smart baseline calculations is now configurable [ID_33584]

<!-- MR 10.3.0 - FR 10.2.7 -->

It is now possible to change the frequency of smart baseline calculations. On systems that aggregate large amounts of data from parameters with smart baselines, it is recommended to increase this frequency, which is 5 minutes by default.

To change this setting, do the following:

1. Open the SLNetClientTest tool.
1. Go to *Advanced \> Options \> SLNet Options*.
1. Select the *SmartBaselineThreadTime* option and change its value.

Minimum value: 1 minute - Default value: 5 minutes

> [!WARNING]
> Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### External authentication using SAML: Extended logging [ID_33622]

<!-- MR 10.3.0 - FR 10.2.10 -->

When authenticating users using SAML, the following additional debug information will now be logged in the *SLSaml.txt* file:

- Whether Just-In-Time provisioning (JIT) is enabled.
- Which group claims are being used.

#### Dashboards app / Low-Code Apps: Support for feed categories in components [ID_33719]

<!-- MR 10.3.0 - FR 10.2.9 -->

Up to now, components could only produce one feed for each data type. Now support has been added for different categories within a data type, so that components will be able to produce several feeds for the same data type. This will for example make it possible for a component to produce a query row feed with the categories "timeline item" and "timeline band".

#### Skyline Device Simulator: Enhanced performance [ID_33761]

<!-- MR 10.3.0 - FR 10.2.9 -->

Because of a number of enhancements, overall performance of the Skyline Device Simulator tool has improved.

#### Maximum for element timeout setting increased to 24 hours [ID_33862] [ID_33951]

<!-- MR 10.3.0 - FR 10.2.9 -->

The maximum value for the element setting "*The element goes into timeout state when it is not responding for (sec)*" has now been increased from 120 seconds to 24 hours (i.e. 86400 seconds).

#### DataMiner Analytics: Improved handling of clearable alarms [ID_33910]

<!-- MR 10.3.0 - FR 10.2.9 -->

Up to now, DataMiner Analytics handled clearable alarms with severity "Normal" in the same way as cleared alarms. This meant that these were automatically removed from alarm groups (also known as incidents).

From now on, clearable alarms will keep the alarm focus from the last alarm in the alarm tree that had a non-normal severity. They will also stay in the same alarm group they were in before their severity became "Normal".

#### Service & Resource Management: Enhancements made to ResourceManagerHelper [ID_33993]

<!-- MR 10.3.0 - FR 10.2.9 -->

A number of enhancements have been made to the ResourceManagerHelper class.

For example, from now on, an ArgumentNullException will be thrown when a NULL argument is provided. Also, when a collection with one or more NULL objects is provided, those objects will be ignored.

#### GQI: Improved performance of column filter [ID_34014]

<!-- MR 10.3.0 - FR 10.2.9 -->

Instead of a client-side filter, a more efficient server-side filter is now used to filter columns of a table component showing GQI data in a dashboard or low-code app. This will greatly improve the filter performance. However, because this server-side filter does not support "OR" filters, it will no longer be possible to combine multiple conditions within the same filter.

#### Dashboards / Low-Code Apps: Table filter improvements [ID_34022]

<!-- MR 10.3.0 - FR 10.2.9 -->

If you used the search box below a table displaying GQI data to filter this data, up to now, this could cause a serious load on the server in case a large number of rows had to be retrieved. To prevent this, the following conditions will now be applied to determine if more data should be retrieved:

- If the table already has enough rows to fill the next page, no further data will be retrieved.
- If the condition above is not met, at least 250 rows will retrieved initially.
- If at least one record is found that matches the search filter, no more rows will be retrieved. You will then need to click a "Load more" button to retrieve more data.
- If 2000 additional records have been retrieved after you click "Load more", no more data will be retrieved until you click the button again.
- If you scroll through the results, additional data will be fetched until there are enough rows to fill the next page.

#### Improved SPI logging for Automation [ID_34025]

<!-- MR 10.3.0 - FR 10.2.9 -->

The log levels of some of the log lines related to SPIs in the *SLAutomation* log file have been changed, so that the log file does not get flooded with potentially irrelevant data. In addition, these log lines will now contain the SPI node ID and definition ID. The log line mentioning the SPI definition ID when this definition is created will no longer be added.

#### Dashboards app / Low-Code Apps: No more statistics and suggestions for conditional coloring of Table and Node edge component [ID_34037]

<!-- MR 10.3.0 - FR 10.2.9 -->
<!-- Part of this RN is still in soft launch and consequently has not been documented yet -->

To improve performance, in the *Layout* pane for a Table or Node edge component, no more statistics and suggestions will be shown for conditional coloring.

#### SLLogCollector now also collects SLAnalytics configuration files [ID_34106]

<!-- MR 10.3.0 - FR 10.2.10 -->

Several SLAnalytics configuration files will now also be collected by the SLLogCollector tool. These will be placed in the *Logs/Skyline DataMiner/Analytics* and *Logs/Skyline DataMiner/Configuration* folders of the archive created by SLLogCollector.

#### GQI: Initial support for nested tables [ID_34144]

<!-- MR 10.3.0 - FR 10.2.9 -->

Initial support has been added for GQI results with cells containing nested records. However, at present this is only used for the *Resources* data source, which still requires the *GenericInterface* [soft-launch option](xref:SoftLaunchOptions).

The following functionality is now available for nested tables:

- Checking the number of records in nested tables. If a column with nested tables is retrieved, you cannot inspect the nested tables themselves yet, but a display value will show the number of records they contain.
- Aggregation on a single nested table column. There is no support for grouping yet. The aggregated value of the nested cell will be shown in the parent record as an ordinary cell.
- Filtering of nested tables.
- Selecting columns from nested tables. These will be shown in the same list box as regular columns, but their name will be prefixed by the parent column name. For example, if the parent column is named "Capabilities" and the nested table column is named "Name", the column will be listed as "Capabilities.Name".

#### Dashboards app / Low-Code Apps: Conditional coloring layout configuration now uses numeric filter instead of numeric slider [ID_34174]

<!-- MR 10.3.0 - FR 10.2.10 -->
<!-- Part of this RN is still in soft launch and consequently has not been documented yet -->

In the conditional coloring layout setting for Table and Node edge components, the numeric slider control has been replaced with a numeric filter. This has the following advantages:

- Full control over the boundaries. You can indicate whether the start and end should be in- or excluded.
- Possibility to not have a start or end boundary.
- More consistent with the free text filter.
- Easier to define a precise filter.

#### Dashboards app / Low-Code Apps: Conditional coloring layout filter configuration now shows discrete column values [ID_34182]

<!-- MR 10.3.0 - FR 10.2.10 -->
<!-- Part of this RN is still in soft launch and consequently has not been documented yet -->

In the conditional coloring layout setting for Table and Node edge components, discrete column values will now be displayed to make it easier to configure a filter.

#### GQI table column names will no longer include table names [ID_34302]

<!-- MR 10.3.0 - FR 10.2.10 -->

When a GQI table column inherits its name from a parameter of which the name includes the table name (between brackets), that table name will now be trimmed from the column name.

#### Improved performance of Resources module [ID_34205]

<!-- MR 10.3.0 - FR 10.2.10 -->

Because of enhancements to the way resources are processed and stored, the Resources module will now initialize more quickly.

In addition, performance has improved when a resource or resource pool is added or updated.

#### GQI: Enhanced performance of the ProfileInstance data source [ID_34320]

<!-- MR 10.3.0 - FR 10.2.11 -->

Because of a number of enhancements, overall performance has increased when running a GQI query using the ProfileInstance data source.

#### SLNet / SLDataGateway: Enhanced algorithm to find the first valid physical address of the DataMiner Agent [ID_34360]

<!-- MR 10.3.0 - FR 10.2.11 -->

A number of enhancements have been made to the algorithm used by SLNet and SLDataGateway to find the first valid physical address of the DataMiner Agent.

#### GQI: Enhanced performance when retrieving table data [ID_34441]

<!-- MR 10.3.0 - FR 10.2.12 -->

Because of a number of enhancements, overall performance has increased when retrieving table data by means of a GQI query.

#### Dashboards app - Line & area chart: Non-trended parameters will now automatically be removed when the component is linked to a parameter feed [ID_34499]

<!-- MR 10.3.0 - FR 10.2.12 -->

When a parameter feed is linked to a *Line & area chart" component, from now on, non-trended parameters will now automatically be removed from the chart.

#### Dashboards app - Parameter feed: 'Auto-select all' setting no longer available when using an EPM identifier feed as source [ID_34501]

<!-- MR 10.3.0 - FR 10.2.11 -->

When a parameter feed has an EPM identifier feed as source, from now on, the *Auto-select all* setting will no longer be available.

#### Dashboards app / Low-code apps - Line & area chart: Group label will no longer be displayed when grouping is set to 'All together' [ID_34544]

<!-- MR 10.3.0 - FR 10.2.12 -->

In case a *Line & area chart* component displays trending for multiple parameters, the *Group by* setting allows you to specify how the graphs should be grouped. From now on, group titles will no longer be displayed when you set *Group by* to "All together".

#### SLElement: Enhanced alarm locking [ID_34561]

<!-- MR 10.3.0 - FR 10.2.12 -->

Alarm locking in the SLElement process has been enhanced.

#### Dashboards app / Low-code apps: Enhanced performance of selection boxes [ID_34577]

<!-- MR 10.3.0 - FR 10.2.12 -->

Because of a number of enhancements, overall performance has increased when opening selection boxes, especially when they contain a large number of items.

#### Dashboards app: Upload size of PDF files will now be validated [ID_34620]

<!-- MR 10.3.0 - FR 10.2.12 -->

When PDF files are uploaded via the WebAPI (e.g. when a PDF report is generated), an error will now be thrown when the batch size exceeds 10 MB or the total file size exceeds 1 GB.

#### Behavioral change points stored in both Cassandra and Elasticsearch [ID_34621]

<!-- MR 10.3.0 - FR 10.2.12 -->

If an Elasticsearch database is available, the behavioral change points detected in trend data by the Behavioral Anomaly Detection feature will now be stored both in the Cassandra database and the Elasticsearch database. Otherwise, they will be stored in Cassandra only like before.

This will support faster and more flexible change point querying via GQI in future releases.

#### Dashboards app / Low-code apps - Visual Overview component: Enhancements with regard to WebSocket/polling settings and user access to visual overviews [ID_34624]

<!-- MR 10.3.0 - FR 10.2.12 -->

A number of enhancements have been made to the visual overview component, especially with regard to the WebSocket/polling settings and the algorithm that checks whether users have access to the visual overviews retrieved by the component.

#### Enhanced parameter locking in SLElement [ID_34688]

<!-- MR 10.3.0 - FR 10.3.1 [CU0] -->

In SLElement, a number of enhancements have been made with regard to parameter locking.

#### Service & Resource Management: GetResources methods not using filter elements have now been marked as obsolete [ID_34720]

<!-- MR 10.3.0 - FR 10.2.12 -->

In *ResourceManagerHelper* and *IResourceManagerHelper*, the following methods not using filter elements have now been marked as obsolete:

```csharp
IEnumerable<Resource> GetResources(IEnumerable<Resource> filters);
Resource[] GetResources(params Resource[] filters);
```

The following method should now be used instead:

```csharp
Resource[] GetResources(FilterElement<Resource> filter);
```

For example, you can now use the following call to retrieve all resources:

```csharp
var allResources = resourceManagerHelper.GetResources(new TRUEFilterElement<Resource>());
```

#### GQI: Enhanced performance when retrieving DomInstances that have a DomBehaviorDefinition [ID_34853]

<!-- MR 10.3.0 - FR 10.3.1 -->

Because of a number of enhancements, overall performance has increased when retrieving DomInstances that have a DomBehaviorDefinition.

#### SLAnalytics: Enhanced automatic evaluation of trend predictions [ID_34901]

<!-- MR 10.3.0 - FR 10.3.1 -->

Because of a number of enhancements, the automatic evaluation of trend predictions has improved.

#### Service & Resource Management: Enhanced performance when adding and updating bookings [ID_35016]

<!-- MR 10.3.0 - FR 10.3.2 -->

Because of a number of enhancements, overall performance has increased when creating and updating bookings.

#### SLAnalytics: Enhanced processing of parameter values 'exception' and 'other' [ID_35214]

<!-- MR 10.3.0 - FR 10.3.2 -->

Because of a number of enhancements, overall processing of "exception" or "other" parameter values by the SLAnalytics process has improved.

### Fixes

#### SLAnalytics: Problem with trend prediction [ID_31352]

<!-- MR 10.3.0 - FR 10.2.1 -->

In some rare cases, an error could occur in SLAnalytics when calculating trend predictions.

#### Proactive cap detection: Problem with frequency of trend prediction calculations [ID_31447]

<!-- MR 10.3.0 - FR 10.2.2 -->

The “proactive cap detection” feature predicts future issues based on trend data in the Cassandra database, using advanced techniques that consider repeating patterns, information on the rate at which a parameter value increases or decreases, etc.

Up to now, in some cases, the frequency with which trend predictions were calculated would either be too low or too high.

#### Alarm templates: Incorrect calculation of smart baselines [ID_31601]

<!-- MR 10.3.0 - FR 10.2.6 -->

In some cases, smart baselines would be calculated incorrectly, especially when the “Skip the last X hours in the configured trend window” and “Handle weekend days separately” options were enabled.

#### Factory reset tool SLReset.exe did not remove a number of .lic files [ID_31722]

<!-- MR 10.3.0 - FR 10.2.1 -->

The factory reset tool `C:\Skyline DataMiner\Files\SLReset.exe` can be used to fully reset a DataMiner Agent to its state immediately after installation.

When run, it will now also remove the following files:

- ClientApps.lic
- request.lic (will be recreated after a DataMiner restart)
- chartDir.lic

#### Dashboards app: Dashboard names would incorrectly be allowed to contain backslash characters [ID_31735]

<!-- MR 10.3.0 - FR 10.2.1 -->

Up to now, it would incorrectly be allowed to enter a name containing backslash characters when creating or renaming a dashboard. From now on, this will no longer be allowed.

#### Service & Resource Management: Retrieving ReservationInstances sorted by a property of type string would return an incorrectly sorted result set [ID_32003]

<!-- MR 10.3.0 - FR 10.2.3 -->

When a list of ReservationInstances were retrieved sorted by a property of type string, that list would be returned in an incorrect sort order.

#### Mobile apps: Clients would not immediately receive updates when items were added [ID_32042]

<!-- MR 10.3.0 - FR 10.2.2 -->

When new items were added in one client, in some cases, those items would not immediately appear in other clients. For example, when a user created a ticket for a particular domain, other users viewing the list of tickets for that same domain would not immediately have their ticket list updated.

#### Cassandra: Problem when a NULL value was encountered in a logger table during a database migration [ID_32358]

<!-- MR 10.3.0 - FR 10.2.3 -->

When migrating a database to a Cassandra cluster, in some cases, an error could be thrown when a NULL value was encountered in a logger table.

#### Jobs app: No 'loading' indication when job sections were being loaded [ID_32616]

<!-- MR 10.3.0 - FR 10.2.4 -->

When configuring jobs, no “loading” indication would appear when job sections were being loaded.

#### Web services API: Problem with GetServiceTemplate [ID_32625]

<!-- MR 10.3.0 - FR 10.2.4 -->

The GetServiceTemplate method would throw an exception when requesting a service template with Text inputs that had neither of the following options:

- Require a valid element name
- Allow 'N/A' to indicate empty value

#### SLAnalytics: Inaccurate short-term trend predictions [ID_32731]

<!-- MR 10.3.0 - FR 10.2.5 -->

If the DataMiner Agent uses a Cassandra database, trend graphs can show how the value of a parameter in the graph is most likely to evolve in the future. Up to now, in some cases, short-term trend predictions could be inaccurate due to a longer seasonality being detected on a higher level.

#### Alarms and information events not migrated during migration to Cassandra Cluster [ID_32755]

<!-- MR 10.3.0 - FR 10.2.4 -->

When a DataMiner cluster with multiple DMAs was migrated to a Cassandra Cluster database, it could occur that the migration of alarms and information events failed because the DMAs tried to truncate the same table at the same time. Truncation will now take place in the initialization phase to prevent this problem, and if it fails, this will be logged but will not stop the migration. This will also prevent a rare problem where data could be missing after DMAs were migrated one by one.

#### SLAnalytics: Unneeded error was thrown when an upgrade action tried to remove the pattern match occurrences table from a non-existing Elasticsearch database [ID_32772]

<!-- MR 10.3.0 - FR 10.2.4 -->

On systems without an Elasticsearch database, the following messages were thrown when an upgrade action tried to remove the pattern match occurrences table from the non-existing Elasticsearch database:

```txt
10.102.0.12|2022-03-03 09:33:57|information|Elastic was not detected in DB.xml. Will not remove obsolete Elastic indices.
10.102.0.12|2022-03-03 09:33:58|error|Couldn't remove Elastic indices. Cause: Object reference not set to an instance of an object.
```

From now on, when no Elasticsearch database can be found, only the above-mentioned information event will be thrown.

#### SLAnalytics - Pattern matching: Disabling the monitoring of a pattern would not be applied immediately [ID_32792]

<!-- MR 10.3.0 - FR 10.2.4 -->

When you disabled the monitoring of a pattern that had monitoring enabled, the update would incorrectly only be applied after restarting either SLAnalytics or the DataMiner software.

#### MessageBroker: Timeout value would incorrectly be ignored when using RequestResponse(Async) [ID_32810]

<!-- MR 10.3.0 - FR 10.2.5 -->

When, in the MessageBroker, RequestResponse(Async) was used when NATS was not yet connected, the specified timeout value would incorrectly be ignored. The timeout value would only be applied to the actual NATS communication and not to the potential reconnection logic.

#### Elasticsearch: TTL settings would not be applied correctly [ID_32913]

<!-- MR 10.3.0 - FR 10.2.6 -->

In some cases, TTL settings defined in an Elasticsearch database would not be applied correctly. As a result, certain data (e.g. profile instance data) would not get properly cleaned up.

#### Web Services API: Problem when opening the soap.asmx page [ID_32939]

<!-- MR 10.3.0 - FR 10.2.5 -->

In some cases, an exception could be thrown when you tried to open the following page: `http://DmaNameOrIpAddress/API/v1/soap.asmx`

#### Dashboards app: Selection in parameter feed would incorrectly be cleared whenever the linked EPM feed was updated [ID_33153]

<!-- MR 10.3.0 - FR 10.2.6 -->

When an EPM feed was linked to a parameter feed, in some cases, the current selection in the parameter feed would incorrectly be cleared whenever the EPM feed was updated.

#### SLPort would incorrectly split WebSocket messages larger than 65kB [ID_33182]

<!-- MR 10.3.0 - FR 10.2.6 -->

Up to now, when SLPort received a WebSocket message larger than the WebSocket buffer (i.e. 65 kB), it would incorrectly split that message in multiple chunks before passing it to the protocol.

#### Alarm templates: Problem with anomaly detection alarms [ID_33216]

<!-- MR 10.3.0 - FR 10.2.6 -->

When you created an element with an alarm template in which anomaly detection alarms were configured for table parameters, in some cases, none of the enabled types of change points would trigger an alarm.

#### SLAnalytics - Automatic incident tracking: Incorrect error message would be generated [ID_33305]

<!-- MR 10.3.0 - FR 10.2.7 -->

In some cases, the following incorrect error message would be generated:

```txt
Ignoring alarm group update: unknown alarm group tree.
```

#### CSLCloudBridge library would incorrectly not take into account the connection timeout specified in SLCloud.xml [ID_33322]

<!-- MR 10.3.0 - FR 10.2.6 [CU0]  -->

Up to now, the CSLCloudBridge library would incorrectly not take into account the connection timeout specified in the SLCloud.xml file. In some cases, this could lead to run-time errors in the MessageBrokerReconnectThread.

The connection timeout specified in SLCloud.xml is the maximum time it can take to set up a connection with NATS (in milliseconds). Minimum value is 1000 ms, default value is 5000 ms.

```xml
<SLCloud>
  ...
  <ConnectTimeout>5000</ConnectTimeout>
  ...
</SLCloud>
```

#### ResourceManager module would fail to initialize on systems with a MySQL database [ID_33327]

<!-- MR 10.3.0 - FR 10.2.6 -->

On systems with a MySQL database, the ResourceManager module would fail to initialize.

#### SLCloud.xml files would incorrectly refer to the local agent using the IP address instead of the hostname when the agents were configured to use HTTPS [ID_33342]

<!-- MR 10.3.0 - FR 10.2.7 -->

When, in a DataMiner System, agents were configured to use HTTPS, the SLCloud.xml files of each of those agent would incorrectly refer to the local agent using the IP address instead of the hostname.

#### SLAnalytics: The automatic incident tracking feature would incorrectly not be disabled when the alarm focus feature was disabled [ID_33348]

<!-- MR 10.3.0 - FR 10.2.7 -->

When the alarm focus feature was disabled, up to now, the automatic incident tracking feature would not automatically be disabled as well. From now on, when the alarm focus feature is disabled, the automatic incident tracking feature will also be disabled.

#### Web apps: Only part of the value would be selected when moving the mouse pointer over a selection box that had the focus [ID_33379]

<!-- MR 10.3.0 - FR 10.2.7 -->

When you moved the mouse pointer over a selection box that had the focus, in some cases, only part of the value would be selected.

#### SLAnalytics: Problem when predicting the trend of a history set parameter [ID_33389]

<!-- MR 10.3.0 - FR 10.2.7 -->

Up to now, negative status values in the trend data due to element restarts could cause the trend prediction engine to incorrectly interpret the trend data of a history set parameter.

#### Dashboards app - GQI: Values of profile parameters without decimals defined would incorrectly be replaced by the maximum integer value [ID_33418]

<!-- MR 10.3.0 - FR 10.2.7 -->

When a profile parameter of type “number” had no decimals defined, its value would incorrectly be displayed as the maximum value that can be assigned to a parameter of type integer. From now on, when a profile parameter has no decimals defined, its value will be displayed as is, without decimals.

#### Issues with NATS request/response actions [ID_33487]

<!-- MR 10.3.0 - FR 10.2.7 -->

A number of issues with NATS request/response actions have been solved.

#### Problem with SLDataGateway when updating parameters [ID_33535]

<!-- MR 10.3.0 - FR 10.2.7 -->

In some cases, an error could occur in SLDataGateway when updating parameters.

#### Ticketing app: Problem when trying to add a value to the State field of a ticket domain [ID_33537]

<!-- MR 10.3.0 - FR 10.2.7 -->

When you tried to add a new value to the State field of a ticket domain, the following error would be thrown when the change was saved:

```txt
Error trapped: Unable to cast object of type 'Skyline.DataMiner.Web.Common.v1.DMATicketFieldPossibleValue' to type 'Skyline.DataMiner.Web.Common.v1.DMATicketStateFieldPossibleState'.
```

#### Dashboards app: Dashboard would incorrectly scroll up when you selected a field in an EPM feed [ID_33650]

<!-- MR 10.3.0 - FR 10.2.8 -->

When, on a dashboard, an EPM feed was surrounded by other components, in some cases, the dashboard would incorrectly scroll up when you selected a field in the EPM feed.

#### Failover: Offline agent would fail to come online when the NATS cluster was down during a Failover switch [ID_33681]

<!-- MR 10.3.0 - FR 10.2.11 -->

When, during a Failover switch, the NATS cluster was down, the offline agent would fail to come online.

#### GQI - Elasticsearch: Aggregated data did not have the number of decimals specified in the parameter info [ID_33712]

<!-- MR 10.3.0 - FR 10.2.11 -->

Aggregated data retrieved from an Elasticsearch database did not have the number of decimals specified in the parameter info.

#### Run-time errors due to MessageBrokerReconnectThread problems in SLCloudBridge [ID_33716]

<!-- MR 10.3.0 - FR 10.2.8 [CU0] -->

In some cases, run-time errors could occur due to MessageBrokerReconnectThread problems in the SLCloudBridge process.

#### SLDataGateway: Communication via NATS could get stopped when a large number of parameter changes were being processed [ID_33731]

<!-- MR 10.3.0 - FR 10.2.7 [CU0] -->

When a large number of parameter changes were being processed, up to now, communication entering or leaving SLDataGateway via NATS could get stopped.

#### Problem with SLAnalytics when an element or a parameter was deleted [ID_33788]

<!-- MR 10.3.0 - FR 10.2.9 -->

When an element or a parameter was deleted, in some rare cases, an error could occur in the SLAnalytics process.

#### SLAnalytics: Error messages could get added to the log file due to a problem with the automatic incident tracking algorithm [ID_33820]

<!-- MR 10.3.0 - FR 10.2.9 -->

Due to a problem with the automatic incident tracking algorithm, error messages similar to the following one could incorrectly get added to the SLAnalytics log file:

```txt
2022/06/08 23:54:36.684|SLAnalytics|Counter.h(61): containers::Counter<ServiceInfo>::decrease)|ERR|0|Decreasing counter for key that is not in the map
```

#### Problem with SLDataGateway while a DataMiner Agent was being shut down [ID_33839]

<!-- MR 10.3.0 - FR 10.2.8 [CU0] -->

When a DataMiner Agent was being shut down, in some cases, an error could occur in the SLDataGateway process.

#### DataMiner upgrade: VerifyNatsRunning prerequisite could fail due to SLCloudBridge.dll having been renamed [ID_33875]

<!-- MR 10.3.0 - FR 10.2.8 [CU0] -->

During a DataMiner upgrade, the VerifyNatsRunning prerequisite could fail due to the SLCloudBridge.dll file having been renamed to SLMessageBroker.dll in DataMiner versions 10.2.0/10.1.5.

#### Azure Active Directory: Domain users who were only a member of a domain group could be deleted during an LDAP synchronization [ID_33916]

<!-- MR 10.3.0 - FR 10.2.9 -->

When using Azure Active Directory as an identity provider, up to now, during an LDAP synchronization, all domain users who were only a member of a domain group would incorrectly be deleted when the Azure AD client secret had expired.

#### DataMiner Object Model: FieldValues would not get concatenated correctly [ID_33989]

<!-- MR 10.3.0 - FR 10.2.9 -->

When a name concatenation for a DomInstance had been defined in either the ModuleSettings or the DomDefinition, in some cases, the FieldValues would not get concatenated correctly.

#### DOM: FieldAlias properties not saved to database [ID_34054]

<!-- MR 10.3.0 - FR 10.2.9 -->

In some cases, it could occur that properties of a FieldAlias DOM object could not be saved to the database.

#### Error during Analytics upgrade action [ID_34082]

<!-- MR 10.3.0 - FR 10.2.10 -->

In some rare cases, an error could occur during the Analytics upgrade action when upgrading a DataMiner System with a Cassandra database per cluster.

#### DataMiner upgrade: AnalyticsDropUnusedCassandraTables upgrade action would fail [ID_34091]

<!-- MR 10.3.0 - FR 10.2.9 -->

During a DataMiner upgrade, in some cases, the *AnalyticsDropUnusedCassandraTables* upgrade action would fail.

#### Dashboards app / Low-Code Apps: Changes to the feed could incorrectly influence the time window of a state timeline component [ID_34148]

<!-- MR 10.3.0 - FR 10.2.10 -->

In some cases, changes to the feed linked to a state timeline component could reset the time window. From now on, linking a query filter to the timeline will no longer influence the time window. The filter will be applied and the current time window will be preserved.

Also, because of a number of enhancements, overall performance has increased when linking a query filter to a state timeline component.

#### SLScripting instances mismatched with SLProtocol instances [ID_34167]

<!-- MR 10.3.0 - FR 10.2.9 -->

When the *ProcessOptions* tag in *DataMiner.xml* was configured with the attribute *protocolProcesses* set to "protocol" and the attribute *scriptingProcesses* set to "protocol" or to a number larger than one, it could occur that elements ran their QActions in the wrong SLScripting instance, which could cause compilation or load balancing issues.

This issue will now be prevented. In addition, the element's instance GUID will now be added to the element log file for easier investigations.

#### SLAnalytics RTEs after upgrading DMS with Cassandra Cluster [ID_34180]

<!-- MR 10.3.0 - FR 10.2.8 CU2 -->

After a DMS with a Cassandra Cluster setup was upgraded to 10.2.8 (CU1), it could occur that the Alarm Console showed run-time errors related to the SLAnalytics process. This was caused by an upgrade action that was not triggered for such a setup.

#### Dashboards app / Low-Code Apps: Column filters in generic filter component incorrectly marked as incapable [ID_34273]

<!-- MR 10.3.0 - FR 10.2.10 -->

In the generic filter component, in some cases, column filters would be incorrectly marked as incapable when the filter assistance option was enabled.

#### Dashboards app / Low-Code Apps: Query column filters would not be applied correctly to table components [ID_34305]

<!-- MR 10.3.0 - FR 10.2.10 -->

when a dashboard, a low-code app page or low-code app panel was initialized, in some cases, query column filters would not be applied correctly to table components on that dashboard, page or panel.

#### Web apps - Interactive Automation scripts: Not possible to clear a selection box by selecting an empty option [ID_34315]

<!-- MR 10.3.0 - FR 10.2.11 -->

When an interactive Automation script was executed in a web app, it would incorrectly not be possible to clear a selection box by selecting an empty option.

#### Web Services API - CreateServiceTemplate: DataMinerID and ElementID incorrectly set to 0 instead of -1 [ID_34440]

<!-- MR 10.3.0 - FR 10.2.11 -->

When a service template was created using the *CreateServiceTemplate* method, the DataMinerID and ElementID of the newly created service template would incorrectly be set to 0 instead of -1.

#### Dashboards / Low-Code Apps: Changing a GQI query would not cause a table to get updated when column filters were applied [ID_34520]

<!-- MR 10.3.0 - FR 10.2.11 -->

When the GQI query linked to a table component was changed, the table would incorrectly not get updated when column filters were applied. The table would only get updated when you changed the column filters.

#### DataMiner upgrade: 'File already exists' exception could be thrown when multiple actions took a backup of the same file [ID_34601]

<!-- MR 10.3.0 - FR 10.2.12 -->

When, during a DataMiner upgrade, multiple upgrade actions took a backup of the same file within the same second, in some cases, a `file already exists` exception could be thrown.

#### DataMiner installer: Cassandra DevCenter would no longer be extracted [ID_34674]

<!-- MR 10.3.0 - FR 10.2.12 -->

Since Cassandra 3.7 was replaced by Cassandra 3.11 in DataMiner Installer 10.2, DevCenter would incorrectly no longer be extracted. From now on, it will again be extracted and a shortcut to the tool will be automatically created.

Also, if the *JAVA_HOME* environment variable is not defined, it will be set to the Java version that comes with Cassandra.

#### External authentication via SAML: Problem when using Okta as identity provider [ID_34745]

<!-- MR 10.3.0 - FR 10.3.2 -->

When using external authentication via SAML, a software issue would prevent you from logging in when Okta was set up as identity provider.

#### Mobile apps: Problem when trying to select an item in a drop-down box [ID_34742]

<!-- MR 10.3.0 - FR 10.2.12 [CU0] -->

In some cases, it would incorrectly not be possible to select an item in a drop-down box when the items were grouped or when their actual value was not identical to the value that was displayed.

#### Skyline Device Simulator: 'no such object' would incorrectly be returned when requesting data from a simulation [ID_34746]

<!-- MR 10.3.0 - FR 10.2.12 -->

When you tried to request data from a simulation that was built with AutoBuildVersion 1.3, in some cases, "no such object" would incorrectly be returned.

> [!CAUTION]
> This tool is provided "As Is" with no representation or warranty whatsoever. Skyline Communications will not provide any maintenance or support for this tool.

#### Problem with SLElement when a trend template was being assigned [ID_34824]

<!-- MR 10.3.0 - FR 10.3.1 -->

In some cases, an error could occur in SLElement when a trend template was being assigned.

#### Dashboards app: Empty groups would incorrectly not be removed from parameter feeds listing EPM parameters [ID_34884]

<!-- MR 10.3.0 - FR 10.3.1 -->

When, in a parameter feed listing EPM parameters, the parameters were grouped, empty groups would incorrectly not be removed after switching to another EPM object.

#### Low-code apps: Problem with 'Close a panel' action [ID_34892]

<!-- MR 10.3.0 - FR 10.3.1 -->

When a *Close a panel* action was configured as a post action on a button component, in some cases, it would incorrectly not cause the panel to close.

#### Dashboards & low-code apps: Decimal values would incorrectly not be allowed in range filters [ID_34897]

<!-- MR 10.3.0 - FR 10.3.1 -->

In some cases, a range filter in a query filter or a table column filter would incorrectly not allow decimal values.

> [!NOTE]
> When using a query filter with filter assistance enabled, the statistics will determine the number of decimals that can be used.

#### Dashboards & low-code apps: Feed component selections would incorrectly be lost after applying a built-in theme [ID_34908]

<!-- MR 10.3.0 - FR 10.3.1 -->

When you applied a built-in theme, feed component selections would incorrectly be lost after refetching the data.

#### Dashboards & low-code apps: Not possible to group the data in a timeline populated using a query with a query filter [ID_34932]

<!-- MR 10.3.0 - FR 10.3.1 -->

When a timeline was populated using a query with a query filter, it would incorrectly not be possible to group the data.

#### Low-code apps: Drop-down box containing an 'execute component' action would incorrectly be empty [ID_34953]

<!-- MR 10.3.0 - FR 10.2.12 [CU1] -->

When an *execute component* action had been configured, in some cases, when you tried to update that action, the drop-down box containing the action would incorrectly be empty.

#### Dashboards app & low-code apps: Manually sorted GQI table would no longer feed row values [ID_34969]

<!-- MR 10.3.0 - FR 10.2.12 [CU1] -->

When you had manually changed the sorting order of a GQI table by clicking a column header, in some cases, the table would no longer feed the selected row values.

#### Dashboards app: Tables would lose their conditional coloring after being sorted or filtered [ID_34979]

<!-- MR 10.3.0 - FR 10.3.1 -->

When you sorted or filtered a table fed by e.g. a query filter, the table would incorrectly lose its conditional coloring.

#### Web apps: Problem when a trend graph displaying multiple parameters showed data that was partly in the future [ID_34982]

<!-- MR 10.3.0 - FR 10.3.1 -->

When a trend graph displaying multiple parameters showed data that was partly in the future, in some cases, an error could occur.

#### Alarm templates: Parameters exported to DVE child elements could have incorrect alarm limits [ID_34996]

<!-- MR 10.3.0 - FR 10.3.2 -->

When a parameter was exported as a standalone parameter to a DVE child element, in some cases, the alarm limits could be incorrect when the type of alarm monitoring was set to either *Relative* or *Absolute*.

Also, LED bar controls would either not display or not update their alarm limits.

#### Dashboards app: Button to restore the initial view would incorrectly appear on all tables after sorting or filtering a table [ID_35003]

<!-- MR 10.3.0 - FR 10.3.2 -->

When, on a dashboard, you sorted or filtered a table, a button to restore the initial view would incorrectly appear on all tables on that dashboard. Also, when you clicked one of those buttons, they would all disappear. From now on, when you sort or filter a table on a dashboard, a button to restore the initial view will only appear on that particular table.

#### Skyline Device Simulator: Problem when running a proxy simulation [ID_35059]

<!-- MR 10.3.0 [CU0]/10.2.0 [CU10] - FR 10.3.1 -->

In some cases, an error could occur in the Skyline Device Simulator when a proxy simulation was being run.

#### Service & Resource Management: Problem when migrating resources containing properties with keys or values set to null [ID_35067]

<!-- MR 10.3.0 - FR 10.3.1 [CU0] -->

When resource data was being migrated to Elasticsearch, the following exception could be thrown when a resource or a resource pool contained properties with keys or values that were set to null.

```txt
2022/12/01 08:53:59.582|SLNet.exe|ResourceManager|ERR|0|6|System.Reflection.TargetInvocationException: Exception has been thrown by the target of an invocation. ---> System.ArgumentException: value is not serializable to json
```

#### Monitoring app: Problem when opening the histogram page of a view [ID_35081]

<!-- MR 10.3.0 - FR 10.3.2 -->

When, in the *Monitoring* app, you selected a view and opened the histogram page, in some cases, a `Maximum call stack size exceeded` error would appear.

#### Dashboards app: Visual Overview component would not show any content when linked to a feed [ID_35130]

<!-- MR 10.3.0 - FR 10.3.2 -->

When a Visual Overview component was linked to a feed, in some cases, it would not show any content.

#### SLElement would leak memory when an element was frequently receiving timeout values [ID_35131]

<!-- MR 10.3.0 - FR 10.3.2 -->

When an element was frequently receiving timeout values, SLElement would leak memory.

#### DataMiner Object Models: Problem when retrieving a non-existing DomInstance status ID [ID_35231]

<!-- MR 10.3.0 - FR 10.3.2 -->

When a GQI query retrieved the status of a DOM instance that had no status, the logic would incorrectly detect that a status was present and would try to resolve the display name for that status, causing a `Could not find state for statusID ...` error to be thrown.
