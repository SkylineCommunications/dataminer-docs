---
uid: GQI_GQIStaticColumnsAttribute
description: Reference for the GQIStaticColumnsAttribute class, which marks GQI ad hoc data sources whose columns are static.
---

# GQIStaticColumnsAttribute class

## Definition

- Namespace: `Skyline.DataMiner.Core.GQI.Extensions`
- Assembly: `Skyline.DataMiner.Core.GQI.Extensions.dll`

This attribute can be used to mark an ad hoc data source class. It indicates that the columns of an ad hoc data source do not depend on input argument values and will modify the lifecycle so columns can be fetched without resolving input arguments.

Available from DataMiner 10.5.0 [CU19]/10.6.0 [CU7]/10.6.10 onwards.<!-- RN 46050 -->

> [!TIP]
> See also: [Lifecycle of ad hoc data sources](xref:Ad_hoc_Life_cycle#does-the-data-source-have-static-columns).

## Constructors

| Constructor | Description |
|--|--|
| `GQIStaticColumnsAttribute()` | Indicates that the decorated ad hoc data source class has static columns. |
