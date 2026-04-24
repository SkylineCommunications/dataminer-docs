---
uid: Ad_hoc_Discrete_Values
---

# Defining discrete values for columns

Available from DataMiner Web 10.6.7/10.5.0 [CU16]/10.6.0 [CU4] onwards.<!-- RN 45380 -->

> [!IMPORTANT]
> This feature requires the [GQI DxM](xref:GQI_DxM) and the [Skyline.DataMiner.Core.GQI.Extensions NuGet package](https://www.nuget.org/packages/Skyline.DataMiner.Core.GQI.Extensions). It is not available through the SLAnalyticsTypes API.

When defining columns in an ad hoc data source, you can optionally associate a set of **discrete values** with a column. These discrete values are exposed to the client and can be used in filter editors, making it easier for users to filter data by selecting from predefined options rather than typing values manually.

## When to use discrete values

Discrete values are useful in two scenarios:

- **Columns with a fixed set of values**: For example, a "Status" column that can only be *Active*, *Inactive*, or *Pending*. Defining these as discrete values enables users to select from a dropdown when filtering.

- **Columns with special exception values**: For example, a numeric measurement column where most values fall within a continuous range (e.g. 0–100), but specific values have a special meaning (e.g. `-1` means "Error"). Defining these exception values as non-strict discretes surfaces them as quick filter options alongside the standard numeric filter.

## How to define discrete values

Use the [GQIDiscreteOptions\<T\>](xref:GQI_GQIDiscreteOptionsT) class to configure the available discrete values for a column. Each individual discrete value is defined using the [GQIDiscrete\<T\>](xref:GQI_GQIDiscreteT) class, which pairs a value with a display name.

> [!IMPORTANT]
> Each discrete value (the underlying value, not the display value) must be unique within the column. Providing duplicate values will result in an error.

Pass the discrete options to one of the column constructors that accept them:

```csharp
using Skyline.DataMiner.Core.GQI.Extensions;

public GQIColumn[] GetColumns()
{
    return new GQIColumn[]
    {
        // A string column with a fixed set of values
        new GQIStringColumn("Status", new GQIDiscreteOptions<string>(new[]
        {
            new GQIDiscrete<string>("active", "Active"),
            new GQIDiscrete<string>("inactive", "Inactive"),
            new GQIDiscrete<string>("pending", "Pending"),
        })),

        // A numeric column with exception values alongside a continuous range
        new GQIDoubleColumn("Temperature", new GQIDiscreteOptions<double>(new[]
        {
            new GQIDiscrete<double>(-1, "Error"),
            new GQIDiscrete<double>(-2, "Not Available"),
        }, isStrict: false)),

        // A column without discrete values
        new GQIStringColumn("Description"),
    };
}
```

## Strict vs. non-strict

The `IsStrict` property on [GQIDiscreteOptions\<T\>](xref:GQI_GQIDiscreteOptionsT) indicates whether the column values come exclusively from the discrete list (`true`) or whether the discretes represent known values alongside a broader range (`false`). When omitted, it defaults to `true`.

> [!NOTE]
> The `IsStrict` setting currently does not affect how the client presents the filter UI. Regardless of this setting, **numeric** discrete columns are generally handled as non-strict (allowing free-form input alongside discrete options) and **string** discrete columns are generally handled as strict (presenting only the discrete options). This behavior may change in a future release.

## Supported column types

Discrete values are supported on all column types:

- `GQIStringColumn`
- `GQIIntColumn`
- `GQIDoubleColumn`
- `GQIBooleanColumn`
- `GQIDateTimeColumn`
- `GQITimeSpanColumn`
