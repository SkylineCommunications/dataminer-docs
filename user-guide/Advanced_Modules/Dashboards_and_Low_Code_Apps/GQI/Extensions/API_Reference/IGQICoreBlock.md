---
uid: GQI_IGQICoreBlock
---

# IGQICoreBlock interface

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface`
- Assembly: `SLAnalyticsTypes.dll`

Represents any native **block** in the core framework. A block can be either a data source or an operator.

## Derived types

- IGQICoreDataSource
- [IGQICoreOperator](xref:GQI_IGQICoreOperator)

## Methods

### bool IsFilterOperator(out IGQIFilterOperator filterOperator)

Checks if this block is a filter operator and provides an [IGQIFilterOperator](xref:GQI_IGQIFilterOperator) reference for it.

#### Parameters

- **out** [IGQIFilterOperator](xref:GQI_IGQIFilterOperator) `filterOperator`: A reference to this block if it is a filter, otherwise null.

#### Returns

`true` if this query block is a filter operator, otherwise `false`.

### bool IsSortOperator(out IGQISortOperator sortOperator)

Checks if this block is a sort operator and provides an [IGQISortOperator](xref:GQI_IGQISortOperator) reference for it.

Available from DataMiner 10.4.0/10.4.1 onwards.<!-- RN 37806 -->

#### Parameters

- **out** [IGQISortOperator](xref:GQI_IGQISortOperator) `sortOperator`: A reference to this block if it represents a sort operation; otherwise null.
