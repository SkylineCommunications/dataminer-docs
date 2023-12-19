---
uid: Configuring_storage_per_DMA
---

# Configuring storage per DMA

If you are still using an older setup with storage per DMA instead of the recommended [Storage as a Service (STaaS)](xref:STaaS), typically this will involve a Cassandra database per DMA. In the oldest legacy setups, a MySQL (or MSSQL) database may still be used.

## Cassandra database per DMA

By default, when you install a new self-hosted DataMiner System, a Cassandra database per DMA is configured. If you have an existing legacy DataMiner System with SQL database, [migrating to Cassandra](xref:Migrating_the_general_database_to_Cassandra) will give you access to additional DataMiner features (depending on your DataMiner version), including:

- Advanced Analytics features such as alarm focus, behavioral anomaly detection, proactive cap detection, automatic incident tracking, and pattern matching
- Trend predictions
- DataMiner Service & Resource Management
- The Generic Query Interface in DataMiner Dashboards
- Alarm Console enhancements: heatline columns, reports view
- Heatmap reports (in the legacy Reporter app)

![storage per DMA](~/user-guide/images/Storage_per_DMA.svg)

> [!IMPORTANT]
> To have access to all the latest DataMiner features, switching to [Storage as a Service (STaaS)](xref:STaaS) is highly recommended. If you prefer to keep using self-hosted storage, we highly recommend installing an [indexing database](xref:Indexing_Database) to get access to additional features such as SRM and DOM.

## MySQL database

On legacy DataMiner Systems, typically a MySQL (or MSSQL) database is used as the general database. To have access to all the latest DataMiner features, switching to [Storage as a Service (STaaS)](xref:STaaS) is highly recommended. For this, you first need to migrate to Cassandra. If you choose to keep using self-hosted storage, [migrating to Cassandra](xref:Migrating_the_general_database_to_Cassandra) is also highly recommended.

> [!IMPORTANT]
> MSSQL is no longer supported as the general database as from DataMiner 10.3.0.
