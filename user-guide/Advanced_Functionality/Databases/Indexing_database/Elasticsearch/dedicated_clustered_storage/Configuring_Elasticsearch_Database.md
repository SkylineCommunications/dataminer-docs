---
uid: Configuring_Elasticsearch_Database
---

# Configuring an Elasticsearch database on a separate machine

> [!NOTE]
> Elasticsearch is **only supported up to version 6.8**, which is no longer supported by Elastic. We therefore recommend using [Storage as a Service](xref:STaaS) instead, or if you do want to continue using self-hosted storage, using [OpenSearch](xref:OpenSearch_database).

To configure a separate Elasticsearch instance (version 6.8), you may need to adapt the *Elasticsearch.yml* as well as several other files before you start the Elasticsearch service. For more information about these settings, see [Configuring Elasticsearch](https://www.elastic.co/guide/en/elasticsearch/reference/6.8/settings.html).

The most important of these settings can be found on the page [Important Elasticsearch configuration](https://www.elastic.co/guide/en/elasticsearch/reference/6.8/important-settings.html).

> [!IMPORTANT]
> The JVM Heap Space must be set to a value larger than the default 1 GB on production systems. To configure this, see [Setting the heap size](https://www.elastic.co/guide/en/elasticsearch/reference/6.8/heap-size.html).
