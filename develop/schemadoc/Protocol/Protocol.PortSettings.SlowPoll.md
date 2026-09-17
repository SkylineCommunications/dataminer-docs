---
metadata_version: 1
uid: Protocol.PortSettings.SlowPoll
description: "Reference the DataMiner connector protocol schema entry for SlowPoll element, including its documented structure, attributes, values, and constraints."
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

# SlowPoll element

Specifies the slow poll configuration.

## Parent

[PortSettings](xref:Protocol.PortSettings)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[DefaultValue](xref:Protocol.PortSettings.SlowPoll.DefaultValue)|[0, 1]|Specifies the default slow poll settings.|
|&nbsp;&nbsp;[Disabled](xref:Protocol.PortSettings.SlowPoll.Disabled)|[0, 1]|Specifies whether the slow poll settings can be modified in the DataMiner user interface.|

## Remarks

> [!NOTE]
> Only applicable for the main connection.