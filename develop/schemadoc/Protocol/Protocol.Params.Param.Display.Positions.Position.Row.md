---
metadata_version: 1
uid: Protocol.Params.Param.Display.Positions.Position.Row
description: "Reference the DataMiner connector protocol schema entry for Row element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
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
