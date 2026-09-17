---
metadata_version: 1
uid: Protocol.Groups.Group-threadId
description: "Reference the DataMiner connector protocol schema entry for threadId attribute, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
lifecycle: active
applies_to:
  - DataMiner
version: 10.4.9
owner: unknown
review_status: needs_update
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
---

# threadId attribute

Specifies the ID of the thread that should execute the group.

## Content Type

int

## Parent

[Group](xref:Protocol.Groups.Group)

## Remarks

If you try to execute a group on a thread that does not exist, the group will be executed on the main protocol thread.

As a specific thread can have multiple connections linked to it, you will also need to specify the [connection](xref:Protocol.Groups.Group-connection). If this is omitted, the thread will use the main connection with ID 0.

*Feature introduced in DataMiner 10.4.9/10.5.0 (RN 38887).*
