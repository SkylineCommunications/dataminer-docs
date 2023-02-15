---
uid: Protocol.Params.Param.Display.RTDisplay-onAppLevel
---

# onAppLevel attribute

Specifies whether this parameter needs to be accessible on application level.

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[RTDisplay](xref:Protocol.Params.Param.Display.RTDisplay)

## Remarks

Set this attribute to true if the parameter needs to be accessible on application level, i.e. outside the protocol. This can for instance be in a visual overview, Automation script, or GQI query.

## Examples

```xml
<RTDisplay onAppLevel="true">true</RTDisplay>
```
