---
uid: Protocol.Chains.Chain.Field-options
---

# options attribute

Specifies a number of options.

## Content Type

string

## Parent

[Field](xref:Protocol.Chains.Chain.Field)

## Remarks

The following sections provide more information on the options for this tag:

- details
- detailTabs
- DiagramSort
- displayInFilter
- displayInFilterCombo
- filter
- FilterCombo
- FilterMode
- fixedPosition
- ignoreEmptyFilterValues
- KPIsInDiagram
- ListKPIHide
- MaxDiagramPid
- MaxDiagramsOnRow
- MaxDiagramsOnRowForParent
- NoLoadOnFilter
- Readonly
- SeverityColumn
- ShowBubbleupAndInstanceAlarmLevel
- ShowCPEChilds
- ShowSiblings
- showTree
- skipInDiagram
- statusTabs
- tabOrder
- tabs
- TileList
- TopologyChains

### details

Use this option to specify tables that will be displayed in the details pane with a filter on the selection. Separate multiple tables with commas in order to show them in different blocks, or with pipe characters to show them in the same block.

Examples:

- To display rows linked to the selection:

  ```xml
  details:11400-KPI|11300
  ```

- To display rows that are linked to the selection AND have value “19” for parameter 11304:

  ```xml
  details:11400-KPI|11300-VALUE=11304==19
  ```

  This filter can contain the dynamic keywords [tableindex] and [displaytableindex]

- To display all rows of the specified table, regardless of the selection filter:

  ```xml
  details:11400-KPI|11300-NoSelectionFilter
  ```

  - To display all rows that have value “19” for parameter 11304, regardless of the selection filter:

  ```xml
  details:11400-KPI|11300-VALUE=11304==19-NoSelectionFilter
  ```

*Feature introduced in DataMiner 8.0.4 (RN 5863).*

> [!NOTE]
> From DataMiner 9.0.0 (RN 10826) onwards, read parameters with multiple lines can be displayed in the details pane. You can define how many lines should be displayed with the lines attribute of the Protocols.Params.Param.Measurement.Type tag. If the value contains more lines, a scrollbar will be displayed. See lines.

### detailTabs

Use this option to specify additional tab pages that will be displayed next to the diagram tab page. To do so, specify a comma-separated list of tables. Each of the items in the list represents an additional tab page.

Example:

```xml
options="detailTabs:1700,1800,1900”
```

- From DataMiner 8.0.5 (RN 6406) onwards, EPM (formerly known as CPE) tables with the detailTabs option have their header titles wrapped over multiple lines with a maximum height of 100px.

  > [!NOTE]
  > Columns for which the protocol specifies an initial width of less than 20 px will not wrap. These kinds of columns are meant to remain small. The height of their header is therefore not allowed to grow.

- From DataMiner 9.0.4 (RN 13060) onwards, it is possible to define custom filters for the detailTabs option, just like for the details option. See details.

  For example:

  ```xml
  detailTabs:19000-VALUE=19002 == [tableindex]-NoSelectionFilter
  ```

- From DataMiner 9.5.2 (RN 14811) onwards, it is possible to add tabs showing KPIs. To do so, use the detailTabs option with the ID of the table of the current field.

  For example:

  ```xml
  <Field name="Headends" options=";displayInFilter;detailTabs:23000" pid="23001"/>
  ```

