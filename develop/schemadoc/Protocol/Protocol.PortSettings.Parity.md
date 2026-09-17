---
metadata_version: 1
uid: Protocol.PortSettings.Parity
description: "Reference the DataMiner connector protocol schema entry for Parity element, including its documented structure, attributes, values, and constraints."
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

# Parity element

Allows to limit parity settings and to define a default value.

## Parent

[PortSettings](xref:Protocol.PortSettings)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***Sequence***|||
|&nbsp;&nbsp;[DefaultValue](xref:Protocol.PortSettings.Parity.DefaultValue)|[0, 1]|Specifies the default parity.|
|&nbsp;&nbsp;[Disabled](xref:Protocol.PortSettings.Parity.Disabled)|[0, 1]|Specifies whether the parity can be modified in the DataMiner user interface.|
|&nbsp;&nbsp;[Range](xref:Protocol.PortSettings.Parity.Range)|[0, 1]|Defines the range of possible parity values.|
|&nbsp;&nbsp;[Value](xref:Protocol.PortSettings.Parity.Value)|[0, *]|Specifies a supported parity setting.|
