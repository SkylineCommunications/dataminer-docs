---
uid: Protocol.PortSettings.PingInterval.DefaultValue
description: "Use the DefaultValue element in a DataMiner protocol to set the default ping interval in milliseconds for an element connection."
---

# DefaultValue element

Specifies the default ping interval.

## Type

[TypePingInterval](xref:Protocol-TypePingInterval)

## Parent

[PingInterval](xref:Protocol.PortSettings.PingInterval)

## Remarks

The value is a number of milliseconds.

The value must be in the range [1000,300000]. The value should be a multiple of 1000 as the resolution is in seconds.

## Examples

```xml
<PingInterval>
   <DefaultValue>10000</DefaultValue>
</PingInterval>
```
