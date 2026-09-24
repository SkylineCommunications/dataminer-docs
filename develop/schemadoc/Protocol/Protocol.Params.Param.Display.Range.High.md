---
metadata_version: 1
uid: Protocol.Params.Param.Display.Range.High
description: "Learn how the High element sets the maximum display range value or the maximum string length for a write parameter in a DataMiner connector protocol."
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
