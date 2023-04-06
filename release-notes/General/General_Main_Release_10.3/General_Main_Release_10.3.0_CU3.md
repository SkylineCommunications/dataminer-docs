---
uid: General_Main_Release_10.3.0_CU3
---

# General Main Release 10.3.0 CU3 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### SLLogCollector now also collects SyncInfo files [ID_35995]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

SLLogCollector packages will now also include all files found in `C:\Skyline DataMiner\Files\SyncInfo` relevant for troubleshooting.

### Fixes

#### Cassandra Cluster Migrator tool would incorrectly not migrate the state-changes table from a single-node Cassandra to a Cassandra Cluster [ID_35699]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.4 -->

When you used the Cassandra Cluster Migrator tool to migrate a single-node Cassandra database to a Cassandra Cluster setup, up to now, the `state-changes` table would incorrectly not be migrated.

#### Creating or updating a function resource while its parent element was in an error state would incorrectly be allowed [ID_35963]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

When you created or updated a function resource while its parent element was in an error state, up to now, the state of that parent element would not be checked correctly. As a result, adding or updating the function resource would incorrectly be allowed.

From now on, when you create or update a function resource while its parent element is in an error state, an error will be thrown.
