---
uid: DBConfiguration_xml
---

# DBConfiguration.xml

The *DBConfiguration.xml* file is not present by default on a DMA. It can be added to configure certain database settings, as detailed below.

> [!NOTE]
> This file is not automatically synced between DataMiner Agents. This applies both for the midnight sync in a DMS and for the synchronization between Failover Agents.

## Configuring a size limit for file offloads

When the main database is offline, file offloads are used to store write/delete operations. From DataMiner 10.1.0 \[CU5\]/10.1.8 onwards, you can configure a limit for the file size of these offloads in the file *DBConfiguration.xml*. When the limit is reached, new data will be dropped.

You can configure this size limit as follows:

1. Open the file *DBConfiguration.xml* in the folder *C:\\Skyline DataMiner\\Database*. If this file does not exist yet, create it manually.

1. Configure the file with a *FileOffloadConfiguration* element with the desired maximum size (in MB), as illustrated below:

    ```xml
    <DatabaseConfiguration>
      <FileOffloadConfiguration>
        <MaxSizeMB>20</MaxSizeMB>
      </FileOffloadConfiguration>
    </DatabaseConfiguration>
    ```

1. Restart DataMiner.

> [!NOTE]
>
> - If no limit is set in DBConfiguration.xml or if the file offload configuration is invalid, the size of the database offload files will by default be limited to 10 GB.
> - When the specified limit has been reached, the following alarm will be generated: "Max file offload disk usage for certain storages has been reached, new data for these storages will be dropped."

## Configuring multiple Elasticsearch clusters

It is possible to have data offloaded to multiple Elasticsearch clusters, i.e. one main cluster and several replicated clusters. This is configured in *DBConfiguration.xml*. For detailed information, see [Configuring multiple Elasticsearch clusters](xref:Configuring_multiple_Elasticsearch_clusters).
