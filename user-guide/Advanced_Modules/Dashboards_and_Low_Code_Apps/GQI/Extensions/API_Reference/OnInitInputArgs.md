---
uid: GQI_OnInitInputArgs
---

# OnInitInputArgs class

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface`
- Assembly: `SLAnalyticsTypes.dll`

Contains functionality and general query information for user-definable data sources. An instance is provided through the `OnInit` life cycle method of the [IGQIOnInit building block](xref:GQI_IGQIOnInit).

## Properties

| Property | Type | Description |
| -------- | ---- | ----------- |
| DMS | [GQIDMS](xref:GQI_GQIDMS) | Object that can be used to interact with the DMS. |
| Factory | [IGQIFactory](xref:GQI_IGQIFactory) | Object with methods to create other objects that can be used to interact with the core GQI framework. Available from DataMiner 10.4.0/10.4.1 onwards.<!-- RN 37806 --> |
