---
uid: Protocol.Params.Param.Interprete.Others.Other
description: "Use the Other element in a DataMiner protocol to map a symbol that violates one raw type by comparing it with another parameter."
---

# Other element

When an incoming character does not match the raw type of a parameter, DataMiner will try to match the symbol to the raw type of the parameter to which a `Protocol.Params.Param.Interprete.Others.Other` tag refers, if any.

## Parent

[Others](xref:Protocol.Params.Param.Interprete.Others)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[id](xref:Protocol.Params.Param.Interprete.Others.Other-id)|[TypeParamId](xref:Protocol-TypeParamId)|Yes|Specifies the ID of the parameter that the incoming symbol will be compared with.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[Display](xref:Protocol.Params.Param.Interprete.Others.Other.Display)||When the value of the parameter referenced with the `Protocol.Params.Param.Interprete.Others.Other@id` attribute matches the incoming symbol, the contents of the `Protocol.Params.Param.Interprete.Others.Other.Display` tag will be shown.|
|&nbsp;&nbsp;[Value](xref:Protocol.Params.Param.Interprete.Others.Other.Value)||Adds a numeric value to the parameter, which can be useful in case you want to show an alarm when this rare condition occurs.|
