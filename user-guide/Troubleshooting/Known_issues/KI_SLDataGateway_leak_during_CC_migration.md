---
uid: KI_SLDataGateway_leak_during_CC_migration
---

# SLDataGateway memory leak during Cassandra Cluster migration

## Affected versions

From DataMiner 10.1.0/10.1.2 onwards.

## Cause

During the migration to a Cassandra Cluster setup, paging handler objects in SLDataGateway expire but are not cleaned up, causing a memory leak. As there is approximately one such object per alarm tree, the impact of this issue increases in systems with many alarms. If this causes the DMA to run out of memory, source database reads can fail, causing the alarm migration to get the "Incomplete" status.

## Fix

No fix is available yet.

## Issue description

From the moment the migration to a Cassandra Cluster setup is started, SLDataGateway memory usage steadily increases without a clear reason. In some cases, the alarm migration can get the status "Incomplete".
