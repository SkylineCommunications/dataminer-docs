---
uid: Protocol-EnumSNMP
---

# EnumSNMP simple type

Specifies the MIB OID generation type.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|auto|The MIB will assign an OID to each parameter according to its number in the protocol.|
|&nbsp;&nbsp;Enumeration|false|The MIB will not automatically create an OID for each parameter.|
