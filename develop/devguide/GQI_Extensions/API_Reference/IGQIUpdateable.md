---
uid: GQI_IGQIUpdateable
---

# IGQIUpdateable interface

Available from DataMiner 10.4.4/10.5.0 onwards<!-- RN 38643 -->.

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface`
- Assembly: `SLAnalyticsTypes.dll`

The *IGQIUpdateable* interface can be implemented by an ad hoc data source class to provide real-time updates.

It defines a method pair, [OnStartUpdates](#void-onstartupdatesigqiupdater) and [OnStopUpdates](#void-onstopupdates), to respectively implement setup and teardown logic.

## Methods

### void OnStartUpdates(IGQIUpdater)

This method is invoked on an ad hoc data source when it is allowed to start publishing updates. It can for example be used to set up subscriptions or event handlers that trigger updates.

In the [ad hoc data source lifecycle](xref:Ad_hoc_Life_cycle#onstartupdates), it is called after [OnPrepareFetch](xref:GQI_IGQIOnPrepareFetch#onpreparefetchoutputargs-onpreparefetchonpreparefetchinputargs-args) and before any [GetNextPage](xref:GQI_IGQIDataSource#gqipage-getnextpagegetnextpageinputargs-args) calls.

> [!NOTE]
> This method will only be called if [updates are enabled](xref:Query_updates#enabling-updates) for the containing query and when that query [can handle](xref:Query_updates#query-update-support) the updates. That way no resources are wasted.

#### Parameters

- [IGQIUpdater](xref:GQI_IGQIUpdater) `updater`: An object on which an ad hoc data source can publish updates.

### void OnStopUpdates()

This method is invoked on an ad hoc data source when it should stop publishing updates. It can for example be used to clean up any subscriptions or event handlers that were set up during the [OnStartUpdates](#void-onstartupdatesigqiupdater) method.

In the [ad hoc data source lifecycle](xref:Ad_hoc_Life_cycle#onstopupdates), it is called after the last [GetNextPage](xref:GQI_IGQIDataSource#gqipage-getnextpagegetnextpageinputargs-args) call and right before [OnDestroy](xref:GQI_IGQIOnDestroy##ondestroyoutputargs-ondestroyondestroyinputargs-args).
