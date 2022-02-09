---
uid: Migrating_the_general_database_to_a_DMS_Cassandra_cluster
---

# Migrating the general database to a DMS Cassandra cluster

From DataMiner 10.1.0/10.1.2 onwards, you can use a single Cassandra cluster as the general database for the entire DataMiner System. Previously it was already possible to use a separate Cassandra cluster for each DataMiner node. However, DataMiner 10.1.0/10.1.2 introduces the “Cassandra cluster” feature, which allows you to have all DataMiner nodes in a DataMiner System use one and the same Cassandra cluster as their general database.

![Cassandra cluster](~/user-guide/images/Cassandra_cluster.jpg)



> [!TIP]
> See also:
> - [DMA in a DMS using a Cassandra cluster](xref:General_DMA_configuration#dma-in-a-dms-using-a-cassandra-cluster)
> - [General database settings](xref:DB_xml#general-database-settings)

## Installation and configuration

Regardless of whether your DataMiner System currently uses SQL databases or Cassandra databases per DMA, from DataMiner 10.2.0/10.2.2 onwards, you can use a migrator tool to switch to a Cassandra cluster setup. For more information, see [Cassandra Cluster Migrator](https://community.dataminer.services/documentation/sql-to-cassandra-cluster-migrator/).

In earlier DataMiner versions, a Cassandra to Cassandra Cluster Migrator tool was available; however, we highly recommend that you upgrade to DataMiner 10.2.0 or 10.2.2 (or higher) and use the above-mentioned Cassandra Cluster Migrator instead.

## Limitations

- .dmimport packages created on a DMS using a Cassandra cluster do not contain any database data, and it is not possible to import database data from .dmimport packages into such a DMS.

- If the Cassandra cluster feature is used, alarm and information event information is always migrated to Elasticsearch. It is not possible to use this feature without enabling indexing on alarms.

## Cluster health monitoring

If a Cassandra node in the cluster goes down or if a Cassandra node is down when DataMiner starts up, an alarm will be generated in the Alarm Console. This alarm also indicates how much the health of the cluster is affected by the node being down, as this depends on multiple factors, including the cluster size and replication factor.

## Customizing the consistency level of the Cassandra cluster

When the Cassandra cluster feature is used, you can customize the consistency level for the Cassandra queries. You can do so as follows:

1. Shut down the DMA.

2. Open the file *DB.xml* from the directory *C:\\Skyline DataMiner* in a text editor.

3. In the \<Database> tag, add the *consistencyLevel=”x”* attribute, and set it to the consistency level you want, e.g. *two*.

    > [!NOTE]
    > - The following possible consistency levels are supported: Any, One, Two, Three, Quorum, All, LocalQuorum, EachQuorum, Serial, LocalSerial, LocalOn. For more information, see [https://docs.datastax.com/en/cassandra-oss/3.0/cassandra/dml/dmlConfigConsistency.html](https://docs.datastax.com/en/cassandra-oss/3.0/cassandra/dml/dmlConfigConsistency.html).
    > - The *consistencyLevel* attribute should only be changed in case the Cassandra cluster feature is used or a remote Cassandra server is used. If the standard configuration of one Cassandra cluster per DMA is used, changing this attribute can cause the DMA to fail to start up.
    > - Together with the replication factor, the consistency level determines the maximum number of nodes that can be down before data unavailability occurs. For example, if a replication factor of 3 and consistency level of 2 are used, Cassandra queries will require an answer from 2 out of 3 replicas to be considered successful. This means that if one node is down, queries will still succeed, but if another node is down, it is possible that queries will no longer succeed.

4. Restart DataMiner.
