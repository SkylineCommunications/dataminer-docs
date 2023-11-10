---
uid: GQI_IGQIOnDestroy
---

# IGQIOnDestroy Interface

## Definition

Namespace: `Skyline.DataMiner.Analytics.GenericInterface`  
Assembly: `SLAnalyticsTypes.dll`

The *IGQIOnDestroy* interface is called when the instance object is destroyed, which happens when the session is closed, e.g. in case of inactivity or when all the necessary data has been retrieved. It can for instance be used to end the connection with a database.

> [!TIP]
> See also: [IGQIOnInit](xref:GQI_IGQIOnInit)

## Methods

### OnDestroyOutputArgs OnDestroy(OnDestroyInputArgs args)

This method is emitted when the data source or custom operator won't be used anymore. It can safely be destroyed.

