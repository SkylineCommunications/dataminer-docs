---
metadata_version: 1
uid: Protocol.PortSettings.GetCommunity.DefaultValue
description: "Reference the DataMiner connector protocol schema entry for DefaultValue element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
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
