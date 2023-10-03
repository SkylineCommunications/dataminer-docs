---
uid: Taking_snapshot_Elasticsearch_cluster_and_restoring_to_different_cluster
---

# Taking a snapshot of one Elasticsearch cluster and restoring it to another

1. Prepare the source and target Elasticsearch clusters by following the steps under [Preparing and configuring the repositories](xref:Configuring_Elasticsearch_backups_Windows_Linux#preparing-and-configuring-the-repositories).

   > [!NOTE]
   >
   > - If there are multiple nodes per Elasticsearch cluster, make sure the first step in [Preparing the source Elasticsearch cluster](xref:Configuring_Elasticsearch_backups_Windows_Linux#preparing-the-source-elasticsearch-cluster) has been properly executed before proceeding with the remaining steps.
   > - Verify that an Elasticsearch repository was created on the source Elasticsearch cluster.

   The snapshot repository has now been initialized on both Elasticsearch clusters.

1. Stop both DataMiner Agents.

   >[!NOTE]
   > If you have configured to have your data offloaded to multiple Elasticsearch clusters, DataMiner must be stopped before continuing with the procedure to avoid the active DMA from continuing to write data to the nodes that will become increasingly more out of sync.

1. [Take a snapshot](xref:Configuring_Elasticsearch_backups_Windows_Linux#taking-the-snapshot) on the source Elasticsearch cluster.

1. Copy the snapshot and [initialize the target repository](xref:Configuring_Elasticsearch_backups_Windows_Linux#preparing-the-target-machine).

   >[!TIP]
   > To speed up the process, you may need to archive files and copy the archive instead of the files. Make sure the target Elasticsearch cluster can unzip the archive when it is copied to the server.

1. Restore the snapshot on the target Elasticsearch cluster, as instructed under [Restoring the snapshot](xref:Configuring_Elasticsearch_backups_Windows_Linux#restoring-the-snapshot)

   > [!NOTE]
   > If there is data on the remote Elasticsearch cluster that should be overwritten, delete it using the [delete index API](https://www.elastic.co/guide/en/elasticsearch/reference/6.8/indices-delete-index.html).
