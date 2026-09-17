---
metadata_version: 1
uid: Protocol-EnumOIDType
description: "Reference the DataMiner connector protocol schema entry for EnumOIDType simple type, including its documented structure, attributes, values, and constrain."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
lifecycle: active
applies_to:
  - DataMiner
version: unknown
owner: unknown
review_status: needs_update
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
---

# EnumOIDType simple type

Specifies the OID type.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|auto|The resulting OID is the combination of VendorOID + DeviceOID + Param ID.|
|&nbsp;&nbsp;Enumeration|complete|The resulting OID is the SNMP.OID value of this parameter.|
|&nbsp;&nbsp;Enumeration|composed|The resulting OID is the combination of VendorOID + DeviceOID + SNMP.OID value of this parameter.|
|&nbsp;&nbsp;Enumeration|wildcard|The resulting OID is the SNMP.OID value of this parameter prepended with the content of the parameter referred to by the **id** attribute.|
