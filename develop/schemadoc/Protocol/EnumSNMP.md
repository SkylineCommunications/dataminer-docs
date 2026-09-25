---
metadata_version: 1
uid: Protocol-EnumSNMP
description: "Review the allowed values for the EnumSNMP simple type and what each value represents in DataMiner connector protocols."
---

# EnumSNMP simple type

Specifies the MIB OID generation type.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|auto|The MIB will assign an OID to each parameter according to its number in the protocol.|
|&nbsp;&nbsp;Enumeration|false|The MIB will not automatically create an OID for each parameter.|
