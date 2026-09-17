---
metadata_version: 1
uid: Protocol.PortSettings.SetCommunity.DefaultValue
description: "Reference the DataMiner connector protocol schema entry for DefaultValue element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
lifecycle: active
applies_to:
  - DataMiner
version: unknown
owner: unknown
review_status: needs_update
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
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
