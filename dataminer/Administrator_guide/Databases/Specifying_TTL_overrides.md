---
uid: Specifying_TTL_overrides
---

# Specifying TTL overrides

The "time to live" (TTL) determines how long specific data is retained before being automatically removed from your DataMiner System. By setting TTL overrides, you can control the lifespan of various data types, such as real-time trending, minute trending, and alarm events. Some data types, such as elements, do not have a TTL and never expire.

This page explains how to configure TTL settings to optimize your database performance and resource utilization.

> [!NOTE]
>
> - TTL settings are automatically configured if you use [DaaS](xref:Creating_a_DMS_in_the_cloud). From DataMiner 10.3.0 [CU15]/10.4.0 [CU3]/10.4.6 onwards<!--RN 39173-->, these settings are no longer available for manual adjustment on the *System settings* > *time to live* tab in System Center when you are using a DaaS system.
> - If a DMS uses [Storage as a Service](xref:STaaS), the default TTL is automatically applied for most database records. The configuration in Cube is only taken into account for real-time trending. From DataMiner 10.5.0 [CU2]/10.5.5 onwards<!--RN 42333-->, the *time to live* settings are no longer available for manual adjustment.

In System Center, you can configure a custom TTL for data in the database. This determines how long the data is kept in the database.

1. In DataMiner Cube, go to System Center > *System settings* > *time to live*.

1. To configure general TTL overrides:

   1. Specify the necessary override values in the *DMS defaults* section.

      - If your system has an Indexing database, the *Local* column contains TTL settings for the Cassandra general database, and the *Indexing* column contains TTL settings for the Indexing database.

      - At present, trending information is not saved in the indexing database. As such, if your DMS uses an indexing database, only the settings in the *Local* column of the *time to live* page will be taken into account for trending.

      - The *Alarm events* setting applies both for alarms and information events.

   1. Click *Apply*.

1. To configure TTL overrides for the trend data of a specific protocol or protocol version:

   1. In the *Overrides* section, click *Add*.

   1. In the pop-up window, select a protocol and if necessary a protocol version, and click *Add*.

   1. In the *Trending* section on the right, specify the necessary override values in the boxes for the various records.

   1. Click *Apply*.

The following default values and limitations apply:

| Type of data       | Default TTL | Minimum TTL      | Maximum TTL |
|--------------------|-------------|------------------|-------------|
| Real-time trending | 1 day       | 15 minutes       | 1098 days   |
| Minute trending    | 31 days     | 1 hour           | 1098 days   |
| Hour trending      | 366 days    | 12 hours         | 1830 days   |
| Day trending       | 0 seconds   | 15 days 12 hours | 3660 days   |
| Alarm events       | 366 days    | 1 hour           | 3660 days   |
| History slider     | 31 days     | 1 hour           | 3660 days   |
| Spectrum traces    | 366 days    | 1 hour           | 3660 days   |

> [!IMPORTANT]
> When a Cassandra database is used, other maxima are recommended for trending. This is because of the [Time Window Compaction Strategy](#cassandra-twcs) (TWCS) used by Cassandra.

> [!NOTE]
>
> - The TTL settings are stored in the file *DBMaintenanceDMS.xml*. For more information, see [DBMaintenanceDMS.xml](xref:DBMaintenanceDMS_xml).
> - If a record is saved with a particular TTL setting in a Cassandra database, this setting applies permanently for that record, even if the configuration is later changed in Cube. The changes are only applied for new records. For example, if a record is saved with TTL set to 150 days, it will only be removed after 150 days, even if the TTL configuration in Cube is later changed to 100 days.
> - To prevent the [year 2038 problem](xref:Year_2038_Problem_for_Cassandra) for Cassandra, from DataMiner 10.2.0 [CU14]/10.3.0 [CU2]/10.3.4 onwards, the maximum allowed TTL for databases is limited to 10 years.

## Cassandra TWCS

### About TWCS

Time Window Compaction Strategy (TWCS) is a compaction mechanism specifically designed for time-series data. The data is organized and compacted into time-based buckets, referred to as time windows. Cassandra groups data into defined time intervals (e.g. 3 hours, 1 day, etc.). Each time, a time window contains all the data written within that interval.

While data is being actively written to the current time window, it is compacted into SSTables for that specific window. Compaction occurs incrementally, merging data within the same time window.

SSTables are immutable and compacting SSTables leads to a new SSTable. When a window ends, a final SSTable will be constructed. A full SSTable for a specific window will exist until the TTL has passed. After the TTL has passed, the SSTable can safely be deleted.

For efficient operation, it is better to maintain **fewer than 50 SSTables on disk per node**. Exceeding this threshold can lead to performance degradation because of:

- Increased storage overhead.
- Higher read latencies as queries need to scan more SSTables.
- Inefficient compaction processes.

Because of this, when choosing the TTL for trending with a Cassandra database, there are some recommended boundaries.

### Recommended maximum TTL

The relationship between the time window size and the recommended maximum TTL is governed by the number of allowable SSTables. The recommended maximum TTL can be calculated as $50 \times \text{time window size}$. This ensures that no more than 50 old SSTables are retained.

The following recommended limitations apply:

| Type of data       | Time window size | Maximum TTL    |
|--------------------|------------------|----------------|
| Real-time trending | 3 hours          | 6 days 6 hours |
| Minute trending    | 4 days           | 200 days       |
| Hour trending      | 14 days          | 700 days       |
| Day trending       | 30 days          | 1500 days      |

> [!NOTE]
> Regardless of how the Cassandra database is configured, the TTL of the tables should never exceed the maximum TTL as defined in this table.
