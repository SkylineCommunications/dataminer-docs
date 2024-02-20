---
uid: GQI_GQIColumn
---

# GQIColumn class

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface`
- Assembly: `SLAnalyticsTypes.dll`

Provides the base class for a column in GQI.

> [!NOTE]
> This is an abstract base class. To create a new column, use one of the [derived types](xref:GQI_GQIColumnT#derived-types) provided by the framework.

> [!TIP]
> Use the generic [GQIColumn\<T\>](xref:GQI_GQIColumnT) equivalent whenever possible. It provides better type safety when getting or setting cell values.

## Derived types

- [GQIColumn\<T\>](xref:GQI_GQIColumnT)

## Properties

| Property | Type | Required | Description |
|--|--|--|--|
| Name | String | Yes | The column name. |
| Type | GQIColumnType | Yes | The type of data in the column. *GQIColumnType* is an enum that contains the following values: String, Int, DateTime, Boolean, Double, or TimeSpan. |
