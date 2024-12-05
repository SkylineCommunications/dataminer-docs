---
uid: General_Main_Release_10.4.0_CU11
---

# General Main Release 10.4.0 CU11 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Main Release 10.4.0 CU11](xref:Cube_Main_Release_10.4.0_CU11).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.4.0 CU11](xref:Web_apps_Main_Release_10.4.0_CU11).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### History Manager: A clearer exception will now be thrown when the History Manager API is used after the History Manager has been stopped [ID 41500]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

When the History Manager API was used to perform create, update or delete operations after the History Manager had been stopped, up to now, a `NullReferenceException` would be thrown.

From now on, when the History Manager API is used after the History Manager has been stopped, the following `DataMinerException` will be thrown and logged:

`There is no known manager that can process objects for Manager X. Check if the manager has been initialized, the agent is licensed and is using the required database.`

#### Storage as a Service: Enhanced performance when updating alarm information [ID 41581]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

Because of a number of enhancements, overall performance has increased when updating alarm information on STaaS systems.

### Fixes

#### Problem with SLDataMiner when deleting a connector [ID 41520]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

In some rare cases, SLDataMiner could stop working when a connector was deleted immediately after an element using that connector had been deleted.

#### DataMiner Maps: Markers that did not match the alarm level filter would become visible for a split second [ID 41555]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

When you zoomed to a different layer while an alarm level filter was active, in some cases, markers that did not match the filter would become visible for a split second before disappearing again.
