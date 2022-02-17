---
uid: Protocol.Params.Param.Interprete.Scale
---

# Scale element

Specifies that you want DataMiner to re-interpret the value range of a particular parameter.

## Parent

[Interprete](xref:Protocol.Params.Param.Interprete)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[lowData](xref:Protocol.Params.Param.Interprete.Scale-lowData)|integer|Yes|Specifies the lowest value that can be returned by the device for the parameter in question.|
|[highData](xref:Protocol.Params.Param.Interprete.Scale-highData)|integer|Yes|Specifies the highest value that can be returned by the device for the parameter in question.|
|[low](xref:Protocol.Params.Param.Interprete.Scale-low)|integer|Yes|Specifies the value to which DataMiner has to convert the lowest value that can be returned by the device.|
|[high](xref:Protocol.Params.Param.Interprete.Scale-high)|integer|Yes|Specifies the value to which DataMiner has to convert the highest value that can be returned by the device.|

## Examples

If, for a specific parameter, the device can return values between 100 and 500, but you want DataMiner to interpret those values as ranging from 0 to 20, then you can specify the following to indicate that 100 should be considered as 0 and 500 should be considered as 20:

```xml
<scale lowdata="100" highdata="500" low="0" high="20" />
```
