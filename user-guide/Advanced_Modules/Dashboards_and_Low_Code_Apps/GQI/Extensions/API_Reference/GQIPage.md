---
uid: GQI_GQIPage
---

# GQIPage class

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface`
- Assembly: `SLAnalyticsTypes.dll`

Represents a single page of rows. Every query result consists of one or more such pages.

## Properties

| Property | Type | Required | Description |
| -------- | ---- | -------- | ----------- |
| Rows | [GQIRow](xref:GQI_GQIRow)[] | Yes | Rows of the page. |
| HasNextPage | boolean  | No | `true` if there are more pages that GQI can fetch, otherwise 'false' (default). |

> [!TIP]
> Learn how `HasNextPage` can be used to apply paged data retrieval through following example: [paged data retrieval example](xref:GQI_IGQIDataSource#paged-data-retrieval)