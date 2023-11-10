---
uid: GQI_IGQICoreBlock
---

# IGQICoreBlock Interface

## Definition

Namespace: `Skyline.DataMiner.Analytics.GenericInterface`  
Assembly: `SLAnalyticsTypes.dll`

Represents any native **block** in the core framework.
A block can either be a data source or an operator.

## Derived types

- IGQICoreDataSource
- [IGQICoreOperator](xref:GQI_IGQICoreOperator)

## Methods

### bool IsFilterOperator(out IGQIFilterOperator filterOperator)

Checks if this block is a filter operator and provides an [IGQIFilterOperator](xref:GQI_IGQIFilterOperator) reference for it.

#### Parameters

- **out** [IGQIFilterOperator](xref:GQI_IGQIFilterOperator) `filterOperator`: a reference to this block if it is a filter, otherwise null.

#### Returns

`true` if this query block is a filter operator, otherwise `false`.
