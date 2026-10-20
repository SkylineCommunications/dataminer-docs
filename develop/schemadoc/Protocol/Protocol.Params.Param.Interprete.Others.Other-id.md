---
uid: Protocol.Params.Param.Interprete.Others.Other-id
description: "Use the id attribute in a DataMiner protocol to reference the parameter used to match an incoming symbol with an Other definition."
---

# id attribute

Specifies the ID of the parameter that the incoming symbol will be compared with.

## Content Type

[TypeParamId](xref:Protocol-TypeParamId)

## Parent

[Other](xref:Protocol.Params.Param.Interprete.Others.Other)

## Remarks

If the incoming symbol matches the referred parameter, the contents of the `Protocol.Params.Param.Interprete.Others.Other.Display` tag will be shown.

## Examples

```xml
<Other id="1115">
```
