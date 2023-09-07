---
uid: General_Main_Release_10.3.0_CU3
---

# General Main Release 10.3.0 CU3

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### DataMiner upgrade: Installation of Microsoft .NET 6.0 [ID_35363]

<!-- MR 10.3.0 [CU3] - FR 10.3.3 -->

During a DataMiner upgrade, Microsoft .NET 6.0 will now be installed if not installed already.

#### DataMiner Object Models: Enhanced performance when reading DOM objects and ModuleSettings [ID_35934]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

Because of a number of enhancements, overall performance has increased when reading DOM objects and ModuleSettings.

#### Improved error handling when elements go into an error state [ID_35944] [ID_36198]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

When an element goes into an error state after an attempt to activate it failed, from now on, no more calls to SLProtocol, SLElement or SLSpectrum will be made for that element.

Also, when an element that generates DVE child elements or virtual functions goes into an error state, from now on, the generated DVE child elements or virtual functions will also go into an error state. However, in order to avoid too many alarms to be generated, only one alarm (for the main element) will be generated.

The following issues have also been fixed:

- When a DVE parent element in an error state on DataMiner startup was activated, its DVE child elements or virtual functions would not be properly loaded.

- When a DVE parent element was started, the method that has to make sure that ElementInfo and ElementData are in sync would incorrectly not check all child elements.

#### SLLogCollector now also collects SyncInfo files [ID_35995]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

SLLogCollector packages will now also include all files found in `C:\Skyline DataMiner\Files\SyncInfo` relevant for troubleshooting.

#### Service & Resource Management: An error will now be thrown when an SRM event has been stuck for more than 15 minutes [ID_36013]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

When an SRM event has been stuck for more than 15 minutes, the following run-time error will now appear in the Alarm Console:

```txt
Thread problem in SLNet: SRM event thread for booking with id <booking id>
```

This error will also be added to the *SLWatchDog2.txt* log file.

> [!NOTE]
>
> - This run-time error will appear when a custom booking event script that was configured to run synchronously has been running for more than 15 minutes. We highly recommend configuring custom booking events to run asynchronously. For more information, see [Service Orchestration custom events configuration](xref:Service_Orchestration_custom_events).
> - Half-open run-time errors (which are thrown after an SRM event has been stuck for more than 7.5 minutes) will also be added to the *SLWatchDog2.txt* log file.

#### DataMiner upgrades and downgrades can now be performed over gRPC [ID_36023]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

DataMiner upgrades and downgrades can now be performed over gRPC.

To make gRPC the default communication method, do the following on every DataMiner Agent in the cluster:

- To make gRPC the default communication method for **client-server communication**, modify [ConnectionSettings.txt](xref:ConnectionSettings_txt).

- To make gRPC the default communication method for **server-server communication**, do one of the following:

  - Disable *.NET Remoting* in [MaintenanceSettings.xml](xref:MaintenanceSettings_xml) by adding `<EnableDotNetRemoting>false</EnableDotNetRemoting>` to the `<SLNet>` section.
  
  OR
  
  - Add explicit `<Redirect>` tags in [DMS.xml](xref:DMS_xml).

> [!NOTE]
>
> - *.NET Remoting* remains the default communication method for both client-server and server-server communication.
> - Certain connectors and Automation scripts still rely on having the *.NET Remoting* port 8004 open.

#### SLAnalytics: Trend data predictions displayed in trend graphs will be more accurate [ID_36038]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

Because of a number of enhancements with regard to the detection of periodic behavior in trend data, the trend data predictions displayed in trend graphs will be more accurate.

#### SLAnalytics - Trend prediction: Enhanced trend prediction verification [ID_36102]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

The verification of trend predictions has been enhanced.

#### SLAnalytics - Behavioral anomaly detection: Enhanced detection of behavioral changes after a gap in the trend data [ID_36186]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

A number of enhancements have been made with regard to the automatic detection of behavioral changes in trend data of trended parameters.

Up to now, in some cases, level shifts and trend changes would remain unlabeled when they occurred immediately after a gap in the trend data.

#### ConnectionSettings.txt: type=RemotingConnection now obsolete [ID_36196]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