- From DataMiner 9.5.10 (RN 17735) onwards, it is possible to specify multiple filters in the custom filter of an EPM (formerly known as CPE) details tab by using a backslash ('\') as separator.

  For example, to filter on the primary key and on "recursive", you can specify the following configuration:

  ```xml
  detailTabs:11200-VALUE=11242 == [tableindex]\recursive-NoSelectionFilter-ListKPIHide
  ```

  > [!NOTE]
  > If you need to add a backslash in the filter, you can do so by specifying it twice.

### DiagramSort

Sorting per field (horizontal stack of items in the diagram).

- Name: sorted by the display value.
- CellSeverity: sorted by alarm severity of item and sub-items.
- BubbleUpSeverity: sorted by alarm severity of sub-items only.
- InstanceSeverity: sorted by alarm severity of item only (KPIs).

Sorting only applies to the diagram and not to the tables or lists.

You can combine sorting methods by adding ”:”, followed by a 0-based number.

In the following example, we first sort by bubble-up, and then by instance.

```xml
options="DiagramSort:BubbleUpSeverity:0;DiagramSort:InstanceSeverity:1"
```

*Feature introduced in DataMiner 8.0.6 (RN 6690).*

From DataMiner 9.0.5 onwards (RN 13808), it is possible to specify that the diagram items have to be sorted based on the value of a particular column parameter. This is done by specifying the ID of the column parameter.

Example:

```xml
<Field options="DiagramSort:BubbleUpSeverity:0;DiagramSort:1002:1;DiagramSort:1003:2" ... >
```

In this example, the items will first be ordered by bubble-up alarm level, then by the value found in column 1002 and then by the value of column 1003.

> [!NOTE]
>
> - Empty values (Not Initialized) are always put at the bottom of the list.
> - If a column value changes, the diagram items will automatically be sorted again.

From DataMiner 9.5.3 (RN 14946) onwards, it is possible to define the sorting order (ascending or descending), by adding |ASC (for ascending order) or |DESC (for descending order) after the sorting field.

Example:

```xml
<Field name="Room" options="DiagramSort:1506|DESC:1" pid="1502"/>
```

The default sort order is ascending.

> [!NOTE]
> In DataMiner 9.5.1 (RN 14442, RN 14468), a dedicated tag DiagramSorting has been introduced, which renders this feature obsolete (see <xref:Protocol.Chains.Chain.Field.DiagramSorting>). New implementations should therefore use the dedicated tag instead of this option.

### displayInFilter

Specify this option to also display the field in the filter column on the left side of the EPM (formerly known as CPE) UI. In addition, this option makes it possible to double-click the diagram item corresponding to this field to navigate to other items.

```xml
<Field name="Room" options="ShowCPEChilds;displayInFilter" pid="1502"/>
```

See also:

[showTree](xref:Protocol.Chains.Chain.Field-options#showtree)

### displayInFilterCombo

Combined with and linked to a FilterCombo field. If you specify this option, the field represents one item in the FilterCombo field. See [FilterCombo](xref:Protocol.Chains.Chain.Field-options#filtercombo).

### filter

Can be used to add an extra filter. While by default only linked rows are displayed, it is possible to specify for example options="filter:value=1002 == 2" to only show the rows where pid 1002 has value 2.

### FilterCombo

Displays the filter as a combobox. Followed by a colon and the name of the combo. The items that can be selected in the combobox are configured by means of the displayInFilterCombo option.

Example:

```xml
<Chain name="Quick">
    <Field name="Type" options="FilterCombo:Type" pid="0"/>
    <Field name="Region" options="displayInFilterCombo:Type" pid="1002"/>
    <Field name="Headend" options="displayInFilterCombo:Type" pid="1502"/>
    <Field name="Packet" options="displayInFilterCombo:Type" pid="1602"/>
    <Field name="Cable" options="displayInFilterCombo:Type" pid="1702"/>
    <Field name="Customer" options="displayInFilterCombo:Type" pid="1802"/>
    <Field name="CPE" options="displayInFilterCombo:Type" pid="1902"/>
</Chain>
```

### FilterMode

Specify the option FilterMode=edit to ensure that users need to specify an exact value in the filter, instead of selecting a value in a drop-down list as usual.

### fixedPosition

Normally, fields follow a predefined path, as specified in the protocol. This option can be used to override this path, so that two fields can have the same position.

For example, if two fields “Packet” and “Cable” should be on the same level below “Headend”, specify the following option in both the “Packet” and “Cable” fields:

```xml
fixedPosition=2
```

The position starts at 0 (for example, 0=Region, 1=Headend, 2=Packet and Cable).

In the example above, if fixedPosition is not used and “Cable” is selected in the filter, the “Packet” field is disabled, and the child filter lists only items linked to “Cable”. If fixedPosition is used and “Cable” is selected in the filter, the “Packet” field remains enabled, and the child filter lists all items linked to selected items (i.e. selected Packet and selected Cable).

### ignoreEmptyFilterValues

It is possible that the column where the filter values are stored has rows with empty values (e.g. because the row was removed while aggregation was still going on, so that the row was created again). With this option, empty values are not included in the filter drop-down list.

### KPIsInDiagram

Displays KPIs (i.e. parameter values) inside a diagram box.

Syntax:

`KPIsInDiagram:SomeText{pid:PID}Text{pid:OtherPID}`

Remarks:

- After "KPIsInDiagram:", any text is allowed except reserved characters such as ";".
- Table column values can be inserted with {pid:PID} placeholders (e.g. {pid:1005}).
These values will be updated in the diagram each time they change.
- If you use "\", "{" or "}" characters in the text, make sure to place a "\" character in front of them.
- The following special characters can be used: "\n" (new line) and "\t" (tab).
- Leading and trailing whitespace is removed.
- "KPIsInDiagram" and "pid" are case insensitive.

Example:

```xml
<Field name="Location" options="...;KPIsInDiagram:(online:{pid:1008} offline: {pid:1009})" pid="1002"/>
<Field name="Location" options="...;KPIsInDiagram:Online:\t{pid:1008}\nOffline:\t{pid:1009}" pid="1002"/>
<Field name="Location" options=";KPIsInDiagram:Escaped: \{0\} Not escaped:{pid:1002}" pid="1002"/>
```

*Feature introduced in DataMiner 9.0.5 (RN 13739).*

> [!NOTE]
> From DataMiner 9.5.1 onwards (RN 14468), this feature can no longer be used, as it has been rendered obsolete by a dedicated DiagramPids tag (see Protocol.Chains.Chain.Field.DiagramPids).

### ListKPIHide

Combined with the DetailTabs option (see detailTabs). Use this option to hide the panel on the right-hand side with the KPIs of the selected item. Specify the option immediately after the ID of the list, using a dash as separator.

Example:

```xml
detailTabs:3000-ListKPIHide,2000,1000
```

*Feature introduced in DataMiner 8.0.6 (RN 5828).*

### MaxDiagramPid

Option to stop displaying the topology on a certain parent level when this filter is selected.

For example, suppose that normally the displayed topology is as follows:

```
100
|
200
|
300
```

When MaxDiagramPid:200 is specified on field 300, and this filter 300 is selected, the following topology will be displayed:

```
200
|
300
```

### MaxDiagramsOnRow

By default, at most 5 items are shown per topology level in an EPM (formerly known as CPE) element. If there are more items, they are combined in the last box. Use this option to show more items per topology level.

Example:

```xml
MaxDiagramsOnRow:8
```

### MaxDiagramsOnRowForParent

This setting is similar to the MaxDiagramsOnRow option, but applies to the upper part of the topology tree.

When a certain node has multiple parents, only a maximum number of items is followed upwards in the tree. All other items are summarized in one block. This prevents large topology trees from having a negative impact on server performance.

*Feature introduced in DataMiner 8.5.0 (RN 7424).*

### NoLoadOnFilter

Use this option to prevent that all items are loaded when a user clicks the filter box.

- If the user enters text in the filter box and clicks the “Down” button, the items will be loaded, but only the items of which the name starts with the entered text.
- If the user clicks the “Down” button without any text in the filter box, a warning will be shown.

The option NoLoadOnFilter can be entered per field:

```xml
<Chain name="Geo">
    <Field name="Region" options="showTree;ShowCPEChilds;displayInFilter;tabs:10000-KPI;detailTabs:10200,10400" pid="10002" xmlns="http://www.skyline.be/protocol"/>
    <Field name="County" options="showTree;TileList;ShowCPEChilds;displayInFilter; tabs:10200-KPI;detailTabs:10400" pid="10202" xmlns="http://www.skyline.be/protocol"/>
    <Field name="Town" options="showTree;ShowCPEChilds;TileList;NoLoadOnFilter; displayInFilter;tabs:10400-KPI" pid="10402" xmlns="http://www.skyline.be/protocol"/>
</Chain>
```

*Feature introduced in DataMiner 8.0.3 (RN 6186).*

### Readonly

Used for filter sections that cannot be filled in directly, but are only filled in via other selections. (Cannot be combined with the FilterCombo option).

### SeverityColumn

From DataMiner 8.0.6 onwards (RN 5828), you can configure an additional “severity” column right next to the primary key column for EPM (formerly known as CPE) lists. This column will contain the summary level of the row and you will be able to sort on it.

Specify the SeverityColumn option right after the list ID (and separate both with a dash).

Example:

```xml
detailTabs:3000-SeverityColumn-otheroptions,2000,1000
```

From DataMiner 8.5.4 onwards (RN 9250), it is possible to specify the width of the “Severity” column.

Default width: 140 (density-independent) pixels.

Example:

```xml
<Field name="Device-Taborder-NontableParam" options="detailTabs:1700-SeverityColumn:50-ListKPIHide,1800;ShowCPEChilds;details:1700-KPI|1800|14-KPI,14;displayInFilter; tabs:1700-KPI|1800|14,14;TabOrder:2,1,0" pid="1704"/>
```

### ShowBubbleupAndInstanceAlarmLevel

On an EPM (formerly known as CPE) interface, apart from displaying the alarm state of the object (e.g. a CMTS) or the alarm state of all the objects below (e.g. all the amplifiers connected to a CMTS), it is possible to have two alarm indications on every object:

- The alarm state of the object
- The alarm state of all the objects below

If you want the user to see the alarm state of the object as well as the alarm states of all the object below, then create severity bubble-up tags that indicate the path and use the chain field option ShowBubbleupAndInstanceAlarmLevel.

See the following example:

```xml
<Chains filters="vertical">
    <Chain name="Overview">
        <Field name="Transportstreams" options="details:100-KPI;showTree;ShowCPEChilds; displayInFilter;ShowBubbleupAndInstanceAlarmLevel" pid="102"/>
        <Field name="Services" options="details:200-KPI;showTree;ShowCPEChilds; displayInFilter; ShowBubbleupAndInstanceAlarmLevel" pid="202"/>
        <Field name="RemoteServices" options="details:300-KPI;showTree;ShowCPEChilds; displayInFilter;ShowBubbleupAndInstanceAlarmLevel" pid="302"/>
    </Chain>
</Chains>
```

> [!NOTE]
> If you combine the ShowBubbleupAndInstanceAlarmLevel and TileList options, then the list will appear as a series of blocks, and each of those blocks will show two alarm colors.

See also:

[Protocol.SeverityBubbleUp.Path](xref:Protocol.SeverityBubbleUp.Path)

*Feature introduced in DataMiner 8.0.2 (RN 5977).*

### ShowCPEChilds

Specify this option in an EPM (formerly known as CPE) element to ensure that child objects of the field in question are displayed.

### ShowSiblings

Use this option to not only build up the tree view up to the root starting from the selection, but to also show the sibling items at the same level as the selected item.

### showTree

(Service Overview Manager + EPM)

If a field does not have the displayInFilter option (see [displayInFilter](xref:Protocol.Chains.Chain.Field-options#displayinfilter), so that it is not displayed as a separate filter item, but you do want to make it possible to navigate further in the diagram by double-clicking the corresponding diagram item, specify this option.

### skipInDiagram

Configures a chain in an EPM (formerly known as CPE) protocol so that a level is skipped in the EPM diagram.

The level linked to this field will then not be displayed in the diagram, unless the currently selected object is actually of that level.

Example:

```xml
<Chains>
  ...
   <Chain name="Example Hide Room/Rack">
      <Field name="Location" options="MaxDiagramsOnRow:3;ShowCPEChilds;details:1000-KPI|1500;displayInFilter;tabs:1000-KPI|1500|1600" pid="1002">
         <DiagramTitleFormat>{rowDK} (temp:{pid:1004})</DiagramTitleFormat>
         <DiagramPids>1004,1006</DiagramPids>
      </Field>
      <Field name="Room" options="SkipInDiagram;DiagramSort:1506|DESC:1;ShowCPEChilds;details:1500-KPI|1600;displayInFilter;KPIsInDiagram:{rowDK}\nCode: {pid:1504},Temperature:{pid:1506}\nRoomAVGDeviceTemp:{pid:1506}" pid="1502">
         <DiagramTitleFormat>{rowDK} ({pid:1506}°C)</DiagramTitleFormat>
         <DiagramPids>1504,1506</DiagramPids>
         <DiagramSorting>1506|DESC</DiagramSorting>
      </Field>
      <Field name="Rack" options="SkipInDiagram;ShowCPEChilds;details:1600-KPI|1700|1900;detailTabs:1700-SeverityColumn-ListKPIHide;displayInFilter;tabs:1600-KPI|1700|1900;ShowBubbleupAndInstanceAlarmLevel" pid="1602"/>
      <Field name="Device-TileList" options="detailTabs:1700-KPI-SeverityColumn-ListKPIHide,1800;ShowCPEChilds;displayInFilter;tabs:1700-KPI|1800|14,14,1800;TabOrder:2,1,0;TileList;ShowBubbleupAndInstanceAlarmLevel;KPIsInDiagram:Online:\t{pid:1710}\nOffline:\t {pid:1714}" pid="1704"/>
   </Chain>
  ...
</Chains>
```

> [!NOTE]
> If you configure the filter of a field to not be displayed (i.e. you leave out the "displayInFilter" option), the "showTree" option is required, as otherwise the diagram would immediately stop at the level corresponding to this field. In that case, depending on whether the "skipInDiagram" option is specified, the diagram will either be shown as if the filter was displayed, or shown without this particular level.

*Feature introduced in DataMiner 9.6.4 (RN 20893).*

### statusTabs

Use this option to display a link to a pop-up window that displays a combination of lists.

For example:

```XML
statusTabs:CPEs-25800|25900|26000-STB|CM|eMTA-MAC|Status|SAP|Street|Nr|Node
```

The configuration consists of four sections, separated by dashes:

1. The title: the name of the link as displayed in DataMiner (e.g. “CPEs” in the example above).
1. Subtables: tables that contain the data to be displayed (e.g. “25800|25900|26000” in the example above).
1. Types: a type field (which will be displayed as an extra column) corresponding to the subtables. (e.g. in the example above: “STB|CM|eMTA”, where STB corresponds to table 25800, CM to table 25900 and eMTA to table 26000).
1. Column names (e.g. “MAC|Status|SAP|Street|Nr|Node” in the example above). The first X columns will be displayed (e.g. 6 columns in the example above, as 6 column names have been specified). Note that the tables must all have the same columns. Also, as the PK usually should not be displayed in the statusTabs, it is best to place it at the end of the view table.

### tabOrder

From DataMiner 8.0.6 (RN 5828) onwards, this option can be used to reorganize the tabs in an EPM (formerly known as CPE) chain.

The tab numbers refer to the original tab positions.

Example:

```xml
TabOrder:1,0,2
```

From DataMiner 9.5.6 (RN 16388) onwards, it is possible to define the order of the tabs by name instead of by tab index.

Special keywords are "VISIO" for all Visio tabs and "DIAGRAM" for all diagram tabs.

> [!NOTE]
> 
> - All tabs not defined in the TabOrder option are added as last tabs.
> - Tab names are case insensitive.

Example:

```xml
<Chain name="TileList">
   <Field name="Network" options="TabOrder:DIAGRAM,VISIO,DEVICES" pid="11902"/>
</Chain>
```

### tabs

Use this option to have one or more links displayed in the block and next to the filter corresponding to this field. Clicking a link will open a pop-up window with KPI information. Multiple tables can be specified. Separate multiple tables with commas in order to show them in different pop-up windows, or with pipe characters to show them in the same pop-up window.

For example, when the configuration below is specified, three links will be displayed. The first link will be displayed as “KPIs”, because “-KPI” is added after the first parameter ID, the other links will display the parameter name.

```xml
tabs:11400-KPI|11300|11200,11300,11200
```

> [!NOTE]
> Usually, the parameters specified in this option are table parameters. However, from DataMiner 8.0.6 (RN 5828) onwards, it is also possible to specify other types of parameters. Single parameter KPI links are supported from DataMiner 9.0.0 [CU9]/9.0.4 [CU1] onwards (RN 13782).

### TileList

Use this option to have the detailTabs in the EPM (formerly known as CPE) interface appear as a series of blocks instead of as a table with rows.

If a child field has the TileList option and one of the parent (upper) fields has the detailtabs option with the same table pid as was used for the child field, it will be displayed as a tile list in the parent detailtab

See the following example:

```xml
<Chains filters="vertical">
  <Chain name="Geo">
     <Field name="Region" options="showTree;TileList;ShowCPEChilds;displayInFilter; tabs:10000-KPI;detailTabs:10200,10400" pid="10002" xmlns="http://www.skyline.be/protocol"/>
     <Field name="County" options="showTree;TileList;ShowCPEChilds;displayInFilter; tabs:10200-KPI;detailTabs:10400" pid="10202" xmlns="http://www.skyline.be/protocol"/>
     <Field name="Town" options="showTree;TileList;ShowCPEChilds;displayInFilter; tabs:10400-KPI" pid="10402" xmlns="http://www.skyline.be/protocol"/>
  </Chain>
</Chains>

> [!NOTE]
> If you combine the ShowBubbleupAndInstanceAlarmLevel and TileList options, the list will appear as a series of blocks, and each of those blocks will show two alarm colors. See [ShowBubbleupAndInstanceAlarmLevel](xref:Protocol.Chains.Chain.Field-options#showbubbleupandinstancealarmlevel).

*Feature introduced in DataMiner 8.0.2 (RN 5977).*

### TopologyChains

With this option, you can specify different tab pages with EPM (formerly known as CPE) diagrams that can represent a combination of existing chains. This is typically used in a quick entry field, where you for example combine Broadcast with VoD.

For example:

```xml
TopologyChains:LogicalView-Broadcast branch,Int/tel branch,VoD branch
```

The configuration of the field consists of two sections, separated by a dash:

1. The name of the tab, e.g. “LogicalView” in the example above.
1. A list of the existing chains that will be combined, separated by commas. For example, “Broadcast branch,Int/tel branch,VoD branch” in the example above.

More tab pages can be specified, separated with colons (“:”), for example:

```xml
TopologyChains:LogicalView-Logical:PhysicalView-Physical:CombinedView-Logical,Physical
```

![alt text](~/develop/schemadoc/Protocol/images/TopologyChains.png "TopologyChains")
