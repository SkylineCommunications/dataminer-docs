---
uid: Protocol.Params.Param.Interprete.Exceptions.Exception.Value
---

# Value element

Specifies the value to which the incoming exception value specified in the value attribute of the Protocol.Params.Param.Interprete.Exceptions.Exception tag is internally mapped.

## Type

string

## Parent

[Exception](xref:Protocol.Params.Param.Interprete.Exceptions.Exception)

## Remarks

This new value will be stored in the alarm and trend database, and will be used to refer to the exception.

> [!NOTE]
> Make sure that the value specified in the Protocol.Params.Param.Interprete.Exceptions.Exception.Value tag is out of the expected, normal value range. If not, this “normal” value will be considered an exception and alarms will be triggered if exception values are
monitored.

## Examples

```xml
<Value>-1</Value>
```
