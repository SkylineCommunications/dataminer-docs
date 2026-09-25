---
metadata_version: 1
uid: Protocol.Params.Param.Display.Positions.Position.Row
description: "Learn how the Row element sets the vertical row where a parameter appears on a Data Display page in a DataMiner connector protocol."
---

# Row element

Specifies the vertical position of the parameter on the Data Display page specified in Protocol.Params.Param.Display.Positions.Position.Page.

## Type

unsignedInt

## Parent

[Position](xref:Protocol.Params.Param.Display.Positions.Position)

## Remarks

Data Display pages are divided into rows and columns. In Protocol.Params.Param.Display.Positions.Position.Row, you can specify the row on which you want the parameter to be displayed.

> [!NOTE]
> 0 = first row

## Examples

```xml
<Row>2</Row>
```
