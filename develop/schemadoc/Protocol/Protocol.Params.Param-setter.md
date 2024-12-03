---
uid: Protocol.Params.Param-setter
---

# setter attribute

Specifies whether the value of the write parameter will be copied to the corresponding read parameter (without the need to add a trigger or an action).

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[Param](xref:Protocol.Params.Param)

## Remarks

Default value: false.

> [!NOTE]
>
> - For a write parameter with the setter attribute set to true, the write value will first be copied to the corresponding read parameter before any QAction triggered by this write parameter is executed.
> - If the button is part of a table and no corresponding read parameter is present, the write parameter may execute its triggers or actions a second time.

## Examples

```xml
<Param id="1" setter="true">
```
