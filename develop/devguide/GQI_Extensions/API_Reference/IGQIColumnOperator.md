---
uid: GQI_IGQIColumnOperator
---

# IGQIColumnOperator Interface

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface`
- Assembly: `SLAnalyticsTypes.dll`

This interface makes it possible to manipulate the columns in a custom operator.

## Methods

### void HandleColumns(GQIEditableHeader header)

Makes it possible to manipulate the columns the custom operator is working with.

> [!TIP]
> Learn more about when this method is called within a [custom operator](xref:CO_Life_cycle#handlecolumns).

#### Parameters

- [GQIEditableHeader](xref:GQI_GQIEditableHeader) `header`: A reference to the header representing the columns.
