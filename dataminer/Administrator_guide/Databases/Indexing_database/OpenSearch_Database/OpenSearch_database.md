---
uid: OpenSearch_database
---

# OpenSearch database

If you choose self-managed storage instead of the recommended [Storage as a Service (STaaS)](xref:STaaS) setup, OpenSearch is the recommended indexing database. This is supported from DataMiner 10.3.0/10.3.3 onwards. In earlier DataMiner versions, [Elasticsearch](xref:Elasticsearch_database) is used, but as Elasticsearch is only supported up to version 6.8, which is no longer supported by Elastic, this is not recommended.

In a **dedicated clustered storage** setup, once you have configured a Cassandra-compatible database service, you need to set up the indexing database cluster to complete your setup. In a setup with **storage per DMA**, setting up an indexing database is not mandatory, but it is highly recommended, as otherwise you will not have access to several DataMiner features.

For more information on how to **install an OpenSearch database**, see [Installing an OpenSearch database](xref:Installing_OpenSearch_database).

From DataMiner 10.3.0/10.3.3 onwards, you can have data offloaded to **multiple OpenSearch clusters**. For more information on how to configure this setup, see [Configuring multiple OpenSearch clusters](xref:Configuring_multiple_OpenSearch_clusters).

If you have a large cluster with nodes in different zones, data centers, or racks, you should [configure allocation awareness](xref:Configuring_multiple_datacenter_OpenSearch_cluster).

For more information on how to configure OpenSearch backups, see [Configuring OpenSearch backups](xref:Configuring_OpenSearch_Backups).

> [!NOTE]
> To query the OpenSearch database, you can use the [ElasticVue](https://elasticvue.com/) browser extension. However, note that ElasticVue was created for ElasticSearch, so not everything may work for OpenSearch.
