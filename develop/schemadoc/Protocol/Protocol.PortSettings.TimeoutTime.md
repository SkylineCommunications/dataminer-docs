---
metadata_version: 1
uid: Protocol.PortSettings.TimeoutTime
description: "Reference the DataMiner connector protocol schema entry for TimeoutTime element, including its documented structure, attributes, values, and constraints."
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

# TimeoutTime element

Specifies settings related to the timeout of a command/request.

## Parent

[PortSettings](xref:Protocol.PortSettings)

## Children

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[DefaultValue](xref:Protocol.PortSettings.TimeoutTime.DefaultValue)|[0, 1]|Specifies the default timeout value.|
|&nbsp;&nbsp;[Disabled](xref:Protocol.PortSettings.TimeoutTime.Disabled)|[0, 1]|Specifies whether the timeout value can be modified in the DataMiner user interface.|
