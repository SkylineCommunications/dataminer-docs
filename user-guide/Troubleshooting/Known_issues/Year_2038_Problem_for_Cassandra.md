---
uid: Year_2038_Problem_for_Cassandra
---

# Year 2038 problem for Cassandra

## Affected versions

All DataMiner versions with Cassandra Cluster setup

## Cause

The time formatting bug known as 'the year 2038 problem' makes it impossible to exceed the maximum unix time stamp of 19 January 2038. Since the start of 2023, it is 15 years prior to 2038, which means that TTLs for a Cassandra database set to 15 years will give an error.

## Fix

A fix will be made available in a future DataMiner update.

## Workaround

1. Stop all DMAs in the DMS, including all Failover Agents.
1. Edit **DBMaintenanceDMS.xml* on every one of those Agents to change TTLS of 15 years to a lower number.
1. Restart all Agents.

## Issue description

When a TTL for Cassandra is set to 15 years, the DMA will not start and will show the following SLDBConnection logging:

```txt
Cassandra.InvalidQueryException: Request on table SLDMADB.timetrace with ttl of 474336000 seconds exceeds maximum supported expiration date of 2038-01-19T03:14:06+00:00. In order to avoid this use a lower TTL, change the expiration date overflow policy or upgrade to a version where this limitation is fixed. See CASSANDRA-14092 for more details.
```
