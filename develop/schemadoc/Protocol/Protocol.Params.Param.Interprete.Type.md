---
metadata_version: 1
uid: Protocol.Params.Param.Interprete.Type
description: "Learn how the Type element controls how DataMiner processes and stores a parameter value, with filtering and trimming in a DataMiner connector protocol."
---

# Type element

Specifies how the parameter should be processed and saved.

## Type

[EnumParamInterpretType](xref:Protocol-EnumParamInterpretType)

## Parent

[Interprete](xref:Protocol.Params.Param.Interprete)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[filter](xref:Protocol.Params.Param.Interprete.Type-filter)|[EnumTrueFalse](xref:Protocol-EnumTrueFalse)||When set to "true", only printable characters will be displayed.|
|[trim](xref:Protocol.Params.Param.Interprete.Type-trim)|[EnumInterpretTypeTrim](xref:Protocol-EnumInterpretTypeTrim)||Specifies whether to remove leading and/or trailing whitespace.|
