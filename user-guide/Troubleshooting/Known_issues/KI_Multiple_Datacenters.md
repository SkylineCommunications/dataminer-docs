---
uid: KI_Multiple_Datacenters
---

# Various issues with a geo-redundant Cassandra setup with multiple data centers

## Affected versions

Geo-redundant or site-redundant Cassandra Cluster setups that have the following configurations on Cassandra level:

- NetworkTopology replication strategy: a strategy used to more easily expand to multiple data centers when required by future expansion. See also: [Data replication](https://docs.datastax.com/en/cassandra-oss/3.0/cassandra/architecture/archDataDistributeReplication.html)

- GossipingPropertyFileSnitch: a snitch for production use that determines the network topology in Cassandra. See also: [Snitch](https://cassandra.apache.org/doc/latest/cassandra/architecture/snitch.html)

- Consistency Level: a level that determines the number of nodes that require answer before queries are considered inconsistent and will fail. See also: [How is the consistency level configured?](https://docs.datastax.com/en/cassandra-oss/3.0/cassandra/dml/dmlConfigConsistency.html)

  - set per query on Cassandra level, or

  - for the entire DMS on DataMiner level

  > [!TIP]
  > See also: [Customizing the consistency level of the Cassandra cluster](xref:Migrating_the_general_database_to_a_DMS_Cassandra_cluster#customizing-the-consistency-level-of-the-cassandra-cluster)

- DCAwareRoundRobinPolicy: the load balancing policy used by the Cassandra driver to connect with the Cassandra cluster. This policy does not switch over to the remote data center by default. See also: [Tuning policies](https://docs.datastax.com/en/developer/csharp-driver/3.19/features/tuning-policies/)

## Cause

- **Cassandra Cluster setup without failover**: In a setup where a single DMS connects to multiple data centers, the DMS automatically detects the data center of the first contact point and evenly distributes queries across all nodes within that data center. If a query consistently fails, the policy will not attempt to connect with nodes in other data centers. In such cases, a DataMiner offload alarm will be triggered, and DataMiner will initiate the process of offloading.

- **Cassandra Cluster setup with failover**: In a setup where a DMS with two failover nodes connects to multiple data centers, the contact points are spread across these two failover nodes. This allows for failover switching if one of the data centers goes down or becomes unresponsive to queries. After the failover sync, both machines will have contact points in the *db.xml* file. Although both nodes have synchronized contact points, the order in which they connect to the data centers cannot be guaranteed. Therefore, this mechanism is not entirely reliable.

## Issues

Below you can find an overview of issues related to this Cassandra Cluster setup:

| Issue | Affected versions | Workaround | Fix |
|--|--|--|--|
| Because of a difference in behavior between replication strategies, the replication factor is not interpreted correctly, resulting in parsing failure. Consequently, the Cassandra driver assumes that there is no redundancy, allowing the DMA to offload data after losing just one Cassandra node. See: [Cassandra disconnects after loss of a single node](xref:KI_Cassandra_disconnects_after_loss_of_a_single_node)| All Cassandra Cluster setups | N/A | TBD |
| When the connection with the Cassandra cluster is temporarily lost, data is not offloaded to database offload files and restored to the database afterwards. This causes data loss for the duration of the connection issue. See: [Cassandra cluster data not offloaded while database is unavailable](xref:KI_Cassandra_cluster_data_not_offloaded)| All Cassandra Cluster setups | N/A | TBD |
