---
metadata_version: 1
uid: Protocol.Display-pageOptions
description: "Reference the DataMiner connector protocol schema entry for pageOptions attribute, including its documented structure, attributes, values, and constraints."
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

# pageOptions attribute

Used for EPM elements in order to disable the possibility to open the Data Display page of the element.

## Content Type

string

## Parent

[Display](xref:Protocol.Display)

## Remarks

Used for EPM elements in order to disable the possibility to open the Data Display page of the element. Otherwise, if the Data Display page is opened, the cross-driver table view is entirely constructed, which significantly increases the load on both the server and the client.

> [!NOTE]
> The Administrator user will still be able to load the Data Display page manually.

## Examples

```xml
<Display type="element manager" pageOptions="*;CPEOnly" />
```
