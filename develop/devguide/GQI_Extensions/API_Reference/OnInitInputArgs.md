---
uid: GQI_OnInitInputArgs
---

# OnInitInputArgs class

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface`
- Assembly: `SLAnalyticsTypes.dll`

Contains functionality and general query information for ad hoc data sources and custom operators. An instance is provided through the `OnInit` lifecycle method of the [IGQIOnInit building block](xref:GQI_IGQIOnInit).

## Properties

| Property | Type | Description |
|----------|------|-------------|
| DMS | [GQIDMS](xref:GQI_GQIDMS) | Object that can be used to interact with the DMS.<!-- RN 35701 --> |
| Logger | [IGQILogger](xref:GQI_IGQILogger) | Object that can be used to log messages and exceptions.<br>Available from DataMiner 10.4.5/10.5.0 onwards. |
| Factory | [IGQIFactory](xref:GQI_IGQIFactory) | Object with methods to create other objects that can be used to interact with the core GQI framework.<br>Available from DataMiner 10.4.0/10.4.1 onwards.<!-- RN 37806 --> |
| Session | [IGQISession](xref:GQI_IGQISession) | Object with extra information regarding the current GQI session.<br>Available from DataMiner 10.6.3/10.5.0 CU12/10.6.0 onwards.<!-- RN 44509 --> |