---
uid: GQI_ObjectRefMetadata
---

# ObjectRefMetadata class

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface`
- Assembly: `SLAnalyticsTypes.dll`

Represents a link to a DataMiner object for a [GQIRow](xref:GQI_GQIRow).

Inherits from [RowMetadataBase](xref:GQI_RowMetadataBase).

## Properties

| Name | Type | Description |
| ---- | ---- | ----------- |
| Object | [DMAObjectRef](#dmaobjectref) | A type-specific reference to the DataMiner object. |

## DMAObjectRef

`DMAObjectRef` is an abstract base class for all types representing a reference to a specific DataMiner object.

> [!IMPORTANT]
> `DMAObjectRef` and its derived classes are part of a different namespace and assembly.
>
> - Namespace: `Skyline.DataMiner.Net`
> - Assembly: `SLNetTypes.dll`

The following derived classes are currently supported:

- AlarmID
- DomInstanceId
- ElementID
- PaProcessObjectRef
- ParamID
- PaTokenObjectRef
- ProfileInstanceID
- ReservationInstanceID
- ResourceID
- ResourcePoolID
- ServiceID
- ViewID
