---
metadata_version: 1
uid: Protocol-EnumTrapOIDType
description: "Reference the DataMiner connector protocol schema entry for EnumTrapOIDType simple type, including its documented structure, attributes, values, and const."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
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
