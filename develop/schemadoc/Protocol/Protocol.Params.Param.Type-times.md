---
metadata_version: 1
uid: Protocol.Params.Param.Type-times
description: "Reference the DataMiner connector protocol schema entry for times attribute, including its documented structure, attributes, values, and constraints."
content_type: schema
applies_to:
  - DataMiner
---

# times attribute

If Type is “trailer”, this attribute indicates how many times the trailer is allowed to occur before it is considered to be the trailer.

## Content Type

unsignedInt

## Parent

[Type](xref:Protocol.Params.Param.Type)

## Examples


```xml
<Type times="4">trailer</Type>
```



