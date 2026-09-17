---
metadata_version: 1
uid: Protocol.PortSettings.SlowPollBase
description: "Reference the DataMiner connector protocol schema entry for SlowPollBase element, including its documented structure, attributes, values, and constraints."
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

# SlowPollBase element

Specifies the slow poll base settings.

## Parent

[PortSettings](xref:Protocol.PortSettings)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[DefaultValue](xref:Protocol.PortSettings.SlowPollBase.DefaultValue)|[0, 1]|Specifies the default slow poll base.|
|&nbsp;&nbsp;[Disabled](xref:Protocol.PortSettings.SlowPollBase.Disabled)|[0, 1]|Specifies whether the slow poll settings can be modified in the DataMiner user interface.|
|&nbsp;&nbsp;[Value](xref:Protocol.PortSettings.SlowPollBase.Value)|[0, 1]|Using one or more Value tags, you can specify the different values that users are allowed to enter.|

## Remarks

> [!NOTE]
> Only applicable for the main connection.
