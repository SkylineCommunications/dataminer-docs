---
uid: Protocol.Params.Param.Interprete.Others.Other.Display
description: "Use the Display element in a DataMiner protocol to set the text shown when an incoming symbol matches the referenced parameter value."
---

# Display element

When the value of the parameter referenced with the `Protocol.Params.Param.Interprete.Others.Other@id` attribute matches the incoming symbol, the contents of the `Protocol.Params.Param.Interprete.Others.Other.Display` tag will be shown.

## Type

string

## Parent

[Other](xref:Protocol.Params.Param.Interprete.Others.Other)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[state](xref:Protocol.Params.Param.Interprete.Others.Other.Display-state)|[EnumDisplayState](xref:Protocol-EnumDisplayState)||Set this attribute to `disabled` to have the parameter displayed in gray.|
