---
uid: GQI_OnInitInputArgs
---

# OnInitInputArgs class

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface`
- Assembly: `SLAnalyticsTypes.dll`

Contains functionality and general query information for ad hod data sources and custom operators. An instance is provided through the `OnInit` life cycle method of the [IGQIOnInit building block](xref:GQI_IGQIOnInit).

## Properties

| Property | Type | Description |
| -------- | ---- | ----------- |
| DMS | [GQIDMS](xref:GQI_GQIDMS) | Object that can be used to interact with the DMS. |
| Logger | [IGQILogger](xref:GQI_IGQILogger) | Object that can be used to log messages and exceptions. Available from DataMiner 10.4.5/10.5.0 onwards. |
