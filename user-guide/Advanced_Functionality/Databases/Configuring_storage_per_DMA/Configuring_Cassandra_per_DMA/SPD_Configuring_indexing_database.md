---
uid: SPD_Configuring_indexing_database
---

# Setting up an indexing database in a setup with storage per DMA

If you choose not to use the recommended [Storage as a Service (STaaS)](xref:STaaS) setup but instead want to use a self-hosted storage setup with a Cassandra database per DMA, you can install an Elasticsearch indexing database per DMA to get access to additional DataMiner features such as GQI, DOM, SRM, etc.

For instructions on how to deploy and configure the Elasticsearch indexing database, see [Setting up an Elasticsearch database in a setup with storage per DMA](xref:Configuring_indexing_database_per_DMS).

> [!NOTE]
> Elasticsearch is only supported up to version 6.8. As a consequence, if you do want to use self-hosted storage instead of [STaaS](xref:STaaS), we recommend using [dedicated clustered storage](xref:Dedicated_clustered_storage) with OpenSearch or the Amazon OpenSearch Service on AWS.
