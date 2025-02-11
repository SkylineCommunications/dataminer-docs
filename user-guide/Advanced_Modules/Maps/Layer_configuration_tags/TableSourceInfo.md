---
uid: TableSourceInfo
---

# TableSourceInfo

In the `<TableSourceInfo>` tag, you have to specify the dynamic table from which to retrieve the necessary data in order to draw the layer’s objects, which can be either markers or lines.

- If the *style* attribute is set to "markers" (i.e. the default setting), the layer will display markers, each positioned at a location specified by one pair of latitude/longitude values retrieved from the dynamic table.

- If the *style* attribute is set to "lines", the layer will display lines, each connecting two pairs of latitude/longitude values retrieved from the dynamic table. Each line will be displayed as a geodesic, a segment of a "great circle" representing the shortest distance between two points on the surface of the Earth.

- You can add an *alarmLevelType* attribute to determine how alarms are displayed for map items on this layer. This attribute can be set to the following values:

  - *instance*: Only the alarm level for each particular instance will be displayed.

  - *bubbleup*: The highest alarm level of all items below this level will be displayed.

  - *summary*: Each item in this layer will display a combination of the instance alarm level and the bubble-up level. This is the default value.

> [!NOTE]
> The lines defined in this tag can inherit the alarm colors configured in the *DataMiner.xml* file.

## TableSourceInfo subtags

Inside the `<TableSourceInfo>` tag, you have to place the tags detailed below.

### DataMinerID

In this mandatory tag, specify the ID of the DataMiner Agent on which the element was created.

### ElementID

In this mandatory tag, specify the ID of the element.

### TableID

In this mandatory tag, specify the ID of the dynamic table.

### LatitudeColumnPID/LongitudeColumnPID/LatitudeColumnPID2/LongitudeColumnPID2

The parameter IDs of the table columns containing the latitude and longitude values.

- If the style attribute is set to "markers", only one pair of latitude/longitude values has to be specified in the *\<LatitudeColumnPID>* and *\<LongitudeColumnPID>* tags. In that case, the *\<LatitudeColumnPID2>* and *\<LongitudeColumnPID2>* tags will not be used and can therefore be omitted.

- If the style attribute is set to "lines", two pairs of latitude/longitude values have to be specified: one pair in the *\<LatitudeColumnPID>* and *\<LongitudeColumnPID>* tags, and another pair in the *\<LatitudeColumnPID2>* and *\<LongitudeColumnPID2>* tags.

### TitleColumnPID

In this optional tag, you can specify the parameter ID of the table column containing the text that has to appear when you hover your mouse over a marker.

### AlarmLevelColumnPID

In this optional tag, you can specify the parameter ID of the table column of which the alarm severity of the cells will determine the alarm color of the markers.

If the marker images are image strips containing a separate image for every alarm severity, then the alarm severities of the cells in this column will determine which of the images in the strip will be displayed.

Markers indicating a masked alarm will be shown in the color associated with the "Masked" status (default: purple).

> [!NOTE]
> The cells in the specified column must be monitored, i.e. they must be included in at least one Alarm template.

### MarkerSelectionPID

In this optional tag, you can specify the parameter ID of the table column containing the marker image IDs.

If, for a specific marker, this column contains an image ID corresponding to a particular MarkerImage ID, then the marker will be displayed on the map using that specific marker image. If, however, no marker image can be found of which the ID matches the image ID retrieved from the dynamic table, then the marker will be displayed using the first marker image defined in the `<MarkerImages>` tag.

### TableFilters

In this optional tag, you can specify one or more row filters in `<TableFilter>` tags.

Use the following syntax:

```txt
value=[ColumnPID][Operator][Value]
```

Examples:

- operators: ==, ...

- values: landmark, t\*, tanker??, ...

> [!NOTE]
>
> - There must be a space before and after the operator.
> - In a table filter, you can use the \[DMA_USERNAME\] placeholder. At runtime, it will be replaced by the name of the current user.
> - You can use the *recursivefullfilter* option in a table filter. See [Dynamic table filter syntax](xref:Dynamic_table_filter_syntax).

## Passing TableSourceInfo data along in the map’s URL

The DataMiner ID, the element ID and the table filter values can be passed along as a parameter in the map’s URL.

### elementVar

If, in the *\<TableSourceInfo>* tag, you add an elementVar attribute with value "myElement" that refers to an Element using the syntax "DMAID/ElementID" or "NameOfElement", then you can omit both the *\<DataMinerID>* tag and the *\<ElementID>* tag and use a map URL like one of the following instead (notice the "d" in front of the parameter name!):

```txt
maps.aspx?config=MyConfigFile&dmyElement=7/46840
maps.aspx?config=MyConfigFile&dmyElement=VesselData
```

### filterVars

If, in the *\<TableSourceInfo>* tag, you add a filterVars attribute with value "myFilter", in a particular *\<TableFilter>* tag, you can replace the fixed value by "\[myFilter\]" and pass the filter value as a parameter in the map’s URL like this (notice the "d" in front of the parameter name!):

```txt
maps.aspx?config=MyConfigFile&dmyFilter=box*
```

> [!NOTE]
> In the value of a filterVars attribute, you can specify several parameters separated by semicolons (";").
