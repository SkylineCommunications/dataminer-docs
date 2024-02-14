---
uid: Supported_system_data_storage_architectures
---

# Supported system data storage architectures

The most straightforward of data storage architectures is [Storage as a Service (STaaS)](xref:STaaS). With this setup, you do not need to maintain the databases yourself, and all the scaling and complexity is taken care of for you. If you instead choose self-hosted storage, the most usual setup involves a Cassandra main database and OpenSearch indexing database for system data storage. However, note that with self-hosted storage, you are responsible for installing and maintaining the databases.

Other data storage solutions can be added optionally, for example to offload data from the DataMiner System and to make it available for third-party systems.

|Architecture | Status |
|-------------|--------|
| [Storage as a Service (STaaS)](xref:STaaS) | Recommended |
| [Dedicated clustered storage](xref:Dedicated_clustered_storage) | Supported |
| [Separate Cassandra setup with indexing](xref:Separate_Cassandra_setup_with_Elasticsearch) | Still supported, but not recommended |
| [Separate Cassandra setup without indexing](xref:Separate_Cassandra_setup_without_Elasticsearch) | Still supported, but not recommended |
| [Legacy setup with MySQL or MSSQL database](xref:Legacy_setup_with_MySQL_or_MSSQL_database) | Legacy |

> [!NOTE]
> If you would like to use a setup that is not described here, please contact [Skyline tech support](mailto:techsupport@skyline.be).
