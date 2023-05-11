---
uid: Configuring_Elasticsearch_Database
---

# Configuring the Elasticsearch database

## Configuring a separate Elasticsearch instance on Linux

To configure a separate Elasticsearch instance on Linux, you may need to adapt the *Elasticsearch.yml* as well as several other files before you start the Elasticsearch service. For more information about these settings, see [Configuring Elasticsearch](https://www.elastic.co/guide/en/elasticsearch/reference/6.8/settings.html).

The most important of these settings can be found on the page [Important Elasticsearch configuration](https://www.elastic.co/guide/en/elasticsearch/reference/6.8/important-settings.html).

> [!IMPORTANT]
> The JVM Heap Space must be set to a value larger than the default 1 GB on production systems.
> To configure this, see [Setting the heap size](https://www.elastic.co/guide/en/elasticsearch/reference/6.8/heap-size.html).

## Configuring Elasticsearch cluster nodes

- [Configuring the master nodes](xref:Configuring_master_Elasticsearch_nodes)

  > [!IMPORTANT]
  > A correct master node configuration is extremely important since master nodes logically determine which nodes are part of the cluster. This page is therefore a must-read before you set up any Elasticsearch clusters.

- [Adding an Elasticsearch cluster node](xref:Configuring_Elasticsearch_node_add)
- [Removing an Elasticsearch cluster node](xref:Configuring_Elasticsearch_node_remove)
