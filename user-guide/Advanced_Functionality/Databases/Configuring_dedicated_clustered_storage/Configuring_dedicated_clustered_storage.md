---
uid: Configuring_dedicated_clustered_storage
---

# Configuring dedicated clustered storage

If you choose not to use the recommended [Storage as a Service (STaaS)](xref:STaaS) setup but instead choose self-hosted storage, typically, you will need to configure a dedicated clustered storage setup.

For this setup, both a Cassandra-compatible database service and [indexing database](xref:Indexing_Database) (also known as Search Cluster) are required. This setup can be either on premises or in the cloud, or a mix of both.

First install a Cassandra Cluster (i.e. a Cassandra cluster used for all DMAs in a DMS, as opposed to [a Cassandra cluster per DMA](xref:Configuring_storage_per_DMA)) or an equivalent database service, as this is a prerequisite for installing an indexing database afterwards. From DataMiner 10.3.0/10.3.3 onwards, Amazon Keyspaces Service on AWS is supported as an alternative for the Cassandra Cluster setup.

Then install the indexing database. You can use an on-premises OpenSearch cluster (supported from DataMiner 10.3.0/10.3.3 onwards) or Amazon OpenSearch Service on AWS (supported from DataMiner 10.3.0/10.3.3 onwards). While an Elasticsearch cluster can also be used, Elasticsearch is only supported up to version 6.8, so this is not recommended.

![dedicated clustered storage](~/user-guide/images/Dedicated_clustered_storage.svg)

- **Cassandra-compatible database service**

  - [Cassandra Cluster](xref:Cassandra_database): Supported from DataMiner 10.1.0/10.1.2 onwards.

  - [Amazon Keyspaces Service](xref:Amazon_Keyspaces_Service): Supported from DataMiner 10.3.0/10.3.3 onwards.

- **Indexing database or Search Cluster**

  > [!TIP]
  > For more information on deploying and configuring an indexing database, see [Indexing database](xref:Indexing_Database).

When both of the above have been installed, you can [configure the database settings in Cube](xref:Configuring_the_database_settings_in_Cube) or [specify the configuration data in the *DB.xml* file](xref:DB_xml). If you already had an existing DataMiner System using storage per DMA, you can [migrate to the clustered storage setup](xref:Migrating_the_general_database_to_a_DMS_Cassandra_cluster).

> [!TIP]
> For more information on this architecture and on other possible data storage architectures, see [Supported data storage architectures](xref:Supported_system_data_storage_architectures).

> [!NOTE]
> .dmimport packages created on a DMS using clustered storage do not contain any database data, and it is not possible to import database data from .dmimport packages into such a DMS.
