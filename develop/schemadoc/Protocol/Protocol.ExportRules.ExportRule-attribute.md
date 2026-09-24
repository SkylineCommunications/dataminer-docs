---
metadata_version: 1
uid: Protocol.ExportRules.ExportRule-attribute
description: "Learn how the ExportRule attribute named attribute selects an XML attribute to change in a DataMiner connector protocol."
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
