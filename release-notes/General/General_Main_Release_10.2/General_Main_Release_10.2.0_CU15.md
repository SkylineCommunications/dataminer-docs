---
uid: General_Main_Release_10.2.0_CU15
---

# General Main Release 10.2.0 CU15 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Dashboards app & Low-code apps - Table component: Enhanced visibility of rows that are selected or hovered over in dark mode [ID_35993]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.5 -->

When a dashboard or a low-code app is in dark mode, from now on, there will be a higher color contrast between rows that are selected or hovered over and rows that are not.

### Fixes

#### Dashboards app & Low-code apps - GQI components: Open sessions would not be closed when a new query was triggered [ID_35824]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU2] - FR 10.3.5 -->

When a GQI component still had a session open when a new query was triggered, in some cases, the open session would incorrectly not be closed.

#### Creating or updating a function resource while its parent element was in an error state would incorrectly be allowed [ID_35963]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

When you created or updated a function resource while its parent element was in an error state, up to now, the state of that parent element would not be checked correctly. As a result, adding or updating the function resource would incorrectly be allowed.

From now on, when you create or update a function resource while its parent element is in an error state, an error will be thrown.
