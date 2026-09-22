---
metadata_version: 1
uid: Protocol.Params.Param.CRC.Type-mod
description: "Reference the DataMiner connector protocol schema entry for mod attribute, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# mod attribute

Specifies that a modulo operation has to be performed on the CRC after it has been calculated.

## Content Type

unsignedInt

## Parent

[Type](xref:Protocol.Params.Param.CRC.Type)

## Examples

```xml
<Param>
	<CRC>
		<Type mod="95">
        ...
```
