---
uid: KI_SLElement_CPU_memory_leak_during_CC_migration
---

# SLElement memory leak during Cassandra Cluster migration

## Affected versions

DataMiner 10.1.0/10.1.2 up to 10.2.0 [CU9]/10.3.0.

## Cause

During the migration to a Cassandra Cluster setup, when the active alarms are requested, a deadlock can occur that blocks the processing of parameter sets, causing a memory leak in SLElement.

## Fix

Install DataMiner 10.2.0 [CU10]/10.3.1<!--RN 34668-->.

## Issue description

During migration to a Cassandra Cluster setup, SLElement uses a continually increasing amount of memory without a clear reason.
