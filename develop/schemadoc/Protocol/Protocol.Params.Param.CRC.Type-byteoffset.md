---
metadata_version: 1
uid: Protocol.Params.Param.CRC.Type-byteoffset
description: "Learn how to use the byteoffset attribute to add an offset to every byte before DataMiner calculates a CRC in a DataMiner connector protocol."
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
