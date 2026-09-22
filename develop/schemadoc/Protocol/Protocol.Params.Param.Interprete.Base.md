---
metadata_version: 1
uid: Protocol.Params.Param.Interprete.Base
description: "Reference the DataMiner connector protocol schema entry for Base element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# Base element

Specifies the numeral system (decimal, hexadecimal, etc.).

## Type

unsignedInt

## Parent

[Interprete](xref:Protocol.Params.Param.Interprete)

## Remarks

Contains a number between 2 and 36. Default: 10

> [!NOTE]
> In case of base 36, the letters “a” through “z” (or “A” through “Z”) are assigned the values 10 through 35.

## Examples

```xml
<Base>10</Base>
```
