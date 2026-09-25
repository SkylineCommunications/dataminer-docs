---
metadata_version: 1
uid: Protocol.Params.Param.Interprete.Value
description: "Learn how the Value element sets the fixed content of a parameter that uses a fixed length and value in a DataMiner connector protocol."
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
