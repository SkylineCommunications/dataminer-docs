---
uid: Indexing_Database
---

# Configuring an indexing database

If you choose not to use the recommended [Storage as a Service (STaaS)](xref:STaaS) setup but instead choose self-hosted storage, you also need to set up an indexing database in your DMS.

An indexing database is required for many DataMiner features, including:

- DataMiner Advanced Analytics features such as pattern matching

  > [!TIP]
  > See also:
  >
  > - [Advanced analytics features in the Alarm Console](xref:Advanced_analytics_features_in_the_Alarm_Console)
  > - [Advanced analytics in trend graphs](xref:Advanced_analytics_trending)

- [DataMiner Object Models (DOM)](xref:DOM)

- [DataMiner Service & Resource Management (SRM)](xref:SRM)

- [DataMiner User-Defined APIs](xref:UD_APIs)

- [Specific GQI data sources](xref:Query_data_sources)

![indexing database per DMS](~/user-guide/images/Indexing_database_per_DMS.svg)

> [!IMPORTANT]
> Elasticsearch is only supported up to version 6.8. As such, we recommend using OpenSearch instead.

> [!NOTE]
> For information on the system requirements for OpenSearch/Elasticsearch, refer to [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements).

> [!TIP]
> See also:
>
> - [Securing the OpenSearch database](xref:Security_OpenSearch)
> - [Securing the Elasticsearch database](xref:Security_Elasticsearch)

## Dedicated clustered storage setup

To complete the configuration of a dedicated clustered storage setup after a Cassandra-compatible database service has been set up, setting up an indexing database is **required**.

The following options are supported:

- [OpenSearch database](xref:OpenSearch_database): Supported from DataMiner 10.3.0/10.3.3 onwards.

- [Elasticsearch](xref:Elasticsearch_database): Only supported up to Elasticsearch 6.8. Not recommended.

- [Amazon OpenSearch Service](xref:Amazon_OpenSearch_Service): **Deprecated**. Supported from DataMiner 10.3.0 [CU0] up to 10.3.0 [CU8] and from DataMiner 10.3.3 up to 10.3.11.

## Storage per DMA

While this is no longer recommended, it is still possible to use a self-hosted storage setup with a Cassandra database per DataMiner Agent. In such a setup, you should also install an OpenSearch or Elasticsearch indexing database in order to get access to additional DataMiner features, including User-Defined APIs, DOM, and SRM.

- To install **OpenSearch**, first [install an OpenSearch database](xref:Installing_OpenSearch_database) (ideally on a separate Linux server), and then [connect your DMS to the OpenSearch database](xref:Manually_Connecting_DMA_to_Elasticsearch_Cluster).

- Installing **Elasticsearch** is possible from within DataMiner Cube. See [Installing Elasticsearch on a DMA via DataMiner](xref:Installing_Elasticsearch_via_DataMiner). When the database has been deployed, you can also [configure the indexing settings](xref:Configuring_DataMiner_Indexing) in DataMiner Cube.
