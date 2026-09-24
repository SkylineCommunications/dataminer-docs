---
metadata_version: 1
uid: Protocol.Params.Param-duplicateAs
description: "Learn how to use the duplicateAs attribute to show another parameter's value in one or more view table columns in a DataMiner connector protocol."
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
