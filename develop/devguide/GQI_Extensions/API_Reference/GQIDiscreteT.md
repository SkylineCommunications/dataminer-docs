---
uid: GQI_GQIDiscreteT
---

# GQIDiscrete\<T\> class

## Definition

- Namespace: `Skyline.DataMiner.Core.GQI.Extensions`
- NuGet: `Skyline.DataMiner.Core.GQI.Extensions`

Available from DataMiner Web 10.6.7/10.5.0 [CU16]/10.6.0 [CU4] onwards.<!-- RN 45380 -->

Represents a single discrete value option for a column, pairing an underlying value with a user-friendly display string.

> [!TIP]
> Learn more about configuring discretes for columns [here](xref:GQI_Extensions_Discrete_Values).

## Type parameters

- `T`: The value type of the discrete, matching the column it belongs to.

## Constructor

| Constructor | Description |
|--|--|
| GQIDiscrete(string name, T value) | Creates a new discrete value. |

## Properties

| Property | Type | Description |
|--|--|--|
| Name | string | The display text shown to the user for this discrete option. |
| Value | T | The underlying value of this discrete option. |


## Example

```csharp
using Skyline.DataMiner.Core.GQI.Extensions;

// Discrete for an exception "error" state.
var error = new GQIDiscrete<int>("Error", -1);

```
