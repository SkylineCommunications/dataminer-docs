---
uid: KI_Cassandra_cluster_node_unexpected_state
---

# Cassandra cluster node in unexpected state

## Affected versions

Any versions using a Cassandra Cluster setup.

## Cause

When there is a time difference between different Cassandra nodes, this causes errors of the type "Bad timestamp generated". This can cause an unexpected state to be reported for some of the nodes.

## Fix

Set up NTP on all servers and restart Cassandra.

## Issue description

In a Cassandra cluster, some nodes report an unexpected state ("?N") of peer nodes. For example:

![Example of unexpected state Cassandra node](~/user-guide/images/KI_Cassandra_node_unexpected.png)

The Cassandra debug and system logs contain warnings similar to the following example:

```txt
WARN   [Messaging-EventLoop-3-7] 2023-01-06 17:53:02,739 NoSpamLogger.java:95 - Bad timestamp 1673020344443 generated, overriding with currentTimeMillis = 1673023982737
```
