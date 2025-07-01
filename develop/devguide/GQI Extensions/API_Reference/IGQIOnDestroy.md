---
uid: GQI_IGQIOnDestroy
---

# IGQIOnDestroy interface

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface`
- Assembly: `SLAnalyticsTypes.dll`

The *IGQIOnDestroy* interface can be implemented for an ad hoc data source or custom operator to clean up resources after it has been used. It can, for instance, be used to close a database connection.

> [!TIP]
> See also: [IGQIOnInit](xref:GQI_IGQIOnInit)

## Methods

### OnDestroyOutputArgs OnDestroy(OnDestroyInputArgs args)

This method is invoked when the data source instance will no longer be used. It can be implemented to clean up or dispose of any resources the instance may hold.

> [!TIP]
> Learn more about when this method is called within an [ad hoc data source](xref:Ad_hoc_Life_cycle#ondestroy) or [custom operator](xref:CO_Life_cycle#ondestroy).
