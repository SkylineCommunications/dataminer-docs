---
uid: Protocol.Params.Param.Interprete.LengthType
---

# LengthType element

Specifies whether the parameter has a fixed length.

## Type

[EnumParamInterpretLengthType](xref:Protocol-EnumParamInterpretLengthType)

## Parent

[Interprete](xref:Protocol.Params.Param.Interprete)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[id](xref:Protocol.Params.Param.Interprete.LengthType-id)|[TypeParamId](xref:Protocol-TypeParamId)||Specifies the ID of another parameter that contains the parameter length.|
|[times](xref:Protocol.Params.Param.Interprete.LengthType-times)|unsignedInt||Specifies the number of times the next parameter should occur before it is considered to be the next parameter.|

## Remarks

Contains one of the following values:

### fixed

The parameter has a fixed length, which has to be defined in the Protocol.Params.Param.Interprete.Length tag. During parameter initialization, DataMiner does the following for parameters that have LengthType set to "fixed":

1. A byte array is created with size equal to the value specified in Interprete.Length. This array is then initialized. The initialization value depends on the RawType value:

    - If RawType is set to "text" or "other", the array is initialized with 0x20 bytes.
    - If RawType is set to "numeric text", the array is initialized with 0x30 bytes.
    - If RawType is set to "signed number", "unsigned number", "double" or "bcd", the array is initialized with 0x00 bytes.

1. If the parameter specifies a fixed value (Interprete/Value), the byte array is set to the specified value.

For example, executing a GetData (SLProtocol) on a parameter with the following Interprete defined will result in a byte array being returned of size 2, with each byte having a value of 0x20 ([0x20 0x20]).

```xml
<Interprete>
    <RawType>other</RawType>
    <Type>string</Type>
    <LengthType>fixed</LengthType>
    <Length>2</Length>
</Interprete>
```

> [!NOTE]
> As a result, the IsEmpty (SLProtocol) method will always return false for fixed length parameters, even if these do not have a value specified (Interprete.Value).

### last next param

The parameter has a variable length, which depends on the last instance of the next (fixed-length) parameter in the response.

If the expected response will contain a number with a length up to 5 digits (which can have a decimal point), followed by a fixed point, then you can define two parameters:

- A first one with a LengthType equal to “last next param” to catch the number containing the decimal point (“last next param” will make sure the number is not broken off at the first point), and
- A second one with a LengthType equal to “fixed” to catch the point.

#### Example

The `last next param` LengthType determines the length of the current parameter by searching for the **last occurrence** of the following parameter’s value in the incoming data.

For example, assume:

- The **current parameter** has `LengthType = last next param`
- The **following parameter** is a fixed parameter with the value `$`
- The incoming data is:

```
abc$def$ghi$
```

In this case:

- The parser searches for the **last occurrence** of `$`
- Everything **before** that last `$` is assigned to the current parameter

Result:

- Current parameter value: `abc$def$ghi`
- Following (fixed) parameter value: `$`

This behavior differs from the `next param` LengthType.  
If `next param` were used instead, the parser would stop at the **first** occurrence of `$`, and the current parameter would receive only:

```
abc
```

In summary, `last next param` ensures that the current parameter includes all content up to the **final occurrence** of the following parameter, making it useful when the data itself may contain the same delimiter multiple times.

### next param

The parameter has a variable length, which depends on the next (fixed-length) parameter in the response.

If the expected response will contain a number with a length up to 5 digits, followed by a point, you can define two parameters:

- A first one with a LengthType equal to “next param” to catch the number, and
- A second one with a LengthType equal to “fixed” to catch the point.

### other param

The length of the parameter will be inherited from another parameter.

The ID of that other parameter has to be specified in the id attribute. See [id](xref:Protocol.Params.Param.Interprete.LengthType-id).
