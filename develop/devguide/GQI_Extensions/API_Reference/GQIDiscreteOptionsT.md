---
uid: GQI_GQIDiscreteOptionsT
---

# GQIDiscreteOptions\<T\> class

## Definition

- Namespace: `Skyline.DataMiner.Core.GQI.Extensions`
- NuGet: `Skyline.DataMiner.Core.GQI.Extensions`

Available from DataMiner Web 10.6.7/10.5.0 [CU16]/10.6.0 [CU4] onwards.<!-- RN 45380 -->

Configures a set of discrete values for a [GQIColumn\<T\>](xref:GQI_GQIColumnT). Discrete values are surfaced to the client for use in filter editors, dropdowns, and similar UI components.

## Type parameters

- `T`: The value type of the column this configuration applies to.

## Constructors

| Constructor | Description |
|--|--|
| GQIDiscreteOptions(IReadOnlyList\<[GQIDiscrete\<T\>](xref:GQI_GQIDiscreteT)\> discretes) | Creates a new instance with the specified discrete values and strict mode enabled. |
| GQIDiscreteOptions(IReadOnlyList\<[GQIDiscrete\<T\>](xref:GQI_GQIDiscreteT)\> discretes, bool isStrict) | Creates a new instance with the specified discrete values and the given strictness setting. |

## Properties

| Property | Type | Description |
|--|--|--|
| Discretes | IReadOnlyList\<[GQIDiscrete\<T\>](xref:GQI_GQIDiscreteT)\> | The list of discrete values. Each value must be unique; providing duplicate values will result in an error. |
| IsStrict | bool | When `true`, the column is treated as a purely discrete column whose values are expected to come exclusively from the provided list (e.g. a status field with a fixed set of states). When `false`, the column can hold a continuous range of values, but the provided discretes represent known special or exception values that are surfaced alongside free-form or range-based filtering (e.g. a numeric measurement where `-1` means "Error"). |

> [!NOTE]
> The `IsStrict` property currently does not affect the query filter behavior in the client. Regardless of this setting, **numeric** discrete columns are generally handled as non-strict (allowing free-form input alongside discrete options) and **string** discrete columns are generally handled as strict (presenting only the discrete options). This behavior may change in a future release.

## Example

```csharp
using Skyline.DataMiner.Core.GQI.Extensions;

// Fixed set of statuses — strict
var statusDiscretes = new GQIDiscreteOptions<string>(new[]
{
    new GQIDiscrete<string>("active", "Active"),
    new GQIDiscrete<string>("inactive", "Inactive"),
    new GQIDiscrete<string>("pending", "Pending"),
});
var statusColumn = new GQIStringColumn("Status", statusDiscretes);

// Continuous range with exception values — non-strict
var temperatureDiscretes = new GQIDiscreteOptions<double>(new[]
{
    new GQIDiscrete<double>(-1, "Error"),
    new GQIDiscrete<double>(-2, "Not Available"),
}, isStrict: false);
var temperatureColumn = new GQIDoubleColumn("Temperature", temperatureDiscretes);
```
