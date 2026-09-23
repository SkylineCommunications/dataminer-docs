---
metadata_version: 1
uid: Protocol.PortSettings.GetCommunity.DefaultValue
description: "Learn how the DefaultValue element under GetCommunity sets the initial SNMP get community string or SNMPv3 authentication password."
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
