---
uid: Offload_database
keywords: central database
---

# Offloading data

DataMiner supports data offloads to a database or to files.

You can for example [set up an offload or "central" database](xref:Setting_up_an_offload_database) in your DataMiner System to produce all kinds of reports without interfering with the live DataMiner System. Even the most demanding database queries will not have any impact on the performance of your DMAs. The following database types are supported:

- MySQL
- MSSQL
- Oracle

The offloads to a database or to files are configured in [System Center](xref:Configuring_data_offloads).

> [!IMPORTANT]
>
> - For [DaaS](xref:Creating_a_DMS_in_the_cloud) Agents, only offloads to files are supported.
> - Some data offloading features are not available when [Swarming](xref:Swarming) is enabled. See [Offload database configuration with Swarming enabled](xref:Offload_Database_With_Swarming) for more information.
