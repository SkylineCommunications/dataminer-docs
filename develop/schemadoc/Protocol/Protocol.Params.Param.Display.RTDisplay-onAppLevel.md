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

Set this attribute to true if the parameter needs to be accessible on application level, i.e. outside the protocol. This can for instance be in a visual overview, Automation script, or GQI query. Note this attribute is not known by DataMiner, it's only being used by and for the protocol validator.

> [!NOTE]
> Today, this attribute should not be used anymore as we now have a better alternative which is the Validator Suppression feature. Indeed, the Validator Suppression purpose is exactly the same and has following advantages:
> 1. It is a generic feature that can be used for on any validator result so it offers better consistency.
> 1. It allows to give an explicit reason why the parameter is required on application level.

## Examples

```xml
<RTDisplay onAppLevel="true">true</RTDisplay>
```
