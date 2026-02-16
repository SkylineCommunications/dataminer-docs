---
uid: Protocol.Params.Param.Alarm.Info
---

# Info element

When the value of the alarm is equal to the value specified in this element, an information event is generated. 

When creating a new alarm template, any parameter that has a default info value will be enabled automatically.

## Type

[TypeAlarmTemplateDefaultValues](xref:Protocol-TypeAlarmTemplateDefaultValues)

## Parent

[Alarm](xref:Protocol.Params.Param.Alarm)

## Remarks

> [!NOTE]
>
> - To specify multiple values, use a semicolon as separator (“;”).
> - To denote an exception value, prepend the exception value with a dollar character (“$”).

## Examples

```xml
<Info>5</Info>
```

## See also

<xref:MonitoringAlarming>
