---
uid: MOP_Verifying_Elasticsearch_Synchronization
---

# Verifying Elasticsearch synchronization

This procedure details how you can compare the data of two Elasticsearch clusters and confirm their synchronization. This setup is typically used when full geo-redundancy is required.

It is necessary to perform periodic manual checks to ensure the synchronization of both clusters as various network- or database-related disruptions can lead to desynchronization. The primary objective is to ensure that both Elasticsearch clusters are operational and supply the same data to the DMA in case of a switch. 

## Prerequisites

- Elasticsearch knowledge
- [Elasticsearch Cluster Monitor](https://catalog.dataminer.services/result/driver/5943)
- A DataMiner Agent with access to <http://[databaseIP]:9200>
- A modern browser, e.g. Chrome, Edge, and Firefox

## Procedure

Follow [the procedure](xref:Verifying_Elasticsearch_Synchronization) included in the documentation on configuring multiple Elasticsearch clusters.

## Time estimate

| Item | Activity | Duration |
|--|--|--|
| 1 | Elasticsearch cluster monitor installation<br> + element creation | 5 min. |
| 2 | Checking database health | 5 min. |
| 3 | Verifying matching index names | 5 min. |
| 4 | Verifying matching index sizes | 15 min. |
