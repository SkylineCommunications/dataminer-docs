---
uid: OpenSearch_database
---

# OpenSearch database

From DataMiner 10.3 [CU0]/10.3.3 onwards, it is possible to install a dedicated OpenSearch indexing database cluster as an alternative for Elasticsearch. This indexing cluster also requires a Cassandra cluster.

> [!NOTE]
> If you are looking to use the Amazon OpenSearch Service instead of on-prem hosted OpenSearch nodes, see [Amazon OpenSearch Service](xref:Amazon_OpenSearch_Service)

## Compatibility

Supported versions:

- OpenSearch 1.X
- OpenSearch 2.X

## Setting up the OpenSearch Cluster

See the official [documentation](https://opensearch.org/docs/latest/) on how to set up your OpenSearch cluster. A lot of configuration is the same as for an Elasticsearch cluster.

> [!IMPORTANT]
> The JVM Heap Space must be set to a value larger than the default on production systems.
> To configure this, see [Important settings](https://opensearch.org/docs/latest/opensearch/install/important-settings)

> [!NOTE]
> OpenSearch is only supported on Linux and not on Windows, as opposed to Elasticsearch

It's also possible to set up OpenSearch Dashboards, this is the equivalent to Kibana for Elasticsearch.
This is optional and not required for DataMiner to function.

## Connecting your DMS to an OpenSearch cluster

To configure the connection to an OpenSearch database, configure the settings as detailed under [Cassandra database](xref:Configuring_the_database_settings_in_Cube#cassandra-database)

> [!IMPORTANT]
> An OpenSearch database requires a separate Cassandra cluster or Amazon Keyspaces.
