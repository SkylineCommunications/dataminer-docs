---
metadata_version: 1
uid: Protocol.Params.Param.Interprete.DefaultValue
description: "Reference the DataMiner connector protocol schema entry for DefaultValue element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# DefaultValue element

<!-- RN 8776 -->

Specifies the default value to be assigned to the parameter if it is empty after startup.

## Type

string

## Parent

[Interprete](xref:Protocol.Params.Param.Interprete)

## Examples

```xml
<Interprete>
   <RawType>other</RawType>
   <LengthType>next param</LengthType>
   <Type>string</Type>
   <DefaultValue>This is the default value</DefaultValue>
</Interprete>
```

> [!NOTE]
> Default values can only be assigned to standalone parameters. They do not work for table columns.
