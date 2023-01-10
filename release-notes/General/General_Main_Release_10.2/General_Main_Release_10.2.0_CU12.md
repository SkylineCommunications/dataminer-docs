---
uid: General_Main_Release_10.2.0_CU12
---

# General Main Release 10.2.0 CU12 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Exporting and importing DELT packages containing element and alarm data is now supported on DataMiner Systems with a clustered database [ID_35213]

<!-- MR 10.2.0 [CU12] - FR 10.3.2 [CU0] -->

From now on, exporting and importing DELT packages containing element and alarm data is also supported on DataMiner Systems with a clustered database.

> [!NOTE]
> Exporting and importing DELT packages containing trend data is not yet supported on DataMiner Systems with a clustered database.

### Fixes

#### Dashboards app / Low-Code Apps - Node edge component: Edge overrides would incorrectly no longer be applied [ID_35298]

<!-- MR 10.2.0 [CU12] - FR 10.3.2 -->

When, in the settings of a node edge graph, you had configured edge overrides, these would incorrectly no longer be applied.
