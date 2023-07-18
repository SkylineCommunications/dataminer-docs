---
uid: OpenSearch_database
---

# OpenSearch database

To complete the configuration of a dedicated clustered storage setup, when a Cassandra-compatible database service has been set up, you can install a dedicated OpenSearch indexing database cluster.

Alternatives to the OpenSearch database are the [Elasticsearch database](xref:Elasticsearch_database) and the [Amazon OpenSearch Service](xref:Amazon_OpenSearch_Service).

For more information on how to **install an OpenSearch database**, see [Installing an OpenSearch database](xref:Installing_OpenSearch_database).

From DataMiner 10.3.0/10.3.3 onwards, you can have data offloaded to **multiple OpenSearch clusters**. For more information on how to configure this setup, see [Configuring multiple OpenSearch clusters](xref:Configuring_multiple_OpenSearch_clusters).

For more information on how to configure OpenSearch backups, see [Configuring OpenSearch backups](xref:Configuring_OpenSearch_Backups).

This setup is supported from DataMiner 10.3.0/10.3.3 onwards.

> [!TIP]
> If you are looking to use the Amazon OpenSearch Service instead of on-premises hosted OpenSearch nodes, see [Amazon OpenSearch Service](xref:Amazon_OpenSearch_Service).

> [!NOTE]
> To query the OpenSearch database, you can use the [ElasticVue](https://elasticvue.com/) browser extension. However, note that ElasticVue was created for ElasticSearch, so not everything may work for OpenSearch.
