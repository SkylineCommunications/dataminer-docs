---
metadata_version: 1
uid: DMSScript.Credentials.Credential.Type
description: "Reference the DataMiner Automation script schema entry for Type element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaAutomationScript
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

# Type element

Specifies the type of the credentials.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|UserNameAndPassword|A set of credentials holding a user name and a password.|
|&nbsp;&nbsp;Enumeration|Token|A set of credentials holding a single access token.|

## Parent

[Credential](xref:DMSScript.Credentials.Credential)

## Remarks

The type must match the type of the linked credentials in the [Credentials Library](xref:Credentials_Library). If the type is missing or not recognized, the credentials cannot be used.
