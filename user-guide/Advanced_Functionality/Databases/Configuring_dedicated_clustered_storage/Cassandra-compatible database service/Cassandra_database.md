---
uid: Cassandra_database
---

# Cassandra Cluster

In this section of the documentation, you can find instructions on [how to deploy a Cassandra Cluster setup](xref:Installing_Cassandra). **Deploying a Cassandra Cluster setup** is the first step in configuring dedicated clustered storage.

A different Cassandra-compatible database service that can be used as an alternative to the Cassandra Cluster setup is the [Amazon Keyspaces Service](xref:Amazon_Keyspaces_Service) (Available from DataMiner 10.3.0/10.3.3 onwards).

For information on how to **configure the settings** for your Cassandra Cluster setup in DataMiner Cube, see [Configuring the database settings in Cube](xref:Configuring_the_database_settings_in_Cube). For more information on how to **monitor your database, keep your nodes repaired, and keep your software up to date**, see [Maintaining a Cassandra cluster](xref:Maintain_Cassandra_Cluster).

> [!NOTE]
>
> - For information on the system requirements for Cassandra, refer to [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements).
> - If a node in the cluster goes down or if a node is down when DataMiner starts up, an alarm will be generated in the Alarm Console. This alarm also indicates how much the health of the cluster is affected by the node being down, as this depends on multiple factors, including the cluster size and replication factor.
> - For information on how to query a Cassandra database, see [Querying a Cassandra database compared to MySQL](xref:Querying_Cassandra_vs_MySQL).

> [!TIP]
> See also:
>
> - [Supported data storage architectures](xref:Supported_system_data_storage_architectures)
> - [Securing the Cassandra general database](xref:Security_Cassandra_general)
> - [Apache Cassandra documentation](https://cassandra.apache.org/doc/latest/)
> - [Cassandra – tips & tricks](https://community.dataminer.services/video/cassandra-tips-tricks/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)
