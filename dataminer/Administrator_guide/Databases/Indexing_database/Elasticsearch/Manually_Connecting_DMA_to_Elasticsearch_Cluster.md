---
uid: Manually_Connecting_DMA_to_Elasticsearch_Cluster
---

# Manually connecting a DMA to an indexing database

If you choose self-managed storage instead of the recommended [Storage as a Service (STaaS)](xref:STaaS) setup, you can connect a DataMiner Agent to an existing OpenSearch or Elasticsearch cluster.

If you are using a [dedicated clustered storage](xref:Dedicated_clustered_storage) setup, from 10.3.0/10.3.3 onwards, you should do so in DataMiner Cube, as detailed under [Configuring the general database settings in Cube](xref:Configuring_the_database_settings_in_Cube#cassandra-cluster-database).

If you are using an older DataMiner version or a setup with storage per DMA, follow the steps below.

> [!IMPORTANT]
> Elasticsearch is **only supported up to version 6.8**, which is no longer supported by Elastic. As a consequence, if you want to use self-managed storage instead of the recommended [Storage as a Service](xref:STaaS), we recommend using [OpenSearch](xref:OpenSearch_database) instead.

> [!CAUTION]
> Make sure the DataMiner Agent has an available connection to each node of the OpenSearch or Elasticsearch cluster. You can for example verify this for Elasticsearch by entering `http://elasticnodeip:9200/` in your browser's address bar to access the general server information.
>
> ![Admin consent](~/dataminer/images/ElasticSearch_Connectivity_Check.png)

> [!NOTE]
> This procedure is only used to connect a DMA to a single OpenSearch/Elasticsearch cluster. For information on how to configure multiple OpenSearch or Elasticsearch clusters, see [Configuring multiple OpenSearch clusters](xref:Configuring_multiple_OpenSearch_clusters) or [Configuring multiple Elasticsearch clusters](xref:Configuring_multiple_Elasticsearch_clusters), respectively.

1. Stop the DataMiner Agent. See [Starting or stopping DataMiner Agents in your DataMiner System](xref:Starting_or_stopping_a_DMA_in_DataMiner_Cube).

1. In the `C:\Skyline DataMiner` directory, find the *DB.xml* file and copy this to your local machine as a backup.

1. Open the original *DB.xml* file.

1. Locate the active *DataBase* tag for the indexing database and specify the hosts, username, and password.

   > [!TIP]
   > See also:
   >
   > - [Specifying custom credentials for OpenSearch or Elasticsearch](xref:DB_xml#specifying-custom-credentials-for-opensearch-or-elasticsearch).
   > - [Indexing database settings in DB.xml](xref:DB_xml#indexing-database-settings)

   Example:

   ```xml
   <DataBase active="true" search="true" type="Elasticsearch">
      <DBServer>Node IP1,Node IP1,..,Node IPx</DBServer>
      <UID>elastic</UID>
      <PWD></PWD>
   </DataBase>
   ```

1. Save the file and restart the DataMiner Agent.

1. When the DMA is online again, confirm that there are no errors related to the database configuration.

> [!NOTE]
> An indexing database is never used on its own by DataMiner. It is always combined with a Cassandra database, either with a Cassandra cluster per DMA, or a Cassandra cluster per DMS. See [Storage options overview](xref:Supported_system_data_storage_architectures).
