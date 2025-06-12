---
uid: GQI_IGQIOnPrepareFetch
---

# IGQIOnPrepareFetch interface

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface`
- Assembly: `SLAnalyticsTypes.dll`

The *IGQIOnPrepareFetch* interface is triggered once before any data pages are fetched. It provides an opportunity to perform initial setup, such as calling external endpoints to retrieve or prepare data, ensuring that all necessary information is available when the `GetNextPage` life cycle event is invoked.

## Methods

### OnPrepareFetchOutputArgs OnPrepareFetch(OnPrepareFetchInputArgs args)

Indicates that the GQI has processed the query.
