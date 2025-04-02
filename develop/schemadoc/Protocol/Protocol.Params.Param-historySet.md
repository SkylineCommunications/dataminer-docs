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
> - You cannot use history sets in combination with the smart baseline option on the same parameter. If you enable smart baselines for a parameter that has its `historySet` set to "true" in the connector in question, the option will have no effect as long as `historySet` is set to "true". From DataMiner 10.4.0 [CU14]/10.5.0 [CU2]/10.5.5 onwards<!--RN 42326-->, a warning message will alert you when this is the case.

## Examples

```xml
<Param id="1" historySet="true">
```

## See also

- [How to use history sets on a protocol parameter](xref:How_to_use_history_sets_on_a_protocol_parameter)
