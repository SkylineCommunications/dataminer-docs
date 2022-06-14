---
uid: Protocol.Params.Param.Display.RTDisplay
---

# RTDisplay element

Specifies whether the parameter should be pushed to the SLElement process.

## Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[Display](xref:Protocol.Params.Param.Display)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[onAppLevel](xref:Protocol.Params.Param.Display.RTDisplay-onAppLevel)|[EnumTrueFalse](xref:Protocol-EnumTrueFalse)||Specifies whether this parameter needs to be accessible on application level.|

## Remarks

Possible values:

- true: the parameter will be pushed to SLElement and can therefore be displayed in the user interface and is available for external use (e.g. another element).
- false: the parameter will not be pushed to SLElement.

See also: [RTDisplay](xref:InnerWorkingsSLElement#rtdisplay)

## Examples

```xml
<RTDisplay>true</RTDisplay>
```
