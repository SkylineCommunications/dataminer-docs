---
uid: GQI_GQICell
---

# GQICell class

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface`
- Assembly: `SLAnalyticsTypes.dll`

## Definition

Represents a single cell in a [GQIRow](xref:GQI_GQIRow).

## Properties

| Property | Type | Required | Description |
|--|--|--|--|
| Value | Object | No | The value of the cell. |
| DisplayValue | String | No | The display value of the cell. |

> [!NOTE]
>
> - Empty cells, i.e., cells without value, are allowed.
> - The DisplayValue will override the value displayed in the UI only when the value is not empty.

> [!IMPORTANT]
> The type of the value of a cell should match the type of the corresponding column.
