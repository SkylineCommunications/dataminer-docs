---
uid: Separate_Cassandra_setup_with_Elasticsearch
description: "Explore how, if you do not want to use the recommended STaaS setup, you can set up a separate Cassandra database with indexing per DMA."
keywords: Cassandra Single
---

# Separate Cassandra setup with indexing

> [!IMPORTANT]
> Support for this architecture ends in DataMiner 10.8.x. We recommend using [Storage as a Service (STaaS)](xref:STaaS) instead. For details, see [Software support lifecycles](xref:Software_support_life_cycles).
>
> This setup cannot be used with an Elasticsearch version higher than 6.8. DataMiner support for this ends in DataMiner 10.7.x, so if you need to continue using self-hosted storage, we recommend using OpenSearch instead.

With this architecture, **each DMA has its own Cassandra database** (which can be a cluster with several nodes). However, only one OpenSearch/Elasticsearch cluster is used for the entire DMS.

The [Swarming](xref:Swarming) feature is not available in DataMiner Systems that use this architecture.

> [!TIP]
> An indexing database is not supported for DataMiner Systems with a MySQL/MSSQL database. For information on how to migrate a legacy setup with MySQL/MSSQL database to Cassandra, see [Migrating the general database to Cassandra](xref:Migrating_the_general_database_to_Cassandra).

> [!NOTE]
>
> In the setups described below, a "machine" or "compute node" can be a virtual machine or a physical server. Every machine must meet the minimum requirements detailed in [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements). In the images illustrating the setups, the dark-blue line indicates a cluster of nodes, the gray line indicates a compute node, and the light-blue line indicates a regional boundary (high latency).

Run Cassandra and OpenSearch on dedicated Linux machines, separately from the Windows machines hosting DataMiner. Native Windows installations of OpenSearch are not recommended. Cassandra is no longer supported on Windows starting from Cassandra 4.x and DataMiner 10.4.x.

![Development setup: DataMiner, Cassandra, and OpenSearch hosted on the same machine](~/dataminer/images/Development-setup-DataMiner-Cassandra-and-OpenSearch.png)<br>
*Development setup: DataMiner, Cassandra, and OpenSearch hosted on the same machine*

For OpenSearch, use at least three cluster-manager-eligible nodes on Linux, with an odd number of voting nodes, and configure data replication. See [Installing an OpenSearch database](xref:Installing_OpenSearch_database). A single-node setup does not provide storage redundancy.

For Cassandra, size the Linux nodes using the [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements#cassandra-requirements), and account for replication and the workload of each DMA.

The following diagrams illustrate existing deployments, not recommendations for new systems. Database nodes shown sharing a host with DataMiner are legacy configurations. [Failover](xref:failover) has reached End of Engineering; new systems should use shared storage and [Swarming](xref:Swarming) with [Node Recovery](xref:NodeRecovery_About).

![A DataMiner, Cassandra, and OpenSearch node, each running on dedicated machines](~/dataminer/images/DataMiner-Cassandra-and-OpenSearch-node.png)<br>
*A DataMiner, Cassandra, and OpenSearch node, each running on dedicated machines*

![A DMS consisting of four DMAs, each with their own Cassandra database, and an OpenSearch cluster](~/dataminer/images/DMS-consisting-of-four-DMAs.png)<br>
*A DMS consisting of four DMAs, each with their own Cassandra database, and an OpenSearch cluster*

![Failover pair with Cassandra database hosted on the same machines as DataMiner and a one-node OpenSearch database](~/dataminer/images/Failover-pair-with-Cassandra-database.png)<br>
*Failover pair with Cassandra database hosted on the same machines as DataMiner and a one-node OpenSearch database*

![Two Failover pairs, each with two Cassandra nodes running on the same machines, and a three-node OpenSearch database for the entire DMS](~/dataminer/images/two-Cassandra-nodes-running-on-the-same-machines.png)<br>
*Two Failover pairs, each with two Cassandra nodes running on the same machines, and a three-node OpenSearch database for the entire DMS*
