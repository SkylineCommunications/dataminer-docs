---
uid: Protocol.Params.Param.Display.Positions.Position.Column
---

# Column element

Specifies the horizontal position of the parameter on the Data Display page specified in Protocol. Params.Param.Display.Positions.Position.Page.

## Type

unsignedInt

## Parent

[Position](xref:Protocol.Params.Param.Display.Positions.Position)

## Remarks

Data Display pages are divided into rows and columns. In Protocol.Params.Param.Display.Positions.Position.
Column, you can specify the column on which you want the parameter to be displayed.

> [!NOTE]
> It is recommended to divide the user interface into two columns:
>
> - a left-hand column with column value 0, and
> - a right-hand column with column value 1.

## Examples

```xml
<Column>1</Column>
```
