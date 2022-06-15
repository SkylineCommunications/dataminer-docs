---
uid: Protocol.Params.Param.Interprete.Others
---

# Others element

Groups Other child elements.

## Parent

[Interprete](xref:Protocol.Params.Param.Interprete)

## Children

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Other](xref:Protocol.Params.Param.Interprete.Others.Other)|[0, *]|When an incoming character does not match the rawtype of a parameter, DataMiner will try to match the symbol to the rawtype of the parameter to which a Protocol.Params.Param.Interprete.Others.Other tag refers to, if any.|

## Remarks

Each parameter has a certain rawtype, but in some cases other characters are sent instead of the usual ones to indicate a rare condition.

These symbols are often not allowed by the rawtype of the parameter. To catch those characters and display the singular state of the parameter, they can be specified in the Protocol.Params.Param.Interprete.Others tag.

The Protocol.Params.Param.Interprete.Others tag can contain a number of Other tags.

> [!NOTE]
> Protocol.Params.Param.Interprete.Others cannot be used when the value of a parameter is provided via a QAction. In that case, you should transform the data as necessary to be compatible with the Exception tag. See [Protocol.Params.Param.Interprete.Exceptions.Exception](xref:Protocol.Params.Param.Interprete.Exceptions.Exception)
