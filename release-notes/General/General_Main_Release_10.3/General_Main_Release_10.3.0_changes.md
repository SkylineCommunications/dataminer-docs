---
uid: General_Main_Release_10.3.0_changes
---

# General Main Release 10.3.0 – Changes

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For release notes related to DataMiner Cube, see [DataMiner Cube 10.3.0](xref:Cube_Main_Release_10.3.0).

## Changes

### Enhancements

#### Security enhancements [ID_31045] [ID_31054] [ID_31761] [ID_32055] [ID_32566] [ID_33069] [ID_33078] [ID_33218] [ID_33365] [ID_33583] [ID_34723] [ID_35331]

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
<!-- Also added to MR 10.2.0 [CU14] -->

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

#### Improved SPI logging for Automation [ID_34025]

<!-- MR 10.3.0 - FR 10.2.9 -->

The log levels of some of the log lines related to SPIs in the *SLAutomation* log file have been changed, so that the log file does not get flooded with potentially irrelevant data. In addition, these log lines will now contain the SPI node ID and definition ID. The log line mentioning the SPI definition ID when this definition is created will no longer be added.

#### SLLogCollector now also collects SLAnalytics configuration files [ID_34106]

<!-- MR 10.3.0 - FR 10.2.10 -->

Several SLAnalytics configuration files will now also be collected by the SLLogCollector tool. These will be placed in the *Logs/Skyline DataMiner/Analytics* and *Logs/Skyline DataMiner/Configuration* folders of the archive created by SLLogCollector.

#### Improved performance of Resources module [ID_34205]

<!-- MR 10.3.0 - FR 10.2.10 -->

Because of enhancements to the way resources are processed and stored, the Resources module will now initialize more quickly.

In addition, performance has improved when a resource or resource pool is added or updated.

#### SLNet / SLDataGateway: Enhanced algorithm to find the first valid physical address of the DataMiner Agent [ID_34360]

<!-- MR 10.3.0 - FR 10.2.11 -->

A number of enhancements have been made to the algorithm used by SLNet and SLDataGateway to find the first valid physical address of the DataMiner Agent.

#### Behavioral change points stored in both Cassandra and Elasticsearch [ID_34621]

<!-- MR 10.3.0 - FR 10.2.12 -->

If an Elasticsearch database is available, the behavioral change points detected in trend data by the Behavioral Anomaly Detection feature will now be stored both in the Cassandra database and the Elasticsearch database. Otherwise, they will be stored in Cassandra only like before.

This will support faster and more flexible change point querying via GQI in future releases.

#### SLLogCollector now has a default log configuration that will be used by the SupportAssistant DxM [ID_34709]

<!-- MR 10.3.0 - FR 10.2.12 -->

The SLLogCollector tool now has a default log configuration that will be used by the SupportAssistant DxM.

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

#### SLAnalytics: Enhanced automatic evaluation of trend predictions [ID_34901]

<!-- MR 10.3.0 - FR 10.3.1 -->

Because of a number of enhancements, the automatic evaluation of trend predictions has improved.

#### Service & Resource Management: Enhanced performance when adding and updating bookings [ID_35016]

<!-- MR 10.3.0 - FR 10.3.2 -->

Because of a number of enhancements, overall performance has increased when creating and updating bookings.

#### SLAnalytics - Behavioral anomaly detection : More accurate change point time ranges [ID_35121]

<!-- MR 10.3.0 - FR 10.3.2 -->

Because of a number of enhancements, behavioral changes of the type "level shift", "trend change" and "variance change" will now have a more accurate time range when the change in behavior is sufficiently clear.

#### Enhanced performance when updating a baseline or assigning an alarm template that contains conditional monitoring [ID_35171]

<!-- MR 10.3.0 - FR 10.3.2 -->

Because of a number of enhancements, overall performance has increased when updating a baseline or assigning an alarm template that contains conditional monitoring.

#### Enhanced performance when deleting a service from an Elasticsearch database [ID_35173]

<!-- MR 10.3.0 - FR 10.3.2 -->

Because of a number of enhancements, overall performance has increased when deleting a service from an Elasticsearch database.

#### SLAnalytics: Enhanced processing of parameter values 'exception' and 'other' [ID_35214]

<!-- MR 10.3.0 - FR 10.3.2 -->

Because of a number of enhancements, overall processing of "exception" or "other" parameter values by the SLAnalytics process has improved.

#### SLAnalytics - Pattern matching: When a pattern is detected on a DVE child element the suggestion event will now be generated on that same DVE child element [ID_35264]

<!-- MR 10.3.0 - FR 10.3.2 -->

When a trend pattern was detected on a DVE child element, up to now, the suggestion event would be generated on the parent element. From now on, it will be generated on the child element instead.

#### SLAnalytics - Behavioral anomaly detection: Suggestion events and alarm events for a DVE child element will now be generated on that same DVE child element [ID_35332]

<!-- MR 10.3.0 - FR 10.3.3 -->

When a behavioral anomaly was detected on a DVE child element, up to now, the suggestion event or the alarm event would be generated on the parent element. From now on, it will be generated on the child element instead.

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

#### Service & Resource Management: Retrieving ReservationInstances sorted by a property of type string would return an incorrectly sorted result set [ID_32003]

