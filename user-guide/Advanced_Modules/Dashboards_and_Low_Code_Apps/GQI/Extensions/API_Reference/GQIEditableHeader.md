---
uid: GQI_GQIEditableHeader
---

# GQIEditableHeader Class

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface`
- Assembly: `SLAnalyticsTypes.dll`

Represents the header, containing columns, that the custom operator can manipulate.

## Methods

### void AddColumns(params GQIColumn[] columns)

Adds new columns to the header.

#### Parameters

- *params* `GQIColumn[]` columns: The columns to add.

### void DeleteAllColumns()

Deletes all the columns in the header.

### void DeleteColumns(params GQIColumn[] columns)

Deletes the provided columns from the header.

#### Parameters

- *params* `GQIColumn[]` columns: The columns to delete.

### void DeleteColumns(params string[] columnNames)

Deletes the columns matching the provided names from the header.

#### Parameters

- *params* `string[]` columns: The column names of the columns to delete.

### GQIColumn GetColumn(string name)

Gets the column by name.

#### Parameters

- string `name`: The column name.

#### Returns

The [GQIColumn](xref:GQI_GQIColumn) matching the provided name.

### void RenameColumn(GQIColumn column, string newName)

Changes the name of the provided column.

#### Parameters

- [GQIColumn](xref:GQI_GQIColumn) `column`: The column for which the name should be updated.
- string `newName`: The new name.

### void RenameColumn(string column, string newName)

Changes the name of a column.

#### Parameters

- string `column`: The column name of the column for which the name should be updated.
- string `newName`: The new name.
