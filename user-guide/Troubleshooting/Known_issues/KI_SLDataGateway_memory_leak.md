---
uid: KI_SLDataGateway_memory_leak
---

# SLDataGateway memory leak

## Affected versions

DataMiner versions with Cassandra Cluster setup prior to DataMiner 10.2.0 [CU8] or 10.2.11.

## Cause

When real-time trending is requested, it is possible that a trend data paging handler object is not cleaned up, causing a memory leak.

## Fix

Upgrade to DataMiner 10.2.0 [CU8] or 10.2.11.

## Issue description

In DataMiner Systems using a Cassandra cluster as the general database for the entire DMS (i.e. a "Cassandra Cluster setup"), the SLDataGateway process could use a continually increasing amount of memory without a clear reason.
