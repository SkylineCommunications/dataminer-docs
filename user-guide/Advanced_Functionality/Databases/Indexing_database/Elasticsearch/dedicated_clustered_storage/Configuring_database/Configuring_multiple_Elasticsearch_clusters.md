---
uid: Configuring_multiple_Elasticsearch_clusters
---

# Configuring multiple Elasticsearch clusters

> [!IMPORTANT]
> Elasticsearch is **only supported up to version 6.8**. We therefore recommend using [Storage as a Service](xref:STaaS) instead, or if you do want to continue using self-hosted storage, using [dedicated clustered storage](xref:Dedicated_clustered_storage) with OpenSearch or the Amazon OpenSearch Service on AWS.

> [!NOTE]
> This procedure can be followed both on Linux and Windows setups. However, we highly recommend using Linux.

From DataMiner 10.2.0/10.1.3 onwards, you can have data offloaded to multiple Elasticsearch clusters, i.e. one main cluster and several replicated clusters. Data is always read from the main cluster, but data updates are sent to all clusters.

Configuring multiple Elasticsearch clusters becomes crucial when on-premises setups are considered, as Elastic strongly advises against setting up clusters across high-latency nodes. Rather than spreading Elasticsearch nodes across locations with high latency, it is preferable to offload data to multiple Elasticsearch clusters. This approach allows for geo-redundancy, ensuring that data remains accessible even if one cluster becomes temporarily unavailable. With this configuration, if inconsistencies arise between the Elasticsearch clusters, synchronization issues can be avoided.

> [!IMPORTANT]
>
> - A setup with multiple Elasticsearch clusters is only recommended for high latency scenarios. For low or medium latency, we strongly advise using the [standard Elasticsearch setup](xref:Configuring_Elasticsearch_Database).
> - Contact Skyline if you are unsure about the setup that best fits your circumstances.

