---
uid: GQI_GQIRow
---

# GQIRow class

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface`
- Assembly: `SLAnalyticsTypes.dll`

Represents a row from a query result.

## Constructors

### GQIRow(GQICell[] cells)

Creates a new row with the provided cells.

#### Parameters

- [GQICell](xref:GQI_GQICell)[] `cells`: The cells of this row.

> [!NOTE]
> A row key based on the row index will automatically be assigned when the row appears in a query result.
>
> Since this row key depends on the number of rows that came before it, it will not be available in the ad hoc data source. The value of the [Key](#properties) property will be `null`.

### GQIRow(string key, GQICell[] cells)

Creates a new row with a specified row key and the provided cells.

#### Parameters

- [GQICell](xref:GQI_GQICell)[] `cells`: The cells of this row.
- `string` `key`: Identifier of the row within its data source.

> [!NOTE]
> From DataMiner 10.3.5/10.4.0 onwards<!-- RN 35999 -->, a row key based on the row index will automatically be assigned when the row appears in a query result. Since this row key depends on the number of rows that came before it, it will not be available in the ad hoc data source.

> [!IMPORTANT]
> The row key should meet all of the following requirements:
>
> 1. It must not be `null` or the empty string.
> 1. It must be unique within the data source.
> 1. It must be deterministic, meaning that the same data should always have the same key.

## Properties

| Property | Type | Description |
| -------- | ---- | ----------- |
| Key | `string` | Unique identifier of the row within the query result. |
| Cells | [GQICell](xref:GQI_GQICell)[] | Cells of the row. |
| Metadata | [GenIfRowMetadata](xref:GQI_GenIfRowMetadata) | Extra information to aid clients in interpreting the row. Available from DataMiner 10.4.0/10.4.1 onwards. |
