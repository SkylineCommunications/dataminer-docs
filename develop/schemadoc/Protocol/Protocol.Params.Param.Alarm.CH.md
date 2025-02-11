---
uid: Protocol.Params.Param.Alarm.CH
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
