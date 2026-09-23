---
metadata_version: 1
uid: Protocol.Params.Param.SNMP.Enabled
description: "Reference the DataMiner connector protocol schema entry for Enabled element, including its documented structure, attributes, values, and constraints."
content_type: schema
applies_to:
  - DataMiner
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
