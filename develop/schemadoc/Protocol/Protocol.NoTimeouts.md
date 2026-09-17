---
metadata_version: 1
uid: Protocol.NoTimeouts
description: "Reference the DataMiner connector protocol schema entry for NoTimeouts element, including its documented structure, attributes, values, and constraints."
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

# NoTimeouts element

<!-- RN 8775 -->

Groups NoTimeout elements.

## Parent

[Protocol](xref:Protocol)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[NoTimeout](xref:Protocol.NoTimeouts.NoTimeout)|[0, *]|Indicates that the specified error (response value) should not cause a timeout.|

## Examples

```xml
<NoTimeouts>
   <NoTimeout>NO SUCH NAME</NoTimeout>
   <NoTimeout>NO SUCH OBJECT</NoTimeout>
   <NoTimeout>TIMEOUT</NoTimeout>
</NoTimeouts>
```
