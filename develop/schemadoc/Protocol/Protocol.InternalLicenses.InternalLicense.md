---
metadata_version: 1
uid: Protocol.InternalLicenses.InternalLicense
description: "Reference the DataMiner connector protocol schema entry for InternalLicense element, including its documented structure, attributes, values, and constrain."
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

# InternalLicense element

Configures internal licensing of the specified type.

## Content Type

string

## Parent

[InternalLicenses](xref:Protocol.InternalLicenses)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[type](xref:Protocol.InternalLicenses.InternalLicense-type)||Yes||

## Remarks

Using this tag, elements running this protocol will not be counted towards the element license count.

Possible values:

- solution
