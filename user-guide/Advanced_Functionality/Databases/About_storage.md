---
uid: About_storage
---

# About storage

Each DataMiner System requires its own system data storage. This data storage serves as a repository for configuration data, historical parameter information, and alarm data.

The recommended system data storage architecture is **Storage as a Service** [(STaaS)](xref:STaaS) on dataminer.services. With StaaS, you do not need to maintain the databases yourself, and all the scaling and complexity is taken care of for you.

<br/>

| | self-managed | Skyline-hosted (SaaS) | all features available | scalable | easy installation | automatic backups | effortless maintenance |
|--|:--:|:--:|:--:|:--:|:--:|:--:|:--:|
| **Storage as a Service (STaaS)** | | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: |
| **Dedicated clustered storage** | :heavy_check_mark: | | :heavy_check_mark: | :heavy_check_mark: | | | |
| **Storage per DMA** | :heavy_check_mark: | | | | | | |

<br/>

Though this is **not recommended**, you can also host and manage the DataMiner storage yourself. In that case, you will need to configure a **dedicated clustered storage** setup, using a [Cassandra-compatible database service](xref:Cassandra_database) and an [indexing database](xref:Indexing_Database) (i.e. a Search Cluster). While all features are also available with this setup, managing and maintaining it is a great deal **more complex**.

Instead of a dedicated clustered storage setup, older systems often still use **storage per DMA** with [Cassandra](xref:Migrating_the_general_database_to_Cassandra) or (prior to DataMiner 10.6) [MySQL](xref:MySQL_database), but this is **not recommended and not all DataMiner features** are available in such a setup. We highly recommend [migrating to a STaaS setup](xref:STaaS#migrating-existing-data-to-staas) instead. To migrate a MySQL setup to STaaS, you will first need to [migrate to Cassandra](xref:Migrating_the_general_database_to_Cassandra).

> [!TIP]
> See also:
>
> - [DataMiner Hosting and High Availability](xref:Overview_hosting)
> - [Securing the DataMiner databases](xref:Cassandra_authentication)
> - [Third-party software support life cycle](xref:Software_support_life_cycles#third-party-software-support-life-cycle)

> [!NOTE]
>
> - When the main database is offline, file offloads are used to store write/delete operations. You can configure a limit for the file size of these offloads in the file [DBConfiguration.xml](xref:DBConfiguration_xml).
> - You can also configure [data offloads to a separate database or to files](xref:Offload_database), for example in order to produce all kinds of reports without interfering with the live DataMiner System.
