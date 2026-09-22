---
metadata_version: 1
uid: Protocol.ExportRules.ExportRule-tag
description: "Reference the DataMiner connector protocol schema entry for tag attribute, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# tag attribute

Specifies the XML element on which to apply this rule.

## Content Type

[TypeNonEmptyString](xref:Protocol-TypeNonEmptyString)

## Parent

[ExportRule](xref:Protocol.ExportRules.ExportRule)

## Examples

```xml
<ExportRule tag="Protocol/Params/Param/Name" />
```
