---
uid: Protocol.Params.Param-duplicateAs
description: "Use the duplicateAs attribute in a DataMiner protocol to show another parameter's value in one or more view table columns."
---

# duplicateAs attribute

Takes the value of another parameter and displays it in a column of a view table.

## Content Type

[TypeCommaSeparatedNumbers](xref:Protocol-TypeCommaSeparatedNumbers)

## Parent

[Param](xref:Protocol.Params.Param)

## Remarks

In case this value needs to be displayed in multiple columns the parameter IDs need to be separated by a comma (',').

## Examples

```xml
<Param id="1" duplicateAs="6002,6103">
```
