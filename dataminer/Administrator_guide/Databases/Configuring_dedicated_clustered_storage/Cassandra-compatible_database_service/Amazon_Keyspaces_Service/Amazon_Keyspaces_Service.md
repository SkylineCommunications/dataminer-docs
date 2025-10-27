---
uid: Amazon_Keyspaces_Service
---

# Amazon Keyspaces Service

> [!IMPORTANT]
> This setup is deprecated. We recommend using [Storage as a Service (STaaS)](xref:STaaS) instead.

Using the Amazon Keyspaces Service on AWS as an alternative for a Cassandra Cluster setup is supported from DataMiner 10.3.0 [CU0] up to 10.3.0 [CU8] and from DataMiner 10.3.3 up to 10.3.11.

In this section of the documentation, you can find instructions on [how to deploy the Amazon Keyspaces Service](xref:Deploying_Amazon_Keyspaces_Service) as a first step in configuring dedicated clustered storage.

> [!IMPORTANT]
> Migrating existing databases to Amazon Keyspaces is not supported.

> [!NOTE]
>
> - For information on how to use Amazon AWS with a DataMiner Failover setup, see [DataMiner Failover on Amazon Web Services](xref:Failover_AWS).
> - Amazon Keyspaces does not support all Cassandra functionality, most notably indices on columns. As a result, some queries against logger tables (including SLAs) may be slower on Amazon Keyspaces compared to Cassandra.
> - The only consistency level supported is `Local Quorum`. See [Supported Apache Cassandra consistency levels in Amazon Keyspaces](https://docs.aws.amazon.com/keyspaces/latest/devguide/consistency.html). No matter the configuration, the consistency level will always be overwritten to `Local Quorum`.
> - The only replication strategy supported is the Amazon Keyspaces specific `Single-Region strategy`, which is not configurable.

> [!TIP]
> See also: [Storage options overview](xref:Supported_system_data_storage_architectures)
