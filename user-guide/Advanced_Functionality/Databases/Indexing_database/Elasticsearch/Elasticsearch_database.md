---
uid: Elasticsearch_database
---

# Elasticsearch

If you choose not to use the recommended [Storage as a Service (STaaS)](xref:STaaS) setup but instead choose self-hosted storage, you need an indexing database in order to have access to all DataMiner features.

If you use a **dedicated clustered storage** setup, it is best to use [OpenSearch](xref:OpenSearch_database) or the [Amazon OpenSearch Service](xref:Amazon_OpenSearch_Service), but you can also use an [Elasticsearch database on a Linux machine](xref:Installing_Elasticsearch_on_separate_Linux_machine). However, Elasticsearch is only supported up to version 6.8. and is therefore not recommended. OpenSearch and the Amazon OpenSearch Service are supported from DataMiner 10.3.0/10.3.3 onwards.

While this is not recommended, you can also still use a setup with **storage per DMA**, where you can [deploy an Elasticsearch database](xref:Configuring_indexing_database_per_DMS) to gain access to DataMiner features such as GQI, SRM, and DOM.

In this section of the documentation, you will also find instructions on how to [manually connect a DMA to an existing Elasticsearch cluster](xref:Manually_Connecting_DMA_to_Elasticsearch_Cluster) in the *DB.xml* file, [configure Elasticsearch backups](xref:Configuring_Elasticsearch_backups), and [remove an Elasticsearch cluster node](xref:Configuring_Elasticsearch_node_remove).

> [!NOTE]
>
> - For information on the system requirements for Elasticsearch, refer to [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements).
> - For information on how to query an Elasticsearch database, see [Querying an Elasticsearch database](xref:Querying_an_Elasticsearch_database).

> [!TIP]
> See also:
>
> - [Securing the Elasticsearch database](xref:Security_Elasticsearch)
> - [Expert Hub – Elasticsearch](https://community.dataminer.services/expert-hub-elastic/) on DataMiner Dojo
