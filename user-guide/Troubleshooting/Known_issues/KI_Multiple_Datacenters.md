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

> [!TIP]
> See also: [Various resolved issues with a geo-redundant Cassandra setup with multiple data centers](xref:KI_Multiple_Datacenters_resolved_issues)
