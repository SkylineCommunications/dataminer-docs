---
metadata_version: 1
uid: Protocol.PortSettings.Retries
description: "Reference the DataMiner connector protocol schema entry for Retries element, including its documented structure, attributes, values, and constraints."
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

# Retries element

Configures the number of retries.

## Parent

[PortSettings](xref:Protocol.PortSettings)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[DefaultValue](xref:Protocol.PortSettings.Retries.DefaultValue)|[0, 1]|Specifies the default value for the maximum number of times that a request will be re-sent.|
|&nbsp;&nbsp;[Disabled](xref:Protocol.PortSettings.Retries.Disabled)|[0, 1]|Specifies whether the maximum number of retries can be modified in the DataMiner user interface.|
