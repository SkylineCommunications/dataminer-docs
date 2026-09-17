---
metadata_version: 1
uid: Protocol.HTTP.Session.Connection-ignoreTimeout
description: "Reference the DataMiner connector protocol schema entry for ignoreTimeout attribute, including its documented structure, attributes, values, and constrain."
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

# ignoreTimeout attribute

<!-- RN 10543 -->

If the HTTP connection should ignore timeout, set this attribute to *true*.

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[Connection](xref:Protocol.HTTP.Session.Connection)

## Remarks

This works in a similar way as the serial pair [ignoreTimeout](xref:Protocol.Pairs.Pair-options#ignoretimeout) option.

Default value: false.
