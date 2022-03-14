---
uid: Protocol.Params.Param-save
---

# save attribute

Specifies whether the parameter has to be saved each time its value changes.

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[Param](xref:Protocol.Params.Param)

## Remarks

Default value: false.

> [!NOTE]
> Only applicable for standalone parameters. For column parameters, refer to the "save" option in the [options](xref:ColumnOptionOptionsOverview#save) attribute.

## Examples

```xml
<Param id="1" save="true">
```
