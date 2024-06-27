---
uid: KI_Failover_switch_Cassandra_Cluster
---

# Failover switch taking a long time on systems with Cassandra Cluster setup

## Affected versions

Failover systems with Cassandra Cluster setup from DataMiner 10.4.2 onwards.

## Cause

Blocking calls in the SLASPConnection process cause a Failover switch to take a long time. This is likely related to the alarm load in the system: the more alarms are active, the longer the Failover switch will take (with a maximum of 10 minutes).

## Fix

No fix is available yet.

## Description

On systems with a Cassandra Cluster setup, a Failover switch takes significantly longer than usual.
