---
uid: General_Feature_Release_10.4.3
---

# General Feature Release 10.4.3 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
> When downgrading from DataMiner Feature Release version 10.3.8 (or higher) to DataMiner Feature Release version 10.3.4, 10.3.5, 10.3.6 or 10.3.7, an extra manual step has to be performed. For more information, see [Downgrading a DMS](xref:MOP_Downgrading_a_DMS).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.4.3](xref:Cube_Feature_Release_10.4.3).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.4.3](xref:Web_apps_Feature_Release_10.4.3).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected yet.*

## New features

#### SLNetClientTest tool: New SLProtocol health statistics [ID_37617]

<!-- MR 10.5.0 - FR 10.4.3 -->

When, in the *SLNetClientTest* tool, you open the *Diagnostics > DMA* menu, you can now find the following new commands:

| Command | Function |
|---------|----------|
| Health Stats (SLProtocol) > Stats      | Show the overall SLProtocol memory used by all elements. |
| Health Stats (SLProtocol) > Details... | Show all details of a specific element.          |

#### DataMiner Maps: ForeignKeyRelationsSourceInfo tag now supports an elementVar attribute [ID_38274]

<!-- MR 10.4.0 - FR 10.4.3 -->

In a `<ForeignKeyRelationsSourceInfo>` tag, it is now possible to specify an *elementVar* attribute.

```xml
<ForeignKeyRelationsSourceInfo elementVar="myElement">
...
</ForeignKeyRelationsSourceInfo>
```

This will allow you to pass an element in the map's URL. See the URL examples below (notice the “d” in front of the parameter name!):

```txt
maps.aspx?config=MyConfigFile&dmyElement=7/46840
maps.aspx?config=MyConfigFile&dmyElement=VesselData
```

## Changes

### Breaking changes

#### Microsoft Entra ID: Enhanced user and group import [ID_38154]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

A number of improvements have been made with regard to importing users and user groups into Microsoft Entra ID (formerly known as Azure Active Directory):

- Enhanced performance for tenants with large amounts of users and groups.
- Support for users of which the name contains non-ASCII characters, users sharing the same given name and surname, and users of whom the given name and/or surname is not provisioned.
- Group descriptions will now also be imported.

These improvements include the following **breaking change**:

User name format has changed from `{organization}\{givenName}.{surname}` to `{domain}\{username}` based on the `userPrincipalName`.

This format is now consistent with automatic user provisioning via SAML authentication.

For example, "ZIINE\Björn.Waldegård" with userPrincipalName <bjorn.waldegard@ziine.com> will now become "ziine.com\bjorn.waldegard".

#### NATS: All processes will now use the DataMinerMessageBroker.API NuGet package [ID_38193]

<!-- MR 10.4.0 - FR 10.4.3 -->

All processes that were still using the deprecated *SLMessageBroker.dll* or *CSLCloudBridge.dll* files will now be using the *DataMinerMessageBroker.API* or *DataMinerMessageBroker.API.Native* NuGet package instead.

| Processing using ... | will now instead use ...          |
|----------------------|-----------------------------------|
| SLMessageBroker.dll  | DataMinerMessageBroker.API        |
| CSLCloudBridge.dll   | DataMinerMessageBroker.API.Native |

