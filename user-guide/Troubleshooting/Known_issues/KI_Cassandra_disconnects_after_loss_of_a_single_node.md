---
uid: KI_Cassandra_disconnects_after_loss_of_a_single_node
---

# Cassandra disconnects after loss of a single node

## Affected versions

Any versions using a Cassandra Cluster setup.

## Cause

This issue results from a difference in behavior between [replication strategies](https://docs.datastax.com/en/cassandra-oss/3.0/cassandra/architecture/archDataDistributeReplication.html).

When connecting to Cassandra, SLDataGateway checks the replication factor. A Cassandra database that has keyspaces using SimpleStrategy (e.g. a Cassandra database per DMA with Failover) returns a response with the following format:

```txt
"{'class': 'org.apache.cassandra.locator.SimpleStrategy', 'replication_factor': '2'}"
```

SLDataGateway wrongly assumes that this exact format will always be followed.

However, in the case of a Cassandra Cluster setup or any setup using NetworkTopologyStrategy, the replication strategy response has a different format:

```txt
"{'class': 'org.apache.cassandra.locator.NetworkTopologyStrategy', 'datacenter1': '2'}"
```

Here, instead of the expected “replication_factor” keyword, the name of the data center ("datacenter1" in this example) is found. The difference in the response causes parsing to fail. The Cassandra driver assumes that in this case, there is no redundancy and therefore allows only the loss of one Cassandra node before marking the database node as down.

## Fix

No fix is available yet.

## Description

Even though your Cassandra cluster has three or more nodes and should be able to survive the loss of a node, DataMiner goes into offload mode and displays an “error” alarm in the Alarm Console after losing only one node. This may also occur if the cluster has more than one data center.
