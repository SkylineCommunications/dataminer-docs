---
metadata_version: 1
uid: Protocol.Params.Param.Display.Positions.Position.Page
description: "Reference the DataMiner connector protocol schema entry for Page element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# Page element

Specifies on which Data Display page the parameter should be displayed.

## Type

[TypeNonEmptyString](xref:Protocol-TypeNonEmptyString)

## Parent

[Position](xref:Protocol.Params.Param.Display.Positions.Position)

## Attributes

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Type|Required|Description|
|--- |--- |--- |--- |
|[measType](xref:Protocol.Params.Param.Display.Positions.Position.Page-measType)|[EnumParamMeasurementType](xref:Protocol-EnumParamMeasurementType)||Specifies that this parameter has to be displayed in a specific way on the specified page.|

## Remarks

All Data Display pages specified in the protocol will appear in the page selection box at the top of Data Display.
