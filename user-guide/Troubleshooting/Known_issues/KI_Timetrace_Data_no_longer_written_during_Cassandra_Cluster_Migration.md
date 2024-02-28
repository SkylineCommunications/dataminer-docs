---
uid: KI_Timetrace_Data_no_longer_written_during_Cassandra_Cluster_Migration
---

# Timetrace data is no longer written during Cassandra Cluster migration

## Affected versions

Any versions using a Cassandra Cluster setup.

## Cause

When initializing a Cassandra Cluster migration, the process of generating new alarms stops storing timetrace data, necessary for historical alarm queries. This disrupts the retrieval of alarm history while the migration is ongoing, even though alarms are still being generated.

## Fix

No fix is available yet.

## Description

During a Cassandra Cluster migration, new generated alarms no longer include timetrace data storage, essential for historical alarm queries. As a result, attempts to query alarm history during the migration process through Cube or other interfaces connected to SLDataGateway return no results. This issue persists until the migration is completed.

If a user tries to halt the migration, the timetrace data that was never written will not be automatically restored, and the historical alarm queries covering the migration period will be incomplete.
