---
metadata_version: 1
uid: Protocol.Name
description: "Reference the DataMiner connector protocol schema entry for Name element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# Name element

Defines the name of the protocol.

## Type

[TypeNonEmptyString](xref:Protocol-TypeNonEmptyString)

## Parent

[Protocol](xref:Protocol)

## Remarks

This name, which must be unique, will be used throughout the DataMiner System to identify the protocol. Typically, it refers to an element (e.g., brand name, device type, etc.).



## Examples


```xml
<Name>Microsoft Platform</Name>
```



