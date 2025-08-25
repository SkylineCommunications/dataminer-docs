---
uid: GQI_GQIColumnT
---

# GQIColumn\<T\> class

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface`
- Assembly: `SLAnalyticsTypes.dll`

Provides the *typed* base class for a column in GQI. It provides increased type safety compared to the non-generic [GQIColumn](xref:GQI_GQIColumn).

Inherits from [GQIColumn](xref:GQI_GQIColumn).

> [!NOTE]
> This is an abstract base class. To create a new column, use one of the [derived types](#derived-types) provided by the framework.

## Type parameters

- `T`: the type of cell values in this column.

## Derived types

- `GQIBooleanColumn`
- `GQIDateTimeColumn`
- `GQIDoubleColumn`
- `GQIIntColumn`
- `GQIStringColumn`
- `GQITimeSpanColumn` (from DataMiner 10.3.9/10.4.0 onwards<!-- RN 36717 -->)
