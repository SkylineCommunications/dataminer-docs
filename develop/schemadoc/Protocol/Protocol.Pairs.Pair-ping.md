---
uid: Protocol.Pairs.Pair-ping
---

# ping attribute

If set to true, the pair will be executed when the device is in timeout and slow polling is activated.

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[Pair](xref:Protocol.Pairs.Pair)

## Remarks

> [!NOTE]
> This option cannot be used in protocols of type SNMP or OPC.

## Examples

```xml
<Pair id="1" ping="true">
```
