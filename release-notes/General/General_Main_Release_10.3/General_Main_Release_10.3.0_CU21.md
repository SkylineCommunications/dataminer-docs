---
uid: General_Main_Release_10.3.0_CU21
---

# General Main Release 10.3.0 CU21

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Main Release 10.3.0 CU21](xref:Cube_Main_Release_10.3.0_CU21).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.3.0 CU21](xref:Web_apps_Main_Release_10.3.0_CU21).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Security enhancements [ID 40684]

<!-- MR 10.3.0 [CU21]/10.4.0 [CU9] - FR 10.4.12 -->

A number of security enhancements have been made.

#### NT Notify types NT_ADD_VIEW_NO_LOCK and NT_ADD_VIEWS_NO_LOCK have been deprecated [ID 40928]

<!-- MR 10.3.0 [CU21]/10.4.0 [CU9] - FR 10.4.12 -->

The following NT Notify types have been deprecated:

- NT_ADD_VIEW_NO_LOCK
- NT_ADD_VIEWS_NO_LOCK

#### SLXML: Enhanced error when erroneous XML code is received [ID 40995]

<!-- MR 10.3.0 [CU21]/10.4.0 [CU9] - FR 10.4.12 -->

Up to now, when SLXML received erroneous XML code, the error message logged in *SLXML.txt* would lose vital information when it was trimmed by SLLog due to the 5120-character error message size limit. The error message in question has now been adapted so that the most important information is found at the beginning.

#### SLLogCollector will no longer be configured by default to collect the log files of the CommunicationGateway DxM [ID 41004]

<!-- MR 10.3.0 [CU21]/10.4.0 [CU9] - FR 10.4.12 -->

Up to now, SLLogCollector would by default be configured to collect the log files of the CommunicationGateway DxM. From now on, this will no longer be the case. Only when the CommunicationGateway DxM is deployed, will SLLogCollector be configured to collect the log files of said DxM.

### Fixes

#### Problem when trying to access trend statistics on a DataMiner Cube connected via gRPC [ID 40668]

<!-- MR 10.3.0 [CU21]/10.4.0 [CU9] - FR 10.4.12 -->

When DataMiner Cube was connected to a DataMiner Agent via gRPC, because of a deserialization issue on the server, it would not be possible to access trend statistics.

#### SLAnalytics - Behavioral anomaly detection: Updates to alarm templates used in alarm template groups could be disregarded [ID 40783]

<!-- MR 10.3.0 [CU21]/10.4.0 [CU9] - FR 10.4.12 -->

Up to now, when an alarm template used in an alarm template group was updated, and no element was using that template directly, in some cases, SLAnalytics would disregard the update. This could then lead to an incorrect anomaly alarm configuration being applied to elements using the alarm template group and to incorrect focus values being set in the alarms of the elements using the alarm template group.

#### Problem with alarm severity of a service not being updated correctly [ID 40840]

<!-- MR 10.3.0 [CU21]/10.4.0 [CU9] - FR 10.4.12 -->

In some cases, the alarm severity of a service would not be updated correctly when, during a row update, both the display key and the monitored value had been changed.

#### Failover: Problem with SLSNMPManager at startup [ID 40883]

<!-- MR 10.3.0 [CU21]/10.4.0 [CU9] - FR 10.4.12 -->

When a DataMiner Agent that was part of a Failover setup started up, in some cases, SLSNMPManager could stop working.

#### Problem when a DVE or virtual function element was deleted while a subscription was updated [ID 40900]

<!-- MR 10.3.0 [CU21]/10.4.0 [CU9] - FR 10.4.12 -->

When a DVE element or virtual function element was deleted while a subscription on the parent element or one of the child elements was updated, in some cases, especially when Stream Viewer was open, a runtime error could occur. This will now be prevented. In addition, information events will no longer be generated for the [Clients connected] parameter.

#### Incomplete CorrelationDetailsEvent messages after a DMA had reconnected to the DMS [ID 40934]

<!-- MR 10.3.0 [CU21]/10.4.0 [CU9] - FR 10.4.12 -->

When a DataMiner Agent reconnected to the DataMiner System of which it was a member (e.g., after having been restarted), in some rare cases, *CorrelationDetailsEvent* messages could be incomplete.

#### Problem when executing a GQI query after a DMA had been restarted [ID 40975]

<!-- MR 10.3.0 [CU21]/10.4.0 [CU9] - FR 10.4.12 -->

When a GQI query was executed on a DataMiner System with storage per DMA, and then executed again after a DMA in that DataMiner System had been restarted, it would fail.

#### Cassandra Cluster Migrator tool: Problem when encountering invalid or corrupt row while migrating alarm data [ID 41002]

<!-- MR 10.3.0 [CU21]/10.4.0 [CU9] - FR 10.4.12 -->

In some rare cases, the Cassandra Cluster Migrator tool (*SLCCMigrator.exe*) would throw an error when it encountered an invalid or corrupt row in the source database while migrating alarm data. From now on, all invalid or corrupt rows will be skipped.

#### Element connections: Value of write parameters would incorrectly be resent [ID 41010]

<!-- MR 10.3.0 [CU21]/10.4.0 [CU9] - FR 10.4.12 -->

When an element connection had a write parameter as source, up to now, the value of that parameter would be pushed to the destination when the element connections of the source element were modified or when the destination element was restarted. In some cases, this could result in unexpected behavior. For example, when the write parameter was a button, the destination element would start to execute the actions as if the button would have been pressed. From now on, write parameters used as source will only be forwarded to the destination when their value is actually updated.

The behavior of read parameters used as source will remain unchanged. Their value will still be forwarded to the destination when the destination element is restarted or when the element connections of the source element are modified. Read parameters are typically used to display the same value in both source and destination.

Also, up to now, when an element connection was saved without the *Include Element State* option being selected, the destination parameter (read parameter) would incorrectly be triggered twice with the same value. From now on, the value will only be forwarded once.

> [!NOTE]
> If you want write parameters used as source to behave as before, you can enable the *LegacyElementConnectionsResendWriteParams* soft-launch option.

#### GQI would no longer be able to send user-friendly error messages to client applications [ID 41019]

<!-- MR 10.3.0 [CU21]/10.4.0 [CU9] - FR 10.4.12 -->

Since DataMiner feature version 10.3.9, SLHelper would wrap GQI exceptions incorrectly, causing GQI to no longer be able to send user-friendly error messages to client applications.

#### Cassandra Cluster Migrator tool: Options for offloading files to a file cache would incorrectly not be preserved [ID 41055]

<!-- MR 10.3.0 [CU21]/10.4.0 [CU9] - FR 10.4.12 -->

Up to now, when finalizing a migration, the Cassandra Cluster Migrator tool (*SLCCMigrator.exe*) would incorrectly not preserve the options that had been specified for offloading files to a file cache. These options will now be preserved.

For more information on the above-mentioned offload options, see [Offloading files to a file cache](xref:DB_xml#offloading-files-to-a-file-cache).

#### Protocols: Stuffing attribute of Protocol.Advanced element was not parsed correctly [ID 41092]

<!-- MR 10.3.0 [CU21]/10.4.0 [CU9] - FR 10.4.12 -->

The value of the `stuffing` attribute of the *Protocol.Advanced* element was not parsed correctly.

#### Enhanced exception handling in SLASPConnection and SLWatchdog [ID 41121]

<!-- MR 10.3.0 [CU21]/10.4.0 [CU9] - FR 10.4.12 -->

A number of enhancements have been made to SLASPConnection and SLWatchdog with regard to exception handling.
