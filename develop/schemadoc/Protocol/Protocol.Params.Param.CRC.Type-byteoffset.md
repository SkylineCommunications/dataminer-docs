---
metadata_version: 1
uid: Protocol.Params.Param.CRC.Type-byteoffset
description: "Reference the DataMiner connector protocol schema entry for byteoffset attribute, including its documented structure, attributes, values, and constraints."
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

# byteoffset attribute

Allows to add an offset to every single byte of the CRC.

## Content Type

int

## Parent

[Type](xref:Protocol.Params.Param.CRC.Type)

## Remarks

Can be used in combination with all possible CRC types.

## Examples

```xml
<Param>
	<CRC>
		<Type byteoffset="2">
```
