---
metadata_version: 1
uid: Protocol.HTTP.Session-userName
description: "Reference the DataMiner connector protocol schema entry for userName attribute, including its documented structure, attributes, values, and constraints."
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

# userName attribute

If you set loginMethod to “credentials”, then use this attribute to specify the user name.

It is possible to specify the ID of a parameter that will contain the user name.

## Content Type

string

## Parent

[Session](xref:Protocol.HTTP.Session)

## Remarks

> [!NOTE]
> In case the parameters referred to by the username and password attributes are not filled in, the resulting behavior will be as if there was no loginMethod specified (i.e., no authentication takes place).
