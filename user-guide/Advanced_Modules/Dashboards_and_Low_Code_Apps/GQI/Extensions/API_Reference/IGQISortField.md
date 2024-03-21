---
uid: GQI_IGQISortField
---

# IGQISortField interface

This interface defines a sort operation for a single column. One or more sort fields are combined into a [IGQISortOperator](xref:GQI_IGQISortOperator) to define a sort operation in GQI.

Available from DataMiner 10.4.5/10.5.0 onwards.<!-- RN 39136 -->

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface.Operators`
- Assembly: `SLAnalyticsTypes.dll`

## Properties

| Name | Type | Description |
| ---- | ---- | ----------- |
| Column | [IGQIColumn](xref:GQI_IGQIColumn) | The column to sort on. |
| Direction | [GQISortDirection](xref:GQI_GQISortDirection) | Whether to sort from lowest to highest or the other way around. |
