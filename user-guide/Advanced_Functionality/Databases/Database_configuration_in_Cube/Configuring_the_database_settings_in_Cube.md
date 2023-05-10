---
uid: Configuring_the_database_settings_in_Cube
---

# Configuring the general database settings in Cube

The general database is the main database used by a DataMiner Agent to store its data. By default, this is a Cassandra database. In legacy setups, a MySQL or MSSQL database can be used.

In older DataMiner systems, this database was also known as the "local database", as the MySQL or MSSQL database was typically hosted locally on the same machine as DataMiner.

> [!NOTE]
> If you want an external program to execute queries against a DataMiner database, you will need to use an offload database. For information on offload database settings, see [Offload database](xref:Offload_database).

> [!IMPORTANT]
> If a DataMiner Agent in a cluster is offline, database configuration changes will not be applied to that DataMiner Agent. From DataMiner 10.3.6/10.4.0 onwards, you will get a warning on the *Database* page in System Center to make you aware of this. However, this warning will not be triggered for the offline Agent in a Failover setup. <!-- RN 36184 -->

## Cassandra database

### [Cassandra cluster database](#tab/tabid-1)

For a Cassandra cluster database (i.e. one Cassandra cluster that is used as the general database for the entire DMS, rather than one Cassandra cluster per DMA), configure the settings as follows:

1. Go to *Apps* > *System Center* > *Database*.

1. Choose **Type**: *Database per cluster*.

1. Specify the following database settings for the Cassandra nodes:

   - **Database**: The type of database, i.e. *CassandraCluster*.

   - **Keyspace prefix** or **Name**: The prefix that the DataMiner System will use to create the keyspaces.

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
   > From DataMiner 10.3.6/10.4.0 onwards, clicking *Save* after changing any of the database settings will cause the following pop-up message to appear: `Database configuration changes won't take effect until the Agent is restarted.` <!-- RN 36184 -->

### [Cassandra database per DMA](#tab/tabid-2)

In case a separate Cassandra cluster is used per DMA, configure the settings as follows:

1. Go to *Apps* > *System Center* > *Database*.

1. In the column on the left, select the Agent of which you want to configure the general database.

1. Specify the following database settings, depending on your DataMiner version:

   From DataMiner 10.0.13/10.1.0 onwards:

   - **Type**: *Database per Agent*.

   - **Database**: The type of database, i.e. *Cassandra*.

   - **Name**: The name of the database.

   - **DB Server**: The name or IP address of the server that hosts the database. From DataMiner 10.3.0/10.3.3 onwards, you can specify an IP address with a custom port, e.g `10.5.100.1:5555`. If no port is provided, the default Cassandra port is used instead (see [Configuring the IP network ports](xref:Configuring_the_IP_network_ports)). <!-- RN 34590 -->

   - **Connection string**: Can be filled in instead of the other fields, in which case this string will be used to connect to the database.

   - **User**: The username with which the DMA has to log on to Cassandra.

   - **Password**: The password with which the DMA has to log on to Cassandra.

   Earlier DataMiner versions:

   - **Type**: The type of database, i.e. *Cassandra*.

   - **DB**: The name of the database.

   - **DB Server**: The name or IP address of the server that hosts the database.

   - **Connection string**: Can be filled in instead of the other fields, in which case this string will be used to connect to the database.

   - **User**: The username with which the DMA has to log on to the general database.

   - **Password**: The password with which the DMA has to log on to the general database.

1. Click *Save*.

   > [!NOTE]
   > From DataMiner 10.3.6/10.4.0 onwards, clicking *Save* after changing any of the database settings will cause the following pop-up message to appear: `Database configuration changes won't take effect until the Agent is restarted.` <!-- RN 36184 -->

***

## Amazon Keyspaces

