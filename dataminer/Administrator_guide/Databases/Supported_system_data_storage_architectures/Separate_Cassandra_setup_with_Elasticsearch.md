---
uid: Separate_Cassandra_setup_with_Elasticsearch
---

# Separate Cassandra setup with indexing

> [!IMPORTANT]
> This architecture is currently still supported, but it is **not recommended**. Instead, we recommend using [Storage as a Service (STaaS)](xref:STaaS).
>
> Elasticsearch is only supported up to version 6.8. As this version is no longer supported by Elastic, we recommend using OpenSearch instead.

With this architecture, **each DMA has its own Cassandra database** (which can be a cluster with several nodes). However, only one OpenSearch/Elasticsearch cluster is used for the entire DMS.

The [Swarming](xref:Swarming) feature is not available in DataMiner Systems that use this architecture.

> [!TIP]
> An indexing database is not supported for DataMiner Systems with a MySQL/MSSQL database. For information on how to migrate a legacy setup with MySQL/MSSQL database to Cassandra, see [Migrating the general database to Cassandra](xref:Migrating_the_general_database_to_Cassandra).

> [!NOTE]
>
> In the setups described below, a "machine" or "compute node" can be a virtual machine or a physical server. Every machine must meet the minimum requirements detailed in [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements). In the images illustrating the setups, the dark-blue line indicates a cluster of nodes, the gray line indicates a compute node, and the light-blue line indicates a regional boundary (high latency).

In a development environment with limited load, it is possible to host DataMiner, Cassandra, and OpenSearch/Elasticsearch on one Windows machine. In this case, OpenSearch/Elasticsearch and DataMiner must be installed on a separate disk or partition. However, this is not recommended for normal production environments. In addition, note that Cassandra is no longer supported on Windows starting from Cassandra 4.x and DataMiner 10.4.x.

![Development setup: DataMiner, Cassandra, and OpenSearch hosted on the same machine](~/dataminer/images/Development-setup-DataMiner-Cassandra-and-OpenSearch.png)<br>
*Development setup: DataMiner, Cassandra, and OpenSearch hosted on the same machine*

Instead, we recommend running DataMiner, Cassandra, and OpenSearch/Elasticsearch on dedicated machines.

The OpenSearch/Elasticsearch cluster should ideally consist of at least 3 nodes, running on Windows or Linux machines. While it is possible to use one single OpenSearch/Elasticsearch node, this means you will miss out on the replication features.

For Cassandra, any number of nodes can be used, running on Linux machines. To get an idea of how many nodes would be required for your system, use the [node calculator](https://community.dataminer.services/calculator/).

Several possible setups are illustrated below.

![A DataMiner, Cassandra, and OpenSearch node, each running on dedicated machines](~/dataminer/images/DataMiner-Cassandra-and-OpenSearch-node.png)<br>
*A DataMiner, Cassandra, and OpenSearch node, each running on dedicated machines*

![A DMS consisting of four DMAs, each with their own Cassandra database, and an OpenSearch cluster](~/dataminer/images/DMS-consisting-of-four-DMAs.png)<br>
*A DMS consisting of four DMAs, each with their own Cassandra database, and an OpenSearch cluster*

![Failover pair with Cassandra database hosted on the same machines as DataMiner and a one-node OpenSearch database](~/dataminer/images/Failover-pair-with-Cassandra-database.png)<br>
*Failover pair with Cassandra database hosted on the same machines as DataMiner and a one-node OpenSearch database*

![Two Failover pairs, each with two Cassandra nodes running on the same machines, and a three-node OpenSearch database for the entire DMS](~/dataminer/images/two-Cassandra-nodes-running-on-the-same-machines.png)<br>
*Two Failover pairs, each with two Cassandra nodes running on the same machines, and a three-node OpenSearch database for the entire DMS*
