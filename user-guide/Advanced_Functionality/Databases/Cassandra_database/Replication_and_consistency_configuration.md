---
uid: replication_and_consistency_configuration
---

# Data replication and consistency configuration

## High availability concept

In DataMiner, you can find, depending on your setup, many flavors of Cassandra clusters, from 1-node clusters, 2 node clusters to clusters with many nodes. For any number of machines in a Cassandra cluster, it's possible a node goes down. If this happens, it may still be possible to query your data using Cassandra's built in data replication and consistency mechanism.

## Data replication

In Cassandra data can be replicated. This means multiple copies of the same record may exist in the same Cassandra cluster.
When in use, data replication ensures that if a node goes down it may still be possible to read or write a record to the Cassandra Cluster.
Data replication is set using the **replication factor**.
The replication factor is set when the *Cassandra Keyspaces* are created by DataMiner. As such, the value for the replication factor is controlled by DataMiner.
See [Cassandra - Data replication](https://docs.datastax.com/en/cassandra-oss/3.x/cassandra/architecture/archDataDistributeReplication.html) for more information.

If the Cassandra cluster is smaller than 4, the *replication factor* is 1, meaning only 1 copy of the data exists in the Cassandra Cluster. In this case you do not benefit from data replication.
If the Cassandra Cluster is 4 or larger, the *replication factor* is 3, meaning 3 copies of the data exist in the Cassandra Cluster. In this case you benefit from data replication.

> [!NOTE]
> If a custom replication factor is required, it is possible to manually configure it.
> However, since this involves altering the *Cassandra Keyspaces* used for crucial DataMiner data, we recommend doing this only in coordination a Cassandra expert or with Skyline Communications.
> For more information: see [Cassandra - Updating the replication factor](https://docs.datastax.com/en/cql-oss/3.3/cql/cql_using/useUpdateKeyspaceRF.html)

## Consistency Level

The **consistency level** is a on-query-level setting that helps decide when a query succeeds or fails.
It specifies the amount of replicas that need to respond before the client deems the response to be acceptable.
More specifically, the *consistency level* answers the following question: out of x replica's of the data (replication factor), how many need to respond for the query to be successful?
This is configured in db.xml and is the same for all queries done by DataMiner.
For more information on how this is set, please see [db.xml](xref:DB_xml)

For more information regarding consistency levels, see [Cassandra - How is the consistency level configured?](https://docs.datastax.com/en/cassandra-oss/3.x/cassandra/dml/dmlConfigConsistency.html)

> [!IMPORTANT]
> Changing the consistency level may increase the chance that your Cassandra reads or writes fail if done improperly.
> Therefore, when in any doubt, please contact Skyline for assistance.
> For more information: see [Cassandra - How are consistent read and write operations handled?](https://docs.datastax.com/en/cassandra-oss/3.x/cassandra/dml/dmlAboutDataConsistency.html)

## Practical example

Whether a read or write query returns successfully or not is decided by the Consistency Level and the replication factor together.

E.g. If the consistency level is Three and the replication factor is 3 as well, then any read or write query will only respond with data if all 3 copies of the data respond.
If the consistency level is Quorum, meaning the majority of the copies/replicas should answer and the replication factor is 3, then at least 2 nodes should respond for the query to be successful.