<!-- MR 10.3.0 - FR 10.2.3 -->

When a list of ReservationInstances were retrieved sorted by a property of type string, that list would be returned in an incorrect sort order.

#### Cassandra: Problem when a NULL value was encountered in a logger table during a database migration [ID_32358]

<!-- MR 10.3.0 - FR 10.2.3 -->

When migrating a database to a Cassandra cluster, in some cases, an error could be thrown when a NULL value was encountered in a logger table.

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

#### SLPort would incorrectly split WebSocket messages larger than 65kB [ID_33182]

<!-- MR 10.3.0 - FR 10.2.6 -->

Up to now, when SLPort received a WebSocket message larger than the WebSocket buffer (i.e. 65 kB), it would incorrectly split that message in multiple chunks before passing it to the protocol.

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

#### SLAnalytics: Problem when predicting the trend of a history set parameter [ID_33389]

<!-- MR 10.3.0 - FR 10.2.7 -->

Up to now, negative status values in the trend data due to element restarts could cause the trend prediction engine to incorrectly interpret the trend data of a history set parameter.

#### Issues with NATS request/response actions [ID_33487]

<!-- MR 10.3.0 - FR 10.2.7 -->

A number of issues with NATS request/response actions have been solved.

#### Problem with SLDataGateway when updating parameters [ID_33535]

<!-- MR 10.3.0 - FR 10.2.7 -->

In some cases, an error could occur in SLDataGateway when updating parameters.

#### Failover: Offline agent would fail to come online when the NATS cluster was down during a Failover switch [ID_33681]

<!-- MR 10.3.0 - FR 10.2.11 -->

When, during a Failover switch, the NATS cluster was down, the offline agent would fail to come online.

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
<!-- Also added to MR 10.2.0 [CU13] -->

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

#### SLScripting instances mismatched with SLProtocol instances [ID_34167]

<!-- MR 10.3.0 - FR 10.2.9 -->

When the *ProcessOptions* tag in *DataMiner.xml* was configured with the attribute *protocolProcesses* set to "protocol" and the attribute *scriptingProcesses* set to "protocol" or to a number larger than one, it could occur that elements ran their QActions in the wrong SLScripting instance, which could cause compilation or load balancing issues.

This issue will now be prevented. In addition, the element's instance GUID will now be added to the element log file for easier investigations.

#### SLAnalytics RTEs after upgrading DMS with Cassandra Cluster [ID_34180]

<!-- MR 10.3.0 - FR 10.2.8 CU2 -->

After a DMS with a Cassandra Cluster setup was upgraded to 10.2.8 (CU1), it could occur that the Alarm Console showed run-time errors related to the SLAnalytics process. This was caused by an upgrade action that was not triggered for such a setup.

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

#### Skyline Device Simulator: 'no such object' would incorrectly be returned when requesting data from a simulation [ID_34746]

<!-- MR 10.3.0 - FR 10.2.12 -->

When you tried to request data from a simulation that was built with AutoBuildVersion 1.3, in some cases, "no such object" would incorrectly be returned.

> [!CAUTION]
> This tool is provided "As Is" with no representation or warranty whatsoever. Skyline Communications will not provide any maintenance or support for this tool.

#### Skyline Device Simulator: Problem when running a proxy simulation [ID_35059]

<!-- MR 10.3.0 [CU0]/10.2.0 [CU10] - FR 10.3.1 -->

In some cases, an error could occur in the Skyline Device Simulator when a proxy simulation was being run.


#### When a direct view table was updated, the wrong columns could be updated in the source element [ID_35075]

<!-- MR 10.3.0 - FR 10.3.3 -->

When a direct view table was updated while one of the source elements was stopped, due to a column translation issue, the wrong columns could be updated in that source element the moment it was started again.

#### SLElement would leak memory when an element was frequently receiving timeout values [ID_35131]

<!-- MR 10.3.0 - FR 10.3.2 -->

When an element was frequently receiving timeout values, SLElement would leak memory.

#### DataMiner Object Models: Problem when retrieving a non-existing DomInstance status ID [ID_35231]

<!-- MR 10.3.0 - FR 10.3.2 -->

When a GQI query retrieved the status of a DOM instance that had no status, the logic would incorrectly detect that a status was present and would try to resolve the display name for that status, causing a `Could not find state for statusID ...` error to be thrown.

#### DataMiner Object Models: Permission checks for DOM modules requiring view permission 'None' were too strict [ID_35305]

<!-- MR 10.3.0 - FR 10.3.3 -->

If a DOM module is created without specifying *SecuritySettings*, the view permission is set to "None".

Up to now, the check to determine whether a user had the view permission set to "None", would only return true for the Administrator or users in the Administrator group. From now on, when the required view permission is "None", permission checks will no longer be performed.

#### Problem with SLPort when an element with a serial connection was restarted [ID_35773]

<!-- MR 10.2.0 [CU12]/10.3.0 [CU0] - FR 10.3.3 [CU1] -->

In some cases, an error could occur in SLPort when an element with a serial connection was restarted.

#### Cassandra Cluster: Rows would incorrectly be added without TTL value [ID_35789]

<!-- MR 10.3.0 [CU0] - FR 10.3.3 [CU0] -->

When a row was added to a Cassandra Cluster table, no TTL value would be inserted into the TTL column of that row.
