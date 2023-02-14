---
uid: AdvancedDataMinerDataPersistencePersistingTables
---

# Persisting tables

In order for a table column to persist in the database, one of the following must apply:

- The column is referred to by the index attribute of the ArrayOptions tag. See index @.
- The column is referred to by the displayColumn attribute of the ArrayOptions tag. See displayColumn.
- From DataMiner 9.0.0 \[CU19\]/9.5.0 \[CU2\] onwards (RN 16743), columns that are referred to by the naming option or in the NamingFormat tag are saved automatically (except for volatile tables). See naming and Protocol.Params.Param.ArrayOptions.NamingFormat.
- The options attribute of the ColumnOption tag for the column includes the foreignKey option. See foreignKey.
- The options attribute of the ColumnOption tag for the column includes the element option. See element.
- The options attribute of the ColumnOption tag for the column includes the hidden option. See hidden.
- The options attribute of the ColumnOption tag for the column includes the save option. See save.
- The options attribute of the ColumnOption tag for the column includes the view option. See view.

For example, the following table parameter defines some columns to be saved. Column 1001 will also be saved, as this is the column holding the primary keys (as indicated by the index attribute).

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
- Trending is not enabled on the table.
- Alarm monitoring is not enabled on the table.

In general, make sure to only use it on tables that are only displayed in the UI or used in a QAction, but are not used in any other way.

> [!NOTE]
> If alarm monitoring is needed even though the data is very volatile, check whether the number of rows added and deleted will remain low enough so that there are at most 7 changes per minute on the same element and at most 10 000 changes per day on the same element. If the number will be higher, this can have a severe impact on the read efficiency of the database, so the *volatile* option must be used. If the number will be low enough, you can remove the *volatile* option for the relevant alarm monitoring, but make sure that you do not add the *save* option to other columns.
