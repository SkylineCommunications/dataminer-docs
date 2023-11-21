---
uid: Configuring_indexing_database_per_DMS
---

# Setting up an Elasticsearch database in a setup with storage per DMA

If you choose not to use the recommended [Storage as a Service (STaaS)](xref:STaaS) setup but instead want to use a self-hosted storage setup with a Cassandra database per DataMiner Agent, you should also install an Elasticsearch indexing database per DMS in order to get access to additional DataMiner features, including User-Defined APIs, DOM, and SRM.

You can [deploy the Elasticsearch indexing database](xref:Installing_Elasticsearch_via_DataMiner) via DataMiner Cube. When the database has been deployed, you can also [configure the indexing settings](xref:Configuring_DataMiner_Indexing) in DataMiner Cube.

> [!IMPORTANT]
> Elasticsearch is only supported up to version 6.8. As a consequence, if you do want to use self-hosted storage instead of [STaaS](xref:STaaS), we recommend using [dedicated clustered storage](xref:Dedicated_clustered_storage) with OpenSearch.

> [!NOTE]
> For information on the system requirements for Elasticsearch, refer to [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements).

> [!TIP]
> See also:
>
> - [Securing the Elasticsearch database](xref:Security_Elasticsearch)
> - [Expert Hub – Elasticsearch](https://community.dataminer.services/expert-hub-elastic/) on DataMiner Dojo
