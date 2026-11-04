---
uid: Protocol.Params.Param.Alarm.MiH
description: "Use the MiH element in a DataMiner protocol to set the default minor-high threshold in a parameter alarm template."
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
