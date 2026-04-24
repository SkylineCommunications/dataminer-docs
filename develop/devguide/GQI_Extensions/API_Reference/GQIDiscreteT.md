---
uid: GQI_GQIDiscreteT
---

# GQIDiscrete\<T\> class

## Definition

- Namespace: `Skyline.DataMiner.Core.GQI.Extensions`
- NuGet: `Skyline.DataMiner.Core.GQI.Extensions`

Available from DataMiner Web 10.6.7/10.5.0 [CU16]/10.6.0 [CU4] onwards.<!-- RN 45380 -->

Represents a single discrete value option for a column, pairing an underlying value with a user-friendly display string.

## Type parameters

- `T`: The value type of the discrete, matching the column it belongs to.

## Constructor

| Constructor | Description |
|--|--|
| GQIDiscrete(T value, string displayValue = null) | Creates a new discrete value. When `displayValue` is not provided, the result of `value.ToString()` is used as display text. |

## Properties

| Property | Type | Description |
|--|--|--|
| Value | T | The underlying value of this discrete option. |
| DisplayValue | string | The display text shown to the user for this discrete option. |

## Example

```csharp
using Skyline.DataMiner.Core.GQI.Extensions;

// Discrete with an explicit display value
var error = new GQIDiscrete<int>(-1, "Error");

// Discrete where the display value defaults to the string representation of the value
var normal = new GQIDiscrete<int>(0);
// normal.DisplayValue will be "0"
```
