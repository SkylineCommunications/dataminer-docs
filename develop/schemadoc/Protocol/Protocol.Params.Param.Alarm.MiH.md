---
uid: Protocol.Params.Param.Alarm.MiH
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
