---
metadata_version: 1
uid: Protocol.HTTP.Session-keepAlive
description: "Reference the DataMiner connector protocol schema entry for keepAlive attribute, including its documented structure, attributes, values, and constraints."
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

# keepAlive attribute

<!-- RN 9929 -->

Specifies whether the session should be kept alive.

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[Session](xref:Protocol.HTTP.Session)

## Remarks

By default, DataMiner supports HTTP keep-alive, also known as HTTP connection reuse.

The keepAlive attribute of a Session can be set to true or false:

- If set to "false" (default setting), DataMiner will open the session, execute all requests and close the session.
- If set to "true", DataMiner will leave the session open from the first request until the element stops.

> [!NOTE]
> In legacy protocols, this option is disabled by default.

## Examples

```xml
<Session id="1" keepAlive="true">
```
