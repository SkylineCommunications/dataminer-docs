---
uid: Protocol.ExportRules.ExportRule-attribute
description: "Use the 'attribute' attribute of ExportRule in a DataMiner protocol to specify the XML attribute to which an export rule applies."
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
