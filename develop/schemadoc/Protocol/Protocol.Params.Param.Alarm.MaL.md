---
metadata_version: 1
uid: Protocol.Params.Param.Alarm.MaL
description: "Reference the DataMiner connector protocol schema entry for MaL element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# MaL element

Defines the default value in the alarm template that this parameter must equal or exceed in order for DataMiner to create a new "major low" alarm.

## Type

[TypeAlarmTemplateDefaultValues](xref:Protocol-TypeAlarmTemplateDefaultValues)

## Parent

[Alarm](xref:Protocol.Params.Param.Alarm)

## Remarks

> [!NOTE]
>
> - To specify multiple values, use a semicolon as separator ((“;”)
> - To denote an exception value, prepend the exception value with a dollar character (“$”).
> - Not applicable for parameters with measurement type equal to discreet or string.

## Examples

```xml
<MaL>-20</MaL>
```

## See also

<xref:MonitoringAlarming>
