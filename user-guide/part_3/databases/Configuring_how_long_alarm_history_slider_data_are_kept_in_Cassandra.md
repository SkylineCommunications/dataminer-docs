## Configuring how long alarm history slider data are kept in Cassandra

In a Cassandra general database, the timetrace table among others contains “snapshots”, which are used to visualize historic alarm information in the DataMiner Cube history slider. Depending on your DataMiner version, there is a different way to customize how long these history slider data are kept in this table.

> [!NOTE]
> To manage how long other alarm data are kept, go to System Center \> *System settings* > *time to live*. For more information, see [Specifying TTL overrides](Specifying_TTL_overrides.md)

> [!TIP]
> See also:
> [Configuring how alarm history slider data are kept in a Cassandra database](../../part_7/SkylineDataminerFolder/DB_xml.md#configuring-how-alarm-history-slider-data-are-kept-in-a-cassandra-database)

#### From DataMiner 9.6.0 \[CU1\]/9.6.6 onwards

From DataMiner 9.6.0 \[CU1\]/9.6.6 onwards, you can manage these settings in DataMiner Cube, by setting the “time to live” for the history slider in System Center. for more information, see [Specifying TTL overrides](Specifying_TTL_overrides.md).

#### From DataMiner 9.5.5 onwards

From DataMiner 9.5.5 onwards, the amount of history slider data kept in this timetrace table can be limited in the file *DBMaintenanceDMS.xml*.

To customize this setting:

1. Stop DataMiner.

2. Go to the folder *C:\\Skyline DataMiner\\Database* (or *C:\\Skyline DataMiner* prior to DataMiner 9.5.8) and open the file *DBMaintenanceDMS.xml.*

3. Within the *\<TimeToLive>* tag, make sure there is a TTL tag with the following attributes:

    - A “type” attribute set to “TimeTrace”.

    - A “default” attribute set to the period of time that the data should be kept. For more information on the time format to use, see [Basic syntax of the TTL settings](../../part_7/SkylineDataminerFolder/DBMaintenance_xml_and_DBMaintenanceDMS_xml.md#basic-syntax-of-the-ttl-settings).

    For example:

    ```xml
    <MaintenanceConfigs>
      <MaintenanceConfig type="DMS" xmlns="http://www.skyline.be/config/dbmaintenance">
        <TimeToLive>
          ...
          <TTL type="TimeTrace" default="1Y"/>
          ...
        </TimeToLive>
      </MaintenanceConfig>
    </MaintenanceConfigs>
    ```

4. Save the file and restart DataMiner.

> [!NOTE]
> From DataMiner 9.6.1 onwards, the default value for this setting is 1 month.

#### Prior to DataMiner 9.5.5

Prior to DataMiner 9.5.5, the amount of history slider data kept in the timetrace table can be limited with the *\<HistorySlider>* setting in the file *DB.xml*.

To customize this setting:

1. Stop DataMiner

2. Go to the folder *C:\\Skyline DataMiner* and open the file *DB.xml*.

3. In the *HistorySlider.TimeToKeep* tag, specify a number of seconds between 0 and 2,147,483,647:

    - If you specify 0, no history slider data will be saved.

    - If you specify -1, history slider data will be saved for the period specified in the monthsToKeep attribute of the Maintenance tag. See [Configuring the maintenance settings](../../part_7/SkylineDataminerFolder/DB_xml.md#configuring-the-maintenance-settings).

    - If a period of longer than twenty years is specified, DataMiner will limit this to twenty years.

    Example:

    ```xml
    <DataBase active="true" type="Cassandra" local="true">
      ...
      <HistorySlider>
        <TimeToKeep>-1</TimeToKeep>
      </HistorySlider>
    </DataBase>
    ```

4. Save the file and restart DataMiner.
