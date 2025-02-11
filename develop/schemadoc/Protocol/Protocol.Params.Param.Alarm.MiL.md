---
uid: Protocol.Params.Param.Alarm.MiL
---

# MiL element

Defines the default value in the alarm template that this parameter must equal or exceed in order for DataMiner to create a new "minor low" alarm.

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
<MiL>0</MiL>
```

## See also

<xref:MonitoringAlarming>
