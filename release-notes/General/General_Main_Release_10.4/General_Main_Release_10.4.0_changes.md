---
uid: General_Main_Release_10.4.0_changes
---

# General Main Release 10.4.0 – Changes (preview)

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## Changes

### Enhancements

#### SLXML no longer used to read out element data [ID_33515] [ID_33616] [ID_33625] [ID_33659]

<!-- MR 10.4.0 - FR 10.3.4 -->

From now on, SLXML will no longer be used to read out the following files containing element data:

- *Element.xml* files
- *ElementData.xml* files
- *EPMConfig.xml* files
- *Description.xml* files
- *Ports.xml* files

> [!IMPORTANT]
> This is a breaking change. Make sure that none of the protocols in your system is using the following deprecated Notify types:
>
> - DMS_GET_INFO
> - DMS_GET_INFO_ALL
> - NT_ADD_DESCRIPTION_FILE
> - NT_GET_ITEM_DATA
> - NT_GET_PARAMETER_BY_DATA
> - NT_GET_XML_COOKIE
> - NT_RELOAD_ELEMENT
> - NT_SET_ITEM_DATA
> - NT_SET_PARAMETER_BY_DATA

#### More detailed logging when the certificate chain is invalid while connecting to Cassandra [ID_34822]

<!-- MR 10.4.0 - FR 10.3.2 -->

More detailed information will now be added to the `SLDBConnection.txt` log file when the certificate chain is invalid while connecting to Cassandra.

Log entry syntax: `Certificate chain error: {chainStatus.Status}, details: {chainStatus.StatusInformation}`

#### SLAnalytics - Proactive cap detection: Enhanced accuracy when generating alarm predictions [ID_35080]

<!-- MR 10.4.0 - FR 10.3.2 -->

Because of a number of enhancements, overall accuracy has increased when generating alarm predictions.

#### DataMiner Object Models: DomInstanceButtonDefinitions can only reference a single action [ID_35156]

<!-- MR 10.4.0 - FR 10.3.2 -->

From now on, DomInstanceButtonDefinitions can only reference a single action. If multiple actions are defined, a `DomBehaviorDefinitionError` with reason `InvalidButtonActionCombination` will be returned.

Also, when using the DomBehaviorDefinition inheritance system, the server-side logic will now make sure that there are no buttons or actions with identical IDs on both the parent and child definition.

- If a duplicate action is found, a `DomBehaviorDefinitionError` with reason `DuplicateActionDefinitionIds` will be returned.
- If a duplicate button is found, a `DomBehaviorDefinitionError` with reason `DuplicateButtonDefinitionIds` will be returned.

#### SLLogCollector: Custom CollectorConfig XML files will now be synchronized across the DataMiner cluster [ID_35180]

<!-- MR 10.4.0 - FR 10.3.2 -->

From now on, all custom CollectorConfig XML files will be synchronized across the DataMiner cluster.

#### SLAnalytics - Pattern matching: Manually created tags will now be saved as pattern occurrences [ID_35299]

<!-- MR 10.4.0 - FR 10.3.3 -->

From now on, when you define a tag for pattern matching, the pattern you selected will be saved as a pattern occurrence in the Elasticsearch database and highlighted in bright orange, similar to so-called "streaming matches", which are detected while tracking for trend patterns whenever a trended parameter is updated.

#### SLDataGateway: Memory enhancements with regard to average trending [ID_35312]

<!-- MR 10.4.0 - FR 10.3.3 -->

In the SLDataGateway process, a number of memory enhancements have been made with regard to the management of average trend data.

#### Maps: Markers will now move more gradual when zooming [ID_35337]

<!-- MR 10.4.0 - FR 10.3.3 -->

Because of a number of enhancements, markers will now move more gradual when zooming.

#### Alarm templates - Smart baseline calculations: NullReferenceException prevented & enhanced exception logging [ID_35348]

<!-- MR 10.4.0 - FR 10.3.3 -->

In some cases, a `Baseline Calculation Failed: System.NullReferenceException: Object reference not set to an instance of an object` error would be added to the *SLSmartBaselineManager.txt* log file. The issue causing that error has now been fixed.

Also, log entries indicating an exception thrown during baseline calculations will now include details regarding the element and parameter associated with the exception.

#### Maps: Enhanced zooming behavior [ID_35351]

<!-- MR 10.4.0 - FR 10.3.3 -->

From now on, when you zoom in or out, the data of the previous zoom level will stay visible until the data of the current zoom level has been loaded.

#### DataMiner upgrade: Installation of Microsoft .NET 6.0 [ID_35363]

<!-- MR 10.4.0 - FR 10.3.3 -->

During a DataMiner upgrade, Microsoft .NET 6.0 will now be installed if not installed already.

#### Maps: Zoom range can now be set by means of a slider [ID_35381]

<!-- MR 10.4.0 - FR 10.3.3 -->

The zoom range of a map can now be set by means of a slider.

#### SLAnalytics - Automatic incident tracking: Enhanced performance when fetching relation information [ID_35414] [ID_35508]

<!-- 35414:  MR 10.4.0 - FR 10.3.3 -->
<!-- 35508:  MR 10.4.0 - FR 10.3.4 -->

Because of a number of enhancements, overall performance has increased when fetching relation information for the automatic incident tracking feature.

#### Security enhancements [ID_35434]

<!-- MR 10.4.0 - FR 10.3.4 -->

A number of security enhancements have been made.

#### SLAnalytics - Behavioral anomaly detection: No longer available for discrete parameters [ID_35465]

<!-- MR 10.4.0 - FR 10.3.3 -->

From now on, anomaly detection will no longer be available for discrete parameters.

