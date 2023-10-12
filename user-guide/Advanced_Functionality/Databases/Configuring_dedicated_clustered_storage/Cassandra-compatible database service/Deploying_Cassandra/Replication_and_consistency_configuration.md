---
uid: replication_and_consistency_configuration
---

# Data replication and consistency configuration

DataMiner supports many flavors of [Cassandra clusters](xref:Migrating_the_general_database_to_a_DMS_Cassandra_cluster) to allow all sorts of different setups, from 1-node clusters or 2-node clusters to clusters with many nodes.

Regardless of the number of machines in a Cassandra cluster, it is always possible that a node might go down. If this happens, it may still be possible to query your data using Cassandra's built-in data replication and consistency mechanism.

A **correct configuration of the replication factor and consistency level is essential to ensure high availability** of the database in such cases. Together, these determine whether a read or write query to the Cassandra database will return successfully.

## Data replication

In Cassandra, data can be replicated. This means that multiple copies of the same record can exist in the same Cassandra cluster. Data replication ensures that if a node goes down, it may still be possible to read or write a record in the Cassandra cluster.

Data replication is set using the **replication factor**.

DataMiner sets this replication factor when it creates the Cassandra keyspaces. As such, the value for the replication factor is controlled by DataMiner.

- If the Cassandra cluster consists of **3 nodes or less**, the default replication factor is **1**. This means that only one copy of the data exists in the Cassandra cluster. In this case, you do not benefit from data replication.
- If the Cassandra cluster consists of **at least 4 nodes**, the default replication factor is **3**. This means that three copies of the data exist in the Cassandra cluster. In this case, you benefit from data replication.

If a **custom replication factor** is required, you can configure this manually. However, as this involves altering the Cassandra keyspaces used for crucial DataMiner data, we recommend doing this **only in coordination with a Cassandra expert or with Skyline Communications**.

> [!TIP]
> See also:
>
> - [Cassandra - Data replication](https://docs.datastax.com/en/cassandra-oss/3.x/cassandra/architecture/archDataDistributeReplication.html)
> - [Cassandra - Updating the replication factor](https://docs.datastax.com/en/cql-oss/3.3/cql/cql_using/useUpdateKeyspaceRF.html)

## Consistency Level

The **consistency level** is an setting on query level that helps decide when a query succeeds or fails. It specifies the number of replicas that need to respond before the client considers a response acceptable. More specifically, the consistency level answers the following question: Out of x replicas of the data (depending on the replication factor), how many need to respond for a query to be successful?

DataMiner uses the same consistency level for all its queries to the Cassandra database. If a **custom consistency level** is required, you can configure this in *DB.xml*:

1. Shut down the DMA.

1. Open the file *DB.xml* from the directory *C:\\Skyline DataMiner* in a text editor.

1. In the `<Database>` tag, add the *consistencyLevel="x"* attribute, and set it to the consistency level you want, e.g. *two*.

   The following consistency levels are supported: One, Two, Three, Quorum, All, LocalQuorum, EachQuorum, Serial, LocalSerial, LocalOne. The default setting is "Quorum".

   > [!NOTE]
   > Together with the replication factor, the consistency level determines the maximum number of nodes that can be down before data unavailability occurs. For more information, see [Data replication and consistency configuration](xref:replication_and_consistency_configuration).

1. Restart DataMiner.

> [!CAUTION]
>
> - Only change this attribute for a Cassandra Cluster setup. If you change it for a standard Cassandra setup with one Cassandra cluster per DMA, this can cause DataMiner to fail to start up.
> - If you change the consistency level incorrectly, this can increase the chance of Cassandra database queries failing. Therefore, if you have any doubts, please contact Skyline for assistance.

> [!TIP]
> See also:
>
> - [Cassandra - How is the consistency level configured?](https://docs.datastax.com/en/cassandra-oss/3.x/cassandra/dml/dmlConfigConsistency.html)
> - [Cassandra - How are consistent read and write operations handled?](https://docs.datastax.com/en/cassandra-oss/3.x/cassandra/dml/dmlAboutDataConsistency.html)

## Examples

The combination of the consistency level and replication factor determine whether queries are successful. For example:

- If the replication factor is 3 and the consistency level is 2, Cassandra queries will require an answer from 2 out of 3 replicas to be considered successful. This means that if one node is down, queries will still succeed, but if another node is down, it is possible that queries will no longer succeed.

- If the replication factor is 3 and the consistency level is also 3, queries will only be successful if all 3 replicas respond.

- If the replication factor is 3 and consistency level is *Quorum*, meaning that the majority of the replicas should answer, at least 2 nodes will need to respond for the query to be successful.
