---
metadata_version: 1
uid: Protocol.Params.Param.Alarm.MiH
description: "Reference the DataMiner connector protocol schema entry for MiH element, including its documented structure, attributes, values, and constraints."
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

# MiH element

Defines the default value in the alarm template that this parameter must equal or exceed in order for DataMiner to create a new "minor high" alarm.

## Type

[TypeAlarmTemplateDefaultValues](xref:Protocol-TypeAlarmTemplateDefaultValues)

## Parent

[Alarm](xref:Protocol.Params.Param.Alarm)

## Remarks

> [!NOTE]
>
> - To specify multiple values, use a semicolon as separator ((“;”)
> - To denote an exception value, prepend the exception value with a dollar character (“$”).

## Examples

```xml
<MiH>55</MiH>
```

## See also

<xref:MonitoringAlarming>
