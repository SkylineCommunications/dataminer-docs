---
uid: General_Main_Release_10.3.0_CU21
---

# General Main Release 10.3.0 CU21 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

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

When a DVE element or virtual function element was deleted while a subscription on the parent element or one of the child elements was updated, in some cases, especially when Stream Viewer was open, a run-time error could occur.

#### Incomplete CorrelationDetailsEvent messages after a DMA had reconnected to the DMS [ID 40934]

<!-- MR 10.3.0 [CU21]/10.4.0 [CU9] - FR 10.4.12 -->

When a DataMiner Agent reconnected to the DataMiner System of which it was a member (e.g. after having been restarted), in some rare cases, *CorrelationDetailsEvent* messages could be incomplete.

#### Problem when executing a GQI query after a DMA had been restarted [ID 40975]

<!-- MR 10.3.0 [CU21]/10.4.0 [CU9] - FR 10.4.12 -->

When a GQI query was executed on a DataMiner System with storage per DMA, and then executed again after a DMA in that DataMiner System had been restarted, it would fail.

#### GQI would no longer be able to send user-friendly error messages to client applications [ID 41019]

<!-- MR 10.3.0 [CU21]/10.4.0 [CU9] - FR 10.4.12 -->

Since DataMiner feature version 10.3.9, SLHelper would wrap GQI exceptions incorrectly, causing GQI to no longer be able to send user-friendly error messages to client applications.
