---
metadata_version: 1
uid: Protocol.Params.Param.Interprete.Others.Other.Display
description: "Learn how the Display element sets the text shown when an incoming symbol matches the referenced parameter value in a DataMiner connector protocol."
---

# Display element

When the value of the parameter referenced with the Protocol.Params.Param.Interprete.Others.Other@id attribute matches the incoming symbol, the contents of the Protocol.Params.Param.Interprete.Others.Other.Display tag will be shown.

## Type

string

## Parent

[Other](xref:Protocol.Params.Param.Interprete.Others.Other)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[state](xref:Protocol.Params.Param.Interprete.Others.Other.Display-state)|[EnumDisplayState](xref:Protocol-EnumDisplayState)||If set to “disabled”, the parameter will be displayed in gray.|
