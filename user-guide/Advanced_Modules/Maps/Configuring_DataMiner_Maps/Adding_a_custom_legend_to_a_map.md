---
uid: Adding_a_custom_legend_to_a_map
---

# Adding a custom legend to a map

It is possible to add a custom legend to a map, which is then visualized as a table. In this legend, you have to define table columns and a row filter. When a user clicks one of the rows in the legend, the contents of that row are then used to filter the markers of all layers of sourceType "table".

## Custom legend configuration

To configure a custom legend, add a `<CustomLegendBox>` tag, and configure it as follows.

- Attributes of the `<CustomLegendBox>` tag:

  - **visible**: Determines whether the legend is displayed on the map.
  - **width**: The width of the legend box in pixels.
  - **height**: The height of the legend box in pixels.
  - **filterVars**: Optional. Can be used to link a table filter to a URL variable. This attribute functions in the same way as when used in the `<TableSourceInfo>` tag. See [filterVars](xref:TableSourceInfo#filtervars).

- Subtags of the `<CustomLegendBox>` tag:

  - **Name**: The label that users will be able to click in order to open the legend.
  - **DataMinerID**: The ID of the table that has to be displayed in the legend.
  - **ElementID**
  - **TableID**
  - **TableColumnPIDs**: The IDs of the table column parameters that have to be displayed in the legend. If none are specified, all columns will be displayed.
  - **TableFilters**: The table row filters. This subtag functions in the same way as when used in the `<TableSourceInfo>` tag. See [TableFilters](xref:TableSourceInfo#tablefilters).
  - **FilterColumnPID**: The ID of the table column parameter that contains the value to be used to filter the layers.

Example:

```xml
<CustomLegendBox visible="true" width="500" height="200" filterVars="satellite">
  <Name>Custom Legend</Name>
  <DataMinerID>157</DataMinerID>
  <ElementID>50823</ElementID>
  <TableID>2000</TableID>
  <TableColumnPIDs>
    <TableColumnPID>2001</TableColumnPID>
    <TableColumnPID>2002</TableColumnPID>
    <TableColumnPID>2003</TableColumnPID>
    <TableColumnPID>2004</TableColumnPID>
    <TableColumnPID>2005</TableColumnPID>
  </TableColumnPIDs>
  <TableFilters>
    <TableFilter>VALUE=2020 == [satellite]</TableFilter>
  </TableFilters>
  <FilterColumnPID>2001</FilterColumnPID>
</CustomLegendBox>
```

## \[CustomLegendBoxFilterValue\] placeholder

In order to link a custom legend to a layer, use the *\[CustomLegendBoxFilterValue\]* placeholder. This placeholder will be replaced by the *FilterColumnPID* value of the row selected in the legend.

Example:

```xml
<Layer sourceType="table" refresh="60000">
  <TableSourceInfo filterVars="vessel">
    <DataMinerID>157</DataMinerID>
    <ElementID>50823</ElementID>
    <TableID>2000</TableID>
    <TableFilters>
      <TableFilter>VALUE=2001 == [CustomLegendBoxFilterValue]</TableFilter>
    </TableFilters>
    <LatitudeColumnPID>2007</LatitudeColumnPID>
    <LongitudeColumnPID>2008</LongitudeColumnPID>
    <TitleColumnPID>2002</TitleColumnPID>
    <AlarmLevelColumnPID>2004</AlarmLevelColumnPID>
    <MarkerSelectionPID>2101</MarkerSelectionPID>
  </TableSourceInfo>
</Layer>
```
