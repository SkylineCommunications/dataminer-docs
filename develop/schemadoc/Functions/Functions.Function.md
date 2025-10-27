---
uid: Functions.Function
---

# Function element

Defines a function for the protocol.

## Parent

[Functions](xref:Functions)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[id](xref:Functions.Function-id)|[guid](xref:Functions-TypeGuid)|Yes|Specifies the unique GUID of the function.|
|[name](xref:Functions.Function-name)|[TypeNonEmptyString](xref:Functions-TypeNonEmptyString)|Yes|The name of the protocol function (e.g. encoder, decoder). The name of VFs created with this element will consist of the main protocol name followed by this name: "mainProtocolName.Name".|
|[maxInstances](xref:Functions.Function-maxInstances)|integer||Determines the maximum number of instances of this function that can be active at the same time.|
|[profile](xref:Functions.Function-profile)|[guid](xref:Functions-TypeGuid)||The GUID of the profile corresponding to the function.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***Sequence***|||
|&nbsp;&nbsp;[Parameters](xref:Functions.Function.Parameters)|[0, 1]|Contains a Parameter subtag for each parameter of the function. These are the parameters that will be exported to the function from the main protocol.|
|&nbsp;&nbsp;[EntryPoints](xref:Functions.Function.EntryPoints)|[0, 1]|Specifies the entry points.|
|&nbsp;&nbsp;[ExportRules](xref:Functions.Function.ExportRules)|[0, 1]|Specifies the export rules. This tag functions similarly to the [ExportRules](xref:Protocol.ExportRules) tag for a DVE element.|
|&nbsp;&nbsp;[Interfaces](xref:Functions.Function.Interfaces)|[0, 1]|Specifies the interfaces available on the function.|
|&nbsp;&nbsp;[Graphical](xref:Functions.Function.Graphical)|[0, 1]|Contains a CDATA tag with the configuration of the function's icon. Both XAML and SVG format are supported.|
