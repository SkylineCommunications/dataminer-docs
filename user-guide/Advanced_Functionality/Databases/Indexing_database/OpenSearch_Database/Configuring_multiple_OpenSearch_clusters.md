---
uid: Configuring_multiple_OpenSearch_clusters
---

# Configuring multiple OpenSearch clusters

From DataMiner 10.3.0/10.3.3 onwards, you can have data offloaded to multiple OpenSearch clusters, i.e. one main cluster and several replicated clusters. Data is always read from the main cluster, but data updates are sent to all clusters.

To configure this setup, proceed as follows:

## [From DataMiner 10.4.0/10.4.2 onwards](#tab/tabid-1)

<!-- RN 37446 -->

1. In the `C:\Skyline DataMiner\` folder, open *DB.xml*.

1. For each OpenSearch cluster, add a *DataBase* tag with the following configuration:

   - *active* attribute: Set this to "true" if you wish your OpenSearch cluster to be added to the list of clusters to offload data to.

   - *search* attribute: Always set this to "true".

   - *ID* attribute: This should be a unique number, preferably starting at 0 and increasing by 1 for each additional cluster.

   - *priorityOrder* attribute: Indicates the priority of the different clusters. The lower the value, the greater the priority. The cluster with the lowest value is the main cluster, from which data will be read.

   - *type* attribute: Always set this to "ElasticSearch". This is necessary for legacy and compatibility reasons.

   - *DBServer*: The hosts of the cluster, separated by commas (see [Indexing database settings](xref:DB_xml#indexing-database-settings))

   - *UID*: The username to connect to OpenSearch.

   - *PWD*: The password to connect to OpenSearch.

   - *DB*: The prefix for the OpenSearch indexes.

   - *FileOffloadIdentifier*: String used to identify this connection. Each connection should have a different identifier, which will be used for file offloads.

   Example:

   ```xml
   <DataBases>
        <!-- Reads will be handled by the ElasticCluster with the lowest priorityOrder -->
        <DataBase active="true" search="true" ID="0" priorityOrder="0" type="ElasticSearch">
            <DBServer>localhost</DBServer>
            <UID />
            <PWD>root</PWD>
            <DB>dms</DB>
            <!--
            Used by file offload (i.e. when the connection with the Elastic cluster is not
            available) for tagging the offloaded data with.
           Should be different for each defined Elastic cluster connection.
            -->
            <FileOffloadIdentifier>cluster1</FileOffloadIdentifier>
        </DataBase>
        <DataBase active="true" search="true" ID="0" priorityOrder="1" type="ElasticSearch">
            <DBServer>10.11.1.44,10.11.2.44,10.11.3.44</DBServer>
            <UID />
            <PWD>root</PWD>
            <DB>dms</DB>
            <FileOffloadIdentifier>cluster2</FileOffloadIdentifier>
        </DataBase>
   </DataBases>
   ```

1. Remove or disable any previous OpenSearch/Elasticsearch configuration from *DB.xml*.

1. Restart DataMiner.

> [!NOTE]
> If an exception occurs for one of the replicated clusters, an alarm will be generated in the Alarm Console, indicating that not all data might be replicated. If further errors occur, no new alarms are created until the DMA is restarted.

## [Prior to DataMiner 10.4.0/10.4.2](#tab/tabid-2)

> [!NOTE]
> For reasons of legacy and compatibility with Elasticsearch, the *DBConfiguration.xml* file will have XML tags referring to Elasticsearch instead of OpenSearch such as the \<ElasticConnections\> or \<ElasticCluster\> tags. Tags such as \<OpenSearchCluster\> will not work.

1. Create and configure a *DBConfiguration.xml* file as illustrated below. For each OpenSearch cluster, an *ElasticCluster* tag must be added with the following configuration:

   - **priorityOrder** attribute: Indicates the priority of the different clusters. The lower the value, the greater the priority. The cluster with the lowest value is the main cluster, from which data will be read.

   - **Hosts**: The hosts of the cluster, separated by commas. This is the equivalent of the *DBServer* tag in the *DB.xml* file (see [Indexing database settings](xref:DB_xml#indexing-database-settings)).

   - **Username**: The username that will be used to connect to OpenSearch. This is the equivalent of the *UID* tag in *DB.xml* (see [Specifying custom credentials for OpenSearch or Elasticsearch](xref:DB_xml#specifying-custom-credentials-for-opensearch-or-elasticsearch)).

   - **Password**: The password that will be used to connect to OpenSearch. This is the equivalent of the *PWD* tag in the *DB.xml* file (see [Specifying custom credentials for OpenSearch or Elasticsearch](xref:DB_xml#specifying-custom-credentials-for-opensearch-or-elasticsearch)).

   - **Prefix**: The prefix for the OpenSearch indexes. This is the equivalent of the *DB* tag in the *DB.xml* file (see [Specifying a custom prefix for the indexes](xref:DB_xml#specifying-a-custom-prefix-for-the-indexes)).

   - **FileOffloadIdentifier**: The string used to identify this connection. Each connection should have a different identifier, which will be used for file offloads.

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

1. Add this file in the `C:\\Skyline DataMiner\\Database` folder on each DataMiner Agent in your DMS. Currently, this file is not synchronized automatically.

1. After the file has been added, restart DataMiner. The *DBConfiguration.xml* file will now take precedence over the Elasticsearch configuration defined in the *DB.xml* file.

> [!NOTE]
> If an exception occurs for one of the replicated clusters, an alarm will be generated in the Alarm Console, indicating that not all data might be replicated. If further errors occur, no new alarms will be created until the DMA is restarted.

***

## Troubleshooting

During normal operation, DataMiner will offload the data written to both OpenSearch clusters simultaneously.

If one of the clusters goes down, an error will be displayed in the Alarm Console to indicate that the indexing cluster is down: `All nodes in the indexing cluster are down` and/or `All nodes in the replicated indexing cluster [IP1, IP2,...] are down`.

If this happens, you need to alter the *priorityOrder* (see above) so that the backup indexing cluster becomes active. Specifically, this means setting *priorityOrder="0"* where the *priorityOrder* used to be 1 and the other way around. After you have done so, restart DataMiner. This should restore DataMiner to a functional state.

> [!IMPORTANT]
> If the main OpenSearch cluster goes down, it will need to be restored afterwards. Make sure you have a backup set up to restore. To restore the backup, stop DataMiner completely and then restore the backup to the node that is out of sync. For more detailed information, see [Configuring OpenSearch backups](xref:Configuring_OpenSearch_Backups).

> [!TIP]
> For more troubleshooting information, see [Investigating OpenSearch issues](xref:Investigating_OpenSearch_Issues)
