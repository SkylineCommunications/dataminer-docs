---
uid: KI_Timetrace_Data_no_longer_written_during_Cassandra_Cluster_Migration
---

# Timetrace data is no longer written during Cassandra Cluster migration

## Affected versions

Any versions using a Cassandra Cluster setup.

## Cause

When initializing a Cassandra Cluster migration, the process of generating new alarms stops storing timetrace data, necessary for historical alarm queries. This disrupts the retrieval of alarm history while the migration is ongoing, even though alarms are still being generated.

## Fix

Install DataMiner 10.3.0 [CU19], 10.4.0 [CU7], or 10.4.10<!--RN 40476-->.

## Description

During a Cassandra Cluster migration, timetrace data storage for newly generated alarms is suspended, impacting the ability to query historical alarm data via Cube or other interfaces connected to SLDataGateway. Attempts to retrieve alarm history during the migration period yield no results. Alarms requested during the migration period are absent from the query results, whereas alarms predating the migration are unaffected because of existing timetrace data.

If a user tries to halt the migration, the timetrace data that was never written will not be automatically restored, and the historical alarm queries covering the migration period will be incomplete.
