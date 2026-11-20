---
uid: UIComponentsTableDisplayKeys
description: "Define unique, user-friendly display keys for table rows with naming or NamingFormat, and understand their effects on alarms, filters, and trend data."
---

# Display keys

Tables always contain a primary key column (which must contain unique values), making it possible to uniquely identify a row by using values from this column. By default, when an alarm occurs related to a row in a table, the primary key will be used in the alarm to identify the row. However, it is possible that the primary key is not very user-friendly.

If this is the case, another column (or a combination of columns) can be selected to act as a so-called display key. A display key is a user-friendly alternative to a primary key. Alarm templates and trend templates will then use the display key instead of the primary key to refer to a row in the Alarm Console or trend data in trend graphs.

Please keep the following guidelines in mind for display keys:

- In case the primary key can be used to let users identify a row, there is no need to define a display key (as by default the primary key is used). Only define a display key if there is a need to identify rows in another (more user-friendly) way.
- Just like the primary key, the display key must be unique for every row in a table.
- A display key must not have leading or trailing whitespace.
- Semicolons (`;`), question marks (`?`) and asterisks (`*`) must be avoided in display keys as these characters have a special meaning in the dynamic table filter syntax and could therefore cause table filter queries to be interpreted incorrectly. (Refer to the [Dynamic Table Filter Syntax](xref:Dynamic_table_filter_syntax).)

> [!NOTE]
> All parameters used to create the display key will be saved by default (except for volatile tables).<!-- RN 16743 -->

More information on how a display key can be defined can be found in the following subsections:

