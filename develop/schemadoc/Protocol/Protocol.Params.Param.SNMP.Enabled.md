---
metadata_version: 1
uid: Protocol.Params.Param.SNMP.Enabled
description: "Reference the DataMiner connector protocol schema entry for Enabled element, including its documented structure, attributes, values, and constraints."
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

# Enabled element

Specifies whether DataMiner is allowed to interrogate the SNMP Agent.

## Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[SNMP](xref:Protocol.Params.Param.SNMP)

## Remarks

If *true*, DataMiner is allowed to interrogate the SNMP agent.

## Examples

```xml
<Enabled>true</Enabled>
```
