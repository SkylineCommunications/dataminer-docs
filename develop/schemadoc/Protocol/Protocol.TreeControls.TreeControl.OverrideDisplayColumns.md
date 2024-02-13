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

Suppose we have 2 tables, Receivers(PID 100) and Transmitters(PID 200) with display keys 101 and 201, respectively. However we would like to show different columns in the [TreeControl](xref:Protocol.TreeControls.TreeControl), for example, 105 for Receivers table, and column 202 for the Transmitters table. In order to achieve this we will provide OverrideDisplayColumns tag with comma separated list of PIDs for the columns we want to show, we need to provide only one column PID per table.

```xml
<OverrideDisplayColumns>105,202</OverrideDisplayColumns>
```
