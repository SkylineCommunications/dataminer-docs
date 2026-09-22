---
metadata_version: 1
uid: Protocol.Params.Param.Interprete.Rounding
description: "Reference the DataMiner connector protocol schema entry for Rounding element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# Rounding element

<!-- RN 13519 -->

Specifies how the parameter value is rounded.

Default: down.

## Type

[EnumRounding](xref:Protocol-EnumRounding)

## Parent

[Interprete](xref:Protocol.Params.Param.Interprete)

## Examples

```xml
<Interprete>
   <RawType>unsigned number</RawType>
   <LengthType>fixed</LengthType>
   <Length>4</Length>
   <Type>double</Type>
   <Rounding>halfToInfinity</Rounding>
</Interprete>
```
