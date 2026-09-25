---
metadata_version: 1
uid: Protocol.Params.Param.CRC.Type-mod
description: "Learn how to use the mod attribute to apply a modulo operation after DataMiner calculates a CRC in a DataMiner connector protocol."
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
