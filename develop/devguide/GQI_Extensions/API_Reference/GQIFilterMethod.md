---
uid: GQI_GQIFilterMethod
---

# GQIFilterMethod enum

Indicates how a filter value should be used to compare against values in the filter column for a [IGQIValueFilter](xref:GQI_IGQIValueFilter).

Available from DataMiner 10.5.0 [CU11]/10.6.2 onwards when using the [GQI DxM](xref:GQI_DxM).<!-- RN 44230 -->

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface.Operators`  
- Assembly: `SLAnalyticsTypes.dll`

## Fields

| Name | Value | Description |
| ---- | ----- | ----------- |
| None | 0 | Missing or unknown filter method. |
| Equals | 1 | Match values that are equal to the filter value. Applicable for every value type. |
| DoesNotEqual | 2 | Match values that are not equal to the filter value. Applicable for every value type. |
| IsLessThan | 3 | Match values that are smaller than the filter value. See [Ordinal comparisons](#ordinal-comparisons). |
| IsLessThanOrEquals | 4 | Match values that are smaller or equal to the filter value. See [Ordinal comparisons](#ordinal-comparisons). |
| IsGreaterThan | 5 | Match values that are larger than the filter value. See [Ordinal comparisons](#ordinal-comparisons). |
| IsGreaterThanOrEquals | 6 | Match values that are larger or equal to the filter value. See [Ordinal comparisons](#ordinal-comparisons). |
| Contains | 7 | Match string values that contain the filter value. |
| DoesNotContain | 8 | Match string values that do not contain the filter value. |
| MatchesRegex | 9 | Match string values that match the regex represented by the filter value. See [Regex comparisions](#regex-comparisons). |
| DoesNotMatchRegex | 10 | Match string value that match the regex represented by the filter value. See [Regex comparisions](#regex-comparisons). |

## Remarks

> [!NOTE]
> Filter methods vary in the value types they support, and their behavior depends on the value type to which they are applied.

### String comparisons

Applies to:

- `Equals`/`DoesNotEqual`
- `Contains`/`DoesNotContain`

All string comparisons are **case-insensitive** and **culture-insensitive** by default. This is equivalent to the [.NET StringComparision.OrdinalIgnoreCase](https://learn.microsoft.com/en-us/dotnet/api/system.stringcomparison).

### Ordinal comparisons

Values that support ordinal comparisons can use any of the following filter methods:

- `Equals`/`DoesNotEqual`
- `IsLessThan`/`IsGreaterThanOrEquals`
- `IsGreaterThan`/`IsLessThanOrEquals`

Ordinal comparisions are supported for the following value types:

- `DateTime`
- `double`
- `int`
- `TimeSpan`

### Regex comparisons

Applies to: `MatchesRegex`/`DoesNotMatchRegex`

Regex (regular expression) comparisons are only supported for string values. The string filter value is interpreted as a .NET regular expression without any [RegexOptions](https://learn.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-options).

See also: [.NET Regular Expresssion Language - Quick Reference](https://learn.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference)
