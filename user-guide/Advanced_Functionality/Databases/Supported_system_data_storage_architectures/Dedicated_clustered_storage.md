---
uid: Dedicated_clustered_storage
---

# Dedicated clustered storage

The **recommended** DataMiner setup can be either on premises or in the cloud, or a mix of both. You will need:

- One **Cassandra cluster** for the entire DataMiner System (DMS) or the [Amazon Keyspaces Service on AWS](xref:Amazon_Keyspaces_Service) or [Azure Managed Instance for Apache Cassandra](xref:Azure_Managed_Instance_for_Apache_Cassandra). Unlike setups with a Cassandra cluster per individual DataMiner Agent (DMA), this allows the database to be scaled for the entire DMS at once.

- One **Elasticsearch** or **OpenSearch** cluster for the entire DMS or the [Amazon OpenSearch Service on AWS](xref:Amazon_OpenSearch_Service).

> [!TIP]
> For information on how to implement a setup like this based on an existing DataMiner setup with SQL or Cassandra databases per DMA, see [Migrating the general database to a DMS Cassandra cluster](xref:Migrating_the_general_database_to_a_DMS_Cassandra_cluster)

> [!NOTE]
> Using managed services from a cloud provider instead of on-premises databases is supported from DataMiner 10.3.0/10.3.3 onwards. Using an on-premises OpenSearch database is also supported from DataMiner 10.3.0/10.3.3 onwards.

## Single DMA setups

We recommend running DataMiner, Cassandra, and Elasticsearch/OpenSearch on **dedicated machines**, or using **managed services from a cloud provider**. At present, we support the Amazon Keyspaces Service, Azure Managed Instance for Apache Cassandra Service, and Amazon OpenSearch Service. We intend to soon make it possible to deploy a DataMiner node as a service as well.

An on-premises **Elasticsearch** cluster should consist of **at least 3 nodes**, running on **Windows or Linux** machines. While it is possible to use one single Elasticsearch node, this means you will miss out on the replication features. An **OpenSearch** cluster is similar but only supports **Linux**.

