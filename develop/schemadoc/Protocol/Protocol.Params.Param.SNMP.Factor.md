---
uid: Protocol.Params.Param.SNMP.Factor
---

# Factor element

Specifies that all values will be divided by the specified factor.

## Type

unsignedInt

## Parent

[SNMP](xref:Protocol.Params.Param.SNMP)

## Remarks

By default, SNMP does not support decimal values. In a DataMiner protocol, however, you can use this Factor element to produce decimal values.

If you specify a factor, all values will be divided by that factor. For example, if you specify a factor 10, all values will be divided by 10. “1”, for instance, will then become “0.1”.

Default factor: 1

## Examples

```xml
<Factor>10</Factor>
```
