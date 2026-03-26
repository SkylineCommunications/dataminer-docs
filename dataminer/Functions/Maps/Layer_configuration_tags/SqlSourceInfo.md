---
uid: SqlSourceInfo
---

# SqlSourceInfo

In the `<SqlSourceInfo>` tag, you have to specify the SQL SELECT statement that has to retrieve the necessary data in order to draw the layer’s objects, which can be either markers or lines.

- If the style attribute is set to "markers" (i.e., the default setting), the layer will display markers, each positioned at a location specified by one pair of latitude/longitude values retrieved from the database.

- If the style attribute is set to "lines", the layer will display lines, each connecting two pairs of latitude/longitude values retrieved from the database. Each line will be displayed as a geodesic, a segment of a "great circle" representing the shortest distance between two points on the surface of the Earth.

- It is possible to add a *dataminerVar* attribute, specifying the name of the URL variable that contains the ID of the DMA that has to execute the SQL query.

  For example, you could specify the following configuration and corresponding URL:

  ```xml
  <SqlSourceInfo style="lines" filterVars="datefrom;dateto" dataminerVar="dma">
  http://localhost/maps/map.aspx?config=myConfig&ddma=157
  ```

  > [!NOTE]
  > If there is no *dataminerVAr* attribute or if the specified DMA does not exist, the DMA specified in the `<DataMinerID>` subtag will be used instead.

## SqlSourceInfo subtags

Inside the `<SqlSourceInfo>` tag, specify the tags detailed below.

### DataMinerID

The DataMiner ID of the DMA that hosts the database containing the table from which the marker coordinates will be retrieved.

### Target

The name of the database containing the table from which the marker coordinates will be retrieved.

Possible values:

- "local" (for the general database),

- "central" (for the offload database), or

- the name of any database that has been defined in the *DB.xml* file.

Default: local

### Sql

The SELECT statement that will retrieve the necessary data.

> [!NOTE]
> In this statement, you can use the *\[DMA_USERNAME\]* placeholder. At runtime, it will be replaced by the name of the current user.

## Example

```xml
<Layer sourceType="sql" refresh="20000">
  <SqlSourceInfo style="markers">
  <DataMinerID>111</DataMinerID>
  <Sql><![CDATA[
  Select
    lat as Latitude, lon as Longitude,
    lat2 as Latitude2, lon2 as Longitude2,
    title as Title, lvl as AlarmLevel,
    idmaptest as PrimaryKey, marker as Marker
  from
    maptest
  ]]></Sql>
  <Target/>
  </SqlSourceInfo>
  ...
</Layer>
```

## Structure of the database table

The records in the database table from which to retrieve the marker coordinates have to contain the following fields.

The name of the database table as well as the names of the table fields can be chosen at will. However, if you use field names other than the ones listed below, then you will have to provide field aliases in the SELECT statement.

| Field name | Data type | Description |
|--|--|--|
| PrimaryKey | int | Table record ID |
| Latitude | varchar | Set of coordinates that defines the position of the marker. If the map has to display lines instead of markers, this is the first of the two sets of coordinates that defines the line to be displayed. |
| Longitude | varchar | See Latitude. |
| Latitude2 | varchar | If the map has to display lines instead of markers, this is the second of the two sets of coordinates that defines the line to be displayed. |
| Longitude2 | varchar | See Latitude2. |
| Title | varchar | The text of the tooltip that has to appear when you hover your mouse over the marker. |
| AlarmLevel | varchar | Alarm severity level that will determine the color of the marker or line, e.g., critical, major, minor, warning, normal, etc. |
| Marker | varchar | The ID of the marker image as defined in the `<MarkerImages>` tag. |

> [!NOTE]
> In case of normal, point-shaped markers, only Latitude and Longitude are mandatory fields. In case of line-shaped markers, also the Latitude2 and Longitude2 fields are mandatory.

## Date picker controls

On layers of sourcetype "sql", you can display date picker controls. That way, you can allow users to specify the dates used in the SQL statement.

In the example below, the datepicker option has been specified. Notice that the WHERE clause of the SQL query contains the placeholders \[datefrom\] and \[dateto\]. These will be replaced by the dates selected in the date picker control.

```xml
<Layer sourceType="sql" refresh="180000" name="Route Trace" visible="false" allowToggle="true"  toggleGroup="Route Trace" option="datepicker">
  <SqlSourceInfo style="lines" filterVars="vessel">
    <DataMinerID>19302</DataMinerID>
    <Sql><![CDATA[
    Select GPSLat as Latitude, GPSLong as Longitude,
    GPSLatPrev as Latitude2, GPSLongPrev as Longitude2,
    GPSCustom2 as AlarmLevel, GPSName as Title,
    GPSCustom1 as Customer, AutoInc as PrimaryKey,
    TimeStamp as TimeStamp FROM elementdata_389_4000
    WHERE TimeStamp >= [datefrom] AND TimeStamp <= [dateto];
    ]]></Sql>
  </SqlSourceInfo>
</Layer>
```
