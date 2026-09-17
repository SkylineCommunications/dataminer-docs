---
metadata_version: 1
uid: Protocol.SNMP-includepages
description: "Reference the DataMiner connector protocol schema entry for includepages attribute, including its documented structure, attributes, values, and constraint."
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

# includepages attribute

If set to *true*, the MIB of the protocol will contain several submaps: one for each page defined in the protocol.

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[SNMP](xref:Protocol.SNMP)

## Remarks

Contains one of the following values:

|Value|Description
|--- |--- |
|false|The MIB will not automatically create an OID for each parameter.|
|auto|The MIB will assign an OID to each parameter according to its number in the protocol.|

> [!NOTE]
> When the main connection of the protocol is SNMP, the parameters will always be included in the generated MIB regardless of the value specified here.

## Examples

In the following example, when a page called “General” contains a number of parameters, the MIB will automatically create a submap named “General”, which will contain all the parameters on that page.

```xml
<SNMP includepages="true">auto</SNMP>
```
