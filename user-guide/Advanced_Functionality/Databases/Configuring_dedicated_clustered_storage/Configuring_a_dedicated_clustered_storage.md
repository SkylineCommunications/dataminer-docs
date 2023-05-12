---
uid: Configuring_dedicated_clustered_storage
---

# Configuring dedicated clustered storage

To properly configure a dedicated clustered storage setup, both a Cassandra-compatible database service and indexing database (also known as Search Cluster) are required. This setup can be either on premises or in the cloud, or a mix of both.

First install a Cassandra Cluster (i.e. a Cassandra cluster used for all DMAs in a DMS, as opposed to [a Cassandra cluster per DMA](xref:Configuring_storage_per_DMA)) or an equivalent database service, as this is a prerequisite for installing an indexing database afterwards. From DataMiner 10.3.0/10.3.3 onwards, Amazon Keyspaces Service on AWS is supported as an alternative for the Cassandra Cluster setup.

Then install the indexing database. You can use an on-premises Elasticsearch cluster (supported from DataMiner 9.6.4 onwards), Amazon OpenSearch Service on AWS (supported from DataMiner 10.3.0/10.3.3 onwards), or an on-premises OpenSearch cluster (supported from DataMiner 10.3.0/10.3.3 onwards).

- **Cassandra-compatible database service**

  - [Cassandra Cluster](xref:Cassandra_database): Supported from DataMiner 10.1.0/10.1.2 onwards.

  - [Amazon Keyspaces Service](xref:Amazon_Keyspaces_Service): Supported from DataMiner 10.3.0/10.3.3 onwards.

- **Indexing database or Search Cluster**

  - [Elasticsearch](xref:Deploying_the_Elasticsearch_database): Supported from DataMiner 9.6.4 onwards.

  - [Amazon OpenSearch Service](xref:Amazon_OpenSearch_Service): Supported from DataMiner 10.3.0/10.3.3 onwards.

  - [OpenSearch database](xref:OpenSearch_database): Supported from DataMiner 10.3.0/10.3.3 onwards.

When both of the above have been installed, you can [configure the database settings in Cube](xref:Configuring_the_database_settings_in_Cube) or [specify the configuration data in the *DB.xml* file](xref:DB_xml). If you already had an existing DataMiner System using storage per DMA, you can [migrate to the clustered storage setup](xref:Migrating_the_general_database_to_a_DMS_Cassandra_cluster).

> [!TIP]
> For more information on the recommended data storage architecture, see [Supported system data architectures](xref:Supported_system_data_storage_architectures).
