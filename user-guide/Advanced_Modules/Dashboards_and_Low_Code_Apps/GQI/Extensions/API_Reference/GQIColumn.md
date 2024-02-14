---
uid: GQI_GQIColumn
---

# GQIColumn class

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface`
- Assembly: `SLAnalyticsTypes.dll`

Provides the base class for a column in GQI.

## Derived types

The *GQIColumn* object is an abstract class, with the following derived types:

- `GQIBooleanColumn`
- `GQIDateTimeColumn`
- `GQIDoubleColumn`
- `GQIIntColumn`
- `GQIStringColumn`
- `GQITimeSpanColumn` (from DataMiner 10.3.9/10.4.0 onwards<!-- RN 36717 -->)

## Properties

| Property | Type | Required | Description |
|--|--|--|--|
| Name | String | Yes | The column name. |
| Type | GQIColumnType | Yes | The type of data in the column. *GQIColumnType* is an enum that contains the following values: String, Int, DateTime, Boolean, Double, or TimeSpan. |
