---
uid: Databases_about
---

# About databases

DataMiner supports multiple different [system data storage architectures](xref:Supported_system_data_storage_architectures).

Each DataMiner System requires its own system data storage. This data storage serves as a repository for configuration data, historical parameter information, and alarm data.

- Soon it will be possible to use **Storage as a Service** [(STaaS)](xref:STaaS) on dataminer.services for this, so you no longer have to maintain the databases yourself, and all the scaling and complexity is taken care of for you.

- At present, it is possible to configure a **dedicated clustered storage setup**, using a [Cassandra-compatible database service](xref:Cassandra_database) and an [indexing database](xref:Indexing_Database) (i.e. a Search Cluster).

  ![dedicated clustered storage](~/user-guide/images/Dedicated_clustered_storage.svg)

- Instead of a dedicated clustered storage setup, it is also possible to configure **storage per DMA** ([Cassandra](xref:Migrating_the_general_database_to_Cassandra) or [MySQL](xref:MySQL_database)). If you have an existing legacy DataMiner System with SQL database, we highly recommend migrating to Cassandra to gain access to additional DataMiner features.

  ![storage per DMA](~/user-guide/images/Storage_per_DMA.svg)

- If you use a Cassandra database per DMA, it is possible to configure an **indexing database per DMS**, an [Elasticsearch database](xref:Configuring_indexing_database_per_DMS) used to store specific data for features such as the Jobs and Dashboards app. Installing an Elasticsearch indexing database unlocks numerous additional DataMiner features, such as GQI, SRM, and more.

  ![indexing database per DMS](~/user-guide/images/Indexing_database_per_DMS.svg)

In addition to the system databases, you can also configure an [offload database](xref:Offload_database), for example to produce reports without interfering with the live DataMiner System. [Additional databases](xref:Configuring_an_additional_database) can also be configured, for example for DataMiner Inventory & Asset Management.

> [!TIP]
> See also: [Securing the DataMiner databases](xref:Database_security)

> [!NOTE]
> When the main database is offline, file offloads are used to store write/delete operations. You can configure a limit for the file size of these offloads in the file [DBConfiguration.xml](xref:DBConfiguration_xml).
