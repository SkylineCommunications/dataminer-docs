---
uid: Protocol.TreeControls.TreeControl.OverrideDisplayColumns
---

# OverrideDisplayColumns element

Used to override the display key or the index of a row by a different column of the same table.

## Type

string

## Parent

[TreeControl](xref:Protocol.TreeControls.TreeControl)

## Remarks

> [!NOTE]
> It is possible to specify that the items in the tree control should be sorted according to the value of another parameter. This is done by specifying the ID of the parameter after a pipe ('|') character.
>
> For example: `<OverrideDisplayColumns>302|304,201,101</OverrideDisplayColumns>`
>
> In this example, the items in the tree control will be sorted according to the value of the parameter with ID 304.

## Examples

```xml
<OverrideDisplayColumns>105,205</OverrideDisplayColumns>
```
