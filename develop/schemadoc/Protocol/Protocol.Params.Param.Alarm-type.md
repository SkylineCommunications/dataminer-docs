---
uid: Protocol.Params.Param.Alarm-type
---

# type attribute

When the polled device is able to send a nominal value for the parameter, this attribute can be added to the Protocol.Params.Param.Alarm tag.

## Content Type

string

## Parent

[Alarm](xref:Protocol.Params.Param.Alarm)

## Remarks

- If set to “absolute”, the alarm values defined in the Protocol.Params.Param.Alarm tag will be calculated in accordance with the nominal value sent by the device. When the Critical Low tag contains the value 5, this value will be subtracted from the nominal value to calculate the actual alarm limit.
- If set to “relative”, percentages will be taken instead of absolute values in order to calculate the actual alarm limits.

  Example: When the Minor High tag contains 50, the alarm limit will be the nominal value increased with 50% of its value.

  You can normalize an alarm by (optionally) adding two parameters, separated by a comma.

  - First parameter: The ID of the parameter that holds the nominal value. This can be a dynamic table parameter or a normal parameter. In case of a dynamic table parameter, each row will be compared with the nominal value found in the same row of the specified column.
  - Second parameter (optional): The ID of the parameter that holds the value by which to multiply the nominal value.

Prior to DataMiner 10.1.9, when a parameter has a (smart) baseline value specified in the protocol, it is not possible to update that (smart) baseline value in Cube's alarm template baseline editor. However, from DataMiner 10.1.9 (RN 30388, RN 30461) onwards, the alarm template baseline editor allows you to configure (smart) baselines specified in protocols.

> [!NOTE]
>
> - The alarm template baseline editor will not allow you to change the monitoring type (Normal, Relative, Absolute, or Rate).
> - When a baseline is specified in a protocol, the baseline value is stored in a separate parameter. Although you should specify a read parameter (e.g. `<Alarm type="absolute:NOMINAL_VALUE_PID,FACTOR_PID">`), make sure that read parameter has an associated write parameter. Otherwise, it will not be possible to update the baseline value stored in that parameter. Also, the parameter in which the baseline value is stored must not have any restrictions (e.g. step size, number of decimals, high/low range, etc.), and the Interprete.RawType tag should not be set to [unsigned number](xref:Protocol.Params.Param.Interprete.RawType#unsigned-number).
> - The smart baseline algorithm may sometimes produce unexpected results with respect to parameter ranges. For example, consider a parameter that consistently fluctuates between 0 and 100. The baseline is an approximation of your data, so it might sometimes slightly dip below 0 or slightly exceed 100. To address this, we recommend configuring appropriate ranges for the parameter within the protocol. The algorithm will respect these limits during baseline calculations. For instance, if a lower range of 0 is defined in the protocol, any baseline value calculated below 0 will automatically be capped at 0.

## Examples

```xml
<Alarm Type="absolute:2214,108">
```
