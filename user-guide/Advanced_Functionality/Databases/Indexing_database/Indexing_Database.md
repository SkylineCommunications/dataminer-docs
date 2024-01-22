---
uid: Indexing_Database
---

# Configuring an indexing database

If you choose not to use the recommended [Storage as a Service (STaaS)](xref:STaaS) setup but instead choose self-hosted storage, you also need to set up an OpenSearch or Elasticsearch indexing database in your DMS.

An indexing database is required for many DataMiner features, including:

- DataMiner Advanced Analytics features such as pattern matching (see [Advanced analytics features in the Alarm Console](xref:Advanced_analytics_features_in_the_Alarm_Console) and [Advanced analytics in trend graphs](xref:Advanced_analytics_trending))

- [DataMiner Object Models (DOM)](xref:DOM)

- [DataMiner Service & Resource Management (SRM)](xref:SRM)

- [DataMiner User-Defined APIs](xref:UD_APIs)

- [Specific GQI data sources](xref:Query_data_sources)

> [!IMPORTANT]
> Elasticsearch is only supported up to version 6.8. As this version is no longer supported by Elastic, we recommend using OpenSearch instead.

> [!NOTE]
> For information on the system requirements for OpenSearch/Elasticsearch, refer to [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements).

> [!TIP]
> See also:
>
> - [Securing the OpenSearch database](xref:Security_OpenSearch)
> - [Securing the Elasticsearch database](xref:Security_Elasticsearch)

## Dedicated clustered storage setup

In a dedicated clustered storage setup, an indexing database is **required**. Once you have set up Cassandra or a Cassandra-compatible database for the general system storage, you need to set up one of the following databases as the indexing database:

- [OpenSearch](xref:OpenSearch_database) is supported from DataMiner 10.3.0/10.3.3 onwards. To install OpenSearch, first [install an OpenSearch database](xref:Installing_OpenSearch_database) (ideally on a separate Linux machine), then configure the OpenSearch settings as detailed under [Cassandra database](xref:Configuring_the_database_settings_in_Cube#cassandra-database).

- [Elasticsearch](xref:Elasticsearch_database) is only supported up to Elasticsearch 6.8 and is therefore not recommended. To install Elasticsearch, first [install Elasticsearch on a separate Linux machine](xref:Installing_Elasticsearch_on_separate_Linux_machine), then configure the Elasticsearch settings as detailed under [Cassandra database](xref:Configuring_the_database_settings_in_Cube#cassandra-database).

> [!NOTE]
> [Amazon OpenSearch Service](xref:Amazon_OpenSearch_Service) is also supported from DataMiner 10.3.0 [CU0] up to 10.3.0 [CU8] and from DataMiner 10.3.3 up to 10.3.11, but this is now **deprecated**.

## Storage per DMA

While this is no longer recommended, it is still possible to use a self-hosted storage setup with a Cassandra database per DataMiner Agent. In such a setup, you should also install an OpenSearch or Elasticsearch indexing database in order to get access to additional DataMiner features, including User-Defined APIs, DOM, and SRM.

- [OpenSearch](xref:OpenSearch_database) is supported from DataMiner 10.3.0/10.3.3 onwards. To install OpenSearch, first [install an OpenSearch database](xref:Installing_OpenSearch_database) (ideally on a separate Linux server), and then [connect your DMS to the OpenSearch database](xref:Manually_Connecting_DMA_to_Elasticsearch_Cluster).

- [Elasticsearch](xref:Elasticsearch_database) is only supported up to Elasticsearch 6.8 and is therefore not recommended. You can [install Elasticsearch from within DataMiner Cube](xref:Installing_Elasticsearch_via_DataMiner), or you can [install Elasticsearch on a separate Linux machine](xref:Installing_Elasticsearch_on_separate_Linux_machine) like for a dedicated clustered storage setup and then [manually connect your DMA to the database](xref:Manually_Connecting_DMA_to_Elasticsearch_Cluster).

When the database has been deployed, you can [configure the indexing settings](xref:Configuring_DataMiner_Indexing) in DataMiner Cube.
