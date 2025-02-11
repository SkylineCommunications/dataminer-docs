---
uid: KI_Failover_switch_Cassandra
---

# Failover switch taking a long time on systems with Cassandra setup

## Affected versions

Failover systems with Cassandra setup from DataMiner 10.4.2 to 10.4.8.

## Cause

Blocking calls in the SLASPConnection process cause a Failover switch to take a long time. This is likely related to the alarm load in the system: the more alarms are active, the longer the Failover switch will take (with a maximum of 10 minutes).

## Fix

Install DataMiner 10.3.0 [CU18], 10.4.0 [CU6], or 10.4.9.

## Description

On systems with a Cassandra setup, a Failover switch takes significantly longer than usual.
