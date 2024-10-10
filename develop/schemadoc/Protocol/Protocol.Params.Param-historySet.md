---
uid: Protocol.Params.Param-historySet
---

# historySet attribute

Specifies that this parameter is a history set parameter.<!-- RN 4383 -->

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[Param](xref:Protocol.Params.Param)

## Remarks

If you mark a parameter as a history set parameter, its last set value will not be stored in the trending database when the element is restarted.

## Examples

```xml
<Param id="1" historySet="true">
```
