---
metadata_version: 1
uid: Protocol.Params.Param.Interprete.ByteOffset
description: "Reference the DataMiner connector protocol schema entry for ByteOffset element, including its documented structure, attributes, values, and constraints."
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

# ByteOffset element

Specifies the byte offset.

## Type

unsignedInt

## Parent

[Interprete](xref:Protocol.Params.Param.Interprete)

## Remarks

Each incoming byte of a group containing this tag will be decremented with the specified byte offset, while each outgoing byte of the group will be incremented with the specified byte offset.

## Examples

```xml
<ByteOffset>40</ByteOffset>
```
