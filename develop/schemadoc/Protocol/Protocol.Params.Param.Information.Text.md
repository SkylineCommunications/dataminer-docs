---
uid: Protocol.Params.Param.Information.Text
description: "Use the Text element in a DataMiner protocol to set the title displayed in a parameter information tooltip."
---

# Text element

Specifies the title of the tooltip.

> [!NOTE]
> The `Text` element is rarely used. By default, the parameter [Description](xref:Protocol.Params.Param.Description) gets used as the tooltip title. If this is the desired behavior, adding a redundant `Information.Text` tag should be avoided.

## Type

string

## Parent

[Information](xref:Protocol.Params.Param.Information)

## Examples

```xml
<Text>This is the title of the tooltip.</Text>
```
