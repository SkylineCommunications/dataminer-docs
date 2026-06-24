---
uid: GQI_Extensions_Discrete_Values
---

# Defining discrete values for a column

From DataMiner Web 10.5.0 [CU17]/10.6.0 [CU5]/10.6.8 onwards<!-- RN 45380 --> it is possible to define a set of **discrete values** when creating a column within GQI extensions. Discrete values are predefined, named constants for values that can occur in the column. They are exposed to the client and can be used in filter editors, making it easier for users to filter data by selecting from predefined options rather than typing values manually.

> [!IMPORTANT]
> This feature requires the [GQI DxM](xref:GQI_DxM) and the Skyline.DataMiner.Core.GQI.Extensions [extension API](xref:GQI_Extension_API)

## When to use discrete values

Discrete values can be used in two ways:

- For columns that can only contain **a fixed set of values**. For example, a "Status" column that can only be *Active*, *Inactive*, or *Pending*.

- For columns that may contain **a fixed set of special or exceptional values alongside regular values**. For example, a numeric measurement column where most values fall within a continuous range (for example, 0–100), but specific values have a special meaning (for example, `-1` means "Error"). Defining these exception values as non-strict discrete values surfaces them as quick filter options alongside the standard numeric filter.

## How to define a column with discrete values

Use the [GQIDiscreteOptions\<T\>](xref:GQI_GQIDiscreteOptionsT) class to configure the available discrete values for a column. Each individual discrete value is defined using the [GQIDiscrete\<T\>](xref:GQI_GQIDiscreteT) class, which pairs a display name with an underlying value.

> [!IMPORTANT]
> Each discrete value (the underlying value, not the name) must be unique within the column. Providing duplicate values will result in an error.

Pass the discrete options to one of the column constructors that accepts them:

```csharp
// A string column with a fixed set of values
new GQIStringColumn("Status", new GQIDiscreteOptions<string>(new[]
{
    new GQIDiscrete<string>("Active", "active"),
    new GQIDiscrete<string>("Inactive", "inactive"),
    new GQIDiscrete<string>("Pending", "pending"),
})),

// A numeric column with exception values alongside a continuous range
new GQIDoubleColumn("Percentage", new GQIDiscreteOptions<double>(new[]
{
    new GQIDiscrete<double>("Error", -1),
    new GQIDiscrete<double>("Not Available", -2),
}, isStrict: false)),
```

> [!NOTE]
> Within custom operators, the discrete values of existing columns can be read but not altered.

## Cell values for discrete columns

When creating a cell for a discrete value, you only need to specify the `Value` property of the discrete value. The `Name` property of the discrete value will automatically be used as the display value. Any other `DisplayValue` on the cell will be ignored.

## Strict vs. non-strict

The `IsStrict` property on [GQIDiscreteOptions\<T\>](xref:GQI_GQIDiscreteOptionsT) indicates whether the column values come exclusively from the discrete value list (`true`) or whether the discrete values represent known values alongside a broader range (`false`). When omitted, it defaults to `true`.

> [!IMPORTANT]
> Only cells with discrete values and empty cells are allowed in a column with strict discrete values. If any other value is provided, the query will fail to execute.
