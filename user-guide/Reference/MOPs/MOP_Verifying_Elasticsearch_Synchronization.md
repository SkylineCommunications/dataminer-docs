---
uid: MOP_Verifying_Elasticsearch_Synchronization
---

# Verifying Elasticsearch synchronization

This procedure details how you can compare the data of two Elasticsearch clusters and confirm their synchronization. This setup is typically used when full geo-redundancy is required.

As various network- or database-related disruptions can lead to the clusters going out of sync, it is necessary to perform periodic manual checks to ensure the synchronization of both clusters. The primary objective is to ensure that both Elasticsearch clusters are at all times operational and supply the same data to the DMA if switching would be necessary.

## Prerequisites

- Elasticsearch knowledge
- An element configured to use the [Elasticsearch Cluster Monitor protocol](https://catalog.dataminer.services/result/driver/5943)
- A DataMiner Agent with access to <http://[databaseIP]:9200>
- A modern browser, e.g. Chrome, Edge, and Firefox

## Procedure

Follow [the procedure](xref:Verifying_Elasticsearch_Synchronization) included in the documentation on configuring multiple Elasticsearch clusters.

## Time estimate

| Item | Activity | Duration |
|--|--|--|
| 1 | Installing Elasticsearch Cluster Monitor protocol<br> + creating element | 5 min. |
| 2 | Checking database health | 5 min. |
| 3 | Ensuring matching index names | 5 min. |
| 4 | Ensuring matching index sizes | 15 min. |
