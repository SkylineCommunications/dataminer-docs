---
metadata_version: 1
uid: Protocol.PortSettings.Flowcontrol.Value
description: "Reference the DataMiner connector protocol schema entry for Value element, including its documented structure, attributes, values, and constraints."
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

# Value element

Using one or more Value elements, you can specify the different values that users are allowed to enter.

## Type

[EnumPortSettingsFlowControl](xref:Protocol-EnumPortSettingsFlowControl)

## Parent

[Flowcontrol](xref:Protocol.PortSettings.Flowcontrol)

## Remarks

- The value specified in the DefaultValue tag does not have to be specified in a Value tag.
- When no Value tags are specified, users will only be allowed to enter the value specified in the DefaultValue tag.
- For SNMPv3 connections, this can be used to specify the possible encryption algorithms.

The following wildcards can be used:

- *: A series of characters
- ?: One single character

## Examples

```xml
<Value>CTS_RTS</Value>
<Value>CTS_DTR</Value>
```
