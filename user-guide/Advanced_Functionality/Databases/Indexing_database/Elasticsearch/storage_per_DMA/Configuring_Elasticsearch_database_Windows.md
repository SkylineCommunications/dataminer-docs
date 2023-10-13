---
uid: Configuring_Elasticsearch_database_Windows
---

# Configuring the Elasticsearch database (Windows)

> [!NOTE]
> Elasticsearch is **only supported up to version 6.8**. We therefore recommend using [Storage as a Service](xref:STaaS) instead, or if you do want to continue using self-hosted storage, using [dedicated clustered storage](xref:Dedicated_clustered_storage) with OpenSearch or the Amazon OpenSearch Service on AWS.

> [!IMPORTANT]
> The JVM Heap Space must be set to a value larger than the default 1 GB on production systems. To configure this, see [Setting the heap size](https://www.elastic.co/guide/en/elasticsearch/reference/6.8/heap-size.html).

Configuring an Elasticsearch database on Windows is done in the same way as configuring an Elasticsearch database on Linux:

- [Configuring the master nodes](xref:Configuring_master_Elasticsearch_nodes)

- [Adding an Elasticsearch cluster node](xref:Configuring_Elasticsearch_node_add)

- [Configuring multiple Elasticsearch clusters](xref:Configuring_multiple_Elasticsearch_clusters)
