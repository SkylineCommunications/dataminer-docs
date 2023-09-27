---
uid: Protocol-EnumParamInterpretLengthType
---

# EnumParamInterpretLengthType simple type

Specifies the length type.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|fixed|The parameter has a fixed length, which has to be defined in the /Protocol/Params/Param/Interprete/Length element.|
|&nbsp;&nbsp;Enumeration|last next param|The parameter has a variable length, which depends on the last instance of the next (fixed-length) parameter in the response.|
|&nbsp;&nbsp;Enumeration|next param|The parameter has a variable length, which depends on the next (fixed-length) parameter in the response.|
|&nbsp;&nbsp;Enumeration|other param|The length of the parameter will be inherited from another parameter.|
