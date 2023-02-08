---
uid: Manually_Connecting_DMA_to_Elasticsearch_Cluster
---
# Manually connecting a DMA to an Elasticsearch cluster

You can connect a DataMiner Agent to an existing Elasticsearch cluster by manually adding a *DataBase* tag to the *DB.xml* file.

> [!IMPORTANT]
> Make sure the DataMiner Agent has an available connection to each node of the Elasticsearch cluster. To verify this, enter `http://elasticnodeip:9200/` in your browser's address bar to access the general server information.
> ![Admin consent](~/user-guide/images/ElasticSearch_Connectivity_Check.png)

To establish a connection between your DMA and an existing Elasticsearch cluster, do the following:

1. Stop the DataMiner Agent. See [Starting or Stopping DataMiner Agents in your DataMiner System](xref:Starting_or_stopping_DataMiner_Agents_in_your_DataMiner_System).

1. In the *C:\\Skyline DataMiner\\Database* directory, find the *DB.xml* file and copy this to your local machine.

1. Open the original *DB.xml* file.

1. Locate the active *DataBase* tag for Elasticsearch and specify the hosts, username, and password.

   > [!TIP]
   > See [Specifying custom credentials for Elasticsearch](xref:DB_xml#specifying-custom-credentials-for-elasticsearch).

   Example:

   ```xml
   <DataBase active="true" search="true" type="Elasticsearch">
      <DBServer>Node IP1,Node IP1,..,Node IPx</DBServer>
      <UID>elastic</UID>
      <PWD>{220CCF11-0785-4712-BBAB-E7DD72CFB0D6}</PWD>
   </DataBase>
   ```

1. Save the file and restart the DataMiner Agent.

1. When the DMA is online again, confirm that there are no errors related to the database configuration.
