---
uid: MOP_Taking_snapshot_Elasticsearch_cluster_and_restoring_to_different_cluster
---

# Taking a snapshot of one Elasticsearch cluster and restoring it to another

The procedure details how you can take and restore snapshots to back up and restore Elasticsearch data. See the [documentation on taking and restoring snapshots](xref:Configuring_Elasticsearch_backups_Windows_Linux).

> [!NOTE]
> We recommend that you use a Linux system when following this guide. However, it is also applicable to a Windows setup.

## Prerequisites

- Elasticsearch knowledge
- A client application that is able to communicate with the Elasticsearch rest API, e.g. Kibana
- A target Elasticsearch cluster of the same or a more recent version than the source Elasticsearch cluster
- A high-quality connection between the Elasticsearch clusters

## Procedure

Follow [the procedure](xref:Taking_snapshot_Elasticsearch_cluster_and_restoring_to_different_cluster) included in the documentation on configuring multiple Elasticsearch clusters.

## Time estimate

| Item | Activity | Duration |
|--|--|--|
| 1 | Checking the requirements | 1-2 hours |
| 2 | Preparing and configuring the repositories | 15-30 min. |
| 3 | Stopping both DataMiner Agents | 2-5 min. |
| 4 | Taking the snapshot | 5-15 min. |
| 5 | Copying the snapshot | 5-120 min.|
| 6 | Restoring the snapshot | 5-15 min.|
