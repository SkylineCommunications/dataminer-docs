---
uid: OpenSearch_database
---

# OpenSearch database

If you choose not to use the recommended [Storage as a Service (STaaS)](xref:STaaS) setup but instead want to use a self-hosted dedicated clustered storage setup, once you have configured a Cassandra-compatible database service, you can complete your setup by installing a dedicated OpenSearch indexing database cluster. This setup is supported from DataMiner 10.3.0/10.3.3 onwards.

Alternatives to the OpenSearch database are the the [Amazon OpenSearch Service](xref:Amazon_OpenSearch_Service) and [Elasticsearch database](xref:Elasticsearch_database). The latter is only supported up to Elasticsearch version 6.8 and is consequently not recommended.

For more information on how to **install an OpenSearch database**, see [Installing an OpenSearch database](xref:Installing_OpenSearch_database).

From DataMiner 10.3.0/10.3.3 onwards, you can have data offloaded to **multiple OpenSearch clusters**. For more information on how to configure this setup, see [Configuring multiple OpenSearch clusters](xref:Configuring_multiple_OpenSearch_clusters).

If you have a large cluster with nodes in different zones, data centers, or racks, you should [configure allocation awareness](xref:Configuring_multiple_datacenter_OpenSearch_cluster).

For more information on how to configure OpenSearch backups, see [Configuring OpenSearch backups](xref:Configuring_OpenSearch_Backups).

> [!TIP]
> If you are looking to use the Amazon OpenSearch Service instead of on-premises hosted OpenSearch nodes, see [Amazon OpenSearch Service](xref:Amazon_OpenSearch_Service).

> [!NOTE]
> To query the OpenSearch database, you can use the [ElasticVue](https://elasticvue.com/) browser extension. However, note that ElasticVue was created for ElasticSearch, so not everything may work for OpenSearch.
