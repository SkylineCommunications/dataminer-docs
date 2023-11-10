---
uid: GQI_IGQIOnInit
---

# IGQIOnInit Interface

## Definition

Namespace: `Skyline.DataMiner.Analytics.GenericInterface`  
Assembly: `SLAnalyticsTypes.dll`

The *IGQIOnInit* interface is called when the data source is initialized, for example when the data source is selected in the query builder or when a dashboard using a query with ad hoc data is opened. It can for instance be used to connect to a database.

> [!TIP]
> See also: [IGQIOnDestroy](xref:GQI_IGQIOnDestroy)

## Methods

### OnInitOutputArgs OnInit(OnInitInputArgs args)

Indicates that an instance of the class has been created.

#### Parameters

- [OnInitInputArgs](xref:GQI_OnInitInputArgs) `args`.