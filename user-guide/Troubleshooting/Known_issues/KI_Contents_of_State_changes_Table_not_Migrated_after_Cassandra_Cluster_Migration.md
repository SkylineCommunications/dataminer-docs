---
uid: KI_Contents_of_State_changes_Table_not_Migrated_after_Cassandra_Cluster_Migration
---

# Contents of state_changes table not migrated after Cassandra Cluster migration

## Affected versions

Any versions using a Cassandra Cluster setup.

## Cause

During the migration from a Cassandra Single setup to a Cassandra Cluster setup, the contents of the *state_changes* table are not migrated.

## Fix

No fix is available yet.

## Issue description

After a migration from a setup with one Cassandra cluster per DMA to a [Cassandra Cluster setup](xref:Migrating_the_general_database_to_a_DMS_Cassandra_cluster), heatmap data from before the migration (e.g. alarm states) are no longer displayed in heatmaps and timelines in the legacy Reporter module and on the *Reports* page of element cards.
