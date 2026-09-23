---
metadata_version: 1
uid: Protocol.Params.Param.CRC.Type-byteoffset
description: "Reference the DataMiner connector protocol schema entry for byteoffset attribute, including its documented structure, attributes, values, and constraints."
content_type: schema
applies_to:
  - DataMiner
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
