---
uid: GQI_GQIColumnT
---

# GQIColumn\<T\> class

## [Skyline.DataMiner.Core.GQI.Extensions](#tab/tabid-1)

### Definition

- Namespace: `Skyline.DataMiner.Core.GQI.Extensions`
- NuGet: `Skyline.DataMiner.Core.GQI.Extensions`

Provides the *typed* base class for a column in GQI. It provides increased type safety compared to the non-generic [GQIColumn](xref:GQI_GQIColumn).

Inherits from [GQIColumn](xref:GQI_GQIColumn).

> [!NOTE]
> This is an abstract base class. To create a new column, use one of the [derived types](#derived-types) provided by the framework.

### Type parameters

- `T`: the type of cell values in this column.

### Properties

| Property | Type | Description | Version |
|--|--|--|--|
| DiscreteOptions | [GQIDiscreteOptions\<T\>](xref:GQI_GQIDiscreteOptionsT) | The discrete value options configured for this column, or `null` if no discretes are defined. | DataMiner Web 10.6.7/10.5.0 [CU16]/10.6.0 [CU4]<!-- RN 45380 --> |

### Derived types

Each derived type has two constructors: one that accepts only a name (backward compatible), and one that also accepts a [GQIDiscreteOptions\<T\>](xref:GQI_GQIDiscreteOptionsT) parameter (available from DataMiner Web 10.6.7/10.5.0 [CU16]/10.6.0 [CU4] onwards<!-- RN 45380 -->).

| Type | Value type | Example |
|--|--|--|
| `GQIBooleanColumn` | `bool` | `new GQIBooleanColumn("Active", discreteOptions)` |
| `GQIDateTimeColumn` | `DateTime` | `new GQIDateTimeColumn("Timestamp", discreteOptions)` |
| `GQIDoubleColumn` | `double` | `new GQIDoubleColumn("Temperature", discreteOptions)` |
| `GQIIntColumn` | `int` | `new GQIIntColumn("Count", discreteOptions)` |
| `GQIStringColumn` | `string` | `new GQIStringColumn("Status", discreteOptions)` |
| `GQITimeSpanColumn` | `TimeSpan` | `new GQITimeSpanColumn("Duration", discreteOptions)` |

## [SLAnalyticsTypes](#tab/tabid-2)

### Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface`
- Assembly: `SLAnalyticsTypes.dll`

Provides the *typed* base class for a column in GQI. It provides increased type safety compared to the non-generic [GQIColumn](xref:GQI_GQIColumn).

Inherits from [GQIColumn](xref:GQI_GQIColumn).

> [!NOTE]
> This is an abstract base class. To create a new column, use one of the [derived types](#derived-types) provided by the framework.

### Type parameters

- `T`: the type of cell values in this column.

### Derived types

- `GQIBooleanColumn`
- `GQIDateTimeColumn`
- `GQIDoubleColumn`
- `GQIIntColumn`
- `GQIStringColumn`
- `GQITimeSpanColumn` (from DataMiner 10.3.9/10.4.0 onwards<!-- RN 36717 -->)

***
