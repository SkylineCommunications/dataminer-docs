---
uid: About_storage
description: "Learn about DataMiner storage options and why Storage as a Service is the recommended choice for scalable, low-maintenance storage."
---

# About storage

Each DataMiner System requires its own system data storage. This serves as a repository for configuration data, historical parameter information, and alarm data.

The recommended system data storage architecture is [Storage as a Service (STaaS)](xref:STaaS) on dataminer.services. With STaaS, you do not need to maintain the databases yourself, and Skyline manages database capacity, redundancy, and storage backups.

## Choosing system data storage

For a comparison of the available architectures and their support status, see [Storage options overview](xref:Supported_system_data_storage_architectures). Check [STaaS features and limitations](xref:STaaS_features) against the functionality your solution uses, especially when migrating an existing system.

Though this is **not recommended**, you can also host and manage the DataMiner storage yourself. In that case, use [dedicated clustered storage](xref:Dedicated_clustered_storage), consisting of a Cassandra cluster and an OpenSearch cluster on dedicated Linux machines. You are responsible for capacity, database maintenance, redundancy, and backups.

Older systems can still use **storage per DMA** with Cassandra or (prior to DataMiner 10.6) MySQL. These architectures are obsolete and do not support all DataMiner features, including Swarming. Plan a migration using [Migrating existing data to STaaS](xref:Migrating_existing_data_to_STaaS), and check the prerequisites for your current storage architecture. Direct migration from MySQL to STaaS is not supported; see [STaaS migration limitations](xref:STaaS_features#limitations).

## Storage availability and offloading

When the main database is offline, file offloads are used to store write/delete operations. You can configure a limit for the size of these offloads in [DB.xml](xref:DB_xml#configuring-a-size-limit-for-file-offloads). File offloads do not replace database redundancy or backups.

You can also configure [data offloads to a separate database or to files](xref:Offload_database), for example to produce reports without interfering with the live DataMiner System.

> [!TIP]
> See also:
>
> - [DataMiner System architecture and components](xref:Overview_Architecture_and_components)
> - [DataMiner deployment models](xref:Overview_hosting)
> - [Securing the DataMiner databases](xref:Cassandra_authentication)
> - [Third-party software support lifecycle](xref:Software_support_life_cycles#third-party-software-support-lifecycle)
