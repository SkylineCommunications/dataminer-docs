---
uid: GQI_IGQIFilterOperator
---

# IGQIFilterOperator interface

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface.Operators`  
- Assembly: `SLAnalyticsTypes.dll`

Represents a **filter operator** in the core framework.

## Implements

- [IGQICoreOperator](xref:GQI_IGQICoreOperator)
- [IGQICoreBlock](xref:GQI_IGQICoreBlock)

## Properties

| Name | Type | Description |
| ---- | ---- | ----------- |
| Filter | [IGQIFilter](xref:GQI_IGQIFilter) | The filter logic. Available from DataMiner 10.5.0 [CU11]/10.6.2 onwards when using the [GQI DxM](xref:GQI_DxM).<!-- RN 44230 + 44235--> |
