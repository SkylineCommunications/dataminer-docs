---
metadata_version: 1
uid: Protocol.Description
description: "Reference the DataMiner connector protocol schema entry for Description element, including its documented structure, attributes, values, and constraints."
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

# Description element

Contains a description of the protocol.

## Type

string

## Parent

[Protocol](xref:Protocol)

## Remarks

In this tag, you can specify general information about the protocol. You could, for example, use this tag to specify that the protocol has been developed for elements running a specific firmware version.

In protocols of elements that are used in Automation, the contents of this tag must be unique.

## Examples

```xml
<Description>Controls a host using WMI</Description>
```