> [!TIP]
> For more information, see [Failover setups (with geo-redundancy)](xref:Dedicated_clustered_storage#failover-setups-with-geo-redundancy).

To configure this setup:

<!--## [From DataMiner 10.3.10/10.4.0 onwards](#tab/tabid-1)

> [!IMPORTANT]
> From DataMiner 10.3.10/10.4.0 onwards, configuring multiple Elasticsearch clusters should only be done via DataMiner Cube (RN 36399 - reverted in RN 37322).

1. Go to *Apps > System Center > Database*.

1. Make sure the **Type** is set to *Database per cluster*. See [Configuring the general database settings](xref:Configuring_the_database_settings_in_Cube).

1. Select the checkbox next to *Multi cluster offload*.

1. Specify the **File offload identifier**, which is the string used to identify this connection. Each connection should have a different identifier, which will be used for file offloads.

1. Select *Add* in the lower right corner to add an empty Elasticsearch offload cluster to the list.

   > [!NOTE]
   > You can add an unlimited number of Elasticsearch offload clusters. The order in which the multiple clusters are listed determines their priority within the configuration. You can move offload clusters up or down with the upwards and downwards arrows next to the name of the cluster. However, the main Elasticsearch configuration always retains the highest level of priority as it is the read database.

1. Specify the following database settings for each of the Elasticsearch nodes:

   - **Database prefix**: The prefix that the DataMiner System will use to create the keyspaces.

     > [!NOTE]
     > The prefix has a maximum length of 20 characters.

   - **DB server**: The IP addresses or hostnames of the nodes, separated by commas. You can specify an IP address with a custom port, e.g `10.5.100.1:5555`. If no port is provided, the default port is used instead (see [Configuring the IP network ports](xref:Configuring_the_IP_network_ports)).

   - **User**: Username with which the DMA has to log on to Elasticsearch.

   - **Password**: Password with which the DMA has to log on to Elasticsearch.

   - **File offload identifier**: String used to identify this connection. Each connection should have a different identifier, which will be used for file offloads.

   ![Configuration](~/user-guide/images/DBOffload_CubeConfig.png)<br/>*DataMiner 10.3.10 example configuration*

1. Click *Save*.

   > [!NOTE]
   >
   > - Database configuration changes will not take effect until the Agent is restarted.
   > - To remove an Elasticsearch cluster, select it in the list below the main Elasticsearch configuration and click *Remove*.

> [!CAUTION]
> While it was possible to configure multiple Elasticsearch clusters in the *DBConfiguration.xml* file prior to DataMiner 10.3.10/10.4.0, this should not be done in recent DataMiner versions. Specifically, refrain from editing the *ID* tag in this file, as this could lead to a need for complete reconfiguration.

## [Prior to DataMiner 10.3.10/10.4.0](#tab/tabid-2) -->

1. Create and configure a file *DBConfiguration.xml* as illustrated below. For each Elasticsearch cluster, an *ElasticCluster* tag must be added with the following configuration:

   - *priorityOrder* attribute: Indicates the priority of the different clusters. The lower the value, the greater the priority. The cluster with the lowest value is the main cluster, from which data will be read.

   - *Hosts*: The hosts of the cluster, separated by commas. This is the equivalent the *DBServer* tag in *DB.xml* (see [Indexing database settings](xref:DB_xml#indexing-database-settings))

   - *Username*: The username to connect to Elasticsearch. This is the equivalent of the *UID* tag in *DB.xml* (see [Specifying custom credentials for Elasticsearch](xref:DB_xml#specifying-custom-credentials-for-elasticsearch)).

   - *Password*: The password to connect to Elasticsearch. This is the equivalent of the *PWD* tag in *DB.xml* (see [Specifying custom credentials for Elasticsearch](xref:DB_xml#specifying-custom-credentials-for-elasticsearch)).

   - *Prefix*: The prefix for the Elasticsearch indexes. This is the equivalent of the *DB* tag in *DB.xml* (see [Specifying a custom prefix for the Elasticsearch indexes](xref:DB_xml#specifying-a-custom-prefix-for-the-indexes)).

   - *FileOffloadIdentifier*: String used to identify this connection. Each connection should have a different identifier, which will be used for file offloads.

   Example:

   ```xml
   <DatabaseConfiguration>
    <SearchConfiguration>
    <ElasticConnections>
    <!-- Reads will be handled by the ElasticCluster with the lowest priorityOrder -->
    <ElasticCluster priorityOrder="0">
    <Hosts>localhost</Hosts>
    <Username />
    <Password>root</Password>
   <!--
    Prefix corresponds with the DB tag in DB.xml.
    The content of the Prefix tag gets prefixed to the names
   of the aliases and indices created by DataMiner.
    -->
    <Prefix>dms</Prefix>
    <!--
    Used by file offload (i.e. when the connection with the Elastic cluster is not
    available) for tagging the offloaded data with.
   Should be different for each defined Elastic cluster connection.
    -->
    <FileOffloadIdentifier>cluster1</FileOffloadIdentifier>
    </ElasticCluster>
    <ElasticCluster priorityOrder="1">
    <Hosts>10.11.1.44,10.11.2.44,10.11.3.44</Hosts>
    <Username />
    <Password>root</Password>
    <Prefix>dms</Prefix>
    <FileOffloadIdentifier>cluster2</FileOffloadIdentifier>
    </ElasticCluster>
    </ElasticConnections>
    </SearchConfiguration>
   </DatabaseConfiguration>
   ```

1. Add this file in the folder *C:\\Skyline DataMiner\\Database* on each DataMiner Agent in your DMS. This file is currently not automatically synced.

1. After the file has been added, restart DataMiner. *DBConfiguration.xml* will now take precedence over the Elasticsearch configuration defined in the file *DB.xml*.

> [!NOTE]
> If the replicated cluster is still up and running, but an exception occurs for one of the replicated clusters, an alarm will be generated in the Alarm Console, indicating that not all data might be replicated. If further errors occur, no new alarms are created until the DMA is restarted.

<!--***-->

## Troubleshooting

During normal operation, DataMiner will offload the data written to both Elasticsearch clusters simultaneously.

If one of the clusters goes down, an error will be displayed in the Alarm Console to indicate that the indexing cluster is down: `All nodes in the indexing cluster are down` and/or `All nodes in the replicated indexing cluster [IP1, IP2,...] are down`.

If this happens, you need to alter the *priorityOrder* (see above) so that the backup indexing cluster becomes active. Specifically, this means setting *priorityOrder="0"* where the *priorityOrder* used to be 1 and the other way around. After you have done so, restart DataMiner. This should restore DataMiner to a functional state.

> [!IMPORTANT]
> If the main Elasticsearch cluster goes down, it will need to be restored afterwards. To ensure that the data is in sync, first follow the procedure on [Verifying Elasticsearch synchronization](xref:Verifying_Elasticsearch_Synchronization#checking-database-health), then follow the procedure to restore on [Taking a snapshot of one Elasticsearch cluster and restoring it to another](xref:Taking_snapshot_Elasticsearch_cluster_and_restoring_to_different_cluster).
