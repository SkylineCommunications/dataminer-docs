---
uid: General_Main_Release_10.3.0_CU10
---

# General Main Release 10.3.0 CU10 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

*No enhancements have been added yet.*

### Fixes

#### DELT: Trend data missing in DELT package after exporting tables with primary keys of type string [ID_37664]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

When you exported tables of which the primary keys were of type string, the DELT export package would incorrectly not contain any trend data.

#### Problem with remote clients after restarting a DMA in a gRPC-only cluster [ID_37726]

<!-- MR 10.3.0 [CU10] - FR 10.4.1 -->

When a DataMiner System was configured to use gRPC connections only (i.e. when *EnableDotNetRemoting* was set to false on all agents), in some cases, remote clients would not get properly registered with SLDataMiner after restarting a DataMiner Agent. This would cause remote requests to fail if they had to be handled by SLDataMiner on the DataMiner Agent that was restarted.

#### SLAnalytics: Problem when the alarm repository was not available at startup [ID_37782]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

In some cases, an error could occur in SLAnalytics when it was not able to connect to the alarm repository at startup.

#### Entire SNMPv3 response would be discarded when one or more cells contained 'no such instance' [ID_37815]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

When a table was polled via SNMPv3 and the response included a cell that contained *no such instance*, the table would not get populated with the values that were received. Instead, the entire result set would be discarded.
