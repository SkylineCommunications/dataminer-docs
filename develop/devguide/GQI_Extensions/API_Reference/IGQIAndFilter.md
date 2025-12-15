---
uid: GQI_IGQIAndFilter
---

# IGQIAndFilter interface

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface.Operators`  
- Assembly: `SLAnalyticsTypes.dll`

Represents a filter that matches when all of the filters in a set of subfilters match.

Available from DataMiner 10.5.0 [CU11]/10.6.2 onwards when using the [GQI DxM](xref:GQI_DxM).<!-- RN 44230 -->

## Implements

- [IGQIFilter](xref:GQI_IGQIFilter)

## Properties

| Name | Type | Description |
| ---- | ---- | ----------- |
| Filters | IReadOnlyList<[IGQIFilter](xref:GQI_IGQIFilter)> | The set of subfilters. |
