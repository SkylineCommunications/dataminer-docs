---
uid: Specifying_TTL_overrides
---

# Specifying TTL overrides

The "time to live" (TTL) determines how long specific data is retained before being automatically removed from your DataMiner System. By setting TTL overrides, you can control the lifespan of various data types, such as real-time trending, minute trending, and alarm events. Some data types, such as elements, do not have a TTL and never expire.

This page explains how to configure TTL settings to optimize your database performance and resource utilization.

In System Center, you can configure a custom TTL for data in the database. This determines how long the data is kept in the database.

1. Go to System Center \> *System settings* > *time to live*.

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

> [!NOTE]
>
> - The TTL settings are stored in the file *DBMaintenanceDMS.xml*. For more information, see [DBMaintenance.xml and DBMaintenanceDMS.xml](xref:DBMaintenance_xml_and_DBMaintenanceDMS_xml).
> - If a record is saved with a particular TTL setting in a Cassandra database, this setting applies permanently for that record, even if the configuration is later changed in Cube. The changes are only applied for new records. For example, if a record is saved with TTL set to 150 days, it will be only be removed after 150 days, even if the TTL configuration in Cube is later changed to 100 days.
> - To prevent the [year 2038 problem](xref:Year_2038_Problem_for_Cassandra) for Cassandra, from DataMiner 10.2.0 [CU14]/10.3.0 [CU2]/10.3.4 onwards, the maximum allowed TTL for databases is limited to 10 years.
