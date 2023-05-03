---
uid: Configuring_a_dedicated_clustered_storage
---

# Configuring a dedicated clustered storage

To properly configure a dedicated clustered storage setup, both a Cassandra-compatible database service and Search Cluster are required. This setup can be either on premises or in the cloud, or a mix of both.

First install the Cassandra Cluster or equivalent database service, as this is a prerequisite for installing a Search Cluster afterwards. From DataMiner 10.3.0/10.3.3 onwards, it is possible to use Amazon Keyspaces Service on AWS as an alternative for the Cassandra Cluster setup.

From DataMiner 10.3.0/10.3.3 onwards, it is possible to use Amazon OpenSearch Service on AWS and an on-premises hosted OpenSearch cluster as an alternative to the on-premises Elasticsearch cluster that has been available from DataMiner 9.6.4 onwards.

- **Cassandra-compatible database service**

  - [Cassandra Cluster](xref:Cassandra_database)

  - [Amazon Keyspaces Service](xref:Amazon_Keyspaces_Service): Available from DataMiner 10.3.0/10.3.3 onwards.

- **Search Cluster**

  - [Elasticsearch](xref:Deploying_the_Elasticsearch_database): Available from DataMiner 9.6.4 onwards.

  - [Amazon OpenSearch Service](xref:Amazon_OpenSearch_Service): Available from DataMiner 10.3.0/10.3.3 onwards.

  - [OpenSearch database](xref:Deploying_OpenSearch_database): Available from DataMiner 10.3.0/10.3.3 onwards.

After the installation is complete, you can [configure the database settings in Cube](xref:Configuring_the_database_settings_in_Cube) or [specify the configuration data in the *DB.xml* file](xref:DB_xml).

> [!TIP]
> For more information on the recommended DataMiner setup, see [Supported system data architectures](xref:Supported_system_data_storage_architectures).