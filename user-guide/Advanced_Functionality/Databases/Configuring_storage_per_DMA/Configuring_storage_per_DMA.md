---
uid: Configuring_storage_per_DMA
---

# Configuring storage per DMA

## Cassandra database per DMA

By default, when you install a new DataMiner System, a Cassandra database per DMA is configured. If you have an existing legacy DataMiner System with SQL database, [migrating to Cassandra](xref:Migrating_the_general_database_to_Cassandra) will give you access to additional DataMiner features (depending on your DataMiner version), including:

- Advanced Analytics features such as alarm focus, behavioral anomaly detection, proactive cap detection, automatic incident tracking, and pattern matching
- Trend predictions
- DataMiner Service & Resource Management
- The Generic Query Interface in DataMiner Dashboards
- Alarm Console enhancements: heatline columns, reports view
- Heatmap reports (in the legacy Reporter app)

> [!NOTE]
> For many of the above-mentioned features, an [indexing database](xref:Configuring_indexing_database_per_DMS) is required as well.

## MySQL database

On legacy DataMiner Systems, typically a MySQL (or MSSQL) database is used as the general database. For the currently supported DataMiner versions, a Cassandra database is preferred instead. Though DataMiner can still be used with a MySQL or MSSQL database, [switching to Cassandra](xref:Migrating_the_general_database_to_Cassandra) is highly recommended as it leads to enhanced performance, and certain DataMiner features are only available if a Cassandra database is used.

> [!IMPORTANT]
> MSSQL is no longer supported as the general database as from DataMiner 10.3.0.
