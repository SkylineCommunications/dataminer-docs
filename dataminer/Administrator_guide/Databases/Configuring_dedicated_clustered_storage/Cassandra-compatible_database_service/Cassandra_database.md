---
uid: Cassandra_database
---

# Cassandra Cluster

If you choose not to use the recommended [Storage as a Service (STaaS)](xref:STaaS) setup but instead choose self-managed storage, typically, you will need to [deploy a Cassandra Cluster setup](xref:Installing_Cassandra) (supported from DataMiner 10.1.0/10.1.2 onwards). This is the first step in configuring self-managed dedicated clustered storage.

For information on how to **configure the settings** for your Cassandra Cluster setup in DataMiner Cube, see [Configuring the database settings in Cube](xref:Configuring_the_database_settings_in_Cube). For more information on how to **monitor your database, keep your nodes repaired, and keep your software up to date**, see [Maintaining a Cassandra cluster](xref:Maintain_Cassandra_Cluster).

> [!NOTE]
>
> - For information on the system requirements for Cassandra, refer to [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements).
> - If a node in the cluster goes down or if a node is down when DataMiner starts up, an alarm will be generated in the Alarm Console. This alarm also indicates how much the health of the cluster is affected by the node being down, as this depends on multiple factors, including the cluster size and replication factor.
> - For information on how to query a Cassandra database, see [Querying a Cassandra database compared to MySQL](xref:Querying_Cassandra_vs_MySQL).

> [!TIP]
> See also:
>
> - [Storage options overview](xref:Supported_system_data_storage_architectures)
> - [Securing the Cassandra general database](xref:Cassandra_authentication)
> - [Apache Cassandra documentation](https://cassandra.apache.org/doc/latest/)
