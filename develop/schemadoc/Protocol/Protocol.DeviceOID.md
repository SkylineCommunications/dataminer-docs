---
metadata_version: 1
uid: Protocol.DeviceOID
description: "Reference the DataMiner connector protocol schema entry for DeviceOID element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# DeviceOID element

Specifies an OID for the device that will be managed with the protocol.

## Type

unsignedInt

## Parent

[Protocol](xref:Protocol)

## Remarks

The device OID has to be specified right after the vendor OID. Note that the complete OID, i.e., the vendor OID followed by the device OID, must be unique. This means that for each device from the same vendor you have to use a new device OID.

## Examples

```xml
<DeviceOID>2</DeviceOID>
```
