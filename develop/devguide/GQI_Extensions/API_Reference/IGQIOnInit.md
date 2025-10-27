---
uid: GQI_IGQIOnInit
---

# IGQIOnInit interface

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface`
- Assembly: `SLAnalyticsTypes.dll`

The *IGQIOnInit* interface allows you to receive a notification via the `OnInit` method when an ad hoc data source or custom operator is instantiated. The `OnInitInputArgs` parameter provides access to additional resources during initialization.

> [!IMPORTANT]
> This lifecycle event is triggered not only when data is being fetched, but also when columns are retrieved or queries are built. Avoid performing data retrieval or slow operations in this event, as it can negatively affect the performance of your ad hoc data source or custom operator.

> [!TIP]
> See also: [IGQIOnDestroy](xref:GQI_IGQIOnDestroy)

## Methods

### OnInitOutputArgs OnInit(OnInitInputArgs args)

Indicates that an instance of the class has been created.

> [!TIP]
> Learn more about when this method is called within an [ad hoc data source](xref:Ad_hoc_Life_cycle#oninit) or [custom operator](xref:CO_Life_cycle#oninit).

#### Parameters

- [OnInitInputArgs](xref:GQI_OnInitInputArgs) `args`.
