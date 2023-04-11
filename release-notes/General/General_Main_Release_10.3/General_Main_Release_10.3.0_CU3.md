---
uid: General_Main_Release_10.3.0_CU3
---

# General Main Release 10.3.0 CU3 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### DataMiner Object Models: Enhanced performance when reading DOM objects and ModuleSettings [ID_35934]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

Because of a number of enhancements, overall performance has increased when reading DOM objects and ModuleSettings.

#### SLLogCollector now also collects SyncInfo files [ID_35995]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

SLLogCollector packages will now also include all files found in `C:\Skyline DataMiner\Files\SyncInfo` relevant for troubleshooting.

### Fixes

#### Cassandra Cluster Migrator tool would incorrectly not migrate the state-changes table from a single-node Cassandra to a Cassandra Cluster [ID_35699]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.4 -->

When you used the Cassandra Cluster Migrator tool to migrate a single-node Cassandra database to a Cassandra Cluster setup, up to now, the `state-changes` table would incorrectly not be migrated.

#### Updating a Resource or ResourcePool would incorrectly cause the 'CreatedAt' and 'CreatedBy' fields to be overwritten [ID_35913]

<!-- MR 10.3.0 [CU3] - FR 10.3.6 -->

When a Resource or ResourcePool was updated, the *CreatedAt* and *CreatedBy* fields would incorrectly be overwritten.

#### Creating or updating a function resource while its parent element was in an error state would incorrectly be allowed [ID_35963]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

When you created or updated a function resource while its parent element was in an error state, up to now, the state of that parent element would not be checked correctly. As a result, adding or updating the function resource would incorrectly be allowed.

From now on, when you create or update a function resource while its parent element is in an error state, an error will be thrown.

#### Spectrum analysis: Measurement points would not be set correctly [ID_36005]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

In some cases, measurement points would not be set correctly when a trace was being displayed.

#### Virtual functions linked to a parameter with a hysteresis timer could be assigned an incorrect alarm severity [ID_36024]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

When a virtual function was linked to a parameter that had a hysteresis timer running, in some cases, that virtual function would be assigned an incorrect alarm severity.

#### SLReset.exe would not clean an Elasticsearch database when no <DB> element was specified in DB.xml [ID_36040]

<!-- MR 10.2.0 [CU15]/10.3.0 [CU3] - FR 10.3.6 -->

When, in the *DB.xml* file, no `<DB>` element was specified for an Elasticsearch database, the factory reset tool *SLReset.exe* would not clean that database when the `cleanclustereddatabases` option had been used.

From now on, when no `<DB>` element is specified for a Elasticsearch database, *SLReset.exe* will use the default database name "dms".
