---
uid: Protocol.Params.Param.Interprete.ByteOffset
---

# ByteOffset element

Specifies the byte offset.

## Type

unsignedInt

## Parent

[Interprete](xref:Protocol.Params.Param.Interprete)

## Remarks

Each incoming byte of a group containing this tag will be decremented with the specified byte offset, while each outgoing byte of the group will be incremented with the specified byte offset.

## Examples

```xml
<ByteOffset>40</ByteOffset>
```
