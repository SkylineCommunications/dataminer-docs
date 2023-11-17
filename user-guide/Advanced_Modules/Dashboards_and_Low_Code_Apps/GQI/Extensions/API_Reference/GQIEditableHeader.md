---
uid: GQI_GQIEditableHeader
---

# GQIEditableHeader Class

## Definition

Namespace: `Skyline.DataMiner.Analytics.GenericInterface`  
Assembly: `SLAnalyticsTypes.dll`

Represents the header, containing columns, that the custom operator can manipulate.

## Methods

### void AddColumns(params GQIColumn[] columns)

Adds new columns to the header.

#### Parameters

- *params* `GQIColumn[]` columns: the columns to add.

### void DeleteAllColumns()

Delete all the columns in the header.

### void DeleteColumns(params GQIColumn[] columns)

Delete the provided columns from the header.

#### Parameters

- *params* `GQIColumn[]` columns: the columns to delete.

### void DeleteColumns(params string[] columnNames)

Delete the columns, matching the provided names, from the header.

#### Parameters

- *params* `string[]` columns: the column names of the columns to delete.

### GQIColumn GetColumn(string name)

Get the column by name.

#### Parameters

- string `name`: the column name.

#### Returns

The [GQIColumn](xref:GQI_GQIColumn) matching the provided name.

### void RenameColumn(GQIColumn column, string newName)

Change the name of the provided column.

#### Parameters

- [GQIColumn](xref:GQI_GQIColumn) `column`: the column for which the name should be updated.
- string `newName`: the new name.

### void RenameColumn(string column, string newName)

Change the name of a column.

#### Parameters

- string `column`: the column name of the column for which the name should be updated.
- string `newName`: the new name.
