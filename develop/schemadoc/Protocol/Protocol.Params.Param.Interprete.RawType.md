---
uid: Protocol.Params.Param.Interprete.RawType
---

# RawType element

Specifies which type of content is allowed in the parameter.

## Type

[EnumParamInterpretRawType](xref:Protocol-EnumParamInterpretRawType)

## Parent

[Interprete](xref:Protocol.Params.Param.Interprete)

## Remarks

If an incoming parameter value does not match the expected rawtype, DataMiner will not process it. The rawtype setting can therefore be considered as a kind of filter.

Contains one of the following predefined values, detailed in the sections below:

### bcd

BCD numbers (Binary Code Decimal)

Example:

```xml
<RawType>bcd</RawType>
```

### double

Decimals of type “double”.

Example:

```xml
<RawType>double</RawType>
```

> [!NOTE]
> If RawType is set to "double", the Interprete/LengthType should be set to "fixed" and Interprete/Length should either be 4 (float) or 8 (double).

### numeric text

DataMiner will try to convert the hex value to a number using string conversion.

Example: If the hex value is 31, the ASCII conversion gives 1. The parameter will contain 1 (result will be the same as what you see in the ASCII part of the stream).

The following characters and digits:
- 0-9
- \+
- \-
- \.
- \,
- e or E or ' ' (space)
- a-f or A-F (if Protocol.Params.Param.Interprete.Base is 16)

In the following example, the value -3 will be saved in database as 2D 33:

```xml
<RawType>numeric text</RawType>
```

### only others

Values made up of different types.

See [Protocol.Params.Param.Interprete.Others](xref:Protocol.Params.Param.Interprete.Others).

### other

ASCII characters, both numeric and alphanumeric.

Example:

```xml
<RawType>other</RawType>
```

### signed number

When a next param is defined in Interprete.Type, the result will be the same as with unsigned number. When a fixed length is defined in Interprete.Type, the first half of the values will be positive number, and second half will be negative number.

Numbers between -128 and 127.

In the following example, the value -3 will be saved in database as FDFFFFFF and the value 3 will be 03000000:

```xml
<RawType>signed number</RawType>
```

> [!NOTE]
> If Interprete/Type is set to "double", RawType is set to "signed number", and Length is set to "fixed", then length must be set to either 1, 2, 4, or 8.

### text

Alphanumeric ASCII characters only.

Text consisting of the following characters:
- 0-9
- A-Z
- a-z
- \-
- .
- ;
- ,
- ?
- !
- a space (“ “)

Example:


```xml
<RawType>text</RawType>
```

### unsigned number

DataMiner will convert the hex value to a number using a decimal conversion.

Example: If the hex value is 31, the decimal conversion gives 49. The parameter will contain 49 (result will be the same as if you use your calculator to convert from hex to dec).

Numbers between 0 and 255.

In the following example, the value 1 will be saved in database as 01:

```xml
<RawType>unsigned number</RawType>
```

> [!NOTE]
> If Interprete/Type is set to "double", RawType is set to "signed number", and Length is set to "fixed", then length must be set to either 1, 2, 4, or 8.
