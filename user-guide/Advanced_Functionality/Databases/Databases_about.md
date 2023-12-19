---
uid: Databases_about
---

# About databases

DataMiner supports multiple different [system data storage architectures](xref:Supported_system_data_storage_architectures).

Each DataMiner System requires its own system data storage. This data storage serves as a repository for configuration data, historical parameter information, and alarm data.

<br/>

| | self-hosted | Skyline-hosted (SaaS) | all features available | scalable | easy installation | automatic backups | effortless maintenance |
|--|:--:|:--:|:--:|:--:|:--:|:--:|:--:|
| **Storage as a Service (STaaS)** | | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: |
| **Dedicated clustered storage** | :heavy_check_mark: | | :heavy_check_mark: | :heavy_check_mark: | | | |
| **Storage per DMA without indexing** | :heavy_check_mark: | | | | | | |
| **Storage per DMA with indexing** | :heavy_check_mark: | | :heavy_check_mark: | | | |  |

<br/>

- With **Storage as a Service** [(STaaS)](xref:STaaS) on dataminer.services, you do not need to maintain the databases yourself, and all the scaling and complexity is taken care of for you.

- If you prefer to host and manage the DataMiner storage yourself, you can configure a **dedicated clustered storage setup**, using a [Cassandra-compatible database service](xref:Cassandra_database) and an [indexing database](xref:Indexing_Database) (i.e. a Search Cluster).

- Instead of a dedicated clustered storage setup, it is also possible to use **storage per DMA** (with [Cassandra](xref:Migrating_the_general_database_to_Cassandra) or [MySQL](xref:MySQL_database)), though this is not recommended. If you are still using a legacy setup with MySQL, we highly recommend migrating to Cassandra, as MySQL is no longer supported as of DataMiner 10.3. If you are using a setup with Cassandra, we also highly recommend adding an [indexing database](xref:Indexing_Database) to make sure you have access to features such as DOM and SRM.

In addition to the system databases, you can also configure an [offload database](xref:Offload_database), for example to produce reports without interfering with the live DataMiner System. [Additional databases](xref:Configuring_an_additional_database) can also be configured, for example for DataMiner Inventory & Asset Management.

> [!TIP]
> See also:
>
> - [Securing the DataMiner databases](xref:Cassandra_authentication)
> - [Third-party software support life cycle](xref:Software_support_life_cycles#third-party-software-support-life-cycle)

> [!NOTE]
> When the main database is offline, file offloads are used to store write/delete operations. You can configure a limit for the file size of these offloads in the file [DBConfiguration.xml](xref:DBConfiguration_xml).
