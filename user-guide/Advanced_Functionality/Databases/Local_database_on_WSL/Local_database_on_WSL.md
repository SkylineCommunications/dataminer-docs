---
uid: Local_database_on_WSL
---

# Local database on WSL

If you deployed DataMiner by using the [pre-installed DataMiner Virtual Hard Disk](xref:Using_a_pre_installed_DataMiner_VHDX) and you chose the WSL database configuration, both Cassandra Cluster and OpenSearch run locally on the Virtual Machine on Windows Subsystem for Linux (WSL).

This allows you to easily get started with a database setup that supports all DataMiner functionalities.

> [!NOTE]
> This setup should only be used for test and staging environments. Make sure to provide sufficient resources to the Virtual Machine. Consider migrating to [Storage as a Service (STaaS)](xref:STaaS) or [configure dedicated clustered storage](xref:Configuring_dedicated_clustered_storage) if you intend to use it in production.
