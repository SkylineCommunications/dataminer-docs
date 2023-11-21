---
uid: GQI_IGQIDataSource
---

# IGQIDataSource interface

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface`
- Assembly: `SLAnalyticsTypes.dll`

Implementing this interface marks the class as a GQI data source.

> [!NOTE]
> The *IGQIDataSource* interface is the only required interface to identify a class as a GQI data source.

## Methods

### GQIColumn[] GetColumns()

The GQI will request the columns.

#### Returns

The columns available in the data source.

### GQIPage GetNextPage(GetNextPageInputArgs args)

The GQI will request data.

#### Returns

A [GQIPage](xref:GQI_GQIPage) with the data.
