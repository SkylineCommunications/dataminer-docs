---
uid: KI_Failover_switch_Cassandra_Cluster
---

# Failover switch can take a long time on systems with a Cassandra Cluster

## Affected versions

Failover systems with a Cassandra Cluster database.

## Cause

The problem is probably caused by inefficient alarm distribution queries sent by SLASPConnection to SLDataGateway.

## Workaround

None.

## Fix

## Description

On systems with a Cassandra Cluster database, a Failover switch can take a long time due to blocking calls on SLASPConnection.
