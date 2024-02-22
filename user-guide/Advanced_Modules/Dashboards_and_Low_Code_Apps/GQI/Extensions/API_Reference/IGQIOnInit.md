---
uid: GQI_IGQIOnInit
---

# IGQIOnInit interface

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface`
- Assembly: `SLAnalyticsTypes.dll`

The *IGQIOnInit* interface can be implemented for an ad hoc data source to get notified, through the `OnInit` method, when the data source is created. It can, for instance, be used to set up a connection to a database.

> [!TIP]
> See also: [IGQIOnDestroy](xref:GQI_IGQIOnDestroy)

## Methods

### OnInitOutputArgs OnInit(OnInitInputArgs args)

Indicates that an instance of the class has been created.

> [!TIP]
> Learn more about when this method is called within an [ad hoc data source](xref:Ad_hoc_Life_cycle).

#### Parameters

- [OnInitInputArgs](xref:GQI_OnInitInputArgs) `args`.
