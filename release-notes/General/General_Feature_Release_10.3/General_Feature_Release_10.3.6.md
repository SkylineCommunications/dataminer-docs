---
uid: General_Feature_Release_10.3.6
---

# General Feature Release 10.3.6 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.3.6](xref:Cube_Feature_Release_10.3.6).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.3.6](xref:Web_apps_Feature_Release_10.3.6).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been added to this release yet.*

## Other features

#### DataMiner installation/upgrade: Automatic installation of DataMiner Extension Modules [ID_36085]

<!-- MR 10.4.0 - FR 10.3.6 -->

When you install or upgrade a DataMiner Agent, the following DataMiner Extension Modules (DxMs) will now automatically be installed (if not present yet):

- DataMiner ArtifactDeployer (version 1.4.3)
- DataMiner CloudFeed (version 1.0.8)
- DataMiner CloudGateway (version 2.10.4)
- DataMiner CoreGateway (version 2.12.1)
- DataMiner FieldControl (version 2.8.2)
- DataMiner Orchestrator (version 1.2.6)
- DataMiner SupportAssistant (version 1.3.0)

> [!NOTE]
> For detailed information on the changes included in the different versions of these DxMs, refer to the [dataminer.services change log](xref:DCP_change_log).

## Changes

### Enhancements

#### DataMiner Object Models: Enhanced performance when reading DOM objects and ModuleSettings [ID_35934]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

Because of a number of enhancements, overall performance has increased when reading DOM objects and ModuleSettings.

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

#### SLAnalytics: Trend data predictions displayed in trend graphs will be more accurate [ID_36038]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

Because of a number of enhancements with regard to the detection of periodic behavior in trend data, the trend data predictions displayed in trend graphs will be more accurate.

#### SLAnalytics - Trend prediction: Enhanced trend prediction verification [ID_36102]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

The verification of trend predictions has been enhanced.

### Fixes

#### DataMiner Agent was not able to connect to the Cassandra database due to a problem with the TLS certificate [ID_35895]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

When a DataMiner Agent was restarted after its database had been configured to use TLS, in some cases, it would not be able to connect to its Cassandra database due to a problem with the TLS certificate validation.

#### Updating a Resource or ResourcePool would incorrectly cause the 'CreatedAt' and 'CreatedBy' fields to be overwritten [ID_35913]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

When a Resource or ResourcePool was updated, the *CreatedAt* and *CreatedBy* fields would incorrectly be overwritten.

#### NATS-related error: 'Failed to copy credentials from [IP address] - corrupt zip file' [ID_35935]

<!-- MR 10.4.0 - FR 10.3.6 -->

In some rare cases, the following NATS-related error would be thrown:

```txt
Failed to copy credentials from [IP address] - corrupt zip file
```

#### Improved error handling when elements go into an error state [ID_35944] [ID_36198]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

When an element goes into an error state after an attempt to activate it failed, from now on, no more calls to SLProtocol, SLElement or SLSpectrum will be made for that element.

Also, when an element that generates DVE child elements or virtual functions goes into an error state, from now on, the generated DVE child elements or virtual functions will also go into an error state. However, in order to avoid too many alarms to be generated, only one alarm (for the main element) will be generated.

The following issues have also been fixed:

- When a DVE parent element in an error state on DataMiner startup was activated, its DVE child elements or virtual functions would not be properly loaded.

- When a DVE parent element was started, the method that has to make sure that ElementInfo and ElementData are in sync would incorrectly not check all child elements.

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

<!-- MR 10.4.0 - FR 10.3.6 -->

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

#### DataMiner Object Models: Problem when creating a DomInstance with an empty status [ID_36063]

<!-- MR 10.4.0 - FR 10.3.6 -->

When a DomInstance was created with an empty status, in some cases, a `MultipleSectionsNotAllowedForSectionDefinition` error could be returned, even when the configuration was correct.

#### New SLScripting processes would incorrectly be created when using 'SeparateProcesses' [ID_36133]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

When the *DataMiner.xml* file contained `<ProcessOptions protocolProcesses="5" scriptingProcesses="protocol">` either in combination with `<SeparateProcesses>` or with `<RunInSeparateInstance>true</RunInSeparateInstance>` specified in the *protocol.xml* file, every time an element of a separate protocol restarted, a new SLScripting process would be created and the previous SLScripting process would not be stopped.

#### Errors would incorrectly state that OpenSearch 2.4 and 2.5 were not supported [ID_36137]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

Although DataMiner supports all OpenSearch 1.x and 2.x versions, in some cases, errors stating that OpenSearch 2.4 and 2.5 were not officially supported would incorrectly be added to the *SLDBConnection.txt* and *SLSearch.txt* log files.

#### DataMiner Backup: Low-code apps would incorrectly not be restored [ID_36139]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

When you restored a DataMiner backup that included low-code apps, those apps would incorrectly not be restored.
