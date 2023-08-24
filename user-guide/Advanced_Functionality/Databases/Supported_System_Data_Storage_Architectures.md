---
uid: Supported_system_data_storage_architectures
---

# Supported system data storage architectures

Usually, DataMiner uses a Cassandra and Elasticsearch database for system data storage. Other data storage solutions can be added optionally, for example to offload data from the DataMiner System and to make it available for third-party systems.

For the system data storage, different setups are supported, as described below. In these setups, a "machine" or "compute node" can be a virtual machine or a physical server. Every machine must meet the minimum requirements detailed in [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements).

In the images illustrating the setups, the dark-blue line indicates a cluster of nodes, the gray line indicates a compute node, and the light-blue line indicates a regional boundary (high latency).

|Architecture | Status |
|-------------|--------|
| [Dedicated clustered storage](xref:Dedicated_clustered_storage) | Recommended |
| [Separate Cassandra setup with Elasticsearch](xref:Separate_Cassandra_setup_with_Elasticsearch) | Still supported, but not recommended |
| [Separate Cassandra setup without Elasticsearch](xref:Separate_Cassandra_setup_without_Elasticsearch) | Still supported, but not recommended |
| [Legacy setup with MySQL or MSSQL database](xref:Legacy_setup_with_MySQL_or_MSSQL_database) | Legacy |

> [!NOTE]
> If you would like to use a setup that is not described here, please contact [Skyline tech support](mailto:techsupport@skyline.be).