In the *ConnectionSettings.txt* file, the **type=** setting defines the default connection method to be used by DataMiner client applications.

One of its values, "RemotingConnection", is now obsolete. If you continue to use this value, we are planning to soon have DataMiner automatically switch to *GRPCConnection* when you upgrade. If you do not want to use *GRPCConnection*, use *LegacyRemotingConnection* to avoid getting automatically switched. However, note that we strongly recommend using *GRPCConnection*.

#### API Gateway module now targets Microsoft .NET 6.0 [ID_36238]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

As Microsoft .NET 5 is being phased out, the *API Gateway* module will now use Microsoft .NET 6.0 instead.

#### Element replication is now able to use gRPC [ID_36262]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

Element replication will now automatically detect the connection settings of the target DMA and will use gRPC when the connection type is set to "GPRCConnection".

#### Failover on RTE now also supports DMAs that communicate using gRPC [ID_36267]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

In the *MaintenanceSettings.xml* file, SLWatchDog can be configured to trigger a Failover switch when it detects a run-time error in a critical process on the active Agent of a Failover pair. From now on, this *Failover on RTE* feature will also support Agents that communicate using gRPC.

#### SLNetClientTest tool now supports gRPC when it needs to establish additional connections [ID_36279]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

The *SLNetClientTest* tool now supports gRPC when it needs to establish additional connections to remote DataMiner Agents.

> [!WARNING]
> Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

### Fixes

#### Cassandra Cluster: Every DMA would incorrectly try to delete any possible old Cassandra compaction and repair tasks found in the entire DMS [ID_31923]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU3] - FR 10.3.3 -->

At start-up, every DataMiner Agent with a Cassandra Cluster configuration would incorrectly try to delete any possible old Cassandra compaction and repair tasks found in the entire DMS.

From now on, at start-up, every DataMiner Agent with a Cassandra Cluster configuration will only delete the old Cassandra compaction and repair tasks found locally.

#### Cassandra Cluster Migrator tool would incorrectly not migrate the state-changes table from a single-node Cassandra to a Cassandra Cluster [ID_35699]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.4 -->

When you used the Cassandra Cluster Migrator tool to migrate a single-node Cassandra database to a Cassandra Cluster setup, up to now, the `state-changes` table would incorrectly not be migrated.

#### DataMiner Agent was not able to connect to the Cassandra database due to a problem with the TLS certificate [ID_35895]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

When a DataMiner Agent was restarted after its database had been configured to use TLS, in some cases, it would not be able to connect to its Cassandra database due to a problem with the TLS certificate validation.

#### Updating a Resource or ResourcePool would incorrectly cause the 'CreatedAt' and 'CreatedBy' fields to be overwritten [ID_35913]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

When a Resource or ResourcePool was updated, the *CreatedAt* and *CreatedBy* fields would incorrectly be overwritten.

#### Problem after offloading element data to Elasticsearch [ID_35962]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

When element data had been offloaded to Elasticsearch via a logger table, after restarting the element, the Elasticsearch table could not be populated.

#### Creating or updating a function resource while its parent element was in an error state would incorrectly be allowed [ID_35963]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

When you created or updated a function resource while its parent element was in an error state, up to now, the state of that parent element would not be checked correctly. As a result, adding or updating the function resource would incorrectly be allowed.

From now on, when you create or update a function resource while its parent element is in an error state, an error will be thrown.

#### Business Intelligence: Problem when a replicated SLA was stopped or deleted [ID_35973]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

In some cases, an error could occur when a replicated SLA was stopped or deleted.

#### Cassandra: Cleared alarms would incorrectly be added to the activealarms table and never removed [ID_36002]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

Cleared alarms would incorrectly be added to the activealarms table and never removed.

#### Spectrum analysis: Measurement points would not be set correctly [ID_36005]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

In some cases, measurement points would not be set correctly when a trace was being displayed.

#### Virtual functions linked to a parameter with a hysteresis timer could be assigned an incorrect alarm severity [ID_36024]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

When a virtual function was linked to a parameter that had a hysteresis timer running, in some cases, that virtual function would be assigned an incorrect alarm severity.

