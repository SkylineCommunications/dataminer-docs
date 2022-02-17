---
uid: Protocol.Params.Param-historySet
---

# historySet attribute

Specifies that this parameter is a history set parameter.

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[Param](xref:Protocol.Params.Param)

## Remarks

If you mark a parameter as a history set parameter, its last set value will not be stored in the trending database when the element is restarted.

*Feature introduced in DataMiner 7.5.0 (RN 4383).*

## Examples

```xml
<Param id="1" historySet="true">
```
