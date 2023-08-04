---
uid: Year_2038_Problem_for_Cassandra
---

# Year 2038 problem for Cassandra

## Affected versions

All DataMiner versions using the Cassandra database

## Cause

The time formatting issue known as the [year 2038 problem](https://en.wikipedia.org/wiki/Year_2038_problem) makes it impossible to exceed the maximum Unix timestamp of 19 January 2038. Setting the TTL for a Cassandra database to any duration that exceeds that date, e.g. setting a TTL of 15 years in early 2023, will result in an error.

From Cassandra version 3.11.2 and 4.0 onwards, an exception will be thrown in this case, while Cassandra version 3.7 will fail silently and drop the data.

> [!TIP]
> See also:
>
> - <https://github.com/apache/cassandra/blob/trunk/NEWS.txt>
> - <https://issues.apache.org/jira/browse/CASSANDRA-14227>

## Fix

From DataMiner 10.2.0 [CU14]/10.3.0 [CU2]/10.3.4 onwards, the general TTL for databases is limited to 10 years to prevent this issue. <!-- RN 35533 -->

## Workaround

1. Stop all DMAs in the DMS, including all Failover Agents.

1. Edit *DBMaintenanceDMS.xml* on every one of those Agents to change TTLs that exceed 19 January 2038 to a lower number.

1. Restart all DMAs.

## Issue description

When a TTL for Cassandra is set to a duration that exceeds 19 January 2038, the DMA will not start and will show an exception in the SLDBConnection logging like the following:

```txt
Cassandra.InvalidQueryException: Request on table SLDMADB.timetrace with ttl of 474336000 seconds exceeds maximum supported expiration date of 2038-01-19T03:14:06+00:00. In order to avoid this use a lower TTL, change the expiration date overflow policy or upgrade to a version where this limitation is fixed. See CASSANDRA-14092 for more details.
```
