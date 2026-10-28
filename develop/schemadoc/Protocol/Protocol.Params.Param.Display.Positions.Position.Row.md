---
uid: Protocol.Params.Param.Display.Positions.Position.Row
description: "Use the Row element in a DataMiner protocol to set the vertical position of a parameter on a Data Display page."
---

# Row element

Specifies the vertical position of the parameter on the Data Display page specified in `Protocol.Params.Param.Display.Positions.Position.Page`.

## Type

unsignedInt

## Parent

[Position](xref:Protocol.Params.Param.Display.Positions.Position)

## Remarks

Data Display pages are divided into rows and columns. In `Protocol.Params.Param.Display.Positions.Position.Row`, you can specify the row on which you want the parameter to be displayed.

> [!NOTE]
> 0 = first row

## Examples

```xml
<Row>2</Row>
```
