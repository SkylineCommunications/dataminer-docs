---
uid: Protocol.Params.Param.Alarm.WaL
---

# WaL element

Defines the default value in the alarm template that this parameter must equal or exceed in order for DataMiner to create a new "warning low" alarm.

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
<WaL>10</WaL>
```

## See also

<xref:MonitoringAlarming>
