---
uid: Protocol.Params.Param.Interprete.StartPosition
---

# StartPosition element

Specifies the start bit in the group to which the parameter refers to in case the parameter is of type "read/write bits".

## Type

unsignedInt

## Parent

[Interprete](xref:Protocol.Params.Param.Interprete)

## Remarks

- When retrieving an SNMP parameter of type integer, a StartPosition 0 will be the most significant bit of the least significant byte.
- Using big endian, the StartPosition 0 is the most significant bit.
- When retrieving a serial response with rawType unsigned number, it is the most significant bit since the bytes are actually reversed by DataMiner.

For example, if the device responds with 0100 (256) and you display the group parameter, it will show 1 instead of 256. If you use big endian, the parameter will display 256. But then StartPosition will be like in the case of an SNMP parameter (i.e., 0 being the most significant bit of the least significant byte).

Using big endian, the StartPosition 0 is the most significant bit of the least significant byte.

## Examples

```xml
<StartPosition>14</StartPosition>
```
