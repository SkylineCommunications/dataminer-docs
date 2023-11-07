---
uid: Separate_Cassandra_setup_with_Elasticsearch
---

# Separate Cassandra setup with Elasticsearch

> [!IMPORTANT]
> This architecture is currently still supported, but it is **not recommended**. Instead, we recommend using [Storage as a Service (STaaS)](xref:STaaS).
>
> Elasticsearch is only supported up to version 6.8. If you do want to use self-hosted storage instead of STaaS, we therefore recommend using [dedicated clustered storage](xref:Dedicated_clustered_storage) with OpenSearch.

With this architecture, **each DMA has its own Cassandra database** (which can be a cluster with several nodes). However, only one Elasticsearch cluster is used for the entire DMS.

> [!TIP]
>
> - For information on how to migrate a legacy setup with MySQL/MSSQL database to Cassandra, see [Migrating the general database to Cassandra](xref:Migrating_the_general_database_to_Cassandra).
> - Elasticsearch can only be installed if DataMiner already uses Cassandra. For more information, see [Installing Elasticsearch on a DMA via DataMiner](xref:Installing_Elasticsearch_via_DataMiner).

> [!NOTE]
>
> - To use OpenSearch instead, switch to a [dedicated clustered storage setup](xref:Configuring_dedicated_clustered_storage).
> - In the setups described below, a "machine" or "compute node" can be a virtual machine or a physical server. Every machine must meet the minimum requirements detailed in [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements). In the images illustrating the setups, the dark-blue line indicates a cluster of nodes, the gray line indicates a compute node, and the light-blue line indicates a regional boundary (high latency).

In a development environment with limited load, it is possible to host DataMiner, Cassandra, and Elasticsearch on one Windows machine. In this case, Elasticsearch and DataMiner must be installed on a separate disk or partition. However, this is not recommended for normal production environments.

![Development setup: DataMiner, Cassandra, and Elasticsearch hosted on the same machine](~/user-guide/images/Development-setup-DataMiner-Cassandra-and-Elasticsearch.png)<br>
*Development setup: DataMiner, Cassandra, and Elasticsearch hosted on the same machine*

Instead, we recommend running DataMiner, Cassandra, and Elasticsearch on dedicated machines.

The Elasticsearch cluster should ideally consist of at least 3 nodes, running on Windows or Linux machines. While it is possible to use one single Elasticsearch node, this means you will miss out on the replication features.

For Cassandra, any number of nodes can be used, ideally running on Linux machines. To get an idea of how many nodes would be required for your system, use the [node calculator](https://community.dataminer.services/calculator/).

Several possible setups are illustrated below.

![A DataMiner, Cassandra, and Elasticsearch node, each running on dedicated machines](~/user-guide/images/DataMiner-Cassandra-and-Elasticsearch-node.png)<br>
*A DataMiner, Cassandra, and Elasticsearch node, each running on dedicated machines*

![A DMS consisting of four DMAs, each with their own Cassandra database, and an Elasticsearch cluster](~/user-guide/images/DMS-consisting-of-four-DMAs.png)<br>
*A DMS consisting of four DMAs, each with their own Cassandra database, and an Elasticsearch cluster*

![Failover pair with Cassandra database hosted on the same machines as DataMiner and a one-node Elasticsearch database](~/user-guide/images/Failover-pair-with-Cassandra-database.png)<br>
*Failover pair with Cassandra database hosted on the same machines as DataMiner and a one-node Elasticsearch database*

![Two Failover pairs, each with two Cassandra nodes running on the same machines, and a three-node Elasticsearch database for the entire DMS](~/user-guide/images/two-Cassandra-nodes-running-on-the-same-machines.png)<br>
*Two Failover pairs, each with two Cassandra nodes running on the same machines, and a three-node Elasticsearch database for the entire DMS*
