---
uid: GQI_GQIDiscreteOptionsT
---

# GQIDiscreteOptions\<T\> class

## Definition

- Namespace: `Skyline.DataMiner.Core.GQI.Extensions`
- Assembly: `Skyline.DataMiner.Core.GQI.Extensions.dll`

Available from DataMiner Web 10.5.0 [CU16]/10.6.0 [CU4]/10.6.7 onwards.<!-- RN 45380 -->

Configures a set of discrete values for a [GQIColumn\<T\>](xref:GQI_GQIColumnT).

> [!TIP]
> See also: [Defining discrete values for a column](xref:GQI_Extensions_Discrete_Values).

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
| IsStrict | bool | The strictness of the discrete values: [strict vs. non-strict](xref:GQI_Extensions_Discrete_Values#strict-vs-non-strict) |

## Example

```csharp
// Fixed set of statuses — strict
var statusDiscretes = new GQIDiscreteOptions<string>(new[]
{
    new GQIDiscrete<string>("Active", "active"),
    new GQIDiscrete<string>("Inactive", "inactive"),
    new GQIDiscrete<string>("Pending", "pending"),
});
var statusColumn = new GQIStringColumn("Status", statusDiscretes);

// Continuous range with exception values — non-strict
var percentageDiscretes = new GQIDiscreteOptions<double>(new[]
{
    new GQIDiscrete<double>("Error", -1),
    new GQIDiscrete<double>("Not Available", -2),
}, isStrict: false);
var percentageColumn = new GQIDoubleColumn("Percentage", percentageDiscretes);
```
