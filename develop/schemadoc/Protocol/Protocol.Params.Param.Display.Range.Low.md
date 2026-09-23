---
metadata_version: 1
uid: Protocol.Params.Param.Display.Range.Low
description: "Reference the DataMiner connector protocol schema entry for Low element, including its documented structure, attributes, values, and constraints."
---

# Low element

Specifies the lower limit of the range, i.e., the minimum value of the parameter.

## Type

decimal

## Parent

[Range](xref:Protocol.Params.Param.Display.Range)

## Remarks

When set on a write parameter (Param.Type = "write") of type "string" (Param.Interprete.Type = "string"), this value defines the minimum number of characters that must be provided.

## Examples

```xml
<Low>3</Low>
```
