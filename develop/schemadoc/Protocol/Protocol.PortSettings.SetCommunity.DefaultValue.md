---
uid: Protocol.PortSettings.SetCommunity.DefaultValue
---

# DefaultValue element

Specifies the default value of the SNMP set community string that will be used in the DataMiner user interface for SNMP connectors.

## Type

string

## Parent

[SetCommunity](xref:Protocol.PortSettings.SetCommunity)

## Remarks

By default, the value is "private".

> [!NOTE]
> For an SNMPv3 connection, this tag can be used to specify the default encryption password.

## Examples

```xml
<SetCommunity>
    <DefaultValue>private</DefaultValue>
</SetCommunity>
```