For an on-premises **Cassandra** cluster, any number of nodes can be used, ideally running on **Linux** machines. To get an idea of how many nodes would be required for your system, use the [**node calculator**](https://community.dataminer.services/calculator/).

![Recommended setup: DataMiner, Cassandra, and Elasticsearch hosted on dedicated machines](~/user-guide/images/Recommended-Setup-1.png)<br>
*Recommended on-premises setup: DataMiner, Cassandra, and Elasticsearch hosted on dedicated machines*

![Recommended setup with managed services in the cloud](~/user-guide/images/Cloud-oneAgent.png)<br>
*Recommended setup with managed services in the cloud*

In a development environment with **limited load**, it is possible to host DataMiner, Cassandra, and Elasticsearch on **one Windows machine**. In this case, Elasticsearch and DataMiner must be installed on a separate disk or partition. However, note that this is not recommended for normal production environments.

![Development setup: DataMiner, Cassandra, and Elasticsearch hosted on the same machine](~/user-guide/images/Development-setup-DataMiner-Cassandra-and-Elasticsearch.png)<br>
*Development setup: DataMiner, Cassandra, and Elasticsearch hosted on the same machine*

## Multiple DMA (non-Failover) setups

In case you have more than one DataMiner Agent, you can scale both on DataMiner level and on database level. You can also use managed services from a cloud provider. At present, we support the Amazon Keyspaces Service, Azure Managed Instance for Apache Cassandra Service, and Amazon OpenSearch Service. We intend to soon make it possible to deploy a DataMiner node as a service as well.

An on-premises **Elasticsearch** cluster should ideally consist of **at least 3 nodes**, running on **Windows or Linux** machines. While it is possible to use one single Elasticsearch node, this means you will miss out on the replication features. Running two nodes is not supported. An **OpenSearch** cluster is similar but only supports **Linux**.

While we recommend running the DataMiner and Elasticsearch nodes on separate machines, it is also possible to host a DataMiner and Elasticsearch node on the same machine. In this case, Elasticsearch and DataMiner must be installed on a separate disk or partition. Note that in that case it is not required to install an Elasticsearch node on every single DataMiner node. While compute resources can be shared, logically there still is a separate DataMiner node cluster and Elasticsearch cluster.

For **Cassandra**, any number of nodes can be used, ideally running on **Linux** machines. To get an idea of how many nodes would be required for your system, use the [**node calculator**](https://community.dataminer.services/calculator/).

![Recommended setup: DataMiner, Cassandra, and Elasticsearch hosted on dedicated machines, with a minimum of three Elasticsearch nodes](~/user-guide/images/Recommended-Setup-2.png)<br>
*Recommended on-premises setup: DataMiner, Cassandra, and Elasticsearch hosted on dedicated machines, with a minimum of three Elasticsearch nodes*

![Recommended setup with managed services in the cloud](~/user-guide/images/Cloud.png)<br>
*Recommended setup with managed services in the cloud*

![Setup with Elasticsearch and DataMiner sharing resources](~/user-guide/images/Elasticsearch-DataMiner-sharing-resources.png)<br>
*Setup with Elasticsearch and DataMiner sharing resources*

![Two DMAs using a single Cassandra and Elasticsearch node running on dedicated machines](~/user-guide/images/Single-Cassandra-and-Elasticsearch-node.png)<br>
*Two DMAs using a single Cassandra and Elasticsearch node running on dedicated machines*

## Failover setups (without geo-redundancy)

A Failover setup is similar to the previously mentioned setups. You can consider the Failover pair to be like one DMA in the DMS. Both DataMiner instances point to the same databases. For added resilience, you can use **managed services in the cloud** instead of a Cassandra cluster and Elasticsearch/OpenSearch cluster on premises. At present, we support the Amazon Keyspaces Service, Azure Managed Instance for Apache Cassandra Service, and Amazon OpenSearch Service.

An on-premises setup should at the very least consist of two DataMiner machines, one Elasticsearch machine, and one Cassandra machine. However, if the Cassandra or Elasticsearch machine are no longer available in this setup, you will no longer be able to start DataMiner, so this is not recommended for redundancy setups. To be fully hardware-redundant, we recommend **at least three machines hosting Elasticsearch** nodes, **two machines hosting the DataMiner Failover pair** and **two machines hosting Cassandra nodes**. More Cassandra and Elasticsearch nodes can be needed depending on the load on your system. Check the [**node calculator**](https://community.dataminer.services/calculator/) for more information.

Note that in a Failover setup, it is bad practice to host the Elasticsearch nodes and DataMiner nodes on the same machine, as this would not allow you to get the desired resilience.

![DataMiner Failover pair using a Cassandra and Elasticsearch database running on dedicated machines](~/user-guide/images/Failover-pair-Cassandra-and-Elasticsearch.png)<br>
*DataMiner Failover pair using a Cassandra and Elasticsearch database running on dedicated machines*

![Minimum recommended setup for a fully redundant system](~/user-guide/images/Min-recom-setup-fully-redundant.png)<br>
*Minimum recommended on-premises setup for a fully redundant system*

![Recommended setup with managed services in the cloud](~/user-guide/images/Failover_recommended_setup.png)<br>
*Recommended setup with managed services in the cloud*

![DataMiner System consisting of three Failover pairs with Cassandra and Elasticsearch nodes running on dedicated machines](~/user-guide/images/3-Failover-pairs-Cassandra-and-Elasticsearch.png)<br>
*DataMiner System consisting of three Failover pairs with Cassandra and Elasticsearch nodes running on dedicated machines*

## Failover setups (with geo-redundancy)

To achieve geo-redundancy and reduce latency between DMAs deployed across the globe, typically data center setups are used. In case you need a setup with multiple data centers deployed worldwide, please contact Skyline.

The easiest way to achieve geo-redundancy for your databases is to use **managed services in the cloud** instead of a Cassandra cluster and Elasticsearch/OpenSearch cluster on premises. At present, we support the Amazon Keyspaces Service, Azure Managed Instance for Apache Cassandra Service, and Amazon OpenSearch Service.

![Setup with cloud services](~/user-guide/images/Cassandra_DataMiner_Opensearch.png)<br>
*Setup with managed services in the cloud*

If you want to go for an on-premises setup, **setting up an Elasticsearch cluster across high-latency nodes is not advised**. This is a strict constraint from Elastic in order not to compromise proper functionality. As such, it is not possible to simply take Elasticsearch nodes and spread them out over two or more locations if there is high latency between those locations. Note that this restriction specifically applies to latency between the Elasticsearch nodes, not between the DataMiner nodes and the Elasticsearch nodes. This is why we recommend that instead data is offloaded to multiple Elasticsearch clusters.

The figure below illustrates the recommended minimum setup for geo-redundancy with on-premises machines. For Cassandra, the built-in [NetworkTopologyStrategy](https://cassandra.apache.org/doc/4.0/cassandra/cql/ddl.html#networktopologystrategy) is used in order to configure geo-redundancy. For Elasticsearch, an option is available from DataMiner 10.1.3 onwards to push data from the DMS to two separate, geo-redundant Elasticsearch clusters. When one of the database clusters is temporarily unavailable, DataMiner will offload the data towards files to prevent data loss. Note that with this option, if there is an inconsistency between the two Elasticsearch clusters, it will not be synced.

![Recommended minimum setup for a geo-redundant system](~/user-guide/images/setup-for-a-geo-redundant-system.png)<br>
*Recommended minimum setup for a geo-redundant system*

Note that while there are several other options for a geo-redundant Failover setup with Elasticsearch, these are currently not supported in DataMiner:

- An optional paid feature of Elasticsearch supports the replication of data between two Elasticsearch clusters with high latency between them. However, this option is currently not supported by DataMiner and would come with a price tag, as this is a paid feature. For information on the cost of this feature, we recommend that you contact Elastic for an accurate quotation.

- Integrating Kafka and Logstash, as [described by Elastic](https://www.elastic.co/blog/scaling_elasticsearch_across_data_centers_with_kafka), is not available in DataMiner, and it is currently not on the roadmap for future releases.