#### NT Notify type NT_GET_BITRATE_DELTA would return incorrect values [ID_36025]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

In some cases, NT Notify type NT_GET_BITRATE_DELTA (269) would return incorrect bitrate counter values when an SNMPv3 element was going into or coming out of a timeout state.

#### SLReset.exe would not clean an Elasticsearch database when no <DB> element was specified in DB.xml [ID_36040]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

When, in the *DB.xml* file, no `<DB>` element was specified for an Elasticsearch database, the factory reset tool *SLReset.exe* would not clean that database when the `cleanclustereddatabases` option had been used.

From now on, when no `<DB>` element is specified for a Elasticsearch database, *SLReset.exe* will use the default database name "dms".

#### Memory leak in SLSPIHost [ID_36041]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

In some cases, the SLSpiHost process could leak memory.

#### SLAnalytics - Behavioral anomaly detection: No flatline stop events would be generated when an element was deleted [ID_36050]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

When an element was deleted, no flatline stop events would be generated for parameters of that element.

#### Business Intelligence: Alarms that had to be replayed would incorrectly have their weight recalculated [ID_36051]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

When an SLA has to process alarms generated due to history sets or alarms generated with hysteresis enabled, those alarms are replayed to ensure that the outages contain the correct information.

Up to now, when an alarm was fetched from a logger table in order to be replayed, the system would incorrectly recalculate its weight instead of taking into account its previously calculated weight stored in the logger table.

> [!NOTE]
> When you change an SLA's violation settings, offline windows, etc., we recommend resetting that SLA as the alarm weights of previously processed alarms will not be recalculated retroactively.

#### New SLScripting processes would incorrectly be created when using 'SeparateProcesses' [ID_36133]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

When the *DataMiner.xml* file contained `<ProcessOptions protocolProcesses="5" scriptingProcesses="protocol">` either in combination with `<SeparateProcesses>` or with `<RunInSeparateInstance>true</RunInSeparateInstance>` specified in the *protocol.xml* file, every time an element of a separate protocol restarted, a new SLScripting process would be created and the previous SLScripting process would not be stopped.

#### Errors would incorrectly state that OpenSearch 2.4 and 2.5 were not supported [ID_36137]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

Although DataMiner supports all OpenSearch 1.x and 2.x versions, in some cases, errors stating that OpenSearch 2.4 and 2.5 were not officially supported would incorrectly be added to the *SLDBConnection.txt* and *SLSearch.txt* log files.

#### Problem with BPA test 'Cassandra DB Size' [ID_36138]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

Up to now, the BPA test *Cassandra DB size* would spawn a number of cmd processes meant to be executed by the Cassandra nodetool utility without checking whether nodetool was running. When nodetool was not running, these cmd processes would not get cleaned up.

#### DataMiner Backup: Low-code apps would incorrectly not be restored [ID_36139]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

When you restored a DataMiner backup that included low-code apps, those apps would incorrectly not be restored.

#### Problem when multiple clients had subscribed to a cell of a partial table [ID_36148]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

When multiple clients had subscribed to a cell of a partial table, in some cases, deleting the row or renaming the row via a display key would not trigger a deletion of the cell in the subscription.

#### Problem when retrieving alarm events from Cassandra Cluster after an element restart [ID_36177]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 [CU0] -->

When an element that had more than 10,000 alarm events stored on a Cassandra cluster was restarted, those alarm events would not all get retrieved from the database. As a result, SLElement would generate additional alarm events, causing the alarm trees to become incorrect.

#### Inaccessible logger table data in Elasticsearch because of incorrect casing [ID_36343]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 [CU0] -->

Since DataMiner versions 10.3.0/10.3.3, if a logger table that had `Indexing` set to true contained column names with uppercase characters, *SLDataGateway* would incorrectly change these column names to lower case. This lead to the data getting stored in a different field than expected and therefore not being retrieved when requested.

For more information on this issue, see [Inaccessible logger table data in Elasticsearch because of incorrect casing](xref:KI_Inaccessible_data_Elasticsearch_casing)
