---
uid: KI_Multiple_Datacenters
---

# Various issues with a geo-redundant Cassandra setup with multiple data centers

## Affected versions

Geo-redundant or site-redundant Cassandra Cluster setups using multiple data centers

## Cause

DataMiner maintains references to multiple contact points in the *DB.xml* configuration file, which may be spread across two or more data centers in Cassandra.
DataMiner automatically detects the data center of the first contact point in *DB.xml* and evenly distributes queries across all nodes within that data center. If a query consistently fails, the policy will not attempt to connect with nodes in other data centers. In such cases, a DataMiner offload alarm will be triggered, and DataMiner will initiate the process of offloading.

## Issues

Below you can find an overview of issues related to this Cassandra Cluster setup:

| Issue | Affected versions | Workaround | Fix |
|--|--|--|--|
| DataMiner does not automatically reconnect to a different Cassandra data center when queries fail consistently. | All Cassandra Cluster setups | N/A | TBD |
| DataMiner goes into offload mode after losing only one node. See: [Cassandra disconnects after loss of a single node](xref:KI_Cassandra_disconnects_after_loss_of_a_single_node)| All Cassandra Cluster setups | N/A | TBD |
| When the connection with the Cassandra cluster is temporarily lost, data is not offloaded to database offload files and restored to the database afterwards, causing data loss for the duration of the connection issue. See: [Cassandra cluster data not offloaded while database is unavailable](xref:KI_Cassandra_cluster_data_not_offloaded)| All Cassandra Cluster setups | N/A | TBD |
