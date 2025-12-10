---
uid: GQI_IGQIValueFilter
---

# IGQIValueFilter interface

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface.Operators`  
- Assembly: `SLAnalyticsTypes.dll`

Represents a filter that matches rows when a column value matches a specific filter value using a filter method.

Available from DataMiner 10.5.0 [CU11]/10.6.2 onwards when using the [GQI DxM](xref:GQI_DxM).<!-- RN 44230 -->

## Implements

- [IGQIFilter](xref:GQI_IGQIFilter)

## Properties

| Name | Type | Description |
| ---- | ---- | ----------- |
| [Column](#filter-column) | [IGQIColumn](xref:GQI_IGQIColumn) | The column whose values are compared against the filter value. |
| [Method](#filter-method) | [GQIFilterMethod](xref:GQI_GQIFilterMethod) | The method that is used to compare the column value against the filter value. |
| [Value](#filter-value) | `object` | The filter value to compare against the column value. |

## Remarks

### Filter column

The filter column can be any column that is available for filtering at the point in the query where the [IGQIFilterOperator](xref:GQI_IGQIFilterOperator) is applied.

To check if the filter column is equal to any other column reference, you can use the [IGQIColumn.Equals](xref:GQI_IGQIColumn#bool-equalsigqicolumn) method.

```csharp
GQIStringColumn myColumn;
IGQIValueFilter filter;
...
if (filter.Column.Equals(myColumn))
   // Do some filter optimizations for myColumn
```

### Filter method

The [filter methods](xref:GQI_GQIFilterMethod#fields) that are supported depend on which column type and filter value is used in the filter.

| Column/filter types | Supported methods |
| ------------------ | ----------------- |
| `bool` | `Equals`/`NotEquals` |
| `DateTime`, `double`, `int`, `TimeSpan` | [Ordinal comparisons](xref:GQI_GQIFilterMethod#ordinal-comparisons) |
| `string` | [String comparisons](xref:GQI_GQIFilterMethod#string-comparisons) and [Regex comparisons](xref:GQI_GQIFilterMethod#ordinal-comparisons) |

### Filter value

The filter value is boxed as an `object` and can be typed checked to extract the actual value.

```csharp
IGQIValueFilter filter;
...
if (filter.Value is string stringValue)
   // Do something with the stringValue
```

Supported types:

- bool
- DateTime
- double
- int
- string
- TimeSpan

> [!Warning]
> When attempting to access the `Value` property of a filter on a column type that is not supported for GQI extensions, a [NotSupportedException](https://learn.microsoft.com/en-us/dotnet/api/system.notsupportedexception) will be thrown.
