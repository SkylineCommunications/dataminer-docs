---
metadata_version: 1
uid: Protocol.PortSettings.FlushPerDatagram
description: "Reference the DataMiner connector protocol schema entry for FlushPerDatagram element, including its documented structure, attributes, values, and constrai."
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

# FlushPerDatagram element

<!-- RN 28999 -->

When this option is set to true, any datagram received on the connection will be forwarded to SLProtocol immediately.

## Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[PortSettings](xref:Protocol.PortSettings)

## Remarks

Only applicable for smart-serial connections of type UDP.

> [!NOTE]
> When this option is used on a connection, you should use a response consisting of only a next param for that connection.

## Examples

```xml
<PortSettings>
   <FlushPerDatagram>true</FlushPerDatagram>
</PortSettings>
```
