---
uid: Protocol.PortSettings.GetCommunity.DefaultValue
description: "Use the DefaultValue element in a DataMiner protocol to set the default SNMP get community string or SNMPv3 authentication password."
---

# DefaultValue element

Specifies the default value of the GetCommunity string that will be used in the DataMiner user interface for SNMP protocols.

## Type

string

## Parent

[GetCommunity](xref:Protocol.PortSettings.GetCommunity)

## Remarks

By default this value is public.

> [!NOTE]
> For an SNMPv3 connection, this tag can be used to specify the default authentication password.

## Examples

```xml
<GetCommunity>
    <DefaultValue>public</DefaultValue>
</GetCommunity>
```
