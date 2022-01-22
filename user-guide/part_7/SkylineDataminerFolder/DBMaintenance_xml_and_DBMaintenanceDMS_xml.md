---
uid: DBMaintenance_xml_and_DBMaintenanceDMS_xml
---

## DBMaintenance.xml and DBMaintenanceDMS.xml

These files mainly contain the “time to live” (TTL) settings of the databases, which determine how long data are kept in the databases.

These settings can be configured directly in DataMiner Cube from DataMiner 9.6.3 onwards.

- *DBMaintenanceDMS.xml* contains TTL information for the entire DMS, and is synchronized within the DMS.

- *DBMaintenance.xml* is deprecated from DataMiner 9.6.6 onwards. Before this, it is used for Agent-specific TTL overrides, and it is only synchronized in a Failover system.

> [!NOTE]
> - Element-specific TTL settings for trending purposes will always override TTL settings specified in *DBMaintenance.xml* or *DBMaintenanceDMS.xml*.
> - If a record is saved with a particular TTL setting in a Cassandra database, this setting applies permanently for that record, even if the configuration is later changed in these files. The changes are only applied for new records.
> - Up to DataMiner 9.5.8, *DBMaintenance.xml* and *DBMaintenanceDMS.xml* are located directly in the Skyline DataMiner folder, instead of in the Database subfolder.
> - Before you make changes to these files, always stop DataMiner. Restart DataMiner when your changes have been saved.

In this section:

- [Basic syntax of the TTL settings](#basic-syntax-of-the-ttl-settings)

- [Specifying overrides for the trending TTL of protocols](#specifying-overrides-for-the-trending-ttl-of-protocols)

- [Overriding default storage behavior for service properties in Cassandra](#overriding-default-storage-behavior-for-service-properties-in-cassandra)

- [Upgrading to a DataMiner version with DBMaintenance.xml and DBMaintenanceDMS.xml files](#upgrading-to-a-dataminer-version-with-dbmaintenancexml-and-dbmaintenancedmsxml-files)

> [!TIP]
> See also:
> - [Specifying TTL overrides](xref:Specifying_TTL_overrides)
> - [Setting the TTL for database records](xref:SLNetClientTest_tool_advanced_procedures#setting-the-ttl-for-database-records)

### Basic syntax of the TTL settings

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
    > From DataMiner 9.5.8 onwards, the TTL for spectrum records is also configured in these files, using a TTL tag with the attribute *type="SpectrumTrace"*.

- **default**: The default TLL period that will be used for all databases that do not have a specific override.

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
> - Strings without unit will be interpreted as a number of seconds.<br>For example, “3600” will be interpreted as 3600 seconds.
> - For a logger table, the TTL value can be set to “-1” to indicate that the TTL value is specified in the protocol.
> - From DataMiner 9.5.13 onwards, if the TTL value is set to “0” for a particular type of data, no data of that type will be stored in the database.
> - For an indexing database, it is possible to specify “infinite”, in which case the data will be kept indefinitely.

> [!NOTE]
> From DataMiner 9.6.3 onwards, TTL overrides for trend and alarm records should be configured directly in DataMiner Cube. See [Specifying TTL overrides](xref:Specifying_TTL_overrides).

### Specifying overrides for the trending TTL of protocols

From DataMiner 9.5.6 onwards, you can specify a TTL override for the trending of a specific protocol.

To do so:

1. Add an additional *\<TimeToLive>* tag in *DBMaintenance.xml* and/or *DBMaintenanceDMS.xml*.

2. Within the *\<TimeToLive>* tag, set the *protocol* attribute to the name of the protocol.

    To only specify the override for a particular version of the protocol, add the protocol version after the protocol name, separated from the name by a slash, e.g. protocol="Microsoft Platform/2.1.0.66".

3. Add the necessary TTL subtags using the same syntax as described above.

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
> Though the protocol TTL overrides the general TTL settings for the system, it is in turn overridden by any TTL settings that have been specified in the *Element.xml* for specific elements.

> [!NOTE]
> From DataMiner 9.6.3 onwards, TTL overrides for trend and alarm records should be configured directly in DataMiner Cube. See [Specifying TTL overrides](xref:Specifying_TTL_overrides).

### Overriding default storage behavior for service properties in Cassandra

From DataMiner 9.5.14 onwards, timetrace data for a service in the Cassandra database by default only contains the service properties that match with the service key. In earlier versions of DataMiner, the rows contained the service properties of all affected services.

It is possible to revert to the earlier behavior by adding the following tag in the *\<MaintenanceConfig>* tag of the *DBMaintenance.xml* or *DBMaintenanceDMS.xml* file: <br>*\<TimeTrace duplicateAllServiceProperties="True" />*.

However, note that this can cause a significant increase in disk space usage, especially in systems with many services and service properties.

> [!NOTE]
> Activating this option does not rewrite historic data. New rows will again contain the properties, but old rows will not be updated.

### Upgrading to a DataMiner version with DBMaintenance.xml and DBMaintenanceDMS.xml files

When you upgrade a DataMiner Agent without the two new configuration files to a version with these files, *DBMaintenance.exe* will copy a number of settings from the *DB.xml* and *MaintenanceSettings.xml* files to the new configuration files. See the following table:

| Existing setting                                                | New setting          |
|-----------------------------------------------------------------|----------------------|
| DB.xml<br> \> Maintenance \> MonthsToKeep                       | Alarm TTL            |
| DB.xml<br> \> Historyslider \> TimeToKeep                       | TimeTrace TTL        |
| MaintenanceSettings.xml<br> \> Trending \> TimeSpan             | RealTimeTrending TTL |
| MaintenanceSettings.xml<br> \> Trending \> TimeSpan5MinRecords  | FiveMinTrending TTL  |
| MaintenanceSettings.xml<br> \> Trending \> TimeSpan1HourRecords | OneHourTrending TTL  |
| MaintenanceSettings.xml<br> \> Trending \> TimeSpan1DayRecords  | OneDayTrending TTL   |

When you downgrade to a DataMiner Agent without the two new configuration files, *DBMaintenance.exe* will revert the above-mentioned copy actions and update the settings in question in both the *DB.xml* and *MaintenanceSettings.xml* files.
