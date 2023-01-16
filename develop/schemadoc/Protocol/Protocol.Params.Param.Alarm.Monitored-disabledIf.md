---
uid: Protocol.Params.Param.Alarm.Monitored-disabledIf
---

# disabledIf attribute

Allows you to enable or disable the Protocol.Params.Param.Alarm tag assigned to the parameter.

## Content Type

string

## Parent

[Monitored](xref:Protocol.Params.Param.Alarm.Monitored)

## Remarks

Expected format: "parameter ID,parameter value".

With this option, monitoring can be disabled when a parameter contains a particular value.

When discrete values are used, it is only possible to set a condition on the discrete value, not on the display value.

When string values are used, commas (,) are currently not supported in the conditional value.

*Feature introduced in DataMiner 8.0.1 (RN 5327).*

## Examples

In the following example, monitoring is disabled when parameter with ID 1 has value 99:

```xml
<Monitored disabledIf="1,99">
```
