---
metadata_version: 1
uid: Protocol.Params.Param.Interprete.ByteOffset
description: "Learn how the ByteOffset element subtracts an offset from incoming bytes and adds it to outgoing bytes in a group in a DataMiner connector protocol."
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
