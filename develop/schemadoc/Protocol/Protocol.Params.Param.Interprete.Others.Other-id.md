---
metadata_version: 1
uid: Protocol.Params.Param.Interprete.Others.Other-id
description: "Learn how the id attribute references the parameter used to match an incoming symbol with an Other definition in a DataMiner connector protocol."
---

# id attribute

Specifies the ID of the parameter to which the incoming symbol will be compared with.

## Content Type

[TypeParamId](xref:Protocol-TypeParamId)

## Parent

[Other](xref:Protocol.Params.Param.Interprete.Others.Other)

## Remarks

If the incoming symbol matches the referred parameter, the contents of the Protocol.Params.Param.Interprete.Others.Other.Display tag will be shown.

## Examples

```xml
<Other id="1115">
```
