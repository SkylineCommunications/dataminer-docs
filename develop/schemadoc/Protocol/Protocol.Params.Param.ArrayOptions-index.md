---
metadata_version: 1
uid: Protocol.Params.Param.ArrayOptions-index
description: "Reference the DataMiner connector protocol schema entry for index attribute, including its documented structure, attributes, values, and constraints."
content_type: schema
applies_to:
  - DataMiner
---

# index attribute

Defines which column contains the primary keys.

## Content Type

unsignedInt

## Parent

[ArrayOptions](xref:Protocol.Params.Param.ArrayOptions)

## Remarks

The column containing the primary keys must be of type “String”. Once a row is created, the primary key cannot be changed.

## Examples

```xml
<ArrayOptions index="0">
  <ColumnOption idx="0" pid="1001" type="custom"/>
  <ColumnOption idx="1" pid="1002" type="custom"/>
  <ColumnOption idx="2" pid="1003" type="custom"/>
</ArrayOptions>
```

## See also

[Protocol.Params.Param.Interprete.Type](xref:Protocol.Params.Param.Interprete.Type)
