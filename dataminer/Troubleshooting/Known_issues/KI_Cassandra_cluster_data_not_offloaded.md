---
uid: KI_Cassandra_cluster_data_not_offloaded
---

# Cassandra cluster data not offloaded while database is unavailable

## Affected versions

Any versions using a Cassandra Cluster setup.

## Cause

When the connection with the Cassandra cluster is temporarily lost, data is not offloaded to database offload files and restored to the database afterwards. This causes data loss for the duration of the connection issue. The following data tables are affected:

- CorrelationmatchInfo
- CorrelationSLidingWindow
- dveElementInfo
- state_changes
- elementdata
- elementLatch
- maskstate
- Spectrum
- Trending

## Fix

Install DataMiner 10.2.0 [CU18]/10.3.0 [CU6]/10.3.9<!--RN 36865-->.

## Description

Data that was added while the Cassandra cluster database was unavailable is missing in the database, causing e.g. gaps in trending.
