---
uid: GQIColumn
---

# GQIColumn

The *GQIColumn* object is an abstract class, with the derived types *GQIStringColumn*, *GQIBooleanColumn*, *GQIIntColumn*, *GQIDateTimeColumn*, *GQIDoubleColumn*, and (from DataMiner 10.3.9/10.4.0 onwards<!-- RN 36717 -->) *GQITimeSpanColumn*, and with the following properties:

| Property | Type | Required | Description |
|--|--|--|--|
| Name | String | Yes | The column name. |
| Type | GQIColumnType | Yes | The type of data in the column. *GQIColumnType* is an enum that contains the following values: String, Int, DateTime, Boolean, Double, or TimeSpan. |
