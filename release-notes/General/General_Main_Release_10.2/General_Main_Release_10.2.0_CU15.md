---
uid: General_Main_Release_10.2.0_CU15
---

# General Main Release 10.2.0 CU15 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

### Fixes

#### Dashboards app & Low-code apps - GQI components: Open sessions would not be closed when a new query was triggered [ID_35824]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU2] - FR 10.3.5 -->

When a GQI component still had a session open when a new query was triggered, in some cases, the open session would incorrectly not be closed.
