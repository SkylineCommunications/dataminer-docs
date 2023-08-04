---
uid: DBMaintenance_xml_and_DBMaintenanceDMS_xml
---

# DBMaintenance.xml and DBMaintenanceDMS.xml

These files are located in the *Database* subfolder. They mainly contain the “time to live” (TTL) settings of the databases, which determine how long data are kept in the databases.

- *DBMaintenanceDMS.xml* contains TTL information for the entire DMS, and is synchronized within the DMS.

- *DBMaintenance.xml* is deprecated from DataMiner 9.6.6 onwards. Before this, it was used for Agent-specific TTL overrides.

> [!NOTE]
>
> - If you make changes to these files, always stop DataMiner first, and restart DataMiner when your changes have been saved.
> - To prevent the [year 2038 problem](xref:Year_2038_Problem_for_Cassandra) for Cassandra, from DataMiner 10.2.0 [CU14]/10.3.0 [CU2]/10.3.4 onwards, the maximum allowed TTL for databases is limited to 10 years.

## Basic syntax of the TTL settings

> [!IMPORTANT]
> We recommend configuring these settings directly in DataMiner Cube. See [Specifying TTL overrides](xref:Specifying_TTL_overrides).

Example of TTL settings in *DBMaintenanceDMS.xml*:

```xml
<MaintenanceConfigs>
  <MaintenanceConfig type="DMS" xmlns="http://www.skyline.be/config/dbmaintenance">
    <TimeToLive>
      <TTL type="Alarm" default="1Y">
        <Local>1Y</Local>
        <Indexing>6M</Indexing>
      </TTL>
      <TTL type="TimeTrace" default="1Y"/>
      <TTL type="RealTimeTrending" default="1D"/>
      <TTL type="FiveMinTrending" default="1M"/>
      <TTL type="OneHourTrending" default="1Y"/>
      <TTL type="OneDayTrending" default="1Y"/>
    </TimeToLive>
  </MaintenanceConfig>
</MaintenanceConfigs>
```

Each TTL tag has the following attributes:

- **type**: The type of database record for which the TTL applies. e.g. *Alarm*, *RealTimeTrending*, *FiveMinTrending*, *OneHourTrending*, *OneDayTrending*, etc. This can also be set to a particular data type or to the name of a logger table.

  > [!NOTE]
  >
  > - The *TimeTrace* TTL type determines how long “snapshots” in the timetrace table are kept. These are used to visualize history alarm information in the DataMiner Cube history slider.
  > - The *SpectrumTrace* TTL type determines how long spectrum records are kept.

- **default**: The default TTL period that will be used for all databases that do not have a specific override.

In addition, it can have the following subtags:

- **Local**: TTL period that will override the default TTL setting in case the table in question is part of the general database.

- **Indexing**: TTL period that will override the default TTL setting in case the table in question is part of an indexing database.

    From DataMiner 10.0.3 onwards, it is possible to specify TTL settings for custom data stored in the indexing database. For example, for jobs this can be configured as follows:

    ```xml
    <TTL type="cjobsection">
      <Indexing>6M</Indexing>
    </TTL>
    ```

When specifying TTL periods, use the following units:

| Unit | Description |
|------|-------------|
| Y    | years       |
| M    | months      |
| D    | days        |
| h    | hours       |
| m    | minutes     |
| s    | seconds     |

Examples:

- To specify a period of 1.5 years, you can use “1Y6M” or “6M1Y”.

- To specify a period of 1 hour, you can use “1h”, “3600s” or “3600”.

> [!NOTE]
>
> - Strings without unit will be interpreted as a number of seconds. For example, “3600” will be interpreted as 3600 seconds.
> - For a logger table, the TTL value can be set to “-1” to indicate that the TTL value is specified in the protocol.
> - If the TTL value is set to “0” for a particular type of data, no data of that type will be stored in the database.
> - For an indexing database, it is possible to specify “infinite”, in which case the data will be kept indefinitely.
> - Element-specific TTL settings for trending purposes will always override TTL settings specified here.
> - If a record is saved with a particular TTL setting in a Cassandra database, this setting applies permanently for that record, even if the configuration is later changed in these files. The changes are only applied for new records.

## Overrides for the trending TTL of protocols

> [!IMPORTANT]
> We recommend configuring these settings directly in DataMiner Cube. See [Specifying TTL overrides](xref:Specifying_TTL_overrides).

TTL overrides for the trending of a specific protocol are specified with an additional *\<TimeToLive>* tag, with the *protocol* attribute set to the name of the protocol. Optionally, the version can also be added, e.g. protocol="Microsoft Platform/2.1.0.66".

Example of a *DBMaintenanceDMS.xml* file with protocol override:

```xml
<MaintenanceConfigs>
  <MaintenanceConfig type="DMS" xmlns="http://www.skyline.be/config/dbmaintenance">
    <TimeToLive>
      <TTL type="Alarm" default="1Y">
        <Local>2Y</Local>
      </TTL>
      <TTL type="TimeTrace" default="1Y"/>
      <TTL type="RealTimeTrending" default="1D"/>
      <TTL type="FiveMinTrending" default="1M"/>
      <TTL type="OneHourTrending" default="1Y"/>
      <TTL type="OneDayTrending" default="1Y"/>
    </TimeToLive>
    <TimeToLive protocol="MyProtocol">
      <TTL type="RealTimeTrending" default="1D">
        <Local>2D</Local>
      </TTL>
      <TTL type="FiveMinTrending" default="2M"/>
      <TTL type="OneHourTrending" default="1Y">
        <Local>2Y</Local>
      </TTL>
      <TTL type="OneDayTrending" default="2Y"/>
    </TimeToLive>
  </MaintenanceConfig>
</MaintenanceConfigs>
```

> [!NOTE]
> Though the protocol TTL overrides the general TTL settings for the system, it is in turn overridden by any TTL settings that have been specified for specific elements.

## Overriding default storage behavior for service properties in Cassandra

From DataMiner 9.5.14 onwards, timetrace data for a service in the Cassandra database by default only contains the service properties that match with the service key. In earlier versions of DataMiner, the rows contained the service properties of all affected services.

It is possible to revert to the earlier behavior by adding the following tag in the *\<MaintenanceConfig>* tag of the *DBMaintenance.xml* or *DBMaintenanceDMS.xml* file: *\<TimeTrace duplicateAllServiceProperties="True" />*.

However, note that this can cause a significant increase in disk space usage, especially in systems with many services and service properties.

> [!NOTE]
> Activating this option does not rewrite history data. New rows will again contain the properties, but old rows will not be updated.
