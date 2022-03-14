---
uid: Protocol.Params.Param.Interprete.LengthType-times
---

# times attribute

Specifies the number of times the next parameter should occur before it is considered to be the next parameter.

## Content Type

unsignedInt

## Parent

[LengthType](xref:Protocol.Params.Param.Interprete.LengthType)

## Remarks

This is used when the parameter is used in a response.

If LengthType is “next param”, then this attribute has to contain the number of times the next parameter should occur before it is considered to be the next parameter.

In the following example, the value of the parameter after this parameter will occur twice in the total response. Once in this parameter and once in the next:

```xml
<LengthType times="2">next param</LengthType>
```

In the following example, the parameter with ID 10 is the header, the parameter with ID 50 has LengthType “next param”, the parameter with ID 11 is a fixed param and the parameter with ID 12 is the trailer.

The response of the device looks like [header] ‘ABCD’ ‘C’ [trailer], the value of the fixed param is present in the value of the next param. This means that times should be equal to 2 in order to have the wanted value in the next param parameter.

```xml
<Response id="1">
	<Name>Response1</Name>
	<Description>Response1</Description>
	<Content>
		<Param>10</Param>
		<Param>50</Param>
		<Param>11</Param>
		<Param>12</Param>
	</Content>
</Response>
```

In the following example, the trailer (ID 12) is the parameter after the next param (ID 50). If the trailer is part of the next param, then the trailer parameter would have a times attribute in its type and the next param would have the times attribute.

```xml
<Response id="1">
    <Name>Response1</Name>
    <Description>Response1</Description>
    <Content>
        <Param>10</Param>
        <Param>50</Param>
        <Param>12</Param>
    </Content>
</Response>
```
