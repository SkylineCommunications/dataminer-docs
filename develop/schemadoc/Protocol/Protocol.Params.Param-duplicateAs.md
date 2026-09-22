---
metadata_version: 1
uid: Protocol.Params.Param-duplicateAs
description: "Reference the DataMiner connector protocol schema entry for duplicateAs attribute, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# duplicateAs attribute

Takes the value of another parameter and displays it in a column of a view table.

## Content Type

[TypeCommaSeparatedNumbers](xref:Protocol-TypeCommaSeparatedNumbers)

## Parent

[Param](xref:Protocol.Params.Param)

## Remarks

In case this value needs to be displayed in multiple columns the parameter IDs need to be separated by a comma (',').

## Examples

```xml
<Param id="1" duplicateAs="6002,6103">
```
