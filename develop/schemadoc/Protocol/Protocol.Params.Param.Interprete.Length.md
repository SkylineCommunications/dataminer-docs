---
metadata_version: 1
uid: Protocol.Params.Param.Interprete.Length
description: "Learn how the Length element sets the exact byte length when a parameter uses a fixed length type in a DataMiner connector protocol."
---

# Length element

Specifies the exact length of the parameter (in bytes).

## Type

unsignedInt

## Parent

[Interprete](xref:Protocol.Params.Param.Interprete)

## Remarks

If you set Protocol.Params.Param.Interprete.LengthType to “fixed”, use this tag to specify the exact length of the parameter (in bytes).

## Examples

```xml
<Length>5</Length>
```
