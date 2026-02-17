---
uid: Protocol.Params.Param.Measurement.Threshold
---

# Threshold element

Specifies a threshold.

## Type

double

## Parent

[Measurement](xref:Protocol.Params.Param.Measurement)

## Remarks

This element only has to be specified if Protocol.Params.Param.Measurement.Type is set to “threshold digital”.

In some cases, when only two states are allowed (e.g., "On" and "Off") but the parameter value lies within a range of values, a turnover point has to be defined (i.e., when value "On" is changed to "Off" and vice versa). This turnover point can be defined here. The actual "On" and "Off" values are defined as discrete entries.

## Examples

- A value lower than 30 will be interpreted as "Off".
- A value equal to or greater than 30 will be interpreted as "On".

```xml
<Threshold>30</Threshold>
```
