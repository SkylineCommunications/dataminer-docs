---
uid: GQI_IGQIFilter
---

# IGQIFilter interface

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface.Operators`  
- Assembly: `SLAnalyticsTypes.dll`

Represents the filter logic used in a [IGQIFilterOperator](xref:GQI_IGQIFilterOperator).

Available from DataMiner 10.5.0 [CU11]/10.6.2 onwards when using the [GQI DxM](xref:GQI_DxM).<!-- RN 44230 -->

## Derived types

| Type | Description |
| ---- | ----------- |
| [IGQIValueFilter](xref:GQI_IGQIValueFilter) | Filter that matches when a column value matches a specific filter value using a filter method. |
| [IGQIAndFilter](xref:GQI_IGQIAndFilter) |  Filter that matches when **all** filters in a set of filters match. |
| [IGQIOrFilter](xref:GQI_IGQIOrFilter) | Filter that matches when **any** filter in a set of filters match. |
