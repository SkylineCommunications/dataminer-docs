---
metadata_version: 1
uid: Protocol.Params.Param.Interprete.Sequence-noset
description: "Learn how the noset attribute must be set to true whenever a Sequence element is used in a DataMiner connector protocol."
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
