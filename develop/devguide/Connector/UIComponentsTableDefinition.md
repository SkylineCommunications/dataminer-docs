---
uid: UIComponentsTableDefinition
---

# Defining a table

![DataMiner Cube table](../../images/uiX_-_table.png "DataMiner Cube table")

To define a table, create a parameter of type "array" that represents the table.

Example:

```xml
<Param id="1000" trending="false">
  <Name>Table</Name>
  <Description>Table Description</Description>
  <Type>array</Type>
  <ArrayOptions index="0">
    <ColumnOption idx="0" pid="1001" type="retrieved" options=""/>
    <ColumnOption idx="1" pid="1002" type="retrieved" options=""/>
    <ColumnOption idx="2" pid="1003" type="retrieved" options=""/>
  </ArrayOptions>
  <Display>
    <RTDisplay>true</RTDisplay>
  </Display>
</Param>
```

The ArrayOptions tag contains all the columns (through ColumnOption child tags) that refer to other parameters (via the pid attribute).

> [!NOTE]
> The column containing the primary keys must be of Interprete/Type "string". Refer to [Primary keys](xref:UIComponentsTablePrimaryKeys).

For each table column, an additional parameter is defined.

```xml
<Param id="1001" trending="false">
  <Name>Column1</Name>
  <Description>Column 1 Description</Description>
  <Type>read</Type>
  <Interprete>
    <RawType>other</RawType>
    <Type>string</Type>
    <LengthType>next param</LengthType>
  </Interprete>
  <Display>
    <RTDisplay>true</RTDisplay>
  </Display>
  <Measurement>
    <Type>string</Type>
  </Measurement>
</Param>
<Param id="1002" trending="false">
  <Name>Column2</Name>
  <Description>Column 2 Description</Description>
  <Type>read</Type>
  <Interprete>
    <RawType>numeric text</RawType>
    <Type>double</Type>
    <LengthType>next param</LengthType>
  </Interprete>
  <Display>
    <RTDisplay>true</RTDisplay>
  </Display>
  <Measurement>
    <Type>number</Type>
  </Measurement>
</Param>
<Param id="1003" trending="false">
  <Name>Column3</Name>
  <Description>Column 3 Description</Description>
  <Type>write</Type>
  <Interprete>
    <RawType>numeric text</RawType>
    <Type>double</Type>
    <LengthType>next param</LengthType>
  </Interprete>
  <Display>
    <RTDisplay>true</RTDisplay>
  </Display>
  <Measurement>
    <Type width="110">button</Type>
    <Discreets>
      <Discreet>
        <Display>Button Name</Display>
        <Value>1</Value>
      </Discreet>
    </Discreets>
  </Measurement>
</Param>
```

> [!NOTE]
> Tables can also be used to hold data while the table should not be displayed on a page and should also not be available in the SLElement process. In case of such internal tables, it is important to set RTDisplay of the table parameter and the column parameters to "false" in order to avoid the table being loaded in the SLElement process.

The table parameter has an ArrayOptions tag that refers to the column parameters and defines the order of the columns (through the idx attribute).

> [!NOTE]
> The idx attribute defines the order in which the columns are stored. The order in which the columns are displayed can be different (this is defined in the options attribute of the Type tag in the Measurements tag).

```xml
  <Measurement>
    <Type options="tab=columns:1003|2-1001|0-1002|1">table</Type>
  </Measurement>
```

> [!TIP]
> See also: [Protocol.Params.Param.Measurement.Type@options: Options for measurement type “table”](xref:Protocol.Params.Param.Measurement.Type-options#options-for-measurement-type-table)

In order to create a writable column, create an additional parameter of type "write".

```xml
<Param id="1102" setter="true">
  <Name>Column2</Name>
  <Description>Column 2 Description</Description>
  <Type>write</Type>
  <Display>
    <RTDisplay>true</RTDisplay>
  </Display>
</Param>
```

> [!NOTE]
>
> - Typically, a fixed offset is used between the parameter IDs of write parameters and the corresponding read parameters (e.g. 100 in the example above).
> - For more information about executing a QAction on a row change of a table, see Executing a QAction on a row change.
