---
uid: Configuring_indexing_database_per_DMS
---

# Setting up an indexing database in a setup with storage per DMA

If you choose not to use the recommended [Storage as a Service (STaaS)](xref:STaaS) setup but instead want to use a self-hosted storage setup with a Cassandra database per DataMiner Agent, you should also install an OpenSearch or Elasticsearch indexing database per DMS in order to get access to additional DataMiner features, including User-Defined APIs, DOM, and SRM.

- To install **OpenSearch**, first [install an OpenSearch database](xref:Installing_OpenSearch_database) (ideally on a separate Linux server), and then [connect your DMS to the OpenSearch database](xref:Manually_Connecting_DMA_to_Elasticsearch_Cluster).

- Installing **Elasticsearch** is possible from within DataMiner Cube. See [Installing Elasticsearch on a DMA via DataMiner](xref:Installing_Elasticsearch_via_DataMiner). When the database has been deployed, you can also [configure the indexing settings](xref:Configuring_DataMiner_Indexing) in DataMiner Cube.

> [!IMPORTANT]
> Elasticsearch is only supported up to version 6.8. As such, we recommend using OpenSearch instead.

> [!NOTE]
> For information on the system requirements for OpenSearch/Elasticsearch, refer to [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements).

> [!TIP]
> See also:
>
> - [Securing the OpenSearch database](xref:Security_OpenSearch)
> - [Securing the Elasticsearch database](xref:Security_Elasticsearch)
