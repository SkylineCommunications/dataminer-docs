---
uid: General_Feature_Release_10.4.1
---

# General Feature Release 10.4.1

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!IMPORTANT]
> When downgrading from DataMiner Feature Release version 10.3.8 (or higher) to DataMiner Feature Release version 10.3.4, 10.3.5, 10.3.6 or 10.3.7, an extra manual step has to be performed. For more information, see [Downgrading a DMS](xref:MOP_Downgrading_a_DMS).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.4.1](xref:Cube_Feature_Release_10.4.1).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.4.1](xref:Web_apps_Feature_Release_10.4.1).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

- [Service & Resource Management: Storage type for ProfileManager and ResourceManager will now always be Elasticsearch/OpenSearch [ID 37877]](#service--resource-management-storage-type-for-profilemanager-and-resourcemanager-will-now-always-be-elasticsearchopensearch-id-37877)
- [Legacy Reports, Dashboards and Annotations modules are now end-of-life and will be disabled by default [ID 37786]](#legacy-reports-dashboards-and-annotations-modules-are-now-end-of-life-and-will-be-disabled-by-default-id-37786)

## New features

#### BrokerGateway DxM will now be installed automatically during a DataMiner upgrade [ID 37714]

<!-- MR 10.5.0 - FR 10.4.1 -->

When a DataMiner Agent is upgraded to version 10.5.0/10.4.1 or above, the *BrokerGateway* DxM will automatically be installed in the `C:\Program Files\Skyline Communications\DataMiner BrokerGateway` folder.

This new DxM, which is currently still under development, is intended to manage all NATS configurations.

#### User-defined APIs: Query string support [ID 37733]

<!-- MR 10.5.0 - FR 10.4.1 -->

User-defined APIs now support the use of query strings.

The query parameters from the API requests are available in the `QueryParameters` property of the `ApiTriggerInput` class. This property is of type `IQueryParameters`.

The `IQueryParameters` class exposes the following methods:

```csharp
bool TryGetValues(string key, out List<string> values);

bool TryGetValue(string key, out string value);

List<string> GetAllKeys();

bool ContainsKey(string key);
```

> [!NOTE]
>
> - Multiple values can be added for one key.
> - Query parameter keys are case-sensitive.

#### DataMiner upgrade: Additional prerequisite will now check whether profiles and resources are stored in an indexing database [ID 37763]

<!-- MR 10.4.0 - FR 10.4.1 -->

Starting from DataMiner version 10.4.0, XML storage for profiles and resources is no longer supported. When you upgrade DataMiner to version 10.4.0, the `VerifyElasticStorageType` prerequisite will verify whether the system has successfully switched to an indexing database. If profiles and/or resources are still stored in XML files, this prerequisite will cause the upgrade to fail.

See also: [Verify Elastic Storage Type](xref:Verify_Elastic_Storage_Type)

#### Service & Resource Management: Storage type for ProfileManager and ResourceManager will now always be Elasticsearch/OpenSearch [ID 37877]

<!-- MR 10.4.0 - FR 10.4.1 -->

From now on, the storage type for ProfileManager and ResourceManager will always be Elasticsearch/OpenSearch. XML storage is no longer supported.

When you retrieve the storage type, it will now always return Elasticsearch/OpenSearch, even if the ProfileManager or ResourceManager configuration states that the storage type is XML. If no ProfileManager configuration can be found, a default configuration will now be created with storage type set to Elasticsearch/OpenSearch.

If you would try to send a `SetResourceManagerConfigMessage` to change the storage type to XML, the response message will state that the attempt failed and will contain the following error message:

`Ignoring the config change, Xml is no longer supported as ResourceStorageType.`

If you would try to set the ProfileManager configuration to Elasticsearch/OpenSearch via the configuration manager, this will fail. The ProfileManager log file should then contain the following trace data:

```txt
TraceData: (amount = 1)
   - ErrorData: (amount = 1)
      - ProfileManagerErrorData: ErrorReason: InvalidConfigurationFile,
                                 Message: Xml is no longer supported as ProfileManagerStorageType,
```

> [!NOTE]
> The *SLNetClientTest* tool will no longer allow you to switch the storage type from XML to Elasticsearch/OpenSearch or vice versa, nor will it allow you to create a ProfileManager configuration anymore.

## Changes

### Enhancements

#### Elasticsearch/OpenSearch: Enhanced log entry when creating a custom data storage fails [ID 26965]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

When an attempt to create a custom data storage fails, the log entry will now also mention the data storage type.

Former log entry:

`Cannot create a custom data table for Elastic when Elastic is not active.`

New log entry:

`Cannot create a custom data table for {typeof(T)} in Elastic when Elastic is not active.`

#### New BPA test 'Check Cluster SLNet Connections' [ID 37110]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->
<!-- Removed from 10.3.0 [CU10] based on feedback from KDG -->

When run on a particular Agent in a DataMiner System, this new BPA test will trigger a local test on each Agent in the DMS that will

- check the connections between the different DMAs and between the DMAs in Failover setups, and
- report any communication problems.

For more information, see [Check Cluster SLNet Connections](xref:BPA_Check_Cluster_SLNet_Connections).

#### DataMiner Object Models: Generic enum field descriptors now allow you to select multiple values [ID 37482]

<!-- MR 10.4.0 - FR 10.4.1 -->

A generic enum field descriptor now allows you to select multiple values.

For a *GenericEnumFieldDescriptor* to allow multiple values, its field type should be set as follows:

- For integer values: `FieldType = typeof(List<GenericEnum<int>>)`
- For string values: `FieldType = typeof(List<GenericEnum<string>>)`

Values need to be set as follows:

- Integer values:

  ```csharp
  new ListValueWrapper<int>(new List<int>(){0, 1});
  ```

- String values:

  ```csharp
  new ListValueWrapper<string>(new List<string>(){ "Value 0", "Value 1" });
  ```

#### GQI: Enhanced error handling when an error occurs while executing a query before it is joined with another query [ID 37521]

<!-- MR 10.4.0 - FR 10.4.1 -->

Up to now, when an error occurred during the execution of a GQI query that, later on, was joined with another query, the exception message would always read `One or more errors occurred`.

From now on, an exception that occurs when executing a query before it is joined with another query will be re-thrown afterwards. This will make sure the exception reveals the actual reason why the query failed.

#### Deprecated NotifyDataMiner type 'NT_CONNECTIONS_TO_REMOVE' can no longer be used [ID 37595]

<!-- MR 10.5.0 - FR 10.4.1 -->

From now on, the deprecated NotifyDataMiner type *NT_CONNECTIONS_TO_REMOVE* can no longer be used.

#### Security enhancements [ID 37641]

<!-- 37641: MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

A number of security enhancements have been made.

#### SLAnalytics - Proactive cap detection: Enhanced detection of possible future alarm threshold breaches [ID 37681]

<!-- MR 10.5.0 - FR 10.4.1 -->

When an increasing or decreasing trend is detected on a highly aggregated level (i.e. a trend that persists for more than 24 hours), from now on, a proactive cap detection suggestion event will be generated when there is a probability that the trend change in question could lead to a breach of a critical alarm limit at some point in the future, even when the breach has not yet been confirmed by the full prediction model built on the historic trend data.

#### SLAnalytics - Behavioral anomaly detection: Flatline suggestion events will now automatically be cleared after a set amount of time [ID 37716]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

Similar to other types of anomaly suggestion events, flatline suggestion events will now also be cleared automatically after a set amount of time.

> [!NOTE]
> Flatline alarms stay open until the flatline in question disappears or SLAnalytics is restarted.

#### Service & Resource Management: Enhanced performance of ResourceManagerHelper.GetResources when using the ResourceExposers.ID.Equal filter [ID 37720]

<!-- MR 10.5.0 - FR 10.4.1 -->

Because of a number of enhancements, overall performance of the `ResourceManagerHelper.GetResources` method has increased when using a `ResourceExposers.ID.Equal` filter.

Also, the performance of `TrueFilterElement<Resource>` has been improved.

#### Service & Resource Management: ProfileManager cache [ID 37735]

<!-- MR 10.4.0 - FR 10.4.1 -->

When profile data is stored in an Elasticsearch/OpenSearch database, all ProfileDefinitions and ProfileParameters in the ProfileManager will now be cached on each of the DMAs in the DataMiner System. During the midnight synchronization, all these caches will be reloaded to ensure that they all remain in sync.

Also, additional logging has been added to indicate when a cache was refilled and how many objects were added, updated, removed or ignored. Each log entry will also include the IDs of the first ten of these objects.

#### User-Defined APIs: Maximum size of HTTP request body has been reduced to 29MB [ID 37753]

<!-- MR 10.4.0 - FR 10.4.1 -->

The maximum size of the HTTP request body has been reduced from 30 MB to 29 MB.

Also, additional logging will be added to the *SLUserDefinableApiManager.txt* log file when subscribing on NATS fails and when sending a reply on an incoming NATS request fails.

#### Enhanced performance when locking or unlocking inputs and output of matrices in client applications [ID 37755]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

Because of a number of enhancements, overall performance has increased when locking or unlocking inputs and output of matrices in client applications.

#### Legacy Reports, Dashboards and Annotations modules are now end-of-life and will be disabled by default [ID 37786]

<!-- MR 10.4.0 - FR 10.4.1 -->

As from DataMiner versions 10.1.10/10.2.0, the *LegacyReportsAndDashboards* and/or *LegacyAnnotations* soft-launch options allowed you to enable or disable the legacy *Reports*, *Dashboards* and *Annotations* modules. By default, they were enabled.

Now, the above-mentioned soft-launch options will be disabled by default, causing the legacy *Reports*, *Dashboards* and *Annotations* modules to be hidden. If you want to continue using these modules, which are now considered end-of-life, you will have to explicitly enable the soft-launch options.

#### SLAnalytics - Behavioral anomaly detection: Changes made to the anomaly configuration in an alarm template of a main DVE element will immediately be applied to all open anomaly alarm events [ID 37788]

<!-- MR 10.4.0 - FR 10.4.1 -->

When you change the anomaly configuration in an alarm template assigned to a main DVE element, from now on, the changes will immediately be applied to all open anomaly alarm events. The severity of the open alarm events will be changed to the new severity defined in the updated anomaly configuration.

#### GQI: Enhanced performance when executing inner of left join queries in which sorting is applied to the left query [ID 37803]

<!-- MR 10.4.0 - FR 10.4.1 -->

Because of a number of enhancements, overall performance has increased when executing inner or left join queries in which sorting is applied to the left query.

#### GQI: Enhanced performance when executing sorted queries [ID 37806]

<!-- MR 10.4.0 - FR 10.4.1 -->

Forwarding sort operators to the backend is now supported for a wider range of query configurations. This will considerably increase overall performance of numerous sorted queries.

#### SLNet will no longer allow DataMiner Agents to connect when they share the same DataMiner GUID [ID 37819]

<!-- MR 10.4.0 - FR 10.4.1 -->

When two DataMiner Agents try to connect via SLNet, from now on, this will no longer be allowed if the two agents share the same DataMiner GUID (except when they are both part of the same Failover setup).

#### Authentication response message now includes the domain user name [ID 37823]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

When a DataMiner Agent receives an authentication request from a client application, it will now include the domain user name in the authentication response message it returns to the client application.

#### Protocols: Buffer for SNMP responses now has a dynamic size [ID 37824]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

Up to now, when an SNMP response was received, a buffer with a fixed size of 10240 characters was used to translate the response to the requested format (e.g. OctetStringUTF8). When the response was larger that 10240 characters, it was cut off.

From now on, the buffer will have a dynamic size. This allow larger responses to be processed, and will also make sure that less memory has to be reserved when smaller responses are received.

#### DataMiner upgrade: New 'UninstallAPIDeployment' upgrade action and 'VerifyNoObsoleteApiDeployed' prerequisite [ID 37825]

<!-- MR 10.4.0 - FR 10.4.1 -->

When you upgrade DataMiner from a version older than 10.4.0 to a version from 10.4.0 onwards, the newly added *VerifyNoObsoleteApiDeployed* prerequisite will check whether the *APIDeployment* soft-launch flag is active and whether APIs are deployed. If so, the prerequisite will fail and return a link to the following page:

- [Verify No Obsolete API Deployed](xref:Verify_No_Obsolete_API_Deployed)

Also, the newly added *UninstallApiDeployment* upgrade action will remove everything related to the deprecated API Deployment soft-launch feature:

- Stop and delete the *SLAPIEndpoint* service.

- Remove the following files (if present):

  - `C:\Skyline DataMiner\SLAPIEndpoint`
  - `C:\Skyline DataMiner\DeployerTokens`
  - `C:\Skyline DataMiner\ForceDeployerTokensFileStorage.txt`
  - `C:\Skyline DataMiner\Resources\SLAPIEndpoint.zip`

- If present, remove the rewrite rules for API Deployment.

- Remove the API Deployment configuration file from `C:\Skyline DataMiner\Configurations\JSON`.

- Remove the *APIDeployment* soft-launch flag from *SoftLaunchOptions.xml*.

#### SLAnalytics - Behavioral anomaly detection: Enhanced coloring of trend graph change point indicators [ID 37827]

<!-- MR 10.5.0 - FR 10.4.1 -->

In a trend graph, the occurrence of change points is indicated by colored rectangular regions below the graph.

Up to now, these regions had a dark color when an alarm event would have been triggered for the change point in question if alarm monitoring had been activated for that type of change point.

From now on, a rectangular region will have a dark color when the change point in question actually triggered an event:

- a suggestion event (if alarm monitoring was not activated for that type of change point), or
- an alarm event (if alarm monitoring was activated for that type of change point).

#### Behavioral anomaly detection: Flatline detection now takes into account the decimal precision of parameter values [ID 37828]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

From now on, the flatline detection algorithm will take into account the decimal precision of parameter values displayed in client applications.

#### Parameter ID range 10,000,000 to 10,999,999 now reserved [ID 37837]

<!-- MR 10.4.0 - FR 10.4.1 -->

Parameters IDs in the range of 10,000,000 to 10,999,999 are now reserved for DataMiner parameters. These will be used for DataMiner features in the future.

#### GQI: Ad hoc data sources and custom operators now support row metadata [ID 37879]

<!-- MR 10.4.0 - FR 10.4.1 -->

Ad hoc data sources and custom operators now support row metadata.

- In case of an ad hoc data source, any metadata can be attached to a row.
- In case of a custom operator, row metadata can be read from existing rows, and row metadata can be modified.

#### DataMiner upgrade: New prerequisite will check whether the DMA still contains legacy reports or legacy dashboards [ID 37922]

<!-- MR 10.4.0 - FR 10.4.1 -->

When you upgrade DataMiner from a version older than 10.4.0 to a version from 10.4.0 onwards, the newly added prerequisite will check whether the DataMiner Agent still contains legacy reports or legacy dashboards. If so, the prerequisite will fail.

See also: [Verify No Legacy Reports Dashboards](xref:Verify_No_Legacy_Reports_Dashboards)

#### SLAnalytics: Enhanced error logging when retrieving trend data [ID 37931]

<!-- MR 10.5.0 - FR 10.4.1 -->

More extensive information will now be logged when errors occur while retrieving trend data.

#### Service & Resource Management: Enhanced performance when updating/applying profile instances [ID 37976]

<!-- MR 10.4.0 - FR 10.4.1 -->

Overall performance has increased when updating/applying profile instances by providing a way to pass cached profile instances instead of first having to retrieve them from the database. To achieve this, the `ResourceUsageDefinition` now has a new overload method:

```csharp
public virtual void UpdateAllCapacitiesAndCapabilitiesByReference(Func<FilterElement<ProfileInstance>, List<ProfileInstance>> retriever, Dictionary<Guid, ProfileInstance> profileInstanceCache, IEnumerable<QuarantinedResourceUsageDefinition> correspondingQuarantines = null);
```

### Fixes

#### Max Payload exceptions when using MessageBroker with chunking [ID 37245]

<!-- MR 10.4.0 - FR 10.4.1 -->

When MessageBroker used chunking, the generated chunks would not be trimmed to the correct size before transmission, resulting in *Max Payload* exceptions.

For more detailed information, refer to [Max Payload exceptions occur when using MessageBroker with chunking](xref:KI_DataMinerMessageBroker_Chunking_MaxPayload).

#### Problem when using MessageBroker with chunking [ID 37532]

<!-- MR 10.4.0 - FR 10.4.1 -->

On high-load systems, MessageBroker threads could leak when using chunking.

#### Databases: Problem when starting a migration from MySQL to Cassandra [ID 37589]

<!-- MR 10.3.0 [CU14] / 10.4.0 [CU2] - FR 10.4.1 -->

When you started a migrating from a MySQL database to a Cassandra database, an error could occur when the connection to the MySQL database took a long time to get established.

#### DELT: Trend data missing in DELT package after exporting tables with primary keys of type string [ID 37664]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

When you exported tables of which the primary keys were of type string, the DELT export package would incorrectly not contain any trend data.

#### Attempt to update a deleted service would incorrectly cause that service to re-appear [ID 37679]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

In some rare cases, if an attempt was made to update a service that had just been deleted, the service could re-appear.

Additional logging has now been added to allow better tracing of errors that occur while creating or updating services.

#### Problem with SLDataGateway during a Cassandra Cluster migration [ID 37684]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

SLDataGateway would leak memory during a Cassandra Cluster migration.

#### Problem with remote clients after restarting a DMA in a gRPC-only cluster [ID 37726]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

When a DataMiner System was configured to use gRPC connections only (i.e. when *EnableDotNetRemoting* was set to false on all agents), in some cases, remote clients would not get properly registered with SLDataMiner after restarting a DataMiner Agent. This would cause remote requests to fail if they had to be handled by SLDataMiner on the DataMiner Agent that was restarted.

#### DELT package created on DataMiner v10.3.8 or newer could no longer be imported on DataMiner v10.3.7 or older [ID 37731]

<!-- MR 10.4.0 - FR 10.4.1 -->

When you exported elements via a DELT package on a DMA running DataMiner version 10.3.8 or newer, it would no longer be possible to import that DELT package on a DMA running DataMiner version 10.3.7 or older.

#### SLAnalytics: Problem when the alarm repository was not available at startup [ID 37782]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

In some cases, an error could occur in SLAnalytics when it was not able to connect to the alarm repository at startup.

#### Entire SNMPv3 response would be discarded when one or more cells contained 'no such instance' [ID 37815]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

When a table was polled via SNMPv3 and the response included a cell that contained *no such instance*, the table would not get populated with the values that were received. Instead, the entire result set would be discarded.

#### Reports for DVE elements would show either incorrect alarm information or no alarm information at all [ID 37816]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

When, in e.g. DataMiner Cube, you double-clicked a parameter of a DVE element and navigated to the *Details* tab, in some cases, the reports would show either incorrect alarm information or no alarm information at all.

The same issue would occur when, in DataMiner Cube, you opened an element card and navigated to *Reports > General*.

#### Security: Users would incorrectly not be allowed to update the Visio file linked to a service [ID 37866]

<!-- MR 10.3.0 [CU11] - FR 10.4.1 -->

Up to now, when users had the following permissions, they would not be allowed to update the Visio file associated with a service by using the *Upload new visio file* or *Set new blank visio file* commands:

- *General > Visual Overview > Access Visual Overviews*
- *General > Visual Overview > Edit Visio drawings*
- *General > Services > Edit*
- *Write* and *Config* permission for the service in question

From now on, when users have the permission to link a Visio file to a specific service, they will always be allowed to update the Visio file linked to that service.

#### Cassandra Cluster: Failover setups would incorrectly report errors when the cluster status was yellow [ID 37868]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

When a Cassandra Cluster was in a yellow state because a number of nodes were down, up to now, Failover setups within the system would incorrectly report errors.

From now on, Failover setups within the system will only report errors if the Cassandra Cluster is in a red state.

#### Incorrect 'Clearing cache ...' entries in SLEventCache.txt [ID 37874]

<!-- MR 10.4.0 - FR 10.4.1 -->

Incorrect entries would be added to the *SLEventCache.txt* log file on DataMiner startup and when new objects (e.g. elements) had been created.

Example of an incorrect log entry:

`Clearing cache: predicate<entries with old hosting agent id> for type XXXXXX`

#### SLAnalytics - Behavioral anomaly detection: Incorrect flatline stops could be generated [ID 37903]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

In some cases, incorrect flatline stops could be generated.

#### SLAutomation would not properly cleanup deleted references to elements [ID 37907]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

In some rare cases, SLAutomation would not clean up deleted references to elements, causing the process to stop unexpectedly when the Automation script ended.

#### GQI: 'Could not find PK column' error after performing a query against an empty parameter table [ID 37978]

<!-- MR 10.3.0 [CU11] - FR 10.4.1 -->

Up to now, in some rare cases, performing a GQI query against an empty parameter table would result in a `Could not find PK column` error. From now on, GQI will return an empty result set instead.

#### Storage as a Service: Problem when starting a database migration [ID 38059]

<!-- MR 10.4.0 - FR 10.4.1 [CU0] -->

When you tried to start a migration of an on-premises database to a DataMiner Storage as a Service platform, the connection towards the cloud could not get established.

#### DataMiner Storage Module: Thread leak [ID 38095]

<!-- MR 10.4.0 - FR 10.4.1 [CU0] -->

In some cases, the DataMiner Storage Module could leak threads.

#### Storage as a Service: Database write operations would not get processed [ID 38112]

<!-- MR 10.4.0 - FR 10.4.1 [CU0] -->

In some rare cases, a database write operation could incorrectly remain stuck in an internal queue and would never get processed.
