---
uid: Protocol.Params.Param.Interprete.Bits
---

# Bits element

Used when a group of multiple bytes has been defined, but only a couple of bits are used from each byte.

## Type

unsignedInt

## Parent

[Interprete](xref:Protocol.Params.Param.Interprete)

## Remarks

For example, when only the lower 4 bits are used from each byte, a group can be defined with the Protocol.Params.Param.Interprete.Bits tag set to 4. When a Read Bit Parameter of 8 bits is assigned to that group, 4 lower bits of 2 bytes will be taken instead of 1 complete byte.

## Examples

```xml
<Bits>4</Bits>
```
