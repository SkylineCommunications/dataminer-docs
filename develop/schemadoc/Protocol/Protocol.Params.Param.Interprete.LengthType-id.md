---
uid: Protocol.Params.Param.Interprete.LengthType-id
---

# id attribute

Specifies the ID of another parameter that contains the parameter length.

## Content Type

[TypeParamId](xref:Protocol-TypeParamId)

## Parent

[LengthType](xref:Protocol.Params.Param.Interprete.LengthType)

## Remarks

If LengthType is "other param", then this attribute has to contain the ID of the "other" parameter that contains the parameter length.

If LengthType is "next param", then this attribute has to contain the ID of the parameter in the serial response until which the data will be read and stored in the "next param".<!-- RN 7646 -->

In the following example, SLPort will read the variable data until it reaches the trailer and store it in "next param". The CRC will not be included. The format of the incoming data:

```none
Header|Bus|Fixed Param|Next Param|CRC|Trailer
```

Length definition of the variable data:

```xml
<LengthType id="4">next param</LengthType>
```
