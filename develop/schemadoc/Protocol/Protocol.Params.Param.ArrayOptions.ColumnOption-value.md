---
uid: Protocol.Params.Param.ArrayOptions.ColumnOption-value
description: "Use the value attribute in a DataMiner protocol to set concatenation columns or an autoincrement offset based on column type."
---

# value attribute

The interpretation of this `value` attribute depends on the value of the `type` attribute:

- If the `type` value is `concatenation`, the `value` attribute is interpreted as the enumeration of the columns to be concatenated.
- If the `type` value is `autoincrement`, the `value` attribute is interpreted as the offset for the automatic increment of the indexes.

## Content Type

string

## Parent

[ColumnOption](xref:Protocol.Params.Param.ArrayOptions.ColumnOption)
