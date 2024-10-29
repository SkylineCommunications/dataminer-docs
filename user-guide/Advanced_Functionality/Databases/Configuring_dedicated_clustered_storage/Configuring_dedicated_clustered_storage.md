---
uid: Configuring_dedicated_clustered_storage
---

# Configuring dedicated clustered storage

If you choose not to use the recommended [Storage as a Service (STaaS)](xref:STaaS) setup but instead choose self-hosted storage, typically, you will need to configure a dedicated clustered storage setup.

For this setup, both a Cassandra Cluster and indexing database (also known as Search Cluster) are required. This setup can be either on premises or in the cloud, or a mix of both.

First install a [Cassandra Cluster](xref:Cassandra_database) (i.e. a Cassandra cluster used for all DMAs in a DMS, as opposed to [a Cassandra cluster per DMA](xref:Configuring_storage_per_DMA)), as this is a prerequisite for installing an indexing database afterwards. Note that Amazon Keyspaces Service on AWS is supported as an alternative for the Cassandra Cluster setup from DataMiner 10.3.0 [CU0] up to 10.3.0 [CU8] and from DataMiner 10.3.3 up to 10.3.11, but this is not recommended, as this setup is considered deprecated in later DataMiner versions.

Then install the [indexing database](xref:Indexing_Database). We recommend an on-premises OpenSearch cluster (supported from DataMiner 10.3.0/10.3.3 onwards). While an Elasticsearch cluster can also be used, Elasticsearch is only supported up to version 6.8. As this version is no longer supported by Elastic, this is not recommended.

![dedicated clustered storage](~/user-guide/images/Dedicated_clustered_storage.svg)

When both of the above have been installed, you can [configure the database settings in Cube](xref:Configuring_the_database_settings_in_Cube) or [specify the configuration data in the *DB.xml* file](xref:DB_xml). If you already had an existing DataMiner System using storage per DMA, you can [migrate to the clustered storage setup](xref:Migrating_the_general_database_to_a_DMS_Cassandra_cluster).

> [!TIP]
> For more information on this architecture and on other possible data storage architectures, see [Supported data storage architectures](xref:Supported_system_data_storage_architectures).

> [!NOTE]
>
> - .dmimport packages created on a DMS using clustered storage do not contain any database data, and it is not possible to import database data from .dmimport packages into such a DMS.
> - If you deployed DataMiner using the [pre-installed DataMiner Virtual Hard Disk](xref:Using_a_pre_installed_DataMiner_Virtual_Hard_Disk) and you chose the *Self-Hosted - Local Storage* data storage option, both Cassandra and OpenSearch run locally on the virtual machine on Windows Subsystem for Linux (WSL). This setup should only be used for testing and staging environments. If you switch such a setup to production and start using [STaaS](xref:STaaS) or Cassandra and OpenSearch clusters on separate servers instead, you will need to then [decommission WSL](xref:Decommissioning_WSL) so it no longer consumes any resources.
