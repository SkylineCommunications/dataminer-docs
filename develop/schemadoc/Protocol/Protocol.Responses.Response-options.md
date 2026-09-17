---
metadata_version: 1
uid: Protocol.Responses.Response-options
description: "Reference the DataMiner connector protocol schema entry for options attribute, including its documented structure, attributes, values, and constraints."
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

# options attribute

Defines a number of options.

## Content Type

string

## Parent

[Response](xref:Protocol.Responses.Response)

## Remarks

In this attribute, you can specify the following options.

### Connection

This option allows you to specify the ID of the connection (in case of multiple ports).

Adding the connection ID at response level is only done in protocols of type “smart-serial” or “websocket”.

Example:

```xml
<Response id="1" options="Connection:1">
```
