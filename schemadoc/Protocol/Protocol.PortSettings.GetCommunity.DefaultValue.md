---
uid: Protocol.PortSettings.GetCommunity.DefaultValue
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
