---
uid: Protocol.TreeControls.TreeControl.OverrideIconColumns
---

# OverrideIconColumns element

By specifying a column in this element, you can apply a custom icon based on a cell value in a row.

## Type

string

## Parent

[TreeControl](xref:Protocol.TreeControls.TreeControl)

## Remarks

The column must be a parameter of type Discreet and all discreet values must have an IconRef referring to an icon. If not, a default icon will be displayed.

## Examples

```xml
<OverrideIconColumns>106,206</OverrideIconColumns>
```
