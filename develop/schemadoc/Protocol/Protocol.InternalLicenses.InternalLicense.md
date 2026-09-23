---
metadata_version: 1
uid: Protocol.InternalLicenses.InternalLicense
description: "Reference the DataMiner connector protocol schema entry for InternalLicense element, including its documented structure, attributes, values, and constrain."
content_type: schema
applies_to:
  - DataMiner
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
