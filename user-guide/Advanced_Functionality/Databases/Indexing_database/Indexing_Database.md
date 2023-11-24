---
uid: Indexing_Database
---

# Configuring an indexing database

If you choose not to use the recommended [Storage as a Service (STaaS)](xref:STaaS) setup but instead choose self-hosted storage, to complete the configuration of a dedicated clustered storage setup after a Cassandra-compatible database service has been set up, you need to set up an indexing database:

- [OpenSearch database](xref:OpenSearch_database): Supported from DataMiner 10.3.0/10.3.3 onwards.

- [Elasticsearch](xref:Elasticsearch_database): Only supported up to Elasticsearch 6.8. Not recommended.

- [Amazon OpenSearch Service](xref:Amazon_OpenSearch_Service): Deprecated. Supported from DataMiner 10.3.0 [CU0] up to 10.3.0 [CU8] and from DataMiner 10.3.3 up to 10.3.11.

While these are not recommended, we also still support setups with storage per DMA using [an Elasticsearch database](xref:Configuring_indexing_database_per_DMS).

When DataMiner is configured to use an index database, it unlocks additional features, including:

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