> [!IMPORTANT]
> An Amazon Keyspaces database requires a separate indexing database.
> For information on how to configure an indexing database, see [Elasticsearch database](xref:Elasticsearch_database) or [OpenSearch database](xref:OpenSearch_database).

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

     - The prefix has a maximum length of 11 characters.

   - **DB Server**: The URL of the [global endpoint](https://docs.aws.amazon.com/keyspaces/latest/devguide/programmatic.endpoints.html) of the region your Amazon Keyspaces cluster is in. (e.g. `cassandra.eu-north-1.amazonaws.com`).

   - **User**: The username of your [Amazon Keyspaces credentials](xref:Amazon_Keyspaces_Service#generating-credentials-for-amazon-keyspaces).

   - **Password**: The password of your [Amazon Keyspaces credentials](xref:Amazon_Keyspaces_Service#generating-credentials-for-amazon-keyspaces).

1. Click *Save*.

   > [!NOTE]
   > From DataMiner 10.3.6/10.4.0 onwards, clicking *Save* after changing any of the database settings will cause the following pop-up message to appear: `Database configuration changes won't take effect until the Agent is restarted.` <!-- RN 36184 -->

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

   - **User**: The username of the master user of your domain.

   - **Password**: The password of the master user of your domain.

   ![OpenSearch Cube Config](~/user-guide/images/Amazon_OpenSearch_CubeConfig.png)

1. Click *Save*.

   > [!NOTE]
   > From DataMiner 10.3.6/10.4.0 onwards, clicking *Save* after changing any of the database settings will cause the following pop-up message to appear: `Database configuration changes won't take effect until the Agent is restarted.` <!-- RN 36184 -->

1. Optionally, you can verify that the DMS is using the database.

   1. Open the `OpenSearch Dashboards URL` to be redirected to your dashboard (equivalent of Kibana for Elasticsearch).

   1. Select the hamburger button and go to *Management* > *Dev Tools*.

      ![DevTools](~/user-guide/images/Amazon_OpenSearch_DevTools.png)

   1. Execute the `GET _cat/indices` query to check whether the DMS has created the necessary indices.

      ![CatIndices](~/user-guide/images/Amazon_OpenSearch_CatIndices.png)

   > [!NOTE]
   > In the example screenshots, the cluster health is set to yellow because only one node is used. Single-node clusters are always displayed in yellow.

## Legacy MySQL or SQL database

For a legacy MySQL or MSSQL database, configure the settings as follows:

1. Go to *Apps* > *System Center* > *Database*.

1. In the column on the left, select the Agent of which you want to configure the general database.

1. Specify the following database settings, depending on your DataMiner version:

   From DataMiner 10.0.13/10.1.0 onwards:

   - **Type**: *Database per Agent*.

   - **Database**: The type of database: *MySQL* or *MSSQL*.

     > [!NOTE]
     > MSSQL is no longer supported as the general database as from DataMiner 10.3.0.

   - **Name**: The name of the database.

   - **DB Server**: The name or IP address of the server that hosts the database.

   - **Connection string**: Can be filled in instead of the other fields, in which case this string will be used to connect to the database.

   - **User**: The username with which the DMA has to log on to Cassandra.

   - **Password**: The password with which the DMA has to log on to Cassandra.

   - **Limit alarms by maximum number**: Select this option to limit the total alarm records in the database by number.

   - **Maximum alarms**: The maximum number of alarms that can be stored in the general database.

   - **Fallback minimum**: If the maximum alarms setting has been reached, the oldest alarms will automatically be deleted until the database contains exactly the number of alarms specified in the *Fallback minimum* box.

   Earlier DataMiner versions:

   - **Type**: The type of database: *MySQL* or *MSSQL*.

   - **DB**: The name of the database.

   - **DB Server**: The name or IP address of the server that hosts the database.

   - **DSN**: This setting is no longer used.

   - **Server**: This setting is no longer used. Use the *DB Server* setting instead.

   - **Connection string**: Can be filled in instead of the other fields, in which case this string will be used to connect to the database.

   - **User**: The username with which the DMA has to log on to the general database.

   - **Password**: The password with which the DMA has to log on to the general database.

   - **Limit alarms by maximum number**: Select this option to limit the total alarm records in the database by number.

   - **Maximum alarms**: The maximum number of alarms that can be stored in the general database.

   - **Fallback minimum**: If the *Maximum alarms* setting has been reached, the oldest alarms will automatically be deleted until the database contains exactly the number of alarms specified in the *Fallback minimum* box.

1. Click *Save*.

   > [!NOTE]
   > From DataMiner 10.3.6/10.4.0 onwards, clicking *Save* after changing any of the database settings will cause the following pop-up message to appear: `Database configuration changes won't take effect until the Agent is restarted.` <!-- RN 36184 -->

> [!NOTE]
>
> - If you use a MSSQL database, a Microsoft SQL Server Enterprise Edition license is required if partitioned data tables are used. Otherwise, the Express edition is sufficient. To run Microsoft SQL Server 2019, Windows Server 2016 or higher is required.
> - If you use an MSSQL database, prior to DataMiner v8.5.8, only user accounts of type NT AUTHORITY\\SYSTEM are supported. In more recent DataMiner versions, you can use other domain accounts, either by using a connection string containing “*Integrated Security=true;user id:Domain\\User Name;Password:PWD*”, or by setting the tag *\<IntegratedSecurity>* to true in *DB.xml*.
