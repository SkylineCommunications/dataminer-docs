---
uid: GQI_GQIDMS
---

# GQIDMS class

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface`
- Assembly: `SLAnalyticsTypes.dll`

Represents the DataMiner System (DMS). Can be used to request information from the system or subscribe on events. Communication happens through [DMSMessage objects](xref:Skyline.DataMiner.Net.Messages).

Available from DataMiner 10.3.4/10.4.0 onwards.<!-- RN 35701 -->

> [!NOTE]
> The `GQIDMS` class itself cannot be used for constructor injection. From DataMiner 10.5.0 [CU18]/10.6.0 [CU6]/10.6.9 onwards<!-- RN 45635 -->, when using the `Skyline.DataMiner.Core.GQI.Extensions` API and the [GQI DxM](xref:GQI_DxM), use [IGQIDMSInterface](xref:GQI_IGQIDMSInterface) to inject DMS access via the constructor. In earlier versions, use the [DMS](xref:GQI_OnInitInputArgs#properties) property of [OnInitInputArgs](xref:GQI_OnInitInputArgs).

> [!TIP]
> See also:
>
> - [Retrieving data from DataMiner](xref:GQI_Extensions_Retrieving_Data_From_DataMiner)
> - [Building a GQI data source that retrieves data from a DMS](xref:Ad_hoc_Tutorials_Interact_With_DMS)

## Methods

The `GQIDMS` class contains the methods listed below. These can be used to request information in the form of `DMSMessage` objects.

> [!IMPORTANT]
> DMS messages are subject to change without notice. If you can implement an alternative using the [built-in data sources](xref:Query_data_sources), we highly recommend that you do so instead.

### IConnection GetConnection()

Available from DataMiner 10.4.6/10.5.0 onwards.<!-- RN39489 -->

Provides a connection interface from GQI to SLNet. This connection can be used to request data from the DMS or to subscribe on events.

#### Returns

An [IConnection](xref:Skyline.DataMiner.Net.IConnection) object representing the connection between GQI and SLNet.

> [!TIP]
> Because of its complexity, instead of interacting directly with the IConnection interface, the best way you can use it is by integrating with existing DataMiner libraries.

> [!NOTE]
> The real underlying connection may be shared by other extensions and queries but can be used as if it were a dedicated connection.

> [!IMPORTANT]
> `GQIDMS` can only be used during the lifetime of the associated extension instance. Do not store or reuse it outside that lifetime.

> [!NOTE]
> From DataMiner 10.5.0 [CU18]/10.6.0 [CU6]/10.6.9 onwards<!-- RN 45635 -->, when using the GQI DxM, `GetConnection()` can be called again to receive a fresh connection if the underlying SLNet connection was dropped.

### DMSMessage SendMessage(DMSMessage message)

Sends one request to retrieve one response from the DMS.

This is a shortcut for [SendMessages](#dmsmessage-sendmessagesparams-dmsmessage-message).

#### Parameters

- `DMSMessage` `message`: The request message for the DMS.

#### Returns

A single response from the DMS or `null`. If the DMS replied with more than 1 response, the first one will be returned.

### DMSMessage[] SendMessages(params DMSMessage[] message)

Sends one or more messages to retrieve multiple responses from the DMS.

#### Parameters

- `DMSMessage[]` `messages`: The request messages for the DMS.

#### Returns

A `DMSMessage` array of all responses from the DMS.
