---
uid: Protocol.Params.Param-duplicateAs
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
