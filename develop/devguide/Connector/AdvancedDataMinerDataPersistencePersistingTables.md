---
metadata_version: 1
uid: AdvancedDataMinerDataPersistencePersistingTables
description: "Describe the DataMiner connector development topic Persisting tables, including its purpose, behavior, implementation guidance, and relevant constraints."
keywords: "volatile"
---

# Persisting tables

In order for a table column to persist in the database, one of the following must apply:

- The column is referred to by the [index](xref:Protocol.Params.Param.ArrayOptions-index) attribute of the [ArrayOptions](xref:Protocol.Params.Param.ArrayOptions) tag.
- The column is referred to by the [displayColumn](xref:Protocol.Params.Param.ArrayOptions-displayColumn) attribute of the [ArrayOptions](xref:Protocol.Params.Param.ArrayOptions) tag.
- Columns that are referred to by the [naming](xref:Protocol.Params.Param.ArrayOptions-options#naming) option or in the [NamingFormat](xref:Protocol.Params.Param.ArrayOptions.NamingFormat) tag are saved automatically (except for volatile tables).<!-- RN 16743 -->
- The options attribute of the ColumnOption tag for the column includes the [foreignKey](xref:ColumnOptionOptionsOverview#foreignkey) option.
- The options attribute of the ColumnOption tag for the column includes the [element](xref:ColumnOptionOptionsOverview#element) option.
- The options attribute of the ColumnOption tag for the column includes the [hidden](xref:ColumnOptionOptionsOverview#hidden) option.
- The options attribute of the ColumnOption tag for the column includes the [save](xref:ColumnOptionOptionsOverview#save) option.
- The options attribute of the ColumnOption tag for the column includes the [view](xref:ColumnOptionOptionsOverview#view) option.

For example, the following table parameter defines some columns to be saved. Column 1001 will also be saved, as this is the column holding the primary keys (as indicated by the [index](xref:Protocol.Params.Param.ArrayOptions-index) attribute).

```xml
<Param id="1000" trending="false">
   <Name>Inputs</Name>
   <Description>Inputs</Description>
   <Type>array</Type>
   <ArrayOptions index="0">
      <NamingFormat><![CDATA[ ;1003;.;1005;. ]]></NamingFormat>
      <ColumnOption idx="0" pid="1001" type="retrieved" options="" />
      <ColumnOption idx="1" pid="1002" type="retrieved" options="" />
      <ColumnOption idx="2" pid="1003" type="retrieved" options=";save" />
      <ColumnOption idx="3" pid="1004" type="retrieved" options="" />
      <ColumnOption idx="4" pid="1005" type="retrieved" options=";save" />
      <ColumnOption idx="5" pid="1006" type="retrieved" options="" />
      <ColumnOption idx="6" pid="1007" type="retrieved" options=";save" />
   </ArrayOptions>
  ...
</Param>
```

> [!IMPORTANT]
> **Runtime limit:** From DataMiner 10.4.9/10.5.0 onwards<!--RN 39836-->, the maximum number of rows in a non-partial table is 105,000. Beyond this limit, you will be unable to add new rows. A warning will be displayed at 85,000 rows to notify you that you are approaching this limit. This is a row-count limit, not a throughput target.

## Volatile tables

In case you do not want anything to be kept in the database, you can use the [volatile](xref:Protocol.Params.Param.ArrayOptions-options#volatile) option.

```xml
<ArrayOptions index="0" displayColumn="1" options=";volatile;">
```

The *volatile* option can also be applied on a specific column in the [options](xref:Protocol.Params.Param.ArrayOptions.ColumnOption-options) attribute of the [ColumnOption](xref:Protocol.Params.Param.ArrayOptions.ColumnOption) tag (except for columns using the element option or referred to by the [displayColumn](xref:Protocol.Params.Param.ArrayOptions-displayColumn) attribute).

You should only use this option in the following cases:

- The table is not used for DCF interface.
- The table is not used for DVEs.
- The [save](xref:ColumnOptionOptionsOverview#save) option is not enabled.
- No [foreign keys](xref:ColumnOptionOptionsOverview#foreignkey) are used in the table.
- Alarm monitoring is not enabled on the table.

In general, make sure to only use it on tables that are only displayed in the UI or used in a QAction, but are not used in any other way.

> [!NOTE]
>
> - **Recommendation:** If alarm monitoring is needed even though the data is very volatile, keep row additions and deletions to at most 7 changes per minute and 10,000 changes per day on the same element. Higher rates can severely affect database read efficiency, so use the *volatile* option. These are performance guidelines, not validator thresholds.
> - **Runtime limit:** From DataMiner 10.4.9/10.5.0 onwards<!--RN 39836-->, the maximum number of rows in a volatile table is 1,005,000. Beyond this limit, you will be unable to add new rows. A warning will be displayed at 805,000 rows to notify you that you are approaching this limit.
