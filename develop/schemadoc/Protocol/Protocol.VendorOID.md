---
metadata_version: 1
uid: Protocol.VendorOID
description: "Reference the DataMiner connector protocol schema entry for VendorOID element, including its documented structure, attributes, values, and constraints."
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

# VendorOID element

Specifies the vendor OID of the monitored data source.

## Type

[TypeVendorOID](xref:Protocol-TypeVendorOID)

## Parent

[Protocol](xref:Protocol)

## Remarks

This OID, to be provided either by the vendor of the data source or (on request) by Skyline, must be unique, as it is used to define MIB objects for all elements using the protocol. Typically, the vendor OID will start with the prefix 1.3.6.1.4.1, which identifies private enterprises.

## Examples

```xml
<VendorOID>1.3.6.1.4.1.8813.2.67</VendorOID>
```

In the example above, the numbers are to be interpreted as follows:

iso.org.dod.internet.private.enterprise.Skyline Communications.thirdparty.Microsoft