> [!IMPORTANT]
> This is a breaking change. It will cause the *VerifyNatsIsRunning* prerequisite to fail when you downgrade to an earlier DataMiner version, because this prerequisite will expect the old *SLMessageBroker* DLL instead of the *DataMinerMessageBroker* API. To be able to downgrade, you will need to open the upgrade package you want to downgrade to (like a zip archive) and remove *VerifyNatsIsRunning.dll* from the `\Update.zip\Prerequisites\` folder.

### Enhancements

#### SLAnalytics - Alarm focus: Alarm occurrences will now be identified using a combination of element ID, parameter ID and primary key  [ID_38184] [ID_38251]

<!-- MR 10.4.0 - FR 10.4.3 -->

When calculating alarm likelihood (i.e. focus score), up to now, the alarm focus feature used a combination of element ID, parameter ID and display key (if applicable) to identify previous occurrences of the same alarm. From now on, previous alarm occurrences will be identified using a combination of element ID, parameter ID and primary key.

> [!NOTE]
> When you upgrade to version 10.4.0/10.4.3, the Cassandra table *analytics_alarmfocus* will automatically be removed.

#### SLNetClientTest tool: Message builder now allows creating an instance of an abstract type or interface [ID_38236]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

The message builder in the SLNetClientTest tool allows you to build SLNet messages from scratch, filling out values for the properties in `DMSMessage` objects.

Up to now, if these properties were for an abstract type or interface, it was not possible to fill out a value. From now on, it will be possible to select a concrete type, create an instance, and edit the properties of that object.

#### DataMiner Object Models: Required list fields can no longer be set to an empty list [ID_38238]

<!-- MR 10.5.0 - FR 10.4.3 -->

From now on, when the value of a required list field is set to an empty list, one of the following errors will be thrown:

- `DomInstanceHasMissingRequiredFieldsForCurrentStatus` (when using the DOM status system)
- `DomInstanceDoesNotContainAllRequiredFieldsForSectionDefinition` (when not using the DOM status system)

#### DataMiner Object Models: HistoryChanges will now be processed in bulk [ID_38241]

<!-- MR 10.5.0 - FR 10.4.3 -->

Up to now, if history storage was enabled, when DomInstances were created, updated or deleted, a HistoryChange operation would be executed for every DomInstance separately.

From now on, for every batch of DomInstances that are processed in bulk, the history records will also be processed in bulk.

#### Security enhancements [ID_38263] [ID_38386]

<!-- 38263: MR 10.5.0 - FR 10.4.3 -->
<!-- 38386: MR 10.3.0 [CU12] - FR 10.4.3 -->

A number of security enhancements have been made.

#### Failover: NATS nodes will now advertise their physical IP address instead of their virtual IP address [ID_38340]

<!-- MR 10.4.0 - FR 10.4.3 -->

From now, NATS nodes will advertise their physical IP address instead of their virtual IP address.

#### SLAnalytics - Behavioral anomaly detection: Enhanced accuracy [ID_38383]

<!-- MR 10.4.0 - FR 10.4.3 -->

The accuracy of the behavioral change points and anomalies detected by the behavioral anomaly detection feature has been improved.

From now on, a behavioral change will only be taken into account when the change is larger than the data precision used to display the data in DataMiner Cube.

As a result, anomalies that report a trend change "from 0%/day to 0%/day", a level shift from "0.1 to 0.1", etc. will no longer be taken into account.

#### SLProtocol will now always fetch element data page by page except on systems with a MySQL database [ID_38388]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

From now on, SLProtocol will always fetch element data page by page, except on systems with a MySQL database.

On systems with a MySQL database, SLProtocol will continue to fetch element data by parameter ID.

#### SLProtocol will no longer log messages related to duplicate keys at the default log levels [ID_38392] [ID_38517]

<!-- MR 10.4.0 - FR 10.4.3 -->

When SLProtocol identifies duplicate keys, it will no longer flood the error log with messages related to duplicate keys (e.g. `Duplicate key in table 1000, key = 123`) at the default log levels.

From now on, if you want to have log entries related to duplicate keys, increase the error log level to 1.

> [!NOTE]
> When polling via SNMP, duplicate keys will only be logged when error log level is set to 1. When using FillArray in a QAction, duplicate keys will always be logged regardless of error log level.

#### DataMiner upgrade: SLAnalytics upgrade actions now support Cassandra connections with TLS [ID_38393]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

DataMiner upgrade actions related to SLAnalytics features now also support Cassandra connections with TLS.

#### User-Defined APIs: Maximum size of HTTP response body has been reduced to 29MB [ID_38397]

<!-- MR 10.4.0 - FR 10.4.3 -->

As of version 10.4.1, the maximum size of the HTTP request body is 29 MB. Now, also the maximum size of the HTTP response body has been reduced to 29 MB.

#### SLAnalytics - Behavioral anomaly detection: Enhanced accuracy [ID_38400]

<!-- MR 10.4.0 - FR 10.4.3 -->

Change point detection accuracy has been improved for parameters that have a discreet trend data behavior.

For parameters of which the trend data behavior is mostly stable, with only infrequent sudden value changes, only behavioral changes that are larger than those infrequent sudden value changes will be taken into account.

#### SLAnalytics: Trend data pattern records will no longer be deleted from the database [ID_38407]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

From now on, trend data pattern records will no longer be deleted from the Elasticsearch/OpenSearch database.

#### GQI: Enhanced performance when executing 'Get parameters from elements' queries for parameter tables [ID_38460]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

When a *Get parameters from elements* query is executed for a parameter table, from now on, the table sessions that are used to resolve those tables in parallel will be closed asynchronously.

As a result, overall performance of clients like the Dashboards app or a low-code app will significantly increase when executing this type of queries.

#### User-Defined APIs: Enhanced logging [ID_38491]

<!-- MR 10.5.0 - FR 10.4.3 -->

Up to now, when a user-defined API was triggered, log entries like the ones below would only be added to the *SLUserDefinableApiManager.txt* file when the log level was set to 5. From now on, when a user-defined API is triggered, these entries will be added to *SLUserDefinableApiManager.txt* when the log level is set to 0 (i.e. always).

```txt
2024/01/18 10:13:00.740|SLNet.exe|Handle|CRU|0|152|[1f9cd6c045] Started handling API trigger from NATS for route 'dma/id_2'.
2024/01/18 10:13:01.268|SLNet.exe|Handle|CRU|0|152|[1f9cd6c045] Handling API trigger from NATS for route 'dma/id_2' SUCCEEDED after 526.46 ms. API script provided response code: 200. (Token ID: 78dd7916-6d01-4c17-9010-530c28338120)
```

#### DxMs upgraded [ID_38499]

<!-- MR 10.5.0 - FR 10.4.3 -->

The following DataMiner Extension Modules (DxMs), which are included in the DataMiner upgrade package, have been upgraded to the indicated versions:

- DataMiner ArtifactDeployer: version 1.6.4.14010
- DataMiner CoreGateway: version 2.13.4.14181
- DataMiner FieldControl: version 2.10.3.14011
- DataMiner Orchestrator: version 1.5.3.14012
- DataMiner SupportAssistant: version 1.6.4.14013

For detailed information about the changes included in those versions, refer to the [dataminer.services change log](xref:DCP_change_log).

#### SLAnalytics - Proactive cap detection: Enhanced accuracy [ID_38508]

<!-- MR 10.4.0 - FR 10.4.3 -->

The accuracy of proactive cap detection events (i.e. forecasted alarms) reporting data range violations has been improved.

#### SLAnalytics - Behavioral anomaly detection: Enhanced detection of change points of type flatline [ID_38528]

<!-- MR 10.4.0 - FR 10.4.3 -->

Change point detection accuracy has been improved for change points of type flatline.

### Fixes

#### DataMiner installer: Some modules would not get installed while performing a full installation of a new DMA [ID_37719]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

Up to now, when you ran the DataMiner installer to install a new DataMiner Agent using a DataMiner upgrade package, some modules would incorrectly not get installed as they were configured to only be installed when upgrading an existing DataMiner Agent.

From now on, when you run the DataMiner installer to install a new DataMiner Agent using a DataMiner upgrade package, all installation steps will be performed, including the upgrade actions.

#### Web apps: Visual overview linked to a view would not get any updates when the user did not have full administrative rights [ID_38180]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU12]/10.4.0 [CU0] - FR 10.4.3 -->

When a web app user without full administrative rights viewed a visual overview linked to a view, the app would incorrectly not receive any updates for that visual overview.

#### DataMiner clients using a gRPC connection would not always detect a disconnect [ID_38215]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

In some cases, DataMiner clients using a gRPC connection would not detect a disconnect.

#### DataMiner Cube was not able to reconnect to the server after a disconnect using gRPC [ID_38260]

<!-- MR 10.4.0 - FR 10.4.3 -->

Up to now, when using a gRPC connection, Cube was not able to verify whether the server endpoint was available. As a result, it would fail to reconnect to the server when the connection had been lost and would display a `Waiting for the connection to become available...` message indefinitely.

#### Correlation: Alarm buckets would not get cleaned up when alarms were cleared before the end of the time frame specified in the 'Collect events for ... after first event, then evaluate conditions and execute actions' setting [ID_38292]

<!-- MR 10.3.0 [CU12]/10.4.0 [CU0] - FR 10.4.3 -->

Up to now, when alarms were cleared before the end of the time frame specified in the *Collect events for ... after first event, then evaluate conditions and execute actions* correlation rule setting, the alarm buckets would not get cleaned up.

From now on, when a correlation rule is configured to use the *Collect events for ... after first event, then evaluate conditions and execute actions* trigger mechanism, all alarm buckets will be properly cleaned up, unless there are actions that need to be executed either when the base alarms are updated or when alarms are cleared.

#### Automation: Script data cleanup routine could cause an error to occur [ID_38370]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

In some rare cases, a cleanup routine within SLAutomation could prematurely clean up data of scripts that had not yet finished, causing an error to occur.

#### Automation: Problem when empty data is passed to the UI parser when running an interactive Automation script [ID_38408]

<!-- MR 10.3.0 [CU12]/10.4.0 [CU0] - FR 10.4.3 -->

When running an interactive Automation script that was launched from Cube or a web app, in some cases, an exception could be thrown when empty data was passed to the UI parser.

From now on, an exception will no longer be thrown when empty data is passed to the UI parser.

#### DataMiner upgrade: Problem with AnalyticsParameterInfoRecordAddChangeRate upgrade action on systems with a Cassandra Cluster database [ID_38443]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

During a DataMiner upgrade, the *AnalyticsParameterInfoRecordAddChangeRate* upgrade action executes an *Alter Table* command on every DataMiner Agent in the cluster. Up to now, when you upgraded a DataMiner System with a Cassandra Cluster database, that *Alter Table* command would incorrectly only get executed on the first DMA that called it. On each subsequent DMA that called the command, errors would get thrown and added to the *upgrade.log* file.

#### DataMiner Cube was not able to reconnect to the server after a disconnect [ID_38481]

<!-- MR 10.4.0 - FR 10.4.3 -->

In some cases, DataMiner Cube would not be able to reconnect to the server after having been disconnected.

#### Alarm filters would not be properly serialized when using a gRPC connection [ID_38507]

<!-- MR 10.3.0 [CU12] - FR 10.4.3 -->

When a client application was connected to a DataMiner Agent via a gRPC connection, in some cases, the alarm filters it received from the DataMiner Agent would not be properly serialized.

#### SLAnalytics - Behavioral anomaly detection: Certain parameter value changes would incorrectly not get processed [ID_38545]

<!-- MR 10.5.0 - FR 10.4.3 -->

When SLAnalytics was handling large amounts of traffic, in some cases, certain parameter value changes would incorrectly not get processed.

Also, a large number of low-severity change points were generated without a label. Those have now been reduced.
