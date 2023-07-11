---
uid: Elasticsearch_database
---

# Elasticsearch

To complete the configuration of a dedicated clustered storage setup, when a Cassandra-compatible database service has been set up, you can set up an [Elasticsearch database](xref:Installing_Elasticsearch_on_separate_Linux_machine).

As an alternative to the Elasticsearch database, from DataMiner 10.3.0/10.3.3 onwards, [OpenSearch](xref:OpenSearch_database) and the [Amazon OpenSearch Service](xref:Amazon_OpenSearch_Service) are also supported.

Additionally, the Elasticsearch database can also be [deployed in a setup with storage per DMA](xref:Configuring_indexing_database_per_DMS) to unlock DataMiner features such as GQI, DOM, and SRM.

In this section of the documentation, you will also find instructions on how to [manually connect a DMA to an existing Elasticsearch cluster](xref:Manually_Connecting_DMA_to_Elasticsearch_Cluster) in the *DB.xml* file, on how to [configure Elasticsearch backups](xref:Configuring_Elasticsearch_backups), and on how to [remove an Elasticsearch cluster node](xref:Configuring_Elasticsearch_node_remove).

> [!NOTE]
>
> - For information on the system requirements for Elasticsearch, refer to [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements).
> - For information on how to query an Elasticsearch database, see [Querying an Elasticsearch database](xref:Querying_an_Elasticsearch_database).

> [!TIP]
> See also:
>
> - [Securing the Elasticsearch database](xref:Security_Elasticsearch)
> - [Expert Hub – Elasticsearch](https://community.dataminer.services/expert-hub-elastic/) on DataMiner Dojo
