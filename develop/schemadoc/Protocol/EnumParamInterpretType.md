---
uid: Protocol-EnumParamInterpretType
---

# EnumParamInterpretType simple type

Specifies the interpretation type.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|double|The parameter value will be processed as a number.|
|&nbsp;&nbsp;Enumeration|high nibble|The parameter value will be processed as the high nibble (i.e., first four bits) of a byte.|
|&nbsp;&nbsp;Enumeration|string|The parameter value will be processed as an ASCII string.|
