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

## Example

Suppose you have 2 tables, *Receivers* (PID 100) and *Transmitters* (PID 200), with display keys 101 and 201, respectively. However, you want to show different columns in the [tree control](xref:Protocol.TreeControls.TreeControl), for example column 105 for the *Receivers* table and column 202 for the *Transmitters* table. In order to achieve this, use the *OverrideDisplayColumns* tag with a comma-separated list of PIDs for the columns you want to show. You only need to provide one column PID per table.

```xml
<OverrideDisplayColumns>105,202</OverrideDisplayColumns>
```
