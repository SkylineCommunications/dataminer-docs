---
uid: GQI_IGQIDMSInterface
---

# IGQIDMSInterface interface

## Definition

- Namespace: `Skyline.DataMiner.Core.GQI.Extensions`
- Assembly: `Skyline.DataMiner.Core.GQI.Extensions.dll`

Provides access to the DataMiner System (DMS).

Available from DataMiner 10.5.0 [CU18]/10.6.0 [CU6]/10.6.9 onwards.<!-- RN 45635 -->

This type can be used to inject DMS access via the constructor of a GQI extension or user-scoped GQI service when using the [GQI DxM](xref:GQI_DxM).

> [!TIP]
> See also:
>
> - [GQIDMS](xref:GQI_GQIDMS)
> - [Retrieving data from DataMiner](xref:GQI_Extensions_Retrieving_Data_From_DataMiner)

## Methods

### IConnection GetConnection()

Gets a live [IConnection](xref:Skyline.DataMiner.Net.IConnection) to the DataMiner System.

> [!NOTE]
> `GetConnection()` can be called again to receive a fresh connection if the underlying SLNet connection was dropped.

#### Returns

A usable connection to the DataMiner System.

### DMSMessage[] SendMessages(params DMSMessage[] messages)

Sends one or more [DMSMessage](xref:Skyline.DataMiner.Net.Messages) objects to retrieve responses from the DMS.

#### Parameters

- `DMSMessage[]` `messages`: The request messages for the DMS.

#### Returns

A `DMSMessage` array of all responses from the DMS.
