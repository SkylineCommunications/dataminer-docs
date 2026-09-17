---
metadata_version: 1
uid: Protocol-baseFor
description: "Reference the DataMiner connector protocol schema entry for baseFor attribute, including its documented structure, attributes, values, and constraints."
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

# baseFor attribute

Specifies the type of element for which this protocol serves as a base protocol.

## Content Type

string

## Parent

[Protocol](xref:Protocol)

## Remarks

In case a value is defined in this attribute, the protocol is considered a base protocol.

> [!NOTE]
> Another protocol can indicate that it is based on this base protocol by specifying this value in [ElementType](xref:Protocol.ElementType).

## Examples

```xml
<Protocol baseFor="Information Platform" xmlns="http://www.skyline.be/protocol">
```