- [Naming](xref:UIComponentsTableDisplayKeys#naming)
- [NamingFormat](xref:UIComponentsTableDisplayKeys#namingformat)
- [displayColumn attribute](xref:UIComponentsTableDisplayKeys#displaycolumn-attribute)

Only one approach should be used at a time and new protocols should avoid using the [displayColumn](xref:Protocol.Params.Param.ArrayOptions-displayColumn) attribute because it performs less well and displayColumn is not supported by Cassandra.

> [!NOTE]
> Based on the way the display key is defined, there is also an important difference in the way trend data is stored in the trend data database table. In case the displayColumn attribute is used, the display key is used in the trend data table. In case either the "naming" option or NamingFormat is used, the primary key is used in the trend data table. Therefore, it is not allowed to change existing protocols to start using naming instead of the displayColumn attribute (unless the TAM instructs to do so, as this results in a major protocol change), as this would result in the trend history becoming unavailable (even though it is still present in the database).

It is possible to define a column of type "displaykey", which shows the display key:

```xml
<ColumnOption idx="1" pid="1502" type="displaykey" options=""/>
```

It is not allowed to set values to this column. The column will automatically be filled in by the SLElement process. This column also does not support alarming or trending. When a column of type "displaykey" is used in a table, it must be defined as the last column of that table.

## NamingFormat

Another way to define a display key using naming is by using the *NamingFormat* tag:

```xml
<Param id="2000">
  <Name>TransportStreams</Name>
  <Description>Transport Streams</Description>
  <Type>array</Type>
  <ArrayOptions index="0">
    <NamingFormat><![CDATA[;Input;1005;TS;2004]]></NamingFormat>
    <ColumnOption idx="0" pid="2001" type="retrieved" options="" />
    <ColumnOption idx="1" pid="2002" type="retrieved" options=";save;foreignKey=1000" />
    <ColumnOption idx="2" pid="2003" type="retrieved" options=";save" />
    <ColumnOption idx="3" pid="2004" type="retrieved" options=";save" />
    ...
    <ColumnOption idx="71" pid="1999" type="displaykey" options="" />
  </ArrayOptions>
</Param>
```

The first character defines the separator and can be freely chosen. `SLElement` evaluates `NamingFormat` token by token using this separator: numeric tokens that match a column parameter ID in the table (or in a parent table linked via a [foreign key](xref:UIComponentsTableForeignKeys) and [relation](xref:UIComponentsTableRelations), such as parameter `1005` from table `1000` in the example above) are replaced by that cell's display value, while all other tokens are rendered verbatim as static text. Using a CDATA block allows you to include characters such as `<`, `>`, and `&`, which would otherwise need to be XML-encoded.

In the example above, the semicolon separates the static text from the dynamic parameter values. A display key for this table will look as follows: "Input2TS3".

Keep the following runtime behavior in mind when you design a `NamingFormat` definition:

- **Static text tokens are rendered unconditionally**: Static text tokens (such as `:`, ` / `, or `Input`) are never omitted when adjacent local or foreign-key columns are empty or uninitialized. For example, in `<NamingFormat>,15601,:,15620, / ,15653,:,10002</NamingFormat>`, if columns `15653` and `10002` are empty on a row, the display key will end with the literal string `" / :"`.
- **Cross-table column references depend on foreign-key resolution**: When `NamingFormat` references a column parameter ID from a parent table linked via `foreignKey`, an empty, delayed, or unmatched foreign key causes the parent column to resolve to an empty string while surrounding static text tokens are still rendered. If a matching parent row is not guaranteed for every child row (for example, when the parent table only monitors a subset of items or is populated asynchronously), prefer referencing a populated local column in `NamingFormat` so that rows remain identifiable in the Alarm Console.
- **Use a `retrieved` column for optional or conditional segments**: Because `SLElement` automatically populates and recomputes columns of type `displaykey`, you must never write to a `displaykey` column from a QAction to construct conditional display keys. Instead, when a display key requires an optional or mutually exclusive segment, format that segment in a QAction (including its leading separator when present, such as `" / 10:Channel A"`, or an empty string `""` when not applicable), store it in a normal string column of type `retrieved`, and reference that column's parameter ID in `NamingFormat` without hardcoded surrounding literals.

> [!NOTE]
> When referencing a parameter ID, take care not to add spaces before or after the number. For example:
>
> - Correct: ";Input;1005;TS;2004"
> - Incorrect: ";Input; 1005;TS;2004 "

## Naming

Naming can be used to define a display key for a table. The example below defines a display key using a combination of parameters from three different tables (table 1000, 2000, and 3000).

```xml
<Param id="3000">
  <Name>PIDs</Name>
  <Description>PIDs</Description>
  <Type>array</Type>
  <ArrayOptions index="0" options=";naming=/1002,2004,3002" >
    <ColumnOption idx="0" pid="3001" type="retrieved" options="" />
    <ColumnOption idx="1" pid="3002" type="retrieved" options="" />
    <ColumnOption idx="2" pid="3003" type="retrieved" options=";foreignKey=1000" />
    <ColumnOption idx="3" pid="3004" type="retrieved" options=";foreignKey=2000" />
    ...
    <ColumnOption idx="71" pid="2999" type="displaykey" options="" />
  </ArrayOptions>
</Param>
```

The naming option defines the separator (`/`), followed by a comma-separated list of column parameter IDs, which together make up a unique label for a row.

> [!NOTE]
>
> - In case you want to use values from columns in other tables, make sure the necessary table links exist.
> - All values used to compose the naming result must be filled in before the parameter value that will trigger the alarm. See [Column processing order in tables](xref:InnerWorkingsSLElement#column-processing-order-in-tables).

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
>
> - The column referred to in the *displayColumn* attribute must never be the column holding the primary key, as this would result in the creation of an unnecessary mapping between primary key and display key.
> - For performance reasons, using either the "naming" option or *NamingFormat* tag is favored over using the *displayColumn* attribute for new protocols.

## CorrectedDisplayKeyOnNaming soft-launch option

By default, if one of the columns used to create the display key contains an exception value, this value is ignored, and the raw value is used in the display key instead. If the exception is defined on a discrete parameter, the value is dropped from the display key entirely.

You can alter this behavior by enabling the [CorrectedDisplayKeyOnNaming](xref:Overview_of_Soft_Launch_Options#correcteddisplaykeyonnaming) soft-launch option. This will cause display keys to be formatted with the exception display value instead. Because altering the display key could break existing fixed uses of display keys, this behavior is currently only available via the soft-launch option.

Note that empty display values for exceptions and discrete parameters will result in the raw parameter value being used in the display key in some cases.

## See also

- [Protocol.Params.Param.ArrayOptions.NamingFormat](xref:Protocol.Params.Param.ArrayOptions.NamingFormat)
- [ArrayOptions@options: naming option](xref:Protocol.Params.Param.ArrayOptions-options#naming)
- [Protocol.Params.Param.ArrayOptions@displayColumn](xref:Protocol.Params.Param.ArrayOptions-displayColumn)
