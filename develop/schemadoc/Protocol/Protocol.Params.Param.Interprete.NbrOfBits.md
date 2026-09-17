---
metadata_version: 1
uid: Protocol.Params.Param.Interprete.NbrOfBits
description: "Reference the DataMiner connector protocol schema entry for NbrOfBits element, including its documented structure, attributes, values, and constraints."
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

# NbrOfBits element

Specifies the number of bits needed.

## Type

unsignedInt

## Parent

[Interprete](xref:Protocol.Params.Param.Interprete)

## Remarks

When this number exceeds the number of bits used in a byte, the Protocol.Params.Param.Interprete.Endian tag can be set to “big” to make DataMiner reverse the bits when processing them.

## Examples

```xml
<NbrOfBits>6</NbrOfBits>
```
