---
uid: KI_Problem_after_removing_DMA_from_cluster
---

# Problem after removing DMA from cluster

## Affected versions

Any DataMiner version using a clustered storage and/or an indexing database.

## Cause

When a DMA is removed from a DMS, the configuration in DB.xml can still point to the database cluster and/or the indexing database used by the DMS. This means that if the DMA is still used after it is removed, it uses the same database and keyspace as the DMS it was removed from, which can cause various issues.

## Fix

No fix is available yet.

## Description

After a DMA has been removed from a DMS, in case that DMA is still used, data from the existing DMS or from the removed DMA gets overwritten or removed unexpectedly.
