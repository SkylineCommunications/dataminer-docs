---
uid: Protocol.InternalLicenses.InternalLicense
description: "Use the InternalLicense element in a DataMiner protocol to configure internal licensing and exclude elements from the element license count."
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
