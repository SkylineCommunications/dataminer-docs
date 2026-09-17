---
metadata_version: 1
uid: Protocol.Groups.Group.Content.Param
description: "Reference the DataMiner connector protocol schema entry for Param element, including its documented structure, attributes, values, and constraints."
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

# Param element

Specifies the ID of a parameter to be included in the group.

## Type

[TypeGroupParamId](xref:Protocol-TypeGroupParamId)

## Parent

[Content](xref:Protocol.Groups.Group.Content)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[next](xref:Protocol.Groups.Group.Content.Param-next)|unsignedInt||Specifies the number of milliseconds DataMiner has to wait before reading the next parameter.|

## Examples

```xml
<Param>25</Param>
```
