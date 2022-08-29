---
uid: KI_RTE_with_SLAnalytics_when_upgrading
---

# SLAnalytics RTEs after upgrading DMS with Cassandra Cluster

## Affected versions

DataMiner 10.2.8 (CU1)

## Cause

The upgrade action "AnalyticsParameterInfoRecordAddChangeRate" is not triggered for a DMS with Cassandra cluster because the check in the upgrade action that controls whether Cassandra is active only checks for "Cassandra" and not for "CassandraCluster".

## Fix

Either downgrade to 10.2.7 and then upgrade to DataMiner 10.2.8 (CU2), or run the command mentioned under "Workaround" below and then upgrade to DataMiner 10.2.8 (CU2).

## Workaround

Open DevCenter and run the command `ALTER TABLE analytics_parameterinfo_v1 add cr int;`.  

## Issue description

After upgrading to DataMiner 10.2.8 (CU1), the Alarm Console shows run-time errors related to the SLAnalytics process.
