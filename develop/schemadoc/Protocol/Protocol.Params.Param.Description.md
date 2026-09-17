---
metadata_version: 1
uid: Protocol.Params.Param.Description
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

Specifies the description of the parameter.

## Type

string

## Parent

[Param](xref:Protocol.Params.Param)

## Remarks

Typically, the parameter name refers to the technical name of the parameter, while the parameter description provides a more common name or description.

> [!NOTE]
> Preferably, the value of this tag should be unique throughout the protocol. Some special characters like single quotes (') or backslashes (\\) are allowed.

## Examples

```xml
<Description>RF Output</Description>
```
