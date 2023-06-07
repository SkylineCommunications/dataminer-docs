---
uid: Databases_about
---

# About databases

DataMiner supports multiple different [system data storage architectures](xref:Supported_system_data_storage_architectures).

Each DataMiner System requires its own system data storage. This data storage serves as a repository for configuration data, historical parameter information, and alarm data.

- Soon it will be possible to use **Storage as a Service** [(STaaS)](xref:STaaS) on dataminer.services for this, so you no longer have to maintain the databases yourself, and all the scaling and complexity is taken care of for you.

- At present, it is possible to configure a **dedicated clustered storage setup**, using a [Cassandra-compatible database service](xref:Cassandra_database) and an [indexing database](xref:Elasticsearch_database) (i.e. a Search Cluster).

- Instead of a dedicated clustered storage setup, it is also possible to configure **storage per DMA** ([Cassandra](xref:Migrating_the_general_database_to_Cassandra) or [MySQL](xref:MySQL_database)) and an **indexing database per DMA**, an [Elasticsearch database](xref:Configuring_indexing_database_per_DMA) used to store specific data for features such as the Jobs and Dashboards app.

In addition to the system databases, you can also configure an [offload database](xref:Offload_database), for example to produce reports without interfering with the live DataMiner System. [Additional databases](xref:Configuring_an_additional_database) can also be configured, for example for DataMiner Inventory & Asset Management.

> [!TIP]
> See also: [Securing the DataMiner databases](xref:Database_security)

> [!NOTE]
> When the main database is offline, file offloads are used to store write/delete operations. You can configure a limit for the file size of these offloads in the file [DBConfiguration.xml](xref:DBConfiguration_xml).
