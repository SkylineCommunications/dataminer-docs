---
uid: KI_Failover_switch_Cassandra_Cluster
---

# Failover switch taking a long time on systems with Cassandra Cluster setup

## Affected versions

Failover systems with Cassandra Cluster setup from DataMiner 10.4.2 onwards.

## Cause

Blocking calls in the SLASPConnection process cause a Failover switch to take a long time. A likely cause for this is inefficient alarm distribution queries sent by SLASPConnection to SLDataGateway, but this is currently still being investigated.

## Fix

No fix is available yet.

## Description

On systems with a Cassandra Cluster setup, a Failover switch takes significantly longer than usual.
