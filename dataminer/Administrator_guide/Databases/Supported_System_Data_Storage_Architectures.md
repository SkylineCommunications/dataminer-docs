---
uid: Supported_system_data_storage_architectures
description: "Compare DataMiner storage architectures, including the recommended STaaS option and supported self-managed options for system data storage."
---

# Storage options overview

Choose system data storage independently of where your self-managed DataMiner nodes run. DaaS and hybrid clusters always use STaaS. For an introduction to what is stored, see [About storage](xref:About_storage); for the compute hosting choices, see [DataMiner deployment models](xref:Overview_hosting).

Other data storage solutions can be added optionally, for example to offload data from the DataMiner System and to make it available for third-party systems.

| Architecture | Operation and maintenance | Status |
|--|--|--|
| [Storage as a Service (STaaS)](xref:STaaS) | Skyline manages database capacity, maintenance, redundancy, and storage backups. Review [features and limitations](xref:STaaS_features). | Recommended |
| [Dedicated clustered storage](xref:Dedicated_clustered_storage) | You manage Cassandra and OpenSearch clusters on dedicated Linux machines, including capacity, redundancy, and backups. | Supported, but **not recommended** |
| [Separate Cassandra setup with indexing](xref:Separate_Cassandra_setup_with_Elasticsearch) | Each DMA has its own Cassandra database; the DMS shares an indexing cluster. Does not support Swarming. | Deprecated |
| [Separate Cassandra setup without indexing](xref:Separate_Cassandra_setup_without_Elasticsearch) | Each DMA has its own Cassandra database, without an indexing cluster. Does not support Swarming and lacks features requiring indexing. | Deprecated |
| [Legacy setup with MySQL or MSSQL database](xref:Legacy_setup_with_MySQL_or_MSSQL_database) | Legacy storage per DMA, with limited functionality. | Legacy |

For the versions in which support ends for legacy databases and storage per DMA, see [Software support lifecycles](xref:Software_support_life_cycles). These setups are documented for maintaining and migrating existing systems, not for new deployments.

> [!NOTE]
> If you would like to use a setup that is not described here, please contact [DataMiner Support](mailto:support@dataminer.services).

> [!TIP]
> To see how these storage options fit into complete system architectures, see [DataMiner System architecture and components](xref:Overview_Architecture_and_components).
