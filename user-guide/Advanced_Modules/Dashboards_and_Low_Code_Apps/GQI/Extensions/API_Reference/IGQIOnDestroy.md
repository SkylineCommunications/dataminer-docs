---
uid: GQI_IGQIOnDestroy
---

# IGQIOnDestroy Interface

## Definition

Namespace: `Skyline.DataMiner.Analytics.GenericInterface`  
Assembly: `SLAnalyticsTypes.dll`

The *IGQIOnDestroy* interface can be implemented for an Ad Hoc data source or Custom Operator to clean up resources after it has been used. It can, for instance, be used to close a database connection.

> [!TIP]
> See also: [IGQIOnInit](xref:GQI_IGQIOnInit)

## Methods

### OnDestroyOutputArgs OnDestroy(OnDestroyInputArgs args)

This method is invoked when the data source or custom operator instance won't be used anymore. It can be implemented to clean up or dispose of any resources the instance may hold.

> [!TIP]
> Learn more about when this method is called within an [Ad Hoc data source](xref:Ad_hoc_Life_cycle) or [custom operator](xref:CO_Life_cycle).
