---
uid: Protocol.Params.Param.Interprete.RawType
---

# RawType element

Specifies how device data should be interpreted.
todo: mention that this mostly applies to serial connections
todo: for other connections it is recommended to always use the **numeric text double** and **other string** combinations

Example:

Given a parameter with these types:
```xml
<RawType>numeric text</RawType>
<Type>double</Type>
```
If a device sends the following binary data:`2D 31 32`.
The _rawtype_ **numeric text** specifies that the data is a string ("-12") that can be parsed to the number -12.
When accessed, such as retrieving in a QAction, the value gets converted to a **double** as specified by _type_.

## Type

[EnumParamInterpretRawType](xref:Protocol-EnumParamInterpretRawType)

## Parent

[Interprete](xref:Protocol.Params.Param.Interprete)

## Remarks
Before DataMiner 9.5,
if an incoming parameter value did not match the expected rawtype, DataMiner would not process it. 
The rawtype setting could therefore have been considered as a kind of filter.

### bcd
todo: how are the raw bytes intepreted
BCD numbers (Binary Code Decimal)

### double
todo: how are the raw bytes intepreted
Decimals of type “double”.

> [!IMPORTANT]
> If RawType is set to "double", the Interprete/LengthType should be set to "fixed" and Interprete/Length should either be 4 (float) or 8 (double).

### numeric text

Data is treated as an ASCII-encoded text representing numbers.
DataMiner will try to parse the text to a number.

Example: If the binary value is 0x31, it gets decoded to the text "1". 
The text then gets parsed to the number 1.

The text is allowed to have the following characters and digits:
- 0-9
- \+
- \-
- \.
- \,
- e or E or ' ' (space)
- a-f or A-F (if Protocol.Params.Param.Interprete.Base is 16)

### only others
todo: how are the raw bytes intepreted
Values made up of different types.

See Protocol.Params.Param.Interprete.[Others](xref:Protocol.Params.Param.Interprete.Others).

> [!NOTE]
> only others is deprecated. It can still be used but is not recommended for new developments. 
> We advise using other in combination with [exception](xref:Protocol.Params.Param.Interprete.Exceptions.Exception) instead.

### other
todo: how are the raw bytes intepreted
todo: any difference between normal and unicode protocol?
any characters, both alphanumeric and non-alphanumeric.

### signed number
todo: how are the raw bytes intepreted
When a next param is defined in Interprete.Type, the result will be the same as with unsigned number. When a fixed length is defined in Interprete.Type, the first half of the values will be positive number, and second half will be negative number.


> [!NOTE]
> If Interprete/Type is set to "double", 
> RawType is set to "signed number", 
> and Length is set to "fixed", 
> then length must be set to either 1, 2, 4, or 8.

### text
todo: how are the raw bytes intepreted
todo: any difference between normal and unicode protocol?
Alphanumeric ASCII characters and punctuation marks only.

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

> [!NOTE]
> text is depricated. 
> It can still be used but is not recommended for new developments. We advise using other instead.

### unsigned number
todo: how are the raw bytes intepreted
DataMiner will convert the value to a number using a decimal conversion.

Example: If the binary value is 0x31, the decimal conversion gives 49. The parameter will contain 49 (result will be the same as if you use your calculator to convert from hex to dec).

> [!NOTE]
> If Interprete/Type is set to "double", 
> RawType is set to "signed number", 
> and Length is set to "fixed", 
> then length must be set to either 1, 2, 4, or 8.
