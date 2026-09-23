---
metadata_version: 1
uid: Protocol.Params.Param.Display.Range.High
description: "Reference the DataMiner connector protocol schema entry for High element, including its documented structure, attributes, values, and constraints."
---

# High element

Specifies the upper limit of the range, i.e., the maximum value of the parameter.

## Type

decimal

## Parent

[Range](xref:Protocol.Params.Param.Display.Range)

## Remarks

When set on a write parameter (Param.Type = "write") of type "string" (Param.Interprete.Type = "string"), this value defines the maximum number of characters that can be provided.

## Examples

```xml
<High>18</High>
```
