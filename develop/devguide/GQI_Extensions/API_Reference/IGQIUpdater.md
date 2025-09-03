---
uid: GQI_IGQIUpdater
---

# IGQIUpdater interface

Available from DataMiner 10.4.4/10.5.0 onwards<!-- RN 38643 -->.

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface`
- Assembly: `SLAnalyticsTypes.dll`

This interface exposes methods to an ad hoc data source to publish updates. A concrete implementation is provided as an argument to the ad hoc data source when it implements the [OnStartUpdates](xref:GQI_IGQIUpdateable#void-onstartupdatesigqiupdater) life cycle method.

It allows adding, removing, and updating rows, or updating individual cells.

## Methods

### void AddRow(GQIRow)

Adds a new row to the query result. If a row with the same row key already exists, that row will be updated instead. This method behaves as an *add-or-update* operation. 

> [!WARNING]
> Prior to DataMiner main release 10.5.0-CU4 and feature release 10.5.7, if a row with the same row key already existed, calling the AddRow method would result in a duplicate row with the same row key to be added.

#### Parameters

- [GQIRow](xref:GQI_GQIRow) `row`: The row to add.

> [!IMPORTANT]
> The new row must have a valid row key.

### void RemoveRow(string)

Removes an existing row from the query result.

#### Parameters

- `string` `rowKey`: The row key of the row to remove.

### void UpdateRow(GQIRow)

Updates an existing row in the query result. If a row with the specified row key does not exist yet, the update event is queued and will be applied once the row is added.

#### Parameters

- [GQIRow](xref:GQI_GQIRow) `row`: The row to update.

> [!IMPORTANT]
> The updated row must have as many cells as there are columns.

### void UpdateCell(string, GQIColumn, GQICell)

Updates the cell value and display value of a single cell in the query result.

> [!TIP]
> Use the generic [UpdateCell\<T\>](#void-updatecelltstring-gqicolumnt-t) method instead whenever possible. It provides better type safety.
>
> Only use this method when the cell value type is not known at runtime or when you also need to update the display value.

#### Parameters

- `string` `rowKey`: Identifies the row of the cell to update.
- [GQIColumn](xref:GQI_GQIColumn) `column`: Identifies the column of the cell to update.
- [GQICell](xref:GQI_GQICell) `cell`: Contains the new cell value and display value.

### void UpdateCell\<T\>(string, GQIColumn\<T\>, T)

Updates the cell value of a single cell in the query result.

#### Type parameters

- `T`: The type of cell value.

#### Parameters

- `string` `rowKey`: Identifies the row of the cell to update.
- [GQIColumn\<T\>](xref:GQI_GQIColumn) `column`: Identifies the column of the cell to update.
- `T` `value`: The new cell value.
