---
metadata_version: 1
uid: Protocol.ExportRules.ExportRule-attribute
description: "Reference the DataMiner connector protocol schema entry for attribute attribute, including its documented structure, attributes, values, and constraints."
content_type: schema
applies_to:
  - DataMiner
---

# attribute attribute

Specifies the attribute of the XML element specified in the "tag" attribute on which to apply this rule.

## Content Type

[TypeNonEmptyString](xref:Protocol-TypeNonEmptyString)

## Parent

[ExportRule](xref:Protocol.ExportRules.ExportRule)

## Examples

```xml
<ExportRule table="300" tag="Protocol/Display" attribute="pageOrder" value="Details;Services" />
```
