---
uid: Protocol.Params.Param.Type-times
description: "Use the times attribute in a DataMiner protocol to set how many trailer occurrences are required before DataMiner recognizes the trailer."
---

# times attribute

If Type is "trailer", this attribute indicates how many times the trailer is allowed to occur before it is considered to be the trailer.

## Content Type

unsignedInt

## Parent

[Type](xref:Protocol.Params.Param.Type)

## Examples

```xml
<Type times="4">trailer</Type>
```
