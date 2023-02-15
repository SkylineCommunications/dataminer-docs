---
uid: General_Main_Release_10.3.0_CU1
---

# General Main Release 10.3.0 CU1 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### SLAnalytics: Number of 'GetParameterMessages' requests has been optimized [ID_34936]

<!-- MR 10.3.0 [CU1] - FR 10.3.1 -->

The number of *GetParameterMessages* sent by SLAnalytics in order to check whether a trended table parameter is still active has been optimized.

### Fixes

#### Problem with SLElement when stopping an EPM element [ID_35439]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1]  - FR 10.3.3 -->

When an EPM element was stopped, in some rare cases, an error could occur in SLElement.

#### SLAnalytics - Behavioral anomaly detection: Two identical behavioral anomaly alarms would incorrectly be created [ID_35511]

<!-- MR 10.3.0 [CU1] - FR 10.3.3 -->

In some cases, two identical behavioral anomaly alarms would incorrectly be created.

#### SLAnalytics : Problem after a DVE parent element had been deleted [ID_35521]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.3 -->

In some cases, an error could occur in the SLAnalytics process after a DVE parent element had been deleted.
