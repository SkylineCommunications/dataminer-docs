---
uid: Elasticsearch_database
---

# Elasticsearch

If you choose self-hosted storage instead of the recommended [Storage as a Service (STaaS)](xref:STaaS) setup, you need an indexing database in order to have access to all DataMiner features. While [OpenSearch](xref:OpenSearch_database) is the recommended indexing database, this is not supported prior to DataMiner 10.3.0/10.3.3. In earlier DataMiner versions, Elasticsearch is used, but as Elasticsearch is only supported up to version 6.8, which is no longer supported by Elastic, this is **not recommended**.

In a **dedicated clustered storage** setup, once you have configured a Cassandra-compatible database service, you need to set up the indexing database cluster to complete your setup. If you use Elasticsearch, we recommend installing [Elasticsearch database on a Linux machine](xref:Installing_Elasticsearch_on_separate_Linux_machine).

In a setup with **storage per DMA**, setting up an indexing database is not mandatory, but it is highly recommended, as otherwise you will not have access to several DataMiner features.

> [!NOTE]
>
> - For information on the system requirements for Elasticsearch, refer to [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements).
> - For information on how to query an Elasticsearch database, see [Querying an Elasticsearch database](xref:Querying_an_Elasticsearch_database).

> [!TIP]
> See also: [Securing the Elasticsearch database](xref:Security_Elasticsearch)
