---
uid: GQI_GQIEditableRow
---

# GQIEditableRow Class

## Definition

Namespace: `Skyline.DataMiner.Analytics.GenericInterface`  
Assembly: `SLAnalyticsTypes.dll`

Represents the row that the custom operator can manipulate.

## Methods

### void Delete()

Delete the row.

### string GetDisplayValue(GQIColumn column)

Get the display value for the cell matching the provided column.

#### Parameters

- [GQIColumn](xref:GQI_GQIColumn) `column`: the column for which the display value should be retrieved.

#### Returns

The value, of type `T`, of the cell matching the provided column.

### string GetDisplayValue(string columnName)

Get the display value for the cell matching the provided column name.

#### Parameters

- string `columnName`: the column name of the column for which the display value should be retrieved.

#### Returns

The display value of the cell matching the provided column.

### T GetValue\<T\>(GQIColumn column)

Get the value for the cell matching the provided column.

#### Parameters

- [GQIColumn](xref:GQI_GQIColumn) `column`: the column for which the value should be retrieved.

#### Returns

The value, of type `T`, of the cell matching the provided column.

### T GetValue\<T\>(GQIColumn\<T\> column)

Get the value for the cell matching the provided column.

> [!NOTE]
> `GetValue` returns the default of type `T` if no value is available in that cell. If it is important to know if a value was present, use the `TryGetValue` variant.

#### Parameters

- [GQIColumn\<T\>](xref:GQI_GQIColumn) `column`: the column for which the value should be retrieved. 

#### Returns

The value, of type `T`, of the cell matching the provided column.

### T GetValue\<T\>(string columnName)

Get the value for the cell matching the provided column name.

#### Parameters

- string `columnName`: the column name of the column for which the value should be retrieved.

#### Returns

The value, of type `T`, of the cell matching the provided column.

### object GetValue(string columnName)

Get the value for the cell matching the provided column.

#### Parameters

- string `columnName`: the column name of the column for which the value should be retrieved.

#### Returns

The value, of type `object`, of the cell matching the provided column.

### bool TryGetValue\<T\>(GQIColumn column, out T value)

Get the value for a certain column.

#### Parameters

- [GQIColumn](xref:GQI_GQIColumn) `column`: the column for which the value should be retrieved.
- *out* `T` value: the value, of type `T`, of the cell matching the provided column.

#### Returns

`true` if the value was successfully retrieved, otherwise `false`.

### bool TryGetValue\<T\>(GQIColumn\<T\> column, out T value)

Get the value for a certain column.

#### Parameters

- [GQIColumn\<T\>](xref:GQI_GQIColumn) `column`: the column for which the value should be retrieved.
- *out* `T` value: the value, of type `T`, in the row matching the provided column.

#### Returns

`true` if the value was successfully retrieved, otherwise `false`.

### bool TryGetValue\<T\>(string columnName, out T value)

Get the value for a certain column.

#### Parameters

- string `columnName`: the name of the column for which the value should be retrieved.
- *out* `T` value: the value, of type `T`, in the row matching the provided column.

#### Returns

`true` if the value was successfully retrieved, otherwise `false`.

### void SetDisplayValue(GQIColumn column, string displayValue)

Set the display value for the cell matching the column of the provided column name.

#### Parameters

- [GQIColumn](xref:GQI_GQIColumn) `column`: the column for which the display value should be set.
- string `displayValue`: the display value that should be set.

### void SetDisplayValue(string columnName, string displayValue)

Set the display value for the cell matching the column of the provided column name.

#### Parameters

- string `columnName`: the column name of the column for which the display value should be set.
- string `displayValue`: the display value that should be set.

### void SetValue(GQIColumn column, object value, string displayValue = null)

Set the value for the cell matching the provided column.

#### Parameters

- [GQIColumn](xref:GQI_GQIColumn) `column`: the column for which the value should be set.
- object `value`: the value that should be set.
- (optional) string `displayValue`: the display value that should be set.

### void SetValue\<T\>(GQIColumn\<T\> column, T value, string displayValue = null)

Set the value for the cell matching the provided column.

#### Parameters

- [GQIColumn\<T\>](xref:GQI_GQIColumn) `column`: the column for which the value should be set.
- object `value`: the value that should be set.
- (optional) string `displayValue`: the display value that should be set.

### void SetValue(string columnName, object value, string displayValue = null)

Set the value for the cell matching the column of the provided column name.

#### Parameters

- string `columnName`: the column name of the column for which the value should be set.
- object `value`: the value that should be set.
- (optional) string `displayValue`: the display value that should be set.