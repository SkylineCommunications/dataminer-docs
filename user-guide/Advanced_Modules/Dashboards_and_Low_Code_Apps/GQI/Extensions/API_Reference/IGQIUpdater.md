---
uid: GQI_IGQIUpdater
---

# IGQIUpdater interface

Available from DataMiner 10.4.4/10.5.0 onwards<!-- RN 38643 -->.

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface`
- Assembly: `SLAnalyticsTypes.dll`

An interface that exposes methods to an Ad Hoc data source to publish updates. A concrete implementation is provided as an argument to the Ad Hoc data source when it implements the [OnStartUpdates](xref:GQI_IGQIUpdateable#void-onstartupdatesigqiupdater) lifecycle method.

It allows to add, remove and update rows or update individual cells.

## Methods

### void AddRow(GQIRow)

Adds a new row to the query result.

#### Parameters

- [GQIRow](xref:GQI_GQIRow) `row`: the row to add.

> [!IMPORTANT]
> The new row should have a valid row key.

### void RemoveRow(string)

Removes an existing row from the query result.

#### Parameters

- `string` `rowKey`: the row key of the row to remove.

### void UpdateRow(GQIRow)

Updates the cells of an existing row in the query result.

#### Parameters

- [GQIRow](xref:GQI_GQIRow) `row`: the row to update.

> [!IMPORTANT]
> The updated row should have as many cells as there are columns.

### void UpdateCell(string, GQIColumn, GQICell)

Update the cell value and display value of a single cell in the query result.

> [!TIP]
> Prefer using the generic [UpdateCell\<T\>](#void-updatecelltstring-gqicolumnt-t) method instead whenever possible. It provides better type safety.
> Only use this method when the cell value type is not known at runtime or when you also need to update the display value.

#### Parameters

- `string` `rowKey`: identies the row of the cell to update.
- [GQIColumn](xref:GQI_GQIColumn) `column`: identifies the column of the cell to update.
- [GQICell](xref:GQI_GQICell) `cell`: contains the new cell value and display value.

### void UpdateCell\<T\>(string, GQIColumn\<T\>, T)

Update the cell value of a single cell in the query result.

#### Type parameters

- `T`: the type of cell value.

#### Parameters

- `string` `rowKey`: identies the row of the cell to update.
- [GQIColumn\<T\>](xref:GQI_GQIColumn) `column`: identifies the column of the cell to update.
- `T` `value`: the new cell value.
