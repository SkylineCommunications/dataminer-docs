---
metadata_version: 1
uid: Protocol.Params.Param.Display.Positions.Position.Column
description: "Reference the DataMiner connector protocol schema entry for Column element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# Column element

Specifies the horizontal position of the parameter on the Data Display page specified in [Protocol.Params.Param.Display.Positions.Position.Page](xref:Protocol.Params.Param.Display.Positions.Position.Page).

## Type

unsignedInt

## Parent

[Position](xref:Protocol.Params.Param.Display.Positions.Position)

## Remarks

Data Display pages are divided into rows and columns. In Protocol.Params.Param.Display.Positions.Position.Column, you can specify the column where you want the parameter to be displayed.

> [!NOTE]
> We recommend dividing the user interface into two columns:
>
> - a column on the left with column value 0, and
> - a column on the right with column value 1.

## Examples

```xml
<Column>1</Column>
```
