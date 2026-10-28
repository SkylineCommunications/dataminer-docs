---
uid: Protocol.TreeControls.TreeControl.OverrideIconColumns
description: "Use the OverrideIconColumns element in a DataMiner protocol to apply custom row icons based on discrete column values in a tree control."
---

# OverrideIconColumns element

By specifying a column in this element, you can apply a custom icon based on a cell value in a row.

## Type

string

## Parent

[TreeControl](xref:Protocol.TreeControls.TreeControl)

## Remarks

The column must be a parameter of type `Discreet` and all discrete values must have an [iconRef](xref:Protocol.Params.Param.Measurement.Discreets.Discreet-iconRef) referring to an icon. If not, a default icon will be displayed.

## Examples

```xml
<OverrideIconColumns>106,206</OverrideIconColumns>
```
