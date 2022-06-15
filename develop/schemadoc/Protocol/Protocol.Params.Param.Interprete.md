---
uid: Protocol.Params.Param.Interprete
---

# Interprete element

Specifies how a parameter value is processed.

## Parent

[Param](xref:Protocol.Params.Param)

## Children

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[Alignment](xref:Protocol.Params.Param.Interprete.Alignment)|[0, 1]|Used to retrieve BCD numbers from an incoming stream.|
|&nbsp;&nbsp;[Base](xref:Protocol.Params.Param.Interprete.Base)|[0, 1]|Specifies the numeral system (decimal, hexadecimal, etc.).|
|&nbsp;&nbsp;[Bits](xref:Protocol.Params.Param.Interprete.Bits)|[0, 1]|Used when a group of multiple bytes has been defined, but only a couple of bits are used from each byte.|
|&nbsp;&nbsp;[ByteOffset](xref:Protocol.Params.Param.Interprete.ByteOffset)|[0, 1]|Specifies the byte offset.|
|&nbsp;&nbsp;[Decimals](xref:Protocol.Params.Param.Interprete.Decimals)|[0, 1]|Specifies the number of decimals that will be stored in memory.|
|&nbsp;&nbsp;[DefaultValue](xref:Protocol.Params.Param.Interprete.DefaultValue)|[0, 1]|Specifies the default value to be assigned to the parameter if it is empty after startup.|
|&nbsp;&nbsp;[Endian](xref:Protocol.Params.Param.Interprete.Endian)|[0, 1]|Specifies whether DataMiner must reverse the byte order (only relevant in case of unsigned numbers).|
|&nbsp;&nbsp;[Exceptions](xref:Protocol.Params.Param.Interprete.Exceptions)|[0, 1]|Contains Exception elements, each representing a different exceptional state.|
|&nbsp;&nbsp;[Factor](xref:Protocol.Params.Param.Interprete.Factor)|[0, 1]|Multiplies the parameter value with the specified factor.|
|&nbsp;&nbsp;[Length](xref:Protocol.Params.Param.Interprete.Length)|[0, 1]|Specifies the exact length of the parameter (in bytes).|
|&nbsp;&nbsp;[LengthType](xref:Protocol.Params.Param.Interprete.LengthType)|[0, 1]|Specifies whether the parameter has a fixed length.|
|&nbsp;&nbsp;[NbrOfBits](xref:Protocol.Params.Param.Interprete.NbrOfBits)|[0, 1]|Specifies the number of bits needed.|
|&nbsp;&nbsp;[OffSet](xref:Protocol.Params.Param.Interprete.OffSet)|[0, 1]|In case the Sequence tag contains "OffSet " as an operation, to offset to be added can be specified using this tag.|
|&nbsp;&nbsp;[Others](xref:Protocol.Params.Param.Interprete.Others)|[0, 1]|Groups Other child elements.|
|&nbsp;&nbsp;[Range](xref:Protocol.Params.Param.Interprete.Range)|[0, 1]|Defines a range for the parameter values.|
|&nbsp;&nbsp;[RawType](xref:Protocol.Params.Param.Interprete.RawType)|[0, 1]|Specifies which type of content is allowed in the parameter.|
|&nbsp;&nbsp;[Rounding](xref:Protocol.Params.Param.Interprete.Rounding)|[0, 1]|Specifies how the parameter value is rounded.|
|&nbsp;&nbsp;[Scale](xref:Protocol.Params.Param.Interprete.Scale)|[0, 1]|Specifies that you want DataMiner to re-interpret the value range of a particular parameter.|
|&nbsp;&nbsp;[Sequence](xref:Protocol.Params.Param.Interprete.Sequence)|[0, 1]|Specifies a mathematical operation to be performed on the parameter value.|
|&nbsp;&nbsp;[StartPosition](xref:Protocol.Params.Param.Interprete.StartPosition)|[0, 1]|Specifies the start bit in the group to which the parameter refers to in case the parameter is of type "read/write bits".|
|&nbsp;&nbsp;[Type](xref:Protocol.Params.Param.Interprete.Type)|[0, 1]|Specifies how the parameter should be processed and saved.|
|&nbsp;&nbsp;[Value](xref:Protocol.Params.Param.Interprete.Value)|[0, 1]|In case of a parameter with a fixed length and a fixed value, set Protocol.Params.Param.Interprete.LengthType to "fixed" and specify the fixed value here.|
