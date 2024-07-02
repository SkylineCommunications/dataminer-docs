---
uid: GQI_IGQIRowOperator
---

# IGQIRowOperator Interface

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface`
- Assembly: `SLAnalyticsTypes.dll`

This interface makes it possible to manipulate the rows in a custom operator.

## Methods

### void HandleRow(GQIEditableRow row)

This method is called exactly once for every row when a query is executed. It allows you to get or set cell values from the given row.

#### Parameters

- [GQIEditableRow](xref:GQI_GQIEditableRow) `row`: A reference to the row the custom operator is processing.
