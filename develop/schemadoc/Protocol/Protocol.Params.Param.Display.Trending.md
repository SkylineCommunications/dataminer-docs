---
uid: Protocol.Params.Param.Display.Trending
---

# Trending element

Specifies the formula to be used for the average trending data of this parameter. By default, the average over a 5 minute timespan is stored.

## Parent

[Display](xref:Protocol.Params.Param.Display)

## Attributes

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Type|Required|Description|
|--- |--- |--- |--- |
|[logarithmic](xref:Protocol.Params.Param.Display.Trending-logarithmic)|[EnumTrueFalse](xref:Protocol-EnumTrueFalse)||Set this attribute to "true" if you want to set the trend graph of the parameter to a logarithmic scale.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Type](xref:Protocol.Params.Param.Display.Trending.Type)|[0, 1]|Specifies the formula used to determine the average trending data.|

## Remarks

Can be added for both analog and discreet parameters.

*Feature introduced in DataMiner 7.5.7.1.*
