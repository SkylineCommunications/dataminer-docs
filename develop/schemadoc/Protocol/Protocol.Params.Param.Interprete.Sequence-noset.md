---
metadata_version: 1
uid: Protocol.Params.Param.Interprete.Sequence-noset
description: "Reference the DataMiner connector protocol schema entry for noset attribute, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# noset attribute

Always use this attribute with value set to `true`.

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[Sequence](xref:Protocol.Params.Param.Interprete.Sequence)

## Examples

```xml
<Sequence noset="true">+:50;*:id:200</Sequence>
```
