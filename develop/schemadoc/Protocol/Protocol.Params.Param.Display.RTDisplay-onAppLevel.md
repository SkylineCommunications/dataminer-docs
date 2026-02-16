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

Set this attribute to true if the parameter needs to be accessible on application level, i.e., outside the protocol. This can for instance be in a visual overview, automation script, or GQI query. Note that this attribute is not known by DataMiner; it is only used by and for the protocol validator.

> [!NOTE]
> This attribute **should no longer be used**, as there is a better alternative, i.e., the [Validator Suppression feature](xref:DisValidatorToolWindow#suppressing-or-postponing-a-validation-result). This feature has the same possibilities, but with the following advantages:
>
> - It is a generic feature that can be used for any validator result so it offers better consistency.
> - It allows you to give an explicit reason why the parameter is required on application level.

## Examples

```xml
<RTDisplay onAppLevel="true">true</RTDisplay>
```
