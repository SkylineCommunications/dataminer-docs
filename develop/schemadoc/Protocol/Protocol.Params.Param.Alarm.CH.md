---
metadata_version: 1
uid: Protocol.Params.Param.Alarm.CH
description: "Reference the DataMiner connector protocol schema entry for CH element, including its documented structure, attributes, values, and constraints."
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

# CH element

Defines the default value in the alarm template that this parameter must equal or exceed in order for DataMiner to create a new "critical high" alarm.

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
<CH>70</CH>
```

## See also

<xref:MonitoringAlarming>
