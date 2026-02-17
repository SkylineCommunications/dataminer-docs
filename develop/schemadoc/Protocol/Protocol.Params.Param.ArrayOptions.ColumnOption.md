---
uid: Protocol.Params.Param.ArrayOptions.ColumnOption
---

# ColumnOption element

Allows you to define a table column.

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[cpeAlignment](xref:Protocol.Params.Param.ArrayOptions.ColumnOption-cpeAlignment)|[EnumCpeAlignment](xref:Protocol-EnumCpeAlignment)||Sets the alignment of KPI values in a CPE interface.|
|[idx](xref:Protocol.Params.Param.ArrayOptions.ColumnOption-idx)|unsignedInt|Yes|Defines the (0-based) position of the column in the table.|
|[options](xref:Protocol.Params.Param.ArrayOptions.ColumnOption-options)|string||Defines different options.|
|[pid](xref:Protocol.Params.Param.ArrayOptions.ColumnOption-pid)|[TypeParamId](xref:Protocol-TypeParamId)|Yes|Specifies the parameter ID of the column data.|
|[pollingRate](xref:Protocol.Params.Param.ArrayOptions.ColumnOption-pollingRate)|unsignedInt||Specifies the polling rate of this column (in ms).|
|[type](xref:Protocol.Params.Param.ArrayOptions.ColumnOption-type)|[EnumColumnOptionType](xref:Protocol-EnumColumnOptionType)|Yes|Specifies column type options.|
|[value](xref:Protocol.Params.Param.ArrayOptions.ColumnOption-value)|string||The interpretation of this value attribute depends on the value of the type attribute.|

## Parent

[ArrayOptions](xref:Protocol.Params.Param.ArrayOptions)

## Remarks

Each table column is defined by one or two parameters:

- one for read, and/or
- one for write

### Requesting index values from index columns

In a QAction, you can use the SLProtocol.GetKeysForIndex method to retrieve the primary keys of the rows that have the specified value for the specified column that has been marked as an indexColumn or a foreignKey. See [indexColumn](xref:ColumnOptionOptionsOverview#indexcolumn).

> [!CAUTION]
> Using this option affects memory usage!
>
> When this option is used, the SLProtocol process will maintain an index for this column. The SLProtocol process will update the index for every update to the column data (e.g., through a FillArray, AddRow, etc. call). It is therefore strongly advised to **only use this option for columns that do not change frequently**.

See also:

- [SLProtocol.GetKeysForIndex](xref:Skyline.DataMiner.Scripting.SLProtocol.GetKeysForIndex(System.Int32,System.String)) method
- [NT_GET_KEYS_FOR_INDEX (196)](xref:NT_GET_KEYS_FOR_INDEX)
- [NT_GET_KEYS_FOR_INDEX_CASED (411)](xref:NT_GET_KEYS_FOR_INDEX_CASED)

In case the column data will get updated frequently and you do not need to obtain the primary keys for a specific value often, an alternative is to not use the indexColumn. Instead you can retrieve the primary key column and the data column in a QAction and perform the filtering. This can be done using the *GetKeysForValue* snippet:

```xml
/// <summary>
/// Gets the key (or another column) of the rows which have a specified value in a specified column.
/// </summary>
/// <param name="protocol">Link with SLProtocol process.</param>
/// <param name="tablePid">Parameter ID of the table.</param>
/// <param name="returnedColumnIdx">IDX of the column to be returned.</param>
/// <param name="filterColumnIdx">IDX of the column to be used to check if the row contains the specified value.</param>
/// <param name="filterValue">Value to be used to check if the rows should be returned.</param>
/// <returns>The values of the column specified in <paramref name="returnedColumnIdx"/> for the rows that matches.</returns>
public static IEnumerable<string> GetKeysForValue(this SLProtocol protocol, int tablePid, uint returnedColumnIdx, uint filterColumnIdx, string filterValue)
{
   object[] getColumns = (object[])protocol.NotifyProtocol((int)SLNetMessages.NotifyType.NT_GET_TABLE_COLUMNS, tablePid, new uint[] { returnedColumnIdx, filterColumnIdx });

  if (getColumns != null && getColumns.Length > 1)
  {
      object[] getKeys = (object[])getColumns[0];
      object[] getValues = (object[])getColumns[1];

     if (getKeys != null && getValues != null)
     {
         int rowCount = getKeys.Length;

        if (rowCount == getValues.Length)
        {
           for (int i = 0; i < rowCount; i++)
           {
               string getValue = Convert.ToString(getValues[i], CultureInfo.InvariantCulture);
 
              if (getValue.Equals(filterValue))
              {
                  yield return Convert.ToString(getKeys[i]);
              }
           }
        }
     }
  }
}
```

### Associating icons with table column values

When defining the table columns, add the displayIcon option to the columns that have to display icons instead of values.

Example:

```xml
<ArrayOptions index="0" displayColumn="1">
  ...
  <ColumnOption idx="5" pid="120" type="custom" value="" options=";save;displayIcon"/>
  ...
```

When defining a discreet parameter of which the values have to be displayed as icons, make sure that every value of that parameter is associated with a particular icon.

Example:

```xml
<Param id="120" trending="false">
  ...
  <Measurement>
     <Type>discreet</Type>
     <Discreets>
        ...
        <Discreet iconRef="InputTransportStream">
           <Display>Input TS</Display>
           <Value>Input TS</Value>
        </Discreet>
        ...
     </Discreets>
  </Measurement>
</Param>
```

> [!NOTE]
> All icon references mentioned in a protocol have to refer to icons listed in the icons.xml file, located in the C:\Skyline DataMiner\Protocols folder.

### Visualization of view alarm states

In a protocol, you can configure that a table column has to indicate the alarm state of the view that is referred to by a particular row.

When defining the table columns, add the displayViewAlarm option to the column that has to indicate the alarm state of the view.

Example:

```xml
<ArrayOptions index="0" displayColumn="1">
  ...
  <ColumnOption idx="5" pid="120" type="custom" value="" options=";save;displayViewAlarm"/>
```

Result: If the value in the displayViewAlarm column is a valid view ID, then that ID will be replaced by a view icon showing the view’s current alarm color. If the value is not a valid view ID, then the cell will be empty.
