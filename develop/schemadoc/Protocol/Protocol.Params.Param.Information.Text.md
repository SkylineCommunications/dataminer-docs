---
uid: Protocol.Params.Param.Information.Text
description: "Use the Text element in a DataMiner protocol to set the title displayed in a parameter information tooltip."
---

# Text element

Specifies the title of the tooltip.

> [!NOTE]
> This tag is rarely used because, by default, the parameter [Description](xref:Protocol.Params.Param.Description) will be used as the tooltip title. In most cases, this is the desired behavior, so we recommend avoiding a redundant `Information.Text` tag.

## Type

string

## Parent

[Information](xref:Protocol.Params.Param.Information)

## Examples

```xml
<Text>This is the title of the tooltip.</Text>
```
