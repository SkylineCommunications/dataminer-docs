---
uid: Protocol.Params.Param.ArrayOptions-options
---

# options attribute

Specifies a number of options, separated by semicolons (';').

## Content Type

string

## Parent

[ArrayOptions](xref:Protocol.Params.Param.ArrayOptions)

## Remarks

### autoAdd

If you specify this option in the ArrayOptions tag of a table parameter, when you perform a SetRow or a SetParameterIndex operation within a QAction and the row does not exist, it will automatically be added.

Example:

```xml
<Param id="101" trending="false">
  ...
  <Type>array</Type>
  <ArrayOptions index="0" options=";autoAdd">
  ...
</Param>
```

### customDatabaseName

To be used in combination with the [database](xref:Protocol.Params.Param.ArrayOptions-options#database) option.

By default, the name of the logger table in the database will be `elementdata_[AgentId]_[ElementId]_[TableParameterId]` (e.g. "elementdata_346_353_1000") and this table will be created in the default local DataMiner schema. When the `customDatabaseName` option is used, the table is created in a separate table schema (where the name of the schema is the name specified in the option) and the name of the table within this schema is the name of your table.

Example:

```xml
<ArrayOptions ... options=";database;customDatabaseName=myName">
```

See also: [Logger tables](xref:AdvancedLoggerTables).

### database

This option should only be used for logger tables.

If you use this option, not all data will be kept in memory. It will instead be stored in the general database and loaded when needed.

By default, 500 rows will be kept in memory. If you want to override this default setting, specify a number of rows in the option. See the following example:

```xml
options=";database:1000"
```

The column parameters are used to create the table. Whitespace characters will be replaced by underscores. So be sure that the parameter name does not contain illegal SQL syntax. For example, “Asset (Log)” will cause errors.

> [!NOTE]
>
> - When the table contains datetime fields, they must always have a valid value and can never be empty or null.
> - If you set this database option for a particular logger table, then remember that it will not be possible to retrieve data from the table or to set data in the table using getparameterbyindex or a setter parameter.
> - In existing elements, the structure of a logger table cannot be changed. For example, in an existing element, you cannot add columns to a logger table.

See also: [Logger tables](xref:AdvancedLoggerTables).

### databaseName

To be used in combination with the [database](xref:Protocol.Params.Param.ArrayOptions-options#database) option.

By default, the name of the logger table in the database will be `elementdata_[AgentId]_[ElementId]_[TableParameterId]` (e.g. "elementdata_346_353_1000"). This table will be created in the default local DataMiner schema. When the `databaseName` option is used, the table is created in a separate table schema (where the name of the schema is the name of the element) and the name of the table within the schema is the name of the table.

Example:

```xml
<ArrayOptions ... options=";database;databaseName">
```

See also: [Logger tables](xref:AdvancedLoggerTables).

### databaseNameProtocol

To be used in combination with the [database](xref:Protocol.Params.Param.ArrayOptions-options#database) option.

By default, the name of the logger table in the database will be `elementdata_[AgentId]_[ElementId]_[TableParameterId]` (e.g. "elementdata_346_353_1000") and this table will be created in the default local DataMiner schema. When the `databaseNameProtocol` option is used, the table is created in a separate table schema (where the name of the schema is the name of the protocol) and the name of the table within this schema is the name of the table.

Example:

```xml
<ArrayOptions ... options=";database;databaseNameProtocol">
```

See also: [Logger tables](xref:AdvancedLoggerTables).

### directView

Use this option to create a view table with data from other elements.

Set *directView* to the parameter ID of the column containing the element ID.

Example:

```xml
options=";view=1000;directView=2802"
```

See also: [view](xref:Protocol.Params.Param.ArrayOptions-options#view)

### discreetDestination

If you use this option, followed by the name of an XML file, all changes made to primary keys and display keys will be stored in the specified XML file for use elsewhere.

Example:

```xml
<ArrayOptions options=";discreetDestination=ports.xml">
```

### interruptTrend

If you use this option, trending will not follow the changed display key.

If you do not use the *interruptTrend* option, when the display key changes, all trending values for the old display key will be transferred to trending values for the new display key.

### naming

This option replaces the display column. Via this option it is possible to define multiple columns that will result in the display key. It is also possible to use a column of a linked table.

The first character is the separator.

> [!NOTE]
> This option cannot be used together with [displayColumn](xref:Protocol.Params.Param.ArrayOptions-displayColumn).

Example:

```xml
options=";naming=/101,202"
```

It is possible to fully customize the format of the display key. See [NamingFormat](xref:Protocol.Params.Param.ArrayOptions.NamingFormat)

See also: [Display keys](xref:UIComponentsTableDisplayKeys)

### onlyFilteredDirectView

When this option is used, data from this direct view can only be retrieved through the use of filters (EPM). The full table cannot be requested/subscribed to.

Example:

```xml
options=";view=1000;directView=2802;onlyFilteredDirectView"
```

### preserve state

If you use this option, you will be able to retrieve the previous value of the changed cell (in a QAction). Be careful when you use this option, as it requires more processing power.

### propertyTable

See [Custom element properties](xref:AdvancedCustomPropertiesCustomElementProperties)

### processingOrder

Use this option to force the SLElement process to use a particular processing order when a table update is received.

By default, the order is as follows:

1. Primary key
1. Display key
1. Foreign key(s)
1. Local naming parameter ID(s)
1. Property parameter ID(s) used as a source for alarm properties
1. Other parameter ID(s)
1. Parameter ID(s) to which conditions have been applied

*Feature introduced in DataMiner 7.5.6 (RN 5431) and updated in DataMiner 9.0.0.0 (RN 11582).*

Example:

```xml
<ArrayOptions index="0" options=";naming=/1002;processingOrder=0,1,2,3,4,6,7,10,12,14,15,16,19,20,21,22,27,29,31,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,5,8,9,11,13,17,18,23,24,25,26,28,30,32,33,34">
```

See also: [Column processing order in tables](xref:InnerWorkingsSLElement#column-processing-order-in-tables)

### queryTablePID=

Specifies the ID of the table parameter to query for more information in an EPM (formerly known as CPE) environment.

*Feature introduced in DataMiner 9.6.2 (RN19897).*

Example:

```xml
<ArrayOptions options=";queryTablePID=1500" />
```

### sizeHint

For large volatile tables, the sizeHint option (available from DataMiner version 9.0 onwards) can be specified with the expected number of rows, allowing the SLElement process to perform some optimizations.

> [!NOTE]
> This option should not be used on non-volatile tables.

Example:

```xml
<ArrayOptions index="0" partial="true:2000" options=";volatile;autoAdd;sizeHint=200000">
```

### view

Use this option to have the table display the values from another table (of which the ID has to be specified).

It is possible to add values from tables linked to this root table.

Example:

```xml
options=";view=1000"
```

From Dataminer 8.0.7 (RN 6914) onwards, direct view tables can have a different element or protocol as their source.

This allows you, for example, to show collector info in an EPM (formerly known as CPE) element that is not aware of all possible values (e.g. frequency info in a collector).

To configure it:

1. Create a directView table. In other words, link to a column (parameter ID) that defines the remote elements.

   Example: `options="...directView=201;..."`

1. Specify the table that has to be retrieved, and indicate that the parameter ID of the remote table has to be taken.

   Example: `options="...view=40000,remoteId;..."`

1. Define a mapping between the local parameter IDs and the remote parameter IDs. Each pair should contain a local ID and a remote ID, separated by a hyphen, and the pairs should be separated by commas.

   Example: `options="...filterChange=701-40001,702-40002,703-40003"`

Example

```xml
<Param id="11600">
  <Name>CPE Frequencies</Name>
  <Description>CPE Frequencies</Description>
  <Type>array</Type>
  <ArrayOptions index="0" partial=";true:1000" options=";volatile;view=90000,remoteId;
directView=3301;onlyFilteredDirectView;filterChange=11601-9001,11602-9002,11603-9003,11604-9004">
     <ColumnOption idx="0" pid="11601" type="retrieved" options=";"/>
     <ColumnOption idx="1" pid="11602" type="retrieved" options=";"/>
     <ColumnOption idx="2" pid="11603" type="retrieved" Options=";"/>
     <ColumnOption idx="3" pid="11604" type="retrieved" Options=";"/>
   </ArrayOptions>
   ...
```

### volatile

If you use this option, the primary keys will not be saved.

> [!CAUTION]
> Be careful about where you use this option, as it cannot be used on every table. For information on the limitations, see [Volatile tables](xref:AdvancedDataMinerDataPersistencePersistingTables#volatile-tables).
