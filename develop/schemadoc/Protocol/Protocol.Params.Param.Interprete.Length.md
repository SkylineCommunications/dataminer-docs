---
uid: Protocol.Params.Param.Interprete.Length
description: "Use the Length element in a DataMiner protocol to set the exact byte length when a parameter uses a fixed length type."
---

# Length element

Specifies the exact length of the parameter (in bytes).

## Type

unsignedInt

## Parent

[Interprete](xref:Protocol.Params.Param.Interprete)

## Remarks

If you set `Protocol.Params.Param.Interprete.LengthType` to "fixed", use this element to specify the exact length of the parameter (in bytes).

## Examples

```xml
<Length>5</Length>
```
