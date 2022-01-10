# Specifying TTL overrides

From DataMiner 9.6.3 onwards, you can configure a custom "time to live" (TTL) for data in the database. From DataMiner 9.6.0 \[CU1\]/9.6.6 onwards, the user interface for this configuration has been redesigned.

> [!NOTE]
> - The TTL settings are stored in the file *DBMaintenanceDMS.xml*. Prior to DataMiner 9.6.0 \[CU1\]/9.6.6, settings for one DMA only can also be saved in *DBMaintenance.xml*. For more information, see [DBMaintenance.xml and DBMaintenanceDMS.xml](../../part_7/SkylineDataminerFolder/DBMaintenance_xml_and_DBMaintenanceDMS_xml.md#dbmaintenancexml-and-dbmaintenancedmsxml).
> - If a record is saved with a particular TTL setting in a Cassandra database, this setting applies permanently for that record, even if the configuration is later changed in Cube. The changes are only applied for new records. For example, if a record is saved with TTL set to 150 days, it will be only be removed after 150 days, even if the TTL configuration in Cube is later changed to 100 days.

#### TTL configuration from DataMiner 9.6.0 \[CU1\]/9.6.6 onwards

From DataMiner 9.6.0 \[CU1\]/9.6.6 onwards, you can configure the TTL as follows:

1. Go to System Center \> *System settings* > *time to live*.

2. To configure general TTL overrides:

    1. Specify the necessary override values in the *DMS defaults* section.

        - If your system has an Indexing database, the *Local* column contains TTL settings for the Cassandra general database, and the *Indexing* column contains TTL settings for the Indexing database.

        - At present, trending information is not saved in the indexing database. As such, if your DMS uses an indexing database, only the settings in the *Local* column of the *time to live* page will be taken into account for trending.

        - The *Alarm events* setting applies both for alarms and information events.

    2. Click *Apply*.

3. To configure TTL overrides for the trend data of a specific protocol or protocol version:

    1. In the *Overrides* section, click *Add*.

    2. In the pop-up window, select a protocol and, if necessary, a protocol version, and click *Add*.

    3. In the *Trending* section on the right, specify the necessary override values in the boxes for the various records.

    4. Click *Apply*.

The following default values and limitations apply:

| Type of data       | Default TTL | Minimum TTL      | Maximum TTL |
|--------------------|-------------|------------------|-------------|
| Real-time trending | 1 day       | 15 minutes       | 1098 days   |
| Minute trending    | 31 days     | 1 hour           | 1098 days   |
| Hour trending      | 366 days    | 12 hours         | 1830 days   |
| Day trending       | 0 seconds   | 15 days 12 hours | 5490 days   |
| Alarm events       | 366 days    | 1 hour           | 5490 days   |
| History slider     | 31 days     | 1 hour           | 5490 days   |
| Spectrum traces    | 366 days    | 1 hour           | 5490 days   |

#### TTL configuration prior to DataMiner 9.6.0 \[CU1\]/9.6.6

Prior to DataMiner 9.6.0 \[CU1\]/9.6.6, the TTL is configured as follows:

1. Go to System Center \> *System settings* > *time to live*.

2. To configure an alarm TTL override:

    1. In the alarm tab, click *Add alarm config*.

    2. By default, a new override is set for the entire DMS. To specify an override for one DMA only, next to *Override on*, select *DataMiner Agents* and then select the DMA.

    3. By default, a new override is set for all databases. To specify an override for a specific database only, select the database in the *Database* drop-down list.

    4. In the *Value* box, specify the TTL value.

3. To configure a trending TTL override:

    1. Click *Add trending config* and select a type of configuration.

        The following types are available:

        | Configuration type | Scope                                                         |
        |----------------------|---------------------------------------------------------------|
        | DataMiner            | All trend data, regardless of protocol or protocol version.   |
        | Protocol             | Trend data related to one specific protocol.                  |
        | Protocol version     | Trend data related to one or more specific protocol versions. |

    2. By default, a new override is set for the entire DMS. To specify an override for one DMA only, next to *Override on*, select *DataMiner Agents* and then select the DMA.

    3. For a *Protocol* or *Protocol version* override, select the protocol or the protocol and protocol version(s), respectively.

    4. By default, a new override is set for all databases. To specify an override for a specific database only, select the database in the *Database* drop-down list.

    5. Set the TTL values for the real-time records, the minute records, the hour records and the day records.

        The following limits apply:

        | Record Type     | Minimum value | Maximum value |
        |-------------------|---------------|---------------|
        | Real-time records | 30 minutes    | 10 days       |
        | Minute records    | 30 minutes    | 6 months      |
        | Hour records      | 1 week        | 15 years      |
        | Day records       | 1 week        | 15 years      |

        > [!NOTE]
        > If you clear the selection of the checkbox in front of a particular record type, no data for this record type will be included in the database.

4. Click the *Save* button at the bottom of the card.
