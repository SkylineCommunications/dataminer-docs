---
uid: Configuring_Elasticsearch_Database
---

# Configuring the Elasticsearch database

## Configuring a separate Elasticsearch instance on Linux

To configure a separate Elasticsearch instance (version 6.8) on Linux, you may need to adapt the *Elasticsearch.yml* as well as several other files before you start the Elasticsearch service. For more information about these settings, see [Configuring Elasticsearch](https://www.elastic.co/guide/en/elasticsearch/reference/6.8/settings.html).

The most important of these settings can be found on the page [Important Elasticsearch configuration](https://www.elastic.co/guide/en/elasticsearch/reference/6.8/important-settings.html).

> [!IMPORTANT]
> The JVM Heap Space must be set to a value larger than the default 1 GB on production systems.
> To configure this, see [Setting the heap size](https://www.elastic.co/guide/en/elasticsearch/reference/6.8/heap-size.html).

## Configuring Elasticsearch cluster nodes

A correct master node configuration is extremely important since **master nodes logically determine which nodes are part of the cluster**. Before you set up an Elasticsearch cluster, first read how to [Configure the master node](xref:Configuring_master_Elasticsearch_nodes). Then you can start [Adding Elasticsearch cluster nodes](xref:Configuring_Elasticsearch_node_add).
