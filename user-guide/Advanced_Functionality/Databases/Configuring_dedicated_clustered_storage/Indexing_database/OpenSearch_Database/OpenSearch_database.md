---
uid: OpenSearch_database
---

# OpenSearch database

From DataMiner 10.3.0/10.3.3 onwards, it is possible to install a dedicated OpenSearch indexing database cluster as an alternative for Elasticsearch. This indexing cluster also requires a Cassandra cluster.

> [!NOTE]
> If you are looking to use the Amazon OpenSearch Service instead of on-premises hosted OpenSearch nodes, see [Amazon OpenSearch Service](xref:Amazon_OpenSearch_Service).

## Compatibility

Supported versions:

- OpenSearch 1.X
- OpenSearch 2.X

## Setting up the OpenSearch cluster

See the [official documentation](https://opensearch.org/docs/latest/) on how to set up your OpenSearch cluster. The configuration is almost identical to that of an Elasticsearch cluster.

> [!IMPORTANT]
>
> - On production systems, the *JVM Heap Space* must be set to a value larger than the default. To configure this setting, see [Important settings](https://opensearch.org/docs/latest/install-and-configure/install-opensearch/index/#important-settings).
> - The `indices.query.bool.max_clause_count` setting should be set to "2147483647" (i.e. the maximum integer value).

> [!NOTE]
> Contrary to Elasticsearch, OpenSearch is only supported on Linux and not on Windows.

It is also possible to set up OpenSearch Dashboards, which is the equivalent of Kibana for Elasticsearch. However, this is optional and not required for DataMiner to function.

## Connecting your DMS to an OpenSearch cluster

To configure the connection to an OpenSearch database, configure the settings as detailed in [Cassandra database](xref:Configuring_the_database_settings_in_Cube#cassandra-cluster-database).

> [!IMPORTANT]
> An OpenSearch database requires a separate Cassandra cluster or Amazon Keyspaces.
