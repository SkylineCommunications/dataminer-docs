---
uid: KI_SLDataGateway_leak_during_CC_migration
---

# SLDataGateway memory leak during Cassandra Cluster migration

## Affected versions

- DataMiner 10.1.0 prior to CU22.
- DataMiner 10.2.0 prior to CU10.
- DataMiner 10.1.2 to 10.2.12.

## Cause

During the migration to a Cassandra Cluster setup, paging handler objects in SLDataGateway expire but are not cleaned up, causing a memory leak. As there is approximately one such object per alarm tree, the impact of this issue increases in systems with many alarms. If this causes the DMA to run out of memory, source database reads can fail, causing the alarm migration to get the "Incomplete" status.

## Fix

Install DataMiner 10.1.0 [CU22], 10.2.0 [CU10], or 10.3.1

## Issue description

From the moment the migration to a Cassandra Cluster setup is started, SLDataGateway memory usage steadily increases without a clear reason. In some cases, the alarm migration can get the status "Incomplete".
