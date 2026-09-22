---
metadata_version: 1
uid: Protocol.ExportRules.ExportRule-table
description: "Reference the DataMiner connector protocol schema entry for table attribute, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# table attribute

Specifies the ID of table parameter that will generate the DVEs.

## Content Type

[TypeWildcardOrNumber](xref:Protocol-TypeWildcardOrNumber)

## Parent

[ExportRule](xref:Protocol.ExportRules.ExportRule)

## Remarks

Use a wildcard (*) if the rule needs to be applied on all of the tables that generate DVEs.

## Examples

In the example below, the first rule will be executed on all the tables, but the second one will only be executed on table 100:

```xml
<ExportRule table="*" />
<ExportRule table="100" />
```
