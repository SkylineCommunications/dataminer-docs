---
metadata_version: 1
uid: Protocol.App
description: "Reference the DataMiner connector protocol schema entry for App element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# App element

If you tag a protocol as “app”, then all elements based on that protocol will appear in the Apps list of DataMiner Cube (in the Apps tab of the Surveyor).

## Parent

[Protocol](xref:Protocol)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[type](xref:Protocol.App-type)|[TypeNonEmptyString](xref:Protocol-TypeNonEmptyString)||Specifies the name of the app.|
