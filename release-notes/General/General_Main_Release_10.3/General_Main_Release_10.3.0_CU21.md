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

#### SLXML: Enhanced error when erroneous XML code is received [ID 40995]

<!-- MR 10.3.0 [CU21]/10.4.0 [CU9] - FR 10.4.12 -->

Up to now, when SLXML received erroneous XML code, the error message logged in *SLXML.txt* would lose vital information when it was trimmed by SLLog due to the 5120-character error message size limit. The error message in question has now been adapted so that the most important information is found at the beginning.

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
