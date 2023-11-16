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
| HasNextPage | boolean  | No | `True` if GQI can fetch additional pages, `False` if the current page is the last page. |
