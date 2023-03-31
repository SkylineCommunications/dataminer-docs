---
uid: UIComponentsTableDisplayKeys
---

# Display keys

Tables always contain a primary key column (which must contain unique values), making it possible to uniquely identify a row by using values from this column. By default, when an alarm occurs related to a row in a table, the primary key will be used in the alarm to identify the row. However, it is possible that the primary key is not very user-friendly.

If this is the case, another column (or a combination of columns) can be selected to act as a so-called display key. A display key is a user-friendly alternative to a primary key. Alarm templates and trend templates will then use the display key instead of the primary key to refer to a row in the Alarm Console or trend data in trend graphs.

Please keep the following guidelines in mind for display keys:

- In case the primary key can be used to let users identify a row, there is no need to define a display key (as by default the primary key is used). Only define a display key if there is a need to identify rows in another (more user-friendly) way.
- Just like the primary key, the display key must be unique for every row in a table.
- A display key must not have leading or trailing whitespace.
- Semicolons (";"), question marks ("?") and asterisks ("*") must be avoided in display keys as these characters have a special meaning in the dynamic table filter syntax and could therefore cause table filter queries to be interpreted incorrectly. (Refer to the [Dynamic Table Filter Syntax](xref:Dynamic_table_filter_syntax).)

> [!NOTE]
> From DataMiner 9.5.5 (RN 16743) onwards, all parameters used to create the display key will be saved by default (except for volatile tables).

More information on how a display key can be defined can be found in the following subsections:

- [Naming](xref:UIComponentsTableDisplayKeys#naming)
- [NamingFormat](xref:UIComponentsTableDisplayKeys#namingformat)
- [displayColumn attribute](xref:UIComponentsTableDisplayKeys#displaycolumn-attribute)

Only one approach should be used at a time and new protocols should avoid using the displayColumn attribute because it performs less well and displayColumn is not supported by Cassandra.

> [!NOTE]
> Based on the way the display key is defined, there is also an important difference in the way trend data is stored in the trend data database table. In case the displayColumn attribute is used, the display key is used in the trend data table. In case either the “naming” option or NamingFormat is used, the primary key is used in the trend data table. Therefore, it is not allowed to change existing protocols to start using naming instead of the displayColumn attribute (unless the TAM instructs to do so, as this results in a major protocol change), as this would result in the trend history becoming unavailable (even though it is still present in the database).

Since DataMiner version 8.0.5, it is possible to define a column of type "displaykey" which shows the display key.

```xml
<ColumnOption idx="1" pid="1502" type="displaykey" value="" options=""/>
```

It is not allowed to set values to this column. The column will automatically be filled in by the SLElement process. This column also does not support alarming or trending. When a column of type "displaykey" is used in a table, it must be defined as the last column of that table.

## NamingFormat

Another way to define a display key using naming is by using the NamingFormat tag:

```xml
<Param id="2000" trending="false">
  <Name>Transport Streams</Name>
  <Description>Transport Streams</Description>
  <Type>array</Type>
  <ArrayOptions index="0">
     <NamingFormat><![CDATA[;Input;1005;TS;2004]]></NamingFormat>
     <ColumnOption idx="0" pid="2001" type="retrieved" options="" />
        <ColumnOption idx="1" pid="2002" type="retrieved" options=";save;foreignKey=1000" />
        <ColumnOption idx="2" pid="2003" type="retrieved" options=";save" />
        <ColumnOption idx="3" pid="2004" type="retrieved" options=";save" />
        ...
        <ColumnOption idx="71" pid="2899" type="displaykey" options="" />
  </ArrayOptions>
```

The first character defines the separator and can be freely chosen. It will be replaced by an empty string when the display key is formed. The use of the CDATA block allows the use of characters like “<”, “>” and “&” that are otherwise encoded in XML.

In the example above, the semicolon separates the static text from the dynamic parameter values. A display key for this table will look as follows: "Input 2 TS 3".

## Naming

Naming can be used to define a display key for a table. The example below defines a display key using a combination of parameters from three different tables (table 1000, 2000 and 3000).

```xml
<Param id="3000" trending="false">
  <Name>PIDs</Name>
  <Description>PIDs</Description>
  <Type>array</Type>
  <ArrayOptions index="0">
     <ArrayOptions index="0" options=";naming=/1002,2004,3002" >
        <ColumnOption idx="0" pid="3001" type="retrieved" options="" />
        <ColumnOption idx="1" pid="3002" type="retrieved" options="" />
```

The naming option defines the separator ("/"), followed by a comma-separated list of column parameter IDs, which together make up a unique label for a row.

> [!NOTE]
> - In case you want to use values from columns in other tables, make sure the necessary table links exist.
> - All values used to compose the naming result must be filled in before the parameter value that will trigger the alarm. See Column processing order in tables (fix in DataMiner version 7.5).

See also:

- [Foreign keys](xref:UIComponentsTableForeignKeys)
- [Relations](xref:UIComponentsTableRelations)
- [Protocol.Params.Param.ArrayOptions@options: naming](xref:Protocol.Params.Param.ArrayOptions-options#naming)

## displayColumn attribute

Using the displayColumn attribute, you can specify that values of a particular column will serve as the display key.

```xml
<ArrayOptions index="0" displayColumn="2">
```

> [!NOTE]
> - The column referred to in the displayColumn attribute must never be the column holding the primary key, as this would result in the creation of an unnecessary mapping between primary key and display key.
> - For performance reasons, using either the "naming" option or NamingFormat tag is favored over using the displayColumn attribute for new protocols.

## See also

- [Protocol.Params.Param.ArrayOptions.NamingFormat](xref:Protocol.Params.Param.ArrayOptions.NamingFormat)
- [ArrayOptions@options: naming option](xref:Protocol.Params.Param.ArrayOptions-options#naming)
- [Protocol.Params.Param.ArrayOptions@displayColumn](xref:Protocol.Params.Param.ArrayOptions-displayColumn)
