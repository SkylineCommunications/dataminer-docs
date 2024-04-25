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
| HasNextPage | boolean  | No | `true` if there are more pages that GQI can fetch, otherwise `false` (default). |

> [!TIP]
> When you are dealing with large amounts of data, we recommend spreading the data across multiple pages. For an example of how you can use the `HasNextPage` property to enable paged data retrieval, see [Paged data retrieval](xref:GQI_IGQIDataSource#paged-data-retrieval).
