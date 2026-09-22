---
metadata_version: 1
uid: Protocol.Params.Param.Interprete.Value
description: "Reference the DataMiner connector protocol schema entry for Value element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# Value element

In case of a parameter with a fixed length and a fixed value, set the Protocol.Params.Param.Interprete.LengthType tag to “fixed” and use this Value tag to specify the fixed value.

## Type

string

## Parent

[Interprete](xref:Protocol.Params.Param.Interprete)

## Examples


```xml
<Interprete>
	...
	<LengthType>fixed</LengthType>
	<Value>abc</Value>
	...
</Interprete>
```
