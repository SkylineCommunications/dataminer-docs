---
uid: Configuring_the_database_settings_in_Cube
---

# Configuring the general database settings

You can configure the database settings for your DataMiner System's dedicated clustered storage in DataMiner Cube.

> [!NOTE]
> If you want an external program to execute queries against a DataMiner database, you will need to use an offload database. For information on offload database settings, see [Offload database](xref:Offload_database).

> [!IMPORTANT]
> If a DataMiner Agent in a cluster is offline, database configuration changes will not be applied to that DataMiner Agent. From DataMiner 10.3.6/10.4.0 onwards, you will get a warning on the *Database* page in System Center to make you aware of this. However, this warning will not be triggered for the offline Agent in a Failover setup. <!-- RN 36184 -->

> [!TIP]
>
> - See also: [Configuring a Cassandra database per DMA](xref:Configuring_Cassandra_per_DMA_in_Cube) and [Configuring the SQL database settings](xref:Configuring_MySQL_database_in_Cube).
> - Some database settings can also be configured in [DB.xml](xref:DB_xml#general-database-settings).

## Cassandra database

## Cassandra cluster database

For a Cassandra cluster database (i.e. one Cassandra cluster that is used as the general database for the entire DMS, rather than one Cassandra cluster per DMA), configure the settings as follows:

1. Go to *Apps* > *System Center* > *Database*.

1. Choose **Type**: *Database per cluster*.

1. Specify the following database settings for the Cassandra nodes:

   - **Database**: The type of database, i.e. *CassandraCluster*.

   - **Keyspace prefix** or **Name**: The prefix that the DataMiner System will use to create the keyspaces.

      > [!NOTE]
      > The prefix has a maximum length of 20 characters. Prior to DataMiner 10.3.0 [CU5]/10.3.8<!-- RN 36503 -->, it has a maximum length of 11 characters.

   - **DB server**: The IP addresses or hostnames of the nodes, separated by commas. From DataMiner 10.3.0/10.3.3 onwards, you can specify an IP address with a custom port, e.g `10.5.100.1:5555`. If no port is provided, the default Cassandra port is used instead (see [Configuring the IP network ports](xref:Configuring_the_IP_network_ports)). <!-- RN 34590 -->

   - **User**: Username with which the DMA has to log on to Cassandra.

   - **Password**: Password with which the DMA has to log on to Cassandra.

1. From DataMiner Cube 10.3.0/10.3.3 onwards, you can also specify the database settings for Elasticsearch. Note that if the server supports [OpenSearch](xref:OpenSearch_database), Cube will allow you to configure this type of database instead of Elasticsearch.

   - **Database**: The type of database, e.g. *Elasticsearch*.

   - **Database prefix**: The prefix that the DataMiner System will use to create the indices.

   - **DB server**: The IP addresses or hostnames of the Elasticsearch nodes, separated by commas. If TLS is enabled, the full URL must be specified, e.g. `https://elastic.mydomain.local`. If no port is provided, the default Elasticsearch port is used instead (see [Configuring the IP network ports](xref:Configuring_the_IP_network_ports)).

   - **User**: The username with which the DMA has to log on to Elasticsearch (if applicable).

   - **Password**: The password with which the DMA has to log on to Elasticsearch (if applicable).

   ![Cube Cassandra Cluster Configuration](~/user-guide/images/CassandraCluster_CubeConfig.png)

1. Click *Save*.

   > [!NOTE]
   > Database configuration changes will not take effect until the Agent is restarted.

## Amazon Keyspaces

> [!IMPORTANT]
>
> - An Amazon Keyspaces database requires a separate indexing database.
> - For information on how to configure an indexing database, see [Configuring an indexing database](xref:Indexing_Database).

> [!NOTE]
> If you do not see the `Amazon Keyspaces` option, it means that your server is not compatible because it is not running DataMiner version 10.3.0/10.3.3 or higher.

To configure the connection to an [Amazon Keyspaces database](xref:Amazon_Keyspaces_Service), proceed as follows:

1. In DataMiner Cube, go to *System Center* > *Database*.

1. Specify the following database settings:

   - **Type**: *Database per cluster*.

   - **Database**: The type of database, i.e. *Amazon Keyspaces*.

   - **Keyspace prefix**: The name all Amazon Keyspaces will be prefixed with. This will be identical for all DMAs in the DMS.

     - Only alphanumeric characters are supported.

     - The prefix cannot start with a number.

     - The prefix has a maximum length of 20 characters. Prior to DataMiner 10.3.0 [CU5]/10.3.8<!-- RN 36503 -->, it has a maximum length of 11 characters.

   - **DB Server**: The URL of the [global endpoint](https://docs.aws.amazon.com/keyspaces/latest/devguide/programmatic.endpoints.html) of the region your Amazon Keyspaces cluster is in. (e.g. `cassandra.eu-north-1.amazonaws.com`).

   - **User**: The username of your [Amazon Keyspaces credentials](xref:Deploying_Amazon_Keyspaces_Service#generating-credentials-for-amazon-keyspaces).

   - **Password**: The password of your [Amazon Keyspaces credentials](xref:Deploying_Amazon_Keyspaces_Service#generating-credentials-for-amazon-keyspaces).

1. Click *Save*.

   > [!NOTE]
   > Database configuration changes will not take effect until the Agent is restarted.

1. Restart the DMS.

   The first restart after configuring Amazon Keyspaces can take up to 15 minutes on top of the normal startup time as the keyspaces and tables will be created. In case of trouble, you can find the relevant logging in the *SLDBConnection.txt* file.

![Cube Database Configuration](~/user-guide/images/aks_cube_config.png)<br>*DataMiner 10.3.3 example configuration*

## Amazon OpenSearch Service

> [!NOTE]
> Ensure your server version is compatible with OpenSearch. Cube will display `Elasticsearch/OpenSearch` instead of `Elasticsearch` if your server is compatible (i.e. running DataMiner 10.3.0/10.3.3 or higher).

1. In DataMiner Cube, go to *System Center* > *Database*.

1. Specify the following database settings:

   - **Type**: *Database per cluster*.

   - **Database**: The type of database, i.e. *Elasticsearch/OpenSearch*.

   - **Database prefix**: The name all indices will be prefixed with. This will be identical for all DMAs in the same cluster.

   - **DB Server**: The full URL of your Amazon OpenSearch Service endpoint, e.g. `https://search-mydomain-123456798.eu-north-1.es.amazonaws.com/`

     > [!IMPORTANT]
     > From DataMiner 10.3.0 [CU4]/10.3.7 onwards, you must append the port `:443` to the Amazon OpenSearch Service endpoint URL. For example: `https://search-mydomain-123456798.eu-north-1.es.amazonaws.com:443`. In earlier DataMiner versions, this is not needed.

   - **User**: The username of the master user of your domain.

   - **Password**: The password of the master user of your domain.

   ![OpenSearch Cube Config](~/user-guide/images/Amazon_OpenSearch_CubeConfig.png)

1. Click *Save*.

   > [!NOTE]
   > Database configuration changes will not take effect until the Agent is restarted.

1. Optionally, you can verify that the DMS is using the database.

   1. Open the `OpenSearch Dashboards URL` to be redirected to your dashboard (equivalent of Kibana for Elasticsearch).

   1. Select the hamburger button and go to *Management* > *Dev Tools*.

      ![DevTools](~/user-guide/images/Amazon_OpenSearch_DevTools.png)

   1. Execute the `GET _cat/indices` query to check whether the DMS has created the necessary indices.

      ![CatIndices](~/user-guide/images/Amazon_OpenSearch_CatIndices.png)

   > [!NOTE]
   > In the example screenshots, the cluster health is set to yellow because only one node is used. Single-node clusters are always displayed in yellow.
