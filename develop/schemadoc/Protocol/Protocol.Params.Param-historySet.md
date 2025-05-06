---
uid: Protocol.Params.Param-historySet
---

# historySet attribute

<!-- RN 4383 -->

Specifies that history sets are enabled for this parameter, allowing historical data to be recorded and accessed accurately.

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[Param](xref:Protocol.Params.Param)

## Remarks

If this attribute is not enabled and a history set is performed, the data may not be saved properly, leading to inaccurate results when accessing or visualizing past data, such as in trend graphs.

For tables, the historySet attribute only needs to be enabled on the specific column parameters that will be used with a history set.

If you mark a parameter as a history set parameter, its last set value will not be stored in the trending database when the element is restarted.

> [!NOTE]
>
> - Using history sets in combination with [alarm hysteresis](xref:Configuring_alarm_hysteresis) on the same parameter can cause unexpected behavior in alarm timestamps, as both features modify the parameter and alarm times. For this reason, we do not recommend combining them.
> - The [smart baseline option](xref:Configuring_dynamic_alarm_thresholds) is incompatible with history sets. If a parameter has history sets enabled, enabling smart baselines will have no effect. From DataMiner 10.4.0 [CU14]/10.5.0 [CU2]/10.5.5 onwards<!--RN 42326-->, you will receive a warning message when attempting to enable smart baselines for a parameter with history sets enabled.
> - When *historySet* is enabled, DataMiner determines the time of the relevant alarms based on when the parameter value is updated, rather than when the alarms themselves are updated (e.g. when alarm properties change, the view impact changes, the alarm is acknowledged, etc.).

## Examples

```xml
<Param id="1" historySet="true">
```

## See also

- [How to use history sets on a protocol parameter](xref:How_to_use_history_sets_on_a_protocol_parameter)
