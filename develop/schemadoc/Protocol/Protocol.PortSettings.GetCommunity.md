---
metadata_version: 1
uid: Protocol.PortSettings.GetCommunity
description: "Reference the DataMiner connector protocol schema entry for GetCommunity element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
lifecycle: active
applies_to:
  - DataMiner
version: unknown
owner: unknown
review_status: needs_update
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
---

# GetCommunity element

Specifies the GetCommunity string of an SNMP connector.

## Parent

[PortSettings](xref:Protocol.PortSettings)

## Children

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[DefaultValue](xref:Protocol.PortSettings.GetCommunity.DefaultValue)|[0, 1]|Specifies the default value of the GetCommunity string that will be used in the DataMiner user interface for SNMP protocols.|
|&nbsp;&nbsp;[Disabled](xref:Protocol.PortSettings.GetCommunity.Disabled)|[0, 1]|Specifies whether the get community string can be modified in the DataMiner user interface.|

## Remarks

> [!NOTE]
> For an SNMPv3 connection, this tag can be used to specify the default authentication password.