#### SLAnalytics - Pattern matching: Enhanced performance when detecting large patterns [ID_35474]

<!-- MR 10.4.0 - FR 10.3.4 -->

Because of a number of enhancements, overall performance has increased when detecting trend patterns that cover more than 30,000 data points.

#### Support for GQI queries from Data Aggregator with ad hoc data sources [ID_35526]

<!-- MR 10.4.0 - FR 10.3.3 -->

GQI now supports queries from [Data Aggregator](xref:Data_Aggregator_DxM) that use ad hoc data sources.

#### SLAnalytics will now send regular notifications instead of client notifications [ID_35591]

<!-- MR 10.4.0 - FR 10.3.4 -->

Up to now, when SLAnalytics sent a notification, it would generate an event of type *client notification* with parameter ID 64574. From now on, it will instead generate an event of type *notification* with parameter ID 64570.

#### GQI: Raw datetime values will now be converted to UTC [ID_35640]

<!-- MR 10.4.0 - FR 10.3.4 -->

Up to now, after each step in a GQI query, raw datetime values were always converted to the time zone that was specified in the query options. From now on, raw datetime values will be converted to UTC instead. The time zone specified in the query options will now only be used when converting a raw datetime value to a display value.

> [!IMPORTANT]
> **BREAKING CHANGE**: When, in an ad hoc data source or a query operation, a datetime value is not in UTC format, an exception will now be thrown.

#### SLAnalytics - Proactive cap detection: Enhanced accuracy [ID_35695]

<!-- MR 10.4.0 - FR 10.3.4 -->

Proactive cap detection predicts future issues based on trend data in the Cassandra database. Because of a number of enhancements, overall prediction accuracy has increased.

#### Service & Resource Management: Bookings of type 'Custom Process Automation' no longer consume license credits [ID_35742]

<!-- MR 10.4.0 - FR 10.3.4 -->

From now on, ReservationInstances of type *Custom Process Automation* will no longer consume SRM credits. This means that, from now on, you can schedule an unlimited number of concurrent bookings of type *Custom Process Automation*.

#### SLAnalytics: A message will be added to the SLAnalytics.txt log file when no Cassandra database is present [ID_35748]

<!-- MR 10.4.0 - FR 10.3.5 -->

Up to now, SLAnalytics would stop working without giving any notice whatsoever when it was started on a system without a Cassandra database.

From now on, when no Cassandra database is present, SLAnalytics will be stopped gracefully and a message will be added to the *SLAnalytics.txt* log file.

### Fixes

#### Cassandra Cluster: Every DMA would incorrectly try to delete any possible old Cassandra compaction and repair tasks found in the entire DMS [ID_31923]

<!-- MR 10.4.0 - FR 10.3.3 -->

At start-up, every DataMiner Agent with a Cassandra Cluster configuration would incorrectly try to delete any possible old Cassandra compaction and repair tasks found in the entire DMS.

From now on, at start-up, every DataMiner Agent with a Cassandra Cluster configuration will only delete the old Cassandra compaction and repair tasks found locally.

#### Problem with Resource Manager when ResourceStorageType was not specified in Resource Manager settings [ID_34981]

<!-- MR 10.4.0 - FR 10.3.1 -->

In some cases, Resource Manager could throw a NullReferenceException when *ResourceStorageType* was not specified in the `C:\Skyline DataMiner\ResourceManager\Config.xml` file.

#### External authentication via SAML: Issues fixed when using Okta as identity provider [ID_35374]

<!-- MR 10.4.0 - FR 10.3.3 -->

Using Okta as identity provider, it would incorrectly no longer be possible to read out signed assertions. Also, when the group claim setting is enabled in the *DataMiner.xml* file, the user will now be added to the correct groups.

Up to now, in case of a claim mismatch, an exception would be thrown. From now on, an entry containing a clear message will be added to the *SLNet.txt* log file instead.

#### NATS would incorrectly be re-installed when a WMI query error occurred while the NATS installer was being run at DMA startup [ID_35647]

<!-- MR 10.4.0 - FR 10.3.5 -->

When the NATS installer was being run at DMA startup, in some cases, due to an issue with a WMI query, NATS could incorrectly be re-installed, even though NATS and NAS were already running.

From now on, the execution of the NATS installer at DMA startup will be skipped when NATS is already running. Also, if an error occurs when running a WMI query during the execution of the NATS installer, a message saying that the re-installation has failed will be added to the *SLUMSEndpointManager.txt* log file.

> [!NOTE]
> When an error occurs while running a WMI query, and no NATS/NAS service is running, NATS will not be installed automatically. A manual installation of NATS will be needed.

#### Cassandra Cluster Migrator tool would incorrectly not migrate the state-changes table from a single-node Cassandra to a Cassandra Cluster [ID_35699]

<!-- MR 10.4.0 - FR 10.3.4 -->

When you used the Cassandra Cluster Migrator tool to migrate a single-node Cassandra database to a Cassandra Cluster setup, up to now, the `state-changes` table would incorrectly not be migrated.

#### Automation: DataMiner would incorrectly remove the xmlns attribute when importing or saving an Automation script [ID_35708]

<!-- MR 10.4.0 - FR 10.3.4 -->

When DataMiner imported or saved an Automation script, it would incorrectly remove the `xmlns` attribute specified in the `<DMSScript>` element, even when that attribute had been added by DataMiner Integration Studio. From now on, when DataMiner imports or saves an Automation script, it will no longer remove this attribute. Moreover, if no such attribute is specified, it will automatically add `xmlns="http://www.skyline.be/automation"`.

Example:

```xml
<DMSScript options="272" xmlns="http://www.skyline.be/automation">
   <Name>...</Name>
   ...
</DMSScript>
```
