---
uid: Protocol.Params.Param.Interprete.Others.Other
---

# Other element

When an incoming character does not match the rawtype of a parameter, DataMiner will try to match the symbol to the rawtype of the parameter to which a Protocol.Params.Param.Interprete.Others.Other tag refers to, if any.

## Parent

[Others](xref:Protocol.Params.Param.Interprete.Others)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[id](xref:Protocol.Params.Param.Interprete.Others.Other-id)|[TypeParamId](xref:Protocol-TypeParamId)|Yes|Specifies the ID of the parameter to which the incoming symbol will be compared with.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[Display](xref:Protocol.Params.Param.Interprete.Others.Other.Display)||When the value of the parameter referenced with the Protocol.Params.Param.Interprete.Others.Other@id attribute matches the incoming symbol, the contents of the Protocol.Params.Param.Interprete.Others.Other.Display tag will be shown.|
|&nbsp;&nbsp;[Value](xref:Protocol.Params.Param.Interprete.Others.Other.Value)||Adds a numeric value to the parameter, which can be useful in case you want to show an alarm when this rare condition occurs.|
