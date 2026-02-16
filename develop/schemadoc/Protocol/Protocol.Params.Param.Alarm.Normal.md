---
uid: Protocol.Params.Param.Alarm.Normal
---

# Normal element

When the parameter value equals this value or does not exceed the specified warning limits, DataMiner will not generate an alarm. If an alarm was generated earlier, its type will be set to “dropped”.

## Type

string

## Parent

[Alarm](xref:Protocol.Params.Param.Alarm)

## Remarks

- To specify multiple values, use a semicolon as separator ((“;”)
- To denote an exception value, prepend the exception value with a dollar character (“$”).
- The Normal value is not required to determine whether a metric is not in an alarm state (i.e., a metric is automatically considered not to be in alarm when it does not meet the alarm condition for an alarm state defined on that metric). However, it can be useful to provide an optional graphical indication for the user on analog readings as to which value is typically to be expected. For example, in the parameter control below, a small green dot indicates the normal value:

![Normal](~/develop/schemadoc/Protocol/images/Normal_alarm.png)

## Examples

```xml
<Normal>25</Normal>
```

## See also

<xref:MonitoringAlarming>
