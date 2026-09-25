---
metadata_version: 1
uid: Protocol-EnumTrapOIDType
description: "Review the allowed values for the EnumTrapOIDType simple type and what each value represents in DataMiner connector protocols."
---

# EnumTrapOIDType simple type

Specifies the trap OID type.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|auto|The resulting OID is the combination of VendorOID + DeviceOID + Param ID.|
|&nbsp;&nbsp;Enumeration|complete|The complete OID is specified in TrapOID.|
|&nbsp;&nbsp;Enumeration|composed|The resulting OID is the combination of VendorOID + DeviceOID + the value specified in TrapOID.|
|&nbsp;&nbsp;Enumeration|wildcard|When set to wildcard, you can use an asterisk (*) in the OID in order to capture all traps that match this OID.|
