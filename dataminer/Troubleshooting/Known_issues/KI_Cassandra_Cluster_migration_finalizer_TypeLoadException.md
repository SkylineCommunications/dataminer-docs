---
uid: KI_Cassandra_Cluster_migration_finalizer_TypeLoadException
description: "Learn why SLCCMigrator fails to finalize a Cassandra Cluster migration with a TypeLoadException and how to complete the migration manually."
---

# Cassandra Cluster migration finalizer fails with TypeLoadException

## Affected versions

- Main Release versions from DataMiner 10.5.0 [CU20]/10.6.0 [CU8] onwards.
- Feature Release versions from DataMiner 10.6.11 onwards.

## Cause

The affected releases include an updated System.Memory library, but the release package does not include *SLCCMigrationFinalizer.exe.config*. Without the binding redirect in this file, when a migration is attempted from a setup using a Cassandra database per DMA to a Cassandra Cluster setup, the migration finalizer fails with a `TypeLoadException` and is unable to respond to the migration tool's ping requests. The finalizer process is terminated after 5 minutes.

Attempting to run the migration again does not resolve this, as this happens for every migration attempt.

## Fix

Install DataMiner 10.6.0 [CU10]/10.7.1.<!-- RN 47230 -->

## Workaround

If all tables have been migrated and the migration fails at the *Finalize migration* step, complete the finalization manually on each DataMiner Agent:

1. Stop DataMiner on the Agent.

1. In [DB.xml](xref:DB_xml), look for the `<Database>` tag that has the `local` attribute set to `true`.

   This represents the general database.

1. Set the `type` attribute for the general database to `CassandraCluster` instead of `Cassandra`.

   This switches the setup from a standalone Cassandra database to a Cassandra Cluster.

1. Start DataMiner on the Agent.

> [!TIP]
> Start with one Agent and check whether the issue is resolved there before applying the workaround to the other Agents.

## Description

When you migrate from a setup using a Cassandra database per DMA to a Cassandra Cluster setup with the Cassandra Cluster Migrator tool (*SLCCMigrator.exe*), all tables are migrated, but the *Finalize migration* step fails on every Agent. The database configuration in *DB.xml* remains set to standalone Cassandra.

The *SLDBMigration.txt* log repeatedly reports "Failed to ping finalizer executable", followed by a `TypeLoadException` indicating that the `get_DataAsSpan` method in a `MessageWithRetries` type does not have an implementation.
