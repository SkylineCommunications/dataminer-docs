---
uid: GQI_GQIEditableRow
---

# GQIEditableRow Class

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface`
- Assembly: `SLAnalyticsTypes.dll`

Represents a row that a custom operator can manipulate. Inherits from [GQIRow](xref:GQI_GQIRow).

## Methods

### void Delete()

Deletes the row.

### string GetDisplayValue(GQIColumn column)

Gets the display value for the cell of the specified column.

#### Parameters

- [GQIColumn](xref:GQI_GQIColumn) `column`: The column for which the display value should be retrieved.

#### Returns

The value, of type `T`, of the cell matching the provided column.

### string GetDisplayValue(string columnName)

Gets the display value for the cell of the specified column name.

#### Parameters

- string `columnName`: The column name of the column for which the display value should be retrieved.

#### Returns

The display value of the cell matching the provided column.

### T GetValue\<T\>(GQIColumn column)

Gets the value for the cell of the specified column.

#### Parameters

- [GQIColumn](xref:GQI_GQIColumn) `column`: The column for which the value should be retrieved.

#### Returns

The value, of type `T`, of the cell matching the provided column.

### T GetValue\<T\>(GQIColumn\<T\> column)

Gets the value for the cell of the specified column.

> [!NOTE]
> `GetValue` returns the default of type `T` if no value is available in that cell. If it is important to know if a value was present, use the `TryGetValue` method instead.

#### Parameters

- [GQIColumn\<T\>](xref:GQI_GQIColumn) `column`: The column for which the value should be retrieved.

#### Returns

The value, of type `T`, of the cell matching the provided column.

### T GetValue\<T\>(string columnName)

Gets the value for the cell of the specified column name.

#### Parameters

- string `columnName`: The column name of the column for which the value should be retrieved.

#### Returns

The value, of type `T`, of the cell matching the provided column.

### object GetValue(string columnName)

Gets the value for the cell of the specified column name.

#### Parameters

- string `columnName`: The column name of the column for which the value should be retrieved.

#### Returns

The value, of type `object`, of the cell matching the provided column.

### bool TryGetValue\<T\>(GQIColumn column, out T value)

Gets the value for the cell of the specified column.

Available from DataMiner 10.3.4/10.4.0 onwards.<!-- RN 35734 -->

#### Parameters

- [GQIColumn](xref:GQI_GQIColumn) `column`: The column for which the value should be retrieved.
- *out* `T` value: The value, of type `T`, of the cell matching the provided column.

#### Returns

`true` if the value has been successfully retrieved, otherwise `false`.

### bool TryGetValue\<T\>(GQIColumn\<T\> column, out T value)

Gets the value for the cell of the specified column.

Available from DataMiner 10.3.4/10.4.0 onwards.<!-- RN 35734 -->

#### Parameters

- [GQIColumn\<T\>](xref:GQI_GQIColumn) `column`: The column for which the value should be retrieved.
- *out* `T` value: The value, of type `T`, in the row matching the provided column.

#### Returns

`true` if the value has been successfully retrieved, otherwise `false`.

### bool TryGetValue\<T\>(string columnName, out T value)

Gets the value for the cell of the specified column name.

Available from DataMiner 10.3.4/10.4.0 onwards.<!-- RN 35734 -->

#### Parameters

- string `columnName`: The name of the column for which the value should be retrieved.
- *out* `T` value: The value, of type `T`, in the row matching the provided column.

#### Returns

`true` if the value has been successfully retrieved, otherwise `false`.

### void SetDisplayValue(GQIColumn column, string displayValue)

Sets the display value for the cell of the specified column.

#### Parameters

- [GQIColumn](xref:GQI_GQIColumn) `column`: The column for which the display value should be set.
- string `displayValue`: The display value that should be set.

### void SetDisplayValue(string columnName, string displayValue)

Sets the display value for the cell of the specified column name.

#### Parameters

- string `columnName`: The column name of the column for which the display value should be set.
- string `displayValue`: The display value that should be set.

### void SetValue(GQIColumn column, object value, string displayValue = null)

Sets the value for the cell of the specified column.

#### Parameters

- [GQIColumn](xref:GQI_GQIColumn) `column`: The column for which the value should be set.
- object `value`: The value that should be set.
- (optional) string `displayValue`: The display value that should be set.

### void SetValue\<T\>(GQIColumn\<T\> column, T value, string displayValue = null)

Sets the value for the cell of the specified column.

#### Parameters

- [GQIColumn\<T\>](xref:GQI_GQIColumn) `column`: The column for which the value should be set.
- object `value`: The value that should be set.
- (optional) string `displayValue`: The display value that should be set.

### void SetValue(string columnName, object value, string displayValue = null)

Set the value for the cell of the specified column.

#### Parameters

- string `columnName`: The column name of the column for which the value should be set.
- object `value`: The value that should be set.
- (optional) string `displayValue`: The display value that should be set.
