---
uid: Configuring_the_Cassandra_Cluster_database_settings_in_Cube
---

# Configuring the Cassandra cluster database settings in Cube

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
