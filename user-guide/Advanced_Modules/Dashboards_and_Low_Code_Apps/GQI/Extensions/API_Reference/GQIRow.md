---
uid: GQIRow
---

# GQIRow

The *GQIRow* object has the following properties:

| Property | Type | Required | Description |
|--|--|--|--|
| Cells | GQICell[] | Yes | The cells of the row. |
| Key | String | No | The identifier of the row within its data source (introduced in DataMiner 10.3.5/10.4.0<!-- RN 35999 -->). This key must be unique (per data source) and cannot be null or empty. The same data should always have the same key. |

> [!NOTE]
> From DataMiner 10.3.5/10.4.0 onwards<!-- RN 35999 -->, a row key based on the row index will automatically be assigned when the row appears in a query result. Since this row key depends on the number of rows that came before it, it will not be available in the ad hoc data source.