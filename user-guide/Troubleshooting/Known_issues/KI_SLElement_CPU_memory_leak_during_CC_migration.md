---
uid: KI_SLElement_CPU_memory_leak_during_CC_migration
---

# SLElement memory leak during Cassandra Cluster migration

## Affected versions

From DataMiner 10.1.0/10.1.2 onwards.

## Cause

During the migration to a Cassandra Cluster setup, when the active alarms are requested, a deadlock can occur that blocks the processing of parameter sets, causing a memory leak in SLElement.

## Fix

No fix is available yet.

## Issue description

During migration to a Cassandra Cluster setup, SLElement uses a continually increasing amount of memory without a clear reason.
